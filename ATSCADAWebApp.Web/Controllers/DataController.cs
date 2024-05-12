using ATSCADAWebApp.Model;
using ATSCADAWebApp.Service;
using Newtonsoft.Json;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ATSCADAWebApp.Web.Controllers
{
    public class DataController : Controller
    {
        protected RootRepository RootRepository => RootRepository.Instance;

        private ServiceClient ServiceClient => ServiceClient.Instance;

        /// <summary>
        /// Phương thức đọc (các) Tag. Được gọi bởi fetch Browser
        /// </summary>
        /// <returns></returns>
        [HttpPost]        
        public async Task<JsonResult> Read()
        {
            try
            {
                // Kiểm tra, khởi tạo kết nối
                StartServiceClient();
                // Lấy tham số đầu vào qua Stream Request
                var names = GetPram<string[]>(Request.InputStream);
                if (names is null || names.Length == 0) throw new System.Exception();

                var result = await Task.Run(() => ServiceClient.Read(names));
                return new JsonResult()
                {
                    Data = new { Status = true, Result = result },
                    ContentType = "application/json",
                    ContentEncoding = Encoding.UTF8,
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                    MaxJsonLength = int.MaxValue
                };
            }
            catch
            {
                return Json(new { Status = false }, JsonRequestBehavior.AllowGet);
            }
        }
        /// <summary>
        /// Phương thức ghi (các) Tag. Được gọi bởi fetch Browser
        /// </summary>
        /// <returns></returns>
        [HttpPost]        
        public async Task<JsonResult> Write()
        {
            try
            {
                // Kiểm tra, khởi tạo kết nối
                StartServiceClient();
                // Lấy tham số đầu vào qua Stream Request
                var writeParams = GetPram<WriteParam[]>(Request.InputStream);
                if (writeParams is null || writeParams.Length == 0) throw new System.Exception();

                var result = await Task.Run(() => ServiceClient.Write(writeParams));
                return new JsonResult()
                {
                    Data = new { Status = true, Result = result },
                    ContentType = "application/json",
                    ContentEncoding = Encoding.UTF8,
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                    MaxJsonLength = int.MaxValue
                };
            }
            catch
            {
                return Json(new { Status = false }, JsonRequestBehavior.AllowGet);
            }
        }
        /// <summary>
        /// Trả về tham số qua Stream Request. Tối ưu cho trường hợp tham số có dữ liệu lớn
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="stream"></param>
        /// <returns></returns>
        private T GetPram<T>(Stream stream)
        {
            stream.Seek(0, SeekOrigin.Begin);
            var json = new StreamReader(stream).ReadToEnd();
            return JsonConvert.DeserializeObject<T>(json);
        }
        /// <summary>
        /// Phương thức kiểm tra, khởi tạo kết nối
        /// </summary>
        private void StartServiceClient()
        {
            if (!ServiceClient.IsActive)
            {
                // Address, Port. 
                var service = RootRepository.Application.Service;                               
                ServiceClient.Start($"{service.Address}:{service.Port}");
            }
        }
    }
}