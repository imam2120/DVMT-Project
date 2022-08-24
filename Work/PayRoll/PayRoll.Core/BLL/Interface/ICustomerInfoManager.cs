using PayRoll.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayRoll.Core.BLL.Interface
{
   public interface ICustomerInfoManager
    {
        IEnumerable<CustomerInfo> GetCustomer();
        CustomerInfo GetACustomer(string CustomerId);
        Message CreateOrUpdate(CustomerInfo CustomerInfo, int create);
        Message Delete(string CustomerId);
    }
}
