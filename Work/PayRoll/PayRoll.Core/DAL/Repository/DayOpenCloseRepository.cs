using PayRoll.Core.DAL.Interface;
using PayRoll.Core.Model;
using PayRoll.Core.Utility.DBManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayRoll.Core.DAL.Repository
{
    public class DayOpenCloseRepository : IDayOpenCloseRepository
    {
        public static DBContext _dbContext;
        public static AppSession session;
        public DayOpenCloseRepository(DBContext dbContext)
        {
            _dbContext = dbContext;
            session = CurrentSession.GetCurrentSession();
        }
        public void CreateOrUpdate(DayOpenClose dayOpenClose, int create)
        {
            Dictionary<string, object> keyValues = new Dictionary<string, object>();
            keyValues.Add("@TransDate", dayOpenClose.TransDate);
            keyValues.Add("@OpenCloseByUser", session.UserName);
            keyValues.Add("@Action", dayOpenClose.Action);

            string spName = "USP_ADMIN_DayOpenClose";

            _dbContext.GetExecuteNonQuery(spName, keyValues);
        }
    }
}
