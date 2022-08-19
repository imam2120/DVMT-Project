using PayRoll.Core.DAL.Interface;
using PayRoll.Core.Model;
using PayRoll.Core.Utility.DBManager;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayRoll.Core.DAL.Repository
{
    public class CommonRepository : ICommonRepository
    {
        public static DBContext _dbContext;
        public static AppSession session;
        public CommonRepository(DBContext dbContext)
        {
            _dbContext = dbContext;
            session = CurrentSession.GetCurrentSession();
        }

        public IEnumerable<UserStatus> GetUserStatuses()
        {
            string query = "select * from UserStatus";
            var data = _dbContext.GetDataTable(query);
            return from DataRow row in data.Rows select UserStatus.ConvertToModel(row);
        }
       
        public DataTable GetEmployeeBasicInfo(string EmployeeId)
        {
            string query = "";            
            query = "select * from Tbl_Employee a where a.EmployeeId='"+EmployeeId+"' ";                        
            var data = _dbContext.GetDataTable(query);
            return data;
        }

        public UserStatus GetAStatus(string statusId)
        {
            string query = "select * from UserStatus where StatusId = " + statusId + "";
            var data = _dbContext.GetDataTable(query);
            return (from DataRow row in data.Rows select UserStatus.ConvertToModel(row)).FirstOrDefault();
        }

        public IEnumerable<RoleWiseScreenPermission> GetModules(string roleId)
        {

            string strWhere = string.Empty;
            if (roleId != "0001")
            {
                strWhere = " and b.RoleId = '" + roleId + "'";
            }
            string query = "select g.ScreenId,g.ScreenName,g.URL,g.ParentScreenId,g.IconName from Screens g where g.ScreenId in ("
                          + " select a.ParentScreenId from Screens a where a.ScreenId in(select a.ScreenId from "
                          + " (select * from Screens s where s.ParentScreenId in (select s.ScreenId from Screens s where s.ParentScreenId='0000') )"
                          + " a inner join RoleWiseScreenPermission r on a.ScreenId=r.ScreenId where  r.RoleId='"+roleId+"'))";

            var data = _dbContext.GetDataTable(query);
            return (from DataRow row in data.Rows select RoleWiseScreenPermission.ConvertToModel(row));
        }

        public IEnumerable<RoleWiseScreenPermission> GetSubModules(string roleId, string parentScreenId)
        {

            string strWhere = string.Empty;
            if (roleId != "0001")
            {
                strWhere = " and b.RoleId = '" + roleId + "'";
            }
            string query = " SELECT  distinct   a.ScreenId, a.ScreenName, a.URL, a.ParentScreenId, a.IconName FROM  Screens AS a"
                           +" INNER JOIN (select * from  RoleWiseScreenPermission a where  a.RoleId='"+roleId+"'  )b "
                           + " ON a.ScreenId = b.ScreenId where a.ParentScreenId <> '0000' ";
            var data = _dbContext.GetDataTable(query);
            return (from DataRow row in data.Rows select RoleWiseScreenPermission.ConvertToModel(row));
        }

        public string GetServerDate()
        {

            string query = "select GetDate()";
            var data = _dbContext.GetQueryDate(query);
            return data;
        
        }

        public Permission GetScreenWisePermission(string screenCode)
        {
            string query = "select CanSave= (CASE WHEN left(a.Permission,1)=0 THEN 0 ELSE 1 END) , CanUpdate= (CASE WHEN substring(a.Permission,2,1)=0 THEN 0 ELSE 1 END), CanDelete= (CASE WHEN right(a.Permission,1)=0 THEN 0 ELSE 1 END) from RoleWiseScreenPermission a where a.RoleId='"+session.UserRoleId+"' and a.ScreenId='"+screenCode+"'";
            var data = _dbContext.GetDataTable(query);
            return (from DataRow row in data.Rows select Permission.ConvertToModel(row)).FirstOrDefault();

        
        }

        public DataTable GetDDlist(DDLSourceModel sourceModel)
        {
            var data = _dbContext.GetDDlist(sourceModel);
            return data;
        }

    }
}
