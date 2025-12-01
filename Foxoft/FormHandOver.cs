using DevExpress.DataAccess.Sql;
using DevExpress.Utils.Diagnostics;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Alerter;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraMap.Drawing.DirectD3D9;
using DevExpress.XtraReports.UI;
using Foxoft.Models;
using Foxoft.Properties;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing.Printing;
using System.IO;
using System.Windows.Forms;
using System.Xml;

namespace Foxoft
{
    public partial class FormHandOver : RibbonForm
    {
        public Guid deliveryInvoiceHeaderId;
        public TrInvoiceHeader deliveryInvoHeader;
        public Guid invoiceLineID;
        public string processCode;
        readonly SettingStore settingStore;
        ReportClass reportClass;
        string reportFileNameInvoiceWare = @"InvoiceRS_A4_depo.repx";

        private readonly BindingList<DeliveryVM> _master = new();
        private readonly Dictionary<Guid, DeliveryVM> _index = new();

        private CancellationTokenSource _cts;

        EfMethods efMethods = new();

        public sealed class DeliveryVM
        {
            public TrInvoiceHeader TrInvoiceHeader { get; set; }

            //public decimal TotalNetAmount => TrInvoiceHeader?.TotalNetAmount ?? 0m;

            public BindingList<Line> Lines { get; } = new BindingList<Line>();

            // Hesablanmış: detail cəmi
            //public decimal RemainingTotal => Lines.Sum(x => x.RemainingQty * (x.PriceLoc));

            // Detail VM – əvvəlki UnDeliveredViewModel-in yerinə
            public sealed class Line
            {
                public TrInvoiceLine TrInvoiceLine { get; set; }
                public TrInvoiceHeader TrInvoiceHeader => TrInvoiceLine?.TrInvoiceHeader;

                public decimal DeliveredQty { get; set; }
                public decimal RemainingQty { get; set; }
            }
        }


        public FormHandOver()
        {
            InitializeComponent();
            //gC_Invoice.DataSource = liveList;

            gC_Invoice.DataSource = _master;

            ClearControls();

            //LoadInvoiceLinesAsync();

            //gvMaster.BestFitColumns();
            settingStore = efMethods.SelectSettingStore(Authorization.StoreCode);
            reportClass = new(settingStore.DesignFileFolder);

            //Foxoft.Models.subContext dbContext = new Foxoft.Models.subContext();

            //dbContext.TrInvoiceHeaders.LoadAsync().ContinueWith(loadTask =>
            //{

            //    trInvoiceHeadersBindingSource.DataSource = dbContext.TrInvoiceHeaders.Local.ToBindingList();
            //}, System.Threading.Tasks.TaskScheduler.FromCurrentSynchronizationContext());

            //dataLayoutControl1.BestFit();
            //dataLayoutControl1.Size = dataLayoutControl1.PreferredSize;
        }

        public FormHandOver(string processCode)
           : this()
        {
            this.processCode = processCode;
        }

        private void FormWaybill_Load(object sender, EventArgs e)
        {
            //gC_InvoiceLine.DataSource = liveList;

            gvMaster.OptionsView.ShowDetailButtons = false;
            LoadDataStreamedAsync();

            LoadLayout();
        }

        private async void BBI_Refresh_ItemClick(object sender, ItemClickEventArgs e)
        {
            await LoadDataStreamedAsync();
        }

        private void ClearControls()
        {
            deliveryInvoiceHeaderId = Guid.NewGuid();
            deliveryInvoHeader = new TrInvoiceHeader();

            gC_DeliveryInvoiceLine.DataSource = null;
            trInvoiceHeadersBindingSource.DataSource = new TrInvoiceHeader() { };
        }

        // class fields
        //private CancellationTokenSource _cts;
        private int _loadSeq;

        private async Task LoadDataStreamedAsync(Guid? filterInvoiceHeaderId = null)
        {
            // cancel & dispose any previous run
            _cts?.Cancel();
            _cts?.Dispose();

            _cts = new CancellationTokenSource();
            var cts = _cts;                    // capture for this run
            var mySeq = Interlocked.Increment(ref _loadSeq);

            ResetAll();

            try
            {
                await foreach (var row in StreamInvoiceLinesForDeliveryAsync(filterInvoiceHeaderId, cts.Token))
                {
                    // guard against races/newer loads
                    if (cts.IsCancellationRequested || mySeq != _loadSeq)
                        break;

                    AddRowToUI(row);

                    // second guard for ultra-tight races
                    if (cts.IsCancellationRequested || mySeq != _loadSeq)
                        break;
                }
            }
            // only show the message if THIS run is still the active one
            catch (OperationCanceledException) when (ReferenceEquals(cts, _cts))
            {
            }
            catch (Exception ex)
            {
            }
            finally
            {
                // only touch UI if this run is still current
                if (ReferenceEquals(cts, _cts) && gvMaster.RowCount > 0)
                {
                    gvMaster.FocusedRowHandle = 0;
                    gvMaster.SetMasterRowExpanded(0, true);
                }
            }
        }


        private void ResetAll()
        {
            _index.Clear();
            _master.Clear();
        }


        private void AddRowToUI(DeliveryVM.Line line)
        {
            if (line?.TrInvoiceHeader == null) return;
            var hid = line.TrInvoiceHeader.InvoiceHeaderId;

            if (!_index.TryGetValue(hid, out var headerVm))
            {
                headerVm = new DeliveryVM
                {
                    TrInvoiceHeader = line.TrInvoiceHeader
                };
                _index.Add(hid, headerVm);
                _master.Add(headerVm);
            }

            headerVm.Lines.Add(line);

            // Master row-u təravətləndir
            var rowHandle = gvMaster.LocateByValue(nameof(TrInvoiceHeader.DocumentNumber), headerVm.TrInvoiceHeader.DocumentNumber);
            if (rowHandle >= 0) gvMaster.RefreshRow(rowHandle);
        }


        public async IAsyncEnumerable<DeliveryVM.Line> StreamInvoiceLinesForDeliveryAsync(
    Guid? invoiceHeader = null,
    [System.Runtime.CompilerServices.EnumeratorCancellation] CancellationToken cancellationToken = default)
        {
            await using var db = new subContext();

            var baseQuery = db.TrInvoiceLines
                .Include(x => x.DcProduct)
                .Include(x => x.TrInvoiceHeader).ThenInclude(x => x.DcCurrAcc)
                .Where(x => new[] { "RS", "WS" }.Contains(x.TrInvoiceHeader.ProcessCode)
                            && (!invoiceHeader.HasValue || x.InvoiceHeaderId == invoiceHeader.Value)
                            && !x.TrInvoiceHeader.IsReturn)
                .OrderByDescending(x => x.TrInvoiceHeader.DocumentDate)
                .ThenByDescending(x => x.TrInvoiceHeader.DocumentTime)
                .AsAsyncEnumerable()
                .WithCancellation(cancellationToken);

            await foreach (var x in baseQuery)
            {
                cancellationToken.ThrowIfCancellationRequested();

                var returned = await db.TrInvoiceLines
                    .Include(y => y.TrInvoiceHeader)
                    .Where(y => y.RelatedLineId == x.InvoiceLineId
                        && new[] { "RS", "WS" }.Contains(y.TrInvoiceHeader.ProcessCode)
                        && y.TrInvoiceHeader.IsReturn)
                    .SumAsync(y => y.QtyIn - y.QtyOut, cancellationToken);

                var delivered = await db.TrInvoiceLines
                    .Include(y => y.TrInvoiceHeader)
                    .Where(y => y.RelatedLineId == x.InvoiceLineId
                        && new[] { "WI", "WO" }.Contains(y.TrInvoiceHeader.ProcessCode))
                    .SumAsync(y => y.QtyIn - y.QtyOut, cancellationToken);

                var original = x.QtyIn - x.QtyOut;
                var remaining = Math.Abs(original) - Math.Abs(returned) - Math.Abs(delivered);
                if (remaining <= 0) continue;

                yield return new DeliveryVM.Line
                {
                    TrInvoiceLine = x,
                    DeliveredQty = Math.Abs(delivered),
                    RemainingQty = remaining
                };
            }
        }



        private void FormWaybill_FormClosing(object sender, FormClosingEventArgs e)
        {
            _cts?.Cancel();
        }

        private void btn_Ok_Click(object sender, EventArgs e)
{
    if (DialogResult.OK == XtraMessageBox.Show(
            Resources.Form_HandOver_OpenInvoiceQuestion,
            Resources.Common_Attention,
            MessageBoxButtons.OKCancel))
    {
        OpenFormInvoice(deliveryInvoHeader.DocumentNumber);
    }

    ClearControls();
    LoadDataStreamedAsync();
}

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(
                    Resources.Form_HandOver_CancelQuestion,
                    Resources.Common_Attention,
                    MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (efMethods.EntityExists<TrInvoiceHeader>(deliveryInvoiceHeaderId))
                {
                    efMethods.DeleteInvoice(deliveryInvoiceHeaderId);

                    ClearControls();
                    LoadDataStreamedAsync();
                }
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
                    MessageBox.Show(Resources.Common_AccessDenied);
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
            {
                MessageBox.Show(Resources.Form_HandOver_NoDocument);
            }
        }


        private void gV_DeliveryInvoiceLine_CalcPreviewText(object sender, CalcPreviewTextEventArgs e)
        {
            GridView view = sender as GridView;
            if (view == null) return;

            string SalesPersonCode = view.GetRowCellDisplayText(e.RowHandle, col_SalesPersonCode);

            //e.PreviewText = CustomExtensions.GetPreviewText(0, 0, 0, 0, String.Empty, SalesPersonCode);
        }

        private void gV_InvoiceHeader_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
        }

        private void repoBtn_AddWaybill_ButtonPressed(object sender, ButtonPressedEventArgs e)
        {
            var editor = sender as ButtonEdit;
            if (editor == null) return;

            var grid = editor.Parent as GridControl;       // detail GridControl
            var view = grid?.FocusedView as GridView;      // aktiv detail GridView
            if (view == null) return;

            var val = view.GetFocusedRowCellValue(col_InvoiceLineId);
            if (val == null || val == DBNull.Value) return;

            Guid invoiceLineID = (Guid)val;

            // Daha etibarlı: seçilmiş detail sətrindən başlıq ID-si
            var focusedDetailRow = view.GetFocusedRow() as DeliveryVM.Line;
            Guid invoiceHeaderId = focusedDetailRow?.TrInvoiceHeader.InvoiceHeaderId
                                   ?? (Guid)gvMaster.GetFocusedRowCellValue(col_InvoiceHeaderId);

            decimal maxDelivery = (decimal)(view.GetFocusedRowCellValue(col_RemainingQty));
            if (!(maxDelivery > 0))
            {
                XtraMessageBox.Show(Resources.Form_HandOver_NoRemainingQty);
                return;
            }

            using (FormInput formQty = new(maxDelivery))
            {
                if (formQty.ShowDialog(this) == DialogResult.OK)
                {
                    if (!efMethods.EntityExists<TrInvoiceHeader>(deliveryInvoiceHeaderId))
                    {
                        string NewDocNum = efMethods.GetNextDocNum(true, processCode, "DocumentNumber", "TrInvoiceHeaders", 6);

                        deliveryInvoHeader = new();
                        deliveryInvoHeader.InvoiceHeaderId = deliveryInvoiceHeaderId;
                        deliveryInvoHeader.RelatedInvoiceId = invoiceHeaderId;
                        deliveryInvoHeader.DocumentNumber = NewDocNum;
                        deliveryInvoHeader.ProcessCode = processCode;
                        if (_index.ContainsKey(invoiceHeaderId))
                            deliveryInvoHeader.CurrAccCode = _index[invoiceHeaderId].TrInvoiceHeader.CurrAccCode;
                        deliveryInvoHeader.OfficeCode = Authorization.OfficeCode;
                        deliveryInvoHeader.StoreCode = Authorization.StoreCode;
                        deliveryInvoHeader.CreatedUserName = Authorization.CurrAccCode;
                        deliveryInvoHeader.WarehouseCode = _index[invoiceHeaderId].TrInvoiceHeader.WarehouseCode;
                        deliveryInvoHeader.IsMainTF = true;

                        efMethods.InsertEntity(deliveryInvoHeader);

                        trInvoiceHeadersBindingSource.DataSource = efMethods.SelectInvoiceHeader(invoiceHeaderId);
                    }

                    if (!efMethods.InvoicelineExistByRelatedLineId(deliveryInvoiceHeaderId, invoiceLineID))
                    {
                        TrInvoiceLine invoiceLine = efMethods.SelectInvoiceLine(invoiceLineID);
                        TrInvoiceLine deliveryInvoiceLine = new();

                        deliveryInvoiceLine.InvoiceLineId = Guid.NewGuid();
                        deliveryInvoiceLine.InvoiceHeaderId = deliveryInvoiceHeaderId;
                        deliveryInvoiceLine.RelatedLineId = invoiceLineID;
                        deliveryInvoiceLine.ProductCode = invoiceLine.ProductCode;
                        deliveryInvoiceLine.CreatedUserName = Authorization.CurrAccCode;

                        if ((bool)CustomExtensions.DirectionIsIn(processCode))
                            deliveryInvoiceLine.QtyIn = formQty.input;
                        else
                            deliveryInvoiceLine.QtyOut = formQty.input;

                        efMethods.InsertEntity(deliveryInvoiceLine);
                    }
                    else
                    {
                        TrInvoiceLine trInvoiceLine = efMethods.SelectTrInvoiceLineByRelatedLineId(deliveryInvoiceHeaderId, invoiceLineID);

                        trInvoiceLine.Amount = (formQty.input + trInvoiceLine.QtyOut) * trInvoiceLine.Price;
                        trInvoiceLine.AmountLoc = (formQty.input + trInvoiceLine.QtyOut) * trInvoiceLine.PriceLoc;
                        trInvoiceLine.NetAmount = (formQty.input + trInvoiceLine.QtyOut) * trInvoiceLine.Price * (100 - trInvoiceLine.PosDiscount);
                        trInvoiceLine.NetAmountLoc = (formQty.input + trInvoiceLine.QtyOut) * trInvoiceLine.PriceLoc * (100 - trInvoiceLine.PosDiscount);
                        trInvoiceLine.QtyOut = formQty.input + trInvoiceLine.QtyOut;

                        efMethods.UpdateEntity(trInvoiceLine);
                    }

                    // UI yenilə
                    List<TrInvoiceLine> deliveryLines = efMethods.SelectInvoiceLines(deliveryInvoiceHeaderId);
                    gC_DeliveryInvoiceLine.DataSource = deliveryLines;

                    // Seçilmiş detail sətrin lokaldakı hesablanmış dəyərlərini yenilə
                    if (focusedDetailRow != null)
                    {
                        focusedDetailRow.DeliveredQty += formQty.input;
                        focusedDetailRow.RemainingQty -= formQty.input;
                        view.RefreshRow(view.FocusedRowHandle);
                    }

                    LoadDataStreamedAsync(invoiceHeaderId);
                }
            }
        }


        private async void BBI_ReportPrintFast_ItemClick(object sender, ItemClickEventArgs e)
        {
            await PrintFast(settingStore.PrinterName);
        }

        private async Task PrintFast(string printerName)
        {
            AlertControl alertControl1 = new AlertControl()
            {
                AutoFormDelay = 3000,
                FormDisplaySpeed = AlertFormDisplaySpeed.Fast
            };

            alertControl1.Show(
                this,
                Resources.Common_PrintSending,
                string.Format(Resources.Common_PrinterLabel, printerName),
                "",
                (Image)null,
                null);

            if (deliveryInvoHeader is not null)
                await Task.Run(() => GetPrint(deliveryInvoHeader.InvoiceHeaderId, printerName));
            else
                MessageBox.Show(Resources.Form_HandOver_NoInvoiceToPrint);

            alertControl1.Show(
                this,
                Resources.Common_PrintSent,
                string.Format(Resources.Common_PrinterLabel, printerName),
                "",
                (Image)null,
                null);
        }


        private void GetPrint(Guid invoiceHeaderId, string printerName)
        {
            XtraReport report = GetInvoiceReport(reportFileNameInvoiceWare);
            report.PrinterName = printerName;

            if (report is not null)
            {
                ReportPrintTool printTool = new(report);
                printTool.Print();
                efMethods.UpdateInvoicePrintCount(invoiceHeaderId);
            }
            report.Dispose();
        }

        private XtraReport GetInvoiceReport(string fileName)
        {
            DsMethods dsMethods = new();
            SqlQuery sqlQuerySale = dsMethods.SelectInvoice(deliveryInvoHeader.InvoiceHeaderId);
            return reportClass.GetReport("invoice", fileName, new SqlQuery[] { sqlQuerySale });
        }

        private void popupMenuPrinters_BeforePopup(object sender, CancelEventArgs e)
        {
            PopupMenu menu = (sender as PopupMenu);
            menu.ItemLinks.Clear();

            try
            {
                foreach (string printer in PrinterSettings.InstalledPrinters)
                {
                    BarButtonItem BBI = new();
                    BBI.Caption = printer;
                    BBI.Name = printer;
                    BBI.ImageOptions.SvgImage = svgImageCollection1["quickprint"];
                    BBI.ItemClick += async (sender, e) =>
                    {
                        await PrintFast(printer);
                    };

                    menu.AddItem(BBI);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format(Resources.Form_HandOver_PrinterError, ex.Message));
            }

            e.Cancel = false;
        }

        private void LoadLayout()
        {
            string fileNameR = "UnDeliveredLayoutMaster.xml";
            string layoutHeaderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "Foxoft", Settings.Default.CompanyCode, "Layout Xml Files", fileNameR);

            if (File.Exists(layoutHeaderPath))
                dataLayoutControl1.RestoreLayoutFromXml(layoutHeaderPath);

            string layoutFileDir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "Foxoft", Settings.Default.CompanyCode, "Layout Xml Files");
            string fileNameM = "UnDeliveredLayoutMaster.xml";
            string fileM = Path.Combine(layoutFileDir, fileNameM);

            if (File.Exists(fileM))
                gvMaster.RestoreLayoutFromXml(fileM);

            string fileNameD = "UnDeliveredLayoutDetail.xml";
            string fileD = Path.Combine(layoutFileDir, fileNameD);

            if (File.Exists(fileD))
                gvDetail.RestoreLayoutFromXml(fileD);
        }

        private void SaveLayout()
        {
            string layoutFileDir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "Foxoft", Settings.Default.CompanyCode, "Layout Xml Files");

            if (!Directory.Exists(layoutFileDir))
                Directory.CreateDirectory(layoutFileDir);
            {
                string fileNameM = "UnDeliveredLayoutMaster.xml";
                gvMaster.SaveLayoutToXml(Path.Combine(layoutFileDir, fileNameM));
                string fileNameD = "UnDeliveredLayoutDetail.xml";
                gvDetail.SaveLayoutToXml(Path.Combine(layoutFileDir, fileNameD));
            }
        }

        private void BBI_GridLayoutSave_ItemClick(object sender, ItemClickEventArgs e)
        {
            SaveLayout();
        }

        private void GvMaster_MasterRowEmpty(object sender, DevExpress.XtraGrid.Views.Grid.MasterRowEmptyEventArgs e)
        {
            if (e.RowHandle < 0) { e.IsEmpty = true; return; }
            var vm = gvMaster.GetRow(e.RowHandle) as DeliveryVM;
            e.IsEmpty = vm == null || vm.Lines.Count == 0;
        }

        private void GvMaster_RowClick(object sender, RowClickEventArgs e)
        {
            var view = sender as GridView;
            if (view == null) return;

            if (view.GetMasterRowExpanded(e.RowHandle))
                view.CollapseMasterRow(e.RowHandle);
            else
                view.ExpandMasterRow(e.RowHandle);
        }




    }
}
