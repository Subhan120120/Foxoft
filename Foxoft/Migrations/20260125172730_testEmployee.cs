using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Foxoft.Migrations
{
    /// <inheritdoc />
    public partial class testEmployee : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrAttendances_DcEmployees_CurrAccCode",
                table: "TrAttendances");

            migrationBuilder.DropForeignKey(
                name: "FK_TrEmployeeContracts_DcEmployees_CurrAccCode",
                table: "TrEmployeeContracts");

            migrationBuilder.DropForeignKey(
                name: "FK_TrEmployeePositions_DcEmployees_CurrAccCode",
                table: "TrEmployeePositions");

            migrationBuilder.DropForeignKey(
                name: "FK_TrPayrollHeaders_DcEmployees_CurrAccCode",
                table: "TrPayrollHeaders");

            migrationBuilder.DropTable(
                name: "TrEmployeeEducations");

            migrationBuilder.DropTable(
                name: "TrLeaves");

            migrationBuilder.DropTable(
                name: "DcEmployees");

            migrationBuilder.DropTable(
                name: "DcLeaveTypes");

            migrationBuilder.AddColumn<byte>(
                name: "Gender",
                table: "DcCurrAccs",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<byte>(
                name: "MaritalStatus",
                table: "DcCurrAccs",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);


            migrationBuilder.UpdateData(
                table: "DcCurrAccs",
                keyColumn: "CurrAccCode",
                keyValue: "C-000001",
                columns: new[] { "Gender", "MaritalStatus" },
                values: new object[] { (byte)0, (byte)0 });

            migrationBuilder.UpdateData(
                table: "DcCurrAccs",
                keyColumn: "CurrAccCode",
                keyValue: "C-000002",
                columns: new[] { "Gender", "MaritalStatus" },
                values: new object[] { (byte)0, (byte)0 });

            migrationBuilder.UpdateData(
                table: "DcCurrAccs",
                keyColumn: "CurrAccCode",
                keyValue: "C-000003",
                columns: new[] { "Gender", "MaritalStatus" },
                values: new object[] { (byte)0, (byte)0 });

            migrationBuilder.UpdateData(
                table: "DcCurrAccs",
                keyColumn: "CurrAccCode",
                keyValue: "C-000004",
                columns: new[] { "Gender", "MaritalStatus" },
                values: new object[] { (byte)0, (byte)0 });

            migrationBuilder.UpdateData(
                table: "DcCurrAccs",
                keyColumn: "CurrAccCode",
                keyValue: "C-000005",
                columns: new[] { "Gender", "MaritalStatus" },
                values: new object[] { (byte)0, (byte)0 });

            migrationBuilder.UpdateData(
                table: "DcCurrAccs",
                keyColumn: "CurrAccCode",
                keyValue: "C-000006",
                columns: new[] { "Gender", "MaritalStatus" },
                values: new object[] { (byte)0, (byte)0 });

            migrationBuilder.UpdateData(
                table: "DcCurrAccs",
                keyColumn: "CurrAccCode",
                keyValue: "kassa01",
                columns: new[] { "Gender", "MaritalStatus" },
                values: new object[] { (byte)0, (byte)0 });

            migrationBuilder.UpdateData(
                table: "DcCurrAccs",
                keyColumn: "CurrAccCode",
                keyValue: "mgz01",
                columns: new[] { "Gender", "MaritalStatus" },
                values: new object[] { (byte)0, (byte)0 });

            migrationBuilder.AddForeignKey(
                name: "FK_TrAttendances_DcCurrAccs_CurrAccCode",
                table: "TrAttendances",
                column: "CurrAccCode",
                principalTable: "DcCurrAccs",
                principalColumn: "CurrAccCode",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TrEmployeeContracts_DcCurrAccs_CurrAccCode",
                table: "TrEmployeeContracts",
                column: "CurrAccCode",
                principalTable: "DcCurrAccs",
                principalColumn: "CurrAccCode",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TrEmployeePositions_DcCurrAccs_CurrAccCode",
                table: "TrEmployeePositions",
                column: "CurrAccCode",
                principalTable: "DcCurrAccs",
                principalColumn: "CurrAccCode",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TrPayrollHeaders_DcCurrAccs_CurrAccCode",
                table: "TrPayrollHeaders",
                column: "CurrAccCode",
                principalTable: "DcCurrAccs",
                principalColumn: "CurrAccCode",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrAttendances_DcCurrAccs_CurrAccCode",
                table: "TrAttendances");

            migrationBuilder.DropForeignKey(
                name: "FK_TrEmployeeContracts_DcCurrAccs_CurrAccCode",
                table: "TrEmployeeContracts");

            migrationBuilder.DropForeignKey(
                name: "FK_TrEmployeePositions_DcCurrAccs_CurrAccCode",
                table: "TrEmployeePositions");

            migrationBuilder.DropForeignKey(
                name: "FK_TrPayrollHeaders_DcCurrAccs_CurrAccCode",
                table: "TrPayrollHeaders");

            migrationBuilder.DeleteData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "PayrollList");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "DcCurrAccs");

            migrationBuilder.DropColumn(
                name: "MaritalStatus",
                table: "DcCurrAccs");

            migrationBuilder.CreateTable(
                name: "DcEmployees",
                columns: table => new
                {
                    CurrAccCode = table.Column<string>(type: "nvarchar(30)", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FatherName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Gender = table.Column<byte>(type: "tinyint", nullable: false),
                    HireDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MaritalStatus = table.Column<byte>(type: "tinyint", nullable: false),
                    NationalId = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    TerminationDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DcEmployees", x => x.CurrAccCode);
                    table.ForeignKey(
                        name: "FK_DcEmployees_DcCurrAccs_CurrAccCode",
                        column: x => x.CurrAccCode,
                        principalTable: "DcCurrAccs",
                        principalColumn: "CurrAccCode",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DcLeaveTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsPaid = table.Column<bool>(type: "bit", nullable: false),
                    LeaveCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    LeaveName = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DcLeaveTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TrEmployeeEducations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CurrAccCode = table.Column<string>(type: "nvarchar(30)", nullable: false),
                    Degree = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    EndYear = table.Column<int>(type: "int", nullable: true),
                    SchoolName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    StartYear = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrEmployeeEducations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrEmployeeEducations_DcEmployees_CurrAccCode",
                        column: x => x.CurrAccCode,
                        principalTable: "DcEmployees",
                        principalColumn: "CurrAccCode",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TrLeaves",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ApprovedByCurrAccCode = table.Column<string>(type: "nvarchar(30)", nullable: true),
                    CurrAccCode = table.Column<string>(type: "nvarchar(30)", nullable: false),
                    LeaveTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrLeaves", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrLeaves_DcEmployees_ApprovedByCurrAccCode",
                        column: x => x.ApprovedByCurrAccCode,
                        principalTable: "DcEmployees",
                        principalColumn: "CurrAccCode",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TrLeaves_DcEmployees_CurrAccCode",
                        column: x => x.CurrAccCode,
                        principalTable: "DcEmployees",
                        principalColumn: "CurrAccCode",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TrLeaves_DcLeaveTypes_LeaveTypeId",
                        column: x => x.LeaveTypeId,
                        principalTable: "DcLeaveTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DcLeaveTypes_LeaveCode",
                table: "DcLeaveTypes",
                column: "LeaveCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TrEmployeeEducations_CurrAccCode",
                table: "TrEmployeeEducations",
                column: "CurrAccCode");

            migrationBuilder.CreateIndex(
                name: "IX_TrLeaves_ApprovedByCurrAccCode",
                table: "TrLeaves",
                column: "ApprovedByCurrAccCode");

            migrationBuilder.CreateIndex(
                name: "IX_TrLeaves_CurrAccCode",
                table: "TrLeaves",
                column: "CurrAccCode");

            migrationBuilder.CreateIndex(
                name: "IX_TrLeaves_LeaveTypeId",
                table: "TrLeaves",
                column: "LeaveTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_TrAttendances_DcEmployees_CurrAccCode",
                table: "TrAttendances",
                column: "CurrAccCode",
                principalTable: "DcEmployees",
                principalColumn: "CurrAccCode",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TrEmployeeContracts_DcEmployees_CurrAccCode",
                table: "TrEmployeeContracts",
                column: "CurrAccCode",
                principalTable: "DcEmployees",
                principalColumn: "CurrAccCode",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TrEmployeePositions_DcEmployees_CurrAccCode",
                table: "TrEmployeePositions",
                column: "CurrAccCode",
                principalTable: "DcEmployees",
                principalColumn: "CurrAccCode",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TrPayrollHeaders_DcEmployees_CurrAccCode",
                table: "TrPayrollHeaders",
                column: "CurrAccCode",
                principalTable: "DcEmployees",
                principalColumn: "CurrAccCode",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
