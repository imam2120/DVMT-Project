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
    public class DesignationRepository : IDesignationRepository
    {
        public static DBContext _dbContext;
        public static AppSession session;
        public DesignationRepository(DBContext dbContext)
        {
            _dbContext = dbContext;
            session = CurrentSession.GetCurrentSession();
        }
        public void CreateOrUpdate(Designation designation, int create)
        {

            Dictionary<string, string> keyValues = new Dictionary<string, string>();
            keyValues.Add("@DesignationId", designation.DesignationId);
            keyValues.Add("@DesignationName", designation.DesignationName);
            keyValues.Add("@Status", designation.Status);
            keyValues.Add("@CreateBy", designation.CreatedBy);
            keyValues.Add("@CreateDate", designation.CreatedDate);
            keyValues.Add("@MakeBy", designation.MakeBy);
            keyValues.Add("@MakeDate", designation.MakeDate);
            keyValues.Add("@Action", "1");

            string spName = "USP_DesignationEntry";

            _dbContext.GetExecuteNonQuery(spName, keyValues);

        }
        public void Delete(string designationid)
        {
            String query = String.Empty;
            query = "delete from Designation where DesignationId = '" + designationid + "' ";

            _dbContext.ExecuteQuery(query);

        }
        public Designation GetADesignation(string designationid)
        {
            string query = "select * from Designation where DesignationId = '" + designationid + "' ";
            var data = _dbContext.GetDataTable(query);

            return (from DataRow row in data.Rows select Designation.ConvertToModel(row)).FirstOrDefault();
        }
        public IEnumerable<Designation> GetDesignation()
        {
            //string query = "select * from Tbl_Employee ";
            List<InputParameter> parameterList = new List<InputParameter>();
            InputParameter inputParameter = new InputParameter();
            inputParameter.ParameterName = "@Action";
            inputParameter.ParameterValue = 1;
            parameterList.Add(inputParameter);

            string spName = "USP_GetDesignation"; //
            var data = _dbContext.GetDataTableWithSP(spName, parameterList);
            // var data = _dbContext.GetDataTable(query);
            return (from DataRow row in data.Rows select Designation.ConvertToModel(row));
        }
    }
}
