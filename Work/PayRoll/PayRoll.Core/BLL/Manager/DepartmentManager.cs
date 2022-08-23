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
    public class DepartmentManager : IDepartmentManager
    {
        private readonly DBContext _dbContext;
        private readonly IDepartmentRepository _iDepartmentRepository;
        public DepartmentManager()
        {
            _dbContext = new DBContext(DatabaseConfiguration.ConnectionString);
            _iDepartmentRepository = new DepartmentRepository(_dbContext);
        }


        public IEnumerable<Department> GetDepartment()
        {
            try
            {
                _dbContext.Open();
                var users = _iDepartmentRepository.GetDepartment();
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

        public Department GetADepartment(string departmentid)
        {
            try
            {
                _dbContext.Open();
                var userStatus = _iDepartmentRepository.GetADepartment(departmentid);
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
        public Message CreateOrUpdate(Department department, int create)
        {
            var message = new Message();
            try
            {
                _dbContext.Open();
                _iDepartmentRepository.CreateOrUpdate(department, create);
                message = Message.SetMessages.SetSuccessMessage("Department Created Successfully");
            }
            catch (Exception ex)
            {
                message = Message.SetMessages.SetErrorMessage("Error in Creating Department" + ex.Message);
            }
            finally
            {
                _dbContext.Close();
            }

            return message;
        }
        public Message Delete(string departmentid)
        {
            var message = new Message();
            try
            {
                _dbContext.Open();
                _iDepartmentRepository.Delete(departmentid);
                message = Message.SetMessages.SetSuccessMessage("Department Deleted Successfully");
            }
            catch (Exception ex)
            {
                message = Message.SetMessages.SetErrorMessage("Error in Deleting Department" + ex.Message);
            }
            finally
            {
                _dbContext.Close();
            }

            return message;
        }


    }
}
