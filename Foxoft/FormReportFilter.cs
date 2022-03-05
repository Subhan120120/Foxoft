using DevExpress.Data.Filtering;
using DevExpress.Utils.VisualEffects;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using Foxoft.Models;
using System;
using System.Data;
using System.Windows.Forms;

namespace Foxoft
{
    public partial class FormReportFilter : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        Badge badge1;
        Badge badge2;
        AdornerUIManager adornerUIManager1;
        EfMethods efMethods = new EfMethods();
        AdoMethods adoMethods = new AdoMethods();

        public FormReportFilter()
        {
            InitializeComponent();

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
            get
            {
                return new AdornerElement[] { badge1, badge2 };
            }
        }

        private void FormReport_Load(object sender, EventArgs e)
        {
            WindowsFormsSettings.FilterCriteriaDisplayStyle = FilterCriteriaDisplayStyle.Text;

            lookUpEdit1.Properties.DataSource = adoMethods.SqlGetDt("Select Id, ReportName, ReportQuery from DcReports");
            lookUpEdit1.Properties.DisplayMember = "ReportName";
            lookUpEdit1.Properties.ValueMember = "Id";
        }

        private void lookUpEdit1_EditValueChanged(object sender, EventArgs e)
        {
            LookUpEdit lookUpEdit = sender as LookUpEdit;
            string qry = lookUpEdit.GetColumnValue("ReportQuery").ToString();
            filterControl1.SourceControl = adoMethods.SqlGetDt(qry);

            DcReport dcReport = efMethods.SelectReport(Guid.Parse(lookUpEdit.EditValue.ToString()));
            filterControl1.FilterString = dcReport.ReportFilter; // load filter from database
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (lookUpEdit1.EditValue != null)
            {
                Guid reportId = Guid.Parse(lookUpEdit1.EditValue.ToString());
                FormReportGrid myform = new FormReportGrid(reportId);

                string qry = lookUpEdit1.GetColumnValue("ReportQuery").ToString();
                string filterString = CriteriaToWhereClauseHelper.GetMsSqlWhere(filterControl1.FilterCriteria);
                if (!string.IsNullOrEmpty(filterString))
                    filterString = " where " + filterString;
                DataTable dt = adoMethods.SqlGetDt(qry + filterString);
                myform.gridControl1.DataSource = dt;
                myform.MdiParent = this.MdiParent;
                myform.Show();

                if (object.ReferenceEquals(filterControl1.FilterCriteria, null))
                    efMethods.UpdateReportFilter(reportId, filterControl1.FilterCriteria.ToString()); //save filter to database
            }
            else
                XtraMessageBox.Show("Hesabat Secin");

        }

        private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (lookUpEdit1.EditValue != null)
            {
                string qry = lookUpEdit1.GetColumnValue("ReportQuery").ToString();
                string id = lookUpEdit1.EditValue.ToString();
                string name = lookUpEdit1.Text;
                DcReport dcReport = new DcReport
                {
                    Id = Guid.Parse(id),
                    ReportName = name,
                    ReportQuery = qry
                };

                FormReportEditor formQueryEditor = new FormReportEditor(dcReport);
                if (formQueryEditor.ShowDialog(this) == DialogResult.OK)
                {
                    lookUpEdit1.Properties.DataSource = adoMethods.SqlGetDt("Select * from DcReports");
                }
            }
        }

        private void barButtonItem3_ItemClick(object sender, ItemClickEventArgs e)
        {

        }
    }
}
