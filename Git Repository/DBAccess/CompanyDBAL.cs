﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace EmunaERP.DBAccess
{
    public class CompanyDBAL
    {
        string sqlConnection = Common.getConnection().ToString();
        public DataTable GetCompanyInfo()
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-134JQLJ;Initial Catalog=CRVLInventoryDatabase;User Id=sa;Password=sa123;pooling=true;min pool size=5;Max Pool Size=60;");
            conn.Open();
            SqlCommand dAd = new SqlCommand("CompanyInfo", conn);
            SqlDataAdapter sda = new SqlDataAdapter(dAd);
            dAd.CommandType = CommandType.StoredProcedure;
            dAd.CommandTimeout = 1000;
            //dAd.Parameters.AddWithValue("@FromDate", FromDate);
            //dAd.Parameters.AddWithValue("@ToDate", ToDate);
            //dAd.Parameters.AddWithValue("@QryOption", 1);

            DataTable dSet = new DataTable();

            //DataTable dSet = new DataTable();
            try
            {
                //sda.Fill(dSet);
                //return dSet;
                sda.Fill(dSet);
                return dSet;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dSet.Dispose();
                dAd.Dispose();
                conn.Close();
                conn.Dispose();
            }
        }
    }
}