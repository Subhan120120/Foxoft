using DevExpress.XtraEditors;
using Foxoft.Models;
using Foxoft.Properties;
using Microsoft.EntityFrameworkCore;
using System.Data;


namespace Foxoft
{
    public partial class FormAppSetting : XtraForm
    {
        subContext dbContext = new();
        AppSetting AppSetting;
        AdoMethods adoMethods = new();
        public class SearchType
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
            List<SearchType> list = new()
            {
                new() { Id = 1, Name = "ProductCode" },
                new() { Id = 2, Name = "Barcode" },
                new() { Id = 3, Name = "SerialNumber" }
            };

            POSFindProductByCheckedComboBoxEdit.Properties.DataSource = list;
            POSFindProductByCheckedComboBoxEdit.Properties.ValueMember = nameof(SearchType.Id);
            POSFindProductByCheckedComboBoxEdit.Properties.DisplayMember = nameof(SearchType.Name);

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
                .LoadAsync()
                .ContinueWith(loadTask =>
                {
                    // If the load failed, throw so you see the real exception
                    if (loadTask.IsFaulted)
                        throw loadTask.Exception!;

                    // Bind source after load
                    appSettingBindingSource.DataSource = dbContext.AppSettings.Local.ToBindingList();

                    // Get the loaded entity (or create it if not exists)
                    AppSetting = dbContext.AppSettings.Local.FirstOrDefault(x => x.Id == 1);

                    // Now safe
                    SetSelectedIdsManual(AppSetting.POSFindProductBy);

                }, TaskScheduler.FromCurrentSynchronizationContext());
        }


        private void Btn_Save_Click(object sender, EventArgs e)
        {
            // Ensure AppSetting is not null
            AppSetting ??= dbContext.AppSettings.Local.FirstOrDefault(x => x.Id == 1)
                        ?? dbContext.AppSettings.FirstOrDefault(x => x.Id == 1);

            AppSetting.POSFindProductBy = POSFindProductByCheckedComboBoxEdit.EditValue?.ToString()?.Trim() ?? "";
            dbContext.SaveChanges();
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