using ATSCADAWebApp.Core;
using ATSCADAWebApp.Model;

namespace ATSCADAWebApp.Web.Models
{
    // Thong tin dang nhap 
    public class LoginView
    {
        // Thong tin ve project
        public InfoView Info { get; set; }

        // Thong tin xac thuc dang nhap
        public AuthenticationAccount Account { get; set; }

        public LoginView(ATSCADAApp app)
        {
            Info = new InfoView(app);
            Account = new AuthenticationAccount();
        }

        public LoginView(ATSCADAApp app, AuthenticationAccount account)
        {
            Info = new InfoView(app);
            Account = account;
        }
    }
}
