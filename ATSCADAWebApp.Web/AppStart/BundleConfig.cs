using System.Web.Optimization;

namespace ATSCADAWebApp.Web
{
    public class BundleConfig
    {       
        public static void RegisterBundles(BundleCollection bundles)
        {
            #region Style

            bundles.Add(new StyleBundle("~/bundles/CoreStyle").Include(
                "~/AppTemplate/css/material/icon/material-icons.css",
                "~/AppTemplate/css/vendor.min.css",
                "~/AppTemplate/css/material/app.min.css"
                ));

            #endregion

            #region Scripts

            bundles.Add(new Bundle("~/bundles/CoreScript").Include(
                "~/AppTemplate/js/vendor.min.js",
                "~/AppTemplate/js/app.min.js",
                "~/AppTemplate/js/theme/material.min.js"
                ));

            bundles.Add(new Bundle("~/bundles/LayoutViewScript").Include(
                "~/AppScripts/Core/Data/atscada-data-task-element.js",
                "~/AppScripts/Component/Card/atscada-card-element.js",
                "~/AppScripts/Component/Card/atscada-chartdemo-element.js",
                "~/AppScripts/Component/Chart/atscada-chart-element.js",
                "~/AppScripts/Component/AlarmViewer/atscada-alarm-viewer-element.js",
                 "~/AppScripts/Component/Slider/atscada-slider-element.js",
                "~/AppScripts/Component/Input/atscada-input-element.js"
                ));

            bundles.Add(new Bundle("~/bundles/AlarmViewScript").Include(
                "~/AppScripts/Component/AlarmReporter/atscada-alarm-reporter-element.js"
                ));

            bundles.Add(new Bundle("~/bundles/DataViewScript").Include(
                "~/AppScripts/Component/DataReporter/atscada-data-reporter-element.js",
                "~/AppScripts/Component/DataReporter/atscada-data-reporter-item-element.js"
                ));

            bundles.Add(new Bundle("~/bundles/SettingsScript").Include(
                "~/AppScripts/Core/Data/atscada-data-task-element.js",
                "~/AppScripts/Component/Slider/atscada-slider-element.js",
                "~/AppScripts/Component/Input/atscada-input-element.js"
                ));

            bundles.Add(new Bundle("~/bundles/AtscadaComponent").Include(
                "~/AppScripts/App/atscada-app-element.js",
               "~/AppScripts/Core/Data/atscada-data-task-element.js",
                "~/AppScripts/Component/Card/atscada-card-element.js",
                "~/AppScripts/Component/Chart/atscada-chart-element.js",
                "~/AppScripts/Component/AlarmViewer/atscada-alarm-viewer-element.js",
                 "~/AppScripts/Component/Slider/atscada-slider-element.js",
                "~/AppScripts/Component/Input/atscada-input-element.js",
                "~/AppScripts/Component/AlarmReporter/atscada-alarm-reporter-element.js",
                "~/AppScripts/Component/DataReporter/atscada-data-reporter-element.js",
                "~/AppScripts/Component/DataReporter/atscada-data-reporter-item-element.js"
                ));

            #endregion
        }
    }
}
