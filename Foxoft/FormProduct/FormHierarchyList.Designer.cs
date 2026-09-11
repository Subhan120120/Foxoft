namespace Foxoft
{
    partial class FormHierarchyList
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
            barManager1 = new DevExpress.XtraBars.BarManager(components);
            barTools = new DevExpress.XtraBars.Bar();
            BBI_AddRoot = new DevExpress.XtraBars.BarButtonItem();
            BBI_AddChild = new DevExpress.XtraBars.BarButtonItem();
            BBI_AddSibling = new DevExpress.XtraBars.BarButtonItem();
            BBI_Edit = new DevExpress.XtraBars.BarButtonItem();
            BBI_Delete = new DevExpress.XtraBars.BarButtonItem();
            BBI_ExpandAll = new DevExpress.XtraBars.BarButtonItem();
            BBI_CollapseAll = new DevExpress.XtraBars.BarButtonItem();
            BBI_Refresh = new DevExpress.XtraBars.BarButtonItem();
            barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            svgImageCollection1 = new DevExpress.Utils.SvgImageCollection(components);
            treeList1 = new DevExpress.XtraTreeList.TreeList();
            treeListCol_HierarchyDesc = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            treeListCol_HierarchyCode = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            treeListCol_HierarchyParentCode = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            panelControlBottom = new DevExpress.XtraEditors.PanelControl();
            btn_Select = new DevExpress.XtraEditors.SimpleButton();
            btn_Clear = new DevExpress.XtraEditors.SimpleButton();
            btn_Cancel = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)barManager1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)svgImageCollection1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)treeList1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)panelControlBottom).BeginInit();
            panelControlBottom.SuspendLayout();
            SuspendLayout();
            // 
            // barManager1
            // 
            barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
                barTools
            });
            barManager1.DockControls.Add(barDockControlTop);
            barManager1.DockControls.Add(barDockControlBottom);
            barManager1.DockControls.Add(barDockControlLeft);
            barManager1.DockControls.Add(barDockControlRight);
            barManager1.Form = this;
            barManager1.Images = svgImageCollection1;
            barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
                BBI_AddRoot,
                BBI_AddChild,
                BBI_AddSibling,
                BBI_Edit,
                BBI_Delete,
                BBI_ExpandAll,
                BBI_CollapseAll,
                BBI_Refresh
            });
            barManager1.MaxItemId = 8;
            // 
            // barTools
            // 
            barTools.BarName = "Tools";
            barTools.DockCol = 0;
            barTools.DockRow = 0;
            barTools.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            barTools.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
                new DevExpress.XtraBars.LinkPersistInfo(BBI_AddRoot),
                new DevExpress.XtraBars.LinkPersistInfo(BBI_AddChild),
                new DevExpress.XtraBars.LinkPersistInfo(BBI_AddSibling),
                new DevExpress.XtraBars.LinkPersistInfo(BBI_Edit),
                new DevExpress.XtraBars.LinkPersistInfo(BBI_Delete),
                new DevExpress.XtraBars.LinkPersistInfo(BBI_ExpandAll, true),
                new DevExpress.XtraBars.LinkPersistInfo(BBI_CollapseAll),
                new DevExpress.XtraBars.LinkPersistInfo(BBI_Refresh, true)
            });
            barTools.OptionsBar.AllowQuickCustomization = false;
            barTools.OptionsBar.DrawDragBorder = false;
            barTools.OptionsBar.UseWholeRow = true;
            barTools.Text = "Tools";
            // 
            // BBI_AddRoot
            // 
            BBI_AddRoot.Caption = Foxoft.Properties.Resources.Form_HierarchyList_AddRoot;
            BBI_AddRoot.Id = 0;
            BBI_AddRoot.ImageOptions.ImageIndex = 1;
            BBI_AddRoot.ItemShortcut = new DevExpress.XtraBars.BarShortcut(Keys.Control | Keys.N);
            BBI_AddRoot.Name = "BBI_AddRoot";
            BBI_AddRoot.ItemClick += BBI_AddRoot_ItemClick;
            // 
            // BBI_AddChild
            // 
            BBI_AddChild.Caption = Foxoft.Properties.Resources.Form_HierarchyList_AddChild;
            BBI_AddChild.Id = 1;
            BBI_AddChild.ImageOptions.ImageIndex = 3;
            BBI_AddChild.ItemShortcut = new DevExpress.XtraBars.BarShortcut(Keys.Insert);
            BBI_AddChild.Name = "BBI_AddChild";
            BBI_AddChild.ItemClick += BBI_AddChild_ItemClick;
            // 
            // BBI_AddSibling
            // 
            BBI_AddSibling.Caption = Foxoft.Properties.Resources.Form_HierarchyList_AddSibling;
            BBI_AddSibling.Id = 2;
            BBI_AddSibling.ImageOptions.ImageIndex = 1;
            BBI_AddSibling.Name = "BBI_AddSibling";
            BBI_AddSibling.ItemClick += BBI_AddSibling_ItemClick;
            // 
            // BBI_Edit
            // 
            BBI_Edit.Caption = Foxoft.Properties.Resources.Common_Edit;
            BBI_Edit.Id = 3;
            BBI_Edit.ImageOptions.ImageIndex = 4;
            BBI_Edit.ItemShortcut = new DevExpress.XtraBars.BarShortcut(Keys.F2);
            BBI_Edit.Name = "BBI_Edit";
            BBI_Edit.ItemClick += BBI_Edit_ItemClick;
            // 
            // BBI_Delete
            // 
            BBI_Delete.Caption = Foxoft.Properties.Resources.Common_Delete;
            BBI_Delete.Id = 4;
            BBI_Delete.ImageOptions.ImageIndex = 5;
            BBI_Delete.ItemShortcut = new DevExpress.XtraBars.BarShortcut(Keys.Delete);
            BBI_Delete.Name = "BBI_Delete";
            BBI_Delete.ItemClick += BBI_Delete_ItemClick;
            // 
            // BBI_ExpandAll
            // 
            BBI_ExpandAll.Caption = Foxoft.Properties.Resources.Form_HierarchyList_ExpandAll;
            BBI_ExpandAll.Id = 5;
            BBI_ExpandAll.ImageOptions.ImageIndex = 7;
            BBI_ExpandAll.Name = "BBI_ExpandAll";
            BBI_ExpandAll.ItemClick += BBI_ExpandAll_ItemClick;
            // 
            // BBI_CollapseAll
            // 
            BBI_CollapseAll.Caption = Foxoft.Properties.Resources.Form_HierarchyList_CollapseAll;
            BBI_CollapseAll.Id = 6;
            BBI_CollapseAll.ImageOptions.ImageIndex = 8;
            BBI_CollapseAll.Name = "BBI_CollapseAll";
            BBI_CollapseAll.ItemClick += BBI_CollapseAll_ItemClick;
            // 
            // BBI_Refresh
            // 
            BBI_Refresh.Caption = Foxoft.Properties.Resources.Common_Refresh;
            BBI_Refresh.Id = 7;
            BBI_Refresh.ImageOptions.ImageIndex = 6;
            BBI_Refresh.ItemShortcut = new DevExpress.XtraBars.BarShortcut(Keys.F5);
            BBI_Refresh.Name = "BBI_Refresh";
            BBI_Refresh.ItemClick += BBI_Refresh_ItemClick;
            // 
            // barDockControlTop
            // 
            barDockControlTop.CausesValidation = false;
            barDockControlTop.Dock = DockStyle.Top;
            barDockControlTop.Location = new Point(0, 0);
            barDockControlTop.Manager = barManager1;
            barDockControlTop.Size = new Size(540, 24);
            // 
            // barDockControlBottom
            // 
            barDockControlBottom.CausesValidation = false;
            barDockControlBottom.Dock = DockStyle.Bottom;
            barDockControlBottom.Location = new Point(0, 580);
            barDockControlBottom.Manager = barManager1;
            barDockControlBottom.Size = new Size(540, 0);
            // 
            // barDockControlLeft
            // 
            barDockControlLeft.CausesValidation = false;
            barDockControlLeft.Dock = DockStyle.Left;
            barDockControlLeft.Location = new Point(0, 24);
            barDockControlLeft.Manager = barManager1;
            barDockControlLeft.Size = new Size(0, 556);
            // 
            // barDockControlRight
            // 
            barDockControlRight.CausesValidation = false;
            barDockControlRight.Dock = DockStyle.Right;
            barDockControlRight.Location = new Point(540, 24);
            barDockControlRight.Manager = barManager1;
            barDockControlRight.Size = new Size(0, 556);
            // 
            // svgImageCollection1
            // 
            svgImageCollection1.Add("open", "image://svgimages/actions/open.svg");
            svgImageCollection1.Add("add", "image://svgimages/icon builder/actions_add.svg");
            svgImageCollection1.Add("child2", "image://svgimages/spreadsheet/expandfieldpivottable.svg");
            svgImageCollection1.Add("child", "image://svgimages/icon builder/actions_addcircled.svg");
            svgImageCollection1.Add("edit", "image://svgimages/icon builder/actions_edit.svg");
            svgImageCollection1.Add("delete", "image://svgimages/icon builder/actions_delete.svg");
            svgImageCollection1.Add("refresh", "image://svgimages/icon builder/actions_refresh.svg");
            svgImageCollection1.Add("expand", "image://svgimages/spreadsheet/expandfieldpivottable.svg");
            svgImageCollection1.Add("collapse", "image://svgimages/spreadsheet/collapsefieldpivottable.svg");
            svgImageCollection1.Add("apply", "image://svgimages/icon builder/actions_check.svg");
            svgImageCollection1.Add("cancel", "image://svgimages/icon builder/actions_delete.svg");
            svgImageCollection1.Add("clear", "image://svgimages/icon builder/actions_clear.svg");
            svgImageCollection1.Add("closed", "image://svgimages/icon builder/actions_folderclose.svg");
            // 
            // treeList1
            // 
            treeList1.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
                treeListCol_HierarchyCode,
                treeListCol_HierarchyDesc,
                treeListCol_HierarchyParentCode
            });
            treeList1.Dock = DockStyle.Fill;
            treeList1.HierarchyColumn = treeListCol_HierarchyCode;
            treeList1.KeyFieldName = "HierarchyCode";
            treeList1.Location = new Point(0, 24);
            treeList1.Name = "treeList1";
            treeList1.OptionsBehavior.Editable = false;
            treeList1.OptionsDragAndDrop.DragNodesMode = DevExpress.XtraTreeList.DragNodesMode.Single;
            treeList1.OptionsFilter.ExpandNodesOnFiltering = true;
            treeList1.OptionsFind.AlwaysVisible = true;
            treeList1.OptionsFind.Behavior = DevExpress.XtraEditors.FindPanelBehavior.Filter;
            treeList1.OptionsFind.FindDelay = 150;
            treeList1.OptionsSelection.EnableAppearanceFocusedCell = false;
            treeList1.OptionsView.ShowColumns = true;
            treeList1.OptionsView.ShowIndicator = false;
            treeList1.ParentFieldName = "HierarchyParentCode";
            treeList1.Size = new Size(540, 512);
            treeList1.StateImageList = svgImageCollection1;
            treeList1.TabIndex = 0;
            treeList1.FocusedNodeChanged += treeList1_FocusedNodeChanged;
            treeList1.PopupMenuShowing += treeList1_PopupMenuShowing;
            treeList1.CellValueChanged += treeList1_CellValueChanged;
            treeList1.DoubleClick += treeList1_DoubleClick;
            treeList1.KeyDown += treeList1_KeyDown;
            treeList1.AfterDropNode += treeList1_AfterDropNode;
            treeList1.HiddenEditor += treeList1_HiddenEditor;
            treeList1.ShowingEditor += treeList1_ShowingEditor;
            // 
            // treeListCol_HierarchyCode
            // 
            treeListCol_HierarchyCode.Caption = Foxoft.Properties.Resources.Entity_Hierarchy_Code;
            treeListCol_HierarchyCode.FieldName = "HierarchyCode";
            treeListCol_HierarchyCode.Name = "treeListCol_HierarchyCode";
            treeListCol_HierarchyCode.OptionsColumn.AllowEdit = false;
            treeListCol_HierarchyCode.OptionsColumn.ReadOnly = true;
            treeListCol_HierarchyCode.Visible = true;
            treeListCol_HierarchyCode.VisibleIndex = 0;
            treeListCol_HierarchyCode.Width = 140;
            // 
            // treeListCol_HierarchyDesc
            // 
            treeListCol_HierarchyDesc.Caption = Foxoft.Properties.Resources.Entity_Hierarchy_Desc;
            treeListCol_HierarchyDesc.FieldName = "HierarchyDesc";
            treeListCol_HierarchyDesc.Name = "treeListCol_HierarchyDesc";
            treeListCol_HierarchyDesc.Visible = true;
            treeListCol_HierarchyDesc.VisibleIndex = 1;
            treeListCol_HierarchyDesc.Width = 300;
            // 
            // treeListCol_HierarchyParentCode
            // 
            treeListCol_HierarchyParentCode.FieldName = "HierarchyParentCode";
            treeListCol_HierarchyParentCode.Name = "treeListCol_HierarchyParentCode";
            // 
            // panelControlBottom
            // 
            panelControlBottom.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            panelControlBottom.Controls.Add(btn_Select);
            panelControlBottom.Controls.Add(btn_Clear);
            panelControlBottom.Controls.Add(btn_Cancel);
            panelControlBottom.Dock = DockStyle.Bottom;
            panelControlBottom.Location = new Point(0, 536);
            panelControlBottom.Name = "panelControlBottom";
            panelControlBottom.Size = new Size(540, 44);
            panelControlBottom.TabIndex = 1;
            // 
            // btn_Select
            // 
            btn_Select.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btn_Select.ImageOptions.ImageIndex = 9;
            btn_Select.ImageOptions.ImageList = svgImageCollection1;
            btn_Select.Location = new Point(265, 8);
            btn_Select.Name = "btn_Select";
            btn_Select.Size = new Size(84, 28);
            btn_Select.TabIndex = 0;
            btn_Select.Text = Foxoft.Properties.Resources.Common_Select;
            btn_Select.Click += btn_Select_Click;
            // 
            // btn_Clear
            // 
            btn_Clear.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btn_Clear.ImageOptions.ImageIndex = 11;
            btn_Clear.ImageOptions.ImageList = svgImageCollection1;
            btn_Clear.Location = new Point(355, 8);
            btn_Clear.Name = "btn_Clear";
            btn_Clear.Size = new Size(84, 28);
            btn_Clear.TabIndex = 1;
            btn_Clear.Text = Foxoft.Properties.Resources.Common_Clear;
            btn_Clear.Click += btnClear_Click;
            // 
            // btn_Cancel
            // 
            btn_Cancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btn_Cancel.DialogResult = DialogResult.Cancel;
            btn_Cancel.ImageOptions.ImageIndex = 10;
            btn_Cancel.ImageOptions.ImageList = svgImageCollection1;
            btn_Cancel.Location = new Point(445, 8);
            btn_Cancel.Name = "btn_Cancel";
            btn_Cancel.Size = new Size(84, 28);
            btn_Cancel.TabIndex = 2;
            btn_Cancel.Text = Foxoft.Properties.Resources.Common_Cancel;
            btn_Cancel.Click += btn_Cancel_Click;
            // 
            // FormHierarchyList
            // 
            AcceptButton = btn_Select;
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btn_Cancel;
            ClientSize = new Size(540, 580);
            Controls.Add(treeList1);
            Controls.Add(panelControlBottom);
            Controls.Add(barDockControlLeft);
            Controls.Add(barDockControlRight);
            Controls.Add(barDockControlBottom);
            Controls.Add(barDockControlTop);
            MinimumSize = new Size(420, 420);
            Name = "FormHierarchyList";
            StartPosition = FormStartPosition.CenterParent;
            Text = Foxoft.Properties.Resources.Form_HierarchyList_Caption;
            Load += FormTreeView_Load;
            Shown += FormTreeView_Shown;
            ((System.ComponentModel.ISupportInitialize)barManager1).EndInit();
            ((System.ComponentModel.ISupportInitialize)svgImageCollection1).EndInit();
            ((System.ComponentModel.ISupportInitialize)treeList1).EndInit();
            ((System.ComponentModel.ISupportInitialize)panelControlBottom).EndInit();
            panelControlBottom.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar barTools;
        private DevExpress.XtraBars.BarButtonItem BBI_AddRoot;
        private DevExpress.XtraBars.BarButtonItem BBI_AddChild;
        private DevExpress.XtraBars.BarButtonItem BBI_AddSibling;
        private DevExpress.XtraBars.BarButtonItem BBI_Edit;
        private DevExpress.XtraBars.BarButtonItem BBI_Delete;
        private DevExpress.XtraBars.BarButtonItem BBI_ExpandAll;
        private DevExpress.XtraBars.BarButtonItem BBI_CollapseAll;
        private DevExpress.XtraBars.BarButtonItem BBI_Refresh;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.Utils.SvgImageCollection svgImageCollection1;
        private DevExpress.XtraTreeList.TreeList treeList1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListCol_HierarchyDesc;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListCol_HierarchyCode;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListCol_HierarchyParentCode;
        private DevExpress.XtraEditors.PanelControl panelControlBottom;
        private DevExpress.XtraEditors.SimpleButton btn_Select;
        private DevExpress.XtraEditors.SimpleButton btn_Clear;
        private DevExpress.XtraEditors.SimpleButton btn_Cancel;
    }
}
