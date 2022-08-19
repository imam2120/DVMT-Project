using PayRoll.Core.Model;
using PayRoll.Core.Utility.DBManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayRoll.Core.DAL.Interface
{
    public interface IRoleWiseScreenRepository
    {
        IEnumerable<RoleWiseScreenPermission> GetAllScreens(string roleId);
        void Create(string roleId, string screenId);
        void Delete(string roleId, string screenId);
        void UpdateSpecificPermission(string roleId, string screenId, string action, string operationType);
    }
}
