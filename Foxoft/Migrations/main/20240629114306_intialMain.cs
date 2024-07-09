using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Foxoft.Migrations.main
{
    /// <inheritdoc />
    public partial class intialMain : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DcCompanies",
                columns: table => new
                {
                    CompanyCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CompanyDesc = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    IsDisabled = table.Column<bool>(type: "bit", nullable: false),
                    RowGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DcCompanies", x => x.CompanyCode);
                });

            migrationBuilder.InsertData(
                table: "DcCompanies",
                columns: new[] { "CompanyCode", "CompanyDesc", "IsDisabled", "RowGuid" },
                values: new object[] { "Company01", "Şirkət01", false, new Guid("00000000-0000-0000-0000-000000000000") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DcCompanies");
        }
    }
}
