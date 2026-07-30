using Foxoft.Models;
using Microsoft.EntityFrameworkCore;

namespace Foxoft.AppCode.Service
{
    public sealed class NotificationStockCheckerService
    {
        private static readonly string[] StockProcessCodes = { "RP", "WP", "RS", "WS", "IS", "CI", "CO", "IT" };
        private static readonly string[] StockWarningTypeCodes = { NotificationTypeCodes.ProductStockWarning, NotificationTypeCodes.ProductOutOfStock };
        private readonly subContext _db;

        public NotificationStockCheckerService(subContext db)
        {
            _db = db;
        }

        public async Task<int> ScanProductStockWarningsAsync(
            IEnumerable<(string ProductCode, string WarehouseCode)> targets,
            string? actorCurrAccCode = null,
            CancellationToken ct = default)
        {
            DateTime scanStartedAt = DateTime.Now;

            List<StockCheckTarget> targetList = NormalizeTargets(targets);
            if (targetList.Count == 0)
                return 0;

            string[] productCodes = targetList
                .Select(x => x.ProductCode)
                .Distinct(StringComparer.OrdinalIgnoreCase)
                .ToArray();

            string[] warehouseCodes = targetList
                .Select(x => x.WarehouseCode)
                .Distinct(StringComparer.OrdinalIgnoreCase)
                .ToArray();

            List<DcProduct> products = await _db.DcProducts
                .AsNoTracking()
                .Where(x => productCodes.Contains(x.ProductCode))
                .Where(x => x.ProductTypeCode == 1)
                .Where(x => !x.IsDisabled)
                .Where(x => x.BalanceWarningLevel.HasValue)
                .ToListAsync(ct);

            List<DcWarehouse> warehouses = await _db.DcWarehouses
                .AsNoTracking()
                .Where(x => warehouseCodes.Contains(x.WarehouseCode))
                .Where(x => !x.IsDisabled)
                .ToListAsync(ct);

            var balanceRows = await _db.TrInvoiceLines
                .AsNoTracking()
                .Where(x => productCodes.Contains(x.ProductCode))
                .Where(x => warehouseCodes.Contains(x.TrInvoiceHeader.WarehouseCode))
                .Where(x => StockProcessCodes.Contains(x.TrInvoiceHeader.ProcessCode))
                .GroupBy(x => new { x.ProductCode, x.TrInvoiceHeader.WarehouseCode })
                .Select(x => new
                {
                    x.Key.ProductCode,
                    x.Key.WarehouseCode,
                    AvailableQty = x.Sum(y => y.QtyIn - y.QtyOut)
                })
                .ToListAsync(ct);

            Dictionary<string, decimal> balanceByProductWarehouse = balanceRows
                .ToDictionary(x => BuildTargetKey(x.ProductCode, x.WarehouseCode), x => x.AvailableQty, StringComparer.OrdinalIgnoreCase);

            NotificationService notificationService = new(_db);
            HashSet<string> activeKeys = new(StringComparer.OrdinalIgnoreCase);
            HashSet<string> resolveKeys = new(StringComparer.OrdinalIgnoreCase);
            int affectedCount = await ProcessTargetsAsync(targetList, products, warehouses, balanceByProductWarehouse, notificationService, activeKeys, resolveKeys, ct);

            await notificationService.ResolveInactiveKeysAsync(
                activeKeys,
                StockWarningTypeCodes,
                actorCurrAccCode,
                ct,
                resolveKeys,
                scanStartedAt);

            return affectedCount;
        }

        private static List<StockCheckTarget> NormalizeTargets(IEnumerable<(string ProductCode, string WarehouseCode)> targets)
            => targets
                .Where(x => !string.IsNullOrWhiteSpace(x.ProductCode) && !string.IsNullOrWhiteSpace(x.WarehouseCode))
                .Select(x => new StockCheckTarget(x.ProductCode.Trim(), x.WarehouseCode.Trim()))
                .GroupBy(x => BuildTargetKey(x.ProductCode, x.WarehouseCode), StringComparer.OrdinalIgnoreCase)
                .Select(x => x.First())
                .ToList();

        private async Task<int> ProcessTargetsAsync(
            IEnumerable<StockCheckTarget> targets,
            IEnumerable<DcProduct> products,
            IEnumerable<DcWarehouse> warehouses,
            IReadOnlyDictionary<string, decimal> balanceByProductWarehouse,
            NotificationService notificationService,
            HashSet<string> activeKeys,
            HashSet<string> resolveKeys,
            CancellationToken ct)
        {
            Dictionary<string, DcProduct> productByCode = products
                .ToDictionary(x => x.ProductCode, x => x, StringComparer.OrdinalIgnoreCase);

            Dictionary<string, DcWarehouse> warehouseByCode = warehouses
                .ToDictionary(x => x.WarehouseCode, x => x, StringComparer.OrdinalIgnoreCase);

            int affectedCount = 0;

            foreach (StockCheckTarget target in targets)
            {
                if (!productByCode.TryGetValue(target.ProductCode, out DcProduct? product)
                    || !warehouseByCode.TryGetValue(target.WarehouseCode, out DcWarehouse? warehouse))
                {
                    AddResolveKeysForTarget(target, resolveKeys);
                    continue;
                }

                decimal availableQty = balanceByProductWarehouse.TryGetValue(BuildTargetKey(product.ProductCode, warehouse.WarehouseCode), out decimal balance)
                    ? balance
                    : 0m;

                string productStockWarningKey = BuildNotificationKey(NotificationTypeCodes.ProductStockWarning, product.ProductCode, warehouse.WarehouseCode);
                string productOutOfStockKey = BuildNotificationKey(NotificationTypeCodes.ProductOutOfStock, product.ProductCode, warehouse.WarehouseCode);

                if (availableQty > product.BalanceWarningLevel!.Value)
                {
                    resolveKeys.Add(productStockWarningKey);
                    resolveKeys.Add(productOutOfStockKey);
                    continue;
                }

                bool outOfStock = availableQty <= 0;
                if (!outOfStock)
                    resolveKeys.Add(productOutOfStockKey);

                Dictionary<string, string> placeholders = new()
                {
                    ["ProductCode"] = product.ProductCode,
                    ["ProductDesc"] = product.ProductDesc ?? product.ProductCode,
                    ["WarehouseCode"] = warehouse.WarehouseCode,
                    ["WarehouseDesc"] = warehouse.WarehouseDesc ?? warehouse.WarehouseCode,
                    ["StoreCode"] = warehouse.StoreCode,
                    ["AvailableQty"] = availableQty.ToString("0.####"),
                    ["WarningQty"] = product.BalanceWarningLevel.Value.ToString("0.####")
                };

                Notification? stockWarningNotification = await notificationService.CreateOrUpdateAsync(
                    new NotificationCreateRequest(
                        NotificationTypeCode: NotificationTypeCodes.ProductStockWarning,
                        NotificationKey: productStockWarningKey,
                        Severity: NotificationSeverities.Warning,
                        EntityType: NotificationEntityTypes.Product,
                        EntityKey: product.ProductCode,
                        StoreCode: warehouse.StoreCode,
                        Placeholders: placeholders),
                    ct);

                if (stockWarningNotification != null)
                {
                    activeKeys.Add(productStockWarningKey);
                    affectedCount++;
                }

                if (outOfStock)
                {
                    Notification? outOfStockNotification = await notificationService.CreateOrUpdateAsync(
                        new NotificationCreateRequest(
                            NotificationTypeCode: NotificationTypeCodes.ProductOutOfStock,
                            NotificationKey: productOutOfStockKey,
                            Severity: NotificationSeverities.Critical,
                            EntityType: NotificationEntityTypes.Product,
                            EntityKey: product.ProductCode,
                            StoreCode: warehouse.StoreCode,
                            Placeholders: placeholders),
                        ct);

                    if (outOfStockNotification != null)
                    {
                        activeKeys.Add(productOutOfStockKey);
                        affectedCount++;
                    }
                }
            }

            return affectedCount;
        }

        private static IEnumerable<string> CreateNotificationKeysForTarget(StockCheckTarget target)
            => StockWarningTypeCodes.Select(notificationTypeCode => BuildNotificationKey(notificationTypeCode, target.ProductCode, target.WarehouseCode));

        private static void AddResolveKeysForTarget(StockCheckTarget target, HashSet<string> resolveKeys)
        {
            foreach (string notificationKey in CreateNotificationKeysForTarget(target))
                resolveKeys.Add(notificationKey);
        }

        private static string BuildNotificationKey(string notificationTypeCode, string productCode, string warehouseCode)
            => $"{notificationTypeCode}:Product:{productCode}:Warehouse:{warehouseCode}";

        private static string BuildTargetKey(string productCode, string warehouseCode)
            => $"{productCode}\u001F{warehouseCode}";

        private sealed record StockCheckTarget(string ProductCode, string WarehouseCode);
    }
}
