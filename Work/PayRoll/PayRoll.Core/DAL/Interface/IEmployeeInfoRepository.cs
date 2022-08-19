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
    public interface IEmployeeInfoRepository
    {
        IEnumerable<EmployeeInfo> GetEmployee();
        EmployeeInfo GetAEmployee(string employeeid);
        void CreateOrUpdate(EmployeeInfo employee, int create);
        void Delete(string employeeid);


    }
}
