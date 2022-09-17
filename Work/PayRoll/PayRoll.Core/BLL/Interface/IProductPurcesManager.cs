using PayRoll.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayRoll.Core.BLL.Interface
{
    public interface IProductPurcesManager
    {
        IEnumerable<ProductPurces> GetProductPurcesInfo();
        ProductPurces GetProductPurcesInfo(string productId);
        Message CreateOrUpdate(ProductPurces purcesinfo, int create);
        Message Delete(string productId);
    }
}
