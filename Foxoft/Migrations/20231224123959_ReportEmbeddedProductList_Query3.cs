using Microsoft.EntityFrameworkCore.Migrations;

namespace Foxoft.Migrations
{
    public partial class ReportEmbeddedProductList_Query3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
          }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "DcReports",
                keyColumn: "ReportId",
                keyValue: 1,
                column: "ReportQuery",
                value: "\r\n--declare @StartDate date = dateadd(DAY, 1, getdate())\r\n--declare @StartTime time =  '00:00:00.000'\r\n\r\n\r\nselect DcProducts.ProductCode\r\n		, [Məhsulun Geniş Adı]= isnull(DcProducts.HierarchyCode + ' ','')  + ProductDesc \r\n			+ isnull(' ' + Feature04,'') + isnull(' ' + Feature05,'') + isnull(' ' + Feature06,'') + isnull(' ' +Feature07,'')\r\n			+ isnull(' ' + Feature08,'') + isnull(' ' + Feature09,'') + isnull(' ' + Feature10,'') + isnull(' ' + Feature11,'')\r\n			+ isnull(' ' + Feature12,'') + isnull(' ' + Feature13,'') + isnull(' ' + Feature16,'') + isnull(' ' + Feature17,'') \r\n			+ isnull(' ' + Feature18,'') + isnull(' ' + Feature19 + 'x' + Feature20 + 'x' + Feature21,'') + isnull(' ' + Feature22,'')\r\n			+ isnull(' ' + Feature23,'') + isnull(' ' + Feature24,'') + isnull(' ' + Feature25,'') + isnull(' ' + Feature26,'') \r\n			+ isnull(' ' + Feature27,'') + isnull(' ' + Feature28,'') \r\n		, ProductDesc\r\n		, [Depo 1] = ISNULL([depo-01], 0)\r\n		, [Depo 2] = ISNULL([depo-02], 0)\r\n		, [Depo 3] = ISNULL([depo-03], 0)\r\n		, Balance = isnull([depo-01], 0) + isnull([depo-02],0) + isnull([depo-03],0)\r\n		, WholesalePrice\r\n		, DcProducts.HierarchyCode\r\n		, HierarchyDesc\r\n		, ProductTypeCode\r\n		, ProductId\r\n		, LastPurchasePrice = CAST((select top 1 toplam = TrInvoiceLines.PriceLoc * (1 - (TrInvoiceLines.PosDiscount / 100))  \r\n							 from TrInvoiceLines \r\n							 join TrInvoiceHeaders on TrInvoiceHeaders.InvoiceHeaderId = TrInvoiceLines.InvoiceHeaderId\r\n							 where TrInvoiceLines.ProductCode = DcProducts.ProductCode\r\n								and TrInvoiceHeaders.ProcessCode IN ( 'RP','CI')\r\n								and TrInvoiceHeaders.IsReturn = 0\r\n							 ORDER BY TrInvoiceHeaders.DocumentDate desc\r\n								, DcHierarchies.HierarchyCode desc\r\n								, TrInvoiceLines.CreatedDate desc) as money)									 \r\n		\r\nfrom DcProducts\r\n\r\nleft join DcHierarchies on DcProducts.HierarchyCode = DcHierarchies.HierarchyCode\r\nleft join SiteProducts on SiteProducts.ProductCode = DcProducts.ProductCode\r\nleft join ProductFeatures ON DcProducts.ProductCode = ProductFeatures.ProductCode \r\nleft join (select * from (\r\n					select ProductCode\r\n						, WarehouseCode\r\n						, Balance = SUM(ISNULL(QtyIn,0) - ISNULL(QtyOut,0))  \r\n					from TrInvoiceLines il\r\n					left join TrInvoiceHeaders ih on il.InvoiceHeaderId = ih.InvoiceHeaderId\r\n					group by ProductCode\r\n						, WarehouseCode\r\n				) AS SourceTable  \r\n				PIVOT  \r\n				( AVG(Balance)\r\n				  FOR WarehouseCode IN ([depo-01], [depo-02], [depo-03])  \r\n				) AS PivotTable \r\n			 ) as depolar on depolar.ProductCode = DcProducts.ProductCode\r\n\r\n	--where ProductTypeCode = 1\r\n	--and (CAST(ih.DocumentDate AS DATETIME) + CAST(ih.DocumentTime AS DATETIME)) <=\r\n	--	(CAST(@StartDate AS DATETIME) + CAST(@StartTime AS DATETIME))\r\n	--and il.ProductCode = '5503'\r\n			\r\n\r\n");
        }
    }
}
