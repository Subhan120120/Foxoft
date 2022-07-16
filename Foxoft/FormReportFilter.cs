using DevExpress.Data.Filtering;
using DevExpress.Utils.VisualEffects;
using DevExpress.Xpo.DB;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Filtering;
using DevExpress.XtraEditors.Repository;
using Foxoft.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Windows.Forms;

namespace Foxoft
{
    public partial class FormReportFilter : RibbonForm
    {
        EfMethods efMethods = new EfMethods();
        AdoMethods adoMethods = new AdoMethods();
        DcReport dcReport = new DcReport();

        readonly RepositoryItemButtonEdit repoBtnEdit_ProductCode = new RepositoryItemButtonEdit();
        readonly RepositoryItemButtonEdit repoBtnEdit_CurrAccCode = new RepositoryItemButtonEdit();

        public FormReportFilter(DcReport Report)
        {
            InitializeComponent();
            WindowsFormsSettings.FilterCriteriaDisplayStyle = FilterCriteriaDisplayStyle.Text;

            this.dcReport = efMethods.SelectReport(Report.ReportId); // reload dcReport


            string querySql = ClearVariables(dcReport.ReportQuery);

            filterControl_Outer.SourceControl = adoMethods.SqlGetDt(querySql);
            filterControl_Outer.FilterString = dcReport.ReportFilter;

            GroupOperator groupOperator = GetFiltersFromDatabase(dcReport.DcReportFilters);
            filterControl_Inner.SourceControl = opToDt(groupOperator);
            filterControl_Inner.FilterCriteria = groupOperator;

            this.repoBtnEdit_ProductCode.AutoHeight = false;
            this.repoBtnEdit_ProductCode.Name = "repoBtnEdit_ProductCode";
            this.repoBtnEdit_ProductCode.ButtonPressed += new ButtonPressedEventHandler(this.repoBtnEdt_ButtonPressed);

            this.repoBtnEdit_CurrAccCode.AutoHeight = false;
            this.repoBtnEdit_CurrAccCode.Name = "repoBtnEdit_CurrAccCode";
            this.repoBtnEdit_CurrAccCode.ButtonPressed += new ButtonPressedEventHandler(this.repobtnEdit_CurrAccCode_ButtonPressed);
        }

        private string ClearVariables(string querySql)
        {
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
        }

        private DataTable opToDt(GroupOperator groupOperand)
        {
            DataTable dt = new DataTable();
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
            int reportId = dcReport.ReportId;
            string reportQuery = dcReport.ReportQuery;

            ICollection<DcReportFilter> dcReportFilters = dcReport.DcReportFilters;

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

            //CriteriaOperator groupOperator = new GroupOperator(GroupOperatorType.And, criteriaOperators);


            string qryMaster = "Select * from ( " + reportQuery + ") as master";

            string queryFilter = CriteriaToWhereClauseHelper.GetMsSqlWhere(filterControl_Outer.FilterCriteria);
            if (!string.IsNullOrEmpty(queryFilter))
                queryFilter = " where " + queryFilter;

            try
            {
                FormReportGrid myform = new FormReportGrid(qryMaster + queryFilter, reportId);

                myform.MdiParent = this.MdiParent;
                myform.Text = dcReport.ReportName;
                myform.Show();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString());
            }

            string filterCriteria = "";
            if (!object.ReferenceEquals(filterControl_Outer.FilterCriteria, null))
                filterCriteria = filterControl_Outer.FilterCriteria.ToString();

            efMethods.UpdateDcReportFilter(reportId, filterCriteria); //save filter to database
        }

        private BinaryOperatorType ConvertOperatorType(string filterOperatorType)
        {
            switch (filterOperatorType)
            {
                case "+":
                    return BinaryOperatorType.Plus;
                case "&":
                    return BinaryOperatorType.BitwiseAnd;
                case "/":
                    return BinaryOperatorType.Divide;
                case "==":
                    return BinaryOperatorType.Equal;
                case ">":
                    return BinaryOperatorType.Greater;
                case ">=":
                    return BinaryOperatorType.GreaterOrEqual;
                case "<":
                    return BinaryOperatorType.Less;
                case "<=":
                    return BinaryOperatorType.LessOrEqual;
                case "%":
                    return BinaryOperatorType.Modulo;
                case "*":
                    return BinaryOperatorType.Multiply;
                case "!=":
                    return BinaryOperatorType.NotEqual;
                case "|":
                    return BinaryOperatorType.BitwiseOr;
                case "-":
                    return BinaryOperatorType.Minus;
                case "^":
                    return BinaryOperatorType.BitwiseXor;
                default:
                    return BinaryOperatorType.Equal;
            }
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
            {
                dcReport.ReportQuery = formQueryEditor.dcReport.ReportQuery;
            }

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
            if (!object.ReferenceEquals(e.Value, null) && !object.ReferenceEquals(e.PropertyName, null))
            {
                foreach (var item in dcReport.DcReportFilters)
                {
                    string prop = e.PropertyName;

                    efMethods.UpdateReportFilter(e.PropertyName, e.Value.ToString());
                }
                this.dcReport = efMethods.SelectReport(dcReport.ReportId); // reload dcReport
            }
        }

        private void filterControl_Outer_CustomValueEditor(object sender, CustomValueEditorArgs e)
        {
            if (e.Node.FirstOperand.PropertyName == "Məhsul Kodu" || e.Node.FirstOperand.PropertyName == "ProductCode")
                e.RepositoryItem = repoBtnEdit_ProductCode;
            if (e.Node.FirstOperand.PropertyName == "Cari Hesab Kodu" || e.Node.FirstOperand.PropertyName == "CurrAccCode")
                e.RepositoryItem = repoBtnEdit_CurrAccCode;
        }

        private void repoBtnEdt_ButtonPressed(object sender, ButtonPressedEventArgs e)
        {
            SelectProduct(sender);
        }

        private void SelectProduct(object sender)
        {
            ButtonEdit editor = (ButtonEdit)sender;
            using (FormProductList form = new FormProductList(0))
            {
                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    editor.EditValue = form.dcProduct.ProductCode;
                }
            }
        }

        private void repobtnEdit_CurrAccCode_ButtonPressed(object sender, ButtonPressedEventArgs e)
        {
            SelectCurrAcc(sender);
        }

        private void SelectCurrAcc(object sender)
        {
            ButtonEdit editor = (ButtonEdit)sender;
            using (FormCurrAccList form = new FormCurrAccList(0))
            {
                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    editor.EditValue = form.dcCurrAcc.CurrAccCode;
                }
            }
        }
    }
}
