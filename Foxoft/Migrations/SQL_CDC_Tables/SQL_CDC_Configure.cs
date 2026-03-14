using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Foxoft.Migrations
{
    /// <inheritdoc />
    public partial class SQL_CDC_Configure : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"

                                    EXEC sys.sp_cdc_enable_db;

                                    EXEC sys.sp_cdc_enable_table
                                    @source_schema = 'dbo',
                                    @source_name   = 'TrInvoiceHeaders',
                                    @role_name     = NULL
                                    
                                    EXEC sys.sp_cdc_enable_table
                                    @source_schema = 'dbo',
                                    @source_name   = 'TrInvoiceLines',
                                    @role_name     = NULL
                                    
                                    EXEC sys.sp_cdc_enable_table
                                    @source_schema = 'dbo',
                                    @source_name   = 'TrPaymentHeaders',
                                    @role_name     = NULL
                                    
                                    EXEC sys.sp_cdc_enable_table
                                    @source_schema = 'dbo',
                                    @source_name   = 'TrPaymentLines',
                                    @role_name     = NULL
                                    
                                    EXEC sys.sp_cdc_enable_table
                                    @source_schema = 'dbo',
                                    @source_name   = 'TrInstallments',
                                    @role_name     = NULL
                                    
                                    EXEC sys.sp_cdc_enable_table
                                    @source_schema = 'dbo',
                                    @source_name   = 'TrInstallmentGuarantors',
                                    @role_name     = NULL
                                    
                                    EXEC sys.sp_cdc_enable_table
                                    @source_schema = 'dbo',
                                    @source_name   = 'DcCurrAccs',
                                    @role_name     = NULL
                                    
                                    EXEC sys.sp_cdc_enable_table
                                    @source_schema = 'dbo',
                                    @source_name   = 'DcProducts',
                                    @role_name     = NULL
                                    
                                    EXEC sys.sp_cdc_enable_table
                                    @source_schema = 'dbo',
                                    @source_name   = 'TrLoyaltyTxns',
                                    @role_name     = NULL

                                    EXEC sys.sp_cdc_change_job
                                    @job_type = 'cleanup',
                                    @retention = 10080 -- 7 days in minutes
									
									");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
