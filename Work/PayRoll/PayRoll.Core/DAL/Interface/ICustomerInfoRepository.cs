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
    public interface ICustomerInfoRepository
    {
        IEnumerable<CustomerInfo> GetCustomer();
        CustomerInfo GetACustomer(string CustomerId);
        void CreateOrUpdate(CustomerInfo Customer, int create);
        void Delete(string CustomerId);


    }
}
