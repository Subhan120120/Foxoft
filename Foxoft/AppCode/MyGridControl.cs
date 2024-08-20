using DevExpress.Data.Filtering.Helpers;
using DevExpress.DataAccess.Excel;
using DevExpress.LookAndFeel;
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
using System;
using System.Collections;
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

        protected override void RegisterAvailableViewsCore(InfoCollection collection)
        {
            base.RegisterAvailableViewsCore(collection);
            collection.Add(new MyGridViewInfoRegistrator());
        }
    }

    public class MyGridView : GridView
    {
        public IWin32Window parentForm;
        public MyGridView(IWin32Window parentForm) : base()
        {
            parentForm = parentForm;
            this.FilterEditorCreated += new FilterControlEventHandler(gV_ProductList_FilterEditorCreated);
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
            e.InitFilterRepositoryItems(parentForm);
        }

        public MyGridView(GridControl grid) : base(grid) { }

        internal const string MyGridViewName = "MyGridView";
        protected override string ViewName { get { return MyGridViewName; } }

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
            FilterControlLabelInfo li = Model.GetLabelInfoByCoordinates(e.X - _Icon.Width - 1, e.Y);
            if (li != null)
                if (li.Owner.Elements[0].ElementType != ElementType.Group)
                    if (li.NodeWidth < e.X)
                        if (ExcelBtnClick != null)
                            ExcelBtnClick(this, new ExcelBtnEventArgs(li));
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
                   && (clauseNode.Operation == ClauseType.AnyOf || clauseNode.Operation == ClauseType.NoneOf))
                {
                    Point p = new Point(labelInfo.NodeBounds.X + labelInfo.NodeBounds.Width,
                       labelInfo.NodeBounds.Y + (labelInfo.NodeBounds.Height - fControl.MyIcon.Height) / 2 + 2);

                    info.Graphics.DrawImage(fControl.MyIcon, p);
                }
            }
            base.DrawNodeLabel(node, info);
        }
    }
}