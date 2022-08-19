using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayRoll.Core.Model
{
    public class RoleWiseScreenPermission
    {
        public string ScreenId { get; set; }
        public string ScreenName { get; set; }
        public string RoleId { get; set; }
        public bool IsChecked { get; set; }
        public bool IsSave { get; set; }
        public bool IsUpdate { get; set; }
        public bool IsDelete { get; set; }
        public string URL { get; set; }
        public string ParentScreenId { get; set; }
        public string IconName { get; set; }

        public static RoleWiseScreenPermission ConvertToModel(DataRow row)
        {
            return new RoleWiseScreenPermission
            {
                ScreenId = row.Table.Columns.Contains("ScreenId") ? Convert.ToString(row["ScreenId"]) : "",
                ScreenName = row.Table.Columns.Contains("ScreenName") ? Convert.ToString(row["ScreenName"]) : "",
                RoleId = row.Table.Columns.Contains("RoleId") ? Convert.ToString(row["RoleId"]) : "",
                IsChecked = row.Table.Columns.Contains("IsChecked") ? Convert.ToBoolean(row["IsChecked"]) : false,
                IsSave = row.Table.Columns.Contains("IsSave") ? Convert.ToBoolean(row["IsSave"]) : false,
                IsUpdate = row.Table.Columns.Contains("IsUpdate") ? Convert.ToBoolean(row["IsUpdate"]) : false,
                IsDelete = row.Table.Columns.Contains("IsDelete") ? Convert.ToBoolean(row["IsDelete"]) : false,
                URL = row.Table.Columns.Contains("URL") ? Convert.ToString(row["URL"]) : "",
                ParentScreenId = row.Table.Columns.Contains("ParentScreenId") ? Convert.ToString(row["ParentScreenId"]) : "",
                IconName = row.Table.Columns.Contains("IconName") ? Convert.ToString(row["IconName"]) : "",

            };
        }
    }
}
