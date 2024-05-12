using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace ATSCADAWebApp.Web.Models
{
    public class ResultCommon
    {
        [JsonProperty("result")]
        public CoreResult Result { get; set; }

        [JsonProperty("id")]
        public string ID { get; set; }
    }

    public class CoreResult
    {
        [JsonProperty("msg")]
        public string Msg { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("data")]
        public ResultData Data { get; set; }
    }
}