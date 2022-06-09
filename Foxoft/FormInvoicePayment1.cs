using DevExpress.Utils.Extensions;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using Foxoft.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Foxoft
{
    public partial class FormInvoicePayment1 : XtraForm
    {

        private TrPaymentHeader trPaymentHeader;
        private subContext dbContext;

        public FormInvoicePayment1()
        {
            InitializeComponent();
        }

        private void btnEdit_DocNum_ButtonPressed(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            SelectDocNum();
        }

        private void SelectDocNum()
        {
            using (FormPaymentHeaderList form = new FormPaymentHeaderList())
            {
                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    trPaymentHeader = form.trPaymentHeader;

                    dbContext = new subContext();

                    dbContext.TrPaymentHeaders.Where(x => x.PaymentHeaderId == form.trPaymentHeader.PaymentHeaderId).Load();
                    LocalView<TrPaymentHeader> lV_paymentHeader = dbContext.TrPaymentHeaders.Local;
                    trPaymentHeadersBindingSource.DataSource = lV_paymentHeader.ToBindingList();

                    dbContext.TrPaymentLines.Where(x => x.PaymentHeaderId == form.trPaymentHeader.PaymentHeaderId)
                                            .OrderBy(x => x.CreatedDate)
                                            .LoadAsync()
                                            .ContinueWith(loadTask =>
                                            {
                                                LocalView<TrPaymentLine> lV_paymentLine = dbContext.TrPaymentLines.Local;
                                                trPaymentLinesBindingSource.DataSource = lV_paymentLine.ToBindingList();

                                            }, TaskScheduler.FromCurrentSynchronizationContext());

                    //dataLayoutControl1.isValid(out List<string> errorList);
                }
            }
        }
    }
}