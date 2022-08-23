﻿using PayRoll.Core.Model;
using PayRoll.Core.Utility.DBManager;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayRoll.Core.DAL.Interface
{
    public interface ISupplierInfoRepository
    {
        IEnumerable<SupplierInfo> GetSupplier();
        SupplierInfo GetASupplier(string supplierId);
        void CreateOrUpdate(SupplierInfo supplier, int create);
        void Delete(string supplierId);


    }
}
