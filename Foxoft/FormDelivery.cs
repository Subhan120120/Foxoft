using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using Foxoft.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Foxoft
{
    public partial class FormDelivery : XtraForm
    {
        private readonly BindingList<DeliveryHeaderVM> _master = new BindingList<DeliveryHeaderVM>();
        private readonly Dictionary<Guid, DeliveryHeaderVM> _index = new Dictionary<Guid, DeliveryHeaderVM>();
        private CancellationTokenSource _cts;

        public sealed class DeliveryHeaderVM
        {
            public TrInvoiceHeader Header { get; set; }
            public BindingList<UnDeliveredViewModel> Lines { get; } = new BindingList<UnDeliveredViewModel>();

            // Master grid üçün rahat sütunlar:
            public string DocumentNumber => Header?.DocumentNumber;
            public DateTime DocumentDate => Header?.DocumentDate ?? DateTime.MinValue;
            public string CurrAccCode => Header?.CurrAccCode;
            public string CurrAccDesc => Header?.CurrAccDesc;
            public decimal TotalNetAmount => Header?.TotalNetAmount ?? 0m;

            // Hesablanmış: detail cəmi
            public decimal RemainingTotal => Lines.Sum(x => x.RemainingQty * (x.TrInvoiceLine?.PriceLoc ?? 0m));
        }


        public FormDelivery()
        {
            InitializeComponent2();
            InitGrids();
        }

        private GridControl grid;
        private GridView gvMaster;
        private GridView gvDetail;
        private SimpleButton btnLoad, btnCancel;
        private TextEdit txtInvoiceFilter;

        private void InitializeComponent2()
        {
            this.grid = new GridControl();
            this.gvMaster = new GridView();
            this.gvDetail = new GridView();
            this.btnLoad = new SimpleButton();
            this.btnCancel = new SimpleButton();
            this.txtInvoiceFilter = new TextEdit();

            // Form
            this.Text = "FormDelivery — Çatdırılmamış sətirlər (stream load)";
            this.WindowState = FormWindowState.Maximized;

            // GridControl
            grid.Dock = DockStyle.Fill;
            grid.MainView = gvMaster;
            grid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gvMaster, gvDetail });

            // Master View
            gvMaster.OptionsBehavior.Editable = false;
            gvMaster.OptionsView.ShowGroupPanel = false;
            gvMaster.OptionsView.ColumnAutoWidth = false;
            gvMaster.OptionsDetail.EnableMasterViewMode = true;
            gvMaster.OptionsDetail.ShowDetailTabs = false;
            gvMaster.OptionsDetail.AllowExpandEmptyDetails = true;
            gvMaster.MasterRowEmpty += (s, e) =>
            {
                if (e.RowHandle < 0) { e.IsEmpty = true; return; }
                var vm = gvMaster.GetRow(e.RowHandle) as DeliveryHeaderVM;
                e.IsEmpty = vm == null || vm.Lines.Count == 0;
            };

            // Detail View
            gvDetail.OptionsBehavior.Editable = false;
            gvDetail.OptionsView.ShowGroupPanel = false;
            gvDetail.OptionsView.ColumnAutoWidth = false;

            // LevelTree (relation adı Lines — VM property-si)
            var level = new GridLevelNode
            {
                RelationName = "Lines",
                LevelTemplate = gvDetail
            };
            grid.LevelTree.Nodes.Add(level);

            // Top panel (controls)
            var panel = new Panel { Dock = DockStyle.Top, Height = 48 };
            btnLoad.Text = "Yüklə (Async)";
            btnLoad.Width = 120;
            btnLoad.Left = 8;
            btnLoad.Top = 8;
            btnLoad.Click += async (s, e) => await StartLoadAsync(ParseInvoiceHeaderId());

            btnCancel.Text = "Ləğv et";
            btnCancel.Width = 100;
            btnCancel.Left = btnLoad.Right + 8;
            btnCancel.Top = 8;
            btnCancel.Click += (s, e) => _cts?.Cancel();

            txtInvoiceFilter.Width = 320;
            txtInvoiceFilter.Left = btnCancel.Right + 16;
            txtInvoiceFilter.Top = 10;
            txtInvoiceFilter.Properties.NullValuePrompt = "InvoiceHeaderId (isteğe bağlı, GUID)";

            panel.Controls.Add(btnLoad);
            panel.Controls.Add(btnCancel);
            panel.Controls.Add(txtInvoiceFilter);

            this.Controls.Add(grid);
            this.Controls.Add(panel);
        }

        private Guid? ParseInvoiceHeaderId()
        {
            var txt = txtInvoiceFilter.Text?.Trim();
            if (Guid.TryParse(txt, out var gid)) return gid;
            return null;
        }

        private void InitGrids()
        {
            // Master columns
            gvMaster.Columns.Clear();
            gvMaster.Columns.AddVisible(nameof(DeliveryHeaderVM.DocumentDate), "Tarix").DisplayFormat.FormatString = "yyyy-MM-dd";
            gvMaster.Columns.AddVisible(nameof(DeliveryHeaderVM.DocumentNumber), "No");
            gvMaster.Columns.AddVisible(nameof(DeliveryHeaderVM.CurrAccCode), "Cari Kod");
            gvMaster.Columns.AddVisible(nameof(DeliveryHeaderVM.CurrAccDesc), "Cari Adı").Width = 200;
            gvMaster.Columns.AddVisible(nameof(DeliveryHeaderVM.TotalNetAmount), "Faktura Tutarı (YPV)").DisplayFormat.FormatString = "n2";
            gvMaster.Columns.AddVisible(nameof(DeliveryHeaderVM.RemainingTotal), "Qalan Tutar (YPV)").DisplayFormat.FormatString = "n2";

            // Detail columns (UnDeliveredViewModel tərəfi)
            gvDetail.Columns.Clear();
            gvDetail.Columns.AddVisible("TrInvoiceLine.ProductCode", "Məhsul");
            gvDetail.Columns.AddVisible("TrInvoiceLine.PriceLoc", "Qiymət (YPV)").DisplayFormat.FormatString = "n2";
            gvDetail.Columns.AddVisible("ReturnQty", "Qaytarılan Say").DisplayFormat.FormatString = "n2";
            gvDetail.Columns.AddVisible("RemainingQty", "Qalan Say").DisplayFormat.FormatString = "n2";
            gvDetail.Columns.AddVisible("TrInvoiceLine.AmountLoc", "Sətir Tutar (YPV)").DisplayFormat.FormatString = "n2";

            // Data binding
            grid.DataSource = _master;

            // Footer cəmləri
            gvMaster.OptionsView.ShowFooter = true;
            gvMaster.Columns[nameof(DeliveryHeaderVM.RemainingTotal)]?.Summary.Add(DevExpress.Data.SummaryItemType.Sum, nameof(DeliveryHeaderVM.RemainingTotal), "Cəm={0:n2}");
            gvDetail.OptionsView.ShowFooter = true;
            gvDetail.Columns["RemainingQty"]?.Summary.Add(DevExpress.Data.SummaryItemType.Sum, "RemainingQty", "Cəm={0:n2}");
        }

        private void ResetAll()
        {
            _index.Clear();
            _master.Clear();
        }

        private async Task StartLoadAsync(Guid? filterInvoiceHeaderId)
        {
            _cts?.Cancel();
            _cts = new CancellationTokenSource();

            ResetAll();

            try
            {
                btnLoad.Enabled = false;
                btnCancel.Enabled = true;

                // Sizin mövcud stream metodunuzdan istifadə:
                // StreamInvoiceLinesForDeliveryAsync(Guid? invoiceHeader = null, CancellationToken ct = default)
                await foreach (var row in StreamInvoiceLinesForDeliveryAsync(filterInvoiceHeaderId, _cts.Token))
                {
                    _cts.Token.ThrowIfCancellationRequested();
                    AddRowToUI(row);
                }
            }
            catch (OperationCanceledException)
            {
                XtraMessageBox.Show("Yükləmə ləğv edildi.", "Məlumat", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnLoad.Enabled = true;
                btnCancel.Enabled = false;
            }
        }

        private void AddRowToUI(UnDeliveredViewModel vmLine)
        {
            if (vmLine?.TrInvoiceHeader == null) return;
            var hid = vmLine.TrInvoiceHeader.InvoiceHeaderId;

            if (!_index.TryGetValue(hid, out var headerVm))
            {
                headerVm = new DeliveryHeaderVM
                {
                    Header = vmLine.TrInvoiceHeader
                };
                _index.Add(hid, headerVm);
                _master.Add(headerVm);
            }

            headerVm.Lines.Add(vmLine);
            // Detail cəm dəyişirsə, master sətrini yeniləmək üçün:
            var rowHandle = gvMaster.LocateByValue(nameof(DeliveryHeaderVM.DocumentNumber), headerVm.DocumentNumber);
            if (rowHandle >= 0) gvMaster.RefreshRow(rowHandle);
        }

        // ======= Demo: Sizin verdiyiniz LINQ-a uyğun stream qaynağı =======
        // Sizdə artıq buna bənzər metod var — onu istifadə edin.
        // Burada işlək demo üçün minimal versiya saxlayıram.
        public async IAsyncEnumerable<UnDeliveredViewModel> StreamInvoiceLinesForDeliveryAsync(
            Guid? invoiceHeader = null,
            [System.Runtime.CompilerServices.EnumeratorCancellation] CancellationToken cancellationToken = default)
        {
            await using var db = new subContext();

            var baseQuery = db.TrInvoiceLines
                .Include(x => x.DcProduct)
                .Include(x => x.TrInvoiceHeader).ThenInclude(x => x.DcCurrAcc)
                .Where(x => new[] { "RS", "WS" }.Contains(x.TrInvoiceHeader.ProcessCode)
                            && (!invoiceHeader.HasValue || x.InvoiceHeaderId == invoiceHeader.Value))
                .OrderByDescending(x => x.TrInvoiceHeader.DocumentDate)
                .AsAsyncEnumerable()
                .WithCancellation(cancellationToken);

            await foreach (var x in baseQuery)
            {
                cancellationToken.ThrowIfCancellationRequested();

                var returned = await db.TrInvoiceLines
                    .Where(y => y.RelatedLineId == x.InvoiceLineId && new[] { "WI", "WO" }.Contains(y.TrInvoiceHeader.ProcessCode))
                    .SumAsync(y => y.QtyIn - y.QtyOut, cancellationToken);

                var original = x.QtyIn - x.QtyOut;
                var remaining = Math.Abs(original) - Math.Abs(returned);
                if (remaining <= 0) continue;

                yield return new UnDeliveredViewModel
                {
                    TrInvoiceLine = x,
                    TrInvoiceHeader = x.TrInvoiceHeader,
                    DeliveryQty = Math.Abs(returned),
                    RemainingQty = remaining
                };
            }
        }
    }
}