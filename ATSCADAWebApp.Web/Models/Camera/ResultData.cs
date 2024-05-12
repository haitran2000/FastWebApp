using System.Collections.Generic;
using Newtonsoft.Json;

namespace ATSCADAWebApp.Web.Models
{
    public class ResultData
    {
        [JsonProperty("expireTime")]
        public int ExpireTime { get; set; }

        [JsonProperty("currentDomain")]
        public string CurrentDomain { get; set; }

        [JsonProperty("accessToken")]
        public string Token { get; set; }

        [JsonProperty("streams")]
        public List<ResultLink> Streams { get; set; }

        [JsonProperty("liveType")]  // bindDeviceLive
        public int LiveType { get; set; }

        [JsonProperty("onLine")]  // deviceOnline
        public string Online { get; set; }
    }
}