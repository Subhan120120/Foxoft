using DevExpress.DataAccess.Sql;
using Foxoft.Models;
using System;
using System.IO;
using System.Reflection;

namespace Foxoft
{
    public class DsMethods
    {
        public CustomSqlQuery SelectInvoice(Guid invoiceHeader)
        {
            string qry = "";
            //Assembly assembly = Assembly.GetExecutingAssembly();
            //
            //using (Stream stream = assembly.GetManifestResourceStream("Foxoft.AppCode.SqlQuery.Qry_Invoice.sql"))
            //{
            //    using (StreamReader reader = new(stream))
            //    {
            //        qry = reader.ReadToEnd();
            //    }
            //}

            EfMethods efMethods = new();
            DcReport report = efMethods.SelectReportByName("Report_Embedded_InvoiceReport");

            QueryParameter queryParameter1 = new();
            queryParameter1.Name = "InvoiceHeaderId";
            queryParameter1.Type = typeof(Guid);
            queryParameter1.ValueInfo = invoiceHeader.ToString();

            CustomSqlQuery sqlQuerySale = new("Invoice", report.ReportQuery);
            sqlQuerySale.Parameters.Add(queryParameter1);

            return sqlQuerySale;
        }

        public CustomSqlQuery SelectDebtCustomers()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            string qry = "";
            using (Stream stream = assembly.GetManifestResourceStream("Foxoft.AppCode.SqlQuery.Qry_Debts.sql"))
            {
                using (StreamReader reader = new(stream))
                {
                    qry = reader.ReadToEnd();
                }
            }

            CustomSqlQuery sqlQuerySale = new("DebtCustomers", qry);

            return sqlQuerySale;
        }

        public CustomSqlQuery SelectDebtVendors()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            string qry = "";
            using (Stream stream = assembly.GetManifestResourceStream("Foxoft.AppCode.SqlQuery.Qry_DebtVendors.sql"))
            {
                using (StreamReader reader = new(stream))
                {
                    qry = reader.ReadToEnd();
                }
            }

            CustomSqlQuery sqlQuerySale = new("DebtVendors", qry);

            return sqlQuerySale;
        }

        public CustomSqlQuery SelectPaymentCustomers(DateTime StartDate, DateTime EndDate)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            string qry = "";
            using (Stream stream = assembly.GetManifestResourceStream("Foxoft.AppCode.SqlQuery.Qry_PaymentCustomers.sql"))
            {
                using (StreamReader reader = new(stream))
                {
                    qry = reader.ReadToEnd();
                }
            }

            QueryParameter queryParameter1 = new();
            queryParameter1.Name = "StartDate";
            queryParameter1.Type = typeof(DateTime);
            queryParameter1.ValueInfo = StartDate.ToString("yyyy-MM-dd");

            QueryParameter queryParameter2 = new();
            queryParameter2.Name = "EndDate";
            queryParameter2.Type = typeof(DateTime);
            queryParameter2.ValueInfo = EndDate.ToString("yyyy-MM-dd");

            CustomSqlQuery sqlQuerySale = new("PaymentCustomers", qry);
            sqlQuerySale.Parameters.AddRange(new QueryParameter[] { queryParameter1, queryParameter2 });

            return sqlQuerySale;
        }

        public CustomSqlQuery SelectPaymentVendors(DateTime StartDate, DateTime EndDate)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            string qry = "";
            using (Stream stream = assembly.GetManifestResourceStream("Foxoft.AppCode.SqlQuery.Qry_PaymentVendors.sql"))
            {
                using (StreamReader reader = new(stream))
                {
                    qry = reader.ReadToEnd();
                }
            }

            QueryParameter queryParameter1 = new();
            queryParameter1.Name = "StartDate";
            queryParameter1.Type = typeof(DateTime);
            queryParameter1.ValueInfo = StartDate.ToString("yyyy-MM-dd");

            QueryParameter queryParameter2 = new();
            queryParameter2.Name = "EndDate";
            queryParameter2.Type = typeof(DateTime);
            queryParameter2.ValueInfo = EndDate.ToString("yyyy-MM-dd");

            CustomSqlQuery sqlQuerySale = new("PaymentVendors", qry);
            sqlQuerySale.Parameters.AddRange(new QueryParameter[] { queryParameter1, queryParameter2 });

            return sqlQuerySale;
        }

        public CustomSqlQuery SelectSales(DateTime StartDate, DateTime EndDate)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            string qry = "";
            using (Stream stream = assembly.GetManifestResourceStream("Foxoft.AppCode.SqlQuery.Qry_Sales.sql"))
            {
                using (StreamReader reader = new(stream))
                {
                    qry = reader.ReadToEnd();
                }
            }

            QueryParameter queryParameter1 = new();
            queryParameter1.Name = "StartDate";
            queryParameter1.Type = typeof(DateTime);
            queryParameter1.ValueInfo = StartDate.ToString("yyyy-MM-dd");

            QueryParameter queryParameter2 = new();
            queryParameter2.Name = "EndDate";
            queryParameter2.Type = typeof(DateTime);
            queryParameter2.ValueInfo = EndDate.ToString("yyyy-MM-dd");

            CustomSqlQuery sqlQuerySale = new("Sales", qry);
            sqlQuerySale.Parameters.AddRange(new QueryParameter[] { queryParameter1, queryParameter2 });

            return sqlQuerySale;
        }

        public CustomSqlQuery SelectPayments(DateTime StartDate, DateTime EndDate)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            string str = "Foxoft.AppCode.SqlQuery.Qry_Payments.sql";
            string qry = "";
            using (Stream stream = assembly.GetManifestResourceStream(str))
            {
                using (StreamReader reader = new(stream))
                {
                    qry = reader.ReadToEnd();
                }
            }

            QueryParameter queryParameter1 = new();
            queryParameter1.Name = "StartDate";
            queryParameter1.Type = typeof(DateTime);
            queryParameter1.ValueInfo = StartDate.ToString("yyyy-MM-dd");

            QueryParameter queryParameter2 = new();
            queryParameter2.Name = "EndDate";
            queryParameter2.Type = typeof(DateTime);
            queryParameter2.ValueInfo = EndDate.ToString("yyyy-MM-dd");

            CustomSqlQuery sqlQueryPayment = new("Payments", qry);
            sqlQueryPayment.Parameters.AddRange(new QueryParameter[] { queryParameter1, queryParameter2 });

            return sqlQueryPayment;
        }

        public CustomSqlQuery SelectExpences(DateTime StartDate, DateTime EndDate)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            string qry = "";
            using (Stream stream = assembly.GetManifestResourceStream("Foxoft.AppCode.SqlQuery.Qry_Expences.sql"))
            {
                using (StreamReader reader = new(stream))
                {
                    qry = reader.ReadToEnd();
                }
            }

            QueryParameter queryParameter1 = new();
            queryParameter1.Name = "StartDate";
            queryParameter1.Type = typeof(DateTime);
            queryParameter1.ValueInfo = StartDate.ToString("yyyy-MM-dd");

            QueryParameter queryParameter2 = new();
            queryParameter2.Name = "EndDate";
            queryParameter2.Type = typeof(DateTime);
            queryParameter2.ValueInfo = EndDate.ToString("yyyy-MM-dd");

            CustomSqlQuery sqlQuerySale = new("Expences", qry);
            sqlQuerySale.Parameters.AddRange(new QueryParameter[] { queryParameter1, queryParameter2 });

            return sqlQuerySale;
        }

        public CustomSqlQuery SelectProduct(string ProductCode)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            string qry = "";
            using (Stream stream = assembly.GetManifestResourceStream("Foxoft.AppCode.SqlQuery.Qry_ProductBarcode.sql"))
            {
                using (StreamReader reader = new(stream))
                {
                    qry = reader.ReadToEnd();
                }
            }

            QueryParameter queryParameter = new("ProductCode", typeof(string), ProductCode);

            CustomSqlQuery sqlQuerySale = new("Product", qry);
            sqlQuerySale.Parameters.Add(queryParameter);

            return sqlQuerySale;
        }
    }
}
