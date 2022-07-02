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
using System.Data;
using System.Windows.Forms;

namespace Foxoft
{
    public partial class FormReportFilter : RibbonForm
    {
        Badge badge1;
        Badge badge2;
        AdornerUIManager adornerUIManager1;
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

            filterControl1.SourceControl = adoMethods.SqlGetDt(dcReport.ReportQuery);
            filterControl1.FilterString = dcReport.ReportFilter;

            this.repoBtnEdit_ProductCode.AutoHeight = false;
            this.repoBtnEdit_ProductCode.Name = "repoBtnEdit_ProductCode";
            this.repoBtnEdit_ProductCode.ButtonPressed += new ButtonPressedEventHandler(this.repoBtnEdt_ButtonPressed);

            this.repoBtnEdit_CurrAccCode.AutoHeight = false;
            this.repoBtnEdit_CurrAccCode.Name = "repoBtnEdit_CurrAccCode";
            this.repoBtnEdit_CurrAccCode.ButtonPressed += new ButtonPressedEventHandler(this.repobtnEdit_CurrAccCode_ButtonPressed);

            adornerUIManager1 = new AdornerUIManager(components);
            badge1 = new Badge();
            badge2 = new Badge();
            adornerUIManager1.Elements.Add(badge1);
            adornerUIManager1.Elements.Add(badge2);
            badge1.TargetElement = barButtonItem1;
            badge2.TargetElement = ribbonPage1;
        }

        public AdornerElement[] Badges
        {
            get { return new AdornerElement[] { badge1, badge2 }; }
        }

        private void FormReport_Load(object sender, EventArgs e)
        {
        }

        private void btn_ShowReport_Click(object sender, EventArgs e)
        {
            int reportId = dcReport.ReportId;

            string qryMaster = "Select * from ( " + dcReport.ReportQuery + ") as master";

            string queryFilter = CriteriaToWhereClauseHelper.GetMsSqlWhere(filterControl1.FilterCriteria);
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
            if (!object.ReferenceEquals(filterControl1.FilterCriteria, null))
                filterCriteria = filterControl1.FilterCriteria.ToString();

            efMethods.UpdateReportFilter(reportId, filterCriteria); //save filter to database
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
