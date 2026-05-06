using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Foxoft.Migrations
{
    /// <inheritdoc />
    public partial class asdasddv : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "DcClaims",
                columns: new[] { "ClaimCode", "CategoryId", "ClaimDesc", "ClaimTypeId" },
                values: new object[,]
                {
                    { "PaymentMethodList", 15, "Ödəniş Üsulları Siyahısı", (byte)1 },
                    { "PaymentPlanList", 15, "Ödəniş Planları Siyahısı", (byte)1 }
                });

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TrRoleClaims",
                keyColumn: "RoleClaimId",
                keyValue: 67);

            migrationBuilder.DeleteData(
                table: "TrRoleClaims",
                keyColumn: "RoleClaimId",
                keyValue: 68);

            migrationBuilder.DeleteData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "PaymentMethodList");

            migrationBuilder.DeleteData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "PaymentPlanList");

            migrationBuilder.UpdateData(
                table: "DcReports",
                keyColumn: "ReportId",
                keyValue: 6,
                column: "ReportQuery",
                value: ";WITH InstallmentPaymentSum AS (\r\n    SELECT\r\n        ph.InvoiceHeaderId,\r\n        ph.CurrAccCode,\r\n        SUM(pl.PaymentLoc) AS InstallmentPaymentSum\r\n    FROM TrPaymentLines pl\r\n    JOIN TrPaymentHeaders ph ON pl.PaymentHeaderId = ph.PaymentHeaderId\r\n    JOIN TrInstallments i ON ph.InvoiceHeaderId = i.InvoiceHeaderId\r\n    WHERE ph.PaymentKindId = 3\r\n    GROUP BY ph.InvoiceHeaderId, ph.CurrAccCode\r\n),\r\nDownPaymentSum AS (\r\n    SELECT\r\n        i.InvoiceHeaderId,\r\n        SUM(pl.PaymentLoc) AS DownPaymentSum\r\n    FROM TrInstallments i\r\n    JOIN TrInvoiceHeaders ih ON ih.InvoiceHeaderId = i.InvoiceHeaderId\r\n    JOIN TrPaymentHeaders ph ON ih.InvoiceHeaderId = ph.InvoiceHeaderId\r\n                             AND ih.CurrAccCode     = ph.CurrAccCode\r\n    JOIN TrPaymentLines pl   ON ph.PaymentHeaderId  = pl.PaymentHeaderId\r\n    WHERE ph.PaymentKindId != 3\r\n    GROUP BY i.InvoiceHeaderId\r\n),\r\nInstallmentData AS (\r\n    SELECT\r\n        i.InstallmentId,\r\n        i.InvoiceHeaderId,\r\n        i.InstallmentDate,\r\n        SUM(il.NetAmountLoc) + COALESCE(SUM(ril.NetAmountLoc), 0)                                AS AmountLoc,\r\n        (SUM(il.NetAmountLoc) + i.Commission) + COALESCE(SUM(ril.NetAmountLoc), 0)               AS AmountWithComLoc,\r\n        (SUM(il.NetAmountLoc) + i.Commission) + COALESCE(SUM(ril.NetAmountLoc), 0)\r\n          - COALESCE(dps.DownPaymentSum, 0)                                                      AS InstallmentAmount,\r\n        ih.DocumentNumber,\r\n        ca.CurrAccDesc,\r\n        ca.PhoneNum,\r\n        ip.DurationInMonths,\r\n        COALESCE(psum.InstallmentPaymentSum, 0)                                                  AS InstallmentPaid,\r\n        COALESCE(dps.DownPaymentSum, 0)                                                          AS DownPayment\r\n    FROM TrInstallments i\r\n    JOIN TrInvoiceHeaders ih    ON i.InvoiceHeaderId = ih.InvoiceHeaderId\r\n    LEFT JOIN TrInvoiceLines il ON il.InvoiceHeaderId = ih.InvoiceHeaderId\r\n    JOIN DcCurrAccs ca          ON ih.CurrAccCode = ca.CurrAccCode\r\n    JOIN DcInstallmentPlan ip   ON i.InstallmentPlanCode = ip.InstallmentPlanCode\r\n    LEFT JOIN InstallmentPaymentSum psum ON i.InvoiceHeaderId = psum.InvoiceHeaderId\r\n                                         AND ih.CurrAccCode     = psum.CurrAccCode\r\n    LEFT JOIN DownPaymentSum dps ON i.InvoiceHeaderId = dps.InvoiceHeaderId\r\n    LEFT JOIN TrInvoiceHeaders rih ON rih.RelatedInvoiceId = i.InvoiceHeaderId AND rih.IsReturn = 1\r\n    LEFT JOIN TrInvoiceLines ril   ON ril.InvoiceHeaderId  = rih.InvoiceHeaderId\r\n                                   AND ril.RelatedLineId   = il.InvoiceLineId\r\n    GROUP BY\r\n        i.InstallmentId, i.InvoiceHeaderId, i.InstallmentDate,\r\n        ih.DocumentNumber, ca.CurrAccDesc, ca.PhoneNum,\r\n        ip.DurationInMonths, i.Commission, psum.InstallmentPaymentSum, dps.DownPaymentSum\r\n)\r\nSELECT\r\n    id.InstallmentId,\r\n    id.InvoiceHeaderId,\r\n    id.DocumentNumber,\r\n    id.CurrAccDesc,\r\n    id.PhoneNum,\r\n	id.InstallmentDate,\r\n    [Kredit Məbləği]     = id.InstallmentAmount,\r\n    [Müddət Ay]          = id.DurationInMonths,\r\n    [Ödənilmiş Məbləğ]   = id.InstallmentPaid,\r\n\r\n    [Qalıq] = CASE\r\n        WHEN COALESCE(id.InstallmentAmount,0) - COALESCE(id.InstallmentPaid,0) < 0 THEN 0\r\n        ELSE COALESCE(id.InstallmentAmount,0) - COALESCE(id.InstallmentPaid,0)\r\n    END,\r\n\r\n    [Aylıq Ödəniş]   = mp.MonthlyPayment,\r\n\r\n    [Keçən Aylar]    = pm.PassedMonth,\r\n\r\n    [Ödənilmiş Ay]   = p2.PaidMonth,\r\n\r\n    [Gecikən Məbləğ] = CASE\r\n        WHEN pm.PassedMonth * mp.MonthlyPayment - COALESCE(id.InstallmentPaid,0) < 0 THEN 0\r\n        ELSE pm.PassedMonth * mp.MonthlyPayment - COALESCE(id.InstallmentPaid,0)\r\n    END,\r\n\r\n    [Gecikmə Tarixi] = dd.DueDate,\r\n\r\n    [Gecikmiş Günlər] = od.OverDueDays\r\n\r\nFROM InstallmentData id\r\nOUTER APPLY (\r\n    SELECT MonthlyPayment =\r\n        CASE\r\n            WHEN NULLIF(id.DurationInMonths, 0) IS NULL OR COALESCE(id.InstallmentAmount,0) = 0 THEN 0.0\r\n            ELSE COALESCE(id.InstallmentAmount,0) * 1.0 / NULLIF(id.DurationInMonths, 0)\r\n        END\r\n) mp\r\nOUTER APPLY (\r\n    SELECT RawPassed =\r\n        DATEDIFF(MONTH, id.InstallmentDate, CAST(GETDATE() AS date))\r\n) rp\r\nOUTER APPLY (\r\n    SELECT PassedMonth =\r\n        CASE\r\n            WHEN rp.RawPassed < 0 THEN 0\r\n            WHEN rp.RawPassed > COALESCE(id.DurationInMonths, 0) THEN COALESCE(id.DurationInMonths, 0)\r\n            ELSE rp.RawPassed\r\n        END\r\n) pm\r\nOUTER APPLY (\r\n\r\n    SELECT PaidMonth =\r\n        CASE\r\n            WHEN mp.MonthlyPayment <= 0 THEN 0\r\n            ELSE\r\n                CASE\r\n                    WHEN FLOOR(COALESCE(id.InstallmentPaid,0) * 1.0 / mp.MonthlyPayment) > COALESCE(id.DurationInMonths,0)\r\n                        THEN COALESCE(id.DurationInMonths,0)\r\n                    ELSE FLOOR(COALESCE(id.InstallmentPaid,0) * 1.0 / mp.MonthlyPayment)\r\n                END\r\n        END\r\n) p2\r\nOUTER APPLY (\r\n\r\n    SELECT DueDate =\r\n        CASE\r\n            WHEN COALESCE(id.InstallmentAmount,0) - COALESCE(id.InstallmentPaid,0) <= 0 THEN NULL\r\n            ELSE DATEADD(MONTH, p2.PaidMonth + 1, id.InstallmentDate)\r\n        END\r\n) dd\r\nOUTER APPLY (\r\n    SELECT OverDueDays =\r\n        CASE\r\n            WHEN COALESCE(id.InstallmentAmount,0) - COALESCE(id.InstallmentPaid,0) <= 0 OR dd.DueDate IS NULL THEN 0\r\n            WHEN CAST(GETDATE() AS date) <= CAST(dd.DueDate AS date) THEN 0\r\n            ELSE DATEDIFF(DAY, CAST(dd.DueDate AS date), CAST(GETDATE() AS date))\r\n        END\r\n) od;\r\n");
        }
    }
}
