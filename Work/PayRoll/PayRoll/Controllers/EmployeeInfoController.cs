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
                ddlDepartment = commonManager.GetLoadCombo(new DDLSourceModel
                {
                    SPName = @"USP_GetEmployeeCombo",
                    Params = dic,
                });
                return Json(ddlDepartment, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
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
                ddlDesignation = commonManager.GetLoadCombo(new DDLSourceModel
                {
                    SPName = @"USP_GetEmployeeCombo",
                    Params = dic,
                });
                return Json(ddlDesignation, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(ddlDesignation, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public JsonResult LoadGender()
        {
            //CommonItem item = new CommonItem();
            IEnumerable<DDLSourceModel> ddlGender = new List<DDLSourceModel>();
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("@QryOption", "3");
            try
            {
                ddlGender = commonManager.GetLoadCombo(new DDLSourceModel
                {
                    SPName = @"USP_GetEmployeeCombo",
                    Params = dic,
                });
                return Json(ddlGender, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(ddlGender, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public JsonResult LoadMaritalStatus()
        {
            //CommonItem item = new CommonItem();
            IEnumerable<DDLSourceModel> ddlMaritalStatus = new List<DDLSourceModel>();
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("@QryOption", "4");
            try
            {
                ddlMaritalStatus = commonManager.GetLoadCombo(new DDLSourceModel
                {
                    SPName = @"USP_GetEmployeeCombo",
                    Params = dic,
                });
                return Json(ddlMaritalStatus, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(ddlMaritalStatus, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public JsonResult LoadBloodGroup()
        {
            //CommonItem item = new CommonItem();
            IEnumerable<DDLSourceModel> ddlBloodGroup = new List<DDLSourceModel>();
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("@QryOption", "5");
            try
            {
                ddlBloodGroup = commonManager.GetLoadCombo(new DDLSourceModel
                {
                    SPName = @"USP_GetEmployeeCombo",
                    Params = dic,
                });
                return Json(ddlBloodGroup, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(ddlBloodGroup, JsonRequestBehavior.AllowGet);
            }
        }


        #endregion

    }

}