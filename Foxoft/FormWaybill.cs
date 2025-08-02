using DevExpress.Utils.Diagnostics;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using Foxoft.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using System.Xml;

namespace Foxoft
{
    public partial class FormWaybill : RibbonForm
    {
        public Guid deliveryInvoiceHeaderId;
        public UnDeliveredViewModel unDeliveredViewModel;
        public TrInvoiceHeader deliveryInvoHeader;
        public Guid invoiceLineID;
        public string processCode;
        private CancellationTokenSource? _cts;
        private Task? _loadingTask;
        private readonly object _lock = new();


        EfMethods efMethods = new();
        BindingList<UnDeliveredViewModel> liveList = new();


        public FormWaybill()
        {
            InitializeComponent();

            gC_InvoiceLine.DataSource = liveList;

            ClearControls();

            //LoadInvoiceLinesAsync();

            gV_InvoiceLine.BestFitColumns();

            //Foxoft.Models.subContext dbContext = new Foxoft.Models.subContext();

            //dbContext.TrInvoiceHeaders.LoadAsync().ContinueWith(loadTask =>
            //{

            //    trInvoiceHeadersBindingSource.DataSource = dbContext.TrInvoiceHeaders.Local.ToBindingList();
            //}, System.Threading.Tasks.TaskScheduler.FromCurrentSynchronizationContext());

            //dataLayoutControl1.BestFit();
            //dataLayoutControl1.Size = dataLayoutControl1.PreferredSize;
        }

        public FormWaybill(string processCode)
           : this()
        {
            this.processCode = processCode;
        }

        //private void FormDelivery_Load(object sender, EventArgs e)
        //{
        //    //ParentForm.FormClosing += new FormClosingEventHandler(ParentForm_FormClosing); // set Parent Form Closing event
        //}
        private void FormDelivery_Load(object sender, EventArgs e)
        {
            //gC_InvoiceLine.DataSource = liveList;

            LoadDataStreamedAsync();
        }


        private void ClearControls()
        {
            deliveryInvoiceHeaderId = Guid.NewGuid();

            //unDeliveredViewModel = null;
            //gC_InvoiceLine.DataSource = null;
            gC_DeliveryInvoiceLine.DataSource = null;
            trInvoiceHeadersBindingSource.DataSource = new TrInvoiceHeader() { };
        }


        private async void LoadDataStreamedAsync(Guid? invoiceHeaderId = null)
        {
            lock (_lock)
            {
                _cts?.Cancel();
            }

            if (_loadingTask != null)
            {
                try
                {
                    await _loadingTask;
                }
                catch (OperationCanceledException)
                {
                    // Load cancelled
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Unexpected error: {ex.Message}");
                }
            }

            _cts = new CancellationTokenSource();
            var token = _cts.Token;

            _loadingTask = Task.Run(async () =>
            {
                // Clear BindingList on UI thread
                this.Invoke(() => liveList.Clear());

                try
                {
                    await foreach (UnDeliveredViewModel? item in efMethods.StreamInvoiceLinesForDeliveryAsync(invoiceHeaderId, token))
                    {
                        if (token.IsCancellationRequested) break;

                        this.Invoke(() => liveList.Add(item));
                    }
                }
                catch (OperationCanceledException)
                {
                    // Safely ignore
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Load error: {ex.Message}");
                }
            }, token);
        }


        private void FormWaybill_FormClosing(object sender, FormClosingEventArgs e)
        {
            _cts?.Cancel();
        }

        private void btn_Ok_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK == XtraMessageBox.Show("Qaiməni açmaq istəyirsiz?", "Qaiməni Aç", MessageBoxButtons.OKCancel))
            {
                OpenFormInvoice(deliveryInvoHeader.DocumentNumber);
            }

            ClearControls();

            LoadDataStreamedAsync();
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Təhvil Ləğv Edilsin?", "Təsdiqlə", MessageBoxButtons.YesNo) == DialogResult.Yes)
                if (efMethods.EntityExists<TrInvoiceHeader>(deliveryInvoiceHeaderId))
                {
                    efMethods.DeleteInvoice(deliveryInvoiceHeaderId);

                    ClearControls();


                    LoadDataStreamedAsync();
                }

        }


        private void OpenFormInvoice(string strDocNum)
        {
            TrInvoiceHeader trInvoiceHeader = efMethods.SelectInvoiceHeaderByDocNum(strDocNum);

            if (trInvoiceHeader is not null)
            {
                string claim = CustomExtensions.GetClaim(trInvoiceHeader.ProcessCode);

                bool currAccHasClaims = efMethods.CurrAccHasClaims(Authorization.CurrAccCode, claim);
                if (!currAccHasClaims)
                {
                    MessageBox.Show("Yetkiniz yoxdur! ");
                    return;
                }

                byte[] bytes = CustomExtensions.GetProductTypeArray(trInvoiceHeader.ProcessCode);

                FormInvoice frm = new(trInvoiceHeader.ProcessCode, null, bytes, null, trInvoiceHeader.InvoiceHeaderId);
                FormERP formERP = Application.OpenForms[nameof(FormERP)] as FormERP;
                frm.MdiParent = formERP;
                frm.WindowState = FormWindowState.Maximized;
                frm.Show();
                formERP.parentRibbonControl.SelectedPage = formERP.parentRibbonControl.MergedPages[0];
            }
            else
                MessageBox.Show("Belə bir sənəd yoxdur.");
        }

        private void gV_DeliveryInvoiceLine_CalcPreviewText(object sender, CalcPreviewTextEventArgs e)
        {
            GridView view = sender as GridView;
            if (view == null) return;

            string SalesPersonCode = view.GetRowCellDisplayText(e.RowHandle, col_SalesPersonCode);

            e.PreviewText = CustomExtensions.GetPreviewText(0, 0, 0, 0, String.Empty, SalesPersonCode);
        }

        private void gV_InvoiceLine_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            unDeliveredViewModel = gV_InvoiceLine.GetFocusedRow() as UnDeliveredViewModel;
        }

        private void repoBtn_AddWaybill_ButtonPressed(object sender, ButtonPressedEventArgs e)
        {
            Guid invoiceLineID = (Guid)gV_InvoiceLine.GetFocusedRowCellValue(col_InvoiceLineId);
            decimal maxDelivery = (decimal)(gV_InvoiceLine.GetFocusedRowCellValue(col_RemainingQty));

            if (!(maxDelivery > 0))
            {
                XtraMessageBox.Show("Təhvil edilə biləcək miqdar yoxdur");
                return;
            }

            using (FormQty formQty = new(maxDelivery))
            {
                if (formQty.ShowDialog(this) == DialogResult.OK)
                {
                    if (!efMethods.EntityExists<TrInvoiceHeader>(deliveryInvoiceHeaderId)) //if invoiceHeader doesnt exist
                    {
                        string NewDocNum = efMethods.GetNextDocNum(true, processCode, "DocumentNumber", "TrInvoiceHeaders", 6);

                        deliveryInvoHeader = new();
                        deliveryInvoHeader.InvoiceHeaderId = deliveryInvoiceHeaderId;
                        //deliveryInvoHeader.RelatedInvoiceId = trInvoiceHeader.InvoiceHeaderId;
                        deliveryInvoHeader.DocumentNumber = NewDocNum;
                        deliveryInvoHeader.ProcessCode = processCode;
                        deliveryInvoHeader.CurrAccCode = unDeliveredViewModel.TrInvoiceHeader.CurrAccCode;
                        deliveryInvoHeader.OfficeCode = Authorization.OfficeCode;
                        deliveryInvoHeader.StoreCode = Authorization.StoreCode;
                        deliveryInvoHeader.CreatedUserName = Authorization.CurrAccCode;
                        deliveryInvoHeader.WarehouseCode = efMethods.SelectWarehouseByStore(Authorization.StoreCode);
                        deliveryInvoHeader.IsMainTF = true;

                        efMethods.InsertEntity(deliveryInvoHeader);

                        trInvoiceHeadersBindingSource.DataSource = efMethods.SelectEntityById<TrInvoiceHeader>(unDeliveredViewModel.TrInvoiceHeader.InvoiceHeaderId);
                    }

                    if (!efMethods.WaybillExistByInvoiceLine(invoiceLineID))
                    {
                        TrInvoiceLine invoiceLine = efMethods.SelectInvoiceLine(invoiceLineID);
                        TrInvoiceLine deliveryInvoiceLine = new();


                        deliveryInvoiceLine.InvoiceLineId = Guid.NewGuid();
                        deliveryInvoiceLine.InvoiceHeaderId = deliveryInvoiceHeaderId;
                        deliveryInvoiceLine.RelatedLineId = invoiceLineID;
                        deliveryInvoiceLine.ProductCode = invoiceLine.ProductCode;
                        deliveryInvoiceLine.CreatedUserName = Authorization.CurrAccCode;

                        if ((bool)CustomExtensions.DirectionIsIn(processCode))
                            deliveryInvoiceLine.QtyIn = formQty.qty;
                        else if (!(bool)CustomExtensions.DirectionIsIn(processCode))
                            deliveryInvoiceLine.QtyOut = formQty.qty;

                        efMethods.InsertEntity(deliveryInvoiceLine);

                        List<TrInvoiceLine> deliveryLines = efMethods.SelectInvoiceLines(deliveryInvoiceHeaderId);
                        gC_DeliveryInvoiceLine.DataSource = deliveryLines;
                    }
                    else
                        efMethods.UpdateInvoiceLineQtyOut(deliveryInvoiceHeaderId, invoiceLineID, formQty.qty * (-1));


                    var gridRow = gV_InvoiceLine.GetFocusedRow() as UnDeliveredViewModel;

                    if (gridRow != null)
                    {
                        gridRow.ReturnQty += formQty.qty;
                        gridRow.RemainingQty -= formQty.qty;

                        gV_InvoiceLine.RefreshRow(gV_InvoiceLine.FocusedRowHandle);
                    }


                    LoadDataStreamedAsync(unDeliveredViewModel.TrInvoiceHeader.InvoiceHeaderId);

                    //gC_InvoiceLine.DataSource = null;
                }
            }

        }
    }
}
