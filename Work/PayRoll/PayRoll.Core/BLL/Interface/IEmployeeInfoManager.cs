using PayRoll.Core.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace PayRoll.Core.BLL.Interface
{
    public interface IEmployeeInfoManager
    {
        IEnumerable<EmployeeInfo> GetEmployee();
        EmployeeInfo GetAEmployee(string employeeid);
        Message CreateOrUpdate(EmployeeInfo employee, int create);
        Message Delete(string employeeid);
       
    }
}