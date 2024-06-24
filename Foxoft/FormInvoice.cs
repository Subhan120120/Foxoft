
#region Using
using DevExpress.Data;
using DevExpress.DataAccess.Excel;
using DevExpress.DataAccess.Native.Excel;
using DevExpress.DataAccess.Sql;
using DevExpress.Utils;
using DevExpress.Utils.Extensions;
using DevExpress.Utils.Menu;
using DevExpress.Utils.Svg;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Filtering;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Menu;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraLayout;
using DevExpress.XtraPrinting;
using DevExpress.XtraReports.UI;
using DevExpress.XtraSplashScreen;
using Foxoft.AppCode;
using Foxoft.Models;
using Foxoft.Properties;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WaitForm_SetDescription;
using PopupMenuShowingEventArgs = DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs;

#endregion

namespace Foxoft
{
    public partial class FormInvoice : RibbonForm
    {
        private EfMethods efMethods = new();
        private subContext dbContext;
        subContext subContext = new();

        string reportFileNameInvoice = @"InvoiceRS_A4.repx";
        string reportFileNameInvoiceWare = @"InvoiceRS_A4_depo.repx";

        readonly SettingStore settingStore;
        private TrInvoiceHeader trInvoiceHeader;
        Guid invoiceHeaderId;
        Guid relatedInvoiceId;
        public DcProcess dcProcess;
        private byte[] productTypeArr;

        //public AdornerElement[] Badges { get { return new AdornerElement[] { badge1, badge2 }; } }

        public FormInvoice(string processCode, byte[] productTypeArr, Guid relatedInvoiceId)
        {
            settingStore = efMethods.SelectSettingStore(Authorization.StoreCode);
            dcProcess = efMethods.SelectProcess(processCode);

            InitializeComponent();

            InitializeColumnName();

            this.productTypeArr = productTypeArr;
            this.relatedInvoiceId = relatedInvoiceId;
            this.Text = dcProcess.ProcessDesc;
            BEI_TwilioInstance.EditValue = Settings.Default.AppSetting.TwilioInstanceId;
            BEI_TwilioToken.EditValue = Settings.Default.AppSetting.TwilioToken;
            BEI_PrinterName.EditValue = settingStore.PrinterName;
            lUE_StoreCode.Properties.DataSource = efMethods.SelectStores();
            lUE_WarehouseCode.Properties.DataSource = efMethods.SelectWarehouses();
            lUE_ToWarehouseCode.Properties.DataSource = efMethods.SelectWarehouses();
            repoLUE_CurrencyCode.DataSource = efMethods.SelectCurrencies();



            AddReports();

            foreach (string printer in PrinterSettings.InstalledPrinters)
                repoCBE_PrinterName.Items.Add(printer);

            LoadLayout();

            if (settingStore is not null)
                if (CustomExtensions.DirectoryExist(settingStore.ImageFolder))
                    AppDomain.CurrentDomain.SetData("DXResourceDirectory", settingStore.ImageFolder);

            ClearControlsAddNew();

            foreach (BaseLayoutItem item in dataLayoutControl1.Items)
            {
                if (item is LayoutControlItem)
                {
                    LayoutControlItem controlItem = item as LayoutControlItem;
                    if (controlItem != null)
                        if (controlItem.Control is BaseEdit)
                            (controlItem.Control as BaseEdit).Leave += item_Leave;
                }
            }
        }

        public FormInvoice(string processCode, byte[] productTypeArr, Guid relatedInvoiceId, Guid invoiceHeaderId)
            : this(processCode, productTypeArr, relatedInvoiceId)
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

        private void InitializeColumnName()
        {
            colLastPurchasePrice.Caption = ReflectionExt.GetDisplayName<DcProduct>(x => x.LastPurchasePrice);
            colBalance.Caption = ReflectionExt.GetDisplayName<DcProduct>(x => x.Balance);
            col_ProductDesc.Caption = ReflectionExt.GetDisplayName<DcProduct>(x => x.ProductDesc);
            checkEdit_IsSent.Properties.Caption = ReflectionExt.GetDisplayName<TrInvoiceHeader>(x => x.IsSent);
            checkEdit_IsReturn.Properties.Caption = ReflectionExt.GetDisplayName<TrInvoiceHeader>(x => x.IsReturn);
        }

        private void AddReports()
        {
            List<TrFormReport> trFormReports = efMethods.SelectFormReports("Products");

            foreach (TrFormReport report in trFormReports)
            {
                BarButtonItem BBI = new();
                BBI.Caption = report.DcReport.ReportName;
                BBI.Id = 57;
                BBI.ImageOptions.SvgImage = svgImageCollection1["report"];
                BBI.Name = report.DcReport.ReportId.ToString();

                if (!string.IsNullOrEmpty(report.Shortcut))
                {
                    KeysConverter cvt = new();
                    Keys key = (Keys)cvt.ConvertFrom(report.Shortcut);
                    BBI.ItemShortcut = new BarShortcut(key);
                }
                BSI_Reports.LinksPersistInfo.Add(new LinkPersistInfo(BBI));

                ((ISupportInitialize)ribbonControl1).BeginInit();
                ribbonControl1.Items.Add(BBI);
                ((ISupportInitialize)ribbonControl1).EndInit();

                BBI.ItemClick += (sender, e) =>
                {
                    DcReport dcReport = efMethods.SelectReport(report.DcReport.ReportId);

                    bool currAccHasClaims = efMethods.CurrAccHasClaims(Authorization.CurrAccCode, dcReport.ReportId.ToString());
                    if (!currAccHasClaims)
                    {
                        MessageBox.Show("Yetkiniz yoxdur! ");
                        return;
                    }

                    List<TrInvoiceLine> mydata = GetFilteredData<TrInvoiceLine>(gV_InvoiceLine).ToList();

                    if (mydata.Count > 0)
                    {
                        string productCode = gV_InvoiceLine.GetFocusedRowCellValue(col_ProductCode)?.ToString();

                        string filter = "";
                        if (!string.IsNullOrEmpty(productCode))
                            filter = "[ProductCode] = '" + productCode + "' ";
                        else
                        {
                            var combined = "";
                            foreach (TrInvoiceLine rowView in mydata)
                                combined += "'" + rowView.ProductCode.ToString() + "',";

                            combined = combined.Substring(0, combined.Length - 1);
                            filter = "[ProductCode] in ( " + combined + ")";
                        }

                        string activeFilterStr = "[StoreCode] = \'" + Authorization.StoreCode + "\'";

                        if (dcReport.ReportTypeId == 1)
                        {
                            FormReportGrid formGrid = new(dcReport.ReportQuery, filter, dcReport, activeFilterStr);
                            formGrid.Show();
                        }
                        else if (dcReport.ReportTypeId == 2)
                        {
                            FormReportPreview form = new(dcReport.ReportQuery, filter, dcReport);
                            form.WindowState = FormWindowState.Maximized;
                            form.Show();
                        }
                    }
                    else XtraMessageBox.Show("Qeydə alınmış məlumat yoxdur");
                };
            }
        }


        private void SaveInvoiceHeader()
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

            checkEdit_IsReturn.Enabled = false;
        }

        private void trInvoiceHeadersBindingSource_AddingNew(object sender, AddingNewEventArgs e)
        {
            TrInvoiceHeader invoiceHeader = new();
            invoiceHeader.InvoiceHeaderId = invoiceHeaderId;
            invoiceHeader.RelatedInvoiceId = relatedInvoiceId;
            string NewDocNum = efMethods.GetNextDocNum(true, dcProcess.ProcessCode, "DocumentNumber", "TrInvoiceHeaders", 6);
            invoiceHeader.DocumentNumber = NewDocNum;
            invoiceHeader.DocumentDate = DateTime.Now;
            invoiceHeader.DocumentTime = TimeSpan.Parse(DateTime.Now.ToString("HH:mm:ss"));
            invoiceHeader.ProcessCode = dcProcess.ProcessCode;
            invoiceHeader.OfficeCode = Authorization.OfficeCode;
            invoiceHeader.StoreCode = Authorization.StoreCode;
            invoiceHeader.CreatedUserName = Authorization.CurrAccCode;
            invoiceHeader.IsMainTF = true;
            invoiceHeader.WarehouseCode = efMethods.SelectWarehouseByStore(Authorization.StoreCode);

            if (dcProcess.ProcessCode == "RS")
            {
                string defaultCustomer = efMethods.SelectDefaultCustomerByStore(Authorization.StoreCode);
                invoiceHeader.CurrAccCode = defaultCustomer;

                if (efMethods.SelectCurrAcc(defaultCustomer) is not null)
                    invoiceHeader.CurrAccDesc = efMethods.SelectCurrAcc(defaultCustomer).CurrAccDesc;
            }

            e.NewObject = invoiceHeader;
        }

        private void trInvoiceHeadersBindingSource_CurrentItemChanged(object sender, EventArgs e)
        {
            gV_InvoiceLine.Focus();
        }

        private void item_EditValueChanged(object sender, EventArgs e)
        {
            //SaveInvoiceHeader();
        }

        private void item_Leave(object sender, EventArgs e)
        {
            SaveInvoiceHeader();
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
            using FormInvoiceHeaderList form = new(dcProcess.ProcessCode, relatedInvoiceId);

            if (form.ShowDialog(this) == DialogResult.OK)
            {
                efMethods.UpdateInvoiceIsOpen(trInvoiceHeader.DocumentNumber, false);

                trInvoiceHeader = form.trInvoiceHeader;

                LoadInvoice(trInvoiceHeader.InvoiceHeaderId);
            }
        }

        private void LoadInvoice(Guid InvoiceHeaderId)
        {
            SplashScreenManager.ShowForm(this, typeof(WaitForm1), true, true, false);

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

            dbContext.TrInvoiceLines.Include(o => o.DcProduct).ThenInclude(f => f.TrProductFeatures)
                                    .Include(x => x.TrInvoiceHeader).ThenInclude(x => x.DcProcess)
                                    .Where(x => x.InvoiceHeaderId == InvoiceHeaderId)
                                    .OrderBy(x => x.CreatedDate)
                                    .LoadAsync()
                                    .ContinueWith(loadTask =>
                                    {
                                        //LocalView<TrInvoiceLine> lV_invoiceLine = dbContext.TrInvoiceLines.Local;
                                        //
                                        //lV_invoiceLine.ForEach(x =>
                                        //{
                                        //    x.ProductDesc = GetProductDescWide(x.DcProduct);
                                        //});
                                        //
                                        //trInvoiceLinesBindingSource.DataSource = lV_invoiceLine.ToBindingList();
                                        trInvoiceLinesBindingSource.DataSource = dbContext.TrInvoiceLines.Local.ToBindingList();

                                        gV_InvoiceLine.BestFitColumns();
                                        gV_InvoiceLine.Focus();

                                    }, TaskScheduler.FromCurrentSynchronizationContext());


            dataLayoutControl1.IsValid(out List<string> errorList);
            CalcPaidAmount();
            //ShowPrintCount();

            checkEdit_IsReturn.Enabled = false;

            SplashScreenManager.CloseForm(false);
        }

        private void CalcPaidAmount()
        {
            decimal paidSum = efMethods.SelectPaymentLinesSum(trInvoiceHeader.InvoiceHeaderId) * (dcProcess.ProcessDir == 1 ? (-1) : 1);
            lbl_InvoicePaidSum.Text = "Ödənilib: " + Math.Round(paidSum, 2).ToString() + " " + Settings.Default.AppSetting.LocalCurrencyCode;
        }

        private void ShowPrintCount()
        {
            int printCount = efMethods.SelectInvoicePrinCount(trInvoiceHeader?.InvoiceHeaderId);

            txtEdit_PrintCount.Text = printCount.ToString();
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
                FormCurrAccList form = new(new byte[] { 1, 2, 3 }, trInvoiceHeader.CurrAccCode);

                if (trInvoiceHeader.ProcessCode == "IT")
                    form = new FormCurrAccList(new byte[] { 4 }, trInvoiceHeader.CurrAccCode);

                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    if (form.dcCurrAcc.CreditLimit > Math.Abs(form.dcCurrAcc.Balance) || form.dcCurrAcc.CreditLimit == 0)
                    {
                        btnEdit_CurrAccCode.EditValue = form.dcCurrAcc.CurrAccCode;
                        //FillCurrAccCode(form.dcCurrAcc);
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
                    string cellValue = gV.GetFocusedValue()?.ToString();
                    if (!string.IsNullOrEmpty(cellValue))
                    {
                        Clipboard.SetText(cellValue);
                        e.Handled = true;
                    }
                }

                if (e.KeyCode == Keys.F5)
                {
                    object productCode = gV.GetFocusedRowCellValue(col_ProductCode);
                    if (productCode != null)
                    {
                        DcReport dcReport = efMethods.SelectReport(1004);

                        string filter = "[ProductCode] = '" + productCode + "' and [CurrAccCode] = '" + trInvoiceHeader.CurrAccCode + "'";
                        string activeFilterStr = "[StoreCode] = \'" + Authorization.StoreCode + "\'";
                        FormReportGrid formGrid = new(dcReport.ReportQuery, filter, dcReport, activeFilterStr);
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

        }

        private void gV_InvoiceLine_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            GridView gV = (GridView)sender;

            if (gV is not null)
            {
                if (e.Column != colLastUpdatedDate && e.Column != colLastUpdatedUserName && !e.Column.ReadOnly && e.Column.OptionsColumn.AllowEdit)
                {
                    Object oldvalue = gV.ActiveEditor?.OldEditValue;

                    if (!Object.Equals(e.Value, oldvalue))
                    {
                        string userName = efMethods.SelectCurrAcc(Authorization.CurrAccCode)?.CurrAccDesc;

                        gV.SetRowCellValue(e.RowHandle, colLastUpdatedDate, DateTime.Now);
                        gV.SetRowCellValue(e.RowHandle, colLastUpdatedUserName, userName);
                    }
                }
            }
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

            //if (trInvoiceHeader.ProcessCode == "IT")
            //{
            //   if (trInvoiceHeader.ToWarehouseCode is null)
            //   {
            //      e.ErrorText = "Transfer Deposu qeyd Olunmayıb";
            //      e.Valid = false;
            //   }
            //}

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

                    bool isServis = false;
                    if (product is not null)
                        isServis = product.ProductTypeCode == 3;

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

            if (column == colBarcode && column == col_ProductCode)
            {
                string eValue = (e.Value ??= String.Empty).ToString();

                DcProduct product = null;

                if (column == colBarcode)
                    product = efMethods.SelectProductByBarcode(eValue);
                if (column == col_ProductCode)
                    product = efMethods.SelectProduct(eValue);

                if (product is not null)
                {
                    FillRow(view.FocusedRowHandle, product);
                    view.UpdateCurrentRow(); // For Model/Entity/trInvoiceLine Included TrInvoiceHeader
                    if (dcProcess.ProcessCode == "EX")
                        view.SetRowCellValue(view.FocusedRowHandle, colQty, 1);
                }
                else
                {
                    e.ErrorText = "Belə bir məhsul yoxdur";
                    e.Valid = false;
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
            string productCode = objProductCode?.ToString();

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

            string value = editor.EditValue?.ToString();

            using FormCurrAccList form = new(new byte[] { 3 }, value);

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
            //GridView gV = (GridView)sender;

            //if (gV is not null)
            //{
            //    string userName = efMethods.SelectCurrAcc(Authorization.CurrAccCode)?.CurrAccDesc;
            //    gV.SetRowCellValue(e.RowHandle, colLastUpdatedDate, DateTime.Now);

            //    if (!string.IsNullOrEmpty(userName))
            //        gV.SetRowCellValue(e.RowHandle, colLastUpdatedUserName, userName);
            //}

            SaveInvoice();
        }

        private void gV_InvoiceLine_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {

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

                            TrInvoiceHeader copyTrIH = trIH;
                            copyTrIH.InvoiceHeaderId = quidHead;
                            string temp = trIH.WarehouseCode;
                            copyTrIH.WarehouseCode = trIH.ToWarehouseCode;
                            copyTrIH.ToWarehouseCode = temp;
                            copyTrIH.StoreCode = trIH.CurrAccCode ??= trIH.StoreCode;
                            copyTrIH.IsMainTF = false;

                            switch (entry.State)
                            {
                                case EntityState.Added: context2.TrInvoiceHeaders.Add(copyTrIH); break;
                                case EntityState.Modified: context2.TrInvoiceHeaders.Update(copyTrIH); break;
                                case EntityState.Deleted: context2.TrInvoiceHeaders.Remove(copyTrIH); break;
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

                efMethods.DeletePaymentsByInvoiceId(trInvoiceHeader.InvoiceHeaderId);

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
            trPaymentHeader.ProcessCode = "EX";
            trPaymentHeader.CreatedUserName = Authorization.CurrAccCode;
            trPaymentHeader.OfficeCode = Authorization.OfficeCode;
            trPaymentHeader.StoreCode = Authorization.StoreCode;
            trPaymentHeader.IsMainTF = true;
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
            trPaymentLine.PaymentMethodId = 1;
            trPaymentLine.CurrencyCode = Settings.Default.AppSetting.LocalCurrencyCode;
            trPaymentLine.ExchangeRate = 1f;
            string storeCode = trInvoiceHeader.StoreCode;
            trPaymentLine.CashRegisterCode = efMethods.SelectCashRegByStore(storeCode);
            trPaymentLine.CreatedUserName = Authorization.CurrAccCode;

            return trPaymentLine;
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

                    //GetPrintDialogToWarehouse();

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

        private void SaveSession()
        {
            object warehouseCode = lUE_WarehouseCode.EditValue;
            if (warehouseCode is not null)
            {
                Settings.Default.WarehouseCode = lUE_WarehouseCode.EditValue.ToString();
                Settings.Default.Save();
            }
        }

        private void GetPrintDialogToWarehouse()
        {
            XtraReport report = GetInvoiceReport(reportFileNameInvoiceWare);

            if (report is not null)
            {
                ReportPrintTool printTool = new(report);

                bool? isPrinted = printTool.PrintDialog();

                if (isPrinted is not null)
                {
                    bool printed = Convert.ToBoolean(isPrinted);
                    if (printed)
                    {
                        efMethods.UpdateInvoicePrintCount(trInvoiceHeader.InvoiceHeaderId);
                    }
                }
            }
        }

        private void GetPrintToWarehouse(Guid invoiceHeader, string printerName)
        {
            XtraReport report = GetInvoiceReport(reportFileNameInvoiceWare);
            report.PrinterName = printerName;

            if (report is not null)
            {
                ReportPrintTool printTool = new(report);

                printTool.Print();
                efMethods.UpdateInvoicePrintCount(invoiceHeader);
            }
        }

        private XtraReport GetInvoiceReport(string fileName)
        {
            ReportClass reportClass = new();
            DsMethods dsMethods = new();
            SqlQuery sqlQuerySale = dsMethods.SelectInvoice(trInvoiceHeader.InvoiceHeaderId);
            return reportClass.GetReport("invocie", fileName, new SqlQuery[] { sqlQuerySale });
        }

        private void MakePayment(decimal summaryInvoice, bool autoPayment)
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
            XtraReport xtraReport = GetInvoiceReport(reportFileNameInvoice);

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
                        if (dcProcess.ProcessCode == "EX")
                            efMethods.DeletePaymentsByInvoiceId(trInvoiceHeader.InvoiceHeaderId);
                        else if (MessageBox.Show("Qaimə üzrə olan ödənişləri də silirsiniz? ", "Diqqət", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                            efMethods.DeletePaymentsByInvoiceId(trInvoiceHeader.InvoiceHeaderId);

                    if (efMethods.ExpensesExistByInvoiceId(trInvoiceHeader.InvoiceHeaderId))
                        if (MessageBox.Show("Qaimə üzrə olan xərcləri də Silirsiniz? ", "Diqqət", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                            efMethods.DeleteExpensesByInvoiceId(trInvoiceHeader.InvoiceHeaderId);

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
                efMethods.DeletePaymentsByInvoiceId(trInvoiceHeader.InvoiceHeaderId);
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

                    //GetPrintDialogToWarehouse();

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
            GridView gV = sender as GridView;

            Color readOnlyBackColor = Color.LightGray;
            try
            {
                if (e.RowHandle >= 0 && (!gV.OptionsBehavior.Editable || !e.Column.OptionsColumn.AllowEdit || e.Column.ReadOnly))
                {
                    GridViewInfo viewInfo = gV.GetViewInfo() as GridViewInfo;
                    GridDataRowInfo rowInfo = viewInfo.RowsInfo.GetInfoByHandle(e.RowHandle) as GridDataRowInfo;

                    if (rowInfo == null || (rowInfo != null && rowInfo.ConditionInfo.GetCellAppearance(e.Column) == null))
                    {
                        bool hasrules = false;
                        foreach (GridFormatRule rule in gV.FormatRules)
                        {
                            if (rule.IsFit(e.CellValue, gV.GetDataSourceRowIndex(e.RowHandle)))
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
                if (e.Column.AppearanceCell.Options.UseBackColor && gV.IsCellSelected(e.RowHandle, e.Column))
                    e.Appearance.BackColor = gV.PaintAppearance.SelectedRow.BackColor;
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
            Image image = Image.FromStream(GetInvoiceReportImg(reportFileNameInvoice));
            Clipboard.SetImage(image);
        }

        private MemoryStream GetInvoiceReportImg(string designPath)
        {
            XtraReport report = GetInvoiceReport(reportFileNameInvoice);

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
                    //FillCurrAccCode(curr);
                }
            }
        }

        private void btnEdit_CurrAccCode_InvalidValue(object sender, InvalidValueExceptionEventArgs e)
        {
            e.ErrorText = "Belə bir cari yoxdur";
            e.ExceptionMode = ExceptionMode.DisplayError;
        }

        private void BBI_ModifyInvoice_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (trInvoiceHeader.ProcessCode == "RS")
            {
                bool currAccHasClaims = efMethods.CurrAccHasClaims(Authorization.CurrAccCode, "SaleIsReturn");
                if (!currAccHasClaims)
                {
                    MessageBox.Show("Yetkiniz yoxdur! ");
                    return;
                }
            }
            else if (trInvoiceHeader.ProcessCode == "RP")
            {
                bool currAccHasClaims = efMethods.CurrAccHasClaims(Authorization.CurrAccCode, "PurchaseIsReturn");
                if (!currAccHasClaims)
                {
                    MessageBox.Show("Yetkiniz yoxdur! ");
                    return;
                }
            }

            if (checkEdit_IsReturn.Enabled)
                checkEdit_IsReturn.Enabled = false;
            else
                checkEdit_IsReturn.Enabled = true;
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
                e.Handled = true;
            }
        }

        private void bbi_ItemClick(object sender, ItemClickEventArgs e)
        {
            XtraMessageBox.Show($"\nEnvironment.CurrentDirectory: from \n{Environment.CurrentDirectory}"
            + $"\n\nAppDomain.CurrentDomain.BaseDirectory: \n{AppDomain.CurrentDomain.BaseDirectory}"
            + $"\n\nAppContext.BaseDirectory: \n{AppContext.BaseDirectory}"
            + $"\n\nAssembly.GetEntryAssembly().Location: \n{Assembly.GetEntryAssembly().Location}"
            + $"\n\nPath.GetDirectoryName(Assembly.GetExecutingAssembly().Location): \n{Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}"
            + $"\n\nPath.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName): \n{Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName)}");
        }

        private void LoadLayout()
        {
            //gV_InvoiceLine.OptionsNavigation.EnterMoveNextColumn = false;
            if (dcProcess.ProcessCode != "EX")
            {
                RPG_Control.Visible = true;
                RPG_Payment.Visible = true;
            }

            if (new string[] { "EX", "CI", "CO", "IT" }.Contains(dcProcess.ProcessCode))
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

            string layoutFilePath = Path.Combine(AppContext.BaseDirectory, "Layout Xml Files", "Invoice" + dcProcess.ProcessCode + "Layout.xml");
            if (File.Exists(layoutFilePath))
                gV_InvoiceLine.RestoreLayoutFromXml(layoutFilePath);

            colLastPurchasePrice = gV_InvoiceLine.Columns[nameof(DcProduct.LastPurchasePrice)];
            if (colLastPurchasePrice != null)
            {
                bool currAccHasClaims = efMethods.CurrAccHasClaims(Authorization.CurrAccCode, "Column_LastPurchasePrice");
                if (!currAccHasClaims)
                {
                    colLastPurchasePrice.OptionsColumn.ShowInCustomizationForm = false;
                    colLastPurchasePrice.Visible = false;
                    colBenefit.OptionsColumn.ShowInCustomizationForm = false;
                    colBenefit.Visible = false;
                }
            }

            colBalance.OptionsColumn.ReadOnly = true;
            colLastPurchasePrice.OptionsColumn.ReadOnly = true;
            col_NetAmount.OptionsColumn.ReadOnly = true;
            colNetAmountLoc.OptionsColumn.ReadOnly = true;
            col_Amount.OptionsColumn.ReadOnly = true;
            colAmountLoc.OptionsColumn.ReadOnly = true;


            if (!colNetAmountLoc.Summary.Any(x => x.SummaryType == SummaryItemType.Sum))
                colNetAmountLoc.Summary.AddRange(new GridSummaryItem[] { new GridColumnSummaryItem(SummaryItemType.Sum, "NetAmountLoc", "{0:n2}") });
        }

        private void SaveLayout()
        {
            string fileName = "Invoice" + dcProcess.ProcessCode + "Layout.xml";
            string layoutFileDir = Path.Combine(AppContext.BaseDirectory, "Layout Xml Files");
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
                    menu.Items.Add(CreateItem("Save Layout", menu.Column, null));
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

        private void gC_InvoiceLine_EditorKeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return) // Barcode Scan Device 
            {
                gV_InvoiceLine.SetFocusedRowCellValue(colQty, 1);
                gV_InvoiceLine.MoveNext();
                gV_InvoiceLine.FocusedColumn = colBarcode;
            }
        }

        private void FormInvoice_FormClosing(object sender, FormClosingEventArgs e)
        {
            efMethods.UpdateInvoiceIsOpen(trInvoiceHeader.DocumentNumber, false);
        }

        private void BBI_ReportPriceList_ItemClick(object sender, ItemClickEventArgs e)
        {
            ColumnView View = gC_InvoiceLine.MainView as ColumnView;
            List<TrInvoiceLine> mydata = GetFilteredData<TrInvoiceLine>(View).ToList();

            ReportClass reportClass = new();
            XtraReport xtraReport = reportClass.CreateReport(mydata, "");

            if (xtraReport is not null)
            {
                ReportDesignTool printTool = new(xtraReport);
                printTool.ShowRibbonDesigner();
            }
        }

        public static List<T> GetFilteredData<T>(ColumnView view)
        {
            List<T> resp = new List<T>();
            for (int i = 0; i < view.DataRowCount; i++)
                resp.Add((T)view.GetRow(i));

            return resp;
        }

        private void BBI_exportXLSX_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                XtraSaveFileDialog sFD = new();
                sFD.Filter = "Excel Faylı|*.xlsx";
                sFD.Title = "Excel Faylı Yadda Saxla";
                sFD.FileName = dcProcess.ProcessDesc;
                sFD.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                sFD.DefaultExt = "*.xlsx";

                var fileName = Invoke((Func<string>)(() =>
                {
                    if (sFD.ShowDialog() == DialogResult.OK)
                    {
                        XlsxExportOptionsEx expOpt = new()
                        {
                            ExportMode = XlsxExportMode.SingleFile,
                            TextExportMode = TextExportMode.Value,
                            AllowLookupValues = DefaultBoolean.True,
                        };

                        gC_InvoiceLine.ExportToXlsx(sFD.FileName, expOpt);

                        if (XtraMessageBox.Show(this, "Açmaq istəyirsiz?", "Diqqət", MessageBoxButtons.OKCancel) == DialogResult.OK)
                        {
                            Process p = new();
                            p.StartInfo = new ProcessStartInfo(sFD.FileName) { UseShellExecute = true };
                            p.Start();
                        }

                        return "Ok";
                    }
                    else
                        return "Fail";
                }));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void BBI_ImportExcel_ItemClick(object sender, ItemClickEventArgs e)
        {
            OpenFileDialog dialog = new();
            dialog.Filter = "Excel Files (*.xls;*.xlsx)|*.xls;*.xlsx|" +
                            "All files (*.*)|*.*";
            dialog.Title = "Excel faylı seçin.";

            DialogResult dr = dialog.ShowDialog();
            if (dr == DialogResult.OK)
            {
                SplashScreenManager.ShowForm(this, typeof(WaitForm1), true, true, false);

                ExcelDataSource excelDataSource = new();
                excelDataSource.FileName = dialog.FileName;

                ExcelWorksheetSettings excelWorksheetSettings = new(0);
                //ExcelWorksheetSettings excelWorksheetSettings = new(0, "A1:A10000");
                //excelWorksheetSettings.WorksheetName = "10QK";

                ExcelSourceOptions excelOptions = new();
                excelOptions.ImportSettings = excelWorksheetSettings;
                excelOptions.SkipHiddenRows = false;
                excelOptions.SkipHiddenColumns = false;
                excelOptions.UseFirstRowAsHeader = true;
                excelDataSource.SourceOptions = excelOptions;

                excelDataSource.Fill();

                DataTable dt = new();
                dt = ToDataTableFromExcelDataSource(excelDataSource);

                string errorCodes = "";
                double rowCount = 0;
                foreach (DataRow row in dt.Rows)
                {
                    int i = Convert.ToInt32(rowCount / dt.Rows.Count * 100);
                    SplashScreenManager.Default.SendCommand(WaitForm1.WaitFormCommand.SetProgress, i);
                    SplashScreenManager.Default.SetWaitFormDescription(i + "%");
                    rowCount++;

                    string captionProductCode = ReflectionExt.GetDisplayName<TrInvoiceLine>(x => x.ProductCode);
                    string productCode = row[captionProductCode].ToString();

                    if (!string.IsNullOrEmpty(productCode))
                    {
                        DcProduct product = efMethods.SelectProduct(productCode);

                        if (product is not null)
                        {
                            object objInvoiceHeadId = gV_InvoiceLine.GetRowCellValue(GridControl.NewItemRowHandle, col_InvoiceHeaderId);
                            if (objInvoiceHeadId is null) // Check InitNewRow
                                gV_InvoiceLine.AddNewRow();

                            FillRow(GridControl.NewItemRowHandle, product);

                            foreach (DataColumn column in dt.Columns)
                            {
                                try
                                {
                                    string captionQty = ReflectionExt.GetDisplayName<TrInvoiceLine>(x => x.Qty);
                                    if (column.ColumnName == captionQty)
                                    {
                                        GridColumn qty = CustomExtensions.ProcessDir(trInvoiceHeader.ProcessCode) == "In" ? colQtyIn : colQtyOut;
                                        gV_InvoiceLine.SetRowCellValue(GridControl.NewItemRowHandle, qty, row[captionQty].ToString());
                                    }

                                    string captionLineDesc = ReflectionExt.GetDisplayName<TrInvoiceLine>(x => x.LineDescription);
                                    if (column.ColumnName == captionLineDesc)
                                        gV_InvoiceLine.SetRowCellValue(GridControl.NewItemRowHandle, col_LineDesc, row[captionLineDesc].ToString());

                                    if (dcProcess.ProcessCode != "IT")
                                    {
                                        string captionPrice = ReflectionExt.GetDisplayName<TrInvoiceLine>(x => x.Price);
                                        if (column.ColumnName == captionPrice)
                                            gV_InvoiceLine.SetRowCellValue(GridControl.NewItemRowHandle, col_Price, row[captionPrice].ToString());

                                        string captionCurrency = ReflectionExt.GetDisplayName<TrInvoiceLine>(x => x.CurrencyCode);
                                        if (column.ColumnName == captionCurrency)
                                        {
                                            if (!string.IsNullOrEmpty(row[captionCurrency].ToString()))
                                            {
                                                DcCurrency currency = efMethods.SelectCurrency(row[captionCurrency].ToString());
                                                if (currency is null)
                                                    currency = efMethods.SelectCurrencyByName(row[captionCurrency].ToString());

                                                if (currency is not null)
                                                {
                                                    gV_InvoiceLine.SetRowCellValue(GridControl.NewItemRowHandle, colCurrencyCode, currency.CurrencyCode);
                                                    gV_InvoiceLine.SetRowCellValue(GridControl.NewItemRowHandle, colExchangeRate, currency.ExchangeRate);
                                                }
                                                else
                                                    errorCodes += captionCurrency + ": " + row[captionCurrency].ToString() + "\n";
                                            }
                                        }

                                        string captionExRate = ReflectionExt.GetDisplayName<TrInvoiceLine>(x => x.ExchangeRate);
                                        if (column.ColumnName == captionExRate)
                                            gV_InvoiceLine.SetRowCellValue(GridControl.NewItemRowHandle, colExchangeRate, row[captionExRate].ToString());

                                        string captionPosDiscount = ReflectionExt.GetDisplayName<TrInvoiceLine>(x => x.PosDiscount);
                                        if (column.ColumnName == captionPosDiscount)
                                            gV_InvoiceLine.SetRowCellValue(GridControl.NewItemRowHandle, col_PosDiscount, row[captionPosDiscount].ToString());
                                    }
                                }
                                catch (ArgumentException ae)
                                {
                                    MessageBox.Show("Xəta No: 256545 \n" + ae.Message, "Import xetası");
                                }
                            }

                            gV_InvoiceLine.UpdateCurrentRow();
                        }
                        else
                            errorCodes += captionProductCode + ": " + row[captionProductCode].ToString() + "\n";
                    }
                }

                SplashScreenManager.CloseForm(false);
                if (!string.IsNullOrEmpty(errorCodes))
                    MessageBox.Show("Aşağıdakı kodlar üzrə Dəyər tapılmadı \n" + errorCodes, "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FillRow(int rowHandle, DcProduct product)
        {
            gV_InvoiceLine.SetRowCellValue(rowHandle, col_ProductCode, product.ProductCode);
            gV_InvoiceLine.SetRowCellValue(rowHandle, colLastPurchasePrice, product.LastPurchasePrice);


            decimal priceProduct = 0;

            if (dcProcess.ProcessCode == "RS")
                if (Settings.Default.AppSetting.UsePriceList)
                    priceProduct = efMethods.SelectPrice("RS", product.ProductCode);
                else
                    priceProduct = product.WholesalePrice;

            if (dcProcess.ProcessCode == "RP")
                if (Settings.Default.AppSetting.UsePriceList)
                    priceProduct = efMethods.SelectPrice("RP", product.ProductCode);
                else
                    priceProduct = product.PurchasePrice;

            //decimal priceProduct = dcProcess.ProcessCode == "RS" ? product.WholesalePrice : (dcProcess.ProcessCode == "RP" ? product.PurchasePrice : 0);
            decimal priceInvoice = Convert.ToInt32(gV_InvoiceLine.GetRowCellValue(rowHandle, col_Price));
            if (priceInvoice == 0)
                gV_InvoiceLine.SetRowCellValue(rowHandle, col_Price, priceProduct);
        }

        private static string GetProductDescWide(DcProduct product)
        {
            var idList = new[] { 4, 5 };
            string arr = "";
            foreach (var item in product?.TrProductFeatures.Where(f => idList.Contains(f.FeatureTypeId)))
                arr += " " + item.FeatureCode;
            string productDescWide = product.HierarchyCode + " " + product.ProductDesc + arr;
            return productDescWide;
        }

        public DataTable ToDataTableFromExcelDataSource(ExcelDataSource excelDataSource)
        {
            IList list = ((IListSource)excelDataSource).GetList();
            DevExpress.DataAccess.Native.Excel.DataView dataView = (DevExpress.DataAccess.Native.Excel.DataView)list;
            List<PropertyDescriptor> props = dataView.Columns.ToList<PropertyDescriptor>();

            DataTable dt = new();
            for (int i = 0; i < props.Count; i++)
            {
                PropertyDescriptor prop = props[i];
                dt.Columns.Add(prop.Name, prop.PropertyType);
            }
            object[] values = new object[props.Count];
            foreach (ViewRow item in list)
            {
                for (int i = 0; i < values.Length; i++)
                {
                    values[i] = props[i].GetValue(item);
                }
                dt.Rows.Add(values);
            }
            return dt;
        }

        private void lUE_StoreCode_EditValueChanged(object sender, EventArgs e)
        {
            string storeCode = lUE_StoreCode.EditValue.ToString();
            List<DcWarehouse> dcWarehouses = efMethods.SelectWarehousesByStore(storeCode);
            lUE_WarehouseCode.Properties.DataSource = dcWarehouses;

            if (!dcWarehouses.Any(x => x.WarehouseCode == trInvoiceHeader?.WarehouseCode) && trInvoiceHeader is not null)
                trInvoiceHeader.WarehouseCode = null;

            if (dcWarehouses is not null && trInvoiceHeader is not null)
            {
                DcWarehouse dcWarehouse = dcWarehouses.Where(x => x.IsDefault == true).FirstOrDefault();
                if (dcWarehouse is not null && trInvoiceHeader?.WarehouseCode is null)
                {
                    trInvoiceHeader.WarehouseCode = dcWarehouse.WarehouseCode;
                    lUE_WarehouseCode.EditValue = dcWarehouse.WarehouseCode;
                }
            }
        }

        private void btnEdit_CurrAccCode_EditValueChanged(object sender, EventArgs e)
        {
            DcCurrAcc curr = efMethods.SelectCurrAcc(btnEdit_CurrAccCode.EditValue?.ToString());

            if (curr is not null && trInvoiceHeader is not null)
            {
                trInvoiceHeader.CurrAccCode = curr.CurrAccCode;
                lbl_CurrAccDesc.Text = curr.CurrAccDesc + " " + curr.FirstName + " " + curr.LastName;

                string storeCode = trInvoiceHeader.CurrAccCode;
                List<DcWarehouse> dcWarehouses = efMethods.SelectWarehousesByStore(storeCode);

                lUE_ToWarehouseCode.Properties.DataSource = dcWarehouses;

                if (!dcWarehouses.Any(x => x.WarehouseCode == trInvoiceHeader?.ToWarehouseCode))
                    trInvoiceHeader.ToWarehouseCode = null;

                if (dcWarehouses is not null)
                {
                    DcWarehouse dcWarehouse = dcWarehouses.Where(x => x.IsDefault == true).FirstOrDefault();

                    if (dcWarehouse is not null && trInvoiceHeader?.ToWarehouseCode is null)
                    {
                        trInvoiceHeader.ToWarehouseCode = dcWarehouse.WarehouseCode;
                        lUE_ToWarehouseCode.EditValue = dcWarehouse.WarehouseCode;
                    }
                }
            }

        }

        private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
        {
            MemoryStream memoryStream = GetInvoiceReportImg(reportFileNameInvoice);

            string phoneNum = efMethods.SelectCurrAcc(trInvoiceHeader.CurrAccCode).PhoneNum;
            string address = efMethods.SelectCurrAcc(trInvoiceHeader.CurrAccCode).Address;

            byte[] imageBytes = memoryStream.ToArray();
            string AsBase64String = Convert.ToBase64String(imageBytes);

            if (!string.IsNullOrEmpty(address))
                phoneNum = address;

            UltramsgClass twilioClass = new();
            UltramsgResponce responce = twilioClass.SendWhatsapp(phoneNum, "image", AsBase64String);

            if (responce.message == "ok")
            {
                efMethods.UpdateInvoiceIsSent(trInvoiceHeader.InvoiceHeaderId);
                checkEdit_IsSent.EditValue = true;
                MessageBox.Show("Göndərildi", "İnfo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show(responce.message + "\n" + responce.error, "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void BBI_TwilioSave_ItemClick(object sender, ItemClickEventArgs e)
        {
            efMethods.UpdateAppSettingTwilioInstance(BEI_TwilioInstance.EditValue.ToString());
            efMethods.UpdateAppSettingTwilioToken(BEI_TwilioToken.EditValue.ToString());

            //AppSetting appSetting = efMethods.SelectAppSetting();
            Settings.Default.AppSetting.TwilioInstanceId = BEI_TwilioInstance.EditValue.ToString();
            Settings.Default.AppSetting.TwilioToken = BEI_TwilioToken.EditValue.ToString();
            Settings.Default.Save();
        }

        private async void BBI_ReportPrintFast_ItemClick(object sender, ItemClickEventArgs e)
        {
            await PrintFast(settingStore.PrinterName);
        }

        private async Task PrintFast(string printerName)
        {
            alertControl1.Show(this, "Print Göndərilir...", "Printer: " + printerName, "", (Image)null, null);

            if (trInvoiceHeader is not null)
                await Task.Run(() => GetPrintToWarehouse(trInvoiceHeader.InvoiceHeaderId, printerName));
            else MessageBox.Show("Çap olunmaq üçün qaimə yoxdur");

            Task task = Task.Run((Action)ShowPrintCount);

            alertControl1.Show(this, "Print Göndərildi.", "Printer: " + printerName, "", (Image)null, null);
        }

        private void repoCBE_PrinterName_EditValueChanged(object sender, EventArgs e)
        {
            ComboBoxEdit comboBox = (ComboBoxEdit)sender;
            settingStore.PrinterName = comboBox.EditValue.ToString();
        }

        private void BBI_PrintSettingSave_ItemClick(object sender, ItemClickEventArgs e)
        {
            efMethods.UpdateStoreSettingPrinterName(BEI_PrinterName.EditValue.ToString());
        }

        private void barButtonItem3_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void gV_InvoiceLine_RowStyle(object sender, RowStyleEventArgs e)
        {
            GridView view = sender as GridView;

            if (e.RowHandle >= 0)
            {
                object isReturn = view.GetRowCellValue(e.RowHandle, view.Columns["Benefit"]);

                if (isReturn is not null)
                {
                    decimal value = (decimal)isReturn;

                    if (value <= 0 && dcProcess.ProcessCode == "RS" && trInvoiceHeader.IsReturn == false)
                        e.Appearance.ForeColor = Color.Red;
                }
            }
        }

        private void Btn_info_ItemClick(object sender, ItemClickEventArgs e)
        {
            DcCurrAcc createdCurrAcc = efMethods.SelectCurrAcc(trInvoiceHeader.CreatedUserName);
            DcCurrAcc updatedCurrAcc = efMethods.SelectCurrAcc(trInvoiceHeader.LastUpdatedUserName);

            string lastUpdatedDate = efMethods.SelectInvoiceLines(trInvoiceHeader.InvoiceHeaderId).OrderByDescending(x => x.LastUpdatedDate).FirstOrDefault().LastUpdatedDate.ToString();
            string lastUpdatedUserName = efMethods.SelectInvoiceLines(trInvoiceHeader.InvoiceHeaderId).OrderByDescending(x => x.LastUpdatedDate).FirstOrDefault().LastUpdatedUserName.ToString();

            string createdUserName = ReflectionExt.GetDisplayName<TrInvoiceHeader>(x => x.CreatedUserName) + ": " + createdCurrAcc.CurrAccDesc + " " + createdCurrAcc.FirstName;
            string createdDate = ReflectionExt.GetDisplayName<TrInvoiceHeader>(x => x.CreatedDate) + ": " + trInvoiceHeader.CreatedDate.ToString();
            string updatedUserName = ReflectionExt.GetDisplayName<TrInvoiceHeader>(x => x.LastUpdatedUserName) + ": " + lastUpdatedUserName;
            string updatedDate = ReflectionExt.GetDisplayName<TrInvoiceHeader>(x => x.LastUpdatedDate) + ": " + lastUpdatedDate;

            XtraMessageBox.Show(createdUserName + "\n\n" + createdDate + "\n\n" + updatedUserName + "\n\n" + updatedDate, "Məlumat", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BBI_picture_ItemClick(object sender, ItemClickEventArgs e)
        {
            FormImage formPictures = new(btnEdit_DocNum.EditValue?.ToString());
            formPictures.ShowDialog();
        }

        private void BBI_Print_ItemClick(object sender, ItemClickEventArgs e)
        {
            XtraReport xtraReport = GetInvoiceReport(reportFileNameInvoice);
            xtraReport.PrinterName = settingStore.PrinterName;

            if (xtraReport is not null)
            {
                ReportPrintTool printTool = new(xtraReport);
                printTool.PrintDialog();
            }
        }

        private void barButtonItem2_ItemClick_1(object sender, ItemClickEventArgs e)
        {
            MessageBox.Show(settingStore.PrinterName);
        }

        private void barButtonItem4_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void popupMenuPrinters_BeforePopup(object sender, CancelEventArgs e)
        {
            PopupMenu menu = (sender as PopupMenu);

            menu.ItemLinks.Clear();

            foreach (string printer in PrinterSettings.InstalledPrinters)
            {
                BarButtonItem BBI = new();
                BBI.Caption = printer;
                BBI.Name = printer;
                BBI.ImageOptions.SvgImage = svgImageCollection1["print"]; ;
                BBI.ItemClick += async (sender, e) =>
                {
                    await PrintFast(printer);
                };

                menu.AddItem(BBI);

            }
            e.Cancel = false;
        }

        private void gV_InvoiceLine_CustomUnboundColumnData(object sender, CustomColumnDataEventArgs e)
        {
            GridView view = sender as GridView;
            int rowInd = view.GetRowHandle(e.ListSourceRowIndex);
            object obj = view.GetRowCellValue(rowInd, col_ProductCode);

            if (obj is not null)
            {

                string productCode = obj?.ToString();
                DcProduct dcProduct = subContext.DcProducts // more fast query
                                        .Include(x => x.DcHierarchy)
                                        .Include(x => x.TrProductFeatures)
                                        .FirstOrDefault(x => x.ProductCode == productCode);

                if (dcProduct is not null && e.IsGetData)
                {
                    dcProduct.Balance = subContext.TrInvoiceLines.Where(x => x.ProductCode == productCode).Sum(x => x.QtyIn - x.QtyOut);

                    if (e.Column == col_ProductDesc)
                    {
                        string productDescWide = GetProductDescWide(dcProduct);
                        e.Value = productDescWide;
                    }

                    if (e.Column == colBalance)
                    {
                        e.Value = dcProduct.Balance;
                    }

                    //if (e.Column == colLastPurchasePrice)
                    //{
                    //    e.Value = dcProduct.LastPurchasePrice;
                    //}

                }
            }
        }

        private void BBI_InvoiceExpenses_ItemClick(object sender, ItemClickEventArgs e)
        {
            FormInvoice formInvoice = new("EX", new byte[] { 2, 3 }, trInvoiceHeader.InvoiceHeaderId);
            formInvoice.WindowState = FormWindowState.Normal; ;
            formInvoice.ShowDialog();
        }
    }
}