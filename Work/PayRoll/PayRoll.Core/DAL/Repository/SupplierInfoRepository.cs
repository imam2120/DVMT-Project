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
    public class SupplierInfoRepository : ISupplierInfoRepository
    {
        public static DBContext _dbContext;
        public static AppSession session;
        public SupplierInfoRepository(DBContext dbContext)
        {
            _dbContext = dbContext;
            session = CurrentSession.GetCurrentSession();
        }
        public void CreateOrUpdate(SupplierInfo supplier, int create)
        {

            Dictionary<string, string> keyValues = new Dictionary<string, string>();
            keyValues.Add("@SupplierId", supplier.SupplierId);
            keyValues.Add("@GLAccountNo", supplier.GLAccountNo);
            keyValues.Add("@SupplierName", supplier.SupplierName);
            keyValues.Add("@ContactPerson", supplier.ContactPerson);
            keyValues.Add("@ContactNumber", supplier.ContactNumber);
            keyValues.Add("@EmailAddress", supplier.EmailAddress);
            keyValues.Add("@MailingAddress", supplier.MailingAddress);
            keyValues.Add("@CurrentBalance", supplier.CurrentBalance);
            keyValues.Add("@DueBalance", supplier.DueBalance);
            keyValues.Add("@Status", "0");
            keyValues.Add("@SetupDate", supplier.SetupDate);
            keyValues.Add("@UserId", session.UserId);
            keyValues.Add("@CreateBy", session.UserId);
            keyValues.Add("@CreateDate", supplier.CreateDate);
            keyValues.Add("@ModifyBy", supplier.ModifyBy);
            keyValues.Add("@ModifyDate", supplier.ModifyDate);
            keyValues.Add("@Action", "1");

            string spName = "USP_SpplierEntry";

            _dbContext.GetExecuteNonQuery(spName, keyValues);

        }
        public void Delete(string SupplierId)
        {
            String query = String.Empty;
            query = "Update a set a.Status = 2 from Supplier a where a.SupplierId = '" + SupplierId + "' ";

            _dbContext.ExecuteQuery(query);

        }
        public SupplierInfo GetASupplier(string SupplierId)
        {
            string query = "select * from Supplier where SupplierId = '" + SupplierId + "' ";
            var data = _dbContext.GetDataTable(query);

            return (from DataRow row in data.Rows select SupplierInfo.ConvertToModel(row)).FirstOrDefault();
        }
        public IEnumerable<SupplierInfo> GetSupplier()
        {
            //string query = "select * from Tbl_Employee ";
            List<InputParameter> parameterList = new List<InputParameter>();
            InputParameter inputParameter = new InputParameter();
            inputParameter.ParameterName = "@Action";
            inputParameter.ParameterValue = 1;
            parameterList.Add(inputParameter);

            string spName = "USP_GetSupplier"; //
            var data = _dbContext.GetDataTableWithSP(spName, parameterList);
            // var data = _dbContext.GetDataTable(query);
            return (from DataRow row in data.Rows select SupplierInfo.ConvertToModel(row));
        }
    }
}
