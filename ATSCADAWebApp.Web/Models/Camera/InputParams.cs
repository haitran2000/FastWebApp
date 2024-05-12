using Newtonsoft.Json;

namespace ATSCADAWebApp.Web.Models
{
    public class InputParams
    {
        [JsonProperty("streamId")]
        public int StreamID { get; set; }

        [JsonProperty("deviceId")]
        public string DeviceID { get; set; }

        [JsonProperty("channelId")]
        public string ChannelID { get; set; }

        [JsonProperty("token")]
        public string Token { get; set; }
    }
}