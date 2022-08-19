using PayRoll.Core.BLL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PayRoll.Controllers
{
    public class RoleWiseScreenController : Controller
    {
        private readonly IRoleWiseScreenManager _iRoleWiseScreenManager = new RoleWiseScreenManager();
        private readonly IUserRoleManager _iUserRoleManager = new UserRoleManager();
        //
        // GET: /RoleWiseScreen/
        public ActionResult Index()
        {
            var roles = _iUserRoleManager.GetRoles().Select(
                    o => new SelectListItem
                    {
                        Value = o.RoleId,
                        Text = o.RoleName
                    }).ToList();

            ViewData["UserRoleList"] = roles;
            return View();
        }

        public ActionResult GetScreens(string roleId)
        {
            var data = _iRoleWiseScreenManager.GetAllScreens(roleId);
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Create(string roleId, string screenId)
        {

            var data = _iRoleWiseScreenManager.Create(roleId, screenId);
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Delete(string roleId, string screenId)
        {
            var data = _iRoleWiseScreenManager.Delete(roleId, screenId);
            return Json(data, JsonRequestBehavior.AllowGet);
        }


        public ActionResult UpdateSpecificPermission(string roleId, string screenId, string action, string operationType)
        {
            var data = _iRoleWiseScreenManager.UpdateSpecificPermission(roleId, screenId, action, operationType);
            return Json(data, JsonRequestBehavior.AllowGet);

        }

    }
}