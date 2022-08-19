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
    public class RoleWiseScreenRepository : IRoleWiseScreenRepository
    {
        public static DBContext _dbContext;
        public static AppSession session;

        public RoleWiseScreenRepository(DBContext dbContext)
        {
            _dbContext = dbContext;
            session = CurrentSession.GetCurrentSession();
        }
        List<InputParameter> _inPutParameters = new List<InputParameter>();

        public IEnumerable<RoleWiseScreenPermission> GetAllScreens(string roleId)
        {
            string query = "SELECT s.ScreenId,s.ScreenName,IsChecked=(CASE WHEN b.ScreenId IS NULL THEN 0 ELSE 1 END),IsSave= (CASE WHEN b.ScreenId IS NULL or left(b.Permission,1)=0 THEN 0 ELSE 1 END),IsUpdate= (CASE WHEN b.ScreenId IS NULL or substring(b.Permission,2,1)=0 THEN 0 ELSE 1 END),IsDelete= (CASE WHEN b.ScreenId IS NULL or right(b.Permission,1)=0 THEN 0 ELSE 1 END) FROM Screens s LEFT JOIN (SELECT * FROM RoleWiseScreenPermission rwsp WHERE rwsp.RoleId='" + roleId + "') b ON s.ScreenId=b.ScreenId  WHERE s.ParentScreenId<>'0000'";
            var data = _dbContext.GetDataTable(query);
            return (from DataRow row in data.Rows
                    select RoleWiseScreenPermission.ConvertToModel(row));
        }

        public void Create(string roleId, string screenId)
        {
            StringBuilder queryStr = new StringBuilder();
            queryStr.Append(" declare @parentScreenId as nchar(4)");
            queryStr.Append(" select @parentScreenId = ParentScreenId from Screens where ScreenId = '" + screenId + "' ");
            queryStr.Append(" delete from RoleWiseScreenPermission where RoleId = '" + roleId + "' and ScreenId = '" + screenId + "' ");
            queryStr.Append(" delete from RoleWiseScreenPermission where RoleId = '" + roleId + "' and ScreenId = @parentScreenId  " );
            queryStr.Append(" insert into RoleWiseScreenPermission(RoleId, ScreenId, SetDate, UserName) values('" + roleId + "', @parentScreenId, GETDATE(), '" + session.UserName + "')");
            queryStr.Append(" insert into RoleWiseScreenPermission(RoleId, ScreenId,SetDate, UserName) values('" + roleId + "', '" + screenId + "',GETDATE(), '" + session.UserName + "')");
            _dbContext.ExecuteQuery(queryStr.ToString());
        }

        public void Delete(string roleId, string screenId)
        {
            StringBuilder queryStr = new StringBuilder();
            queryStr.Append(" declare @parentScreenId as nchar(4)");
            queryStr.Append(" select @parentScreenId = ParentScreenId from Screens where ScreenId = '" + screenId + "' ");            
            queryStr.Append(" delete from RoleWiseScreenPermission where RoleId = '" + roleId + "' and ScreenId = '" + screenId + "'");
            _dbContext.ExecuteQuery(queryStr.ToString());
        }

        public void UpdateSpecificPermission(string roleId, string screenId, string action, string operationType)
        {

            StringBuilder queryStr = new StringBuilder();
          
            queryStr.Append(" Exec Sp_UpdateSpecificPermission @RoleId,@ScreenId,@OperationType,@Action");

            _inPutParameters.Clear();
            _inPutParameters.Add(new InputParameter{ ParameterName="@RoleId",ParameterType=DbType.String,ParameterValue=roleId});
            _inPutParameters.Add(new InputParameter{ ParameterName="@ScreenId",ParameterType=DbType.String,ParameterValue=screenId});
            _inPutParameters.Add(new InputParameter{ ParameterName="@OperationType",ParameterType=DbType.String,ParameterValue=operationType});
            _inPutParameters.Add(new InputParameter{ ParameterName="@Action",ParameterType=DbType.String,ParameterValue=action});            

            _dbContext.ExecuteQuery(queryStr.ToString(),_inPutParameters);
        
        }
    }
}
