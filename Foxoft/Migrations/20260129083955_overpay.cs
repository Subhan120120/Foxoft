using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Foxoft.Migrations
{
    /// <inheritdoc />
    public partial class overpay : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            

            migrationBuilder.AlterColumn<decimal>(
                name: "BalanceWarningLevel",
                table: "DcProducts",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDefault",
                table: "DcCurrAccs",
                type: "bit",
                nullable: false,
                defaultValueSql: "0",
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AddColumn<byte>(
                name: "OverpaymentMode",
                table: "AppSettings",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.UpdateData(
                table: "AppSettings",
                keyColumn: "Id",
                keyValue: 1,
                column: "OverpaymentMode",
                value: (byte)0);

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DcProducts",
                keyColumn: "ProductCode",
                keyValue: "01");

            migrationBuilder.DeleteData(
                table: "DcProducts",
                keyColumn: "ProductCode",
                keyValue: "02");

            migrationBuilder.DropColumn(
                name: "OverpaymentMode",
                table: "AppSettings");

            migrationBuilder.AlterColumn<decimal>(
                name: "BalanceWarningLevel",
                table: "DcProducts",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDefault",
                table: "DcCurrAccs",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValueSql: "0");

            migrationBuilder.UpdateData(
                table: "DcProducts",
                keyColumn: "ProductCode",
                keyValue: "test01",
                column: "BalanceWarningLevel",
                value: 0m);

            migrationBuilder.UpdateData(
                table: "DcProducts",
                keyColumn: "ProductCode",
                keyValue: "test02",
                column: "BalanceWarningLevel",
                value: 0m);

            migrationBuilder.InsertData(
                table: "DcProducts",
                columns: new[] { "ProductCode", "BalanceWarningLevel", "CreatedDate", "DefaultUnitOfMeasureId", "HierarchyCode", "ImagePath", "ProductCode2", "ProductDesc", "ProductFeature", "ProductTypeCode", "PromotionCode", "PromotionCode2" },
                values: new object[,]
                {
                    { "xerc01", 0m, new DateTime(1901, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, null, "Yol Xərci", null, (byte)2, null, null },
                    { "xerc02", 0m, new DateTime(1901, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, null, "İşıq Pulu", null, (byte)2, null, null }
                });
        }
    }
}
