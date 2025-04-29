using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using Microsoft.EntityFrameworkCore;
using Foxoft.Models;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Foxoft
{
    public partial class UcExpense : XtraUserControl
    {
        subContext dbContext;

        EfMethods efMethods = new EfMethods();
        TrInvoiceHeader trInvoiceHeader;

        public UcExpense()
        {
            InitializeComponent();
        }

        private void UcExpense_Load(object sender, EventArgs e)
        {
            ClearControlsAddNew();
        }

        private void ClearControlsAddNew()
        {
            dbContext = new subContext();

            trInvoiceHeader = trInvoiceHeadersBindingSource.AddNew() as TrInvoiceHeader;

            string NewDocNum = efMethods.GetNextDocNum(true, "EX", "DocumentNumber", "TrInvoiceHeaders", 6);
            trInvoiceHeader.InvoiceHeaderId = Guid.NewGuid();
            trInvoiceHeader.DocumentNumber = NewDocNum;
            trInvoiceHeader.DocumentDate = DateTime.Now;
            trInvoiceHeader.DocumentTime = TimeSpan.Parse(DateTime.Now.ToString("HH:mm:ss"));
            trInvoiceHeader.ProcessCode = "EX";

            dbContext.TrInvoiceLines.Include(o => o.DcProduct).ThenInclude(f => f.TrProductFeatures)
                                    .Include(x => x.TrInvoiceHeader).ThenInclude(x => x.DcProcess)
                                    .Where(x => x.InvoiceHeaderId == trInvoiceHeader.InvoiceHeaderId)
                                    .OrderBy(x => x.CreatedDate)
                                    .LoadAsync()
                                    .ContinueWith(loadTask =>
                                    {
                                        trInvoiceLinesBindingSource.DataSource = dbContext.TrInvoiceLines.Local.ToBindingList();
                                        gV_InvoiceLine.Focus();

                                    }, TaskScheduler.FromCurrentSynchronizationContext());
        }

        private void gV_InvoiceLine_InitNewRow(object sender, InitNewRowEventArgs e)
        {
            gV_InvoiceLine.SetRowCellValue(e.RowHandle, "InvoiceHeaderId", trInvoiceHeader.InvoiceHeaderId);
            gV_InvoiceLine.SetRowCellValue(e.RowHandle, "InvoiceLineId", Guid.NewGuid());
        }

        private void btnEdit_DocNum_ButtonPressed(object sender, ButtonPressedEventArgs e)
        {
            using (FormInvoiceHeaderList form = new("EX", Guid.Empty))
            {
                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    trInvoiceHeader.InvoiceHeaderId = form.trInvoiceHeader.InvoiceHeaderId;

                    dbContext = new subContext();

                    dbContext.TrInvoiceHeaders.Where(x => x.InvoiceHeaderId == form.trInvoiceHeader.InvoiceHeaderId).Load();
                    trInvoiceHeadersBindingSource.DataSource = dbContext.TrInvoiceHeaders.Local.ToBindingList();

                    dbContext.TrInvoiceLines.Where(x => x.InvoiceHeaderId == form.trInvoiceHeader.InvoiceHeaderId)
                                            .LoadAsync()
                                            .ContinueWith(loadTask => trInvoiceLinesBindingSource.DataSource = dbContext.TrInvoiceLines.Local.ToBindingList(), TaskScheduler.FromCurrentSynchronizationContext());
                }
            }
        }

        private void btnEdit_CurrAccCode_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            using (FormCurrAccList form = new FormCurrAccList(new byte[] { 2 }))
            {
                if (form.ShowDialog(this) == DialogResult.OK)
                    btnEdit_CurrAccCode.EditValue = form.dcCurrAcc.CurrAccCode;
            }
        }

        private void gV_InvoiceLine_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (MessageBox.Show("Sətir Silinsin?", "Təsdiqlə", MessageBoxButtons.YesNo) != DialogResult.Yes)
                    return;
                GridView gV = sender as GridView;
                gV.DeleteRow(gV.FocusedRowHandle);
            }
        }

        private void gV_InvoiceLine_CellValueChanging(object sender, CellValueChangedEventArgs e)
        {
        }

        private void repoBtnEdit_ProductCode_ButtonPressed(object sender, ButtonPressedEventArgs e)
        {
            ButtonEdit editor = (ButtonEdit)sender;
            int buttonIndex = editor.Properties.Buttons.IndexOf(e.Button);
            if (buttonIndex == 0)
            {
                using (FormProductList form = new(new byte[] { 2 }, false))
                {
                    if (form.ShowDialog(this) == DialogResult.OK)
                    {
                        editor.EditValue = form.dcProduct.ProductCode;
                    }
                }
            }
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            //TrInvoiceHeader trInvoiceHeader = trInvoiceHeadersBindingSource.Current as TrInvoiceHeader;
            if (!efMethods.EntityExists<TrInvoiceHeader>(trInvoiceHeader.InvoiceHeaderId))
                dbContext.TrInvoiceHeaders.Add(trInvoiceHeader);
            dbContext.SaveChanges();
            efMethods.UpdateInvoiceIsCompleted(trInvoiceHeader.InvoiceHeaderId);


            ClearControlsAddNew();
        }

    }
}
