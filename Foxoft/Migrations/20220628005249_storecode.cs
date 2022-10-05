using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Foxoft.Migrations
{
    public partial class storecode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DcStores");

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "DcCurrAccs",
                type: "nvarchar(60)",
                maxLength: 60,
                nullable: true,
                defaultValueSql: "space(0)",
                oldClrType: typeof(string),
                oldType: "nvarchar(60)",
                oldMaxLength: 60,
                oldDefaultValueSql: "space(0)");

            migrationBuilder.AddColumn<string>(
                name: "CurrAccDesc",
                table: "DcCurrAccs",
                type: "nvarchar(60)",
                maxLength: 60,
                nullable: true);

            migrationBuilder.UpdateData(
                table: "DcCurrAccTypes",
                keyColumn: "CurrAccTypeCode",
                keyValue: (byte)3,
                column: "CurrAccTypeDesc",
                value: "Mağaza");

            migrationBuilder.InsertData(
                table: "DcCurrAccTypes",
                columns: new[] { "CurrAccTypeCode", "CurrAccTypeDesc", "IsDisabled", "RowGuid" },
                values: new object[] { (byte)4, "Personal", false, new Guid("00000000-0000-0000-0000-000000000000") });

            migrationBuilder.InsertData(
                table: "DcCurrAccs",
                columns: new[] { "CurrAccCode", "CompanyCode", "ConfirmPassword", "CurrAccDesc", "CurrAccTypeCode", "CustomerTypeCode", "FirstName", "NewPassword", "PhoneNum", "RowGuid", "StoreCode", "VendorTypeCode" },
                values: new object[] { "mgz01", (byte)0, null, "Merkez", (byte)3, null, "Orxan", "456", "0773628800", new Guid("00000000-0000-0000-0000-000000000000"), null, null });

            migrationBuilder.UpdateData(
                table: "DcCurrAccs",
                keyColumn: "CurrAccCode",
                keyValue: "CA-4",
                column: "CurrAccTypeCode",
                value: (byte)4);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DcCurrAccTypes",
                keyColumn: "CurrAccTypeCode",
                keyValue: (byte)4);

            migrationBuilder.DeleteData(
                table: "DcCurrAccs",
                keyColumn: "CurrAccCode",
                keyValue: "mgz01");

            migrationBuilder.DropColumn(
                name: "CurrAccDesc",
                table: "DcCurrAccs");

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "DcCurrAccs",
                type: "nvarchar(60)",
                maxLength: 60,
                nullable: false,
                defaultValueSql: "space(0)",
                oldClrType: typeof(string),
                oldType: "nvarchar(60)",
                oldMaxLength: 60,
                oldNullable: true,
                oldDefaultValueSql: "space(0)");

            migrationBuilder.CreateTable(
                name: "DcStores",
                columns: table => new
                {
                    StoreCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CompanyCode = table.Column<decimal>(type: "numeric(4,0)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    CreatedUserName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, defaultValueSql: "substring(suser_name(),patindex('%\\%',suser_name())+(1),(20))"),
                    IsDisabled = table.Column<bool>(type: "bit", nullable: false),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    LastUpdatedUserName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, defaultValueSql: "substring(suser_name(),patindex('%\\%',suser_name())+(1),(20))"),
                    RowGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StoreDesc = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false, defaultValueSql: "space(0)")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DcStores", x => x.StoreCode);
                });

            migrationBuilder.UpdateData(
                table: "DcCurrAccTypes",
                keyColumn: "CurrAccTypeCode",
                keyValue: (byte)3,
                column: "CurrAccTypeDesc",
                value: "Personal");

            migrationBuilder.UpdateData(
                table: "DcCurrAccs",
                keyColumn: "CurrAccCode",
                keyValue: "CA-4",
                column: "CurrAccTypeCode",
                value: (byte)3);

            migrationBuilder.InsertData(
                table: "DcStores",
                columns: new[] { "StoreCode", "CompanyCode", "IsDisabled", "RowGuid", "StoreDesc" },
                values: new object[,]
                {
                    { "mgz01", 0m, false, new Guid("00000000-0000-0000-0000-000000000000"), "Bakıxanov" },
                    { "mgz02", 0m, false, new Guid("00000000-0000-0000-0000-000000000000"), "Elmlər" }
                });
        }
    }
}
