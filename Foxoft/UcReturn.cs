using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Views.Grid;
using Microsoft.EntityFrameworkCore;
using Foxoft.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Foxoft
{
   public partial class UcReturn : XtraForm
   {
      public Guid returnInvoiceHeaderId;
      public TrInvoiceHeader trInvoiceHeader;
      public Guid invoiceLineID;

      EfMethods efMethods = new EfMethods();

      public UcReturn()
      {
         InitializeComponent();
      }

      private void UcReturn_Load(object sender, EventArgs e)
      {
         //ParentForm.FormClosing += new FormClosingEventHandler(ParentForm_FormClosing); // set Parent Form Closing event
      }

      void ParentForm_FormClosing(object sender, FormClosingEventArgs e) // Parent Form Closing event
      {
         //if (efMethods.InvoiceHeaderExist(returnInvoiceHeaderId))
         //   efMethods.DeleteInvoice(returnInvoiceHeaderId); 
      }

      private void btnEdit_InvoiceHeader_ButtonClick(object sender, ButtonPressedEventArgs e)
      {
         SelectDocNum();
      }

      private void SelectDocNum()
      {
         using (FormInvoiceLineList form = new("RS"))
         {
            if (form.ShowDialog(this) == DialogResult.OK)
            {
               Guid invoiceHeaderId = form.trInvoiceLine.InvoiceHeaderId;

               trInvoiceHeader = efMethods.SelectInvoiceHeader(invoiceHeaderId);

               btnEdit_InvoiceHeader.EditValue = trInvoiceHeader.DocumentNumber;

               if (efMethods.InvoiceHeaderExist(returnInvoiceHeaderId))
                  efMethods.DeleteInvoice(returnInvoiceHeaderId);                // delete previous invoice
               returnInvoiceHeaderId = Guid.NewGuid();                             // create next invoice

               LoadInvoice(trInvoiceHeader.InvoiceHeaderId);
            }
         }
      }

      private void LoadInvoice(Guid invoiceHeaderId)
      {
         gC_InvoiceLine.DataSource = efMethods.SelectInvoiceLines(invoiceHeaderId);

         gC_PaymentLine.DataSource = efMethods.SelectPaymentLinesByInvoice(invoiceHeaderId);
         gC_ReturnInvoiceLine.DataSource = null;

         CalcPaidAmount();
      }
      private void CalcPaidAmount()
      {
         //decimal paidSum = efMethods.SelectPaymentLinesSum(trInvoiceHeader.InvoiceHeaderId) * (dcProcess.ProcessDir == 1 ? (-1) : 1);
         //lbl_InvoicePaidSum.Text = "Ödənilib: " + Math.Round(paidSum, 2).ToString() + " USD";
      }

      private void repobtn_ReturnLine_ButtonClick(object sender, ButtonPressedEventArgs e)
      {
         //ButtonEdit editor = (ButtonEdit)sender;
         //int buttonIndex = editor.Properties.Buttons.IndexOf(e.Button);
         //if (buttonIndex == 0)
         //{

         Guid invoiceLineID = (Guid)gV_InvoiceLine.GetFocusedRowCellValue(col_InvoiceLineId);
         int maxReturn = Convert.ToInt32(gV_InvoiceLine.GetFocusedRowCellValue(col_RemainingQty));

         if (maxReturn > 0)
         {
            using (FormQty formQty = new(maxReturn))
            {
               if (formQty.ShowDialog(this) == DialogResult.OK)
               {
                  if (!efMethods.InvoiceHeaderExist(returnInvoiceHeaderId)) //if invoiceHeader doesnt exist
                  {
                     string NewDocNum = efMethods.GetNextDocNum("RS", "DocumentNumber", "TrInvoiceHeaders", 6);

                     TrInvoiceHeader returnInvoHead = new();

                     returnInvoHead.InvoiceHeaderId = returnInvoiceHeaderId;
                     returnInvoHead.DocumentNumber = NewDocNum;
                     returnInvoHead.ProcessCode = trInvoiceHeader.ProcessCode;
                     returnInvoHead.IsReturn = true;
                     returnInvoHead.CurrAccCode = trInvoiceHeader.CurrAccCode;

                     returnInvoHead.OfficeCode = Authorization.OfficeCode;
                     returnInvoHead.StoreCode = Authorization.StoreCode;
                     returnInvoHead.CreatedUserName = Authorization.CurrAccCode;
                     returnInvoHead.WarehouseCode = efMethods.SelectWarehouseByStore(Authorization.StoreCode);


                     efMethods.InsertInvoiceHeader(returnInvoHead);
                  }

                  if (!efMethods.InvoiceLineExistByRelatedLine(returnInvoiceHeaderId, invoiceLineID))
                  {
                     TrInvoiceLine invoiceLine = efMethods.SelectInvoiceLine(invoiceLineID);

                     TrInvoiceLine returnInvoiceLine = new();

                     returnInvoiceLine.InvoiceLineId = Guid.NewGuid();
                     returnInvoiceLine.InvoiceHeaderId = returnInvoiceHeaderId;
                     returnInvoiceLine.RelatedLineId = invoiceLineID;
                     returnInvoiceLine.ProductCode = invoiceLine.ProductCode;
                     returnInvoiceLine.QtyOut = formQty.qty * (-1);
                     returnInvoiceLine.Price = invoiceLine.Price;
                     returnInvoiceLine.Amount = Convert.ToDecimal(formQty.qty * invoiceLine.Price * (-1));
                     returnInvoiceLine.PosDiscount = formQty.qty * invoiceLine.PosDiscount / invoiceLine.QtyOut * (-1);
                     returnInvoiceLine.NetAmount = formQty.qty * invoiceLine.NetAmount / invoiceLine.QtyOut * (-1);


                     efMethods.InsertInvoiceLine(returnInvoiceLine);
                     gC_ReturnInvoiceLine.DataSource = efMethods.SelectInvoiceLines(returnInvoiceHeaderId);
                  }
                  else
                     efMethods.UpdateInvoiceLineQtyOut(returnInvoiceHeaderId, invoiceLineID, formQty.qty * (-1));

                  gC_InvoiceLine.DataSource = efMethods.SelectInvoiceLines(trInvoiceHeader.InvoiceHeaderId);
               }
            }
         }
         else
            XtraMessageBox.Show("Geri qaytarıla bilecek miqdar yoxdur");

      }

      private void btn_Payment_Click(object sender, EventArgs e)
      {
         decimal sumNetAmount = efMethods.SelectInvoiceNetAmount(returnInvoiceHeaderId);

         if (sumNetAmount != 0)
         {
            byte paymentType = 0;

            SimpleButton simpleButton = sender as SimpleButton;
            switch (simpleButton.Name)
            {
               case "simpleButtonCash":
                  paymentType = 1;
                  break;
               case "simpleButtonCashless":
                  paymentType = 2;
                  break;
               case "simpleButtonCustomerBonus":
                  paymentType = 3;
                  break;
               default:
                  break;
            }

            using (FormPayment formPayment = new(paymentType, sumNetAmount, new TrInvoiceHeader() { }))
            {
               if (formPayment.ShowDialog(this) == DialogResult.OK)
               {
                  returnInvoiceHeaderId = Guid.NewGuid();
                  efMethods.UpdateInvoiceIsCompleted(trInvoiceHeader.InvoiceHeaderId);

                  gC_InvoiceLine.DataSource = null;
                  gC_PaymentLine.DataSource = null;
                  gC_ReturnInvoiceLine.DataSource = null;
                  btnEdit_InvoiceHeader.EditValue = null;
               }
            }
         }
         else XtraMessageBox.Show("Ödəmə 0a bərabərdir");
      }

      private void gV_ReturnInvoiceLine_CalcPreviewText(object sender, CalcPreviewTextEventArgs e)
      {
         GridView view = sender as GridView;
         if (view == null) return;
         //string Barcode = view.GetRowCellDisplayText(e.RowHandle, view.Columns["Barcode"]);
         decimal PosDiscount = Convert.ToDecimal(view.GetRowCellDisplayText(e.RowHandle, view.Columns["PosDiscount"]));
         decimal Amount = Convert.ToDecimal(view.GetRowCellDisplayText(e.RowHandle, view.Columns["Amount"]));
         decimal NetAmount = Convert.ToDecimal(view.GetRowCellDisplayText(e.RowHandle, view.Columns["NetAmount"]));
         string strVatRate = view.GetRowCellDisplayText(e.RowHandle, view.Columns["VatRate"]);
         string SalesPersonCode = view.GetRowCellDisplayText(e.RowHandle, view.Columns["SalesPersonCode"]);
         float VatRate = float.Parse(strVatRate);

         e.PreviewText = CustomExtensions.GetPreviewText(PosDiscount, Amount, NetAmount, VatRate, String.Empty, SalesPersonCode);
      }

   }
}
