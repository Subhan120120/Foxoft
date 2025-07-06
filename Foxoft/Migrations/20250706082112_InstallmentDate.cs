using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Foxoft.Migrations
{
    /// <inheritdoc />
    public partial class InstallmentDate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.RenameColumn(
                name: "DocumentDate",
                table: "TrInstallments",
                newName: "InstallmentDate");

            migrationBuilder.AddColumn<decimal>(
                name: "InterestRate",
                table: "TrInstallments",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InterestRate",
                table: "TrInstallments");

            migrationBuilder.RenameColumn(
                name: "InstallmentDate",
                table: "TrInstallments",
                newName: "DocumentDate");

            migrationBuilder.UpdateData(
                table: "DcPaymentTypes",
                keyColumn: "PaymentTypeCode",
                keyValue: (byte)3,
                column: "PaymentTypeDesc",
                value: "Daxili Kredit");

            migrationBuilder.UpdateData(
                table: "DcPaymentTypes",
                keyColumn: "PaymentTypeCode",
                keyValue: (byte)4,
                column: "PaymentTypeDesc",
                value: "Bonus");

            migrationBuilder.InsertData(
                table: "DcPaymentTypes",
                columns: new[] { "PaymentTypeCode", "PaymentTypeDesc" },
                values: new object[] { (byte)5, "Komissiya" });

            migrationBuilder.UpdateData(
                table: "DcReports",
                keyColumn: "ReportId",
                keyValue: 6,
                column: "ReportQuery",
                value: "\r\n\r\nWITH InstallmentPaymentSum AS (\r\n    SELECT\r\n        ph.InvoiceHeaderId,\r\n        ph.CurrAccCode,\r\n        SUM(pl.PaymentLoc) AS InstallmentPaymentSum\r\n    FROM\r\n        TrPaymentLines pl\r\n    INNER JOIN\r\n        TrPaymentHeaders ph ON pl.PaymentHeaderId = ph.PaymentHeaderId\r\n    INNER JOIN\r\n        TrInstallments i ON ph.InvoiceHeaderId = i.InvoiceHeaderId\r\n    WHERE\r\n        ph.PaymentKindId = 3\r\n    GROUP BY\r\n        ph.InvoiceHeaderId, ph.CurrAccCode\r\n),\r\nDownPaymentSum AS (\r\n    SELECT\r\n        i.InvoiceHeaderId,\r\n        SUM(pl.PaymentLoc) AS DownPaymentSum\r\n    FROM\r\n        TrPaymentLines pl\r\n    INNER JOIN\r\n        TrPaymentHeaders ph ON pl.PaymentHeaderId = ph.PaymentHeaderId\r\n    INNER JOIN\r\n        TrInstallments i ON ph.InvoiceHeaderId = i.InvoiceHeaderId\r\n    WHERE\r\n        ph.PaymentKindId != 3\r\n    GROUP BY\r\n        i.InvoiceHeaderId\r\n),\r\nInstallmentData AS (\r\n    SELECT\r\n        i.InstallmentId,\r\n        i.InvoiceHeaderId,\r\n        i.DocumentDate,\r\n        SUM(il.NetAmountLoc) + COALESCE(SUM(ril.NetAmount), 0) AS Amount,\r\n        SUM(il.NetAmountLoc) + COALESCE(SUM(ril.NetAmountLoc), 0) AS AmountLoc, \r\n        (SUM(il.NetAmountLoc) + i.Commission) + COALESCE(SUM(ril.NetAmountLoc), 0) AS AmountWithComLoc,\r\n        (SUM(il.NetAmountLoc) + i.Commission) + COALESCE(SUM(ril.NetAmountLoc), 0) - COALESCE(dps.DownPaymentSum, 0) AS InstallmentAmount,\r\n        ih.DocumentNumber,\r\n        ca.CurrAccDesc,\r\n        ca.PhoneNum,\r\n        ip.DurationInMonths,\r\n        COALESCE(psum.InstallmentPaymentSum, 0) AS InstallmentPaid,\r\n        COALESCE(dps.DownPaymentSum, 0) AS DownPayment\r\n    FROM\r\n        TrInstallments i\r\n    INNER JOIN\r\n        TrInvoiceHeaders ih ON i.InvoiceHeaderId = ih.InvoiceHeaderId\r\n    LEFT JOIN\r\n        TrInvoiceLines il ON il.InvoiceHeaderId = ih.InvoiceHeaderId\r\n    INNER JOIN\r\n        DcCurrAccs ca ON ih.CurrAccCode = ca.CurrAccCode\r\n    INNER JOIN\r\n        DcInstallmentPlan ip ON i.InstallmentPlanCode = ip.InstallmentPlanCode\r\n    LEFT JOIN\r\n        InstallmentPaymentSum psum ON i.InvoiceHeaderId = psum.InvoiceHeaderId AND ih.CurrAccCode = psum.CurrAccCode\r\n    LEFT JOIN\r\n        DownPaymentSum dps ON i.InvoiceHeaderId = dps.InvoiceHeaderId\r\n    LEFT JOIN\r\n        TrInvoiceHeaders rih ON rih.RelatedInvoiceId = i.InvoiceHeaderId AND rih.IsReturn = 1 \r\n    LEFT JOIN\r\n        TrInvoiceLines ril ON ril.InvoiceHeaderId = rih.InvoiceHeaderId AND ril.RelatedLineId = il.InvoiceLineId\r\n    GROUP BY \r\n        i.InstallmentId,\r\n        i.InvoiceHeaderId,\r\n        i.DocumentDate,\r\n        ih.DocumentNumber,\r\n        ca.CurrAccDesc,\r\n        ca.PhoneNum,\r\n        ip.DurationInMonths,\r\n        i.Commission,\r\n        psum.InstallmentPaymentSum,\r\n        dps.DownPaymentSum\r\n\r\n),\r\nCalculatedData AS (\r\n    SELECT\r\n        InstallmentId,\r\n        InvoiceHeaderId,\r\n        CurrAccDesc,\r\n        PhoneNum,\r\n        DocumentNumber,\r\n        DocumentDate,\r\n        Amount,\r\n        AmountWithComLoc,\r\n        InstallmentAmount,\r\n        DownPayment,\r\n        InstallmentPaid,\r\n		DurationInMonths,\r\n        InstallmentAmount - InstallmentPaid AS RemainingBalance,\r\n        ((InstallmentAmount) / NULLIF(DurationInMonths, 0)) AS MonthlyPayment,\r\n        FLOOR(InstallmentPaid / ((InstallmentAmount) / NULLIF(DurationInMonths, 0))) AS MonthsPaid,\r\n		DATEADD(MONTH, \r\n		    FLOOR(InstallmentPaid / COALESCE(NULLIF((InstallmentAmount)/ NULLIF(DurationInMonths, 0), 0), 1)) + 1, DocumentDate\r\n		) AS OverdueDate\r\n    FROM\r\n        InstallmentData\r\n)\r\nSELECT\r\n    InstallmentId,\r\n    InvoiceHeaderId,\r\n    CurrAccDesc,\r\n    PhoneNum,\r\n    DocumentNumber,\r\n    DocumentDate,\r\n    Amount,\r\n    MonthlyPayment,\r\n    [Tutar Faizi ilə] = AmountWithComLoc,\r\n    [Kredit Məbləği] = InstallmentAmount,\r\n	[Ay] = DurationInMonths,\r\n    [İlkin Ödəniş] = DownPayment,  -- Showing Down Payment Separately\r\n    [Toplam Ödəniş] = InstallmentPaid,   -- Payments excluding downpayment\r\n    [Qalıq] = RemainingBalance,\r\n    [Aylıq Ödəniş] = MonthlyPayment,\r\n    [Ödənilməli məbləğ] = InstallmentPaid - (DATEDIFF(DAY, DocumentDate, GETDATE()) / 30) * MonthlyPayment,\r\n    [Gecikmə tarixi] = OverdueDate,\r\n    [Gecikmiş Günlər] = CASE \r\n        WHEN GETDATE() > OverdueDate THEN DATEDIFF(DAY, OverdueDate, GETDATE())\r\n        ELSE 0\r\n    END\r\nFROM\r\n    CalculatedData;\r\n");
        }
    }
}
