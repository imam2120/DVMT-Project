using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayRoll.Core.Model
{
    public class SaleEntry
    {
        public string TransDate { get; set; }
        public string TransNo { get; set; }
        public string ProductCode { get; set; }
        public string EmpAccNo { get; set; }
        public string TargetAmount { get; set; }
        public string SaleAmount { get; set; }
        public string PendingAmount { get; set; }    
        public string ByCashAmount { get; set; }
        public string ByBankAmount { get; set; }
        public string DueAmount { get; set; }
        public string CusAccNo { get; set; }
        public string CurrBalance { get; set; }
        public string MakeBy { get; set; }
        public string MakeDate { get; set; }


        public static SaleEntry ConvertToModel(DataRow row)
        {
            return new SaleEntry
            {
                EmpAccNo = row.Table.Columns.Contains("EmpAccNo") ? Convert.ToString(row["EmpAccNo"]) : "",
                ProductCode = row.Table.Columns.Contains("ProductCode") ? Convert.ToString(row["ProductCode"]) : "",
                TargetAmount = row.Table.Columns.Contains("TargetAmount") ? Convert.ToString(row["TargetAmount"]) : "",
                SaleAmount = row.Table.Columns.Contains("SaleAmount") ? Convert.ToString(row["SaleAmount"]) : "",
                PendingAmount = row.Table.Columns.Contains("TotSalePending") ? Convert.ToString(row["TotSalePending"]) : "",
                ByCashAmount = row.Table.Columns.Contains("ByCashAmount") ? Convert.ToString(row["ByCashAmount"]) : "",
                ByBankAmount = row.Table.Columns.Contains("ByBankAmount") ? Convert.ToString(row["ByBankAmount"]) : "",
                CusAccNo = row.Table.Columns.Contains("CusAccNo") ? Convert.ToString(row["CusAccNo"]) : "",
                DueAmount = row.Table.Columns.Contains("DueAmount") ? Convert.ToString(row["DueAmount"]) : "",
                TransNo = row.Table.Columns.Contains("TransNo") ? Convert.ToString(row["TransNo"]) : "",
                MakeBy = row.Table.Columns.Contains("MakeBy") ? Convert.ToString(row["MakeBy"]) : "",
                MakeDate = row.Table.Columns.Contains("MakeDate") ? Convert.ToString(row["MakeDate"]) : "",
                
            };

        }
    }
}
