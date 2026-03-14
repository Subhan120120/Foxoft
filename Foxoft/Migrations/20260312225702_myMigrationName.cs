using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Foxoft.Migrations
{
    /// <inheritdoc />
    public partial class myMigrationName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CloseRequestReason",
                table: "DocumentLocks");

            migrationBuilder.DropColumn(
                name: "CloseRequestedAtUtc",
                table: "DocumentLocks");

            migrationBuilder.DropColumn(
                name: "CloseRequestedByUserId",
                table: "DocumentLocks");
        }
    }
}
