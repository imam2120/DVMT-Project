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
    public class EmployeeInfoRepository : IEmployeeInfoRepository
    {
        public static DBContext _dbContext;
        public static AppSession session;
        public EmployeeInfoRepository(DBContext dbContext)
        {
            _dbContext = dbContext;
            session = CurrentSession.GetCurrentSession();
        }
        public void CreateOrUpdate(EmployeeInfo employee, int create)
        {

            Dictionary<string, string> keyValues = new Dictionary<string, string>();
            keyValues.Add("@EmployeeId", employee.EmployeeId);
            keyValues.Add("@GLAccountNo", employee.GLAccountNo);
            keyValues.Add("@EmployeeName", employee.EmployeeName);
            keyValues.Add("@FatherName", employee.FatherName);
            keyValues.Add("@MotherName", employee.MotherName);
            keyValues.Add("@PresentAddress", employee.PresentAddress);
            keyValues.Add("@PermanentAddress", employee.PermanentAddress);
            keyValues.Add("@GenderId", employee.GenderId);
            keyValues.Add("@DateOfBirth", employee.DateOfBirth /*System.DateTime.Now.ToShortDateString()*/);
            keyValues.Add("@ContractNumber", employee.ContractNumber);
            keyValues.Add("@EmergencyNumber", employee.EmergencyNumber);
            keyValues.Add("@BloodGroup", employee.BloodGroup);
            keyValues.Add("@NationalId", employee.NationalId);
            keyValues.Add("@MaritalStatus", employee.MaritalStatus);
            keyValues.Add("@DeptId", employee.DeptId);
            keyValues.Add("@DesignationId", employee.DesignationId);
            keyValues.Add("@JoiningDate", employee.JoiningDate);
            keyValues.Add("@JoiningType", employee.JoiningType);
            keyValues.Add("@StatusId", "0");
            keyValues.Add("@ImagePath", string.Empty);
            keyValues.Add("@UserId", session.UserId);
            keyValues.Add("@Action", "1");

            string spName = "USP_EmployeeEntry";

            _dbContext.GetExecuteNonQuery(spName, keyValues);

        }
        public void Delete(string employeeid)
        {
            String query = String.Empty;
            query = "delete from Employee where EmployeeId = '" + employeeid + "' ";

            _dbContext.ExecuteQuery(query);

        }
        public EmployeeInfo GetAEmployee(string employeeid)
        {
            string query = "select * from Employee where EmployeeId = '" + employeeid + "' ";
            var data = _dbContext.GetDataTable(query);

            return (from DataRow row in data.Rows select EmployeeInfo.ConvertToModel(row)).FirstOrDefault();
        }
        public IEnumerable<EmployeeInfo> GetEmployee()
        {
            //string query = "select * from Tbl_Employee ";
            List<InputParameter> parameterList = new List<InputParameter>();
            InputParameter inputParameter = new InputParameter();
            inputParameter.ParameterName = "@Action";
            inputParameter.ParameterValue = 1;
            parameterList.Add(inputParameter);

            string spName = "USP_GetEmployee"; //
            var data = _dbContext.GetDataTableWithSP(spName, parameterList);
            // var data = _dbContext.GetDataTable(query);
            return (from DataRow row in data.Rows select EmployeeInfo.ConvertToModel(row));
        }
    }
}
