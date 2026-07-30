using Foxoft.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.Data;
using System.Data.Common;
using System.Globalization;

namespace Foxoft.AppCode.Service
{
    public sealed class NotificationInstallmentCheckerService
    {
        private static readonly string[] InstallmentDueTypeCodes =
        {
            NotificationTypeCodes.InstallmentDueSoon,
            NotificationTypeCodes.InstallmentDueToday
        };

        private readonly subContext _db;

        public NotificationInstallmentCheckerService(subContext db)
        {
            _db = db;
        }

        public async Task<int> ScanInstallmentPaymentNotificationsAsync(
            int daysBefore = 2,
            string? actorCurrAccCode = null,
            CancellationToken ct = default)
        {
            DateTime scanStartedAt = DateTime.Now;
            DateTime today = DateTime.Today;
            DateTime dueSoonDate = today.AddDays(Math.Max(0, daysBefore));
            List<InstallmentDueRow> dueRows = await ReadDueRowsAsync(dueSoonDate, today, ct);

            NotificationService notificationService = new(_db);
            HashSet<string> activeKeys = new(StringComparer.OrdinalIgnoreCase);
            int affectedCount = 0;

            foreach (InstallmentDueRow row in dueRows)
            {
                int day = (row.DueDate.Date - today).Days;
                string notificationTypeCode;

                if (day == 0)
                {
                    notificationTypeCode = NotificationTypeCodes.InstallmentDueToday;
                }
                else if (day == daysBefore && daysBefore > 0)
                {
                    notificationTypeCode = NotificationTypeCodes.InstallmentDueSoon;
                }
                else
                {
                    continue;
                }

                string notificationKey = BuildNotificationKey(notificationTypeCode, row.InstallmentId, row.DueDate);
                Notification? notification = await notificationService.CreateOrUpdateAsync(
                    new NotificationCreateRequest(
                        NotificationTypeCode: notificationTypeCode,
                        NotificationKey: notificationKey,
                        Severity: NotificationSeverities.Warning,
                        EntityType: NotificationEntityTypes.Invoice,
                        EntityKey: row.InvoiceHeaderId.ToString(),
                        StoreCode: row.StoreCode,
                        Placeholders: BuildPlaceholders(row, day),
                        ExpireDate: row.DueDate.Date.AddDays(1),
                        ChannelReceivers: BuildChannelReceivers(row)),
                    ct);

                if (notification != null)
                {
                    activeKeys.Add(notificationKey);
                    affectedCount++;
                }
            }

            await notificationService.ResolveInactiveKeysAsync(
                activeKeys,
                InstallmentDueTypeCodes,
                actorCurrAccCode,
                ct,
                maxLastRaisedDate: scanStartedAt);

            return affectedCount;
        }

        private async Task<List<InstallmentDueRow>> ReadDueRowsAsync(DateTime dueSoonDate, DateTime dueTodayDate, CancellationToken ct)
        {
            List<InstallmentDueRow> rows = new();
            DbConnection connection = _db.Database.GetDbConnection();
            bool shouldCloseConnection = connection.State != ConnectionState.Open;

            if (shouldCloseConnection)
                await connection.OpenAsync(ct);

            try
            {
                await using DbCommand command = connection.CreateCommand();
                command.CommandText = DueRowsSql;
                command.CommandType = CommandType.Text;

                if (_db.Database.CurrentTransaction != null)
                    command.Transaction = _db.Database.CurrentTransaction.GetDbTransaction();

                AddDateParameter(command, "@DueSoonDate", dueSoonDate);
                AddDateParameter(command, "@DueTodayDate", dueTodayDate);

                await using DbDataReader reader = await command.ExecuteReaderAsync(ct);
                while (await reader.ReadAsync(ct))
                    rows.Add(ReadDueRow(reader));
            }
            finally
            {
                if (shouldCloseConnection)
                    await connection.CloseAsync();
            }

            return rows;
        }

        private static void AddDateParameter(DbCommand command, string name, DateTime value)
        {
            DbParameter parameter = command.CreateParameter();
            parameter.ParameterName = name;
            parameter.DbType = DbType.Date;
            parameter.Value = value.Date;
            command.Parameters.Add(parameter);
        }

        private static InstallmentDueRow ReadDueRow(DbDataReader reader)
        {
            return new InstallmentDueRow(
                InstallmentId: Convert.ToInt32(reader["InstallmentId"], CultureInfo.InvariantCulture),
                InvoiceHeaderId: (Guid)reader["InvoiceHeaderId"],
                CurrAccCode: GetString(reader, "CurrAccCode"),
                CurrAccDesc: GetString(reader, "CurrAccDesc"),
                PhoneNum: GetString(reader, "PhoneNum"),
                StoreCode: GetString(reader, "StoreCode"),
                StoreDesc: GetString(reader, "StoreDesc"),
                StorePhone: GetString(reader, "StorePhone"),
                DocumentNumber: GetString(reader, "DocumentNumber"),
                DueDate: Convert.ToDateTime(reader["DueDate"], CultureInfo.InvariantCulture),
                MonthlyPayment: Convert.ToDecimal(reader["MonthlyPayment"], CultureInfo.InvariantCulture),
                RemainingBalance: Convert.ToDecimal(reader["RemainingBalance"], CultureInfo.InvariantCulture));
        }

        private static string GetString(DbDataReader reader, string columnName)
        {
            object value = reader[columnName];
            return value == DBNull.Value ? string.Empty : Convert.ToString(value, CultureInfo.InvariantCulture) ?? string.Empty;
        }

        private static Dictionary<string, string> BuildPlaceholders(InstallmentDueRow row, int day)
        {
            return new Dictionary<string, string>
            {
                ["day"] = day.ToString(CultureInfo.InvariantCulture),
                ["CurrAccCode"] = row.CurrAccCode,
                ["CurrAccDesc"] = row.CurrAccDesc,
                ["StoreCode"] = row.StoreCode,
                ["StoreDesc"] = string.IsNullOrWhiteSpace(row.StoreDesc) ? row.StoreCode : row.StoreDesc,
                ["StorePhone"] = row.StorePhone,
                ["DocumentNumber"] = row.DocumentNumber,
                ["DueDate"] = row.DueDate.ToString("d", CultureInfo.CurrentCulture),
                ["MonthlyPayment"] = row.MonthlyPayment.ToString("N2", CultureInfo.CurrentCulture),
                ["RemainingBalance"] = row.RemainingBalance.ToString("N2", CultureInfo.CurrentCulture)
            };
        }

        private static IReadOnlyCollection<NotificationChannelReceiver>? BuildChannelReceivers(InstallmentDueRow row)
        {
            string phoneNum = NormalizePhoneNumber(row.PhoneNum);
            if (string.IsNullOrWhiteSpace(phoneNum))
                return null;

            return new[]
            {
                new NotificationChannelReceiver(NotificationChannels.WhatsApp, phoneNum, BodyOnly: true)
            };
        }

        private static string NormalizePhoneNumber(string phoneNum)
            => string.IsNullOrWhiteSpace(phoneNum)
                ? string.Empty
                : phoneNum.Trim().Replace("+", string.Empty).Replace(" ", string.Empty);

        private static string BuildNotificationKey(string notificationTypeCode, int installmentId, DateTime dueDate)
            => $"{notificationTypeCode}:Installment:{installmentId}:DueDate:{dueDate:yyyyMMdd}";

        private const string DueRowsSql = @"
;WITH InstallmentPaymentSum AS (
    SELECT
        InvoiceHeaderId = ph.InvoiceHeaderId,
        CurrAccCode = ph.CurrAccCode,
        InstallmentPaymentSum = SUM(pl.PaymentLoc)
    FROM TrPaymentLines pl
    JOIN TrPaymentHeaders ph ON pl.PaymentHeaderId = ph.PaymentHeaderId
    JOIN TrInstallments i ON ph.InvoiceHeaderId = i.InvoiceHeaderId
    WHERE ph.PaymentKindId = 3
    GROUP BY ph.InvoiceHeaderId, ph.CurrAccCode
),
DownPaymentSum AS (
    SELECT
        InvoiceHeaderId = i.InvoiceHeaderId,
        DownPaymentSum = SUM(pl.PaymentLoc)
    FROM TrInstallments i
    JOIN TrInvoiceHeaders ih ON ih.InvoiceHeaderId = i.InvoiceHeaderId
    JOIN TrPaymentHeaders ph ON ih.InvoiceHeaderId = ph.InvoiceHeaderId AND ih.CurrAccCode = ph.CurrAccCode
    JOIN TrPaymentLines pl ON ph.PaymentHeaderId = pl.PaymentHeaderId
    WHERE ph.PaymentKindId != 3
    GROUP BY i.InvoiceHeaderId
),
InstallmentData AS (
    SELECT
        InstallmentId = i.InstallmentId,
        InvoiceHeaderId = i.InvoiceHeaderId,
        InstallmentDate = i.InstallmentDate,
        DocumentNumber = ih.DocumentNumber,
        StoreCode = ih.StoreCode,
        StoreDesc = store.CurrAccDesc,
        StorePhone = store.PhoneNum,
        CurrAccCode = ih.CurrAccCode,
        CurrAccDesc = ca.CurrAccDesc,
        PhoneNum = ca.PhoneNum,
        AmountLoc = SUM(il.NetAmountLoc) + COALESCE(SUM(ril.NetAmountLoc), 0),
        InstallmentAmount = (SUM(il.NetAmountLoc) + i.Commission) + COALESCE(SUM(ril.NetAmountLoc), 0) - COALESCE(dps.DownPaymentSum, 0),
        DurationInMonths = ip.DurationInMonths,
        InstallmentPaid = COALESCE(psum.InstallmentPaymentSum, 0),
        DownPayment = COALESCE(dps.DownPaymentSum, 0)
    FROM TrInstallments i
    JOIN TrInvoiceHeaders ih ON i.InvoiceHeaderId = ih.InvoiceHeaderId
    LEFT JOIN TrInvoiceLines il ON il.InvoiceHeaderId = ih.InvoiceHeaderId
    JOIN DcCurrAccs ca ON ih.CurrAccCode = ca.CurrAccCode
    LEFT JOIN DcCurrAccs store ON ih.StoreCode = store.CurrAccCode
    JOIN DcInstallmentPlan ip ON i.InstallmentPlanCode = ip.InstallmentPlanCode
    LEFT JOIN InstallmentPaymentSum psum ON i.InvoiceHeaderId = psum.InvoiceHeaderId AND ih.CurrAccCode = psum.CurrAccCode
    LEFT JOIN DownPaymentSum dps ON i.InvoiceHeaderId = dps.InvoiceHeaderId
    LEFT JOIN TrInvoiceHeaders rih ON rih.RelatedInvoiceId = i.InvoiceHeaderId AND rih.IsReturn = 1
    LEFT JOIN TrInvoiceLines ril ON ril.InvoiceHeaderId = rih.InvoiceHeaderId AND ril.RelatedLineId = il.InvoiceLineId
    WHERE ih.IsReturn = 0
    GROUP BY
        i.InstallmentId,
        i.InvoiceHeaderId,
        i.InstallmentDate,
        ih.DocumentNumber,
        ih.StoreCode,
        store.CurrAccDesc,
        store.PhoneNum,
        ih.CurrAccCode,
        ca.CurrAccDesc,
        ca.PhoneNum,
        ip.DurationInMonths,
        i.Commission,
        psum.InstallmentPaymentSum,
        dps.DownPaymentSum
),
DueData AS (
    SELECT
        InstallmentId = id.InstallmentId,
        InvoiceHeaderId = id.InvoiceHeaderId,
        CurrAccCode = id.CurrAccCode,
        CurrAccDesc = id.CurrAccDesc,
        PhoneNum = id.PhoneNum,
        StoreCode = id.StoreCode,
        StoreDesc = id.StoreDesc,
        StorePhone = id.StorePhone,
        DocumentNumber = id.DocumentNumber,
        MonthlyPayment = mp.MonthlyPayment,
        RemainingBalance = COALESCE(id.InstallmentAmount, 0) - COALESCE(id.InstallmentPaid, 0),
        DueDate = dd.DueDate
    FROM InstallmentData id
    OUTER APPLY (
        SELECT MonthlyPayment = CASE
            WHEN NULLIF(id.DurationInMonths, 0) IS NULL OR COALESCE(id.InstallmentAmount, 0) = 0 THEN 0.0
            ELSE COALESCE(id.InstallmentAmount, 0) * 1.0 / NULLIF(id.DurationInMonths, 0)
        END
    ) mp
    OUTER APPLY (
        SELECT RawPassed = DATEDIFF(MONTH, id.InstallmentDate, CAST(GETDATE() AS date))
    ) rp
    OUTER APPLY (
        SELECT PassedMonth = CASE
            WHEN rp.RawPassed < 0 THEN 0
            WHEN rp.RawPassed > COALESCE(id.DurationInMonths, 0) THEN COALESCE(id.DurationInMonths, 0)
            ELSE rp.RawPassed
        END
    ) pm
    OUTER APPLY (
        SELECT PaidMonth = CASE
            WHEN mp.MonthlyPayment <= 0 THEN 0
            ELSE CASE
                WHEN FLOOR(COALESCE(id.InstallmentPaid, 0) * 1.0 / mp.MonthlyPayment) > COALESCE(id.DurationInMonths, 0)
                    THEN COALESCE(id.DurationInMonths, 0)
                ELSE FLOOR(COALESCE(id.InstallmentPaid, 0) * 1.0 / mp.MonthlyPayment)
            END
        END
    ) p2
    OUTER APPLY (
        SELECT DueDate = CASE
            WHEN COALESCE(id.InstallmentAmount, 0) - COALESCE(id.InstallmentPaid, 0) <= 0 THEN NULL
            ELSE DATEADD(MONTH, p2.PaidMonth + 1, id.InstallmentDate)
        END
    ) dd
)
SELECT
    InstallmentId,
    InvoiceHeaderId,
    CurrAccCode,
    CurrAccDesc,
    PhoneNum,
    StoreCode,
    StoreDesc,
    StorePhone,
    DocumentNumber,
    DueDate,
    MonthlyPayment,
    RemainingBalance
FROM DueData
WHERE RemainingBalance > 0
  AND DueDate IS NOT NULL
  AND CAST(DueDate AS date) IN (@DueSoonDate, @DueTodayDate)
  AND NULLIF(PhoneNum, N'') IS NOT NULL;";

        private sealed record InstallmentDueRow(
            int InstallmentId,
            Guid InvoiceHeaderId,
            string CurrAccCode,
            string CurrAccDesc,
            string PhoneNum,
            string StoreCode,
            string StoreDesc,
            string StorePhone,
            string DocumentNumber,
            DateTime DueDate,
            decimal MonthlyPayment,
            decimal RemainingBalance);
    }
}
