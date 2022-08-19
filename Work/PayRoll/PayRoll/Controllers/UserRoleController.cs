using PayRoll.Core.BLL.Interface;
using PayRoll.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PayRoll.Controllers
{
    public class UserRoleController : Controller
    {

        IUserRoleManager _iUserRoleManager = new UserRoleManager();
        ICommonManager commonManager = new CommonManager();

       
        public ActionResult Index()
        {
            int screenCode = (int)Enum.Parse(typeof(ScreenList.Screens), Enum.GetName(typeof(ScreenList.Screens), ScreenList.Screens.UserRole));            
            var data=commonManager.GetScreenWisePermission(screenCode.ToString());
            ViewData["Permission"] = data;

            return View();
        }

        public ActionResult CreateOrUpdate(UserRole userRole, int create)
        {

            var data = _iUserRoleManager.CreateOrUpdate(userRole, create);
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Delete(UserRole userRole)
        {
            var data = _iUserRoleManager.Delete(userRole);
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult GenerateRoleId()
        {
            string roleId = _iUserRoleManager.GenerateRoleId();
            return Json(roleId, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetRoles()
        {
            var data = _iUserRoleManager.GetRoles();
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetARole(string roleId)
        {
            var data = _iUserRoleManager.GetARole(roleId);
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetAllRoles()
        {
            var data = _iUserRoleManager.GetAllRoles();
            return Json(data, JsonRequestBehavior.AllowGet);
        }

	}
}