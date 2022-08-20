﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayRoll.Core.Model
{
    public class ScreenList
    {
        public enum Screens
        {
            UserRole = 1001,
            UserInfo = 1002,
            EmployeeInfo = 2001,
            SupplierInfo = 3001,
            CustomerInfo = 3002,
            ProductPurces = 4001,
            Distribution = 4002,
            SaleEntry = 4003,
            DayClose = 5001,
            DayOpen = 5002,
            ProductSetup = 6001
        }
    }
}