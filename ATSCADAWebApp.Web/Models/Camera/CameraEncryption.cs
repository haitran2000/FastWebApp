using ATSCADAWebApp.Web.Models.Camera;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ATSCADAWebApp.Web.Models
{
    public class CameraEncryption
    {
        #region FIELDS

        private string nonce;

        private string appId;

        private string appSecret;

        private string deviceId;

        private string signStr;

        private string sign;

        #endregion

        #region CONSTRUCTORS

        public CameraEncryption(CameraInput cameraParam)
        {
            this.appId = cameraParam.AppID;
            this.appSecret = cameraParam.AppSecret;
            this.deviceId = cameraParam.DeviceID;
        }

        #endregion

        #region METHODS

        public async Task<string> AccessToken()
        {
            try
            {
                var time = this.GetTime();

                nonce = Guid.NewGuid().ToString();
                signStr = "time:" + time + ",nonce:" + nonce + ",appSecret:" + appSecret;
                sign = MD5Encrypt32(signStr).ToLower();

                var paramInput = new InputComParams()
                {
                    ID = "88",
                    System = new CoreParams()
                    {
                        Ver = "1.0",
                        Sign = sign,
                        AppID = appId,
                        Time = time,
                        Nonce = nonce
                    }
                };

                var json = JsonConvert.SerializeObject(paramInput);
                var data = new StringContent(json, Encoding.UTF8, "application/json");
                var url = "https://openapi.easy4ip.com/openapi/accessToken";
                var no = 0;

                var result = await Post(url, data, no);

                return result;
            }
            catch
            {
                return null;
            }
        }

        public async Task<string> BindDeviceLive(string token)
        {
            try
            {
                var time = this.GetTime();

                nonce = Guid.NewGuid().ToString();
                signStr = "time:" + time + ",nonce:" + nonce + ",appSecret:" + appSecret;
                sign = MD5Encrypt32(signStr).ToLower();

                var paramInput = new InputComParams()
                {
                    ID = "88",
                    System = new CoreParams()
                    {
                        Ver = "1.0",
                        Sign = sign,
                        AppID = appId,
                        Time = time,
                        Nonce = nonce
                    },
                    Params = new InputParams()
                    {
                        StreamID = 1,
                        DeviceID = deviceId,
                        ChannelID = "0",
                        Token = token
                    }
                };

                var json = JsonConvert.SerializeObject(paramInput);
                var data = new StringContent(json, Encoding.UTF8, "application/json");
                var url = "https://openapi.easy4ip.com/openapi/bindDeviceLive";
                var no = 1;

                var result = await Post(url, data, no);

                return result;
            }
            catch
            {
                return null;
            }            
        }

        public async Task<string> GetLiveStreamInfor(string token)
        {
            try
            {
                var time = this.GetTime();

                nonce = Guid.NewGuid().ToString();
                signStr = "time:" + time + ",nonce:" + nonce + ",appSecret:" + appSecret;
                sign = MD5Encrypt32(signStr).ToLower();

                var paramInput = new InputComParams()
                {
                    ID = "88",
                    System = new CoreParams()
                    {
                        Ver = "1.0",
                        Sign = sign,
                        AppID = appId,
                        Time = time,
                        Nonce = nonce
                    },
                    Params = new InputParams()
                    {
                        DeviceID = deviceId,
                        ChannelID = "0",
                        Token = token
                    }
                };

                var json = JsonConvert.SerializeObject(paramInput);
                var data = new StringContent(json, Encoding.UTF8, "application/json");
                var url = "https://openapi.easy4ip.com/openapi/getLiveStreamInfo";
                var no = 2;

                var result = await Post(url, data, no);

                return result;
            }
            catch
            {
                return null;
            }
            
        }
        
        public async Task<string> DeviceOnline(string token)
        {
            try
            {
                var time = this.GetTime();

                nonce = Guid.NewGuid().ToString();
                signStr = "time:" + time + ",nonce:" + nonce + ",appSecret:" + appSecret;
                sign = MD5Encrypt32(signStr).ToLower();

                var paramInput = new InputComParams()
                {
                    ID = "88",
                    System = new CoreParams()
                    {
                        Ver = "1.0",
                        Sign = sign,
                        AppID = appId,
                        Time = time,
                        Nonce = nonce
                    },
                    Params = new InputParams()
                    {
                        DeviceID = deviceId,
                        Token = token
                    }
                };

                var json = JsonConvert.SerializeObject(paramInput);
                var data = new StringContent(json, Encoding.UTF8, "application/json");
                var url = "https://openapi.easy4ip.com/openapi/deviceOnline";
                var no = 3;

                var result = await Post(url, data, no);

                return result;
            }
            catch
            {
                return null;
            }
            
        }

        public string MD5Encrypt32(string password)
        {
            string cl = password;
            string pwd = "";
            MD5 md5 = MD5.Create();
            byte[] s = md5.ComputeHash(Encoding.UTF8.GetBytes(cl));
            for (int i = 0; i < s.Length; i++)
            {
                pwd = pwd + s[i].ToString("X2");
            }
            return pwd;
        }

        public async Task<string> Post(string url, StringContent data, int no)
        {
            using (var client = new HttpClient())
            {
                var response = await client.PostAsync(url, data);
                var result = await response.Content.ReadAsStringAsync();

                DecodeJson DecodeJson = new DecodeJson();
                var dataResult = DecodeJson.Decode(result, no);

                return dataResult;
            }
        }

        private long GetTime()
        {
            var now = DateTime.Now;
            return Convert.ToInt64((now - TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1))).TotalSeconds);
        }

        #endregion
    }
}