using DevExpress.XtraDataLayout;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.DXErrorProvider;
using Foxoft.Models;
using Foxoft.Properties;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.Drawing.Printing;
using System.IO;

namespace Foxoft
{
    public partial class FormTerminal : XtraForm
    {
        subContext? dbContext;
        EfMethods efMethods = new EfMethods();
        bool isLoading;

        // Edit olunan entity
        public DcTerminal dcTerminal = new();

        public FormTerminal()
        {
            InitializeComponent();

            AcceptButton = btn_Ok;
            CancelButton = btn_Cancel;

        }

        public FormTerminal(int terminalId)
            : this()
        {
            dcTerminal.TerminalId = terminalId;

            // ID editdə dəyişməsin
            TerminalIdTextEdit.Properties.ReadOnly = true;
            TerminalIdTextEdit.Properties.Appearance.BackColor = Color.LightGray;
        }

        private void FormTerminal_Load(object sender, EventArgs e)
        {
            isLoading = true;

            try
            {
                LoadLookups();
                LoadPrinters();
                LoadTerminal();
                LoadLayout();
                EnsureTerminalFieldsVisible();
            }
            finally
            {
                isLoading = false;
            }

            dataLayoutControl1.IsValid(out List<string> errorList);
        }

        private void LoadLookups()
        {
            StoreCodeLookUpEdit.Properties.DataSource = efMethods.SelectStores();
        }

        private void LoadPrinters()
        {
            PrinterNameComboBoxEdit.Properties.Items.Clear();

            foreach (string printerName in PrinterSettings.InstalledPrinters)
                PrinterNameComboBoxEdit.Properties.Items.Add(printerName);
        }

        private void LoadTerminal()
        {
            dbContext = new subContext();

            if (dcTerminal.TerminalId <= 0)
                ClearControlsAddNew();
            else
            {
                dbContext.DcTerminals.Where(x => x.TerminalId == dcTerminal.TerminalId).Load();
                dcTerminalsBindingSource.DataSource = dbContext.DcTerminals.Local.ToBindingList();
            }
        }

        private void LoadLayout()
        {
            string fileName = "FormTerminal.xml";
            string layoutFilePath = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData),
                "Foxoft",
                Settings.Default.CompanyCode,
                "Layout Xml Files",
                fileName);

            if (File.Exists(layoutFilePath))
                dataLayoutControl1.RestoreLayoutFromXml(layoutFilePath);
        }

        private void EnsureTerminalFieldsVisible()
        {
            var visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;

            ItemForTerminalId.Visibility = visibility;
            ItemForTerminalDesc.Visibility = visibility;
            ItemForStoreCode.Visibility = visibility;
            ItemForCashRegisterCode.Visibility = visibility;
            ItemForPrinterName.Visibility = visibility;
            ItemForIsDisabled.Visibility = visibility;
            ItemForTouchUIMode.Visibility = visibility;
            ItemForTouchScaleFactor.Visibility = visibility;
            ItemForRowGuid.Visibility = visibility;
        }

        private void ClearControlsAddNew()
        {
            dcTerminal = (DcTerminal)dcTerminalsBindingSource.AddNew();

            // Default-lar
            dcTerminal.IsDisabled = false;
            dcTerminal.TouchUIMode = false;
            dcTerminal.TouchScaleFactor = 1;
            dcTerminal.PrinterName = GetDefaultPrinterName();

            if (dcTerminal.RowGuid == null)
                dcTerminal.RowGuid = Guid.NewGuid();

            dcTerminalsBindingSource.DataSource = dcTerminal;
            TerminalDescTextEdit.Select();
        }

        private void dataLayoutControl1_FieldRetrieving(object sender, FieldRetrievingEventArgs e)
        {
            if (e.FieldName is nameof(BaseEntity.CreatedDate)
                or nameof(BaseEntity.CreatedUserName)
                or nameof(BaseEntity.LastUpdatedDate)
                or nameof(BaseEntity.LastUpdatedUserName)
                or nameof(DcTerminal.DcCashRegister)
                or nameof(DcTerminal.DcStore)
                or nameof(DcTerminal.TrInvoiceHeaders))
            {
                e.Visible = false;
                e.Handled = true;
            }
        }

        private void btn_Ok_Click(object sender, EventArgs e)
        {
            if (!ValidateChildren())
                return;

            if (dataLayoutControl1.IsValid(out List<string> errorList))
            {
                dcTerminalsBindingSource.EndEdit();
                if (dcTerminalsBindingSource.Current is not DcTerminal currentTerminal)
                    return;

                dcTerminal = currentTerminal;
                dbContext ??= new subContext();

                if (dcTerminal.TerminalId <= 0)
                    dbContext.DcTerminals.Add(dcTerminal);

                dbContext.SaveChanges();

                DialogResult = DialogResult.OK;
            }
            else
            {
                XtraMessageBox.Show(
                    string.Join(Environment.NewLine, errorList),
                    Resources.Common_Error,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void CashRegisterCodeButtonEdit_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            ButtonEdit editor = (ButtonEdit)sender;
            string storeCode = StoreCodeLookUpEdit.EditValue?.ToString() ?? string.Empty;

            using (FormCashRegisterList form = new(editor.EditValue?.ToString() ?? string.Empty, storeCode, PaymentType.Cash))
            {
                if (form.ShowDialog(this) == DialogResult.OK && form.dcCurrAcc is not null)
                {
                    editor.EditValue = form.dcCurrAcc.CurrAccCode;
                }
            }
        }

        private void Btn_CashRegCode_Validating(object sender, CancelEventArgs e)
        {
            if (sender is not ButtonEdit editor)
                return;

            dxErrorProvider1.SetError(editor, string.Empty);

            string value = editor.Text?.Trim() ?? string.Empty;

            if (string.IsNullOrEmpty(value))
                return;

            DcCurrAcc? curr = efMethods.SelectCashReg(value, PaymentType.Cash);

            if (curr is null)
            {
                SetValidationError(editor, e, Resources.Form_Invoice_NoCashReg);
                return;
            }

            dxErrorProvider1.SetError(editor, string.Empty);
        }

        private void Btn_CashRegCode_InvalidValue(object sender, InvalidValueExceptionEventArgs e)
        {
            e.ExceptionMode = ExceptionMode.DisplayError;
        }

        private void SetValidationError(BaseEdit editor, CancelEventArgs e, string message)
        {
            dxErrorProvider1.SetError(editor, message, ErrorType.Critical);
            e.Cancel = true;
        }

        private void StoreCodeLookUpEdit_EditValueChanged(object sender, EventArgs e)
        {
            if (isLoading)
                return;

            CashRegisterCodeButtonEdit.EditValue = null;
        }

        private static string? GetDefaultPrinterName()
        {
            using PrintDocument printDocument = new();
            string printerName = printDocument.PrinterSettings.PrinterName;

            return string.IsNullOrWhiteSpace(printerName) ? null : printerName;
        }
    }
}
