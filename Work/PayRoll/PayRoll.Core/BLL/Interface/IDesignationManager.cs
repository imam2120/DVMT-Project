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
    public interface IDesignationManager
    {
        IEnumerable<Designation> GetDesignation();
        Designation GetADesignation(string designationid);
        Message CreateOrUpdate(Designation designation, int create);
        Message Delete(string designationid);
       
    }
}