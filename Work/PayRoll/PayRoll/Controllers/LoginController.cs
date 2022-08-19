using PayRoll.Core.BLL.Interface;
using PayRoll.Core.Model;
using PayRoll.Core.Utility.DBManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PayRoll.Controllers
{
    public class LoginController : Controller
    {

        ILoginManager _iLoginManager = new LoginManager();
        //
        // GET: /Login/
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string userName, string password)
        {
            var msg = _iLoginManager.DoLogin(userName, password);
            if (msg.MessageType == MessageTypes.Success)
            {
                CreateSession(userName);
            }
            else
            {
                Session["Session"] = null;
            }

            return Json(msg, JsonRequestBehavior.AllowGet);

        }

        private void CreateSession(string userName)
        {
            var data = _iLoginManager.GetUserSession(userName);
            AppSession appSession = new AppSession();
            if (data != null)
            {
                appSession.UserId = data.UserId;
                appSession.UserName = data.UserName;
                appSession.UserRoleId = data.UserRoleId;
                appSession.UserStatus = data.UserStatusId;
                appSession.UserTenancyId = data.UserTenancyId;             
                Session["Session"] = appSession;
            }
            else
            {
                Session["Session"] = null;
            }

        }

        public ActionResult LogOut()
        {
            Session.RemoveAll();
            return RedirectToAction("Index", "Login");
        }

	}
}