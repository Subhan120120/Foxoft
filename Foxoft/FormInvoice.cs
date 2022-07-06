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
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Foxoft
{
    public partial class FormInvoice : RibbonForm
    {
        Badge badge1;
        Badge badge2;
        AdornerUIManager adornerUIManager1;
        public AdornerElement[] Badges { get { return new AdornerElement[] { badge1, badge2 }; } }

        string designFolder = @"C:\Users\Administrator\Documents\";

        private TrInvoiceHeader trInvoiceHeader;
        public string processCode;
        private byte productTypeCode;
        private byte currAccTypeCode;
        private EfMethods efMethods = new EfMethods();
        private subContext dbContext;
        Guid invoiceHeaderId;
        public FormInvoice(string processCode, byte productTypeCode, byte currAccTypeCode)
        {
            InitializeComponent();
            //gV_InvoiceLine.OptionsNavigation.AutoFocusNewRow = true;
            //bBI_SaveQuit.ItemShortcut = new BarShortcut(Keys.Escape);

            this.processCode = processCode;
            this.productTypeCode = productTypeCode;
            this.currAccTypeCode = currAccTypeCode;

            this.Text = efMethods.SelectProcessName(processCode);

            if (CustomExtensions.ProcessDir(processCode) == "In")
                colQtyOut.Visible = false;
            else
                colQtyIn.Visible = false;

            lUE_OfficeCode.Properties.DataSource = efMethods.SelectOffices();
            lUE_StoreCode.Properties.DataSource = efMethods.SelectStores();
            lUE_WarehouseCode.Properties.DataSource = efMethods.SelectWarehouses();
            repoLUE_CurrencyCode.DataSource = efMethods.SelectCurrencies();

            adornerUIManager1 = new AdornerUIManager(components);
            badge1 = new Badge();
            badge2 = new Badge();
            adornerUIManager1.Elements.Add(badge1);
            adornerUIManager1.Elements.Add(badge2);
            badge1.TargetElement = bBI_Save;
            //badge2.TargetElement = RibbonPage_Invoice;

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

            dbContext.TrInvoiceHeaders.Where(x => x.InvoiceHeaderId == invoiceHeaderId)
                                      .Load();
            trInvoiceHeadersBindingSource.DataSource = dbContext.TrInvoiceHeaders.Local.ToBindingList();

            trInvoiceHeader = trInvoiceHeadersBindingSource.AddNew() as TrInvoiceHeader;


            lbl_InvoicePaidSum.Text = "";

            dbContext.TrInvoiceLines.Where(x => x.InvoiceHeaderId == trInvoiceHeader.InvoiceHeaderId)
                                    .LoadAsync()
                                    .ContinueWith(loadTask => trInvoiceLinesBindingSource.DataSource = dbContext.TrInvoiceLines.Local.ToBindingList(), TaskScheduler.FromCurrentSynchronizationContext());

            dataLayoutControl1.isValid(out List<string> errorList);
        }

        private void trInvoiceHeadersBindingSource_AddingNew(object sender, AddingNewEventArgs e)
        {
            TrInvoiceHeader invoiceHeader = new TrInvoiceHeader();
            invoiceHeader.InvoiceHeaderId = invoiceHeaderId;
            string NewDocNum = efMethods.GetNextDocNum(this.processCode, "DocumentNumber", "TrInvoiceHeaders");
            invoiceHeader.DocumentNumber = NewDocNum;
            invoiceHeader.DocumentDate = DateTime.Now;
            invoiceHeader.DocumentTime = TimeSpan.Parse(DateTime.Now.ToString("HH:mm:ss"));
            invoiceHeader.ProcessCode = this.processCode;
            invoiceHeader.OfficeCode = Authorization.OfficeCode;
            invoiceHeader.StoreCode = Authorization.StoreCode;
            invoiceHeader.CreatedUserName = Authorization.CurrAccCode;
            invoiceHeader.WarehouseCode = Settings.Default.WarehouseCode;
            if (processCode == "RS")
                invoiceHeader.CurrAccCode = "111";

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

            if (trInvoiceHeader != null && dbContext != null && dataLayoutControl1.isValid(out List<string> errorList))
            {
                int count = efMethods.SelectInvoiceLines(trInvoiceHeader.InvoiceHeaderId).Count;
                if (count > 0)
                    SaveInvoice();
            }
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
            using (FormInvoiceHeaderList form = new FormInvoiceHeaderList(this.processCode))
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
                                      .Where(x => x.InvoiceHeaderId == InvoiceHeaderId).Load();

            LocalView<TrInvoiceHeader> lV_invoiceHeader = dbContext.TrInvoiceHeaders.Local;

            //if (!lV_invoiceHeader.Any(x => Object.ReferenceEquals(x.DcCurrAcc, null)))
            //    lV_invoiceHeader.ForEach(x => x.CurrAccDesc = x.DcCurrAcc.CurrAccDesc + " " + x.DcCurrAcc.FirstName + " " + x.DcCurrAcc.LastName);

            trInvoiceHeadersBindingSource.DataSource = lV_invoiceHeader.ToBindingList();

            dbContext.TrInvoiceLines.Include(o => o.DcProduct)
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


            dataLayoutControl1.isValid(out List<string> errorList);
            CalcPaidAmount();
        }

        private void CalcPaidAmount()
        {
            decimal paidSum = efMethods.SelectPaymentLinesSum(trInvoiceHeader.InvoiceHeaderId) / (decimal)1.703 * (CustomExtensions.ProcessDir(processCode) == "In" ? (-1) : 1);
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
                    trInvoiceHeader.CurrAccCode = form.dcCurrAcc.CurrAccCode;
                    CurrAccDescTextEdit.Text = form.dcCurrAcc.CurrAccDesc + " " + form.dcCurrAcc.FirstName + " " + form.dcCurrAcc.LastName;
                }
            }
        }

        private void gV_InvoiceLine_InitNewRow(object sender, InitNewRowEventArgs e)
        {
            //GridView gv = sender as GridView;

            gV_InvoiceLine.SetRowCellValue(e.RowHandle, col_InvoiceHeaderId, trInvoiceHeader.InvoiceHeaderId);
            gV_InvoiceLine.SetRowCellValue(e.RowHandle, col_InvoiceLineId, Guid.NewGuid());
            gV_InvoiceLine.SetRowCellValue(e.RowHandle, CustomExtensions.ProcessDir(processCode) == "In" ? colQtyIn : colQtyOut, 1);
            gV_InvoiceLine.SetRowCellValue(e.RowHandle, colCreatedDate, DateTime.Now);
            gV_InvoiceLine.SetRowCellValue(e.RowHandle, colCreatedUserName, Authorization.CurrAccCode);
        }

        private void gC_InvoiceLine_KeyDown(object sender, KeyEventArgs e)
        {
            GridControl gC = sender as GridControl;
            GridView gV = gC.MainView as GridView;

            if (e.KeyCode == Keys.Delete)
            {
                if (MessageBox.Show("Sətir Silinsin?", "Təsdiqlə", MessageBoxButtons.YesNo) != DialogResult.Yes)
                    return;

                gV.DeleteSelectedRows();
            }

            if (e.KeyCode == Keys.F1)
            {
                gV_InvoiceLine.FocusedRowHandle = GridControl.NewItemRowHandle;
            }

            if (e.KeyCode == Keys.F2)
            {
                gV_InvoiceLine.FocusedColumn = col_ProductCode;
                gV_InvoiceLine.ShowEditor();
                if (gV_InvoiceLine.ActiveEditor is ButtonEdit)
                    SelectProduct(gV_InvoiceLine.ActiveEditor);

                gV_InvoiceLine.CloseEditor();
                e.Handled = true;
            }

            if (e.KeyCode == Keys.F9 && gV.SelectedRowsCount > 0)
            {
                object productCode = gV.GetFocusedRowCellValue(col_ProductCode);
                if (productCode != null)
                {
                    DcReport dcReport = efMethods.SelectReport(1005);

                    string qryMaster = "Select * from ( " + dcReport.ReportQuery + ") as master";

                    string filter = " where [Məhsul Kodu] = '" + productCode + "' ";

                    FormReportGrid formGrid = new FormReportGrid(qryMaster + filter, dcReport.ReportId);
                    formGrid.Text = dcReport.ReportName;
                    formGrid.Show();
                }
            }

            if (e.KeyCode == Keys.F10 && gV.SelectedRowsCount > 0)
            {
                object productCode = gV.GetFocusedRowCellValue(col_ProductCode);
                if (productCode != null)
                {
                    DcReport dcReport = efMethods.SelectReport(1004);

                    string qryMaster = "Select * from ( " + dcReport.ReportQuery + ") as master";

                    string filter = " where [Məhsul Kodu] = '" + productCode + "' ";

                    FormReportGrid formGrid = new FormReportGrid(qryMaster + filter, dcReport.ReportId);
                    formGrid.Text = dcReport.ReportName;
                    formGrid.Show();
                }
            }
        }

        private void gV_InvoiceLine_CellValueChanging(object sender, CellValueChangedEventArgs e)
        {
            //CalcRowLocNetAmount(e);
        }

        private void gV_InvoiceLine_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            //CalcRowLocNetAmount(e);
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
            #region Comment
            //GridView view = sender as GridView;
            //decimal val = Convert.ToDecimal(view.GetRowCellValue(e.RowHandle, colQty));
            //if (val < 10)
            //{
            //    //e.ErrorText = "Error absh verdi";
            //    e.Valid = false;
            //    view.SetColumnError(colQty, "Deyer 10dan az ola bilmez");
            //} 
            #endregion
        }

        private void repoBtnEdit_ProductCode_ButtonPressed(object sender, ButtonPressedEventArgs e)
        {
            SelectProduct(sender);
        }

        private void repoBtnEdit_SalesPersonCode_ButtonPressed(object sender, ButtonPressedEventArgs e)
        {
            SelectSalesPerson(sender);
        }

        BaseEdit editor;
        private void gridView_ShownEditor(object sender, EventArgs e)
        {
            GridView view = sender as GridView;
            editor = view.ActiveEditor;
            editor.DoubleClick += editor_DoubleClick;
        }

        void gridView_HiddenEditor(object sender, EventArgs e)
        {
            editor.DoubleClick -= editor_DoubleClick;
            editor = null;
        }

        private void gV_InvoiceLine_DoubleClick(object sender, EventArgs e)
        {
            //DXMouseEventArgs ea = e as DXMouseEventArgs;
            //GridView view = sender as GridView;
            //GridHitInfo info = view.CalcHitInfo(ea.Location);
            //info.Column
            //if (info.InRow || info.InRowCell)
            //{
            //    string colCaption = info.Column == null ? "N/A" : info.Column.GetCaption();
            //    MessageBox.Show(string.Format("DoubleClick on row: {0}, column: {1}.", info.RowHandle, colCaption));
            //}
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
                //string colCaption = info.Column == null ? "N/A" : info.Column.GetCaption();
                //MessageBox.Show(string.Format("DoubleClick on row: {0}, column: {1}.", info.RowHandle, colCaption));
            }
        }

        private void SelectSalesPerson(object sender)
        {
            ButtonEdit editor = (ButtonEdit)sender;
            //int buttonIndex = editor.Properties.Buttons.IndexOf(e.Button);
            //if (buttonIndex == 0)
            //{
            using (FormCurrAccList form = new FormCurrAccList(0))
            {
                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    editor.EditValue = form.dcCurrAcc.CurrAccCode;
                }
            }
            //}
        }

        private void SelectProduct(object sender)
        {
            string productCode = "";
            if (gV_InvoiceLine.GetFocusedRowCellValue("ProductCode") != null)
                productCode = gV_InvoiceLine.GetFocusedRowCellValue("ProductCode").ToString();

            ButtonEdit editor = (ButtonEdit)sender;
            //int buttonIndex = editor.Properties.Buttons.IndexOf(e.Button);
            //if (buttonIndex == 0)
            //{
            using (FormProductList form = new FormProductList(productTypeCode, productCode))
            {
                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    editor.EditValue = form.dcProduct.ProductCode;

                    gV_InvoiceLine.SetFocusedRowCellValue(col_ProductCode, form.dcProduct.ProductCode);
                    gV_InvoiceLine.SetFocusedRowCellValue(col_ProductDesc, form.dcProduct.ProductDesc);

                    double price = this.processCode == "RS" ? form.dcProduct.RetailPrice : (this.processCode == "RP" ? form.dcProduct.PurchasePrice : 0);
                    gV_InvoiceLine.SetFocusedRowCellValue(col_Price, price);

                    //CalcRowLocNetAmount(new CellValueChangedEventArgs(gV_InvoiceLine.FocusedRowHandle, col_Price, price));
                }
            }

            gV_InvoiceLine.UpdateCurrentRow();
            //}
        }

        private void gV_InvoiceLine_InvalidRowException(object sender, InvalidRowExceptionEventArgs e)
        {
            //e.ExceptionMode = ExceptionMode.DisplayError;
            //e.ErrorText = "Deyer 10dan az ola bilmez";
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
            //for (int i = 0; i < gV_InvoiceLine.DataRowCount; i++)
            //{
            //    //MakeReturnIsNegativ(i);
            //}
            //if (!efMethods.InvoiceHeaderExist(trInvoiceHeader.InvoiceHeaderId))//if invoiceHeader doesnt exist
            //    efMethods.InsertInvoiceHeader(trInvoiceHeader);

            efMethods.UpdatePaymentsCurrAccCode(trInvoiceHeader.InvoiceHeaderId, trInvoiceHeader.CurrAccCode);

            try
            {
                dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Daxil Etdiyiniz Məlumatlar Əsaslı Deyil ! \n \n {ex}");
            }

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
                decimal summaryInvoice = CalcSumInvoice();

                if (summaryInvoice != 0)
                {
                    SaveInvoice();

                    MakePayment(summaryInvoice);

                    GetPrint();

                    ClearControlsAddNew();
                }
                else if (XtraMessageBox.Show("Ödəmə 0a bərabərdir! \n Fakturaya qayıtmaq istəyirsiz? ", "Diqqət", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                {
                    ClearControlsAddNew();
                }
            }
            else
            {
                string combinedString = errorList.Aggregate((x, y) => x + "" + y);
                XtraMessageBox.Show(combinedString);
            }
        }

        private decimal CalcSumInvoice()
        {
            decimal summaryNetAmount = 0;

            for (int i = 0; i < gV_InvoiceLine.DataRowCount; i++)
            {
                decimal netAmount = Convert.ToDecimal(gV_InvoiceLine.GetRowCellValue(i, colNetAmountLoc));
                summaryNetAmount += netAmount;
            }

            //if ((bool)CheckEdit_IsReturn.EditValue)
            //    summaryNetAmount *= (-1);
            //if (CustomExtensions.ProcessDir(processCode) != "In")
            //    summaryNetAmount *= (-1);

            return summaryNetAmount;
        }

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

            string designPath = designFolder + "InvoiceRS_A5.repx";

            if (!File.Exists(designPath))
                designPath = reportClass.SelectDesign();
            if (File.Exists(designPath))
            {
                XtraReport report = reportClass.CreateReport(efMethods.SelectInvoiceLineForReport(trInvoiceHeader.InvoiceHeaderId), designPath);

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
            //}
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
            string designPath = designFolder + "InvoiceRS_A5.repx";

            if (!File.Exists(designPath))
                designPath = reportClass.SelectDesign();

            if (File.Exists(designPath))
            {
                DsMethods dsMethods = new DsMethods();
                SqlDataSource dataSource = new SqlDataSource(new CustomStringConnectionParameters(subConnString));
                SqlQuery sqlQuerySale = dsMethods.SelectInvoice(trInvoiceHeader.InvoiceHeaderId);
                dataSource.Name = "Invoice";
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
            string designPath = designFolder + "InvoiceRS_A5.repx";

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
                decimal summaryInvoice = CalcSumInvoice();
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
                decimal summaryInvoice = CalcSumInvoice();
                if (summaryInvoice != 0)
                {
                    SaveInvoice();
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

        private void repoLUE_Currency_EditValueChanged(object sender, EventArgs e)
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
                decimal summaryInvoice = CalcSumInvoice();

                if (summaryInvoice != 0)
                {
                    SaveInvoice();

                    MakePayment(summaryInvoice);

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
    }
}