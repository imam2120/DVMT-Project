using PayRoll.Core.Model;
using PayRoll.Core.Utility.DBManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayRoll.Core.DAL.Interface
{
    public interface IUserInfoRepository
    {
        IEnumerable<UserInfo> GetUsers();
        UserInfo GetAUser(string userName);
        void CreateOrUpdate(UserInfo userInfo, int create);
        void Delete(string userName);
        UserStatus GetAStatus(string statusId);
        IEnumerable<UserStatus> GetUserStatuses();
        int IsUserExist(string userName);


    }
}
