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
    public class ProductPurchaseRepository : IProductPurchaseRepository
    {
        public static DBContext _dbContext;
        public static AppSession session;
        public ProductPurchaseRepository(DBContext dbContext)
        {
            _dbContext = dbContext;
            session = CurrentSession.GetCurrentSession();
        }
        public void CreateOrUpdate(PreProductPurces preProductPurces, int create)
        {

            Dictionary<string, object> keyValues = new Dictionary<string, object>();

            keyValues.Add("@TransDate",System.DateTime.Now);
            keyValues.Add("@TransNo", preProductPurces.TransNo);
            keyValues.Add("@ProductAccNo", preProductPurces.ProductAccNo);
            keyValues.Add("@OpeningBalance", preProductPurces.OpeningBalance);
            keyValues.Add("@PurcesAmount", preProductPurces.PurcesAmount);
            keyValues.Add("@ClosingBalance", preProductPurces.ClosingBalance);
            keyValues.Add("@ByCashAmount" ,preProductPurces.ByCashAmount);
            keyValues.Add("@ByBankAmount" ,preProductPurces.ByBankAmount);
            keyValues.Add("@DueAmount" , preProductPurces.DueAmount);
            keyValues.Add("@SupAccNo", preProductPurces.SupAccNo);
            keyValues.Add("@SupDueAmount",preProductPurces.SupDueAmount);
            keyValues.Add("@SupCurrBalance", preProductPurces.SupCurrBalance);
            keyValues.Add("@qryOption", 1);
            

            string spName = "USP_PreProductPurces";

            _dbContext.GetExecuteNonQuery(spName, keyValues);

        }
    }
}
