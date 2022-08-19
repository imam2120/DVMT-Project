using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayRoll.Core.Model
{
    public class UserInfo
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string UserFullName { get; set; }
        public string UserPassword { get; set; }
        public string UserRoleId { get; set; }
        public string UserStatusId { get; set; }
        public string UserTenancyId { set; get; }        
        public virtual UserRole UserRole { get; set; }
        public virtual UserStatus UserStatus { get; set; }
   

        public static UserInfo ConvertToRow(DataRow row, UserRole userRole = null, UserStatus userStatus = null)
        {
            return new UserInfo
            {
                UserId = row.Table.Columns.Contains("UserId") ? Convert.ToString(row["UserId"]) : "",
                UserName = row.Table.Columns.Contains("UserName") ? Convert.ToString(row["UserName"]) : "",
                UserFullName = row.Table.Columns.Contains("UserFullName") ? Convert.ToString(row["UserFullName"]) : "",
                UserPassword = row.Table.Columns.Contains("UserPassword") ? Convert.ToString(row["UserPassword"]) : "",
                UserRoleId = row.Table.Columns.Contains("UserRoleId") ? Convert.ToString(row["UserRoleId"]) : "",
                UserStatusId = row.Table.Columns.Contains("UserStatus") ? Convert.ToString(row["UserStatus"]) : "",
                UserTenancyId = row.Table.Columns.Contains("UserTenancyId") ? Convert.ToString(row["UserTenancyId"]) : "",                
                UserRole = userRole,
                UserStatus = userStatus,
               

            };
        }
    }
}
