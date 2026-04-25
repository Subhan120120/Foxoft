using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Foxoft.Migrations
{
    /// <inheritdoc />
    public partial class asd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DcCrmActivityTypes",
                columns: table => new
                {
                    ActivityTypeId = table.Column<byte>(type: "tinyint", nullable: false),
                    ActivityTypeDesc = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsDisabled = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DcCrmActivityTypes", x => x.ActivityTypeId);
                });

            migrationBuilder.CreateTable(
                name: "CrmActivities",
                columns: table => new
                {
                    ActivityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ActivityCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CurrAccCode = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    OfficeCode = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    StoreCode = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Subject = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ActivityTypeId = table.Column<byte>(type: "tinyint", nullable: false),
                    Status = table.Column<byte>(type: "tinyint", nullable: false),
                    Priority = table.Column<byte>(type: "tinyint", nullable: false),
                    ActivityDate = table.Column<DateTime>(type: "date", nullable: false),
                    StartTime = table.Column<TimeSpan>(type: "time(0)", nullable: true),
                    EndTime =
                    table.Column<TimeSpan>(type: "time(0)", nullable: true),
                    AssignedCurrAccCode = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    Result = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    IsCompleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedUserName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, defaultValueSql: "substring(suser_name(),patindex('%\\%',suser_name())+(1),(20))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    LastUpdatedUserName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, defaultValueSql: "substring(suser_name(),patindex('%\\%',suser_name())+(1),(20))"),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CrmActivities", x => x.ActivityId);
                    table.ForeignKey(
                        name: "FK_CrmActivities_DcCrmActivityTypes_ActivityTypeId",
                        column: x => x.ActivityTypeId,
                        principalTable: "DcCrmActivityTypes",
                        principalColumn: "ActivityTypeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CrmActivities_DcCurrAccs_CurrAccCode",
                        column: x => x.CurrAccCode,
                        principalTable: "DcCurrAccs",
                        principalColumn: "CurrAccCode",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CrmActivities_ActivityCode",
                table: "CrmActivities",
                column: "ActivityCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CrmActivities_ActivityTypeId",
                table: "CrmActivities",
                column: "ActivityTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_CrmActivities_CurrAccCode_ActivityDate",
                table: "CrmActivities",
                columns: new[] { "CurrAccCode", "ActivityDate" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CrmActivities");

            migrationBuilder.DropTable(
                name: "DcCrmActivityTypes");
        }
    }
}
