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
    public interface IDesignationRepository
    {
        IEnumerable<Designation> GetDesignation();
        Designation GetADesignation(string designationid);
        void CreateOrUpdate(Designation designation, int create);
        void Delete(string designationid);


    }
}
