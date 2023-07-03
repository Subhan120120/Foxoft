using DevExpress.Data.Filtering;
using DevExpress.Data.Filtering.Helpers;
using DevExpress.DataAccess.ConnectionParameters;
using DevExpress.DataAccess.Excel;
using DevExpress.DataAccess.Sql;
using DevExpress.DataAccess.UI.Sql;
using DevExpress.Utils.Svg;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Filtering;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraReports.UI;
using DevExpress.XtraReports.UserDesigner;
using Foxoft.AppCode;
using Foxoft.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Foxoft
{
    public partial class FormReportFilter : RibbonForm
    {
        readonly SettingStore settingStore;
        EfMethods efMethods = new EfMethods();
        AdoMethods adoMethods = new AdoMethods();
        DcReport dcReport = new();

        public FormReportFilter(DcReport Report)
        {
            InitializeComponent();

            settingStore = efMethods.SelectSettingStore(Authorization.StoreCode);

            ComponentResourceManager resources = new(typeof(FormReportFilter));

            SvgImage ımage = ((SvgImage)(resources.GetObject("barButtonItem1.ImageOptions.SvgImage")));

            SvgBitmap bm = new SvgBitmap(ımage);
            Image img = bm.Render(null, 0.5);
            filterControl_Outer.MyIcon = img;
            filterControl_Outer.ExcelButtonClick += new ExcelButtonFilterControl.ExcelButtonEventHandler(this.ExcelButtonFilterControl_ExcelButtonClick);

            WindowsFormsSettings.FilterCriteriaDisplayStyle = FilterCriteriaDisplayStyle.Text;
            AcceptButton = btn_ShowReport;

            this.dcReport = efMethods.SelectReport(Report.ReportId); // reload dcReport
            this.Text = Report.ReportName;

            string querySql = null;
            if (dcReport is not null)
                querySql = ClearVariables(dcReport.ReportQuery);

            if (querySql is not null)
                filterControl_Outer.SourceControl = adoMethods.SqlGetDt(querySql);
            filterControl_Outer.FilterString = dcReport.ReportFilter;

            GroupOperator groupOperator = GetFiltersFromDatabase(dcReport.DcReportFilters);
            filterControl_Inner.SourceControl = opToDt(groupOperator);
            filterControl_Inner.FilterCriteria = groupOperator;
        }

        private string ClearVariables(string querySql)
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

        private DataTable opToDt(GroupOperator groupOperand)
        {
            DataTable dt = new();
            dt.Clear();
            Dictionary<string, object> keyValuePairs = Extract(groupOperand);
            foreach (var item in keyValuePairs)
                dt.Columns.Add(item.Key);

            return dt;
        }

        private GroupOperator GetFiltersFromDatabase(ICollection<DcReportFilter> dcReportFilters)
        {
            GroupOperator groupOperand = new GroupOperator();

            foreach (DcReportFilter rf in dcReportFilters)
            {
                BinaryOperatorType operatorType = ConvertOperatorType(rf.FilterOperatorType);
                CriteriaOperator op = new BinaryOperator(rf.FilterProperty, rf.FilterValue, operatorType);
                groupOperand.Operands.Add(op);
            }

            return groupOperand;
        }

        //private CriteriaOperator DoSomthing(CriteriaOperator criteriaOperator)
        //{
        //    if (criteriaOperator is GroupOperator)
        //    {
        //        var groupOperator = (GroupOperator)criteriaOperator;
        //        CriteriaOperatorCollection operands = groupOperator.Operands;

        //        var indexesToremove = new List<int>();
        //        for (int i = 0; i < operands.Count; i++)
        //        {
        //            CriteriaOperator operand = operands[i];
        //            if (operand.ToString() == matchString)
        //            {
        //                if (ReferenceEquals(replaceOperator, null))
        //                    indexesToremove.Add(i);
        //                else
        //                    operands[i] = replaceOperator;
        //            }
        //            else
        //            {
        //                CriteriaOperator extract = operand;
        //                operands.RemoveAt(i);
        //                operands.Insert(i, extract);
        //            }
        //        }
        //        foreach (int i in indexesToremove)
        //            operands.RemoveAt(i);
        //    }
        //    return criteriaOperator;
        //}

        private void FormReport_Load(object sender, EventArgs e)
        {
        }

        private void btn_ShowReport_Click(object sender, EventArgs e)
        {
            string reportQuery = dcReport.ReportQuery;
            ICollection<DcReportFilter> dcReportFilters = dcReport.DcReportFilters;
            reportQuery = AddFilterToQuery(reportQuery, dcReportFilters);
            //CriteriaOperator groupOperator = new GroupOperator(GroupOperatorType.And, criteriaOperators);
            string qryMaster = "Select * from ( " + reportQuery + ") as master";

            string queryFilter = CriteriaToWhereClauseHelper.GetMsSqlWhere(filterControl_Outer.FilterCriteria);
            if (!string.IsNullOrEmpty(queryFilter))
                queryFilter = " where " + queryFilter;

            string qry = qryMaster + queryFilter;

            switch (dcReport.ReportTypeId)
            {
                case 1: OpenGridReport(qry); break;
                case 2: OpenDetailReport(qry); break;
                default: OpenGridReport(qry); break;
            }




            SaveFilterToDB();
        }

        private void SaveFilterToDB()
        {
            string filterCriteria = "";
            if (filterControl_Outer.FilterCriteria is not null)
                filterCriteria = filterControl_Outer.FilterCriteria.ToString();

            efMethods.UpdateDcReport_Filter(dcReport.ReportId, filterCriteria); //save filter to database
        }

        private void OpenGridReport(string qry)
        {
            try
            {
                FormReportGrid myform = new(qry, dcReport);

                myform.MdiParent = this.MdiParent;
                myform.Show();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString());
            }
        }

        private void OpenDetailReport(string qry)
        {
            try
            {
                XtraReport xtraReport = GetInvoiceReport(dcReport, qry);
                //ReportPrintTool printTool = new(xtraReport);
                //printTool.ShowRibbonPreview();

                XRDesignRibbonForm FormDesignRibbon = new();

                RibbonPageGroup pageGroup = FormDesignRibbon.RibbonControl.Pages[0].GetGroupByName("Report");
                BarButtonItem item = CreateItem();
                pageGroup.ItemLinks.Add(item);

                FormDesignRibbon.OpenReport(xtraReport);
                FormDesignRibbon.Show();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString());
            }
        }

        private string subConnString = ConfigurationManager
                 .OpenExeConfiguration(ConfigurationUserLevel.None)
                 .ConnectionStrings
                 .ConnectionStrings["subConnString"]
                 .ConnectionString;

        private XtraReport GetInvoiceReport(DcReport dcReport, string qry)
        {
            List<DcReportQuery> dcReportQueries = efMethods.SelectReportQueriesByReport(dcReport.ReportId);
            List<CustomSqlQuery> sqlQueries = new();

            foreach (DcReportQuery reportQuery in dcReportQueries)
            {
                CustomSqlQuery sqlQuery = SelectQry(reportQuery);
                sqlQueries.Add(sqlQuery);
            }

            ReportClass reportClass = new();
            return reportClass.GetReport(dcReport.ReportName, dcReport.ReportName + ".repx", sqlQueries);
        }

        public CustomSqlQuery SelectQry(DcReportQuery dcReportQuery)
        {
            List<DcQueryParam> dcQueryParams = efMethods.SelectQueryParamsByQuery(dcReportQuery.QueryId);

            CustomSqlQuery sqlQuery = new(dcReportQuery.QueryName, dcReportQuery.QueryText);

            foreach (DcQueryParam queryParam in dcQueryParams)
            {
                //string typeName = typeof(DateTime).FullName;

                object value = Convert.ChangeType(queryParam.ParameterValue, Type.GetType(queryParam.ParameterType));
                QueryParameter queryParameter = new(queryParam.ParameterName, Type.GetType(queryParam.ParameterType), value);
                sqlQuery.Parameters.Add(queryParameter);

                //QueryParameter queryParameter2 = new();
                //queryParameter2.Name = "EndDate";
                //queryParameter2.Type = typeof(DateTime);
                //queryParameter2.ValueInfo = EndDate.ToString("yyyy-MM-dd");
            }

            return sqlQuery;
        }

        private BarButtonItem CreateItem()
        {
            BarButtonItem item = new();
            item.ItemClick += item_ItemClick;
            item.Caption = "Get Help";
            return item;
        }

        void item_ItemClick(object sender, ItemClickEventArgs e)
        {
            MessageBox.Show("Item clicked");
        }

        private string AddFilterToQuery(string reportQuery, ICollection<DcReportFilter> dcReportFilters)
        {
            CriteriaOperator[] criteriaOperators = new CriteriaOperator[dcReportFilters.Count];
            int index = 0;
            foreach (DcReportFilter rf in dcReportFilters)
            {
                BinaryOperatorType operatorType = ConvertOperatorType(rf.FilterOperatorType);

                criteriaOperators[index] = new BinaryOperator(rf.FilterProperty, rf.FilterValue, operatorType);

                string filterSql = CriteriaToWhereClauseHelper.GetMsSqlWhere(criteriaOperators[index]);
                reportQuery = reportQuery.Replace(rf.Representative, " and " + filterSql); //filter sorgunun icinde temsilci ile deyisdirilir

                index++;
            }

            return reportQuery;
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

        Dictionary<string, object> Extract(CriteriaOperator op)
        {
            Dictionary<string, object> dict = new Dictionary<string, object>();
            GroupOperator opGroup = op as GroupOperator;
            if (ReferenceEquals(opGroup, null))
            {
                ExtractOne(dict, op);
            }
            else
            {
                if (opGroup.OperatorType == GroupOperatorType.And)
                {
                    foreach (var opn in opGroup.Operands)
                    {
                        ExtractOne(dict, opn);
                    }
                }
            }
            return dict;
        }
        private void ExtractOne(Dictionary<string, object> dict, CriteriaOperator op)
        {
            BinaryOperator opBinary = op as BinaryOperator;
            if (ReferenceEquals(opBinary, null)) return;
            OperandProperty opProperty = opBinary.LeftOperand as OperandProperty;
            OperandValue opValue = opBinary.RightOperand as OperandValue;
            if (ReferenceEquals(opProperty, null) || ReferenceEquals(opValue, null)) return;
            dict.Add(opProperty.PropertyName, opValue.Value);
        }

        private void bBI_ReportEdit_ItemClick(object sender, ItemClickEventArgs e)
        {
            string qry = dcReport.ReportQuery;
            int id = dcReport.ReportId;

            FormReportEditor formQueryEditor = new FormReportEditor(id);
            if (formQueryEditor.ShowDialog(this) == DialogResult.OK)
                dcReport.ReportQuery = formQueryEditor.dcReport.ReportQuery;
        }

        private void bBI_ReportNew_ItemClick(object sender, ItemClickEventArgs e)
        {
            FormReportEditor formQueryEditor = new FormReportEditor(0);
            if (formQueryEditor.ShowDialog(this) == DialogResult.OK)
            {
            }
        }

        private void bBI_ReportDelete_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (MessageBox.Show("Silmək İstəyirsiniz?", "Diqqət", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                efMethods.DeleteReport(dcReport.ReportId);
            }
        }

        private void filterControl_Inner_CustomValueEditor(object sender, CustomValueEditorArgs e)
        {
            e.InitFilterRepositoryItems(this);

            if (e.Value is not null && e.PropertyName is not null)
            {
                foreach (var item in dcReport.DcReportFilters)
                {
                    efMethods.UpdateReportFilter(dcReport.ReportId, e.PropertyName, e.Value.ToString());
                }
                this.dcReport = efMethods.SelectReport(dcReport.ReportId); // reload dcReport
            }
        }

        private void filterControl_Outer_CustomValueEditor(object sender, CustomValueEditorArgs e)
        {
            e.InitFilterRepositoryItems(this);
        }

        private void ExcelButtonFilterControl_ExcelButtonClick(object sender, ExcelButtonEventArgs e)
        {
            OpenFileDialog dialog = new();
            dialog.Filter = "Excel Files (*.xls;*.xlsx)|*.xls;*.xlsx|" +
                            "All files (*.*)|*.*";
            dialog.Title = "Yalnız ilk sütünda olan məlumatlar daxil edilir.";

            DialogResult dr = dialog.ShowDialog();
            if (dr == DialogResult.OK)
            {
                ExcelDataSource excelDataSource = new();
                excelDataSource.FileName = dialog.FileName;

                ExcelWorksheetSettings excelWorksheetSettings = new(0, "A1:A10000");
                //excelWorksheetSettings.WorksheetName = "10QK";

                ExcelSourceOptions excelOptions = new();
                excelOptions.ImportSettings = excelWorksheetSettings;
                excelOptions.SkipHiddenRows = false;
                excelOptions.SkipHiddenColumns = false;
                excelOptions.UseFirstRowAsHeader = true;
                excelDataSource.SourceOptions = excelOptions;

                excelDataSource.Fill();

                DataTable dt = new();
                dt = ToDataTableFromExcelDataSource(excelDataSource);

                ClauseNode clauseNode = (ClauseNode)e.LabelInfo.Owner;

                if (clauseNode.Operation == ClauseType.AnyOf || clauseNode.Operation == ClauseType.NoneOf)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        clauseNode.AdditionalOperands.Add(row[0].ToString());
                    }
                }
            }
        }

        public DataTable ToDataTableFromExcelDataSource(ExcelDataSource excelDataSource)
        {
            IList list = ((IListSource)excelDataSource).GetList();
            DevExpress.DataAccess.Native.Excel.DataView dataView = (DevExpress.DataAccess.Native.Excel.DataView)list;
            List<PropertyDescriptor> props = dataView.Columns.ToList<PropertyDescriptor>();

            DataTable table = new();
            for (int i = 0; i < props.Count; i++)
            {
                PropertyDescriptor prop = props[i];
                table.Columns.Add(prop.Name, prop.PropertyType);
            }
            object[] values = new object[props.Count];
            foreach (DevExpress.DataAccess.Native.Excel.ViewRow item in list)
            {
                for (int i = 0; i < values.Length; i++)
                {
                    values[i] = props[i].GetValue(item);
                }
                table.Rows.Add(values);
            }
            return table;
        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {

        }
    }

    public class TypedProperty<T> : Property where T : IConvertible
    {
        public T TypedValue
        {
            get { return (T)Convert.ChangeType(base.Value, typeof(T)); }
            set { base.Value = value.ToString(); }
        }
    }

    public class Property
    {
        public string Value { get; set; }
    }
}
