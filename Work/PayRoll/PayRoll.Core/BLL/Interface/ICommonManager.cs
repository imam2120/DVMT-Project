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
    public interface ICommonManager
    {
        UserStatus GetAStatus(string statusId);
        IEnumerable<SelectListItem> GetUserStatuses();
        IEnumerable<SelectListItem> GetMonthsOfYear();
        IEnumerable<RoleWiseScreenPermission> GetModules(string roleId);
        IEnumerable<RoleWiseScreenPermission> GetSubModules(string roleId, string parentScreenId);
        string GetServerDate();
        Permission GetScreenWisePermission(string screenCode);
        IEnumerable<SelectListItem> GetAllMaritalStatus();
        Object GetEmployeeBasicInfo(string EmployeeId);
        IEnumerable<DDLSourceModel> GetDepartment(DDLSourceModel sourceModel);
        IEnumerable<DDLSourceModel> GetLoadCombo(DDLSourceModel sourceModel);

    }
}
