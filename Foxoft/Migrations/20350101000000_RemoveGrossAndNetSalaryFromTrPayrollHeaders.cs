using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Foxoft.Models;

#nullable disable

namespace Foxoft.Migrations
{
    [DbContext(typeof(subContext))]
    [Migration("20350101000000_RemoveGrossAndNetSalaryFromTrPayrollHeaders")]
    public partial class RemoveGrossAndNetSalaryFromTrPayrollHeaders : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
-- 1. Drop GrossSalary column from TrPayrollHeaders if exists
IF COL_LENGTH(N'dbo.TrPayrollHeaders', N'GrossSalary') IS NOT NULL
BEGIN
    DECLARE @GrossConstraint nvarchar(200);
    SELECT @GrossConstraint = d.name
    FROM sys.default_constraints d
    JOIN sys.columns c ON d.parent_object_id = c.object_id AND d.parent_column_id = c.column_id
    WHERE d.parent_object_id = OBJECT_ID(N'dbo.TrPayrollHeaders') AND c.name = N'GrossSalary';

    IF @GrossConstraint IS NOT NULL
        EXEC(N'ALTER TABLE [dbo].[TrPayrollHeaders] DROP CONSTRAINT [' + @GrossConstraint + N']');

    ALTER TABLE [dbo].[TrPayrollHeaders] DROP COLUMN [GrossSalary];
END

-- 2. Drop NetSalary column from TrPayrollHeaders if exists
IF COL_LENGTH(N'dbo.TrPayrollHeaders', N'NetSalary') IS NOT NULL
BEGIN
    DECLARE @NetConstraint nvarchar(200);
    SELECT @NetConstraint = d.name
    FROM sys.default_constraints d
    JOIN sys.columns c ON d.parent_object_id = c.object_id AND d.parent_column_id = c.column_id
    WHERE d.parent_object_id = OBJECT_ID(N'dbo.TrPayrollHeaders') AND c.name = N'NetSalary';

    IF @NetConstraint IS NOT NULL
        EXEC(N'ALTER TABLE [dbo].[TrPayrollHeaders] DROP CONSTRAINT [' + @NetConstraint + N']');

    ALTER TABLE [dbo].[TrPayrollHeaders] DROP COLUMN [NetSalary];
END

-- 3. Drop columns from TrPayrollHeadersDeleted if table exists
IF OBJECT_ID(N'dbo.TrPayrollHeadersDeleted', N'U') IS NOT NULL
BEGIN
    IF COL_LENGTH(N'dbo.TrPayrollHeadersDeleted', N'GrossSalary') IS NOT NULL
    BEGIN
        DECLARE @GrossDelConstraint nvarchar(200);
        SELECT @GrossDelConstraint = d.name
        FROM sys.default_constraints d
        JOIN sys.columns c ON d.parent_object_id = c.object_id AND d.parent_column_id = c.column_id
        WHERE d.parent_object_id = OBJECT_ID(N'dbo.TrPayrollHeadersDeleted') AND c.name = N'GrossSalary';

        IF @GrossDelConstraint IS NOT NULL
            EXEC(N'ALTER TABLE [dbo].[TrPayrollHeadersDeleted] DROP CONSTRAINT [' + @GrossDelConstraint + N']');

        ALTER TABLE [dbo].[TrPayrollHeadersDeleted] DROP COLUMN [GrossSalary];
    END

    IF COL_LENGTH(N'dbo.TrPayrollHeadersDeleted', N'NetSalary') IS NOT NULL
    BEGIN
        DECLARE @NetDelConstraint nvarchar(200);
        SELECT @NetDelConstraint = d.name
        FROM sys.default_constraints d
        JOIN sys.columns c ON d.parent_object_id = c.object_id AND d.parent_column_id = c.column_id
        WHERE d.parent_object_id = OBJECT_ID(N'dbo.TrPayrollHeadersDeleted') AND c.name = N'NetSalary';

        IF @NetDelConstraint IS NOT NULL
            EXEC(N'ALTER TABLE [dbo].[TrPayrollHeadersDeleted] DROP CONSTRAINT [' + @NetDelConstraint + N']');

        ALTER TABLE [dbo].[TrPayrollHeadersDeleted] DROP COLUMN [NetSalary];
    END
END

-- 4. Update dbo.CurrAccBalance function to compute payroll net salary dynamically from lines
IF OBJECT_ID(N'dbo.CurrAccBalance', N'FN') IS NOT NULL
BEGIN
    EXEC(N'
    CREATE OR ALTER FUNCTION dbo.CurrAccBalance (
        @CurrAccCode NVARCHAR(50),
        @DateTime DATETIME
    )
    RETURNS DECIMAL(18, 2)
    AS
    BEGIN
        DECLARE @result DECIMAL(18, 2)

        -- Calculate the sum of invoice lines
        DECLARE @invoiceSum DECIMAL(18, 2)
        SET @invoiceSum = ISNULL(
            (
                SELECT SUM((QtyIn - QtyOut) * (PriceLoc - (PriceLoc * PosDiscount / 100)))
                FROM TrInvoiceLines il  
                LEFT JOIN TrInvoiceHeaders ih ON il.InvoiceHeaderId = ih.InvoiceHeaderId
                WHERE ih.CurrAccCode = @CurrAccCode
                  AND ih.ProcessCode IN (''RP'', ''WP'', ''RS'', ''WS'', ''IS'', ''CI'', ''CO'', ''IT'')
                  AND (CAST(ih.DocumentDate AS DATETIME) + CAST(ih.DocumentTime AS DATETIME)) <= @DateTime
            ), 
            0
        )

        -- Calculate the sum of payment lines
        DECLARE @paymentSum DECIMAL(18, 2)
        SET @paymentSum = ISNULL(
            (
                SELECT SUM(PaymentLoc)
                FROM TrPaymentLines pl
                LEFT JOIN TrPaymentHeaders ph ON pl.PaymentHeaderId = ph.PaymentHeaderId
                WHERE ph.CurrAccCode = @CurrAccCode
                  AND (CAST(ph.DocumentDate AS DATETIME) + CAST(ph.DocumentTime AS DATETIME)) <= @DateTime
            ), 
            0
        )

        -- Calculate the sum of payrolls (HR) from TrPayrollLines
        DECLARE @payrollSum DECIMAL(18, 2)
        SET @payrollSum = ISNULL(
            (
                SELECT SUM(CASE 
                    WHEN prl.PayrollItemType IN (1, 2, 3) THEN prl.AmountLoc 
                    WHEN prl.PayrollItemType IN (4, 5, 6) THEN -prl.AmountLoc 
                    ELSE 0 END)
                FROM TrPayrollLines prl
                INNER JOIN TrPayrollHeaders prh ON prl.PayrollHeaderId = prh.Id
                LEFT JOIN DcPayrollPeriods prp ON prh.PayrollPeriodId = prp.Id
                WHERE prh.CurrAccCode = @CurrAccCode
                  AND (CAST(EOMONTH(DATEFROMPARTS(prp.PeriodYear, prp.PeriodMonth, 1)) AS DATETIME) + CAST(''23:59:59'' AS DATETIME)) <= @DateTime
            ), 
            0
        )

        -- Calculate the result
        SET @result = @invoiceSum + @paymentSum + @payrollSum

        RETURN @result
    END');
END
");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
IF COL_LENGTH(N'dbo.TrPayrollHeaders', N'GrossSalary') IS NULL
BEGIN
    ALTER TABLE [dbo].[TrPayrollHeaders] 
    ADD [GrossSalary] decimal(18, 2) NOT NULL CONSTRAINT [DF_TrPayrollHeaders_GrossSalary] DEFAULT (0);
END

IF COL_LENGTH(N'dbo.TrPayrollHeaders', N'NetSalary') IS NULL
BEGIN
    ALTER TABLE [dbo].[TrPayrollHeaders] 
    ADD [NetSalary] decimal(18, 2) NOT NULL CONSTRAINT [DF_TrPayrollHeaders_NetSalary] DEFAULT (0);
END
");
        }
    }
}
