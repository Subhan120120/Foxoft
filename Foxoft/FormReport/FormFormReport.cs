using DevExpress.XtraEditors;
using Foxoft.Models;
using Foxoft.Models.Entity.Report;
using Foxoft.Properties;
using Microsoft.EntityFrameworkCore;

namespace Foxoft
{
    public partial class FormFormReport : XtraForm
    {
        private readonly string? initialFormCode;
        private readonly int? initialReportId;
        private subContext dbContext = null!;

        public TrFormReport trFormReport = new();

        public FormFormReport()
            : this(null, null)
        {
        }

        public FormFormReport(string? formCode)
            : this(formCode, null)
        {
        }

        public FormFormReport(string formCode, int reportId)
            : this(formCode, (int?)reportId)
        {
        }

        private FormFormReport(string? formCode, int? reportId)
        {
            initialFormCode = formCode;
            initialReportId = reportId;

            InitializeComponent();

            AcceptButton = btn_Ok;
            CancelButton = btn_Cancel;
            FormClosed += (_, _) => dbContext?.Dispose();
        }

        private void FormFormReport_Load(object sender, EventArgs e)
        {
            LoadFormReport();
            dataLayoutControl1.IsValid(out List<string> errorList);
        }

        private void LoadFormReport()
        {
            dbContext = new subContext();

            LoadLookups();

            if (initialReportId is null)
                ClearControlsAddNew();
            else
            {
                dbContext.TrFormReports
                    .Where(x => x.FormCode == initialFormCode && x.ReportId == initialReportId.Value)
                    .Load();

                trFormReportsBindingSource.DataSource = dbContext.TrFormReports.Local.ToBindingList();
                trFormReport = trFormReportsBindingSource.Current as TrFormReport ?? new TrFormReport();

                SetKeyEditorsReadOnly();
            }
        }

        private void LoadLookups()
        {
            FormCodeLookUpEdit.Properties.DataSource = dbContext.DcForms
                .AsNoTracking()
                .OrderBy(x => x.FormCode)
                .Select(x => new
                {
                    x.FormCode,
                    x.FormDesc
                })
                .ToList();

            ReportIdLookUpEdit.Properties.DataSource = dbContext.DcReports
                .AsNoTracking()
                .OrderBy(x => x.ReportName)
                .Select(x => new
                {
                    x.ReportId,
                    x.ReportName
                })
                .ToList();

            UseReportAsLookUpEdit.Properties.DataSource = new[]
            {
                new { UseReportAs = UseReportAs.CopyToClipboard, UseReportAsDesc = Resources.Entity_FormReport_UseReportAs_CopyToClipboard },
                new { UseReportAs = UseReportAs.OpenPreview, UseReportAsDesc = Resources.Entity_FormReport_UseReportAs_OpenPreview },
                new { UseReportAs = UseReportAs.CopyToClipboardAndOpenPreview, UseReportAsDesc = Resources.Entity_FormReport_UseReportAs_CopyToClipboardAndOpenPreview }
            };
        }

        private void ClearControlsAddNew()
        {
            trFormReport = new TrFormReport
            {
                FormCode = initialFormCode ?? string.Empty,
                UseReportAs = UseReportAs.OpenPreview
            };

            trFormReportsBindingSource.DataSource = trFormReport;

            if (!string.IsNullOrWhiteSpace(initialFormCode))
                SetFormCodeReadOnly();

            ReportIdLookUpEdit.Select();
        }

        private void SetKeyEditorsReadOnly()
        {
            SetFormCodeReadOnly();
            ReportIdLookUpEdit.Properties.ReadOnly = true;
            ReportIdLookUpEdit.Properties.Appearance.BackColor = Color.LightGray;
        }

        private void SetFormCodeReadOnly()
        {
            FormCodeLookUpEdit.Properties.ReadOnly = true;
            FormCodeLookUpEdit.Properties.Appearance.BackColor = Color.LightGray;
        }

        private void btn_Ok_Click(object sender, EventArgs e)
        {
            trFormReportsBindingSource.EndEdit();
            trFormReport = trFormReportsBindingSource.Current as TrFormReport ?? new TrFormReport();

            if (!ValidateFormReport())
                return;

            if (initialReportId is null)
            {
                bool exists = dbContext.TrFormReports
                    .AsNoTracking()
                    .Any(x => x.FormCode == trFormReport.FormCode && x.ReportId == trFormReport.ReportId);

                if (exists)
                {
                    XtraMessageBox.Show(this, Resources.Form_Common_Exists, Resources.Common_Attention, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                dbContext.TrFormReports.Add(trFormReport);
            }

            dbContext.SaveChanges();
            DialogResult = DialogResult.OK;
        }

        private bool ValidateFormReport()
        {
            if (!dataLayoutControl1.IsValid(out List<string> errorList))
            {
                string combined = errorList.Aggregate((x, y) => x + "" + y);
                XtraMessageBox.Show(this, combined, Resources.Common_Attention, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(trFormReport.FormCode) || trFormReport.ReportId <= 0)
            {
                XtraMessageBox.Show(this, Resources.Form_PriceListDetail_Message_InvalidData, Resources.Common_Attention, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

    }
}
