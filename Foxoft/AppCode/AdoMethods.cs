﻿using DevExpress.XtraEditors;
using System;
using System.Configuration;
using System.Data;
using Microsoft.Data.SqlClient;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace Foxoft
{
    public class AdoMethods
    {

        private string subConnString = Properties.Settings.Default.SubConnString;


        private SqlParameter[] paramArray = Array.Empty<SqlParameter>();

        public int SqlExec(string query)
        {
            using SqlConnection con = new(subConnString);
            using SqlCommand cmd = new(query, con);
            con.Open();

            int result = cmd.ExecuteNonQuery();

            //if (result < 0)
            //    XtraMessageBox.Show("Data Əlavə edilməsində xəta baş verdi!");
            return result;
        }

        public int SqlExec(string query, SqlParameter[] sqlParameters)
        {
            using SqlConnection con = new(subConnString);
            using SqlCommand cmd = new(query, con);


            cmd.Parameters.AddRange(sqlParameters);
            con.Open();

            int result = cmd.ExecuteNonQuery();

            //if (result < 0)
            //    XtraMessageBox.Show("Data Əlavə edilməsində xəta baş verdi!");
            return result;
        }

        public DataTable SqlGetDt(string query)
        {
            using SqlConnection con = new(subConnString);
            con.Open();

            using SqlCommand cmd = new(query, con);

            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new();
            dt.Load(dr);

            ReflectionExt.SetCaptionName(dt);

            return dt;
        }

        public DataTable SqlGetDt(string query, SqlParameter[] sqlParameters)
        {
            using SqlConnection con = new(subConnString);
            using SqlDataAdapter da = new(query, con);

            da.SelectCommand.Parameters.AddRange(sqlParameters);
            DataTable dt = new();
            da.Fill(dt);

            if (dt.Columns.Contains("RowNum"))
                dt.Columns.Remove("RowNum");

            ReflectionExt.SetCaptionName(dt);

            return dt;
        }

        public DataTable SelectInvoiceLines(DateTime StartDate, DateTime EndDate)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            string str = "Foxoft.AppCode.Qry_Sales.sql";
            string qry = "";

            using Stream stream = assembly.GetManifestResourceStream(str);
            using StreamReader reader = new(stream);
            qry = reader.ReadToEnd();


            paramArray = new SqlParameter[]
            {
                new SqlParameter("@StartDate", StartDate),
                new SqlParameter("@EndDate", EndDate)
            };

            DataTable dt = SqlGetDt(qry, paramArray);
            dt.TableName = "trInvoiceLines";
            return dt;
        }

        public DataTable SelectPaymentLines(DateTime StartDate, DateTime EndDate)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            string str = "Foxoft.AppCode.Qry_Payments.sql";
            string qry = "";

            using Stream stream = assembly.GetManifestResourceStream(str);
            using StreamReader reader = new(stream);
            qry = reader.ReadToEnd();

            paramArray = new SqlParameter[]
            {
                new SqlParameter("@StartDate", StartDate),
                new SqlParameter("@EndDate", EndDate)
            };

            DataTable dt = SqlGetDt(qry, paramArray);
            dt.TableName = "trPaymentLines";
            return dt;
        }

        public DataTable SelectDebts(DateTime StartDate, DateTime EndDate)
        {
            string qry = "";
            paramArray = new SqlParameter[]
            {
                new SqlParameter("@StartDate", StartDate),
                new SqlParameter("@EndDate", EndDate)
            };

            DataTable dt = SqlGetDt(qry, paramArray);
            dt.TableName = "trPaymentLines";
            return dt;
        }

        public void customUpdateQry()
        {
            SqlExec("update report");
        }
    }
}