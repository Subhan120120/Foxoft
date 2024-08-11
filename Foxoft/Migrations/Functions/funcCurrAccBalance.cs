using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Foxoft.Migrations
{
    /// <inheritdoc />
    public partial class funcCurrAccBalance : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                                @"

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
                                      and ih.ProcessCode in ('RP', 'WP', 'RS', 'WS', 'CI', 'CO', 'IT' )
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
                        
                            -- Calculate the result
                            SET @result = @invoiceSum + @paymentSum
                        
                            RETURN @result
                        END
                        "
                );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "Session",
                column: "ClaimDesc",
                value: "Özəlliyi İyerarxiyaya Bağlama");
        }
    }
}
