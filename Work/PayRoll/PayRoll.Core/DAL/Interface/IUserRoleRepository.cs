using PayRoll.Core.Model;
using PayRoll.Core.Utility.DBManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayRoll.Core.DAL.Interface
{
    public interface IUserRoleRepository
    {
        void CreateOrUpdate(UserRole userRole, int create);
        void Delete(UserRole userRole);
        UserRole GetARole(string roleId);
        IEnumerable<UserRole> GetRoles();
        string GenerateRoleId();
    }
}
