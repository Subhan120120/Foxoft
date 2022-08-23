using Microsoft.EntityFrameworkCore;
using Foxoft.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using DevExpress.Data.Linq;
using DevExpress.Data.Filtering;
using DevExpress.Data.Linq.Helpers;

namespace Foxoft
{
   public class EfMethods
   {
      //private subContext db;
      public EfMethods()
      {
         //this.db = new subContext();
      }

      public string GetNextDocNum(string processCode, string columnName, string tableName, int ReplicateNum)
      {
         using (subContext db = new subContext())
         {
            string qry = $"exec [dbo].[GetNextDocNum] {processCode}, {columnName}, {tableName}, {ReplicateNum}";

            return db.Set<GetNextDocNum>()
                .FromSqlRaw(qry)
                .AsEnumerable()
                .First()
                .Value;
         }
      }

      public List<TrInvoiceLine> SelectInvoiceLines(Guid invoiceHeaderId)
      {
         using (subContext db = new subContext())
         {
            List<TrInvoiceLine> InvoiceLines = db.TrInvoiceLines.Include(x => x.DcProduct)
                                                              .Where(x => x.InvoiceHeaderId == invoiceHeaderId)
                                                              .OrderBy(x => x.CreatedDate)
                                                              .ToList();

            //InvoiceLines.ForEach(x =>
            //{
            //    x.ReturnQty = db.TrInvoiceLines.Where(y => y.RelatedLineId == x.InvoiceLineId).Sum(s => s.QtyOut);
            //    x.RemainingQty = db.TrInvoiceLines.Where(y => y.RelatedLineId == x.InvoiceLineId).Sum(s => s.QtyOut) + x.QtyOut;
            //});

            #region Comment
            //List<TrInvoiceLine> linqInvoiceLine = (from i in db.TrInvoiceLines
            //                   join p in db.DcProducts on i.ProductCode equals p.ProductCode
            //                   where i.InvoiceHeaderId == invoiceHeaderId
            //                   orderby i.CreatedDate
            //                   select new TrInvoiceLine
            //                   {                                       
            //                       ReturnQty = db.TrInvoiceLines.Where(x => x.RelatedLineId == i.InvoiceLineId).Sum(x => x.Qty),
            //                       RemainingQty = i.Qty + db.TrInvoiceLines.Where(x => x.RelatedLineId == i.InvoiceLineId).Sum(x => x.Qty),
            //                   }).ToList(); 
            #endregion

            return InvoiceLines;
         }
      }

      public decimal SelectInvoiceNetAmount(Guid invoiceHeaderId)
      {
         using (subContext db = new subContext())
         {
            decimal sumNetAmount = db.TrInvoiceLines.Where(x => x.InvoiceHeaderId == invoiceHeaderId)
                                                    .Sum(x => x.NetAmount);
            return sumNetAmount;
         }
      }


      public List<DcProductType> SelectProductTypes()
      {
         using (subContext db = new subContext())
         {
            return db.DcProductTypes.ToList();
         }
      }

      public List<DcCurrAccType> SelectCurrAccTypes()
      {
         using (subContext db = new subContext())
         {
            return db.DcCurrAccTypes.ToList();
         }
      }

      public List<DcProduct> SelectProducts()
      {
         using (subContext db = new subContext())
         {
            List<DcProduct> products = db.DcProducts.Include(x => x.TrInvoiceLines)
                                                        .ThenInclude(x => x.TrInvoiceHeader)
                                                    .Select(x => new DcProduct
                                                    {
                                                       Balance = x.TrInvoiceLines.Sum(l => l.QtyIn - l.QtyOut),
                                                       BalanceM = x.TrInvoiceLines.Where(l => l.TrInvoiceHeader.WarehouseCode == "depo-01").Sum(l => l.QtyIn - l.QtyOut),
                                                       BalanceF = x.TrInvoiceLines.Where(l => l.TrInvoiceHeader.WarehouseCode == "depo-02").Sum(l => l.QtyIn - l.QtyOut),
                                                       LastPurchasePrice = x.TrInvoiceLines.Where(l => l.TrInvoiceHeader.ProcessCode == "RP" || l.TrInvoiceHeader.ProcessCode == "CI").OrderByDescending(l => l.TrInvoiceHeader.DocumentDate).ThenByDescending(l => l.TrInvoiceHeader.DocumentTime).Select(x => x.PriceLoc - (x.PriceLoc * x.PosDiscount / 100)).FirstOrDefault(),
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
                                                    })
                                                    .ToList();
            return products;
         }
      }

      public DcProduct SelectProduct(string productCode)
      {
         using (subContext db = new subContext())
         {
            return db.DcProducts.Include(x => x.TrInvoiceLines)
                                    .ThenInclude(x => x.TrInvoiceHeader)
                                .Select(x => new DcProduct
                                {
                                   Balance = x.TrInvoiceLines.Sum(l => l.QtyIn - l.QtyOut),
                                   BalanceM = x.TrInvoiceLines.Where(l => l.TrInvoiceHeader.WarehouseCode == "depo-01").Sum(l => l.QtyIn - l.QtyOut),
                                   BalanceF = x.TrInvoiceLines.Where(l => l.TrInvoiceHeader.WarehouseCode == "depo-02").Sum(l => l.QtyIn - l.QtyOut),
                                   LastPurchasePrice = x.TrInvoiceLines.Where(l => l.TrInvoiceHeader.ProcessCode == "RP" || l.TrInvoiceHeader.ProcessCode == "CI").OrderByDescending(l => l.TrInvoiceHeader.DocumentDate).ThenByDescending(l => l.TrInvoiceHeader.DocumentTime).Select(x => x.PriceLoc - (x.PriceLoc * x.PosDiscount / 100)).FirstOrDefault(),
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
                                }).FirstOrDefault(x => x.ProductCode == productCode);
         }
      }

      public int SelectProductBalance(string productCode, string warehouseCode)
      {
         using (subContext db = new subContext())
         {
            return db.TrInvoiceLines.Include(x => x.TrInvoiceHeader)
                                    .Where(x => x.ProductCode == productCode && x.TrInvoiceHeader.WarehouseCode == warehouseCode)
                                    .Sum(x => x.QtyIn - x.QtyOut);
         }
      }

      public List<DcProduct> SelectProductsByType(byte productTypeCode, CriteriaOperator filterCriteria)
      {
         using (subContext db = new subContext())
         {
            IQueryable<DcProduct> DcProducts = db.DcProducts;
            CriteriaToExpressionConverter converter = new CriteriaToExpressionConverter();
            IQueryable<DcProduct> filteredData = DcProducts.AppendWhere(new CriteriaToExpressionConverter(), filterCriteria) as IQueryable<DcProduct>;

            //filteredData = filteredData.Take(100);

            IQueryable<DcProduct> dcProducts = filteredData.Where(x => x.ProductTypeCode == productTypeCode)
                            .Include(x => x.TrInvoiceLines)
                                .ThenInclude(l => l.TrInvoiceHeader)
                            .OrderBy(x => x.ProductDesc)
                            .Select(x => new DcProduct
                            {
                               Balance = x.TrInvoiceLines.Sum(l => l.QtyIn - l.QtyOut),
                               BalanceM = x.TrInvoiceLines.Where(l => l.TrInvoiceHeader.WarehouseCode == "depo-01").Sum(l => l.QtyIn - l.QtyOut),
                               BalanceF = x.TrInvoiceLines.Where(l => l.TrInvoiceHeader.WarehouseCode == "depo-02").Sum(l => l.QtyIn - l.QtyOut),
                               LastPurchasePrice = x.TrInvoiceLines.Where(l => l.TrInvoiceHeader.ProcessCode == "RP" || l.TrInvoiceHeader.ProcessCode == "CI").OrderByDescending(l => l.TrInvoiceHeader.DocumentDate).ThenByDescending(l => l.TrInvoiceHeader.DocumentTime).Select(x => x.PriceLoc - (x.PriceLoc * x.PosDiscount / 100)).FirstOrDefault(),
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
                            });


            return dcProducts.ToList();
         }
      }

      public List<TrInvoiceHeader> SelectInvoiceHeaders()
      {
         using (subContext db = new subContext())
         {
            return db.TrInvoiceHeaders.Where(x => x.IsCompleted == true)
                                      .OrderBy(x => x.CreatedDate)
                                      .ToList();
         }
      }

      public TrInvoiceHeader SelectInvoiceHeader(Guid invoiceHeaderId)
      {
         using (subContext db = new subContext())
         {
            return db.TrInvoiceHeaders.Include(x => x.DcCurrAcc)
                                      .Include(x => x.TrInvoiceLines)
                                      .Where(x => x.InvoiceHeaderId == invoiceHeaderId)
                                      .FirstOrDefault();
         }
      }

      public TrPaymentHeader SelectPaymentHeader(Guid paymentHeaderId)
      {
         using (subContext db = new subContext())
         {
            return db.TrPaymentHeaders.Include(x => x.DcCurrAcc)
                                      .Include(x => x.TrPaymentLines)
                                      .Where(x => x.PaymentHeaderId == paymentHeaderId)
                                      .FirstOrDefault();
         }
      }

      public List<TrInvoiceHeader> SelectInvoiceHeadersByProcessCode(string processCode)
      {
         using (subContext db = new subContext())
         {
            return db.TrInvoiceHeaders.Where(x => x.ProcessCode == processCode)
                                      .OrderBy(x => x.CreatedDate)
                                      .ToList();
         }
      }

      public TrInvoiceLine SelectInvoiceLine(Guid invoiceLineId)
      {
         using (subContext db = new subContext())
         {
            return db.TrInvoiceLines.Include(x => x.TrInvoiceHeader)
                                    .FirstOrDefault(x => x.InvoiceLineId == invoiceLineId);
         }
      }

      public List<TrInvoiceLine> SelectInvoiceLineForReport(Guid invoiceHeaderId)
      {
         using (subContext db = new subContext())
         {
            return db.TrInvoiceLines.Include(x => x.TrInvoiceHeader)
                                        .ThenInclude(x => x.DcCurrAcc)
                                    .Include(x => x.DcProduct)
                                    .Where(x => x.InvoiceHeaderId == invoiceHeaderId)
                                    .OrderBy(x => x.CreatedDate)
                                    .ToList();
         }
      }

      public int InsertInvoiceLine(DcProduct dcProduct, Guid invoiceHeaderId)
      {
         using (subContext db = new subContext())
         {
            IQueryable<DcProduct> dcProducts = db.DcProducts.AsQueryable();

            if (!string.IsNullOrEmpty(dcProduct.ProductCode))
               dcProducts = dcProducts.Where(x => x.ProductCode == dcProduct.ProductCode);
            else if (!string.IsNullOrEmpty(dcProduct.Barcode))
               dcProducts = dcProducts.Where(x => x.Barcode == dcProduct.Barcode);

            DcProduct product = dcProducts.FirstOrDefault();

            if (product != null)
            {
               TrInvoiceLine trInvoiceLine = new TrInvoiceLine()
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
      }

      public int InsertInvoiceLine(TrInvoiceLine TrInvoiceLine)
      {
         using (subContext db = new subContext())
         {
            db.TrInvoiceLines.Add(TrInvoiceLine);
            return db.SaveChanges();
         }
      }

      public bool InvoiceLineExistByRelatedLine(Guid invoicecHeaderId, Guid relatedLineId)
      {
         using (subContext db = new subContext())
         {
            return db.TrInvoiceLines.Where(x => x.InvoiceHeaderId == invoicecHeaderId)
                                    .Any(x => x.RelatedLineId == relatedLineId);
         }
      }

      public bool InvoiceHeaderExist(Guid invoiceHeaderId)
      {
         using (subContext db = new subContext())
         {
            return db.TrInvoiceHeaders.Any(x => x.InvoiceHeaderId == invoiceHeaderId);
         }
      }

      public void InsertInvoiceHeader(TrInvoiceHeader TrInvoiceHeader)
      {
         using (subContext db = new subContext())
         {
            db.TrInvoiceHeaders.Add(TrInvoiceHeader);
            db.SaveChanges();
         }
      }

      public int DeleteInvoice(Guid invoiceHeaderId)
      {
         using (subContext db = new subContext())
         {
            string editable = invoiceHeaderId.ToString();
            Guid transferHead = Guid.Parse(editable.Replace(editable.Substring(0, 8), "00000000")); // 00000000-ED42-11CE-BACD-00AA0057B223

            TrInvoiceHeader trInvoiceHeader = new TrInvoiceHeader() { InvoiceHeaderId = invoiceHeaderId };
            db.TrInvoiceHeaders.Remove(trInvoiceHeader);

            TrInvoiceHeader transferHeader = db.TrInvoiceHeaders.FirstOrDefault(x => x.InvoiceHeaderId == transferHead);
            if (!Object.ReferenceEquals(transferHeader, null))
               db.TrInvoiceHeaders.Remove(transferHeader);


            IQueryable<TrInvoiceLine> trInvoiceLine = db.TrInvoiceLines.Where(x => x.InvoiceHeaderId == invoiceHeaderId);
            if (trInvoiceLine.Any())
               db.TrInvoiceLines.Remove(trInvoiceLine.First());

            return db.SaveChanges();
         }
      }

      public int DeletePayment(Guid paymentHeaderId)
      {
         using (subContext db = new subContext())
         {
            TrPaymentHeader trPaymentHeader = db.TrPaymentHeaders.Where(x => x.PaymentHeaderId == paymentHeaderId)
                                                                 .FirstOrDefault();
            if (!object.ReferenceEquals(trPaymentHeader, null))
               db.TrPaymentHeaders.Remove(trPaymentHeader);

            return db.SaveChanges();
         }
      }

      public int DeletePaymentByInvoice(Guid invoiceHeaderId)
      {
         using (subContext db = new subContext())
         {
            List<TrPaymentHeader> trPaymentHeaders = db.TrPaymentHeaders.Where(x => x.InvoiceHeaderId == invoiceHeaderId)
                                                                        .ToList();
            if (!object.ReferenceEquals(trPaymentHeaders, null))
               db.TrPaymentHeaders.RemoveRange(trPaymentHeaders);

            int result = db.SaveChanges();
            return result;
         }
      }

      public int DeleteInvoiceLine(object invoiceLineId)
      {
         using (subContext db = new subContext())
         {
            TrInvoiceLine trInvoiceLine = new TrInvoiceLine() { InvoiceLineId = Guid.Parse(invoiceLineId.ToString()) };
            db.TrInvoiceLines.Remove(trInvoiceLine);
            return db.SaveChanges();
         }
      }

      public int DeleteReport(int ReportId)
      {
         using (subContext db = new subContext())
         {
            DcReport dcReport = new DcReport() { ReportId = ReportId };
            db.DcReports.Remove(dcReport);
            return db.SaveChanges();
         }
      }

      public int UpdateInvoiceIsCompleted(Guid invoiceHeaderId)
      {
         using (subContext db = new subContext())
         {
            TrInvoiceHeader trInvoiceHeader = new TrInvoiceHeader() { InvoiceHeaderId = invoiceHeaderId, IsCompleted = true };
            db.Entry(trInvoiceHeader).Property(x => x.IsCompleted).IsModified = true;
            return db.SaveChanges();
         }
      }

      public int UpdateInvoiceLineQtyOut(object invoiceLineId, int qtyOut)
      {
         Guid variable = Guid.Parse(invoiceLineId.ToString());

         using (subContext db = new subContext())
         {
            TrInvoiceLine trInvoiceLine = db.TrInvoiceLines.FirstOrDefault(x => x.InvoiceLineId == variable);

            trInvoiceLine.PosDiscount = qtyOut * (trInvoiceLine.PosDiscount / trInvoiceLine.QtyOut); // qty is new quantity trInvoiceLine.Qty is old quantity
            trInvoiceLine.Amount = qtyOut * Convert.ToDecimal(trInvoiceLine.Price);
            trInvoiceLine.NetAmount = trInvoiceLine.Amount - trInvoiceLine.PosDiscount;
            trInvoiceLine.QtyOut = qtyOut;

            db.TrInvoiceLines.Update(trInvoiceLine);
            return db.SaveChanges();
         }
      }

      public int UpdateInvoiceLineQtyOut(object invoiceHeaderId, object relatedLineId, int qtyOut)
      {
         Guid HeaderId = Guid.Parse(invoiceHeaderId.ToString());
         Guid relatedId = Guid.Parse(relatedLineId.ToString());

         using (subContext db = new subContext())
         {
            TrInvoiceLine trInvoiceLine = db.TrInvoiceLines.Where(x => x.RelatedLineId == relatedId)
                                               .FirstOrDefault(x => x.InvoiceHeaderId == HeaderId);

            trInvoiceLine.PosDiscount = qtyOut * (trInvoiceLine.PosDiscount / trInvoiceLine.QtyOut); // qty is new quantity trInvoiceLine.Qty is old quantity
            trInvoiceLine.Amount = qtyOut * Convert.ToDecimal(trInvoiceLine.Price);
            trInvoiceLine.NetAmount = trInvoiceLine.Amount - trInvoiceLine.PosDiscount;
            trInvoiceLine.QtyOut = qtyOut;

            db.TrInvoiceLines.Update(trInvoiceLine);
            return db.SaveChanges();
         }
      }

      public int UpdateInvoicePosDiscount(TrInvoiceLine trInvoiceLine)
      {
         using (subContext db = new subContext())
         {
            //db.TrInvoiceLine.Attach(TrInvoiceLine);
            db.Entry(trInvoiceLine).Property(x => x.PosDiscount).IsModified = true;
            db.Entry(trInvoiceLine).Property(x => x.NetAmount).IsModified = true;
            return db.SaveChanges();
         }
      }

      public int UpdateInvoiceCurrAccCode(Guid invoiceHeaderId, string currAccCode)
      {
         using (subContext db = new subContext())
         {
            TrInvoiceHeader trInvoiceHeader = new TrInvoiceHeader() { InvoiceHeaderId = invoiceHeaderId, CurrAccCode = currAccCode };
            db.Entry(trInvoiceHeader).Property(x => x.CurrAccCode).IsModified = true;
            return db.SaveChanges();
         }
      }

      public int UpdatePaymentsCurrAccCode(Guid invoiceHeaderId, string currAccCode)
      {
         using (subContext db = new subContext())
         {
            List<TrPaymentHeader> trPaymentHeaders = SelectPaymentHeaders(invoiceHeaderId);

            foreach (TrPaymentHeader entity in trPaymentHeaders)
            {
               entity.CurrAccCode = currAccCode;
               db.Entry(entity).Property(x => x.CurrAccCode).IsModified = true;
            }

            return db.SaveChanges();
         }
      }

      public int UpdateInvoiceSalesPerson(Guid invoiceLineId, string currAccCode)
      {
         using (subContext db = new subContext())
         {
            TrInvoiceLine trInvoiceLine = new TrInvoiceLine() { InvoiceLineId = invoiceLineId, SalesPersonCode = currAccCode };
            db.Entry(trInvoiceLine).Property(x => x.SalesPersonCode).IsModified = true;
            return db.SaveChanges();
         }
      }

      public int InsertCustomer(DcCurrAcc dcCurrAcc)
      {
         using (subContext db = new subContext())
         {
            db.DcCurrAccs.Add(dcCurrAcc);
            return db.SaveChanges();
         }
      }

      public bool CustomerExist(string CurrAccCode)
      {
         using (subContext db = new subContext())
         {
            return db.DcCurrAccs.Any(x => x.CurrAccCode == CurrAccCode);
         }
      }

      public int UpdateCustomer(DcCurrAcc dcCurrAcc)
      {
         using (subContext db = new subContext())
         {
            db.DcCurrAccs.Update(dcCurrAcc);
            return db.SaveChanges();
         }
      }

      public int InsertPaymentHeader(TrPaymentHeader trPaymentHeader)
      {
         using (subContext db = new subContext())
         {
            db.TrPaymentHeaders.Add(trPaymentHeader);
            return db.SaveChanges();
         }
      }

      public int InsertPaymentLine(TrPaymentLine trPaymentLine)
      {
         using (subContext db = new subContext())
         {
            db.TrPaymentLines.Add(trPaymentLine);
            return db.SaveChanges();
         }
      }

      public bool PaymentHeaderExist(Guid paymentHeaderId)
      {
         using (subContext db = new subContext())
         {
            return db.TrPaymentHeaders.Any(x => x.PaymentHeaderId == paymentHeaderId);
         }
      }

      public List<TrPaymentLine> SelectPaymentLines(Guid paymentHeaderId)
      {
         using (subContext db = new subContext())
         {
            return db.TrPaymentLines.Include(x => x.TrPaymentHeader)
                                    .Include(x => x.DcPaymentType)
                                    .Where(x => x.TrPaymentHeader.PaymentHeaderId == paymentHeaderId)
                                    .ToList();
         }
      }

      public List<TrPaymentLine> SelectPaymentLinesByInvoice(Guid invoiceHeaderId)
      {
         using (subContext db = new subContext())
         {
            return db.TrPaymentLines.Include(x => x.TrPaymentHeader)
                                    //.ThenInclude(x => x.TrInvoiceHeader)
                                    .Include(x => x.DcPaymentType)
                                    .Where(x => x.TrPaymentHeader.InvoiceHeaderId == invoiceHeaderId)
                                    .ToList();
         }
      }

      public List<TrPaymentHeader> SelectPaymentHeaders(Guid invoiceHeaderId)
      {
         using (subContext db = new subContext())
         {
            return db.TrPaymentHeaders.Where(x => x.InvoiceHeaderId == invoiceHeaderId)
                                    .ToList();
         }
      }

      public decimal SelectPaymentLinesSum(Guid invoiceHeaderId)
      {
         using (subContext db = new subContext())
         {
            return db.TrPaymentLines.Include(x => x.TrPaymentHeader)
                                    .Where(x => x.TrPaymentHeader.InvoiceHeaderId == invoiceHeaderId)
                                    .Sum(s => s.PaymentLoc);
         }
      }

      public List<DcCurrAcc> SelectCurrAccs()
      {
         using (subContext db = new subContext())
         {
            return db.DcCurrAccs.Where(x => x.IsDisabled == false)
                                .OrderBy(x => x.CreatedDate)
                                .Select(x => new DcCurrAcc
                                {
                                   Balance = db.TrInvoiceLines.Include(l => l.TrInvoiceHeader).Where(l => l.TrInvoiceHeader.CurrAccCode == x.CurrAccCode).Sum(s => (s.QtyIn - s.QtyOut) * (s.PriceLoc - (s.PriceLoc * s.PosDiscount / 100)))
                                   + db.TrPaymentLines.Include(l => l.TrPaymentHeader).Where(l => l.TrPaymentHeader.CurrAccCode == x.CurrAccCode).Sum(s => s.PaymentLoc),
                                   CurrAccCode = x.CurrAccCode,
                                   CurrAccDesc = x.CurrAccDesc,
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
                                })
                                .ToList(); // burdaki kolonlari dizaynda da elave et
         }
      }

      public List<DcCurrAcc> SelectCurrAccsByType(byte currAccTypeCode)
      {
         using (subContext db = new subContext())
         {
            return db.DcCurrAccs.Where(x => x.IsDisabled == false && x.CurrAccTypeCode == currAccTypeCode)
                                .OrderBy(x => x.CreatedDate)
                                .ToList(); // burdaki kolonlari dizaynda da elave et
         }
      }

      public DcCurrAcc SelectCurrAcc(string currAccCode)
      {
         using (subContext db = new subContext())
         {
            return db.DcCurrAccs.Where(x => x.IsDisabled == false)
                                .FirstOrDefault(x => x.CurrAccCode == currAccCode);
         }
      }

      public decimal SelectCurrAccBalance(string currAccCode, DateTime documentDate)
      {
         using (subContext db = new subContext())
         {
            decimal invoiceSum = db.TrInvoiceLines.Include(x => x.TrInvoiceHeader)
                                       .Where(x => x.TrInvoiceHeader.CurrAccCode == currAccCode && x.TrInvoiceHeader.DocumentDate <= documentDate)
                                       .Sum(x => (x.QtyIn - x.QtyOut) * (x.PriceLoc - (x.PriceLoc * x.PosDiscount / 100)));

            decimal paymentSum = db.TrPaymentLines.Include(x => x.TrPaymentHeader)
                                       .Where(x => x.TrPaymentHeader.CurrAccCode == currAccCode && x.TrPaymentHeader.OperationDate <= documentDate)
                                       .Sum(x => x.PaymentLoc);

            return invoiceSum + paymentSum;
         }
      }

      public decimal SelectPaymentSum(string currAccCode, string docNum)
      {
         using (subContext db = new subContext())
         {
            return db.TrPaymentLines.Include(x => x.TrPaymentHeader)
                                    .Where(x => x.TrPaymentHeader.CurrAccCode == currAccCode && x.TrPaymentHeader.DocumentNumber == docNum)
                                    .Sum(x => x.PaymentLoc);
         }
      }

      public decimal SelectInvoiceSum(string currAccCode, string docNum)
      {
         using (subContext db = new subContext())
         {
            return db.TrInvoiceLines.Include(x => x.TrInvoiceHeader)
                                    .Where(x => x.TrInvoiceHeader.CurrAccCode == currAccCode && x.TrInvoiceHeader.DocumentNumber == docNum)
                                    .Sum(x => (x.QtyIn - x.QtyOut) * x.PriceLoc);
         }
      }

      public List<DcOffice> SelectOffices()
      {
         using (subContext db = new subContext())
         {
            return db.DcOffices.Where(x => x.IsDisabled == false)
                               .OrderBy(x => x.CreatedDate)
                               .ToList(); // burdaki kolonlari dizaynda da elave et
         }
      }

      public DcProcess SelectProcess(string processCode)
      {
         using (subContext db = new subContext())
         {
            DcProcess dcProcess = db.DcProcesses.Where(x => x.ProcessCode == processCode)
                               .FirstOrDefault();
            return dcProcess; ;
         }
      }

      public List<DcCurrency> SelectCurrencies()
      {
         using (subContext db = new subContext())
         {
            return db.DcCurrencies.ToList(); // burdaki kolonlari dizaynda da elave et
         }
      }

      public List<DcPaymentType> SelectPaymentTypes()
      {
         using (subContext db = new subContext())
         {
            return db.DcPaymentTypes.ToList(); // burdaki kolonlari dizaynda da elave et
         }
      }

      public float SelectExRate(string currancyCode)
      {
         using (subContext db = new subContext())
         {
            DcCurrency dcCurrency = db.DcCurrencies.Where(x => x.CurrencyCode == currancyCode)
                                                   .FirstOrDefault();
            return dcCurrency.ExchangeRate;
         }
      }

      public List<DcCurrAcc> SelectStores()
      {
         using (subContext db = new subContext())
         {
            return db.DcCurrAccs.Where(x => x.IsDisabled == false)
                                .Where(x => x.CurrAccTypeCode == 4)
                                .OrderBy(x => x.CreatedDate)
                                .ToList(); // burdaki kolonlari dizaynda da elave et
         }
      }

      public List<DcWarehouse> SelectWarehouses()
      {
         using (subContext db = new subContext())
         {
            return db.DcWarehouses.Where(x => x.IsDisabled == false)
                                  .OrderBy(x => x.CreatedDate)
                                  .ToList(); // burdaki kolonlari dizaynda da elave et
         }
      }

      public string SelectWarehouseByStore(string storeCode)
      {
         using (subContext db = new subContext())
         {
            return db.DcWarehouses.Where(x => x.IsDisabled == false && x.IsDefault == true)
                                  .FirstOrDefault(x => x.StoreCode == storeCode).WarehouseCode; // burdaki kolonlari dizaynda da elave et
         }
      }

      public bool Login(string CurrAccCode, string Password)
      {
         if (string.IsNullOrEmpty(Password.Trim()))
            return false;
         else
         {
            using (subContext db = new subContext())
            {
               return db.DcCurrAccs.Where(x => x.IsDisabled == false)
                                   .Where(x => x.CurrAccCode == CurrAccCode)
                                   .Any(x => x.NewPassword == Password);
            }
         }
      }

      public bool CurrAccExist(string CurrAccCode)
      {

         using (subContext db = new subContext())
         {
            return db.DcCurrAccs.Where(x => x.IsDisabled == false)
                                .Any(x => x.CurrAccCode == CurrAccCode);
         }
      }

      public bool ReportExist(int Id)
      {

         using (subContext db = new subContext())
         {
            return db.DcReports.Any(x => x.ReportId == Id);
         }
      }

      public bool ProductExist(string productCode)
      {
         using (subContext db = new subContext())
         {
            return db.DcProducts.Where(x => x.IsDisabled == false)
                                .Any(x => x.ProductCode == productCode);
         }
      }

      public void InsertCurrAcc(DcCurrAcc dcCurrAcc)
      {
         using (subContext db = new subContext())
         {
            db.DcCurrAccs.Add(dcCurrAcc);
            db.SaveChanges();
         }
      }

      public void InsertProduct(DcProduct dcProduct)
      {
         using (subContext db = new subContext())
         {
            db.DcProducts.Add(dcProduct);
            db.SaveChanges();
         }
      }

      public List<DcRole> SelectRoles(string CurrAccCode)
      {
         using (subContext db = new subContext())
         {
            return db.DcRoles.Include(x => x.TrCurrAccRoles)
                                .ThenInclude(x => x.DcCurrAcc)
                             .Where(o => o.TrCurrAccRoles.Any(x => x.CurrAccCode == CurrAccCode))
                             .ToList();
         }
      }

      public string SelectOfficeCode(string CurrAccCode)
      {
         using (subContext db = new subContext())
         {
            DcCurrAcc currAcc = db.DcCurrAccs.Where(x => x.CurrAccCode == CurrAccCode)
                                             .FirstOrDefault();

            return currAcc.OfficeCode;
         }
      }

      public string SelectStoreCode(string CurrAccCode)
      {
         using (subContext db = new subContext())
         {
            DcCurrAcc currAcc = db.DcCurrAccs.Where(x => x.CurrAccCode == CurrAccCode)
                                             .FirstOrDefault();
            return currAcc.StoreCode;
         }
      }

      public int UpdateReportLayout(int id, string reportLayout)
      {
         using (subContext db = new subContext())
         {
            DcReport dcReport = new DcReport() { ReportId = id, ReportLayout = reportLayout };
            db.Entry(dcReport).Property(x => x.ReportLayout).IsModified = true;
            return db.SaveChanges();
         }
      }

      public DcReport SelectReport(int id)
      {
         using (subContext db = new subContext())
         {
            return db.DcReports.Include(x => x.DcReportFilters).FirstOrDefault(x => x.ReportId == id);
         }
      }

      public List<DcReport> SelectReports()
      {
         using (subContext db = new subContext())
         {
            return db.DcReports.ToList();
         }
      }

      public int UpdateDcReport_Filter(int id, string reportFilter)
      {
         using (subContext db = new subContext())
         {
            DcReport dcReport = new DcReport() { ReportId = id, ReportFilter = reportFilter };
            db.Entry(dcReport).Property(x => x.ReportFilter).IsModified = true;
            return db.SaveChanges();
         }
      }

      public int UpdateDcReportFilter_Value(int ReportId, string fieldName, string filterValue)
      {
         using (subContext db = new subContext())
         {
            DcReportFilter dcReport = db.DcReportFilters.Where(x => x.FilterProperty == fieldName).FirstOrDefault(x => x.ReportId == ReportId);
            dcReport.FilterValue = filterValue;
            db.Entry(dcReport).Property(x => x.FilterValue).IsModified = true;
            return db.SaveChanges();
         }
      }

      public int UpdateReportFilter(string prop, string value)
      {
         using (subContext db = new subContext())
         {
            DcReportFilter dcReportFilter = db.DcReportFilters.FirstOrDefault(x => x.FilterProperty == prop);
            dcReportFilter.FilterValue = value;

            db.Entry(dcReportFilter).Property(x => x.FilterValue).IsModified = true;
            return db.SaveChanges();
         }
      }



      public void InsertReport(DcReport dcReport)
      {
         using (subContext db = new subContext())
         {
            db.DcReports.Add(dcReport);
            db.SaveChanges();
         }
      }

      public int UpdateAppSettingGridViewLayout(string layout)
      {
         using (subContext db = new subContext())
         {
            AppSetting appSetting = new AppSetting() { Id = 1, GridViewLayout = layout };
            db.Entry(appSetting).Property(x => x.GridViewLayout).IsModified = true;
            return db.SaveChanges();
         }
      }

      public AppSetting SelectAppSetting()
      {
         using (subContext db = new subContext())
         {
            return db.AppSettings.Find(1);
         }
      }
   }
}