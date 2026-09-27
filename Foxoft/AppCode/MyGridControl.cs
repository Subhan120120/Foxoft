using DevExpress.Data.Filtering.Helpers;
using DevExpress.DataAccess.Excel;
using DevExpress.LookAndFeel;
using DevExpress.Utils;
using DevExpress.Utils.Menu;
using DevExpress.Utils.Svg;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Drawing;
using DevExpress.XtraEditors.Filtering;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.FilterEditor;
using DevExpress.XtraGrid.Registrator;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Foxoft.AppCode;
using DevExpress.XtraLayout;
using DevExpress.XtraLayout.Utils;

namespace Foxoft
{
    public class MyGridControl : GridControl
    {
        public MyGridControl() : base()
        {
        }

        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            DisableHeaderClickSorting();
        }

        protected override void RegisterAvailableViewsCore(InfoCollection collection)
        {
            base.RegisterAvailableViewsCore(collection);
            collection.Add(new MyGridViewInfoRegistrator());
        }

        private void DisableHeaderClickSorting()
        {
            if (MainView is GridView mainView)
                MyGridView.DisableHeaderClickSorting(mainView);

            foreach (BaseView view in ViewCollection)
            {
                if (view is GridView gridView)
                    MyGridView.DisableHeaderClickSorting(gridView);
            }
        }
    }

    public class MyGridView : GridView
    {
        public MyGridView() : base()
        {
            InitializeMyGridView();
        }

        private void InitializeMyGridView()
        {
            DisableHeaderClickSorting(this);
            FilterEditorCreated -= gV_ProductList_FilterEditorCreated;
            FilterEditorCreated += gV_ProductList_FilterEditorCreated;
        }

        private void gV_ProductList_FilterEditorCreated(object sender, FilterControlEventArgs e)
        {
            e.FilterControl.BeforeShowValueEditor += FilterControl_BeforeShowValueEditor;

            //FilterBuilder asds = e.FilterBuilder;
            //_FilterControlForm.FormClosed += new(FilterEditorForm_FormClosed);

            //filterControl2 = e.FilterControl;
        }

        void FilterControl_BeforeShowValueEditor(object sender, ShowValueEditorEventArgs e)
        {
            e.InitFilterRepositoryItems();
        }

        public MyGridView(GridControl grid) : base(grid)
        {
            InitializeMyGridView();
        }

        internal const string MyGridViewName = "MyGridView";
        protected override string ViewName { get { return MyGridViewName; } }

        private static readonly Dictionary<GridView, Point> _columnClickPoints = new();

        internal static void DisableHeaderClickSorting(GridView view)
        {
            view.MouseDown -= MyGridView_MouseDown;
            view.MouseDown += MyGridView_MouseDown;
            view.MouseUp -= MyGridView_MouseUp;
            view.MouseUp += MyGridView_MouseUp;
        }

        private static void MyGridView_MouseDown(object sender, MouseEventArgs e)
        {
            if (sender is not GridView view || e.Button != MouseButtons.Left)
                return;

            GridHitInfo hitInfo = view.CalcHitInfo(e.Location);
            if (hitInfo.HitTest == GridHitTest.Column)
                _columnClickPoints[view] = e.Location;
            else
                _columnClickPoints.Remove(view);
        }

        private static void MyGridView_MouseUp(object sender, MouseEventArgs e)
        {
            if (sender is not GridView view || e.Button != MouseButtons.Left)
                return;

            if (_columnClickPoints.TryGetValue(view, out Point downPoint))
            {
                _columnClickPoints.Remove(view);

                int dx = Math.Abs(e.X - downPoint.X);
                int dy = Math.Abs(e.Y - downPoint.Y);

                // Only block if mouse didn't move — it's a pure click (sorting), not drag/resize
                if (dx <= SystemInformation.DragSize.Width && dy <= SystemInformation.DragSize.Height)
                    DXMouseEventArgs.GetMouseArgs(e).Handled = true;
            }
        }

        protected override Form CreateFilterBuilderDialog(FilterColumnCollection filterColumns, FilterColumn defaultFilterColumn)
        {
            return new MyFilterBuilder(filterColumns, GridControl.MenuManager, GridControl.LookAndFeel, this, defaultFilterColumn);
        }
    }

    public class MyGridViewInfoRegistrator : GridInfoRegistrator
    {

        public MyGridViewInfoRegistrator() : base()
        {
        }

        public override string ViewName { get { return MyGridView.MyGridViewName; } }

        public override BaseView CreateView(GridControl grid)
        {
            return new MyGridView(grid); 
        }

    }

    public class MyFilterBuilder : FilterBuilder
    {
        private SimpleButton? sbExportEntireFilterExcel;
        private SimpleButton? sbImportEntireFilterExcel;

        public MyFilterBuilder(FilterColumnCollection columns, IDXMenuManager manager, UserLookAndFeel lookAndFeel, ColumnView view, FilterColumn fColumn)
            : base(columns, manager, lookAndFeel, view, fColumn)
        {
            sbOK.Enabled = sbApply.Enabled = false;
            ((FilterControl)fcMain).FilterChanged += new FilterChangedEventHandler(OnFilterControlFilterChanged);
            InitializeExcelButtons();
        }

        private void InitializeExcelButtons()
        {
            var layoutControl = Controls.Find("layoutControl1", true).FirstOrDefault() as LayoutControl;
            if (layoutControl != null)
            {
                layoutControl.BeginUpdate();
                try
                {
                    sbExportEntireFilterExcel = new SimpleButton
                    {
                        Name = "sbExportEntireFilterExcel",
                        Text = Properties.Resources.Common_Filter_ExportEntireFilter,
                        ToolTip = Properties.Resources.Common_Filter_ExportEntireFilter
                    };
                    sbExportEntireFilterExcel.Click += SbExportEntireFilterExcel_Click;

                    sbImportEntireFilterExcel = new SimpleButton
                    {
                        Name = "sbImportEntireFilterExcel",
                        Text = Properties.Resources.Common_Filter_ImportEntireFilter,
                        ToolTip = Properties.Resources.Common_Filter_ImportEntireFilter
                    };
                    sbImportEntireFilterExcel.Click += SbImportEntireFilterExcel_Click;

                    try
                    {
                        ComponentResourceManager resProduct = new(typeof(FormProductList));
                        var svgExport = resProduct.GetObject("bBI_ExportExcel.ImageOptions.SvgImage") as SvgImage;
                        if (svgExport != null)
                        {
                            sbExportEntireFilterExcel.ImageOptions.SvgImage = svgExport;
                            sbExportEntireFilterExcel.ImageOptions.SvgImageSize = new Size(16, 16);
                        }
                    }
                    catch { }

                    try
                    {
                        ComponentResourceManager resInvoice = new(typeof(FormInvoice));
                        var svgImport = resInvoice.GetObject("BBI_ImportExcel.ImageOptions.SvgImage") as SvgImage;
                        if (svgImport != null)
                        {
                            sbImportEntireFilterExcel.ImageOptions.SvgImage = svgImport;
                            sbImportEntireFilterExcel.ImageOptions.SvgImageSize = new Size(16, 16);
                        }
                    }
                    catch { }

                    var lciExport = layoutControl.Root.AddItem();
                    lciExport.Control = sbExportEntireFilterExcel;
                    lciExport.TextVisible = false;

                    var lciImport = layoutControl.Root.AddItem();
                    lciImport.Control = sbImportEntireFilterExcel;
                    lciImport.TextVisible = false;

                    var emptySpace = layoutControl.Root.Items.OfType<EmptySpaceItem>().FirstOrDefault();
                    if (emptySpace != null)
                    {
                        lciExport.Move(emptySpace, InsertType.Left);
                        lciImport.Move(lciExport, InsertType.Right);
                    }
                }
                finally
                {
                    layoutControl.EndUpdate();
                }
            }
        }

        private void SbExportEntireFilterExcel_Click(object? sender, EventArgs e)
        {
            FilterExcelHelper.ExportEntireFilterToExcel((FilterControl)fcMain, this);
        }

        private void SbImportEntireFilterExcel_Click(object? sender, EventArgs e)
        {
            if (FilterExcelHelper.ImportEntireFilterFromExcel((FilterControl)fcMain, this))
            {
                sbOK.Enabled = sbApply.Enabled = true;
            }
        }

        protected override GridFilterControl CreateGridFilterControl()
        {
            var filterControl = new ClauseNodeExcelButtonFilterControl(Client);
            filterControl.ClauseNodeExcelButtonClick += FilterControl_ClauseNodeExcelButtonClick;

            return filterControl;
        }

        private void FilterControl_ClauseNodeExcelButtonClick(object sender, ClauseNodeExcelButtonEventArgs e)
        {
            ClauseNode clauseNode = (ClauseNode)e.LabelInfo.Owner;
            FilterControl filterControl = (FilterControl)fcMain;

            var menu = new DXPopupMenu();
            menu.Items.Add(new DXMenuItem(Properties.Resources.Common_Filter_Node_ImportExcel, (s, ev) =>
            {
                if (FilterExcelHelper.ImportClauseNodeValuesFromExcel(clauseNode, filterControl, this))
                {
                    sbOK.Enabled = sbApply.Enabled = true;
                }
            }));
            menu.Items.Add(new DXMenuItem(Properties.Resources.Common_Filter_Node_ExportExcel, (s, ev) =>
            {
                FilterExcelHelper.ExportClauseNodeValuesToExcel(clauseNode, filterControl, this);
            }));

            Point clientPoint = new(e.LabelInfo.NodeBounds.Right, e.LabelInfo.NodeBounds.Top);
            MenuManagerHelper.ShowMenu(menu, LookAndFeel, ((IDXMenuManagerProvider)this).MenuManager, filterControl, clientPoint);
        }

        public DataTable ToDataTableFromExcelDataSource(ExcelDataSource excelDataSource)
        {
            IList list = ((IListSource)excelDataSource).GetList();
            DevExpress.DataAccess.Native.Excel.DataView dataView = (DevExpress.DataAccess.Native.Excel.DataView)list;
            List<PropertyDescriptor> props = dataView.Columns.ToList<PropertyDescriptor>();

            DataTable table = new();

            foreach (var prop in props)
            {
                table.Columns.Add(prop.Name, prop.PropertyType);
            }
            object[] values = new object[props.Count];
            foreach (DevExpress.DataAccess.Native.Excel.ViewRow item in list)
            {
                for (int i = 0; i < values.Length; i++)
                {
                    values[i] = props[i].GetValue(item);
                }
                table.Rows.Add(values);
            }
            return table;
        }

        private void OnFilterControlFilterChanged(object sender, FilterChangedEventArgs e)
        {
            sbOK.Enabled = sbApply.Enabled = true;
        }
    }

    public class ClauseNodeExcelButtonFilterControl : GridFilterControl
    {
        private ToolTip? _toolTip;
        private bool _isToolTipVisible;

        public ClauseNodeExcelButtonFilterControl(ISupportFilterCriteriaDisplayStyle client)
            : base(client.DisplayStyle)
        {
            InitIcon();
            _toolTip = new ToolTip();
        }

        private void InitIcon()
        {
            if (_Icon != null) return;
            try
            {
                ComponentResourceManager resources = new(typeof(FormProductList));
                SvgImage? svgImage = resources.GetObject("bBI_ExportExcel.ImageOptions.SvgImage") as SvgImage;
                if (svgImage != null)
                {
                    SvgBitmap bm = new(svgImage);
                    _Icon = bm.Render(null, 0.5);
                }
            }
            catch { }
        }

        private Image? _Icon;
        public Image? MyIcon
        {
            get
            {
                if (_Icon == null) InitIcon();
                return _Icon;
            }
            set { _Icon = value; }
        }

        public delegate void ClauseNodeExcelButtonEventHandler(object sender, ClauseNodeExcelButtonEventArgs e);
        public event ClauseNodeExcelButtonEventHandler? ClauseNodeExcelButtonClick;

        [Obsolete("Use ClauseNodeExcelButtonClick instead.")]
        public delegate void ExcelBtnEventHandler(object sender, ExcelBtnEventArgs e);
        [Obsolete("Use ClauseNodeExcelButtonClick instead.")]
        public event ExcelBtnEventHandler? ExcelBtnClick;

        protected override BaseControlPainter CreatePainter()
        {
            return new ClauseNodeExcelButtonPainter(this);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            Point mouseLocation = new(e.X, e.Y);
            if (TryGetExcelButtonLabelInfo(mouseLocation, out FilterControlLabelInfo labelInfo))
            {
                Cursor = Cursors.Hand;
                if (!_isToolTipVisible)
                {
                    _toolTip?.Show(Properties.Resources.Common_Filter_Node_Tooltip, this, e.X + 16, e.Y + 16);
                    _isToolTipVisible = true;
                }
            }
            else
            {
                Cursor = Cursors.Default;
                if (_isToolTipVisible)
                {
                    _toolTip?.Hide(this);
                    _isToolTipVisible = false;
                }
            }
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            Cursor = Cursors.Default;
            if (_isToolTipVisible)
            {
                _toolTip?.Hide(this);
                _isToolTipVisible = false;
            }
        }

        protected override void OnMouseDown(System.Windows.Forms.MouseEventArgs e)
        {
            if (_Icon == null)
                InitIcon();

            base.OnMouseDown(e);
            Point mouseLocation = new(e.X, e.Y);
            if (e.Button == MouseButtons.Left && TryGetExcelButtonLabelInfo(mouseLocation, out FilterControlLabelInfo labelInfo))
            {
                ClauseNodeExcelButtonClick?.Invoke(this, new ClauseNodeExcelButtonEventArgs(labelInfo));
#pragma warning disable CS0618
                ExcelBtnClick?.Invoke(this, new ExcelBtnEventArgs(labelInfo));
#pragma warning restore CS0618
            }
        }

        private bool TryGetExcelButtonLabelInfo(Point mouseLocation, out FilterControlLabelInfo labelInfo)
        {
            labelInfo = null!;

            if (MyIcon == null)
                return false;

            labelInfo = Model.GetLabelInfoByCoordinates(mouseLocation.X - MyIcon.Width - 1, mouseLocation.Y);
            if (labelInfo == null)
                return false;

            ClauseNode? clauseNode = labelInfo.Owner as ClauseNode;
            if (labelInfo.Owner.Elements[0].ElementType == ElementType.Group
                || (clauseNode?.Operation != ClauseType.AnyOf && clauseNode?.Operation != ClauseType.NoneOf))
                return false;

            return GetExcelButtonBounds(labelInfo).Contains(mouseLocation);
        }

        internal Rectangle GetExcelButtonBounds(FilterControlLabelInfo labelInfo)
        {
            int iconHeight = MyIcon?.Height ?? 16;
            int iconWidth = MyIcon?.Width ?? 16;

            return new Rectangle(
                labelInfo.NodeBounds.X + labelInfo.NodeBounds.Width,
                labelInfo.NodeBounds.Y + (labelInfo.NodeBounds.Height - iconHeight) / 2 + 2,
                iconWidth,
                iconHeight);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _toolTip?.Dispose();
                _toolTip = null;
            }
            base.Dispose(disposing);
        }
    }

    public class ClauseNodeExcelButtonEventArgs : EventArgs
    {
        private FilterControlLabelInfo _LabelInfo;

        public FilterControlLabelInfo LabelInfo
        {
            get { return _LabelInfo; }
            set { _LabelInfo = value; }
        }
        public ClauseNodeExcelButtonEventArgs(FilterControlLabelInfo li)
        {
            _LabelInfo = li;
        }
    }

    [Obsolete("Use ClauseNodeExcelButtonEventArgs instead.")]
    public class ExcelBtnEventArgs : EventArgs
    {
        private FilterControlLabelInfo _LabelInfo;

        public FilterControlLabelInfo LabelInfo
        {
            get { return _LabelInfo; }
            set { _LabelInfo = value; }
        }
        public ExcelBtnEventArgs(FilterControlLabelInfo li)
        {
            _LabelInfo = li;
        }
    }

    [Obsolete("Use ClauseNodeExcelButtonFilterControl instead.")]
    public class ExcelBtnFilterControl : ClauseNodeExcelButtonFilterControl
    {
        public ExcelBtnFilterControl(ISupportFilterCriteriaDisplayStyle client) : base(client) { }
    }

    public class ClauseNodeExcelButtonPainter : FilterControlPainter
    {
        public ClauseNodeExcelButtonPainter(FilterControl filter) : base(filter) { }

        protected override void DrawNodeLabel(Node node, ControlGraphicsInfoArgs info)
        {
            FilterControlLabelInfo? labelInfo = (node.Model as WinFilterTreeNodeModel)?[node];
            ClauseNodeExcelButtonFilterControl? fControl = Owner as ClauseNodeExcelButtonFilterControl;
            if (fControl?.MyIcon != null && labelInfo != null)
            {
                ClauseNode? clauseNode = node as ClauseNode;

                if (node.Elements[0].ElementType != ElementType.Group
                   && (clauseNode?.Operation == ClauseType.AnyOf || clauseNode?.Operation == ClauseType.NoneOf))
                {
                    info.Graphics.DrawImage(fControl.MyIcon, fControl.GetExcelButtonBounds(labelInfo).Location);
                }
            }
            base.DrawNodeLabel(node, info);
        }
    }

    [Obsolete("Use ClauseNodeExcelButtonPainter instead.")]
    public class ExcelBtnFilterControlPainter : ClauseNodeExcelButtonPainter
    {
        public ExcelBtnFilterControlPainter(FilterControl filter) : base(filter) { }
    }
}
