using ATSCADAWebApp.Core;
using ATSCADAWebApp.Model;
using System.Collections.Generic;

namespace ATSCADAWebApp.Web.Models
{
    // Thong tin ve Project
    public class IndexView
    {        
        // Co yeu cau phai xac thuc ( dang nhap) khi truy cap Web hay khong
        public bool AuthenticationRequired { get; set; }

        // Thong tin Project
        public InfoView Info { get; set; }

        // Session dang nhap
        public AuthenticationSession Session { get; set; }

        // Cac page - View duoc phep hien thi
        public IEnumerable<PageView> Pages { get; set; }

        public IndexView(ATSCADAApp app)
        {
            if (app is null) return;
            AuthenticationRequired = app.Authentication.Required;
            Info = new InfoView(app);
            Session = new AuthenticationSession("admin", "admin");
        }       
    }
}
