using PayRoll.Core.BLL.Interface;
using PayRoll.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PayRoll.Controllers
{
    public class ProductInfoController : Controller
    {
        // GET: ProductInfo
        IProductInfoManager _iProductInfoManager = new ProductInfoManager();
        ICommonManager commonManager = new CommonManager();
        public ActionResult Index()
        {
            int screenCode = (int)Enum.Parse(typeof(ScreenList.Screens), Enum.GetName(typeof(ScreenList.Screens), ScreenList.Screens.ProductInfo));
            var data = commonManager.GetScreenWisePermission(screenCode.ToString());
            ViewData["Permission"] = data;
            return View();
        }
        public ActionResult CreateOrUpdate(ProductInfo product)
        {
            var data = _iProductInfoManager.CreateOrUpdate(product, 1);
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetProduct()
        {
            var data = _iProductInfoManager.GetProduct();
            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}