
namespace ATSCADAWebApp.Model.GoogleMap
{
    public class GoogleMapParameters
    {
        public string Alias { get; set; }

        public string Value { get; set; }

        public GoogleMapParameters(string alias, string value)
        {
            Alias = alias;
            Value = value;
        }
    }
}
