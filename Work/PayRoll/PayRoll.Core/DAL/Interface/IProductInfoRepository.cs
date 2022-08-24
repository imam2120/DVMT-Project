using PayRoll.Core.Model;
using PayRoll.Core.Utility.DBManager;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayRoll.Core.DAL.Interface
{
    public interface IProductInfoRepository
    {
        IEnumerable<ProductInfo> GetProduct();
        ProductInfo GetAProduct(string productid);
        void CreateOrUpdate(ProductInfo product, int create);
        void Delete(string productid);


    }
}
