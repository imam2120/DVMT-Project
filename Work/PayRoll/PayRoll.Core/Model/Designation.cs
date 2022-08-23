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
        public string CreatedBy { get; set; }
        public string CreatedDate { get; set; }
        public string MakeBy { get; set; }
        public string MakeDate { get; set; }
        public static Designation ConvertToModel(DataRow row)
        {
            return new Designation
            {
                DesignationId = row.Table.Columns.Contains("DesignationId") ? Convert.ToString(row["DesignationId"]) : "",
                DesignationName = row.Table.Columns.Contains("DesignationName") ? Convert.ToString(row["DesignationName"]) : "",
                Status = row.Table.Columns.Contains("Status") ? Convert.ToString(row["Status"]) : "",
                CreatedBy = row.Table.Columns.Contains("CreatedBy") ? Convert.ToString(row["CreatedBy"]) : "",
                CreatedDate = row.Table.Columns.Contains("CreatedDate") ? Convert.ToString(row["CreatedDate"]) : "",
                MakeBy = row.Table.Columns.Contains("MakeBy") ? Convert.ToString(row["MakeBy"]) : "",
                MakeDate = row.Table.Columns.Contains("MakeDate") ? Convert.ToString(row["MakeDate"]) : "",                
            };

        }
    }
}
