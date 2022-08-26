using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayRoll.Core.Model
{
    public class Department
    {
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public string Status { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedDate { get; set; }
        public string MakeBy { get; set; }
        public string MakeDate { get; set; }
        public static Department ConvertToModel(DataRow row)
        {
            return new Department
            {
                DepartmentId = row.Table.Columns.Contains("DepartmentId") ? Convert.ToInt32(row["DepartmentId"]) : 0,
                DepartmentName = row.Table.Columns.Contains("DepartmentName") ? Convert.ToString(row["DepartmentName"]) : "",
                Status = row.Table.Columns.Contains("Status") ? Convert.ToString(row["Status"]) : "",
                CreatedBy = row.Table.Columns.Contains("CreatedBy") ? Convert.ToString(row["CreatedBy"]) : "",
                CreatedDate = row.Table.Columns.Contains("CreatedDate") ? Convert.ToString(row["CreatedDate"]) : "",
                MakeBy = row.Table.Columns.Contains("MakeBy") ? Convert.ToString(row["MakeBy"]) : "",
                MakeDate = row.Table.Columns.Contains("MakeDate") ? Convert.ToString(row["MakeDate"]) : "",

            };

        }
    }
}
