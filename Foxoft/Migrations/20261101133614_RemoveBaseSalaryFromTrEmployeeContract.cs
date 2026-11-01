using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Foxoft.Migrations
{
    /// <inheritdoc />
    public partial class RemoveBaseSalaryFromTrEmployeeContract : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Data migration: Copy existing contract salaries into TrEmployeeContractAddenda as initial terms before dropping columns
            migrationBuilder.Sql(@"
                INSERT INTO TrEmployeeContractAddenda (Id, ContractId, AddendumNumber, StartDate, EndDate, BaseSalary, CurrencyCode, Description)
                SELECT 
                    NEWID(),
                    c.Id,
                    N'" + "\u0130lkin \u015E\u0259rtl\u0259r" + @"',
                    c.StartDate,
                    c.EndDate,
                    ISNULL(c.BaseSalary, 0),
                    ISNULL(c.CurrencyCode, 'AZN'),
                    N'" + "\u0130lkin m\u00FCqavil\u0259 \u0259m\u0259khaqq\u0131 \u015F\u0259rti" + @"'
                FROM TrEmployeeContracts c
                WHERE NOT EXISTS (
                    SELECT 1 
                    FROM TrEmployeeContractAddenda a 
                    WHERE a.ContractId = c.Id
                );
            ");

            migrationBuilder.DropColumn(
                name: "BaseSalary",
                table: "TrEmployeeContracts");

            migrationBuilder.DropColumn(
                name: "CurrencyCode",
                table: "TrEmployeeContracts");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "BaseSalary",
                table: "TrEmployeeContracts",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "CurrencyCode",
                table: "TrEmployeeContracts",
                type: "nvarchar(3)",
                maxLength: 3,
                nullable: true);

            // Reverse data migration: Restore BaseSalary and CurrencyCode from the latest addendum back into TrEmployeeContracts
            migrationBuilder.Sql(@"
                UPDATE c
                SET c.BaseSalary = a.BaseSalary,
                    c.CurrencyCode = a.CurrencyCode
                FROM TrEmployeeContracts c
                CROSS APPLY (
                    SELECT TOP 1 a.BaseSalary, a.CurrencyCode
                    FROM TrEmployeeContractAddenda a
                    WHERE a.ContractId = c.Id
                    ORDER BY a.StartDate DESC
                ) a;
            ");
        }
    }
}
