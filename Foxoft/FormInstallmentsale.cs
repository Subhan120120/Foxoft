using DevExpress.XtraEditors;
using Foxoft.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Foxoft
{
    public partial class FormInstallmentsale : DevExpress.XtraEditors.XtraForm
    {
        EfMethods efMethods = new();
        public FormInstallmentsale()
        {
            InitializeComponent();

            //gridView1.RowHeight = 30;

            LoadInstallments();
        }

        private void LoadInstallments()
        {
            List<TrInstallmentViewModel> installment = efMethods.SelectInstallmentsVM();

            bindingSourceTrInstallmentsale.DataSource = installment;
        }

        public void RepoBtnEdit_Payment_ButtonPressed(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            TrInstallmentViewModel asd = gridView1.GetRow(gridView1.FocusedRowHandle) as TrInstallmentViewModel;

            TrInvoiceHeader trInvoiceHeader = efMethods.SelectInvoiceHeader(asd.InvoiceHeaderId);

            MakePayment(asd.MonthlyPayment, trInvoiceHeader, false);
        }

        private void MakePayment(decimal summaryInvoice, TrInvoiceHeader trInvoiceHeader, bool autoPayment)
        {
            using FormPayment formPayment = new(1, summaryInvoice, trInvoiceHeader, autoPayment);
            bool currAccHasClaims = efMethods.CurrAccHasClaims(Authorization.CurrAccCode, formPayment.Name);
            if (!currAccHasClaims)
            {
                MessageBox.Show("Yetkiniz yoxdur! ");
                return;
            }
            else
            {
                if (formPayment.ShowDialog(this) == DialogResult.OK)
                {
                    LoadInstallments();
                }
            }
        }
    }
}