using ATSCADAWebApp.Core;

namespace ATSCADAWebApp.Web.Models
{
    // Thong tin cua View
    public class PageView
    {
        // Tieu de. Hien thi tren thanh SideBar - Menu
        public string Content { get; set; }

        // Link URL (#hash) cua View
        public string Location { get; set; }

        // Icon hien thi tren SideBar
        public string Icon { get; set; }
        
        public PageView(IATSCADAView view)
        {
            if (view is null) return;
            Content = view.Content;
            Location = view.Location;
            Icon = view.Icon;            
        }
    }
}
