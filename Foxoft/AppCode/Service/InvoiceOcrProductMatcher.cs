using System;
using System.Collections.Generic;
using System.Linq;
using Foxoft.Models;
using Foxoft.Models.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace Foxoft.AppCode.Service
{
    public static class InvoiceOcrProductMatcher
    {
        public static void MatchLines(IEnumerable<InvoiceOcrLineVM> lines, byte[]? productTypeArr = null)
        {
            if (lines == null)
                return;

            using subContext db = new();

            var units = db.DcUnitOfMeasures.AsNoTracking().ToList();

            foreach (var line in lines)
            {
                DcProduct? matchedProduct = null;
                string? matchedBarcode = null;

                // 1. Try barcode matching
                if (!string.IsNullOrWhiteSpace(line.OcrBarcode))
                {
                    string cleanBarcode = line.OcrBarcode.Trim();
                    var barcodeEntity = db.TrProductBarcodes
                        .Include(x => x.DcProduct)
                        .AsNoTracking()
                        .FirstOrDefault(x => x.Barcode == cleanBarcode);

                    if (barcodeEntity?.DcProduct != null)
                    {
                        matchedProduct = barcodeEntity.DcProduct;
                        matchedBarcode = barcodeEntity.Barcode;
                    }
                }

                // 2. Try product code matching
                if (matchedProduct == null && !string.IsNullOrWhiteSpace(line.OcrProductCode))
                {
                    string cleanCode = line.OcrProductCode.Trim();
                    matchedProduct = db.DcProducts
                        .AsNoTracking()
                        .FirstOrDefault(x => x.ProductCode == cleanCode);
                }

                // 3. Try product name / description matching (exact or contains)
                if (matchedProduct == null && !string.IsNullOrWhiteSpace(line.OcrProductName))
                {
                    string cleanName = line.OcrProductName.Trim();
                    matchedProduct = db.DcProducts
                        .AsNoTracking()
                        .FirstOrDefault(x => x.ProductDesc.ToLower() == cleanName.ToLower());

                    if (matchedProduct == null)
                    {
                        matchedProduct = db.DcProducts
                            .AsNoTracking()
                            .FirstOrDefault(x => x.ProductDesc.Contains(cleanName) || cleanName.Contains(x.ProductDesc));
                    }
                }

                if (matchedProduct != null)
                {
                    line.MatchedProductCode = matchedProduct.ProductCode;
                    line.MatchedProductName = matchedProduct.ProductDesc;
                    line.MatchedBarcode = matchedBarcode ?? db.TrProductBarcodes
                        .AsNoTracking()
                        .Where(x => x.ProductCode == matchedProduct.ProductCode)
                        .Select(x => x.Barcode)
                        .FirstOrDefault();

                    line.IsMatched = true;
                    line.MatchStatus = Properties.Resources.Form_InvoiceWizard_StatusMatched;

                    if (line.Price == 0 && matchedProduct.PurchasePrice > 0)
                        line.Price = matchedProduct.PurchasePrice;

                    if (!line.UnitOfMeasureId.HasValue && matchedProduct.DefaultUnitOfMeasureId > 0)
                    {
                        line.UnitOfMeasureId = matchedProduct.DefaultUnitOfMeasureId;
                        line.UnitOfMeasureName = units.FirstOrDefault(u => u.UnitOfMeasureId == matchedProduct.DefaultUnitOfMeasureId)?.UnitOfMeasureDesc;
                    }
                }
                else
                {
                    line.IsMatched = false;
                    line.MatchStatus = Properties.Resources.Form_InvoiceWizard_StatusUnmatched;
                }

                // Map Unit of Measure if missing
                if (!line.UnitOfMeasureId.HasValue && !string.IsNullOrWhiteSpace(line.UnitOfMeasureName))
                {
                    var uom = MapUnitOfMeasure(line.UnitOfMeasureName, units);
                    if (uom != null)
                    {
                        line.UnitOfMeasureId = uom.UnitOfMeasureId;
                        line.UnitOfMeasureName = uom.UnitOfMeasureDesc;
                    }
                }

                if (line.Amount == 0 && line.Qty > 0 && line.Price > 0)
                    line.UpdateAmount();
            }
        }

        public static void UpdateMatchedProduct(InvoiceOcrLineVM line, string productCode)
        {
            if (line == null)
                return;

            if (string.IsNullOrWhiteSpace(productCode))
            {
                line.MatchedProductCode = null;
                line.MatchedProductName = null;
                line.IsMatched = false;
                line.MatchStatus = Properties.Resources.Form_InvoiceWizard_StatusUnmatched;
                return;
            }

            using subContext db = new();
            var product = db.DcProducts.AsNoTracking().FirstOrDefault(x => x.ProductCode == productCode.Trim());
            if (product != null)
            {
                line.MatchedProductCode = product.ProductCode;
                line.MatchedProductName = product.ProductDesc;
                line.IsMatched = true;
                line.MatchStatus = Properties.Resources.Form_InvoiceWizard_StatusMatched;

                if (!line.UnitOfMeasureId.HasValue && product.DefaultUnitOfMeasureId > 0)
                {
                    line.UnitOfMeasureId = product.DefaultUnitOfMeasureId;
                    var uom = db.DcUnitOfMeasures.AsNoTracking().FirstOrDefault(u => u.UnitOfMeasureId == product.DefaultUnitOfMeasureId);
                    if (uom != null)
                        line.UnitOfMeasureName = uom.UnitOfMeasureDesc;
                }

                if (line.Price == 0 && product.PurchasePrice > 0)
                    line.Price = product.PurchasePrice;

                line.MatchedBarcode = db.TrProductBarcodes
                    .AsNoTracking()
                    .Where(x => x.ProductCode == product.ProductCode)
                    .Select(x => x.Barcode)
                    .FirstOrDefault();
            }
            else
            {
                line.MatchedProductCode = productCode;
                line.MatchedProductName = string.Empty;
                line.IsMatched = false;
                line.MatchStatus = Properties.Resources.Form_InvoiceWizard_StatusUnmatched;
            }
        }

        private static DcUnitOfMeasure? MapUnitOfMeasure(string unitText, List<DcUnitOfMeasure> units)
        {
            if (string.IsNullOrWhiteSpace(unitText) || units == null || units.Count == 0)
                return null;

            string normalized = unitText.Trim().ToLowerInvariant();

            // Direct desc match
            var exact = units.FirstOrDefault(u => u.UnitOfMeasureDesc.ToLowerInvariant() == normalized);
            if (exact != null)
                return exact;

            // Common aliases
            if (normalized is "ədəd" or "əd" or "ed" or "eded" or "pcs" or "piece" or "ad." or "pc" or "əd.")
                return units.FirstOrDefault(u => u.UnitOfMeasureDesc.ToLowerInvariant().Contains("əd"));

            if (normalized is "kq" or "kg" or "kilo" or "kilogram")
                return units.FirstOrDefault(u => u.UnitOfMeasureDesc.ToLowerInvariant().Contains("k"));

            if (normalized is "litr" or "l" or "lt" or "liter")
                return units.FirstOrDefault(u => u.UnitOfMeasureDesc.ToLowerInvariant().Contains("lit"));

            if (normalized is "metr" or "m" or "meter")
                return units.FirstOrDefault(u => u.UnitOfMeasureDesc.ToLowerInvariant().Contains("metr"));

            if (normalized is "qutu" or "box")
                return units.FirstOrDefault(u => u.UnitOfMeasureDesc.ToLowerInvariant().Contains("qut"));

            if (normalized is "dəst" or "set")
                return units.FirstOrDefault(u => u.UnitOfMeasureDesc.ToLowerInvariant().Contains("dəs"));

            return units.FirstOrDefault(u => u.UnitOfMeasureDesc.ToLowerInvariant().Contains(normalized));
        }
    }
}
