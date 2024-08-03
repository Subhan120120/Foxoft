using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Foxoft.Migrations
{
    /// <inheritdoc />
    public partial class ExpencesInvoice : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "DcProcesses",
                columns: new[] { "ProcessCode", "CustomCurrencyCode", "ProcessDesc", "ProcessDir" },
                values: new object[] { "EI", null, "Faktura Xərci", (byte)1 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DcProcesses",
                keyColumn: "ProcessCode",
                keyValue: "EI");

            migrationBuilder.UpdateData(
                table: "DcReports",
                keyColumn: "ReportId",
                keyValue: 15,
                column: "ReportQuery",
                value: "\r\n\r\n\r\nSELECT Maya = (-1)*(case when Dvijok.ProcessCode = 'RS' then (Dvijok.QtyIn - Dvijok.QtyOut) * ISNULL(ISNULL(NULLIF(SonQiymet, 0), ProductCost),0) else 0 end)\r\n, Menfeet = (-1)*(case when ProcessCode = 'RS' then (Dvijok.QtyIn - Dvijok.QtyOut) * ((Dvijok.PriceLoc * (100 - PosDiscount) / 100) - ISNULL(ISNULL(NULLIF(SonQiymet, 0), ProductCost),0)) else 0 end)\r\n, [Net Menfeet] = (-1)*(case when ProcessCode = 'RS' then (Dvijok.QtyIn - Dvijok.QtyOut) * ((Dvijok.PriceLoc * (100 - PosDiscount) / 100) - ISNULL(ISNULL(NULLIF(SonQiymet, 0), ProductCost),0)) else 0 end) - Xərc\r\n, *\r\nFROM (\r\nselect  InvoiceLineId\r\n, TrInvoiceHeaders.InvoiceHeaderId\r\n, TrInvoiceLines.ProductCode\r\n, ProductDesc\r\n, Qty = (QtyIn-QtyOut)*(-1)\r\n, Price\r\n, PriceLoc\r\n, Amount\r\n, TrInvoiceLines.PosDiscount\r\n, QtyIn\r\n, QtyOut\r\n, Xərc = case when TrInvoiceHeaders.ProcessCode = 'EX' then NetAmountLoc else 0 end\r\n, Satis = (-1)*(case when TrInvoiceHeaders.ProcessCode = 'RS' then (QtyIn - QtyOut) * ((PriceLoc * (100 - TrInvoiceLines.PosDiscount) / 100)) else 0 end)\r\n, Artirma = case when TrInvoiceHeaders.ProcessCode = 'CI' then NetAmountLoc else 0 end\r\n, Silinme = case when TrInvoiceHeaders.ProcessCode = 'CO' then NetAmountLoc else 0 end\r\n, ProductCost\r\n, SonQiymet = (select top 1 toplam = il.PriceLoc * (1 - (il.PosDiscount / 100))  \r\n					from TrInvoiceLines il\r\n					join TrInvoiceHeaders ih on ih.InvoiceHeaderId = il.InvoiceHeaderId\r\n					where il.ProductCode = TrInvoiceLines.ProductCode\r\n					and (ih.ProcessCode = 'RP' or ih.ProcessCode = 'CI')\r\n					and ih.IsReturn = 0\r\n					and (CAST(ih.DocumentDate AS DATETIME) + CAST(ih.DocumentTime AS DATETIME)) <=\r\n						 (CAST(TrInvoiceHeaders.DocumentDate AS DATETIME) + CAST(TrInvoiceHeaders.DocumentTime AS DATETIME))\r\n					ORDER BY ih.DocumentDate desc\r\n					, il.CreatedDate desc )	\r\n\r\n, LineDescription\r\n, SalesPersonCode\r\n, CurrencyCode\r\n, ExchangeRate\r\n, TrInvoiceHeaders.ProcessCode\r\n, ProcessDesc\r\n, InvoiceNumber = DocumentNumber\r\n, Faiz =Round( ((PriceLoc * (100 - TrInvoiceLines.PosDiscount) / 100) - ProductCost)  / NULLIF(ProductCost,0) * 100,2)\r\n, DocumentDate\r\n, DocumentTime\r\n, OperationDate\r\n, OperationTime\r\n, Description\r\n, TrInvoiceHeaders.CurrAccCode\r\n, DcCurrAccs.CurrAccDesc\r\n, DcCurrAccTypes.CurrAccTypeDesc\r\n, DcCurrAccs.CurrAccTypeCode\r\n, TrInvoiceHeaders.OfficeCode\r\n, TrInvoiceHeaders.StoreCode\r\n, WarehouseCode\r\n, CustomsDocumentNumber\r\n, PosTerminalId\r\n, IsSuspended\r\n, IsCompleted\r\n, IsSalesViaInternet\r\n, IsLocked\r\n, DcProducts.ProductTypeCode\r\n, ProductTypeDesc\r\n, UsePos\r\n, PromotionCode\r\n, TaxRate\r\n, RetailPrice\r\n, PurchasePrice\r\n, WholesalePrice\r\n, TrInvoiceLines.CreatedDate\r\n\r\nfrom TrInvoiceLines \r\nleft join TrInvoiceHeaders on TrInvoiceLines.InvoiceHeaderId = TrInvoiceHeaders.InvoiceHeaderId\r\nleft join DcProducts on TrInvoiceLines.ProductCode = DcProducts.ProductCode\r\nleft join DcProductTypes on DcProducts.ProductTypeCode = DcProductTypes.ProductTypeCode\r\nleft join DcCurrAccs on TrInvoiceHeaders.CurrAccCode = DcCurrAccs.CurrAccCode\r\nleft join DcCurrAccTypes on DcCurrAccs.CurrAccTypeCode = DcCurrAccTypes.CurrAccTypeCode\r\nleft join DcProcesses on TrInvoiceHeaders.ProcessCode = DcProcesses.ProcessCode\r\nleft join DcCurrAccs as SalesPerson on TrInvoiceLines.SalesPersonCode = SalesPerson.CurrAccCode	\r\n\r\nwhere TrInvoiceHeaders.ProcessCode IN ('CI', 'CO', 'RS', 'EX')\r\n--and DocumentNumber = 'RS-000012'\r\n) Dvijok\r\norder by Dvijok.DocumentDate\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n");
        }
    }
}
