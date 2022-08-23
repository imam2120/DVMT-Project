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
        public string GLAccountNo { get; set; }
        public string SupplierName { get; set; }
        public string ContactPerson { get; set; }
        public string ContactNumber { get; set; }
        public string EmailAddress { get; set; }
        public string MailingAddress { get; set; }
        public string CurrentBalance { get; set; }
        public string DueBalance { get; set; }
        public string Status { get; set; }
        public string SetupDate { get; set; }
        public string UserId { get; set; }
        public string CreateBy { get; set; }
        public string CreateDate { get; set; }
        public string ModifyBy { get; set; }
        public string ModifyDate { get; set; }

        public static SupplierInfo ConvertToModel(DataRow row)
        {
            return new SupplierInfo
            {
                SupplierId = row.Table.Columns.Contains("SupplierId") ? Convert.ToString(row["SupplierId"]) : "",
                GLAccountNo = row.Table.Columns.Contains("GLAccountNo") ? Convert.ToString(row["GLAccountNo"]) : "",
                SupplierName = row.Table.Columns.Contains("SupplierName") ? Convert.ToString(row["SupplierName"]) : "",
                ContactPerson = row.Table.Columns.Contains("ContactPerson") ? Convert.ToString(row["ContactPerson"]) : "",
                ContactNumber = row.Table.Columns.Contains("ContactNumber") ? Convert.ToString(row["ContactNumber"]) : "",
                EmailAddress = row.Table.Columns.Contains("EmailAddress") ? Convert.ToString(row["EmailAddress"]) : "",
                MailingAddress = row.Table.Columns.Contains("MailingAddress") ? Convert.ToString(row["MailingAddress"]) : "",
                CurrentBalance = row.Table.Columns.Contains("CurrentBalance") ? Convert.ToString(row["CurrentBalance"]) : "",
                DueBalance = row.Table.Columns.Contains("DueBalance") ? Convert.ToString(row["DueBalance"]) : "",
                Status = row.Table.Columns.Contains("Status") ? Convert.ToString(row["Status"]) : "",
                SetupDate = row.Table.Columns.Contains("SetupDate") ? Convert.ToString(row["SetupDate"]) : "",
                UserId = row.Table.Columns.Contains("UserId") ? Convert.ToString(row["UserId"]) : "",
                CreateBy = row.Table.Columns.Contains("CreateBy") ? Convert.ToString(row["CreateBy"]) : "",
                CreateDate = row.Table.Columns.Contains("CreateDate") ? Convert.ToString(row["CreateDate"]) : "",
                ModifyBy = row.Table.Columns.Contains("ModifyBy") ? Convert.ToString(row["ModifyBy"]) : "",
                ModifyDate = row.Table.Columns.Contains("ModifyDate") ? Convert.ToString(row["ModifyDate"]) : "",
            };

        }
    }
}
