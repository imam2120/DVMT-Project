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
    public class DistributionManager : IDistributionManager
    {
        private readonly DBContext _dbContext;
        private readonly IDistributionRepository _iDistributionRepository;
        public DistributionManager()
        {
            _dbContext = new DBContext(DatabaseConfiguration.ConnectionString);
            _iDistributionRepository = new DistributionRepository(_dbContext);
        }
        public IEnumerable<Distribution> GetEmployeeTarget()
        {
            try
            {
                _dbContext.Open();
                var users = _iDistributionRepository.GetEmployeeTarget();
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
        public Message CreateOrUpdate(Distribution distribution, int create)
        {
            var message = new Message();
            try
            {
                _dbContext.Open();
                _iDistributionRepository.CreateOrUpdate(distribution, create);
                message = Message.SetMessages.SetSuccessMessage("Transaction No " + distribution.TransNo + " Done Successfully");
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
