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
    public class SupplierInfoManager : ISupplierInfoManager
    {
        private readonly DBContext _dbContext;
        private readonly ISupplierInfoRepository _iSupplierInfoRepository;
        public SupplierInfoManager()
        {
            _dbContext = new DBContext(DatabaseConfiguration.ConnectionString);
            _iSupplierInfoRepository = new SupplierInfoRepository(_dbContext);
        }
        public IEnumerable<SupplierInfo> GetSupplier()
        {
            try
            {
                _dbContext.Open();
                var users = _iSupplierInfoRepository.GetSupplier();
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
        public SupplierInfo GetASupplier(string supplierId)
        {
            try
            {
                _dbContext.Open();
                var userStatus = _iSupplierInfoRepository.GetASupplier(supplierId);
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
        public Message CreateOrUpdate(SupplierInfo supplier, int create)
        {
            var message = new Message();
            try
            {
                _dbContext.Open();
                _iSupplierInfoRepository.CreateOrUpdate(supplier, create);
                message = Message.SetMessages.SetSuccessMessage("Supplier Created Successfully");
            }
            catch (Exception ex)
            {
                message = Message.SetMessages.SetErrorMessage("Error in Creating Supplier" + ex.Message);
            }
            finally
            {
                _dbContext.Close();
            }

            return message;
        }
        public Message Delete(string supplierId)
        {
            var message = new Message();
            try
            {
                _dbContext.Open();
                _iSupplierInfoRepository.Delete(supplierId);
                message = Message.SetMessages.SetSuccessMessage("Supplier Deleted Successfully");
            }
            catch (Exception ex)
            {
                message = Message.SetMessages.SetErrorMessage("Error in Deleting Supplier" + ex.Message);
            }
            finally
            {
                _dbContext.Close();
            }

            return message;
        }
    }
}
