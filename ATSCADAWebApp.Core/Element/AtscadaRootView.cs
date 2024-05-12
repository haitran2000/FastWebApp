using System.Xml.Serialization;

namespace ATSCADAWebApp.Core.Element
{
    [XmlRoot("atscada-root-view")]
    public class AtscadaRootView
    {
        [XmlElement(ElementName = "atscada-layout-view")]
        public AtscadaLayoutView AtscadaLayoutView { get; set; }

        [XmlElement(ElementName = "atscada-alarm-reporter-view")]
        public AtscadaAlarmReportView AtscadaAlarmReportView { get; set; }

        [XmlElement(ElementName = "atscada-data-reporter-view")]
        public AtscadaDataReportView AtscadaDataReportView { get; set; }

        [XmlElement(ElementName = "atscada-settings-view")]
        public AtscadaSettingsView AtscadaSettingsView { get; set; }

        public AtscadaRootView()
        {
            AtscadaLayoutView = new AtscadaLayoutView();
            AtscadaAlarmReportView = new AtscadaAlarmReportView();
            AtscadaDataReportView = new AtscadaDataReportView();
            AtscadaSettingsView = new AtscadaSettingsView();
        }
    }
}
