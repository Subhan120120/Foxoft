﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace Foxoft.Migrations
{
    public partial class Add_procedures_GetNextDocNum : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var createProcSql = @"CREATE OR ALTER PROCEDURE [dbo].[GetNextDocNum] @DefisExist bit, @VariableCode nvarchar(5), @ColumnName nvarchar(30), @TableName nvarchar(30), @ReplicateNum int
				AS
				BEGIN
				
					DECLARE @LastNumber int = (select ISNULL(LastNumber,0) from DcVariables where VariableCode = @VariableCode )
					DECLARE @DocCount int = 1	
															
					IF (@LastNumber is null or @LastNumber = '') 
						SET @LastNumber = 0
				
					WHILE ( @DocCount = 1)
					BEGIN
						SET @LastNumber = @LastNumber + 1
						
						DECLARE @zero nvarchar(50) = REPLICATE('0', @ReplicateNum)
						
						DECLARE @NextDoc nvarchar(50) ; 
						
						if(@DefisExist = 1 )
							BEGIN
								SET @NextDoc = @VariableCode + '-' + Convert(nvarchar, format(@LastNumber, @zero)); 
							END
						ELSE 
							BEGIN
								SET @NextDoc = @VariableCode + Convert(nvarchar, format(@LastNumber, @zero)); 
							END
						DECLARE @QryDocCount nvarchar(500) = 'select @DocNum = count(1) from '+@TableName+' where '+@ColumnName+' = '''+@NextDoc+''''
						
						EXEC sp_executesql @QryDocCount, N'@DocNum int OUTPUT', @DocCount OUTPUT
				
					END

					DECLARE @IsIdentityColumn BIT =  (SELECT 
														    CASE 
														        WHEN c.is_identity = 1 THEN CAST(1 AS BIT)
														        ELSE CAST(0 AS BIT)
														    END AS IsIdentityColumn
														FROM 
														    sys.tables AS t
														INNER JOIN 
														    sys.columns AS c
														    ON t.object_id = c.object_id
														WHERE 
														    t.name = @TableName
														    AND c.name = @ColumnName)
					IF(@IsIdentityColumn = 1)
						set @NextDoc = 0;

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
