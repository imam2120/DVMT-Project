using PayRoll.Core.BLL.Interface;
using PayRoll.Core.DAL.Interface;
using PayRoll.Core.DAL.Repository;
using PayRoll.Core.Model;
using PayRoll.Core.Utility.DBManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayRoll.Core.BLL.Manager
{
    public class ProductPurchaseManager : IProductPurchaseManager
    {
        private readonly DBContext _dbContext;
        private readonly IProductPurchaseRepository _iProductPurchaseRepository;
        public ProductPurchaseManager()
        {
            _dbContext = new DBContext(DatabaseConfiguration.ConnectionString);
            _iProductPurchaseRepository = new ProductPurchaseRepository(_dbContext);
        }
        public Message CreateOrUpdate(PreProductPurces preProductPurces, int create)
        {
            var message = new Message();
            try
            {
                _dbContext.Open();
                _iProductPurchaseRepository.CreateOrUpdate(preProductPurces, create);
                message = Message.SetMessages.SetSuccessMessage("Transaction No " + preProductPurces.TransNo + " Done Successfully");
            }
            catch (Exception ex)
            {
                message = Message.SetMessages.SetErrorMessage("Error in Creating Transaction" + ex.Message);
            }
            finally
            {
                _dbContext.Close();
            }

            return message;
        }
    }
}
