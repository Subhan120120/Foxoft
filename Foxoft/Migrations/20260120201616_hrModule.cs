using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Foxoft.Migrations
{
    /// <inheritdoc />
    public partial class hrModule : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DcDepartments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DepartmentCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    DepartmentName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    ParentDepartmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DcDepartments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DcDepartments_DcDepartments_ParentDepartmentId",
                        column: x => x.ParentDepartmentId,
                        principalTable: "DcDepartments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DcEmployees",
                columns: table => new
                {
                    CurrAccCode = table.Column<string>(type: "nvarchar(30)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FatherName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Gender = table.Column<byte>(type: "tinyint", nullable: false),
                    MaritalStatus = table.Column<byte>(type: "tinyint", nullable: false),
                    NationalId = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    HireDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TerminationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
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
                name: "DcEmploymentTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TypeCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    TypeName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DcEmploymentTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DcLeaveTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LeaveCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    LeaveName = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    IsPaid = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DcLeaveTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DcPayrollPeriods",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PeriodYear = table.Column<int>(type: "int", nullable: false),
                    PeriodMonth = table.Column<int>(type: "int", nullable: false),
                    IsClosed = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DcPayrollPeriods", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DcPositions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PositionCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    PositionName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    DepartmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsManagerial = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DcPositions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DcPositions_DcDepartments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "DcDepartments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TrAttendances",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CurrAccCode = table.Column<string>(type: "nvarchar(30)", nullable: false),
                    WorkDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CheckInTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CheckOutTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    WorkedMinutes = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrAttendances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrAttendances_DcEmployees_CurrAccCode",
                        column: x => x.CurrAccCode,
                        principalTable: "DcEmployees",
                        principalColumn: "CurrAccCode",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TrEmployeeEducations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CurrAccCode = table.Column<string>(type: "nvarchar(30)", nullable: false),
                    SchoolName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Degree = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    StartYear = table.Column<int>(type: "int", nullable: true),
                    EndYear = table.Column<int>(type: "int", nullable: true)
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
                name: "TrEmployeeContracts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CurrAccCode = table.Column<string>(type: "nvarchar(30)", nullable: false),
                    EmploymentTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    BaseSalary = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CurrencyCode = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrEmployeeContracts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrEmployeeContracts_DcEmployees_CurrAccCode",
                        column: x => x.CurrAccCode,
                        principalTable: "DcEmployees",
                        principalColumn: "CurrAccCode",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TrEmployeeContracts_DcEmploymentTypes_EmploymentTypeId",
                        column: x => x.EmploymentTypeId,
                        principalTable: "DcEmploymentTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TrLeaves",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CurrAccCode = table.Column<string>(type: "nvarchar(30)", nullable: false),
                    LeaveTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ApprovedByCurrAccCode = table.Column<string>(type: "nvarchar(30)", nullable: true),
                    Status = table.Column<byte>(type: "tinyint", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
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

            migrationBuilder.CreateTable(
                name: "TrPayrollHeaders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CurrAccCode = table.Column<string>(type: "nvarchar(30)", nullable: false),
                    PayrollPeriodId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GrossSalary = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NetSalary = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrPayrollHeaders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrPayrollHeaders_DcEmployees_CurrAccCode",
                        column: x => x.CurrAccCode,
                        principalTable: "DcEmployees",
                        principalColumn: "CurrAccCode",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TrPayrollHeaders_DcPayrollPeriods_PayrollPeriodId",
                        column: x => x.PayrollPeriodId,
                        principalTable: "DcPayrollPeriods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TrEmployeePositions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CurrAccCode = table.Column<string>(type: "nvarchar(30)", nullable: false),
                    PositionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrEmployeePositions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrEmployeePositions_DcEmployees_CurrAccCode",
                        column: x => x.CurrAccCode,
                        principalTable: "DcEmployees",
                        principalColumn: "CurrAccCode",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TrEmployeePositions_DcPositions_PositionId",
                        column: x => x.PositionId,
                        principalTable: "DcPositions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TrPayrollLines",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PayrollHeaderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PayrollItemType = table.Column<byte>(type: "tinyint", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrPayrollLines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrPayrollLines_TrPayrollHeaders_PayrollHeaderId",
                        column: x => x.PayrollHeaderId,
                        principalTable: "TrPayrollHeaders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DcDepartments_DepartmentCode",
                table: "DcDepartments",
                column: "DepartmentCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DcDepartments_ParentDepartmentId",
                table: "DcDepartments",
                column: "ParentDepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_DcEmploymentTypes_TypeCode",
                table: "DcEmploymentTypes",
                column: "TypeCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DcLeaveTypes_LeaveCode",
                table: "DcLeaveTypes",
                column: "LeaveCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DcPayrollPeriods_PeriodYear_PeriodMonth",
                table: "DcPayrollPeriods",
                columns: new[] { "PeriodYear", "PeriodMonth" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DcPositions_DepartmentId",
                table: "DcPositions",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_DcPositions_PositionCode",
                table: "DcPositions",
                column: "PositionCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TrAttendances_CurrAccCode",
                table: "TrAttendances",
                column: "CurrAccCode");

            migrationBuilder.CreateIndex(
                name: "IX_TrEmployeeContracts_CurrAccCode",
                table: "TrEmployeeContracts",
                column: "CurrAccCode");

            migrationBuilder.CreateIndex(
                name: "IX_TrEmployeeContracts_EmploymentTypeId",
                table: "TrEmployeeContracts",
                column: "EmploymentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_TrEmployeeEducations_CurrAccCode",
                table: "TrEmployeeEducations",
                column: "CurrAccCode");

            migrationBuilder.CreateIndex(
                name: "IX_TrEmployeePositions_CurrAccCode",
                table: "TrEmployeePositions",
                column: "CurrAccCode");

            migrationBuilder.CreateIndex(
                name: "IX_TrEmployeePositions_PositionId",
                table: "TrEmployeePositions",
                column: "PositionId");

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

            migrationBuilder.CreateIndex(
                name: "IX_TrPayrollHeaders_CurrAccCode",
                table: "TrPayrollHeaders",
                column: "CurrAccCode");

            migrationBuilder.CreateIndex(
                name: "IX_TrPayrollHeaders_PayrollPeriodId",
                table: "TrPayrollHeaders",
                column: "PayrollPeriodId");

            migrationBuilder.CreateIndex(
                name: "IX_TrPayrollLines_PayrollHeaderId",
                table: "TrPayrollLines",
                column: "PayrollHeaderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TrAttendances");

            migrationBuilder.DropTable(
                name: "TrEmployeeContracts");

            migrationBuilder.DropTable(
                name: "TrEmployeeEducations");

            migrationBuilder.DropTable(
                name: "TrEmployeePositions");

            migrationBuilder.DropTable(
                name: "TrLeaves");

            migrationBuilder.DropTable(
                name: "TrPayrollLines");

            migrationBuilder.DropTable(
                name: "DcEmploymentTypes");

            migrationBuilder.DropTable(
                name: "DcPositions");

            migrationBuilder.DropTable(
                name: "DcLeaveTypes");

            migrationBuilder.DropTable(
                name: "TrPayrollHeaders");

            migrationBuilder.DropTable(
                name: "DcDepartments");

            migrationBuilder.DropTable(
                name: "DcEmployees");

            migrationBuilder.DropTable(
                name: "DcPayrollPeriods");
        }
    }
}
