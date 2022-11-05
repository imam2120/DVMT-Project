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
    public class DayOpenCloseController : Controller
    {
        private readonly DBContext _dbContext;
        IDayOpenCloseManager idayOpenCloseManager = new DayOpenCloseManager();

        ICommonManager commonManager = new CommonManager();

        public ActionResult Index()
        {
            int screenCode = (int)Enum.Parse(typeof(ScreenList.Screens), Enum.GetName(typeof(ScreenList.Screens), ScreenList.Screens.DayOpenClose));
            var data = commonManager.GetScreenWisePermission(screenCode.ToString());
            ViewData["Permission"] = data;

            return View();
        }

        [HttpGet]
        public ActionResult GetOpenCloseDate()
        {
            string result = string.Empty;
            try
            {
                string strQry = string.Empty;
                string strQry1 = string.Empty;
                string result1 = string.Empty;

                strQry1 = "Select Status from Acc_DayOpenClose Where  Convert(Date,EntryDate) = (select Max(Convert(Date,EntryDate)) from Acc_DayOpenClose)";
                result1 = commonManager.GetDataSingle(strQry1);
                if (result1 == "1")
                {
                    strQry = "select Max(EntryDate)+1 from Acc_DayOpenClose ";
                }
                else
                {
                    strQry = "select Max(EntryDate) from Acc_DayOpenClose ";
                }
                
                result = commonManager.GetDataSingle(strQry);
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(result, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public ActionResult GetDayStatus()
        {
            string result = string.Empty;
            try
            {
                string strQry = "Select Status from Acc_DayOpenClose Where  Convert(Date,EntryDate) = (select Max(Convert(Date,EntryDate)) from Acc_DayOpenClose)";
                result = commonManager.GetDataSingle(strQry);
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(result, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult CreateOrUpdate(DayOpenClose dayOpenClose)
        {
            var data = idayOpenCloseManager.CreateOrUpdate(dayOpenClose, 1);
            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}