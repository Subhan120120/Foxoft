using DevExpress.Data.Filtering;
using DevExpress.Utils.VisualEffects;
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

        public FormReportFilter(DcReport dcReport)
        {
            InitializeComponent();
            WindowsFormsSettings.FilterCriteriaDisplayStyle = FilterCriteriaDisplayStyle.Text;

            dcReport = efMethods.SelectReport(dcReport.ReportId); // reload dcReport

            this.dcReport = dcReport;

            filterControl_Outer.SourceControl = adoMethods.SqlGetDt(dcReport.ReportQuery);
            filterControl_Outer.FilterString = dcReport.ReportFilter;

            this.repoBtnEdit_ProductCode.AutoHeight = false;
            this.repoBtnEdit_ProductCode.Name = "repoBtnEdit_ProductCode";
            this.repoBtnEdit_ProductCode.ButtonPressed += new ButtonPressedEventHandler(this.repoBtnEdt_ButtonPressed);

            this.repoBtnEdit_CurrAccCode.AutoHeight = false;
            this.repoBtnEdit_CurrAccCode.Name = "repoBtnEdit_CurrAccCode";
            this.repoBtnEdit_CurrAccCode.ButtonPressed += new ButtonPressedEventHandler(this.repobtnEdit_CurrAccCode_ButtonPressed);
        }


        private void FormReport_Load(object sender, EventArgs e)
        {
        }

        private void btn_ShowReport_Click(object sender, EventArgs e)
        {
            int reportId = dcReport.ReportId;

            string qryMaster = "Select * from ( " + dcReport.ReportQuery + ") as master";

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

            efMethods.UpdateReportFilter(reportId, filterCriteria); //save filter to database

            CriteriaOperator criteriaOperator = filterControl_Outer.FilterCriteria;



            var asdasd = Extract(criteriaOperator);
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

        private void filterControl1_CustomValueEditor(object sender, CustomValueEditorArgs e)
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
