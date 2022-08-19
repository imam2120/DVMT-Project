using PayRoll.Core.DAL.Interface;
using PayRoll.Core.Model;
using PayRoll.Core.Utility.DBManager;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayRoll.Core.DAL.Repository
{
    public class LoginRepository : ILoginRepository
    {

        public static DBContext _dbContext;
        public  static AppSession session;
       
        internal LoginRepository(DBContext dbContext)
        {
            _dbContext = dbContext;
            session = CurrentSession.GetCurrentSession();
        }

        public UserInfo GetLoginInfo(string userName, string password)
        {
            var strBuilder = new StringBuilder();
            strBuilder.Append("select UserId, UserName, UserPassword, UserRoleId, UserStatus from UserInfo where UserName = '" + userName + "'");
            var data = _dbContext.GetDataTable(strBuilder.ToString());            
            return (from DataRow row in data.Rows
                    let userRole = new UserRoleRepository(_dbContext).GetARole(Convert.ToString(row["UserRoleId"]))
                    let userStatus = new UserInfoRepository(_dbContext).GetAStatus(Convert.ToString(row["UserStatus"]))                    
                    select UserInfo.ConvertToRow(row, userRole, userStatus)).FirstOrDefault();
        }

        public UserInfo GetUserSession(string userName)
        {
            var strBuilder = new StringBuilder();
            strBuilder.Append("select UserId, UserName, UserPassword, UserRoleId, UserStatus from UserInfo where UserName = '" + userName + "'");
            var data = _dbContext.GetDataTable(strBuilder.ToString());
            return (from DataRow row in data.Rows
                    let userRole = new UserRoleRepository(_dbContext).GetARole(Convert.ToString(row["UserRoleId"]))
                    let userStatus = new  UserInfoRepository(_dbContext).GetAStatus(Convert.ToString(row["UserStatus"]))                    
                    select UserInfo.ConvertToRow(row, userRole, userStatus)).FirstOrDefault();
        }

    }
}
