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
      public Guid invoiceHeaderId;
      public Guid invoiceLineID;

      EfMethods efMethods = new EfMethods();

      public UcReturn()
      {
         InitializeComponent();
      }

      private void UcReturn_Load(object sender, EventArgs e)
      {
         ParentForm.FormClosing += new FormClosingEventHandler(ParentForm_FormClosing); // set Parent Form Closing event
      }

      void ParentForm_FormClosing(object sender, FormClosingEventArgs e) // Parent Form Closing event
      {
         if (efMethods.InvoiceHeaderExist(returnInvoiceHeaderId))
            efMethods.DeleteInvoice(returnInvoiceHeaderId);                // delete incomplete invoice
      }

      private void btnEdit_InvoiceHeader_ButtonClick(object sender, ButtonPressedEventArgs e)
      {
         using (FormInvoiceHeaderList formInvoiceHeaderList = new FormInvoiceHeaderList("RS"))
         {
            if (formInvoiceHeaderList.ShowDialog(this) == DialogResult.OK)
            {
               btnEdit_InvoiceHeader.EditValue = formInvoiceHeaderList.trInvoiceHeader.DocumentNumber;
               invoiceHeaderId = formInvoiceHeaderList.trInvoiceHeader.InvoiceHeaderId;

               if (efMethods.InvoiceHeaderExist(returnInvoiceHeaderId))
                  efMethods.DeleteInvoice(returnInvoiceHeaderId);                // delete previous invoice
               returnInvoiceHeaderId = Guid.NewGuid();                             // create next invoice

               gC_InvoiceLine.DataSource = efMethods.SelectInvoiceLines(invoiceHeaderId);

               gC_PaymentLine.DataSource = efMethods.SelectPaymentLinesByInvoice(invoiceHeaderId);
               gC_ReturnInvoiceLine.DataSource = null;
            }
         }
      }

      private void repobtn_ReturnLine_ButtonClick(object sender, ButtonPressedEventArgs e)
      {
         ButtonEdit editor = (ButtonEdit)sender;
         int buttonIndex = editor.Properties.Buttons.IndexOf(e.Button);

         if (buttonIndex == 0)
         {
            Guid invoiceLineID = (Guid)gV_InvoiceLine.GetRowCellValue(gV_InvoiceLine.FocusedRowHandle, "InvoiceLineId");
            int maxReturn = Convert.ToInt32(gV_InvoiceLine.GetRowCellValue(gV_InvoiceLine.FocusedRowHandle, "RemainingQty"));

            if (maxReturn > 0)
            {
               using (FormQty formQty = new FormQty(maxReturn))
               {
                  if (formQty.ShowDialog(this) == DialogResult.OK)
                  {
                     if (!efMethods.InvoiceHeaderExist(returnInvoiceHeaderId)) //if invoiceHeader doesnt exist
                     {
                        string NewDocNum = efMethods.GetNextDocNum("RS", "DocumentNumber", "TrInvoiceHeaders", 6);
                        TrInvoiceHeader TrInvoiceHeader = new TrInvoiceHeader()
                        {
                           InvoiceHeaderId = returnInvoiceHeaderId,
                           DocumentNumber = NewDocNum,
                           ProcessCode = "RS",
                           IsReturn = true
                        };
                        efMethods.InsertInvoiceHeader(TrInvoiceHeader);
                     }

                     if (!efMethods.InvoiceLineExistByRelatedLine(returnInvoiceHeaderId, invoiceLineID))
                     {
                        TrInvoiceLine invoiceLine = efMethods.SelectInvoiceLine(invoiceLineID);

                        TrInvoiceLine returnInvoiceLine = new TrInvoiceLine
                        {
                           InvoiceLineId = Guid.NewGuid(),
                           InvoiceHeaderId = returnInvoiceHeaderId,
                           RelatedLineId = invoiceLineID,
                           ProductCode = invoiceLine.ProductCode,
                           QtyOut = formQty.qty * (-1),
                           Price = invoiceLine.Price,
                           Amount = Convert.ToDecimal(formQty.qty * invoiceLine.Price * (-1)),
                           PosDiscount = formQty.qty * invoiceLine.PosDiscount / invoiceLine.QtyOut * (-1),
                           NetAmount = formQty.qty * invoiceLine.NetAmount / invoiceLine.QtyOut * (-1),
                        };

                        efMethods.InsertInvoiceLine(returnInvoiceLine);
                        gC_ReturnInvoiceLine.DataSource = efMethods.SelectInvoiceLines(returnInvoiceHeaderId);
                     }
                     else
                        efMethods.UpdateInvoiceLineQtyOut(returnInvoiceHeaderId, invoiceLineID, formQty.qty * (-1));

                     gC_InvoiceLine.DataSource = efMethods.SelectInvoiceLines(invoiceHeaderId);
                  }
               }
            }
            else
               XtraMessageBox.Show("Geri qaytarıla bilecek miqdar yoxdur");
         }
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

            using (FormPayment formPayment = new FormPayment(paymentType, sumNetAmount, new TrInvoiceHeader() { }))
            {
               if (formPayment.ShowDialog(this) == DialogResult.OK)
               {
                  returnInvoiceHeaderId = Guid.NewGuid();
                  efMethods.UpdateInvoiceIsCompleted(invoiceHeaderId);

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
