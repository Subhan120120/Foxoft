using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Foxoft.Migrations
{
    /// <inheritdoc />
    public partial class CalcPaymenLineExt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE OR ALTER TRIGGER [dbo].[CalcPaymenLineExt_INSERT]
                                    ON [dbo].[TrInvoiceLines]
                                    AFTER INSERT
                                    AS
                                    
                                    BEGIN
                                        INSERT INTO trInvoiceLineExts (InvoiceLineId, PriceDiscounted, PriceDiscountedLoc)
										   SELECT InvoiceLineId, Price * (1 - PosDiscount / 100), PriceLoc * (1 - PosDiscount / 100)
										   FROM inserted;
										   
										   -- Declare @invoiceheader to capture unique invoice header based on condition
										   Declare @invoiceheader uniqueidentifier = (SELECT TOP 1 
										                                                 CASE 
										                                                     WHEN ihEx.ProcessCode = 'EI' THEN ih.InvoiceHeaderId 
										                                                     WHEN ihEx.ProcessCode = 'RP' THEN ihEx.InvoiceHeaderId 
										                                                 END 
										                                              FROM inserted  
										                                              LEFT JOIN TrInvoiceHeaders ihEx ON ihEx.InvoiceHeaderId = inserted.InvoiceHeaderId
										                                              LEFT JOIN TrInvoiceHeaders ih ON ih.InvoiceHeaderId = ihEx.RelatedInvoiceId);
										
										   -- Calculate LineExpences for each relevant InvoiceLineId
										   UPDATE TrInvoiceLineExts
										   SET LineExpences = (SELECT SUM(NetAmountLoc)
										                       FROM TrInvoiceLines rl
										                       LEFT JOIN TrInvoiceHeaders rh ON rh.InvoiceHeaderId = rl.InvoiceHeaderId
										                       WHERE rh.ProcessCode = 'EI' AND RelatedInvoiceId = @invoiceheader)
										                       / (SELECT SUM(NetAmountLoc) 
										                          FROM TrInvoiceLines 
										                          WHERE TrInvoiceLines.InvoiceHeaderId = @invoiceheader) 
										                       * TrInvoiceLineExts.PriceDiscountedLoc
										   WHERE TrInvoiceLineExts.InvoiceLineId IN (SELECT DISTINCT InvoiceLineId 
										                                             FROM TrInvoiceLines 
										                                             WHERE InvoiceHeaderId = @invoiceheader);
                                    END");

            migrationBuilder.Sql(@"CREATE OR ALTER TRIGGER [dbo].[CalcPaymenLineExt_UPDATE]
                                    ON [dbo].[TrInvoiceLines]
                                    AFTER UPDATE
                                    AS
                                    
                                    BEGIN
                                            -- Update PriceDiscounted with correlated subquery
                                            UPDATE trInvoiceLineExts	
                                            SET PriceDiscountedLoc = (SELECT PriceLoc * (1 - PosDiscount / 100) FROM inserted WHERE inserted.InvoiceLineId = trInvoiceLineExts.InvoiceLineId)
                                            , PriceDiscounted = (SELECT Price * (1 - PosDiscount / 100) FROM inserted WHERE inserted.InvoiceLineId = trInvoiceLineExts.InvoiceLineId)
                                            WHERE InvoiceLineId IN (SELECT InvoiceLineId FROM inserted)

                                            -- Get the appropriate @invoiceheader
                                            DECLARE @invoiceheader uniqueidentifier = 
                                                (SELECT TOP 1 
                                                    CASE WHEN ihEx.ProcessCode = 'EI' THEN ih.InvoiceHeaderId 
                                                         WHEN ihEx.ProcessCode = 'RP' THEN ihEx.InvoiceHeaderId 
                                                    END 
                                                FROM inserted  
                                                LEFT JOIN TrInvoiceHeaders ihEx ON ihEx.InvoiceHeaderId = inserted.InvoiceHeaderId
                                                LEFT JOIN TrInvoiceHeaders ih ON ih.InvoiceHeaderId = ihEx.RelatedInvoiceId)

                                            -- Update LineExpences with correlated subquery
                                            UPDATE TrInvoiceLineExts
                                            SET LineExpences = 
                                                (SELECT SUM(NetAmountLoc)
                                                 FROM TrInvoiceLines rl 
                                                 LEFT JOIN TrInvoiceHeaders rh ON rh.InvoiceHeaderId = rl.InvoiceHeaderId
                                                 WHERE rh.ProcessCode = 'EI' AND RelatedInvoiceId = @invoiceheader)
                                                 / 
                                                 (SELECT SUM(NetAmountLoc) FROM TrInvoiceLines WHERE TrInvoiceLines.InvoiceHeaderId = @invoiceheader) 
                                                 * TrInvoiceLineExts.PriceDiscountedLoc
                                            WHERE TrInvoiceLineExts.InvoiceLineId IN 
                                                (SELECT InvoiceLineId FROM TrInvoiceLines WHERE InvoiceHeaderId = @invoiceheader)
                                    END");

            migrationBuilder.Sql(@"CREATE OR ALTER TRIGGER [dbo].[CalcPaymenLineExt_DELETE]
                                    ON [dbo].[TrInvoiceLines]
                                    AFTER DELETE
                                    AS
                                    
                                    BEGIN
                                    	DELETE FROM trInvoiceLineExts 
                                    	WHERE InvoiceLineId in (SELECT InvoiceLineId FROM deleted)
                                    
                                    	Declare @invoiceheader uniqueidentifier = (select top 1 case when ihEx.ProcessCode = 'EI' then ih.InvoiceHeaderId 
                                    															when ihEx.ProcessCode = 'RP' then ihEx.InvoiceHeaderId end 
                                    																from deleted  
                                    																left join TrInvoiceHeaders ihEx on ihEx.InvoiceHeaderId = deleted.InvoiceHeaderId
                                    																left join TrInvoiceHeaders ih on ih.InvoiceHeaderId = ihEx.RelatedInvoiceId)
                                    
                                    	UPDATE TrInvoiceLineExts
										SET LineExpences = 
										    (SELECT SUM(NetAmountLoc)
										     FROM TrInvoiceLines rl 
										     LEFT JOIN TrInvoiceHeaders rh ON rh.InvoiceHeaderId = rl.InvoiceHeaderId
										     WHERE rh.ProcessCode = 'EI' AND RelatedInvoiceId = @invoiceheader)
										     / 
										     (SELECT SUM(NetAmountLoc) FROM TrInvoiceLines WHERE TrInvoiceLines.InvoiceHeaderId = @invoiceheader) 
										     * TrInvoiceLineExts.PriceDiscountedLoc
										WHERE TrInvoiceLineExts.InvoiceLineId IN 
										    (SELECT InvoiceLineId FROM TrInvoiceLines WHERE InvoiceHeaderId = @invoiceheader)
										         				
                                    END
                                ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
