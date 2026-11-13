using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Foxoft.Migrations
{
    /// <inheritdoc />
    public partial class AddAttendanceModule : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ApprovedOvertimeMinutes",
                table: "TrAttendances",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<byte>(
                name: "AttendanceStatus",
                table: "TrAttendances",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<int>(
                name: "BreakMinutes",
                table: "TrAttendances",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "CalculatedAt",
                table: "TrAttendances",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EarlyExitMinutes",
                table: "TrAttendances",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "EffectiveStartTime",
                table: "TrAttendances",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsManualOverride",
                table: "TrAttendances",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "LateMinutes",
                table: "TrAttendances",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "LeaveRequestId",
                table: "TrAttendances",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Notes",
                table: "TrAttendances",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OvertimeMinutes",
                table: "TrAttendances",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "PlannedCheckInTime",
                table: "TrAttendances",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "PlannedCheckOutTime",
                table: "TrAttendances",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PlannedWorkMinutes",
                table: "TrAttendances",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "WorkScheduleId",
                table: "TrAttendances",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "DcWorkSchedules",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ScheduleCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    ScheduleName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    ScheduleType = table.Column<byte>(type: "tinyint", nullable: false),
                    WeeklyHours = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DcWorkSchedules", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HrLeaveTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TypeCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TypeName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsPaid = table.Column<bool>(type: "bit", nullable: false),
                    AffectAttendance = table.Column<bool>(type: "bit", nullable: false),
                    RequiresApproval = table.Column<bool>(type: "bit", nullable: false),
                    IsHourly = table.Column<bool>(type: "bit", nullable: false),
                    DefaultDaysPerYear = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HrLeaveTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TrAttendanceLogs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CurrAccCode = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    DeviceCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LogDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PunchType = table.Column<byte>(type: "tinyint", nullable: false),
                    SourceMethod = table.Column<byte>(type: "tinyint", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IsIgnored = table.Column<bool>(type: "bit", nullable: false),
                    IgnoreReason = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedUserName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrAttendanceLogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrAttendanceLogs_DcCurrAccs_CurrAccCode",
                        column: x => x.CurrAccCode,
                        principalTable: "DcCurrAccs",
                        principalColumn: "CurrAccCode",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TrMonthlyTimesheets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CurrAccCode = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    PayrollPeriodId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Year = table.Column<int>(type: "int", nullable: false),
                    Month = table.Column<int>(type: "int", nullable: false),
                    ScheduledDays = table.Column<int>(type: "int", nullable: false),
                    WorkedDays = table.Column<int>(type: "int", nullable: false),
                    WorkedHours = table.Column<decimal>(type: "decimal(6,2)", nullable: false),
                    UnexcusedAbsenceDays = table.Column<int>(type: "int", nullable: false),
                    ExcusedAbsenceDays = table.Column<int>(type: "int", nullable: false),
                    LateMinutes = table.Column<int>(type: "int", nullable: false),
                    EarlyExitMinutes = table.Column<int>(type: "int", nullable: false),
                    TotalOvertimeHours = table.Column<decimal>(type: "decimal(6,2)", nullable: false),
                    ApprovedOvertimeHours = table.Column<decimal>(type: "decimal(6,2)", nullable: false),
                    PaidLeaveDays = table.Column<int>(type: "int", nullable: false),
                    UnpaidLeaveDays = table.Column<int>(type: "int", nullable: false),
                    SickLeaveDays = table.Column<int>(type: "int", nullable: false),
                    IsLocked = table.Column<bool>(type: "bit", nullable: false),
                    CalculatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrMonthlyTimesheets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrMonthlyTimesheets_DcCurrAccs_CurrAccCode",
                        column: x => x.CurrAccCode,
                        principalTable: "DcCurrAccs",
                        principalColumn: "CurrAccCode",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TrMonthlyTimesheets_DcPayrollPeriods_PayrollPeriodId",
                        column: x => x.PayrollPeriodId,
                        principalTable: "DcPayrollPeriods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TrOvertimeRequests",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CurrAccCode = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    WorkDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StartTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    EndTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    OvertimeMinutes = table.Column<int>(type: "int", nullable: false),
                    Reason = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    IsApproved = table.Column<bool>(type: "bit", nullable: false),
                    ApprovedByCurrAccCode = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    ApprovedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrOvertimeRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrOvertimeRequests_DcCurrAccs_ApprovedByCurrAccCode",
                        column: x => x.ApprovedByCurrAccCode,
                        principalTable: "DcCurrAccs",
                        principalColumn: "CurrAccCode",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TrOvertimeRequests_DcCurrAccs_CurrAccCode",
                        column: x => x.CurrAccCode,
                        principalTable: "DcCurrAccs",
                        principalColumn: "CurrAccCode",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DcAttendanceSettings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AttendanceEnabled = table.Column<bool>(type: "bit", nullable: false),
                    DefaultWorkScheduleId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AttendanceMethod = table.Column<byte>(type: "tinyint", nullable: false),
                    RequireApproval = table.Column<bool>(type: "bit", nullable: false),
                    AllowManualEntry = table.Column<bool>(type: "bit", nullable: false),
                    AllowAttendanceCorrection = table.Column<bool>(type: "bit", nullable: false),
                    AutoCalculateAttendance = table.Column<bool>(type: "bit", nullable: false),
                    AutoCloseDay = table.Column<bool>(type: "bit", nullable: false),
                    DebounceMinutes = table.Column<int>(type: "int", nullable: false),
                    GracePeriodMinutes = table.Column<int>(type: "int", nullable: false),
                    LateCalculationMethod = table.Column<byte>(type: "tinyint", nullable: false),
                    LateRoundingMethod = table.Column<byte>(type: "tinyint", nullable: false),
                    AllowLateCorrection = table.Column<bool>(type: "bit", nullable: false),
                    LateApprovalRequired = table.Column<bool>(type: "bit", nullable: false),
                    EarlyExitGracePeriodMinutes = table.Column<int>(type: "int", nullable: false),
                    OvertimePolicy = table.Column<byte>(type: "tinyint", nullable: false),
                    MinOvertimeMinutes = table.Column<int>(type: "int", nullable: false),
                    OvertimeRoundingMinutes = table.Column<int>(type: "int", nullable: false),
                    NotifyHrOnLate = table.Column<bool>(type: "bit", nullable: false),
                    NotifyManagerOnAbsence = table.Column<bool>(type: "bit", nullable: false),
                    NotifyOnMissingCheckOut = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DcAttendanceSettings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DcAttendanceSettings_DcWorkSchedules_DefaultWorkScheduleId",
                        column: x => x.DefaultWorkScheduleId,
                        principalTable: "DcWorkSchedules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DcWorkScheduleDays",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WorkScheduleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DayOfWeek = table.Column<int>(type: "int", nullable: false),
                    IsWorkDay = table.Column<bool>(type: "bit", nullable: false),
                    StartTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    EndTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    BreakStartTime = table.Column<TimeSpan>(type: "time", nullable: true),
                    BreakEndTime = table.Column<TimeSpan>(type: "time", nullable: true),
                    BreakDurationMinutes = table.Column<int>(type: "int", nullable: false),
                    PlannedWorkMinutes = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DcWorkScheduleDays", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DcWorkScheduleDays_DcWorkSchedules_WorkScheduleId",
                        column: x => x.WorkScheduleId,
                        principalTable: "DcWorkSchedules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TrEmployeeWorkSchedules",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CurrAccCode = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    WorkScheduleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrEmployeeWorkSchedules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrEmployeeWorkSchedules_DcCurrAccs_CurrAccCode",
                        column: x => x.CurrAccCode,
                        principalTable: "DcCurrAccs",
                        principalColumn: "CurrAccCode",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TrEmployeeWorkSchedules_DcWorkSchedules_WorkScheduleId",
                        column: x => x.WorkScheduleId,
                        principalTable: "DcWorkSchedules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HrEmployeeLeaveBalances",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CurrAccCode = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    LeaveTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    TotalEntitledDays = table.Column<decimal>(type: "decimal(6,2)", nullable: false),
                    UsedDays = table.Column<decimal>(type: "decimal(6,2)", nullable: false),
                    RemainingDays = table.Column<decimal>(type: "decimal(6,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HrEmployeeLeaveBalances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HrEmployeeLeaveBalances_DcCurrAccs_CurrAccCode",
                        column: x => x.CurrAccCode,
                        principalTable: "DcCurrAccs",
                        principalColumn: "CurrAccCode",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HrEmployeeLeaveBalances_HrLeaveTypes_LeaveTypeId",
                        column: x => x.LeaveTypeId,
                        principalTable: "HrLeaveTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HrLeaveRequests",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RequestNumber = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    CurrAccCode = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    LeaveTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalDays = table.Column<decimal>(type: "decimal(6,2)", nullable: false),
                    TotalHours = table.Column<decimal>(type: "decimal(6,2)", nullable: false),
                    Reason = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Status = table.Column<byte>(type: "tinyint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedUserName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HrLeaveRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HrLeaveRequests_DcCurrAccs_CurrAccCode",
                        column: x => x.CurrAccCode,
                        principalTable: "DcCurrAccs",
                        principalColumn: "CurrAccCode",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HrLeaveRequests_HrLeaveTypes_LeaveTypeId",
                        column: x => x.LeaveTypeId,
                        principalTable: "HrLeaveTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HrLeaveApprovals",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LeaveRequestId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ApproverCurrAccCode = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    ApprovalDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<byte>(type: "tinyint", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HrLeaveApprovals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HrLeaveApprovals_DcCurrAccs_ApproverCurrAccCode",
                        column: x => x.ApproverCurrAccCode,
                        principalTable: "DcCurrAccs",
                        principalColumn: "CurrAccCode",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HrLeaveApprovals_HrLeaveRequests_LeaveRequestId",
                        column: x => x.LeaveRequestId,
                        principalTable: "HrLeaveRequests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HrLeaveRequestDays",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LeaveRequestId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StartTime = table.Column<TimeSpan>(type: "time", nullable: true),
                    EndTime = table.Column<TimeSpan>(type: "time", nullable: true),
                    DurationHours = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    IsHalfDay = table.Column<bool>(type: "bit", nullable: false),
                    IsPaid = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HrLeaveRequestDays", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HrLeaveRequestDays_HrLeaveRequests_LeaveRequestId",
                        column: x => x.LeaveRequestId,
                        principalTable: "HrLeaveRequests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "DcClaims",
                columns: new[] { "ClaimCode", "CategoryId", "ClaimDesc", "ClaimTypeId" },
                values: new object[,]
                {
                    { "AttendanceCalculationWizard", 23, "Davamiyyət Hesablama Sihirbazı", (byte)1 },
                    { "AttendanceLogs", 23, "Davamiyyət Logları", (byte)1 },
                    { "AttendanceSettings", 23, "Davamiyyət Ayarları", (byte)1 },
                    { "DailyAttendance", 23, "Gündəlik Davamiyyət İdarəsi", (byte)1 },
                    { "LeaveRequests", 23, "İcazələr və Məzuniyyətlər", (byte)1 },
                    { "WorkSchedules", 23, "İş Qrafikləri", (byte)1 }
                });

            migrationBuilder.InsertData(
                table: "DcWorkSchedules",
                columns: new[] { "Id", "Description", "IsActive", "ScheduleCode", "ScheduleName", "ScheduleType", "WeeklyHours" },
                values: new object[,]
                {
                    { new Guid("11111111-1111-1111-1111-111111111111"), "Bazar ertəsi - Cümə 09:00 - 18:00, 13:00 - 14:00 nahar", true, "WS-5DAY", "Standart 5 günlük (09:00 - 18:00)", (byte)1, 40.00m },
                    { new Guid("22222222-2222-2222-2222-222222222222"), "Bazar ertəsi - Şənbə 09:00 - 17:00", true, "WS-6DAY", "Standart 6 günlük (09:00 - 17:00)", (byte)2, 48.00m }
                });

            migrationBuilder.InsertData(
                table: "HrLeaveTypes",
                columns: new[] { "Id", "AffectAttendance", "DefaultDaysPerYear", "IsActive", "IsHourly", "IsPaid", "RequiresApproval", "TypeCode", "TypeName" },
                values: new object[,]
                {
                    { new Guid("33333333-3333-3333-3333-333333333331"), true, 21, true, false, true, true, "AnnualLeave", "Əsas Məzuniyyət" },
                    { new Guid("33333333-3333-3333-3333-333333333332"), true, 14, true, false, true, true, "SickLeave", "Xəstəlik Məzuniyyəti" },
                    { new Guid("33333333-3333-3333-3333-333333333333"), true, 0, true, false, false, true, "UnpaidLeave", "Ödənişsiz İcazə" },
                    { new Guid("33333333-3333-3333-3333-333333333334"), true, 0, true, true, false, true, "PersonalPermission", "Şəxsi İcazə (Saatlıq/Günlük)" },
                    { new Guid("33333333-3333-3333-3333-333333333335"), true, 0, true, false, true, true, "BusinessTrip", "Ezamiyyət" },
                    { new Guid("33333333-3333-3333-3333-333333333336"), true, 0, true, false, true, true, "DayOff", "İstirahət / Əvəzləmə Günü" }
                });

            migrationBuilder.InsertData(
                table: "DcAttendanceSettings",
                columns: new[] { "Id", "AllowAttendanceCorrection", "AllowLateCorrection", "AllowManualEntry", "AttendanceEnabled", "AttendanceMethod", "AutoCalculateAttendance", "AutoCloseDay", "DebounceMinutes", "DefaultWorkScheduleId", "EarlyExitGracePeriodMinutes", "GracePeriodMinutes", "LateApprovalRequired", "LateCalculationMethod", "LateRoundingMethod", "MinOvertimeMinutes", "NotifyHrOnLate", "NotifyManagerOnAbsence", "NotifyOnMissingCheckOut", "OvertimePolicy", "OvertimeRoundingMinutes", "RequireApproval" },
                values: new object[] { 1, true, true, true, true, (byte)3, true, false, 2, new Guid("11111111-1111-1111-1111-111111111111"), 5, 5, false, (byte)1, (byte)0, 15, false, false, false, (byte)1, 0, false });

            migrationBuilder.InsertData(
                table: "DcWorkScheduleDays",
                columns: new[] { "Id", "BreakDurationMinutes", "BreakEndTime", "BreakStartTime", "DayOfWeek", "EndTime", "IsWorkDay", "PlannedWorkMinutes", "StartTime", "WorkScheduleId" },
                values: new object[,]
                {
                    { new Guid("11111111-1111-1111-1111-000000000000"), 0, new TimeSpan(0, 14, 0, 0, 0), new TimeSpan(0, 13, 0, 0, 0), 0, new TimeSpan(0, 0, 0, 0, 0), false, 0, new TimeSpan(0, 0, 0, 0, 0), new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("11111111-1111-1111-1111-000000000001"), 60, new TimeSpan(0, 14, 0, 0, 0), new TimeSpan(0, 13, 0, 0, 0), 1, new TimeSpan(0, 18, 0, 0, 0), true, 480, new TimeSpan(0, 9, 0, 0, 0), new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("11111111-1111-1111-1111-000000000002"), 60, new TimeSpan(0, 14, 0, 0, 0), new TimeSpan(0, 13, 0, 0, 0), 2, new TimeSpan(0, 18, 0, 0, 0), true, 480, new TimeSpan(0, 9, 0, 0, 0), new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("11111111-1111-1111-1111-000000000003"), 60, new TimeSpan(0, 14, 0, 0, 0), new TimeSpan(0, 13, 0, 0, 0), 3, new TimeSpan(0, 18, 0, 0, 0), true, 480, new TimeSpan(0, 9, 0, 0, 0), new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("11111111-1111-1111-1111-000000000004"), 60, new TimeSpan(0, 14, 0, 0, 0), new TimeSpan(0, 13, 0, 0, 0), 4, new TimeSpan(0, 18, 0, 0, 0), true, 480, new TimeSpan(0, 9, 0, 0, 0), new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("11111111-1111-1111-1111-000000000005"), 60, new TimeSpan(0, 14, 0, 0, 0), new TimeSpan(0, 13, 0, 0, 0), 5, new TimeSpan(0, 18, 0, 0, 0), true, 480, new TimeSpan(0, 9, 0, 0, 0), new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("11111111-1111-1111-1111-000000000006"), 0, new TimeSpan(0, 14, 0, 0, 0), new TimeSpan(0, 13, 0, 0, 0), 6, new TimeSpan(0, 0, 0, 0, 0), false, 0, new TimeSpan(0, 0, 0, 0, 0), new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("22222222-2222-2222-2222-000000000000"), 0, new TimeSpan(0, 14, 0, 0, 0), new TimeSpan(0, 13, 0, 0, 0), 0, new TimeSpan(0, 0, 0, 0, 0), false, 0, new TimeSpan(0, 0, 0, 0, 0), new Guid("22222222-2222-2222-2222-222222222222") },
                    { new Guid("22222222-2222-2222-2222-000000000001"), 60, new TimeSpan(0, 14, 0, 0, 0), new TimeSpan(0, 13, 0, 0, 0), 1, new TimeSpan(0, 17, 0, 0, 0), true, 420, new TimeSpan(0, 9, 0, 0, 0), new Guid("22222222-2222-2222-2222-222222222222") },
                    { new Guid("22222222-2222-2222-2222-000000000002"), 60, new TimeSpan(0, 14, 0, 0, 0), new TimeSpan(0, 13, 0, 0, 0), 2, new TimeSpan(0, 17, 0, 0, 0), true, 420, new TimeSpan(0, 9, 0, 0, 0), new Guid("22222222-2222-2222-2222-222222222222") },
                    { new Guid("22222222-2222-2222-2222-000000000003"), 60, new TimeSpan(0, 14, 0, 0, 0), new TimeSpan(0, 13, 0, 0, 0), 3, new TimeSpan(0, 17, 0, 0, 0), true, 420, new TimeSpan(0, 9, 0, 0, 0), new Guid("22222222-2222-2222-2222-222222222222") },
                    { new Guid("22222222-2222-2222-2222-000000000004"), 60, new TimeSpan(0, 14, 0, 0, 0), new TimeSpan(0, 13, 0, 0, 0), 4, new TimeSpan(0, 17, 0, 0, 0), true, 420, new TimeSpan(0, 9, 0, 0, 0), new Guid("22222222-2222-2222-2222-222222222222") },
                    { new Guid("22222222-2222-2222-2222-000000000005"), 60, new TimeSpan(0, 14, 0, 0, 0), new TimeSpan(0, 13, 0, 0, 0), 5, new TimeSpan(0, 17, 0, 0, 0), true, 420, new TimeSpan(0, 9, 0, 0, 0), new Guid("22222222-2222-2222-2222-222222222222") },
                    { new Guid("22222222-2222-2222-2222-000000000006"), 60, new TimeSpan(0, 14, 0, 0, 0), new TimeSpan(0, 13, 0, 0, 0), 6, new TimeSpan(0, 17, 0, 0, 0), true, 420, new TimeSpan(0, 9, 0, 0, 0), new Guid("22222222-2222-2222-2222-222222222222") }
                });

            migrationBuilder.InsertData(
                table: "TrRoleClaims",
                columns: new[] { "RoleClaimId", "ClaimCode", "RoleCode" },
                values: new object[,]
                {
                    { 1529, "DailyAttendance", "Admin" },
                    { 1530, "AttendanceCalculationWizard", "Admin" },
                    { 1531, "WorkSchedules", "Admin" },
                    { 1532, "LeaveRequests", "Admin" },
                    { 1533, "AttendanceSettings", "Admin" },
                    { 1534, "AttendanceLogs", "Admin" },
                    { 1535, "DailyAttendance", "Manager" },
                    { 1536, "AttendanceCalculationWizard", "Manager" },
                    { 1537, "WorkSchedules", "Manager" },
                    { 1538, "LeaveRequests", "Manager" },
                    { 1539, "AttendanceSettings", "Manager" },
                    { 1540, "AttendanceLogs", "Manager" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_TrAttendances_LeaveRequestId",
                table: "TrAttendances",
                column: "LeaveRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_TrAttendances_WorkScheduleId",
                table: "TrAttendances",
                column: "WorkScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_DcAttendanceSettings_DefaultWorkScheduleId",
                table: "DcAttendanceSettings",
                column: "DefaultWorkScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_DcWorkScheduleDays_WorkScheduleId",
                table: "DcWorkScheduleDays",
                column: "WorkScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_DcWorkSchedules_ScheduleCode",
                table: "DcWorkSchedules",
                column: "ScheduleCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_HrEmployeeLeaveBalances_CurrAccCode",
                table: "HrEmployeeLeaveBalances",
                column: "CurrAccCode");

            migrationBuilder.CreateIndex(
                name: "IX_HrEmployeeLeaveBalances_LeaveTypeId",
                table: "HrEmployeeLeaveBalances",
                column: "LeaveTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_HrLeaveApprovals_ApproverCurrAccCode",
                table: "HrLeaveApprovals",
                column: "ApproverCurrAccCode");

            migrationBuilder.CreateIndex(
                name: "IX_HrLeaveApprovals_LeaveRequestId",
                table: "HrLeaveApprovals",
                column: "LeaveRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_HrLeaveRequestDays_LeaveRequestId",
                table: "HrLeaveRequestDays",
                column: "LeaveRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_HrLeaveRequests_CurrAccCode",
                table: "HrLeaveRequests",
                column: "CurrAccCode");

            migrationBuilder.CreateIndex(
                name: "IX_HrLeaveRequests_LeaveTypeId",
                table: "HrLeaveRequests",
                column: "LeaveTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_HrLeaveTypes_TypeCode",
                table: "HrLeaveTypes",
                column: "TypeCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TrAttendanceLogs_CurrAccCode",
                table: "TrAttendanceLogs",
                column: "CurrAccCode");

            migrationBuilder.CreateIndex(
                name: "IX_TrEmployeeWorkSchedules_CurrAccCode",
                table: "TrEmployeeWorkSchedules",
                column: "CurrAccCode");

            migrationBuilder.CreateIndex(
                name: "IX_TrEmployeeWorkSchedules_WorkScheduleId",
                table: "TrEmployeeWorkSchedules",
                column: "WorkScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_TrMonthlyTimesheets_CurrAccCode_Year_Month",
                table: "TrMonthlyTimesheets",
                columns: new[] { "CurrAccCode", "Year", "Month" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TrMonthlyTimesheets_PayrollPeriodId",
                table: "TrMonthlyTimesheets",
                column: "PayrollPeriodId");

            migrationBuilder.CreateIndex(
                name: "IX_TrOvertimeRequests_ApprovedByCurrAccCode",
                table: "TrOvertimeRequests",
                column: "ApprovedByCurrAccCode");

            migrationBuilder.CreateIndex(
                name: "IX_TrOvertimeRequests_CurrAccCode",
                table: "TrOvertimeRequests",
                column: "CurrAccCode");

            migrationBuilder.AddForeignKey(
                name: "FK_TrAttendances_DcWorkSchedules_WorkScheduleId",
                table: "TrAttendances",
                column: "WorkScheduleId",
                principalTable: "DcWorkSchedules",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TrAttendances_HrLeaveRequests_LeaveRequestId",
                table: "TrAttendances",
                column: "LeaveRequestId",
                principalTable: "HrLeaveRequests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrAttendances_DcWorkSchedules_WorkScheduleId",
                table: "TrAttendances");

            migrationBuilder.DropForeignKey(
                name: "FK_TrAttendances_HrLeaveRequests_LeaveRequestId",
                table: "TrAttendances");

            migrationBuilder.DropTable(
                name: "DcAttendanceSettings");

            migrationBuilder.DropTable(
                name: "DcWorkScheduleDays");

            migrationBuilder.DropTable(
                name: "HrEmployeeLeaveBalances");

            migrationBuilder.DropTable(
                name: "HrLeaveApprovals");

            migrationBuilder.DropTable(
                name: "HrLeaveRequestDays");

            migrationBuilder.DropTable(
                name: "TrAttendanceLogs");

            migrationBuilder.DropTable(
                name: "TrEmployeeWorkSchedules");

            migrationBuilder.DropTable(
                name: "TrMonthlyTimesheets");

            migrationBuilder.DropTable(
                name: "TrOvertimeRequests");

            migrationBuilder.DropTable(
                name: "HrLeaveRequests");

            migrationBuilder.DropTable(
                name: "DcWorkSchedules");

            migrationBuilder.DropTable(
                name: "HrLeaveTypes");

            migrationBuilder.DropIndex(
                name: "IX_TrAttendances_LeaveRequestId",
                table: "TrAttendances");

            migrationBuilder.DropIndex(
                name: "IX_TrAttendances_WorkScheduleId",
                table: "TrAttendances");

            migrationBuilder.DeleteData(
                table: "TrRoleClaims",
                keyColumn: "RoleClaimId",
                keyValue: 529);

            migrationBuilder.DeleteData(
                table: "TrRoleClaims",
                keyColumn: "RoleClaimId",
                keyValue: 530);

            migrationBuilder.DeleteData(
                table: "TrRoleClaims",
                keyColumn: "RoleClaimId",
                keyValue: 531);

            migrationBuilder.DeleteData(
                table: "TrRoleClaims",
                keyColumn: "RoleClaimId",
                keyValue: 532);

            migrationBuilder.DeleteData(
                table: "TrRoleClaims",
                keyColumn: "RoleClaimId",
                keyValue: 533);

            migrationBuilder.DeleteData(
                table: "TrRoleClaims",
                keyColumn: "RoleClaimId",
                keyValue: 534);

            migrationBuilder.DeleteData(
                table: "TrRoleClaims",
                keyColumn: "RoleClaimId",
                keyValue: 535);

            migrationBuilder.DeleteData(
                table: "TrRoleClaims",
                keyColumn: "RoleClaimId",
                keyValue: 536);

            migrationBuilder.DeleteData(
                table: "TrRoleClaims",
                keyColumn: "RoleClaimId",
                keyValue: 537);

            migrationBuilder.DeleteData(
                table: "TrRoleClaims",
                keyColumn: "RoleClaimId",
                keyValue: 538);

            migrationBuilder.DeleteData(
                table: "TrRoleClaims",
                keyColumn: "RoleClaimId",
                keyValue: 539);

            migrationBuilder.DeleteData(
                table: "TrRoleClaims",
                keyColumn: "RoleClaimId",
                keyValue: 540);

            migrationBuilder.DeleteData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "AttendanceCalculationWizard");

            migrationBuilder.DeleteData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "AttendanceLogs");

            migrationBuilder.DeleteData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "AttendanceSettings");

            migrationBuilder.DeleteData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "DailyAttendance");

            migrationBuilder.DeleteData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "LeaveRequests");

            migrationBuilder.DeleteData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "WorkSchedules");

            migrationBuilder.DropColumn(
                name: "ApprovedOvertimeMinutes",
                table: "TrAttendances");

            migrationBuilder.DropColumn(
                name: "AttendanceStatus",
                table: "TrAttendances");

            migrationBuilder.DropColumn(
                name: "BreakMinutes",
                table: "TrAttendances");

            migrationBuilder.DropColumn(
                name: "CalculatedAt",
                table: "TrAttendances");

            migrationBuilder.DropColumn(
                name: "EarlyExitMinutes",
                table: "TrAttendances");

            migrationBuilder.DropColumn(
                name: "EffectiveStartTime",
                table: "TrAttendances");

            migrationBuilder.DropColumn(
                name: "IsManualOverride",
                table: "TrAttendances");

            migrationBuilder.DropColumn(
                name: "LateMinutes",
                table: "TrAttendances");

            migrationBuilder.DropColumn(
                name: "LeaveRequestId",
                table: "TrAttendances");

            migrationBuilder.DropColumn(
                name: "Notes",
                table: "TrAttendances");

            migrationBuilder.DropColumn(
                name: "OvertimeMinutes",
                table: "TrAttendances");

            migrationBuilder.DropColumn(
                name: "PlannedCheckInTime",
                table: "TrAttendances");

            migrationBuilder.DropColumn(
                name: "PlannedCheckOutTime",
                table: "TrAttendances");

            migrationBuilder.DropColumn(
                name: "PlannedWorkMinutes",
                table: "TrAttendances");

            migrationBuilder.DropColumn(
                name: "WorkScheduleId",
                table: "TrAttendances");
        }
    }
}
