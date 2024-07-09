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
                                        INSERT INTO trInvoiceLineExts (InvoiceLineId, PriceDiscounted) (SELECT InvoiceLineId, PriceLoc * (100 - PosDiscount) / 100  FROM inserted)
                                    
                                    	Declare @invoiceheader uniqueidentifier = (select top 1 case when ihEx.ProcessCode = 'EX' then ih.InvoiceHeaderId 
                                    															when ihEx.ProcessCode = 'RP' then ihEx.InvoiceHeaderId end 
                                    																from inserted  
                                    																left join TrInvoiceHeaders ihEx on ihEx.InvoiceHeaderId = inserted.InvoiceHeaderId
                                    																left join TrInvoiceHeaders ih on ih.InvoiceHeaderId = ihEx.RelatedInvoiceId)
                                    
                                    	UPDATE TrInvoiceLineExts
                                    	set LineExpences = (select sum(NetAmountLoc)
                                    						from TrInvoiceLines  rl 
                                    						left join TrInvoiceHeaders rh on rh.InvoiceHeaderId = rl.InvoiceHeaderId
                                    						where rh.ProcessCode = 'EX' and RelatedInvoiceId = @invoiceheader)
                                    						/ (select sum(NetAmountLoc) from TrInvoiceLines where TrInvoiceLines.InvoiceHeaderId = @invoiceheader) * TrInvoiceLineExts.PriceDiscounted
                                    						From inserted
                                    						WHERE TrInvoiceLineExts.InvoiceLineId in (select InvoiceLineId from TrInvoiceLines where InvoiceHeaderId = @invoiceheader)
                                    
                                    END");

            migrationBuilder.Sql(@"CREATE OR ALTER TRIGGER [dbo].[CalcPaymenLineExt_UPDATE]
                                    ON [dbo].[TrInvoiceLines]
                                    AFTER UPDATE
                                    AS
                                    
                                    BEGIN
                                    	UPDATE trInvoiceLineExts	SET PriceDiscounted = (SELECT PriceLoc * (100 - PosDiscount) / 100  FROM inserted) 
                                    	WHERE InvoiceLineId in (SELECT InvoiceLineId FROM inserted)
                                    
                                    	Declare @invoiceheader uniqueidentifier = (select top 1 case when ihEx.ProcessCode = 'EX' then ih.InvoiceHeaderId 
                                    															when ihEx.ProcessCode = 'RP' then ihEx.InvoiceHeaderId end 
                                    																from inserted  
                                    																left join TrInvoiceHeaders ihEx on ihEx.InvoiceHeaderId = inserted.InvoiceHeaderId
                                    																left join TrInvoiceHeaders ih on ih.InvoiceHeaderId = ihEx.RelatedInvoiceId)
                                    
                                    	UPDATE TrInvoiceLineExts
                                    	set LineExpences = (select sum(NetAmountLoc)
                                    						from TrInvoiceLines  rl 
                                    						left join TrInvoiceHeaders rh on rh.InvoiceHeaderId = rl.InvoiceHeaderId
                                    						where rh.ProcessCode = 'EX' and RelatedInvoiceId = @invoiceheader)
                                    						/ (select sum(NetAmountLoc) from TrInvoiceLines where TrInvoiceLines.InvoiceHeaderId = @invoiceheader) * TrInvoiceLineExts.PriceDiscounted
                                    						From inserted
                                    						WHERE TrInvoiceLineExts.InvoiceLineId in (select InvoiceLineId from TrInvoiceLines where InvoiceHeaderId = @invoiceheader)
                                    END");

            migrationBuilder.Sql(@"CREATE OR ALTER TRIGGER [dbo].[CalcPaymenLineExt_DELETE]
                                    ON [dbo].[TrInvoiceLines]
                                    AFTER DELETE
                                    AS
                                    
                                    BEGIN
                                    	DELETE FROM trInvoiceLineExts 
                                    	WHERE InvoiceLineId in (SELECT InvoiceLineId FROM deleted)
                                    
                                    	Declare @invoiceheader uniqueidentifier = (select top 1 case when ihEx.ProcessCode = 'EX' then ih.InvoiceHeaderId 
                                    															when ihEx.ProcessCode = 'RP' then ihEx.InvoiceHeaderId end 
                                    																from deleted  
                                    																left join TrInvoiceHeaders ihEx on ihEx.InvoiceHeaderId = deleted.InvoiceHeaderId
                                    																left join TrInvoiceHeaders ih on ih.InvoiceHeaderId = ihEx.RelatedInvoiceId)
                                    
                                    	UPDATE TrInvoiceLineExts
                                    	set LineExpences = (select sum(NetAmountLoc)
                                    						from TrInvoiceLines  rl 
                                    						left join TrInvoiceHeaders rh on rh.InvoiceHeaderId = rl.InvoiceHeaderId
                                    						where rh.ProcessCode = 'EX' and RelatedInvoiceId = @invoiceheader)
                                    						/ (select sum(NetAmountLoc) from TrInvoiceLines where TrInvoiceLines.InvoiceHeaderId = @invoiceheader) * TrInvoiceLineExts.PriceDiscounted
                                    						From deleted
                                    						WHERE TrInvoiceLineExts.InvoiceLineId in (select InvoiceLineId from TrInvoiceLines where InvoiceHeaderId = @invoiceheader)
                                    				
                                    END
                                ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
