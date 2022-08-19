using PayRoll.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayRoll.Core.BLL.Interface
{
    public interface IRoleWiseScreenManager
    {
        IEnumerable<RoleWiseScreenPermission> GetAllScreens(string roleId);
        Message Create(string roleId, string screenId);
        Message Delete(string roleId, string screenId);
        Message UpdateSpecificPermission(string roleId, string screenId, string action, string operationType);
    }
}
