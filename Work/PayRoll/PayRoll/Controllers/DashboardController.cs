using PayRoll.Core.BLL.Interface;
using PayRoll.Core.BLL.Interface;
using PayRoll.Core.Model;
using PayRoll.Core.Utility.DBManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PayRoll.Controllers
{
    [CheckSession]
    public class DashboardController : Controller
    {
        //
        // GET: /Dashboard/
        ICommonManager _iCommonManager = new CommonManager();
        public ActionResult Index()
        {
            AppSession appSession = CurrentSession.GetCurrentSession();
            if (Session["Module"] == null)
            {
                Session["Module"] = _iCommonManager.GetModules(appSession.UserRoleId).ToList();
            }

            if (Session["SubModules"] == null)
            {
                var result = _iCommonManager.GetSubModules(appSession.UserRoleId, "000").ToList<RoleWiseScreenPermission>();
                Session["SubModules"] = result;
            }
            return View();
        }

        public ActionResult Module(string moduleId)
        {
            AppSession currentSession = CurrentSession.GetCurrentSession();
            if (!(moduleId != "00"))
            {
                Session["SubModules"] = null;
                return RedirectToAction("Index");
            }
            var result= _iCommonManager.GetSubModules(currentSession.UserRoleId, moduleId).ToList<RoleWiseScreenPermission>();
            Session["SubModules"] = result;
            if (moduleId == "1000")
            {
                return RedirectToAction("SecurityPolicy");
            }
            if (moduleId == "2000")
            {
                return RedirectToAction("Setup");
            }
            if (moduleId == "3000")
            {
                return RedirectToAction("Patient");
            }
          
            if (moduleId == "4000")
            {
                return RedirectToAction("Reports");
            }
            if (moduleId == "5000")
            {
                return RedirectToAction("COA");
            }
            if (moduleId=="6000")
            {
                return RedirectToAction("Employee");
            }

            return RedirectToAction("Test");
        }

        public ActionResult SecurityPolicy()
        {
            return View();
        }

        public ActionResult Setup()
        {
            return View();
        }
        public ActionResult Patient()
        {
            return View();
        }

     
        public ActionResult Reports()
        {
            return View();
        }

        public ActionResult COA()
        {
            return View();
        }
        public ActionResult Employee()
        {
            return View();
        }


    }
}