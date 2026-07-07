using DevExpress.Spreadsheet;
using Foxoft.Models;
using Foxoft.Properties;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Globalization;
using System.IO;

namespace Foxoft.AppCode.Services
{
    public sealed class InvoiceExcelService
    {
        private static readonly DateTime DefaultSqlDate = new(1901, 1, 1);

        private readonly subContext _dbContext;
        private readonly EfMethods _efMethods;

        public InvoiceExcelService(subContext dbContext, EfMethods efMethods)
        {
            _dbContext = dbContext;
            _efMethods = efMethods;
        }

        public void Export(string fileName, InvoiceExcelExportContext context)
        {
            InvoiceExcelCaptions captions = new();
            Workbook workbook = new();
            Worksheet headerSheet = workbook.Worksheets[0];
            headerSheet.Name = NormalizeExcelSheetName(captions.SheetHeader);

            WriteHeaderSheet(headerSheet, captions, context);
            WriteLinesSheet(workbook.Worksheets.Add(NormalizeExcelSheetName(captions.SheetLines)), captions, context);
            WriteLineFeaturesSheet(workbook.Worksheets.Add(NormalizeExcelSheetName(captions.SheetLineFeatures)), captions, context);

            if (IsInstallmentProcess(context.InvoiceHeader, context.Process))
            {
                WriteInstallmentSheet(workbook.Worksheets.Add(NormalizeExcelSheetName(captions.SheetInstallment)), captions, context);
                WriteInstallmentGuarantorsSheet(workbook.Worksheets.Add(NormalizeExcelSheetName(captions.SheetInstallmentGuarantors)), captions, context);
            }

            workbook.SaveDocument(fileName, DocumentFormat.Xlsx);
        }

        public InvoiceExcelImportPlan ReadImportPlan(string fileName, InvoiceExcelImportContext context)
        {
            InvoiceExcelCaptions captions = new();
            InvoiceExcelImportPlan plan = new(captions);
            Workbook workbook = new();
            workbook.LoadDocument(fileName);
            plan._workbook = workbook;

            Worksheet headerSheet = FindWorksheet(workbook, captions.SheetHeader);
            Worksheet lineSheet = FindWorksheet(workbook, captions.SheetLines);

            if (headerSheet is null)
                plan.Errors.Add($"{Resources.Common_NotFound}: {captions.SheetHeader}");
            if (lineSheet is null)
                plan.Errors.Add($"{Resources.Common_NotFound}: {captions.SheetLines}");

            if (plan.HasErrors)
                return plan;

            plan._headerTable = ReadWorksheetTable(headerSheet);
            plan._lineTable = ReadWorksheetTable(lineSheet);
            plan._featureTable = FindWorksheet(workbook, captions.SheetLineFeatures) is Worksheet featureSheet
                ? ReadWorksheetTable(featureSheet)
                : null;
            plan._installmentTable = FindWorksheet(workbook, captions.SheetInstallment) is Worksheet installmentSheet
                ? ReadWorksheetTable(installmentSheet)
                : null;
            plan._guarantorTable = FindWorksheet(workbook, captions.SheetInstallmentGuarantors) is Worksheet guarantorSheet
                ? ReadWorksheetTable(guarantorSheet)
                : null;
            plan.ImportedProcessCode = ReadOptionalText(plan._headerTable, 1, captions.ProcessCode);

            ValidateImportedHeader(plan._headerTable, captions, context, plan.Errors, validateHeaderValues: false);

            plan._lines.AddRange(ReadImportedLines(plan._lineTable, captions, context, plan.Errors));
            plan._features.AddRange(ReadImportedLineFeatures(plan._featureTable, captions, plan._lines, plan.Errors));

            return plan;
        }

        public List<string> ValidateHeaderValues(InvoiceExcelImportPlan plan, InvoiceExcelImportContext context)
        {
            List<string> errors = new();
            ValidateImportedHeader(plan._headerTable, plan._captions, context, errors, validateHeaderValues: true);
            plan._guarantors.Clear();
            plan._guarantors.AddRange(ReadImportedInstallmentGuarantors(plan._guarantorTable, plan._captions, context, errors));
            plan._headerValuesValidated = !errors.Any();
            return errors;
        }

        public void ApplyImportPlan(InvoiceExcelImportPlan plan, InvoiceExcelImportContext context, bool applyHeader)
        {
            if (plan.HasErrors)
                return;

            if (applyHeader && !plan._headerValuesValidated)
            {
                List<string> errors = ValidateHeaderValues(plan, context);
                if (errors.Any())
                {
                    plan.Errors.AddRange(errors);
                    return;
                }
            }

            if (applyHeader)
                ApplyImportedHeader(plan._headerTable, plan._captions, context);

            Dictionary<int, TrInvoiceLine> importedLineMap = AppendImportedLines(plan._lines, context);
            AppendImportedLineFeatures(plan._features, importedLineMap);

            if (applyHeader)
            {
                ApplyImportedInstallment(plan._installmentTable, plan._captions, context);
                AppendImportedInstallmentGuarantors(plan._guarantors, context);
            }
        }

        public static string GetSafeFileName(string fileName)
        {
            string safeName = fileName;
            foreach (char invalid in Path.GetInvalidFileNameChars())
                safeName = safeName.Replace(invalid, '_');

            return safeName;
        }

        private void WriteHeaderSheet(Worksheet sheet, InvoiceExcelCaptions c, InvoiceExcelExportContext context)
        {
            TrInvoiceHeader invoiceHeader = context.InvoiceHeader;

            string[] headers =
            {
                c.InvoiceHeaderId,
                c.RelatedInvoiceId,
                c.ProcessCode,
                c.DocumentNumber,
                c.IsReturn,
                c.DocumentDate,
                c.DocumentTime,
                c.OperationDate,
                c.OperationTime,
                c.Description,
                c.CurrAccCode,
                c.OfficeCode,
                c.StoreCode,
                c.WarehouseCode,
                c.ToWarehouseCode,
                c.CustomsDocumentNumber,
                c.TerminalId,
                c.LoyaltyCardId,
                c.IsSent,
                c.IsCompleted,
                c.PrintCount,
                c.DeliveryDate,
                c.CashRegisterCode,
            };

            object[] values =
            {
                invoiceHeader.InvoiceHeaderId,
                invoiceHeader.RelatedInvoiceId,
                invoiceHeader.ProcessCode,
                invoiceHeader.DocumentNumber,
                invoiceHeader.IsReturn,
                invoiceHeader.DocumentDate,
                invoiceHeader.DocumentTime,
                invoiceHeader.OperationDate,
                invoiceHeader.OperationTime,
                invoiceHeader.Description,
                invoiceHeader.CurrAccCode,
                invoiceHeader.OfficeCode,
                invoiceHeader.StoreCode,
                invoiceHeader.WarehouseCode,
                invoiceHeader.ToWarehouseCode,
                invoiceHeader.CustomsDocumentNumber,
                invoiceHeader.TerminalId,
                invoiceHeader.LoyaltyCardId,
                invoiceHeader.IsSent,
                invoiceHeader.IsCompleted,
                invoiceHeader.PrintCount,
                invoiceHeader.DeliveryDate,
                invoiceHeader.CashRegisterCode,
            };

            WriteRow(sheet, 0, headers);
            WriteRow(sheet, 1, values);
        }

        private void WriteLinesSheet(Worksheet sheet, InvoiceExcelCaptions c, InvoiceExcelExportContext context)
        {
            string[] headers =
            {
                c.LineNo,
                c.InvoiceLineId,
                c.ProductCode,
                c.ProductDesc,
                c.Barcode,
                c.Qty,
                c.QtyIn,
                c.QtyOut,
                c.UnitOfMeasureId,
                c.Price,
                c.CurrencyCode,
                c.ExchangeRate,
                c.PriceLoc,
                c.Amount,
                c.AmountLoc,
                c.PosDiscount,
                c.NetAmount,
                c.NetAmountLoc,
                c.DiscountCampaign,
                c.VatRate,
                c.LineDescription,
                c.SerialNumberCode,
                c.SalesPersonCode,
                c.WorkerCode,
                c.ProductCost,
                c.Benefit,
                c.TotalBenefit,
            };

            WriteRow(sheet, 0, headers);

            int row = 1;
            foreach (TrInvoiceLine line in GetInvoiceLinesForExcel(context))
            {
                object[] values =
                {
                    row,
                    line.InvoiceLineId,
                    line.ProductCode,
                    ResolveProductDesc(line),
                    line.Barcode,
                    line.Qty,
                    line.QtyIn,
                    line.QtyOut,
                    line.UnitOfMeasureId,
                    line.Price,
                    line.CurrencyCode,
                    line.ExchangeRate,
                    line.PriceLoc,
                    line.Amount,
                    line.AmountLoc,
                    line.PosDiscount,
                    line.NetAmount,
                    line.NetAmountLoc,
                    line.DiscountCampaign,
                    line.VatRate,
                    line.LineDescription,
                    line.SerialNumberCode,
                    line.SalesPersonCode,
                    line.WorkerCode,
                    line.ProductCost,
                    line.Benefit,
                    line.TotalBenefit,
                };

                WriteRow(sheet, row, values);
                row++;
            }
        }

        private void WriteLineFeaturesSheet(Worksheet sheet, InvoiceExcelCaptions c, InvoiceExcelExportContext context)
        {
            string[] headers =
            {
                c.LineNo,
                c.InvoiceLineId,
                c.ProductCode,
                c.FeatureTypeId,
                c.FeatureTypeName,
                c.FeatureCode,
                c.FeatureDesc,
            };

            WriteRow(sheet, 0, headers);

            int row = 1;
            List<TrInvoiceLine> lines = GetInvoiceLinesForExcel(context).ToList();
            Dictionary<Guid, int> lineNumbers = lines
                .Select((line, index) => new { line.InvoiceLineId, LineNo = index + 1 })
                .ToDictionary(x => x.InvoiceLineId, x => x.LineNo);

            foreach (TrInvoiceLine line in lines)
            {
                if (line.TrInvoiceLineFeatures is null)
                    continue;

                foreach (TrInvoiceLineFeature feature in line.TrInvoiceLineFeatures.OrderBy(x => x.InvoiceLineFeatureTypeId))
                {
                    DcInvoiceLineFeatureType type = _dbContext.DcInvoiceLineFeatureTypes
                        .AsNoTracking()
                        .FirstOrDefault(x => x.InvoiceLineFeatureTypeId == feature.InvoiceLineFeatureTypeId);

                    DcInvoiceLineFeature featureValue = _dbContext.DcInvoiceLineFeatures
                        .AsNoTracking()
                        .FirstOrDefault(x =>
                            x.InvoiceLineFeatureTypeId == feature.InvoiceLineFeatureTypeId
                            && x.InvoiceLineFeatureCode == feature.InvoiceLineFeatureCode);

                    object[] values =
                    {
                        lineNumbers[line.InvoiceLineId],
                        line.InvoiceLineId,
                        line.ProductCode,
                        feature.InvoiceLineFeatureTypeId,
                        type?.FeatureTypeName,
                        feature.InvoiceLineFeatureCode,
                        featureValue?.FeatureDesc,
                    };

                    WriteRow(sheet, row, values);
                    row++;
                }
            }
        }

        private void WriteInstallmentSheet(Worksheet sheet, InvoiceExcelCaptions c, InvoiceExcelExportContext context)
        {
            TrInstallment installment = context.EnsureInstallment();

            string[] headers =
            {
                c.InstallmentId,
                c.InvoiceHeaderId,
                c.InstallmentPlanCode,
                c.InstallmentDate,
                c.InstallmentCommission,
                c.InstallmentInterestRate,
            };

            object[] values =
            {
                installment.InstallmentId,
                installment.InvoiceHeaderId,
                installment.InstallmentPlanCode,
                installment.InstallmentDate,
                installment.Commission,
                installment.InterestRate,
            };

            WriteRow(sheet, 0, headers);
            WriteRow(sheet, 1, values);
        }

        private void WriteInstallmentGuarantorsSheet(Worksheet sheet, InvoiceExcelCaptions c, InvoiceExcelExportContext context)
        {
            string[] headers =
            {
                c.GuarantorId,
                c.CurrAccCode,
                c.InvoiceHeaderId,
            };

            WriteRow(sheet, 0, headers);

            int row = 1;
            foreach (TrInstallmentGuarantor guarantor in context.InstallmentGuarantors)
            {
                WriteRow(sheet, row, new object[]
                {
                    guarantor.InstallmentGuarantorId,
                    guarantor.CurrAccCode,
                    context.InvoiceHeader.InvoiceHeaderId,
                });
                row++;
            }
        }

        private void ValidateImportedHeader(
            ExcelWorksheetTable table,
            InvoiceExcelCaptions c,
            InvoiceExcelImportContext context,
            List<string> errors,
            bool validateHeaderValues)
        {
            if (table is null || table.LastRow < 1)
                return;

            if (!validateHeaderValues)
                return;

            if (table.TryGetCellText(1, c.CurrAccCode, out string currAccCode)
                && !string.IsNullOrWhiteSpace(currAccCode))
            {
                bool exists = string.Equals(context.Process.ProcessCode, "IT", StringComparison.OrdinalIgnoreCase)
                    ? _efMethods.SelectStore(currAccCode) is not null
                    : _efMethods.SelectCurrAcc(currAccCode) is not null;

                if (!exists)
                    errors.Add($"{c.CurrAccCode}: {currAccCode} {Resources.Common_NotFound}");
            }

            ValidateEntityValue<DcOffice>(table, 1, c.OfficeCode, errors);
            ValidateEntityValue<DcCurrAcc>(table, 1, c.StoreCode, errors);
            ValidateEntityValue<DcWarehouse>(table, 1, c.WarehouseCode, errors);
            ValidateEntityValue<DcWarehouse>(table, 1, c.ToWarehouseCode, errors, allowEmpty: true);
            ValidateEntityValue<DcTerminal>(table, 1, c.TerminalId, errors, allowEmpty: true, convert: int.TryParse);
        }

        private List<ImportedInvoiceLine> ReadImportedLines(
            ExcelWorksheetTable table,
            InvoiceExcelCaptions c,
            InvoiceExcelImportContext context,
            List<string> errors)
        {
            List<ImportedInvoiceLine> result = new();

            for (int row = 1; row <= table.LastRow; row++)
            {
                int lineNo = ReadOptionalInt(table, row, c.LineNo) ?? row;
                string productCode = ReadOptionalText(table, row, c.ProductCode);
                string barcode = ReadOptionalText(table, row, c.Barcode);

                if (string.IsNullOrWhiteSpace(productCode) && string.IsNullOrWhiteSpace(barcode))
                    continue;

                DcProduct product = null;
                if (!string.IsNullOrWhiteSpace(productCode))
                    product = _efMethods.SelectProduct(productCode, context.ProductTypeArr);

                if (product is null && !string.IsNullOrWhiteSpace(barcode))
                    product = _efMethods.SelectProductByBarcode(barcode);

                if (product is null)
                {
                    string value = !string.IsNullOrWhiteSpace(productCode) ? productCode : barcode;
                    string caption = !string.IsNullOrWhiteSpace(productCode) ? c.ProductCode : c.Barcode;
                    errors.Add($"{Resources.Common_Identity} {lineNo}: {caption}: {value} {Resources.Common_NotFound}");
                    continue;
                }

                string currencyText = ReadOptionalText(table, row, c.CurrencyCode);
                DcCurrency currency = null;
                if (!string.IsNullOrWhiteSpace(currencyText))
                    currency = _efMethods.SelectEntityById<DcCurrency>(currencyText)
                               ?? _efMethods.SelectCurrencyByName(currencyText);

                currency ??= _efMethods.SelectEntityById<DcCurrency>(
                    string.IsNullOrWhiteSpace(context.Process.CustomCurrencyCode)
                        ? Settings.Default.AppSetting.LocalCurrencyCode
                        : context.Process.CustomCurrencyCode);

                if (currency is null)
                {
                    errors.Add($"{Resources.Common_Identity} {lineNo}: {c.CurrencyCode}: {currencyText} {Resources.Common_NotFound}");
                    continue;
                }

                int? unitOfMeasureId = ReadOptionalInt(table, row, c.UnitOfMeasureId) ?? product.DefaultUnitOfMeasureId;
                if (unitOfMeasureId.HasValue && !_efMethods.EntityExists<DcUnitOfMeasure>(unitOfMeasureId.Value))
                {
                    errors.Add($"{Resources.Common_Identity} {lineNo}: {c.UnitOfMeasureId}: {unitOfMeasureId} {Resources.Common_NotFound}");
                    continue;
                }

                string salesPersonCode = ReadOptionalText(table, row, c.SalesPersonCode);
                if (!string.IsNullOrWhiteSpace(salesPersonCode) && _efMethods.SelectSalesPerson(salesPersonCode) is null)
                    errors.Add($"{Resources.Common_Identity} {lineNo}: {c.SalesPersonCode}: {salesPersonCode} {Resources.Common_NotFound}");

                string workerCode = ReadOptionalText(table, row, c.WorkerCode);
                if (!string.IsNullOrWhiteSpace(workerCode) && _efMethods.SelectWorker(workerCode) is null)
                    errors.Add($"{Resources.Common_Identity} {lineNo}: {c.WorkerCode}: {workerCode} {Resources.Common_NotFound}");

                result.Add(new ImportedInvoiceLine
                {
                    LineNo = lineNo,
                    ProductCode = product.ProductCode,
                    Product = product,
                    Barcode = barcode,
                    HasQty = HasCellValue(table, row, c.Qty),
                    HasQtyIn = HasCellValue(table, row, c.QtyIn),
                    HasQtyOut = HasCellValue(table, row, c.QtyOut),
                    Qty = ReadOptionalDecimal(table, row, c.Qty),
                    QtyIn = ReadOptionalDecimal(table, row, c.QtyIn),
                    QtyOut = ReadOptionalDecimal(table, row, c.QtyOut),
                    UnitOfMeasureId = unitOfMeasureId,
                    Price = ReadOptionalDecimal(table, row, c.Price),
                    CurrencyCode = currency.CurrencyCode,
                    Currency = currency,
                    ExchangeRate = ReadOptionalFloat(table, row, c.ExchangeRate),
                    PosDiscount = ReadOptionalDecimal(table, row, c.PosDiscount),
                    DiscountCampaign = ReadOptionalDecimal(table, row, c.DiscountCampaign),
                    VatRate = ReadOptionalFloat(table, row, c.VatRate),
                    LineDescription = ReadOptionalText(table, row, c.LineDescription),
                    SerialNumberCode = ReadOptionalText(table, row, c.SerialNumberCode),
                    SalesPersonCode = salesPersonCode,
                    WorkerCode = workerCode,
                    ProductCost = ReadOptionalDecimal(table, row, c.ProductCost),
                });
            }

            return result;
        }

        private List<ImportedInvoiceLineFeature> ReadImportedLineFeatures(
            ExcelWorksheetTable table,
            InvoiceExcelCaptions c,
            List<ImportedInvoiceLine> importedLines,
            List<string> errors)
        {
            List<ImportedInvoiceLineFeature> result = new();
            if (table is null)
                return result;

            HashSet<int> lineNumbers = importedLines.Select(x => x.LineNo).ToHashSet();

            for (int row = 1; row <= table.LastRow; row++)
            {
                int? lineNo = ReadOptionalInt(table, row, c.LineNo);
                int? featureTypeId = ReadOptionalInt(table, row, c.FeatureTypeId);
                string featureCode = ReadOptionalText(table, row, c.FeatureCode);

                if (!lineNo.HasValue && !featureTypeId.HasValue && string.IsNullOrWhiteSpace(featureCode))
                    continue;

                if (!lineNo.HasValue || !lineNumbers.Contains(lineNo.Value))
                {
                    errors.Add($"{Resources.Common_Identity} {row}: {c.LineNo}: {lineNo} {Resources.Common_NotFound}");
                    continue;
                }

                if (!featureTypeId.HasValue || string.IsNullOrWhiteSpace(featureCode))
                {
                    errors.Add($"{Resources.Common_Identity} {lineNo}: {Resources.Common_InvalidValue}");
                    continue;
                }

                bool exists = _dbContext.DcInvoiceLineFeatures
                    .AsNoTracking()
                    .Any(x => x.InvoiceLineFeatureTypeId == featureTypeId.Value && x.InvoiceLineFeatureCode == featureCode);

                if (!exists)
                {
                    errors.Add($"{Resources.Common_Identity} {lineNo}: {c.FeatureCode}: {featureCode} {Resources.Common_NotFound}");
                    continue;
                }

                result.Add(new ImportedInvoiceLineFeature
                {
                    LineNo = lineNo.Value,
                    FeatureTypeId = featureTypeId.Value,
                    FeatureCode = featureCode,
                });
            }

            return result;
        }

        private List<ImportedInstallmentGuarantor> ReadImportedInstallmentGuarantors(
            ExcelWorksheetTable table,
            InvoiceExcelCaptions c,
            InvoiceExcelImportContext context,
            List<string> errors)
        {
            List<ImportedInstallmentGuarantor> result = new();
            if (table is null || !IsInstallmentProcess(context.InvoiceHeader, context.Process))
                return result;

            for (int row = 1; row <= table.LastRow; row++)
            {
                string currAccCode = ReadOptionalText(table, row, c.CurrAccCode);
                if (string.IsNullOrWhiteSpace(currAccCode))
                    continue;

                DcCurrAcc currAcc = _efMethods.SelectCurrAcc(currAccCode);
                if (currAcc is null)
                {
                    errors.Add($"{Resources.Common_Identity} {row}: {c.CurrAccCode}: {currAccCode} {Resources.Common_NotFound}");
                    continue;
                }

                result.Add(new ImportedInstallmentGuarantor
                {
                    CurrAccCode = currAcc.CurrAccCode,
                    CurrAcc = currAcc,
                });
            }

            return result;
        }

        private void ApplyImportedHeader(ExcelWorksheetTable table, InvoiceExcelCaptions c, InvoiceExcelImportContext context)
        {
            TrInvoiceHeader invoiceHeader = context.InvoiceHeader;

            if (table is null || table.LastRow < 1)
                return;

            SetIfText(table, c.DocumentNumber, value => invoiceHeader.DocumentNumber = value);
            SetIfBool(table, c.IsReturn, value => invoiceHeader.IsReturn = value);
            SetIfDate(table, c.DocumentDate, value => invoiceHeader.DocumentDate = value);
            SetIfTime(table, c.DocumentTime, value => invoiceHeader.DocumentTime = value);
            SetIfDate(table, c.OperationDate, value => invoiceHeader.OperationDate = value);
            SetIfTime(table, c.OperationTime, value => invoiceHeader.OperationTime = value);
            SetIfText(table, c.Description, value => invoiceHeader.Description = NullIfEmpty(value));
            SetIfText(table, c.CurrAccCode, value => invoiceHeader.CurrAccCode = NullIfEmpty(value));
            SetIfText(table, c.OfficeCode, value => invoiceHeader.OfficeCode = value);
            SetIfText(table, c.StoreCode, value => invoiceHeader.StoreCode = value);
            SetIfText(table, c.WarehouseCode, value => invoiceHeader.WarehouseCode = value);
            SetIfText(table, c.ToWarehouseCode, value => invoiceHeader.ToWarehouseCode = NullIfEmpty(value));
            SetIfText(table, c.CustomsDocumentNumber, value => invoiceHeader.CustomsDocumentNumber = NullIfEmpty(value));
            SetIfInt(table, c.TerminalId, value => invoiceHeader.TerminalId = value);
            SetIfGuid(table, c.LoyaltyCardId, value => invoiceHeader.LoyaltyCardId = value);
            SetIfBool(table, c.IsSent, value => invoiceHeader.IsSent = value);
            SetIfBool(table, c.IsCompleted, value => invoiceHeader.IsCompleted = value);
            SetIfByte(table, c.PrintCount, value => invoiceHeader.PrintCount = value);
            SetIfDateNullable(table, c.DeliveryDate, value => invoiceHeader.DeliveryDate = value);
            SetIfText(table, c.CashRegisterCode, value => invoiceHeader.CashRegisterCode = NullIfEmpty(value));
        }

        private Dictionary<int, TrInvoiceLine> AppendImportedLines(
            List<ImportedInvoiceLine> importedLines,
            InvoiceExcelImportContext context)
        {
            Dictionary<int, TrInvoiceLine> importedLineMap = new();

            foreach (ImportedInvoiceLine imported in importedLines)
            {
                TrInvoiceLine line = new()
                {
                    InvoiceHeaderId = context.InvoiceHeader.InvoiceHeaderId,
                    InvoiceLineId = Guid.NewGuid(),
                    TrInvoiceHeader = context.InvoiceHeader,
                    ProductCode = imported.ProductCode,
                    Barcode = NullIfEmpty(imported.Barcode),
                    UnitOfMeasureId = imported.UnitOfMeasureId,
                    Price = IsTransferProcess(context.Process) ? 0m : imported.Price ?? 0m,
                    CurrencyCode = imported.CurrencyCode,
                    ExchangeRate = imported.ExchangeRate ?? imported.Currency.ExchangeRate,
                    PosDiscount = imported.PosDiscount ?? 0m,
                    DiscountCampaign = imported.DiscountCampaign ?? 0m,
                    VatRate = imported.VatRate ?? 0f,
                    LineDescription = NullIfEmpty(imported.LineDescription),
                    SerialNumberCode = NullIfEmpty(imported.SerialNumberCode),
                    SalesPersonCode = NullIfEmpty(imported.SalesPersonCode),
                    WorkerCode = NullIfEmpty(imported.WorkerCode),
                    ProductCost = imported.ProductCost ?? imported.Product.ProductCost,
                    CreatedDate = DateTime.Now,
                    CreatedUserName = Authorization.CurrAccCode,
                    LastUpdatedDate = DateTime.Now,
                    LastUpdatedUserName = Authorization.CurrAccCode,
                    TrInvoiceLineFeatures = new List<TrInvoiceLineFeature>(),
                };

                line.DcUnitOfMeasure = LoadUnitOfMeasure(line.UnitOfMeasureId);

                ApplyImportedLineDefaults(line, imported.Product, context.Process);

                if (imported.HasQty && (!imported.HasQtyIn && !imported.HasQtyOut || imported.Qty.GetValueOrDefault() != 0m))
                {
                    line.Qty = imported.Qty ?? 0m;
                }
                else if (imported.HasQtyIn || imported.HasQtyOut)
                {
                    line.QtyIn = imported.QtyIn ?? 0m;
                    line.QtyOut = imported.QtyOut ?? 0m;
                }
                else
                {
                    line.Qty = 1m;
                }

                _dbContext.TrInvoiceLines.Add(line);
                importedLineMap[imported.LineNo] = line;
            }

            return importedLineMap;
        }

        private void AppendImportedLineFeatures(
            List<ImportedInvoiceLineFeature> importedFeatures,
            Dictionary<int, TrInvoiceLine> importedLineMap)
        {
            foreach (ImportedInvoiceLineFeature importedFeature in importedFeatures)
            {
                if (!importedLineMap.TryGetValue(importedFeature.LineNo, out TrInvoiceLine line))
                    continue;

                bool alreadyAdded = line.TrInvoiceLineFeatures?.Any(x =>
                    x.InvoiceLineFeatureTypeId == importedFeature.FeatureTypeId) == true;

                if (alreadyAdded)
                    continue;

                TrInvoiceLineFeature feature = new()
                {
                    InvoiceLineId = line.InvoiceLineId,
                    InvoiceLineFeatureTypeId = importedFeature.FeatureTypeId,
                    InvoiceLineFeatureCode = importedFeature.FeatureCode,
                };

                line.TrInvoiceLineFeatures ??= new List<TrInvoiceLineFeature>();
                line.TrInvoiceLineFeatures.Add(feature);
                _dbContext.TrInvoiceLineFeatures.Add(feature);
            }
        }

        private void ApplyImportedInstallment(
            ExcelWorksheetTable table,
            InvoiceExcelCaptions c,
            InvoiceExcelImportContext context)
        {
            if (table is null || !IsInstallmentProcess(context.InvoiceHeader, context.Process) || table.LastRow < 1)
                return;

            TrInstallment installment = context.EnsureInstallment();

            SetIfText(table, c.InstallmentPlanCode, value => installment.InstallmentPlanCode = value);
            SetIfDate(table, c.InstallmentDate, value => installment.InstallmentDate = value);
            SetIfDecimal(table, c.InstallmentCommission, value => installment.Commission = value);
            SetIfFloat(table, c.InstallmentInterestRate, value => installment.InterestRate = value);
        }

        private void AppendImportedInstallmentGuarantors(
            List<ImportedInstallmentGuarantor> guarantors,
            InvoiceExcelImportContext context)
        {
            if (!IsInstallmentProcess(context.InvoiceHeader, context.Process) || !guarantors.Any())
                return;

            TrInstallment installment = context.EnsureInstallment();
            IList<TrInstallmentGuarantor> existingGuarantors = context.GetInstallmentGuarantors();
            subContext? guarantorContext = context.GetInstallmentGuarantorContext?.Invoke();

            foreach (ImportedInstallmentGuarantor guarantor in guarantors)
            {
                if (existingGuarantors.Any(x => x.CurrAccCode == guarantor.CurrAccCode))
                    continue;

                TrInstallmentGuarantor newGuarantor = new()
                {
                    CurrAccCode = guarantor.CurrAccCode,
                    DcCurrAcc = guarantor.CurrAcc,
                    InstallmentId = installment.InstallmentId,
                    CreatedDate = DateTime.Now,
                    CreatedUserName = Authorization.CurrAccCode,
                    LastUpdatedDate = DateTime.Now,
                    LastUpdatedUserName = Authorization.CurrAccCode,
                };

                if (guarantorContext is not null)
                {
                    EntityEntry<DcCurrAcc> existingEntity = guarantorContext.ChangeTracker.Entries<DcCurrAcc>()
                        .FirstOrDefault(en => en.Entity.CurrAccCode == guarantor.CurrAccCode);

                    if (existingEntity != null)
                        newGuarantor.DcCurrAcc = existingEntity.Entity;
                    else
                        guarantorContext.Attach(guarantor.CurrAcc);
                }

                existingGuarantors.Add(newGuarantor);
            }
        }

        private void ApplyImportedLineDefaults(TrInvoiceLine line, DcProduct product, DcProcess process)
        {
            if (!line.UnitOfMeasureId.HasValue)
            {
                line.UnitOfMeasureId = product.DefaultUnitOfMeasureId;
                line.DcUnitOfMeasure = LoadUnitOfMeasure(line.UnitOfMeasureId);
            }

            if (IsTransferProcess(process))
                return;

            if (line.Price == 0m)
            {
                line.Price = Settings.Default.AppSetting.UsePriceList
                    ? _efMethods.SelectPriceByProcess(process.ProcessCode, product.ProductCode)
                    : process.ProcessCode switch
                    {
                        "RP" or "CI" or "CO" => product.PurchasePrice,
                        "RS" => product.RetailPrice,
                        "WS" => product.WholesalePrice,
                        _ => 0m
                    };
            }
        }

        private DcUnitOfMeasure LoadUnitOfMeasure(int? unitOfMeasureId)
        {
            if (!unitOfMeasureId.HasValue)
                return null;

            return _dbContext.DcUnitOfMeasures
                .Include(x => x.ParentUnitOfMeasure)
                    .ThenInclude(x => x.ParentUnitOfMeasure)
                .FirstOrDefault(x => x.UnitOfMeasureId == unitOfMeasureId.Value);
        }

        private IEnumerable<TrInvoiceLine> GetInvoiceLinesForExcel(InvoiceExcelExportContext context)
            => context.InvoiceLines
                .Where(x => x.InvoiceHeaderId == context.InvoiceHeader.InvoiceHeaderId)
                .Where(x => !string.IsNullOrWhiteSpace(x.ProductCode))
                .OrderBy(x => x.CreatedDate)
                .ToList();

        private string ResolveProductDesc(TrInvoiceLine line)
        {
            if (!string.IsNullOrWhiteSpace(line.ProductDesc))
                return line.ProductDesc;

            DcProduct product = _dbContext.DcProducts
                .AsNoTracking()
                .Include(x => x.TrProductFeatures)
                .FirstOrDefault(x => x.ProductCode == line.ProductCode);

            return product is null ? string.Empty : GetProductDescWide(product);
        }

        private static string GetProductDescWide(DcProduct product)
        {
            int[] featureTypeIds = new[] { 4, 5 };
            string arr = "";
            foreach (var item in product?.TrProductFeatures.Where(f => featureTypeIds.Contains(f.FeatureTypeId)))
                arr += " " + item.FeatureCode;

            return product.HierarchyCode + " " + product.ProductDesc + arr;
        }

        private static void WriteRow(Worksheet sheet, int row, IReadOnlyList<object> values)
        {
            for (int col = 0; col < values.Count; col++)
                WriteCell(sheet, row, col, values[col]);
        }

        private static void WriteCell(Worksheet sheet, int row, int col, object value)
        {
            if (value is null)
            {
                sheet.Cells[row, col].Value = string.Empty;
                return;
            }

            switch (value)
            {
                case Guid guid:
                    sheet.Cells[row, col].Value = guid.ToString();
                    break;
                case DateTime dateTime:
                    sheet.Cells[row, col].Value = dateTime < new DateTime(1753, 1, 1)
                        ? string.Empty
                        : dateTime.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
                    break;
                case TimeSpan timeSpan:
                    sheet.Cells[row, col].Value = timeSpan.ToString(@"hh\:mm\:ss", CultureInfo.InvariantCulture);
                    break;
                case decimal decimalValue:
                    sheet.Cells[row, col].Value = (double)decimalValue;
                    break;
                case float floatValue:
                    sheet.Cells[row, col].Value = floatValue;
                    break;
                case double doubleValue:
                    sheet.Cells[row, col].Value = doubleValue;
                    break;
                case int intValue:
                    sheet.Cells[row, col].Value = intValue;
                    break;
                case byte byteValue:
                    sheet.Cells[row, col].Value = byteValue;
                    break;
                case bool boolValue:
                    sheet.Cells[row, col].Value = boolValue;
                    break;
                default:
                    sheet.Cells[row, col].Value = value.ToString();
                    break;
            }
        }

        private static Worksheet FindWorksheet(Workbook workbook, string localizedSheetName)
        {
            string normalizedName = NormalizeExcelSheetName(localizedSheetName);
            foreach (Worksheet worksheet in workbook.Worksheets)
                if (string.Equals(worksheet.Name, normalizedName, StringComparison.CurrentCultureIgnoreCase))
                    return worksheet;

            return null;
        }

        private static ExcelWorksheetTable ReadWorksheetTable(Worksheet worksheet)
        {
            CellRange usedRange = worksheet.GetUsedRange();
            int lastRow = usedRange.BottomRowIndex;
            int lastColumn = usedRange.RightColumnIndex;
            Dictionary<string, int> columns = new(StringComparer.CurrentCultureIgnoreCase);

            for (int col = 0; col <= lastColumn; col++)
            {
                string caption = ReadCellText(worksheet, 0, col);
                if (!string.IsNullOrWhiteSpace(caption) && !columns.ContainsKey(caption))
                    columns.Add(caption, col);
            }

            return new ExcelWorksheetTable(worksheet, lastRow, columns);
        }

        private static string ReadCellText(Worksheet worksheet, int row, int col)
            => worksheet.Cells[row, col].DisplayText?.Trim() ?? string.Empty;

        private static string NormalizeExcelSheetName(string name)
        {
            string safeName = string.IsNullOrWhiteSpace(name) ? "Sheet" : name.Trim();
            foreach (char invalid in new[] { '[', ']', ':', '*', '?', '/', '\\' })
                safeName = safeName.Replace(invalid.ToString(), string.Empty);

            safeName = safeName.Trim('\'');
            if (safeName.Length > 31)
                safeName = safeName.Substring(0, 31);

            return string.IsNullOrWhiteSpace(safeName) ? "Sheet" : safeName;
        }

        private static string ReadOptionalText(ExcelWorksheetTable table, int row, string caption)
            => table.TryGetCellText(row, caption, out string value) ? value?.Trim() ?? string.Empty : string.Empty;

        private static bool HasCellValue(ExcelWorksheetTable table, int row, string caption)
            => table.TryGetCellText(row, caption, out string value) && !string.IsNullOrWhiteSpace(value);

        private static decimal? ReadOptionalDecimal(ExcelWorksheetTable table, int row, string caption)
        {
            string value = ReadOptionalText(table, row, caption);
            if (string.IsNullOrWhiteSpace(value))
                return null;

            if (decimal.TryParse(value, NumberStyles.Any, CultureInfo.CurrentCulture, out decimal current))
                return current;

            if (decimal.TryParse(value, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal invariant))
                return invariant;

            return null;
        }

        private static float? ReadOptionalFloat(ExcelWorksheetTable table, int row, string caption)
        {
            decimal? value = ReadOptionalDecimal(table, row, caption);
            return value.HasValue ? (float)value.Value : null;
        }

        private static int? ReadOptionalInt(ExcelWorksheetTable table, int row, string caption)
        {
            string value = ReadOptionalText(table, row, caption);
            if (string.IsNullOrWhiteSpace(value))
                return null;

            if (int.TryParse(value, NumberStyles.Any, CultureInfo.CurrentCulture, out int current))
                return current;

            if (int.TryParse(value, NumberStyles.Any, CultureInfo.InvariantCulture, out int invariant))
                return invariant;

            return null;
        }

        private static byte? ReadOptionalByte(ExcelWorksheetTable table, int row, string caption)
        {
            int? value = ReadOptionalInt(table, row, caption);
            if (!value.HasValue || value.Value < byte.MinValue || value.Value > byte.MaxValue)
                return null;

            return (byte)value.Value;
        }

        private static Guid? ReadOptionalGuid(ExcelWorksheetTable table, int row, string caption)
        {
            string value = ReadOptionalText(table, row, caption);
            return Guid.TryParse(value, out Guid guid) ? guid : null;
        }

        private static DateTime? ReadOptionalDate(ExcelWorksheetTable table, int row, string caption)
        {
            string value = ReadOptionalText(table, row, caption);
            if (string.IsNullOrWhiteSpace(value))
                return null;

            if (DateTime.TryParse(value, CultureInfo.CurrentCulture, DateTimeStyles.None, out DateTime current))
                return current.Date;

            if (DateTime.TryParse(value, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime invariant))
                return invariant.Date;

            return null;
        }

        private static TimeSpan? ReadOptionalTime(ExcelWorksheetTable table, int row, string caption)
        {
            string value = ReadOptionalText(table, row, caption);
            if (string.IsNullOrWhiteSpace(value))
                return null;

            if (TimeSpan.TryParse(value, CultureInfo.CurrentCulture, out TimeSpan current))
                return current;

            if (TimeSpan.TryParse(value, CultureInfo.InvariantCulture, out TimeSpan invariant))
                return invariant;

            if (DateTime.TryParse(value, CultureInfo.CurrentCulture, DateTimeStyles.None, out DateTime dateTime))
                return dateTime.TimeOfDay;

            return null;
        }

        private static bool? ReadOptionalBool(ExcelWorksheetTable table, int row, string caption)
        {
            string value = ReadOptionalText(table, row, caption);
            if (string.IsNullOrWhiteSpace(value))
                return null;

            if (bool.TryParse(value, out bool boolValue))
                return boolValue;

            if (int.TryParse(value, out int intValue))
                return intValue != 0;

            return null;
        }

        private static void SetIfText(ExcelWorksheetTable table, string caption, Action<string> setter)
        {
            if (!table.TryGetCellText(1, caption, out string value))
                return;

            setter(value?.Trim() ?? string.Empty);
        }

        private static void SetIfDecimal(ExcelWorksheetTable table, string caption, Action<decimal> setter)
        {
            decimal? value = ReadOptionalDecimal(table, 1, caption);
            if (value.HasValue)
                setter(value.Value);
        }

        private static void SetIfFloat(ExcelWorksheetTable table, string caption, Action<float> setter)
        {
            float? value = ReadOptionalFloat(table, 1, caption);
            if (value.HasValue)
                setter(value.Value);
        }

        private static void SetIfInt(ExcelWorksheetTable table, string caption, Action<int?> setter)
        {
            int? value = ReadOptionalInt(table, 1, caption);
            if (value.HasValue || table.Columns.ContainsKey(caption))
                setter(value);
        }

        private static void SetIfByte(ExcelWorksheetTable table, string caption, Action<byte> setter)
        {
            byte? value = ReadOptionalByte(table, 1, caption);
            if (value.HasValue)
                setter(value.Value);
        }

        private static void SetIfGuid(ExcelWorksheetTable table, string caption, Action<Guid?> setter)
        {
            Guid? value = ReadOptionalGuid(table, 1, caption);
            if (value.HasValue || table.Columns.ContainsKey(caption))
                setter(value);
        }

        private static void SetIfDate(ExcelWorksheetTable table, string caption, Action<DateTime> setter)
        {
            DateTime? value = ReadOptionalDate(table, 1, caption);
            if (value.HasValue)
                setter(FixSqlDate(value.Value));
        }

        private static void SetIfDateNullable(ExcelWorksheetTable table, string caption, Action<DateTime?> setter)
        {
            DateTime? value = ReadOptionalDate(table, 1, caption);
            if (value.HasValue || table.Columns.ContainsKey(caption))
                setter(value.HasValue ? FixSqlDate(value.Value) : null);
        }

        private static void SetIfTime(ExcelWorksheetTable table, string caption, Action<TimeSpan> setter)
        {
            TimeSpan? value = ReadOptionalTime(table, 1, caption);
            if (value.HasValue)
                setter(value.Value);
        }

        private static void SetIfBool(ExcelWorksheetTable table, string caption, Action<bool> setter)
        {
            bool? value = ReadOptionalBool(table, 1, caption);
            if (value.HasValue)
                setter(value.Value);
        }

        private void ValidateEntityValue<T>(
            ExcelWorksheetTable table,
            int row,
            string caption,
            List<string> errors,
            bool allowEmpty = false,
            TryParseIntDelegate convert = null)
            where T : class
        {
            string value = ReadOptionalText(table, row, caption);
            if (string.IsNullOrWhiteSpace(value))
            {
                if (!allowEmpty && table.Columns.ContainsKey(caption))
                    errors.Add($"{caption}: {Resources.Common_InvalidValue}");
                return;
            }

            object key = value;
            if (convert is not null)
            {
                if (!convert(value, out int intKey))
                {
                    errors.Add($"{caption}: {value} {Resources.Common_InvalidValue}");
                    return;
                }
                key = intKey;
            }

            if (!_efMethods.EntityExists<T>(key))
                errors.Add($"{caption}: {value} {Resources.Common_NotFound}");
        }

        private static string NullIfEmpty(string value)
            => string.IsNullOrWhiteSpace(value) ? null : value.Trim();

        private static DateTime FixSqlDate(DateTime dt)
            => dt < new DateTime(1753, 1, 1) ? DefaultSqlDate : dt;

        private static bool IsInstallmentProcess(TrInvoiceHeader invoiceHeader, DcProcess process)
            => string.Equals(invoiceHeader?.ProcessCode ?? process?.ProcessCode, "IS", StringComparison.OrdinalIgnoreCase);

        private static bool IsTransferProcess(DcProcess process)
            => string.Equals(process?.ProcessCode, "IT", StringComparison.OrdinalIgnoreCase);

        private delegate bool TryParseIntDelegate(string value, out int result);

        internal sealed class InvoiceExcelCaptions
        {
            public readonly string SheetHeader = Resources.Entity_InvoiceHeader;
            public readonly string SheetLines = Resources.Entity_InvoiceLine;
            public readonly string SheetLineFeatures = Resources.Entity_InvoiceLineFeatureLink;
            public readonly string SheetInstallment = Resources.Entity_Installment;
            public readonly string SheetInstallmentGuarantors = Resources.Entity_InstallmentGuarantor;

            public readonly string LineNo = Resources.Common_Identity;
            public readonly string InvoiceHeaderId = Resources.Entity_InvoiceHeader_InvoiceHeaderId;
            public readonly string RelatedInvoiceId = Resources.Entity_InvoiceHeader_RelatedInvoiceId;
            public readonly string ProcessCode = Resources.Entity_InvoiceHeader_ProcessCode;
            public readonly string DocumentNumber = Resources.Entity_InvoiceHeader_DocumentNumber;
            public readonly string IsReturn = Resources.Entity_InvoiceHeader_IsReturn;
            public readonly string DocumentDate = Resources.Entity_InvoiceHeader_DocumentDate;
            public readonly string DocumentTime = Resources.Entity_InvoiceHeader_DocumentTime;
            public readonly string OperationDate = Resources.Entity_InvoiceHeader_OperationDate;
            public readonly string OperationTime = Resources.Entity_InvoiceHeader_OperationTime;
            public readonly string Description = Resources.Entity_InvoiceHeader_Description;
            public readonly string CurrAccCode = Resources.Entity_InvoiceHeader_CurrAccCode;
            public readonly string OfficeCode = Resources.Entity_InvoiceHeader_OfficeCode;
            public readonly string StoreCode = Resources.Entity_InvoiceHeader_StoreCode;
            public readonly string WarehouseCode = Resources.Entity_InvoiceHeader_WarehouseCode;
            public readonly string ToWarehouseCode = Resources.Entity_InvoiceHeader_ToWarehouseCode;
            public readonly string CustomsDocumentNumber = Resources.Entity_InvoiceHeader_CustomsDocumentNumber;
            public readonly string TerminalId = Resources.Entity_InvoiceHeader_TerminalId;
            public readonly string LoyaltyCardId = Resources.Entity_InvoiceHeader_LoyaltyCardId;
            public readonly string IsSent = Resources.Entity_InvoiceHeader_IsSent;
            public readonly string IsCompleted = Resources.Entity_InvoiceHeader_IsCompleted;
            public readonly string PrintCount = Resources.Entity_InvoiceHeader_PrintCount;
            public readonly string DeliveryDate = Resources.Entity_InvoiceHeader_DeliveryDate;
            public readonly string CashRegisterCode = ReflectionExt.GetDisplayName<TrPaymentLine>(x => x.CashRegisterCode);

            public readonly string InvoiceLineId = Resources.Entity_InvoiceLine_Id;
            public readonly string ProductCode = Resources.Entity_InvoiceLine_ProductCode;
            public readonly string ProductDesc = Resources.Entity_InvoiceLine_ProductDesc;
            public readonly string Barcode = Resources.Entity_InvoiceLine_Barcode;
            public readonly string Qty = Resources.Entity_InvoiceLine_Qty;
            public readonly string QtyIn = Resources.Entity_InvoiceLine_QtyIn;
            public readonly string QtyOut = Resources.Entity_InvoiceLine_QtyOut;
            public readonly string UnitOfMeasureId = Resources.Entity_InvoiceLine_UnitOfMeasureId;
            public readonly string Price = Resources.Entity_InvoiceLine_Price;
            public readonly string CurrencyCode = Resources.Entity_InvoiceLine_CurrencyCode;
            public readonly string ExchangeRate = Resources.Entity_InvoiceLine_ExchangeRate;
            public readonly string PriceLoc = Resources.Entity_InvoiceLine_PriceLoc;
            public readonly string Amount = Resources.Entity_InvoiceLine_Amount;
            public readonly string AmountLoc = Resources.Entity_InvoiceLine_AmountLoc;
            public readonly string PosDiscount = Resources.Entity_InvoiceLine_PosDiscount;
            public readonly string NetAmount = Resources.Entity_InvoiceLine_NetAmount;
            public readonly string NetAmountLoc = Resources.Entity_InvoiceLine_NetAmountLoc;
            public readonly string DiscountCampaign = Resources.Entity_InvoiceLine_DiscountCampaign;
            public readonly string VatRate = Resources.Entity_InvoiceLine_VatRate;
            public readonly string LineDescription = Resources.Entity_InvoiceLine_LineDescription;
            public readonly string SerialNumberCode = Resources.Entity_InvoiceLine_SerialNumberCode;
            public readonly string SalesPersonCode = Resources.Entity_InvoiceLine_SalesPersonCode;
            public readonly string WorkerCode = Resources.Entity_InvoiceLine_WorkerCode;
            public readonly string ProductCost = Resources.Entity_InvoiceLine_ProductCost;
            public readonly string Benefit = Resources.Entity_InvoiceLine_Benefit;
            public readonly string TotalBenefit = Resources.Entity_InvoiceLine_TotalBenefit;

            public readonly string FeatureTypeId = Resources.Entity_InvoiceLineFeatureType_Id;
            public readonly string FeatureTypeName = Resources.Entity_InvoiceLineFeatureType_Name;
            public readonly string FeatureCode = Resources.Entity_InvoiceLineFeature_Code;
            public readonly string FeatureDesc = Resources.Entity_InvoiceLineFeature_Desc;

            public readonly string InstallmentId = Resources.Entity_Installment_Id;
            public readonly string InstallmentPlanCode = Resources.Entity_Installment_PlanCode;
            public readonly string InstallmentDate = Resources.Entity_Installment_Date;
            public readonly string InstallmentCommission = Resources.Entity_Installment_Commission;
            public readonly string InstallmentInterestRate = Resources.Entity_Installment_InterestRate;
            public readonly string GuarantorId = Resources.Entity_InstallmentGuarantor_Id;
        }

        internal sealed class ExcelWorksheetTable
        {
            public ExcelWorksheetTable(Worksheet worksheet, int lastRow, Dictionary<string, int> columns)
            {
                Worksheet = worksheet;
                LastRow = lastRow;
                Columns = columns;
            }

            public Worksheet Worksheet { get; }
            public int LastRow { get; }
            public Dictionary<string, int> Columns { get; }

            public bool TryGetCellText(int row, string caption, out string value)
            {
                value = string.Empty;

                if (!Columns.TryGetValue(caption.Trim(), out int col))
                    return false;

                value = ReadCellText(Worksheet, row, col);
                return true;
            }
        }

        internal sealed class ImportedInvoiceLine
        {
            public int LineNo { get; set; }
            public string ProductCode { get; set; }
            public string Barcode { get; set; }
            public bool HasQty { get; set; }
            public bool HasQtyIn { get; set; }
            public bool HasQtyOut { get; set; }
            public decimal? Qty { get; set; }
            public decimal? QtyIn { get; set; }
            public decimal? QtyOut { get; set; }
            public int? UnitOfMeasureId { get; set; }
            public decimal? Price { get; set; }
            public string CurrencyCode { get; set; }
            public float? ExchangeRate { get; set; }
            public decimal? PosDiscount { get; set; }
            public decimal? DiscountCampaign { get; set; }
            public float? VatRate { get; set; }
            public string LineDescription { get; set; }
            public string SerialNumberCode { get; set; }
            public string SalesPersonCode { get; set; }
            public string WorkerCode { get; set; }
            public decimal? ProductCost { get; set; }
            public DcProduct Product { get; set; }
            public DcCurrency Currency { get; set; }
        }

        internal sealed class ImportedInvoiceLineFeature
        {
            public int LineNo { get; set; }
            public int FeatureTypeId { get; set; }
            public string FeatureCode { get; set; }
        }

        internal sealed class ImportedInstallmentGuarantor
        {
            public string CurrAccCode { get; set; }
            public DcCurrAcc CurrAcc { get; set; }
        }

        public sealed class InvoiceExcelExportContext
        {
            public TrInvoiceHeader InvoiceHeader { get; init; } = null!;
            public DcProcess Process { get; init; } = null!;
            public IEnumerable<TrInvoiceLine> InvoiceLines { get; init; } = Enumerable.Empty<TrInvoiceLine>();
            public IEnumerable<TrInstallmentGuarantor> InstallmentGuarantors { get; init; } = Enumerable.Empty<TrInstallmentGuarantor>();
            public Func<TrInstallment> EnsureInstallment { get; init; } = null!;
        }

        public sealed class InvoiceExcelImportContext
        {
            public TrInvoiceHeader InvoiceHeader { get; init; } = null!;
            public DcProcess Process { get; init; } = null!;
            public byte[] ProductTypeArr { get; init; } = Array.Empty<byte>();
            public Func<TrInstallment> EnsureInstallment { get; init; } = null!;
            public Func<IList<TrInstallmentGuarantor>> GetInstallmentGuarantors { get; init; } = () => new List<TrInstallmentGuarantor>();
            public Func<subContext?> GetInstallmentGuarantorContext { get; init; } = () => null;
        }

        public sealed class InvoiceExcelImportPlan
        {
            internal InvoiceExcelImportPlan(InvoiceExcelCaptions captions)
            {
                _captions = captions;
            }

            internal readonly InvoiceExcelCaptions _captions;
            internal readonly List<ImportedInvoiceLine> _lines = new();
            internal readonly List<ImportedInvoiceLineFeature> _features = new();
            internal readonly List<ImportedInstallmentGuarantor> _guarantors = new();
            internal Workbook _workbook;
            internal ExcelWorksheetTable _headerTable;
            internal ExcelWorksheetTable _lineTable;
            internal ExcelWorksheetTable _featureTable;
            internal ExcelWorksheetTable _installmentTable;
            internal ExcelWorksheetTable _guarantorTable;
            internal bool _headerValuesValidated;

            public List<string> Errors { get; } = new();
            public bool HasErrors => Errors.Any();
            public string ImportedProcessCode { get; internal set; }

            public bool HasDifferentProcess(string currentProcessCode)
            {
                return !string.IsNullOrWhiteSpace(ImportedProcessCode)
                    && !string.Equals(ImportedProcessCode, currentProcessCode, StringComparison.OrdinalIgnoreCase);
            }
        }
    }
}
