using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace PayRoll.Core.Utility.DBManager
{
    public class CheckSession : ActionFilterAttribute
    {
        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (CurrentSession.GetCurrentSession()==null)
            {
                string redirectUrl = string.Format("~/Login/Logout");
                filterContext.Result = new RedirectResult(redirectUrl);
            }
        
        
        }
    }
}
