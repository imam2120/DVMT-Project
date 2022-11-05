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
    public class SaleEntryRepository : ISaleEntryRepository
    {
        public static DBContext _dbContext;
        public static AppSession session;

        public SaleEntryRepository(DBContext dbContext)
        {
            _dbContext = dbContext;
            session = CurrentSession.GetCurrentSession();
        }
        public void CreateOrUpdate(SaleEntry saleEntry, int create)
        {
            Dictionary<string, object> keyValues = new Dictionary<string, object>();

            keyValues.Add("@TransDate", System.DateTime.Now);
            keyValues.Add("@TransNo", saleEntry.TransNo);
            keyValues.Add("@ProductCode", saleEntry.ProductCode);
            keyValues.Add("@EmpAccNo", saleEntry.EmpAccNo);
            keyValues.Add("@TargetAmount", saleEntry.TargetAmount);
            keyValues.Add("@SaleAmount", saleEntry.SaleAmount);
            keyValues.Add("@PendingAmount", saleEntry.PendingAmount);
            keyValues.Add("@ByCashAmount", saleEntry.ByCashAmount);
            keyValues.Add("@ByBankAmount", saleEntry.ByBankAmount);
            keyValues.Add("@DueAmount", saleEntry.DueAmount);
            keyValues.Add("@CusAccNo", saleEntry.CusAccNo);
            keyValues.Add("@CurrBalance", saleEntry.CurrBalance);
            keyValues.Add("@MakeBy", session.UserName);
            keyValues.Add("@MakeDate", System.DateTime.Now);
            keyValues.Add("@Action", 1);


            string spName = "USP_SaleEntry";

            _dbContext.GetExecuteNonQuery(spName, keyValues);

        }

    }
}
