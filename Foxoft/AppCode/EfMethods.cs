using DevExpress.CodeParser;
using DevExpress.Data.Filtering;
using DevExpress.Data.Linq;
using DevExpress.Data.Linq.Helpers;
using DevExpress.Data.ODataLinq.Helpers;
using DevExpress.Mvvm.Native;
using DevExpress.Spreadsheet;
using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;
using DevExpress.XtraSpreadsheet.Model;
using Foxoft.Models;
using Foxoft.Models.Entity;
using Foxoft.Models.Entity.Report;
using Foxoft.Models.Entity.RoleClaim;
using Foxoft.Models.ViewModel;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace Foxoft
{
    public class EfMethods
    {
        //private subContext db;
        public EfMethods()
        {
            //this.db = new subContext();
        }

        public string GetNextDocNum(bool DefisExist, string processCode, string columnName, string tableName, int ReplicateNum)
        {
            using subContext db = new();
            string qry = $"exec [dbo].[GetNextDocNum] {DefisExist}, '{processCode}', '{columnName}', '{tableName}', {ReplicateNum}";

            return db.Set<GetNextDocNum>()
                .FromSqlRaw(qry)
                .AsEnumerable()
                .First()
                .Value;
        }

        public List<T> SelectEntities<T>() where T : class
        {
            using subContext db = new();
            return db.Set<T>().ToList();
        }

        public List<DcCompany> SelectCompanies()
        {
            using mainContext db = new();
            return db.DcCompanies.ToList();
        }

        public T InsertEntity<T>(T entity) where T : class
        {
            using subContext db = new();
            db.Set<T>().Add(entity);
            int rowAffected = db.SaveChanges();

            if (rowAffected > 0)
                return entity;
            else
                return null;
        }

        public int UpdateEntity<T>(T entity) where T : class
        {
            using subContext db = new();
            db.Set<T>().Update(entity);
            return db.SaveChanges();
        }

        public T SelectEntityById<T>(params object[] keyValues) where T : class
        {
            using subContext db = new();
            return db.Set<T>().Find(keyValues);
        }

        public bool EntityExists<T>(params object[] keyValues) where T : class
        {
            using subContext db = new();
            return db.Set<T>().Find(keyValues) != null;
        }

        public int DeleteEntity<T>(T entity) where T : class
        {
            using subContext db = new();

            db.Set<T>().Remove(entity);
            return db.SaveChanges();
        }

        public int DeleteEntityById<T>(params object[] keyValues) where T : class
        {
            using subContext db = new();
            var entity = db.Set<T>().Find(keyValues); // Find the entity by primary key(s)
            if (entity != null)
            {
                db.Set<T>().Remove(entity); // Mark the entity for deletion
                return db.SaveChanges(); // Save changes to the database
            }
            else return 0;
        }

        public List<TrInvoiceLine> SelectInvoiceLines(Guid invoiceHeaderId)
        {
            using subContext db = new();
            {
                List<TrInvoiceLine> InvoiceLines = db.TrInvoiceLines.Include(x => x.DcProduct)
                                                                  .Include(x => x.TrInvoiceHeader)
                                                                  .Where(x => x.InvoiceHeaderId == invoiceHeaderId)
                                                                  .OrderBy(x => x.CreatedDate)
                                                                  .ToList();

                InvoiceLines.ForEach(x =>
                {
                    x.ProductDesc = x.DcProduct.ProductDesc;
                });

                return InvoiceLines;
            }
        }

        public List<ReturnLineVM> SelectReturnLineVMs(Guid invoiceHeaderId)
        {
            using subContext db = new();

            var lines = db.TrInvoiceLines
                .Include(x => x.DcProduct)
                .Include(x => x.TrInvoiceHeader)
                .Where(x => x.InvoiceHeaderId == invoiceHeaderId)
                .OrderBy(x => x.CreatedDate)
                .ToList();

            var returnedByRelatedId = db.TrInvoiceLines
                .Include(y => y.TrInvoiceHeader)
                .Where(y => y.TrInvoiceHeader.IsReturn)
                .Where(y => y.RelatedLineId != null)
                .GroupBy(y => y.RelatedLineId!.Value)
                .Select(g => new
                {
                    RelatedLineId = g.Key,
                    ReturnQty = g.Sum(s => Math.Abs(s.QtyIn - s.QtyOut))
                })
                .ToDictionary(x => x.RelatedLineId, x => x.ReturnQty);


            var deliveredByRelatedId = db.TrInvoiceLines
                .Include(y => y.TrInvoiceHeader)
                .Where(y => y.TrInvoiceHeader.ProcessCode == "WO")
                .Where(y => y.RelatedLineId != null)
                .GroupBy(y => y.RelatedLineId!.Value)
                .Select(g => new
                {
                    RelatedLineId = g.Key,
                    ReturnQty = g.Sum(s => Math.Abs(s.QtyIn - s.QtyOut))
                })
                .ToDictionary(x => x.RelatedLineId, x => x.ReturnQty);

            var vms = AutoMapper<TrInvoiceLine, ReturnLineVM>.MapList(
                lines,
                afterMap: (src, dest) =>
                {
                    var returnedQty = returnedByRelatedId.TryGetValue(src.InvoiceLineId, out var rq) ? rq : 0m;
                    var deliveredQty = deliveredByRelatedId.TryGetValue(src.InvoiceLineId, out var dq) ? dq : 0m;

                    dest.ProductDesc = src.DcProduct.ProductDesc;
                    dest.ReturnQty = returnedQty;
                    dest.RemainingQty = Math.Abs(src.QtyIn - src.QtyOut) - returnedQty;
                    dest.DeliveredQty = deliveredQty;
                });

            return vms;
        }



        public List<TrInvoiceHeader> SelectMasterForDelivery(Guid? invoiceHeader = null)
        {
            using subContext db = new();

            return db.TrInvoiceHeaders
                .Include(x => x.DcCurrAcc)
                .Where(x => new[] { "RS", "WS" }.Contains(x.ProcessCode)
                            && (!invoiceHeader.HasValue || x.InvoiceHeaderId == invoiceHeader.Value))
                .OrderByDescending(x => x.DocumentDate)
                .ToList();
        }

        // Service layer (can live in your repo/service class)
        public async IAsyncEnumerable<TrInvoiceHeader> StreamMasterForDeliveryAsync(
                                Guid? invoiceHeader = null,
                        [System.Runtime.CompilerServices.EnumeratorCancellation] CancellationToken cancellationToken = default)
        {
            await using var db = new subContext();

            var qry = db.TrInvoiceHeaders
                .AsNoTracking()
                .Include(x => x.DcCurrAcc)
                .Where(x => new[] { "RS", "WS" }.Contains(x.ProcessCode)
                            && (!invoiceHeader.HasValue || x.InvoiceHeaderId == invoiceHeader.Value))
                .OrderByDescending(x => x.DocumentDate)
                .AsAsyncEnumerable()
                .WithCancellation(cancellationToken);

            await foreach (var h in qry)
            {
                cancellationToken.ThrowIfCancellationRequested();
                yield return h;
            }
        }

        //public async Task<List<UnDeliveredViewModel>> SelectInvoiceLinesForDeliveryAsync(Guid? invoiceHeader = null)
        //{
        //    await using var db = new subContext();

        //    var data = await db.TrInvoiceLines
        //        .Include(x => x.DcProduct)
        //        .Include(x => x.TrInvoiceHeader).ThenInclude(x => x.DcCurrAcc)
        //        .Where(x => new[] { "RS", "WS" }.Contains(x.TrInvoiceHeader.ProcessCode)
        //                    && (!invoiceHeader.HasValue || x.InvoiceHeaderId == invoiceHeader.Value))
        //        .Select(x => new
        //        {
        //            TrInvoiceLine = x,
        //            TrInvoiceHeader = x.TrInvoiceHeader,
        //            Returned = db.TrInvoiceLines
        //                        .Where(y => y.RelatedLineId == x.InvoiceLineId &&
        //                                    new[] { "WI", "WO" }.Contains(y.TrInvoiceHeader.ProcessCode))
        //                        .Sum(y => y.QtyIn - y.QtyOut),
        //            Original = x.QtyIn - x.QtyOut
        //        })
        //        .Where(t => Math.Abs(t.Original) - Math.Abs(t.Returned) > 0)
        //        .ToListAsync();

        //    return data
        //        .Select(t => new UnDeliveredViewModel
        //        {
        //            TrInvoiceLine = t.TrInvoiceLine,
        //            TrInvoiceHeader = t.TrInvoiceHeader,
        //            ReturnQty = Math.Abs(t.Returned),
        //            RemainingQty = Math.Abs(t.Original) - Math.Abs(t.Returned)
        //        })
        //        .OrderByDescending(x => x.TrInvoiceHeader.DocumentDate)
        //        .ToList();
        //}

        public List<TrPriceListLine> SelectPriceListLines(Guid priceListHeaderId)
        {
            using subContext db = new();
            {
                List<TrPriceListLine> PriceListLines = db.TrPriceListLines.Include(x => x.DcProduct)
                                                                  .Include(x => x.TrPriceListHeader)
                                                                  .Where(x => x.PriceListHeaderId == priceListHeaderId)
                                                                  .OrderBy(x => x.CreatedDate)
                                                                  .ToList();

                return PriceListLines;
            }
        }

        public decimal SelectInvoiceNetAmount(Guid invoiceHeaderId)
        {
            using subContext db = new();

            decimal sumNetAmount = db.TrInvoiceLines.Where(x => x.InvoiceHeaderId == invoiceHeaderId)
                                                    .Sum(x => x.NetAmountLoc);
            return sumNetAmount;
        }

        public DateTime SelectInvoiceLastModifiedDate()
        {
            using subContext db = new();
            return db.TrInvoiceHeaders
                    .Select(h => h.LastUpdatedDate)
                    .Concat(db.TrInvoiceLines.Select(l => l.LastUpdatedDate))
                    .Max();
        }

        public string SelectInvoiceLastUpdatedUserName(Guid invoiceHeaderId)
        {
            using subContext db = new();
            var latestUserNameFromHeader = db.TrInvoiceHeaders
                .Where(x => x.InvoiceHeaderId == invoiceHeaderId)
                .OrderByDescending(h => h.LastUpdatedDate)
                .Select(h => new { h.LastUpdatedDate, h.LastUpdatedUserName })
                .FirstOrDefault();

            var latestUserNameFromLine = db.TrInvoiceLines
                .Where(x => x.InvoiceHeaderId == invoiceHeaderId)
                .OrderByDescending(l => l.LastUpdatedDate)
                .Select(l => new { l.LastUpdatedDate, l.LastUpdatedUserName })
                .FirstOrDefault();

            return (latestUserNameFromHeader == null ||
                (latestUserNameFromLine != null && latestUserNameFromLine.LastUpdatedDate > latestUserNameFromHeader.LastUpdatedDate))
                ? latestUserNameFromLine?.LastUpdatedUserName
                : latestUserNameFromHeader?.LastUpdatedUserName;
        }

        public List<DcFeatureType> SelectFeatureTypesByHierarchy(string hierarchyCode)
        {
            using subContext db = new();

            List<DcFeatureType> featureTypes =
                db.DcFeatureTypes.Include(x => x.TrHierarchyFeatureTypes)
                    .ThenInclude(x => x.DcHierarchy)
                .Where(x => x.TrHierarchyFeatureTypes.Where(x => x.HierarchyCode == hierarchyCode).Any() || !x.TrHierarchyFeatureTypes.Any())
                .OrderByDescending(x => x.Order)
                .ToList();

            return featureTypes;
        }

        public TrProductFeature SelectProductFeature(string productCode, int featureTypeId)
        {
            using subContext db = new();

            TrProductFeature dc = db.TrProductFeatures
                     .Where(x => x.FeatureTypeId == featureTypeId)
                     .FirstOrDefault(x => x.ProductCode == productCode);
            return dc;
        }

        public TrCurrAccFeature SelectCurrAccFeature(string currAccCode, int featureTypeId)
        {
            using subContext db = new();

            TrCurrAccFeature dc = db.TrCurrAccFeatures
                     .Where(x => x.CurrAccFeatureTypeId == featureTypeId)
                     .FirstOrDefault(x => x.CurrAccCode == currAccCode);
            return dc;
        }


        //public DcFeatureType SelectFeatureType(int featureTypeId)
        //{
        //    using subContext db = new();

        //    DcFeatureType dc = db.DcFeatureTypes
        //             .FirstOrDefault(x => x.FeatureTypeId == featureTypeId);
        //    return dc;
        //}

        public DcProduct SelectProductByBarcode(string barCode)
        {
            if (string.IsNullOrEmpty(barCode))
                return null;
            using subContext db = new();

            return db.DcProducts
                .Include(x => x.TrProductBarcodes.Where(x => x.Barcode == barCode))
                .Where(x => x.TrProductBarcodes.Any(x => x.Barcode == barCode))
                .Select(x => new DcProduct
                {
                    ProductCost = SqlFunctions.GetProductCost(x.ProductCode, null),
                    ProductCode = x.ProductCode,
                    ProductDesc = x.ProductDesc,
                    PosDiscount = x.PosDiscount,
                    RetailPrice = x.RetailPrice,
                    PurchasePrice = x.PurchasePrice,
                    ProductTypeCode = x.ProductTypeCode,
                    WholesalePrice = x.WholesalePrice,
                    UsePos = x.UsePos,
                    UseInternet = x.UseInternet,
                    CreatedDate = x.CreatedDate,
                    CreatedUserName = x.CreatedUserName,
                    LastUpdatedDate = x.LastUpdatedDate,
                    LastUpdatedUserName = x.LastUpdatedUserName,
                    HierarchyCode = x.HierarchyCode,
                    TrProductFeatures = x.TrProductFeatures,
                    SiteProduct = x.SiteProduct,
                    DcHierarchy = x.DcHierarchy,
                    TrProductDiscounts = x.TrProductDiscounts,
                    DcSerialNumbers = x.DcSerialNumbers,
                    DefaultUnitOfMeasureId = x.DefaultUnitOfMeasureId,
                    TrProductBarcodes = x.TrProductBarcodes
                }).FirstOrDefault();
        }

        public DcProduct SelectProductById(int id)
        {
            using subContext db = new();

            return db.DcProducts.Include(x => x.DcProductScale)
                .FirstOrDefault(x => x.DcProductScale.ScaleProductNumber == id && x.DcProductScale.UseInScale == true);
        }

        public DcProduct SelectProductBySerialNumber(string serialNumberCode)
        {
            if (string.IsNullOrEmpty(serialNumberCode))
                return null;
            using subContext db = new();
            return QueryableSelectProducts(db)
                                       .Where(x => x.DcSerialNumbers.Any(x => x.SerialNumberCode == serialNumberCode))
                                       .FirstOrDefault();
        }

        public DcProduct SelectProduct(string productCode, byte[] productTypeCode)
        {
            using subContext db = new();
            var product = QueryableSelectProducts(db)
                            .Where(x => productTypeCode.Contains(x.ProductTypeCode))
                            .FirstOrDefault(x => x.ProductCode == productCode);
            return product;
        }

        public DcProduct SelectExpense(string productCode)
        {
            using subContext db = new();
            var product = QueryableSelectProducts(db)
                            .Where(x => x.ProductTypeCode == 2)
                            .FirstOrDefault(x => x.ProductCode == productCode);
            return product;
        }

        public List<DcUnitOfMeasure> SelectUnitOfMeasuresAllRelated(int parentMeasureId)
        {
            using var db = new subContext();
            var result = new List<DcUnitOfMeasure>();

            void Collect(int? unitId)
            {
                if (result.Any(x => x.UnitOfMeasureId == unitId))
                    return;

                var unit = db.DcUnitOfMeasures.FirstOrDefault(x => x.UnitOfMeasureId == unitId);
                if (unit == null)
                    return;

                result.Add(unit);

                // Recurse to parent
                if (unit.ParentUnitOfMeasureId != 0)
                    Collect(unit.ParentUnitOfMeasureId);

                // Recurse to children
                var children = db.DcUnitOfMeasures
                    .Where(x => x.ParentUnitOfMeasureId == unitId)
                    .Select(x => x.UnitOfMeasureId)
                    .ToList();

                foreach (var childId in children)
                    Collect(childId);
            }

            Collect(parentMeasureId);
            return result;
        }

        public List<DcProduct> SelectProducts(bool? isDisabled)
        {
            using subContext db = new();
            return QueryableSelectProducts(db).ToList();
        }

        public IQueryable<DcProduct> QueryableSelectProducts(subContext db)
        {
            var products = db.DcProducts
                                .Include(x => x.TrProductFeatures).ThenInclude(x => x.DcFeature).ThenInclude(x => x.DcFeatureType)
                                .Include(x => x.TrInvoiceLines).ThenInclude(x => x.TrInvoiceHeader)
                                .Include(x => x.TrProductDiscounts).ThenInclude(x => x.DcDiscount).ThenInclude(x => x.TrPaymentMethodDiscounts).ThenInclude(x => x.DcPaymentMethod)
                                .Include(x => x.DcHierarchy)
                                .Include(x => x.SiteProduct)
                                .Include(x => x.DcSerialNumbers)
                                .Select(x => new DcProduct
                                {
                                    Balance = x.TrInvoiceLines.Where(x => new string[] { "RP", "WP", "RS", "WS", "IS", "CI", "CO", "IT" }.Contains(x.TrInvoiceHeader.ProcessCode))
                                                              .Sum(l => l.QtyIn - l.QtyOut),
                                    ProductCost = SqlFunctions.GetProductCost(x.ProductCode, null),
                                    ProductCode = x.ProductCode,
                                    ProductDesc = x.ProductDesc,
                                    PosDiscount = x.PosDiscount,
                                    RetailPrice = x.RetailPrice,
                                    PurchasePrice = x.PurchasePrice,
                                    ProductTypeCode = x.ProductTypeCode,
                                    WholesalePrice = x.WholesalePrice,
                                    UsePos = x.UsePos,
                                    UseInternet = x.UseInternet,
                                    CreatedDate = x.CreatedDate,
                                    CreatedUserName = x.CreatedUserName,
                                    LastUpdatedDate = x.LastUpdatedDate,
                                    LastUpdatedUserName = x.LastUpdatedUserName,
                                    HierarchyCode = x.HierarchyCode,
                                    TrProductFeatures = x.TrProductFeatures,
                                    SiteProduct = x.SiteProduct,
                                    DcHierarchy = x.DcHierarchy,
                                    TrProductDiscounts = x.TrProductDiscounts,
                                    DcSerialNumbers = x.DcSerialNumbers,
                                    DefaultUnitOfMeasureId = x.DefaultUnitOfMeasureId
                                })
                                .OrderBy(x => x.ProductDesc);
            return products;
        }

        public decimal SelectProductBalance(string productCode, string warehouseCode)
        {
            using subContext db = new();

            return db.TrInvoiceLines.Include(x => x.TrInvoiceHeader)
                                    .Where(x => x.ProductCode == productCode)
                                    .Where(x => x.TrInvoiceHeader.WarehouseCode == warehouseCode)
                                    .Where(x => new string[] { "RP", "WP", "RS", "WS", "IS", "CI", "CO", "IT" }.Contains(x.TrInvoiceHeader.ProcessCode))
                                    .Sum(x => x.QtyIn - x.QtyOut);
        }

        public decimal SelectProductBalanceSerialNumber(string productCode, string warehouseCode, string serialNumberCode)
        {
            using subContext db = new();

            return db.TrInvoiceLines.Include(x => x.TrInvoiceHeader)
                                    .Where(x => x.ProductCode == productCode)
                                    .Where(x => new string[] { "RP", "WP", "RS", "WS", "IS", "CI", "CO", "IT" }.Contains(x.TrInvoiceHeader.ProcessCode))
                                    .Where(x => x.SerialNumberCode == serialNumberCode)
                                    .Where(x => x.TrInvoiceHeader.WarehouseCode == warehouseCode)
                                    .Sum(x => x.QtyIn - x.QtyOut);
        }

        public List<DcProduct> SelectProductsByTypeByFilter(byte[] productTypeArr, bool? isDisabled, CriteriaOperator filterCriteria)
        {
            using subContext db = new();

            IQueryable<DcProduct> DcProducts = QueryableSelectProducts(db)
                .Where(x => productTypeArr.Contains(x.ProductTypeCode));

            if (isDisabled.HasValue)
                DcProducts = DcProducts.Where(x => x.IsDisabled == isDisabled.Value);

            IQueryable<DcProduct> filteredData = DcProducts.AppendWhere(new CriteriaToExpressionConverter(), filterCriteria) as IQueryable<DcProduct>;

            return filteredData.ToList();
        }


        public TrInvoiceHeader SelectInvoiceHeader(Guid invoiceHeaderId)
        {
            using subContext db = new();

            return db.TrInvoiceHeaders.Include(x => x.DcCurrAcc)
                                      .Include(x => x.TrInvoiceLines)
                                      .FirstOrDefault(x => x.InvoiceHeaderId == invoiceHeaderId);
        }

        public List<TrHierarchyFeatureType> SelectHierarchyFeatureTypes()
        {
            using subContext db = new();

            return db.TrHierarchyFeatureTypes.Include(x => x.DcHierarchy)
                                             .Include(x => x.DcFeatureType)
                                             .ToList();
        }

        public List<TrHierarchyFeatureType> SelectHierarchyFeatureTypes(string hierarchyCode)
        {
            using subContext db = new();

            List<TrHierarchyFeatureType> result = SelectHierarchyFeatureTypes()
                                                    .Where(x => x.HierarchyCode == hierarchyCode)
                                                    .ToList();

            List<TrHierarchyFeatureType> dcFeatureTypes = db.DcFeatureTypes.Include(x => x.TrHierarchyFeatureTypes)
                                                  .Where(x => !x.TrHierarchyFeatureTypes.Any())
                                                  .Select(x => new TrHierarchyFeatureType() { FeatureTypeId = x.FeatureTypeId, DcFeatureType = x })
                                                  .ToList();

            result.AddRange(dcFeatureTypes);

            return result;
        }

        public List<TrRoleClaim> SelectRoleClaim(string roleCode)
        {
            using subContext db = new();

            List<TrRoleClaim> roleClaims = db.TrRoleClaims.Include(x => x.DcRole)
                                                                  .Where(x => x.RoleCode == roleCode)
                                                                  .ToList();
            return roleClaims;
        }

        public TrRoleClaim SelectRoleClaim(string roleCode, string claimCode)
        {
            using subContext db = new();

            TrRoleClaim roleClaims = db.TrRoleClaims.Include(x => x.DcRole)
                                                                  .Where(x => x.RoleCode == roleCode)
                                                                  .Where(x => x.ClaimCode == claimCode)
                                                                  .FirstOrDefault();
            return roleClaims;
        }

        public TrClaimReport SelectClaimReport(int reportId, string claimCode)
        {
            using subContext db = new();

            TrClaimReport roleClaims = db.TrClaimReports
                                                                  .Where(x => x.ReportId == reportId)
                                                                  .Where(x => x.ClaimCode == claimCode)
                                                                  .FirstOrDefault();
            return roleClaims;
        }

        public List<TrFormReport> SelectFormReports(string formCode)
        {
            using subContext db = new();

            return db.TrFormReports.Include(x => x.DcReport).ThenInclude(x => x.DcReportVariables)
                                   .Where(x => x.FormCode == formCode)
                                   .ToList();
        }

        public List<DcHierarchy> SelectHierarchies()
        {
            using subContext db = new();

            return db.DcHierarchies
                .Include(x => x.TrHierarchyFeatureTypes)
                    .ThenInclude(x => x.DcFeatureType)
                .OrderBy(x => x.Order).ToList();
        }

        public List<DcClaimCategoryViewModel> SelectDcClaimCategories(string roleCode)
        {
            using var db = new subContext();

            var categories =
                db.DcClaimCategories
                  .AsNoTracking()
                  .Select(cat => new DcClaimCategoryViewModel
                  {
                      CategoryId = cat.CategoryId,
                      CategoryParentId = cat.CategoryParentId,
                      CategoryDesc = cat.CategoryDesc,
                      ClaimDesc = null,

                      IsSelected = !cat.DcClaims.Any()
                          ? false
                          : cat.DcClaims.All(cl => cl.TrRoleClaims.Any(rc => rc.RoleCode == roleCode))
                              ? true
                              : cat.DcClaims.All(cl => cl.TrRoleClaims.All(rc => rc.RoleCode != roleCode))
                                  ? false
                                  : null,

                      IsCategory = true
                  });


            var claims =
                db.DcClaims
                  .AsNoTracking()
                  .Select(cl => new DcClaimCategoryViewModel
                  {
                      CategoryId = cl.Id + 1000,
                      CategoryParentId = cl.CategoryId,
                      CategoryDesc = cl.ClaimCode,
                      ClaimDesc = cl.ClaimDesc,
                      IsSelected = cl.TrRoleClaims.Any(rc => rc.RoleCode == roleCode),
                      IsCategory = false
                  });

            var data = categories
                .Concat(claims)           // Union-all
                .ToList();

            return data;


        }

        public List<TrCurrAccRole> SelectCurrAccRole(string currAccCode)
        {
            using subContext db = new();

            List<TrCurrAccRole> currAccRoles = db.TrCurrAccRoles.Include(x => x.DcRole)
                                                                  .Include(x => x.DcCurrAcc)
                                                                  .Where(x => x.CurrAccCode == currAccCode)
                                                                  .ToList();
            return currAccRoles;
        }

        public List<DcClaimReportViewModel> SelectClaimReport(string claimCode)
        {

            using var db = new subContext();

            return
            db.DcReports
              .Include(x => x.TrClaimReports)
              .AsNoTracking()
              .Select(x => new DcClaimReportViewModel
              {
                  ReportId = x.ReportId,
                  ReportName = x.ReportName,
                  IsSelected = x.TrClaimReports.Any(x => x.ClaimCode == claimCode),
                  ClaimCode = claimCode
              }).ToList();
        }

        public TrInvoiceHeader SelectInvoiceHeaderByDocNum(string documentNumber)
        {
            using subContext db = new();

            return db.TrInvoiceHeaders.Include(x => x.DcCurrAcc)
                                      .Include(x => x.TrInvoiceLines)
                                      .Where(x => x.DocumentNumber == documentNumber)
                                      .Where(x => x.IsMainTF == true)
                                      .FirstOrDefault();// (x => x.IsMainTF == true)
        }

        public TrPaymentHeader SelectPaymentHeader(Guid paymentHeaderId)
        {
            using subContext db = new();

            return db.TrPaymentHeaders.Include(x => x.DcCurrAcc)
                                      .Include(x => x.TrPaymentLines)
                                      .Where(x => x.PaymentHeaderId == paymentHeaderId)
                                      .FirstOrDefault();
        }

        public TrPaymentHeader SelectPaymentHeaderByDocNum(string documentNumber)
        {
            using subContext db = new();

            return db.TrPaymentHeaders.Include(x => x.DcCurrAcc)
                                      .Include(x => x.TrPaymentLines)
                                      .Where(x => x.DocumentNumber == documentNumber)
                                      .FirstOrDefault(x => x.IsMainTF == true);
        }

        public TrInvoiceLine SelectInvoiceLine(Guid invoiceLineId)
        {
            using subContext db = new();

            return db.TrInvoiceLines.Include(x => x.TrInvoiceHeader)
                                    .Include(x => x.DcProduct)
                                    .FirstOrDefault(x => x.InvoiceLineId == invoiceLineId);
        }

        public object SelectPayrolList()
        {
            using subContext db = new();

            return db.TrPayrollHeaders.AsNoTracking()
                .Include(x => x.DcCurrAcc)
                .Include(x => x.PayrollPeriod)
                .OrderByDescending(x => x.PayrollPeriod.PeriodYear)
                .ThenByDescending(x => x.PayrollPeriod.PeriodMonth)
                .Select(x => new
                {
                    x.Id,
                    Period = x.PayrollPeriod.PeriodYear.ToString() + "-" + x.PayrollPeriod.PeriodMonth.ToString("00"),
                    Employee = x.DcCurrAcc.CurrAccCode + " - " + x.DcCurrAcc.CurrAccDesc + " - " + x.DcCurrAcc.FirstName + " " + x.DcCurrAcc.LastName,
                    x.GrossSalary,
                    x.NetSalary
                })
                .ToList();
        }

        public TrPayrollHeader SelectEntityByIdWithLine(Guid? id)
        {
            using subContext db = new();
            return db.TrPayrollHeaders
                .Include(x => x.Lines)
                .FirstOrDefault(x => x.Id == id.Value);
        }

        public bool ReturnExistByInvoiceLine(Guid relatedLineId)
        {
            using subContext db = new();

            return db.TrInvoiceLines.Include(x => x.TrInvoiceHeader)
                                    .Where(x => x.TrInvoiceHeader.IsReturn)
                                    .Any(x => x.RelatedLineId == relatedLineId);
        }

        public List<TrInvoiceLine> SelectReturnLinesByInvoiceLine(Guid relatedLineId)
        {
            using subContext db = new();

            return db.TrInvoiceLines.Include(x => x.TrInvoiceHeader)
                                    .Where(x => x.TrInvoiceHeader.IsReturn)
                                    .Where(x => x.RelatedLineId == relatedLineId)
                                    .ToList();
        }

        public List<TrInvoiceLine> SelectWaybillByInvoiceLine(Guid relatedLineId)
        {
            using subContext db = new();

            return db.TrInvoiceLines.Include(x => x.TrInvoiceHeader)
                                    .Where(x => x.TrInvoiceHeader.ProcessCode == "WO")
                                    .Where(x => x.RelatedLineId == relatedLineId)
                                    .ToList();
        }

        public List<TrInvoiceLine> SelectInvoiceLineByReturnLine(Guid? invoiceLineId, string processCode)
        {
            using subContext db = new();

            return db.TrInvoiceLines.Include(x => x.TrInvoiceHeader)
                                    .Where(x => x.TrInvoiceHeader.ProcessCode == processCode)
                                    .Where(x => x.InvoiceLineId == invoiceLineId)
                                    .ToList();
        }

        public List<TrInvoiceHeader> SelectInvoiceLineByReturnHeader(Guid? invoiceHeaderId, string processCode)
        {
            using subContext db = new();

            return db.TrInvoiceHeaders
                                    .Where(x => x.ProcessCode == processCode)
                                    .Where(x => x.InvoiceHeaderId == invoiceHeaderId)
                                    .ToList();
        }

        public List<TrInvoiceLine> SelectInvoiceLinesByLineId(Guid? invoiceLineId)
        {
            using subContext db = new();

            return db.TrInvoiceLines.Include(x => x.TrInvoiceHeader)
                                    .Where(x => x.InvoiceLineId == invoiceLineId)
                                    .ToList();
        }

        public List<TrInvoiceHeader> SelectInvoiceLinesByHeaderId(Guid? invoiceHeaderId)
        {
            using subContext db = new();

            return db.TrInvoiceHeaders
                                    .Where(x => x.InvoiceHeaderId == invoiceHeaderId)
                                    .ToList();
        }

        public bool ReturnExistByInvoiceLine(Guid invoiceHeaderId, Guid relatedLineId)
        {
            using subContext db = new();

            return db.TrInvoiceLines.Include(x => x.TrInvoiceHeader)
                                    .Where(x => x.InvoiceHeaderId == invoiceHeaderId)
                                    .Where(x => x.TrInvoiceHeader.IsReturn)
                                    .Any(x => x.RelatedLineId == relatedLineId);
        }

        public List<TrInvoiceLine> SelectInvoiceLineForReport(Guid invoiceHeaderId)
        {
            using subContext db = new();

            return db.TrInvoiceLines.Include(x => x.TrInvoiceHeader)
                                        .ThenInclude(x => x.DcCurrAcc)
                                    .Include(x => x.DcProduct)
                                    .Where(x => x.InvoiceHeaderId == invoiceHeaderId)
                                    .OrderBy(x => x.CreatedDate)
                                    .ToList();
        }

        public bool ExpensesExistByInvoiceId(Guid invoiceHeaderId)
        {
            using subContext db = new();
            return db.TrInvoiceHeaders.Where(x => x.ProcessCode == "EI")
                                      .Any(x => x.RelatedInvoiceId == invoiceHeaderId);
        }

        public bool InstallmentsExistByInvoiceId(Guid invoiceHeaderId)
        {
            using subContext db = new();
            return db.TrInstallments.Any(x => x.InvoiceHeaderId == invoiceHeaderId);
        }

        public void DeleteExpensesByInvoiceId(Guid invoiceHeaderId)
        {
            using subContext db = new();

            var expences = db.TrInvoiceHeaders.Where(x => x.ProcessCode == "EI")
                                              .Where(x => x.RelatedInvoiceId == invoiceHeaderId);

            expences.ForEach(x =>
            {
                DeletePaymentsByInvoiceId(x.InvoiceHeaderId);
            });

            db.TrInvoiceHeaders.RemoveRange(expences);
            db.SaveChanges();

        }

        public int DeleteInvoice(Guid invoiceHeaderId)
        {
            using subContext db = new();

            string editable = invoiceHeaderId.ToString();
            Guid transferHead = Guid.Parse(editable.Replace(editable.Substring(0, 8), "00000000")); // 00000000-ED42-11CE-BACD-00AA0057B223

            TrInvoiceHeader trInvoiceHeader = new() { InvoiceHeaderId = invoiceHeaderId };
            db.TrInvoiceHeaders.Remove(trInvoiceHeader);

            TrInvoiceHeader transferHeader = db.TrInvoiceHeaders.FirstOrDefault(x => x.InvoiceHeaderId == transferHead);
            if (transferHeader is not null)
                db.TrInvoiceHeaders.Remove(transferHeader);

            IQueryable<TrInvoiceLine> trInvoiceLine = db.TrInvoiceLines.Where(x => x.InvoiceHeaderId == invoiceHeaderId);
            if (trInvoiceLine.Any())
                db.TrInvoiceLines.Remove(trInvoiceLine.First());

            return db.SaveChanges();
        }

        public int DeleteMoneyTransfer(Guid paymentHeaderId)
        {
            using subContext db = new();

            string editable = paymentHeaderId.ToString();
            Guid transferHead = Guid.Parse(editable.Replace(editable.Substring(0, 8), "00000000")); // 00000000-ED42-11CE-BACD-00AA0057B223

            TrPaymentHeader trPaymentHeader = new() { PaymentHeaderId = paymentHeaderId };
            db.TrPaymentHeaders.Remove(trPaymentHeader);

            TrPaymentHeader transferHeader = db.TrPaymentHeaders.FirstOrDefault(x => x.PaymentHeaderId == transferHead);
            if (transferHeader is not null)
                db.TrPaymentHeaders.Remove(transferHeader);

            return db.SaveChanges();
        }

        public int DeleteProduct(DcProduct dcProduct)
        {
            using subContext db = new();

            EntityEntry<DcProduct> product = null;

            if (dcProduct is not null)
            {
                var siteProducts = db.SiteProducts.Where(x => x.ProductCode == dcProduct.ProductCode);
                db.SiteProducts.RemoveRange(siteProducts);
                product = db.DcProducts.Remove(dcProduct);
            }

            return db.SaveChanges();
        }

        public int DeleteBarcodesByProduct(string product)
        {
            using subContext db = new();

            db.TrProductBarcodes.RemoveRange(db.TrProductBarcodes.Where(x => x.ProductCode == product));
            return db.SaveChanges();
        }

        public bool PaymentExistByInvoice(Guid invoiceHeaderId)
        {
            using subContext db = new();
            return db.TrPaymentHeaders.Any(x => x.InvoiceHeaderId == invoiceHeaderId);
        }

        public TrPaymentHeader SelectPaymentHeaderByInvoice(Guid invoiceHeaderId)
        {
            using subContext db = new();
            return db.TrPaymentHeaders.FirstOrDefault(x => x.InvoiceHeaderId == invoiceHeaderId);
        }

        public int DeletePaymentsByInvoiceId(Guid invoiceHeaderId)
        {
            using subContext db = new();
            List<TrPaymentHeader> trPaymentHeaders = db.TrPaymentHeaders.Where(x => x.InvoiceHeaderId == invoiceHeaderId)
                                                               .ToList();
            if (trPaymentHeaders is not null)
                db.TrPaymentHeaders.RemoveRange(trPaymentHeaders);

            return db.SaveChanges();
        }

        public int DeleteInstallmentsByInvoiceId(Guid invoiceHeaderId)
        {
            using subContext db = new();
            List<TrInstallment> trInstallments = db.TrInstallments.Where(x => x.InvoiceHeaderId == invoiceHeaderId)
                                                               .ToList();
            if (trInstallments is not null)
                db.TrInstallments.RemoveRange(trInstallments);

            return db.SaveChanges();
        }

        public int DeletePaymentLinesByPaymentHeader(Guid paymentHeader)
        {
            using subContext db = new();
            List<TrPaymentLine> paymentLines = db.TrPaymentLines.Where(x => x.PaymentHeaderId == paymentHeader)
                                                               .ToList();
            if (paymentLines is not null)
                db.TrPaymentLines.RemoveRange(paymentLines);

            return db.SaveChanges();
        }

        public int DeleteLoyaltyByPaymentHeader(Guid paymentHeader)
        {
            using subContext db = new();
            List<TrLoyaltyTxn> trLoyaltyTxns = db.TrLoyaltyTxns.Where(x => x.PaymentLineId == paymentHeader)
                                                               .ToList();
            if (trLoyaltyTxns is not null)
                db.TrLoyaltyTxns.RemoveRange(trLoyaltyTxns);

            return db.SaveChanges();
        }

        public int UpdateInvoiceIsCompleted(Guid invoiceHeaderId)
        {
            using subContext db = new();

            if (EntityExists<TrInvoiceHeader>(invoiceHeaderId))
            {
                TrInvoiceHeader trInvoiceHeader = new() { InvoiceHeaderId = invoiceHeaderId, IsCompleted = true };
                db.Entry(trInvoiceHeader).Property(x => x.IsCompleted).IsModified = true;
                return db.SaveChanges();
            }
            else return 0;
        }

        public int UpdateInvoiceIsSuspended(Guid invoiceHeaderId, bool isSuspended)
        {
            using subContext db = new();
            TrInvoiceHeader trInvoiceHeader = new() { InvoiceHeaderId = invoiceHeaderId, IsSuspended = isSuspended };
            db.Entry(trInvoiceHeader).Property(x => x.IsSuspended).IsModified = true;
            return db.SaveChanges();
        }

        public int UpdateInvoiceIsLocked(Guid invoiceHeaderId, bool isLocked)
        {
            using subContext db = new();
            TrInvoiceHeader trInvoiceHeader = new() { InvoiceHeaderId = invoiceHeaderId, IsLocked = isLocked };
            db.Entry(trInvoiceHeader).Property(x => x.IsLocked).IsModified = true;
            return db.SaveChanges();
        }

        public string CashRegFromExpense(Guid invoiceHeaderId, int terminalId)
        {
            using subContext db = new();
            return db.TrPaymentHeaders  //xerce bagli her hansi odenisin kassasi
                .Where(ph => ph.InvoiceHeaderId == invoiceHeaderId)
                .SelectMany(ph => ph.TrPaymentLines)
                .Select(pl => pl.CashRegisterCode)
                .FirstOrDefault() ?? SelectCashRegisterByTerminal(terminalId);
        }

        public int UpdatePaymentIsLocked(Guid paymentHeaderId, bool isLocked)
        {
            using subContext db = new();
            TrPaymentHeader trPaymentHeader = new() { PaymentHeaderId = paymentHeaderId, IsLocked = isLocked };
            db.Entry(trPaymentHeader).Property(x => x.IsLocked).IsModified = true;
            return db.SaveChanges();
        }

        public int UpdatePaymentIsSent(Guid paymentHeaderId)
        {
            using subContext db = new();
            TrPaymentHeader trPaymentHeader = new() { PaymentHeaderId = paymentHeaderId, IsSent = true };
            db.Entry(trPaymentHeader).Property(x => x.IsSent).IsModified = true;
            return db.SaveChanges();
        }

        public int UpdateInvoicePrintCount(Guid invoiceHeaderId)
        {
            using subContext db = new();
            TrInvoiceHeader trInvoiceHeader = db.TrInvoiceHeaders.FirstOrDefault(x => x.InvoiceHeaderId == invoiceHeaderId);
            if (trInvoiceHeader is not null)
            {
                trInvoiceHeader.PrintCount = Convert.ToByte(trInvoiceHeader.PrintCount + 1);
                db.Entry(trInvoiceHeader).Property(x => x.PrintCount).IsModified = true;
                db.SaveChanges();
                return trInvoiceHeader.PrintCount;
            }
            else
                return 0;
        }

        public bool WaybillExistByInvoiceLine(Guid relatedLineId)
        {
            using subContext db = new();

            return db.TrInvoiceLines.Include(x => x.TrInvoiceHeader)
                                    .Where(x => new string[] { "WI", "WO" }.Contains(x.TrInvoiceHeader.ProcessCode))
                                    .Any(x => x.RelatedLineId == relatedLineId);
        }

        public bool InvoicelineExistByRelatedLineId(Guid invoiceHeaderId, Guid relatedLineId)
        {
            using subContext db = new();
            return db.TrInvoiceLines.Where(x => x.InvoiceHeaderId == invoiceHeaderId)
                                    .Where(x => new string[] { "WI", "WO" }.Contains(x.TrInvoiceHeader.ProcessCode))
                                    .Any(x => x.RelatedLineId == relatedLineId);
        }


        public TrInvoiceLine SelectTrInvoiceLineByRelatedLineId(Guid invoiceHeaderId, Guid relatedLineId)
        {
            using subContext db = new();
            TrInvoiceLine trInvoiceLine = db.TrInvoiceLines.Where(x => x.InvoiceHeaderId == invoiceHeaderId)
                                               .FirstOrDefault(x => x.RelatedLineId == relatedLineId);
            return trInvoiceLine;
        }

        public int UpdateInvoiceLine_PosDiscount(TrInvoiceLine trInvoiceLine)
        {
            using subContext db = new();

            db.Entry(trInvoiceLine).Property(x => x.PosDiscount).IsModified = true;
            //db.Entry(trInvoiceLine).Property(x => x.NetAmount).IsModified = true;
            return db.SaveChanges();
        }

        public int UpdateInvoiceCurrAccCode(Guid invoiceHeaderId, string currAccCode)
        {
            using subContext db = new();
            TrInvoiceHeader trInvoiceHeader = new() { InvoiceHeaderId = invoiceHeaderId, CurrAccCode = currAccCode };
            db.Entry(trInvoiceHeader).Property(x => x.CurrAccCode).IsModified = true;
            return db.SaveChanges();
        }

        public int UpdatePaymentsCurrAccCode(Guid invoiceHeaderId, string currAccCode)
        {
            using subContext db = new();

            List<TrPaymentHeader> trPaymentHeaders = SelectPaymentHeadersByInvoice(invoiceHeaderId);

            foreach (TrPaymentHeader entity in trPaymentHeaders)
            {
                if (entity.PaymentKindId == 2)
                {
                    entity.CurrAccCode = currAccCode;
                    db.Entry(entity).Property(x => x.CurrAccCode).IsModified = true;
                }
            }

            return db.SaveChanges();
        }

        public decimal SelectPriceByProcess(string processCode, string productCode)
        {
            using subContext db = new();

            string priceTypeCode = db.TrProcessPriceTypes.FirstOrDefault(x => x.ProcessCode == processCode).PriceTypeCode;

            var price = db.TrPriceListLines.Where(x => x.ProductCode == productCode)
                                           .Include(x => x.TrPriceListHeader)
                                           .Where(x => x.TrPriceListHeader.PriceTypeCode == priceTypeCode)
                                           .OrderBy(x => x.TrPriceListHeader.DocumentDate).ThenBy(x => x.TrPriceListHeader.DocumentTime)
                                           .FirstOrDefault().Price;

            return price;
        }

        public int UpdateInvoiceSalesPerson(Guid invoiceLineId, string currAccCode)
        {
            using subContext db = new();

            TrInvoiceLine trInvoiceLine = new() { InvoiceLineId = invoiceLineId, SalesPersonCode = currAccCode };
            db.Entry(trInvoiceLine).Property(x => x.SalesPersonCode).IsModified = true;
            return db.SaveChanges();
        }

        public List<TrPaymentLine> SelectPaymentLines(Guid paymentHeaderId)
        {
            using subContext db = new();
            return db.TrPaymentLines.Include(x => x.TrPaymentHeader)
                           .Include(x => x.DcPaymentType)
                           .Where(x => x.TrPaymentHeader.PaymentHeaderId == paymentHeaderId)
                           .ToList();
        }

        public List<TrBarcodeOperationLine> SelectBarcodeOperationLinesByHeaderId(int id)
        {
            using subContext db = new();
            return db.TrBarcodeOperationLines.Include(x => x.BarcodeOperationHeaderId == id)
                           .ToList();
        }

        public List<TrPaymentLine> SelectPaymentLinesByInvoice(Guid invoiceHeaderId)
        {
            using subContext db = new();
            return db.TrPaymentLines.Include(x => x.TrPaymentHeader)
                           .Include(x => x.DcPaymentType)
                           .Where(x => x.TrPaymentHeader.InvoiceHeaderId == invoiceHeaderId)
                           .ToList();
        }

        public DcCompany SelectCompany(string companyCode)
        {
            using mainContext db = new();
            return db.DcCompanies.FirstOrDefault(x => x.CompanyCode == companyCode);
        }

        public List<TrPaymentHeader> SelectPaymentHeadersByInvoice(Guid invoiceHeaderId)
        {
            using subContext db = new();
            return db.TrPaymentHeaders.Where(x => x.InvoiceHeaderId == invoiceHeaderId)
                                    .ToList();
        }

        public decimal SelectPaymentLinesSumByInvoice(Guid invoiceHeaderId, string currAccCode)
        {
            using subContext db = new();

            return db.TrPaymentLines.Include(x => x.TrPaymentHeader)
                                    .Where(x => x.TrPaymentHeader.InvoiceHeaderId == invoiceHeaderId)
                                    .Where(x => x.TrPaymentHeader.CurrAccCode == currAccCode)
                                    .Sum(s => s.PaymentLoc);
        }

        public decimal SelectPaymentLinesCashSumByInvoice(Guid invoiceHeaderId, string currAccCode)
        {
            using subContext db = new();

            return db.TrPaymentLines.Include(x => x.TrPaymentHeader)
                                    .Where(x => x.TrPaymentHeader.InvoiceHeaderId == invoiceHeaderId)
                                    .Where(x => x.TrPaymentHeader.CurrAccCode == currAccCode)
                                    .Where(x => x.PaymentTypeCode == PaymentType.Cash)
                                    .Sum(s => s.PaymentLoc);
        }

        public decimal SelectPaymentLinesCashlessSumByInvoice(Guid invoiceHeaderId, string currAccCode)
        {
            using subContext db = new();

            return db.TrPaymentLines.Include(x => x.TrPaymentHeader)
                                    .Where(x => x.TrPaymentHeader.InvoiceHeaderId == invoiceHeaderId)
                                    .Where(x => x.TrPaymentHeader.CurrAccCode == currAccCode)
                                    .Where(x => x.PaymentTypeCode == PaymentType.Cashless)
                                    .Sum(s => s.PaymentLoc);
        }

        public decimal SelectPaymentLinesLoyaltySumByInvoice(Guid invoiceHeaderId, string currAccCode)
        {
            using subContext db = new();

            return db.TrPaymentLines.Include(x => x.TrPaymentHeader)
                                    .Where(x => x.TrPaymentHeader.InvoiceHeaderId == invoiceHeaderId)
                                    .Where(x => x.TrPaymentHeader.CurrAccCode == currAccCode)
                                    .Where(x => x.PaymentTypeCode == PaymentType.Bonus)
                                    .Sum(s => s.PaymentLoc);
        }

        public decimal SelectPaymentLinesBonusSumByInvoice(DcLoyaltyCard dcLoyaltyCard)
        {
            using subContext db = new();

            decimal invoiceSum =
                (from il in db.TrInvoiceLines.AsNoTracking()
                 where db.TrLoyaltyTxns.AsNoTracking()
                     .Where(lt => lt.LoyaltyCardId == dcLoyaltyCard.LoyaltyCardId)
                     .Select(lt => lt.InvoiceHeaderId)
                     .Distinct()
                     .Contains(il.InvoiceHeaderId)
                 select (decimal?)il.NetAmountLoc
                ).Sum() ?? 0m;

            decimal paymentSum =
                (from pl in db.TrPaymentLines.AsNoTracking()
                 where db.TrLoyaltyTxns.AsNoTracking()
                     .Where(lt => lt.LoyaltyCardId == dcLoyaltyCard.LoyaltyCardId)
                     .Select(lt => lt.PaymentLineId)
                     .Distinct()
                     .Contains(pl.PaymentHeaderId)
                 select (decimal?)pl.PaymentLoc
                ).Sum() ?? 0m;

            return invoiceSum - paymentSum;
        }

        public DcLoyaltyCard GetLoyaltyCard(Guid InvoiceHeaderId)
        {
            using subContext db = new();

            return db.TrLoyaltyTxns
                .Include(x => x.DcLoyaltyCard).ThenInclude(x => x.DcLoyaltyProgram)
                .FirstOrDefault(x => x.InvoiceHeaderId == InvoiceHeaderId && x.LoyaltyCardId != null)
                ?.DcLoyaltyCard;

        }

        public decimal GetLoyaltyBalanceAsync(Guid? loyaltyCardId)
        {
            using subContext db = new();
            var result = (
                from lc in db.DcLoyaltyCards.AsNoTracking()
                where lc.LoyaltyCardId == loyaltyCardId
                let earnPercent = (decimal?)(lc.DcLoyaltyProgram.EarnPercent) ?? 0m

                // SUM(il.NetAmountLoc)
                let invoiceNetSum =
                    (
                        from lt in db.TrLoyaltyTxns.AsNoTracking()
                        where lt.LoyaltyCardId == lc.LoyaltyCardId && lt.InvoiceHeaderId != null
                        join il in db.TrInvoiceLines.AsNoTracking()
                            on lt.InvoiceHeaderId equals il.InvoiceHeaderId
                        select (decimal?)il.NetAmountLoc
                    ).Sum() ?? 0m

                // SUM(ISNULL(pl.PaymentLoc,0)) with pl.PaymentTypeCode = 3
                let bonusPaymentSum =
                    (
                        from lt in db.TrLoyaltyTxns.AsNoTracking()
                        where lt.LoyaltyCardId == lc.LoyaltyCardId && lt.PaymentLineId != null
                        join pl in db.TrPaymentLines.AsNoTracking().Where(x => x.PaymentTypeCode == PaymentType.Bonus)
                            on lt.PaymentLineId equals pl.PaymentHeaderId
                        select (decimal?)pl.PaymentLoc
                    ).Sum() ?? 0m

                select (invoiceNetSum * earnPercent / 100m) - bonusPaymentSum
            ).SingleOrDefault();

            return result; // kart tapılmazsa 0 qaytarır
        }

        public decimal SelectLoyaltyBonusBalance(Guid? loyaltyCardId, Guid? invoiceHeaderId)
        {
            using var db = new subContext();

            DateTime today = DateTime.Today;

            return db.Set<TrLoyaltyTxn>()
                .Where(x => x.LoyaltyCardId == loyaltyCardId
                            && x.InvoiceHeaderId != invoiceHeaderId
                            && (x.ExpireAt == null || x.ExpireAt >= today))
                .Sum(x => (decimal?)x.Amount) ?? 0m;
        }


        //public decimal SelectInstallmentsSumByInvoice(Guid invoiceHeaderId)
        //{
        //    using subContext db = new();

        //    return db.TrInstallments.Where(x => x.InvoiceHeaderId == invoiceHeaderId)
        //                            .Sum(s => s.AmountLoc);
        //}

        //public decimal SelectInstallmentCommissionsSumByInvoice(Guid invoiceHeaderId)
        //{
        //    using subContext db = new();

        //    return db.TrInstallments.Where(x => x.InvoiceHeaderId == invoiceHeaderId)
        //                            .Sum(s => s.Commission / (decimal)s.ExchangeRate);
        //}

        //public decimal SelectInstallmentsTotalSumByInvoice(Guid invoiceHeaderId)
        //{
        //    using subContext db = new();

        //    return db.TrInstallments.Where(x => x.InvoiceHeaderId == invoiceHeaderId)
        //                            .Sum(s => s.AmountLoc + (s.Commission / (decimal)s.ExchangeRate));
        //}

        //public List<TrInstallmentViewModel> SelectInstallmentsVM()
        //{
        //    using subContext db = new();

        //    DateTime currentDate = DateTime.Now;

        //    var installments = db.TrInstallments
        //        .Include(x => x.TrInvoiceHeader).ThenInclude(x => x.DcCurrAcc)
        //        .Include(x => x.DcInstallmentPlan)
        //        .Select(installment => new
        //        {
        //            Installment = installment,
        //            PaymentLinesSum = db.TrPaymentLines
        //                .Where(x => x.TrPaymentHeader.InvoiceHeaderId == installment.InvoiceHeaderId &&
        //                            x.TrPaymentHeader.CurrAccCode == installment.TrInvoiceHeader.CurrAccCode)
        //                .Sum(s => s.PaymentLoc)
        //        })
        //        .AsEnumerable() // Materialize query to client-side (switch from SQL to LINQ to Objects)
        //        .Select(temp =>
        //        {
        //            var installment = temp.Installment;
        //            var totalPaid = temp.PaymentLinesSum;
        //            var AmountWithComLoc = installment.AmountLoc + installment.Commission;
        //            var monthlyPayment = AmountWithComLoc / installment.DcInstallmentPlan.DurationInMonths;
        //            var monthsPaid = (int)(totalPaid / monthlyPayment);
        //            var overdueDate = installment.DocumentDate.AddMonths(monthsPaid + 1);
        //            var overdueDays = currentDate > overdueDate ? (currentDate - overdueDate).Days : 0;

        //            return new TrInstallmentViewModel
        //            {
        //                InstallmentId = installment.InstallmentId,
        //                InvoiceHeaderId = installment.InvoiceHeaderId,
        //                CurrAccCode = installment.TrInvoiceHeader.CurrAccCode,
        //                DocumentDate = installment.DocumentDate,
        //                PaymentPlanCode = installment.InstallmentPlanCode,
        //                Amount = installment.Amount,
        //                AmountLoc = AmountWithComLoc,
        //                CurrencyCode = installment.CurrencyCode,
        //                ExchangeRate = installment.ExchangeRate,
        //                TotalPaid = totalPaid,
        //                RemainingBalance = AmountWithComLoc - totalPaid,
        //                MonthlyPayment = monthlyPayment,
        //                DueAmount = totalPaid - (currentDate - installment.DocumentDate).Days / 30 * monthlyPayment,
        //                OverdueDate = overdueDate,
        //                OverdueDays = overdueDays
        //            };
        //        })
        //        .ToList();

        //    return installments;
        //}

        public List<DcCurrAcc> SelectCurrAccs(byte[] currAccTypeArr)
        {
            using subContext db = new();

            //byte[] byteArr = new byte[] { 1, 2, 3, 4 };

            List<DcCurrAcc> asdasd = db.DcCurrAccs.Where(x => x.IsDisabled == false
                                              && currAccTypeArr.Contains(x.CurrAccTypeCode)
                                              && x.CurrAccTypeCode != 5) // kassanin balansi ayri hesablanir , ona gore yazilib
                       .OrderBy(x => x.CreatedDate)
                       .Select(x => new DcCurrAcc
                       {
                           CurrAccCode = x.CurrAccCode,
                           CurrAccDesc = x.CurrAccDesc,
                           CreditLimit = x.CreditLimit,
                           CurrAccTypeCode = x.CurrAccTypeCode,
                           IsVip = x.IsVip,
                           PhoneNum = x.PhoneNum,
                           Address = x.Address,
                           StoreCode = x.StoreCode,
                           FirstName = x.FirstName,
                           LastName = x.LastName,
                           CreatedDate = x.CreatedDate,
                           CreatedUserName = x.CreatedUserName,
                           LastUpdatedDate = x.LastUpdatedDate,
                           LastUpdatedUserName = x.LastUpdatedUserName,
                           Balance = db.TrInvoiceLines.Include(l => l.TrInvoiceHeader)
                                                     .Where(l => new string[] { "RP", "WP", "RS", "WS", "IS", "CI", "CO", "IT" }.Contains(l.TrInvoiceHeader.ProcessCode))
                                                     .Where(l => l.TrInvoiceHeader.CurrAccCode == x.CurrAccCode)
                                                     .Sum(s => (s.QtyIn - s.QtyOut) * (s.PriceLoc - (s.PriceLoc * s.PosDiscount / 100)))
                                  + db.TrPaymentLines.Include(l => l.TrPaymentHeader)
                                                     .Where(l => l.TrPaymentHeader.CurrAccCode == x.CurrAccCode)
                                                     .Sum(s => s.PaymentLoc),
                       })
                       .ToList();

            List<DcCurrAcc> asdasd2 = db.DcCurrAccs.Where(x => x.IsDisabled == false
                                                && x.CurrAccTypeCode == 5 // kassanin balansi ayri hesablanir , ona gore yazilib
                                                && currAccTypeArr.Contains(x.CurrAccTypeCode))
                       .OrderBy(x => x.CreatedDate)
                       .Select(x => new DcCurrAcc
                       {
                           CurrAccCode = x.CurrAccCode,
                           CurrAccDesc = x.CurrAccDesc,
                           CreditLimit = x.CreditLimit,
                           CurrAccTypeCode = x.CurrAccTypeCode,
                           IsVip = x.IsVip,
                           PhoneNum = x.PhoneNum,
                           Address = x.Address,
                           StoreCode = x.StoreCode,
                           FirstName = x.FirstName,
                           LastName = x.LastName,
                           CreatedDate = x.CreatedDate,
                           CreatedUserName = x.CreatedUserName,
                           LastUpdatedDate = x.LastUpdatedDate,
                           LastUpdatedUserName = x.LastUpdatedUserName,
                           Balance = db.TrPaymentLines.Include(l => l.TrPaymentHeader)
                                                     .Where(l => l.CashRegisterCode == x.CurrAccCode)
                                                     .Sum(s => s.PaymentLoc),
                       })
                       .ToList();

            asdasd.AddRange(asdasd2);

            return asdasd;
        }

        public DcCurrAcc SelectCurrAcc(string currAccCode)
        {
            using subContext db = new();
            return db.DcCurrAccs.Where(x => x.IsDisabled == false)
                                .FirstOrDefault(x => x.CurrAccCode == currAccCode);
        }

        public DcCurrAcc SelectSalesPerson(string currAccCode)
        {
            using subContext db = new();
            return db.DcCurrAccs.Where(x => x.IsDisabled == false)
                                .Where(x => x.PersonalTypeCode == 1)
                                .FirstOrDefault(x => x.CurrAccCode == currAccCode);
        }

        public DcCurrAcc SelectWorker(string currAccCode)
        {
            using subContext db = new();
            return db.DcCurrAccs.Where(x => x.IsDisabled == false)
                                .Where(x => x.PersonalTypeCode == 3)
                                .FirstOrDefault(x => x.CurrAccCode == currAccCode);
        }

        public decimal SelectCurrAccBalance(string currAccCode, DateTime documentDate)
        {
            using subContext db = new();

            decimal invoiceSum = db.TrInvoiceLines.Include(x => x.TrInvoiceHeader)
                                       .Where(x => x.TrInvoiceHeader.CurrAccCode == currAccCode)
                                       .Where(x => new string[] { "RP", "WP", "RS", "WS", "IS", "CI", "CO", "IT" }.Contains(x.TrInvoiceHeader.ProcessCode))
                                       .AsEnumerable()
                                       .Where(x => x.TrInvoiceHeader.DocumentDate.Add(x.TrInvoiceHeader.DocumentTime) < documentDate)
                                       .Sum(x => (x.QtyIn - x.QtyOut) * (x.PriceLoc - (x.PriceLoc * x.PosDiscount / 100)));

            decimal paymentSum = db.TrPaymentLines.Include(x => x.TrPaymentHeader)
                                       .Where(x => x.TrPaymentHeader.CurrAccCode == currAccCode)
                                       .AsEnumerable()
                                       .Where(x => x.TrPaymentHeader.OperationDate.Add(x.TrPaymentHeader.OperationTime) < documentDate)
                                       .Sum(x => x.PaymentLoc);

            return paymentSum + invoiceSum;
        }

        public decimal SelectCashRegBalance(string cashRegCode, DateTime documentDate)
        {
            using subContext db = new();

            decimal paymentSum = db.TrPaymentLines.Include(x => x.TrPaymentHeader)
                                       .Where(x => x.CashRegisterCode == cashRegCode)
                                       .ToList() // Pull the data into memory for 'TrInvoiceHeader.DocumentDate.Add'
                                       .Where(x => x.TrPaymentHeader.OperationDate.Add(x.TrPaymentHeader.OperationTime) < documentDate)
                                       .Sum(x => x.PaymentLoc);

            return paymentSum;
        }

        public decimal SelectInvoiceSum(Guid invoiceHeaderId)
        {
            using subContext db = new();

            return db.TrInvoiceLines.Include(x => x.TrInvoiceHeader)
                                    .Where(x => x.TrInvoiceHeader.InvoiceHeaderId == invoiceHeaderId)
                                    .Sum(x => x.NetAmountLoc);
        }

        public List<DcOffice> SelectOffices()
        {
            using subContext db = new();

            return db.DcOffices.Where(x => x.IsDisabled == false)
                               .OrderBy(x => x.CreatedDate)
                               .ToList();
        }

        public List<DcUnitOfMeasure> SelectUnitOfMeasures()
        {
            using subContext db = new();

            return db.DcUnitOfMeasures.Where(x => x.IsDisabled == false)
                               .ToList();
        }

        public DcCurrency SelectCurrencyByName(string currencyDesc)
        {
            using subContext db = new();
            return db.DcCurrencies.FirstOrDefault(x => x.CurrencyDesc == currencyDesc);
        }

        public List<TrInstallmentGuarantor> SelectInstaallmentGarantorByInstallment(int installmentId)
        {
            using subContext db = new();
            return db.TrInstallmentGuarantors.Where(x => x.InstallmentId == installmentId)
                .Include(x => x.DcCurrAcc)
                .ToList();
        }

        public DcProductScale SelectProductScaleByProduct(string productCode)
        {
            using subContext db = new();
            return db.DcProductScales.FirstOrDefault(x => x.ProductCode == productCode);
        }

        public DcClaim SelectDcClaimByIdentity(int Id)
        {
            using subContext db = new();
            return db.DcClaims.FirstOrDefault(x => x.Id == Id);
        }

        public List<DcPaymentMethod> SelectPaymentMethodsByPaymentTypes(PaymentType[] paymentTypes)
        {
            using subContext db = new();
            return db.DcPaymentMethods.Where(x => paymentTypes.Contains(x.PaymentTypeCode)).ToList();
        }

        public List<DcPaymentPlan> SelectPaymentPlans(int paymentMethodId)
        {
            using subContext db = new();
            return db.DcPaymentPlans.Where(x => x.PaymentMethodId == paymentMethodId).ToList();
        }

        public DcPaymentPlan SelectPaymentPlanDefault(int paymentMethodId)
        {
            using subContext db = new();
            return db.DcPaymentPlans.Where(x => x.PaymentMethodId == paymentMethodId)
                                    .Where(x => x.IsDefault)
                                    .FirstOrDefault();
        }

        public List<DcDiscount> SelectDiscounts()
        {
            using subContext db = new();
            var discounts = db.DcDiscounts.Include(x => x.TrPaymentMethodDiscounts)
                                 .Include(x => x.TrProductDiscounts).ThenInclude(x => x.DcProduct).ThenInclude(x => x.SiteProduct)
                                 .ToList();

            return discounts;
        }

        public DcDiscount SelectDiscount(int discountId)
        {
            using subContext db = new();
            var discount = db.DcDiscounts.Include(x => x.TrPaymentMethodDiscounts)
                                 .Include(x => x.TrProductDiscounts).ThenInclude(x => x.DcProduct).ThenInclude(x => x.SiteProduct)
                                 .FirstOrDefault(x => x.DiscountId == discountId);

            return discount;
        }

        public List<DcCurrAcc> SelectStores()
        {
            using subContext db = new();
            return db.DcCurrAccs.Where(x => x.IsDisabled == false)
                       .Where(x => x.CurrAccTypeCode == 4)
                       .OrderBy(x => x.CreatedDate)
                       .ToList();
        }

        public DcCurrAcc SelectStore(string storeCode)
        {
            using subContext db = new();
            return db.DcCurrAccs.Where(x => x.IsDisabled == false)
                       .Where(x => x.CurrAccTypeCode == 4)
                       .Where(x => x.CurrAccCode == storeCode)
                       .FirstOrDefault();
        }

        public List<DcCurrAcc> SelectStoresIncludeDisabled()
        {
            using subContext db = new();
            return db.DcCurrAccs.Where(x => x.CurrAccTypeCode == 4)
                                .OrderBy(x => x.CreatedDate)
                                .ToList();
        }

        public List<DcWarehouse> SelectWarehouses()
        {
            using subContext db = new();
            return db.DcWarehouses.Where(x => x.IsDisabled == false)
                         .OrderBy(x => x.CreatedDate)
                         .ToList();
        }

        public List<DcWarehouse> SelectWarehousesByStore(string storeCode)
        {
            using subContext db = new();
            return db.DcWarehouses.Where(x => x.IsDisabled == false)
                                  .Where(x => x.StoreCode == storeCode)
                                  .OrderBy(x => x.CreatedDate)
                                  .ToList();
        }

        public List<DcWarehouse> SelectWarehousesByStoreIncludeDisabled(string storeCode)
        {
            using subContext db = new();
            return db.DcWarehouses//.Where(x => x.IsDisabled == false)
                                  .Where(x => x.StoreCode == storeCode)
                                  .OrderBy(x => x.CreatedDate)
                                  .ToList();
        }

        public string SelectWarehouseByStore(string storeCode)
        {
            using subContext db = new();
            string wareCode = "";

            DcWarehouse dcWarehouse = db.DcWarehouses.Where(x => x.IsDisabled == false && x.IsDefault == true)
                                  .FirstOrDefault(x => x.StoreCode == storeCode);

            if (dcWarehouse is not null)
                wareCode = dcWarehouse.WarehouseCode;

            return wareCode;
        }

        public DcCurrAcc? SelectCashRegById(string currAccCode)
        {
            using subContext db = new();

            return db.DcCurrAccs.Where(x => x.IsDisabled == false && x.CurrAccTypeCode == 5)
                                  .FirstOrDefault(x => x.CurrAccCode == currAccCode);
        }

        public string? SelectCashRegByStore(string storeCode)
        {
            using subContext db = new();

            DcCurrAcc dcCurrAcc = db.DcCurrAccs.Where(x => x.IsDisabled == false && x.IsDefault == true && x.CurrAccTypeCode == 5)
                                  .FirstOrDefault(x => x.StoreCode == storeCode);

            if (dcCurrAcc is not null)
                return dcCurrAcc.CurrAccCode;
            return null;
        }

        public string SelectDefaultCashRegister(string storeCode)
        {
            using subContext db = new();
            string cashRegCode = "";

            DcCurrAcc dcCurrAcc = db.DcCurrAccs.Where(x => x.IsDisabled == false && x.IsDefault == true && x.CurrAccTypeCode == 5)
                                  .FirstOrDefault(x => x.StoreCode == storeCode);

            if (dcCurrAcc is not null)
                cashRegCode = dcCurrAcc.CurrAccCode;

            return cashRegCode;
        }

        public string? SelectCashRegisterByTerminal(int terminaId)
        {
            using subContext db = new();

            DcCurrAcc dcCashReg = db.DcTerminals.Where(x => x.TerminalId == terminaId)
                                  .Select(x => x.DcCashRegister)
                                  .FirstOrDefault();

            if (dcCashReg is not null)
                return dcCashReg.CurrAccCode;
            else return null;
        }

        public string SelectDefaultCustomerByStore(string storeCode)
        {
            using subContext db = new();

            string defCustomer = "";
            DcCurrAcc dcCurrAcc = db.DcCurrAccs.Where(x => x.IsDefault == true && x.CurrAccTypeCode == 1)
                                               .FirstOrDefault(x => x.IsDisabled == false && x.StoreCode == storeCode);

            if (dcCurrAcc is not null)
                defCustomer = dcCurrAcc.CurrAccCode;

            return defCustomer;
        }

        public DcCurrAcc Login(string CurrAccCode, string Password)
        {
            if (string.IsNullOrEmpty(Password.Trim()))
                return null;
            else
            {
                using subContext db = new();
                return db.DcCurrAccs.Where(x => x.IsDisabled == false)
                        .Where(x => x.CurrAccCode == CurrAccCode)
                        .Where(x => x.NewPassword == Password)
                        .FirstOrDefault();
            }
        }

        public bool CurrAccExist(string CurrAccCode)
        {
            using subContext db = new();
            return db.DcCurrAccs.Where(x => x.IsDisabled == false)
                                .Any(x => x.CurrAccCode == CurrAccCode);
        }

        public DcCurrAcc SelectSalesManByIdentityCard(string salesman)
        {
            using subContext db = new();
            return db.DcCurrAccs.Where(x => x.IsDisabled == false)
                                .Where(x => x.PersonalTypeCode == 1)
                                .FirstOrDefault(x => x.BonusCardNum == salesman);
        }

        public bool ProductExist(string productCode)
        {
            using subContext db = new();
            return db.DcProducts.Where(x => x.IsDisabled == false)
                       .Any(x => x.ProductCode == productCode);
        }

        public bool ProductScaleExist(string productCode)
        {
            using subContext db = new();
            return db.DcProductScales.Any(x => x.ProductCode == productCode);
        }

        public bool TrRoleClaimExist(string roleCode, string claimCode)
        {
            using subContext db = new();
            return db.TrRoleClaims.Where(x => x.RoleCode == roleCode)
                       .Any(x => x.ClaimCode == claimCode);
        }

        public bool TrClaimReportExist(int reportId, string claimCode)
        {
            using subContext db = new();
            return db.TrClaimReports.Where(x => x.ReportId == reportId)
                       .Any(x => x.ClaimCode == claimCode);
        }

        public bool BarcodeExistByProduct(string productCode)
        {
            using subContext db = new();
            return db.TrProductBarcodes.Any(x => x.ProductCode == productCode);
        }

        public bool CurrAccExistByPhoneNumExceptCurrAcc(string phoneNum, string currAccCode)
        {
            //phoneNum = Regex.Replace(phoneNum, @"\D", "");

            using subContext db = new();

            phoneNum = new string((phoneNum ?? "")
                .Where(char.IsDigit).ToArray());

            // compare against DB after stripping common symbols (translated to SQL REPLACE)
            return db.DcCurrAccs
                .Where(x => x.CurrAccCode != currAccCode)
                .Any(x =>
                    (x.PhoneNum ?? "")
                        .Replace(" ", "")
                        .Replace("-", "")
                        .Replace("(", "")
                        .Replace(")", "")
                        .Replace("+", "") == phoneNum);
        }

        public bool ProductExistByNameExceptProduct(string productName, string productCode)
        {
            using subContext db = new();
            return db.DcProducts
                .Where(x => x.ProductCode != productCode)
                .Any(x => x.ProductDesc == productName);
        }

        public bool CurrAccContactDetailsExistByCurrAcc(string currAccCode)
        {
            using subContext db = new();
            return db.DcCurrAccContactDetails.Any(x => x.CurrAccCode == currAccCode);
        }

        public void InsertProduct(DcProduct dcProduct)
        {
            using subContext db = new();
            EntityEntry<DcProduct> result = db.DcProducts.Add(dcProduct);

            if (result is not null)
                db.SiteProducts.Add(new SiteProduct() { ProductCode = dcProduct.ProductCode });

            db.SaveChanges();
        }

        public List<DcRole> SelectRolesByCurrAcc(string CurrAccCode)
        {
            using subContext db = new();
            return db.DcRoles.Include(x => x.TrCurrAccRoles)
                       .ThenInclude(x => x.DcCurrAcc)
                    .Where(o => o.TrCurrAccRoles.Any(x => x.CurrAccCode == CurrAccCode))
                    .ToList();
        }

        public bool CurrAccHasClaims(string currAccCode, string claim)
        {
            using subContext db = new();

            bool hasClaim;

            hasClaim = db.TrCurrAccRoles.Include(x => x.DcRole)
                                       .ThenInclude(x => x.TrRoleClaims)
                                    .Where(x => x.CurrAccCode == currAccCode)
                                    .Any(x => x.DcRole.TrRoleClaims.Any(x => x.ClaimCode == claim));

            if (!hasClaim)
                hasClaim = db.TrCurrAccRoles.Include(x => x.DcRole)
                           .ThenInclude(x => x.TrRoleClaims)
                           .ThenInclude(x => x.DcClaim)
                           .ThenInclude(x => x.TrClaimReports)
                           .ThenInclude(x => x.DcReport)
                        .Where(x => x.CurrAccCode == currAccCode)
                        .Any(x => x.DcRole.TrRoleClaims.Any(x => x.DcClaim.TrClaimReports.Any(x => x.DcReport.ReportId.ToString() == claim)));

            return hasClaim;
        }

        public int UpdateReportLayout(int id, string reportLayout)
        {
            using subContext db = new();
            DcReport dcReport = new() { ReportId = id, ReportLayout = reportLayout };
            db.Entry(dcReport).Property(x => x.ReportLayout).IsModified = true;
            return db.SaveChanges();
        }

        public int UpdateCurrAccTheme(string CurrAccCode, string themeLayout)
        {
            using subContext db = new();
            DcCurrAcc dcCurrAcc = new() { CurrAccCode = CurrAccCode, Theme = themeLayout };
            db.Entry(dcCurrAcc).Property(x => x.Theme).IsModified = true;
            return db.SaveChanges();
        }

        public int UpdateCurrAccPassword(string CurrAccCode, string newPassword)
        {
            using subContext db = new();
            DcCurrAcc dcCurrAcc = new() { CurrAccCode = CurrAccCode, NewPassword = newPassword };
            db.Entry(dcCurrAcc).Property(x => x.NewPassword).IsModified = true;
            return db.SaveChanges();
        }

        public DcReport SelectReport(int id)
        {
            using subContext db = new();
            return db.DcReports.Include(x => x.TrReportSubQueries).ThenInclude(x => x.TrReportSubQueryRelationColumns)
                               .Include(x => x.DcReportVariables)
                               .FirstOrDefault(x => x.ReportId == id);
        }

        public List<TrReportCustomization> SelectReportCustomizationByCurrAcc(int reportId, string currAccCode)
        {
            using subContext db = new();
            return db.TrReportCustomizations.Where(x => x.ReportId == reportId && x.CurrAccCode == currAccCode)
                               .ToList();
        }

        public DcReport SelectReportByName(string name)
        {
            using subContext db = new();
            return db.DcReports.Include(x => x.DcReportVariables)
                                .Include(x => x.TrReportSubQueries)
                                .ThenInclude(x => x.TrReportSubQueryRelationColumns)
                                .FirstOrDefault(x => x.ReportName == name);
        }

        public List<DcReport> SelectReportsByType(byte[] reportType)
        {
            using subContext db = new();
            return db.DcReports.Where(x => reportType.Contains(x.ReportTypeId)).ToList();
        }

        public int UpdateDcReport_Filter(int id, string reportFilter)
        {
            using subContext db = new();
            DcReport dcReport = new() { ReportId = id, ReportFilter = reportFilter };
            db.Entry(dcReport).Property(x => x.ReportFilter).IsModified = true;
            return db.SaveChanges();
        }

        public int UpdateDcProductStaticPrice_Value(string priceTypeCode, string productCode, decimal? value)
        {
            using subContext db = new();
            DcProductStaticPrice pp = db.DcProductStaticPrices.FirstOrDefault(x => x.PriceTypeCode == priceTypeCode && x.ProductCode == productCode);

            if (pp is not null)
            {
                if (pp.Price != value)
                {
                    //3u de composite key olduguna gore update alinmadi
                    db.DcProductStaticPrices.Remove(pp);
                    db.SaveChanges();
                }
            }

            if (pp?.Price != value && value is not null)
            {
                pp = new DcProductStaticPrice()
                {
                    PriceTypeCode = priceTypeCode,
                    ProductCode = productCode,
                    Price = (decimal)value
                };
                db.DcProductStaticPrices.Add(pp);
            }

            return db.SaveChanges();
        }

        public int UpdateDcFeature_Value(byte featureTypeId, string productCode, string value)
        {
            using subContext db = new();
            TrProductFeature pf = db.TrProductFeatures.FirstOrDefault(x => x.FeatureTypeId == featureTypeId && x.ProductCode == productCode);

            if (pf is not null) // update
            {
                if (pf.FeatureCode != value)
                {
                    //3u de composite key olduguna gore update alinmadi
                    db.TrProductFeatures.Remove(pf);
                    db.SaveChanges();
                }
            }

            if (!string.IsNullOrEmpty(value) && pf?.FeatureCode != value)
            {
                pf = new TrProductFeature()
                {
                    FeatureTypeId = featureTypeId,
                    ProductCode = productCode,
                    FeatureCode = value
                };
                db.TrProductFeatures.Add(pf);
            }

            return db.SaveChanges();
        }

        public int UpdateDcFeatureCurrAcc_Value(byte featureTypeId, string currAccCode, string value)
        {
            using subContext db = new();
            TrCurrAccFeature pf = db.TrCurrAccFeatures.FirstOrDefault(x => x.CurrAccFeatureTypeId == featureTypeId && x.CurrAccCode == currAccCode);

            if (pf is not null) // update
            {
                if (pf.CurrAccFeatureCode != value)
                {
                    //3u de composite key olduguna gore update alinmadi
                    db.TrCurrAccFeatures.Remove(pf);
                    db.SaveChanges();
                }
            }

            if (!string.IsNullOrEmpty(value) && pf?.CurrAccFeatureCode != value)
            {
                pf = new TrCurrAccFeature()
                {
                    CurrAccFeatureTypeId = featureTypeId,
                    CurrAccCode = currAccCode,
                    CurrAccFeatureCode = value
                };
                db.TrCurrAccFeatures.Add(pf);
            }

            return db.SaveChanges();
        }

        public int UpdateReportVariableValue(int id, string prop, string value)
        {
            using subContext db = new();
            DcReportVariable dcReportVariable = db.DcReportVariables.FirstOrDefault(x => x.VariableProperty == prop && x.ReportId == id);
            dcReportVariable.VariableValue = value;

            db.Entry(dcReportVariable).Property(x => x.VariableValue).IsModified = true;

            return db.SaveChanges();
        }

        public int UpdateAppSettingGridViewLayout(string layout)
        {
            using subContext db = new();
            AppSetting appSetting = new() { Id = 1, GridViewLayout = layout };
            db.Entry(appSetting).Property(x => x.GridViewLayout).IsModified = true;
            return db.SaveChanges();
        }

        public int UpdateAppSettingPOSFindProductBy(string value)
        {
            using subContext db = new();
            AppSetting appSetting = new() { Id = 1, POSFindProductBy = value };
            db.Entry(appSetting).Property(x => x.POSFindProductBy).IsModified = true;
            return db.SaveChanges();
        }

        public int UpdateTerminalTouchUIMode(int terminalId, bool touchUIMode)
        {
            using subContext db = new();
            DcTerminal dcTerminal = new() { TerminalId = terminalId, TouchUIMode = touchUIMode, TouchScaleFactor = 2 };
            db.Entry(dcTerminal).Property(x => x.TouchUIMode).IsModified = true;
            db.Entry(dcTerminal).Property(x => x.TouchScaleFactor).IsModified = true;
            return db.SaveChanges();
        }

        public int UpdateProductHierarchyCode(string productCode, string? hierarchyCode)
        {
            using subContext db = new();
            DcProduct dcProduct = new() { ProductCode = productCode, HierarchyCode = hierarchyCode };
            db.Entry(dcProduct).Property(x => x.HierarchyCode).IsModified = true;
            return db.SaveChanges();
        }

        public int UpdateHierarchyDesc(string hierarchyCode, string hierarchyDesc)
        {
            using subContext db = new();
            DcHierarchy hierarcy = new DcHierarchy() { HierarchyCode = hierarchyCode, HierarchyDesc = hierarchyDesc };
            db.Entry(hierarcy).Property(x => x.HierarchyDesc).IsModified = true;
            return db.SaveChanges();
        }

        public int UpdateStoreSettingPrinterName(string printerName)
        {
            using subContext db = new();
            SettingStore settingStore = new() { Id = 1, PrinterName = printerName };
            db.Entry(settingStore).Property(x => x.PrinterName).IsModified = true;
            return db.SaveChanges();
        }

        public int UpdateStoreSettingSalesmanContinuity(string storeCode, bool salesmanContinuity)
        {
            using subContext db = new();
            SettingStore settingStore = db.SettingStores.FirstOrDefault(x => x.StoreCode == storeCode);
            settingStore.SalesmanContinuity = salesmanContinuity;
            db.Entry(settingStore).Property(x => x.SalesmanContinuity).IsModified = true;
            return db.SaveChanges();
        }

        public void UpdateAppSettingLicense(string license, string databaseName)
        {
            subContext db = new();
            string connString = db.Database.GetConnectionString();

            var builder = new SqlConnectionStringBuilder(connString);
            builder.InitialCatalog = databaseName;

            using (db = new subContext(new DbContextOptionsBuilder<subContext>().UseSqlServer(builder.ConnectionString).Options))
            {
                if (db.Database.CanConnect())
                {
                    AppSetting appSetting = new() { Id = 1, License = license };
                    db.Entry(appSetting).Property(x => x.License).IsModified = true;
                    db.SaveChanges();
                }
            }
        }

        public DcBarcodeType SelectBarcodTypeDefault()
        {
            using subContext db = new();

            return db.DcBarcodeTypes.FirstOrDefault(x => x.DefaultBarcodeType == true);

        }

        public SettingStore SelectSettingStore(string StoreCode)
        {
            using subContext db = new();
            return db.SettingStores.FirstOrDefault(x => x.StoreCode == StoreCode);
        }

        public DcLoyaltyCard SelectLoyalityCard(string loaltyCardNumb)
        {
            using subContext db = new();
            return db.DcLoyaltyCards
                                .Include(x => x.DcLoyaltyProgram) // mutleq include etmek lazimdir yoxsa EarnPercent 0 olacaq, loyaltytx silinecek. risklidi.
                                .FirstOrDefault(x => x.CardNumber == loaltyCardNumb);
        }

        public decimal SelectLoyalityTxnAmount(Guid invoiceHeaderId)
        {
            using subContext db = new();
            return db.TrLoyaltyTxns
                                .Where(x => x.TxnType == LoyaltyTxnType.Earn)
                                .Where(x => x.InvoiceHeaderId == invoiceHeaderId)
                                .Sum(x => x.Amount);
        }
    }
}