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
    public class UserInfoRepository : IUserInfoRepository
    {
        public static DBContext _dbContext;
        public static AppSession session;
      
        public UserInfoRepository(DBContext dbContext)
        {
            _dbContext = dbContext;
            session = CurrentSession.GetCurrentSession();
        }
        public IEnumerable <UserInfo> GetUsers()
        {
            string query = "select * from UserInfo ";
            var data = _dbContext.GetDataTable(query);
            return (from DataRow row in data.Rows
                    let userRole = new UserRoleRepository(_dbContext).GetARole(Convert.ToString(row["UserRoleId"]))
                    let userStatus = GetAStatus(Convert.ToString(row["UserStatus"]))                    
                    select UserInfo.ConvertToRow(row, userRole, userStatus));
        }
        public void CreateOrUpdate(UserInfo userInfo, int create)
        {
            String query = String.Empty;
            if (create == 1)
            {
                query = "insert into UserInfo(UserName,UserFullName, UserPassword, UserRoleId,UserStatus, SetDate, ModifyUser) ";
                query = query + "values('" + userInfo.UserName + "','" + userInfo.UserFullName + "', '" + userInfo.UserPassword + "', '" + userInfo.UserRoleId + "','" + userInfo.UserStatusId + "', GETDATE(), '" + userInfo.UserName + "')";
            }
            else
            {
                query = "update UserInfo set UserFullName = '" + userInfo.UserFullName + "', UserPassword = '" + userInfo.UserPassword + "', UserRoleId = '" + userInfo.UserRoleId + "', UserStatus = '" + userInfo.UserStatusId + "' where UserName = '" + userInfo.UserName + "' ";
            }

            _dbContext.ExecuteQuery(query);
        }
        public void Delete(string userName)
        {
            String query = String.Empty;
            query = "delete from UserInfo where UserName = '" + userName + "' ";
            _dbContext.ExecuteQuery(query);
        }
        public IEnumerable<UserStatus> GetUserStatuses()
        {
            string query = "select * from UserStatus ";
            var data = _dbContext.GetDataTable(query);
            return (from DataRow row in data.Rows select UserStatus.ConvertToModel(row));
        }
        public UserStatus GetAStatus(string statusId)
        {
            string query = "select * from UserStatus where StatusId = " + statusId + " ";
            var data = _dbContext.GetDataTable(query);
            return (from DataRow row in data.Rows select UserStatus.ConvertToModel(row)).FirstOrDefault();
        }
        public UserInfo GetAUser(string userName)
        {
            string query = "select * from UserInfo where UserName = '" + userName + "'";
            var data = _dbContext.GetDataTable(query);
            return (from DataRow row in data.Rows
                    let userRole = new UserRoleRepository(_dbContext).GetARole(Convert.ToString(row["UserRoleId"]))
                    let userStatus = GetAStatus(Convert.ToString(row["UserStatus"]))                    
                    select UserInfo.ConvertToRow(row, userRole, userStatus)).FirstOrDefault();
        }
        public UserInfo GetAUserById(string userId)
        {
            string query = "select * from UserInfo where UserId = '" + userId + "'";
            var data = _dbContext.GetDataTable(query);
            return (from DataRow row in data.Rows
                    let userRole = new UserRoleRepository(_dbContext).GetARole(Convert.ToString(row["UserRoleId"]))
                    let userStatus = GetAStatus(Convert.ToString(row["UserStatus"]))                    
                    select UserInfo.ConvertToRow(row, userRole, userStatus)).FirstOrDefault();
        }
        public int IsUserExist(string userName) 
        {
            string query = "select * from UserInfo where UserName = '" + userName + "'";
            var data = _dbContext.GetQueryInteger(query);
            return data;
        
        }
    }
}
