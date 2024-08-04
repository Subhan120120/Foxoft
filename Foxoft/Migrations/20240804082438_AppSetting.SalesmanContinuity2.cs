﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Foxoft.Migrations
{
    /// <inheritdoc />
    public partial class AppSettingSalesmanContinuity2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SalesmanContinuity",
                table: "AppSettings");

            migrationBuilder.AddColumn<bool>(
                name: "SalesmanContinuity",
                table: "SettingStores",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "SettingStores",
                keyColumn: "Id",
                keyValue: 1,
                column: "SalesmanContinuity",
                value: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SalesmanContinuity",
                table: "SettingStores");

            migrationBuilder.AddColumn<bool>(
                name: "SalesmanContinuity",
                table: "AppSettings",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AppSettings",
                keyColumn: "Id",
                keyValue: 1,
                column: "SalesmanContinuity",
                value: false);
        }
    }
}
