using DevExpress.Office.NumberConverters;
using DevExpress.Utils.Svg;
using DevExpress.XtraBars;
using DevExpress.XtraBars.ToolbarForm;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using Foxoft.AppCode;
using Foxoft.Models;
using Foxoft.Properties;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Windows.Forms;

namespace Foxoft
{
    public partial class FormLogin : ToolbarForm
    {
        private readonly EfMethods efMethods = new();
        private readonly CustomMethods cM = new();

        private bool _isCurrentCompanyHealthy = false;
        private bool _isInitializing = true;

        public FormLogin()
        {
            InitializeComponent();

            txtEdit_UserName.Leave += (_, _) =>
            {
                UpdateCompanyListForUser();
                UpdateTerminalListForUser();
            };
            LUE_Terminal.QueryPopUp += (_, _) => UpdateTerminalListForUser();

            AcceptButton = btn_ERP;

            InitializeLoginState();
        }

        private void InitializeLoginState()
        {
            _isInitializing = true;
            try
            {
                List<DcCompany> companies;
                try
                {
                    companies = efMethods.SelectCompanies();
                }
                catch
                {
                    companies = new List<DcCompany>();
                }

                LUE_Company.Properties.DataSource = companies;

                string? savedCompany = Settings.Default.CompanyCode;
                string? targetCompany = null;

                if (!string.IsNullOrWhiteSpace(savedCompany) && companies.Any(c => c.CompanyCode == savedCompany))
                {
                    var health = CompanyDatabaseHelper.TestCompanyDatabase(savedCompany);
                    if (health.IsHealthy)
                    {
                        targetCompany = savedCompany;
                        _isCurrentCompanyHealthy = true;
                    }
                    else
                    {
                        // The previously saved company database is corrupted or inaccessible
                        string? alternateHealthy = CompanyDatabaseHelper.FindFirstHealthyCompany(companies, excludeCompanyCode: savedCompany);
                        if (!string.IsNullOrEmpty(alternateHealthy))
                        {
                            targetCompany = alternateHealthy;
                            _isCurrentCompanyHealthy = true;
                            SaveConnectionString(CompanyDatabaseHelper.BuildConnectionString(alternateHealthy));
                            Settings.Default.CompanyCode = alternateHealthy;
                            Settings.Default.Save();

                            XtraMessageBox.Show(
                                string.Format(Resources.Form_Login_AutoSwitchedToHealthyCompany, savedCompany, alternateHealthy),
                                Resources.Common_Attention,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                        }
                        else
                        {
                            targetCompany = savedCompany;
                            _isCurrentCompanyHealthy = false;

                            XtraMessageBox.Show(
                                string.Format(Resources.Form_Login_DatabaseCorruptedOrInaccessible, savedCompany, health.ErrorMessage),
                                Resources.Common_Attention,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                        }
                    }
                }
                else
                {
                    string? firstHealthy = CompanyDatabaseHelper.FindFirstHealthyCompany(companies);
                    if (!string.IsNullOrEmpty(firstHealthy))
                    {
                        targetCompany = firstHealthy;
                        _isCurrentCompanyHealthy = true;
                        SaveConnectionString(CompanyDatabaseHelper.BuildConnectionString(firstHealthy));
                        Settings.Default.CompanyCode = firstHealthy;
                        Settings.Default.Save();
                    }
                    else if (companies.Count > 0)
                    {
                        targetCompany = companies[0].CompanyCode;
                        _isCurrentCompanyHealthy = false;
                    }
                }

                LUE_Company.EditValue = targetCompany;

                if (_isCurrentCompanyHealthy && !string.IsNullOrEmpty(targetCompany))
                {
                    SaveConnectionString(CompanyDatabaseHelper.BuildConnectionString(targetCompany));
                }

                LoadLanguages();

                if (_isCurrentCompanyHealthy)
                {
                    LoadDataByDatabase();
                }
                else
                {
                    LoadOfflineDefaults();
                }

                UpdateCompanyListForUser();
                UpdateTerminalListForUser();
            }
            finally
            {
                _isInitializing = false;
            }
        }

        private void LoadLanguages()
        {
            List<DcUILanguage>? languages = null;

            if (_isCurrentCompanyHealthy)
            {
                try
                {
                    languages = efMethods.SelectEntities<DcUILanguage>();
                }
                catch
                {
                    languages = null;
                }
            }

            if (languages == null || languages.Count == 0)
            {
                languages = GetDefaultLanguages();
            }

            LUE_Language.Properties.DataSource = languages;

            if (LUE_Language.EditValue is null)
            {
                string savedLang = Settings.Default.LanguageCode;
                if (!string.IsNullOrEmpty(savedLang) && languages.Any(l => l.LanguageCode == savedLang))
                    LUE_Language.EditValue = savedLang;
                else
                    LUE_Language.EditValue = languages[0].LanguageCode;
            }
        }

        private static List<DcUILanguage> GetDefaultLanguages()
        {
            return new List<DcUILanguage>
            {
                new() { LanguageCode = "az", LanguageDesc = "Az\u0259rbaycanca" },
                new() { LanguageCode = "en", LanguageDesc = "English" },
                new() { LanguageCode = "tr", LanguageDesc = "T\u00FCrk\u00E7e" },
                new() { LanguageCode = "ru", LanguageDesc = "\u0420\u0443\u0441\u0441\u043A\u0438\u0439" }
            };
        }

        private void LoadOfflineDefaults()
        {
            try
            {
                AppFontSettings.Apply();
            }
            catch { }

            if (string.IsNullOrEmpty(txtEdit_UserName.Text))
                txtEdit_UserName.Text = Settings.Default.LoginName;
            if (string.IsNullOrEmpty(txtEdit_Password.Text))
                txtEdit_Password.Text = Settings.Default.LoginPassword;
            checkEdit_RemindMe.Checked = Settings.Default.LoginChecked;

            LUE_Terminal.Properties.DataSource = new List<DcTerminal>();
            LUE_Terminal.EditValue = null;
        }

        private void UpdateCompanyListForUser()
        {
            string userName = txtEdit_UserName.Text?.Trim() ?? string.Empty;
            List<DcCompany> companies;

            try
            {
                if (!string.IsNullOrWhiteSpace(userName) && efMethods.MainUserExist(userName))
                {
                    companies = efMethods.SelectCompaniesByUser(userName);
                }
                else
                {
                    companies = efMethods.SelectCompanies();
                }
            }
            catch
            {
                companies = new List<DcCompany>();
            }

            LUE_Company.Properties.DataSource = companies;

            string? currentVal = LUE_Company.EditValue?.ToString();
            if (companies.Count > 0 && (string.IsNullOrEmpty(currentVal) || !companies.Any(c => c.CompanyCode == currentVal)))
            {
                string? healthy = CompanyDatabaseHelper.FindFirstHealthyCompany(companies);
                LUE_Company.EditValue = healthy ?? companies[0].CompanyCode;
            }
        }

        private void UpdateTerminalListForUser()
        {
            string userName = txtEdit_UserName.Text?.Trim() ?? string.Empty;
            string? companyCode = LUE_Company.EditValue?.ToString();

            List<DcTerminal> terminals = new();

            if (_isCurrentCompanyHealthy && !string.IsNullOrWhiteSpace(userName) && !string.IsNullOrWhiteSpace(companyCode))
            {
                try
                {
                    string? storeCode = efMethods.SelectUserStoreCode(userName, companyCode);
                    if (!string.IsNullOrWhiteSpace(storeCode))
                    {
                        terminals = efMethods.SelectTerminalsByStore(storeCode, companyCode);
                    }
                }
                catch
                {
                    terminals = new List<DcTerminal>();
                }
            }

            LUE_Terminal.Properties.DataSource = terminals;

            int currentVal = Convert.ToInt32(LUE_Terminal.EditValue);
            if (terminals.Count > 0)
            {
                if (currentVal != 0 && terminals.Any(t => t.TerminalId == currentVal))
                {
                    // Keep current selection
                }
                else if (Settings.Default.TerminalId != 0 && terminals.Any(t => t.TerminalId == Settings.Default.TerminalId))
                {
                    LUE_Terminal.EditValue = Settings.Default.TerminalId;
                }
                else
                {
                    LUE_Terminal.EditValue = terminals[0].TerminalId;
                }
            }
            else
            {
                LUE_Terminal.EditValue = null;
            }

            TouchUIMode(Convert.ToInt32(LUE_Terminal.EditValue));
        }

        private void LoadDataByDatabase()
        {
            try
            {
                AppSetting? appSetting = efMethods.SelectEntityById<AppSetting>(1);
                Settings.Default.AppSetting = appSetting;
                Settings.Default.Save();
                AppFontSettings.Apply(appSetting?.AppFontSize);
            }
            catch
            {
                AppFontSettings.Apply();
            }

            if (string.IsNullOrEmpty(txtEdit_UserName.Text))
                txtEdit_UserName.Text = Settings.Default.LoginName;
            if (string.IsNullOrEmpty(txtEdit_Password.Text))
                txtEdit_Password.Text = Settings.Default.LoginPassword;
            if (LUE_Language.EditValue is null)
                LUE_Language.EditValue = Settings.Default.LanguageCode;
            checkEdit_RemindMe.Checked = Settings.Default.LoginChecked;

            UpdateTerminalListForUser();
        }

        private void TouchUIMode(int terminalId)
        {
            if (terminalId <= 0 || !_isCurrentCompanyHealthy)
                return;

            try
            {
                DcTerminal? dcTerminal = efMethods.SelectEntityById<DcTerminal>(terminalId);

                if (dcTerminal != null)
                {
                    if (dcTerminal.TouchUIMode == true)
                        WindowsFormsSettings.TouchUIMode = DevExpress.LookAndFeel.TouchUIMode.True;
                    else
                        WindowsFormsSettings.TouchUIMode = DevExpress.LookAndFeel.TouchUIMode.False;

                    WindowsFormsSettings.TouchScaleFactor = dcTerminal.TouchScaleFactor;
                }
            }
            catch
            {
                // Ignore terminal UI adjustment failures on corrupted databases
            }
        }

        private void btn_POS_Click(object sender, EventArgs e)
        {
            ExecuteLogin(isErp: false);
        }

        private void btn_ERP_Click(object sender, EventArgs e)
        {
            ExecuteLogin(isErp: true);
        }

        private void ExecuteLogin(bool isErp)
        {
            string? selectedCompany = LUE_Company.EditValue?.ToString();
            if (string.IsNullOrWhiteSpace(selectedCompany))
            {
                XtraMessageBox.Show(Resources.Form_Login_CompanyRequired, Resources.Common_Attention, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 1. Strictly verify the company database health before proceeding
            var health = CompanyDatabaseHelper.TestCompanyDatabase(selectedCompany);
            if (!health.IsHealthy)
            {
                _isCurrentCompanyHealthy = false;
                XtraMessageBox.Show(
                    string.Format(Resources.Form_Login_DatabaseCorruptedOrInaccessible, selectedCompany, health.ErrorMessage),
                    Resources.Common_Attention,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            _isCurrentCompanyHealthy = true;
            SaveConnectionString(health.ConnectionString);
            Settings.Default.CompanyCode = selectedCompany;
            Settings.Default.Save();

            // 2. Ensure AppSetting is loaded
            if (Settings.Default.AppSetting?.LocalCurrencyCode is null)
            {
                try
                {
                    AppSetting? appSetting = efMethods.SelectEntityById<AppSetting>(1);
                    Settings.Default.AppSetting = appSetting;
                    Settings.Default.Save();
                }
                catch { }

                if (Settings.Default.AppSetting?.LocalCurrencyCode is null)
                    XtraMessageBox.Show(Resources.Form_Login_LocalCurrencyNotSet);
            }

            UpdateCompanyListForUser();
            UpdateTerminalListForUser();

            // 3. Verify terminal selection
            int terminalId = Convert.ToInt32(LUE_Terminal.EditValue);
            if (terminalId == 0)
            {
                XtraMessageBox.Show(Resources.Form_Login_TerminalRequired, Resources.Common_Attention, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string userName = txtEdit_UserName.Text.Trim();
            string? userStoreCode = efMethods.SelectUserStoreCode(userName, selectedCompany);
            DcTerminal? dcTerminal;
            try
            {
                dcTerminal = efMethods.SelectEntityById<DcTerminal>(terminalId);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(
                    string.Format(Resources.Form_Login_DatabaseConnectionFailed, ex.Message),
                    Resources.Common_Attention,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            if (dcTerminal == null || string.IsNullOrEmpty(userStoreCode) || dcTerminal.StoreCode != userStoreCode)
            {
                XtraMessageBox.Show(Resources.Form_Login_TerminalStoreMismatch, Resources.Common_Attention, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 4. Verify license
            LicenseValidationResult licenseResult = CheckLicense(selectedCompany);
            if (!licenseResult.IsValid)
            {
                XtraMessageBox.Show(licenseResult.Message, Resources.Common_Attention, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (licenseResult.IsExpiringSoon)
            {
                _ = LicenseService.PublishExpiringSoonNotificationAsync(selectedCompany, licenseResult, userName);
            }

            // 5. Authenticate and log in
            bool loginSuccessful;
            try
            {
                loginSuccessful = Authorization.Login(userName, txtEdit_Password.Text, selectedCompany, checkEdit_RemindMe.Checked);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(
                    string.Format(Resources.Form_Login_DatabaseConnectionFailed, ex.Message),
                    Resources.Common_Attention,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            if (loginSuccessful)
            {
                SessionSave(
                    userName,
                    txtEdit_Password.Text,
                    checkEdit_RemindMe.Checked,
                    terminalId,
                    selectedCompany,
                    LUE_Language.EditValue?.ToString());

                CultureInfo culture = CultureInfo.CreateSpecificCulture(LUE_Language.EditValue?.ToString() ?? "az");
                Thread.CurrentThread.CurrentUICulture = culture;
                Thread.CurrentThread.CurrentCulture = culture;
                CultureInfo.DefaultThreadCurrentCulture = culture;
                CultureInfo.DefaultThreadCurrentUICulture = culture;

                Hide();
                if (isErp)
                {
                    FormERP formERP = new();
                    formERP.ShowDialog();
                }
                else
                {
                    FormPOS formPos = new();
                    formPos.ShowDialog();
                }
                Close();
            }
        }

        private LicenseValidationResult CheckLicense(string? companyCode)
        {
            return LicenseService.ValidateLicense(companyCode);
        }

        private static void SessionSave(string user, string password, bool Checked, int terminalId, string companyCode, string langCode)
        {
            Settings.Default.TerminalId = terminalId;
            Settings.Default.CompanyCode = companyCode;

            if (Checked)
            {
                Settings.Default.LoginName = user;
                Settings.Default.LoginPassword = password;
                Settings.Default.LanguageCode = langCode;
                Settings.Default.LoginChecked = Checked;
                Settings.Default.Save();
            }
            else
            {
                Settings.Default.LoginName = string.Empty;
                Settings.Default.LoginPassword = string.Empty;
                Settings.Default.LanguageCode = "az";
                Settings.Default.LoginChecked = false;
                Settings.Default.Save();
            }
        }

        private void BBI_GetKey_ItemClick(object sender, ItemClickEventArgs e)
        {
            string hardwareId = LicenseService.GetHardwareId();
            System.Windows.Clipboard.SetText(hardwareId);
            XtraMessageBox.Show(Resources.Form_Login_KeyCopiedToClipboard, Resources.Common_Attention, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void LUE_Terminal_EditValueChanged(object sender, EventArgs e)
        {
            TouchUIMode(Convert.ToInt32(LUE_Terminal.EditValue));
        }

        private void LUE_Company_EditValueChanging(object sender, ChangingEventArgs e)
        {
            if (_isInitializing)
                return;

            string? newCompanyCode = e.NewValue?.ToString();
            if (string.IsNullOrWhiteSpace(newCompanyCode))
                return;

            DcCompany? company;
            try
            {
                company = efMethods.SelectCompany(newCompanyCode);
            }
            catch
            {
                company = null;
            }

            var health = CompanyDatabaseHelper.TestCompanyDatabase(newCompanyCode);
            if (!health.IsHealthy)
            {
                string displayName = company?.CompanyDesc ?? company?.CompanyCode ?? newCompanyCode;
                DialogResult dr = XtraMessageBox.Show(
                    string.Format(Resources.Form_Login_ConfirmSelectCorruptedCompany, displayName, health.ErrorMessage),
                    Resources.Common_Attention,
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (dr == DialogResult.No)
                {
                    e.Cancel = true;
                    return;
                }

                _isCurrentCompanyHealthy = false;
                Settings.Default.CompanyCode = newCompanyCode;
                Settings.Default.Save();
                return;
            }

            _isCurrentCompanyHealthy = true;
            SaveConnectionString(health.ConnectionString);
            Settings.Default.CompanyCode = newCompanyCode;
            Settings.Default.Save();
        }

        private void LUE_Company_EditValueChanged(object sender, EventArgs e)
        {
            if (_isInitializing)
                return;

            string? selectedCompany = LUE_Company.EditValue?.ToString();
            if (string.IsNullOrWhiteSpace(selectedCompany))
                return;

            Settings.Default.CompanyCode = selectedCompany;
            Settings.Default.Save();

            if (_isCurrentCompanyHealthy)
            {
                LoadLanguages();
                LoadDataByDatabase();
            }
            else
            {
                LoadLanguages();
                LoadOfflineDefaults();
            }
        }

        private void SaveConnectionString(string constr)
        {
            Settings.Default.SubConnString = constr;
            Settings.Default.Save();
        }

        private void btn_ConStr(object sender, EventArgs e)
        {
            string currentSubConn = Settings.Default.SubConnString;
            if (string.IsNullOrWhiteSpace(currentSubConn))
                currentSubConn = Settings.Default.MainConnString;

            using FormConnectionStringBuilder form = new(currentSubConn);
            form.ShowDialog();

            RefreshDatabaseAndCompanyState();
        }

        private void RefreshDatabaseAndCompanyState()
        {
            string? currentCompany = LUE_Company.EditValue?.ToString();
            if (string.IsNullOrWhiteSpace(currentCompany))
                currentCompany = Settings.Default.CompanyCode;

            if (!string.IsNullOrWhiteSpace(currentCompany))
            {
                var health = CompanyDatabaseHelper.TestCompanyDatabase(currentCompany);
                if (health.IsHealthy)
                {
                    _isCurrentCompanyHealthy = true;
                    SaveConnectionString(health.ConnectionString);
                    LoadLanguages();
                    LoadDataByDatabase();
                    UpdateCompanyListForUser();
                    UpdateTerminalListForUser();

                    XtraMessageBox.Show(
                        Resources.Form_Connection_Result_Success,
                        Resources.Common_Attention,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    return;
                }
                else
                {
                    _isCurrentCompanyHealthy = false;
                    LoadLanguages();
                    LoadOfflineDefaults();
                }
            }

            UpdateCompanyListForUser();
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
        }

        private async void bbi_test_ItemClick(object sender, EventArgs e)
        {
        }
    }
}
