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
    public class SaleEntryManager : ISaleEntryManager
    {
        private readonly DBContext _dbContext;
        private readonly ISaleEntryRepository _iSaleEntryRepository;
        public SaleEntryManager()
        {
            _dbContext = new DBContext(DatabaseConfiguration.ConnectionString);
            _iSaleEntryRepository = new SaleEntryRepository(_dbContext);
        }
        public Message CreateOrUpdate(SaleEntry saleEntry, int create)
        {
            var message = new Message();
            try
            {
                _dbContext.Open();
                _iSaleEntryRepository.CreateOrUpdate(saleEntry, create);
                message = Message.SetMessages.SetSuccessMessage("Transaction No " + saleEntry.TransNo + " Done Successfully");
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
