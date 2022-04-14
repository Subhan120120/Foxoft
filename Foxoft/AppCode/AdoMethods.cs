using DevExpress.XtraEditors;
using Microsoft.EntityFrameworkCore;
using Foxoft.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Foxoft
{
    public class AdoMethods
    {
        private string subConnString = Properties.Settings.Default.subConnString;
        private SqlParameter[] paramArray = new SqlParameter[] { };

        public int SqlExec(string query)
        {
            using (SqlConnection con = new SqlConnection(subConnString))
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    con.Open();

                    int result = cmd.ExecuteNonQuery();

                    if (result < 0)
                        XtraMessageBox.Show("Data Əlavə edilməsində xəta baş verdi!");
                    return result;
                }
            }
        }

        public int SqlExec(string query, SqlParameter[] sqlParameters)
        {
            using (SqlConnection con = new SqlConnection(subConnString))
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddRange(sqlParameters);
                    con.Open();

                    int result = cmd.ExecuteNonQuery();

                    if (result < 0)
                        XtraMessageBox.Show("Data Əlavə edilməsində xəta baş verdi!");
                    return result;
                }
            }
        }

        public DataTable SqlGetDt(string query)
        {
            using (SqlConnection con = new SqlConnection(subConnString))
            {
                using (SqlDataAdapter da = new SqlDataAdapter(query, con))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        public DataTable SqlGetDt(string query, SqlParameter[] sqlParameters)
        {
            using (SqlConnection con = new SqlConnection(subConnString))
            {
                using (SqlDataAdapter da = new SqlDataAdapter(query, con))
                {
                    da.SelectCommand.Parameters.AddRange(sqlParameters);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        public DataTable SelectInvoiceLines(DateTime StartDate, DateTime EndDate)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            string str = "Foxoft.AppCode.Qry_Sales.sql";
            string qry = "";
            using (Stream stream = assembly.GetManifestResourceStream(str))
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    qry = reader.ReadToEnd();
                }
            }

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
            using (Stream stream = assembly.GetManifestResourceStream(str))
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    qry = reader.ReadToEnd();
                }
            }

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

    }
}