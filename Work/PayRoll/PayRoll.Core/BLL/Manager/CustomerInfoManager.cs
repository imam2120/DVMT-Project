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
    public class CustomerInfoManager : ICustomerInfoManager
    {
        private readonly DBContext _dbContext;
        private readonly ICustomerInfoRepository _iCustomerInfoRepository;
        public CustomerInfoManager()
        {
            _dbContext = new DBContext(DatabaseConfiguration.ConnectionString);
            _iCustomerInfoRepository = new CustomerInfoRepository(_dbContext);
        }
        public IEnumerable<CustomerInfo> GetCustomer()
        {
            try
            {
                _dbContext.Open();
                var users = _iCustomerInfoRepository.GetCustomer();
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
        public CustomerInfo GetACustomer(string CustomerId)
        {
            try
            {
                _dbContext.Open();
                var userStatus = _iCustomerInfoRepository.GetACustomer(CustomerId);
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
        public Message CreateOrUpdate(CustomerInfo Customer, int create)
        {
            var message = new Message();
            try
            {
                _dbContext.Open();
                _iCustomerInfoRepository.CreateOrUpdate(Customer, create);
                message = Message.SetMessages.SetSuccessMessage("Customer Created Successfully");
            }
            catch (Exception ex)
            {
                message = Message.SetMessages.SetErrorMessage("Error in Creating Customer" + ex.Message);
            }
            finally
            {
                _dbContext.Close();
            }

            return message;
        }
        public Message Delete(string CustomerId)
        {
            var message = new Message();
            try
            {
                _dbContext.Open();
                _iCustomerInfoRepository.Delete(CustomerId);
                message = Message.SetMessages.SetSuccessMessage("Customer Deleted Successfully");
            }
            catch (Exception ex)
            {
                message = Message.SetMessages.SetErrorMessage("Error in Deleting Customer" + ex.Message);
            }
            finally
            {
                _dbContext.Close();
            }

            return message;
        }
    }
}
