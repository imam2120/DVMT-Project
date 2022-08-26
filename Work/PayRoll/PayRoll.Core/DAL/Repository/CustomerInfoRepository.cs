using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PayRoll.Core.DAL.Interface;
using PayRoll.Core.Model;
using PayRoll.Core.Utility.DBManager;
using System.Data.SqlClient;
using System.Data.Common;

namespace PayRoll.Core.DAL.Repository
{
    public class CustomerInfoRepository : ICustomerInfoRepository
    {
        public static DBContext _dbContext;
        public static AppSession session;
        public CustomerInfoRepository(DBContext dbContext)
        {
            _dbContext = dbContext;
            session = CurrentSession.GetCurrentSession();
        }
        public void CreateOrUpdate(CustomerInfo Customer, int create)
        {

            Dictionary<string, object> keyValues = new Dictionary<string, object>();
            keyValues.Add("@CustomerId", Customer.CustomerId);
            keyValues.Add("@GLAccountNo", Customer.GLAccountNo);
            keyValues.Add("@CustomerName", Customer.CustomerName);
            keyValues.Add("@ContactPerson", Customer.ContactPerson);
            keyValues.Add("@ContactNumber", Customer.ContactNumber);
            keyValues.Add("@EmailAddress", Customer.EmailAddress);
            keyValues.Add("@MailingAddress", Customer.MailingAddress);
            keyValues.Add("@CurrentBalance", Customer.CurrentBalance);
            keyValues.Add("@DueBalance", Customer.DueBalance);
            keyValues.Add("@Status", "0");
            keyValues.Add("@SetupDate", Customer.SetupDate);
            keyValues.Add("@UserId", session.UserId);
            keyValues.Add("@CreateBy", session.UserId);
            keyValues.Add("@CreateDate", Customer.CreateDate);
            keyValues.Add("@ModifyBy", Customer.ModifyBy);
            keyValues.Add("@ModifyDate", Customer.ModifyDate);
            keyValues.Add("@Action", "1");

            string spName = "USP_CustomerEntry";

            _dbContext.GetExecuteNonQuery(spName, keyValues);

        }
        public void Delete(string CustomerId)
        {
            String query = String.Empty;
            query = "Update a set a.Status = 2 from Customer a where a.CustomerId = '" + CustomerId + "' ";

            _dbContext.ExecuteQuery(query);

        }
        public CustomerInfo GetACustomer(string CustomerId)
        {
            string query = "select * from Customer where CustomerId = '" + CustomerId + "' ";
            var data = _dbContext.GetDataTable(query);

            return (from DataRow row in data.Rows select CustomerInfo.ConvertToModel(row)).FirstOrDefault();
        }
        public IEnumerable<CustomerInfo> GetCustomer()
        {
            //string query = "select * from Tbl_Employee ";
            List<InputParameter> parameterList = new List<InputParameter>();
            InputParameter inputParameter = new InputParameter();
            inputParameter.ParameterName = "@Action";
            inputParameter.ParameterValue = 1;
            parameterList.Add(inputParameter);

            string spName = "USP_GetCustomer"; //
            var data = _dbContext.GetDataTableWithSP(spName, parameterList);
            // var data = _dbContext.GetDataTable(query);
            return (from DataRow row in data.Rows select CustomerInfo.ConvertToModel(row));
        }
    }
}
