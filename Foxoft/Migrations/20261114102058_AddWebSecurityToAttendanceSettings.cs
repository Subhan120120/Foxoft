using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Foxoft.Migrations
{
    /// <inheritdoc />
    public partial class AddWebSecurityToAttendanceSettings : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "RequireDeviceLock",
                table: "DcAttendanceSettings",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "RequireDynamicQrCode",
                table: "DcAttendanceSettings",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "RequireGpsGeofencing",
                table: "DcAttendanceSettings",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "DcAttendanceSettings",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "RequireDeviceLock", "RequireDynamicQrCode", "RequireGpsGeofencing" },
                values: new object[] { true, true, true });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RequireDeviceLock",
                table: "DcAttendanceSettings");

            migrationBuilder.DropColumn(
                name: "RequireDynamicQrCode",
                table: "DcAttendanceSettings");

            migrationBuilder.DropColumn(
                name: "RequireGpsGeofencing",
                table: "DcAttendanceSettings");
        }
    }
}
