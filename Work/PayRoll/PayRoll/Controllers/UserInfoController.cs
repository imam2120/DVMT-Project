using PayRoll.Core.BLL.Interface;
using PayRoll.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PayRoll.Controllers
{
    public class UserInfoController : Controller
    {

        IUserInfoManager _iUserInfoManager = new UserInfoManager();
        ICommonManager commonManager = new CommonManager();

       
        public ActionResult Index()
        {
            int screenCode = (int)Enum.Parse(typeof(ScreenList.Screens), Enum.GetName(typeof(ScreenList.Screens), ScreenList.Screens.UserInfo));           
            var data = commonManager.GetScreenWisePermission(screenCode.ToString());
            ViewData["Permission"] = data;
            return View();
        }
        [HttpGet]
        public ActionResult GetAUser(string userName)
        {
            var data = _iUserInfoManager.GetAUser(userName);
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult GetUsers()
        {
            var data = _iUserInfoManager.GetUsers();
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Create(UserInfo userInfo)
        {
            var data = _iUserInfoManager.CreateOrUpdate(userInfo, 1);
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Update(UserInfo userInfo)
        {
            var data = _iUserInfoManager.CreateOrUpdate(userInfo, 2);
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Delete(string userName)
        {
            var data = _iUserInfoManager.Delete(userName);
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GetAStatus(string statusId)
        {
            var data = _iUserInfoManager.GetAStatus(statusId);
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult GetUserStatuses()
        {
            var data = _iUserInfoManager.GetUserStatuses();
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetAllUserStatuses()
        {
            var data = _iUserInfoManager.GetAllUserStatuses();
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public ActionResult IsUserExist(string userName) 
        {
            var data = _iUserInfoManager.IsUserExist(userName);
            return Json(data, JsonRequestBehavior.AllowGet);
        }

	}
}