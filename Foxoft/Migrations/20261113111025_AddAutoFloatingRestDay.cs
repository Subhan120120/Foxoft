using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Foxoft.Migrations
{
    /// <inheritdoc />
    public partial class AddAutoFloatingRestDay : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "AutoFloatingRestDayEnabled",
                table: "DcAttendanceSettings",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "MaxWeeklyRestDays",
                table: "DcAttendanceSettings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "DcAttendanceSettings",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AutoFloatingRestDayEnabled", "MaxWeeklyRestDays" },
                values: new object[] { true, 1 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AutoFloatingRestDayEnabled",
                table: "DcAttendanceSettings");

            migrationBuilder.DropColumn(
                name: "MaxWeeklyRestDays",
                table: "DcAttendanceSettings");
        }
    }
}
