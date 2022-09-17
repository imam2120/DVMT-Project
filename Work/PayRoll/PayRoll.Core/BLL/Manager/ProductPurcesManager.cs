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
    public class ProductPurcesManager : IProductPurcesManager
    {
        private readonly DBContext _dbContext;
        private readonly IProductPurcesRepository _iProductPurcesRepository;
        public ProductPurcesManager()
        {
            _dbContext = new DBContext(DatabaseConfiguration.ConnectionString);
            _iProductPurcesRepository = new ProductPurcesRepository(_dbContext);
        }
        public IEnumerable<ProductPurces> GetProductPurcesInfo()
        {
            try
            {
                _dbContext.Open();
                var users = _iProductPurcesRepository.GetProductPurcesInfo();
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
        public ProductPurces GetProductPurcesInfo(string employeeid)
        {
            try
            {
                _dbContext.Open();
                var userStatus = _iProductPurcesRepository.GetProductPurcesInfo(employeeid);
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
        public Message CreateOrUpdate(ProductPurces employee, int create)
        {
            var message = new Message();
            try
            {
                _dbContext.Open();
                _iProductPurcesRepository.CreateOrUpdate(employee, create);
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
                _iProductPurcesRepository.Delete(employeeid);
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
