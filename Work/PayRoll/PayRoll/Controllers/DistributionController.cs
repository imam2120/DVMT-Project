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
    public class DistributionController : Controller
    {
        private readonly DBContext _dbContext;
        IDistributionManager _iDistributionManager = new DistributionManager();
      
        ICommonManager commonManager = new CommonManager();
        public ActionResult Index()
        {
            int screenCode = (int)Enum.Parse(typeof(ScreenList.Screens), Enum.GetName(typeof(ScreenList.Screens), ScreenList.Screens.Distribution));
            var data = commonManager.GetScreenWisePermission(screenCode.ToString());
            ViewData["Permission"] = data;

            return View();
        }
        [HttpGet]
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
        public JsonResult LoadSupplierName()
        {
            IEnumerable<DDLSourceModel> ddlProductName = new List<DDLSourceModel>();
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("@QryOption", "3");
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
        public JsonResult LoadProductBalance(string ProductId)
        {
            double result = 0;
            try
            {
                string strQry = "Select ISNULL(Balance,0) Balance from Product Where GLAccountNo='"+ ProductId +"'";
                result = Convert.ToDouble(commonManager.GetDataSingle(strQry));
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(result, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public JsonResult GetEmployeeBalance(string EmployeeCode)
        {
            double result = 0;
            try
            {
                //string strQry = "Select isnull(DueBalance,0) Balance from Supplier Where GLAccountNo='" + SuplierId + "'";
                string strQuery = "select isnull(OpeningBalance,0)Balance from EmployeeTransaction where EmployeeCode = '" + EmployeeCode + "' and convert(date,transdate) = convert(date,getdate())";
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
                string strQry = "SELECT TransType+RIGHT('00000000'+convert(varchar,LastSeqNo+1),9) FROM LastTransactionNo where TransType = 'PD' ";
                result = commonManager.GetDataSingle(strQry);
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(result, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult CreateOrUpdate(Distribution distribution)
        {
            var data = _iDistributionManager.CreateOrUpdate(distribution, 1);
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetEmployeeTarget()
        {
            var data = _iDistributionManager.GetEmployeeTarget();
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        
    }
}