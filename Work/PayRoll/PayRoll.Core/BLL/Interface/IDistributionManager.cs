using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PayRoll.Core.Model;

namespace PayRoll.Core.BLL.Interface
{
    public interface IDistributionManager
    {
        IEnumerable<Distribution> GetEmployeeTarget();
        Message CreateOrUpdate(Distribution distribution, int create);
    }
}
