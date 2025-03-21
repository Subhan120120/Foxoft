using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Foxoft.Migrations
{
    /// <inheritdoc />
    public partial class paymentkind : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrRoleClaims_DcRoles_RoleCode",
                table: "TrRoleClaims");

            migrationBuilder.AddColumn<byte>(
                name: "PaymentKind",
                table: "TrPaymentHeaders",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.CreateTable(
                name: "DcPaymentKinds",
                columns: table => new
                {
                    PaymentKindId = table.Column<byte>(type: "tinyint", nullable: false),
                    PaymentKindDesc = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DcPaymentKinds", x => x.PaymentKindId);
                });

            migrationBuilder.InsertData(
                table: "DcPaymentKinds",
                columns: new[] { "PaymentKindId", "PaymentKindDesc" },
                values: new object[,]
                {
                    { (byte)0, "Unknown" },
                    { (byte)1, "Invoice" },
                    { (byte)2, "Payment" },
                    { (byte)3, "Installment" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_TrPaymentHeaders_PaymentKind",
                table: "TrPaymentHeaders",
                column: "PaymentKind");

            migrationBuilder.AddForeignKey(
                name: "FK_TrPaymentHeaders_DcPaymentKinds_PaymentKind",
                table: "TrPaymentHeaders",
                column: "PaymentKind",
                principalTable: "DcPaymentKinds",
                principalColumn: "PaymentKindId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TrRoleClaims_DcRoles_RoleCode",
                table: "TrRoleClaims",
                column: "RoleCode",
                principalTable: "DcRoles",
                principalColumn: "RoleCode",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrPaymentHeaders_DcPaymentKinds_PaymentKind",
                table: "TrPaymentHeaders");

            migrationBuilder.DropForeignKey(
                name: "FK_TrRoleClaims_DcRoles_RoleCode",
                table: "TrRoleClaims");

            migrationBuilder.DropTable(
                name: "DcPaymentKinds");

            migrationBuilder.DropIndex(
                name: "IX_TrPaymentHeaders_PaymentKind",
                table: "TrPaymentHeaders");

            migrationBuilder.DeleteData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "InstallmentCommissionChange");

            migrationBuilder.DeleteData(
                table: "TrRoleClaims",
                keyColumn: "RoleClaimId",
                keyValue: 48);

            migrationBuilder.DropColumn(
                name: "PaymentKind",
                table: "TrPaymentHeaders");

            migrationBuilder.UpdateData(
                table: "DcReports",
                keyColumn: "ReportId",
                keyValue: 6,
                column: "ReportQuery",
                value: "WITH PaymentLinesSum AS (\r\n    SELECT\r\n        ph.InvoiceHeaderId,\r\n        ph.CurrAccCode,\r\n        SUM(pl.PaymentLoc) AS PaymentLinesSum\r\n    FROM\r\n        TrPaymentLines pl\r\n    INNER JOIN\r\n        TrPaymentHeaders ph ON pl.PaymentHeaderId = ph.PaymentHeaderId\r\n    INNER JOIN\r\n        TrInstallments i ON ph.InvoiceHeaderId = i.InvoiceHeaderId\r\n    WHERE\r\n        ph.OperationDate > i.DocumentDate -- Filter payments after DocumentDate\r\n    GROUP BY\r\n        ph.InvoiceHeaderId, ph.CurrAccCode\r\n),\r\nInstallmentData AS (\r\n    SELECT\r\n        i.InstallmentId,\r\n        i.InvoiceHeaderId,\r\n        i.DocumentDate,\r\n        i.PaymentPlanCode,\r\n        i.Amount,\r\n        i.AmountLoc,\r\n        i.CurrencyCode,\r\n        i.ExchangeRate,\r\n        i.AmountLoc + i.Commission AS AmountWithComLoc,\r\n		ca.CurrAccDesc,\r\n		ca.PhoneNum,\r\n        p.DurationInMonths,\r\n        COALESCE(psum.PaymentLinesSum, 0) AS TotalPaid\r\n    FROM\r\n        TrInstallments i\r\n    INNER JOIN\r\n        TrInvoiceHeaders ih ON i.InvoiceHeaderId = ih.InvoiceHeaderId\r\n    INNER JOIN\r\n        DcCurrAccs ca ON ih.CurrAccCode = ca.CurrAccCode\r\n    INNER JOIN\r\n        DcPaymentPlans p ON i.PaymentPlanCode = p.PaymentPlanCode\r\n    LEFT JOIN\r\n        PaymentLinesSum psum ON i.InvoiceHeaderId = psum.InvoiceHeaderId AND ih.CurrAccCode = psum.CurrAccCode\r\n),\r\nCalculatedData AS (\r\n    SELECT\r\n        InstallmentId,\r\n        InvoiceHeaderId,\r\n		CurrAccDesc,\r\n		PhoneNum,\r\n        DocumentDate,\r\n        PaymentPlanCode,\r\n        Amount,\r\n        AmountWithComLoc,\r\n        CurrencyCode,\r\n        ExchangeRate,\r\n        TotalPaid,\r\n        AmountWithComLoc - TotalPaid AS RemainingBalance,\r\n        (AmountWithComLoc / NULLIF(DurationInMonths, 0)) AS MonthlyPayment,\r\n        FLOOR(TotalPaid / (AmountWithComLoc / NULLIF(DurationInMonths, 0))) AS MonthsPaid,\r\n        DATEADD(MONTH, FLOOR(TotalPaid / (AmountWithComLoc / NULLIF(DurationInMonths, 0))) + 1, DocumentDate) AS OverdueDate\r\n    FROM\r\n        InstallmentData\r\n)\r\nSELECT\r\n    InstallmentId,\r\n    InvoiceHeaderId,\r\n	CurrAccDesc,\r\n	PhoneNum,\r\n    DocumentDate,\r\n    PaymentPlanCode,\r\n    Amount,\r\n    AmountWithComLoc,\r\n    CurrencyCode,\r\n    ExchangeRate,\r\n    TotalPaid,\r\n    RemainingBalance,\r\n    MonthlyPayment,\r\n    TotalPaid - (DATEDIFF(DAY, DocumentDate, GETDATE()) / 30) * MonthlyPayment AS DueAmount,\r\n    OverdueDate,\r\n    CASE \r\n        WHEN GETDATE() > OverdueDate THEN DATEDIFF(DAY, OverdueDate, GETDATE())\r\n        ELSE 0\r\n    END AS OverdueDays\r\nFROM\r\n    CalculatedData;");

            migrationBuilder.UpdateData(
                table: "TrRoleClaims",
                keyColumn: "RoleClaimId",
                keyValue: 46,
                column: "ClaimCode",
                value: "EditLockedInvoice");

            migrationBuilder.UpdateData(
                table: "TrRoleClaims",
                keyColumn: "RoleClaimId",
                keyValue: 47,
                column: "ClaimCode",
                value: "EditLockedPayment");

            migrationBuilder.AddForeignKey(
                name: "FK_TrRoleClaims_DcRoles_RoleCode",
                table: "TrRoleClaims",
                column: "RoleCode",
                principalTable: "DcRoles",
                principalColumn: "RoleCode",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
