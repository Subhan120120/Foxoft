using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Foxoft.Migrations
{
    /// <inheritdoc />
    public partial class lockService2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClientProcessId",
                table: "DocumentLocks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "ForceCloseRequestedAtUtc",
                table: "DocumentLocks",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "FormInstanceId",
                table: "DocumentLocks",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClientProcessId",
                table: "DocumentLocks");

            migrationBuilder.DropColumn(
                name: "ForceCloseRequestedAtUtc",
                table: "DocumentLocks");

            migrationBuilder.DropColumn(
                name: "FormInstanceId",
                table: "DocumentLocks");
        }
    }
}
