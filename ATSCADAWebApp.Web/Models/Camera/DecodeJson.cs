using Newtonsoft.Json;
using System;

namespace ATSCADAWebApp.Web.Models
{
    public class DecodeJson
    {
        public string Decode(string data, int no)
        {
            var result = JsonConvert.DeserializeObject<ResultCommon>(data);

            var code = result.Result.Code;

            if (!code.Equals("0"))
            {
                // System.Diagnostics.Debug.WriteLine("Code: " + code);
                return null;
            }

            if (no > 3) return null;

            if (no == 0)
            {
                var token = result.Result.Data.Token;

                if (!string.IsNullOrEmpty(token))
                    return token;
            }

            else if (no == 1)
            {
                return null;
            }
            else if (no == 2)
            {
                var streams = result.Result.Data.Streams;
                string linkHls = null;

                foreach (var link in streams)
                {
                    if (string.Equals(link.StreamID, "1") && (link.Hls.StartsWith("https")))
                    {
                        linkHls = link.Hls;
                        return linkHls;
                    }
                }
            }
            else
            {
                var online = result.Result.Data.Online;

                if (!string.IsNullOrEmpty(online))
                    return online;
            }
            return null;
        }
    }
}