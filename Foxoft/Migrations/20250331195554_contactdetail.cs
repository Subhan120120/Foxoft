using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Foxoft.Migrations
{
    /// <inheritdoc />
    public partial class contactdetail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DcContactType",
                columns: table => new
                {
                    Id = table.Column<byte>(type: "tinyint", nullable: false),
                    ContactTypeDesc = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DcContactType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DcCurrAccContactDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContactDesc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactTypeId = table.Column<byte>(type: "tinyint", nullable: false),
                    CurrAccCode = table.Column<string>(type: "nvarchar(30)", nullable: false),
                    PhoneNumberFormat = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    DefaultValue = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DcCurrAccContactDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DcCurrAccContactDetails_DcContactType_ContactTypeId",
                        column: x => x.ContactTypeId,
                        principalTable: "DcContactType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DcCurrAccContactDetails_DcCurrAccs_CurrAccCode",
                        column: x => x.CurrAccCode,
                        principalTable: "DcCurrAccs",
                        principalColumn: "CurrAccCode",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "DcContactType",
                columns: new[] { "Id", "ContactTypeDesc" },
                values: new object[,]
                {
                    { (byte)1, "Telefon" },
                    { (byte)2, "Adres" },
                    { (byte)3, "Email" },
                    { (byte)4, "Sosial Media" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_DcCurrAccContactDetails_ContactTypeId",
                table: "DcCurrAccContactDetails",
                column: "ContactTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_DcCurrAccContactDetails_CurrAccCode",
                table: "DcCurrAccContactDetails",
                column: "CurrAccCode");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DcCurrAccContactDetails");

            migrationBuilder.DropTable(
                name: "DcContactType");

            migrationBuilder.UpdateData(
                table: "DcReports",
                keyColumn: "ReportId",
                keyValue: 6,
                column: "ReportQuery",
                value: "WITH PaymentLinesSum AS (\r\n    SELECT\r\n        ph.InvoiceHeaderId,\r\n        ph.CurrAccCode,\r\n        SUM(pl.PaymentLoc) AS PaymentLinesSum\r\n    FROM\r\n        TrPaymentLines pl\r\n    INNER JOIN\r\n        TrPaymentHeaders ph ON pl.PaymentHeaderId = ph.PaymentHeaderId\r\n    INNER JOIN\r\n        TrInstallments i ON ph.InvoiceHeaderId = i.InvoiceHeaderId\r\n    WHERE\r\n        ph.OperationDate > i.DocumentDate -- payments without downpayments\r\n    GROUP BY\r\n        ph.InvoiceHeaderId, ph.CurrAccCode\r\n),\r\nDownPaymentSum AS (\r\n    SELECT\r\n        i.InvoiceHeaderId,\r\n        SUM(pl.PaymentLoc) AS DownPaymentSum\r\n    FROM\r\n        TrPaymentLines pl\r\n    INNER JOIN\r\n        TrPaymentHeaders ph ON pl.PaymentHeaderId = ph.PaymentHeaderId\r\n    INNER JOIN\r\n        TrInstallments i ON ph.InvoiceHeaderId = i.InvoiceHeaderId\r\n    WHERE\r\n        ph.OperationDate <= i.DocumentDate -- only downpayments\r\n    GROUP BY\r\n        i.InvoiceHeaderId\r\n),\r\nInstallmentData AS (\r\n    SELECT\r\n        i.InstallmentId,\r\n        i.InvoiceHeaderId,\r\n        i.DocumentDate,\r\n        i.Amount + COALESCE(ril.NetAmount, 0) AS Amount,\r\n        i.AmountLoc + COALESCE(ril.NetAmountLoc, 0) AS AmountLoc, \r\n        i.CurrencyCode,\r\n        i.ExchangeRate,\r\n        (i.AmountLoc + i.Commission) + COALESCE(ril.NetAmountLoc, 0) AS AmountWithComLoc,\r\n        ih.DocumentNumber,\r\n        ca.CurrAccDesc,\r\n        ca.PhoneNum,\r\n        pp.DurationInMonths,\r\n        COALESCE(psum.PaymentLinesSum, 0) AS TotalPaid,\r\n        COALESCE(dps.DownPaymentSum, 0) AS DownPayment\r\n    FROM\r\n        TrInstallments i\r\n    INNER JOIN\r\n        TrInvoiceHeaders ih ON i.InvoiceHeaderId = ih.InvoiceHeaderId\r\n    INNER JOIN\r\n        DcCurrAccs ca ON ih.CurrAccCode = ca.CurrAccCode\r\n    INNER JOIN\r\n        DcPaymentPlans pp ON i.PaymentPlanCode = pp.PaymentPlanCode\r\n    LEFT JOIN\r\n        PaymentLinesSum psum ON i.InvoiceHeaderId = psum.InvoiceHeaderId AND ih.CurrAccCode = psum.CurrAccCode\r\n    LEFT JOIN\r\n        DownPaymentSum dps ON i.InvoiceHeaderId = dps.InvoiceHeaderId\r\n    LEFT JOIN\r\n        TrInvoiceHeaders rih ON rih.RelatedInvoiceId = i.InvoiceHeaderId AND rih.IsReturn = 1 \r\n    LEFT JOIN\r\n        TrInvoiceLines ril ON ril.InvoiceHeaderId = rih.InvoiceHeaderId\r\n),\r\nCalculatedData AS (\r\n    SELECT\r\n        InstallmentId,\r\n        InvoiceHeaderId,\r\n        CurrAccDesc,\r\n        PhoneNum,\r\n        DocumentNumber,\r\n        DocumentDate,\r\n        Amount,\r\n        AmountWithComLoc,\r\n        CurrencyCode,\r\n        ExchangeRate,\r\n        DownPayment,\r\n        TotalPaid,\r\n		DurationInMonths,\r\n        AmountWithComLoc - TotalPaid AS RemainingBalance,\r\n        (AmountWithComLoc / NULLIF(DurationInMonths, 0)) AS MonthlyPayment,\r\n        FLOOR(TotalPaid / (AmountWithComLoc / NULLIF(DurationInMonths, 0))) AS MonthsPaid,\r\n		DATEADD(MONTH, \r\n		    FLOOR(TotalPaid / COALESCE(NULLIF(AmountWithComLoc / NULLIF(DurationInMonths, 0), 0), 1)) + 1, DocumentDate\r\n		) AS OverdueDate\r\n    FROM\r\n        InstallmentData\r\n)\r\nSELECT\r\n    InstallmentId,\r\n    InvoiceHeaderId,\r\n    CurrAccDesc,\r\n    PhoneNum,\r\n    DocumentNumber,\r\n    DocumentDate,\r\n    Amount,\r\n    CurrencyCode,\r\n    ExchangeRate,\r\n    MonthlyPayment,\r\n    [Tutar Faizi ilə] = AmountWithComLoc,\r\n	[Ay] = DurationInMonths,\r\n    [İlkin Ödəniş] = DownPayment,  -- Showing Down Payment Separately\r\n    [Toplam Ödəniş] = TotalPaid,   -- Payments excluding downpayment\r\n    [Qalıq] = RemainingBalance,\r\n    [Aylıq Ödəniş] = MonthlyPayment,\r\n    [Ödənilməli məbləğ] = TotalPaid - (DATEDIFF(DAY, DocumentDate, GETDATE()) / 30) * MonthlyPayment,\r\n    [Gecikmə tarixi] = OverdueDate,\r\n    [Gecikmiş Günlər] = CASE \r\n        WHEN GETDATE() > OverdueDate THEN DATEDIFF(DAY, OverdueDate, GETDATE())\r\n        ELSE 0\r\n    END\r\nFROM\r\n    CalculatedData;\r\n");
        }
    }
}
