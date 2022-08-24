using PayRoll.Core.BLL.Interface;
using PayRoll.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PayRoll.Controllers
{
    public class CustomerInfoController : Controller
    {
        ICustomerInfoManager _iCustomerInfoManager = new CustomerInfoManager();
        ICommonManager commonManager = new CommonManager();
        // GET: CustomerInfo
        public ActionResult Index()
        {
            int screenCode = (int)Enum.Parse(typeof(ScreenList.Screens), Enum.GetName(typeof(ScreenList.Screens), ScreenList.Screens.CustomerInfo));
            var data = commonManager.GetScreenWisePermission(screenCode.ToString());
            ViewData["Permission"] = data;
            return View();
        }
        public ActionResult CreateOrUpdate(CustomerInfo Customer)
        {
            var data = _iCustomerInfoManager.CreateOrUpdate(Customer, 1);
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetCustomer()
        {
            var data = _iCustomerInfoManager.GetCustomer();
            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}