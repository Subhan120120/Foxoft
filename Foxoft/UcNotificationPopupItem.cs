using Foxoft.Models;
using Foxoft.Models.ViewModel;
using Foxoft.Properties;
using System.Drawing.Drawing2D;

namespace Foxoft
{
    public partial class UcNotificationPopupItem : DevExpress.XtraEditors.XtraUserControl
    {
        private Image? notificationImage;
        private static readonly Color ReadBackColor = Color.FromArgb(232, 245, 233);
        private static readonly Color ReadAccentColor = Color.FromArgb(46, 125, 50);
        private static readonly Font TitleUnreadFont = new("Segoe UI", 9F, FontStyle.Bold);
        private static readonly Font TitleReadFont = new("Segoe UI", 9F, FontStyle.Regular);
        private static readonly Font BodyUnreadFont = new("Segoe UI", 8.25F, FontStyle.Bold);
        private static readonly Font BodyReadFont = new("Segoe UI", 8.25F, FontStyle.Regular);
        private static readonly Font DetailUnreadFont = new("Segoe UI", 7.8F, FontStyle.Bold);
        private static readonly Font DetailReadFont = new("Segoe UI", 7.8F, FontStyle.Regular);

        public event EventHandler? NotificationClick;
        public NotificationInboxItem? NotificationItem { get; private set; }

        public UcNotificationPopupItem()
        {
            InitializeComponent();
            RegisterNotificationClickHandlers(this);
        }

        public void Bind(NotificationInboxItem item, Image? entityImage = null)
        {
            NotificationItem = item;
            Color severityColor = GetSeverityColor(item.Severity);
            ApplyRecipientStatusAppearance(item, severityColor);

            lblTitle.Text = item.Title;
            lblBody.Text = NormalizeBody(item.Body);
            lblStatus.Text = item.RecipientStatus;
            lblMeta.Text = BuildMetaText(item);
            lblEntity.Text = BuildEntityText(item);

            notificationImage?.Dispose();
            notificationImage = entityImage ?? CreateSeverityImage(item.Severity, severityColor);
            pictureSeverity.Image = notificationImage;
        }

        private void ApplyRecipientStatusAppearance(NotificationInboxItem item, Color severityColor)
        {
            bool isUnread = string.Equals(item.RecipientStatus, NotificationRecipientStatuses.Unread, StringComparison.OrdinalIgnoreCase);
            bool isRead = string.Equals(item.RecipientStatus, NotificationRecipientStatuses.Read, StringComparison.OrdinalIgnoreCase);
            Color backColor = isRead ? ReadBackColor : Color.White;
            Color statusColor = isRead ? ReadAccentColor : severityColor;

            Appearance.BackColor = backColor;
            Appearance.Options.UseBackColor = true;

            panelAccent.Appearance.BackColor = statusColor;
            panelAccent.Appearance.Options.UseBackColor = true;

            lblStatus.Appearance.BackColor = statusColor;
            lblStatus.Appearance.Options.UseBackColor = true;

            lblTitle.Appearance.BackColor = backColor;
            lblTitle.Appearance.Font = isUnread ? TitleUnreadFont : TitleReadFont;
            lblTitle.Appearance.Options.UseBackColor = true;
            lblTitle.Appearance.Options.UseFont = true;

            lblBody.Appearance.BackColor = backColor;
            lblBody.Appearance.Font = isUnread ? BodyUnreadFont : BodyReadFont;
            lblBody.Appearance.Options.UseBackColor = true;
            lblBody.Appearance.Options.UseFont = true;

            lblMeta.Appearance.BackColor = backColor;
            lblMeta.Appearance.Font = isUnread ? DetailUnreadFont : DetailReadFont;
            lblMeta.Appearance.Options.UseBackColor = true;
            lblMeta.Appearance.Options.UseFont = true;

            lblEntity.Appearance.BackColor = backColor;
            lblEntity.Appearance.Font = isUnread ? DetailUnreadFont : DetailReadFont;
            lblEntity.Appearance.Options.UseBackColor = true;
            lblEntity.Appearance.Options.UseFont = true;

            pictureSeverity.Properties.Appearance.BackColor = backColor;
            pictureSeverity.Properties.Appearance.Options.UseBackColor = true;
        }

        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
            RaiseNotificationClick();
        }

        private void RegisterNotificationClickHandlers(Control parent)
        {
            foreach (Control control in parent.Controls)
            {
                control.Click += NotificationControl_Click;
                RegisterNotificationClickHandlers(control);
            }
        }

        private void NotificationControl_Click(object? sender, EventArgs e)
        {
            RaiseNotificationClick();
        }

        private void RaiseNotificationClick()
        {
            if (NotificationItem != null)
                NotificationClick?.Invoke(this, EventArgs.Empty);
        }

        private static string NormalizeBody(string body)
            => string.IsNullOrWhiteSpace(body)
                ? string.Empty
                : body.Replace("\r\n", " ").Replace('\n', ' ').Trim();

        private static string BuildMetaText(NotificationInboxItem item)
        {
            string store = string.IsNullOrWhiteSpace(item.StoreCode)
                ? string.Empty
                : $" | {Resources.Entity_InvoiceHeader_StoreCode}: {item.StoreCode}";

            return $"{item.NotificationTypeDesc} | {Resources.Entity_Notification_LastRaisedDate}: {item.LastRaisedDate:g}{store}";
        }

        private static string BuildEntityText(NotificationInboxItem item)
        {
            if (string.IsNullOrWhiteSpace(item.EntityType) && string.IsNullOrWhiteSpace(item.EntityKey))
                return string.Empty;

            return $"{Resources.Entity_Notification_EntityType}: {item.EntityType} | {Resources.Entity_Notification_EntityKey}: {item.EntityKey}";
        }

        private static Color GetSeverityColor(string severity)
            => severity switch
            {
                NotificationSeverities.Critical => Color.FromArgb(211, 47, 47),
                NotificationSeverities.High => Color.FromArgb(239, 108, 0),
                NotificationSeverities.Warning => Color.FromArgb(245, 166, 35),
                _ => Color.FromArgb(25, 118, 210)
            };

        private static string GetSeverityGlyph(string severity)
            => severity switch
            {
                NotificationSeverities.Critical => "!",
                NotificationSeverities.High => "!",
                NotificationSeverities.Warning => "!",
                _ => "i"
            };

        private static Image CreateSeverityImage(string severity, Color color)
        {
            Bitmap bitmap = new(38, 38);

            using Graphics graphics = Graphics.FromImage(bitmap);
            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            graphics.Clear(Color.Transparent);

            using SolidBrush backgroundBrush = new(color);
            graphics.FillEllipse(backgroundBrush, 1, 1, 36, 36);

            using Font font = new("Segoe UI", 16F, FontStyle.Bold);
            using SolidBrush textBrush = new(Color.White);
            using StringFormat format = new()
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };

            graphics.DrawString(GetSeverityGlyph(severity), font, textBrush, new RectangleF(1, 0, 36, 36), format);
            return bitmap;
        }
    }
}
