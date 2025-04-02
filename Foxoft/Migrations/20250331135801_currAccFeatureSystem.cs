using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Foxoft.Migrations
{
    /// <inheritdoc />
    public partial class currAccFeatureSystem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte>(
                name: "PaymentKindId",
                table: "TrPaymentHeaders",
                type: "tinyint",
                nullable: true,
                oldClrType: typeof(byte),
                oldType: "tinyint");

            migrationBuilder.CreateTable(
                name: "DcFeatureTypeCurrAccs",
                columns: table => new
                {
                    FeatureTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FeatureTypeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false),
                    Filterable = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DcFeatureTypeCurrAccs", x => x.FeatureTypeId);
                });

            migrationBuilder.CreateTable(
                name: "DcFeatureCurrAccs",
                columns: table => new
                {
                    FeatureCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FeatureTypeId = table.Column<int>(type: "int", nullable: false),
                    FeatureDesc = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DcFeatureCurrAccs", x => new { x.FeatureCode, x.FeatureTypeId });
                    table.ForeignKey(
                        name: "FK_DcFeatureCurrAccs_DcFeatureTypeCurrAccs_FeatureTypeId",
                        column: x => x.FeatureTypeId,
                        principalTable: "DcFeatureTypeCurrAccs",
                        principalColumn: "FeatureTypeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TrCurrAccFeatures",
                columns: table => new
                {
                    CurrAccCode = table.Column<string>(type: "nvarchar(30)", nullable: false),
                    FeatureTypeId = table.Column<int>(type: "int", nullable: false),
                    FeatureCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IdentityColumn = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrCurrAccFeatures", x => new { x.CurrAccCode, x.FeatureTypeId, x.FeatureCode });
                    table.ForeignKey(
                        name: "FK_TrCurrAccFeatures_DcCurrAccs_CurrAccCode",
                        column: x => x.CurrAccCode,
                        principalTable: "DcCurrAccs",
                        principalColumn: "CurrAccCode",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TrCurrAccFeatures_DcFeatureCurrAccs_FeatureCode_FeatureTypeId",
                        columns: x => new { x.FeatureCode, x.FeatureTypeId },
                        principalTable: "DcFeatureCurrAccs",
                        principalColumns: new[] { "FeatureCode", "FeatureTypeId" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TrCurrAccFeatures_DcFeatureTypeCurrAccs_FeatureTypeId",
                        column: x => x.FeatureTypeId,
                        principalTable: "DcFeatureTypeCurrAccs",
                        principalColumn: "FeatureTypeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "DcClaims",
                columns: new[] { "ClaimCode", "CategoryId", "ClaimDesc", "ClaimTypeId" },
                values: new object[,]
                {
                    { "CurrAccFeatureType", 19, "Cari Hesab Özəlliyi", (byte)1 },
                    { "DeleteInvoiceIT", 14, "Transfer Fakturası Silmə", (byte)1 },
                    { "DeleteLineIT", 14, "Məhsul Transfer Sətiri Silmə", (byte)1 },
                    { "InventoryTransferReturnCustom", 14, "Məhsul Transferi Qaytarması", (byte)1 }
                });

            migrationBuilder.UpdateData(
                table: "DcUnitOfMeasures",
                keyColumn: "UnitOfMeasureId",
                keyValue: 1,
                columns: new[] { "Level", "UnitOfMeasureDesc" },
                values: new object[] { (byte)0, "ədəd" });

            migrationBuilder.UpdateData(
                table: "DcUnitOfMeasures",
                keyColumn: "UnitOfMeasureId",
                keyValue: 2,
                columns: new[] { "Level", "UnitOfMeasureDesc" },
                values: new object[] { (byte)0, "kq" });

            migrationBuilder.CreateIndex(
                name: "IX_DcFeatureCurrAccs_FeatureTypeId",
                table: "DcFeatureCurrAccs",
                column: "FeatureTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_TrCurrAccFeatures_FeatureCode_FeatureTypeId",
                table: "TrCurrAccFeatures",
                columns: new[] { "FeatureCode", "FeatureTypeId" });

            migrationBuilder.CreateIndex(
                name: "IX_TrCurrAccFeatures_FeatureTypeId",
                table: "TrCurrAccFeatures",
                column: "FeatureTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TrCurrAccFeatures");

            migrationBuilder.DropTable(
                name: "DcFeatureCurrAccs");

            migrationBuilder.DropTable(
                name: "DcFeatureTypeCurrAccs");

            migrationBuilder.DeleteData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "DeleteInvoiceIT");

            migrationBuilder.DeleteData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "DeleteLineIT");

            migrationBuilder.DeleteData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "InventoryTransferReturnCustom");

            migrationBuilder.DeleteData(
                table: "DcUnitOfMeasures",
                keyColumn: "UnitOfMeasureId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "DcUnitOfMeasures",
                keyColumn: "UnitOfMeasureId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "TrRoleClaims",
                keyColumn: "RoleClaimId",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "CurrAccFeatureType");

            migrationBuilder.AlterColumn<byte>(
                name: "PaymentKindId",
                table: "TrPaymentHeaders",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0,
                oldClrType: typeof(byte),
                oldType: "tinyint",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "DcReports",
                keyColumn: "ReportId",
                keyValue: 6,
                column: "ReportQuery",
                value: "WITH PaymentLinesSum AS (\r\n    SELECT\r\n        ph.InvoiceHeaderId,\r\n        ph.CurrAccCode,\r\n        SUM(pl.PaymentLoc) AS PaymentLinesSum\r\n    FROM\r\n        TrPaymentLines pl\r\n    INNER JOIN\r\n        TrPaymentHeaders ph ON pl.PaymentHeaderId = ph.PaymentHeaderId\r\n    INNER JOIN\r\n        TrInstallments i ON ph.InvoiceHeaderId = i.InvoiceHeaderId\r\n    WHERE\r\n        ph.PaymentKindId = 3 -- payments without downpayments\r\n    GROUP BY\r\n        ph.InvoiceHeaderId, ph.CurrAccCode\r\n),\r\nDownPaymentSum AS (\r\n    SELECT\r\n        i.InvoiceHeaderId,\r\n        SUM(pl.PaymentLoc) AS DownPaymentSum\r\n    FROM\r\n        TrPaymentLines pl\r\n    INNER JOIN\r\n        TrPaymentHeaders ph ON pl.PaymentHeaderId = ph.PaymentHeaderId\r\n    INNER JOIN\r\n        TrInstallments i ON ph.InvoiceHeaderId = i.InvoiceHeaderId\r\n    WHERE\r\n        ph.PaymentKindId != 3 -- only downpayments\r\n    GROUP BY\r\n        i.InvoiceHeaderId\r\n),\r\nInstallmentData AS (\r\n    SELECT\r\n        i.InstallmentId,\r\n        i.InvoiceHeaderId,\r\n        i.DocumentDate,\r\n        i.Amount + COALESCE(ril.NetAmount, 0) AS Amount,\r\n        i.AmountLoc + COALESCE(ril.NetAmountLoc, 0) AS AmountLoc, \r\n        i.CurrencyCode,\r\n        i.ExchangeRate,\r\n        (i.AmountLoc + i.Commission) + COALESCE(ril.NetAmountLoc, 0) AS AmountWithComLoc,\r\n        ih.DocumentNumber,\r\n        ca.CurrAccDesc,\r\n        ca.PhoneNum,\r\n        pp.DurationInMonths,\r\n        COALESCE(psum.PaymentLinesSum, 0) AS TotalPaid,\r\n        COALESCE(dps.DownPaymentSum, 0) AS DownPayment\r\n    FROM\r\n        TrInstallments i\r\n    INNER JOIN\r\n        TrInvoiceHeaders ih ON i.InvoiceHeaderId = ih.InvoiceHeaderId\r\n    INNER JOIN\r\n        DcCurrAccs ca ON ih.CurrAccCode = ca.CurrAccCode\r\n    INNER JOIN\r\n        DcPaymentPlans pp ON i.PaymentPlanCode = pp.PaymentPlanCode\r\n    LEFT JOIN\r\n        PaymentLinesSum psum ON i.InvoiceHeaderId = psum.InvoiceHeaderId AND ih.CurrAccCode = psum.CurrAccCode\r\n    LEFT JOIN\r\n        DownPaymentSum dps ON i.InvoiceHeaderId = dps.InvoiceHeaderId\r\n    LEFT JOIN\r\n        TrInvoiceHeaders rih ON rih.RelatedInvoiceId = i.InvoiceHeaderId AND rih.IsReturn = 1 \r\n    LEFT JOIN\r\n        TrInvoiceLines ril ON ril.InvoiceHeaderId = rih.InvoiceHeaderId\r\n),\r\nCalculatedData AS (\r\n    SELECT\r\n        InstallmentId,\r\n        InvoiceHeaderId,\r\n        CurrAccDesc,\r\n        PhoneNum,\r\n        DocumentNumber,\r\n        DocumentDate,\r\n        Amount,\r\n        AmountWithComLoc,\r\n        CurrencyCode,\r\n        ExchangeRate,\r\n        DownPayment,\r\n        TotalPaid,\r\n		DurationInMonths,\r\n        AmountWithComLoc - TotalPaid AS RemainingBalance,\r\n        (AmountWithComLoc / NULLIF(DurationInMonths, 0)) AS MonthlyPayment,\r\n        FLOOR(TotalPaid / (AmountWithComLoc / NULLIF(DurationInMonths, 0))) AS MonthsPaid,\r\n        DATEADD(MONTH, FLOOR(TotalPaid / (AmountWithComLoc / NULLIF(DurationInMonths, 0))) + 1, DocumentDate) AS OverdueDate\r\n    FROM\r\n        InstallmentData\r\n)\r\nSELECT\r\n    InstallmentId,\r\n    InvoiceHeaderId,\r\n    CurrAccDesc,\r\n    PhoneNum,\r\n    DocumentNumber,\r\n    DocumentDate,\r\n    Amount,\r\n    CurrencyCode,\r\n    ExchangeRate,\r\n    MonthlyPayment,\r\n    [Tutar Faizi ilə] = AmountWithComLoc,\r\n	[Ay] = DurationInMonths,\r\n    [İlkin Ödəniş] = DownPayment,  -- Showing Down Payment Separately\r\n    [Toplam Ödəniş] = TotalPaid,   -- Payments excluding downpayment\r\n    [Qalıq] = RemainingBalance,\r\n    [Aylıq Ödəniş] = MonthlyPayment,\r\n    [Ödənilməli məbləğ] = TotalPaid - (DATEDIFF(DAY, DocumentDate, GETDATE()) / 30) * MonthlyPayment,\r\n    [Gecikmə tarixi] = OverdueDate,\r\n    [Gecikmiş Günlər] = CASE \r\n        WHEN GETDATE() > OverdueDate THEN DATEDIFF(DAY, OverdueDate, GETDATE())\r\n        ELSE 0\r\n    END\r\nFROM\r\n    CalculatedData;\r\n");

            migrationBuilder.UpdateData(
                table: "DcUnitOfMeasures",
                keyColumn: "UnitOfMeasureId",
                keyValue: 1,
                columns: new[] { "Level", "UnitOfMeasureDesc" },
                values: new object[] { (byte)1, "Ədəd" });

            migrationBuilder.UpdateData(
                table: "DcUnitOfMeasures",
                keyColumn: "UnitOfMeasureId",
                keyValue: 2,
                columns: new[] { "Level", "UnitOfMeasureDesc" },
                values: new object[] { (byte)1, "Qutu" });
        }
    }
}
