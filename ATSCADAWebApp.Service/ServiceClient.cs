using System;
using System.Linq;
using System.ServiceModel;

namespace ATSCADAWebApp.Service
{
    /// <summary>
    /// Đối tượng Singleton quản lý Client kết nối tới iWebService
    /// </summary>
    public class ServiceClient
    {

        #region FILEDS

        private static volatile ServiceClient instance;

        private static readonly object keyLock = new object();

        private ChannelFactory<IATSCADAService> channelFactory;

        private IATSCADAService channel;

        private string address;

        #endregion

        #region PROPERTIES

        public bool IsActive { get; private set; }

        #endregion

        #region CONSTRUCTORS

        public static ServiceClient Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (keyLock)
                    {
                        if (instance == null)
                        {
                            instance = new ServiceClient();
                        }
                    }
                }
                return instance;
            }
        }

        private ServiceClient()
        {
        }
        /// <summary>
        /// Hàm khởi tạo Client
        /// </summary>
        /// <param name="address"> Địa chỉ của Service. Format: IPAddress:Port </param>
        public void Start(string address)
        {
            // Tạo Custom Binding. Xác thực Client (UserName, Password) trên tầng Transport
            this.address = address;

            var binding = new CustomNetTcpBinding();
            binding.OpenTimeout = TimeSpan.FromMinutes(2);
            binding.SendTimeout = TimeSpan.FromMinutes(2);
            binding.ReceiveTimeout = TimeSpan.FromMinutes(10);

            var endpointAddress = new EndpointAddress($"net.tcp://{this.address}/ATSCADAService");
            this.channelFactory = new ChannelFactory<IATSCADAService>(binding, endpointAddress);
            this.channelFactory.Credentials.UserName.UserName = Account.UserName; // Gán UserName cho Client
            this.channelFactory.Credentials.UserName.Password = Account.Password; // Gán Password cho Client

            // Tạo Client kết nối
            this.channel = this.channelFactory.CreateChannel();
            IsActive = true;
        }

        /// <summary>
        /// Phương thức đọc giá trị các Tag. Được gọi bởi DataController
        /// </summary>
        /// <param name="names"> Danh sách Tag (name) cần đọc </param>
        /// <returns> Gói dữ liệu chứa giá trị của Tag </returns>
        public ResultPackage[] Read(string[] names)
        {
            try
            {
                if (!IsActive) return default;
                if (names is null) return default;
                // Mã hóa Name trước khi truyền
                var result = this.channel?.Read(names.Select(x => x.EncryptAddress()).ToArray());
                if (result is null) return default;
                // Giải mã gói tin
                return result.Decrypt();
            }
            catch
            {
                HandleException();
                return null;
            }
        }

        /// <summary>
        /// Phương thức ghi giá trị
        /// </summary>
        /// <param name="writeParams"> Danh sách tham số truyền, gồm Name (Tên của Tag) và Value (giá trị cần ghi) </param>
        /// <returns> Gói dữ liệu trả về kết quả ghi (Status = Good: ghi thành công, Status = Bad: ghi thất bại/ Tag không tồn tại) </returns>
        public ResultPackage[] Write(WriteParam[] writeParams)
        {
            try
            {
                if (!IsActive) return default;
                if (writeParams is null) return default;
                // // Mã hóa WriteParam trước khi truyền
                var result = this.channel?.Write(writeParams.Encrypt());
                // Giải mã gói tins
                return result.Decrypt();
            }
            catch
            {
                HandleException();
                return null;
            }
        }

        /// <summary>
        /// Hàm kiểm tra lỗi Service
        /// </summary>
        public void HandleException()
        {
            try
            {
                if (this.channel is ICommunicationObject communicationObject)
                {
                    // Nếu Client bị lỗi/mất kết nối...
                    if (communicationObject.State == CommunicationState.Faulted ||
                        communicationObject.State == CommunicationState.Closed)
                    {
                        try
                        {
                            IsActive = false;
                            // Đóng, hủy kết nối hiện tại...
                            this.channelFactory.Close();
                            communicationObject?.Close();
                            communicationObject?.Abort();
                        }
                        catch 
                        {
                            try
                            {
                                communicationObject?.Close();
                                communicationObject?.Abort();
                            }
                            catch { }
                        }
                        finally
                        {
                            // Và tạo ra kết nối mới
                            Start(this.address);
                        }
                    }
                }
            }
            catch
            {
                return;
            }
        }

        #endregion
    }
}
