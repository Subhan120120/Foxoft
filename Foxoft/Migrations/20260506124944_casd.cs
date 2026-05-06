using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Foxoft.Migrations
{
    /// <inheritdoc />
    public partial class casd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "DcClaims",
                columns: new[] { "ClaimCode", "CategoryId", "ClaimDesc", "ClaimTypeId" },
                values: new object[] { "CurrencyList", 15, "Valyuta Siyahısı", (byte)1 });

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TrRoleClaims",
                keyColumn: "RoleClaimId",
                keyValue: 66);

            migrationBuilder.DeleteData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "CurrencyList");

            migrationBuilder.UpdateData(
                table: "DcReports",
                keyColumn: "ReportId",
                keyValue: 9,
                column: "ReportQuery",
                value: "\n\nselect ph.*\n	, ProcessDesc\n	, pl.PaymentLineId\n	, pl.PaymentTypeCode\n	, pl.Payment\n	, pl.PaymentLoc\n	, pl.CurrencyCode\n	, pl.ExchangeRate\n	, pl.LineDescription\n	, pl.CashRegisterCode\n	, pl.PaymentMethodId\n	, cari.CurrAccDesc\n	, cari.PhoneNum\n	, CashRegisterDesc = kassa.CurrAccDesc\n	, DcPaymentTypes.PaymentTypeDesc\n	, CurrAccBalance = dbo.CurrAccBalance(ph.CurrAccCode, DocumentDate)\n	from TrPaymentLines pl \n	left join TrPaymentHeaders ph on pl.PaymentHeaderId = ph.PaymentHeaderId\n	left join DcPaymentTypes on DcPaymentTypes.PaymentTypeCode = pl.PaymentTypeCode\n	left join DcCurrAccs cari on cari.CurrAccCode = ph.CurrAccCode\n	left join DcCurrAccs kassa on kassa.CurrAccCode = pl.CashRegisterCode\n	left join DcProcesses on DcProcesses.ProcessCode = ph.ProcessCode\n\n	where ph.ProcessCode = 'PA' AND ph.PaymentHeaderId = @PaymentHeaderId\n	order by DocumentDate\n\n");
        }
    }
}
