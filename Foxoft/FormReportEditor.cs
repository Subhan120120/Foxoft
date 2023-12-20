using DevExpress.XtraEditors;
using Foxoft.AppCode;
using Foxoft.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Foxoft
{
    public partial class FormReportEditor : XtraForm
    {
        public DcReport dcReport = new DcReport();
        subContext dbContext = new subContext();

        public FormReportEditor(int reportId)
        {
            this.dcReport.ReportId = reportId;

            InitializeComponent();

            CancelButton = btn_Cancel;
            AcceptButton = btn_Ok;
        }

        private void FormQueryEditor_Load(object sender, EventArgs e)
        {
            FillDataLayout();
        }

        private void FillDataLayout()
        {
            if (!(dcReport.ReportId > 0))
                ClearControlsAddNew();
            else
            {
                dbContext.DcReports.Include(x => x.DcReportFilters)
                                    .Where(x => x.ReportId == dcReport.ReportId)
                                   .Load();
                dcReportsBindingSource.DataSource = dbContext.DcReports.Local.ToBindingList();
            }
        }

        private void ClearControlsAddNew()
        {
            dcReport = dcReportsBindingSource.AddNew() as DcReport;

            dcReportsBindingSource.DataSource = dcReport;
        }

        private void btn_Ok_Click(object sender, EventArgs e)
        {
            EfMethods efMethods = new();
            AdoMethods adoMethods = new();

            dcReport = dcReportsBindingSource.Current as DcReport;

            if (!String.IsNullOrEmpty(dcReport?.ReportQuery))
            {
                string query = CustomExtensions.AddTop(dcReport.ReportQuery, 1);

                string qryMaster = "select * from (" + query + " \n) as Master " + " order by RowNumber";

                try
                {
                    CustomMethods cM = new();
                    string qry = cM.ClearVariablesFromQuery(qryMaster);
                    DataTable dt = adoMethods.SqlGetDt(qry);

                    if (!efMethods.ReportExist(dcReport.ReportId)) //if doesnt exist
                        efMethods.InsertReport(dcReport);
                    else
                        dbContext.SaveChanges();

                    DialogResult = DialogResult.OK;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Foxoft Error Code: 1215451 \n\n " + ex);
                }
            }
        }
    }
}
