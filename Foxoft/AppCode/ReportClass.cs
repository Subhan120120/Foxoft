using DevExpress.Data.Filtering;
using DevExpress.DataAccess.ConnectionParameters;
using DevExpress.DataAccess.DataFederation;
using DevExpress.DataAccess.Sql;
using DevExpress.Mvvm.POCO;
using DevExpress.XtraEditors;
using DevExpress.XtraReports;
using DevExpress.XtraReports.UI;
using Foxoft.Models;
using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace Foxoft
{
    class ReportClass
    {
        EfMethods efMethods = new();

        string designFolder;
        private string subConnString = Properties.Settings.Default.SubConnString;

        public ReportClass(string designFolder)
        {
            this.designFolder = designFolder;
        }

        public string SelectDesign()
        {
            string fileExt = string.Empty;
            OpenFileDialog file = new();
            file.InitialDirectory = designFolder;
            if (file.ShowDialog() == DialogResult.OK)
            {
                fileExt = Path.GetExtension(file.FileName);
                if (fileExt.CompareTo(".repx") == 0)
                    return file.FileName;
                else
                {
                    XtraMessageBox.Show("Yalnız .repx fayl seçə bilərsiniz", "Diqqət", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return "";
                }
            }
            else
                return "";
        }

        public XtraReport CreateReport(object datasource, string repxFileName)
        {
            string designPath = string.Empty;
            if (!string.IsNullOrEmpty(designFolder))
                if (CustomExtensions.DirectoryExist(designFolder))
                    designPath = designFolder + @"\" + repxFileName;

            if (!File.Exists(designPath))
                designPath = SelectDesign();
            if (File.Exists(designPath))
            {
                XtraReport report = new();
                report.LoadLayoutFromXml(designPath);

                report.DataSource = datasource;
                report.ShowPrintMarginsWarning = false;

                return report;
            }
            else
            {
                return null;
            }
        }

        public XtraReport GetReport(string dataSourceName, string repxFileName, IEnumerable<SqlQuery> sqlQueries)
        {
            using (SqlDataSource dataSource = new(new CustomStringConnectionParameters(subConnString)))
            {
                dataSource.Name = dataSourceName;
                dataSource.Queries.AddRange(sqlQueries);
                dataSource.Fill();

                return CreateReport(dataSource, repxFileName);
            }
        }

        public void ShowReport(DcReport dcReport, string filter, Form parent = null)
        {
            //string filter = CriteriaToWhereClauseHelper.GetMsSqlWhere(filterControl_Outer.FilterCriteria);
            switch (dcReport.ReportTypeId)
            {
                case 1: OpenGridReport(dcReport, filter, parent); break;
                case 2: OpenDetailReport(dcReport, filter, parent); break;
                default: OpenGridReport(dcReport, filter, parent); break;
            }
        }

        private void OpenGridReport(DcReport dcReport, string filter, Form parent = null)
        {
            try
            {
                FormReportGrid myform = new(dcReport.ReportQuery, filter, dcReport);

                myform.MdiParent = parent;
                myform.Show();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString());
            }
        }

        private void OpenDetailReport(DcReport dcReport, string filter, Form parent = null)
        {
            if (!string.IsNullOrEmpty(dcReport.ReportQuery))
            {
                FormReportPreview frm = new(dcReport.ReportQuery, filter, dcReport);
                frm.MdiParent = parent;
                frm.Show();
                frm.WindowState = FormWindowState.Maximized;
                //this.ParentForm.parentRibbonControl.SelectedPage = parentRibbonControl.MergedPages[0];
            }
        }

        public string ApplyFilter(DcReport dcReport, string query, string filter, out SqlParameter[] sqlParameters, int topCount = int.MaxValue)
        {
            string queryTop = AddTop(query, topCount);

            if (!string.IsNullOrEmpty(filter))
                queryTop = AddFilter(queryTop, filter);

            string queryReady = ReplaceFilters(queryTop, dcReport);

            sqlParameters = GetParameters(dcReport);

            return queryReady;
        }

        public string AddTop(string query, int topCount)
        {
            string trimmedQuery = query.Trim();
            int selectIndex = trimmedQuery.ToUpper().IndexOf("SELECT");

            if (selectIndex != -1 && trimmedQuery.ToUpper().Contains("ORDER BY"))
            {
                int orderByIndex = trimmedQuery.ToUpper().LastIndexOf("ORDER BY");

                if (orderByIndex != -1 && trimmedQuery.Substring(orderByIndex).Trim().ToUpper().StartsWith("ORDER BY"))// Ensure the "ORDER BY" is at the end of the query or followed by only valid SQL syntax
                {
                    string modifiedQuery = trimmedQuery.Insert(selectIndex + 6, $" TOP ({topCount})");
                    return modifiedQuery;
                }
            }

            return query;
        }

        private static string AddFilter(string queryTop, string filter)
        {
            string userQuery = @$" SELECT *, ROW_NUMBER() OVER (ORDER BY (SELECT NULL)) AS RowNum FROM ({queryTop + Environment.NewLine}) AS UserQuery";

            filter = !string.IsNullOrEmpty(filter) ? "WHERE " + filter : filter;

            string queryMaster = $@"SELECT * FROM ({userQuery}) AS queryMaster {filter} ORDER BY queryMaster.RowNum";
            return queryMaster;
        }

        public string ReplaceFilters(string sqlQuery, DcReport dcReport)
        {
            CriteriaOperator[] criteriaOperators = new CriteriaOperator[dcReport.DcReportVariables.Count];
            int index = 0;
            foreach (DcReportVariable rf in dcReport.DcReportVariables)
            {
                if (rf.VariableTypeId == 2)
                {
                    BinaryOperatorType operatorType = ConvertOperatorType(rf.VariableOperator);

                    string variableValue = rf.VariableValue;
                    if (rf.VariableValueType == "System.DateTime")
                        variableValue = DateTime.Parse(rf.VariableValue).ToString("yyyyMMdd");

                    criteriaOperators[index] = new BinaryOperator(rf.VariableProperty, variableValue, operatorType);

                    string filterSql = CriteriaToWhereClauseHelper.GetMsSqlWhere(criteriaOperators[index]);
                    sqlQuery = sqlQuery.Replace(rf.Representative, " and " + filterSql); //filter sorgunun icinde temsilci ile deyisdirilir

                    index++;
                }
            }
            return sqlQuery;
        }

        public SqlParameter[] GetParameters(DcReport report)
        {
            List<SqlParameter> sqlParameterList = new();
            foreach (DcReportVariable rf in report.DcReportVariables)
            {
                if (rf.VariableTypeId == 1)
                    sqlParameterList.Add(new SqlParameter()
                    {
                        ParameterName = rf.Representative,
                        Value = GetTypedValue(rf.VariableValue, rf.VariableValueType),
                        DbType = GetDbType(rf.VariableValueType)
                    });
            }

            return sqlParameterList.ToArray();
        }

        private static object GetTypedValue(string variableValue, string variableValueType)
        {
            if (variableValueType == "System.Guid")
            {
                return Guid.Parse(variableValue); // Explicitly parse Guid
            }

            return Convert.ChangeType(variableValue, Type.GetType(variableValueType));
        }

        private BinaryOperatorType ConvertOperatorType(string filterOperatorType)
        {
            return filterOperatorType switch
            {
                "+" => BinaryOperatorType.Plus,
                "&" => BinaryOperatorType.BitwiseAnd,
                "/" => BinaryOperatorType.Divide,
                "==" => BinaryOperatorType.Equal,
                ">" => BinaryOperatorType.Greater,
                ">=" => BinaryOperatorType.GreaterOrEqual,
                "<" => BinaryOperatorType.Less,
                "<=" => BinaryOperatorType.LessOrEqual,
                "%" => BinaryOperatorType.Modulo,
                "*" => BinaryOperatorType.Multiply,
                "!=" => BinaryOperatorType.NotEqual,
                "|" => BinaryOperatorType.BitwiseOr,
                "-" => BinaryOperatorType.Minus,
                "^" => BinaryOperatorType.BitwiseXor,
                _ => BinaryOperatorType.Equal,
            };
        }

        private DbType GetDbType(string type)
        {
            return type switch
            {
                "System.Byte" => DbType.Byte,
                "System.Sbyte" => DbType.SByte,
                "System.Short" => DbType.Int16,
                "System.Ushort" => DbType.UInt16,
                "System.Int" => DbType.Int32,
                "System.Uint" => DbType.UInt32,
                "System.Long" => DbType.Int64,
                "System.Ulong" => DbType.UInt64,
                "System.Float" => DbType.Single,
                "System.Double" => DbType.Double,
                "System.Decimal" => DbType.Decimal,
                "System.Bool" => DbType.Boolean,
                "System.String" => DbType.String,
                "System.Char" => DbType.StringFixedLength,
                "System.Guid" => DbType.Guid,
                "System.DateTime" => DbType.DateTime,
                "System.DateTimeOffset" => DbType.DateTimeOffset,
                "System.Byte[]" => DbType.Binary,
                "byte?" => DbType.Byte,
                "sbyte?" => DbType.SByte,
                "short?" => DbType.Int16,
                "ushort?" => DbType.UInt16,
                "int?" => DbType.Int32,
                "uint?" => DbType.UInt32,
                "long?" => DbType.Int64,
                "ulong?" => DbType.UInt64,
                "float?" => DbType.Single,
                "double?" => DbType.Double,
                "decimal?" => DbType.Decimal,
                "bool?" => DbType.Boolean,
                "char?" => DbType.StringFixedLength,
                "Guid?" => DbType.Guid,
                "DateTime?" => DbType.DateTime,
                "DateTimeOffset?" => DbType.DateTimeOffset,
                _ => DbType.String
            };
        }
    }
}
