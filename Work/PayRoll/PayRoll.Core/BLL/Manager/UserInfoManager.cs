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
using System.Web.Mvc;

namespace PayRoll.Core.BLL.Interface
{
    public class UserInfoManager : IUserInfoManager
    {
        private readonly DBContext _dbContext;
        private readonly IUserInfoRepository _iUserInfoRepository;
        public UserInfoManager()
        {
            _dbContext = new DBContext(DatabaseConfiguration.ConnectionString);
            _iUserInfoRepository = new UserInfoRepository(_dbContext);
        }

        public IEnumerable<UserInfo> GetUsers()
        {
            try
            {
                _dbContext.Open();
                var users = _iUserInfoRepository.GetUsers();
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
        public UserInfo GetAUser(string userName)
        {
            try
            {
                _dbContext.Open();
                var user = _iUserInfoRepository.GetAUser(userName);
                return user;
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
        public UserStatus GetAStatus(string statusId)
        {
            try
            {
                _dbContext.Open();
                var userStatus = _iUserInfoRepository.GetAStatus(statusId);
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
        public IEnumerable<UserStatus> GetUserStatuses()
        {
            try
            {
                _dbContext.Open();
                var userStatuss = _iUserInfoRepository.GetUserStatuses();
                return userStatuss;
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
        public IEnumerable<SelectListItem> GetAllUserStatuses()
        {
            try
            {
                _dbContext.Open();
                var ustatuses = _iUserInfoRepository.GetUserStatuses().Select(
                    o => new SelectListItem
                    {
                        Value = o.StatusId,
                        Text = o.StatusName
                    }).ToList();
                return ustatuses;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                _dbContext.Close();
            }
        }
        public Message IsUserExist(string userName)
        {
            var message = new Message();
            try
            {
                _dbContext.Open();
                if (_iUserInfoRepository.IsUserExist(userName) == 1)
                {
                    message = Message.SetMessages.SetWarningMessage("This User Name already exist ?");
                }
                else
                {
                    message = Message.SetMessages.SetSuccessMessage("This User Name not exist ?");
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {

            }
            return message;

        }
        public Message CreateOrUpdate(UserInfo userInfo, int create)
        {
            var message = new Message();
            try
            {
                _dbContext.Open();
                _iUserInfoRepository.CreateOrUpdate(userInfo, create);
                message = Message.SetMessages.SetSuccessMessage("User Created Successfully");
            }
            catch (Exception ex)
            {
                message = Message.SetMessages.SetErrorMessage("Error in Creating User" + ex.Message);
            }
            finally
            {
                _dbContext.Close();
            }

            return message;
        }
        public Message Delete(string userName)
        {

            var message = new Message();
            try
            {
                _dbContext.Open();
                _iUserInfoRepository.Delete(userName);
                message = Message.SetMessages.SetSuccessMessage("User Deleted Successfully");
            }
            catch (Exception ex)
            {
                message = Message.SetMessages.SetErrorMessage("Error in Deleting User" + ex.Message);
            }
            finally
            {
                _dbContext.Close();
            }

            return message;
        }

    }
}
