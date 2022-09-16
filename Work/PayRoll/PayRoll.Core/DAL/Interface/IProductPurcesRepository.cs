using PayRoll.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayRoll.Core.DAL.Interface
{
    public interface IProductPurcesRepository
    {
        IEnumerable<ProductPurces> GetProductPurcesInfo();
        ProductPurces GetProductPurcesInfo(string productId);
        void CreateOrUpdate(ProductPurces purcesinfo, int create);
        void Delete(string productId);
    }
}
