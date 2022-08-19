using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayRoll.Core.Model
{
    public class CustomerInfo
    {
        public string CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerGLAC { get; set; }
        public string CustomerBalance { get; set; }
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

        public static CustomerInfo ConvertToModel(DataRow row)
        {
            return new CustomerInfo
            {
                CustomerId = row.Table.Columns.Contains("CustomerId") ? Convert.ToString(row["CustomerId"]) : "",
                CustomerName = row.Table.Columns.Contains("CustomerName") ? Convert.ToString(row["CustomerName"]) : "",
                CustomerGLAC = row.Table.Columns.Contains("CustomerGLAC") ? Convert.ToString(row["CustomerGLAC"]) : "",
                CustomerBalance = row.Table.Columns.Contains("CustomerBalance") ? Convert.ToString(row["CustomerBalance"]) : "",
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
