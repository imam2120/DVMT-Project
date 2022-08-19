using PayRoll.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace PayRoll.Core.BLL.Interface
{
    public interface IUserRoleManager
    {
        Message CreateOrUpdate(UserRole userRole, int create);
        Message Delete(UserRole userRole);
        UserRole GetARole(string roleId);
        IEnumerable<UserRole> GetRoles();
        string GenerateRoleId();
        IEnumerable<SelectListItem> GetAllRoles();
    }
}
