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
    public class LoginManager : ILoginManager
    {
        private readonly ILoginRepository _iLoginRepository;
        private readonly DBContext _dbContext;

        public LoginManager()
        {
            _dbContext = new DBContext(DatabaseConfiguration.ConnectionString);
            _iLoginRepository = new LoginRepository(_dbContext);
        }

        public Message DoLogin(string userName, string password)
        {
            var message = new Message();
            try
            {
                _dbContext.Open();
                var logininfo = _iLoginRepository.GetLoginInfo(userName, password);
                if (logininfo != null)
                {
                    message = !string.Equals(logininfo.UserPassword, password) ?
                        Message.SetMessages.SetErrorMessage("Invalid Login Credentials") :
                        Message.SetMessages.SetSuccessMessage("Login successfull");
                }
                else
                {
                    message = Message.SetMessages.SetErrorMessage("Invalid Username or Password!!! Please Check...");
                }
            }
            catch (Exception ex)
            {
                message = Message.SetMessages.SetErrorMessage("Exception Occurred!!!!!! Ex Message : " + ex.Message);
            }
            finally
            {
                _dbContext.Close();
            }

            return message;
        }

        public UserInfo GetUserSession(string userName)
        {

            try
            {
                _dbContext.Open();
                var data = _iLoginRepository.GetUserSession(userName);
                return data;
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
    }
}
