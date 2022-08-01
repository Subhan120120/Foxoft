using DevExpress.Data;
using DevExpress.DataAccess.ConnectionParameters;
using DevExpress.DataAccess.Sql;
using DevExpress.Utils.Extensions;
using DevExpress.Utils.VisualEffects;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraPrinting;
using DevExpress.XtraReports.UI;
using Foxoft.Models;
using Foxoft.Properties;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Foxoft
{
   public partial class FormInvoice : RibbonForm
   {
      string designFolder = @"C:\Users\Administrator\Documents\";
      string designFile = @"InvoiceRS_A5.repx";

      private TrInvoiceHeader trInvoiceHeader;
      public DcProcess dcProcess;
      private byte productTypeCode;
      private byte currAccTypeCode;
      private EfMethods efMethods = new EfMethods();
      private subContext dbContext;
      Guid invoiceHeaderId;

      //public AdornerElement[] Badges { get { return new AdornerElement[] { badge1, badge2 }; } }
      public FormInvoice(string processCode, byte productTypeCode, byte currAccTypeCode)
      {
         InitializeComponent();

         if (processCode == "EX")
            btnEdit_CurrAccCode.Enabled = false;

         this.productTypeCode = productTypeCode;
         this.currAccTypeCode = currAccTypeCode;
         dcProcess = efMethods.SelectProcess(processCode);

         this.Text = dcProcess.ProcessDesc;

         lUE_OfficeCode.Properties.DataSource = efMethods.SelectOffices();
         lUE_StoreCode.Properties.DataSource = efMethods.SelectStores();
         lUE_WarehouseCode.Properties.DataSource = efMethods.SelectWarehouses();
         repoLUE_CurrencyCode.DataSource = efMethods.SelectCurrencies();

         ClearControlsAddNew();
      }

      public FormInvoice(string processCode, byte productTypeCode, byte currAccTypeCode, Guid invoiceHeaderId)
          : this(processCode, productTypeCode, currAccTypeCode)
      {
         trInvoiceHeader = efMethods.SelectInvoiceHeader(invoiceHeaderId);
         LoadInvoice(trInvoiceHeader.InvoiceHeaderId);
      }

      private void FormInvoice_Load(object sender, EventArgs e)
      {
         dataLayoutControl1.isValid(out List<string> errorList);
      }

      private void FormInvoice_Shown(object sender, EventArgs e)
      {
         gC_InvoiceLine.Focus();
      }

      private void ClearControlsAddNew()
      {
         dbContext = new subContext();

         invoiceHeaderId = Guid.NewGuid();

         dbContext.TrInvoiceHeaders.Include(x => x.DcProcess)
                                   .Include(x => x.DcCurrAcc)
                                   .Where(x => x.InvoiceHeaderId == invoiceHeaderId)
                                   .Load();

         trInvoiceHeadersBindingSource.DataSource = dbContext.TrInvoiceHeaders.Local.ToBindingList();

         trInvoiceHeader = trInvoiceHeadersBindingSource.AddNew() as TrInvoiceHeader;


         lbl_InvoicePaidSum.Text = "";
         lbl_CurrAccDesc.Text = trInvoiceHeader.CurrAccDesc;

         dbContext.TrInvoiceLines.Include(x => x.DcProduct)
                                 .Include(x => x.TrInvoiceHeader).ThenInclude(x => x.DcProcess)
                                 .Where(x => x.InvoiceHeaderId == trInvoiceHeader.InvoiceHeaderId)
                                 .LoadAsync()
                                 .ContinueWith(loadTask => trInvoiceLinesBindingSource.DataSource = dbContext.TrInvoiceLines.Local.ToBindingList(), TaskScheduler.FromCurrentSynchronizationContext());

         dataLayoutControl1.isValid(out List<string> errorList);
      }

      private void trInvoiceHeadersBindingSource_AddingNew(object sender, AddingNewEventArgs e)
      {
         TrInvoiceHeader invoiceHeader = new TrInvoiceHeader();
         invoiceHeader.InvoiceHeaderId = invoiceHeaderId;
         string NewDocNum = efMethods.GetNextDocNum(this.dcProcess.ProcessCode, "DocumentNumber", "TrInvoiceHeaders", 6);
         invoiceHeader.DocumentNumber = NewDocNum;
         invoiceHeader.DocumentDate = DateTime.Now;
         invoiceHeader.DocumentTime = TimeSpan.Parse(DateTime.Now.ToString("HH:mm:ss"));
         invoiceHeader.ProcessCode = this.dcProcess.ProcessCode;
         invoiceHeader.OfficeCode = Authorization.OfficeCode;
         invoiceHeader.StoreCode = Authorization.StoreCode;
         invoiceHeader.CreatedUserName = Authorization.CurrAccCode;
         invoiceHeader.WarehouseCode = Settings.Default.WarehouseCode;
         if (dcProcess.ProcessCode == "RS")
         {
            invoiceHeader.CurrAccCode = "111";
            lbl_CurrAccDesc.Text = efMethods.SelectCurrAcc("111").CurrAccDesc;
         }

         e.NewObject = invoiceHeader;
      }

      private void trInvoiceLinesBindingSource_AddingNew(object sender, AddingNewEventArgs e)
      {
         //line.DcProduct = new DcProduct();
         //line.DcProduct.ProductDescription = "Fazil";
         //e.NewObject = line;
      }

      private void trInvoiceHeadersBindingSource_CurrentItemChanged(object sender, EventArgs e)
      {
         trInvoiceHeader = trInvoiceHeadersBindingSource.Current as TrInvoiceHeader;

         //DcCurrAcc dcCurrAcc = efMethods.SelectCurrAcc(trInvoiceHeader.CurrAccCode);
         //if (!object.ReferenceEquals(dcCurrAcc, null))
         //    CurrAccDescTextEdit.Text = dcCurrAcc.CurrAccDesc + " " + dcCurrAcc.FirstName + " " + dcCurrAcc.LastName;

         if (!Object.ReferenceEquals(trInvoiceHeader, null)) // if Isreturn Changed calculate Qty again
         {
            for (int i = 0; i < gV_InvoiceLine.DataRowCount; i++)
            {
               int qtyIn = (int)gV_InvoiceLine.GetRowCellValue(i, CustomExtensions.ProcessDir(trInvoiceHeader.ProcessCode) == "In" ? colQtyIn : colQtyOut);
               int qtyInAbs = Math.Abs(qtyIn);
               gV_InvoiceLine.SetRowCellValue(i, colQty, qtyInAbs);
            }
         }

         if (trInvoiceHeader != null && dbContext != null && dataLayoutControl1.isValid(out List<string> errorList))
         {
            int count = efMethods.SelectInvoiceLines(trInvoiceHeader.InvoiceHeaderId).Count;
            if (count > 0)
               SaveInvoice();
         }

         gV_InvoiceLine.Focus();
      }

      private void btnEdit_DocNum_ButtonPressed(object sender, ButtonPressedEventArgs e)
      {
         SelectDocNum();
      }

      private void btnEdit_DocNum_DoubleClick(object sender, EventArgs e)
      {
         SelectDocNum();
      }

      private void SelectDocNum()
      {
         using (FormInvoiceHeaderList form = new FormInvoiceHeaderList(dcProcess.ProcessCode))
         {
            if (form.ShowDialog(this) == DialogResult.OK)
            {
               trInvoiceHeader = form.trInvoiceHeader;
               LoadInvoice(trInvoiceHeader.InvoiceHeaderId);
            }
         }
      }

      private void LoadInvoice(Guid InvoiceHeaderId)
      {
         dbContext = new subContext();
         dbContext.TrInvoiceHeaders.Include(x => x.DcCurrAcc)
                                   .Include(x => x.DcProcess)
                                   .Where(x => x.InvoiceHeaderId == InvoiceHeaderId).Load();

         LocalView<TrInvoiceHeader> lV_invoiceHeader = dbContext.TrInvoiceHeaders.Local;

         if (!lV_invoiceHeader.Any(x => Object.ReferenceEquals(x.DcCurrAcc, null)))
            lV_invoiceHeader.ForEach(x =>
            {
               x.CurrAccDesc = x.DcCurrAcc.CurrAccDesc + " " + x.DcCurrAcc.FirstName + " " + x.DcCurrAcc.LastName;
               lbl_CurrAccDesc.Text = x.DcCurrAcc.CurrAccDesc + " " + x.DcCurrAcc.FirstName + " " + x.DcCurrAcc.LastName;
            });

         trInvoiceHeadersBindingSource.DataSource = lV_invoiceHeader.ToBindingList();
         trInvoiceHeader = trInvoiceHeadersBindingSource.Current as TrInvoiceHeader;

         dbContext.TrInvoiceLines.Include(o => o.DcProduct)
                                 .Include(x => x.TrInvoiceHeader).ThenInclude(x => x.DcProcess)
                                 .Where(x => x.InvoiceHeaderId == InvoiceHeaderId)
                                 .OrderBy(x => x.CreatedDate)
                                 .LoadAsync()
                                 .ContinueWith(loadTask =>
                                 {
                                    LocalView<TrInvoiceLine> lV_invoiceLine = dbContext.TrInvoiceLines.Local;

                                    lV_invoiceLine.ForEach(x => { x.ProductDesc = x.DcProduct.ProductDesc; });

                                    trInvoiceLinesBindingSource.DataSource = lV_invoiceLine.ToBindingList();

                                    gV_InvoiceLine.BestFitColumns();
                                    gV_InvoiceLine.Focus();

                                 }, TaskScheduler.FromCurrentSynchronizationContext());


         dataLayoutControl1.isValid(out List<string> errorList);
         CalcPaidAmount();
      }

      private void CalcPaidAmount()
      {
         decimal paidSum = efMethods.SelectPaymentLinesSum(trInvoiceHeader.InvoiceHeaderId) * (dcProcess.ProcessDir == 1 ? (-1) : 1);
         lbl_InvoicePaidSum.Text = "Ödənilib: " + Math.Round(paidSum, 2).ToString() + " USD";
      }

      private void btnEdit_CurrAccCode_ButtonClick(object sender, ButtonPressedEventArgs e)
      {
         SelectCurrAcc();
      }

      private void btnEdit_CurrAccCode_DoubleClick(object sender, EventArgs e)
      {
         SelectCurrAcc();
      }

      private void SelectCurrAcc()
      {
         using (FormCurrAccList form = new FormCurrAccList(0))
         {
            if (form.ShowDialog(this) == DialogResult.OK)
            {
               btnEdit_CurrAccCode.EditValue = form.dcCurrAcc.CurrAccCode;
               //trInvoiceHeader.CurrAccCode = form.dcCurrAcc.CurrAccCode;
               //lbl_CurrAccDesc.Text = form.dcCurrAcc.CurrAccDesc + " " + form.dcCurrAcc.FirstName + " " + form.dcCurrAcc.LastName;

            }
         }
      }

      private void gV_InvoiceLine_InitNewRow(object sender, InitNewRowEventArgs e)
      {
         GridView gv = sender as GridView;
         gv.SetRowCellValue(e.RowHandle, col_InvoiceHeaderId, trInvoiceHeader.InvoiceHeaderId);
         gv.SetRowCellValue(e.RowHandle, col_InvoiceLineId, Guid.NewGuid());
         //gv.SetRowCellValue(e.RowHandle, colQty, 1);
         gv.SetRowCellValue(e.RowHandle, colCreatedDate, DateTime.Now);
         gv.SetRowCellValue(e.RowHandle, colCreatedUserName, Authorization.CurrAccCode);
      }

      private void gC_InvoiceLine_KeyDown(object sender, KeyEventArgs e)
      {
         GridControl gC = sender as GridControl;
         GridView gV = gC.MainView as GridView;

         StandartKeys(e);

         if (gV.SelectedRowsCount > 0)
         {
            if (e.KeyCode == Keys.Delete)
            {
               if (MessageBox.Show("Sətir Silinsin?", "Təsdiqlə", MessageBoxButtons.YesNo) != DialogResult.Yes)
                  return;

               gV.DeleteSelectedRows();
            }

            if (e.KeyCode == Keys.C && e.Control)
            {
               string cellValue = gV.GetFocusedValue().ToString();
               Clipboard.SetText(cellValue);
            }

            if (e.KeyCode == Keys.F9)
            {
               object productCode = gV.GetFocusedRowCellValue(col_ProductCode);
               if (productCode != null)
               {
                  DcReport dcReport = efMethods.SelectReport(1005);

                  string qryMaster = "Select * from ( " + dcReport.ReportQuery + ") as master";

                  string filter = " where [Məhsul Kodu] = '" + productCode + "' ";

                  FormReportGrid formGrid = new FormReportGrid(qryMaster + filter, dcReport);
                  formGrid.Show();
               }
            }

            if (e.KeyCode == Keys.F10)
            {
               object productCode = gV.GetFocusedRowCellValue(col_ProductCode);
               if (productCode != null)
               {
                  DcReport dcReport = efMethods.SelectReport(1004);

                  string qryMaster = "Select * from ( " + dcReport.ReportQuery + ") as master";

                  string filter = " where [Məhsul Kodu] = '" + productCode + "' ";

                  FormReportGrid formGrid = new FormReportGrid(qryMaster + filter, dcReport);
                  formGrid.Show();
               }
            }
         }

      }

      private void StandartKeys(KeyEventArgs e)
      {
         if (e.KeyCode == Keys.F1)
         {
            SelectCurrAcc();
         }

         if (e.KeyCode == Keys.F2)
         {
            gV_InvoiceLine.FocusedColumn = col_ProductCode;
            gV_InvoiceLine.ShowEditor();
            if (gV_InvoiceLine.ActiveEditor is ButtonEdit)
               SelectProduct(gV_InvoiceLine.ActiveEditor);

            gV_InvoiceLine.CloseEditor();

            e.Handled = true;   // Stop the character from being entered into the control.
         }
      }

      private void gV_InvoiceLine_CellValueChanging(object sender, CellValueChangedEventArgs e)
      {
         //CalcRowLocNetAmount(e);
      }

      private void gV_InvoiceLine_CellValueChanged(object sender, CellValueChangedEventArgs e)
      {
         //CalcRowLocNetAmount(e);
         GridView view = sender as GridView;

         if (view == null) return;
         if (e.Column != col_ProductCode) return;
      }

      #region CalcRowLocNetAmount

      //private void CalcRowLocNetAmount(CellValueChangedEventArgs e)
      //{
      //    object objQty = gV_InvoiceLine.GetRowCellValue(e.RowHandle, CustomExtensions.ProcessDir(processCode) == "In" ? colQtyIn : colQtyOut);
      //    object objExRate = gV_InvoiceLine.GetFocusedRowCellValue(colExchangeRate);
      //    object objPrice = gV_InvoiceLine.GetRowCellValue(e.RowHandle, col_Price);
      //    object objPriceLoc = gV_InvoiceLine.GetFocusedRowCellValue(colPriceLoc);

      //    decimal Qty = objQty.IsNumeric() ? Convert.ToDecimal(objQty, CultureInfo.InvariantCulture) : 0;
      //    decimal exRate = objExRate.IsNumeric() ? Convert.ToDecimal(objExRate, CultureInfo.InvariantCulture) : 1;
      //    decimal Price = objPrice.IsNumeric() ? Convert.ToDecimal(objPrice, CultureInfo.InvariantCulture) : 0;
      //    decimal PriceLoc = objPriceLoc.IsNumeric() ? Convert.ToDecimal(objPriceLoc, CultureInfo.InvariantCulture) : 0;

      //    if (e.Value != null && e.Column == col_Price)
      //    {
      //        objPrice = e.Value;
      //        Price = objPrice.IsNumeric() ? Convert.ToDecimal(objPrice, CultureInfo.InvariantCulture) : 0;
      //        gV_InvoiceLine.SetRowCellValue(e.RowHandle, colPriceLoc, Math.Round(Price * exRate, 2));
      //        gV_InvoiceLine.SetRowCellValue(e.RowHandle, col_Amount, Math.Round(Qty * Price, 2));
      //        gV_InvoiceLine.SetRowCellValue(e.RowHandle, col_NetAmount, Math.Round(Qty * Price, 2));
      //        gV_InvoiceLine.SetRowCellValue(e.RowHandle, colAmountLoc, Math.Round(Qty * Price * exRate, 2));
      //        gV_InvoiceLine.SetRowCellValue(e.RowHandle, colNetAmountLoc, Math.Round(Qty * Price * exRate, 2));

      //    }
      //    else if (e.Value != null && e.Column == colPriceLoc)
      //    {
      //        objPriceLoc = e.Value;
      //        PriceLoc = objPriceLoc.IsNumeric() ? Convert.ToDecimal(objPriceLoc, CultureInfo.InvariantCulture) : 0;
      //        gV_InvoiceLine.SetRowCellValue(e.RowHandle, col_Price, Math.Round(PriceLoc / exRate, 2));
      //        gV_InvoiceLine.SetRowCellValue(e.RowHandle, col_Amount, Math.Round(Qty * PriceLoc / exRate, 2));
      //        gV_InvoiceLine.SetRowCellValue(e.RowHandle, col_NetAmount, Math.Round(Qty * PriceLoc / exRate, 2));
      //        gV_InvoiceLine.SetRowCellValue(e.RowHandle, colAmountLoc, Math.Round(Qty * PriceLoc, 2));
      //        gV_InvoiceLine.SetRowCellValue(e.RowHandle, colNetAmountLoc, Math.Round(Qty * PriceLoc, 2));
      //    }
      //    else if (e.Value != null && e.Column == (CustomExtensions.ProcessDir(processCode) == "In" ? colQtyIn : colQtyOut))
      //    {
      //        objQty = e.Value;
      //        Qty = objQty.IsNumeric() ? Convert.ToDecimal(objQty, CultureInfo.InvariantCulture) : 0;
      //        gV_InvoiceLine.SetRowCellValue(e.RowHandle, col_Amount, Math.Round(Qty * Price, 2));
      //        gV_InvoiceLine.SetRowCellValue(e.RowHandle, col_NetAmount, Math.Round(Qty * Price, 2));
      //        gV_InvoiceLine.SetRowCellValue(e.RowHandle, colAmountLoc, Math.Round(Qty * PriceLoc, 2));
      //        gV_InvoiceLine.SetRowCellValue(e.RowHandle, colNetAmountLoc, Math.Round(Qty * PriceLoc, 2));
      //    }
      //    else if (e.Value != null && e.Column == colExchangeRate)
      //    {
      //        objExRate = e.Value;
      //        exRate = objExRate.IsNumeric() ? Convert.ToDecimal(objExRate, CultureInfo.InvariantCulture) : 1;
      //        gV_InvoiceLine.SetRowCellValue(e.RowHandle, colPriceLoc, Math.Round(Price * exRate, 2));
      //        gV_InvoiceLine.SetRowCellValue(e.RowHandle, colAmountLoc, Math.Round(Qty * Price * exRate, 2));
      //        gV_InvoiceLine.SetRowCellValue(e.RowHandle, colNetAmountLoc, Math.Round(Qty * Price * exRate, 2));
      //    }
      //} 
      #endregion

      private void gV_InvoiceLine_ValidateRow(object sender, ValidateRowEventArgs e)
      {
      }

      private void gV_InvoiceLine_InvalidRowException(object sender, InvalidRowExceptionEventArgs e)
      {
      }

      private void btnEdit_CurrAccCode_Validating(object sender, CancelEventArgs e)
      {
         object eValue = btnEdit_CurrAccCode.EditValue;

         if (!Object.ReferenceEquals(eValue, null))
         {
            DcCurrAcc curr = efMethods.SelectCurrAcc(eValue.ToString());

            if (Object.ReferenceEquals(curr, null))
            {
               e.Cancel = true;
            }
            else
            { 
               trInvoiceHeader.CurrAccCode = curr.CurrAccCode;
               lbl_CurrAccDesc.Text = curr.CurrAccDesc + " " + curr.FirstName + " " + curr.LastName;
            }
         }
      }

      private void btnEdit_CurrAccCode_InvalidValue(object sender, InvalidValueExceptionEventArgs e)
      {
         e.ErrorText = "Belə bir cari yoxdur";
         e.ExceptionMode = ExceptionMode.DisplayError;
      }

      private void gV_InvoiceLine_ValidatingEditor(object sender, BaseContainerValidateEditorEventArgs e)
      {
         GridView view = sender as GridView;

         if (view.FocusedColumn == colQty)
         {
            if (!trInvoiceHeader.IsReturn && trInvoiceHeader.ProcessCode == "RS")
            {
               object colProductCode = view.GetFocusedRowCellValue(col_ProductCode);
               string productCode = (colProductCode ??= "").ToString();

               if (!String.IsNullOrEmpty(productCode))
               {
                  object colInvoiceLineId = view.GetFocusedRowCellValue(col_InvoiceLineId);
                  Guid invoiceLineId = Guid.Parse((colInvoiceLineId ??= Guid.Empty).ToString());

                  TrInvoiceLine currTrInvoLine = efMethods.SelectInvoiceLine(invoiceLineId);
                  int currentQty = Object.ReferenceEquals(currTrInvoLine, null) ? 0 : currTrInvoLine.Qty;

                  int balance = efMethods.SelectProduct(productCode).Balance + currentQty;
                  int eValue = Convert.ToInt32(e.Value ??= 0);

                  if (eValue > balance)
                  {
                     e.ErrorText = "Stokda miqdar yoxdur";
                     e.Valid = false;
                  }
               }

            }
         }

         if (view.FocusedColumn == col_ProductCode)
         {
            string eValue = (e.Value ??= String.Empty).ToString();

            DcProduct product = efMethods.SelectProduct(eValue);

            if (Object.ReferenceEquals(product, null))
            {
               e.ErrorText = "Belə nir məhsul yoxdur";
               e.Valid = false;
            }
            else
            {
               //ButtonEdit editor = (ButtonEdit)view.ActiveEditor;
               //editor.EditValue = product.ProductCode;

               gV_InvoiceLine.SetFocusedRowCellValue(col_ProductCode, product.ProductCode);
               gV_InvoiceLine.SetFocusedRowCellValue(col_ProductDesc, product.ProductDesc);
               gV_InvoiceLine.SetFocusedRowCellValue(colBalance, product.Balance);
               gV_InvoiceLine.SetFocusedRowCellValue(colLastPurchasePrice, product.LastPurchasePrice);

               decimal priceProduct = dcProcess.ProcessCode == "RS" ? product.RetailPrice : (dcProcess.ProcessCode == "RP" ? product.PurchasePrice : 0);
               decimal priceInvoice = Convert.ToInt32(gV_InvoiceLine.GetFocusedRowCellValue(col_Price));
               if (priceInvoice == 0)
                  gV_InvoiceLine.SetFocusedRowCellValue(col_Price, priceProduct);

               gV_InvoiceLine.UpdateCurrentRow(); // For Model/Entity/trInvoiceLine Included TrInvoiceHeader
            }
         }
      }

      private void gV_InvoiceLine_InvalidValueException(object sender, InvalidValueExceptionEventArgs e)
      {
         e.ExceptionMode = ExceptionMode.DisplayError;
         e.WindowCaption = "Diqqət";
      }

      private void repoBtnEdit_ProductCode_ButtonPressed(object sender, ButtonPressedEventArgs e)
      {
         SelectProduct(sender);
      }

      private void repoBtnEdit_SalesPersonCode_ButtonPressed(object sender, ButtonPressedEventArgs e)
      {
         SelectSalesPerson(sender);
      }

      BaseEdit editorCustom;
      private void gV_InvoiceLine_ShownEditor(object sender, EventArgs e)
      {
         GridView view = sender as GridView;
         editorCustom = view.ActiveEditor;
         editorCustom.DoubleClick += editor_DoubleClick;
      }

      void gV_InvoiceLine_HiddenEditor(object sender, EventArgs e)
      {
         editorCustom.DoubleClick -= editor_DoubleClick;
         editorCustom = null;
      }

      private void gV_InvoiceLine_DoubleClick(object sender, EventArgs e)
      {
         #region DXMouseEventArgs ea
         //DXMouseEventArgs ea = e as DXMouseEventArgs;
         //GridView view = sender as GridView;
         //GridHitInfo info = view.CalcHitInfo(ea.Location);
         //info.Column
         //if (info.InRow || info.InRowCell)
         //{
         //    string colCaption = info.Column == null ? "N/A" : info.Column.GetCaption();
         //    MessageBox.Show(string.Format("DoubleClick on row: {0}, column: {1}.", info.RowHandle, colCaption));
         //} 
         #endregion
      }

      void editor_DoubleClick(object sender, EventArgs e)
      {
         BaseEdit editor = (BaseEdit)sender;
         GridControl grid = editor.Parent as GridControl;
         GridView view = grid.FocusedView as GridView;
         Point pt = grid.PointToClient(Control.MousePosition);
         GridHitInfo info = view.CalcHitInfo(pt);
         if (info.InRow || info.InRowCell)
         {
            if (info.Column == col_ProductCode)
            {
               SelectProduct(sender);
            }
            else if (info.Column == col_SalesPersonCode)
            {
               SelectSalesPerson(sender);
            }
         }
      }

      private void SelectSalesPerson(object sender)
      {
         ButtonEdit editor = (ButtonEdit)sender;
         using (FormCurrAccList form = new FormCurrAccList(0))
         {
            if (form.ShowDialog(this) == DialogResult.OK)
            {
               editor.EditValue = form.dcCurrAcc.CurrAccCode;
            }
         }
      }

      private void SelectProduct(object sender)
      {
         string productCode = "";
         if (gV_InvoiceLine.GetFocusedRowCellValue("ProductCode") != null)
            productCode = gV_InvoiceLine.GetFocusedRowCellValue("ProductCode").ToString();

         ButtonEdit editor = (ButtonEdit)sender;

         using (FormProductList form = new FormProductList(productTypeCode, productCode))
         {
            try
            {
               if (form.ShowDialog(this) == DialogResult.OK)
               {
                  editor.EditValue = form.dcProduct.ProductCode;
                  gV_InvoiceLine.CloseEditor();
                  gV_InvoiceLine.UpdateCurrentRow(); // For Model/Entity/trInvoiceLine Included TrInvoiceHeader

                  gV_InvoiceLine.BestFitColumns();
               }
            }
            catch (Exception ex)
            {
               MessageBox.Show(ex.ToString());
            }
         }
      }

      private void gV_InvoiceLine_RowUpdated(object sender, RowObjectEventArgs e)
      {
         //DataRowView rowView = e.Row as DataRowView;
         //DataRow row = rowView.Row;

         SaveInvoice();
      }

      private void gV_InvoiceLine_RowDeleted(object sender, RowDeletedEventArgs e)
      {
         SaveInvoice();
      }

      private void SaveInvoice()
      {
         efMethods.UpdatePaymentsCurrAccCode(trInvoiceHeader.InvoiceHeaderId, trInvoiceHeader.CurrAccCode);

         try
         {
            dbContext.SaveChanges();
         }
         catch (Exception ex)
         {
            MessageBox.Show($"Daxil Etdiyiniz Məlumatlar Əsaslı Deyil ! \n \n {ex}");
         }

         //if (trInvoiceHeader.ProcessCode == "EX")
         //{
         //   decimal summaryInvoice = (decimal)colNetAmountLoc.SummaryItem.SummaryValue;

         //   if (summaryInvoice != 0)
         //   {
         //      MakePayment(summaryInvoice);
         //   }
         //}

         SaveSession();
      }

      private void FormInvoice_FormClosed(object sender, FormClosedEventArgs e)
      {
         dbContext.Dispose();
      }

      private void bBI_SaveAndNew_ItemClick(object sender, ItemClickEventArgs e)
      {
         if (dataLayoutControl1.isValid(out List<string> errorList))
         {
            decimal summaryInvoice = (decimal)colNetAmountLoc.SummaryItem.SummaryValue;

            if (summaryInvoice != 0)
            {
               SaveInvoice();

               //MakePayment(summaryInvoice);

               GetPrint();

               ClearControlsAddNew();
            }
            else if (XtraMessageBox.Show("Ödəmə 0a bərabərdir! \n Fakturaya qayıtmaq istəyirsiz? ", "Diqqət", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
               ClearControlsAddNew();

         }
         else
         {
            string combinedString = errorList.Aggregate((x, y) => x + "" + y);
            XtraMessageBox.Show(combinedString);
         }
      }

      //private decimal CalcSumInvoice()
      //{
      //    decimal summaryNetAmount = 0;

      //    for (int i = 0; i < gV_InvoiceLine.DataRowCount; i++)
      //    {
      //        decimal netAmount = Convert.ToDecimal(gV_InvoiceLine.GetRowCellValue(i, colNetAmountLoc));
      //        summaryNetAmount += netAmount;
      //    }

      //    return summaryNetAmount;
      //}

      private void SaveSession()
      {
         object warehouseCode = lUE_WarehouseCode.EditValue;
         if (!object.ReferenceEquals(warehouseCode, null))
         {
            Settings.Default.WarehouseCode = lUE_WarehouseCode.EditValue.ToString();
            Settings.Default.Save();
         }
      }

      private void GetPrint()
      {
         //if (Settings.Default.AppSetting.GetPrint == true)
         //{
         ReportClass reportClass = new ReportClass();
         //string designPath = Settings.Default.AppSetting.PrintDesignPath;

         string designPath = designFolder + designFile;

         if (!File.Exists(designPath))
            designPath = reportClass.SelectDesign();
         if (File.Exists(designPath))
         {
            DsMethods dsMethods = new DsMethods();
            SqlDataSource dataSource = new SqlDataSource(new CustomStringConnectionParameters(subConnString));
            dataSource.Name = "Invoice";

            SqlQuery sqlQuerySale = dsMethods.SelectInvoice(trInvoiceHeader.InvoiceHeaderId);
            dataSource.Queries.AddRange(new SqlQuery[] { sqlQuerySale });
            dataSource.Fill();

            XtraReport report = reportClass.CreateReport(dataSource, designPath);

            ReportPrintTool printTool = new ReportPrintTool(report);
            printTool.PrintDialog();

            using (MemoryStream ms = new MemoryStream())
            {
               report.ExportToImage(ms, new ImageExportOptions() { Format = System.Drawing.Imaging.ImageFormat.Png, PageRange = "1", ExportMode = ImageExportMode.SingleFile });
               //Write your code here  
               Image img = Image.FromStream(ms);

               Clipboard.SetImage(img);
            }
         }

      }

      private void MakePayment(decimal summaryInvoice)
      {
         using (FormPayment formPayment = new FormPayment(1, summaryInvoice, trInvoiceHeader))
         {
            if (formPayment.ShowDialog(this) == DialogResult.OK)
            {
               CalcPaidAmount();
               //efMethods.UpdateInvoiceIsCompleted(trInvoiceHeader.InvoiceHeaderId);
            }
         }
      }

      private void gV_InvoiceLine_AsyncCompleted(object sender, EventArgs e)
      {
         MessageBox.Show("Event AsyncCompleted");
      }

      private void gV_InvoiceLine_RowLoaded(object sender, RowEventArgs e)
      {
         //object a = sender;
         //RowEventArgs r = e;
         MessageBox.Show("Event RowLoaded");
      }

      private void bBI_New_ItemClick(object sender, ItemClickEventArgs e)
      {
         ClearControlsAddNew();
      }

      private string subConnString = Settings.Default.subConnString;

      private void bBI_reportDesign_ItemClick(object sender, ItemClickEventArgs e)
      {
         ReportClass reportClass = new ReportClass();
         //string designPath = Settings.Default.AppSetting.PrintDesignPath;
         string designPath = reportClass.SelectDesign();

         if (File.Exists(designPath))
         {
            DsMethods dsMethods = new DsMethods();
            SqlDataSource dataSource = new SqlDataSource(new CustomStringConnectionParameters(subConnString));

            dataSource.Name = "Invoice";

            SqlQuery sqlQuerySale = dsMethods.SelectInvoice(trInvoiceHeader.InvoiceHeaderId);
            dataSource.Queries.AddRange(new SqlQuery[] { sqlQuerySale });
            dataSource.Fill();

            ReportDesignTool printTool = new ReportDesignTool(reportClass.CreateReport(dataSource, designPath));
            printTool.ShowRibbonDesigner();
         }
      }

      private void bBI_reportPreview_ItemClick(object sender, ItemClickEventArgs e)
      {
         ReportClass reportClass = new ReportClass();
         //string designPath = Settings.Default.AppSetting.PrintDesignPath;
         string designPath = designFolder + designFile;

         if (!File.Exists(designPath))
            designPath = reportClass.SelectDesign();

         if (File.Exists(designPath))
         {
            DsMethods dsMethods = new DsMethods();
            SqlDataSource dataSource = new SqlDataSource(new CustomStringConnectionParameters(subConnString));

            dataSource.Name = "Invoice";

            SqlQuery sqlQuerySale = dsMethods.SelectInvoice(trInvoiceHeader.InvoiceHeaderId);
            dataSource.Queries.AddRange(new SqlQuery[] { sqlQuerySale });
            dataSource.Fill();

            ReportPrintTool printTool = new ReportPrintTool(reportClass.CreateReport(dataSource, designPath));
            printTool.ShowRibbonPreview();
         }
      }

      private void bBI_reportPreviewAzn_ItemClick(object sender, ItemClickEventArgs e)
      {
         ReportClass reportClass = new ReportClass();
         //string designPath = Settings.Default.AppSetting.PrintDesignPath;
         string designPath = designFolder + @"InvoiceRS_A5_Azn.repx";

         if (!File.Exists(designPath))
            designPath = reportClass.SelectDesign();

         if (File.Exists(designPath))
         {
            DsMethods dsMethods = new DsMethods();
            SqlDataSource dataSource = new SqlDataSource(new CustomStringConnectionParameters(subConnString));

            dataSource.Name = "Invoice";

            SqlQuery sqlQuerySale = dsMethods.SelectInvoice(trInvoiceHeader.InvoiceHeaderId);
            dataSource.Queries.AddRange(new SqlQuery[] { sqlQuerySale });
            dataSource.Fill();

            ReportPrintTool printTool = new ReportPrintTool(reportClass.CreateReport(dataSource, designPath));
            printTool.ShowRibbonPreview();
         }
      }

      private void bBI_Save_ItemClick(object sender, ItemClickEventArgs e)
      {
         if (dataLayoutControl1.isValid(out List<string> errorList))
         {
            decimal summaryInvoice = (decimal)colNetAmountLoc.SummaryItem.SummaryValue;

            if (summaryInvoice != 0)
            {
               SaveInvoice();
            }
         }
         else
         {
            string combinedString = errorList.Aggregate((x, y) => x + "" + y);
            XtraMessageBox.Show(combinedString);
         }
      }

      private void bBI_Payment_ItemClick(object sender, ItemClickEventArgs e)
      {
         if (dataLayoutControl1.isValid(out List<string> errorList))
         {
            decimal summaryInvoice = (decimal)colNetAmountLoc.SummaryItem.SummaryValue;

            if (summaryInvoice != 0)
            {
               //SaveInvoice();
               MakePayment(summaryInvoice);
            }
         }
         else
         {
            string combinedString = errorList.Aggregate((x, y) => x + "" + y);
            XtraMessageBox.Show(combinedString);
         }
      }

      private void bBI_DeleteInvoice_ItemClick(object sender, ItemClickEventArgs e)
      {
         if (efMethods.InvoiceHeaderExist(trInvoiceHeader.InvoiceHeaderId))
         {
            if (MessageBox.Show("Silmek Isteyirsiz?", "Diqqet", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
               efMethods.DeletePaymentByInvoice(trInvoiceHeader.InvoiceHeaderId);
               efMethods.DeleteInvoice(trInvoiceHeader.InvoiceHeaderId);

               ClearControlsAddNew();
            }
         }
         else
            XtraMessageBox.Show("Silinmeli olan faktura yoxdur");
      }

      private void bBI_DeletePayment_ItemClick(object sender, ItemClickEventArgs e)
      {
         if (MessageBox.Show("Silmek Isteyirsiz?", "Diqqet", MessageBoxButtons.OKCancel) == DialogResult.OK)
         {
            efMethods.DeletePaymentByInvoice(trInvoiceHeader.InvoiceHeaderId);
            CalcPaidAmount();
         }
      }

      private void repoLUE_CurrencyCode_EditValueChanged(object sender, EventArgs e)
      {
         LookUpEdit textEditor = (LookUpEdit)sender;
         float exRate = efMethods.SelectExRate(textEditor.EditValue.ToString());
         gV_InvoiceLine.SetFocusedRowCellValue(colExchangeRate, exRate);

         //CalcRowLocNetAmount(new CellValueChangedEventArgs(gV_InvoiceLine.FocusedRowHandle, colExchangeRate, exRate));
      }

      private void bBI_SaveQuit_ItemClick(object sender, ItemClickEventArgs e)
      {
         if (dataLayoutControl1.isValid(out List<string> errorList))
         {
            decimal summaryInvoice = (decimal)colNetAmountLoc.SummaryItem.SummaryValue;

            if (summaryInvoice != 0)
            {
               SaveInvoice();

               //MakePayment(summaryInvoice);

               GetPrint();

               this.Close();
            }
            else if (XtraMessageBox.Show("Ödəmə 0a bərabərdir! \n Fakturaya qayıtmaq istəyirsiz? ", "Diqqət", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
            {
               this.Close();
            };
         }
         else
         {
            string combinedString = errorList.Aggregate((x, y) => x + "" + y);
            XtraMessageBox.Show(combinedString);
         }
      }

      private void gV_InvoiceLine_RowCellStyle(object sender, RowCellStyleEventArgs e)
      {
         GridView gridView = sender as GridView;
         Color readOnlyForeColor = Color.Gray;
         try
         {
            // Apply the ReadOnly style  
            if (e.RowHandle >= 0 && (!gridView.OptionsBehavior.Editable || !e.Column.OptionsColumn.AllowEdit || e.Column.ReadOnly))
            {
               GridViewInfo viewInfo = gridView.GetViewInfo() as GridViewInfo;
               GridDataRowInfo rowInfo = viewInfo.RowsInfo.GetInfoByHandle(e.RowHandle) as GridDataRowInfo;
               // Check if there are style conditions  
               if (rowInfo == null || (rowInfo != null && rowInfo.ConditionInfo.GetCellAppearance(e.Column) == null))
               {
                  // Check if there are FormatRules that should override the ReadOnly style  
                  bool hasrules = false;
                  foreach (var rule in gridView.FormatRules)
                  {
                     if (rule.IsFit(e.CellValue, gridView.GetDataSourceRowIndex(e.RowHandle)))
                     {
                        hasrules = true;
                        break;
                     }
                  }
                  if (!hasrules)
                     e.Appearance.ForeColor = readOnlyForeColor;
               }
            }
            // This is to fix the selection color when a color is set for the column  
            if (e.Column.AppearanceCell.Options.UseBackColor && gridView.IsCellSelected(e.RowHandle, e.Column))
               e.Appearance.BackColor = gridView.PaintAppearance.SelectedRow.BackColor;
         }
         catch (Exception ex)
         {
            System.Diagnostics.Debug.Print(ex.Message);
         }
      }

      private void btnEdit_CurrAccCode_KeyDown(object sender, KeyEventArgs e)
      {
         //MessageBox.Show("\nKeyCode: " + e.KeyCode +
         //                     "\nKeyData: " + e.KeyData +
         //                     "\nKeyValue: " + e.KeyValue
         //                     );
      }

      private void dataLayoutControls_KeyDown(object sender, KeyEventArgs e)
      {
         StandartKeys(e);
      }

   }
}