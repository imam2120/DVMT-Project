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
    public interface IDepartmentManager
    {
        IEnumerable<Department> GetDepartment();
        Department GetADepartment(string departmentid);
        Message CreateOrUpdate(Department department, int create);
        Message Delete(string departmentid);
       
    }
}