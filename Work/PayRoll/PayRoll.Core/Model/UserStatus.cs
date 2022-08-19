using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayRoll.Core.Model
{
    public class UserStatus
    {
        public string StatusId { get; set; }
        public string StatusName { get; set; }

        public static UserStatus ConvertToModel(DataRow row)
        {
            return new UserStatus
            {
                StatusId = row.Table.Columns.Contains("StatusId") ? Convert.ToString(row["StatusId"]) : "",
                StatusName = row.Table.Columns.Contains("StatusName") ? Convert.ToString(row["StatusName"]) : "",
            };

        }
    }
}
