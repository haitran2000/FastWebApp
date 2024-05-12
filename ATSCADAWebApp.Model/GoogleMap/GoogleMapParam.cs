
using System.Collections.Generic;

namespace ATSCADAWebApp.Model.GoogleMap
{
    public class GoogleMapParam
    {
        public string ID { get; set; }

        public string Content { get; set; }

        public string Connection { get; set; } = "atscada";

        public string TableName { get; set; } = "datalog";

        public string FromDateTime { get; set; }

        public string ToDateTime { get; set; }
    }
}
