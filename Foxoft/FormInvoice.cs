using DevExpress.Data;
using DevExpress.DataAccess.ConnectionParameters;
using DevExpress.DataAccess.Sql;
using DevExpress.Utils;
using DevExpress.Utils.Extensions;
using DevExpress.Utils.VisualEffects;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
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
        string designFolder = @"C:\Users\Administrator\Documents\";

        private TrInvoiceHeader trInvoiceHeader;
        public string processCode;
        private byte productTypeCode;
        private byte currAccTypeCode;
        private EfMethods efMethods = new EfMethods();
        private subContext dbContext;

        public FormInvoice(string processCode, byte productTypeCode, byte currAccTypeCode)
        {
            InitializeComponent();

            this.processCode = processCode;
            this.productTypeCode = productTypeCode;
            this.currAccTypeCode = currAccTypeCode;

            if (CustomExtensions.ProcessDir(processCode) == "In")
                colQtyOut.Visible = false;
            else
                colQtyIn.Visible = false;

            lUE_OfficeCode.Properties.DataSource = efMethods.SelectOffices();
            lUE_StoreCode.Properties.DataSource = efMethods.SelectStores();
            lUE_WarehouseCode.Properties.DataSource = efMethods.SelectWarehouses();
            repoLUE_Currency.DataSource = efMethods.SelectCurrencies();


            adornerUIManager1 = new AdornerUIManager(components);
            badge1 = new Badge();
            badge2 = new Badge();
            adornerUIManager1.Elements.Add(badge1);
            adornerUIManager1.Elements.Add(badge2);
            badge1.TargetElement = bBI_Save;
            //badge2.TargetElement = RibbonPage_Invoice;

            ClearControlsAddNew();

            LoadSession();
        }

        public AdornerElement[] Badges { get { return new AdornerElement[] { badge1, badge2 }; } }

        private void FormInvoice_Load(object sender, EventArgs e)
        {
            dataLayoutControl1.isValid(out List<string> errorList);
        }

        private void ClearControlsAddNew()
        {
            dbContext = new subContext();

            trInvoiceHeader = trInvoiceHeadersBindingSource.AddNew() as TrInvoiceHeader;

            string NewDocNum = efMethods.GetNextDocNum(this.processCode, "DocumentNumber", "TrInvoiceHeaders");
            trInvoiceHeader.InvoiceHeaderId = Guid.NewGuid();
            trInvoiceHeader.DocumentNumber = NewDocNum;
            trInvoiceHeader.DocumentDate = DateTime.Now;
            trInvoiceHeader.DocumentTime = TimeSpan.Parse(DateTime.Now.ToString("HH:mm:ss"));
            trInvoiceHeader.ProcessCode = this.processCode;

            trInvoiceHeadersBindingSource.DataSource = trInvoiceHeader;

            labelControl1.Text = "";

            dbContext.TrInvoiceLines.Where(x => x.InvoiceHeaderId == trInvoiceHeader.InvoiceHeaderId)
                                    .LoadAsync()
                                    .ContinueWith(loadTask => trInvoiceLinesBindingSource.DataSource = dbContext.TrInvoiceLines.Local.ToBindingList(), TaskScheduler.FromCurrentSynchronizationContext());
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

                    dbContext = new subContext();
                    dbContext.TrInvoiceHeaders.Include(x => x.DcCurrAcc)
                                              .Where(x => x.InvoiceHeaderId == form.trInvoiceHeader.InvoiceHeaderId).Load();
                    LocalView<TrInvoiceHeader> lV_invoiceHeader = dbContext.TrInvoiceHeaders.Local;

                    if (!lV_invoiceHeader.Any(x => Object.ReferenceEquals(x.DcCurrAcc, null)))
                        lV_invoiceHeader.ForEach(x => x.CurrAccDesc = x.DcCurrAcc.FirstName + " " + x.DcCurrAcc.LastName);

                    trInvoiceHeadersBindingSource.DataSource = lV_invoiceHeader.ToBindingList();

                    dbContext.TrInvoiceLines.Include(o => o.DcProduct)
                                            .Where(x => x.InvoiceHeaderId == form.trInvoiceHeader.InvoiceHeaderId)
                                            .OrderBy(x => x.CreatedDate)
                                            .LoadAsync()
                                            .ContinueWith(loadTask =>
                                            {
                                                LocalView<TrInvoiceLine> lV_invoiceLine = dbContext.TrInvoiceLines.Local;

                                                lV_invoiceLine.ForEach(x =>
                                                {
                                                    x.ProductDescription = x.DcProduct.ProductDescription;

                                                    //x.Price = Math.Round(x.Price / x.ExchangeRate, 4); //ferqli valyutada gostermek
                                                    //x.Amount = Math.Round(x.Amount / (decimal)x.ExchangeRate, 4); //ferqli valyutada gostermek
                                                    //x.NetAmount = Math.Round(x.NetAmount / (decimal)x.ExchangeRate, 4); //ferqli valyutada gostermek

                                                    if (form.trInvoiceHeader.IsReturn)
                                                    {
                                                        x.QtyIn = x.QtyIn * (-1);
                                                        x.QtyOut = x.QtyOut * (-1);
                                                        x.Amount = x.Amount * (-1);
                                                        x.NetAmount = x.NetAmount * (-1);
                                                    }
                                                });



                                                trInvoiceLinesBindingSource.DataSource = lV_invoiceLine.ToBindingList();

                                            }, TaskScheduler.FromCurrentSynchronizationContext());


                    dataLayoutControl1.isValid(out List<string> errorList);

                    labelControl1.Text = "Ödənilib: " + Math.Round(efMethods.SelectPaymentLinesSum(trInvoiceHeader.InvoiceHeaderId), 2).ToString() + "AZN";
                }
            }
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
            using (FormCurrAccList form = new FormCurrAccList(currAccTypeCode))
            {
                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    btnEdit_CurrAccCode.EditValue = form.dcCurrAcc.CurrAccCode;
                    lC_CurrAccDesc.Text = form.dcCurrAcc.FirstName + " " + form.dcCurrAcc.LastName;
                    trInvoiceHeader.CurrAccCode = form.dcCurrAcc.CurrAccCode;
                    trInvoiceHeader.CurrAccDesc = form.dcCurrAcc.FirstName + " " + form.dcCurrAcc.LastName;
                }
            }
        }

        private void gV_InvoiceLine_InitNewRow(object sender, InitNewRowEventArgs e)
        {
            gV_InvoiceLine.SetRowCellValue(e.RowHandle, "InvoiceHeaderId", trInvoiceHeader.InvoiceHeaderId);
            gV_InvoiceLine.SetRowCellValue(e.RowHandle, "InvoiceLineId", Guid.NewGuid());
            gV_InvoiceLine.SetRowCellValue(e.RowHandle, CustomExtensions.ProcessDir(processCode) == "In" ? "QtyIn" : "QtyOut", 1);
            gV_InvoiceLine.SetRowCellValue(e.RowHandle, colCreatedDate, DateTime.Now);

            //GridView view = sender as GridView;
            //view.SetRowCellValue(e.RowHandle, col_ProductDesc, "InitNewRow");
        }

        private void gV_InvoiceLine_KeyDown(object sender, KeyEventArgs e)
        {
            GridView gV = sender as GridView;

            if (e.KeyCode == Keys.Delete)
            {
                if (MessageBox.Show("Sətir Silinsin?", "Təsdiqlə", MessageBoxButtons.YesNo) != DialogResult.Yes)
                    return;

                gV.DeleteSelectedRows();
            }

            if (e.KeyCode == Keys.F1)
            {
                gV_InvoiceLine.OptionsNavigation.AutoFocusNewRow = true;
            }

            if (e.KeyCode == Keys.F2)
            {
                repoBtnEdit_ProductCode.Buttons[0].PerformClick();
                //if (gV.FocusedRowHandle >= 0 && gV.FocusedColumn != null)
                //{
                //    GridViewInfo viewInfo = gV.GetViewInfo() as GridViewInfo;
                //    GridCellInfo cellInfo = viewInfo.GetGridCellInfo(gV.FocusedRowHandle, col_ProductCode);
                //    if (cellInfo != null)
                //    {
                //        RepositoryItem item = cellInfo.Editor;
                //        SelectProduct(item);

                //        //propertyGridControl1.SelectedObject = item;
                //        //propertyGridControl1.RetrieveFields();
                //    }
                //}
            }
        }

        private void gV_InvoiceLine_CellValueChanging(object sender, CellValueChangedEventArgs e)
        {
            CalcRowLocNetAmount(e);
        }

        private void CalcRowLocNetAmount(CellValueChangedEventArgs e)
        {
            object objPrice = gV_InvoiceLine.GetRowCellValue(e.RowHandle, col_Price);
            object objQty = gV_InvoiceLine.GetRowCellValue(e.RowHandle, CustomExtensions.ProcessDir(processCode) == "In" ? colQtyIn : colQtyOut);
            object objExRate = gV_InvoiceLine.GetFocusedRowCellValue(colExchangeRate);
            object objPriceLoc = gV_InvoiceLine.GetFocusedRowCellValue(colPriceLoc);


            decimal exRate = objExRate.IsNumeric() ? Convert.ToDecimal(objExRate, CultureInfo.InvariantCulture) : 1;
            decimal Qty = objQty.IsNumeric() ? Convert.ToDecimal(objQty, CultureInfo.InvariantCulture) : 0;
            decimal Price = objPrice.IsNumeric() ? Convert.ToDecimal(objPrice, CultureInfo.InvariantCulture) : 0;
            decimal PriceLoc = objPriceLoc.IsNumeric() ? Convert.ToDecimal(objPriceLoc, CultureInfo.InvariantCulture) : 0;

            if (e.Value != null && e.Column == col_Price)
            {
                objPrice = e.Value;
                Price = objPrice.IsNumeric() ? Convert.ToDecimal(objPrice, CultureInfo.InvariantCulture) : 0;
                gV_InvoiceLine.SetRowCellValue(e.RowHandle, colPriceLoc, Price * exRate);
                gV_InvoiceLine.SetRowCellValue(e.RowHandle, col_NetAmount, Qty * Price);
                gV_InvoiceLine.SetRowCellValue(e.RowHandle, colNetAmountLoc, Qty * Price * exRate);

            }
            else if (e.Value != null && e.Column == colPriceLoc)
            {
                objPriceLoc = e.Value;
                PriceLoc = objPriceLoc.IsNumeric() ? Convert.ToDecimal(objPriceLoc, CultureInfo.InvariantCulture) : 0;
                gV_InvoiceLine.SetRowCellValue(e.RowHandle, col_Price, Math.Round(PriceLoc / exRate, 2));
                gV_InvoiceLine.SetRowCellValue(e.RowHandle, col_NetAmount, Math.Round(Qty * PriceLoc / exRate, 2));
                gV_InvoiceLine.SetRowCellValue(e.RowHandle, colNetAmountLoc, Qty * PriceLoc);
            }
            else if (e.Value != null && e.Column == (CustomExtensions.ProcessDir(processCode) == "In" ? colQtyIn : colQtyOut))
            {
                objQty = e.Value;
                Qty = objQty.IsNumeric() ? Convert.ToDecimal(objQty, CultureInfo.InvariantCulture) : 0;
                gV_InvoiceLine.SetRowCellValue(e.RowHandle, col_NetAmount, Qty * Price);
                gV_InvoiceLine.SetRowCellValue(e.RowHandle, colNetAmountLoc, Qty * PriceLoc);
            }
            else if (e.Value != null && e.Column == colExchangeRate)
            {
                objExRate = e.Value;
                exRate = objExRate.IsNumeric() ? Convert.ToDecimal(objExRate, CultureInfo.InvariantCulture) : 1;
                gV_InvoiceLine.SetRowCellValue(e.RowHandle, colPriceLoc, Price * exRate);
                gV_InvoiceLine.SetRowCellValue(e.RowHandle, colNetAmountLoc, Qty * Price * exRate);
            }
        }

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
            using (FormCurrAccList form = new FormCurrAccList(3))
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
                    //gV_InvoiceLine.AddNewRow();
                    gV_InvoiceLine.SetFocusedRowCellValue(col_ProductCode, form.dcProduct.ProductCode);
                    gV_InvoiceLine.SetFocusedRowCellValue(col_ProductDesc, form.dcProduct.ProductDescription);

                    double price = this.processCode == "RS" ? form.dcProduct.RetailPrice : (this.processCode == "RP" ? form.dcProduct.PurchasePrice : 0);
                    gV_InvoiceLine.SetFocusedRowCellValue(col_Price, price);

                    CalcRowLocNetAmount(new CellValueChangedEventArgs(gV_InvoiceLine.FocusedRowHandle, col_Price, price));
                }
            }
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

            //dbContext.SaveChanges();
        }

        private void gV_InvoiceLine_RowDeleted(object sender, RowDeletedEventArgs e)
        {
            //dbContext.SaveChanges();
        }

        private void FormInvoice_FormClosed(object sender, FormClosedEventArgs e)
        {
            dbContext.Dispose();
        }

        private void bBI_SaveAndNew_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (dataLayoutControl1.isValid(out List<string> errorList))
            {
                decimal summaryNetAmount = CalcSumNetAmount();

                if (summaryNetAmount != 0)
                {
                    SaveInvoice();

                    SaveSession();

                    decimal bePaidAmount = Math.Round(summaryNetAmount - efMethods.SelectPaymentLinesSum(trInvoiceHeader.InvoiceHeaderId), 2);
                    MakePayment(bePaidAmount);

                    ClearControlsAddNew();

                    LoadSession();

                    GetPrint();
                }
                else XtraMessageBox.Show("Ödəmə 0a bərabərdir");
            }
            else
            {
                string combinedString = errorList.Aggregate((x, y) => x + "" + y);
                XtraMessageBox.Show(combinedString);
            }
        }

        private decimal CalcSumNetAmount()
        {
            decimal summaryNetAmount = 0;

            for (int i = 0; i < gV_InvoiceLine.DataRowCount; i++)
            {
                decimal netAmount = Convert.ToDecimal(gV_InvoiceLine.GetRowCellValue(i, col_NetAmount));
                summaryNetAmount += netAmount;
            }

            if ((bool)CheckEdit_IsReturn.EditValue)
                summaryNetAmount *= (-1);
            return summaryNetAmount;
        }

        //private void ConvertCurrency(int rowInd)
        //{
        //    float exRate = (float)gV_InvoiceLine.GetRowCellValue(rowInd, colExchangeRate);
        //    double price = (double)gV_InvoiceLine.GetRowCellValue(rowInd, col_Price);

        //    price = Math.Round(price * exRate, 4);

        //    gV_InvoiceLine.SetRowCellValue(rowInd, col_Price, price);
        //    CalcRowLocNetAmount(new CellValueChangedEventArgs(rowInd, col_Price, price));
        //}

        private void SaveInvoice()
        {
            for (int i = 0; i < gV_InvoiceLine.DataRowCount; i++)
            {
                MakeReturnIsNegativ(i);
            }

            if (!efMethods.InvoiceHeaderExist(trInvoiceHeader.InvoiceHeaderId))//if invoiceHeader doesnt exist
                efMethods.InsertInvoiceHeader(trInvoiceHeader);

            dbContext.SaveChanges();
        }

        private void MakeReturnIsNegativ(int rowInd)
        {
            if ((bool)CheckEdit_IsReturn.EditValue)
            {
                GridColumn qtyColumn = CustomExtensions.ProcessDir(processCode) == "In" ? colQtyIn : colQtyOut;

                int qty = Convert.ToInt32(gV_InvoiceLine.GetRowCellValue(rowInd, qtyColumn));
                gV_InvoiceLine.SetRowCellValue(rowInd, qtyColumn, qty * (-1));

                CalcRowLocNetAmount(new CellValueChangedEventArgs(rowInd, qtyColumn, qty * (-1)));
            }
        }

        private void GetPrint()
        {
            if (Settings.Default.AppSetting.GetPrint == true)
            {
                ReportClass reportClass = new ReportClass();
                //string designPath = Settings.Default.AppSetting.PrintDesignPath;
                string designPath = designFolder + "InvoiceRS_A5.repx";


                if (!File.Exists(designPath))
                    designPath = reportClass.SelectDesign();
                if (!File.Exists(designPath))
                {
                    ReportPrintTool printTool = new ReportPrintTool(reportClass.CreateReport(efMethods.SelectInvoiceLineForReport(trInvoiceHeader.InvoiceHeaderId), designPath));
                    printTool.PrintDialog();
                }
            }
        }

        private void MakePayment(decimal bePaidAmount)
        {
            using (FormPayment formPayment = new FormPayment(1, bePaidAmount, trInvoiceHeader))
            {
                if (formPayment.ShowDialog(this) == DialogResult.OK)
                {
                    //efMethods.UpdateInvoiceIsCompleted(trInvoiceHeader.InvoiceHeaderId);
                }
            }
        }

        private void LoadSession()
        {
            trInvoiceHeader.OfficeCode = Authorization.OfficeCode;
            trInvoiceHeader.StoreCode = Authorization.StoreCode;
            trInvoiceHeader.WarehouseCode = Settings.Default.WarehouseCode;
        }

        private void SaveSession()
        {
            Settings.Default.WarehouseCode = lUE_WarehouseCode.EditValue.ToString();
            Settings.Default.Save();
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

            LoadSession();

            dataLayoutControl1.isValid(out List<string> errorList);
        }

        private string subConnString = Settings.Default.subConnString;

        private void bBI_reportDesign_ItemClick(object sender, ItemClickEventArgs e)
        {
            ReportClass reportClass = new ReportClass();
            //string designPath = Settings.Default.AppSetting.PrintDesignPath;
            string designPath = designFolder + "InvoiceRS_Tokla.repx";

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
            string designPath = designFolder + "InvoiceRS_Tokla.repx";

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
                decimal summaryNetAmount = CalcSumNetAmount();
                if (summaryNetAmount != 0)
                {
                    SaveInvoice();
                    SaveSession();
                }
            }
            else
            {
                string combinedString = errorList.Aggregate((x, y) => x + "" + y);
                XtraMessageBox.Show(combinedString);
            }
        }

        private void trInvoiceLinesBindingSource_AddingNew(object sender, AddingNewEventArgs e)
        {
            //line.DcProduct = new DcProduct();
            //line.DcProduct.ProductDescription = "Fazil";
            //e.NewObject = line;
        }

        private void bBI_Payment_ItemClick(object sender, ItemClickEventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Qaimə yadda saxlanılsınmı?");
            if (dialogResult == DialogResult.OK)
            {
                if (dataLayoutControl1.isValid(out List<string> errorList))
                {
                    decimal summaryNetAmount = CalcSumNetAmount();
                    if (summaryNetAmount != 0)
                    {
                        SaveInvoice();
                        SaveSession();
                    }

                    decimal bePaidAmount = Math.Round(summaryNetAmount - efMethods.SelectPaymentLinesSum(trInvoiceHeader.InvoiceHeaderId), 2);
                    MakePayment(bePaidAmount);
                }
                else
                {
                    string combinedString = errorList.Aggregate((x, y) => x + "" + y);
                    XtraMessageBox.Show(combinedString);
                }
            }
        }

        private void bBI_DeleteInvoice_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (efMethods.InvoiceHeaderExist(trInvoiceHeader.InvoiceHeaderId))
            {
                if (MessageBox.Show("Silmek Isteyirsiz?", "Diqqet", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    efMethods.DeleteInvoice(trInvoiceHeader.InvoiceHeaderId);
                    efMethods.DeletePaymentByInvoice(trInvoiceHeader.InvoiceHeaderId);

                    ClearControlsAddNew();

                    LoadSession();

                    dataLayoutControl1.isValid(out List<string> errorList);
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
                labelControl1.Text = "0.00";
            }
        }

        private void repoLUE_Currency_EditValueChanged(object sender, EventArgs e)
        {
            LookUpEdit textEditor = (LookUpEdit)sender;
            float exRate = efMethods.SelectExRate(textEditor.EditValue.ToString());
            gV_InvoiceLine.SetFocusedRowCellValue(colExchangeRate, exRate);

            CalcRowLocNetAmount(new CellValueChangedEventArgs(gV_InvoiceLine.FocusedRowHandle, colExchangeRate, exRate));

        }

        private void repoBtnEdit_ProductCode_ButtonPressed(object sender, EventArgs e)
        {
            SelectProduct(sender);
        }
    }
}