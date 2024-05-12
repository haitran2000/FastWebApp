using ATSCADAWebApp.Web.Models;
using System;
using System.Web.Mvc;

namespace ATSCADAWebApp.Web.Controllers
{
    /// <summary>
    /// Controller kiem tra loi
    /// </summary>
    public class ErrorController : Controller
    {
        public ActionResult Oops(int statusCode, Exception exception)
        {
            Response.StatusCode = statusCode;
            return View(new ErrorView()
            {
                StatusCode = statusCode,
                Message = exception?.Message
            });
        }
    }
}