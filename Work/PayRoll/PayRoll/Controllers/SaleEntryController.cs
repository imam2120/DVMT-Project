using PayRoll.Core.BLL.Interface;
using PayRoll.Core.BLL.Manager;
using PayRoll.Core.Model;
using PayRoll.Core.Utility.DBManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PayRoll.Controllers
{
    public class SaleEntryController : Controller
    {
        private readonly DBContext _dbContext;
        ISaleEntryManager _iSaleEntryManager = new SaleEntryManager();

        ICommonManager commonManager = new CommonManager();
        public ActionResult Index()
        {
            int screenCode = (int)Enum.Parse(typeof(ScreenList.Screens), Enum.GetName(typeof(ScreenList.Screens), ScreenList.Screens.SaleEntry));
            var data = commonManager.GetScreenWisePermission(screenCode.ToString());
            ViewData["Permission"] = data;

            return View();
        }

        public JsonResult LoadProductName()
        {
            IEnumerable<DDLSourceModel> ddlProductName = new List<DDLSourceModel>();
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("@QryOption", "1");
            try
            {
                ddlProductName = commonManager.GetLoadCombo(new DDLSourceModel
                {
                    SPName = @"USP_GetProductPurces",
                    Params = dic,
                });
                return Json(ddlProductName, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(ddlProductName, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public JsonResult LoadEmployeeName()
        {
            IEnumerable<DDLSourceModel> ddlProductName = new List<DDLSourceModel>();
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("@Action", "1");
            try
            {
                ddlProductName = commonManager.GetLoadCombo(new DDLSourceModel
                {
                    SPName = @"USP_GetEmployeeTarget",
                    Params = dic,
                });
                return Json(ddlProductName, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(ddlProductName, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public JsonResult LoadProductBalance(string ProductId)
        {
            double result = 0;
            try
            {
                string strQry = "Select ISNULL(Balance,0) Balance from Product Where GLAccountNo='" + ProductId + "'";
                result = Convert.ToDouble(commonManager.GetDataSingle(strQry));
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(result, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public JsonResult GetEmployeeTarget(string TransNo)
        {
            double result = 0;
            try
            {
                string strQuery = "";

                strQuery = "select SUM((ISNULL(a.OpeningBalance,0) + ISNULL(a.TargetAmount,0)) - ISNULL(b.SaleAmount,0)) AS Balance  from EmployeeTarget a ";
                strQuery += "Left Join SaleEntry b on a.ProductAccNo = b.ProductCode and a.TransNo = b.TrTransNo ";
                strQuery += "Where a.TransNo ='" + TransNo + "' HAVING SUM((ISNULL(a.OpeningBalance,0) +ISNULL(a.TargetAmount, 0)) -ISNULL(b.SaleAmount, 0)) > 0 ";


                //string strQry = "select (ISNULL(OpeningBalance,0) + ISNULL(TargetAmount,0)) AS Balance from EmployeeTarget Where TransNo='" + TransNo + "'";


                result = Convert.ToDouble(commonManager.GetDataSingle(strQuery));
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(result, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public JsonResult GetLastTransaction()
        {
            string result = string.Empty;
            try
            {
                string strQry = "SELECT TransType+RIGHT('00000000'+convert(varchar,LastSeqNo+1),9) FROM LastTransactionNo where TransType = 'PS' ";
                result = commonManager.GetDataSingle(strQry);
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(result, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public JsonResult LoadCustomerName()
        {
            IEnumerable<DDLSourceModel> ddlProductName = new List<DDLSourceModel>();
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("@Action", "3");
            try
            {
                ddlProductName = commonManager.GetLoadCombo(new DDLSourceModel
                {
                    SPName = @"USP_GetCustomer",
                    Params = dic,
                });
                return Json(ddlProductName, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(ddlProductName, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult CreateOrUpdate(SaleEntry saleEntry)
        {
            var data = _iSaleEntryManager.CreateOrUpdate(saleEntry, 1);
            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}