using DevExpress.Data.Filtering.Helpers;
using DevExpress.Utils.Drawing;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Drawing;
using DevExpress.XtraEditors.Filtering;
using System;
using System.Drawing;

namespace Foxoft.AppCode
{
    public class ExcelButtonFilterControl : FilterControl
    {


        // *******************************************  Add Custom Button to FilterControl  ********************************************

        public Image MyIcon
        {
            get { return _Icon; }
            set { _Icon = value; }
        }

        public delegate void ExcelButtonEventHandler(object sender, ExcelButtonEventArgs e);
        public event ExcelButtonEventHandler ExcelButtonClick;

        protected override BaseControlPainter CreatePainter()
        {
            return new ExcelButtonFilterControlPainter(this);
        }

        protected override void OnMouseDown(System.Windows.Forms.MouseEventArgs e)
        {
            base.OnMouseDown(e);
            FilterControlLabelInfo li = Model.GetLabelInfoByCoordinates(e.X - _Icon.Width - 1, e.Y);
            if (li != null)
            {
                ClauseNode clauseNode = li.Owner as ClauseNode;

                if (li.Owner.Elements[0].ElementType != ElementType.Group && 
                    (clauseNode?.Operation == ClauseType.AnyOf || clauseNode?.Operation == ClauseType.NoneOf))
                    if (li.NodeWidth < e.X)
                        if (ExcelButtonClick != null)
                            ExcelButtonClick(this, new ExcelButtonEventArgs(li));
            }
        }

        private Image _Icon;
    }

    public class ExcelButtonEventArgs : EventArgs
    {
        // Fields...
        private FilterControlLabelInfo _LabelInfo;

        public FilterControlLabelInfo LabelInfo
        {
            get { return _LabelInfo; }
            set { _LabelInfo = value; }
        }
        public ExcelButtonEventArgs(FilterControlLabelInfo li)
        {
            LabelInfo = li;
        }
    }

    public class ExcelButtonFilterControlPainter : FilterControlPainter
    {
        public ExcelButtonFilterControlPainter(FilterControl filter) : base(filter) { }

        protected override void DrawNodeLabel(Node node, ControlGraphicsInfoArgs info)
        {
            FilterControlLabelInfo labelInfo = (node.Model as WinFilterTreeNodeModel)[node];
            ExcelButtonFilterControl fControl = Owner as ExcelButtonFilterControl;
            if (fControl.MyIcon != null)
            {
                ClauseNode clauseNode = node as ClauseNode;

                if (node.Elements[0].ElementType != ElementType.Group &&
                    (clauseNode?.Operation == ClauseType.AnyOf || clauseNode?.Operation == ClauseType.NoneOf))
                {
                    Point p = new Point(labelInfo.NodeBounds.X + labelInfo.NodeBounds.Width,
                       labelInfo.NodeBounds.Y + (labelInfo.NodeBounds.Height - fControl.MyIcon.Height) / 2 + 2);

                    info.Graphics.DrawImage(fControl.MyIcon, p);
                }
            }
            base.DrawNodeLabel(node, info);
        }
    }

    // *******************************************  Prevent delete filter from FIlterControl  ********************************************
    public class NotEditableFilterControl : FilterControl
    {
        public NotEditableFilterControl() : base() { }
        protected override BaseControlPainter CreatePainter()
        {
            return new NotEditableFilterControlPainter(this);
        }

        protected override void RaisePopupMenuShowing(PopupMenuShowingEventArgs e)
        {
            base.RaisePopupMenuShowing(e);
            e.Cancel = true;
        }
    }

    public class NotEditableFilterControlPainter : FilterControlPainter
    {
        public NotEditableFilterControlPainter(FilterControl filterControl) : base(filterControl) { }

        protected override void DrawNodeLabel(Node node, ControlGraphicsInfoArgs info)
        {
            //base.DrawNodeLabel(node, info);
            if (Model[node] == null) return;
            Paint(Model[node], info);
        }

        public virtual void Paint(FilterControlLabelInfo labelInfo, ControlGraphicsInfoArgs info)
        {
            labelInfo.ViewInfo.Calculate(new GraphicsCache(info.Graphics));
            labelInfo.ViewInfo.TopLine = 0;
            for (int i = 0; i < labelInfo.ViewInfo.Count; i++)
            {
                NodeEditableElement elem = labelInfo.ViewInfo[i].InfoText.Tag as NodeEditableElement;

                if (elem == null || (elem.ElementType == ElementType.NodeAdd
                                  || elem.ElementType == ElementType.NodeRemove
                                  || elem.ElementType == ElementType.Group))
                {
                    labelInfo.ViewInfo[i].InfoText.Tag = null;
                    continue;
                }
                labelInfo.ViewInfo[i].ViewInfo.Calculate(new GraphicsCache(info.Graphics));
                labelInfo.ViewInfo[i].Draw(info.Cache, info.ViewInfo.Appearance.GetFont(), labelInfo.ViewInfo[i].InfoText.Color, info.ViewInfo.Appearance.GetStringFormat());
            }
        }

        public override void DrawFocusRectangle(ControlGraphicsInfoArgs info) { }
    }
}
