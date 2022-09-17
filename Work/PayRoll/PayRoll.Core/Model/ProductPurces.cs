using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayRoll.Core.Model
{
    public class ProductPurces
    {
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public string GLAccountNo { get; set; }
        public string OpeningBalance { get; set; }
        public string BalancePurces { get; set; }
        public string CurrentBalance { get; set; }
        public string SuplierAccNo { get; set; }
        public string DueAmountToSuplier { get; set; }
        public string PayAmountToSuplier { get; set; }
        public string PaymentType { get; set; }
        public string CreateBy { get; set; }
        public string CreateDate { get; set; }
        public string ModifyBy { get; set; }
        public string ModifyDate { get; set; }

        public static ProductPurces ConvertToModel(DataRow row)
        {
            return new ProductPurces
            {
                ProductId = row.Table.Columns.Contains("ProductId") ? Convert.ToString(row["ProductId"]) : "",
                ProductName = row.Table.Columns.Contains("ProductName") ? Convert.ToString(row["ProductName"]) : "",
                GLAccountNo = row.Table.Columns.Contains("GLAccountNo") ? Convert.ToString(row["GLAccountNo"]) : "",
                OpeningBalance = row.Table.Columns.Contains("OpeningBalance") ? Convert.ToString(row["OpeningBalance"]) : "",
                BalancePurces = row.Table.Columns.Contains("BalancePurces") ? Convert.ToString(row["BalancePurces"]) : "",
                CurrentBalance = row.Table.Columns.Contains("CurrentBalance") ? Convert.ToString(row["CurrentBalance"]) : "",
                SuplierAccNo = row.Table.Columns.Contains("SuplierAccNo") ? Convert.ToString(row["SuplierAccNo"]) : "",
                DueAmountToSuplier = row.Table.Columns.Contains("DueAmountToSuplier") ? Convert.ToString(row["DueAmountToSuplier"]) : "",
                PayAmountToSuplier = row.Table.Columns.Contains("PayAmountToSuplier") ? Convert.ToString(row["PayAmountToSuplier"]) : "",
                PaymentType = row.Table.Columns.Contains("PaymentType") ? Convert.ToString(row["PaymentType"]) : "",
                CreateBy = row.Table.Columns.Contains("CreateBy") ? Convert.ToString(row["CreateBy"]) : "",
                CreateDate = row.Table.Columns.Contains("CreateDate") ? Convert.ToString(row["CreateDate"]) : "",
                ModifyBy = row.Table.Columns.Contains("ModifyBy") ? Convert.ToString(row["ModifyBy"]) : "",
                ModifyDate = row.Table.Columns.Contains("ModifyDate") ? Convert.ToString(row["ModifyDate"]) : "",
            };

        }
    }
}
