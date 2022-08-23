using PayRoll.Core.BLL.Interface;
using PayRoll.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PayRoll.Controllers
{
    public class DesignationController : Controller
    {
        // GET: Designation
        IDesignationManager _iDesignationManager = new DesignationManager();
        ICommonManager commonManager = new CommonManager();
        public ActionResult Index()
        {
            int screenCode = (int)Enum.Parse(typeof(ScreenList.Screens), Enum.GetName(typeof(ScreenList.Screens), ScreenList.Screens.Designation));
            var data = commonManager.GetScreenWisePermission(screenCode.ToString());
            ViewData["Permission"] = data;
            return View();
        }
        public ActionResult CreateOrUpdate(Designation designation)
        {
            var data = _iDesignationManager.CreateOrUpdate(designation, 1);
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetDesignation()
        {
            var data = _iDesignationManager.GetDesignation();
            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}