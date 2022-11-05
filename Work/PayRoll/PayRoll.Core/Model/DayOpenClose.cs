using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayRoll.Core.Model
{
    public class DayOpenClose
    {
        public string TransDate { get; set; }
        public string OpenCloseByUser { get; set; }
        public string Action { get; set; }

        public static DayOpenClose ConvertToModel(DataRow row)
        {
            return new DayOpenClose
            {
                TransDate = row.Table.Columns.Contains("TransDate") ? Convert.ToString(row["TransDate"]) : "",
                OpenCloseByUser = row.Table.Columns.Contains("OpenCloseByUser") ? Convert.ToString(row["OpenCloseByUser"]) : "",
                Action = row.Table.Columns.Contains("Action") ? Convert.ToString(row["Action"]) : "",
            };
        }
    }
}
