using PayRoll.Core.BLL.Interface;
using PayRoll.Core.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PayRoll.Controllers
{
    public class EmployeeInfoController : Controller
    {
        // GET: Employee

        IEmployeeInfoManager _iEmployeeManager = new EmployeeInfoManager();
        ICommonManager commonManager = new CommonManager();
        public ActionResult Index()
        {
            int screenCode = (int)Enum.Parse(typeof(ScreenList.Screens), Enum.GetName(typeof(ScreenList.Screens), ScreenList.Screens.EmployeeInfo));
            var data = commonManager.GetScreenWisePermission(screenCode.ToString());
            ViewData["Permission"] = data;
            return View();
        }
        public ActionResult CreateOrUpdate(EmployeeInfo employeeInfo)
        {
            
            var data = _iEmployeeManager.CreateOrUpdate(employeeInfo, 1);
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetEmployee()
        {          
            var data = _iEmployeeManager.GetEmployee();
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        #region ddl load

        [HttpGet]
        public JsonResult LoadDepartment()
        {
            //CommonItem item = new CommonItem();
            IEnumerable<DDLSourceModel> ddlDepartment = new List<DDLSourceModel>();
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("@QryOption", "1");
            try
            {
                ddlDepartment = commonManager.GetDDlist(new DDLSourceModel
                {
                    SPName = @"USP_Depatment",
                    Params = dic,
                });
                return Json(ddlDepartment, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(ddlDepartment, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public JsonResult LoadDesignation()
        {
            //CommonItem item = new CommonItem();
            IEnumerable<DDLSourceModel> ddlDesignation = new List<DDLSourceModel>();
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("@QryOption", "2");
            try
            {
                ddlDesignation = commonManager.GetDDlist(new DDLSourceModel
                {
                    SPName = @"USP_Depatment",
                    Params = dic,
                });
                return Json(ddlDesignation, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(ddlDesignation, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion

    }

}