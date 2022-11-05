using PayRoll.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace PayRoll.Controllers
{
    public class DailyPositionController : Controller
    {
        // GET: DayendPosition
        public ActionResult Index()
        {
            return View();
        }
        public RedirectResult RedirectToAspx()
        {
            return Redirect("/Reports/ReportViewer.aspx");
        }
        public void GenerateDailyPositionReport()
        {
            ReportParams<DailyPositionEntity> reportParams = new ReportParams<DailyPositionEntity>();
            reportParams.DataSource = GetReportData();
            reportParams.RptFileName = "rptDailyPositionReport.rpt";
            this.HttpContext.Session["ReportType"] = "rptDailyPositionReport";
            this.HttpContext.Session["ReportParam"] = reportParams;

            string path = Server.MapPath("~" + "/Reports/ReportViewer.aspx");

            
            Response.Redirect("../Reports/ReportViewer.aspx"); 

            //RedirectToAspx();
            //RedirectToAction("Reports/ReportViewer.aspx");
            //@Html.Partial("../Reports/Page.aspx");

        }

        public List<DailyPositionEntity> GetReportData()
        {
            string constring = ConfigurationManager.ConnectionStrings["SqlConnectionString"].ConnectionString;
            DataTable dataTable = new DataTable();
            string sqlQuery = "select EmployeeId,EmployeeName,PresentAddress as Address, DateOfBirth as JoinDate from Employee";
            SqlConnection con = new SqlConnection(constring);
            SqlCommand command = new SqlCommand(sqlQuery, con);
            SqlDataAdapter sda = new SqlDataAdapter(command);
            sda.Fill(dataTable);

            return (from DataRow row in dataTable.Rows select DailyPositionEntity.ConvertToModel(row)).ToList();

            //var list = ConvertDataTableToList<DailyPositionEntity>(dataTable);
            //return list;

        }
        //For List Convert
        public static List<T> ConvertDataTableToList<T>(DataTable dt)
        {
            List<T> data = new List<T>();
            foreach (DataRow row in dt.Rows)
            {
                T item = GetItems<T>(row);
                data.Add(item);
            }

            return data;
        }

        private static T GetItems<T>(DataRow dr)
        {
            Type temp = typeof(T);
            T obj = Activator.CreateInstance<T>();

            foreach (DataColumn column in dr.Table.Columns)
            {
                foreach (PropertyInfo pro in temp.GetProperties())
                {
                    if (pro.Name == column.ColumnName)
                        pro.SetValue(obj, dr[column.ColumnName], null);
                    else
                        continue;
                }
            }

            return obj;

        }

    }
}