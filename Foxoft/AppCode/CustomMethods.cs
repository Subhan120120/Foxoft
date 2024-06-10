using System.Collections.Generic;
using System;
using System.IO;
using System.Reflection;
using System.Drawing;
using DevExpress.Data.Filtering;
using DevExpress.DataAccess.Sql;
using Foxoft.Models;
using System.Data.SqlClient;
using System.Data;
using System.Threading;
using System.Globalization;

namespace Foxoft.AppCode
{
    public class CustomMethods
    {
        public string AddTop(string query, int count)
        {
            query = query.Trim();

            int selectIndx = query.IndexOf("Select", StringComparison.OrdinalIgnoreCase);

            string top = query.Substring(selectIndx + 7, 3);

            bool topExist = top.Contains("Top", StringComparison.OrdinalIgnoreCase);

            if (topExist)
                query = query.Substring(0, selectIndx) + "Select Top " + count.ToString() + query.Substring(selectIndx + 6);
            else
                query = query.Substring(0, selectIndx) + "Select Top " + count.ToString() + " ROW_NUMBER() OVER (Order by (select null)) as RowNumber, " + query.Substring(selectIndx + 6);

            return query;
        }

        public CustomSqlQuery AddParameters(CustomSqlQuery sqlQuery, DcReport report)
        {
            foreach (DcReportVariable rf in report.DcReportVariables)
            {
                if (rf.VariableTypeId == 1)
                {
                    //string typeName = typeof(DateTime).FullName;
                    object value = Convert.ChangeType(rf.VariableValue, Type.GetType(rf.VariableValueType));
                    QueryParameter queryParameter = new(rf.VariableProperty, Type.GetType(rf.VariableValueType), value);
                    sqlQuery.Parameters.Add(queryParameter);

                    //QueryParameter queryParameter2 = new();
                    //queryParameter2.Name = "EndDate";
                    //queryParameter.Type = typeof(DateTime);
                    //queryParameter2.ValueInfo = EndDate.ToString("yyyy-MM-dd");
                }
            }
            return sqlQuery;
        }

        public string AddParameters(string sqlQuery, DcReport report)
        {
            foreach (DcReportVariable rf in report.DcReportVariables)
            {
                if (rf.VariableTypeId == 1)
                {
                    sqlQuery = sqlQuery.Replace(rf.Representative, rf.VariableValue); //parametr sorgunun icinde temsilci ile deyisdirilir
                }
            }
            return sqlQuery;
        }

        public SqlParameter[] AddParameters(DcReport report)
        {
            List<SqlParameter> sqlParameterList = new(); ;
            foreach (DcReportVariable rf in report.DcReportVariables)
            {
                if (rf.VariableTypeId == 1)
                    sqlParameterList.Add(new SqlParameter()
                    {
                        ParameterName = rf.Representative,
                        Value = rf.VariableValue,
                        DbType = GetDbType(rf.VariableValueType)
                    });
            }

            return sqlParameterList.ToArray();
        }

        public string AddFilters(string sqlQuery, DcReport report)
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
    }
}
