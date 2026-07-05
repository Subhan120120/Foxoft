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
        public MyFilterBuilder(FilterColumnCollection columns, IDXMenuManager manager, UserLookAndFeel lookAndFeel, ColumnView view, FilterColumn fColumn)
            : base(columns, manager, lookAndFeel, view, fColumn)
        {
            sbOK.Enabled = sbApply.Enabled = false;
            ((FilterControl)fcMain).FilterChanged += new FilterChangedEventHandler(OnFilterControlFilterChanged);
        }

        protected override GridFilterControl CreateGridFilterControl()
        {
            var filterControl = new ExcelBtnFilterControl(Client);
            filterControl.ExcelBtnClick += new ExcelBtnFilterControl.ExcelBtnEventHandler(ExcelBtnFilterControl_ExcelBtnClick);

            return filterControl;
        }

        private void ExcelBtnFilterControl_ExcelBtnClick(object sender, ExcelBtnEventArgs e)
        {
            XtraOpenFileDialog dialog = new();
            dialog.Filter = "Excel Files (*.xls;*.xlsx)|*.xls;*.xlsx|All files (*.*)|*.*";
            dialog.Title = "Yalnız ilk sütünda olan məlumatlar daxil edilir.";

            DialogResult dr = dialog.ShowDialog();

            if (dr == DialogResult.OK)
            {
                ExcelDataSource excelDataSource = new();
                excelDataSource.FileName = dialog.FileName;

                ExcelWorksheetSettings excelWorksheetSettings = new(0, "A1:A10000");
                //excelWorksheetSettings.WorksheetName = "10QK";

                ExcelSourceOptions excelOptions = new();
                excelOptions.ImportSettings = excelWorksheetSettings;
                excelOptions.SkipHiddenRows = false;
                excelOptions.SkipHiddenColumns = false;
                excelOptions.UseFirstRowAsHeader = true;
                excelDataSource.SourceOptions = excelOptions;

                excelDataSource.Fill();

                DataTable dt = new();
                dt = ToDataTableFromExcelDataSource(excelDataSource);

                ClauseNode clauseNode = (ClauseNode)e.LabelInfo.Owner;

                if (clauseNode.Operation == ClauseType.AnyOf || clauseNode.Operation == ClauseType.NoneOf)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        clauseNode.AdditionalOperands.Add(row[0].ToString());
                    }
                }
            }
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
            ((FilterControl)fcMain).FilterChanged -= new FilterChangedEventHandler(OnFilterControlFilterChanged);
        }
    }

    public class ExcelBtnFilterControl : GridFilterControl
    {
        public ExcelBtnFilterControl(ISupportFilterCriteriaDisplayStyle client)
            : base(client.DisplayStyle)
        { }

        private Image _Icon;
        public Image MyIcon
        {
            get { return _Icon; }
            set { _Icon = value; }
        }

        public delegate void ExcelBtnEventHandler(object sender, ExcelBtnEventArgs e);
        public event ExcelBtnEventHandler ExcelBtnClick;

        protected override BaseControlPainter CreatePainter()
        {
            return new ExcelBtnFilterControlPainter(this);
        }

        protected override void OnMouseDown(System.Windows.Forms.MouseEventArgs e)
        {
            ComponentResourceManager resources = new(typeof(FormProductList));
            SvgImage ımage = ((SvgImage)(resources.GetObject("bBI_ExportExcel.ImageOptions.SvgImage")));
            SvgBitmap bm = new SvgBitmap(ımage);
            MyIcon = bm.Render(null, 0.5);

            base.OnMouseDown(e);
            Point mouseLocation = new(e.X, e.Y);
            if (e.Button == MouseButtons.Left && TryGetExcelButtonLabelInfo(mouseLocation, out FilterControlLabelInfo labelInfo))
                ExcelBtnClick?.Invoke(this, new ExcelBtnEventArgs(labelInfo));
        }

        private bool TryGetExcelButtonLabelInfo(Point mouseLocation, out FilterControlLabelInfo labelInfo)
        {
            labelInfo = null;

            if (_Icon == null)
                return false;

            labelInfo = Model.GetLabelInfoByCoordinates(mouseLocation.X - _Icon.Width - 1, mouseLocation.Y);
            if (labelInfo == null)
                return false;

            ClauseNode clauseNode = labelInfo.Owner as ClauseNode;
            if (labelInfo.Owner.Elements[0].ElementType == ElementType.Group
                || (clauseNode?.Operation != ClauseType.AnyOf && clauseNode?.Operation != ClauseType.NoneOf))
                return false;

            return GetExcelButtonBounds(labelInfo).Contains(mouseLocation);
        }

        internal Rectangle GetExcelButtonBounds(FilterControlLabelInfo labelInfo)
        {
            return new Rectangle(
                labelInfo.NodeBounds.X + labelInfo.NodeBounds.Width,
                labelInfo.NodeBounds.Y + (labelInfo.NodeBounds.Height - MyIcon.Height) / 2 + 2,
                MyIcon.Width,
                MyIcon.Height);
        }

    }

    public class ExcelBtnEventArgs : EventArgs
    {
        // Fields...
        private FilterControlLabelInfo _LabelInfo;

        public FilterControlLabelInfo LabelInfo
        {
            get { return _LabelInfo; }
            set { _LabelInfo = value; }
        }
        public ExcelBtnEventArgs(FilterControlLabelInfo li)
        {
            LabelInfo = li;
        }
    }

    public class ExcelBtnFilterControlPainter : FilterControlPainter
    {
        public ExcelBtnFilterControlPainter(FilterControl filter) : base(filter) { }

        protected override void DrawNodeLabel(Node node, ControlGraphicsInfoArgs info)
        {
            FilterControlLabelInfo labelInfo = (node.Model as WinFilterTreeNodeModel)[node];
            ExcelBtnFilterControl fControl = Owner as ExcelBtnFilterControl;
            if (fControl.MyIcon != null)
            {
                ClauseNode clauseNode = node as ClauseNode;

                if (node.Elements[0].ElementType != ElementType.Group
                   && (clauseNode?.Operation == ClauseType.AnyOf || clauseNode?.Operation == ClauseType.NoneOf))
                {
                    info.Graphics.DrawImage(fControl.MyIcon, fControl.GetExcelButtonBounds(labelInfo).Location);
                }
            }
            base.DrawNodeLabel(node, info);
        }
    }
}
