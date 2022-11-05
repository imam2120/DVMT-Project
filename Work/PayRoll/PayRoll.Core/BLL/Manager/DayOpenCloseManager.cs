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
    public class DayOpenCloseManager : IDayOpenCloseManager
    {
        private readonly DBContext _dbContext;
        private readonly IDayOpenCloseRepository idayOpenCloseRepository;

        public DayOpenCloseManager()
        {
            _dbContext = new DBContext(DatabaseConfiguration.ConnectionString);
            idayOpenCloseRepository = new DayOpenCloseRepository(_dbContext);
        }

        public Message CreateOrUpdate(DayOpenClose dayOpenClose, int create)
        {
            var message = new Message();
            var messgeType = "";
            if (dayOpenClose.Action == "0")
            {
                messgeType = "Close";
            }
            else
            {
                messgeType = "Open";
            }

            try
            {
                _dbContext.Open();
                idayOpenCloseRepository.CreateOrUpdate(dayOpenClose, create);
                message = Message.SetMessages.SetSuccessMessage("Day "+ messgeType + " Successfully");
            }
            catch (Exception ex)
            {
                message = Message.SetMessages.SetErrorMessage("Error in " + messgeType + " " + ex.Message);
            }
            finally
            {
                _dbContext.Close();
            }

            return message;
        }
    }
}
