namespace Foxoft
{
    /// <summary>
    /// Notification templates management form.
    /// Unified into <see cref="FormNotificationRule"/> with the templates tab focused.
    /// Kept for backward compatibility with navigation, permissions, and existing calls.
    /// </summary>
    public class FormNotificationTemplate : FormNotificationRule
    {
        public FormNotificationTemplate()
        {
            SelectTemplatesTab();
        }
    }
}
