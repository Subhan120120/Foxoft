namespace Foxoft.Models
{
    public static class NotificationTypeCodes
    {
        public const string ProductStockWarning = "ProductStockWarning";
        public const string ProductOutOfStock = "ProductOutOfStock";
        public const string NegativeStock = "NegativeStock";
        public const string OverStock = "OverStock";
        public const string ExpiredProduct = "ExpiredProduct";
        public const string ProductExpireSoon = "ProductExpireSoon";
        public const string SerialImeiMissing = "SerialImeiMissing";
        public const string StockTransferPending = "StockTransferPending";
        public const string StockTransferRejected = "StockTransferRejected";
        public const string InventoryDifference = "InventoryDifference";
        public const string SaleBelowMinimumPrice = "SaleBelowMinimumPrice";
        public const string DiscountApprovalRequired = "DiscountApprovalRequired";
        public const string InvoiceNotPosted = "InvoiceNotPosted";
        public const string CustomerCreditLimitExceeded = "CustomerCreditLimitExceeded";
        public const string LargeSaleCreated = "LargeSaleCreated";
        public const string ReturnCreated = "ReturnCreated";
        public const string PurchaseOrderPending = "PurchaseOrderPending";
        public const string SupplierDebtDue = "SupplierDebtDue";
        public const string PurchasePriceChanged = "PurchasePriceChanged";
        public const string SupplierInvoiceMissing = "SupplierInvoiceMissing";
        public const string CashBalanceWarning = "CashBalanceWarning";
        public const string PaymentNotConfirmed = "PaymentNotConfirmed";
        public const string BankPaymentImported = "BankPaymentImported";
        public const string CashboxClosingMissing = "CashboxClosingMissing";
        public const string PaymentDifference = "PaymentDifference";
        public const string InstallmentDueSoon = "InstallmentDueSoon";
        public const string InstallmentDueToday = "InstallmentDueToday";
        public const string InstallmentOverdue = "InstallmentOverdue";
        public const string InstallmentPaid = "InstallmentPaid";
        public const string CreditClosed = "CreditClosed";
        public const string CustomerDebtIncreased = "CustomerDebtIncreased";
        public const string CustomerBirthday = "CustomerBirthday";
        public const string CustomerInactive = "CustomerInactive";
        public const string VipCustomerSale = "VipCustomerSale";
        public const string NewCustomerCreated = "NewCustomerCreated";
        public const string BackupFailed = "BackupFailed";
        public const string IntegrationFailed = "IntegrationFailed";
        public const string SyncFailed = "SyncFailed";
        public const string LicenseExpireSoon = "LicenseExpireSoon";
        public const string UserLoginFailedManyTimes = "UserLoginFailedManyTimes";
    }

    public static class NotificationCategories
    {
        public const string Stock = "Stock";
        public const string Sale = "Sale";
        public const string Purchase = "Purchase";
        public const string Payment = "Payment";
        public const string Installment = "Installment";
        public const string Customer = "Customer";
        public const string System = "System";
    }

    public static class NotificationSeverities
    {
        public const string Info = "Info";
        public const string Warning = "Warning";
        public const string High = "High";
        public const string Critical = "Critical";
    }

    public static class NotificationStatuses
    {
        public const string Active = "Active";
        public const string Resolved = "Resolved";
        public const string Cancelled = "Cancelled";
        public const string Expired = "Expired";
    }

    public static class NotificationRecipientStatuses
    {
        public const string Unread = "Unread";
        public const string Read = "Read";
        public const string Dismissed = "Dismissed";
        public const string Snoozed = "Snoozed";
    }

    public static class NotificationChannels
    {
        public const string InApp = "InApp";
        public const string Popup = "Popup";
        public const string Sms = "SMS";
        public const string Email = "Email";
        public const string WhatsApp = "WhatsApp";
    }

    public static class NotificationOutboxStatuses
    {
        public const string Pending = "Pending";
        public const string Sent = "Sent";
        public const string Failed = "Failed";
        public const string Cancelled = "Cancelled";
    }

    public static class NotificationActionTypes
    {
        public const string Created = "Created";
        public const string RaisedAgain = "RaisedAgain";
        public const string Assigned = "Assigned";
        public const string Read = "Read";
        public const string Dismissed = "Dismissed";
        public const string Snoozed = "Snoozed";
        public const string Resolved = "Resolved";
        public const string Cancelled = "Cancelled";
        public const string OutboxCreated = "OutboxCreated";
        public const string ChannelSent = "ChannelSent";
        public const string ChannelFailed = "ChannelFailed";
        public const string PopupShown = "PopupShown";
    }

    public static class NotificationEntityTypes
    {
        public const string Product = "Product";
        public const string Invoice = "Invoice";
        public const string Customer = "Customer";
        public const string Payment = "Payment";
        public const string Store = "Store";
        public const string System = "System";
    }
}
