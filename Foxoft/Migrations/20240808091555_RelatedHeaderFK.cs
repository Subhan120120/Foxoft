using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Foxoft.Migrations
{
    /// <inheritdoc />
    public partial class RelatedHeaderFK : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_TrInvoiceHeaders_RelatedInvoiceId",
                table: "TrInvoiceHeaders",
                column: "RelatedInvoiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_TrInvoiceHeaders_TrInvoiceHeaders_RelatedInvoiceId",
                table: "TrInvoiceHeaders",
                column: "RelatedInvoiceId",
                principalTable: "TrInvoiceHeaders",
                principalColumn: "InvoiceHeaderId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrInvoiceHeaders_TrInvoiceHeaders_RelatedInvoiceId",
                table: "TrInvoiceHeaders");

            migrationBuilder.DropIndex(
                name: "IX_TrInvoiceHeaders_RelatedInvoiceId",
                table: "TrInvoiceHeaders");

            migrationBuilder.UpdateData(
                table: "DcReports",
                keyColumn: "ReportId",
                keyValue: 13,
                column: "ReportQuery",
                value: "\r\n\r\n\r\nselect 	CurrAccDesc\r\n	--, ProductDesc\r\n	, NetAmountLoc\r\n	, PaymentLoc\r\n	, [Ara Toplam] = sum(Summary) OVER (ORDER BY DocumentDate, DocumentTime )\r\n	, ProcessDesc\r\n	, DocumentNumber\r\n	, CurrAccCode\r\n	, DocumentDate\r\n	, DocumentTime\r\n	, InvoiceHeaderId\r\n	, PaymentHeaderId\r\n	, LineDescription\r\n	, IsReturn\r\n	, StoreCode\r\n	--, LineId\r\nfrom (\r\n	select FirstName\r\n	, CurrAccDesc\r\n	--, ProductDesc\r\n	, TrInvoiceHeaders.InvoiceHeaderId\r\n	, PaymentHeaderId = cast(cast(0 as binary) as uniqueidentifier)\r\n	, NetAmountLoc = sum((QtyIn - QtyOut) * (PriceLoc * (100 - PosDiscount) / 100))  -- (-2) * 100 = -200 usd\r\n	, PaymentLoc= 0\r\n	, Summary = sum((QtyIn - QtyOut) * (PriceLoc * (100 - PosDiscount) / 100))  -- (-2) * 100 = -200 usd\r\n	, ProcessDesc = ProcessDesc\r\n	, DocumentNumber\r\n	, TrInvoiceHeaders.StoreCode\r\n	, TrInvoiceHeaders.CurrAccCode\r\n	, TrInvoiceHeaders.DocumentDate\r\n	, TrInvoiceHeaders.DocumentTime\r\n	, LineDescription = TrInvoiceHeaders.Description\r\n	, TrInvoiceHeaders.ProcessCode\r\n	, IsReturn\r\n	--, LineId = InvoiceLineId\r\n	from TrInvoiceLines \r\n	left join TrInvoiceHeaders on TrInvoiceLines.InvoiceHeaderId = TrInvoiceHeaders.InvoiceHeaderId\r\n	left join DcCurrAccs on TrInvoiceHeaders.CurrAccCode = DcCurrAccs.CurrAccCode\r\n	left join DcProcesses on DcProcesses.ProcessCode = TrInvoiceHeaders.ProcessCode\r\n	--left join DcProducts on DcProducts.ProductCode = TrInvoiceLines.ProductCode\r\n	group by FirstName\r\n			, CurrAccDesc\r\n			, ProcessDesc\r\n			, DocumentNumber\r\n			, TrInvoiceHeaders.InvoiceHeaderId\r\n			, TrInvoiceHeaders.CurrAccCode\r\n			, TrInvoiceHeaders.DocumentDate	\r\n			, TrInvoiceHeaders.DocumentTime\r\n			, TrInvoiceHeaders.Description\r\n			, TrInvoiceHeaders.StoreCode\r\n	, TrInvoiceHeaders.ProcessCode\r\n	, IsReturn\r\n	\r\n	UNION ALL \r\n	\r\n	select FirstName\r\n	--, ProductCode = ''\r\n	, CurrAccDesc = CurrAccDesc\r\n	, InvoiceHeaderId = cast(cast(0 as binary) as uniqueidentifier)\r\n	, TrPaymentHeaders.PaymentHeaderId\r\n	, NetAmountLoc = 0\r\n	, PaymentLoc\r\n	, Summary = PaymentLoc\r\n	, ProcessDesc = N'Ödəniş'\r\n	, DocumentNumber\r\n	, TrPaymentHeaders.StoreCode\r\n	, TrPaymentHeaders.CurrAccCode\r\n	, DocumentDate = TrPaymentHeaders.OperationDate\r\n	, DocumentTime = TrPaymentHeaders.OperationTime\r\n	, LineDescription\r\n	, ProcessCode = 'PA'\r\n	, IsReturn = CAST(0 as bit)\r\n	--, LineId = PaymentLineId\r\n	from TrPaymentLines\r\n	left join TrPaymentHeaders on TrPaymentLines.PaymentHeaderId = TrPaymentHeaders.PaymentHeaderId\r\n	left join DcCurrAccs  on TrPaymentHeaders.CurrAccCode = DcCurrAccs.CurrAccCode	\r\n\r\n) as CurrAccExtra where 1=1 {CurrAccCode}\r\n\r\norder by DocumentDate, DocumentTime");
        }
    }
}
