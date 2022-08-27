using PayRoll.Core.BLL.Interface;
using PayRoll.Core.BLL.Manager;
using PayRoll.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PayRoll.Controllers
{
    public class TransactionController : Controller
    {
        // GET: ProductInfo
        ITransactionManager _iTransactionManager = new TransactionManager();
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
            var data = "";// ITransactionManager.CreateOrUpdate(product, 1);
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult LoadAccountNO()
        {
            //CommonItem item = new CommonItem();
            IEnumerable<DDLSourceModel> ddlDepartment = new List<DDLSourceModel>();
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("@QryOption", "1");
            try
            {
                ddlDepartment = commonManager.GetLoadCombo(new DDLSourceModel
                {
                    SPName = @"USP_AccountNo",
                    Params = dic,
                });
                return Json(ddlDepartment, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(ddlDepartment, JsonRequestBehavior.AllowGet);
            }
        }
    }
}