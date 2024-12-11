using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Foxoft.Migrations
{
    /// <inheritdoc />
    public partial class PaymentTypecomission : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "DcPaymentTypes",
                columns: new[] { "PaymentTypeCode", "PaymentTypeDesc" },
                values: new object[] { (byte)4, "Komissiya" });

          }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DcPaymentTypes",
                keyColumn: "PaymentTypeCode",
                keyValue: (byte)4);

            migrationBuilder.UpdateData(
                table: "DcReports",
                keyColumn: "ReportId",
                keyValue: 1,
                column: "ReportQuery",
                value: "\r\n\r\n\r\n\r\n\r\n\r\n--declare @StartDate date = dateadd(DAY, 1, getdate())\r\n--declare @StartTime time =  '00:00:00.000'\r\n\r\nselect * from (\r\n\r\nSelect pro.ProductCode\r\n		, pro.HierarchyCode\r\n		, [M?hsulun Genis Adi]= isnull(pro.HierarchyCode + ' ','')  + ProductDesc \r\n			+ isnull(' ' + Feature04,'') + isnull(' ' + Feature05,'') + isnull(' ' + Feature06,'') + isnull(' ' +Feature07,'')\r\n			+ isnull(' ' + Feature08,'') + isnull(' ' + Feature09,'') + isnull(' ' + Feature10,'') + isnull(' ' + Feature11,'')\r\n			+ isnull(' ' + Feature12,'') + isnull(' ' + Feature13,'') + isnull(' ' + Feature16,'') + isnull(' ' + Feature17,'') \r\n			+ isnull(' ' + Feature18,'') + isnull(' ' + Feature19 + 'x' + Feature20 + 'x' + Feature21,'') + isnull(' ' + Feature22,'')\r\n			+ isnull(' ' + Feature23,'') + isnull(' ' + Feature24,'') + isnull(' ' + Feature25,'') + isnull(' ' + Feature26,'') \r\n			+ isnull(' ' + Feature27,'') + isnull(' ' + Feature28,'') \r\n		, ProductDesc\r\n		, Balance = isnull(ProductBalance.[depo-01],0)\r\n		, WholesalePrice\r\n		, HierarchyDesc\r\n		, ProductTypeCode\r\n		--, ProductId	\r\n		, ProductCost = dbo.GetProductCost(pro.ProductCode, null)\r\n		, CalcClosingStockFifo.FIFO_CORG\r\n		\r\nfrom DcProducts pro\r\n\r\nleft join DcHierarchies on pro.HierarchyCode = DcHierarchies.HierarchyCode\r\n--left join SiteProducts on SiteProducts.ProductCode = pro.ProductCode\r\nleft join ProductFeatures ON pro.ProductCode = ProductFeatures.ProductCode \r\nleft join ProductBalance on ProductBalance.ProductCode = pro.ProductCode\r\nleft join CalcClosingStockFifo on CalcClosingStockFifo.ProductCode = pro.ProductCode\r\n\r\n	--where ProductTypeCode = 1\r\n	--and (CAST(ih.DocumentDate AS DATETIME) + CAST(ih.DocumentTime AS DATETIME)) <=\r\n	--	(CAST(@StartDate AS DATETIME) + CAST(@StartTime AS DATETIME))\r\n	--and il.ProductCode = '5503'\r\n\r\n) as tablo \r\n	order by \r\ntablo.HierarchyCode \r\n, tablo.ProductDesc \r\n\r\n\r\n\r\n\r\n");
        }
    }
}
