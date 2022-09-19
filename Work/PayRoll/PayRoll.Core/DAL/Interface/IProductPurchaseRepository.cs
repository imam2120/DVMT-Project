using PayRoll.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayRoll.Core.DAL.Interface
{
   public interface IProductPurchaseRepository
    {
        void CreateOrUpdate(PreProductPurces preProductPurces, int create);
    }
}
