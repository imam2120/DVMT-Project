using PayRoll.Core.DAL.Interface;
using PayRoll.Core.Utility.DBManager;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayRoll.Core.Model
{
    public class UserRoleRepository : IUserRoleRepository
    {
        public static DBContext _dbContext;
        public static AppSession session;

        public UserRoleRepository(DBContext dbContext)
        {
            _dbContext = dbContext;
            session = CurrentSession.GetCurrentSession();
        }

        public string GenerateRoleId()
        {
            string roleId = "";
            string Qry = "select right('0000'+ cast(cast(isnull(max(RoleId), 0) as int)+1 as varchar), 4) from UserRole ";
            DataTable dtInfo = _dbContext.GetDataTable(Qry);
            roleId = dtInfo.Rows[0][0].ToString();
            return roleId;
        }
        public void CreateOrUpdate(UserRole userRole, int create)
        {
            String qryStr = String.Empty;
            if (create == 1)
            {

                qryStr = "insert into UserRole(RoleId, RoleName, SetDate, UserName) values('" + userRole.RoleId + "','" + userRole.RoleName + "' ,GETDATE(), '" + session.UserName + "')";

            }
            else
            {
                qryStr = "update UserRole set RoleName = '" + userRole.RoleName + "' where RoleId = '" + userRole.RoleId + "' ";
            }

            _dbContext.ExecuteQuery(qryStr);
        }

        public void Delete(UserRole userRole)
        {
            String qryStr = String.Empty;

            qryStr = "delete from UserRole where RoleId = '" + userRole.RoleId + "'";
            _dbContext.ExecuteQuery(qryStr);
        }

        public UserRole GetARole(string roleId)
        {
            string query = "select RoleId, RoleName from UserRole where RoleId = '" + roleId + "'";
            var data = _dbContext.GetDataTable(query);
            return (from DataRow row in data.Rows select UserRole.ConvertToModel(row)).FirstOrDefault();
        }

        public IEnumerable<UserRole> GetRoles()
        {
            string query = "select RoleId, RoleName from UserRole";
            var data = _dbContext.GetDataTable(query);
            return from DataRow row in data.Rows select UserRole.ConvertToModel(row);
        }
    }
}
