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
            ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            BBI_SelectAll = new DevExpress.XtraBars.BarButtonItem();
            BBI_ClearSelection = new DevExpress.XtraBars.BarButtonItem();
            BBI_CopyFromParent = new DevExpress.XtraBars.BarButtonItem();
            BBI_MakeGlobal = new DevExpress.XtraBars.BarButtonItem();
            BBI_ManageFeatureTypes = new DevExpress.XtraBars.BarButtonItem();
            BBI_ExpandAll = new DevExpress.XtraBars.BarButtonItem();
            BBI_CollapseAll = new DevExpress.XtraBars.BarButtonItem();
            BCI_ShowAssignedOnly = new DevExpress.XtraBars.BarCheckItem();
            BBI_Refresh = new DevExpress.XtraBars.BarButtonItem();
            BSI_Status = new DevExpress.XtraBars.BarStaticItem();
            BSI_HierarchyInfo = new DevExpress.XtraBars.BarStaticItem();
            BSI_CountInfo = new DevExpress.XtraBars.BarStaticItem();
            ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            rpgSelection = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            rpgFeatureTypes = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            rpgTreeView = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            rpgView = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            gcHierarchies = new DevExpress.XtraEditors.GroupControl();
            treeListHierarchies = new DevExpress.XtraTreeList.TreeList();
            treeListCol_HierarchyDesc = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            treeListCol_HierarchyCode = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            gcFeatureTypes = new DevExpress.XtraEditors.GroupControl();
            myGridControl1 = new MyGridControl();
            gridView1 = new MyGridView();
            colIsSelected = new DevExpress.XtraGrid.Columns.GridColumn();
            repoCheckEditSelect = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            colFeatureTypeName = new DevExpress.XtraGrid.Columns.GridColumn();
            colScope = new DevExpress.XtraGrid.Columns.GridColumn();
            colFilterable = new DevExpress.XtraGrid.Columns.GridColumn();
            repoCheckEditFilterable = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            colOrder = new DevExpress.XtraGrid.Columns.GridColumn();
            colFeatureTypeId = new DevExpress.XtraGrid.Columns.GridColumn();
            pnlHeader = new DevExpress.XtraEditors.PanelControl();
            lblHierarchyStats = new DevExpress.XtraEditors.LabelControl();
            lblHierarchyTitle = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)ribbon).BeginInit();
            ((System.ComponentModel.ISupportInitialize)splitContainerControl1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)splitContainerControl1.Panel1).BeginInit();
            splitContainerControl1.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainerControl1.Panel2).BeginInit();
            splitContainerControl1.Panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gcHierarchies).BeginInit();
            gcHierarchies.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)treeListHierarchies).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gcFeatureTypes).BeginInit();
            gcFeatureTypes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)myGridControl1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)repoCheckEditSelect).BeginInit();
            ((System.ComponentModel.ISupportInitialize)repoCheckEditFilterable).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pnlHeader).BeginInit();
            pnlHeader.SuspendLayout();
            SuspendLayout();
            // 
            // ribbon
            // 
            ribbon.ExpandCollapseItem.Id = 0;
            ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
                ribbon.ExpandCollapseItem,
                BBI_SelectAll,
                BBI_ClearSelection,
                BBI_CopyFromParent,
                BBI_MakeGlobal,
                BBI_ManageFeatureTypes,
                BBI_ExpandAll,
                BBI_CollapseAll,
                BCI_ShowAssignedOnly,
                BBI_Refresh,
                BSI_Status,
                BSI_HierarchyInfo,
                BSI_CountInfo
            });
            ribbon.Location = new System.Drawing.Point(0, 0);
            ribbon.MaxItemId = 13;
            ribbon.Name = "ribbon";
            ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
                ribbonPage1
            });
            ribbon.Size = new System.Drawing.Size(1236, 158);
            ribbon.StatusBar = ribbonStatusBar;
            // 
            // BBI_SelectAll
            // 
            BBI_SelectAll.Caption = Foxoft.Properties.Resources.Common_SelectAll;
            BBI_SelectAll.Id = 1;
            BBI_SelectAll.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("BBI_Add.ImageOptions.SvgImage");
            BBI_SelectAll.Name = "BBI_SelectAll";
            BBI_SelectAll.ItemClick += BBI_SelectAll_ItemClick;
            // 
            // BBI_ClearSelection
            // 
            BBI_ClearSelection.Caption = Foxoft.Properties.Resources.Common_Clear;
            BBI_ClearSelection.Id = 2;
            BBI_ClearSelection.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("BBI_Delete.ImageOptions.SvgImage");
            BBI_ClearSelection.Name = "BBI_ClearSelection";
            BBI_ClearSelection.ItemClick += BBI_ClearSelection_ItemClick;
            // 
            // BBI_CopyFromParent
            // 
            BBI_CopyFromParent.Caption = Foxoft.Properties.Resources.Form_HierarchyFeatureType_CopyFromParent;
            BBI_CopyFromParent.Id = 3;
            BBI_CopyFromParent.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("BBI_Update.ImageOptions.SvgImage");
            BBI_CopyFromParent.Name = "BBI_CopyFromParent";
            BBI_CopyFromParent.ItemClick += BBI_CopyFromParent_ItemClick;
            // 
            // BBI_MakeGlobal
            // 
            BBI_MakeGlobal.Caption = Foxoft.Properties.Resources.Form_HierarchyFeatureType_MakeGlobal;
            BBI_MakeGlobal.Id = 4;
            BBI_MakeGlobal.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("BBI_Update.ImageOptions.SvgImage");
            BBI_MakeGlobal.Name = "BBI_MakeGlobal";
            BBI_MakeGlobal.ItemClick += BBI_MakeGlobal_ItemClick;
            // 
            // BBI_ManageFeatureTypes
            // 
            BBI_ManageFeatureTypes.Caption = Foxoft.Properties.Resources.Form_HierarchyFeatureType_ManageFeatureTypes;
            BBI_ManageFeatureTypes.Id = 5;
            BBI_ManageFeatureTypes.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("BBI_Add.ImageOptions.SvgImage");
            BBI_ManageFeatureTypes.Name = "BBI_ManageFeatureTypes";
            BBI_ManageFeatureTypes.ItemClick += BBI_ManageFeatureTypes_ItemClick;
            // 
            // BBI_ExpandAll
            // 
            BBI_ExpandAll.Caption = Foxoft.Properties.Resources.Form_HierarchyFeatureType_ExpandAll;
            BBI_ExpandAll.Id = 6;
            BBI_ExpandAll.Name = "BBI_ExpandAll";
            BBI_ExpandAll.ItemClick += BBI_ExpandAll_ItemClick;
            // 
            // BBI_CollapseAll
            // 
            BBI_CollapseAll.Caption = Foxoft.Properties.Resources.Form_HierarchyFeatureType_CollapseAll;
            BBI_CollapseAll.Id = 7;
            BBI_CollapseAll.Name = "BBI_CollapseAll";
            BBI_CollapseAll.ItemClick += BBI_CollapseAll_ItemClick;
            // 
            // BCI_ShowAssignedOnly
            // 
            BCI_ShowAssignedOnly.Caption = Foxoft.Properties.Resources.Form_HierarchyFeatureType_AssignedOnly;
            BCI_ShowAssignedOnly.Id = 8;
            BCI_ShowAssignedOnly.Name = "BCI_ShowAssignedOnly";
            BCI_ShowAssignedOnly.CheckedChanged += BCI_ShowAssignedOnly_CheckedChanged;
            // 
            // BBI_Refresh
            // 
            BBI_Refresh.Caption = Foxoft.Properties.Resources.Common_Refresh;
            BBI_Refresh.Id = 9;
            BBI_Refresh.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("BBI_Update.ImageOptions.SvgImage");
            BBI_Refresh.Name = "BBI_Refresh";
            BBI_Refresh.ItemClick += BBI_Refresh_ItemClick;
            // 
            // BSI_Status
            // 
            BSI_Status.Caption = "";
            BSI_Status.Id = 10;
            BSI_Status.Name = "BSI_Status";
            // 
            // BSI_HierarchyInfo
            // 
            BSI_HierarchyInfo.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            BSI_HierarchyInfo.Caption = "";
            BSI_HierarchyInfo.Id = 11;
            BSI_HierarchyInfo.Name = "BSI_HierarchyInfo";
            // 
            // BSI_CountInfo
            // 
            BSI_CountInfo.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            BSI_CountInfo.Caption = "";
            BSI_CountInfo.Id = 12;
            BSI_CountInfo.Name = "BSI_CountInfo";
            // 
            // ribbonPage1
            // 
            ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
                rpgSelection,
                rpgFeatureTypes,
                rpgTreeView,
                rpgView
            });
            ribbonPage1.Name = "ribbonPage1";
            ribbonPage1.Text = Foxoft.Properties.Resources.Form_HierarchyFeatureType_Caption;
            // 
            // rpgSelection
            // 
            rpgSelection.ItemLinks.Add(BBI_SelectAll);
            rpgSelection.ItemLinks.Add(BBI_ClearSelection);
            rpgSelection.ItemLinks.Add(BBI_CopyFromParent);
            rpgSelection.Name = "rpgSelection";
            rpgSelection.Text = Foxoft.Properties.Resources.Common_Select;
            // 
            // rpgFeatureTypes
            // 
            rpgFeatureTypes.ItemLinks.Add(BBI_MakeGlobal);
            rpgFeatureTypes.ItemLinks.Add(BBI_ManageFeatureTypes);
            rpgFeatureTypes.Name = "rpgFeatureTypes";
            rpgFeatureTypes.Text = Foxoft.Properties.Resources.Form_HierarchyFeatureType_FeatureTypes;
            // 
            // rpgTreeView
            // 
            rpgTreeView.ItemLinks.Add(BBI_ExpandAll);
            rpgTreeView.ItemLinks.Add(BBI_CollapseAll);
            rpgTreeView.Name = "rpgTreeView";
            rpgTreeView.Text = Foxoft.Properties.Resources.Form_HierarchyFeatureType_TreeOperations;
            // 
            // rpgView
            // 
            rpgView.ItemLinks.Add(BCI_ShowAssignedOnly);
            rpgView.ItemLinks.Add(BBI_Refresh);
            rpgView.Name = "rpgView";
            rpgView.Text = Foxoft.Properties.Resources.Common_Operations;
            // 
            // ribbonStatusBar
            // 
            ribbonStatusBar.ItemLinks.Add(BSI_Status);
            ribbonStatusBar.ItemLinks.Add(BSI_HierarchyInfo);
            ribbonStatusBar.ItemLinks.Add(BSI_CountInfo);
            ribbonStatusBar.Location = new System.Drawing.Point(0, 586);
            ribbonStatusBar.Name = "ribbonStatusBar";
            ribbonStatusBar.Ribbon = ribbon;
            ribbonStatusBar.Size = new System.Drawing.Size(1236, 24);
            // 
            // splitContainerControl1
            // 
            splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            splitContainerControl1.Location = new System.Drawing.Point(0, 158);
            splitContainerControl1.Name = "splitContainerControl1";
            // 
            // splitContainerControl1.Panel1
            // 
            splitContainerControl1.Panel1.Controls.Add(gcHierarchies);
            splitContainerControl1.Panel1.Text = "Panel1";
            // 
            // splitContainerControl1.Panel2
            // 
            splitContainerControl1.Panel2.Controls.Add(gcFeatureTypes);
            splitContainerControl1.Panel2.Text = "Panel2";
            splitContainerControl1.Size = new System.Drawing.Size(1236, 428);
            splitContainerControl1.SplitterPosition = 400;
            splitContainerControl1.TabIndex = 2;
            // 
            // gcHierarchies
            // 
            gcHierarchies.Controls.Add(treeListHierarchies);
            gcHierarchies.Dock = System.Windows.Forms.DockStyle.Fill;
            gcHierarchies.Location = new System.Drawing.Point(0, 0);
            gcHierarchies.Name = "gcHierarchies";
            gcHierarchies.Size = new System.Drawing.Size(400, 428);
            gcHierarchies.TabIndex = 0;
            gcHierarchies.Text = Foxoft.Properties.Resources.Form_HierarchyFeatureType_Hierarchies;
            // 
            // treeListHierarchies
            // 
            treeListHierarchies.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
                treeListCol_HierarchyDesc,
                treeListCol_HierarchyCode
            });
            treeListHierarchies.Dock = System.Windows.Forms.DockStyle.Fill;
            treeListHierarchies.KeyFieldName = "HierarchyCode";
            treeListHierarchies.Location = new System.Drawing.Point(2, 23);
            treeListHierarchies.Name = "treeListHierarchies";
            treeListHierarchies.OptionsBehavior.Editable = false;
            treeListHierarchies.OptionsFilter.ExpandNodesOnFiltering = true;
            treeListHierarchies.OptionsFind.AlwaysVisible = true;
            treeListHierarchies.OptionsFind.Behavior = DevExpress.XtraEditors.FindPanelBehavior.Filter;
            treeListHierarchies.OptionsFind.FindDelay = 100;
            treeListHierarchies.OptionsMenu.ShowExpandCollapseItems = false;
            treeListHierarchies.OptionsView.ShowAutoFilterRow = false;
            treeListHierarchies.OptionsView.ShowHorzLines = true;
            treeListHierarchies.OptionsView.ShowIndicator = false;
            treeListHierarchies.OptionsView.ShowVertLines = false;
            treeListHierarchies.ParentFieldName = "HierarchyParentCode";
            treeListHierarchies.Size = new System.Drawing.Size(396, 403);
            treeListHierarchies.TabIndex = 0;
            treeListHierarchies.TreeLineStyle = DevExpress.XtraTreeList.LineStyle.Percent50;
            treeListHierarchies.FocusedNodeChanged += treeListHierarchies_FocusedNodeChanged;
            // 
            // treeListCol_HierarchyDesc
            // 
            treeListCol_HierarchyDesc.Caption = Foxoft.Properties.Resources.Entity_Hierarchy_Desc;
            treeListCol_HierarchyDesc.FieldName = "HierarchyDesc";
            treeListCol_HierarchyDesc.Name = "treeListCol_HierarchyDesc";
            treeListCol_HierarchyDesc.Visible = true;
            treeListCol_HierarchyDesc.VisibleIndex = 0;
            treeListCol_HierarchyDesc.Width = 240;
            // 
            // treeListCol_HierarchyCode
            // 
            treeListCol_HierarchyCode.Caption = Foxoft.Properties.Resources.Entity_Hierarchy_Code;
            treeListCol_HierarchyCode.FieldName = "HierarchyCode";
            treeListCol_HierarchyCode.Name = "treeListCol_HierarchyCode";
            treeListCol_HierarchyCode.Visible = true;
            treeListCol_HierarchyCode.VisibleIndex = 1;
            treeListCol_HierarchyCode.Width = 100;
            // 
            // gcFeatureTypes
            // 
            gcFeatureTypes.Controls.Add(myGridControl1);
            gcFeatureTypes.Controls.Add(pnlHeader);
            gcFeatureTypes.Dock = System.Windows.Forms.DockStyle.Fill;
            gcFeatureTypes.Location = new System.Drawing.Point(0, 0);
            gcFeatureTypes.Name = "gcFeatureTypes";
            gcFeatureTypes.Size = new System.Drawing.Size(826, 428);
            gcFeatureTypes.TabIndex = 0;
            gcFeatureTypes.Text = Foxoft.Properties.Resources.Form_HierarchyFeatureType_FeatureTypes;
            // 
            // myGridControl1
            // 
            myGridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            myGridControl1.Location = new System.Drawing.Point(2, 67);
            myGridControl1.MainView = gridView1;
            myGridControl1.MenuManager = ribbon;
            myGridControl1.Name = "myGridControl1";
            myGridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
                repoCheckEditSelect,
                repoCheckEditFilterable
            });
            myGridControl1.Size = new System.Drawing.Size(822, 359);
            myGridControl1.TabIndex = 1;
            myGridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
                gridView1
            });
            // 
            // gridView1
            // 
            gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
                colIsSelected,
                colFeatureTypeName,
                colScope,
                colFilterable,
                colOrder,
                colFeatureTypeId
            });
            gridView1.GridControl = myGridControl1;
            gridView1.Name = "gridView1";
            gridView1.OptionsFind.AlwaysVisible = true;
            gridView1.OptionsFind.Behavior = DevExpress.XtraEditors.FindPanelBehavior.Filter;
            gridView1.OptionsFind.FindDelay = 100;
            gridView1.OptionsView.ShowGroupPanel = false;
            gridView1.OptionsView.ShowIndicator = true;
            gridView1.CellValueChanged += gridView1_CellValueChanged;
            gridView1.CustomDrawRowIndicator += gridView1_CustomDrawRowIndicator;
            gridView1.RowCellStyle += gridView1_RowCellStyle;
            // 
            // colIsSelected
            // 
            colIsSelected.Caption = Foxoft.Properties.Resources.Common_Select;
            colIsSelected.ColumnEdit = repoCheckEditSelect;
            colIsSelected.FieldName = "IsSelected";
            colIsSelected.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            colIsSelected.Name = "colIsSelected";
            colIsSelected.Visible = true;
            colIsSelected.VisibleIndex = 0;
            colIsSelected.Width = 60;
            // 
            // repoCheckEditSelect
            // 
            repoCheckEditSelect.AutoHeight = false;
            repoCheckEditSelect.Name = "repoCheckEditSelect";
            repoCheckEditSelect.EditValueChanged += repoCheckEditSelect_EditValueChanged;
            // 
            // colFeatureTypeName
            // 
            colFeatureTypeName.Caption = Foxoft.Properties.Resources.Entity_FeatureType_Name;
            colFeatureTypeName.FieldName = "FeatureTypeName";
            colFeatureTypeName.Name = "colFeatureTypeName";
            colFeatureTypeName.OptionsColumn.AllowEdit = false;
            colFeatureTypeName.Visible = true;
            colFeatureTypeName.VisibleIndex = 1;
            colFeatureTypeName.Width = 240;
            // 
            // colScope
            // 
            colScope.Caption = Foxoft.Properties.Resources.Form_HierarchyFeatureType_Scope;
            colScope.FieldName = "ScopeText";
            colScope.Name = "colScope";
            colScope.OptionsColumn.AllowEdit = false;
            colScope.Visible = true;
            colScope.VisibleIndex = 2;
            colScope.Width = 160;
            // 
            // colFilterable
            // 
            colFilterable.Caption = Foxoft.Properties.Resources.Entity_FeatureType_Filterable;
            colFilterable.ColumnEdit = repoCheckEditFilterable;
            colFilterable.FieldName = "Filterable";
            colFilterable.Name = "colFilterable";
            colFilterable.OptionsColumn.AllowEdit = false;
            colFilterable.Visible = true;
            colFilterable.VisibleIndex = 3;
            colFilterable.Width = 90;
            // 
            // repoCheckEditFilterable
            // 
            repoCheckEditFilterable.AutoHeight = false;
            repoCheckEditFilterable.Name = "repoCheckEditFilterable";
            repoCheckEditFilterable.ReadOnly = true;
            // 
            // colOrder
            // 
            colOrder.Caption = Foxoft.Properties.Resources.Entity_FeatureType_Order;
            colOrder.FieldName = "Order";
            colOrder.Name = "colOrder";
            colOrder.OptionsColumn.AllowEdit = false;
            colOrder.Visible = true;
            colOrder.VisibleIndex = 4;
            colOrder.Width = 70;
            // 
            // colFeatureTypeId
            // 
            colFeatureTypeId.Caption = Foxoft.Properties.Resources.Entity_FeatureType_Id;
            colFeatureTypeId.FieldName = "FeatureTypeId";
            colFeatureTypeId.Name = "colFeatureTypeId";
            colFeatureTypeId.OptionsColumn.AllowEdit = false;
            colFeatureTypeId.Visible = false;
            colFeatureTypeId.Width = 60;
            // 
            // pnlHeader
            // 
            pnlHeader.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            pnlHeader.Controls.Add(lblHierarchyStats);
            pnlHeader.Controls.Add(lblHierarchyTitle);
            pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            pnlHeader.Location = new System.Drawing.Point(2, 23);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new System.Drawing.Size(822, 44);
            pnlHeader.TabIndex = 0;
            // 
            // lblHierarchyStats
            // 
            lblHierarchyStats.Appearance.ForeColor = System.Drawing.Color.Gray;
            lblHierarchyStats.Appearance.Options.UseForeColor = true;
            lblHierarchyStats.Location = new System.Drawing.Point(12, 25);
            lblHierarchyStats.Name = "lblHierarchyStats";
            lblHierarchyStats.Size = new System.Drawing.Size(0, 13);
            lblHierarchyStats.TabIndex = 1;
            // 
            // lblHierarchyTitle
            // 
            lblHierarchyTitle.AllowHtmlString = true;
            lblHierarchyTitle.Appearance.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            lblHierarchyTitle.Appearance.Options.UseFont = true;
            lblHierarchyTitle.Location = new System.Drawing.Point(12, 5);
            lblHierarchyTitle.Name = "lblHierarchyTitle";
            lblHierarchyTitle.Size = new System.Drawing.Size(0, 17);
            lblHierarchyTitle.TabIndex = 0;
            // 
            // FormHierarchyFeatureType
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1236, 610);
            Controls.Add(splitContainerControl1);
            Controls.Add(ribbonStatusBar);
            Controls.Add(ribbon);
            Name = "FormHierarchyFeatureType";
            Ribbon = ribbon;
            StatusBar = ribbonStatusBar;
            Text = Foxoft.Properties.Resources.Form_HierarchyFeatureType_Caption;
            ((System.ComponentModel.ISupportInitialize)ribbon).EndInit();
            ((System.ComponentModel.ISupportInitialize)splitContainerControl1.Panel1).EndInit();
            splitContainerControl1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainerControl1.Panel2).EndInit();
            splitContainerControl1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainerControl1).EndInit();
            splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)gcHierarchies).EndInit();
            gcHierarchies.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)treeListHierarchies).EndInit();
            ((System.ComponentModel.ISupportInitialize)gcFeatureTypes).EndInit();
            gcFeatureTypes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)myGridControl1).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)repoCheckEditSelect).EndInit();
            ((System.ComponentModel.ISupportInitialize)repoCheckEditFilterable).EndInit();
            ((System.ComponentModel.ISupportInitialize)pnlHeader).EndInit();
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rpgSelection;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rpgFeatureTypes;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rpgTreeView;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rpgView;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        private DevExpress.XtraBars.BarButtonItem BBI_SelectAll;
        private DevExpress.XtraBars.BarButtonItem BBI_ClearSelection;
        private DevExpress.XtraBars.BarButtonItem BBI_CopyFromParent;
        private DevExpress.XtraBars.BarButtonItem BBI_MakeGlobal;
        private DevExpress.XtraBars.BarButtonItem BBI_ManageFeatureTypes;
        private DevExpress.XtraBars.BarButtonItem BBI_ExpandAll;
        private DevExpress.XtraBars.BarButtonItem BBI_CollapseAll;
        private DevExpress.XtraBars.BarCheckItem BCI_ShowAssignedOnly;
        private DevExpress.XtraBars.BarButtonItem BBI_Refresh;
        private DevExpress.XtraBars.BarStaticItem BSI_Status;
        private DevExpress.XtraBars.BarStaticItem BSI_HierarchyInfo;
        private DevExpress.XtraBars.BarStaticItem BSI_CountInfo;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraEditors.GroupControl gcHierarchies;
        private DevExpress.XtraTreeList.TreeList treeListHierarchies;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListCol_HierarchyDesc;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListCol_HierarchyCode;
        private DevExpress.XtraEditors.GroupControl gcFeatureTypes;
        private DevExpress.XtraEditors.PanelControl pnlHeader;
        private DevExpress.XtraEditors.LabelControl lblHierarchyTitle;
        private DevExpress.XtraEditors.LabelControl lblHierarchyStats;
        private MyGridControl myGridControl1;
        private MyGridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colIsSelected;
        private DevExpress.XtraGrid.Columns.GridColumn colFeatureTypeName;
        private DevExpress.XtraGrid.Columns.GridColumn colScope;
        private DevExpress.XtraGrid.Columns.GridColumn colFilterable;
        private DevExpress.XtraGrid.Columns.GridColumn colOrder;
        private DevExpress.XtraGrid.Columns.GridColumn colFeatureTypeId;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repoCheckEditSelect;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repoCheckEditFilterable;
    }
}
