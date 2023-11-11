using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Foxoft.Migrations
{
    public partial class asdsadfhj : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DcCurrAccs",
                keyColumn: "CurrAccCode",
                keyValue: "C-000001");

            migrationBuilder.DeleteData(
                table: "DcCurrAccs",
                keyColumn: "CurrAccCode",
                keyValue: "C-000002");

            migrationBuilder.DeleteData(
                table: "DcCurrAccs",
                keyColumn: "CurrAccCode",
                keyValue: "C-000003");

            migrationBuilder.DeleteData(
                table: "DcCurrAccs",
                keyColumn: "CurrAccCode",
                keyValue: "C-000004");

            migrationBuilder.DeleteData(
                table: "DcCurrAccs",
                keyColumn: "CurrAccCode",
                keyValue: "C-000005");

            migrationBuilder.InsertData(
                table: "DcCurrAccs",
                columns: new[] { "CurrAccCode", "Address", "BonusCardNum", "CashRegPaymentTypeCode", "CompanyCode", "ConfirmPassword", "CreatedDate", "CurrAccDesc", "CurrAccTypeCode", "CustomerTypeCode", "DataLanguageCode", "FatherName", "FirstName", "IdentityNum", "IsDefault", "LastName", "NewPassword", "OfficeCode", "PhoneNum", "RowGuid", "StoreCode", "TaxNum", "Theme", "VendorTypeCode" },
                values: new object[,]
                {
                    { "CA-1", null, null, null, (byte)0, null, new DateTime(1901, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, (byte)3, null, null, null, "Administrator", null, false, null, "123", "ofs01", "0519678909", new Guid("00000000-0000-0000-0000-000000000000"), "mgz01", null, null, null },
                    { "CA-2", null, null, null, (byte)0, null, new DateTime(1901, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, (byte)3, null, null, null, "Mudir", null, false, "Mudir", "123", "ofs01", "0519678909", new Guid("00000000-0000-0000-0000-000000000000"), "mgz01", null, null, null },
                    { "CA-3", null, null, null, (byte)0, null, new DateTime(1901, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, (byte)3, null, null, null, "Operator", null, false, "Operator", "123", "ofs01", "0773628800", new Guid("00000000-0000-0000-0000-000000000000"), "mgz01", null, null, null },
                    { "CA-4", null, null, null, (byte)0, null, new DateTime(1901, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, (byte)3, null, null, null, "Satici", null, false, "Satici", "123", "ofs01", "0553628804", new Guid("00000000-0000-0000-0000-000000000000"), "mgz01", null, null, null },
                    { "CA-5", null, null, null, (byte)0, null, new DateTime(1901, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ümumi Müştəri", (byte)1, null, null, null, "Ümumi Müştəri", null, true, null, "123", "ofs01", null, new Guid("00000000-0000-0000-0000-000000000000"), "mgz01", null, null, null }
                });

            migrationBuilder.UpdateData(
                table: "DcCurrencies",
                keyColumn: "CurrencyCode",
                keyValue: "EUR",
                column: "ExchangeRate",
                value: 1.798f);

            migrationBuilder.UpdateData(
                table: "DcCurrencies",
                keyColumn: "CurrencyCode",
                keyValue: "USD",
                column: "ExchangeRate",
                value: 1.703f);

            migrationBuilder.UpdateData(
                table: "DcOffices",
                keyColumn: "OfficeCode",
                keyValue: "ofs01",
                column: "OfficeDesc",
                value: "Bakıxanov Ofisi");

            migrationBuilder.InsertData(
                table: "DcOffices",
                columns: new[] { "OfficeCode", "CompanyCode", "IsDisabled", "OfficeDesc", "RowGuid" },
                values: new object[] { "ofs02", 0m, false, "Elmlər Ofisi", new Guid("00000000-0000-0000-0000-000000000000") });

            migrationBuilder.UpdateData(
                table: "DcProducts",
                keyColumn: "ProductCode",
                keyValue: "xerc01",
                column: "ProductDesc",
                value: "Yol Xerci");

            migrationBuilder.UpdateData(
                table: "DcProducts",
                keyColumn: "ProductCode",
                keyValue: "xerc02",
                column: "ProductDesc",
                value: "Isiq Pulu");

            migrationBuilder.UpdateData(
                table: "DcProducts",
                keyColumn: "ProductCode",
                keyValue: "test01",
                column: "ProductDesc",
                value: "Papaq");

            migrationBuilder.UpdateData(
                table: "DcProducts",
                keyColumn: "ProductCode",
                keyValue: "test02",
                column: "ProductDesc",
                value: "Salvar");

            migrationBuilder.UpdateData(
                table: "DcReports",
                keyColumn: "ReportId",
                keyValue: 4,
                column: "ReportName",
                value: "Report_Grid_Expenses");

            migrationBuilder.UpdateData(
                table: "DcReports",
                keyColumn: "ReportId",
                keyValue: 5,
                column: "ReportName",
                value: "Report_Grid_MoneyMovements");

            migrationBuilder.UpdateData(
                table: "DcReports",
                keyColumn: "ReportId",
                keyValue: 6,
                column: "ReportName",
                value: "Report_Grid_MovementsWithAccounts");

            migrationBuilder.UpdateData(
                table: "DcReports",
                keyColumn: "ReportId",
                keyValue: 7,
                column: "ReportName",
                value: "Report_Grid_ProductMovements");

            migrationBuilder.UpdateData(
                table: "DcReports",
                keyColumn: "ReportId",
                keyValue: 8,
                column: "ReportName",
                value: "Report_Grid_Profit");

            migrationBuilder.UpdateData(
                table: "DcReports",
                keyColumn: "ReportId",
                keyValue: 9,
                column: "ReportName",
                value: "Report_Grid_RecentGoods");

            migrationBuilder.UpdateData(
                table: "DcReports",
                keyColumn: "ReportId",
                keyValue: 10,
                column: "ReportName",
                value: "Report_Grid_WarehouseBalance");

            migrationBuilder.UpdateData(
                table: "DcReports",
                keyColumn: "ReportId",
                keyValue: 11,
                columns: new[] { "ReportName", "ReportTypeId" },
                values: new object[] { "Report_Detail_ProductCard", (byte)1 });

            migrationBuilder.InsertData(
                table: "DcWarehouses",
                columns: new[] { "WarehouseCode", "ControlStockLevel", "IsDefault", "IsDisabled", "OfficeCode", "PermitNegativeStock", "RowGuid", "StoreCode", "WarehouseDesc", "WarehouseTypeCode", "WarnNegativeStock", "WarnStockLevelRate" },
                values: new object[] { "depo-02", false, false, false, "ofs01", false, new Guid("00000000-0000-0000-0000-000000000000"), "mgz01", "Elmlər deposu", (byte)0, false, false });

            migrationBuilder.UpdateData(
                table: "TrCurrAccRoles",
                keyColumn: "CurrAccRoleId",
                keyValue: 1,
                column: "CurrAccCode",
                value: "CA-1");
        }
    }
}
