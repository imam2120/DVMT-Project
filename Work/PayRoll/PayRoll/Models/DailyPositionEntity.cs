using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace PayRoll.Models
{
    public class DailyPositionEntity
    {
        public string EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string JoinDate { get; set; }
        public string Address { get; set; }
        public string ProductId { get; set; }

        public static DailyPositionEntity ConvertToModel(DataRow row)
        {
            return new DailyPositionEntity
            {
                EmployeeId = row.Table.Columns.Contains("EmployeeId") ? Convert.ToString(row["EmployeeId"]) : ""
            };
        }
    }
}