using DevExpress.Data.Filtering;
using DevExpress.DataAccess.Sql;
using DevExpress.Utils;
using DevExpress.XtraBars;
using Foxoft.Models;
using Microsoft.Data.SqlClient;
using DevExpress.XtraBars.Ribbon;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using Foxoft.Properties;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using DevExpress.XtraGrid.Views.Grid;
using System.Globalization;

namespace Foxoft.AppCode
{
    public class CustomMethods
    {
        EfMethods efMethods = new EfMethods();
        public string EncryptString(string plainText, string key, string iv)
        {
            byte[] keyBytes = Encoding.UTF8.GetBytes(key);
            byte[] ivBytes = Encoding.UTF8.GetBytes(iv);

            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = keyBytes;
                aesAlg.IV = ivBytes;

                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            swEncrypt.Write(plainText);
                        }
                        return Convert.ToBase64String(msEncrypt.ToArray());
                    }
                }
            }
        }

        public string DecryptString(string cipherText, string key, string iv)
        {
            byte[] keyBytes = Encoding.UTF8.GetBytes(key);
            byte[] ivBytes = Encoding.UTF8.GetBytes(iv);
            byte[] cipherTextBytes = Convert.FromBase64String(cipherText);

            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = keyBytes;
                aesAlg.IV = ivBytes;

                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                using (MemoryStream msDecrypt = new MemoryStream(cipherTextBytes))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {
                            return srDecrypt.ReadToEnd();
                        }
                    }
                }
            }
        }

        public string ApplyFilter(DcReport dcReport, string query, string filter, out SqlParameter[] sqlParameters, int topCount = int.MaxValue)
        {
            string queryTop = AddTop(query, int.MaxValue);

            if (!string.IsNullOrEmpty(filter))
                queryTop = AddFilter(queryTop, filter);

            string queryReady = ReplaceFilters(queryTop, dcReport);

            sqlParameters = GetParameters(dcReport);

            return queryReady;
        }

        private static string AddFilter(string queryTop, string filter)
        {
            string userQuery = @$" SELECT *, ROW_NUMBER() OVER (ORDER BY (SELECT NULL)) AS RowNum FROM ({queryTop + Environment.NewLine}) AS UserQuery";

            filter = !string.IsNullOrEmpty(filter) ? "WHERE " + filter : filter;

            string queryMaster = $@"SELECT * FROM ({userQuery}) AS queryMaster {filter} ORDER BY queryMaster.RowNum";
            return queryMaster;
        }

        public List<QueryParameter> ConvertSqlParametersToQueryParameters(SqlParameter[] sqlParameters)
        {
            List<QueryParameter> queryParameters = new List<QueryParameter>();

            foreach (var sqlParam in sqlParameters)
            {
                QueryParameter queryParam = new QueryParameter
                {
                    Name = sqlParam.ParameterName,
                    Type = ConvertSqlDbTypeToType(sqlParam.SqlDbType), // This maps SQL type from SqlParameter
                    Value = sqlParam.Value
                };

                queryParameters.Add(queryParam);
            }

            return queryParameters;
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

        public string RemoveComments(string sql)
        {
            // Remove single-line comments (--) and multi-line comments (/* */)
            string noComments = Regex.Replace(sql, @"(--[^\r\n]*|/\*.*?\*/)", string.Empty, RegexOptions.Singleline);
            return noComments;
        }

        public CustomSqlQuery AddParameters(CustomSqlQuery sqlQuery, DcReport report)
        {
            foreach (DcReportVariable rf in report.DcReportVariables)
            {
                if (rf.VariableTypeId == 1)
                {
                    object value = Convert.ChangeType(rf.VariableValue, Type.GetType(rf.VariableValueType));
                    QueryParameter queryParameter = new(rf.VariableProperty, Type.GetType(rf.VariableValueType), value);
                    sqlQuery.Parameters.Add(queryParameter);
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

        public string ReplaceFilters(string sqlQuery, DcReport report)
        {
            CriteriaOperator[] criteriaOperators = new CriteriaOperator[report.DcReportVariables.Count];
            int index = 0;
            foreach (DcReportVariable rf in report.DcReportVariables)
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

        public string AddRelation(string mainQuery, TrReportSubQuery reportSubQuery)
        {
            string subQueryTxt = $"select * from ({reportSubQuery.SubQueryText} \n ) as [{reportSubQuery.SubQueryName}] where 1=1";

            foreach (TrReportSubQueryRelationColumn relationColumn in reportSubQuery.TrReportSubQueryRelationColumns)
            {
                string mainQueryTxt = $@"select {relationColumn.ParentColumnName} from ({mainQuery}) as main";
                subQueryTxt += $" and [{reportSubQuery.SubQueryName}].{relationColumn.SubColumnName} in ({mainQueryTxt})";
            }

            return subQueryTxt;
        }


        private Type ConvertSqlDbTypeToType(SqlDbType sqlDbType)
        {
            switch (sqlDbType)
            {
                case SqlDbType.Int:
                    return typeof(int);
                case SqlDbType.VarChar:
                case SqlDbType.NVarChar:
                case SqlDbType.Char:
                case SqlDbType.NChar:
                    return typeof(string);
                case SqlDbType.UniqueIdentifier:
                    return typeof(Guid);
                case SqlDbType.Decimal:
                case SqlDbType.Money:
                case SqlDbType.SmallMoney:
                    return typeof(decimal);
                case SqlDbType.Bit:
                    return typeof(bool);
                case SqlDbType.DateTime:
                case SqlDbType.SmallDateTime:
                case SqlDbType.Date:
                case SqlDbType.Time:
                    return typeof(DateTime);
                case SqlDbType.Float:
                    return typeof(double);
                case SqlDbType.Binary:
                case SqlDbType.VarBinary:
                    return typeof(byte[]);
                default:
                    throw new ArgumentOutOfRangeException(nameof(sqlDbType), $"No mapping exists for SqlDbType {sqlDbType}");
            }
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

        public string ClearVariablesFromQuery(string querySql)
        {
            if (querySql is not null)

                if (querySql.Contains("{"))
                {
                    int startindex = querySql.IndexOf('{');
                    int endindex = querySql.IndexOf('}');
                    string outputstring = querySql.Substring(startindex, endindex - startindex + 1);
                    string newQuerySql = querySql.Replace(outputstring, "");
                    return newQuerySql;
                }
                else
                    return querySql;
            else return null;
        }

        public string GetDataFromFile(string pathFile)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();

            using (Stream stream = assembly.GetManifestResourceStream(pathFile))
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    return reader.ReadToEnd();
                }
            }
        }

        public List<Image> GetImagesFrom(String folderPath, String[] filters, SearchOption searchOption)
        {
            List<Image> filesFound = new();

            foreach (var filter in filters)
            {
                if (CustomExtensions.DirectoryExist(folderPath))
                {
                    string[] fileNames = Directory.GetFiles(folderPath, String.Format("*.{0}", filter), searchOption);

                    foreach (var fileName in fileNames)
                    {
                        string fullPath = Path.Combine(folderPath, fileName);

                        if (File.Exists(fullPath))
                            using (var file = new FileStream(fullPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                            {
                                Image img = Image.FromStream(file);
                                img.Tag = fullPath;
                                filesFound.Add(img);
                            }
                    }
                }
            }

            return filesFound;
        }

        public void AddReports(BarSubItem BSI, string formCode, string columnName = null, GridView gV = null, string activeFilterStr = null)
        {
            SvgImageCollection svg = new();
            svg.Add("report", "image://svgimages/business objects/bo_report.svg");
            svg.Add("setting", "image://svgimages/dashboards/scatterchartlabeloptions.svg");

            BSI.AddItem(new BarHeaderItem { Caption = formCode });

            List<TrFormReport> trFormReports = efMethods.SelectFormReports(formCode);

            foreach (TrFormReport formReport in trFormReports)
            {
                BarButtonItem BBI = new BarButtonItem
                {
                    Caption = formReport.DcReport.ReportName,
                    Id = 57,
                    ImageOptions = { SvgImage = svg["report"] },
                    Name = formReport.DcReport.ReportId.ToString(),
                    ItemShortcut = ConvertToShortCut(formReport.Shortcut)
                };

                BBI.ItemClick += (sender, e) =>
                {
                    DcReport dcReport = formReport.DcReport;
                    if (!efMethods.CurrAccHasClaims(Authorization.CurrAccCode, dcReport.ReportId.ToString()))
                    {
                        MessageBox.Show("Yetkiniz yoxdur! ");
                        return;
                    }

                    string filter = "";
                    if (gV != null)
                    {
                        string columnValue = gV.GetFocusedRowCellValue(columnName)?.ToString();

                        if (!string.IsNullOrEmpty(columnValue))
                            filter = $"{columnName} = '{columnValue}'";
                        else
                        {
                            int rowCount = gV.DataRowCount;
                            if (rowCount > 0)
                            {
                                string[] columnValueArr = new string[rowCount];

                                for (int i = 0; i < rowCount; i++)
                                {
                                    object value = gV.GetRowCellValue(i, columnName);
                                    if (value != null)
                                        columnValueArr[i] = value.ToString();
                                }

                                string combinedValues = string.Join(",", columnValueArr.Select(value => $"'{value}'"));
                                filter = $"{columnName} IN ({combinedValues})";
                            }
                        }

                        foreach (var item in dcReport.DcReportVariables.Where(x => x.ReportId == Convert.ToInt32(BBI.Name)))
                        {
                            if (item.VariableProperty == columnName && !string.IsNullOrEmpty(columnValue))
                            {
                                item.VariableValue = columnValue;
                                //efMethods.UpdateDcReportVariable_Value(item.ReportId, item.VariableProperty, item.VariableValue);
                            }
                        }
                    }

                    ShowReportForm(dcReport, filter, activeFilterStr);
                };
                BSI.ItemLinks.Add(BBI);
            }

            BarButtonItem BBI_manage = new BarButtonItem
            {
                Caption = "İdarə Et",
                ImageOptions = { SvgImage = svg["setting"] },
                Name = "Manage"
            };

            BBI_manage.ItemClick += (sender, e) =>
            {
                using FormCommonList<TrFormReport> form = new("", "ReportId", "", "FormCode", formCode);
                try
                {
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        efMethods.InsertEntity<TrFormReport>(new() { FormCode = formCode, ReportId = Convert.ToInt32(form.Value_Id) });
                        AddReports(BSI, formCode, columnName, gV, activeFilterStr);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            };

            BSI.ItemLinks.Add(BBI_manage, true);
        }

        private void ShowReportForm(DcReport dcReport, string filter, string activeFilterStr)
        {
            if (dcReport.ReportTypeId == 1)
            {
                FormReportGrid formGrid = new(dcReport.ReportQuery, filter, dcReport, activeFilterStr);
                formGrid.Show();
            }
            else if (dcReport.ReportTypeId == 2)
            {
                FormReportPreview form = new(dcReport.ReportQuery, filter, dcReport)
                {
                    WindowState = FormWindowState.Maximized
                };
                form.Show();
            }
        }

        private static BarShortcut ConvertToShortCut(string shortCut)
        {
            if (!string.IsNullOrEmpty(shortCut))
            {
                KeysConverter converter = new();
                Keys key = Keys.None;

                // Split the shortcut by '+'
                string[] keys = shortCut.Split('+');

                foreach (string keyPart in keys)
                {
                    string trimmedKeyPart = keyPart.Trim().ToUpper();

                    switch (trimmedKeyPart)
                    {
                        case "CTRL":
                        case "CONTROL":
                            key |= Keys.Control;
                            break;
                        case "SHIFT":
                            key |= Keys.Shift;
                            break;
                        case "ALT":
                            key |= Keys.Alt;
                            break;
                        default:
                            // Convert the main key (like G) using the converter
                            key |= (Keys)converter.ConvertFromString(trimmedKeyPart);
                            break;
                    }
                }

                return new BarShortcut(key);
            }

            return null;
        }



    }
}
