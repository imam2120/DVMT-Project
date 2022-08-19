using PayRoll.Core.Model;
using PayRoll.Core.Utility.DBManager;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayRoll.Core.DAL.Interface
{
    public interface ICommonRepository
    {
              
        UserStatus GetAStatus(string statusId);
        string GetServerDate();
        IEnumerable<UserStatus> GetUserStatuses();
        IEnumerable<RoleWiseScreenPermission> GetModules(string roleId);
        IEnumerable<RoleWiseScreenPermission> GetSubModules(string roleId, string parentScreenId);
        Permission GetScreenWisePermission(string screenCode);
        DataTable GetEmployeeBasicInfo(string EmployeeId);
        DataTable GetDDlist(DDLSourceModel sourceModel);


    }
}
