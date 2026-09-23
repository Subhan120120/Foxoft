using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using Foxoft.AppCode;
using Foxoft.Models;
using Foxoft.Models.Entity.Report;
using Foxoft.Properties;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Windows.Forms;

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

            FormClosed += (_, _) => dbContext?.Dispose();
        }

        private void FormFormReport_Load(object sender, EventArgs e)
        {
            LoadFormReport();
        }

        private void LoadFormReport()
        {
            dbContext = new subContext();

            LoadLookups();

            if (initialReportId is null)
            {
                trFormReport = new TrFormReport
                {
                    FormCode = initialFormCode ?? string.Empty,
                    UseReportAs = UseReportAs.OpenPreview
                };

                trFormReportsBindingSource.DataSource = trFormReport;

                if (!string.IsNullOrWhiteSpace(initialFormCode))
                {
                    FormCodeLookUpEdit.Properties.ReadOnly = true;
                    ReportIdLookUpEdit.Select();
                }
                else
                {
                    FormCodeLookUpEdit.Select();
                }
            }
            else
            {
                trFormReport = dbContext.TrFormReports
                    .FirstOrDefault(x => x.FormCode == initialFormCode && x.ReportId == initialReportId.Value)
                    ?? new TrFormReport { FormCode = initialFormCode ?? string.Empty, ReportId = initialReportId.Value };

                trFormReportsBindingSource.DataSource = trFormReport;

                FormCodeLookUpEdit.Properties.ReadOnly = true;
                ReportIdLookUpEdit.Properties.ReadOnly = true;
                ShortcutButtonEdit.Select();
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
                new { Value = UseReportAs.OpenPreview, Name = Resources.Entity_FormReport_UseReportAs_OpenPreview },
                new { Value = UseReportAs.CopyToClipboard, Name = Resources.Entity_FormReport_UseReportAs_CopyToClipboard },
                new { Value = UseReportAs.CopyToClipboardAndOpenPreview, Name = Resources.Entity_FormReport_UseReportAs_CopyToClipboardAndOpenPreview }
            };
        }

        private void ShortcutButtonEdit_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            ShortcutButtonEdit.EditValue = null;
            trFormReport.Shortcut = null;
            dxErrorProvider1.SetError(ShortcutButtonEdit, string.Empty);
        }

        private void ShortcutButtonEdit_KeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = true;
            e.SuppressKeyPress = true;

            // Ignore standalone modifier keys
            if (e.KeyCode == Keys.ControlKey || e.KeyCode == Keys.ShiftKey || e.KeyCode == Keys.Menu)
                return;

            if (e.KeyCode == Keys.Escape || e.KeyCode == Keys.Delete || e.KeyCode == Keys.Back)
            {
                ShortcutButtonEdit.EditValue = null;
                trFormReport.Shortcut = null;
                dxErrorProvider1.SetError(ShortcutButtonEdit, string.Empty);
                return;
            }

            string shortcutStr = ShortcutHelper.KeysToString(e.KeyData);
            if (!string.IsNullOrEmpty(shortcutStr))
            {
                ShortcutButtonEdit.EditValue = shortcutStr;
                trFormReport.Shortcut = shortcutStr;
                dxErrorProvider1.SetError(ShortcutButtonEdit, string.Empty);
            }
        }

        private bool ValidateData()
        {
            dxErrorProvider1.ClearErrors();
            bool isValid = true;

            if (string.IsNullOrWhiteSpace(trFormReport.FormCode))
            {
                dxErrorProvider1.SetError(FormCodeLookUpEdit, string.Format(Resources.Validation_Required, Resources.Entity_FormReport_FormCode));
                isValid = false;
            }

            if (trFormReport.ReportId <= 0)
            {
                dxErrorProvider1.SetError(ReportIdLookUpEdit, string.Format(Resources.Validation_Required, Resources.Entity_FormReport_ReportId));
                isValid = false;
            }

            if (!isValid)
                return false;

            if (initialReportId is null)
            {
                bool exists = dbContext.TrFormReports
                    .AsNoTracking()
                    .Any(x => x.FormCode == trFormReport.FormCode && x.ReportId == trFormReport.ReportId);

                if (exists)
                {
                    XtraMessageBox.Show(this, Resources.Form_Common_Exists, Resources.Common_Attention, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }

            if (!string.IsNullOrWhiteSpace(trFormReport.Shortcut))
            {
                bool shortcutExists = dbContext.TrFormReports
                    .AsNoTracking()
                    .Any(x => x.FormCode == trFormReport.FormCode
                           && x.ReportId != trFormReport.ReportId
                           && x.Shortcut == trFormReport.Shortcut);

                if (shortcutExists)
                {
                    dxErrorProvider1.SetError(ShortcutButtonEdit, Resources.FormShortcut_DuplicateWarning);
                    XtraMessageBox.Show(this, Resources.FormShortcut_DuplicateWarning, Resources.Common_Attention, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }

            return true;
        }

        private void btn_Ok_Click(object sender, EventArgs e)
        {
            trFormReportsBindingSource.EndEdit();
            trFormReport = trFormReportsBindingSource.Current as TrFormReport ?? trFormReport;

            if (!ValidateData())
                return;

            try
            {
                if (initialReportId is null)
                {
                    dbContext.TrFormReports.Add(trFormReport);
                }

                dbContext.SaveChanges();
                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(this, ex.Message, Resources.Common_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
