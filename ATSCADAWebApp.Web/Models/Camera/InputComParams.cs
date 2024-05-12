using Newtonsoft.Json;

namespace ATSCADAWebApp.Web.Models
{
    public class InputComParams
    {
        [JsonProperty("id")]
        public string ID { get; set; }

        [JsonProperty("system")]
        public CoreParams System { get; set; }

        [JsonProperty("params")]
        public InputParams Params { get; set; }
    }

    public class CoreParams
    {
        [JsonProperty("ver")]
        public string Ver { get; set; }

        [JsonProperty("appId")]
        public string AppID { get; set; }

        [JsonProperty("sign")]
        public string Sign { get; set; }

        [JsonProperty("time")]
        public long Time { get; set; }

        [JsonProperty("nonce")]
        public string Nonce { get; set; }
    }
}