using PayRoll.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayRoll.Core.BLL.Interface
{
   public interface ISupplierInfoManager
    {
        IEnumerable<SupplierInfo> GetSupplier();
        SupplierInfo GetASupplier(string supplierId);
        Message CreateOrUpdate(SupplierInfo supplierInfo, int create);
        Message Delete(string supplierId);
    }
}
