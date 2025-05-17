using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Foxoft
{
    public static class MouseWheelHelper
    {
        public static void DisableMouseWheel(Control control)
        {
            control.MouseWheel += (s, e) =>
            {
                if (e is HandledMouseEventArgs handledArgs)
                    handledArgs.Handled = true;
            };
        }

        public static void DisableMouseWheelForType<T>(Control parent) where T : Control
        {
            foreach (Control ctrl in parent.Controls)
            {
                if (ctrl is T)
                    DisableMouseWheel(ctrl);

                if (ctrl.HasChildren)
                    DisableMouseWheelForType<T>(ctrl);
            }
        }
    }
}
