using ATSCADAWebApp.Web.Models;
using ATSCADAWebApp.Web.Models.Camera;
using System.Configuration;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ATSCADAWebApp.Web.Controllers
{
    /// <summary>
    /// Quan ly, realtime Camera IMOU
    /// </summary>
    public class CameraController : Controller
    {
        [HttpPost]
        public async Task<ActionResult> Web(CameraInput param)
        {
            try
            {
                Response.Headers.Add("Access-Control-Allow-Origin", "*");

                var user = ConfigurationManager.ConnectionStrings[param.Connection].ConnectionString.Split(';')[0].Split('=')[1];
                var pwd = ConfigurationManager.ConnectionStrings[param.Connection].ConnectionString.Split(';')[1].Split('=')[1];
                var cameraID = ConfigurationManager.ConnectionStrings[param.Connection].ConnectionString.Split(';')[2].Split('=')[1];

                CameraInput cameraParam = new CameraInput()
                {
                    AppID = user,
                    AppSecret = pwd,
                    DeviceID = cameraID
                };

                CameraEncryption encryption = new CameraEncryption(cameraParam);
                var token = await encryption.AccessToken();
                var value = await encryption.BindDeviceLive(token);
                var link = await encryption.GetLiveStreamInfor(token);

                return new JsonResult()
                {
                    Data = new { Status = true, Link = link, Token = token },
                    ContentType = "application/json",
                    ContentEncoding = Encoding.UTF8,
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                    MaxJsonLength = int.MaxValue
                };
            }
            catch
            {
                return Json(new { Status = false }, JsonRequestBehavior.AllowGet);
            }            
        }

        [HttpPost]
        public async Task<ActionResult> Online(CameraInput online)
        {
            try
            {
                Response.Headers.Add("Access-Control-Allow-Origin", "*");

                var user = ConfigurationManager.ConnectionStrings[online.Connection].ConnectionString.Split(';')[0].Split('=')[1];
                var pwd = ConfigurationManager.ConnectionStrings[online.Connection].ConnectionString.Split(';')[1].Split('=')[1];
                var cameraID = ConfigurationManager.ConnectionStrings[online.Connection].ConnectionString.Split(';')[2].Split('=')[1];
                var token = online.Token;

                CameraInput cameraParam = new CameraInput()
                {
                    AppID = user,
                    AppSecret = pwd,
                    DeviceID = cameraID
                };

                CameraEncryption encryption = new CameraEncryption(cameraParam);
                var result = await encryption.DeviceOnline(token);

                return new JsonResult()
                {
                    Data = new { Status = true, Result = result is null ? false : result.Trim() == "1" },
                    ContentType = "application/json",
                    ContentEncoding = Encoding.UTF8,
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                    MaxJsonLength = int.MaxValue
                };
            }
            catch
            {
                return Json(new { Status = false }, JsonRequestBehavior.AllowGet);
            }            
        }
    }    
}