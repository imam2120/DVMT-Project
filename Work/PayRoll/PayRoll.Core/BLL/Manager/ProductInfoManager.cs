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
    public class ProductInfoManager : IProductInfoManager
    {
        private readonly DBContext _dbContext;
        private readonly IProductInfoRepository _iProductInfoRepository;
        public ProductInfoManager()
        {
            _dbContext = new DBContext(DatabaseConfiguration.ConnectionString);
            _iProductInfoRepository = new ProductInfoRepository(_dbContext);
        }
        public IEnumerable<ProductInfo> GetProduct()
        {
            try
            {
                _dbContext.Open();
                var users = _iProductInfoRepository.GetProduct();
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
        public ProductInfo GetAProduct(string productid)
        {
            try
            {
                _dbContext.Open();
                var userStatus = _iProductInfoRepository.GetAProduct(productid);
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
        public Message CreateOrUpdate(ProductInfo product, int create)
        {
            var message = new Message();
            try
            {
                _dbContext.Open();
                _iProductInfoRepository.CreateOrUpdate(product, create);
                message = Message.SetMessages.SetSuccessMessage("Product Created Successfully");
            }
            catch (Exception ex)
            {
                message = Message.SetMessages.SetErrorMessage("Error in Creating Product" + ex.Message);
            }
            finally
            {
                _dbContext.Close();
            }

            return message;
        }
        public Message Delete(string productid)
        {
            var message = new Message();
            try
            {
                _dbContext.Open();
                _iProductInfoRepository.Delete(productid);
                message = Message.SetMessages.SetSuccessMessage("Product Deleted Successfully");
            }
            catch (Exception ex)
            {
                message = Message.SetMessages.SetErrorMessage("Error in Deleting Product" + ex.Message);
            }
            finally
            {
                _dbContext.Close();
            }

            return message;
        }
    }
}
