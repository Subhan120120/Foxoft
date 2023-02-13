using DevExpress.Data;
using DevExpress.DataAccess.ConnectionParameters;
using DevExpress.DataAccess.Sql;
using DevExpress.Utils.Extensions;
using DevExpress.Utils.Menu;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Menu;
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
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

//using Twilio;
//using Twilio.Rest.Api.V2010.Account;
//using Twilio.Types;

namespace Foxoft
{
   public partial class FormInvoice : RibbonForm
   {
      readonly string designFolder;
      //string pathMyDocuments = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
      string reportFileNameInvoice = @"InvoiceRS_A4.repx";
      string reportFileNameInvoiceWare = @"InvoiceRS_depo_A5.repx";

      private TrInvoiceHeader trInvoiceHeader;
      public DcProcess dcProcess;
      private byte[] productTypeArr;
      private EfMethods efMethods = new();
      private subContext dbContext;
      Guid invoiceHeaderId;

      //public AdornerElement[] Badges { get { return new AdornerElement[] { badge1, badge2 }; } }
      public FormInvoice(string processCode, byte[] productTypeArr, byte currAccTypeCode)
      {
         InitializeComponent();

         dcProcess = efMethods.SelectProcess(processCode);

         LoadLayout();

         SettingStore settingStore = efMethods.SelectSettingStore(Authorization.StoreCode);

         if (CustomExtensions.DirectoryExist(settingStore.DesignFileFolder))
            designFolder = settingStore.DesignFileFolder;

         this.productTypeArr = productTypeArr;
         this.Text = dcProcess.ProcessDesc;

         lUE_StoreCode.Properties.DataSource = efMethods.SelectStores();
         lUE_WarehouseCode.Properties.DataSource = efMethods.SelectWarehouses();
         lUE_ToWarehouseCode.Properties.DataSource = efMethods.SelectWarehouses();
         repoLUE_CurrencyCode.DataSource = efMethods.SelectCurrencies();

         ClearControlsAddNew();
      }

      public FormInvoice(string processCode, byte[] productTypeArr, byte currAccTypeCode, Guid invoiceHeaderId)
          : this(processCode, productTypeArr, currAccTypeCode)
      {
         trInvoiceHeader = efMethods.SelectInvoiceHeader(invoiceHeaderId);
         LoadInvoice(trInvoiceHeader.InvoiceHeaderId);
      }

      private void FormInvoice_Load(object sender, EventArgs e)
      {
         dataLayoutControl1.IsValid(out List<string> errorList);
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

         //lbl_InvoicePaidSum.Text = "Ödənilib: 0.00 " + Settings.Default.AppSetting.LocalCurrencyCode;
         CalcPaidAmount();

         lbl_CurrAccDesc.Text = trInvoiceHeader.CurrAccDesc;

         dbContext.TrInvoiceLines.Include(x => x.DcProduct)
                                 .Include(x => x.TrInvoiceHeader).ThenInclude(x => x.DcProcess)
                                 .Where(x => x.InvoiceHeaderId == trInvoiceHeader.InvoiceHeaderId)
                                 .LoadAsync()
                                 .ContinueWith(loadTask => trInvoiceLinesBindingSource.DataSource = dbContext.TrInvoiceLines.Local.ToBindingList(), TaskScheduler.FromCurrentSynchronizationContext());

         dataLayoutControl1.IsValid(out List<string> errorList);

         ShowPrintCount();

         CheckEdit_IsReturn.Enabled = false;
      }

      private void trInvoiceHeadersBindingSource_AddingNew(object sender, AddingNewEventArgs e)
      {
         TrInvoiceHeader invoiceHeader = new();
         invoiceHeader.InvoiceHeaderId = invoiceHeaderId;
         string NewDocNum = efMethods.GetNextDocNum(true, dcProcess.ProcessCode, "DocumentNumber", "TrInvoiceHeaders", 6);
         invoiceHeader.DocumentNumber = NewDocNum;
         invoiceHeader.DocumentDate = DateTime.Now;
         invoiceHeader.DocumentTime = TimeSpan.Parse(DateTime.Now.ToString("HH:mm:ss"));
         invoiceHeader.ProcessCode = dcProcess.ProcessCode;
         invoiceHeader.OfficeCode = Authorization.OfficeCode;
         invoiceHeader.StoreCode = Authorization.StoreCode;
         invoiceHeader.CreatedUserName = Authorization.CurrAccCode;
         invoiceHeader.WarehouseCode = efMethods.SelectWarehouseByStore(Authorization.StoreCode);

         if (dcProcess.ProcessCode == "RS")
         {
            string defaultCustomer = efMethods.SelectCustomerByStore(Authorization.StoreCode);
            invoiceHeader.CurrAccCode = defaultCustomer;

            if (efMethods.SelectCurrAcc(defaultCustomer) is not null)
               invoiceHeader.CurrAccDesc = efMethods.SelectCurrAcc(defaultCustomer).CurrAccDesc;
         }

         e.NewObject = invoiceHeader;
      }

      private void trInvoiceHeadersBindingSource_CurrentItemChanged(object sender, EventArgs e)
      {
         trInvoiceHeader = trInvoiceHeadersBindingSource.Current as TrInvoiceHeader;

         if (trInvoiceHeader is not null) // if Isreturn Changed calculate Qty again
         {
            for (int i = 0; i < gV_InvoiceLine.DataRowCount; i++)
            {
               int qtyIn = (int)gV_InvoiceLine.GetRowCellValue(i, CustomExtensions.ProcessDir(trInvoiceHeader.ProcessCode) == "In" ? colQtyIn : colQtyOut);
               int qtyInAbs = Math.Abs(qtyIn);
               gV_InvoiceLine.SetRowCellValue(i, colQty, qtyInAbs);
            }
         }

         if (trInvoiceHeader != null && dbContext != null && dataLayoutControl1.IsValid(out List<string> errorList))
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
         using FormInvoiceHeaderList form = new(dcProcess.ProcessCode);
         if (form.ShowDialog(this) == DialogResult.OK)
         {
            trInvoiceHeader = form.trInvoiceHeader;
            LoadInvoice(trInvoiceHeader.InvoiceHeaderId);
         }
      }

      private void LoadInvoice(Guid InvoiceHeaderId)
      {
         dbContext = new subContext();

         dbContext.TrInvoiceHeaders.Include(x => x.DcCurrAcc)
                                   .Include(x => x.DcProcess)
                                   .Where(x => x.InvoiceHeaderId == InvoiceHeaderId)
                                   .Load();

         LocalView<TrInvoiceHeader> lV_invoiceHeader = dbContext.TrInvoiceHeaders.Local;

         if (!lV_invoiceHeader.Any(x => x.DcCurrAcc is null))
            lV_invoiceHeader.ForEach(x =>
            {
               x.CurrAccDesc = x.DcCurrAcc.CurrAccDesc + " " + x.DcCurrAcc.FirstName + " " + x.DcCurrAcc.LastName;
               lbl_CurrAccDesc.Text = x.DcCurrAcc.CurrAccDesc + " " + x.DcCurrAcc.FirstName + " " + x.DcCurrAcc.LastName;
            });

         trInvoiceHeadersBindingSource.DataSource = lV_invoiceHeader.ToBindingList();
         trInvoiceHeader = trInvoiceHeadersBindingSource.Current as TrInvoiceHeader;

         dcProcess = efMethods.SelectProcess(trInvoiceHeader.ProcessCode);

         dbContext.TrInvoiceLines.Include(o => o.DcProduct)
                                 .Include(x => x.TrInvoiceHeader).ThenInclude(x => x.DcProcess)
                                 .Where(x => x.InvoiceHeaderId == InvoiceHeaderId)
                                 .OrderBy(x => x.CreatedDate)
                                 .LoadAsync()
                                 .ContinueWith(loadTask =>
                                 {
                                    LocalView<TrInvoiceLine> lV_invoiceLine = dbContext.TrInvoiceLines.Local;

                                    lV_invoiceLine.ForEach(x =>
                                    {
                                       x.ProductDesc = x.DcProduct.ProductDesc;
                                    });

                                    trInvoiceLinesBindingSource.DataSource = lV_invoiceLine.ToBindingList();

                                    gV_InvoiceLine.BestFitColumns();
                                    gV_InvoiceLine.Focus();

                                 }, TaskScheduler.FromCurrentSynchronizationContext());


         dataLayoutControl1.IsValid(out List<string> errorList);
         CalcPaidAmount();
         ShowPrintCount();

         CheckEdit_IsReturn.Enabled = false;
      }

      private void CalcPaidAmount()
      {
         decimal paidSum = efMethods.SelectPaymentLinesSum(trInvoiceHeader.InvoiceHeaderId) * (dcProcess.ProcessDir == 1 ? (-1) : 1);
         lbl_InvoicePaidSum.Text = "Ödənilib: " + Math.Round(paidSum, 2).ToString() + " " + Settings.Default.AppSetting.LocalCurrencyCode;
      }

      private void ShowPrintCount()
      {
         int printCount = efMethods.SelectInvoicePrinCount(trInvoiceHeader.InvoiceHeaderId);

         lbl_PrintCount.Text = "Print Edilib: " + printCount + " nüsxə";
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
         if (btnEdit_CurrAccCode.Enabled)
         {
            FormCurrAccList form = new(0, trInvoiceHeader.CurrAccCode);

            if (trInvoiceHeader.ProcessCode == "IT")
               form = new FormCurrAccList(4, trInvoiceHeader.CurrAccCode);

            if (form.ShowDialog(this) == DialogResult.OK)
            {
               if (form.dcCurrAcc.CreditLimit > Math.Abs(form.dcCurrAcc.Balance) || form.dcCurrAcc.CreditLimit == 0)
               {
                  btnEdit_CurrAccCode.EditValue = form.dcCurrAcc.CurrAccCode;
                  FillCurrAccCode(form.dcCurrAcc);
               }
               else
                  XtraMessageBox.Show("Müştəri Kredit Limitin Aşır", "Diqqət");
            }
         }
      }

      private void gV_InvoiceLine_InitNewRow(object sender, InitNewRowEventArgs e)
      {
         GridView gv = sender as GridView;
         gv.SetRowCellValue(e.RowHandle, col_InvoiceHeaderId, trInvoiceHeader.InvoiceHeaderId);
         gv.SetRowCellValue(e.RowHandle, col_InvoiceLineId, Guid.NewGuid());
         gv.SetRowCellValue(e.RowHandle, colCreatedDate, DateTime.Now);
         gv.SetRowCellValue(e.RowHandle, colCreatedUserName, Authorization.CurrAccCode);

         string currencyCode = Settings.Default.AppSetting.LocalCurrencyCode;
         if (!string.IsNullOrEmpty(dcProcess.CustomCurrencyCode))
            currencyCode = dcProcess.CustomCurrencyCode;
         DcCurrency currency = efMethods.SelectCurrency(currencyCode);
         if (currency is not null)
         {
            gv.SetRowCellValue(e.RowHandle, colCurrencyCode, currency.CurrencyCode);
            gv.SetRowCellValue(e.RowHandle, colExchangeRate, currency.ExchangeRate);
         }
         //GridColumn qty = CustomExtensions.ProcessDir(trInvoiceHeader.ProcessCode) == "In" ? colQtyIn : colQtyOut;
         //gv.SetRowCellValue(e.RowHandle, qty, 1);
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
               e.Handled = true;
            }

            if (e.KeyCode == Keys.F9)
            {
               object productCode = gV.GetFocusedRowCellValue(col_ProductCode);
               if (productCode != null)
               {
                  DcReport dcReport = efMethods.SelectReport(1005);

                  string qryMaster = "Select * from ( " + dcReport.ReportQuery + ") as master";
                  string filter = " where [ProductCode] = '" + productCode + "' ";
                  string activeFilterStr = "[StoreCode] = \'" + Authorization.StoreCode + "\'";
                  FormReportGrid formGrid = new(qryMaster + filter, dcReport, activeFilterStr);
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
                  string filter = " where [ProductCode] = '" + productCode + "' ";
                  string activeFilterStr = "[StoreCode] = \'" + Authorization.StoreCode + "\'";
                  FormReportGrid formGrid = new(qryMaster + filter, dcReport, activeFilterStr);
                  formGrid.Show();
               }
            }

            if (e.KeyCode == Keys.F5)
            {
               object productCode = gV.GetFocusedRowCellValue(col_ProductCode);
               if (productCode != null)
               {
                  DcReport dcReport = efMethods.SelectReport(1004);

                  string qryMaster = "Select * from ( " + dcReport.ReportQuery + ") as master";
                  string filter = " where [ProductCode] = '" + productCode + "' and [CurrAccCode] = '" + trInvoiceHeader.CurrAccCode + "'";
                  string activeFilterStr = "[StoreCode] = \'" + Authorization.StoreCode + "\'";
                  FormReportGrid formGrid = new(qryMaster + filter, dcReport, activeFilterStr);
                  formGrid.Show();
               }
            }
         }
      }

      private void StandartKeys(KeyEventArgs e)
      {
         if (e.KeyCode == Keys.F1)
            SelectCurrAcc();

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
         GridView view = (GridView)sender;

         if (view == null) return;

         //gV_InvoiceLine.SetFocusedRowCellValue(colQty, 1);

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


      private void gV_InvoiceLine_ValidatingEditor(object sender, BaseContainerValidateEditorEventArgs e)
      {
         GridView view = sender as GridView;
         GridColumn column = (e as EditFormValidateEditorEventArgs)?.Column ?? view.FocusedColumn;

         if (column == colQty)
         {
            int eValue = Convert.ToInt32(e.Value ??= 0);
            if ((!trInvoiceHeader.IsReturn && trInvoiceHeader.ProcessCode == "RS") || trInvoiceHeader.ProcessCode == "IT")
            {
               object objProductCode = view.GetFocusedRowCellValue(col_ProductCode);
               object objInvoiceLineId = view.GetFocusedRowCellValue(col_InvoiceLineId);

               string wareHouse = lUE_WarehouseCode.EditValue.ToString();
               if (trInvoiceHeader.IsReturn && trInvoiceHeader.ProcessCode == "IT")
                  wareHouse = lUE_ToWarehouseCode.EditValue.ToString();

               int balance = CalcProductBalance(objProductCode, objInvoiceLineId, wareHouse);

               string productCode = (objProductCode ??= "").ToString();
               DcProduct product = efMethods.SelectProduct(productCode);

               bool isServis = product.ProductTypeCode == 3;

               if (!isServis)
                  if (eValue > balance)
                  {
                     e.ErrorText = "Stokda miqdar yoxdur";
                     e.Valid = false;
                  }
            }

            if (!trInvoiceHeader.IsReturn && trInvoiceHeader.ProcessCode == "RS")
            {
               string currAccCode = trInvoiceHeader.CurrAccCode;
               if (!String.IsNullOrEmpty(currAccCode))
               {
                  DcCurrAcc dcCurrAcc = efMethods.SelectCurrAcc(currAccCode);
                  decimal creditLimit = dcCurrAcc.CreditLimit;
                  decimal sumInvo = CalcCurrAccCreditBalance(eValue, view, currAccCode);

                  if (sumInvo > creditLimit && creditLimit != 0)
                  {
                     e.ErrorText = "Müştəri Kredit Limitini Aşır!";
                     e.Valid = false;
                  }
               }
            }
         }

         if (column == colBarcode)
         {
            string eValue = (e.Value ??= String.Empty).ToString();
            DcProduct product = efMethods.SelectProductByBarcode(eValue);

            if (product is null)
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

               decimal priceProduct = dcProcess.ProcessCode == "RS" ? product.WholesalePrice : (dcProcess.ProcessCode == "RP" ? product.PurchasePrice : 0);
               decimal priceInvoice = Convert.ToInt32(gV_InvoiceLine.GetFocusedRowCellValue(col_Price));
               if (priceInvoice == 0)
                  gV_InvoiceLine.SetFocusedRowCellValue(col_Price, priceProduct);

               gV_InvoiceLine.UpdateCurrentRow(); // For Model/Entity/trInvoiceLine Included TrInvoiceHeader

               if (dcProcess.ProcessCode == "EX")
                  gV_InvoiceLine.SetFocusedRowCellValue(colQty, 1);

               //gV_InvoiceLine.SetFocusedRowCellValue(colQty, 1);
            }
         }

         if (column == col_ProductCode)
         {
            string eValue = (e.Value ??= String.Empty).ToString();
            DcProduct product = efMethods.SelectProduct(eValue);

            if (product is null)
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

               decimal priceProduct = dcProcess.ProcessCode == "RS" ? product.WholesalePrice : (dcProcess.ProcessCode == "RP" ? product.PurchasePrice : 0);
               decimal priceInvoice = Convert.ToInt32(gV_InvoiceLine.GetFocusedRowCellValue(col_Price));
               if (priceInvoice == 0)
                  gV_InvoiceLine.SetFocusedRowCellValue(col_Price, priceProduct);

               gV_InvoiceLine.UpdateCurrentRow(); // For Model/Entity/trInvoiceLine Included TrInvoiceHeader

               if (dcProcess.ProcessCode == "EX")
                  gV_InvoiceLine.SetFocusedRowCellValue(colQty, 1);

               //gV_InvoiceLine.SetFocusedRowCellValue(colQty, 1);
            }
         }
      }

      private decimal CalcCurrAccCreditBalance(int eValue, GridView view, string currAccCode)
      {
         decimal invoiceSumLoc = (-1) * efMethods.SelectCurrAccBalance(currAccCode, trInvoiceHeader.DocumentDate);

         object colInvoiceLineId = view.GetFocusedRowCellValue(col_InvoiceLineId);
         Guid invoiceLineId = (Guid)(colInvoiceLineId ??= Guid.Empty);
         TrInvoiceLine currTrInvoLine = efMethods.SelectInvoiceLine(invoiceLineId);
         decimal currentNetAmountLoc = currTrInvoLine is null ? 0 : currTrInvoLine.NetAmountLoc;

         decimal sumInvoExpectLine = invoiceSumLoc - currentNetAmountLoc;

         object objPriceLoc = view.GetFocusedRowCellValue(colPriceLoc);

         decimal sumLineNet = eValue * Convert.ToDecimal(objPriceLoc ??= 0);

         decimal sumInvo = sumInvoExpectLine + sumLineNet;
         return sumInvo;
      }

      private int CalcProductBalance(object objProductCode, object objInvoicelineId, string wareHouse)
      {
         string productCode = (objProductCode ??= "").ToString();

         if (!String.IsNullOrEmpty(productCode))
         {
            Guid invoiceLineId = (Guid)(objInvoicelineId ??= Guid.Empty);

            TrInvoiceLine currTrInvoLine = efMethods.SelectInvoiceLine(invoiceLineId);
            int currentQty = currTrInvoLine is null ? 0 : currTrInvoLine.Qty;

            return efMethods.SelectProductBalance(productCode, wareHouse) + currentQty;
         }
         else return 0;
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

         //Barcode Move Next Row
         //BaseEdit edit = (sender as GridView).ActiveEditor;
         //edit.KeyDown -= Edit_KeyDown;
         //edit.KeyDown += Edit_KeyDown;
      }

      //private void Edit_KeyDown(object sender, KeyEventArgs e)
      //{
      //   if (e.KeyCode == Keys.Enter)
      //   {
      //      if (!this.gV_InvoiceLine.IsLastVisibleRow)
      //         this.gV_InvoiceLine.MoveNext();
      //      else
      //         this.gV_InvoiceLine.MoveFirst();
      //   }
      //}

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
         using FormCurrAccList form = new(0, editor.EditValue.ToString());

         if (form.ShowDialog(this) == DialogResult.OK)
         {
            editor.EditValue = form.dcCurrAcc.CurrAccCode;
         }
      }

      private void SelectProduct(object sender)
      {
         string productCode = "";
         if (gV_InvoiceLine.GetFocusedRowCellValue("ProductCode") != null)
            productCode = gV_InvoiceLine.GetFocusedRowCellValue("ProductCode").ToString();

         ButtonEdit editor = (ButtonEdit)sender;

         using FormProductList form = new(productTypeArr, productCode);

         try
         {
            if (form.ShowDialog(this) == DialogResult.OK)
            {
               editor.EditValue = form.dcProduct.ProductCode;
               gV_InvoiceLine.CloseEditor();
               gV_InvoiceLine.UpdateCurrentRow(); // For Model/Entity/trInvoiceLine Included TrInvoiceHeader

               gV_InvoiceLine.BestFitColumns();
               gV_InvoiceLine.FocusedColumn = colQty;
            }
         }
         catch (Exception ex)
         {
            MessageBox.Show(ex.ToString());
         }
      }

      private void gV_InvoiceLine_RowUpdated(object sender, RowObjectEventArgs e)
      {
         //DataRowView rowView = e.Row as DataRowView;
         //DataRow row = rowView.Row;

         //if (gV_InvoiceLine.FocusedColumn == colBarcode)
         //{

         //   //if (gV_InvoiceLine.FocusedRowHandle == GridControl.NewItemRowHandle)
         //   //   gV_InvoiceLine.FocusedRowHandle = 1;
         //   //else
         ///////////////////gV_InvoiceLine.MoveNext();
         //   gV_InvoiceLine.MoveNext();
         //   //gv.FocusedRowHandle++;
         //}

         SaveInvoice();
      }

      private void gV_InvoiceLine_RowDeleted(object sender, RowDeletedEventArgs e)
      {
         SaveInvoice();
      }

      Guid quidHead;
      private void SaveInvoice()
      {
         efMethods.UpdatePaymentsCurrAccCode(trInvoiceHeader.InvoiceHeaderId, trInvoiceHeader.CurrAccCode);

         try
         {
            dbContext.SaveChanges(false);

            //List<EntityEntry> entityEntry = new();
            IEnumerable<EntityEntry> entityEntry = dbContext.ChangeTracker.Entries();

            if (trInvoiceHeader.ProcessCode == "IT")
            {
               foreach (var entry in entityEntry)
               {
                  if (entry.Entity.GetType().Name == nameof(TrInvoiceHeader))
                  {
                     TrInvoiceHeader trIH = (TrInvoiceHeader)entry.CurrentValues.ToObject();

                     string invoHeadStr = trIH.InvoiceHeaderId.ToString();

                     quidHead = Guid.Parse(invoHeadStr.Replace(invoHeadStr.Substring(0, 8), "00000000")); // 00000000-ED42-11CE-BACD-00AA0057B223

                     using subContext context2 = new();

                     TrInvoiceHeader newTrIH = trIH;
                     newTrIH.InvoiceHeaderId = quidHead;
                     string temp = trIH.WarehouseCode;
                     newTrIH.WarehouseCode = trIH.ToWarehouseCode;
                     newTrIH.ToWarehouseCode = temp;
                     newTrIH.StoreCode = trIH.CurrAccCode;

                     switch (entry.State)
                     {
                        case EntityState.Added: context2.TrInvoiceHeaders.Add(newTrIH); break;
                        case EntityState.Modified: context2.TrInvoiceHeaders.Update(newTrIH); break;
                        case EntityState.Deleted: context2.TrInvoiceHeaders.Remove(newTrIH); break;
                        default: break;
                     }

                     context2.SaveChanges();
                  }

                  if (entry.Entity.GetType().Name == nameof(TrInvoiceLine))
                  {
                     TrInvoiceLine trIL = (TrInvoiceLine)entry.CurrentValues.ToObject();

                     string invoLineStr = trIL.InvoiceLineId.ToString();
                     Guid quidLine = Guid.Parse(invoLineStr.Replace(invoLineStr.Substring(0, 8), "00000000")); // 00000000-ED42-11CE-BACD-00AA0057B223

                     using subContext context2 = new();

                     TrInvoiceLine newTrIL = trIL;
                     newTrIL.InvoiceHeaderId = quidHead;
                     newTrIL.InvoiceLineId = quidLine;
                     newTrIL.QtyIn = trIL.QtyOut;
                     newTrIL.QtyOut -= trIL.QtyOut;

                     switch (entry.State)
                     {
                        case EntityState.Added: context2.TrInvoiceLines.Add(newTrIL); break;
                        case EntityState.Modified: context2.TrInvoiceLines.Update(newTrIL); break;
                        case EntityState.Deleted: context2.TrInvoiceLines.Remove(newTrIL); break;
                        default: break;
                     }
                     context2.SaveChanges();
                  }
               }
            }

            dbContext.ChangeTracker.AcceptAllChanges();
         }
         catch (Exception ex)
         {
            MessageBox.Show($"Daxil Etdiyiniz Məlumatlar Əsaslı Deyil ! \n \n {ex}");
         }

         if (trInvoiceHeader.ProcessCode == "EX")
         {
            SavePayment();
         }

         SaveSession();
      }

      private void SavePayment()
      {
         TrPaymentHeader trPaymentHeader = PaymentHeaderDefaults(trInvoiceHeader);
         TrPaymentLine trPaymentLine = PaymentLineDefaults();

         decimal invoiceSumLoc = Math.Abs(efMethods.SelectInvoiceSum(trInvoiceHeader.InvoiceHeaderId));


         if (invoiceSumLoc > 0)
         {
            if (CustomExtensions.ProcessDir(trInvoiceHeader.ProcessCode) == "In")
               invoiceSumLoc *= (-1);

            bool isNegativ = false;

            if (invoiceSumLoc < 0)
               isNegativ = true;

            EfMethods efMethods = new();

            string NewDocNum = efMethods.GetNextDocNum(true, "PA", "DocumentNumber", "TrPaymentHeaders", 6);
            trPaymentHeader.DocumentNumber = NewDocNum;
            trPaymentHeader.Description = trInvoiceHeader.Description;

            efMethods.DeletePaymentsByInvoice(trInvoiceHeader.InvoiceHeaderId);

            efMethods.InsertPaymentHeader(trPaymentHeader);

            List<TrInvoiceLine> trInvoiceLines = efMethods.SelectInvoiceLines(trInvoiceHeader.InvoiceHeaderId);
            foreach (TrInvoiceLine il in trInvoiceLines)
            {
               trPaymentLine.PaymentHeaderId = trPaymentHeader.PaymentHeaderId;
               trPaymentLine.PaymentLineId = Guid.NewGuid();
               trPaymentLine.Payment = isNegativ ? il.NetAmount * (-1) : il.NetAmount;
               trPaymentLine.CurrencyCode = il.CurrencyCode;
               trPaymentLine.ExchangeRate = il.ExchangeRate;
               trPaymentLine.LineDescription = il.LineDescription;
               trPaymentLine.PaymentLoc = isNegativ ? il.NetAmountLoc * (-1) : il.NetAmountLoc;

               efMethods.InsertPaymentLine(trPaymentLine);
            }
         }

         CalcPaidAmount();
      }

      private TrPaymentHeader PaymentHeaderDefaults(TrInvoiceHeader trInvoiceHeader)
      {
         TrPaymentHeader trPaymentHeader = new();

         Guid PaymentHeaderId = Guid.NewGuid();

         bool invoiceExist = trInvoiceHeader.InvoiceHeaderId != Guid.Empty && trInvoiceHeader != null;

         string operType = "payment";
         if (invoiceExist)
            operType = "invoice";

         trPaymentHeader.PaymentHeaderId = PaymentHeaderId;
         trPaymentHeader.CurrAccCode = trInvoiceHeader.CurrAccCode;
         trPaymentHeader.CreatedUserName = Authorization.CurrAccCode;
         trPaymentHeader.OfficeCode = Authorization.OfficeCode;
         trPaymentHeader.StoreCode = Authorization.StoreCode;
         trPaymentHeader.DocumentDate = trInvoiceHeader.DocumentDate;
         trPaymentHeader.DocumentTime = trInvoiceHeader.DocumentTime;
         if (invoiceExist)
            trPaymentHeader.InvoiceHeaderId = trInvoiceHeader.InvoiceHeaderId;
         trPaymentHeader.OperationType = operType;
         trPaymentHeader.OperationDate = trInvoiceHeader.DocumentDate;
         trPaymentHeader.OperationTime = trInvoiceHeader.DocumentTime;

         return trPaymentHeader;
      }

      private TrPaymentLine PaymentLineDefaults()
      {
         TrPaymentLine trPaymentLine = new();
         trPaymentLine.PaymentTypeCode = 1;
         trPaymentLine.CurrencyCode = Settings.Default.AppSetting.LocalCurrencyCode;
         trPaymentLine.ExchangeRate = 1f;
         trPaymentLine.CashRegisterCode = efMethods.SelectCashRegByStore(Authorization.StoreCode);
         trPaymentLine.CreatedUserName = Authorization.CurrAccCode;

         return trPaymentLine;
      }
      private void FormInvoice_FormClosed(object sender, FormClosedEventArgs e)
      {
         dbContext.Dispose();
      }

      private void bBI_SaveAndNew_ItemClick(object sender, ItemClickEventArgs e)
      {
         if (dataLayoutControl1.IsValid(out List<string> errorList))
         {
            decimal summaryInvoice = (decimal)colNetAmountLoc.SummaryItem.SummaryValue;

            if (summaryInvoice != 0 || trInvoiceHeader.ProcessCode == "IT")
            {
               SaveInvoice();

               //MakePayment(summaryInvoice);

               GetPrintToWarehouse();

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
         if (warehouseCode is not null)
         {
            Settings.Default.WarehouseCode = lUE_WarehouseCode.EditValue.ToString();
            Settings.Default.Save();
         }
      }

      private void GetPrintToWarehouse()
      {
         string designPath = designFolder + @"\" + reportFileNameInvoiceWare;

         XtraReport report = GetInvoiceReport(designPath);

         if (report is not null)
         {
            using MemoryStream ms = new();
            report.ExportToImage(ms, new ImageExportOptions() { Format = ImageFormat.Png, PageRange = "1", ExportMode = ImageExportMode.SingleFile });
            Image img = Image.FromStream(ms);
            Clipboard.SetImage(img);

            ReportPrintTool printTool = new(report);

            bool? isPrinted = printTool.PrintDialog();

            if (isPrinted is not null)
            {
               bool printed = Convert.ToBoolean(isPrinted);
               if (printed)
               {
                  efMethods.UpdateInvoicePrintCount(trInvoiceHeader.InvoiceHeaderId);
                  //ShowPrintCount();
               }
            }
         }
      }

      private string subConnString = ConfigurationManager
                       .OpenExeConfiguration(ConfigurationUserLevel.None)
                       .ConnectionStrings
                       .ConnectionStrings["Foxoft.Properties.Settings.subConnString"]
                       .ConnectionString;
      private XtraReport GetInvoiceReport(string designPath)
      {
         ReportClass reportClass = new();

         if (!File.Exists(designPath))
            designPath = reportClass.SelectDesign();
         if (File.Exists(designPath))
         {
            DsMethods dsMethods = new();
            SqlDataSource dataSource = new(new CustomStringConnectionParameters(subConnString));
            dataSource.Name = "Invoice";

            SqlQuery sqlQuerySale = dsMethods.SelectInvoice(trInvoiceHeader.InvoiceHeaderId);
            dataSource.Queries.AddRange(new SqlQuery[] { sqlQuerySale });
            dataSource.Fill();

            return reportClass.CreateReport(dataSource, designPath);
         }
         else
         {
            return null;
         }
      }

      private void MakePayment(decimal summaryInvoice, bool autoPayment)
      {
         using FormPayment formPayment = new(1, summaryInvoice, trInvoiceHeader, autoPayment);

         if (formPayment.ShowDialog(this) == DialogResult.OK)
         {
            CalcPaidAmount();
            //efMethods.UpdateInvoiceIsCompleted(trInvoiceHeader.InvoiceHeaderId);
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

      private void bBI_reportDesign_ItemClick(object sender, ItemClickEventArgs e)
      {
         string designPath = "";
         XtraReport xtraReport = GetInvoiceReport(designPath);

         if (xtraReport is not null)
         {
            ReportDesignTool printTool = new(xtraReport);
            printTool.ShowRibbonDesigner();
         }
      }

      private void bBI_reportPreview_ItemClick(object sender, ItemClickEventArgs e)
      {
         ShowReportPreview();
      }

      private void ShowReportPreview()
      {
         //string designPath = Settings.Default.AppSetting.PrintDesignPath;
         string designPath = designFolder + @"\" + reportFileNameInvoice;

         XtraReport xtraReport = GetInvoiceReport(designPath);

         if (xtraReport is not null)
         {
            ReportPrintTool printTool = new(xtraReport);
            printTool.ShowRibbonPreview();
         }
      }

      private void bBI_Save_ItemClick(object sender, ItemClickEventArgs e)
      {
         if (dataLayoutControl1.IsValid(out List<string> errorList))
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
         if (dataLayoutControl1.IsValid(out List<string> errorList))
         {
            decimal summaryInvoice = (decimal)colNetAmountLoc.SummaryItem.SummaryValue;

            if (summaryInvoice != 0)
            {
               //SaveInvoice();
               MakePayment(summaryInvoice, false);
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
               if (efMethods.PaymentHeaderExistByInvoice(trInvoiceHeader.InvoiceHeaderId))
                  if (MessageBox.Show("Ödənişi də Silirsiniz! ", "Diqqət", MessageBoxButtons.OKCancel) == DialogResult.OK)
                     efMethods.DeletePaymentsByInvoice(trInvoiceHeader.InvoiceHeaderId);

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
            efMethods.DeletePaymentsByInvoice(trInvoiceHeader.InvoiceHeaderId);
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

      private void bBI_SaveAndQuit_ItemClick(object sender, ItemClickEventArgs e)
      {
         if (dataLayoutControl1.IsValid(out List<string> errorList))
         {
            decimal summInvoice = (decimal)colNetAmountLoc.SummaryItem.SummaryValue;

            if (summInvoice != 0 || trInvoiceHeader.ProcessCode == "IT")
            {
               SaveInvoice();

               //MakePayment(summInvoice, false);

               GetPrintToWarehouse();

               Close();
            }
            else if (XtraMessageBox.Show("Ödəmə 0a bərabərdir! \n Fakturaya qayıtmaq istəyirsiz? ", "Diqqət", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
            {
               Close();
            };
         }
         else
         {
            string combinedStr = errorList.Aggregate((x, y) => x + "" + y);
            XtraMessageBox.Show(combinedStr);
         }
      }

      private void gV_InvoiceLine_RowCellStyle(object sender, RowCellStyleEventArgs e)
      {
         GridView gridView = sender as GridView;

         Color readOnlyBackColor = Color.LightGray;
         try
         {
            if (e.RowHandle >= 0 && (!gridView.OptionsBehavior.Editable || !e.Column.OptionsColumn.AllowEdit || e.Column.ReadOnly))
            {
               GridViewInfo viewInfo = gridView.GetViewInfo() as GridViewInfo;
               GridDataRowInfo rowInfo = viewInfo.RowsInfo.GetInfoByHandle(e.RowHandle) as GridDataRowInfo;

               if (rowInfo == null || (rowInfo != null && rowInfo.ConditionInfo.GetCellAppearance(e.Column) == null))
               {
                  bool hasrules = false;
                  foreach (GridFormatRule rule in gridView.FormatRules)
                  {
                     if (rule.IsFit(e.CellValue, gridView.GetDataSourceRowIndex(e.RowHandle)))
                     {
                        hasrules = true;
                        break;
                     }
                  }
                  if (!hasrules)
                     e.Appearance.BackColor = readOnlyBackColor;
               }
            }
            // This is to fix the selection color when a color is set for the column  
            if (e.Column.AppearanceCell.Options.UseBackColor && gridView.IsCellSelected(e.RowHandle, e.Column))
               e.Appearance.BackColor = gridView.PaintAppearance.SelectedRow.BackColor;
         }
         catch (Exception ex)
         {
            Debug.Print(ex.Message);
         }
      }

      private void dataLayoutControls_KeyDown(object sender, KeyEventArgs e)
      {
         StandartKeys(e);
      }

      private void bBI_CopyInvoice_ItemClick(object sender, ItemClickEventArgs e)
      {
         string fileName = reportFileNameInvoice;

         Image image = Image.FromStream(GetInvoiceReportImg(fileName));
         Clipboard.SetImage(image);
      }

      private MemoryStream GetInvoiceReportImg(string designPath)
      {
         //string designPath = Settings.Default.AppSetting.PrintDesignPath;

         designPath = designFolder + @"\" + reportFileNameInvoice;

         XtraReport report = GetInvoiceReport(designPath);

         if (report is not null)
         {
            MemoryStream ms = new();

            report.ExportToImage(ms, new ImageExportOptions() { Format = ImageFormat.Png, PageRange = "1", ExportMode = ImageExportMode.SingleFile });

            return ms;
         }
         else
            return null;
      }

      private void bBI_Whatsapp_ItemClick(object sender, ItemClickEventArgs e)
      {
         MemoryStream memoryStream = GetInvoiceReportImg(reportFileNameInvoice);
         Clipboard.SetImage(Image.FromStream(memoryStream));
         string phoneNum = efMethods.SelectCurrAcc(trInvoiceHeader.CurrAccCode).PhoneNum;

         //byte[] AsBytes = memoryStream.ToArray();
         //string AsBase64String = Convert.ToBase64String(AsBytes);

         SendWhatsApp(phoneNum, "");
      }

      private void SendWhatsApp(string number, string message)
      {
         if (String.IsNullOrEmpty(number))
         {
            MessageBox.Show("Nömrə qeyd olunmayıb.");
            return;
         }

         number = number.Trim();
         number = "+994" + number;

         string link = $"https://web.whatsapp.com/send?phone={number}&text={message}";

         Process myProcess = new();
         myProcess.StartInfo.UseShellExecute = true;
         myProcess.StartInfo.FileName = link;
         myProcess.Start();
      }

      #region Whatsapp api.ultramsg
      //private void SendWhatsapp(string number, string type, string body)
      //{
      //   if (String.IsNullOrEmpty(number))
      //   {
      //      MessageBox.Show("Nömrə qeyd olunmayıb.");
      //      return;
      //   }

      //   number = number.Trim();
      //   number = "+994" + number;

      //   string instanceId = "instance17384";
      //   string token = "y4hm0p00tuganpqt";
      //   string url = "https://api.ultramsg.com/" + instanceId + "/messages/";

      //   //byte[] AsBytes = File.ReadAllBytes(body);
      //   //string AsBase64String = Convert.ToBase64String(AsBytes);

      //   url += type == "image" ? "image" : "chat";

      //   var client = new RestClient(url);
      //   var request = new RestRequest(url, Method.Post);
      //   request.AddHeader("content-type", "application/x-www-form-urlencoded");
      //   request.AddParameter("token", token);
      //   request.AddParameter("to", number);

      //   if (type == "chat")
      //      request.AddParameter("body", body);
      //   else if (type == "image")
      //      request.AddParameter("image", body);

      //   RestResponse response = client.Execute(request);
      //   var output = response.Content;

      //   MessageBox.Show(output.ToString());
      //} 
      #endregion

      private void btnEdit_CurrAccCode_Validating(object sender, CancelEventArgs e)
      {
         object eValue = trInvoiceHeader.CurrAccCode;

         if (eValue is not null)
         {
            DcCurrAcc curr = efMethods.SelectCurrAcc(eValue.ToString());

            if (curr is null)
            {
               e.Cancel = true;
            }
            else
            {
               FillCurrAccCode(curr);
            }
         }
      }

      private void FillCurrAccCode(DcCurrAcc curr)
      {
         trInvoiceHeader.CurrAccCode = curr.CurrAccCode;
         lbl_CurrAccDesc.Text = curr.CurrAccDesc + " " + curr.FirstName + " " + curr.LastName;

         trInvoiceHeader.ToWarehouseCode = efMethods.SelectWarehouseByStore(trInvoiceHeader.CurrAccCode);
         lUE_ToWarehouseCode.EditValue = trInvoiceHeader.ToWarehouseCode;
      }

      private void btnEdit_CurrAccCode_InvalidValue(object sender, InvalidValueExceptionEventArgs e)
      {
         e.ErrorText = "Belə bir cari yoxdur";
         e.ExceptionMode = ExceptionMode.DisplayError;
      }

      private void BBI_ModifyInvoice_ItemClick(object sender, ItemClickEventArgs e)
      {
         if (CheckEdit_IsReturn.Enabled)
            CheckEdit_IsReturn.Enabled = false;
         else
            CheckEdit_IsReturn.Enabled = true;
      }

      private void gC_InvoiceLine_EditorKeyPress(object sender, KeyPressEventArgs e)
      {
         GridControl gc = sender as GridControl;
         GridView gv = gc.FocusedView as GridView;

         if (gv.FocusedColumn.ColumnType == typeof(decimal))
         {
            if (e.KeyChar == '.')
               e.KeyChar = Convert.ToChar(",");
         }



         if (e.KeyChar == (char)Keys.Return && gv.FocusedColumn == colBarcode)
         {
            //////////gv.FocusedColumn = colBarcode;
            //////////if (gv.FocusedRowHandle == GridControl.NewItemRowHandle)
            //////////{
            //////////   gv.MoveNext();
            //////////}
            //////////else
            //////////   gv.MoveNext();


            //gv.FocusedColumn = colBarcode;

            e.Handled = true;


            //gv.FocusedRowHandle++;
         }
      }

      private void bbi_ItemClick(object sender, ItemClickEventArgs e)
      {
         //gV_InvoiceLine.FocusedColumn = colBarcode;

         //MessageBox.Show($"\nEnvironment.CurrentDirectory: from \n{Environment.CurrentDirectory}"
         //+ $"\n\nAppDomain.CurrentDomain.BaseDirectory: \n{AppDomain.CurrentDomain.BaseDirectory}"
         //+ $"\n\nAppContext.BaseDirectory: \n{AppContext.BaseDirectory}"
         //+ $"\n\nLocation: \n{Assembly.GetEntryAssembly().Location}"
         //+ $"\n\nPath.GetDirectoryName(Assembly.GetExecutingAssembly().Location): \n{Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}"
         //+ $"\n\nPath.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName): \n{Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName)}");

      }

      private void LoadLayout()
      {
         //gV_InvoiceLine.OptionsNavigation.EnterMoveNextColumn = false;

         colBalance.OptionsColumn.ReadOnly = true;
         colLastPurchasePrice.OptionsColumn.ReadOnly = true;
         col_NetAmount.OptionsColumn.ReadOnly = true;
         colNetAmountLoc.OptionsColumn.ReadOnly = true;
         col_Amount.OptionsColumn.ReadOnly = true;
         colAmountLoc.OptionsColumn.ReadOnly = true;

         if (dcProcess.ProcessCode == "EX" || dcProcess.ProcessCode == "CI" || dcProcess.ProcessCode == "CO" || dcProcess.ProcessCode == "IT")
         {
            btnEdit_CurrAccCode.Enabled = false;
            colBalance.Visible = false;
            col_PosDiscount.Visible = false;
            colLastPurchasePrice.Visible = false;
            colBenefit.Visible = false;

            if (dcProcess.ProcessCode == "EX")
               colQty.Visible = false;
            if (dcProcess.ProcessCode == "IT")
            {
               btnEdit_CurrAccCode.Enabled = true;
               col_Price.Visible = false;
               colCurrencyCode.Visible = false;
               col_NetAmount.Visible = false;
            }
         }

         if (true)
         {

         }


         string fileName = "Invoice" + dcProcess.ProcessCode + "Layout.xml";
         string layoutFilePath = Path.Combine(Environment.CurrentDirectory, "Layout Xml Files", fileName);
         if (File.Exists(layoutFilePath))
            gV_InvoiceLine.RestoreLayoutFromXml(layoutFilePath);

      }

      private void SaveLayout()
      {
         string fileName = "Invoice" + dcProcess.ProcessCode + "Layout.xml";
         string layoutFileDir = Path.Combine(Environment.CurrentDirectory, "Layout Xml Files");
         if (!Directory.Exists(layoutFileDir))
            Directory.CreateDirectory(layoutFileDir);
         gV_InvoiceLine.SaveLayoutToXml(Path.Combine(layoutFileDir, fileName));
      }

      private void gV_Report_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
      {
         if (e.MenuType == GridMenuType.Column)
         {
            GridViewColumnMenu menu = e.Menu as GridViewColumnMenu;
            //menu.Items.Clear();
            if (menu.Column != null)
            {
               menu.Items.Add(CreateItem("Save Layout", menu.Column, null));
            }
         }
      }

      DXMenuItem CreateItem(string caption, GridColumn column, Image image)
      {
         DXMenuItem item = new(caption, new EventHandler(DXMenuCheckItem_ItemClick), image);
         item.Tag = new MenuColumnInfo(column);
         return item;
      }

      // Menu item click handler.
      void DXMenuCheckItem_ItemClick(object sender, EventArgs e)
      {
         DXMenuItem item = sender as DXMenuItem;
         MenuColumnInfo info = item.Tag as MenuColumnInfo;
         if (info == null) return;

         SaveLayout();

         //GridColumn col = gV_Report.Columns.AddVisible("Unbound" + gV_Report.Columns.Count);
      }

      class MenuColumnInfo
      {
         public MenuColumnInfo(GridColumn column)
         {
            this.Column = column;
         }
         public GridColumn Column;
      }

      private void gV_InvoiceLine_KeyPress(object sender, KeyPressEventArgs e)
      {
         //GridView gv = sender as GridView;

         //if (e.KeyChar == (char)Keys.Return && gv.FocusedColumn == colBarcode)
         //{
         //   gv.MoveNext();
         //}


         //DcProduct product = efMethods.SelectProduct(currValue);

         //int balance = CalcProductBalance(view);

         //if (product is null)
         //{
         //   e.ErrorText = "Belə nir məhsul yoxdur";
         //   e.Valid = false;
         //}
      }

      private void gV_InvoiceLine_RowCountChanged(object sender, EventArgs e)
      {
         //gV_InvoiceLine.FocusedColumn = colBarcode;
      }

      private void gC_InvoiceLine_EditorKeyUp(object sender, KeyEventArgs e)
      {
         if (e.KeyCode == Keys.Return) // Barcode Scan Device 
         {
            gV_InvoiceLine.SetFocusedRowCellValue(colQty, 1);
            gV_InvoiceLine.MoveNext();
            gV_InvoiceLine.FocusedColumn = colBarcode;
         }
      }

      private void gC_InvoiceLine_ProcessGridKey(object sender, KeyEventArgs e)
      {
         if (e.KeyCode == Keys.Return)
         {

            //gV_InvoiceLine.FocusedColumn = colBarcode;
         }
      }

      private void gC_InvoiceLine_KeyUp(object sender, KeyEventArgs e)
      {
         if (e.KeyCode == Keys.Return)
         {

            //gV_InvoiceLine.FocusedColumn = colBarcode;
         }
      }
   }
}