using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Foxoft.Migrations
{
    public partial class asdasdkgjj : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CurrencyCode",
                table: "TrPaymentHeaders");

            migrationBuilder.DropColumn(
                name: "ExchangeRate",
                table: "TrPaymentHeaders");

            migrationBuilder.RenameIndex(
                name: "IX_ShipmentHeaderID",
                table: "TrShipmentLines",
                newName: "IX_TrShipmentLines_ShipmentHeaderId");

            migrationBuilder.AlterColumn<string>(
                name: "UsedBarcode",
                table: "TrShipmentLines",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10,
                oldDefaultValueSql: "space(0)");

            migrationBuilder.AlterColumn<string>(
                name: "SalespersonCode",
                table: "TrShipmentLines",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10,
                oldDefaultValueSql: "space(0)");

            migrationBuilder.AlterColumn<string>(
                name: "ProductDimensionCode",
                table: "TrShipmentLines",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10,
                oldDefaultValueSql: "space(0)");

            migrationBuilder.AlterColumn<string>(
                name: "ProductCode",
                table: "TrShipmentLines",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldDefaultValueSql: "space(0)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "TrShipmentLines",
                type: "money",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "money",
                oldDefaultValue: 0m);

            migrationBuilder.AlterColumn<string>(
                name: "LineDescription",
                table: "TrShipmentLines",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldDefaultValueSql: "space(0)");

            migrationBuilder.AlterColumn<string>(
                name: "CurrencyCode",
                table: "TrShipmentLines",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10,
                oldDefaultValueSql: "space(0)");

            migrationBuilder.AlterColumn<string>(
                name: "ColorCode",
                table: "TrShipmentLines",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10,
                oldDefaultValueSql: "space(0)");

            migrationBuilder.AlterColumn<string>(
                name: "WarehouseCode",
                table: "TrShipmentHeaders",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30,
                oldDefaultValueSql: "space(0)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "TransferApprovedDate",
                table: "TrShipmentHeaders",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "space(0)");

            migrationBuilder.AlterColumn<string>(
                name: "ToWarehouseCode",
                table: "TrShipmentHeaders",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30,
                oldDefaultValueSql: "space(0)");

            migrationBuilder.AlterColumn<string>(
                name: "StoreCode",
                table: "TrShipmentHeaders",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30,
                oldDefaultValueSql: "space(0)");

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "ShippingTime",
                table: "TrShipmentHeaders",
                type: "time(0)",
                nullable: false,
                oldClrType: typeof(TimeSpan),
                oldType: "time(0)",
                oldDefaultValueSql: "convert(varchar(10), GETDATE(), 108)");

            migrationBuilder.AlterColumn<Guid>(
                name: "ShippingPostalAddressId",
                table: "TrShipmentHeaders",
                type: "uniqueidentifier",
                maxLength: 60,
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldMaxLength: 60,
                oldDefaultValueSql: "space(0)");

            migrationBuilder.AlterColumn<string>(
                name: "ShippingNumber",
                table: "TrShipmentHeaders",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30,
                oldDefaultValueSql: "space(0)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ShippingDate",
                table: "TrShipmentHeaders",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "date",
                oldDefaultValueSql: "getdate()");

            migrationBuilder.AlterColumn<string>(
                name: "ProcessCode",
                table: "TrShipmentHeaders",
                type: "nvarchar(5)",
                maxLength: 5,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(5)",
                oldMaxLength: 5,
                oldDefaultValueSql: "space(0)");

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "OperationTime",
                table: "TrShipmentHeaders",
                type: "time(0)",
                nullable: false,
                oldClrType: typeof(TimeSpan),
                oldType: "time(0)",
                oldDefaultValueSql: "convert(varchar(10), GETDATE(), 108)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "OperationDate",
                table: "TrShipmentHeaders",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "date",
                oldDefaultValueSql: "getdate()");

            migrationBuilder.AlterColumn<string>(
                name: "OfficeCode",
                table: "TrShipmentHeaders",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10,
                oldDefaultValueSql: "space(0)");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "TrShipmentHeaders",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldDefaultValueSql: "space(0)");

            migrationBuilder.AlterColumn<decimal>(
                name: "PaymentLoc",
                table: "TrPaymentLines",
                type: "money",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "money",
                oldDefaultValueSql: "0");

            migrationBuilder.AlterColumn<decimal>(
                name: "Payment",
                table: "TrPaymentLines",
                type: "money",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "money",
                oldDefaultValueSql: "0");

            migrationBuilder.AlterColumn<float>(
                name: "ExchangeRate",
                table: "TrPaymentLines",
                type: "real",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real",
                oldDefaultValueSql: "1");

            migrationBuilder.AlterColumn<short>(
                name: "PosterminalId",
                table: "TrPaymentHeaders",
                type: "smallint",
                nullable: false,
                oldClrType: typeof(short),
                oldType: "smallint",
                oldDefaultValueSql: "space(0)");

            migrationBuilder.AlterColumn<bool>(
                name: "IsLocked",
                table: "TrPaymentHeaders",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValueSql: "0");

            migrationBuilder.AlterColumn<bool>(
                name: "IsCompleted",
                table: "TrPaymentHeaders",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValueSql: "0");

            migrationBuilder.AlterColumn<string>(
                name: "DocumentNumber",
                table: "TrPaymentHeaders",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldDefaultValueSql: "space(0)");

            migrationBuilder.AlterColumn<float>(
                name: "VatRate",
                table: "TrInvoiceLines",
                type: "real",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real",
                oldDefaultValueSql: "0");

            migrationBuilder.AlterColumn<int>(
                name: "QtyOut",
                table: "TrInvoiceLines",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValueSql: "0");

            migrationBuilder.AlterColumn<int>(
                name: "QtyIn",
                table: "TrInvoiceLines",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValueSql: "0");

            migrationBuilder.AlterColumn<double>(
                name: "Price",
                table: "TrInvoiceLines",
                type: "float",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float",
                oldDefaultValueSql: "0");

            migrationBuilder.AlterColumn<decimal>(
                name: "PosDiscount",
                table: "TrInvoiceLines",
                type: "money",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "money",
                oldDefaultValueSql: "0");

            migrationBuilder.AlterColumn<decimal>(
                name: "NetAmount",
                table: "TrInvoiceLines",
                type: "money",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "money",
                oldDefaultValueSql: "0");

            migrationBuilder.AlterColumn<float>(
                name: "ExchangeRate",
                table: "TrInvoiceLines",
                type: "real",
                nullable: false,
                defaultValueSql: "1.703",
                oldClrType: typeof(float),
                oldType: "real",
                oldDefaultValueSql: "1");

            migrationBuilder.AlterColumn<decimal>(
                name: "DiscountCampaign",
                table: "TrInvoiceLines",
                type: "money",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "money",
                oldDefaultValueSql: "0");

            migrationBuilder.AlterColumn<decimal>(
                name: "Amount",
                table: "TrInvoiceLines",
                type: "money",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "money",
                oldDefaultValueSql: "0");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameIndex(
                name: "IX_TrShipmentLines_ShipmentHeaderId",
                table: "TrShipmentLines",
                newName: "IX_ShipmentHeaderID");

            migrationBuilder.AlterColumn<string>(
                name: "UsedBarcode",
                table: "TrShipmentLines",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValueSql: "space(0)",
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10);

            migrationBuilder.AlterColumn<string>(
                name: "SalespersonCode",
                table: "TrShipmentLines",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValueSql: "space(0)",
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10);

            migrationBuilder.AlterColumn<string>(
                name: "ProductDimensionCode",
                table: "TrShipmentLines",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValueSql: "space(0)",
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10);

            migrationBuilder.AlterColumn<string>(
                name: "ProductCode",
                table: "TrShipmentLines",
                type: "nvarchar(max)",
                nullable: true,
                defaultValueSql: "space(0)",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "TrShipmentLines",
                type: "money",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "money");

            migrationBuilder.AlterColumn<string>(
                name: "LineDescription",
                table: "TrShipmentLines",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValueSql: "space(0)",
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "CurrencyCode",
                table: "TrShipmentLines",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValueSql: "space(0)",
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10);

            migrationBuilder.AlterColumn<string>(
                name: "ColorCode",
                table: "TrShipmentLines",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValueSql: "space(0)",
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10);

            migrationBuilder.AlterColumn<string>(
                name: "WarehouseCode",
                table: "TrShipmentHeaders",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValueSql: "space(0)",
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<DateTime>(
                name: "TransferApprovedDate",
                table: "TrShipmentHeaders",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "space(0)",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "ToWarehouseCode",
                table: "TrShipmentHeaders",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValueSql: "space(0)",
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<string>(
                name: "StoreCode",
                table: "TrShipmentHeaders",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValueSql: "space(0)",
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "ShippingTime",
                table: "TrShipmentHeaders",
                type: "time(0)",
                nullable: false,
                defaultValueSql: "convert(varchar(10), GETDATE(), 108)",
                oldClrType: typeof(TimeSpan),
                oldType: "time(0)");

            migrationBuilder.AlterColumn<Guid>(
                name: "ShippingPostalAddressId",
                table: "TrShipmentHeaders",
                type: "uniqueidentifier",
                maxLength: 60,
                nullable: false,
                defaultValueSql: "space(0)",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldMaxLength: 60);

            migrationBuilder.AlterColumn<string>(
                name: "ShippingNumber",
                table: "TrShipmentHeaders",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValueSql: "space(0)",
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ShippingDate",
                table: "TrShipmentHeaders",
                type: "date",
                nullable: false,
                defaultValueSql: "getdate()",
                oldClrType: typeof(DateTime),
                oldType: "date");

            migrationBuilder.AlterColumn<string>(
                name: "ProcessCode",
                table: "TrShipmentHeaders",
                type: "nvarchar(5)",
                maxLength: 5,
                nullable: false,
                defaultValueSql: "space(0)",
                oldClrType: typeof(string),
                oldType: "nvarchar(5)",
                oldMaxLength: 5);

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "OperationTime",
                table: "TrShipmentHeaders",
                type: "time(0)",
                nullable: false,
                defaultValueSql: "convert(varchar(10), GETDATE(), 108)",
                oldClrType: typeof(TimeSpan),
                oldType: "time(0)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "OperationDate",
                table: "TrShipmentHeaders",
                type: "date",
                nullable: false,
                defaultValueSql: "getdate()",
                oldClrType: typeof(DateTime),
                oldType: "date");

            migrationBuilder.AlterColumn<string>(
                name: "OfficeCode",
                table: "TrShipmentHeaders",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValueSql: "space(0)",
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "TrShipmentHeaders",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValueSql: "space(0)",
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<decimal>(
                name: "PaymentLoc",
                table: "TrPaymentLines",
                type: "money",
                nullable: false,
                defaultValueSql: "0",
                oldClrType: typeof(decimal),
                oldType: "money");

            migrationBuilder.AlterColumn<decimal>(
                name: "Payment",
                table: "TrPaymentLines",
                type: "money",
                nullable: false,
                defaultValueSql: "0",
                oldClrType: typeof(decimal),
                oldType: "money");

            migrationBuilder.AlterColumn<float>(
                name: "ExchangeRate",
                table: "TrPaymentLines",
                type: "real",
                nullable: false,
                defaultValueSql: "1",
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<short>(
                name: "PosterminalId",
                table: "TrPaymentHeaders",
                type: "smallint",
                nullable: false,
                defaultValueSql: "space(0)",
                oldClrType: typeof(short),
                oldType: "smallint");

            migrationBuilder.AlterColumn<bool>(
                name: "IsLocked",
                table: "TrPaymentHeaders",
                type: "bit",
                nullable: false,
                defaultValueSql: "0",
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "IsCompleted",
                table: "TrPaymentHeaders",
                type: "bit",
                nullable: false,
                defaultValueSql: "0",
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<string>(
                name: "DocumentNumber",
                table: "TrPaymentHeaders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValueSql: "space(0)",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "CurrencyCode",
                table: "TrPaymentHeaders",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValueSql: "space(0)");

            migrationBuilder.AddColumn<double>(
                name: "ExchangeRate",
                table: "TrPaymentHeaders",
                type: "float",
                maxLength: 60,
                nullable: false,
                defaultValueSql: "1");

            migrationBuilder.AlterColumn<float>(
                name: "VatRate",
                table: "TrInvoiceLines",
                type: "real",
                nullable: false,
                defaultValueSql: "0",
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<int>(
                name: "QtyOut",
                table: "TrInvoiceLines",
                type: "int",
                nullable: false,
                defaultValueSql: "0",
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "QtyIn",
                table: "TrInvoiceLines",
                type: "int",
                nullable: false,
                defaultValueSql: "0",
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<double>(
                name: "Price",
                table: "TrInvoiceLines",
                type: "float",
                nullable: false,
                defaultValueSql: "0",
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<decimal>(
                name: "PosDiscount",
                table: "TrInvoiceLines",
                type: "money",
                nullable: false,
                defaultValueSql: "0",
                oldClrType: typeof(decimal),
                oldType: "money");

            migrationBuilder.AlterColumn<decimal>(
                name: "NetAmount",
                table: "TrInvoiceLines",
                type: "money",
                nullable: false,
                defaultValueSql: "0",
                oldClrType: typeof(decimal),
                oldType: "money");

            migrationBuilder.AlterColumn<float>(
                name: "ExchangeRate",
                table: "TrInvoiceLines",
                type: "real",
                nullable: false,
                defaultValueSql: "1",
                oldClrType: typeof(float),
                oldType: "real",
                oldDefaultValueSql: "1.703");

            migrationBuilder.AlterColumn<decimal>(
                name: "DiscountCampaign",
                table: "TrInvoiceLines",
                type: "money",
                nullable: false,
                defaultValueSql: "0",
                oldClrType: typeof(decimal),
                oldType: "money");

            migrationBuilder.AlterColumn<decimal>(
                name: "Amount",
                table: "TrInvoiceLines",
                type: "money",
                nullable: false,
                defaultValueSql: "0",
                oldClrType: typeof(decimal),
                oldType: "money");
        }
    }
}
