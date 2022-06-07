using DevExpress.XtraEditors;
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
        DcReport dcReport = new DcReport();
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
                dbContext.DcReports.Where(x => x.ReportId == dcReport.ReportId)
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
            EfMethods efMethods = new EfMethods();

            //dcReport = efMethods.SelectReport(dcReport.ReportId);
            //efMethods.UpdateReport(dcReport);

            dcReport = dcReportsBindingSource.Current as DcReport;
            if (!efMethods.ReportExist(dcReport.ReportId)) //if invoiceHeader doesnt exist
                efMethods.InsertReport(dcReport);
            else
                dbContext.SaveChanges();

            DialogResult = DialogResult.OK;
        }
    }
}
