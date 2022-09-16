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
    public class ProductPurcesRepository : IProductPurcesRepository
    {
        public static DBContext _dbContext;
        public static AppSession session;
        public ProductPurcesRepository(DBContext dbContext)
        {
            _dbContext = dbContext;
            session = CurrentSession.GetCurrentSession();
        }
        public void CreateOrUpdate(ProductPurces purcesinfo, int create)
        {
            Dictionary<string, object> keyValues = new Dictionary<string, object>();
            keyValues.Add("@StatusId", "0");
            keyValues.Add("@ImagePath", string.Empty);
            keyValues.Add("@UserId", session.UserId);
            keyValues.Add("@Action", "1");

            string spName = "USP_EmployeeEntry";

            _dbContext.GetExecuteNonQuery(spName, keyValues);
        }

        public void Delete(string productId)
        {
            String query = String.Empty;
            query = "delete from Employee where EmployeeId = '" + productId + "' ";

            _dbContext.ExecuteQuery(query);
        }

        IEnumerable<ProductPurces> IProductPurcesRepository.GetProductPurcesInfo()
        {
            List<InputParameter> parameterList = new List<InputParameter>();
            InputParameter inputParameter = new InputParameter();
            inputParameter.ParameterName = "@Action";
            inputParameter.ParameterValue = 1;
            parameterList.Add(inputParameter);

            string spName = "USP_GetEmployee";
            var data = _dbContext.GetDataTableWithSP(spName, parameterList);
            return (from DataRow row in data.Rows select ProductPurces.ConvertToModel(row));
        }

        ProductPurces IProductPurcesRepository.GetProductPurcesInfo(string productId)
        {
            string query = "select * from Employee where EmployeeId = '" + productId + "' ";
            var data = _dbContext.GetDataTable(query);

            return (from DataRow row in data.Rows select ProductPurces.ConvertToModel(row)).FirstOrDefault();
        }
    }
}
