using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Foxoft.Migrations
{
    /// <inheritdoc />
    public partial class asdfdfd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.AddColumn<bool>(
                name: "CopyToClipboard",
                table: "TrFormReports",
                type: "bit",
                nullable: false,
                defaultValueSql: "0");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "DcReports",
                keyColumn: "ReportId",
                keyValue: 9,
                column: "ReportQuery",
                value: "\r\n\r\nselect ph.*\r\n	, ProcessDesc\r\n	, pl.PaymentLineId\r\n	, pl.PaymentTypeCode\r\n	, pl.Payment\r\n	, pl.PaymentLoc\r\n	, pl.CurrencyCode\r\n	, pl.ExchangeRate\r\n	, pl.LineDescription\r\n	, pl.CashRegisterCode\r\n	, pl.PaymentMethodId\r\n	, cari.CurrAccDesc\r\n	, cari.PhoneNum\r\n	, CashRegisterDesc = kassa.CurrAccDesc\r\n	, DcPaymentTypes.PaymentTypeDesc\r\n	, CurrAccBalance = dbo.CurrAccBalance(ph.CurrAccCode, CAST(ph.DocumentDate as Datetime) + CAST(ph.DocumentTime as Datetime))\r\n	\r\n	, StorePhoneNum = store.PhoneNum\r\n	, StoreAddress = store.Address\r\n\r\n	from TrPaymentLines pl \r\n	left join TrPaymentHeaders ph on pl.PaymentHeaderId = ph.PaymentHeaderId\r\n	left join DcPaymentTypes on DcPaymentTypes.PaymentTypeCode = pl.PaymentTypeCode\r\n	left join DcCurrAccs cari on cari.CurrAccCode = ph.CurrAccCode\r\n	left join DcCurrAccs kassa on kassa.CurrAccCode = pl.CashRegisterCode\r\n	left join DcProcesses on DcProcesses.ProcessCode = ph.ProcessCode\r\n	left join DcCurrAccs store on store.CurrAccCode = ph.StoreCode\r\n	left join DcCurrencies on DcCurrencies.CurrencyCode = pl.CurrencyCode\r\n\r\n	where ph.ProcessCode = 'PA' AND ph.PaymentHeaderId = @PaymentHeaderId\r\n	order by DocumentDate\r\n\r\n");
        }
    }
}
