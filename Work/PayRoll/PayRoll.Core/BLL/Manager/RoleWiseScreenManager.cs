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

namespace PayRoll.Core.BLL.Interface
{
    public class RoleWiseScreenManager : IRoleWiseScreenManager
    {
        private readonly DBContext _dbContext;
        private readonly IRoleWiseScreenRepository _iRoleWiseScreenRepository;

        public RoleWiseScreenManager()
        {
            _dbContext = new DBContext(DatabaseConfiguration.ConnectionString);
            _iRoleWiseScreenRepository = new RoleWiseScreenRepository(_dbContext);
        }

        public IEnumerable<RoleWiseScreenPermission> GetAllScreens(string roleId)
        {

            try
            {
                _dbContext.Open();
                var screens = _iRoleWiseScreenRepository.GetAllScreens(roleId);
                return screens;
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

        public Message Create(string roleId, string screenId)
        {
            var message = new Message();            
            try
            {
                _dbContext.Open();
                _iRoleWiseScreenRepository.Create(roleId, screenId);
                message = Message.SetMessages.SetSuccessMessage("Screen Permission Saved Successfully");
            }
            catch (Exception ex)
            {
                message = Message.SetMessages.SetErrorMessage("Exception Occurred!!!!  Ex: " + ex.Message);
            }
            finally
            {
                _dbContext.Close();
            }

            return message;
        }


        public Message UpdateSpecificPermission(string roleId, string screenId, string action, string operationType)
        {
            var message = new Message();
            try
            {
                _dbContext.Open();
                _iRoleWiseScreenRepository.UpdateSpecificPermission(roleId, screenId, action, operationType);
                message = Message.SetMessages.SetSuccessMessage("Screen Permission Saved Successfully");
            }
            catch (Exception ex)
            {
                message = Message.SetMessages.SetErrorMessage("Exception Occurred!!!!  Ex: " + ex.Message);
            }
            finally
            {
                _dbContext.Close();
            }

            return message;
        }


        public Message Delete(string roleId, string screenId)
        {
            var message = new Message();
            try
            {
                _dbContext.Open();
                _iRoleWiseScreenRepository.Delete(roleId, screenId);
                message = Message.SetMessages.SetSuccessMessage("Screen Permission Deleted Successfully");
            }
            catch (Exception ex)
            {
                message = Message.SetMessages.SetErrorMessage("Exception Occurred!!!!  Ex: " + ex.Message);
            }
            finally
            {
                _dbContext.Close();
            }

            return message;
        }
    }
}
