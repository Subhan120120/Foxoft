using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Foxoft.Migrations
{
    /// <inheritdoc />
    public partial class loyalty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DcLoyaltyPrograms",
                columns: table => new
                {
                    LoyaltyProgramId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    EarnPercent = table.Column<decimal>(type: "decimal(9,2)", nullable: false),
                    ExpireDays = table.Column<int>(type: "int", nullable: true),
                    MaxRedeemPercent = table.Column<decimal>(type: "decimal(9,2)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DcLoyaltyPrograms", x => x.LoyaltyProgramId);
                });

            migrationBuilder.CreateTable(
                name: "DcLoyaltyCards",
                columns: table => new
                {
                    LoyaltyCardId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CardNumber = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    CurrAccCode = table.Column<string>(type: "nvarchar(30)", nullable: false),
                    LoyaltyProgramId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    CreatedUserName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, defaultValueSql: "substring(suser_name(),patindex('%\\%',suser_name())+(1),(20))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    LastUpdatedUserName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, defaultValueSql: "substring(suser_name(),patindex('%\\%',suser_name())+(1),(20))"),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DcLoyaltyCards", x => x.LoyaltyCardId);
                    table.ForeignKey(
                        name: "FK_DcLoyaltyCards_DcCurrAccs_CurrAccCode",
                        column: x => x.CurrAccCode,
                        principalTable: "DcCurrAccs",
                        principalColumn: "CurrAccCode",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DcLoyaltyCards_DcLoyaltyPrograms_LoyaltyProgramId",
                        column: x => x.LoyaltyProgramId,
                        principalTable: "DcLoyaltyPrograms",
                        principalColumn: "LoyaltyProgramId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TrLoyaltyTxns",
                columns: table => new
                {
                    LoyaltyTxnId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoyaltyCardId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CurrAccCode = table.Column<string>(type: "nvarchar(30)", nullable: false),
                    TxnType = table.Column<byte>(type: "tinyint", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DocumentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpireAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    InvoiceHeaderId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PaymentHeaderId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RelatedLoyaltyTxnId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrLoyaltyTxns", x => x.LoyaltyTxnId);
                    table.ForeignKey(
                        name: "FK_TrLoyaltyTxns_DcCurrAccs_CurrAccCode",
                        column: x => x.CurrAccCode,
                        principalTable: "DcCurrAccs",
                        principalColumn: "CurrAccCode",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TrLoyaltyTxns_DcLoyaltyCards_LoyaltyCardId",
                        column: x => x.LoyaltyCardId,
                        principalTable: "DcLoyaltyCards",
                        principalColumn: "LoyaltyCardId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TrLoyaltyTxns_TrInvoiceHeaders_InvoiceHeaderId",
                        column: x => x.InvoiceHeaderId,
                        principalTable: "TrInvoiceHeaders",
                        principalColumn: "InvoiceHeaderId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TrLoyaltyTxns_TrLoyaltyTxns_RelatedLoyaltyTxnId",
                        column: x => x.RelatedLoyaltyTxnId,
                        principalTable: "TrLoyaltyTxns",
                        principalColumn: "LoyaltyTxnId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TrLoyaltyTxns_TrPaymentHeaders_PaymentHeaderId",
                        column: x => x.PaymentHeaderId,
                        principalTable: "TrPaymentHeaders",
                        principalColumn: "PaymentHeaderId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "DcReports",
                columns: new[] { "ReportId", "ReportCategoryId", "ReportFilter", "ReportLayout", "ReportName", "ReportQuery", "ReportTypeId" },
                values: new object[,]
                {
                    { 20, 1, null, "", "Alacaqlar", "\r\n\r\n\r\n\r\n--declare @EndDate date = dateadd(DAY, 1, getdate())\r\n--declare @EndTime time =  '00:00:00.000'\r\n\r\nselect DcCurrAccs.CurrAccCode\r\n, CurrAccDesc\r\n, PhoneNum\r\n, IsVIP\r\n, Amount = sum(isnull(Amount,0))\r\n, DcCurrAccs.CurrAccTypeCode\r\n, CurrAccTypeDesc\r\n	from \r\nDcCurrAccs \r\nleft join \r\n(\r\n	select CurrAccCode\r\n	, Amount = (QtyIn - QtyOut) * (PriceLoc - (PriceLoc * PosDiscount / 100))  -- (-2) * 100 = -200 usd\r\n	--, Amount = NetAmountLoc  -- (-2) * 100 = -200 usd\r\n	from TrInvoiceLines il\r\n	left join TrInvoiceHeaders ih  on il.InvoiceHeaderId = ih.InvoiceHeaderId\r\n\r\n--	where 1=1\r\n--	and (CAST(ih.DocumentDate AS DATETIME) + CAST(ih.DocumentTime AS DATETIME)) <=\r\n--	(CAST(@EndDate AS DATETIME) + CAST(@EndTime AS DATETIME))\r\n\r\n	UNION ALL \r\n	\r\n	select CurrAccCode\r\n	, Amount = PaymentLoc -- 200 usd\r\n	from TrPaymentLines pl\r\n	left join TrPaymentHeaders ph on pl.PaymentHeaderId = ph.PaymentHeaderId\r\n	\r\n--	where 1=1 \r\n--	and (CAST(ph.OperationDate AS DATETIME) + CAST(ph.OperationTime AS DATETIME)) <=\r\n--	(CAST(@EndDate AS DATETIME) + CAST(@EndTime AS DATETIME))\r\n) as balance on balance.CurrAccCode = DcCurrAccs.CurrAccCode\r\njoin DcCurrAccTypes on DcCurrAccTypes.CurrAccTypeCode = DcCurrAccs.CurrAccTypeCode\r\nwhere 1 = 1 \r\n	--and DcCurrAccs.IsVIP = 1 \r\n	--and balance.CurrAccCode = '1403'\r\ngroup by DcCurrAccs.CurrAccCode\r\n, CurrAccDesc\r\n, PhoneNum\r\n, IsVIP\r\n, DcCurrAccs.CurrAccTypeCode\r\n, CurrAccTypeDesc\r\n\r\nhaving   sum(Amount) < 0\r\norder by CurrAccDesc\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n", (byte)1 },
                    { 21, 2, null, "", "Verəcəklər", "\r\n\r\n\r\n--declare @EndDate date = dateadd(DAY, 1, getdate())\r\n--declare @EndTime time =  '00:00:00.000'\r\n\r\nselect DcCurrAccs.CurrAccCode\r\n, CurrAccDesc\r\n, PhoneNum\r\n, IsVIP\r\n, Amount = sum(Amount)\r\nfrom \r\nDcCurrAccs \r\nleft join \r\n(\r\n	select CurrAccCode\r\n	, Amount = (QtyIn - QtyOut) * (PriceLoc - (PriceLoc * PosDiscount / 100))  -- (-2) * 100 = -200 usd\r\n	--, Amount = NetAmountLoc  -- (-2) * 100 = -200 usd\r\n	from TrInvoiceLines il\r\n	left join TrInvoiceHeaders ih  on il.InvoiceHeaderId = ih.InvoiceHeaderId\r\n\r\n--	where 1=1\r\n--	and (CAST(ih.DocumentDate AS DATETIME) + CAST(ih.DocumentTime AS DATETIME)) <=\r\n--	(CAST(@EndDate AS DATETIME) + CAST(@EndTime AS DATETIME))\r\n\r\n	UNION ALL \r\n	\r\n	select CurrAccCode\r\n	, Amount = PaymentLoc -- 200 usd\r\n	from TrPaymentLines pl\r\n	left join TrPaymentHeaders ph on pl.PaymentHeaderId = ph.PaymentHeaderId\r\n	\r\n--	where 1=1 \r\n--	and (CAST(ph.OperationDate AS DATETIME) + CAST(ph.OperationTime AS DATETIME)) <=\r\n--	(CAST(@EndDate AS DATETIME) + CAST(@EndTime AS DATETIME))\r\n) as balance on balance.CurrAccCode = DcCurrAccs.CurrAccCode\r\nwhere 1 = 1 \r\nand CurrAccTypeCode in (1,2,3)\r\n	--and DcCurrAccs.IsVIP = 1 \r\n	--and balance.CurrAccCode = '1403'\r\ngroup by DcCurrAccs.CurrAccCode\r\n, CurrAccDesc\r\n, PhoneNum\r\n, IsVIP\r\n\r\nhaving   sum(Amount) > 0\r\n", (byte)1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_DcLoyaltyCards_CardNumber",
                table: "DcLoyaltyCards",
                column: "CardNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DcLoyaltyCards_CurrAccCode",
                table: "DcLoyaltyCards",
                column: "CurrAccCode");

            migrationBuilder.CreateIndex(
                name: "IX_DcLoyaltyCards_LoyaltyProgramId",
                table: "DcLoyaltyCards",
                column: "LoyaltyProgramId");

            migrationBuilder.CreateIndex(
                name: "IX_DcLoyaltyPrograms_Name",
                table: "DcLoyaltyPrograms",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TrLoyaltyTxns_CurrAccCode",
                table: "TrLoyaltyTxns",
                column: "CurrAccCode");

            migrationBuilder.CreateIndex(
                name: "IX_TrLoyaltyTxns_InvoiceHeaderId",
                table: "TrLoyaltyTxns",
                column: "InvoiceHeaderId");

            migrationBuilder.CreateIndex(
                name: "IX_TrLoyaltyTxns_LoyaltyCardId_DocumentDate",
                table: "TrLoyaltyTxns",
                columns: new[] { "LoyaltyCardId", "DocumentDate" });

            migrationBuilder.CreateIndex(
                name: "IX_TrLoyaltyTxns_PaymentHeaderId",
                table: "TrLoyaltyTxns",
                column: "PaymentHeaderId");

            migrationBuilder.CreateIndex(
                name: "IX_TrLoyaltyTxns_RelatedLoyaltyTxnId",
                table: "TrLoyaltyTxns",
                column: "RelatedLoyaltyTxnId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TrLoyaltyTxns");

            migrationBuilder.DropTable(
                name: "DcLoyaltyCards");

            migrationBuilder.DropTable(
                name: "DcLoyaltyPrograms");

            migrationBuilder.DeleteData(
                table: "DcReports",
                keyColumn: "ReportId",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "DcReports",
                keyColumn: "ReportId",
                keyValue: 21);
        }
    }
}
