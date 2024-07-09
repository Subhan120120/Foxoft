using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Foxoft.Migrations
{
    /// <inheritdoc />
    public partial class RetailSales : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.Sql(@"CREATE OR ALTER VIEW RetailSales AS 
									select  TrInvoiceHeaders.InvoiceHeaderId
										, InvoiceLineId
										, DcOffices.OfficeCode
										, DcOffices.OfficeDesc
										, TrInvoiceHeaders.StoreCode
										, StoreDesc = DcStores.CurrAccDesc
										, DcWarehouses.WarehouseCode
										, WarehouseDesc
										, DcProcesses.ProcessCode
										, ProcessDesc
										, DocumentNumber
										, IsReturn
										, DocumentDate
										, DocumentTime
										, OperationDate
										, OperationTime
										, DcCurrAccs.CurrAccCode
										, DcCurrAccs.CurrAccDesc
										, DcCurrAccs.FirstName
										, DcCurrAccs.PhoneNum
										, ProductDesc
										--, CurrAccBalance = ((select Sum(NetAmount) from TrInvoiceLines il 
										--					join TrInvoiceHeaders as ih on ih.InvoiceHeaderId = il.InvoiceHeaderId 
										--					where ih.CurrAccCode = TrInvoiceHeaders.CurrAccCode) 
										--					- (select isnull(Sum(Payment), 0)/ 1.703 from TrPaymentLines pl 
										--					join TrPaymentHeaders as ph on ph.PaymentHeaderId = pl.PaymentHeaderId 
										--					where ph.CurrAccCode = TrInvoiceHeaders.CurrAccCode)), DcProducts.ProductCode
										--, ProductBalance = (select SUM(CASE WHEN ih.IsReturn = 0 THEN (QtyIn - QtyOut) ELSE (QtyIn - QtyOut) * (-1) END) ProductBalance
										--					from TrInvoiceLines il 
										--					left join TrInvoiceHeaders ih on il.InvoiceHeaderId = ih.InvoiceHeaderId
										--					where il.ProductCode = TrInvoiceLines.ProductCode)
										, Qty = CASE WHEN IsReturn = 0 THEN QtyIn - QtyOut ELSE (QtyIn - QtyOut) * (-1) END
										, Price
										, TrInvoiceLines.PosDiscount
										, CurrencyCode
										, ExchangeRate
										, Amount = CASE WHEN IsReturn = 0 THEN Amount ELSE (Amount) * (-1) END
										, NetAmount = CASE WHEN IsReturn = 0 THEN NetAmount ELSE NetAmount * (-1) END
										, PriceLoc = CASE WHEN IsReturn = 0 THEN PriceLoc ELSE PriceLoc * (-1) END
										, AmountLoc = CASE WHEN IsReturn = 0 THEN AmountLoc ELSE AmountLoc * (-1) END
										, NetAmountLoc = CASE WHEN IsReturn = 0 THEN NetAmountLoc ELSE NetAmountLoc * (-1) END
										, SalesPersonCode
										, SalesPersonDesc = sp.FirstName
										, LineDescription
										, TrInvoiceLines.CreatedDate
										, TrInvoiceLines.CreatedUserName
										, TrInvoiceLines.LastUpdatedDate
										, TrInvoiceLines.LastUpdatedUserName
										, TrInvoiceLines.RelatedLineId
									from TrInvoiceLines
									
									join TrInvoiceHeaders on TrInvoiceLines.InvoiceHeaderId = TrInvoiceHeaders.InvoiceHeaderId
									left join DcCurrAccs on TrInvoiceHeaders.CurrAccCode = DcCurrAccs.CurrAccCode
									left join DcCurrAccs sp on TrInvoiceLines.SalesPersonCode = sp.CurrAccCode
									left join DcProducts on TrInvoiceLines.ProductCode = DcProducts.ProductCode
									left join DcProcesses on TrInvoiceHeaders.ProcessCode = DcProcesses.ProcessCode
									left join DcCurrAccs as DcStores on TrInvoiceHeaders.StoreCode = DcStores.StoreCode
									left join DcWarehouses on TrInvoiceHeaders.WarehouseCode = DcWarehouses.WarehouseCode
									left join DcOffices on TrInvoiceHeaders.OfficeCode = DcOffices.OfficeCode
									
									where TrInvoiceHeaders.ProcessCode = 'RS'");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
