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

            lookUpEdit1.Properties.DataSource = adoMethods.SqlGetDt("Select ReportId, ReportName, ReportQuery from DcReports");
            lookUpEdit1.Properties.ValueMember = "ReportId";
            lookUpEdit1.Properties.DisplayMember = "ReportName";
        }

        private void lookUpEdit1_EditValueChanged(object sender, EventArgs e)
        {
            LookUpEdit lookUpEdit = sender as LookUpEdit;
            string qry = lookUpEdit.GetColumnValue("ReportQuery").ToString();

            if (!string.IsNullOrEmpty(qry))
                filterControl1.SourceControl = adoMethods.SqlGetDt(qry);

            DcReport dcReport = efMethods.SelectReport(Convert.ToInt32(lookUpEdit.EditValue));
            filterControl1.FilterString = dcReport.ReportFilter; // load filter from database
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (lookUpEdit1.EditValue != null)
            {
                int reportId = Convert.ToInt32(lookUpEdit1.EditValue.ToString());
                FormReportGrid myform = new FormReportGrid(reportId);

                string qry = lookUpEdit1.GetColumnValue("ReportQuery").ToString();

                string qryMaster = "Select * from ( " + qry + ") as master";

                string queryFilter = CriteriaToWhereClauseHelper.GetMsSqlWhere(filterControl1.FilterCriteria);
                if (!string.IsNullOrEmpty(queryFilter))
                    queryFilter = " where " + queryFilter;

                try
                {
                    DataTable dt = adoMethods.SqlGetDt(qryMaster + queryFilter);
                    myform.gridControl1.DataSource = dt;
                    myform.MdiParent = this.MdiParent;
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
            else
                XtraMessageBox.Show("Hesabat Secin");

        }

        private void bBI_QueryEditor_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (lookUpEdit1.EditValue != null)
            {
                string qry = lookUpEdit1.GetColumnValue("ReportQuery").ToString();
                int id = Convert.ToInt32(lookUpEdit1.EditValue);

                FormReportEditor formQueryEditor = new FormReportEditor(id);
                if (formQueryEditor.ShowDialog(this) == DialogResult.OK)
                {
                    lookUpEdit1.Properties.DataSource = adoMethods.SqlGetDt("Select * from DcReports");
                }
            }
        }

        private void barButtonItem3_ItemClick(object sender, ItemClickEventArgs e)
        {
            FormReportEditor formQueryEditor = new FormReportEditor(0);
            if (formQueryEditor.ShowDialog(this) == DialogResult.OK)
            {
                lookUpEdit1.Properties.DataSource = adoMethods.SqlGetDt("Select * from DcReports");
            }
        }
    }
}
