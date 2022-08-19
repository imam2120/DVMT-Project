using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayRoll.Core.Model
{
    public class UserRole
    {
        public string RoleId { get; set; }
        public string RoleName { get; set; }

        public static UserRole ConvertToModel(DataRow row)
        {
            return new UserRole
            {
                RoleId = row.Table.Columns.Contains("RoleId") ? Convert.ToString(row["RoleId"]) : "",
                RoleName = row.Table.Columns.Contains("RoleName") ? Convert.ToString(row["RoleName"]) : "",
            };

        }

    }
}
