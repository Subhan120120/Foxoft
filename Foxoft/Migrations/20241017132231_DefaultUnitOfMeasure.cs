using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Foxoft.Migrations
{
    /// <inheritdoc />
    public partial class DefaultUnitOfMeasure : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DefaultUnitOfMeasure",
                table: "DcProducts",
                type: "nvarchar(50)",
                nullable: true,
                defaultValueSql: "1");

            migrationBuilder.AlterColumn<Guid>(
                name: "RowGuid",
                table: "DcCurrAccs",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.CreateIndex(
                name: "IX_DcProducts_DefaultUnitOfMeasure",
                table: "DcProducts",
                column: "DefaultUnitOfMeasure");

            migrationBuilder.AddForeignKey(
                name: "FK_DcProducts_DcUnitOfMeasures_DefaultUnitOfMeasure",
                table: "DcProducts",
                column: "DefaultUnitOfMeasure",
                principalTable: "DcUnitOfMeasures",
                principalColumn: "UnitOfMeasureCode",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DcProducts_DcUnitOfMeasures_DefaultUnitOfMeasure",
                table: "DcProducts");

            migrationBuilder.DropIndex(
                name: "IX_DcProducts_DefaultUnitOfMeasure",
                table: "DcProducts");

            migrationBuilder.DropColumn(
                name: "DefaultUnitOfMeasure",
                table: "DcProducts");

            migrationBuilder.AlterColumn<Guid>(
                name: "RowGuid",
                table: "DcCurrAccs",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "DcCurrAccs",
                keyColumn: "CurrAccCode",
                keyValue: "C-000001",
                column: "RowGuid",
                value: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "DcCurrAccs",
                keyColumn: "CurrAccCode",
                keyValue: "C-000002",
                column: "RowGuid",
                value: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "DcCurrAccs",
                keyColumn: "CurrAccCode",
                keyValue: "C-000003",
                column: "RowGuid",
                value: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "DcCurrAccs",
                keyColumn: "CurrAccCode",
                keyValue: "C-000004",
                column: "RowGuid",
                value: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "DcCurrAccs",
                keyColumn: "CurrAccCode",
                keyValue: "C-000005",
                column: "RowGuid",
                value: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "DcCurrAccs",
                keyColumn: "CurrAccCode",
                keyValue: "kassa01",
                column: "RowGuid",
                value: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "DcCurrAccs",
                keyColumn: "CurrAccCode",
                keyValue: "mgz01",
                column: "RowGuid",
                value: new Guid("00000000-0000-0000-0000-000000000000"));
        }
    }
}
