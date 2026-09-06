using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using Foxoft.Models;
using Foxoft.Properties;
using Microsoft.EntityFrameworkCore;
using System.IO;

namespace Foxoft
{
    public partial class FormPaymentMethod : XtraForm
    {
        subContext dbContext;
        EfMethods efMethods = new();
        public DcPaymentMethod dcPaymentMethod = new();

        public FormPaymentMethod()
        {
            InitializeComponent();

            PaymentTypeCodeLookUpEdit.Properties.DataSource = efMethods.SelectEntities<DcPaymentType>();

            AcceptButton = btn_Ok;
            CancelButton = btn_Cancel;
        }

        public FormPaymentMethod(int paymentMethodId)
            : this()
        {
            dcPaymentMethod.PaymentMethodId = paymentMethodId;

            PaymentMethodIdTextEdit.Properties.ReadOnly = true;
            PaymentMethodIdTextEdit.Properties.Appearance.BackColor = Color.LightGray;
        }

        private void FormPaymentMethod_Load(object sender, EventArgs e)
        {
            LoadData();
            LoadLayout();
            dataLayoutControl1.IsValid(out List<string> errorList);
        }

        private void LoadData()
        {
            dbContext = new subContext();

            if (dcPaymentMethod.PaymentMethodId == 0)
                ClearControlsAddNew();
            else
            {
                dbContext.DcPaymentMethods.Where(x => x.PaymentMethodId == dcPaymentMethod.PaymentMethodId).Load();
                dcPaymentMethodsBindingSource.DataSource = dbContext.DcPaymentMethods.Local.ToBindingList();
            }
        }

        private void LoadLayout()
        {
            string fileName = "FormPaymentMethod.xml";
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
            dcPaymentMethod = dcPaymentMethodsBindingSource.AddNew() as DcPaymentMethod;
            dcPaymentMethodsBindingSource.DataSource = dcPaymentMethod;
            PaymentMethodDescTextEdit.Select();
        }

        private void DefaultCashRegCodeButtonEdit_ButtonPressed(object sender, ButtonPressedEventArgs e)
        {
            string currAccCode = ((ButtonEdit)sender).EditValue?.ToString();
            using FormCurrAccList form = new(new byte[] { 1, 2, 3 }, false, currAccCode);
            try
            {
                if (form.ShowDialog(this) == DialogResult.OK)
                    ((ButtonEdit)sender).EditValue = form.dcCurrAcc.CurrAccCode;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void RedirectedCurrAccCodeButtonEdit_ButtonPressed(object sender, ButtonPressedEventArgs e)
        {
            string currAccCode = ((ButtonEdit)sender).EditValue?.ToString();
            using FormCurrAccList form = new(new byte[] { 1, 2, 3 }, false, currAccCode);
            try
            {
                if (form.ShowDialog(this) == DialogResult.OK)
                    ((ButtonEdit)sender).EditValue = form.dcCurrAcc.CurrAccCode;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btn_Ok_Click(object sender, EventArgs e)
        {
            if (dataLayoutControl1.IsValid(out List<string> errorList))
            {
                dcPaymentMethod = dcPaymentMethodsBindingSource.Current as DcPaymentMethod;

                if (!efMethods.EntityExists<DcPaymentMethod>(dcPaymentMethod.PaymentMethodId))
                    efMethods.InsertEntity(dcPaymentMethod);
                else
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
    }
}
