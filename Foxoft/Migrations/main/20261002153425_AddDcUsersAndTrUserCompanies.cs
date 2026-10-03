using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Foxoft.Migrations.main
{
    /// <inheritdoc />
    public partial class AddDcUsersAndTrUserCompanies : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DcUsers",
                columns: table => new
                {
                    UserName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UserDesc = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IsDisabled = table.Column<bool>(type: "bit", nullable: false),
                    RowGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DcUsers", x => x.UserName);
                });

            migrationBuilder.CreateTable(
                name: "TrUserCompanies",
                columns: table => new
                {
                    UserCompanyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    CompanyCode = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrUserCompanies", x => x.UserCompanyId);
                    table.ForeignKey(
                        name: "FK_TrUserCompanies_DcCompanies_CompanyCode",
                        column: x => x.CompanyCode,
                        principalTable: "DcCompanies",
                        principalColumn: "CompanyCode",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TrUserCompanies_DcUsers_UserName",
                        column: x => x.UserName,
                        principalTable: "DcUsers",
                        principalColumn: "UserName",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "DcUsers",
                columns: new[] { "UserName", "IsDisabled", "Password", "RowGuid", "UserDesc" },
                values: new object[,]
                {
                    { "admin", false, "123", new Guid("11111111-1111-1111-1111-111111111111"), "Administrator" },
                    { "C-000001", false, "123", new Guid("22222222-2222-2222-2222-222222222222"), "Administrator" },
                    { "CA-1", false, "123", new Guid("33333333-3333-3333-3333-333333333333"), "Administrator" }
                });

            migrationBuilder.InsertData(
                table: "TrUserCompanies",
                columns: new[] { "UserCompanyId", "CompanyCode", "UserName" },
                values: new object[,]
                {
                    { 1, "Company01", "admin" },
                    { 2, "Company01", "C-000001" },
                    { 3, "Company01", "CA-1" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_TrUserCompanies_CompanyCode",
                table: "TrUserCompanies",
                column: "CompanyCode");

            migrationBuilder.CreateIndex(
                name: "IX_TrUserCompanies_UserName_CompanyCode",
                table: "TrUserCompanies",
                columns: new[] { "UserName", "CompanyCode" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TrUserCompanies");

            migrationBuilder.DropTable(
                name: "DcUsers");
        }
    }
}
