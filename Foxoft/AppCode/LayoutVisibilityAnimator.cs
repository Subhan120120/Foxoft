using DevExpress.XtraLayout;
using DevExpress.XtraLayout.Utils;

public static class LayoutControlAnimator
{
    public static void SetVisibilityWithAnimation(LayoutControlItem layoutControlItem, LayoutVisibility visibility)
    {
        if (layoutControlItem.Visibility != visibility)
        {
            if (visibility == LayoutVisibility.Never)
            {
                AnimateLayoutControlItem(layoutControlItem, false, () =>
                {
                    layoutControlItem.Visibility = visibility;
                });
            }
            else
            {
                layoutControlItem.Visibility = visibility;
                AnimateLayoutControlItem(layoutControlItem, true);
            }
        }
    }

    private static void AnimateLayoutControlItem(LayoutControlItem layoutControlItem, bool show, Action onComplete = null)
    {
        System.Windows.Forms.Timer timer = new();
        timer.Interval = 1;
        int step = show ? 5 : -5;
        int initialHeight = show ? 1 : layoutControlItem.Height;
        int targetHeight = show ? 26 : 1;

        layoutControlItem.Height = initialHeight;
        if (layoutControlItem.Control != null)
        {
            layoutControlItem.Control.MaximumSize = new Size(layoutControlItem.Control.MaximumSize.Width, initialHeight);
        }

        timer.Tick += (s, e) =>
        {
            layoutControlItem.Height += step;

            if (layoutControlItem.Control != null)
            {
                layoutControlItem.Control.MaximumSize = new Size(layoutControlItem.Control.MaximumSize.Width, layoutControlItem.Height);
            }

            if ((show && layoutControlItem.Height >= targetHeight) || (!show && layoutControlItem.Height <= targetHeight))
            {
                layoutControlItem.Height = targetHeight;

                if (layoutControlItem.Control != null)
                {
                    layoutControlItem.Control.MaximumSize = new Size(layoutControlItem.Control.MaximumSize.Width, targetHeight);
                }

                timer.Stop();

                if (!show)
                {
                    layoutControlItem.Visibility = LayoutVisibility.Never;
                }

                onComplete?.Invoke();
            }
        };

        timer.Start();
    }
}
