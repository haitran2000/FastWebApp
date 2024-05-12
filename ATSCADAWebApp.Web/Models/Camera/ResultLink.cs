using Newtonsoft.Json;

namespace ATSCADAWebApp.Web.Models
{
    public class ResultLink
    {
        [JsonProperty("streamId")]
        public string StreamID { get; set; }

        [JsonProperty("liveToken")]
        public string LiveToken { get; set; }

        [JsonProperty("hls")]
        public string Hls { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }
    }
}