using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PayRoll.Core.DAL.Interface;
using PayRoll.Core.Model;
using PayRoll.Core.Utility.DBManager;
using System.Data.SqlClient;
using System.Data.Common;

namespace PayRoll.Core.DAL.Repository
{
    public class ProductInfoRepository : IProductInfoRepository
    {
        public static DBContext _dbContext;
        public static AppSession session;
        public ProductInfoRepository(DBContext dbContext)
        {
            _dbContext = dbContext;
            session = CurrentSession.GetCurrentSession();
        }
        public void CreateOrUpdate(ProductInfo product, int create)
        {

            Dictionary<string, string> keyValues = new Dictionary<string, string>();
            keyValues.Add("@ProductId", product.ProductId);
            keyValues.Add("@ProductName", product.ProductName);
            keyValues.Add("@GLAccountNo", product.GLAccountNo);
            keyValues.Add("@Unit", "1");
            keyValues.Add("@CostPrice", product.CostPrice);
            keyValues.Add("@RetailSalePrice", product.RetailSalePrice);
            keyValues.Add("@WholeSalePrice", product.WholeSalePrice);
            keyValues.Add("@Balance", product.Balance);
            keyValues.Add("@Status", product.Status);
            keyValues.Add("@Retunable", "0");
            keyValues.Add("@IsSync", "0");
            keyValues.Add("@EffectiveDate", product.EffectiveDate);
            keyValues.Add("@ExpiryDate", product.ExpiryDate);
            keyValues.Add("@CreateBy", session.UserId);
            keyValues.Add("@CreateDate", product.CreateDate);
            keyValues.Add("@ModifyBy", product.ModifyBy);
            keyValues.Add("@ModifyDate", product.ModifyDate);
            keyValues.Add("@Action", "1");

            string spName = "USP_ProductEntry";

            _dbContext.GetExecuteNonQuery(spName, keyValues);

        }
        public void Delete(string productid)
        {
            String query = String.Empty;
            query = "Update a set a.Status = 2 from Product a where a.ProductId = '" + productid + "' ";

            _dbContext.ExecuteQuery(query);

        }
        public ProductInfo GetAProduct(string productid)
        {
            string query = "select * from Product where ProductId = '" + productid + "' ";
            var data = _dbContext.GetDataTable(query);

            return (from DataRow row in data.Rows select ProductInfo.ConvertToModel(row)).FirstOrDefault();
        }
        public IEnumerable<ProductInfo> GetProduct()
        {
            //string query = "select * from Tbl_Employee ";
            List<InputParameter> parameterList = new List<InputParameter>();
            InputParameter inputParameter = new InputParameter();
            inputParameter.ParameterName = "@Action";
            inputParameter.ParameterValue = 1;
            parameterList.Add(inputParameter);

            string spName = "USP_GetProduct"; //
            var data = _dbContext.GetDataTableWithSP(spName, parameterList);
            // var data = _dbContext.GetDataTable(query);
            return (from DataRow row in data.Rows select ProductInfo.ConvertToModel(row));
        }
    }
}
