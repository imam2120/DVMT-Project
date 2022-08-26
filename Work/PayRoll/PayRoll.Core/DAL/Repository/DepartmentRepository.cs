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
    public class DepartmentRepository : IDepartmentRepository
    {
        public static DBContext _dbContext;
        public static AppSession session;
        public DepartmentRepository(DBContext dbContext)
        {
            _dbContext = dbContext;
            session = CurrentSession.GetCurrentSession();
        }
        public void CreateOrUpdate(Department department, int operationType)
        {
            try
            {  
            Dictionary<string, object> keyValues = new Dictionary<string, object>();

                if (operationType == 1 && department.DepartmentId <= 0)
                {
                    //keyValues.Add("@DepartmentId", department.DepartmentId);
                    keyValues.Add("@DepartmentName", department.DepartmentName);
                    keyValues.Add("@Status", department.Status);
                    keyValues.Add("@UserId", session.UserId);
                    //keyValues.Add("@CreateDate", department.CreatedDate);
                    //keyValues.Add("@MakeBy", department.MakeBy);
                    //keyValues.Add("@MakeDate", department.MakeDate);
                    keyValues.Add("@Action", 1);
                }
                else if (operationType == 2)
                {
                    keyValues.Add("@DepartmentId", department.DepartmentId);
                    keyValues.Add("@DepartmentName", department.DepartmentName);
                    keyValues.Add("@UserId", session.UserId);
                    keyValues.Add("@Action", 2);
                }
                else if (operationType == 3 && department.DepartmentId > 0)
                {
                    keyValues.Add("@DepartmentId", department.DepartmentId);                   
                    keyValues.Add("@Action", 3);
                }


                string spName = "USP_DepartmentEntry";

            _dbContext.GetExecuteNonQuery(spName, keyValues);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void Delete(string departmentid)
        {
            String query = String.Empty;
            query = "delete from Department where DepartmentId = '" + departmentid + "' ";

            _dbContext.ExecuteQuery(query);

        }
        public Department GetADepartment(string departmentid)
        {
            string query = "select * from Department where DepartmentId = '" + departmentid + "' ";
            var data = _dbContext.GetDataTable(query);

            return (from DataRow row in data.Rows select Department.ConvertToModel(row)).FirstOrDefault();
        }
        public IEnumerable<Department> GetDepartment()
        {
            //string query = "select * from Tbl_Employee ";
            List<InputParameter> parameterList = new List<InputParameter>();
            InputParameter inputParameter = new InputParameter();
            inputParameter.ParameterName = "@Action";
            inputParameter.ParameterValue = 1;
            parameterList.Add(inputParameter);

            string spName = "USP_GetDepartment"; //
            var data = _dbContext.GetDataTableWithSP(spName, parameterList);
            // var data = _dbContext.GetDataTable(query);
            return (from DataRow row in data.Rows select Department.ConvertToModel(row));
        }
    }
}
