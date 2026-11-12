using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraWizard;
using Foxoft.Migrations;
using Foxoft.Models;
using Foxoft.Models.Entity;
using Foxoft.Models.ViewModel;
using Foxoft.Properties;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Foxoft
{
    public partial class FormCounting : Form
    {
        private List<CountingLineVM> countingVM;
        private readonly List<TrInvoiceLine> rawInvoiceLines;
        private readonly EfMethods efMethods = new();
        private readonly Guid relatedInvoiceId;

        public FormCounting(List<TrInvoiceLine> invoiceLines, Guid relatedInvoiceId)
        {
            InitializeComponent();

            this.relatedInvoiceId = relatedInvoiceId;
            this.rawInvoiceLines = invoiceLines ?? new List<TrInvoiceLine>();
            this.countingVM = LoadAndAggregateCountingLines();
            LUE_StoreCode.Properties.DataSource = efMethods.SelectStores();

            if (!string.IsNullOrEmpty(Authorization.StoreCode) && LUE_StoreCode.EditValue == null)
            {
                LUE_StoreCode.EditValue = Authorization.StoreCode;
            }

            checkEdit_AutoAddCostPrice.Checked = Settings.Default.CountingAutoAddCostPrice;
        }

        private void WizardControl1_NextClick(object sender, WizardCommandButtonClickEventArgs e)
        {
            if (e.Page == welcomeWizardPage1)
            {
                countingVM = LoadAndAggregateCountingLines();

                if (checkEdit_AutoAddCostPrice.Checked)
                {
                    ApplyProductCosts(countingVM);
                }

                string warehouseCode = LUE_WarehouseCode.EditValue?.ToString();

                countingVM.ForEach(x =>
                {
                    x.Balance = CalcProductBalance(x.SerialNumberCode, x.ProductCode, warehouseCode, 0);
                    x.Difference = x.Qty - x.Balance;
                });

                gridControl1.DataSource = countingVM;
                gridControl1.RefreshDataSource();
            }

            if (e.Page == wizardPage2)
            {

            }
        }

        private List<CountingLineVM> LoadAndAggregateCountingLines()
        {
            var validRawLines = rawInvoiceLines
                .Where(x => !string.IsNullOrWhiteSpace(x.ProductCode))
                .ToList();

            var mappedLines = AutoMapper<TrInvoiceLine, CountingLineVM>.MapList(validRawLines, (src, dest) =>
            {
                if (dest.Qty == 0 && (src.QtyIn != 0 || src.QtyOut != 0))
                    dest.Qty = src.QtyIn != 0 ? src.QtyIn : src.QtyOut;
                if (dest.QtyIn == 0 && dest.Qty != 0)
                    dest.QtyIn = dest.Qty;
                if (string.IsNullOrWhiteSpace(dest.Barcode) && !string.IsNullOrWhiteSpace(src.Barcode))
                    dest.Barcode = src.Barcode;
            });

            var aggregated = mappedLines
                .GroupBy(x => new
                {
                    ProductCode = x.ProductCode.Trim(),
                    SerialNumberCode = string.IsNullOrWhiteSpace(x.SerialNumberCode) ? string.Empty : x.SerialNumberCode.Trim()
                })
                .Select(g =>
                {
                    var first = g.First();

                    decimal totalQty = g.Sum(x => x.Qty);
                    decimal totalQtyIn = g.Sum(x => x.QtyIn != 0 ? x.QtyIn : x.Qty);
                    decimal totalQtyOut = g.Sum(x => x.QtyOut);

                    if (totalQty == 0 && totalQtyIn > 0)
                        totalQty = totalQtyIn;

                    var linesWithPrice = g.Where(x => x.Price > 0).ToList();
                    decimal price = 0m;
                    if (linesWithPrice.Count > 0)
                    {
                        decimal sumQtyPrice = linesWithPrice.Sum(x => (x.Qty != 0 ? x.Qty : x.QtyIn) * x.Price);
                        decimal sumQty = linesWithPrice.Sum(x => (x.Qty != 0 ? x.Qty : x.QtyIn));
                        price = sumQty > 0 ? Math.Round(sumQtyPrice / sumQty, 4) : linesWithPrice[0].Price;
                    }
                    else
                    {
                        price = first.Price;
                    }

                    float exchangeRate = g.Select(x => x.ExchangeRate).FirstOrDefault(r => r > 0);
                    if (exchangeRate == 0) exchangeRate = 1;

                    var linesWithCost = g.Where(x => x.ProductCost.HasValue && x.ProductCost.Value > 0).ToList();
                    decimal? productCost = null;
                    if (linesWithCost.Count > 0)
                    {
                        decimal sumQtyCost = linesWithCost.Sum(x => (x.Qty != 0 ? x.Qty : x.QtyIn) * x.ProductCost.Value);
                        decimal sumQty = linesWithCost.Sum(x => (x.Qty != 0 ? x.Qty : x.QtyIn));
                        productCost = sumQty > 0 ? Math.Round(sumQtyCost / sumQty, 4) : linesWithCost[0].ProductCost;
                    }
                    else
                    {
                        productCost = g.Select(x => x.ProductCost).FirstOrDefault(c => c.HasValue && c.Value > 0) ?? (price > 0 ? price : null);
                    }

                    var descriptions = g.Select(x => x.LineDescription)
                        .Where(d => !string.IsNullOrWhiteSpace(d))
                        .Select(d => d.Trim())
                        .Distinct()
                        .ToList();

                    first.ProductCode = g.Key.ProductCode;
                    first.SerialNumberCode = string.IsNullOrEmpty(g.Key.SerialNumberCode) ? null : g.Key.SerialNumberCode;
                    first.Qty = totalQty;
                    first.QtyIn = totalQtyIn;
                    first.QtyOut = totalQtyOut;
                    first.Barcode = g.Select(x => x.Barcode).FirstOrDefault(b => !string.IsNullOrWhiteSpace(b)) ?? first.Barcode;
                    first.UnitOfMeasureId = g.Select(x => x.UnitOfMeasureId).FirstOrDefault(u => u.HasValue && u.Value > 0) ?? first.UnitOfMeasureId;
                    first.CurrencyCode = g.Select(x => x.CurrencyCode).FirstOrDefault(c => !string.IsNullOrWhiteSpace(c))
                        ?? Settings.Default.AppSetting?.LocalCurrencyCode ?? "AZN";
                    first.ExchangeRate = exchangeRate;
                    first.Price = price;
                    first.PriceLoc = Math.Round(price / (decimal)exchangeRate, 4);
                    first.ProductCost = productCost;
                    first.PosDiscount = g.Select(x => x.PosDiscount).FirstOrDefault(d => d > 0);
                    first.VatRate = g.Select(x => x.VatRate).FirstOrDefault(v => v > 0);
                    first.LineDescription = descriptions.Count > 0 ? string.Join("; ", descriptions) : null;

                    return first;
                })
                .ToList();

            return aggregated;
        }

        private void ApplyProductCosts(List<CountingLineVM> lines)
        {
            if (lines == null || lines.Count == 0)
                return;

            List<string> productCodes = lines
                .Where(x => !string.IsNullOrEmpty(x.ProductCode))
                .Select(x => x.ProductCode)
                .Distinct()
                .ToList();

            if (productCodes.Count == 0)
                return;

            using subContext db = new();

            Dictionary<string, decimal> costDict = new(StringComparer.OrdinalIgnoreCase);

            foreach (var chunk in productCodes.Chunk(1000))
            {
                var chunkCosts = db.DcProducts
                    .Where(p => chunk.Contains(p.ProductCode))
                    .Select(p => new
                    {
                        p.ProductCode,
                        Cost = SqlFunctions.GetProductCost(p.ProductCode, null),
                        p.PurchasePrice
                    })
                    .ToList();

                foreach (var item in chunkCosts)
                {
                    decimal effectiveCost = item.Cost > 0 ? item.Cost : (item.PurchasePrice > 0 ? item.PurchasePrice : 0m);
                    costDict[item.ProductCode] = effectiveCost;
                }
            }

            foreach (var line in lines)
            {
                if (costDict.TryGetValue(line.ProductCode, out decimal cost) && cost > 0)
                {
                    line.ProductCost = cost;
                    line.Price = cost;
                }
            }
        }

        private void WizardControl1_FinishClick(object sender, CancelEventArgs e)
        {
            string warehouseCode = LUE_WarehouseCode.EditValue?.ToString();

            Settings.Default.CountingAutoAddCostPrice = checkEdit_AutoAddCostPrice.Checked;
            Settings.Default.Save();

            if (countingVM.Where(x => x.Difference > 0).Any())
            {
                Guid invoiceHeaderId = Guid.NewGuid();

                TrInvoiceHeader invoiceHeader = new();
                invoiceHeader.InvoiceHeaderId = invoiceHeaderId;
                invoiceHeader.RelatedInvoiceId = relatedInvoiceId;
                string NewDocNum = efMethods.GetNextDocNum(true, "CI", nameof(TrInvoiceHeader.DocumentNumber), nameof(subContext.TrInvoiceHeaders), 6);
                invoiceHeader.DocumentNumber = NewDocNum;
                invoiceHeader.DocumentDate = DateTime.Now;
                invoiceHeader.DocumentTime = TimeSpan.Parse(DateTime.Now.ToString("HH:mm:ss"));
                invoiceHeader.ProcessCode = "CI";
                invoiceHeader.OfficeCode = Authorization.OfficeCode;
                invoiceHeader.StoreCode = Authorization.StoreCode;
                invoiceHeader.CreatedUserName = Authorization.CurrAccCode;
                invoiceHeader.IsMainTF = true;
                invoiceHeader.WarehouseCode = warehouseCode;

                efMethods.InsertEntity<TrInvoiceHeader>(invoiceHeader);

                countingVM.Where(x => x.Difference > 0).ToList().ForEach(x =>
                {
                    TrInvoiceLine invoiceLine = new();
                    invoiceLine.InvoiceHeaderId = invoiceHeaderId;
                    invoiceLine.InvoiceLineId = Guid.NewGuid();
                    invoiceLine.CreatedDate = DateTime.Now;
                    invoiceLine.CreatedUserName = Authorization.CurrAccCode;
                    invoiceLine.QtyIn = x.Difference;
                    invoiceLine.VatRate = x.VatRate;
                    invoiceLine.ExchangeRate = x.ExchangeRate;
                    invoiceLine.Amount = x.Amount;
                    invoiceLine.AmountLoc = x.AmountLoc;
                    invoiceLine.CurrencyCode = x.CurrencyCode;
                    invoiceLine.ExchangeRate = x.ExchangeRate;
                    invoiceLine.LineDescription = x.LineDescription;
                    invoiceLine.NetAmount = x.NetAmount;
                    invoiceLine.NetAmountLoc = x.NetAmountLoc;
                    invoiceLine.PosDiscount = x.PosDiscount;
                    invoiceLine.Price = x.Price;
                    invoiceLine.PriceLoc = x.PriceLoc;
                    invoiceLine.ProductCode = x.ProductCode;
                    invoiceLine.Barcode = x.Barcode;
                    invoiceLine.SerialNumberCode = x.SerialNumberCode;
                    invoiceLine.UnitOfMeasureId = x.UnitOfMeasureId;
                    invoiceLine.VatRate = x.VatRate;
                    invoiceLine.ProductCost = x.ProductCost ?? (x.Price > 0 ? x.Price : null);

                    efMethods.InsertEntity<TrInvoiceLine>(invoiceLine);
                });
            }

            if (countingVM.Where(x => x.Difference < 0).Any())
            {
                Guid invoiceHeaderId = Guid.NewGuid();

                TrInvoiceHeader invoiceHeader = new();
                invoiceHeader.InvoiceHeaderId = invoiceHeaderId;
                invoiceHeader.RelatedInvoiceId = relatedInvoiceId;
                string NewDocNum = efMethods.GetNextDocNum(true, "CO", nameof(TrInvoiceHeader.DocumentNumber), nameof(subContext.TrInvoiceHeaders), 6);
                invoiceHeader.DocumentNumber = NewDocNum;
                invoiceHeader.DocumentDate = DateTime.Now;
                invoiceHeader.DocumentTime = TimeSpan.Parse(DateTime.Now.ToString("HH:mm:ss"));
                invoiceHeader.ProcessCode = "CO";
                invoiceHeader.OfficeCode = Authorization.OfficeCode;
                invoiceHeader.StoreCode = Authorization.StoreCode;
                invoiceHeader.CreatedUserName = Authorization.CurrAccCode;
                invoiceHeader.IsMainTF = true;
                invoiceHeader.WarehouseCode = warehouseCode;

                efMethods.InsertEntity<TrInvoiceHeader>(invoiceHeader);

                countingVM.Where(x => x.Difference < 0).ToList().ForEach(x =>
                {
                    TrInvoiceLine invoiceLine = new();
                    invoiceLine.InvoiceHeaderId = invoiceHeaderId;
                    invoiceLine.InvoiceLineId = Guid.NewGuid();
                    invoiceLine.CreatedDate = DateTime.Now;
                    invoiceLine.CreatedUserName = Authorization.CurrAccCode;
                    invoiceLine.QtyOut = Math.Abs(x.Difference);
                    invoiceLine.VatRate = x.VatRate;
                    invoiceLine.ExchangeRate = x.ExchangeRate;
                    invoiceLine.Amount = x.Amount;
                    invoiceLine.AmountLoc = x.AmountLoc;
                    invoiceLine.CurrencyCode = x.CurrencyCode;
                    invoiceLine.ExchangeRate = x.ExchangeRate;
                    invoiceLine.LineDescription = x.LineDescription;
                    invoiceLine.NetAmount = x.NetAmount;
                    invoiceLine.NetAmountLoc = x.NetAmountLoc;
                    invoiceLine.PosDiscount = x.PosDiscount;
                    invoiceLine.Price = x.Price;
                    invoiceLine.PriceLoc = x.PriceLoc;
                    invoiceLine.ProductCode = x.ProductCode;
                    invoiceLine.Barcode = x.Barcode;
                    invoiceLine.SerialNumberCode = x.SerialNumberCode;
                    invoiceLine.UnitOfMeasureId = x.UnitOfMeasureId;
                    invoiceLine.VatRate = x.VatRate;
                    invoiceLine.ProductCost = x.ProductCost ?? (x.Price > 0 ? x.Price : null);

                    efMethods.InsertEntity<TrInvoiceLine>(invoiceLine);
                });
            }

            // Reset stock balance of uncounted products
            if (checkEdit_ResetUncountedProductBalance.Checked && !string.IsNullOrEmpty(warehouseCode))
            {
                var countedProductCodes = countingVM.Select(x => x.ProductCode).Distinct().ToHashSet();

                using var db = new subContext();
                // Get all products that have stock in this warehouse but were NOT counted
                var productsWithStock = db.TrInvoiceLines
                    .Include(x => x.TrInvoiceHeader)
                    .Where(x => x.TrInvoiceHeader.WarehouseCode == warehouseCode)
                    .Where(x => new string[] { "RP", "WP", "RS", "WS", "IS", "CI", "CO", "IT" }.Contains(x.TrInvoiceHeader.ProcessCode))
                    .GroupBy(x => x.ProductCode)
                    .Select(g => new { ProductCode = g.Key, Balance = g.Sum(x => x.QtyIn - x.QtyOut) })
                    .Where(x => x.Balance != 0)
                    .Where(x => !countedProductCodes.Contains(x.ProductCode))
                    .ToList();

                if (productsWithStock.Any())
                {
                    Guid resetHeaderId = Guid.NewGuid();

                    TrInvoiceHeader resetHeader = new();
                    resetHeader.InvoiceHeaderId = resetHeaderId;
                    resetHeader.RelatedInvoiceId = relatedInvoiceId;
                    resetHeader.DocumentNumber = efMethods.GetNextDocNum(true, "CO", nameof(TrInvoiceHeader.DocumentNumber), nameof(subContext.TrInvoiceHeaders), 6);
                    resetHeader.DocumentDate = DateTime.Now;
                    resetHeader.DocumentTime = TimeSpan.Parse(DateTime.Now.ToString("HH:mm:ss"));
                    resetHeader.ProcessCode = "CO";
                    resetHeader.OfficeCode = Authorization.OfficeCode;
                    resetHeader.StoreCode = Authorization.StoreCode;
                    resetHeader.CreatedUserName = Authorization.CurrAccCode;
                    resetHeader.IsMainTF = true;
                    resetHeader.WarehouseCode = warehouseCode;

                    efMethods.InsertEntity<TrInvoiceHeader>(resetHeader);

                    Dictionary<string, decimal>? uncountedCostDict = null;
                    if (checkEdit_AutoAddCostPrice.Checked)
                    {
                        var uncountedCodes = productsWithStock.Select(p => p.ProductCode).Distinct().ToList();
                        uncountedCostDict = new Dictionary<string, decimal>(StringComparer.OrdinalIgnoreCase);

                        foreach (var chunk in uncountedCodes.Chunk(1000))
                        {
                            var chunkCosts = db.DcProducts
                                .Where(p => chunk.Contains(p.ProductCode))
                                .Select(p => new
                                {
                                    p.ProductCode,
                                    Cost = SqlFunctions.GetProductCost(p.ProductCode, null),
                                    p.PurchasePrice
                                })
                                .ToList();

                            foreach (var item in chunkCosts)
                            {
                                decimal effectiveCost = item.Cost > 0 ? item.Cost : (item.PurchasePrice > 0 ? item.PurchasePrice : 0m);
                                uncountedCostDict[item.ProductCode] = effectiveCost;
                            }
                        }
                    }

                    string localCurrency = Settings.Default.AppSetting?.LocalCurrencyCode ?? "AZN";

                    foreach (var p in productsWithStock)
                    {
                        TrInvoiceLine resetLine = new();
                        resetLine.InvoiceHeaderId = resetHeaderId;
                        resetLine.InvoiceLineId = Guid.NewGuid();
                        resetLine.CreatedDate = DateTime.Now;
                        resetLine.CreatedUserName = Authorization.CurrAccCode;
                        resetLine.ProductCode = p.ProductCode;
                        resetLine.CurrencyCode = localCurrency;
                        resetLine.ExchangeRate = 1;

                        decimal cost = 0m;
                        if (checkEdit_AutoAddCostPrice.Checked && uncountedCostDict != null && uncountedCostDict.TryGetValue(p.ProductCode, out decimal foundCost))
                        {
                            cost = foundCost;
                        }

                        resetLine.Price = cost;
                        resetLine.PriceLoc = cost;
                        resetLine.ProductCost = cost > 0 ? cost : null;

                        if (p.Balance > 0)
                            resetLine.QtyOut = p.Balance;
                        else
                            resetLine.QtyIn = Math.Abs(p.Balance);

                        efMethods.InsertEntity<TrInvoiceLine>(resetLine);
                    }
                }
            }
        }

        private void WizardPage2_PageInit(object sender, EventArgs e)
        {
        }

        private decimal CalcProductBalance(string serialNumberCode, string productCode, string wareHouse, decimal presentQty)
        {
            if (!String.IsNullOrEmpty(serialNumberCode))
                return efMethods.SelectProductBalanceSerialNumber(productCode, wareHouse, serialNumberCode);
            else
                return efMethods.SelectProductBalance(productCode, wareHouse);
        }

        private void LUE_StoreCode_EditValueChanged(object sender, EventArgs e)
        {
            string storeCode = LUE_StoreCode.EditValue.ToString();
            List<DcWarehouse> dcWarehouses = efMethods.SelectWarehousesByStoreIncludeDisabled(storeCode);
            LUE_WarehouseCode.Properties.DataSource = dcWarehouses;
        }

        private void gridView1_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            if (e.Column.FieldName == $"{nameof(DcProduct)}.{nameof(DcProduct.ProductDesc)}" && e.IsGetData)
            {
                GridView view = sender as GridView;
                int rowInd = view.GetRowHandle(e.ListSourceRowIndex);
                string productCode = view.GetRowCellValue(rowInd, colProductCode) as string ?? string.Empty;

                DcProduct dcProduct = efMethods.SelectProduct(productCode, new byte[] { 1 });

                e.Value = dcProduct?.ProductDesc;
            }
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column == colQty)
            {
                if (gridView1.GetRow(e.RowHandle) is CountingLineVM row)
                {
                    row.QtyIn = row.Qty;
                    row.Difference = row.Qty - row.Balance;
                    gridView1.UpdateCurrentRow();
                }
            }
        }
    }
}
