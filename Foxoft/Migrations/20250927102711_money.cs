using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Foxoft.Migrations
{
    /// <inheritdoc />
    public partial class money : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TrInvoiceLines_InvoiceHeaderId_ProductCode",
                table: "TrInvoiceLines");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "TrInvoiceLines",
                type: "money",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.CreateIndex(
                name: "IX_TrInvoiceLines_InvoiceHeaderId_ProductCode",
                table: "TrInvoiceLines",
                columns: new[] { "InvoiceHeaderId", "ProductCode" })
                .Annotation("SqlServer:Include", new[] { "Price" });

            migrationBuilder.AlterColumn<decimal>(
                name: "PosDiscount",
                table: "TrInvoiceLines",
                type: "decimal(18,2)",
                nullable: false,
                defaultValueSql: "0",
                oldClrType: typeof(decimal),
                oldType: "money",
                oldDefaultValueSql: "0");

            migrationBuilder.UpdateData(
                table: "DcForms",
                keyColumn: "FormCode",
                keyValue: "PaymentDetails",
                column: "FormDesc",
                value: "Ödəniş");

            migrationBuilder.UpdateData(
                table: "TrRoleClaims",
                keyColumn: "RoleClaimId",
                keyValue: 45,
                column: "ClaimCode",
                value: "InstallmentSales");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "InstallmentSales");

            migrationBuilder.DeleteData(
                table: "DcForms",
                keyColumn: "FormCode",
                keyValue: "InstallmentSale");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "TrInvoiceLines",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "money");

            migrationBuilder.AlterColumn<decimal>(
                name: "PosDiscount",
                table: "TrInvoiceLines",
                type: "money",
                nullable: false,
                defaultValueSql: "0",
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldDefaultValueSql: "0");

            migrationBuilder.InsertData(
                table: "DcClaims",
                columns: new[] { "ClaimCode", "CategoryId", "ClaimDesc", "ClaimTypeId" },
                values: new object[] { "Installments", 8, "Kreditlər", (byte)1 });

            migrationBuilder.UpdateData(
                table: "DcForms",
                keyColumn: "FormCode",
                keyValue: "PaymentDetails",
                column: "FormDesc",
                value: "Payment Details");

            migrationBuilder.UpdateData(
                table: "DcReports",
                keyColumn: "ReportId",
                keyValue: 1,
                column: "ReportQuery",
                value: "\r\n\r\n\r\n\r\n\r\n\r\n--declare @StartDate date = dateadd(DAY, 1, getdate())\r\n--declare @StartTime time =  '00:00:00.000'\r\n\r\nselect * from (\r\n\r\nSelect pro.ProductCode\r\n		, pro.HierarchyCode\r\n		, [Məhsulun Genis Adi]= isnull(pro.HierarchyCode + ' ','')  + ProductDesc \r\n			+ isnull(' ' + Feature04,'') + isnull(' ' + Feature05,'') + isnull(' ' + Feature06,'') + isnull(' ' +Feature07,'')\r\n			+ isnull(' ' + Feature08,'') + isnull(' ' + Feature09,'') + isnull(' ' + Feature10,'') + isnull(' ' + Feature11,'')\r\n			+ isnull(' ' + Feature12,'') + isnull(' ' + Feature13,'') + isnull(' ' + Feature16,'') + isnull(' ' + Feature17,'') \r\n			+ isnull(' ' + Feature18,'') + isnull(' ' + Feature19 + 'x' + Feature20 + 'x' + Feature21,'') + isnull(' ' + Feature22,'')\r\n			+ isnull(' ' + Feature23,'') + isnull(' ' + Feature24,'') + isnull(' ' + Feature25,'') + isnull(' ' + Feature26,'') \r\n			+ isnull(' ' + Feature27,'') + isnull(' ' + Feature28,'') \r\n		, ProductDesc\r\n		, Balance = CAST(isnull(ProductBalance.[depo-01],0) AS INT)\r\n		, WholesalePrice\r\n		, HierarchyDesc\r\n		, ProductTypeCode\r\n		--, ProductId	\r\n		, ProductCost = dbo.GetProductCost(pro.ProductCode, null)\r\n		, CalcClosingStockFifo.FIFO_CORG\r\n		\r\nfrom DcProducts pro\r\n\r\nleft join DcHierarchies on pro.HierarchyCode = DcHierarchies.HierarchyCode\r\n--left join SiteProducts on SiteProducts.ProductCode = pro.ProductCode\r\nleft join ProductFeatures ON pro.ProductCode = ProductFeatures.ProductCode \r\nleft join ProductBalance on ProductBalance.ProductCode = pro.ProductCode\r\nleft join CalcClosingStockFifo on CalcClosingStockFifo.ProductCode = pro.ProductCode\r\n\r\n	--where ProductTypeCode = 1\r\n	--and (CAST(ih.DocumentDate AS DATETIME) + CAST(ih.DocumentTime AS DATETIME)) <=\r\n	--	(CAST(@StartDate AS DATETIME) + CAST(@StartTime AS DATETIME))\r\n	--and il.ProductCode = '5503'\r\n\r\n) as tablo \r\n	order by \r\ntablo.HierarchyCode \r\n, tablo.ProductDesc \r\n\r\n\r\n\r\n\r\n");

            migrationBuilder.UpdateData(
                table: "DcReports",
                keyColumn: "ReportId",
                keyValue: 6,
                column: "ReportQuery",
                value: "WITH InstallmentPaymentSum AS (\r\n    SELECT\r\n        ph.InvoiceHeaderId,\r\n        ph.CurrAccCode,\r\n        SUM(pl.PaymentLoc) AS InstallmentPaymentSum\r\n    FROM\r\n        TrPaymentLines pl\r\n    INNER JOIN\r\n        TrPaymentHeaders ph ON pl.PaymentHeaderId = ph.PaymentHeaderId\r\n    INNER JOIN\r\n        TrInstallments i ON ph.InvoiceHeaderId = i.InvoiceHeaderId\r\n    WHERE\r\n        ph.PaymentKindId = 3\r\n    GROUP BY\r\n        ph.InvoiceHeaderId, ph.CurrAccCode\r\n),\r\nDownPaymentSum AS (\r\n    SELECT\r\n        i.InvoiceHeaderId,\r\n        SUM(pl.PaymentLoc) AS DownPaymentSum\r\n    FROM\r\n        TrInstallments i\r\n    INNER JOIN\r\n        TrInvoiceHeaders ih ON ih.InvoiceHeaderId = i.InvoiceHeaderId  \r\n    INNER JOIN\r\n        TrPaymentHeaders ph ON ih.InvoiceHeaderId = ph.InvoiceHeaderId AND ih.CurrAccCode = ph.CurrAccCode\r\n    INNER JOIN\r\n        TrPaymentLines pl ON ph.PaymentHeaderId = pl.PaymentHeaderId\r\n    WHERE\r\n        ph.PaymentKindId != 3\r\n    GROUP BY\r\n        i.InvoiceHeaderId\r\n),\r\nInstallmentData AS (\r\n    SELECT\r\n        i.InstallmentId,\r\n        i.InvoiceHeaderId,\r\n        i.InstallmentDate,\r\n        SUM(il.NetAmountLoc) + COALESCE(SUM(ril.NetAmount), 0) AS Amount,\r\n        SUM(il.NetAmountLoc) + COALESCE(SUM(ril.NetAmountLoc), 0) AS AmountLoc, \r\n        (SUM(il.NetAmountLoc) + i.Commission) + COALESCE(SUM(ril.NetAmountLoc), 0) AS AmountWithComLoc,\r\n        (SUM(il.NetAmountLoc) + i.Commission) + COALESCE(SUM(ril.NetAmountLoc), 0) - COALESCE(dps.DownPaymentSum, 0) AS InstallmentAmount,\r\n        ih.DocumentNumber,\r\n        ca.CurrAccDesc,\r\n        ca.PhoneNum,\r\n        ip.DurationInMonths,\r\n        COALESCE(psum.InstallmentPaymentSum, 0) AS InstallmentPaid,\r\n        COALESCE(dps.DownPaymentSum, 0) AS DownPayment\r\n    FROM\r\n        TrInstallments i\r\n    INNER JOIN\r\n        TrInvoiceHeaders ih ON i.InvoiceHeaderId = ih.InvoiceHeaderId\r\n    LEFT JOIN\r\n        TrInvoiceLines il ON il.InvoiceHeaderId = ih.InvoiceHeaderId\r\n    INNER JOIN\r\n        DcCurrAccs ca ON ih.CurrAccCode = ca.CurrAccCode\r\n    INNER JOIN\r\n        DcInstallmentPlan ip ON i.InstallmentPlanCode = ip.InstallmentPlanCode\r\n    LEFT JOIN\r\n        InstallmentPaymentSum psum ON i.InvoiceHeaderId = psum.InvoiceHeaderId AND ih.CurrAccCode = psum.CurrAccCode\r\n    LEFT JOIN\r\n        DownPaymentSum dps ON i.InvoiceHeaderId = dps.InvoiceHeaderId\r\n    LEFT JOIN\r\n        TrInvoiceHeaders rih ON rih.RelatedInvoiceId = i.InvoiceHeaderId AND rih.IsReturn = 1 \r\n    LEFT JOIN\r\n        TrInvoiceLines ril ON ril.InvoiceHeaderId = rih.InvoiceHeaderId AND ril.RelatedLineId = il.InvoiceLineId\r\n    GROUP BY \r\n        i.InstallmentId,\r\n        i.InvoiceHeaderId,\r\n        i.InstallmentDate,\r\n        ih.DocumentNumber,\r\n        ca.CurrAccDesc,\r\n        ca.PhoneNum,\r\n        ip.DurationInMonths,\r\n        i.Commission,\r\n        psum.InstallmentPaymentSum,\r\n        dps.DownPaymentSum\r\n\r\n),\r\nCalculatedData AS (\r\n    SELECT\r\n        InstallmentId,\r\n        InvoiceHeaderId,\r\n        CurrAccDesc,\r\n        PhoneNum,\r\n        DocumentNumber,\r\n        InstallmentDate,\r\n        Amount,\r\n        AmountWithComLoc,\r\n        InstallmentAmount,\r\n        DownPayment,\r\n        InstallmentPaid,\r\n        DurationInMonths,\r\n        InstallmentAmount - InstallmentPaid AS RemainingBalance,\r\n        ((InstallmentAmount) / NULLIF(DurationInMonths, 0)) AS MonthlyPayment,\r\n        FLOOR(InstallmentPaid / (InstallmentAmount / NULLIF(DurationInMonths, 0))) AS MonthsPaid,\r\n        CASE \r\n            WHEN DurationInMonths = 0 THEN InstallmentDate\r\n            ELSE DATEADD(MONTH, FLOOR(InstallmentPaid / (NULLIF(InstallmentAmount / NULLIF(DurationInMonths, 0), 0))) + 1, InstallmentDate)\r\n        END AS OverdueDate\r\n    FROM\r\n        InstallmentData\r\n)\r\nSELECT\r\n    InstallmentId,\r\n    InvoiceHeaderId,\r\n    CurrAccDesc,\r\n    PhoneNum,\r\n    DocumentNumber,\r\n    InstallmentDate,\r\n    Amount,\r\n    MonthsPaid,\r\n    MonthlyPayment,\r\n    [Tutar Faizi ilə] = AmountWithComLoc,\r\n    [Kredit Məbləği] = InstallmentAmount,\r\n    [Ay] = DurationInMonths,\r\n    [İlkin Ödəniş] = DownPayment,\r\n    [Toplam Ödəniş] = InstallmentPaid,\r\n    [Qalıq] = RemainingBalance,\r\n    [Aylıq Ödəniş] = MonthlyPayment,\r\n    [Ödənilməli məbləğ] = InstallmentPaid - (DATEDIFF(DAY, InstallmentDate, GETDATE()) / 30) * MonthlyPayment,\r\n    [Gecikmə tarixi] = OverdueDate,\r\n    [Gecikmiş Günlər] = CASE \r\n        WHEN GETDATE() > OverdueDate THEN DATEDIFF(DAY, OverdueDate, GETDATE())\r\n        ELSE 0\r\n    END\r\nFROM\r\n    CalculatedData;\r\n");

            migrationBuilder.UpdateData(
                table: "DcReports",
                keyColumn: "ReportId",
                keyValue: 7,
                column: "ReportQuery",
                value: "\r\n\r\n	select CashRegisterCode = DcCurrAccs.CurrAccCode\r\n	, [Mağaza Adı] = CurrAccDesc\r\n	, Balance =ISNULL(SUM(CAST(PaymentLoc as money)),0)\r\n	, PhoneNum\r\n	, IsVIP\r\n	, CurrAccTypeCode\r\n	from \r\n	DcCurrAccs \r\n	left join  TrPaymentLines on TrPaymentLines.CashRegisterCode = DcCurrAccs.CurrAccCode and PaymentTypeCode = 1\r\n	where CurrAccTypeCode = 4 and IsDisabled = 0\r\n		--and DcCurrAccs.IsVIP = 1 \r\n		--and balance.CurrAccCode = '1403'\r\n	group by DcCurrAccs.CurrAccCode\r\n	, CurrAccDesc\r\n	, PhoneNum\r\n	, IsVIP\r\n	, CurrAccTypeCode\r\n	, CashRegisterCode \r\n	order by CurrAccDesc");

            migrationBuilder.UpdateData(
                table: "TrRoleClaims",
                keyColumn: "RoleClaimId",
                keyValue: 45,
                column: "ClaimCode",
                value: "Installments");
        }
    }
}
