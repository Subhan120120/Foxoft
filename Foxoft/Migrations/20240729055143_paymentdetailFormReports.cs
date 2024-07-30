using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Foxoft.Migrations
{
    /// <inheritdoc />
    public partial class paymentdetailFormReports : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "DcForms",
                columns: new[] { "FormCode", "FormDesc" },
                values: new object[] { "PaymentDetails", "Payment Details" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DcForms",
                keyColumn: "FormCode",
                keyValue: "PaymentDetails");

            migrationBuilder.UpdateData(
                table: "DcReports",
                keyColumn: "ReportId",
                keyValue: 4,
                column: "ReportQuery",
                value: "\r\n--Declare @invoiceHeader nvarchar(50) = 'dd6927e4-d33c-4dc7-929c-1410c299e0a9'\r\n\r\n	select  InvoiceLineId\r\n			,	[Marka] = isnull(' ' +  Feature02Desc,'')\r\n		  , [Ceki] = isnull(' ' + Feature04Desc,'')\r\n		  , [Reng] = isnull(' ' + Feature05Desc,'')\r\n		  , [Məhsul Tipi] = isnull(' ' + Feature06Desc,'')\r\n		  , [Soyutma Tipi] = isnull(' ' + Feature07Desc,'')\r\n		  , [BTU] = isnull(' ' + Feature09Desc,'')\r\n		  , [Ekran Ölçüsü] = isnull(' ' + Feature10Desc,'')\r\n		  , [Ekran İcazəsi] = isnull(' ' + Feature11Desc,'')\r\n		  , [Motorun Növü] = isnull(' ' + Feature12Desc,'')\r\n		  , [Həcmi] = isnull(' ' + Feature13Desc,'')\r\n		  , [Soyuducu Kameranın Həcmi] = isnull(' ' + Feature14Desc,'')\r\n		  , [Dondurucu Kameranın Həcmi] = isnull(' ' + Feature15Desc,'')\r\n		  , [Istehsalçı Ölkə] = isnull(' ' + Feature16Desc,'')\r\n		  , [Məhsuldarlıq] = isnull(' ' + Feature17Desc,'')\r\n		  , [Güc] = isnull(' ' + Feature18Desc,'')\r\n		  , [Tərtib Edən İstifadəçi] =( select CurrAccDesc from DcCurrAccs where CurrAccCode = TrInvoiceHeaders.CreatedUserName)\r\n	, TrInvoiceHeaders.InvoiceHeaderId\r\n	, DcProducts.ProductCode\r\n	, ProductDesc\r\n	, QtyIn = QtyIn\r\n	, QtyOut = QtyOut\r\n	, Price\r\n	, TrInvoiceLines.PosDiscount\r\n	, TrInvoiceHeaders.ProcessCode\r\n	, ProcessDesc\r\n	, TrInvoiceLines.CurrencyCode\r\n	, DcProducts.HierarchyCode\r\n	, HierarchyDesc\r\n	, IsReturn\r\n	, CustomsDocumentNumber\r\n	, PrintCount\r\n	, NetAmount\r\n	, LineDescription\r\n	, PriceLoc\r\n	, TrInvoiceLines.ExchangeRate\r\n	, NetAmountLoc = (QtyIn-QtyOut) * PriceLoc * (100 - TrInvoiceLines.PosDiscount) / 100\r\n	, DocumentNumber\r\n	, DocumentDate\r\n	, DocumentTime\r\n	, DcCurrAccs.CurrAccCode\r\n	, DcCurrAccs.CurrAccDesc\r\n	, FirstName\r\n	, PhoneNum\r\n	, HeaderCreatedDate = TrInvoiceHeaders.CreatedDate\r\n	, LineCreatedDate = TrInvoiceLines.CreatedDate\r\n	, TrInvoiceHeaders.CreatedUserName\r\n	, CurrAccBalance = dbo.CurrAccBalance(TrInvoiceHeaders.CurrAccCode, DocumentDate)\r\n	, BalanceCode = 'M' + Convert(nvarchar, Format((select SUM(QtyIn - QtyOut) ProductBalance\r\n						from TrInvoiceLines il \r\n						left join TrInvoiceHeaders ih on il.InvoiceHeaderId = ih.InvoiceHeaderId\r\n						where il.ProductCode = TrInvoiceLines.ProductCode and WarehouseCode = TrInvoiceHeaders.WarehouseCode),'000'))\r\n	, TrInvoiceHeaders.WarehouseCode\r\n	, TrInvoiceHeaders.ToWarehouseCode\r\n	, [Depodan] = wareIn.WarehouseDesc\r\n	, [Depoya] = wareOut.WarehouseDesc\r\n	, Description\r\n	, TrInvoiceHeaders.StoreCode\r\n	, PaymentLoc = ISNULL((	select sum(PaymentLoc) from TrPaymentLines pl \r\n							join TrPaymentHeaders ph on pl.PaymentHeaderId = ph.PaymentHeaderId\r\n							where ph.InvoiceHeaderId = TrInvoiceHeaders.InvoiceHeaderId), 0)\r\n	, ProductCost\r\n	from TrInvoiceLines\r\n\r\n	join TrInvoiceHeaders on TrInvoiceLines.InvoiceHeaderId = TrInvoiceHeaders.InvoiceHeaderId\r\n	left join DcCurrAccs on TrInvoiceHeaders.CurrAccCode = DcCurrAccs.CurrAccCode\r\n	left join DcProducts on TrInvoiceLines.ProductCode = DcProducts.ProductCode\r\n	left join DcProcesses on TrInvoiceHeaders.ProcessCode = DcProcesses.ProcessCode\r\n	left join DcHierarchies on DcHierarchies.HierarchyCode = DcProducts.HierarchyCode\r\n	left join DcCurrencies on DcCurrencies.CurrencyCode = TrInvoiceLines.CurrencyCode\r\n	left join DcWarehouses wareIn on wareIn.WarehouseCode = TrInvoiceHeaders.WarehouseCode\r\n	left join DcWarehouses wareOut on wareOut.WarehouseCode = TrInvoiceHeaders.ToWarehouseCode\r\n	left join ProductFeatures on ProductFeatures.ProductCode = DcProducts.ProductCode\r\n\r\n	where TrInvoiceHeaders.InvoiceHeaderId = @invoiceHeader\r\n\r\n\r\n	order by TrInvoiceLines.CreatedDate\r\n\r\n\r\n");
        }
    }
}
