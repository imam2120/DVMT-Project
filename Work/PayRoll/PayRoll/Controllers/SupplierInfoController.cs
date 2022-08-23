using PayRoll.Core.BLL.Interface;
using PayRoll.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PayRoll.Controllers
{
    public class SupplierInfoController : Controller
    {
        ISupplierInfoManager _iSupplierInfoManager = new SupplierInfoManager();
        ICommonManager commonManager = new CommonManager();
        public ActionResult Index()
        {
            int screenCode = (int)Enum.Parse(typeof(ScreenList.Screens), Enum.GetName(typeof(ScreenList.Screens), ScreenList.Screens.SupplierInfo));
            var data = commonManager.GetScreenWisePermission(screenCode.ToString());
            ViewData["Permission"] = data;
            return View();
        }
        public ActionResult CreateOrUpdate(SupplierInfo supplier)
        {
            var data = _iSupplierInfoManager.CreateOrUpdate(supplier, 1);
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetSupplier()
        {
            var data = _iSupplierInfoManager.GetSupplier();
            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}