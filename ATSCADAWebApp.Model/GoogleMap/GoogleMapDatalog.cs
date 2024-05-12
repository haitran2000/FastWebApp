using System.Collections.Generic;

namespace ATSCADAWebApp.Model.GoogleMap
{
    public class GoogleMapDatalog
    {
        public string DateTime { get; set; }

        public string Location { get; set; }

        public List<GoogleMapParameters> Parameters { get; set; }

        public GoogleMapDatalog(string dateTime, string location)
        {
            DateTime = dateTime;
            Location = location;
            Parameters = new List<GoogleMapParameters>();
        }
    }
}
