using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Foxoft.Migrations
{
    /// <inheritdoc />
    public partial class asd2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CrmActivities_DcCrmActivityTypes_ActivityTypeId",
                table: "CrmActivities");

            migrationBuilder.DropForeignKey(
                name: "FK_CrmActivities_DcCurrAccs_CurrAccCode",
                table: "CrmActivities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CrmActivities",
                table: "CrmActivities");

            migrationBuilder.RenameTable(
                name: "CrmActivities",
                newName: "TrCrmActivities");

            migrationBuilder.RenameIndex(
                name: "IX_CrmActivities_CurrAccCode_ActivityDate",
                table: "TrCrmActivities",
                newName: "IX_TrCrmActivities_CurrAccCode_ActivityDate");

            migrationBuilder.RenameIndex(
                name: "IX_CrmActivities_ActivityTypeId",
                table: "TrCrmActivities",
                newName: "IX_TrCrmActivities_ActivityTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_CrmActivities_ActivityCode",
                table: "TrCrmActivities",
                newName: "IX_TrCrmActivities_ActivityCode");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TrCrmActivities",
                table: "TrCrmActivities",
                column: "ActivityId");

            migrationBuilder.AddForeignKey(
                name: "FK_TrCrmActivities_DcCrmActivityTypes_ActivityTypeId",
                table: "TrCrmActivities",
                column: "ActivityTypeId",
                principalTable: "DcCrmActivityTypes",
                principalColumn: "ActivityTypeId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TrCrmActivities_DcCurrAccs_CurrAccCode",
                table: "TrCrmActivities",
                column: "CurrAccCode",
                principalTable: "DcCurrAccs",
                principalColumn: "CurrAccCode",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrCrmActivities_DcCrmActivityTypes_ActivityTypeId",
                table: "TrCrmActivities");

            migrationBuilder.DropForeignKey(
                name: "FK_TrCrmActivities_DcCurrAccs_CurrAccCode",
                table: "TrCrmActivities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TrCrmActivities",
                table: "TrCrmActivities");

            migrationBuilder.RenameTable(
                name: "TrCrmActivities",
                newName: "CrmActivities");

            migrationBuilder.RenameIndex(
                name: "IX_TrCrmActivities_CurrAccCode_ActivityDate",
                table: "CrmActivities",
                newName: "IX_CrmActivities_CurrAccCode_ActivityDate");

            migrationBuilder.RenameIndex(
                name: "IX_TrCrmActivities_ActivityTypeId",
                table: "CrmActivities",
                newName: "IX_CrmActivities_ActivityTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_TrCrmActivities_ActivityCode",
                table: "CrmActivities",
                newName: "IX_CrmActivities_ActivityCode");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CrmActivities",
                table: "CrmActivities",
                column: "ActivityId");

            migrationBuilder.AddForeignKey(
                name: "FK_CrmActivities_DcCrmActivityTypes_ActivityTypeId",
                table: "CrmActivities",
                column: "ActivityTypeId",
                principalTable: "DcCrmActivityTypes",
                principalColumn: "ActivityTypeId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CrmActivities_DcCurrAccs_CurrAccCode",
                table: "CrmActivities",
                column: "CurrAccCode",
                principalTable: "DcCurrAccs",
                principalColumn: "CurrAccCode",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
