using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayRoll.Core.Model
{
   public class SupplierInfo
    {
        public string SupplierId { get; set; }
        public string SupplierName { get; set; }
        public string SupplierGLAC { get; set; }
        public string SupplierBalance { get; set; }
        public string PresentAddress { get; set; }
        public string PermanentAddress { get; set; }
        public string ContractNumber { get; set; }
        public string EmergencyNumber { get; set; }
        public string NID { get; set; }
        public string StatusId { get; set; }
        public string Image { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedDate { get; set; }
        public string ModifyBy { get; set; }
        public string ModifyDate { get; set; }

        public static SupplierInfo ConvertToModel(DataRow row)
        {
            return new SupplierInfo
            {
                SupplierId = row.Table.Columns.Contains("SupplierId") ? Convert.ToString(row["SupplierId"]) : "",
                SupplierName = row.Table.Columns.Contains("SupplierName") ? Convert.ToString(row["SupplierName"]) : "",
                SupplierGLAC = row.Table.Columns.Contains("SupplierGLAC") ? Convert.ToString(row["SupplierGLAC"]) : "",
                SupplierBalance = row.Table.Columns.Contains("SupplierBalance") ? Convert.ToString(row["SupplierBalance"]) : "",
                PresentAddress = row.Table.Columns.Contains("PresentAddress") ? Convert.ToString(row["PresentAddress"]) : "",
                PermanentAddress = row.Table.Columns.Contains("PermanentAddress") ? Convert.ToString(row["PermanentAddress"]) : "",
                ContractNumber = row.Table.Columns.Contains("ContractNumber") ? Convert.ToString(row["ContractNumber"]) : "",
                EmergencyNumber = row.Table.Columns.Contains("EmergencyNumber") ? Convert.ToString(row["EmergencyNumber"]) : "",
                NID = row.Table.Columns.Contains("NID") ? Convert.ToString(row["NID"]) : "",
                StatusId = row.Table.Columns.Contains("StatusId") ? Convert.ToString(row["StatusId"]) : "",
                Image = row.Table.Columns.Contains("Image") ? Convert.ToString(row["Image"]) : "",
                CreatedBy = row.Table.Columns.Contains("CreatedBy") ? Convert.ToString(row["CreatedBy"]) : "",
                CreatedDate = row.Table.Columns.Contains("CreatedDate") ? Convert.ToString(row["CreatedDate"]) : "",
                ModifyBy = row.Table.Columns.Contains("ModifyBy") ? Convert.ToString(row["ModifyBy"]) : "",
                ModifyDate = row.Table.Columns.Contains("ModifyDate") ? Convert.ToString(row["ModifyDate"]) : "",
            };

        }
    }
}
