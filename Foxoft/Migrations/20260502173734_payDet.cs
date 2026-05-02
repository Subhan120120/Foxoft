using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Foxoft.Migrations
{
    /// <inheritdoc />
    public partial class payDet : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TrWhatsAppMessageLogs",
                columns: table => new
                {
                    WhatsAppMessageLogId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DocumentHeaderId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ReceiverPhoneNumber = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    MessageType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Sender = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    CreatedUserName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, defaultValueSql: "substring(suser_name(),patindex('%\\%',suser_name())+(1),(20))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    LastUpdatedUserName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, defaultValueSql: "substring(suser_name(),patindex('%\\%',suser_name())+(1),(20))"),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrWhatsAppMessageLogs", x => x.WhatsAppMessageLogId);
                });

            migrationBuilder.InsertData(
                table: "DcReports",
                columns: new[] { "ReportId", "ReportCategoryId", "ReportFilter", "ReportLayout", "ReportName", "ReportQuery", "ReportTypeId" },
                values: new object[] { 9, null, null, "", "Report_Embedded_PaymentReport", "\n\nselect ph.*\n	, ProcessDesc\n	, pl.PaymentLineId\n	, pl.PaymentTypeCode\n	, pl.Payment\n	, pl.PaymentLoc\n	, pl.CurrencyCode\n	, pl.ExchangeRate\n	, pl.LineDescription\n	, pl.CashRegisterCode\n	, pl.PaymentMethodId\n	, cari.CurrAccDesc\n	, cari.PhoneNum\n	, CashRegisterDesc = kassa.CurrAccDesc\n	, DcPaymentTypes.PaymentTypeDesc\n	, CurrAccBalance = dbo.CurrAccBalance(ph.CurrAccCode, DocumentDate)\n	from TrPaymentLines pl \n	left join TrPaymentHeaders ph on pl.PaymentHeaderId = ph.PaymentHeaderId\n	left join DcPaymentTypes on DcPaymentTypes.PaymentTypeCode = pl.PaymentTypeCode\n	left join DcCurrAccs cari on cari.CurrAccCode = ph.CurrAccCode\n	left join DcCurrAccs kassa on kassa.CurrAccCode = pl.CashRegisterCode\n	left join DcProcesses on DcProcesses.ProcessCode = ph.ProcessCode\n\n	where ph.ProcessCode = 'PA' AND ph.PaymentHeaderId = @PaymentHeaderId\n	order by DocumentDate\n\n", (byte)0 });

            migrationBuilder.InsertData(
                table: "DcReportVariables",
                columns: new[] { "VariableId", "ReportId", "Representative", "VariableOperator", "VariableProperty", "VariableTypeId", "VariableValue", "VariableValueType" },
                values: new object[] { 4, 9, "@PaymentHeaderId", "", "PaymentHeaderId", (byte)1, "", "System.Guid" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TrWhatsAppMessageLogs");

            migrationBuilder.DeleteData(
                table: "DcReportVariables",
                keyColumn: "VariableId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "DcReports",
                keyColumn: "ReportId",
                keyValue: 9);
        }
    }
}
