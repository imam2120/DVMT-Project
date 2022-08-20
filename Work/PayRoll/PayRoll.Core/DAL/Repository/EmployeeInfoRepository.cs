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
            String query = String.Empty;
            if (create == 1)
            {
                CurrentSession.GetCurrentSession();
                query = @"INSERT INTO Tbl_Employee (EmployeeId,Name,FatherName,MotherName,PresentAddress ,PermanentAddress,GenderId,DOB,ContractNumber,EmergencyNumber,BloodGroup,NID ,MaritalStatus,DeptId,DesignationId,JoiningDate,JoiningType,StatusId,Image,CreatedBy ,CreatedDate,ModifyBy,ModifyDate)
                          VALUES('" + employee.EmployeeId + "','" + employee.Name + "','" + employee.FatherName + "','" + employee.MotherName + "','" + employee.PresentAddress + "','" + employee.PermanentAddress + "','" + employee.GenderId + "','" + employee.DOB + "','" + employee.ContractNumber + "'" +
                          ",'" + employee.EmergencyNumber + "','" + employee.BloodGroup + "','" + employee.NID + "','" + employee.MaritalStatus + "','" + employee.DeptId + "','" + employee.DesignationId + "','" + employee.JoiningDate + "','" + employee.JoiningType + "','" + employee.StatusId + "',null,null,GETDATE(),null,null)";
            }
            else
            {
                query = "update Tbl_Employee set Name = '" + employee.Name + "', FatherName = '" + employee.FatherName + "', MotherName = '" + employee.MotherName + "', PresentAddress = '" + employee.PresentAddress + "' where EmployeeId = '" + employee.EmployeeId + "' ";
            }

            //Dictionary<string, string> keyValues = new Dictionary<string, string>();
            //keyValues.Add()

            _dbContext.ExecuteQuery(query);


            //SqlConnection connection = new SqlConnection(DatabaseConfiguration.ConnectionString);
            //SqlCommand command = connection.CreateCommand();
            //SqlTransaction transaction;
            //transaction = connection.BeginTransaction();

            //command.Connection = connection;
            //command.Transaction = transaction;

            //command.CommandType = CommandType.Text;
            //command.CommandText = query;
            ////command.CommandTimeout = _commandTimeOut;
            //command.Connection = connection;
            //int result = command.ExecuteNonQuery();

            ////_dbContext.ExecuteQuery(query);
            //if (result > 0)
            //{
            //    transaction.Commit();
            //}
            //else
            //{
            //    transaction.Rollback();
            //}
        }
        public void Delete(string employeeid)
        {
            String query = String.Empty;
            query = "delete from Tbl_Employee where EmployeeId = '" + employeeid + "' ";

            _dbContext.ExecuteQuery(query);

        }
        public EmployeeInfo GetAEmployee(string employeeid)
        {
            string query = "select * from Tbl_Employee where EmployeeId = '" + employeeid + "' ";
            var data = _dbContext.GetDataTable(query);
           
            return (from DataRow row in data.Rows select EmployeeInfo.ConvertToModel(row)).FirstOrDefault();
        }          
        public IEnumerable<EmployeeInfo> GetEmployee()
        {
            //string query = "select * from Tbl_Employee ";
            List<InputParameter> parameterList = new List<InputParameter>();
            InputParameter inputParameter = new InputParameter();
            inputParameter.ParameterName = "@QryOption";
            inputParameter.ParameterValue = 1;
            parameterList.Add(inputParameter);

            string spName = "GetEmployee"; //
            var data = _dbContext.GetDataTableWithSP(spName, parameterList);
           // var data = _dbContext.GetDataTable(query);
            return (from DataRow row in data.Rows select EmployeeInfo.ConvertToModel(row));
        }


    }
}
