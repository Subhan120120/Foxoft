using DevExpress.Data;
using DevExpress.Utils.Extensions;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Navigation;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using Foxoft.AppCode;
using Foxoft.Models;
using Foxoft.Properties;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Foxoft
{
    public partial class FormPriceListDetail : RibbonForm
    {
        private TrPriceListHeader trPriceListHeader;
        private EfMethods efMethods = new();
        private subContext dbContext;
        private Guid PriceListHeaderId;

        public FormPriceListDetail()
        {
            InitializeComponent();

            //StoreCodeLookUpEdit.Properties.DataSource = efMethods.SelectStores();
            repoLUE_CurrencyCode.DataSource = efMethods.SelectCurrencies();
            //repoLUE_PriceListTypeCode.DataSource = efMethods.SelectPriceListTypes();

            ClearControlsAddNew();

            //bool currAccHasClaims = efMethods.CurrAccHasClaims(Authorization.CurrAccCode, "PriceListDetail");
            //if (!currAccHasClaims)
            //{
            //    MessageBox.Show("Yetkiniz yoxdur! ");
            //    return;
            //}
            //else
            //    this.Show();
        }

        public FormPriceListDetail(Guid PriceListHeaderId)
            : this()
        {
            trPriceListHeader = efMethods.SelectPriceListHeader(PriceListHeaderId);

            if (trPriceListHeader is not null)
            {
                LoadPriceList(trPriceListHeader.PriceListHeaderId);
            }
        }

        private void ClearControlsAddNew()
        {
            dbContext = new subContext();

            PriceListHeaderId = Guid.NewGuid();

            dbContext.TrPriceListHeaders.Where(x => x.PriceListHeaderId == PriceListHeaderId)
                                      .Load();
            trPriceListHeadersBindingSource.DataSource = dbContext.TrPriceListHeaders.Local.ToBindingList();

            trPriceListHeader = trPriceListHeadersBindingSource.AddNew() as TrPriceListHeader;

            dbContext.TrPriceListLines.Include(x => x.DcProduct)
                                    .Where(x => x.PriceListHeaderId == trPriceListHeader.PriceListHeaderId)
                                    .LoadAsync()
                                    .ContinueWith(loadTask => trPriceListLinesBindingSource.DataSource = dbContext.TrPriceListLines.Local.ToBindingList(), TaskScheduler.FromCurrentSynchronizationContext());

            dataLayoutControl1.IsValid(out List<string> errorList);

            gV_PriceListLine.Focus();
        }

        private void trPriceListHeadersBindingSource_AddingNew(object sender, AddingNewEventArgs e)
        {
            TrPriceListHeader PriceListHeader = new();
            PriceListHeader.PriceListHeaderId = PriceListHeaderId;
            string NewDocNum = efMethods.GetNextDocNum(true, "PL", "DocumentNumber", "TrPriceListHeaders", 6);
            PriceListHeader.DocumentNumber = NewDocNum;
            PriceListHeader.DocumentDate = DateTime.Now;
            PriceListHeader.OperationDate = DateTime.Now;
            PriceListHeader.DocumentTime = TimeSpan.Parse(DateTime.Now.ToString("HH:mm:ss"));
            PriceListHeader.OperationTime = TimeSpan.Parse(DateTime.Now.ToString("HH:mm:ss"));
            PriceListHeader.OfficeCode = Authorization.OfficeCode;
            PriceListHeader.CreatedUserName = Authorization.CurrAccCode;

            e.NewObject = PriceListHeader;
        }

        private void trPriceListHeadersBindingSource_CurrentItemChanged(object sender, EventArgs e)
        {
            trPriceListHeader = trPriceListHeadersBindingSource.Current as TrPriceListHeader;

            if (trPriceListHeader != null && dbContext != null && dataLayoutControl1.IsValid(out List<string> errorList))
            {
                int count = efMethods.SelectPriceListLines(trPriceListHeader.PriceListHeaderId).Count;
                if (count > 0)
                    SavePriceList();
            }
        }

        private void SavePriceList()
        {
            try
            {
                dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Daxil Etdiyiniz Məlumatlar Əsaslı Deyil ! \n \n {ex}");
            }
        }

        private void btnEdit_DocNum_ButtonPressed(object sender, ButtonPressedEventArgs e)
        {
            SelectDocNum();
        }

        private void CurrAccCodeButtonEdit_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
        }

        private void SelectDocNum()
        {
            using (FormPriceListHeaderList form = new())
            {
                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    trPriceListHeader = form.trPriceListHeader;
                    if (trPriceListHeader is not null)
                    {
                        LoadPriceList(trPriceListHeader.PriceListHeaderId);
                    }
                }
            }
        }

        private void LoadPriceList(Guid PriceListHeaderId)
        {
            dbContext = new subContext();

            dbContext.TrPriceListHeaders
                                      .Where(x => x.PriceListHeaderId == PriceListHeaderId).Load();

            LocalView<TrPriceListHeader> lV_PriceListHeader = dbContext.TrPriceListHeaders.Local;

            lV_PriceListHeader.ForEach(x =>
            {

            });

            trPriceListHeadersBindingSource.DataSource = lV_PriceListHeader.ToBindingList();
            trPriceListHeader = trPriceListHeadersBindingSource.Current as TrPriceListHeader;

            dbContext.TrPriceListLines.Include(x => x.DcProduct)
                                    .Where(x => x.PriceListHeaderId == PriceListHeaderId)
                                    .OrderBy(x => x.CreatedDate)
                                    .LoadAsync()
                                    .ContinueWith(loadTask =>
                                    {
                                        LocalView<TrPriceListLine> lV_PriceListLine = dbContext.TrPriceListLines.Local;
                                        trPriceListLinesBindingSource.DataSource = lV_PriceListLine.ToBindingList();

                                    }, TaskScheduler.FromCurrentSynchronizationContext());

            dataLayoutControl1.IsValid(out List<string> errorList);

        }

        private void bBI_DeletePriceList_ItemClick(object sender, ItemClickEventArgs e)
        {
            //if (efMethods.PriceListHeaderExist(trPriceListHeader.PriceListHeaderId))
            //{
            //    if (MessageBox.Show("Silmek Isteyirsiz?", "Diqqet", MessageBoxButtons.OKCancel) == DialogResult.OK)
            //    {
            //        efMethods.DeletePriceList(trPriceListHeader.PriceListHeaderId);

            //        ClearControlsAddNew();
            //    }
            //}
            //else
            //    XtraMessageBox.Show("Silinmeli olan faktura yoxdur");
        }

        //private void SelectCurrAcc()
        //{
        //    using (FormCurrAccList form = new(new byte[] { 1, 2, 3 }, trPriceListHeader.CurrAccCode))
        //    {
        //        if (form.ShowDialog(this) == DialogResult.OK)
        //        {
        //            CurrAccCodeButtonEdit.EditValue = form.dcCurrAcc.CurrAccCode;
        //            trPriceListHeader.CurrAccCode = form.dcCurrAcc.CurrAccCode;
        //            lbl_CurrAccDesc.Text = form.dcCurrAcc.CurrAccDesc + " " + form.dcCurrAcc.FirstName + " " + form.dcCurrAcc.LastName;

        //            CalcCurrAccBalance(form.dcCurrAcc.CurrAccCode, trPriceListHeader.OperationDate);
        //        }
        //    }
        //}

        private void gV_PriceListLine_InitNewRow(object sender, InitNewRowEventArgs e)
        {
            gV_PriceListLine.SetRowCellValue(e.RowHandle, colPriceListHeaderId, trPriceListHeader.PriceListHeaderId);
            gV_PriceListLine.SetRowCellValue(e.RowHandle, colPriceListLineId, Guid.NewGuid());

            string currencyCode = Settings.Default.AppSetting.LocalCurrencyCode;
            DcProcess dcProcess = efMethods.SelectProcess("PL");
            if (!string.IsNullOrEmpty(dcProcess.CustomCurrencyCode))
                currencyCode = dcProcess.CustomCurrencyCode;
            DcCurrency currency = efMethods.SelectCurrency(currencyCode);
            if (currency is not null)
            {
                gV_PriceListLine.SetRowCellValue(e.RowHandle, colCurrencyCode, currency.CurrencyCode);
            }

            //gV_PriceListLine.SetRowCellValue(e.RowHandle, colCreatedDate, DateTime.Now);
            //gV_PriceListLine.SetRowCellValue(e.RowHandle, colCreatedUserName, Authorization.CurrAccCode);
        }

        private void gC_PriceListLine_KeyDown(object sender, KeyEventArgs e)
        {
            GridControl gC = sender as GridControl;
            GridView gV = gC.MainView as GridView;

            if (e.KeyCode == Keys.Delete)
            {
                if (MessageBox.Show("Sətir Silinsin?", "Təsdiqlə", MessageBoxButtons.YesNo) != DialogResult.Yes)
                    return;

                gV.DeleteSelectedRows();
            }
        }

        private void gV_PriceListLine_CellValueChanging(object sender, CellValueChangedEventArgs e)
        {
            //CalcRowLocNetAmount(e);
        }

        private void gV_PriceListLine_RowUpdated(object sender, RowObjectEventArgs e)
        {
            if (dataLayoutControl1.IsValid(out List<string> errorList))
            {
                SavePriceList();
            }
            else
            {
                string combinedString = errorList.Aggregate((x, y) => x + "" + y);
                XtraMessageBox.Show(combinedString);
            }
        }

        private void gV_PriceListLine_RowDeleted(object sender, RowDeletedEventArgs e)
        {
            if (dataLayoutControl1.IsValid(out List<string> errorList))
            {
                SavePriceList();
            }
            else
            {
                string combinedString = errorList.Aggregate((x, y) => x + "" + y);
                XtraMessageBox.Show(combinedString);
            }
        }

        private void repoLUE_CurrencyCode_EditValueChanged(object sender, EventArgs e)
        {
        }

        private void bBI_SaveAndClose_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (trPriceListHeader != null && dbContext != null && dataLayoutControl1.IsValid(out List<string> errorList))
            {
                int count = efMethods.SelectPriceListLines(trPriceListHeader.PriceListHeaderId).Count;
                if (count > 0)
                    SavePriceList();
            }
            this.Close();
        }

        private void bBI_SendWhatsapp_ItemClick(object sender, ItemClickEventArgs e)
        {
        }

        private void sendWhatsApp(string number, string message)
        {
        }

        private void bBI_NewPriceList_ItemClick(object sender, ItemClickEventArgs e)
        {
            ClearControlsAddNew();
        }

        private void dataLayout_KeyDown(object sender, KeyEventArgs e)
        {
        }

        private void bBI_CopyPriceList_ItemClick(object sender, ItemClickEventArgs e)
        {
        }

        private void repoBtnEdit_ProductCode_ButtonPressed(object sender, ButtonPressedEventArgs e)
        {
            string productCode = gV_PriceListLine.GetFocusedRowCellValue("ProductCode")?.ToString();

            ButtonEdit editor = (ButtonEdit)sender;

            using FormProductList form = new(new byte[] { 1, 3 }, productCode);

            try
            {
                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    editor.EditValue = form.dcProduct.ProductCode;
                    gV_PriceListLine.CloseEditor();
                    gV_PriceListLine.UpdateCurrentRow(); // For Model/Entity/trInvoiceLine Included TrInvoiceHeader

                    gV_PriceListLine.BestFitColumns();
                    gV_PriceListLine.FocusedColumn = colPrice;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void barButtonItem3_ItemClick(object sender, ItemClickEventArgs e)
        {
            //TwilioClass twilio = new TwilioClass();
            //twilio.AlmaDolmasi();
        }

        private void BBI_Info_ItemClick(object sender, ItemClickEventArgs e)
        {
        }

        private void gV_PriceListLine_CustomUnboundColumnData(object sender, CustomColumnDataEventArgs e)
        {
            if (e.Column.FieldName == "ProductDesc" && e.IsGetData)
            {
                GridView view = sender as GridView;
                int rowInd = view.GetRowHandle(e.ListSourceRowIndex);
                string productCode = view.GetRowCellValue(rowInd, colProductCode) as string ?? string.Empty;

                DcProduct dcProduct = efMethods.SelectProduct(productCode);

                e.Value = dcProduct?.ProductDesc;
            }
        }
    }
}