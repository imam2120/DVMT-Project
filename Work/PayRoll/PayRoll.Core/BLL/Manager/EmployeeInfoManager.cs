using PayRoll.Core.BLL.Interface;
using PayRoll.Core.DAL.Interface;
using PayRoll.Core.DAL.Repository;
using PayRoll.Core.Model;
using PayRoll.Core.Utility.DBManager;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace PayRoll.Core.BLL.Interface
{
    public class EmployeeInfoManager : IEmployeeInfoManager
    {
        private readonly DBContext _dbContext;
        private readonly IEmployeeInfoRepository _iEmployeeRepository;
        public EmployeeInfoManager()
        {
            _dbContext = new DBContext(DatabaseConfiguration.ConnectionString);
            _iEmployeeRepository = new EmployeeInfoRepository(_dbContext);
        }


        public IEnumerable<EmployeeInfo> GetEmployee()
        {
            try
            {
                _dbContext.Open();
                var users = _iEmployeeRepository.GetEmployee();
                return users;
            }
            catch
            {
                return null;
            }
            finally
            {
                _dbContext.Close();
            }
        }

        public EmployeeInfo GetAEmployee(string employeeid)
        {
            try
            {
                _dbContext.Open();
                var userStatus = _iEmployeeRepository.GetAEmployee(employeeid);
                return userStatus;
            }
            catch
            {
                return null;
            }
            finally
            {
                _dbContext.Close();
            }
        }
        public Message CreateOrUpdate(EmployeeInfo employee, int create)
        {
            var message = new Message();
            try
            {
                _dbContext.Open();
                _iEmployeeRepository.CreateOrUpdate(employee, create);
                message = Message.SetMessages.SetSuccessMessage("Employee Created Successfully");
            }
            catch (Exception ex)
            {
                message = Message.SetMessages.SetErrorMessage("Error in Creating Employee" + ex.Message);
            }
            finally
            {
                _dbContext.Close();
            }

            return message;
        }
        public Message Delete(string employeeid)
        {
            var message = new Message();
            try
            {
                _dbContext.Open();
                _iEmployeeRepository.Delete(employeeid);
                message = Message.SetMessages.SetSuccessMessage("Employee Deleted Successfully");
            }
            catch (Exception ex)
            {
                message = Message.SetMessages.SetErrorMessage("Error in Deleting Employee" + ex.Message);
            }
            finally
            {
                _dbContext.Close();
            }

            return message;
        }


    }
}
