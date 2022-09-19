using PayRoll.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayRoll.Core.BLL.Interface
{
   public interface IProductInfoManager
    {
        IEnumerable<ProductInfo> GetProduct();
        ProductInfo GetAProduct(string productid);
        Message CreateOrUpdate(ProductInfo product, int create);
    }
}
