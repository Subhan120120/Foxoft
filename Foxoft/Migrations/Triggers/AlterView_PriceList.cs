using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Foxoft.Migrations
{
    /// <inheritdoc />
    public partial class AlterView_PriceList : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
									CREATE OR ALTER TRIGGER [dbo].[trgCreateView]
									ON [dbo].[DcPriceTypes]
									AFTER INSERT, UPDATE, DELETE
									AS
									BEGIN
										DECLARE  @colsPivot AS NVARCHAR(MAX), @SQL AS NVARCHAR(MAX);
									
										SELECT @colsPivot = COALESCE(@colsPivot + ', ', '') + QUOTENAME(PriceTypeCode) FROM DcPriceTypes
									
									    SET @SQL = N'
										CREATE OR ALTER VIEW PriceList
										AS 
									
										select * from (
											select * from (
												select ProductCode
												, PriceTypeCode
												, Price
												, ROW_NUM = ROW_NUMBER() over (partition by ProductCode, PriceTypeCode order by DocumentDate, DocumentTime desc)
											from TrPriceListLines
											left join TrPriceListHeaders on TrPriceListHeaders.PriceListHeaderId = TrPriceListLines.PriceListHeaderId
											) tablo where tablo.ROW_NUM=1
										) tabko
										Pivot
										(sum(Price) for PriceTypeCode in ([STD])) piv';
									    
									    EXEC sp_executesql @SQL;
									END;
									
									");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
