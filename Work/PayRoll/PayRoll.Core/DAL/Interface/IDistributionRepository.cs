using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PayRoll.Core.Model;

namespace PayRoll.Core.DAL.Interface
{
    public interface IDistributionRepository
    {
        IEnumerable<Distribution> GetEmployeeTarget();
        void CreateOrUpdate(Distribution distribution, int create);
        
    }
}
