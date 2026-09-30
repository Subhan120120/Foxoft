using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Foxoft.Migrations
{
    /// <inheritdoc />
    public partial class payrol : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.InsertData(
                table: "DcReports",
                columns: new[] { "ReportId", "ReportCategoryId", "ReportFilter", "ReportLayout", "ReportName", "ReportQuery", "ReportTypeId" },
                values: new object[] { 10, null, null, "", "Report_Embedded_PayrollReport", "select prh.Id\n	, prh.CurrAccCode\n	, prh.PayrollPeriodId\n	, prh.GrossSalary\n	, prh.NetSalary\n	, PayrollLineId = prl.Id\n	, prl.PayrollItemType\n	, PayrollItemTypeName = case prl.PayrollItemType\n		when 1 then 'Maaş'\n		when 2 then 'Bonus'\n		when 3 then 'Əlavə İş'\n		when 4 then 'Vergi'\n		when 5 then 'Sığorta'\n		when 6 then 'Tutulma'\n		else 'Digər'\n	  end\n	, LineDescription = prl.Description\n	, prl.Amount\n	, prl.CurrencyCode\n	, prl.ExchangeRate\n	, prl.AmountLoc\n	, cari.CurrAccDesc\n	, cari.FirstName\n	, cari.LastName\n	, cari.PhoneNum\n	, EmployeeName = isnull(nullif(cari.CurrAccDesc, ''), rtrim(isnull(cari.FirstName, '') + ' ' + isnull(cari.LastName, '')))\n	, prp.PeriodYear\n	, prp.PeriodMonth\n	, PeriodName = right('0000' + cast(prp.PeriodYear as varchar(4)), 4) + '-' + right('00' + cast(prp.PeriodMonth as varchar(2)), 2)\n\n	from TrPayrollLines prl\n	inner join TrPayrollHeaders prh on prl.PayrollHeaderId = prh.Id\n	left join DcPayrollPeriods prp on prh.PayrollPeriodId = prp.Id\n	left join DcCurrAccs cari on cari.CurrAccCode = prh.CurrAccCode\n\n	where prh.Id = @PayrollHeaderId\n	order by prl.PayrollItemType\n", (byte)0 });

            migrationBuilder.InsertData(
                table: "DcReportVariables",
                columns: new[] { "VariableId", "ReportId", "Representative", "VariableOperator", "VariableProperty", "VariableTypeId", "VariableValue", "VariableValueType" },
                values: new object[] { 5, 10, "@PayrollHeaderId", "", "PayrollHeaderId", (byte)1, "", "System.Guid" });

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrPayrollLines_DcCurrencies_CurrencyCode",
                table: "TrPayrollLines");

            migrationBuilder.DropIndex(
                name: "IX_TrPayrollLines_CurrencyCode",
                table: "TrPayrollLines");

            migrationBuilder.DeleteData(
                table: "DcReportVariables",
                keyColumn: "VariableId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "DcShortcuts",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "DcShortcuts",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "DcShortcuts",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "DcShortcuts",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "TrRoleClaims",
                keyColumn: "RoleClaimId",
                keyValue: 218);

            migrationBuilder.DeleteData(
                table: "TrRoleClaims",
                keyColumn: "RoleClaimId",
                keyValue: 219);

            migrationBuilder.DeleteData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "ChangeCurrAccPassword");

            migrationBuilder.DeleteData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "DailyExpense");

            migrationBuilder.DeleteData(
                table: "DcReports",
                keyColumn: "ReportId",
                keyValue: 10);

            migrationBuilder.DropColumn(
                name: "AmountLoc",
                table: "TrPayrollLines");

            migrationBuilder.DropColumn(
                name: "CurrencyCode",
                table: "TrPayrollLines");

            migrationBuilder.DropColumn(
                name: "ExchangeRate",
                table: "TrPayrollLines");

            migrationBuilder.DropColumn(
                name: "IsDailyExpense",
                table: "TrInvoiceHeaders");

            migrationBuilder.UpdateData(
                table: "DcReports",
                keyColumn: "ReportId",
                keyValue: 9,
                column: "ReportQuery",
                value: "\r\n\r\nselect ph.*\r\n	, ProcessDesc\r\n	, pl.PaymentLineId\r\n	, pl.PaymentTypeCode\r\n	, pl.Payment\r\n	, pl.PaymentLoc\r\n	, pl.CurrencyCode\r\n	, pl.ExchangeRate\r\n	, pl.LineDescription\r\n	, pl.CashRegisterCode\r\n	, pl.PaymentMethodId\r\n	, cari.CurrAccDesc\r\n	, cari.PhoneNum\r\n	, CashRegisterDesc = kassa.CurrAccDesc\r\n	, DcPaymentTypes.PaymentTypeDesc\r\n	, CurrAccBalance = dbo.CurrAccBalance(ph.CurrAccCode, CAST(ph.DocumentDate as Datetime) + CAST(ph.DocumentTime as Datetime))\r\n	\r\n	, StorePhoneNum = store.PhoneNum\r\n	, StoreAddress = store.Address\r\n\r\n	from TrPaymentLines pl \r\n	left join TrPaymentHeaders ph on pl.PaymentHeaderId = ph.PaymentHeaderId\r\n	left join DcPaymentTypes on DcPaymentTypes.PaymentTypeCode = pl.PaymentTypeCode\r\n	left join DcCurrAccs cari on cari.CurrAccCode = ph.CurrAccCode\r\n	left join DcCurrAccs kassa on kassa.CurrAccCode = pl.CashRegisterCode\r\n	left join DcProcesses on DcProcesses.ProcessCode = ph.ProcessCode\r\n	left join DcCurrAccs store on store.CurrAccCode = ph.StoreCode\r\n	left join DcCurrencies on DcCurrencies.CurrencyCode = pl.CurrencyCode\r\n\r\n	where ph.PaymentHeaderId = @PaymentHeaderId\n	order by DocumentDate\n");
        }
    }
}
