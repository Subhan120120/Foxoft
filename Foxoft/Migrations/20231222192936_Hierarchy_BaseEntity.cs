using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Foxoft.Migrations
{
    public partial class Hierarchy_BaseEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "DcHierarchies",
                type: "datetime",
                nullable: false,
                defaultValueSql: "getdate()");

            migrationBuilder.AddColumn<string>(
                name: "CreatedUserName",
                table: "DcHierarchies",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true,
                defaultValueSql: "substring(suser_name(),patindex('%\\%',suser_name())+(1),(20))");

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdatedDate",
                table: "DcHierarchies",
                type: "datetime",
                nullable: false,
                defaultValueSql: "getdate()");

            migrationBuilder.AddColumn<string>(
                name: "LastUpdatedUserName",
                table: "DcHierarchies",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true,
                defaultValueSql: "substring(suser_name(),patindex('%\\%',suser_name())+(1),(20))");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "DcHierarchies");

            migrationBuilder.DropColumn(
                name: "CreatedUserName",
                table: "DcHierarchies");

            migrationBuilder.DropColumn(
                name: "LastUpdatedDate",
                table: "DcHierarchies");

            migrationBuilder.DropColumn(
                name: "LastUpdatedUserName",
                table: "DcHierarchies");
        }
    }
}
