using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayRoll.Core.Model
{
    public class ProductInfo
    {
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductGroup { get; set; }
        public string Unit { get; set; }
        public string CostPrice { get; set; }
        public string RetailSalePrice { get; set; }
        public string WholeSalePrice { get; set; }
        public string Status { get; set; }
        public string Retunable { get; set; }
        public string IsSync { get; set; }
        public string EffectiveDate { get; set; }
        public string ExpiryDate { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedDate { get; set; }
        public string ModifyBy { get; set; }
        public string ModifyDate { get; set; }

        public static ProductInfo ConvertToModel(DataRow row)
        {
            return new ProductInfo
            {
                ProductId = row.Table.Columns.Contains("ProductId") ? Convert.ToString(row["ProductId"]) : "",
                ProductName = row.Table.Columns.Contains("ProductName") ? Convert.ToString(row["ProductName"]) : "",
                ProductGroup = row.Table.Columns.Contains("ProductGroup") ? Convert.ToString(row["ProductGroup"]) : "",
                Unit = row.Table.Columns.Contains("Unit") ? Convert.ToString(row["Unit"]) : "",
                CostPrice = row.Table.Columns.Contains("CostPrice") ? Convert.ToString(row["CostPrice"]) : "",
                RetailSalePrice = row.Table.Columns.Contains("RetailSalePrice") ? Convert.ToString(row["RetailSalePrice"]) : "",
                WholeSalePrice = row.Table.Columns.Contains("WholeSalePrice") ? Convert.ToString(row["WholeSalePrice"]) : "",
                Status = row.Table.Columns.Contains("Status") ? Convert.ToString(row["Status"]) : "",
                Retunable = row.Table.Columns.Contains("Retunable") ? Convert.ToString(row["Retunable"]) : "",
                IsSync = row.Table.Columns.Contains("IsSync") ? Convert.ToString(row["IsSync"]) : "",
                EffectiveDate = row.Table.Columns.Contains("EffectiveDate") ? Convert.ToString(row["EffectiveDate"]) : "",
                ExpiryDate = row.Table.Columns.Contains("ExpiryDate") ? Convert.ToString(row["ExpiryDate"]) : "",
                CreatedBy = row.Table.Columns.Contains("CreatedBy") ? Convert.ToString(row["CreatedBy"]) : "",
                CreatedDate = row.Table.Columns.Contains("CreatedDate") ? Convert.ToString(row["CreatedDate"]) : "",
                ModifyBy = row.Table.Columns.Contains("ModifyBy") ? Convert.ToString(row["ModifyBy"]) : "",
                ModifyDate = row.Table.Columns.Contains("ModifyDate") ? Convert.ToString(row["ModifyDate"]) : "",
            };

        }
    }
}
