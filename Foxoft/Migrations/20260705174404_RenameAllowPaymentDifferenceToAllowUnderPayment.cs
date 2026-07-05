using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Foxoft.Migrations
{
    /// <inheritdoc />
    public partial class RenameAllowPaymentDifferenceToAllowUnderPayment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
IF EXISTS (SELECT 1 FROM DcClaims WHERE ClaimCode = N'AllowPaymentDifference')
    AND NOT EXISTS (SELECT 1 FROM DcClaims WHERE ClaimCode = N'AllowUnderPayment')
BEGIN
    INSERT INTO DcClaims (ClaimCode, ClaimDesc, ClaimTypeId, CategoryId)
    SELECT N'AllowUnderPayment', ClaimDesc, ClaimTypeId, CategoryId
    FROM DcClaims
    WHERE ClaimCode = N'AllowPaymentDifference';
END;

IF NOT EXISTS (SELECT 1 FROM DcClaims WHERE ClaimCode = N'AllowUnderPayment')
BEGIN
    INSERT INTO DcClaims (ClaimCode, ClaimDesc, ClaimTypeId, CategoryId)
    VALUES (N'AllowUnderPayment', N'Faktura ilə ödəniş arasında fərqə icazə', CAST(1 AS tinyint), 2);
END;

UPDATE TrRoleClaims
SET ClaimCode = N'AllowUnderPayment'
WHERE ClaimCode = N'AllowPaymentDifference';

UPDATE TrClaimReports
SET ClaimCode = N'AllowUnderPayment'
WHERE ClaimCode = N'AllowPaymentDifference';

DELETE FROM DcClaims
WHERE ClaimCode = N'AllowPaymentDifference';
");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
IF EXISTS (SELECT 1 FROM DcClaims WHERE ClaimCode = N'AllowUnderPayment')
    AND NOT EXISTS (SELECT 1 FROM DcClaims WHERE ClaimCode = N'AllowPaymentDifference')
BEGIN
    INSERT INTO DcClaims (ClaimCode, ClaimDesc, ClaimTypeId, CategoryId)
    SELECT N'AllowPaymentDifference', ClaimDesc, ClaimTypeId, CategoryId
    FROM DcClaims
    WHERE ClaimCode = N'AllowUnderPayment';
END;

IF NOT EXISTS (SELECT 1 FROM DcClaims WHERE ClaimCode = N'AllowPaymentDifference')
BEGIN
    INSERT INTO DcClaims (ClaimCode, ClaimDesc, ClaimTypeId, CategoryId)
    VALUES (N'AllowPaymentDifference', N'Faktura ilə ödəniş arasında fərqə icazə', CAST(1 AS tinyint), 2);
END;

UPDATE TrRoleClaims
SET ClaimCode = N'AllowPaymentDifference'
WHERE ClaimCode = N'AllowUnderPayment';

UPDATE TrClaimReports
SET ClaimCode = N'AllowPaymentDifference'
WHERE ClaimCode = N'AllowUnderPayment';

DELETE FROM DcClaims
WHERE ClaimCode = N'AllowUnderPayment';
");
        }
    }
}
