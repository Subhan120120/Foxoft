using DevExpress.Utils.Extensions;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
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
    public partial class FormPaymentDetail : RibbonForm
    {
        private TrPaymentHeader trPaymentHeader;
        private EfMethods efMethods = new EfMethods();
        private subContext dbContext;

        public FormPaymentDetail()
        {
            InitializeComponent();
        }

        private void btnEdit_DocNum_ButtonPressed(object sender, ButtonPressedEventArgs e)
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

        private void bBI_DeletePayment_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (MessageBox.Show("Silmek Isteyirsiz?", "Diqqet", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                efMethods.DeletePayment(trPaymentHeader.PaymentHeaderId);
            }
        }
    }
}