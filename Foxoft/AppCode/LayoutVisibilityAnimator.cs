using DevExpress.XtraLayout;
using DevExpress.XtraLayout.Utils;
using System;
using System.Drawing;
using System.Windows.Forms;

public static class LayoutControlAnimator
{
    public static void SetVisibilityWithAnimation(LayoutControlItem layoutControlItem, LayoutVisibility visibility)
    {
        var h = layoutControlItem.Height;
        var n = layoutControlItem.Name;

        layoutControlItem.SizeConstraintsType = SizeConstraintsType.Custom;
        layoutControlItem.MinSize = new Size(163, 1);

        if (layoutControlItem.Visibility != visibility)
        {
            if (visibility == LayoutVisibility.Never)
            {
                AnimateLayoutControlItem(layoutControlItem, false, () =>
                {
                    layoutControlItem.Visibility = visibility;
                    layoutControlItem.SizeConstraintsType = SizeConstraintsType.Default;
                });
            }
            else
            {
                layoutControlItem.Visibility = visibility;
                AnimateLayoutControlItem(layoutControlItem, true, () =>
                {
                    layoutControlItem.SizeConstraintsType = SizeConstraintsType.Default;
                });
            }
        }
        else
        {
            layoutControlItem.SizeConstraintsType = SizeConstraintsType.Default;
        }
    }

    private static void AnimateLayoutControlItem(LayoutControlItem layoutControlItem, bool show, Action onComplete = null)
    {
        System.Windows.Forms.Timer timer = new();
        timer.Interval = 15;
        int step = show ? 5 : -5;
        int initialHeight = show ? 1 : layoutControlItem.Height;
        int targetHeight = show ? 26 : 1;

        string asd = layoutControlItem.ControlName;

        layoutControlItem.Height = initialHeight;
        if (layoutControlItem.Control != null)
        {
            layoutControlItem.Control.MaximumSize = new Size(layoutControlItem.Control.MaximumSize.Width, initialHeight);
        }

        timer.Tick += (s, e) =>
        {
            if (layoutControlItem.Height + step < 0) // layoutControlItem.Height menfi almasin deye 
                return;

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
