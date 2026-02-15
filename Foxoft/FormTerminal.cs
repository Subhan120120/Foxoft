using DevExpress.XtraDataLayout;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.DXErrorProvider;
using Foxoft.Models;
using Foxoft.Properties;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.IO;

namespace Foxoft
{
    public partial class FormTerminal : XtraForm
    {
        subContext dbContext;
        EfMethods efMethods = new EfMethods();

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
            LoadLookups();
            LoadTerminal();
            LoadLayout();

            dataLayoutControl1.IsValid(out List<string> errorList);
        }

        private void LoadLookups()
        {
            StoreCodeLookUpEdit.Properties.DataSource = efMethods.SelectStores();
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

        private void ClearControlsAddNew()
        {
            dcTerminal = dcTerminalsBindingSource.AddNew() as DcTerminal;

            // Default-lar
            dcTerminal.IsDisabled = false;
            dcTerminal.TouchUIMode = false;

            if (dcTerminal.RowGuid == null)
                dcTerminal.RowGuid = Guid.NewGuid();

            dcTerminalsBindingSource.DataSource = dcTerminal;
            TerminalDescTextEdit.Select();
        }

        private void dataLayoutControl1_FieldRetrieving(object sender, FieldRetrievingEventArgs e)
        {
            // BaseEntity sahələri layihəyə görə fərqli ola bilər – ehtiyac olduqda burada gizlət.
            if (e.FieldName == "ModifiedDate" || e.FieldName == "CreatedDate" ||
                e.FieldName == "CreatedUserName" || e.FieldName == "ModifiedUserName")
            {
                e.Visible = false;
                e.Handled = true;
            }
        }

        private void btn_Ok_Click(object sender, EventArgs e)
        {
            if (dataLayoutControl1.IsValid(out List<string> errorList))
            {
                dcTerminal = dcTerminalsBindingSource.Current as DcTerminal;

                if (dcTerminal.TerminalId <= 0)
                    dbContext.DcTerminals.Add(dcTerminal);

                dbContext.SaveChanges();

                DialogResult = DialogResult.OK;
            }
            else
            {
                string combined = errorList.Aggregate((x, y) => x + "" + y);
                XtraMessageBox.Show(combined);
            }
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void CashRegisterCodeButtonEdit_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            ButtonEdit editor = (ButtonEdit)sender;
            string storeCode = StoreCodeLookUpEdit.EditValue?.ToString();

            using (FormCashRegisterList form = new(editor.EditValue?.ToString(), storeCode))
            {
                if (form.ShowDialog(this) == DialogResult.OK)
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

            string value = editor.Text?.Trim();

            if (string.IsNullOrEmpty(value))
                return;

            DcCurrAcc curr = efMethods.SelectCashRegById(value);

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
            CashRegisterCodeButtonEdit.EditValue = null;
        }
    }
}
