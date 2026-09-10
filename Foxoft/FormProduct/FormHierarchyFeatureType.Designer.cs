namespace Foxoft
{
    partial class FormHierarchyFeatureType
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormHierarchyFeatureType));
            svgImageCollection1 = new DevExpress.Utils.SvgImageCollection(components);
            ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            BBI_Save = new DevExpress.XtraBars.BarButtonItem();
            BBI_Add = new DevExpress.XtraBars.BarButtonItem();
            BBI_FilterSelected = new DevExpress.XtraBars.BarButtonItem();
            BBI_Delete = new DevExpress.XtraBars.BarButtonItem();
            BBI_Update = new DevExpress.XtraBars.BarButtonItem();
            BBI_Hierarchy = new DevExpress.XtraBars.BarButtonItem();
            ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            ribbonPageGroupOperations = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            ribbonPageGroupFilter = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            ribbonPageGroupHierarchy = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            treeListHierarchy = new DevExpress.XtraTreeList.TreeList();
            treeColHierarchyDesc = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            treeColHierarchyCode = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            panelControlRight = new DevExpress.XtraEditors.PanelControl();
            myGridControl1 = new MyGridControl();
            bindingSource1 = new BindingSource(components);
            gridView1 = new MyGridView();
            colScope = new DevExpress.XtraGrid.Columns.GridColumn();
            repoImageCombo_Scope = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            colFeatureTypeName = new DevExpress.XtraGrid.Columns.GridColumn();
            colOrder = new DevExpress.XtraGrid.Columns.GridColumn();
            repoSpin_Order = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            colFilterable = new DevExpress.XtraGrid.Columns.GridColumn();
            repoCheck_Filterable = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            lblSelectedHierarchy = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)svgImageCollection1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ribbon).BeginInit();
            ((System.ComponentModel.ISupportInitialize)splitContainerControl1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)splitContainerControl1.Panel1).BeginInit();
            splitContainerControl1.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainerControl1.Panel2).BeginInit();
            splitContainerControl1.Panel2.SuspendLayout();
            splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)treeListHierarchy).BeginInit();
            ((System.ComponentModel.ISupportInitialize)panelControlRight).BeginInit();
            panelControlRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)myGridControl1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bindingSource1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)repoImageCombo_Scope).BeginInit();
            ((System.ComponentModel.ISupportInitialize)repoSpin_Order).BeginInit();
            ((System.ComponentModel.ISupportInitialize)repoCheck_Filterable).BeginInit();
            SuspendLayout();
            // 
            // svgImageCollection1
            // 
            svgImageCollection1.Add("save", "image://svgimages/save/save.svg");
            svgImageCollection1.Add("delete", "image://svgimages/scheduling/delete.svg");
            svgImageCollection1.Add("refresh", "image://svgimages/icon builder/actions_refresh.svg");
            svgImageCollection1.Add("scope_assigned", "image://svgimages/icon builder/actions_check.svg");
            svgImageCollection1.Add("scope_global", "image://svgimages/icon builder/actions_checkcircled.svg");
            // 
            // ribbon
            // 
            ribbon.ExpandCollapseItem.Id = 0;
            ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] { ribbon.ExpandCollapseItem, BBI_Save, BBI_Add, BBI_FilterSelected, BBI_Delete, BBI_Update, BBI_Hierarchy });
            ribbon.Location = new Point(0, 0);
            ribbon.MaxItemId = 7;
            ribbon.Name = "ribbon";
            ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] { ribbonPage1 });
            ribbon.Size = new Size(1236, 158);
            ribbon.StatusBar = ribbonStatusBar;
            // 
            // BBI_Save
            // 
            BBI_Save.Caption = Properties.Resources.Common_Save;
            BBI_Save.Id = 1;
            BBI_Save.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("BBI_Save.ImageOptions.SvgImage");
            BBI_Save.ItemShortcut = new DevExpress.XtraBars.BarShortcut(Keys.Control | Keys.S);
            BBI_Save.Name = "BBI_Save";
            BBI_Save.ItemClick += BBI_Save_ItemClick;
            // 
            // BBI_Add
            // 
            BBI_Add.Caption = Properties.Resources.Common_New;
            BBI_Add.Id = 2;
            BBI_Add.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("BBI_Add.ImageOptions.SvgImage");
            BBI_Add.ItemShortcut = new DevExpress.XtraBars.BarShortcut(Keys.Control | Keys.N);
            BBI_Add.Name = "BBI_Add";
            BBI_Add.ItemClick += BBI_FeatureTypeAdd_ItemClick;
            // 
            // BBI_FilterSelected
            // 
            BBI_FilterSelected.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
            BBI_FilterSelected.Caption = Properties.Resources.Form_HierarchyFeatureType_FilterSelected;
            BBI_FilterSelected.Id = 3;
            BBI_FilterSelected.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("BBI_FilterSelected.ImageOptions.SvgImage");
            BBI_FilterSelected.Name = "BBI_FilterSelected";
            BBI_FilterSelected.ItemClick += BBI_FilterSelected_ItemClick;
            // 
            // BBI_Delete
            // 
            BBI_Delete.Caption = Properties.Resources.Common_Delete;
            BBI_Delete.Id = 4;
            BBI_Delete.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("BBI_Delete.ImageOptions.SvgImage");
            BBI_Delete.ItemShortcut = new DevExpress.XtraBars.BarShortcut(Keys.Delete);
            BBI_Delete.Name = "BBI_Delete";
            BBI_Delete.ItemClick += BBI_Delete_ItemClick;
            // 
            // BBI_Update
            // 
            BBI_Update.Caption = Properties.Resources.Common_Refresh;
            BBI_Update.Id = 5;
            BBI_Update.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("BBI_Update.ImageOptions.SvgImage");
            BBI_Update.ItemShortcut = new DevExpress.XtraBars.BarShortcut(Keys.F5);
            BBI_Update.Name = "BBI_Update";
            BBI_Update.ItemClick += BBI_Update_ItemClick;
            // 
            // BBI_Hierarchy
            // 
            BBI_Hierarchy.Caption = Properties.Resources.Form_HierarchyFeatureType_Hierarchy;
            BBI_Hierarchy.Id = 6;
            BBI_Hierarchy.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("BBI_Hierarchy.ImageOptions.SvgImage");
            BBI_Hierarchy.Name = "BBI_Hierarchy";
            BBI_Hierarchy.ItemClick += BBI_Hierarchy_ItemClick;
            // 
            // ribbonPage1
            // 
            ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] { ribbonPageGroupOperations, ribbonPageGroupFilter, ribbonPageGroupHierarchy });
            ribbonPage1.Name = "ribbonPage1";
            ribbonPage1.Text = Properties.Resources.Form_HierarchyFeatureType_Caption;
            // 
            // ribbonPageGroupOperations
            // 
            ribbonPageGroupOperations.ItemLinks.Add(BBI_Save);
            ribbonPageGroupOperations.ItemLinks.Add(BBI_Add);
            ribbonPageGroupOperations.ItemLinks.Add(BBI_Delete);
            ribbonPageGroupOperations.ItemLinks.Add(BBI_Update);
            ribbonPageGroupOperations.Name = "ribbonPageGroupOperations";
            ribbonPageGroupOperations.Text = Properties.Resources.Common_Operations;
            // 
            // ribbonPageGroupFilter
            // 
            ribbonPageGroupFilter.ItemLinks.Add(BBI_FilterSelected);
            ribbonPageGroupFilter.Name = "ribbonPageGroupFilter";
            ribbonPageGroupFilter.Text = Properties.Resources.Form_HierarchyFeatureType_RibbonGroup_Filter;
            // 
            // ribbonPageGroupHierarchy
            // 
            ribbonPageGroupHierarchy.ItemLinks.Add(BBI_Hierarchy);
            ribbonPageGroupHierarchy.Name = "ribbonPageGroupHierarchy";
            ribbonPageGroupHierarchy.Text = Properties.Resources.Form_HierarchyFeatureType_RibbonGroup_Hierarchy;
            // 
            // ribbonStatusBar
            // 
            ribbonStatusBar.Location = new Point(0, 586);
            ribbonStatusBar.Name = "ribbonStatusBar";
            ribbonStatusBar.Ribbon = ribbon;
            ribbonStatusBar.Size = new Size(1236, 24);
            // 
            // splitContainerControl1
            // 
            splitContainerControl1.Dock = DockStyle.Fill;
            splitContainerControl1.Location = new Point(0, 158);
            splitContainerControl1.Name = "splitContainerControl1";
            // 
            // splitContainerControl1.Panel1
            // 
            splitContainerControl1.Panel1.Controls.Add(treeListHierarchy);
            splitContainerControl1.Panel1.Text = "Panel1";
            // 
            // splitContainerControl1.Panel2
            // 
            splitContainerControl1.Panel2.Controls.Add(panelControlRight);
            splitContainerControl1.Panel2.Text = "Panel2";
            splitContainerControl1.Size = new Size(1236, 428);
            splitContainerControl1.SplitterPosition = 360;
            splitContainerControl1.TabIndex = 2;
            // 
            // treeListHierarchy
            // 
            treeListHierarchy.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] { treeColHierarchyDesc, treeColHierarchyCode });
            treeListHierarchy.Dock = DockStyle.Fill;
            treeListHierarchy.KeyFieldName = "HierarchyCode";
            treeListHierarchy.Location = new Point(0, 0);
            treeListHierarchy.Name = "treeListHierarchy";
            treeListHierarchy.OptionsBehavior.Editable = false;
            treeListHierarchy.OptionsFilter.ExpandNodesOnFiltering = true;
            treeListHierarchy.OptionsFind.AlwaysVisible = true;
            treeListHierarchy.OptionsFind.Behavior = DevExpress.XtraEditors.FindPanelBehavior.Filter;
            treeListHierarchy.OptionsFind.FindDelay = 150;
            treeListHierarchy.OptionsSelection.EnableAppearanceFocusedCell = false;
            treeListHierarchy.ParentFieldName = "HierarchyParentCode";
            treeListHierarchy.Size = new Size(360, 428);
            treeListHierarchy.TabIndex = 0;
            treeListHierarchy.ViewStyle = DevExpress.XtraTreeList.TreeListViewStyle.TreeView;
            treeListHierarchy.FocusedNodeChanged += treeListHierarchy_FocusedNodeChanged;
            // 
            // treeColHierarchyDesc
            // 
            treeColHierarchyDesc.Caption = "İyerarxiya";
            treeColHierarchyDesc.FieldName = "HierarchyDesc";
            treeColHierarchyDesc.Name = "treeColHierarchyDesc";
            treeColHierarchyDesc.Visible = true;
            treeColHierarchyDesc.VisibleIndex = 0;
            // 
            // treeColHierarchyCode
            // 
            treeColHierarchyCode.Caption = "Kod";
            treeColHierarchyCode.FieldName = "HierarchyCode";
            treeColHierarchyCode.Name = "treeColHierarchyCode";
            // 
            // panelControlRight
            // 
            panelControlRight.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            panelControlRight.Controls.Add(myGridControl1);
            panelControlRight.Controls.Add(lblSelectedHierarchy);
            panelControlRight.Dock = DockStyle.Fill;
            panelControlRight.Location = new Point(0, 0);
            panelControlRight.Name = "panelControlRight";
            panelControlRight.Size = new Size(866, 428);
            panelControlRight.TabIndex = 0;
            // 
            // myGridControl1
            // 
            myGridControl1.DataSource = bindingSource1;
            myGridControl1.Dock = DockStyle.Fill;
            myGridControl1.Location = new Point(0, 36);
            myGridControl1.MainView = gridView1;
            myGridControl1.MenuManager = ribbon;
            myGridControl1.Name = "myGridControl1";
            myGridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] { repoImageCombo_Scope, repoSpin_Order, repoCheck_Filterable });
            myGridControl1.Size = new Size(866, 392);
            myGridControl1.TabIndex = 1;
            myGridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gridView1 });
            // 
            // bindingSource1
            // 
            bindingSource1.DataSource = typeof(HierarchyFeatureTypeItem);
            // 
            // gridView1
            // 
            gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { colScope, colFeatureTypeName, colOrder, colFilterable });
            gridView1.GridControl = myGridControl1;
            gridView1.Name = "gridView1";
            gridView1.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.MouseDown;
            gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            gridView1.OptionsView.ShowAutoFilterRow = true;
            gridView1.OptionsView.ShowGroupPanel = false;
            gridView1.RowCellStyle += gridView1_RowCellStyle;
            gridView1.CellValueChanged += gridView1_CellValueChanged;
            gridView1.KeyDown += gridView1_KeyDown;
            // 
            // colScope
            // 
            colScope.Caption = Properties.Resources.Form_HierarchyFeatureType_Scope;
            colScope.ColumnEdit = repoImageCombo_Scope;
            colScope.FieldName = "Scope";
            colScope.MaxWidth = 180;
            colScope.MinWidth = 120;
            colScope.Name = "colScope";
            colScope.Visible = true;
            colScope.VisibleIndex = 0;
            colScope.Width = 140;
            // 
            // repoImageCombo_Scope
            // 
            repoImageCombo_Scope.AutoHeight = false;
            repoImageCombo_Scope.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            repoImageCombo_Scope.GlyphAlignment = DevExpress.Utils.HorzAlignment.Default;
            repoImageCombo_Scope.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] { new DevExpress.XtraEditors.Controls.ImageComboBoxItem(Properties.Resources.Form_HierarchyFeatureType_StatusNotAssigned, HierarchyFeatureScope.NotAssigned, 5), new DevExpress.XtraEditors.Controls.ImageComboBoxItem(Properties.Resources.Form_HierarchyFeatureType_IsAssigned, HierarchyFeatureScope.Assigned, 6), new DevExpress.XtraEditors.Controls.ImageComboBoxItem(Properties.Resources.Form_HierarchyFeatureType_IsGlobal, HierarchyFeatureScope.Global, 7) });
            repoImageCombo_Scope.Name = "repoImageCombo_Scope";
            repoImageCombo_Scope.SmallImages = svgImageCollection1;
            repoImageCombo_Scope.EditValueChanged += repoImageCombo_Scope_EditValueChanged;
            // 
            // colFeatureTypeName
            // 
            colFeatureTypeName.Caption = Properties.Resources.Entity_FeatureType_Name;
            colFeatureTypeName.FieldName = "FeatureTypeName";
            colFeatureTypeName.MinWidth = 150;
            colFeatureTypeName.Name = "colFeatureTypeName";
            colFeatureTypeName.Visible = true;
            colFeatureTypeName.VisibleIndex = 1;
            colFeatureTypeName.Width = 240;
            // 
            // colOrder
            // 
            colOrder.Caption = Properties.Resources.Entity_FeatureType_Order;
            colOrder.ColumnEdit = repoSpin_Order;
            colOrder.FieldName = "Order";
            colOrder.MaxWidth = 80;
            colOrder.MinWidth = 60;
            colOrder.Name = "colOrder";
            colOrder.Visible = true;
            colOrder.VisibleIndex = 2;
            colOrder.Width = 70;
            // 
            // repoSpin_Order
            // 
            repoSpin_Order.AutoHeight = false;
            repoSpin_Order.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            repoSpin_Order.IsFloatValue = false;
            repoSpin_Order.MaskSettings.Set("mask", "N0");
            repoSpin_Order.Name = "repoSpin_Order";
            // 
            // colFilterable
            // 
            colFilterable.Caption = Properties.Resources.Entity_FeatureType_Filterable;
            colFilterable.ColumnEdit = repoCheck_Filterable;
            colFilterable.FieldName = "Filterable";
            colFilterable.MaxWidth = 90;
            colFilterable.MinWidth = 70;
            colFilterable.Name = "colFilterable";
            colFilterable.Visible = true;
            colFilterable.VisibleIndex = 3;
            colFilterable.Width = 80;
            // 
            // repoCheck_Filterable
            // 
            repoCheck_Filterable.AutoHeight = false;
            repoCheck_Filterable.Name = "repoCheck_Filterable";
            // 
            // lblSelectedHierarchy
            // 
            lblSelectedHierarchy.Appearance.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            lblSelectedHierarchy.Appearance.Options.UseFont = true;
            lblSelectedHierarchy.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            lblSelectedHierarchy.Dock = DockStyle.Top;
            lblSelectedHierarchy.Location = new Point(0, 0);
            lblSelectedHierarchy.Name = "lblSelectedHierarchy";
            lblSelectedHierarchy.Padding = new Padding(10, 0, 10, 0);
            lblSelectedHierarchy.Size = new Size(866, 36);
            lblSelectedHierarchy.TabIndex = 0;
            lblSelectedHierarchy.Text = "İyerarxiya";
            // 
            // FormHierarchyFeatureType
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1236, 610);
            Controls.Add(splitContainerControl1);
            Controls.Add(ribbonStatusBar);
            Controls.Add(ribbon);
            Name = "FormHierarchyFeatureType";
            Ribbon = ribbon;
            StatusBar = ribbonStatusBar;
            Text = "Hierarchy Feature Types";
            FormClosing += FormHierarchyFeatureType_FormClosing;
            Load += FormHierarchyFeatureType_Load;
            ((System.ComponentModel.ISupportInitialize)svgImageCollection1).EndInit();
            ((System.ComponentModel.ISupportInitialize)ribbon).EndInit();
            ((System.ComponentModel.ISupportInitialize)splitContainerControl1.Panel1).EndInit();
            splitContainerControl1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainerControl1.Panel2).EndInit();
            splitContainerControl1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainerControl1).EndInit();
            splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)treeListHierarchy).EndInit();
            ((System.ComponentModel.ISupportInitialize)panelControlRight).EndInit();
            panelControlRight.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)myGridControl1).EndInit();
            ((System.ComponentModel.ISupportInitialize)bindingSource1).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)repoImageCombo_Scope).EndInit();
            ((System.ComponentModel.ISupportInitialize)repoSpin_Order).EndInit();
            ((System.ComponentModel.ISupportInitialize)repoCheck_Filterable).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DevExpress.Utils.SvgImageCollection svgImageCollection1;
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroupOperations;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroupFilter;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroupHierarchy;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        private DevExpress.XtraBars.BarButtonItem BBI_Save;
        private DevExpress.XtraBars.BarButtonItem BBI_Add;
        private DevExpress.XtraBars.BarButtonItem BBI_FilterSelected;
        private DevExpress.XtraBars.BarButtonItem BBI_Delete;
        private DevExpress.XtraBars.BarButtonItem BBI_Update;
        private DevExpress.XtraBars.BarButtonItem BBI_Hierarchy;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraTreeList.TreeList treeListHierarchy;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeColHierarchyDesc;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeColHierarchyCode;
        private DevExpress.XtraEditors.PanelControl panelControlRight;
        private DevExpress.XtraEditors.LabelControl lblSelectedHierarchy;
        private MyGridControl myGridControl1;
        private MyGridView gridView1;
        private System.Windows.Forms.BindingSource bindingSource1;
        private DevExpress.XtraGrid.Columns.GridColumn colScope;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repoImageCombo_Scope;
        private DevExpress.XtraGrid.Columns.GridColumn colFeatureTypeName;
        private DevExpress.XtraGrid.Columns.GridColumn colOrder;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit repoSpin_Order;
        private DevExpress.XtraGrid.Columns.GridColumn colFilterable;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repoCheck_Filterable;
    }
}
