using DevExpress.Data;
using DevExpress.Utils.Extensions;
using DevExpress.Utils.VisualEffects;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraReports.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Foxoft.Models;
using Foxoft.Properties;
using System;
using System.Collections.Generic;
using System.Data;
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

        private TrInvoiceHeader trInvoiceHeader;
        public string processCode;
        private byte productTypeCode;
        private EfMethods efMethods = new EfMethods();
        private subContext dbContext;

        public FormInvoice(string processCode, byte productTypeCode)
        {
            this.processCode = processCode;
            this.productTypeCode = productTypeCode;
            InitializeComponent();
            if (CustomExtensions.ProcessDir(processCode) == "In")
                gV_InvoiceLine.Columns["QtyOut"].Visible = false;
            else
                gV_InvoiceLine.Columns["QtyIn"].Visible = false;

            lUE_OfficeCode.Properties.DataSource = efMethods.SelectOffices();
            lUE_StoreCode.Properties.DataSource = efMethods.SelectStores();
            lUE_WarehouseCode.Properties.DataSource = efMethods.SelectWarehouses();

            adornerUIManager1 = new AdornerUIManager(components);
            badge1 = new Badge();
            badge2 = new Badge();
            adornerUIManager1.Elements.Add(badge1);
            adornerUIManager1.Elements.Add(badge2);
            badge1.TargetElement = bBI_Save;
            //badge2.TargetElement = RibbonPage_Invoice;
        }

        public AdornerElement[] Badges { get { return new AdornerElement[] { badge1, badge2 }; } }

        private void FormInvoice_Load(object sender, EventArgs e)
        {
            ClearControlsAddNew();

            LoadSession();

            dataLayoutControl1.isValid(out List<string> errorList);
        }

        private void LoadSession()
        {
            lUE_OfficeCode.EditValue = Settings.Default.OfficeCode;
            lUE_StoreCode.EditValue = Settings.Default.StoreCode;
            lUE_WarehouseCode.EditValue = Settings.Default.WarehouseCode;
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

            //trInvoiceHeadersBindingSource.EndEdit();

            labelControl1.Text = "";

            dbContext.TrInvoiceLines.Where(x => x.InvoiceHeaderId == trInvoiceHeader.InvoiceHeaderId)
                                    .LoadAsync()
                                    .ContinueWith(loadTask => trInvoiceLinesBindingSource.DataSource = dbContext.TrInvoiceLines.Local.ToBindingList(), TaskScheduler.FromCurrentSynchronizationContext());
        }

        private void btnEdit_DocNum_ButtonPressed(object sender, ButtonPressedEventArgs e)
        {
            using (FormInvoiceHeaderList form = new FormInvoiceHeaderList(this.processCode))
            {
                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    trInvoiceHeader.InvoiceHeaderId = form.trInvoiceHeader.InvoiceHeaderId;

                    dbContext = new subContext();
                    dbContext.TrInvoiceHeaders.Where(x => x.InvoiceHeaderId == form.trInvoiceHeader.InvoiceHeaderId).Load();
                    trInvoiceHeadersBindingSource.DataSource = dbContext.TrInvoiceHeaders.Local.ToBindingList();

                    dbContext.TrInvoiceLines.Where(x => x.InvoiceHeaderId == form.trInvoiceHeader.InvoiceHeaderId)
                                            .LoadAsync()
                                            .ContinueWith(loadTask =>
                                            {
                                                LocalView<TrInvoiceLine> local = dbContext.TrInvoiceLines.Local;
                                                if (form.trInvoiceHeader.IsReturn)
                                                    local.ForEach(x =>
                                                    {
                                                        x.QtyIn = x.QtyIn * (-1);
                                                        x.QtyOut = x.QtyOut * (-1);
                                                        x.Amount = x.Amount * (-1);
                                                        x.NetAmount = x.NetAmount * (-1);
                                                    });

                                                trInvoiceLinesBindingSource.DataSource = local.ToBindingList();
                                            }, TaskScheduler.FromCurrentSynchronizationContext());

                    //dbContext.TrInvoiceLines.Where(x => x.InvoiceHeaderId == trInvoiceHeader.InvoiceHeaderId).Load();
                    //LocalView<TrInvoiceLine> local = dbContext.TrInvoiceLines.Local;
                    //local.ForEach(x => x.Qty = x.Qty * (-1));
                    //trInvoiceLinesBindingSource.DataSource = local.ToBindingList();

                    dataLayoutControl1.isValid(out List<string> errorList);

                    labelControl1.Text = "Ödənilib: " + Math.Round(efMethods.SelectPaymentLinesSum(trInvoiceHeader.InvoiceHeaderId), 2).ToString() + "AZN";
                }
            }
        }

        private void btnEdit_CurrAccCode_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            using (FormCurrAccList form = new FormCurrAccList(2))
            {
                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    btnEdit_CurrAccCode.EditValue = form.dcCurrAcc.CurrAccCode;
                }
            }
        }

        private void gV_InvoiceLine_InitNewRow(object sender, InitNewRowEventArgs e)
        {
            gV_InvoiceLine.SetRowCellValue(e.RowHandle, "InvoiceHeaderId", trInvoiceHeader.InvoiceHeaderId);
            gV_InvoiceLine.SetRowCellValue(e.RowHandle, "InvoiceLineId", Guid.NewGuid());
            gV_InvoiceLine.SetRowCellValue(e.RowHandle, CustomExtensions.ProcessDir(processCode) == "In" ? "QtyIn" : "QtyOut", 1);
        }

        private void gV_InvoiceLine_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (MessageBox.Show("Sətir Silinsin?", "Təsdiqlə", MessageBoxButtons.YesNo) != DialogResult.Yes)
                    return;
                GridView gV = sender as GridView;
                gV.DeleteSelectedRows();
            }
        }

        private void gV_InvoiceLine_CellValueChanging(object sender, CellValueChangedEventArgs e)
        {
            object objPrice = gV_InvoiceLine.GetRowCellValue(e.RowHandle, "Price");
            object objQty = gV_InvoiceLine.GetRowCellValue(e.RowHandle, CustomExtensions.ProcessDir(processCode) == "In" ? "QtyIn" : "QtyOut");
            object objPosDiscount = gV_InvoiceLine.GetRowCellValue(e.RowHandle, "PosDiscount");

            if (e.Column.FieldName == "Price")
                objPrice = e.Value;
            if (e.Column.FieldName == (CustomExtensions.ProcessDir(processCode) == "In" ? "QtyIn" : "QtyOut"))
                objQty = e.Value;
            if (e.Column.FieldName == "PosDiscount")
                objPosDiscount = e.Value;

            decimal Price = objPrice.IsNumeric() ? Convert.ToDecimal(objPrice) : 0;
            decimal Qty = objQty.IsNumeric() ? Convert.ToDecimal(objQty) : 0;
            decimal PosDiscount = objPosDiscount.IsNumeric() ? Convert.ToDecimal(objPosDiscount) : 0;

            gV_InvoiceLine.SetRowCellValue(e.RowHandle, "Amount", Qty * Price);
            gV_InvoiceLine.SetRowCellValue(e.RowHandle, "NetAmount", Qty * Price - PosDiscount);
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
            ButtonEdit editor = (ButtonEdit)sender;
            int buttonIndex = editor.Properties.Buttons.IndexOf(e.Button);
            if (buttonIndex == 0)
            {
                using (FormProductList form = new FormProductList(productTypeCode))
                {
                    if (form.ShowDialog(this) == DialogResult.OK)
                    {
                        editor.EditValue = form.dcProduct.ProductCode;

                        gV_InvoiceLine.SetFocusedRowCellValue("Price", this.processCode == "RS" ? form.dcProduct.RetailPrice : (this.processCode == "RP" ? form.dcProduct.PurchasePrice : 0));

                        CalcInvoiceLineNetAmount();
                    }
                }
            }
        }

        private void CalcInvoiceLineNetAmount()
        {
            object objPrice = gV_InvoiceLine.GetFocusedRowCellValue("Price");
            object objQty = gV_InvoiceLine.GetFocusedRowCellValue(CustomExtensions.ProcessDir(processCode) == "In" ? "QtyIn" : "QtyOut");
            object objPosDiscount = gV_InvoiceLine.GetFocusedRowCellValue("PosDiscount");

            decimal Price = objPrice.IsNumeric() ? Convert.ToDecimal(objPrice) : 0;
            decimal Qty = objQty.IsNumeric() ? Convert.ToDecimal(objQty) : 0;
            decimal PosDiscount = objPosDiscount.IsNumeric() ? Convert.ToDecimal(objPosDiscount) : 0;

            gV_InvoiceLine.SetFocusedRowCellValue("Amount", Qty * Price);
            gV_InvoiceLine.SetFocusedRowCellValue("NetAmount", Qty * Price - PosDiscount);
        }

        private void repoBtnEdit_SalesPersonCode_ButtonPressed(object sender, ButtonPressedEventArgs e)
        {
            ButtonEdit editor = (ButtonEdit)sender;
            int buttonIndex = editor.Properties.Buttons.IndexOf(e.Button);
            if (buttonIndex == 0)
            {
                using (FormCurrAccList form = new FormCurrAccList(3))
                {
                    if (form.ShowDialog(this) == DialogResult.OK)
                    {
                        editor.EditValue = form.dcCurrAcc.CurrAccCode;
                    }
                }
            }
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
                decimal summaryNetAmount = Convert.ToDecimal(gV_InvoiceLine.Columns["NetAmount"].SummaryItem.SummaryValue);

                if (trInvoiceHeader.IsReturn)
                    summaryNetAmount *= (-1);
                if (CustomExtensions.ProcessDir(processCode) == "In")
                    summaryNetAmount *= (-1);


                if (summaryNetAmount != 0)
                {
                    using (FormPayment formPayment = new FormPayment(1, summaryNetAmount, trInvoiceHeader.InvoiceHeaderId))
                    {
                        if (!efMethods.InvoiceHeaderExist(trInvoiceHeader.InvoiceHeaderId))//if invoiceHeader doesnt exist
                            efMethods.InsertInvoiceHeader(trInvoiceHeader);

                        if ((bool)CheckEdit_IsReturn.EditValue)
                        {
                            for (int i = 0; i < gV_InvoiceLine.DataRowCount; i++)
                            {
                                if (CustomExtensions.ProcessDir(processCode) == "In")
                                {
                                    int qty = Convert.ToInt32(gV_InvoiceLine.GetRowCellValue(i, "QtyIn"));
                                    gV_InvoiceLine.SetRowCellValue(i, "QtyIn", qty * (-1));
                                }
                                else if (CustomExtensions.ProcessDir(processCode) == "Out")
                                {
                                    int qty = Convert.ToInt32(gV_InvoiceLine.GetRowCellValue(i, "QtyOut"));
                                    gV_InvoiceLine.SetRowCellValue(i, "QtyOut", qty * (-1));
                                }

                                int amount = Convert.ToInt32(gV_InvoiceLine.GetRowCellValue(i, col_Amount));
                                gV_InvoiceLine.SetRowCellValue(i, "Amount", amount * (-1));

                                int netAmount = Convert.ToInt32(gV_InvoiceLine.GetRowCellValue(i, col_NetAmount));
                                gV_InvoiceLine.SetRowCellValue(i, "NetAmount", netAmount * (-1));
                            }
                        }

                        dbContext.SaveChanges();

                        if (formPayment.ShowDialog(this) == DialogResult.OK)
                        {
                            efMethods.UpdateInvoiceIsCompleted(trInvoiceHeader.InvoiceHeaderId);
                            SaveSession();
                            ClearControlsAddNew();

                            if (Settings.Default.AppSetting.GetPrint == true)
                            {
                                ReportClass reportClass = new ReportClass();
                                string designPath = Settings.Default.AppSetting.PrintDesignPath;
                                if (!File.Exists(designPath))
                                    designPath = reportClass.SelectDesign();
                            }
                        }
                    }
                }
                else XtraMessageBox.Show("Ödəmə 0a bərabərdir");
            }
            else
            {
                string combinedString = errorList.Aggregate((x, y) => x + "" + y);
                XtraMessageBox.Show(combinedString);
            }
        }

        private void SaveSession()
        {
            Settings.Default.OfficeCode = lUE_OfficeCode.EditValue.ToString();
            Settings.Default.StoreCode = lUE_StoreCode.EditValue.ToString();
            Settings.Default.WarehouseCode = lUE_WarehouseCode.EditValue.ToString();
            Settings.Default.Save();
        }

        private void bBI_reportDesign_ItemClick(object sender, ItemClickEventArgs e)
        {
            ReportClass reportClass = new ReportClass();
            string designPath = Settings.Default.AppSetting.PrintDesignPath;
            if (!File.Exists(designPath))
                designPath = reportClass.SelectDesign();

            ReportDesignTool printTool = new ReportDesignTool(reportClass.CreateReport(efMethods.SelectInvoiceLineForReport(trInvoiceHeader.InvoiceHeaderId), designPath));
            printTool.ShowRibbonDesigner();
        }

        private void gV_InvoiceLine_AsyncCompleted(object sender, EventArgs e)
        {
            MessageBox.Show("Test");
        }

        private void gV_InvoiceLine_RowLoaded(object sender, RowEventArgs e)
        {
            object a = sender;
            RowEventArgs r = e;
        }
    }
}