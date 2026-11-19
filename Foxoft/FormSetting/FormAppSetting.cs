using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using Foxoft.AppCode;
using Foxoft.AppCode.Service;
using Foxoft.Models;
using Foxoft.Properties;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Drawing;
using System.IO;


namespace Foxoft
{
    public partial class FormAppSetting : XtraForm
    {
        subContext dbContext = new();
        AppSetting AppSetting;
        AdoMethods adoMethods = new();
        public class FindBy
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }

        public FormAppSetting()
        {
            InitializeComponent();
            BindCheckedCombo();
            InitNumberFormatControls();
        }

        private void FormAppSetting_Load(object sender, EventArgs e)
        {
            FillDataLayout();
        }


        private void BindCheckedCombo()
        {
            List<FindBy> list = new()
            {
                new() { Id = 1, Name = Resources.Entity_ProductBarcode_ProductCode },
                new() { Id = 2, Name = Resources.Common_Barcode },
                new() { Id = 3, Name = Resources.Entity_SerialNumber }
            };

            POSFindProductByCheckedComboBoxEdit.Properties.DataSource = list;
            POSFindProductByCheckedComboBoxEdit.Properties.ValueMember = nameof(FindBy.Id);
            POSFindProductByCheckedComboBoxEdit.Properties.DisplayMember = nameof(FindBy.Name);

            // Important for correct "value-based" operations
            POSFindProductByCheckedComboBoxEdit.Properties.SeparatorChar = ',';
        }

        private void SetSelectedIdsManual(string selectedIds)
        {
            POSFindProductByCheckedComboBoxEdit.Properties.Items.BeginUpdate();
            try
            {
                // Uncheck all first
                for (int i = 0; i < POSFindProductByCheckedComboBoxEdit.Properties.Items.Count; i++)
                    POSFindProductByCheckedComboBoxEdit.Properties.Items[i].CheckState = CheckState.Unchecked;

                if (string.IsNullOrWhiteSpace(selectedIds))
                    return;

                var set = selectedIds
                    .Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(x => x.Trim())
                    .ToHashSet(StringComparer.OrdinalIgnoreCase);

                for (int i = 0; i < POSFindProductByCheckedComboBoxEdit.Properties.Items.Count; i++)
                {
                    var val = POSFindProductByCheckedComboBoxEdit.Properties.Items[i].Value?.ToString();
                    if (val != null && set.Contains(val))
                        POSFindProductByCheckedComboBoxEdit.Properties.Items[i].CheckState = CheckState.Checked;
                }
            }
            finally
            {
                POSFindProductByCheckedComboBoxEdit.Properties.Items.EndUpdate();
            }
        }

        private void FillDataLayout()
        {
            dbContext = new subContext();

            dbContext.AppSettings
                .Where(x => x.Id == 1)
                .Load();

            appSettingBindingSource.DataSource = dbContext.AppSettings.Local.ToBindingList();

            AppSetting = dbContext.AppSettings.Local.FirstOrDefault(x => x.Id == 1);
            
            AppSetting.AppFontSize = AppFontSettings.NormalizeFontSize(AppSetting.AppFontSize);

            OverpaymentModeImageComboBoxEdit.EditValue = (int)AppSetting.OverpaymentMode;
            SetSelectedIdsManual(AppSetting.POSFindProductBy);
            LoadNumberFormatFromSetting();
        }


        private void Btn_Save_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidateChildren())
                    return;

                AppSetting ??= dbContext.AppSettings.Local.FirstOrDefault(x => x.Id == 1)
                            ?? dbContext.AppSettings.FirstOrDefault(x => x.Id == 1);
                                
                decimal previousFontSize = AppFontSettings.NormalizeFontSize(Settings.Default.AppSetting?.AppFontSize);

                appSettingBindingSource.EndEdit();
                AppSetting.POSFindProductBy = POSFindProductByCheckedComboBoxEdit.EditValue?.ToString()?.Trim() ?? "";
                AppSetting.AppFontSize = AppFontSettings.NormalizeFontSize(AppSetting.AppFontSize);
                AppSetting.NumberDecimalSeparator = GetSelectedDecimalSeparator();
                AppSetting.NumberGroupSeparator = GetSelectedGroupSeparator();
                AppSetting.NumberDecimalDigits = GetSelectedAmountDecimalDigits();
                AppSetting.QuantityDecimalDigits = GetSelectedQuantityDecimalDigits();

                if (OverpaymentModeImageComboBoxEdit.EditValue is int modeVal)
                    AppSetting.OverpaymentMode = (OverpaymentMode)modeVal;

                if (ucMessagingSetting1.IsLoaded)
                    ucMessagingSetting1.SaveMessagingSettings();

                dbContext.SaveChanges();

                Settings.Default.AppSetting = AppSetting;
                Settings.Default.Save();

                AppNumberFormat.Apply(AppSetting.NumberDecimalSeparator, AppSetting.NumberGroupSeparator, AppSetting.NumberDecimalDigits, AppSetting.QuantityDecimalDigits);

                if (AppFontSettings.NormalizeFontSize(AppSetting.AppFontSize) != previousFontSize)
                    XtraMessageBox.Show(Resources.Message_AppFontSizeRestartRequired, Resources.Common_Attention, MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    XtraMessageBox.Show(Resources.Common_SavedSuccessfully, Resources.Common_Info, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, Resources.Common_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool _isInitializingNumberFormat = false;

        private void InitNumberFormatControls()
        {
            cbeNumberDecimalSeparator.Properties.Items.Clear();
            cbeNumberDecimalSeparator.Properties.Items.AddRange(new object[]
            {
                Resources.Common_Default_System,
                Resources.Common_Dot,
                Resources.Common_Comma
            });

            cbeNumberGroupSeparator.Properties.Items.Clear();
            cbeNumberGroupSeparator.Properties.Items.AddRange(new object[]
            {
                Resources.Common_Default_System,
                Resources.Common_Space,
                Resources.Common_Comma,
                Resources.Common_Dot,
                Resources.Common_None
            });

            cbeNumberDecimalDigits.Properties.Items.Clear();
            cbeNumberDecimalDigits.Properties.Items.AddRange(new object[]
            {
                Resources.Common_Default_System,
                "0",
                "1",
                "2",
                "3",
                "4"
            });

            cbeQuantityDecimalDigits.Properties.Items.Clear();
            cbeQuantityDecimalDigits.Properties.Items.AddRange(new object[]
            {
                Resources.Common_Default_System,
                "0",
                "1",
                "2",
                "3",
                "4"
            });

            cbeNumberDecimalSeparator.SelectedIndexChanged += (s, e) => OnNumberFormatChanged();
            cbeNumberGroupSeparator.SelectedIndexChanged += (s, e) => OnNumberFormatChanged();
            cbeNumberDecimalDigits.SelectedIndexChanged += (s, e) => OnNumberFormatChanged();
            cbeQuantityDecimalDigits.SelectedIndexChanged += (s, e) => OnNumberFormatChanged();
        }

        private void LoadNumberFormatFromSetting()
        {
            _isInitializingNumberFormat = true;
            try
            {
                string dec = AppSetting?.NumberDecimalSeparator ?? string.Empty;
                if (dec == ".")
                    cbeNumberDecimalSeparator.SelectedItem = Resources.Common_Dot;
                else if (dec == ",")
                    cbeNumberDecimalSeparator.SelectedItem = Resources.Common_Comma;
                else
                    cbeNumberDecimalSeparator.SelectedItem = Resources.Common_Default_System;

                string grp = AppSetting?.NumberGroupSeparator ?? string.Empty;
                if (grp == " ")
                    cbeNumberGroupSeparator.SelectedItem = Resources.Common_Space;
                else if (grp == ",")
                    cbeNumberGroupSeparator.SelectedItem = Resources.Common_Comma;
                else if (grp == ".")
                    cbeNumberGroupSeparator.SelectedItem = Resources.Common_Dot;
                else if (string.Equals(grp, "None", StringComparison.OrdinalIgnoreCase) || (AppSetting?.NumberGroupSeparator != null && grp == ""))
                    cbeNumberGroupSeparator.SelectedItem = Resources.Common_None;
                else
                    cbeNumberGroupSeparator.SelectedItem = Resources.Common_Default_System;

                int? digits = AppSetting?.NumberDecimalDigits;
                if (digits.HasValue && digits.Value >= 0 && digits.Value <= 4)
                    cbeNumberDecimalDigits.SelectedItem = digits.Value.ToString();
                else
                    cbeNumberDecimalDigits.SelectedItem = Resources.Common_Default_System;

                int? qtyDigits = AppSetting?.QuantityDecimalDigits;
                if (qtyDigits.HasValue && qtyDigits.Value >= 0 && qtyDigits.Value <= 4)
                    cbeQuantityDecimalDigits.SelectedItem = qtyDigits.Value.ToString();
                else
                    cbeQuantityDecimalDigits.SelectedItem = Resources.Common_Default_System;
            }
            finally
            {
                _isInitializingNumberFormat = false;
            }

            UpdateNumberFormatPreview();
        }

        private string? GetSelectedDecimalSeparator()
        {
            string? sel = cbeNumberDecimalSeparator.SelectedItem?.ToString();
            if (sel == Resources.Common_Dot)
                return ".";
            if (sel == Resources.Common_Comma)
                return ",";
            return null; // System default
        }

        private string? GetSelectedGroupSeparator()
        {
            string? sel = cbeNumberGroupSeparator.SelectedItem?.ToString();
            if (sel == Resources.Common_Space)
                return " ";
            if (sel == Resources.Common_Comma)
                return ",";
            if (sel == Resources.Common_Dot)
                return ".";
            if (sel == Resources.Common_None)
                return "None";
            return null; // System default
        }

        private int? GetSelectedAmountDecimalDigits()
        {
            string? sel = cbeNumberDecimalDigits.SelectedItem?.ToString();
            if (int.TryParse(sel, out int val) && val >= 0)
                return val;
            return null; // System default
        }

        private int? GetSelectedQuantityDecimalDigits()
        {
            string? sel = cbeQuantityDecimalDigits.SelectedItem?.ToString();
            if (int.TryParse(sel, out int val) && val >= 0)
                return val;
            return null; // System default
        }

        private void OnNumberFormatChanged()
        {
            if (_isInitializingNumberFormat)
                return;

            string? dec = GetSelectedDecimalSeparator();
            string? grp = GetSelectedGroupSeparator();

            // Prevent selecting the same character for both decimal and grouping
            if (dec != null && grp != null && dec == grp)
            {
                _isInitializingNumberFormat = true;
                cbeNumberGroupSeparator.SelectedItem = dec == "." ? Resources.Common_Comma : Resources.Common_Dot;
                _isInitializingNumberFormat = false;
            }

            UpdateNumberFormatPreview();
        }

        private void UpdateNumberFormatPreview()
        {
            string? dec = GetSelectedDecimalSeparator();
            string? grp = GetSelectedGroupSeparator();
            int? amountDigits = GetSelectedAmountDecimalDigits();
            int? qtyDigits = GetSelectedQuantityDecimalDigits();

            var sysCulture = System.Globalization.CultureInfo.InstalledUICulture ?? System.Globalization.CultureInfo.CurrentCulture;
            string actualDec = dec ?? sysCulture.NumberFormat.NumberDecimalSeparator;
            string actualGrp = grp == "None" ? "" : (grp ?? sysCulture.NumberFormat.NumberGroupSeparator);
            int actualAmountDigits = amountDigits ?? (sysCulture.NumberFormat.NumberDecimalDigits >= 0 ? sysCulture.NumberFormat.NumberDecimalDigits : 2);

            if (actualDec == actualGrp && !string.IsNullOrEmpty(actualGrp))
                actualGrp = actualDec == "." ? "," : ".";

            var previewCulture = (System.Globalization.CultureInfo)System.Globalization.CultureInfo.CurrentCulture.Clone();
            previewCulture.NumberFormat.NumberDecimalSeparator = actualDec;
            previewCulture.NumberFormat.NumberGroupSeparator = actualGrp;
            previewCulture.NumberFormat.NumberDecimalDigits = actualAmountDigits;

            string qtyFormat = AppNumberFormat.BuildQuantityFormatString(qtyDigits);

            decimal sampleAmount = 1234.5678m;
            decimal sampleQtyInt = 15m;
            decimal sampleQtyFrac = 15.375m;

            string amountPreview = sampleAmount.ToString($"n{actualAmountDigits}", previewCulture);
            string qtyIntPreview = sampleQtyInt.ToString(qtyFormat, previewCulture);
            string qtyFracPreview = sampleQtyFrac.ToString(qtyFormat, previewCulture);

            lblNumberFormatPreview.Text = $"{amountPreview} | {qtyIntPreview} / {qtyFracPreview}";
        }

        private void Btn_OptimizeDatabaseIndexes_Click(object sender, EventArgs e)
        {
            adoMethods.RebuldOrReorganizeDatabase();
            btn_OptimizeDatabaseIndexes.Text = string.Format(Resources.Entity_AppSetting_OptimizeDatabaseIndexes, adoMethods.DatabaseAVGFragmentationPercent());
        }

        private void Btn_ClearMemory_Click(object sender, EventArgs e)
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        private void txtOpenAIApiKey_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            txtOpenAIApiKey.Properties.UseSystemPasswordChar = !txtOpenAIApiKey.Properties.UseSystemPasswordChar;
            e.Button.Caption = txtOpenAIApiKey.Properties.UseSystemPasswordChar ? "Göstər" : "Gizlət";
        }

        private async void btn_TestOpenAI_Click(object sender, EventArgs e)
        {
            string apiKey = txtOpenAIApiKey.Text.Trim();
            if (string.IsNullOrWhiteSpace(apiKey))
            {
                XtraMessageBox.Show(Resources.Form_InvoiceWizard_ApiKeyRequired, Resources.Common_Attention, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            btn_TestOpenAI.Enabled = false;
            try
            {
                InvoiceOcrService ocrService = new();
                string model = string.IsNullOrWhiteSpace(cbeOpenAIModel.Text) ? "gpt-4o" : cbeOpenAIModel.Text.Trim();
                var (success, message) = await ocrService.TestConnectionAsync(apiKey, model);
                XtraMessageBox.Show(message, success ? Resources.Common_Info : Resources.Common_Error, MessageBoxButtons.OK, success ? MessageBoxIcon.Information : MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, Resources.Common_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btn_TestOpenAI.Enabled = true;
            }
        }

        private void btn_ProductMatchSettings_Click(object sender, EventArgs e)
        {
            using FormProductMatchSetting form = new();
            form.ShowDialog(this);
        }
    }
}
