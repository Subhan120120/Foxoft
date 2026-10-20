using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;
using DevExpress.XtraWizard;
using Foxoft.AppCode;
using Foxoft.Models;
using Foxoft.Models.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace Foxoft
{
    public partial class FormGoogleContactWizard : XtraForm
    {
        private readonly GoogleContactAPI _contactApi = new();
        private BindingList<GoogleContactWizardItemVM> _itemsList = new();
        private readonly HashSet<string> _preSelectedCodes = new(StringComparer.OrdinalIgnoreCase);
        private readonly byte[]? _initialCurrAccTypes;
        private string? _connectedEmail;
        private bool _isConnected;
        private bool _isExporting;
        private bool _isExportCompleted;
        private CancellationTokenSource? _exportCts;

        public FormGoogleContactWizard()
        {
            InitializeComponent();
        }

        public FormGoogleContactWizard(IEnumerable<string>? preSelectedCurrAccCodes, byte[]? initialCurrAccTypes = null)
            : this()
        {
            if (preSelectedCurrAccCodes != null)
            {
                foreach (var code in preSelectedCurrAccCodes)
                {
                    if (!string.IsNullOrWhiteSpace(code))
                        _preSelectedCodes.Add(code);
                }
            }

            _initialCurrAccTypes = initialCurrAccTypes;
        }

        private async void FormGoogleContactWizard_Load(object sender, EventArgs e)
        {
            ApplyInitialFilterSettings();
            await CheckConnectionAsync(false);
        }

        private void ApplyInitialFilterSettings()
        {
            if (_initialCurrAccTypes != null && _initialCurrAccTypes.Length > 0)
            {
                chkFilterCustomer.Checked = _initialCurrAccTypes.Contains((byte)CurrAccType.Customer);
                chkFilterSupplier.Checked = _initialCurrAccTypes.Contains((byte)CurrAccType.Supplier);
                chkFilterPersonnel.Checked = _initialCurrAccTypes.Contains((byte)CurrAccType.Personnel);
                chkFilterOthers.Checked = _initialCurrAccTypes.Contains((byte)CurrAccType.Store) ||
                                          _initialCurrAccTypes.Contains((byte)CurrAccType.CashRegister);
            }
        }

        private async Task CheckConnectionAsync(bool showErrorMessage)
        {
            lblConnectionStatus.Text = Properties.Resources.Form_GoogleContactWizard_CheckingConnection;
            btnCheckConnection.Enabled = false;

            try
            {
                var (isSuccess, message, email) = await _contactApi.TestConnectionAsync();
                _isConnected = isSuccess;

                if (isSuccess)
                {
                    _connectedEmail = email ?? "Google Account";
                    lblConnectionStatus.Text = string.Format(Properties.Resources.Form_GoogleContactWizard_ConnectedAs, _connectedEmail);
                }
                else
                {
                    _connectedEmail = null;
                    lblConnectionStatus.Text = string.Format(Properties.Resources.Form_GoogleContactWizard_ConnectionFailed, message);

                    if (showErrorMessage)
                    {
                        XtraMessageBox.Show(this,
                            string.Format(Properties.Resources.Form_GoogleContactWizard_ConnectionFailed, message),
                            Properties.Resources.Common_Error,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                }
            }
            finally
            {
                btnCheckConnection.Enabled = true;
            }
        }

        private async void BtnCheckConnection_Click(object sender, EventArgs e)
        {
            await CheckConnectionAsync(true);
        }

        private void BtnResetToken_Click(object sender, EventArgs e)
        {
            _contactApi.ResetToken();
            _isConnected = false;
            _connectedEmail = null;
            lblConnectionStatus.Text = Properties.Resources.Form_GoogleContactWizard_StatusNotChecked;
        }

        private void ChkAddPrefix_CheckedChanged(object sender, EventArgs e)
        {
            txtPrefix.Enabled = chkAddPrefix.Checked;
        }

        private void BtnSelectAll_Click(object sender, EventArgs e)
        {
            foreach (var item in _itemsList)
                item.Selected = true;

            UpdateAccountsSummary();
            gridViewAccounts.RefreshData();
        }

        private void BtnUnselectAll_Click(object sender, EventArgs e)
        {
            foreach (var item in _itemsList)
                item.Selected = false;

            UpdateAccountsSummary();
            gridViewAccounts.RefreshData();
        }

        private void BtnSelectNewOnly_Click(object sender, EventArgs e)
        {
            foreach (var item in _itemsList)
                item.Selected = !item.ExistsInGoogle && item.HasPhone;

            UpdateAccountsSummary();
            gridViewAccounts.RefreshData();
        }

        private void GridViewAccounts_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            if (e.RowHandle >= 0)
            {
                var item = gridViewAccounts.GetRow(e.RowHandle) as GoogleContactWizardItemVM;
                if (item != null && item.ExistsInGoogle)
                {
                    e.Appearance.BackColor = Color.FromArgb(254, 249, 231);
                    e.HighPriority = true;
                }
            }
        }

        private void GridViewAccounts_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column == colSelected && e.Value is bool isSelected)
            {
                var row = gridViewAccounts.GetRow(e.RowHandle) as GoogleContactWizardItemVM;
                if (row != null)
                {
                    row.Selected = isSelected;
                    BeginInvoke(new Action(UpdateAccountsSummary));
                }
            }
        }

        private void UpdateAccountsSummary()
        {
            int selected = _itemsList.Count(x => x.Selected);
            int total = _itemsList.Count;
            int exists = _itemsList.Count(x => x.ExistsInGoogle);
            int newCount = _itemsList.Count(x => !x.ExistsInGoogle && x.HasPhone);

            lblAccountsSummary.Text = string.Format(Properties.Resources.Form_GoogleContactWizard_SummaryWithGoogleCounts, selected, total, newCount, exists);
        }

        private async void WizardControl1_NextClick(object sender, WizardCommandButtonClickEventArgs e)
        {
            if (e.Page == welcomeWizardPage1)
            {
                e.Handled = true;

                if (!_isConnected)
                {
                    await CheckConnectionAsync(false);
                    if (!_isConnected)
                    {
                        var confirm = XtraMessageBox.Show(this,
                            Properties.Resources.Form_GoogleContactWizard_AuthRequired,
                            Properties.Resources.Common_Attention,
                            MessageBoxButtons.OKCancel,
                            MessageBoxIcon.Question);

                        if (confirm == DialogResult.OK)
                        {
                            await CheckConnectionAsync(true);
                        }

                        if (!_isConnected)
                            return;
                    }
                }

                await LoadAndVerifyAccountsAsync();

                if (_itemsList.Count == 0)
                {
                    XtraMessageBox.Show(this,
                        Properties.Resources.Form_GoogleContactWizard_NoAccountsSelected,
                        Properties.Resources.Common_Attention,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                wizardControl1.SelectedPage = wizardPageAccounts;
                return;
            }
            else if (e.Page == wizardPageAccounts)
            {
                gridViewAccounts.CloseEditor();
                gridViewAccounts.UpdateCurrentRow();

                int selectedCount = _itemsList.Count(x => x.Selected);
                if (selectedCount == 0)
                {
                    XtraMessageBox.Show(this,
                        Properties.Resources.Form_GoogleContactWizard_NoAccountsSelected,
                        Properties.Resources.Common_Attention,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    e.Handled = true;
                    return;
                }
            }
            else if (e.Page == wizardPageOptions)
            {
                int selectedCount = _itemsList.Count(x => x.Selected);
                lblSummary.Text = string.Format(Properties.Resources.Form_GoogleContactWizard_ExportSummary, selectedCount, _connectedEmail ?? "Google");
                progressBar.Position = 0;
                lblProgressStatus.Text = string.Empty;
            }
        }

        private async Task LoadAndVerifyAccountsAsync()
        {
            SplashScreenManager.ShowForm(this, typeof(WaitForm), true, true, false);
            SplashScreenManager.Default?.SetWaitFormDescription(Properties.Resources.Form_GoogleContactWizard_CheckingGoogleContacts);

            try
            {
                var vms = LoadAccountsFromDatabase();

                Dictionary<string, string> googleContactsMap = new(StringComparer.OrdinalIgnoreCase);
                if (_isConnected)
                {
                    googleContactsMap = await _contactApi.GetExistingContactsMapAsync();
                }

                foreach (var item in vms)
                {
                    string matchedGoogleName = string.Empty;
                    bool exists = false;

                    if (!string.IsNullOrEmpty(item.CleanPhoneNum) && googleContactsMap.TryGetValue(item.CleanPhoneNum, out var name1))
                    {
                        exists = true;
                        matchedGoogleName = name1;
                    }
                    else if (item.AdditionalPhoneNumbers != null && item.AdditionalPhoneNumbers.Count > 0)
                    {
                        foreach (var addPhone in item.AdditionalPhoneNumbers)
                        {
                            string addNorm = GoogleContactAPI.NormalizePhone(addPhone);
                            if (!string.IsNullOrEmpty(addNorm) && googleContactsMap.TryGetValue(addNorm, out var name2))
                            {
                                exists = true;
                                matchedGoogleName = name2;
                                break;
                            }
                        }
                    }

                    item.ExistsInGoogle = exists;
                    if (exists)
                    {
                        item.GoogleContactName = string.IsNullOrWhiteSpace(matchedGoogleName) ? Properties.Resources.Form_GoogleContactWizard_Status_ExistsInGoogle : matchedGoogleName;
                        item.GoogleStatus = Properties.Resources.Form_GoogleContactWizard_Status_ExistsInGoogle;
                        item.Selected = _preSelectedCodes.Count > 0 ? _preSelectedCodes.Contains(item.CurrAccCode) : false;
                    }
                    else if (item.HasPhone)
                    {
                        item.GoogleContactName = "-";
                        item.GoogleStatus = Properties.Resources.Form_GoogleContactWizard_Status_NewInGoogle;
                        item.Selected = _preSelectedCodes.Count > 0 ? _preSelectedCodes.Contains(item.CurrAccCode) : true;
                    }
                    else
                    {
                        item.GoogleContactName = "-";
                        item.GoogleStatus = "-";
                        item.Selected = false;
                    }
                }

                _itemsList = new BindingList<GoogleContactWizardItemVM>(vms);
                gridControlAccounts.DataSource = _itemsList;
                gridViewAccounts.BestFitColumns();
                UpdateAccountsSummary();
            }
            finally
            {
                try
                {
                    SplashScreenManager.CloseForm(false);
                }
                catch
                {
                    // Ignore if already closed
                }
            }
        }

        private List<GoogleContactWizardItemVM> LoadAccountsFromDatabase()
        {
            using var db = new subContext();

            List<CurrAccType> selectedTypes = new();
            if (chkFilterCustomer.Checked) selectedTypes.Add(CurrAccType.Customer);
            if (chkFilterSupplier.Checked) selectedTypes.Add(CurrAccType.Supplier);
            if (chkFilterPersonnel.Checked) selectedTypes.Add(CurrAccType.Personnel);
            if (chkFilterOthers.Checked)
            {
                selectedTypes.Add(CurrAccType.Store);
                selectedTypes.Add(CurrAccType.CashRegister);
            }

            var query = db.DcCurrAccs.AsNoTracking()
                .Include(x => x.DcCurrAccContactDetails)
                .Where(x => !x.IsDisabled && selectedTypes.Contains(x.CurrAccTypeCode));

            if (chkOnlyWithPhone.Checked)
            {
                query = query.Where(x => (!string.IsNullOrEmpty(x.PhoneNum) && x.PhoneNum.Trim() != "") ||
                                         x.DcCurrAccContactDetails.Any(cd => cd.ContactTypeId == ContactType.Phone && !string.IsNullOrEmpty(cd.ContactDesc)));
            }

            var accList = query.OrderBy(x => x.CurrAccDesc).ToList();

            var vms = new List<GoogleContactWizardItemVM>();

            foreach (var acc in accList)
            {
                string phone = acc.PhoneNum ?? string.Empty;
                List<string> addPhones = new();
                string email = string.Empty;
                List<string> addEmails = new();

                if (acc.DcCurrAccContactDetails != null)
                {
                    foreach (var detail in acc.DcCurrAccContactDetails)
                    {
                        if (detail.ContactTypeId == ContactType.Phone && !string.IsNullOrWhiteSpace(detail.ContactDesc))
                        {
                            if (string.IsNullOrWhiteSpace(phone))
                                phone = detail.ContactDesc.Trim();
                            else if (detail.ContactDesc.Trim() != phone.Trim())
                                addPhones.Add(detail.ContactDesc.Trim());
                        }
                        else if (detail.ContactTypeId == ContactType.Email && !string.IsNullOrWhiteSpace(detail.ContactDesc))
                        {
                            if (string.IsNullOrWhiteSpace(email))
                                email = detail.ContactDesc.Trim();
                            else if (detail.ContactDesc.Trim() != email.Trim())
                                addEmails.Add(detail.ContactDesc.Trim());
                        }
                    }
                }

                string typeName = acc.CurrAccTypeCode switch
                {
                    CurrAccType.Customer => Properties.Resources.Form_GoogleContactWizard_FilterCustomers,
                    CurrAccType.Supplier => Properties.Resources.Form_GoogleContactWizard_FilterSuppliers,
                    CurrAccType.Personnel => Properties.Resources.Form_GoogleContactWizard_FilterPersonnel,
                    CurrAccType.Store => "Mağaza",
                    CurrAccType.CashRegister => "Kassa",
                    _ => acc.CurrAccTypeCode.ToString()
                };

                vms.Add(new GoogleContactWizardItemVM
                {
                    Selected = true,
                    CurrAccCode = acc.CurrAccCode,
                    CurrAccDesc = acc.CurrAccDesc ?? string.Empty,
                    FirstName = acc.FirstName,
                    LastName = acc.LastName,
                    FatherName = acc.FatherName,
                    PhoneNum = phone,
                    CleanPhoneNum = GoogleContactAPI.NormalizePhone(phone),
                    AdditionalPhoneNumbers = addPhones,
                    Email = email,
                    AdditionalEmails = addEmails,
                    Address = acc.Address,
                    CurrAccTypeCode = acc.CurrAccTypeCode,
                    CurrAccTypeName = typeName,
                    Status = Properties.Resources.Form_GoogleContactWizard_Status_Pending
                });
            }

            return vms;
        }

        private async void BtnStartExport_Click(object sender, EventArgs e)
        {
            if (_isExporting) return;

            var selectedItems = _itemsList.Where(x => x.Selected).ToList();
            if (selectedItems.Count == 0)
            {
                XtraMessageBox.Show(this,
                    Properties.Resources.Form_GoogleContactWizard_NoAccountsSelected,
                    Properties.Resources.Common_Attention,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            string confirmMsg = string.Format(Properties.Resources.Form_GoogleContactWizard_ConfirmExport, selectedItems.Count);
            if (XtraMessageBox.Show(this, confirmMsg, Properties.Resources.Common_Attention, MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            await ExecuteExportAsync(selectedItems);
        }

        private async Task ExecuteExportAsync(List<GoogleContactWizardItemVM> selectedItems)
        {
            _isExporting = true;
            btnStartExport.Enabled = false;
            wizardControl1.SelectedPage.AllowBack = false;
            wizardControl1.SelectedPage.AllowNext = false;
            wizardControl1.SelectedPage.AllowFinish = false;

            progressBar.Properties.Maximum = selectedItems.Count;
            progressBar.Position = 0;
            memoLog.Text = string.Empty;

            var options = new GoogleContactExportOptions
            {
                NameFormat = rgNameFormat.SelectedIndex == 1 ? ContactNameFormat.FirstAndLastName : ContactNameFormat.DescAsFullName,
                AddPrefix = chkAddPrefix.Checked,
                Prefix = txtPrefix.Text,
                IncludeNote = chkIncludeNote.Checked,
                SetOrganization = chkSetOrganization.Checked,
                SkipDuplicates = chkSkipDuplicates.Checked
            };

            _exportCts = new CancellationTokenSource();

            var progress = new Progress<GoogleContactExportProgress>(p =>
            {
                progressBar.Position = p.CurrentIndex;
                lblProgressStatus.Text = string.Format(Properties.Resources.Form_GoogleContactWizard_ExportInProgress, p.CurrentIndex, p.TotalCount);
                memoLog.MaskBox.AppendText(p.Message + Environment.NewLine);
            });

            try
            {
                var (added, skipped, failed) = await _contactApi.ExportContactsAsync(selectedItems, options, progress, _exportCts.Token);

                _isExportCompleted = true;
                string completedMsg = string.Format(Properties.Resources.Form_GoogleContactWizard_ExportCompleted, selectedItems.Count, added, skipped, failed);
                lblProgressStatus.Text = completedMsg;
                memoLog.MaskBox.AppendText(Environment.NewLine + completedMsg + Environment.NewLine);

                XtraMessageBox.Show(this, completedMsg, Properties.Resources.Common_Info, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (OperationCanceledException)
            {
                lblProgressStatus.Text = "Export cancelled.";
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(this, ex.Message, Properties.Resources.Common_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                _isExporting = false;
                btnStartExport.Enabled = true;
                wizardControl1.SelectedPage.AllowBack = true;
                wizardControl1.SelectedPage.AllowFinish = true;
            }
        }

        private async void WizardControl1_FinishClick(object sender, CancelEventArgs e)
        {
            if (!_isExportCompleted)
            {
                var selectedItems = _itemsList.Where(x => x.Selected).ToList();
                if (selectedItems.Count > 0)
                {
                    string confirmMsg = string.Format(Properties.Resources.Form_GoogleContactWizard_ConfirmExport, selectedItems.Count);
                    if (XtraMessageBox.Show(this, confirmMsg, Properties.Resources.Common_Attention, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        e.Cancel = true;
                        await ExecuteExportAsync(selectedItems);
                        return;
                    }
                }
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void WizardControl1_CancelClick(object sender, CancelEventArgs e)
        {
            if (_isExporting)
            {
                _exportCts?.Cancel();
            }

            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void FormGoogleContactWizard_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_isExporting)
            {
                _exportCts?.Cancel();
            }

            _contactApi.Dispose();
        }
    }
}
