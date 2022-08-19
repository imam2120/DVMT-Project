using PayRoll.Core.BLL.Interface;
using PayRoll.Core.BLL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PayRoll.Controllers
{
    public class CommonController : Controller
    {


        ICommonManager _iCommonManager = new CommonManager();
       
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GeaAllStatuses()
        {
            var data = _iCommonManager.GetUserStatuses();
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetEmployeeBasicInfo(string EmployeeId)
        {
            var data = _iCommonManager.GetEmployeeBasicInfo(EmployeeId);
            return Json(data, JsonRequestBehavior.AllowGet);
        
        }

        public ActionResult GeaAStatus(string statusid)
        {
            var data = _iCommonManager.GetAStatus(statusid);
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetMonthsOfYear()
        {
            var data = _iCommonManager.GetMonthsOfYear();
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetServerDate()
        {
            var data = _iCommonManager.GetServerDate();
            return Json(data, JsonRequestBehavior.AllowGet);

        }
      
       

       
        

       

       
        public ActionResult GetAllMaritalStatus()
        {
            var data = _iCommonManager.GetAllMaritalStatus();
            return Json(data, JsonRequestBehavior.AllowGet);

        }

        [HttpGet]
        public ActionResult LoadAllMonth()
        {
            List<SelectListItem> items = new List<SelectListItem>();
            items.Add(new SelectListItem() { Text = "January", Value = "1" });
            items.Add(new SelectListItem() { Text = "February", Value = "2" });
            items.Add(new SelectListItem() { Text = "March", Value = "3" });            
            items.Add(new SelectListItem() { Text = "April", Value = "4" });
            items.Add(new SelectListItem() { Text = "May", Value = "5" });
            items.Add(new SelectListItem() { Text = "June", Value = "6" });
            items.Add(new SelectListItem() { Text = "July", Value = "7" });
            items.Add(new SelectListItem() { Text = "August", Value = "8" });
            items.Add(new SelectListItem() { Text = "September", Value = "9" });
            items.Add(new SelectListItem() { Text = "October", Value = "10" });
            items.Add(new SelectListItem() { Text = "November", Value = "11" });
            items.Add(new SelectListItem() { Text = "December", Value = "12" });

            return Json(items, JsonRequestBehavior.AllowGet);
        }

       
	}
}