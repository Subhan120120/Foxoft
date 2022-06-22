using Microsoft.EntityFrameworkCore.Migrations;

namespace Foxoft.Migrations
{
    public partial class Add_procedures_GetNextDocNum : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var createProcSql = @"Create PROCEDURE [dbo].[GetNextDocNum] @VariableCode nvarchar(5), @ColumnName nvarchar(30), @TableName nvarchar(30)
									AS
									BEGIN
										DECLARE @LastNumber int = (select ISNULL(LastNumber,0) from DcVariables where VariableCode = @VariableCode)
										DECLARE @DocCount int = 1	
										
										WHILE ( @DocCount = 1)
										BEGIN
											IF (@LastNumber is null or @LastNumber = '') 
												SET @LastNumber = 0
											SET @LastNumber = @LastNumber + 1
									
											DECLARE @NextDoc nvarchar(50) = @VariableCode + '-' + Convert(nvarchar, @LastNumber)
											
											DECLARE @QryDocCount nvarchar(500) = 'select @DocNum = count(1) from '+@TableName+' where '+@ColumnName+' = '''+@NextDoc+''''
											
											EXEC sp_executesql @QryDocCount, N'@DocNum int OUTPUT', @DocCount OUTPUT
									
										END
										SELECT @NextDoc AS Value
										UPDATE DcVariables SET LastNumber = @LastNumber WHERE VariableCode = @VariableCode
									END";
            migrationBuilder.Sql(createProcSql);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            var dropProcSql = "DROP PROC GetNextDocNum";
            migrationBuilder.Sql(dropProcSql);
        }
    }
}
