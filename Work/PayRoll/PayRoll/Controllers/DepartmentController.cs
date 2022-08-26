using PayRoll.Core.BLL.Interface;
using PayRoll.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PayRoll.Controllers
{
    public class DepartmentController : Controller
    {
        // GET: Department
        IDepartmentManager _iDepartmentManager = new DepartmentManager();
        ICommonManager commonManager = new CommonManager();
        public ActionResult Index()
        {
            int screenCode = (int)Enum.Parse(typeof(ScreenList.Screens), Enum.GetName(typeof(ScreenList.Screens), ScreenList.Screens.Department));
            var data = commonManager.GetScreenWisePermission(screenCode.ToString());
            ViewData["Permission"] = data;
            return View();
        }
        public ActionResult CreateOrUpdate(Department department,int operationType)
        {
            Message data=new Message();
            try
            {
   
             data = _iDepartmentManager.CreateOrUpdate(department, operationType);
            return Json(data, JsonRequestBehavior.AllowGet);
               
            }
            catch (Exception)
            {
                return Json(data, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult GetDepartment()
        {
            var data = _iDepartmentManager.GetDepartment();
            return Json(data, JsonRequestBehavior.AllowGet);
        }

    }
}