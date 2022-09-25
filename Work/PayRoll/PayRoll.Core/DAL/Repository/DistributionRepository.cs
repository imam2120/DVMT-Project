using PayRoll.Core.DAL.Interface;
using PayRoll.Core.Model;
using PayRoll.Core.Utility.DBManager;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayRoll.Core.DAL.Repository
{
    public class DistributionRepository : IDistributionRepository
    {
        public static DBContext _dbContext;
        public static AppSession session;

        public DistributionRepository(DBContext dbContext)
        {
            _dbContext = dbContext;
            session = CurrentSession.GetCurrentSession();
        }
        public IEnumerable<Distribution> GetEmployeeTarget()
        {
            //string query = "select * from Tbl_Employee ";
            List<InputParameter> parameterList = new List<InputParameter>();
            InputParameter inputParameter = new InputParameter();
            inputParameter.ParameterName = "@TransDate";
            inputParameter.ParameterValue = System.DateTime.Now;
            parameterList.Add(inputParameter);

            string spName = "USP_GetEmployeeTarget"; 
            var data = _dbContext.GetDataTableWithSP(spName, parameterList);
            
            return (from DataRow row in data.Rows select Distribution.ConvertToModel(row));
        }
        public void CreateOrUpdate(Distribution distribution, int create)
        {
            Dictionary<string, object> keyValues = new Dictionary<string, object>();

            keyValues.Add("@TransDate", System.DateTime.Now);
            keyValues.Add("@TransNo", distribution.TransNo);
            keyValues.Add("@ProductAccNo", distribution.ProductAccNo);
            keyValues.Add("@PrdOpenBalance", distribution.PrdOpenBalance);
            keyValues.Add("@EmpAccNo", distribution.EmpAccNo);
            keyValues.Add("@OpeningBalance", distribution.OpeningBalance);
            keyValues.Add("@TargetAmount", distribution.TargetAmount);
            keyValues.Add("@ClosingBalance", distribution.ClosingBalance);

            string spName = "USP_PreEmployeeTarget";

            _dbContext.GetExecuteNonQuery(spName, keyValues);
        }
    }
}
