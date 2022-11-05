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
        public string CreateBy { get; set; }
        public string CreateDate { get; set; }
        public string ModifyBy { get; set; }
        public string ModifyDate { get; set; }
        public static Department ConvertToModel(DataRow row)
        {
            return new Department
            {
                DepartmentId = row.Table.Columns.Contains("DepartmentId") ? Convert.ToInt32(row["DepartmentId"]) : 0,
                DepartmentName = row.Table.Columns.Contains("DepartmentName") ? Convert.ToString(row["DepartmentName"]) : "",
                Status = row.Table.Columns.Contains("Status") ? Convert.ToString(row["Status"]) : "",
                CreateBy = row.Table.Columns.Contains("CreateBy") ? Convert.ToString(row["CreateBy"]) : "",
                CreateDate = row.Table.Columns.Contains("CreateDate") ? Convert.ToString(row["CreateDate"]) : "",
                ModifyBy = row.Table.Columns.Contains("ModifyBy") ? Convert.ToString(row["ModifyBy"]) : "",
                ModifyDate = row.Table.Columns.Contains("ModifyDate") ? Convert.ToString(row["ModifyDate"]) : "",

            };

        }
    }
}
