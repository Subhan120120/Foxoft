using DevExpress.DataAccess.Sql;
using System;
using System.IO;
using System.Reflection;

namespace Foxoft
{
    public class DsMethods
    {
        public CustomSqlQuery SelectInvoice(Guid invoiceHeader)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            string qry = "";
            using (Stream stream = assembly.GetManifestResourceStream("Foxoft.AppCode.SqlQuery.Qry_Invoice.sql"))
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    qry = reader.ReadToEnd();
                }
            }
            QueryParameter queryParameter1 = new QueryParameter();
            queryParameter1.Name = "invoiceHeader";
            queryParameter1.Type = typeof(Guid);
            queryParameter1.ValueInfo = invoiceHeader.ToString();

            CustomSqlQuery sqlQuerySale = new CustomSqlQuery();
            sqlQuerySale.Sql = qry;
            sqlQuerySale.Name = "Invoice";
            sqlQuerySale.Parameters.Add(queryParameter1);

            return sqlQuerySale;
        }

        public CustomSqlQuery SelectDebtCustomers()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            string qry = "";
            using (Stream stream = assembly.GetManifestResourceStream("Foxoft.AppCode.SqlQuery.Qry_Debts.sql"))
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    qry = reader.ReadToEnd();
                }
            }

            CustomSqlQuery sqlQuerySale = new CustomSqlQuery();
            sqlQuerySale.Name = "DebtCustomers";
            sqlQuerySale.Sql = qry;

            return sqlQuerySale;
        }

        public CustomSqlQuery SelectDebtVendors()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            string qry = "";
            using (Stream stream = assembly.GetManifestResourceStream("Foxoft.AppCode.SqlQuery.Qry_DebtVendors.sql"))
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    qry = reader.ReadToEnd();
                }
            }

            CustomSqlQuery sqlQuerySale = new CustomSqlQuery();
            sqlQuerySale.Name = "DebtVendors";
            sqlQuerySale.Sql = qry;

            return sqlQuerySale;
        }

        public CustomSqlQuery SelectPaymentCustomers(DateTime StartDate, DateTime EndDate)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            string qry = "";
            using (Stream stream = assembly.GetManifestResourceStream("Foxoft.AppCode.SqlQuery.Qry_PaymentCustomers.sql"))
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    qry = reader.ReadToEnd();
                }
            }

            QueryParameter queryParameter1 = new QueryParameter();
            queryParameter1.Name = "StartDate";
            queryParameter1.Type = typeof(DateTime);
            queryParameter1.ValueInfo = StartDate.ToString("yyyy-MM-dd");

            QueryParameter queryParameter2 = new QueryParameter();
            queryParameter2.Name = "EndDate";
            queryParameter2.Type = typeof(DateTime);
            queryParameter2.ValueInfo = EndDate.ToString("yyyy-MM-dd");

            CustomSqlQuery sqlQuerySale = new CustomSqlQuery();
            sqlQuerySale.Name = "PaymentCustomers";
            sqlQuerySale.Parameters.Add(queryParameter1);
            sqlQuerySale.Parameters.Add(queryParameter2);
            sqlQuerySale.Sql = qry;

            return sqlQuerySale;
        }

        public CustomSqlQuery SelectPaymentVendors(DateTime StartDate, DateTime EndDate)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            string qry = "";
            using (Stream stream = assembly.GetManifestResourceStream("Foxoft.AppCode.SqlQuery.Qry_PaymentVendors.sql"))
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    qry = reader.ReadToEnd();
                }
            }

            QueryParameter queryParameter1 = new QueryParameter();
            queryParameter1.Name = "StartDate";
            queryParameter1.Type = typeof(DateTime);
            queryParameter1.ValueInfo = StartDate.ToString("yyyy-MM-dd");

            QueryParameter queryParameter2 = new QueryParameter();
            queryParameter2.Name = "EndDate";
            queryParameter2.Type = typeof(DateTime);
            queryParameter2.ValueInfo = EndDate.ToString("yyyy-MM-dd");

            CustomSqlQuery sqlQuerySale = new CustomSqlQuery();
            sqlQuerySale.Name = "PaymentVendors";
            sqlQuerySale.Parameters.Add(queryParameter1);
            sqlQuerySale.Parameters.Add(queryParameter2);
            sqlQuerySale.Sql = qry;

            return sqlQuerySale;
        }

        public CustomSqlQuery SelectSales(DateTime StartDate, DateTime EndDate)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            string qry = "";
            using (Stream stream = assembly.GetManifestResourceStream("Foxoft.AppCode.SqlQuery.Qry_Sales.sql"))
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    qry = reader.ReadToEnd();
                }
            }

            QueryParameter queryParameter1 = new QueryParameter();
            queryParameter1.Name = "StartDate";
            queryParameter1.Type = typeof(DateTime);
            queryParameter1.ValueInfo = StartDate.ToString("yyyy-MM-dd");

            QueryParameter queryParameter2 = new QueryParameter();
            queryParameter2.Name = "EndDate";
            queryParameter2.Type = typeof(DateTime);
            queryParameter2.ValueInfo = EndDate.ToString("yyyy-MM-dd");

            CustomSqlQuery sqlQuerySale = new CustomSqlQuery();
            sqlQuerySale.Name = "Sales";
            sqlQuerySale.Parameters.Add(queryParameter1);
            sqlQuerySale.Parameters.Add(queryParameter2);
            sqlQuerySale.Sql = qry;

            return sqlQuerySale;
        }

        public CustomSqlQuery SelectPayments(DateTime StartDate, DateTime EndDate)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            string str = "Foxoft.AppCode.SqlQuery.Qry_Payments.sql";
            string qry = "";
            using (Stream stream = assembly.GetManifestResourceStream(str))
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    qry = reader.ReadToEnd();
                }
            }

            QueryParameter queryParameter1 = new QueryParameter();
            queryParameter1.Name = "StartDate";
            queryParameter1.Type = typeof(DateTime);
            queryParameter1.ValueInfo = StartDate.ToString("yyyy-MM-dd");

            QueryParameter queryParameter2 = new QueryParameter();
            queryParameter2.Name = "EndDate";
            queryParameter2.Type = typeof(DateTime);
            queryParameter2.ValueInfo = EndDate.ToString("yyyy-MM-dd");

            CustomSqlQuery sqlQueryPayment = new CustomSqlQuery();
            sqlQueryPayment.Name = "Payments";
            sqlQueryPayment.Parameters.Add(queryParameter1);
            sqlQueryPayment.Parameters.Add(queryParameter2);

            sqlQueryPayment.Sql = qry;

            return sqlQueryPayment;
        }

        public CustomSqlQuery SelectExpences(DateTime StartDate, DateTime EndDate)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            string qry = "";
            using (Stream stream = assembly.GetManifestResourceStream("Foxoft.AppCode.SqlQuery.Qry_Expences.sql"))
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    qry = reader.ReadToEnd();
                }
            }

            QueryParameter queryParameter1 = new QueryParameter();
            queryParameter1.Name = "StartDate";
            queryParameter1.Type = typeof(DateTime);
            queryParameter1.ValueInfo = StartDate.ToString("yyyy-MM-dd");

            QueryParameter queryParameter2 = new QueryParameter();
            queryParameter2.Name = "EndDate";
            queryParameter2.Type = typeof(DateTime);
            queryParameter2.ValueInfo = EndDate.ToString("yyyy-MM-dd");

            CustomSqlQuery sqlQuerySale = new CustomSqlQuery();
            sqlQuerySale.Name = "Expences";
            sqlQuerySale.Parameters.Add(queryParameter1);
            sqlQuerySale.Parameters.Add(queryParameter2);
            sqlQuerySale.Sql = qry;

            return sqlQuerySale;
        }
    }
}
