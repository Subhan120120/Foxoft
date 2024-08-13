using DevExpress.Data.Filtering;
using DevExpress.Data.Linq;
using DevExpress.Data.Linq.Helpers;
using DevExpress.Data.ODataLinq.Helpers;
using DevExpress.Mvvm.Native;
using Foxoft.Models;
using Foxoft.Models.Entity;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Data;
using static DevExpress.Skins.SolidColorHelper;

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
                    x.ReturnQty = db.TrInvoiceLines.Include(y => y.TrInvoiceHeader)
                                                   .Where(y => y.TrInvoiceHeader.IsReturn)
                                                   .Where(y => y.RelatedLineId == x.InvoiceLineId)
                                                   .Sum(s => Math.Abs(s.QtyIn - s.QtyOut));
                    x.RemainingQty = Math.Abs(x.QtyIn - x.QtyOut) - db.TrInvoiceLines.Include(y => y.TrInvoiceHeader)
                                                                                     .Where(y => y.TrInvoiceHeader.IsReturn)
                                                                                     .Where(y => y.RelatedLineId == x.InvoiceLineId)
                                                                                     .Sum(s => Math.Abs(s.QtyIn - s.QtyOut));
                });

                return InvoiceLines;
            }
        }

        public List<TrInvoiceLine> SelectInvoiceLinesForDelivery(Guid invoiceHeaderId)
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
                    x.ReturnQty = db.TrInvoiceLines.Include(y => y.TrInvoiceHeader)
                                                   .Where(y => new string[] { "WI", "WO" }.Contains(y.TrInvoiceHeader.ProcessCode))
                                                   .Where(y => y.RelatedLineId == x.InvoiceLineId)
                                                   .Sum(s => Math.Abs(s.QtyIn - s.QtyOut));
                    x.RemainingQty = Math.Abs(x.QtyIn - x.QtyOut) - db.TrInvoiceLines.Include(y => y.TrInvoiceHeader)
                                                                                     .Where(y => y.RelatedLineId == x.InvoiceLineId)
                                                                                     .Where(y => new string[] { "WI", "WO" }.Contains(y.TrInvoiceHeader.ProcessCode))
                                                                                     .Sum(s => Math.Abs(s.QtyIn - s.QtyOut));
                });

                return InvoiceLines;
            }
        }

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

        public List<DcProductType> SelectProductTypes()
        {
            using subContext db = new();
            return db.DcProductTypes.ToList();
        }

        public List<DcReportType> SelectReportTypes()
        {
            using subContext db = new();
            return db.DcReportTypes.ToList();
        }

        public List<DcCurrAccType> SelectCurrAccTypes()
        {
            using subContext db = new();
            return db.DcCurrAccTypes.ToList();
        }

        public List<DcTerminal> SelectTerminals()
        {
            using subContext db = new();
            return db.DcTerminals.ToList();
        }

        public List<DcCompany> SelectCompanies()
        {
            using mainContext db = new();
            return db.DcCompanies.ToList();
        }

        public DcTerminal SelectTerminal(int id)
        {
            using subContext db = new();
            return db.DcTerminals.FirstOrDefault(x => x.TerminalId == id);
        }

        public DcCompany SelectCompany(string companyCode)
        {
            using mainContext db = new();
            return db.DcCompanies.FirstOrDefault(x => x.CompanyCode == companyCode);
        }

        public List<DcFeatureType> SelectFeatureTypes()
        {
            using subContext db = new();

            List<DcFeatureType> featureTypes = db.DcFeatureTypes.ToList();
            return featureTypes;
        }

        public List<DcFeatureType> SelectFeatureTypesByHierarchy(string hierarchyCode)
        {
            using subContext db = new();

            List<DcFeatureType> featureTypes = db.DcFeatureTypes.Include(x => x.TrHierarchyFeatureTypes)
                                                                    .ThenInclude(x => x.DcHierarchy)
                                                                .Where(x => x.TrHierarchyFeatureTypes.Where(x => x.HierarchyCode == hierarchyCode).Any() || !x.TrHierarchyFeatureTypes.Any())
                                                                .OrderByDescending(x => x.Order)
                                                                .ToList();

            return featureTypes;
        }

        public List<DcFeature> SelectFeaturesByType(int featureTypeId)
        {
            using subContext db = new();

            List<DcFeature> features = db.DcFeatures.Where(x => x.FeatureTypeId == featureTypeId).ToList();
            return features;
        }

        public List<DcFeature> SelectFeatures()
        {
            using subContext db = new();

            List<DcFeature> features = db.DcFeatures.Include(x => x.DcFeatureType).ToList();
            return features;
        }

        public TrProductFeature SelectProductFeature(int featureTypeId, string productCode)
        {
            using subContext db = new();

            TrProductFeature dc = db.TrProductFeatures
                     .Where(x => x.FeatureTypeId == featureTypeId)
                     .FirstOrDefault(x => x.ProductCode == productCode);
            return dc;
        }


        public DcFeatureType SelectFeatureType(int featureTypeId)
        {
            using subContext db = new();

            DcFeatureType dc = db.DcFeatureTypes
                     .FirstOrDefault(x => x.FeatureTypeId == featureTypeId);
            return dc;
        }

        public List<TrProductFeature> SelectProductFeaturesByProductCode(string productCode)
        {
            using subContext db = new();

            List<TrProductFeature> productFeatures = db.TrProductFeatures
                                            .Include(x => x.DcFeature)
                                            .Where(x => x.ProductCode == productCode)
                                            .ToList();
            return productFeatures;
        }

        public DcProduct SelectProductByBarcode(string barCode)
        {
            if (string.IsNullOrEmpty(barCode))
                return null;
            using subContext db = new();
            return db.TrProductBarcodes
                .Where(x => x.Barcode == barCode)
                .Select(x => x.DcProduct)
                .FirstOrDefault();
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

        public DcProduct SelectProductBySlug(string slug)
        {
            if (string.IsNullOrEmpty(slug))
                return null;
            using subContext db = new();
            return QueryableSelectProducts(db).FirstOrDefault(x => x.SiteProduct.Slug == slug);
        }

        public List<DcProduct> SelectProductByName(string productName, int Skip, int Take)
        {
            if (string.IsNullOrEmpty(productName))
                return null;
            using subContext db = new();

            char[] delimiterChars = { ' ', ',', '.', ':', '\t' };

            string[] words = productName.Split(delimiterChars);

            IQueryable<DcProduct> products = QueryableSelectProductsForSite(db);

            foreach (var word in words)
            {
                products = products.Where(p => p.TrProductFeatures.Where(f => EF.Functions.Like(f.DcFeature.FeatureDesc, $"%{word}%")).Any());
            }

            var asd = products.Skip(Skip);


            var dolma = asd.Take(Take);

            return dolma.ToList();
        }


        public DcProduct SelectProductBySiteId(int productId)
        {
            using subContext db = new();
            var product = QueryableSelectProducts(db).FirstOrDefault(x => x.SiteProduct.ProductId == productId);
            return product;
        }

        public DcProduct SelectProduct(string productCode)
        {
            using subContext db = new();
            var product = QueryableSelectProducts(db).FirstOrDefault(x => x.ProductCode == productCode);
            return product;
        }

        public List<DcProduct> SelectProducts()
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
                                    Balance = x.TrInvoiceLines.Where(x => new string[] { "RP", "WP", "RS", "WS", "CI", "CO", "IT" }.Contains(x.TrInvoiceHeader.ProcessCode))
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
                                })
                                .OrderBy(x => x.ProductDesc);
            return products;
        }

        public List<DcProduct> SelectProductsForSite()
        {
            using subContext db = new();

            IQueryable<DcProduct> DcProducts = QueryableSelectProductsForSite(db);

            return DcProducts.ToList();
        }

        public List<DcProduct> SelectProductsByFilterForSite(int CategoryId, int minPrice, int maxPrice)
        {
            using subContext db = new();

            IQueryable<DcProduct> DcProducts = QueryableSelectProductsForSite(db)
                                                    .Where(x => CategoryId > 0 ? x.DcHierarchy.Id == CategoryId : true)
                                                    .Where(x => x.SiteProduct.Price >= minPrice)
                                                    .Where(x => x.SiteProduct.Price <= maxPrice);

            return DcProducts.ToList();
        }

        public List<DcProduct> SelectProductsForSite(int CategoryId, int skip, int take)
        {
            using subContext db = new();

            IQueryable<DcProduct> DcProducts = QueryableSelectProductsForSite(db)
                                                    .Where(x => CategoryId > 0 ? x.DcHierarchy.Id == CategoryId : true)
                                                    .Skip(skip)
                                                    .Take(take);

            return DcProducts.ToList();
        }

        public List<DcProduct> SelectPopularProductsForSite(int take)
        {
            using subContext db = new();

            IQueryable<DcProduct> DcProducts = QueryableSelectProductsForSite(db)
                                                    .OrderBy(x => x.SiteProduct.ViewCount)
                                                    .Take(take);

            return DcProducts.ToList();
        }

        public List<DcProduct> SelectProductsForSite(List<int> ProductsIds)
        {
            using subContext db = new();

            IQueryable<DcProduct> DcProducts = QueryableSelectProductsForSite(db)
                                                    .Where(x => ProductsIds.Contains(x.SiteProduct.ProductId));

            return DcProducts.ToList();
        }


        public IQueryable<DcProduct> QueryableSelectProductsForSite(subContext db)
        {
            var products = db.DcProducts
                                .Include(x => x.TrProductFeatures).ThenInclude(x => x.DcFeature).ThenInclude(x => x.DcFeatureType)
                                .Include(x => x.TrProductDiscounts)
                                .Include(x => x.DcHierarchy)
                                .Include(x => x.SiteProduct)
                                .Where(x => x.HierarchyCode != null)
                                .Where(x => x.UseInternet == true)
                                .Where(x => x.ProductTypeCode == 1)
                                .Select(x => new DcProduct
                                {
                                    Balance = x.TrInvoiceLines.Sum(l => l.QtyIn - l.QtyOut),
                                    ProductCode = x.ProductCode,
                                    ProductDesc = x.ProductDesc,
                                    RetailPrice = x.RetailPrice,
                                    PurchasePrice = x.PurchasePrice,
                                    ProductTypeCode = x.ProductTypeCode,
                                    WholesalePrice = x.WholesalePrice,
                                    UseInternet = x.UseInternet,
                                    HierarchyCode = x.HierarchyCode,
                                    TrProductFeatures = x.TrProductFeatures,
                                    SiteProduct = x.SiteProduct,
                                    DcHierarchy = x.DcHierarchy,
                                    TrProductDiscounts = x.TrProductDiscounts,
                                })
                                .OrderBy(x => x.ProductDesc);
            return products;
        }

        public int SelectProductBalance(string productCode, string warehouseCode)
        {
            using subContext db = new();

            return db.TrInvoiceLines.Include(x => x.TrInvoiceHeader)
                                    .Where(x => x.ProductCode == productCode)
                                    .Where(x => x.TrInvoiceHeader.WarehouseCode == warehouseCode)
                                    .Where(x => new string[] { "RP", "WP", "RS", "WS", "CI", "CO", "IT" }.Contains(x.TrInvoiceHeader.ProcessCode))
                                    .Sum(x => x.QtyIn - x.QtyOut);
        }

        public int SelectProductBalanceSerialNumber(string productCode, string warehouseCode, string serialNumberCode)
        {
            using subContext db = new();

            return db.TrInvoiceLines.Include(x => x.TrInvoiceHeader)
                                    .Where(x => x.ProductCode == productCode)
                                    .Where(x => new string[] { "RP", "WP", "RS", "WS", "CI", "CO", "IT" }.Contains(x.TrInvoiceHeader.ProcessCode))
                                    .Where(x => x.SerialNumberCode == serialNumberCode)
                                    .Where(x => x.TrInvoiceHeader.WarehouseCode == warehouseCode)
                                    .Sum(x => x.QtyIn - x.QtyOut);
        }

        public List<DcProduct> SelectProductsByType(byte[] productTypeArr)
        {
            using subContext db = new();

            IQueryable<DcProduct> DcProducts = QueryableSelectProducts(db).Where(x => productTypeArr.Contains(x.ProductTypeCode));

            return DcProducts.ToList();
        }
        public List<DcProduct> SelectProductsByTypeByFilter(byte[] productTypeArr, CriteriaOperator filterCriteria)
        {
            using subContext db = new();

            IQueryable<DcProduct> DcProducts = QueryableSelectProducts(db).Where(x => productTypeArr.Contains(x.ProductTypeCode));
            IQueryable<DcProduct> filteredData = DcProducts.AppendWhere(new CriteriaToExpressionConverter(), filterCriteria) as IQueryable<DcProduct>;

            return DcProducts.ToList();
        }

        public List<TrInvoiceHeader> SelectInvoiceHeaders()
        {
            using subContext db = new();

            return db.TrInvoiceHeaders.Where(x => x.IsCompleted == true)
                                      .OrderBy(x => x.CreatedDate)
                                      .ToList();
        }

        public TrInvoiceHeader SelectInvoiceHeader(Guid invoiceHeaderId)
        {
            using subContext db = new();

            return db.TrInvoiceHeaders.Include(x => x.DcCurrAcc)
                                      .Include(x => x.TrInvoiceLines)
                                      .FirstOrDefault(x => x.InvoiceHeaderId == invoiceHeaderId);
        }

        public TrPriceListHeader SelectPriceListHeader(Guid priceListHeaderId)
        {
            using subContext db = new();

            return db.TrPriceListHeaders.FirstOrDefault(x => x.PriceListHeaderId == priceListHeaderId);
        }

        public List<TrProductHierarchy> SelectProductHierarchies()
        {
            using subContext db = new();

            return db.TrProductHierarchies.Include(x => x.DcHierarchy).ToList();
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

        public List<TrCurrAccRole> SelectCurrAccRole(string currAccCode)
        {
            using subContext db = new();

            List<TrCurrAccRole> currAccRoles = db.TrCurrAccRoles.Include(x => x.DcRole)
                                                                  .Include(x => x.DcCurrAcc)
                                                                  .Where(x => x.CurrAccCode == currAccCode)
                                                                  .ToList();
            return currAccRoles;
        }

        public List<TrRoleClaim> SelectRoleClaim(string roleCode)
        {
            using subContext db = new();

            List<TrRoleClaim> roleClaims = db.TrRoleClaims.Include(x => x.DcRole)
                                                                  .Where(x => x.RoleCode == roleCode)
                                                                  .ToList();
            return roleClaims;
        }

        public List<TrHierarchyFeatureType> SelectHierarchyFeatureTypes(int featureTypeId)
        {
            using subContext db = new();

            return SelectHierarchyFeatureTypes()
                                             .Where(x => x.FeatureTypeId == featureTypeId)
                                             .ToList();
        }

        public List<TrFormReport> SelectFormReports(string formCode)
        {
            using subContext db = new();

            return db.TrFormReports.Include(x => x.DcReport)
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

        public List<TrInvoiceHeader> SelectInvoiceHeadersByProcessCode(string processCode)
        {
            using subContext db = new();

            return db.TrInvoiceHeaders.Where(x => x.ProcessCode == processCode)
                                      .OrderBy(x => x.CreatedDate)
                                      .ToList();
        }

        public TrInvoiceLine SelectInvoiceLine(Guid invoiceLineId)
        {
            using subContext db = new();

            return db.TrInvoiceLines.Include(x => x.TrInvoiceHeader)
                                    .FirstOrDefault(x => x.InvoiceLineId == invoiceLineId);
        }

        public bool ReturnExistByInvoiceLine(Guid relatedLineId)
        {
            using subContext db = new();

            return db.TrInvoiceLines.Include(x => x.TrInvoiceHeader)
                                    .Where(x => x.TrInvoiceHeader.IsReturn)
                                    .Any(x => x.RelatedLineId == relatedLineId);
        }

        public bool WaybillExistByInvoiceLine(Guid relatedLineId)
        {
            using subContext db = new();

            return db.TrInvoiceLines.Include(x => x.TrInvoiceHeader)
                                    .Where(x => new string[] { "WI", "WO" }.Contains(x.TrInvoiceHeader.ProcessCode))
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

        public int InsertInvoiceLine(DcProduct dcProduct, Guid invoiceHeaderId)
        {
            using subContext db = new();

            IQueryable<DcProduct> dcProducts = db.DcProducts.AsQueryable();

            if (!string.IsNullOrEmpty(dcProduct.ProductCode))
                dcProducts = dcProducts.Where(x => x.ProductCode == dcProduct.ProductCode);

            DcProduct product = dcProducts.FirstOrDefault();

            if (product is not null)
            {
                TrInvoiceLine trInvoiceLine = new()
                {
                    InvoiceLineId = Guid.NewGuid(),
                    InvoiceHeaderId = invoiceHeaderId,
                    ProductCode = product.ProductCode,
                    Price = product.RetailPrice,
                    Amount = Convert.ToDecimal(product.RetailPrice),
                    PosDiscount = Convert.ToDecimal(product.PosDiscount),
                    NetAmount = Convert.ToDecimal(product.RetailPrice)
                };

                db.TrInvoiceLines.Add(trInvoiceLine);
                return db.SaveChanges();
            }
            else
                return -1;
        }

        public int InsertInvoiceLine(TrInvoiceLine TrInvoiceLine)
        {
            using subContext db = new();
            db.TrInvoiceLines.Add(TrInvoiceLine);
            return db.SaveChanges();
        }

        public bool InvoiceHeaderExist(Guid invoiceHeaderId)
        {
            using subContext db = new();
            return db.TrInvoiceHeaders.Any(x => x.InvoiceHeaderId == invoiceHeaderId);
        }

        public bool ExpensesExistByInvoiceId(Guid invoiceHeaderId)
        {
            using subContext db = new();
            return db.TrInvoiceHeaders.Where(x => x.ProcessCode == "EI")
                                      .Any(x => x.RelatedInvoiceId == invoiceHeaderId);
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

        public bool PriceListHeaderExist(Guid priceListHeaderId)
        {
            using subContext db = new();
            return db.TrPriceListHeaders.Any(x => x.PriceListHeaderId == priceListHeaderId);
        }

        public void InsertInvoiceHeader(TrInvoiceHeader TrInvoiceHeader)
        {
            using subContext db = new();
            db.TrInvoiceHeaders.Add(TrInvoiceHeader);
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

        public int DeletePayment(Guid paymentHeaderId)
        {
            using subContext db = new();
            TrPaymentHeader trPaymentHeader = db.TrPaymentHeaders.Where(x => x.PaymentHeaderId == paymentHeaderId)
                                                        .FirstOrDefault();
            if (trPaymentHeader is not null)
                db.TrPaymentHeaders.Remove(trPaymentHeader);

            return db.SaveChanges();
        }

        public int DeletePriceList(Guid priceListHeaderId)
        {
            using subContext db = new();
            TrPriceListHeader trPriceListHeader = db.TrPriceListHeaders.Where(x => x.PriceListHeaderId == priceListHeaderId)
                                                        .FirstOrDefault();
            if (trPriceListHeader is not null)
                db.TrPriceListHeaders.Remove(trPriceListHeader);

            return db.SaveChanges();
        }

        public int DeletePriceType(DcPriceType dcPriceType)
        {
            using subContext db = new();

            if (dcPriceType is not null)
                db.DcPriceTypes.Remove(dcPriceType);

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
                var asddfgfg = db.SiteProducts.Where(x => x.ProductCode == dcProduct.ProductCode);
                db.SiteProducts.RemoveRange(asddfgfg);
                product = db.DcProducts.Remove(dcProduct);
            }

            return db.SaveChanges();
        }

        public int DeleteCurrAcc(DcCurrAcc dcCurrAcc)
        {
            using subContext db = new();

            if (dcCurrAcc is not null)
                db.DcCurrAccs.Remove(dcCurrAcc);

            return db.SaveChanges();
        }

        public int DeleteWarehouse(DcWarehouse dcWarehouse)
        {
            using subContext db = new();

            if (dcWarehouse is not null)
                db.DcWarehouses.Remove(dcWarehouse);

            return db.SaveChanges();
        }

        public int DeleteFeatureType(DcFeatureType dcFeatureType)
        {
            using subContext db = new();

            if (dcFeatureType is not null)
                db.DcFeatureTypes.Remove(dcFeatureType);

            return db.SaveChanges();
        }

        public int DeleteFeature(DcFeature dcFeature)
        {
            using subContext db = new();

            if (dcFeature is not null)
                db.DcFeatures.Remove(dcFeature);

            return db.SaveChanges();
        }

        public int DeleteSession(TrSession session)
        {
            using subContext db = new();

            if (session is not null)
                db.TrSessions.Remove(session);

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

        public int DeletePaymentLinesByPaymentHeader(Guid paymentHeader)
        {
            using subContext db = new();
            List<TrPaymentLine> paymentLines = db.TrPaymentLines.Where(x => x.PaymentHeaderId == paymentHeader)
                                                               .ToList();
            if (paymentLines is not null)
                db.TrPaymentLines.RemoveRange(paymentLines);

            return db.SaveChanges();
        }

        public int DeleteInvoiceLine(object invoiceLineId)
        {
            using subContext db = new();

            TrInvoiceLine trInvoiceLine = new() { InvoiceLineId = Guid.Parse(invoiceLineId.ToString()) };
            db.TrInvoiceLines.Remove(trInvoiceLine);
            return db.SaveChanges();
        }

        public int DeleteReport(int ReportId)
        {
            using subContext db = new();
            DcReport dcReport = new() { ReportId = ReportId };
            db.DcReports.Remove(dcReport);
            return db.SaveChanges();
        }

        public int UpdateInvoiceIsCompleted(Guid invoiceHeaderId)
        {
            using subContext db = new();
            TrInvoiceHeader trInvoiceHeader = new() { InvoiceHeaderId = invoiceHeaderId, IsCompleted = true };
            db.Entry(trInvoiceHeader).Property(x => x.IsCompleted).IsModified = true;
            return db.SaveChanges();
        }

        public int UpdateInvoiceIsSent(Guid invoiceHeaderId)
        {
            using subContext db = new();
            TrInvoiceHeader trInvoiceHeader = new() { InvoiceHeaderId = invoiceHeaderId, IsSent = true };
            db.Entry(trInvoiceHeader).Property(x => x.IsSent).IsModified = true;
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

        public int UpdateInvoiceIsOpen(string docNum, bool isOpen)
        {
            using subContext db = new();
            TrInvoiceHeader trInvoiceHeader = db.TrInvoiceHeaders.Where(x => x.DocumentNumber == docNum)
                                                                 .FirstOrDefault(x => x.IsMainTF == true);
            if (trInvoiceHeader is not null)
            {
                trInvoiceHeader.IsOpen = isOpen;
                db.Entry(trInvoiceHeader).Property(x => x.IsOpen).IsModified = true;
                return db.SaveChanges();
            }
            else
                return 0;
        }

        public int UpdateInvoiceLineQtyOut(object invoiceLineId, int qtyOut)
        {
            Guid variable = Guid.Parse(invoiceLineId.ToString());

            using subContext db = new();

            TrInvoiceLine trInvoiceLine = db.TrInvoiceLines.FirstOrDefault(x => x.InvoiceLineId == variable);

            if (trInvoiceLine.QtyOut != 0)
                trInvoiceLine.PosDiscount = qtyOut * (trInvoiceLine.PosDiscount / trInvoiceLine.QtyOut); // qty is new quantity trInvoiceLine.Qty is old quantity
            trInvoiceLine.Amount = qtyOut * Convert.ToDecimal(trInvoiceLine.Price);
            trInvoiceLine.NetAmount = trInvoiceLine.Amount - trInvoiceLine.PosDiscount;
            trInvoiceLine.QtyOut = qtyOut;

            db.TrInvoiceLines.Update(trInvoiceLine);
            return db.SaveChanges();
        }

        public int UpdateInvoiceLineQtyOut(Guid invoiceHeaderId, Guid relatedLineId, int qtyOut)
        {
            using subContext db = new();

            TrInvoiceLine trInvoiceLine = db.TrInvoiceLines.Where(x => x.InvoiceHeaderId == invoiceHeaderId)
                                               .FirstOrDefault(x => x.RelatedLineId == relatedLineId);

            trInvoiceLine.Amount = qtyOut * trInvoiceLine.Price;
            trInvoiceLine.AmountLoc = qtyOut * trInvoiceLine.PriceLoc;
            trInvoiceLine.NetAmount = qtyOut * (trInvoiceLine.Price * (100 - trInvoiceLine.PosDiscount));
            trInvoiceLine.NetAmountLoc = qtyOut * (trInvoiceLine.PriceLoc * (100 - trInvoiceLine.PosDiscount));
            trInvoiceLine.QtyOut = qtyOut;

            db.TrInvoiceLines.Update(trInvoiceLine);
            return db.SaveChanges();
        }

        public int UpdateInvoicePosDiscount(TrInvoiceLine trInvoiceLine)
        {
            using subContext db = new();

            db.Entry(trInvoiceLine).Property(x => x.PosDiscount).IsModified = true;
            db.Entry(trInvoiceLine).Property(x => x.NetAmount).IsModified = true;
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

            List<TrPaymentHeader> trPaymentHeaders = SelectPaymentHeaders(invoiceHeaderId);

            foreach (TrPaymentHeader entity in trPaymentHeaders)
            {
                entity.CurrAccCode = currAccCode;
                db.Entry(entity).Property(x => x.CurrAccCode).IsModified = true;
            }

            return db.SaveChanges();
        }

        public decimal SelectPrice(string processCode, string productCode)
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

        public int InsertCustomer(DcCurrAcc dcCurrAcc)
        {
            using subContext db = new();
            db.DcCurrAccs.Add(dcCurrAcc);
            return db.SaveChanges();
        }

        public int InsertCompany(DcCompany dcCompany)
        {
            using mainContext db = new();
            db.DcCompanies.Add(dcCompany);
            return db.SaveChanges();
        }

        public bool CustomerExist(string CurrAccCode)
        {
            using subContext db = new();
            return db.DcCurrAccs.Any(x => x.CurrAccCode == CurrAccCode);
        }

        public int UpdateCustomer(DcCurrAcc dcCurrAcc)
        {
            using subContext db = new();
            db.DcCurrAccs.Update(dcCurrAcc);
            return db.SaveChanges();
        }

        public int InsertPaymentHeader(TrPaymentHeader trPaymentHeader)
        {
            using subContext db = new();
            db.TrPaymentHeaders.Add(trPaymentHeader);
            return db.SaveChanges();
        }

        public int InsertPaymentLine(TrPaymentLine trPaymentLine)
        {
            using subContext db = new();
            db.TrPaymentLines.Add(trPaymentLine);
            return db.SaveChanges();
        }

        public bool PaymentHeaderExist(Guid paymentHeaderId)
        {
            using subContext db = new();
            return db.TrPaymentHeaders.Any(x => x.PaymentHeaderId == paymentHeaderId);
        }

        public List<TrPaymentLine> SelectPaymentLines(Guid paymentHeaderId)
        {
            using subContext db = new();
            return db.TrPaymentLines.Include(x => x.TrPaymentHeader)
                           .Include(x => x.DcPaymentType)
                           .Where(x => x.TrPaymentHeader.PaymentHeaderId == paymentHeaderId)
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

        public List<TrPaymentHeader> SelectPaymentHeaders(Guid invoiceHeaderId)
        {
            using subContext db = new();
            return db.TrPaymentHeaders.Where(x => x.InvoiceHeaderId == invoiceHeaderId)
                                    .ToList();
        }

        public decimal SelectPaymentLinesSumByInvoice(Guid invoiceHeaderId)
        {
            using subContext db = new();

            return db.TrPaymentLines.Include(x => x.TrPaymentHeader)
                                    .Where(x => x.TrPaymentHeader.InvoiceHeaderId == invoiceHeaderId)
                                    .Sum(s => s.PaymentLoc);
        }

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
                                                     .Where(l => new string[] { "RP", "WP", "RS", "WS", "CI", "CO", "IT" }.Contains(l.TrInvoiceHeader.ProcessCode))
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

        public List<DcCurrAcc> SelectCurrAccsByType(byte currAccTypeCode)
        {
            using subContext db = new();

            return db.DcCurrAccs.Where(x => x.IsDisabled == false && x.CurrAccTypeCode == currAccTypeCode)
                                .OrderBy(x => x.CreatedDate)
                                .ToList();
        }

        public DcCurrAcc SelectCurrAcc(string currAccCode)
        {
            using subContext db = new();
            return db.DcCurrAccs.Where(x => x.IsDisabled == false)
                                .FirstOrDefault(x => x.CurrAccCode == currAccCode);
        }

        public decimal SelectCurrAccBalance(string currAccCode, DateTime documentDate)
        {
            using subContext db = new();

            decimal invoiceSum = db.TrInvoiceLines.Include(x => x.TrInvoiceHeader)
                                       .Where(x => x.TrInvoiceHeader.CurrAccCode == currAccCode)
                                       .Where(x => new string[] { "RP", "WP", "RS", "WS", "CI", "CO", "IT" }.Contains(x.TrInvoiceHeader.ProcessCode))
                                       .AsEnumerable() // Pull the data into memory for 'TrInvoiceHeader.DocumentDate.Add'
                                       .Where(x => x.TrInvoiceHeader.DocumentDate.Add(x.TrInvoiceHeader.DocumentTime) < documentDate)
                                       .Sum(x => (x.QtyIn - x.QtyOut) * (x.PriceLoc - (x.PriceLoc * x.PosDiscount / 100)));

            decimal paymentSum = db.TrPaymentLines.Include(x => x.TrPaymentHeader)
                                       .Where(x => x.TrPaymentHeader.CurrAccCode == currAccCode)
                                       .AsEnumerable() // Pull the data into memory for 'TrInvoiceHeader.DocumentDate.Add'
                                       .Where(x => x.TrPaymentHeader.OperationDate.Add(x.TrPaymentHeader.OperationTime) < documentDate)
                                       .Sum(x => x.PaymentLoc);

            return paymentSum + invoiceSum;
        }

        public decimal SelectCurrAccBalance(string currAccCode)
        {
            using subContext db = new();

            decimal invoiceSum = db.TrInvoiceLines.Include(x => x.TrInvoiceHeader).Where(x => x.TrInvoiceHeader.CurrAccCode == currAccCode)
                                                  .Where(x => new string[] { "RP", "WP", "RS", "WS", "CI", "CO", "IT" }.Contains(x.TrInvoiceHeader.ProcessCode))
                                                  .Sum(x => x.NetAmountLoc);

            decimal paymentSum = db.TrPaymentLines.Include(x => x.TrPaymentHeader)
                                                  .Where(x => x.TrPaymentHeader.CurrAccCode == currAccCode)
                                                  .Sum(x => x.PaymentLoc);

            return invoiceSum + paymentSum;
        }

        public decimal SelectCashRegBalance(string cashRegCode, DateTime documentDate)
        {
            using subContext db = new();

            decimal paymentSum = db.TrPaymentLines.Include(x => x.TrPaymentHeader)
                                       .Where(x => x.CashRegisterCode == cashRegCode && x.TrPaymentHeader.OperationDate < documentDate)
                                       .Sum(x => x.PaymentLoc);

            return paymentSum;
        }

        public decimal SelectPaymentLinesSum(Guid paymentHeaderId)
        {
            using subContext db = new();

            return db.TrPaymentLines.Include(x => x.TrPaymentHeader)
                                    .Where(x => x.PaymentHeaderId == paymentHeaderId)
                                    .Sum(x => x.PaymentLoc);
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

        public DcProcess SelectProcess(string processCode)
        {
            using subContext db = new();
            DcProcess dcProcess = db.DcProcesses.Where(x => x.ProcessCode == processCode)
                      .FirstOrDefault();
            return dcProcess;
        }

        public List<DcCurrency> SelectCurrencies()
        {
            using subContext db = new();

            return db.DcCurrencies.ToList();
        }

        public DcCurrency SelectCurrency(string currencyCode)
        {
            using subContext db = new();
            return db.DcCurrencies.FirstOrDefault(x => x.CurrencyCode == currencyCode);
        }

        public DcHierarchy SelectHierarchy(string hierarchyCode)
        {
            using subContext db = new();
            return db.DcHierarchies.FirstOrDefault(x => x.HierarchyCode == hierarchyCode);
        }

        public DcRole SelectRole(string roleCode)
        {
            using subContext db = new();
            return db.DcRoles.FirstOrDefault(x => x.RoleCode == roleCode);
        }

        public DcHierarchy SelectHierarchyBySlug(string slug)
        {
            using subContext db = new();
            return db.DcHierarchies.FirstOrDefault(x => x.Slug == slug);
        }

        public DcCurrency SelectCurrencyByName(string currencyDesc)
        {
            using subContext db = new();
            return db.DcCurrencies.FirstOrDefault(x => x.CurrencyDesc == currencyDesc);
        }

        public List<DcPaymentType> SelectPaymentTypes()
        {
            using subContext db = new();
            return db.DcPaymentTypes.ToList();
        }

        public DcPaymentType SelectPaymentType(byte paymentTypeId)
        {
            using subContext db = new();
            return db.DcPaymentTypes.FirstOrDefault(x => x.PaymentTypeCode == paymentTypeId);
        }

        public List<DcPaymentMethod> SelectPaymentMethods()
        {
            using subContext db = new();
            return db.DcPaymentMethods.ToList();
        }

        public DcPaymentMethod SelectPaymentMethod(int paymentMethodId)
        {
            using subContext db = new();
            return db.DcPaymentMethods.FirstOrDefault(x => x.PaymentMethodId == paymentMethodId);
        }

        public List<TrPaymentMethodDiscount> SelectPaymentDiscounts()
        {
            using subContext db = new();
            return db.TrPaymentMethodDiscounts.Include(x => x.DcDiscount)
                                              .Include(x => x.DcPaymentMethod)
                                              .ToList();
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

        public DcHierarchy SelectHierarchyById(int hierarchyId)
        {
            using subContext db = new();

            var asd = db.DcHierarchies
                     .Include(x => x.TrHierarchyFeatureTypes).ThenInclude(x => x.DcFeatureType)
                     .FirstOrDefault(x => x.Id == hierarchyId);

            return asd;
        }

        public List<TrPaymentMethodDiscount> SelectPaymentMethodsByDiscount(int discountId)
        {
            using subContext db = new();
            return db.TrPaymentMethodDiscounts
                        .Include(x => x.DcDiscount)
                        .Include(x => x.DcPaymentMethod)
                        .ToList();
        }

        public List<TrPaymentMethodDiscount> SelectPaymentMethodByDiscounts()
        {
            using subContext db = new();
            return db.TrPaymentMethodDiscounts
                        .Include(x => x.DcDiscount)
                        .Include(x => x.DcPaymentMethod)
                        .ToList();
        }

        public float SelectExRate(string currancyCode)
        {
            using subContext db = new();
            DcCurrency dcCurrency = db.DcCurrencies.Where(x => x.CurrencyCode == currancyCode)
                                                   .FirstOrDefault();
            return dcCurrency.ExchangeRate;
        }

        public int SelectInvoicePrinCount(Guid? invoiceHeaderId)
        {
            using subContext db = new();
            int rtrn = 0;
            TrInvoiceHeader trInvoice = db.TrInvoiceHeaders.Where(x => x.InvoiceHeaderId == invoiceHeaderId)
                                                           .FirstOrDefault();
            if (trInvoice is not null)
                rtrn = trInvoice.PrintCount;
            return rtrn;
        }

        public List<DcCurrAcc> SelectStores()
        {
            using subContext db = new();
            return db.DcCurrAccs.Where(x => x.IsDisabled == false)
                       .Where(x => x.CurrAccTypeCode == 4)
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

        public string SelectCashRegByStore(string storeCode)
        {
            using subContext db = new();
            string cashReg = "";

            DcCurrAcc dcCurrAcc = db.DcCurrAccs.Where(x => x.IsDisabled == false && x.IsDefault == true && x.CurrAccTypeCode == 5)
                                  .FirstOrDefault(x => x.StoreCode == storeCode);

            if (dcCurrAcc is not null)
                cashReg = dcCurrAcc.CurrAccCode;

            return cashReg;
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

        public bool Login(string CurrAccCode, string Password)
        {
            if (string.IsNullOrEmpty(Password.Trim()))
                return false;
            else
            {
                using subContext db = new();
                return db.DcCurrAccs.Where(x => x.IsDisabled == false)
                        .Where(x => x.CurrAccCode == CurrAccCode)
                        .Any(x => x.NewPassword == Password);
            }
        }

        public bool CurrAccExist(string CurrAccCode)
        {
            using subContext db = new();
            return db.DcCurrAccs.Where(x => x.IsDisabled == false)
                                .Any(x => x.CurrAccCode == CurrAccCode);
        }

        public bool CheckHasLicense(string id)
        {
            using subContext db = new();
            AppSetting AppSetting = db.AppSettings.FirstOrDefault(x => x.License == id);
            return db.AppSettings.Any(x => x.License == id);
        }

        public bool FeatureTypeExist(int featureTypeId)
        {
            using subContext db = new();
            return db.DcFeatureTypes.Any(x => x.FeatureTypeId == featureTypeId);
        }

        public bool PriceTypeExist(string priceTypeCode)
        {
            using subContext db = new();
            return db.DcPriceTypes.Any(x => x.PriceTypeCode == priceTypeCode);
        }

        public bool FeatureExist(string featureCode, int featureTypeId)
        {
            using subContext db = new();
            return db.DcFeatures.Any(x => x.FeatureCode == featureCode && x.FeatureTypeId == featureTypeId);
        }

        public bool HierarchyExist(string hierarchy)
        {
            using subContext db = new();
            return db.DcHierarchies.Any(x => x.HierarchyCode == hierarchy);
        }

        public bool ReportExist(int Id)
        {
            using subContext db = new();
            return db.DcReports.Any(x => x.ReportId == Id);
        }

        public bool ProductExist(string productCode)
        {
            using subContext db = new();
            return db.DcProducts.Where(x => x.IsDisabled == false)
                       .Any(x => x.ProductCode == productCode);
        }

        public void InsertCurrAcc(DcCurrAcc dcCurrAcc)
        {
            using subContext db = new();
            db.DcCurrAccs.Add(dcCurrAcc);
            db.SaveChanges();
        }

        public void InsertTrSession(TrSession trSession)
        {
            using subContext db = new();
            db.TrSessions.Add(trSession);
            db.SaveChanges();
        }

        public bool TrSessionExistCurrAccCode(string currAccCode)
        {
            using subContext db = new();
            return db.TrSessions.Any(x => x.CurrAccCode == currAccCode);
        }

        public void InsertProduct(DcProduct dcProduct)
        {
            using subContext db = new();
            EntityEntry<DcProduct> result = db.DcProducts.Add(dcProduct);

            if (result is not null)
                db.SiteProducts.Add(new SiteProduct() { ProductCode = dcProduct.ProductCode });

            db.SaveChanges();
        }

        public void InsertFeature(DcFeature dcFeature)
        {
            using subContext db = new();
            db.DcFeatures.Add(dcFeature);
            db.SaveChanges();
        }

        public void InsertHierarchy(DcHierarchy dcHierarchy)
        {
            using subContext db = new();
            db.DcHierarchies.Add(dcHierarchy);
            db.SaveChanges();
        }

        public int DeleteHierarchy(string hierarchyCode)
        {
            using subContext db = new();
            db.DcHierarchies.Remove(db.DcHierarchies.FirstOrDefault(x => x.HierarchyCode == hierarchyCode));
            return db.SaveChanges();
        }

        public int DeleteHierarchyFeatureType(string hierarchyCode, int featureType)
        {
            using subContext db = new();
            db.TrHierarchyFeatureTypes.Remove(db.TrHierarchyFeatureTypes.FirstOrDefault(x => x.HierarchyCode == hierarchyCode && x.FeatureTypeId == featureType));
            return db.SaveChanges();
        }

        public int DeleteCurrAccRole(int currAccRolId)
        {
            using subContext db = new();
            db.TrCurrAccRoles.Remove(db.TrCurrAccRoles.Find(currAccRolId));
            return db.SaveChanges();
        }

        public int DeleteRoleClaim(int colRoleClaimId)
        {
            using subContext db = new();
            db.TrRoleClaims.Remove(db.TrRoleClaims.Find(colRoleClaimId));
            return db.SaveChanges();
        }

        public void InsertFeature(DcPriceType DcPriceType)
        {
            using subContext db = new();
            db.DcPriceTypes.Add(DcPriceType);
            db.SaveChanges();
        }

        public List<DcRole> SelectRoles(string CurrAccCode)
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

        public string SelectOfficeCode(string CurrAccCode)
        {
            using subContext db = new();

            DcCurrAcc currAcc = db.DcCurrAccs.Where(x => x.CurrAccCode == CurrAccCode)
                                             .FirstOrDefault();
            return currAcc.OfficeCode;
        }

        public string SelectStoreCode(string CurrAccCode)
        {
            using subContext db = new();
            DcCurrAcc currAcc = db.DcCurrAccs.Where(x => x.CurrAccCode == CurrAccCode)
                                    .FirstOrDefault();
            return currAcc.StoreCode;
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

        public DcReport SelectReport(int id)
        {
            using subContext db = new();
            return db.DcReports.Include(x => x.TrReportSubQueries).ThenInclude(x => x.TrReportSubQueryRelationColumns)
                               .Include(x => x.DcReportVariables)
                               .FirstOrDefault(x => x.ReportId == id);
        }

        public List<TrReportSubQuery> SelectReportQueriesByReport(int reportId)
        {
            using subContext db = new();
            return db.TrReportSubQueries.Where(x => x.ReportId == reportId).ToList();
        }

        public List<TrReportSubQueryRelationColumn> SelectSubQueryRelationColumnByQueryId(int subQueryId)
        {
            using subContext db = new();
            return db.TrReportSubQueryRelationColumns.Where(x => x.SubQueryId == subQueryId).ToList();
        }

        //public List<DcQueryParam> SelectQueryParamsByReport(int reportId)
        //{
        //    using subContext db = new();
        //    return db.DcQueryParams.Where(x => x.ReportId == reportId).ToList();
        //}

        public DcReport SelectReportByName(string name)
        {
            using subContext db = new();
            return db.DcReports.Include(x => x.DcReportVariables).FirstOrDefault(x => x.ReportName == name);
        }

        public List<DcReport> SelectReports()
        {
            using subContext db = new();
            return db.DcReports.ToList();
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

        public int UpdateTrSession(TrSession trSession)
        {
            using subContext db = new();
            db.TrSessions.Update(trSession);
            return db.SaveChanges();
        }

        public int UpdateDcReportVariable_Value(int ReportId, string fieldName, string filterValue)
        {
            using subContext db = new();
            DcReportVariable reportVariable = db.DcReportVariables.Where(x => x.VariableProperty == fieldName)
                                                        .FirstOrDefault(x => x.ReportId == ReportId);
            reportVariable.VariableValue = filterValue;
            db.Entry(reportVariable).Property(x => x.VariableValue).IsModified = true;
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

        public int UpdateReportFilter(int id, string prop, string value)
        {
            using subContext db = new();
            DcReportVariable dcReportVariable = db.DcReportVariables.FirstOrDefault(x => x.VariableProperty == prop && x.ReportId == id);
            dcReportVariable.VariableValue = value;

            db.Entry(dcReportVariable).Property(x => x.VariableValue).IsModified = true;

            return db.SaveChanges();
        }

        public void InsertReport(DcReport dcReport)
        {
            using subContext db = new();
            db.DcReports.Add(dcReport);
            db.SaveChanges();
        }

        public void InsertFormReport(string formCode, int reportId)
        {
            using subContext db = new();
            TrFormReport trFormReport = new() { FormCode = formCode, ReportId = reportId };
            db.TrFormReports.Add(trFormReport);
            db.SaveChanges();
        }

        public int UpdateAppSettingGridViewLayout(string layout)
        {
            using subContext db = new();
            AppSetting appSetting = new() { Id = 1, GridViewLayout = layout };
            db.Entry(appSetting).Property(x => x.GridViewLayout).IsModified = true;
            return db.SaveChanges();
        }

        public int UpdateSettingStoreImagePath(string storeCode, string imagePath)
        {
            using subContext db = new();
            SettingStore setting = new() { StoreCode = storeCode, ImageFolder = imagePath };
            db.Entry(setting).Property(x => x.ImageFolder).IsModified = true;
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
            //hierarcy.HierarchyDesc = hierarchyDesc;
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

        public int UpdateAppSettingTwilioInstance(string instanceId)
        {
            using subContext db = new();
            AppSetting appSetting = new() { Id = 1, TwilioInstanceId = instanceId };
            db.Entry(appSetting).Property(x => x.TwilioInstanceId).IsModified = true;
            return db.SaveChanges();
        }

        public int UpdateAppSettingDueDate(string dueDate)
        {
            using subContext db = new();
            AppSetting appSetting = new() { Id = 1, DueDate = dueDate };
            db.Entry(appSetting).Property(x => x.DueDate).IsModified = true;
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

        public int UpdateAppSettingTwilioToken(string token)
        {
            using subContext db = new();
            AppSetting appSetting = new() { Id = 1, TwilioToken = token };
            db.Entry(appSetting).Property(x => x.TwilioToken).IsModified = true;
            return db.SaveChanges();
        }

        public AppSetting SelectAppSetting()
        {
            using subContext db = new();
            string asdasd = db.Database.GetConnectionString();

            return db.AppSettings.Find(1);

        }

        public SettingStore SelectSettingStore(string StoreCode)
        {
            using subContext db = new();
            return db.SettingStores.FirstOrDefault(x => x.StoreCode == StoreCode);
        }

        public TrSession SelectTrSessionByCurrAccCode(string currAccCode)
        {
            using subContext db = new();
            return db.TrSessions.FirstOrDefault(x => x.CurrAccCode == currAccCode);
        }

        public List<TrSession> SelectSessions()
        {
            using subContext db = new();
            return db.TrSessions.ToList();
        }
    }
}