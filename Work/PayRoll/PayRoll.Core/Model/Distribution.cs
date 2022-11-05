using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayRoll.Core.Model
{
    public class Distribution
    {
        public string TransDate { get; set; }
        public string TransNo { get; set; }
        public string ProductAccNo { get; set; }
        public string PrdOpenBalance { get; set; }
        public string EmpAccNo { get; set; }
        public string OpeningBalance { get; set; }
        public string TargetAmount { get; set; }
        public string ClosingBalance { get; set; }

        public static Distribution ConvertToModel(DataRow row)
        {
            return new Distribution
            {
                TransDate = row.Table.Columns.Contains("TransDate") ? Convert.ToString(row["TransDate"]) : "",
                TransNo = row.Table.Columns.Contains("TransNo") ? Convert.ToString(row["TransNo"]) : "",
                ProductAccNo = row.Table.Columns.Contains("ProductAccNo") ? Convert.ToString(row["ProductAccNo"]) : "",
                PrdOpenBalance = row.Table.Columns.Contains("PrdOpenBalance") ? Convert.ToString(row["PrdOpenBalance"]) : "",
                EmpAccNo = row.Table.Columns.Contains("EmpAccNo") ? Convert.ToString(row["EmpAccNo"]) : "",
                OpeningBalance = row.Table.Columns.Contains("OpeningBalance") ? Convert.ToString(row["OpeningBalance"]) : "",
                TargetAmount = row.Table.Columns.Contains("TargetAmount") ? Convert.ToString(row["TargetAmount"]) : "",
                ClosingBalance = row.Table.Columns.Contains("ClosingBalance") ? Convert.ToString(row["ClosingBalance"]) : "",

            };

        }

    }
}
