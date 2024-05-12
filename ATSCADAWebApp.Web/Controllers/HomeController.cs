using ATSCADAWebApp.Database.Service;
using ATSCADAWebApp.Model;
using ATSCADAWebApp.Web.Models;
using System.Configuration;
using System.Linq;
using System.Web.Mvc;

namespace ATSCADAWebApp.Web.Controllers
{
    public class HomeController : BaseController
    {
        /// <summary>
        /// Trang login
        /// </summary>
        /// <returns></returns>
        public ActionResult Login()
        {
            // Xoa tat ca ma loi
            ModelState.Clear();
            // Doc file config.xml -> Load app
            LoadApplication(true);
            var application = RootRepository.Application;
            // Neu khong yeu cau dang nhap, dieu huong thang toi Home
            if (!application.Authentication.Required)
            {
                return RedirectToAction("Index", "Home");
            }

            return View(new LoginView(application));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Login(AuthenticationAccount account)
        {
            // Doc file config.xml -> Load app
            LoadApplication();
            var application = RootRepository.Application;

            // Kiem tra tinh hop le cua ModelInput
            if (ModelState.IsValid)
            {
                var config = ConfigurationManager.ConnectionStrings[application.Authentication.Connection];
                // Kiem tra co chuoi ket noi login hay khong
                if(config is null || string.IsNullOrEmpty(config.ConnectionString))
                {
                    // add ma loi
                    ModelState.AddModelError(string.Empty, "Check your connection and try again");
                    // Tra ve lai giao dien login
                    return View(new LoginView(application, account));
                }
                
                var authenticationService = new AuthenticationService(config.ConnectionString);
                // Kiem tra tai khoan dang nhap
                if(!authenticationService.CheckAccount(application.Authentication.TableName, account, out string role))
                {
                    ModelState.AddModelError(string.Empty, "The Username or Password is Incorrect!");
                    return View(new LoginView(application, account));
                }
                
                var session = new AuthenticationSession(account.UserName, role);
                // Gan thong tin user (userName, role) vao Session
                // Check quyen truy cap theo Session
                Session["Authentication"] = session;
                return RedirectToAction("Index", "Home");
            }

            return View(new LoginView(application, account));
        }

        public ActionResult Logout()
        {
            Session.Clear();            
            return RedirectToAction("Login", "Home");
        }

        /// <summary>
        /// Tra ve View Default - Home
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            LoadApplication(true);            
            var application = RootRepository.Application;
            var indexView = new IndexView(application);

            // Neu yeu cau dang nhap. Se dieu huong toi trang Login
            if (application.Authentication.Required)
            {
                if (!(Session["Authentication"] is AuthenticationSession session))
                    return RedirectToAction("Login", "Home");

                RootRepository.Role = session.Role;
                indexView.Session = session;                
            }
            else
            {
                RootRepository.Role = string.Empty;
            }

            indexView.Pages = RootRepository.ViewAccessed.Select(view => new PageView(view));
            return View(indexView);         
        }     
    }
}