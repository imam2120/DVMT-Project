using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace PayRoll.Core.Utility.DBManager
{
    public class CurrentSession
    {
        public static AppSession GetCurrentSession()
        {
            AppSession UserSession;
            if (HttpContext.Current.Session["Session"]!=null)
            {
                UserSession = HttpContext.Current.Session["Session"] as AppSession;
            }
            else
            {
                UserSession = null;
                UserSession = HttpContext.Current.Session["Session"] as AppSession;
            }
            return UserSession;
        
        }
    }
}
