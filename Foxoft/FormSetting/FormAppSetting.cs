using DevExpress.XtraEditors;
using Foxoft.AppCode;
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

                if (OverpaymentModeImageComboBoxEdit.EditValue is int modeVal)
                    AppSetting.OverpaymentMode = (OverpaymentMode)modeVal;

                if (ucMessagingSetting1.IsLoaded)
                    ucMessagingSetting1.SaveMessagingSettings();

                dbContext.SaveChanges();

                Settings.Default.AppSetting = AppSetting;
                Settings.Default.Save();

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
    }
}
