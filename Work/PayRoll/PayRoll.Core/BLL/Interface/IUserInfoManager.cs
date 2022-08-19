using PayRoll.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace PayRoll.Core.BLL.Interface
{
    public interface IUserInfoManager
    {
        IEnumerable<UserInfo> GetUsers();
        UserInfo GetAUser(string userName);        
        UserStatus GetAStatus(string statusId);
        IEnumerable<UserStatus> GetUserStatuses();
        IEnumerable<SelectListItem> GetAllUserStatuses();
        Message CreateOrUpdate(UserInfo userInfo, int create);
        Message Delete(string userName);
        Message IsUserExist(string userName);
    }
}
