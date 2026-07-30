using DevExpress.XtraBars.Alerter;
using DevExpress.XtraEditors;
using Foxoft.Models;
using Foxoft.Models.ViewModel;
using Foxoft.Properties;

namespace Foxoft.AppCode.Service
{
    public sealed class NotificationPopupService
    {
        public async Task ShowPendingPopupsAsync(Form owner, string currAccCode, CancellationToken ct = default)
        {
            using subContext db = new();
            NotificationService service = new(db);
            List<NotificationInboxItem> notifications = await service.GetPopupCandidatesAsync(currAccCode, ct);

            if (notifications.Count == 0)
                return;

            foreach (NotificationInboxItem notification in notifications)
            {
                AlertControl alertControl = new()
                {
                    AutoFormDelay = 7000,
                    FormDisplaySpeed = AlertFormDisplaySpeed.Fast
                };

                alertControl.AlertClick += async (sender, args) =>
                {
                    if (owner is not FormERP formERP || args.Info.Tag is not NotificationInboxItem item)
                        return;

                    try
                    {
                        args.ActivateOwner = true;
                        await formERP.OpenNotificationItemAsync(item);
                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show(
                            string.Format(Resources.ERP_OpenFormError, item.Title, ex.Message),
                            Resources.Common_Error,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                };

                alertControl.Show(owner, new AlertInfo(notification.Title, notification.Body) { Tag = notification });
                await service.MarkPopupShownAsync(notification.NotificationRecipientId, currAccCode, ct);
            }
        }
    }
}
