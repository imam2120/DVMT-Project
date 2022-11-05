using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayRoll.Core.Model
{
    public class Designation
    {
        public string DesignationId { get; set; }
        public string DesignationName { get; set; }
        public string Status { get; set; }
        public string CreateBy { get; set; }
        public string CreateDate { get; set; }
        public string MakeBy { get; set; }
        public string MakeDate { get; set; }
        public static Designation ConvertToModel(DataRow row)
        {
            return new Designation
            {
                DesignationId = row.Table.Columns.Contains("DesignationId") ? Convert.ToString(row["DesignationId"]) : "",
                DesignationName = row.Table.Columns.Contains("DesignationName") ? Convert.ToString(row["DesignationName"]) : "",
                Status = row.Table.Columns.Contains("Status") ? Convert.ToString(row["Status"]) : "",
                CreateBy = row.Table.Columns.Contains("CreateBy") ? Convert.ToString(row["CreateBy"]) : "",
                CreateDate = row.Table.Columns.Contains("CreateDate") ? Convert.ToString(row["CreateDate"]) : "",
                MakeBy = row.Table.Columns.Contains("MakeBy") ? Convert.ToString(row["MakeBy"]) : "",
                MakeDate = row.Table.Columns.Contains("MakeDate") ? Convert.ToString(row["MakeDate"]) : "",                
            };

        }
    }
}
