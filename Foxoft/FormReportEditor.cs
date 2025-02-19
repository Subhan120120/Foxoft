using DevExpress.XtraEditors;
using DevExpress.XtraReports;
using Foxoft.AppCode;
using Foxoft.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace Foxoft
{
    public partial class FormReportEditor : XtraForm
    {
        public DcReport dcReport = new();
        subContext dbContext = new();
        CustomMethods cM = new();
        EfMethods efMethods = new();

        public FormReportEditor(int reportId)
        {
            this.dcReport.ReportId = reportId;

            InitializeComponent();

            CancelButton = btn_Cancel;
            AcceptButton = btn_Ok;

            ReportTypeIdLookUpEdit.Properties.DataSource = efMethods.SelectEntities<DcReportType>();
            ReportTypeIdLookUpEdit.Properties.ValueMember = "ReportTypeId";
            ReportTypeIdLookUpEdit.Properties.DisplayMember = "ReportTypeDesc";

            ReportCategoryIdLookUpEdit.Properties.DataSource = efMethods.SelectEntities<DcReportCategory>();
            ReportCategoryIdLookUpEdit.Properties.ValueMember = "ReportCategoryId";
            ReportCategoryIdLookUpEdit.Properties.DisplayMember = "ReportCategoryDesc";
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
                dbContext.DcReports.Include(x => x.DcReportVariables)
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
                try
                {
                    SqlParameter[] sqlParameters;
                    string query = cM.ApplyFilter(dcReport, dcReport.ReportQuery, null, out sqlParameters); ;

                    DataTable dt = adoMethods.SqlGetDt(query, sqlParameters); // if query is correct 

                    if (!efMethods.EntityExists<DcReport>(dcReport.ReportId)) //if doesnt exist
                        efMethods.InsertEntity<DcReport>(dcReport);
                    else
                        dbContext.SaveChanges();

                    DialogResult = DialogResult.OK;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Foxoft Error Code: 1215451 ");
                }
            }
        }
    }
}
