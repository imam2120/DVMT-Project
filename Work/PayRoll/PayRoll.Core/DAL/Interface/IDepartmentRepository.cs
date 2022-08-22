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
    public interface IDepartmentRepository
    {
        IEnumerable<Department> GetDepartment();
        Department GetADepartment(string departmentid);
        void CreateOrUpdate(Department department, int create);
        void Delete(string departmentid);


    }
}
