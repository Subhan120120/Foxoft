using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraLayout;
using DevExpress.XtraTab;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Columns;
using Foxoft.Models;
using Foxoft.Properties;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Foxoft
{
    partial class FormCurrAccPermission
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            components = new Container();
            ComponentResourceManager resources = new ComponentResourceManager(typeof(FormCurrAccPermission));

            // Ribbon
            ribbon = new RibbonControl();
            BBI_Save = new BarButtonItem();
            BBI_Refresh = new BarButtonItem();
            BBI_SelectAllRoles = new BarButtonItem();
            BBI_UnselectAllRoles = new BarButtonItem();
            BBI_NewRole = new BarButtonItem();
            BBI_EditRole = new BarButtonItem();
            BBI_DeleteRole = new BarButtonItem();
            BBI_RoleClaimsWindow = new BarButtonItem();
            ribbonPage1 = new RibbonPage();
            ribbonPageGroup1 = new RibbonPageGroup();
            ribbonPageGroup2 = new RibbonPageGroup();
            ribbonStatusBar = new RibbonStatusBar();

            // Splitter
            splitterControl1 = new SplitterControl();

            // Left Layout Control & Components
            layoutControl1 = new LayoutControl();
            Root = new LayoutControlGroup();
            btnEdit_CurrAccCode = new ButtonEdit();
            txt_CurrAccDesc = new TextEdit();
            gridControl_Roles = new MyGridControl();
            gV_Roles = new MyGridView();
            col_IsAssigned = new GridColumn();
            repoCheckEditRole = new RepositoryItemCheckEdit();
            col_RoleCode = new GridColumn();
            col_RoleDesc = new GridColumn();
            btn_SaveRoles = new SimpleButton();
            bindingSourceRoles = new BindingSource(components);

            layoutControlItemCurrAccCode = new LayoutControlItem();
            layoutControlItemCurrAccDesc = new LayoutControlItem();
            groupRoles = new LayoutControlGroup();
            layoutControlItemRolesGrid = new LayoutControlItem();
            layoutControlItemSaveRoles = new LayoutControlItem();

            // Right Tab Control & Components
            xtraTabControl1 = new XtraTabControl();
            tab_RoleClaims = new XtraTabPage();
            panelControlRoleTop = new PanelControl();
            lbl_SelectedRole = new LabelControl();
            btn_SaveRoleClaims = new SimpleButton();
            btn_SelectAllClaims = new SimpleButton();
            btn_UnselectAllClaims = new SimpleButton();
            btn_ExpandAllClaims = new SimpleButton();
            btn_CollapseAllClaims = new SimpleButton();
            btn_OpenClaimsWindow = new SimpleButton();
            treeListRoleClaims = new TreeList();
            colRC_IsSelected = new TreeListColumn();
            repoCheckEditRoleClaim = new RepositoryItemCheckEdit();
            colRC_CategoryDesc = new TreeListColumn();
            colRC_ClaimDesc = new TreeListColumn();
            colRC_ClaimCode = new TreeListColumn();
            colRC_CategoryId = new TreeListColumn();
            colRC_CategoryParentId = new TreeListColumn();
            colRC_IsCategory = new TreeListColumn();

            tab_EffectiveClaims = new XtraTabPage();
            panelControlEffectiveTop = new PanelControl();
            lbl_EffectiveSummary = new LabelControl();
            btn_RefreshEffective = new SimpleButton();
            btn_ExpandAllEffective = new SimpleButton();
            btn_CollapseAllEffective = new SimpleButton();
            treeListEffectiveClaims = new TreeList();
            colEff_IsSelected = new TreeListColumn();
            repoCheckEditEffective = new RepositoryItemCheckEdit();
            colEff_CategoryDesc = new TreeListColumn();
            colEff_ClaimDesc = new TreeListColumn();
            colEff_ClaimCode = new TreeListColumn();
            colEff_CategoryId = new TreeListColumn();
            colEff_CategoryParentId = new TreeListColumn();
            colEff_IsCategory = new TreeListColumn();

            tab_ReportClaims = new XtraTabPage();
            panelControlReportTop = new PanelControl();
            lbl_ClaimReport = new LabelControl();
            btnEdit_ClaimReport = new ButtonEdit();
            btn_ClaimReportSave = new SimpleButton();
            treeListReportClaims = new TreeList();
            colReport_IsSelected = new TreeListColumn();
            repoCheckEditReport = new RepositoryItemCheckEdit();
            colReport_ReportId = new TreeListColumn();
            colReport_ReportName = new TreeListColumn();
            colReport_ClaimCode = new TreeListColumn();

            // ----------------------------------------------------
            // Ribbon Initialization
            // ----------------------------------------------------
            ((ISupportInitialize)ribbon).BeginInit();
            ribbon.ExpandCollapseItem.Id = 0;
            ribbon.Items.AddRange(new BarItem[] {
                ribbon.ExpandCollapseItem,
                BBI_Save,
                BBI_Refresh,
                BBI_SelectAllRoles,
                BBI_UnselectAllRoles,
                BBI_NewRole,
                BBI_EditRole,
                BBI_DeleteRole,
                BBI_RoleClaimsWindow
            });
            ribbon.Location = new Point(0, 0);
            ribbon.MaxItemId = 12;
            ribbon.Name = "ribbon";
            ribbon.Pages.AddRange(new RibbonPage[] { ribbonPage1 });
            ribbon.Size = new Size(1350, 158);
            ribbon.StatusBar = ribbonStatusBar;

            // BBI_Save
            BBI_Save.Caption = Resources.Common_Save;
            BBI_Save.Id = 1;
            BBI_Save.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("BBI_Add.ImageOptions.SvgImage");
            BBI_Save.Name = "BBI_Save";
            BBI_Save.ItemClick += BBI_Save_ItemClick;

            // BBI_Refresh
            BBI_Refresh.Caption = Resources.Common_Refresh;
            BBI_Refresh.Id = 2;
            BBI_Refresh.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("BBI_EditCurrAccRole.ImageOptions.SvgImage");
            BBI_Refresh.Name = "BBI_Refresh";
            BBI_Refresh.ItemClick += BBI_Refresh_ItemClick;

            // BBI_SelectAllRoles
            BBI_SelectAllRoles.Caption = Resources.Common_SelectAll;
            BBI_SelectAllRoles.Id = 3;
            BBI_SelectAllRoles.Name = "BBI_SelectAllRoles";
            BBI_SelectAllRoles.ItemClick += BBI_SelectAllRoles_ItemClick;

            // BBI_UnselectAllRoles
            BBI_UnselectAllRoles.Caption = Resources.Common_UnselectAll;
            BBI_UnselectAllRoles.Id = 4;
            BBI_UnselectAllRoles.Name = "BBI_UnselectAllRoles";
            BBI_UnselectAllRoles.ItemClick += BBI_UnselectAllRoles_ItemClick;

            // BBI_NewRole
            BBI_NewRole.Caption = Resources.Form_CurrAccProfile_NewRole;
            BBI_NewRole.Id = 5;
            BBI_NewRole.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("BBI_Add.ImageOptions.SvgImage");
            BBI_NewRole.Name = "BBI_NewRole";
            BBI_NewRole.ItemClick += BBI_NewRole_ItemClick;

            // BBI_EditRole
            BBI_EditRole.Caption = Resources.Form_CurrAccProfile_EditRole;
            BBI_EditRole.Id = 6;
            BBI_EditRole.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("BBI_EditCurrAccRole.ImageOptions.SvgImage");
            BBI_EditRole.Name = "BBI_EditRole";
            BBI_EditRole.ItemClick += BBI_EditRole_ItemClick;

            // BBI_DeleteRole
            BBI_DeleteRole.Caption = Resources.Form_CurrAccProfile_DeleteRole;
            BBI_DeleteRole.Id = 7;
            BBI_DeleteRole.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("BBI_Delete.ImageOptions.SvgImage");
            BBI_DeleteRole.Name = "BBI_DeleteRole";
            BBI_DeleteRole.ItemClick += BBI_DeleteRole_ItemClick;

            // BBI_RoleClaimsWindow
            BBI_RoleClaimsWindow.Caption = Resources.Form_CurrAccProfile_Button_Permissions;
            BBI_RoleClaimsWindow.Id = 8;
            BBI_RoleClaimsWindow.Name = "BBI_RoleClaimsWindow";
            BBI_RoleClaimsWindow.ItemClick += BBI_RoleClaimsWindow_ItemClick;

            // ribbonPage1
            ribbonPage1.Groups.AddRange(new RibbonPageGroup[] { ribbonPageGroup1, ribbonPageGroup2 });
            ribbonPage1.Name = "ribbonPage1";
            ribbonPage1.Text = Resources.Form_CurrAccProfile_RibbonPage_Main;

            // ribbonPageGroup1
            ribbonPageGroup1.ItemLinks.Add(BBI_Save);
            ribbonPageGroup1.ItemLinks.Add(BBI_Refresh);
            ribbonPageGroup1.ItemLinks.Add(BBI_SelectAllRoles);
            ribbonPageGroup1.ItemLinks.Add(BBI_UnselectAllRoles);
            ribbonPageGroup1.Name = "ribbonPageGroup1";
            ribbonPageGroup1.Text = Resources.Form_CurrAccProfile_RibbonGroup_CurrAccRole;

            // ribbonPageGroup2
            ribbonPageGroup2.ItemLinks.Add(BBI_NewRole);
            ribbonPageGroup2.ItemLinks.Add(BBI_EditRole);
            ribbonPageGroup2.ItemLinks.Add(BBI_DeleteRole);
            ribbonPageGroup2.ItemLinks.Add(BBI_RoleClaimsWindow);
            ribbonPageGroup2.Name = "ribbonPageGroup2";
            ribbonPageGroup2.Text = Resources.Form_CurrAccProfile_RibbonGroup_RoleClaim;

            // ribbonStatusBar
            ribbonStatusBar.Location = new Point(0, 720);
            ribbonStatusBar.Name = "ribbonStatusBar";
            ribbonStatusBar.Ribbon = ribbon;
            ribbonStatusBar.Size = new Size(1350, 24);

            // ----------------------------------------------------
            // Left Panel (layoutControl1)
            // ----------------------------------------------------
            ((ISupportInitialize)layoutControl1).BeginInit();
            layoutControl1.SuspendLayout();
            ((ISupportInitialize)btnEdit_CurrAccCode.Properties).BeginInit();
            ((ISupportInitialize)txt_CurrAccDesc.Properties).BeginInit();
            ((ISupportInitialize)gridControl_Roles).BeginInit();
            ((ISupportInitialize)gV_Roles).BeginInit();
            ((ISupportInitialize)repoCheckEditRole).BeginInit();
            ((ISupportInitialize)bindingSourceRoles).BeginInit();
            ((ISupportInitialize)Root).BeginInit();
            ((ISupportInitialize)groupRoles).BeginInit();

            layoutControl1.Controls.Add(btnEdit_CurrAccCode);
            layoutControl1.Controls.Add(txt_CurrAccDesc);
            layoutControl1.Controls.Add(gridControl_Roles);
            layoutControl1.Controls.Add(btn_SaveRoles);
            layoutControl1.Dock = DockStyle.Left;
            layoutControl1.Location = new Point(0, 158);
            layoutControl1.Name = "layoutControl1";
            layoutControl1.Root = Root;
            layoutControl1.Size = new Size(480, 562);
            layoutControl1.TabIndex = 1;

            // Root
            Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            Root.GroupBordersVisible = false;
            Root.Items.AddRange(new BaseLayoutItem[] {
                layoutControlItemCurrAccCode,
                layoutControlItemCurrAccDesc,
                groupRoles
            });
            Root.Name = "Root";
            Root.Size = new Size(480, 562);
            Root.TextVisible = false;

            // btnEdit_CurrAccCode
            btnEdit_CurrAccCode.Location = new Point(110, 12);
            btnEdit_CurrAccCode.MenuManager = ribbon;
            btnEdit_CurrAccCode.Name = "btnEdit_CurrAccCode";
            btnEdit_CurrAccCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                new DevExpress.XtraEditors.Controls.EditorButton()
            });
            btnEdit_CurrAccCode.Size = new Size(358, 20);
            btnEdit_CurrAccCode.StyleController = layoutControl1;
            btnEdit_CurrAccCode.TabIndex = 0;
            btnEdit_CurrAccCode.ButtonPressed += btnEdit_CurrAccCode_ButtonPressed;
            btnEdit_CurrAccCode.EditValueChanged += btnEdit_CurrAccCode_EditValueChanged;

            layoutControlItemCurrAccCode.Control = btnEdit_CurrAccCode;
            layoutControlItemCurrAccCode.Location = new Point(0, 0);
            layoutControlItemCurrAccCode.Name = "layoutControlItemCurrAccCode";
            layoutControlItemCurrAccCode.Size = new Size(460, 24);
            layoutControlItemCurrAccCode.Text = Resources.Entity_CurrAcc + ":";
            layoutControlItemCurrAccCode.TextSize = new Size(90, 13);

            // txt_CurrAccDesc
            txt_CurrAccDesc.Location = new Point(110, 36);
            txt_CurrAccDesc.MenuManager = ribbon;
            txt_CurrAccDesc.Name = "txt_CurrAccDesc";
            txt_CurrAccDesc.Properties.ReadOnly = true;
            txt_CurrAccDesc.Size = new Size(358, 20);
            txt_CurrAccDesc.StyleController = layoutControl1;
            txt_CurrAccDesc.TabIndex = 1;

            layoutControlItemCurrAccDesc.Control = txt_CurrAccDesc;
            layoutControlItemCurrAccDesc.Location = new Point(0, 24);
            layoutControlItemCurrAccDesc.Name = "layoutControlItemCurrAccDesc";
            layoutControlItemCurrAccDesc.Size = new Size(460, 24);
            layoutControlItemCurrAccDesc.Text = Resources.Entity_CurrAcc_Desc + ":";
            layoutControlItemCurrAccDesc.TextSize = new Size(90, 13);

            // groupRoles
            groupRoles.Items.AddRange(new BaseLayoutItem[] {
                layoutControlItemRolesGrid,
                layoutControlItemSaveRoles
            });
            groupRoles.Location = new Point(0, 48);
            groupRoles.Name = "groupRoles";
            groupRoles.Size = new Size(460, 494);
            groupRoles.Text = Resources.Form_CurrAccProfile_RolesGroup;

            // bindingSourceRoles
            bindingSourceRoles.DataSource = typeof(CurrAccRoleVM);

            // gridControl_Roles
            gridControl_Roles.DataSource = bindingSourceRoles;
            gridControl_Roles.Location = new Point(24, 93);
            gridControl_Roles.MainView = gV_Roles;
            gridControl_Roles.MenuManager = ribbon;
            gridControl_Roles.Name = "gridControl_Roles";
            gridControl_Roles.RepositoryItems.AddRange(new RepositoryItem[] { repoCheckEditRole });
            gridControl_Roles.Size = new Size(432, 419);
            gridControl_Roles.TabIndex = 2;
            gridControl_Roles.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gV_Roles });

            // gV_Roles
            gV_Roles.Columns.AddRange(new GridColumn[] { col_IsAssigned, col_RoleCode, col_RoleDesc });
            gV_Roles.GridControl = gridControl_Roles;
            gV_Roles.Name = "gV_Roles";
            gV_Roles.OptionsView.ShowGroupPanel = false;
            gV_Roles.OptionsView.ShowIndicator = false;
            gV_Roles.FocusedRowChanged += gV_Roles_FocusedRowChanged;
            gV_Roles.CellValueChanged += gV_Roles_CellValueChanged;

            // col_IsAssigned
            col_IsAssigned.Caption = Resources.Form_CurrAccProfile_Assigned;
            col_IsAssigned.ColumnEdit = repoCheckEditRole;
            col_IsAssigned.FieldName = "IsAssigned";
            col_IsAssigned.Name = "col_IsAssigned";
            col_IsAssigned.Visible = true;
            col_IsAssigned.VisibleIndex = 0;
            col_IsAssigned.Width = 65;

            // repoCheckEditRole
            repoCheckEditRole.AutoHeight = false;
            repoCheckEditRole.Name = "repoCheckEditRole";
            repoCheckEditRole.EditValueChanged += repoCheckEditRole_EditValueChanged;

            // col_RoleCode
            col_RoleCode.Caption = Resources.Entity_Role_Code;
            col_RoleCode.FieldName = "RoleCode";
            col_RoleCode.Name = "col_RoleCode";
            col_RoleCode.OptionsColumn.AllowEdit = false;
            col_RoleCode.Visible = true;
            col_RoleCode.VisibleIndex = 1;
            col_RoleCode.Width = 110;

            // col_RoleDesc
            col_RoleDesc.Caption = Resources.Entity_Role_Desc;
            col_RoleDesc.FieldName = "RoleDesc";
            col_RoleDesc.Name = "col_RoleDesc";
            col_RoleDesc.OptionsColumn.AllowEdit = false;
            col_RoleDesc.Visible = true;
            col_RoleDesc.VisibleIndex = 2;
            col_RoleDesc.Width = 240;

            layoutControlItemRolesGrid.Control = gridControl_Roles;
            layoutControlItemRolesGrid.Location = new Point(0, 0);
            layoutControlItemRolesGrid.Name = "layoutControlItemRolesGrid";
            layoutControlItemRolesGrid.Size = new Size(436, 423);
            layoutControlItemRolesGrid.TextVisible = false;

            // btn_SaveRoles
            btn_SaveRoles.Location = new Point(24, 516);
            btn_SaveRoles.Name = "btn_SaveRoles";
            btn_SaveRoles.Size = new Size(432, 22);
            btn_SaveRoles.StyleController = layoutControl1;
            btn_SaveRoles.TabIndex = 3;
            btn_SaveRoles.Text = Resources.Form_CurrAccProfile_SaveRoles;
            btn_SaveRoles.Click += btn_SaveRoles_Click;

            layoutControlItemSaveRoles.Control = btn_SaveRoles;
            layoutControlItemSaveRoles.Location = new Point(0, 423);
            layoutControlItemSaveRoles.Name = "layoutControlItemSaveRoles";
            layoutControlItemSaveRoles.Size = new Size(436, 26);
            layoutControlItemSaveRoles.TextVisible = false;

            // ----------------------------------------------------
            // Splitter
            // ----------------------------------------------------
            splitterControl1.Dock = DockStyle.Left;
            splitterControl1.Location = new Point(480, 158);
            splitterControl1.Name = "splitterControl1";
            splitterControl1.Size = new Size(10, 562);
            splitterControl1.TabIndex = 2;
            splitterControl1.TabStop = false;

            // ----------------------------------------------------
            // Right Tab Control (xtraTabControl1)
            // ----------------------------------------------------
            ((ISupportInitialize)xtraTabControl1).BeginInit();
            xtraTabControl1.SuspendLayout();
            tab_RoleClaims.SuspendLayout();
            tab_EffectiveClaims.SuspendLayout();
            tab_ReportClaims.SuspendLayout();
            ((ISupportInitialize)panelControlRoleTop).BeginInit();
            panelControlRoleTop.SuspendLayout();
            ((ISupportInitialize)treeListRoleClaims).BeginInit();
            ((ISupportInitialize)repoCheckEditRoleClaim).BeginInit();
            ((ISupportInitialize)panelControlEffectiveTop).BeginInit();
            panelControlEffectiveTop.SuspendLayout();
            ((ISupportInitialize)treeListEffectiveClaims).BeginInit();
            ((ISupportInitialize)repoCheckEditEffective).BeginInit();
            ((ISupportInitialize)panelControlReportTop).BeginInit();
            panelControlReportTop.SuspendLayout();
            ((ISupportInitialize)btnEdit_ClaimReport.Properties).BeginInit();
            ((ISupportInitialize)treeListReportClaims).BeginInit();
            ((ISupportInitialize)repoCheckEditReport).BeginInit();

            xtraTabControl1.Dock = DockStyle.Fill;
            xtraTabControl1.Location = new Point(490, 158);
            xtraTabControl1.Name = "xtraTabControl1";
            xtraTabControl1.SelectedTabPage = tab_RoleClaims;
            xtraTabControl1.Size = new Size(860, 562);
            xtraTabControl1.TabPages.AddRange(new XtraTabPage[] {
                tab_RoleClaims,
                tab_EffectiveClaims,
                tab_ReportClaims
            });
            xtraTabControl1.TabIndex = 3;
            xtraTabControl1.SelectedPageChanged += xtraTabControl1_SelectedPageChanged;

            // ====================================================
            // Tab 1: tab_RoleClaims
            // ====================================================
            tab_RoleClaims.Controls.Add(treeListRoleClaims);
            tab_RoleClaims.Controls.Add(panelControlRoleTop);
            tab_RoleClaims.Name = "tab_RoleClaims";
            tab_RoleClaims.Size = new Size(858, 537);
            tab_RoleClaims.Text = Resources.Form_CurrAccProfile_Tab_RoleClaims;

            // panelControlRoleTop
            panelControlRoleTop.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            panelControlRoleTop.Controls.Add(lbl_SelectedRole);
            panelControlRoleTop.Controls.Add(btn_SaveRoleClaims);
            panelControlRoleTop.Controls.Add(btn_SelectAllClaims);
            panelControlRoleTop.Controls.Add(btn_UnselectAllClaims);
            panelControlRoleTop.Controls.Add(btn_ExpandAllClaims);
            panelControlRoleTop.Controls.Add(btn_CollapseAllClaims);
            panelControlRoleTop.Controls.Add(btn_OpenClaimsWindow);
            panelControlRoleTop.Dock = DockStyle.Top;
            panelControlRoleTop.Location = new Point(0, 0);
            panelControlRoleTop.Name = "panelControlRoleTop";
            panelControlRoleTop.Size = new Size(858, 38);
            panelControlRoleTop.TabIndex = 0;

            // lbl_SelectedRole
            lbl_SelectedRole.Appearance.Font = new Font("Tahoma", 8.25F, FontStyle.Bold);
            lbl_SelectedRole.Appearance.Options.UseFont = true;
            lbl_SelectedRole.Location = new Point(10, 12);
            lbl_SelectedRole.Name = "lbl_SelectedRole";
            lbl_SelectedRole.Size = new Size(95, 13);
            lbl_SelectedRole.TabIndex = 0;
            lbl_SelectedRole.Text = Resources.Form_CurrAccProfile_NoRoleSelected;

            // btn_SaveRoleClaims
            btn_SaveRoleClaims.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btn_SaveRoleClaims.Location = new Point(270, 7);
            btn_SaveRoleClaims.Name = "btn_SaveRoleClaims";
            btn_SaveRoleClaims.Size = new Size(115, 24);
            btn_SaveRoleClaims.TabIndex = 1;
            btn_SaveRoleClaims.Text = Resources.Form_CurrAccProfile_SaveRoleClaims;
            btn_SaveRoleClaims.Click += btn_SaveRoleClaims_Click;

            // btn_SelectAllClaims
            btn_SelectAllClaims.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btn_SelectAllClaims.Location = new Point(390, 7);
            btn_SelectAllClaims.Name = "btn_SelectAllClaims";
            btn_SelectAllClaims.Size = new Size(85, 24);
            btn_SelectAllClaims.TabIndex = 2;
            btn_SelectAllClaims.Text = Resources.Common_SelectAll;
            btn_SelectAllClaims.Click += btn_SelectAllClaims_Click;

            // btn_UnselectAllClaims
            btn_UnselectAllClaims.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btn_UnselectAllClaims.Location = new Point(480, 7);
            btn_UnselectAllClaims.Name = "btn_UnselectAllClaims";
            btn_UnselectAllClaims.Size = new Size(95, 24);
            btn_UnselectAllClaims.TabIndex = 3;
            btn_UnselectAllClaims.Text = Resources.Common_UnselectAll;
            btn_UnselectAllClaims.Click += btn_UnselectAllClaims_Click;

            // btn_ExpandAllClaims
            btn_ExpandAllClaims.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btn_ExpandAllClaims.Location = new Point(580, 7);
            btn_ExpandAllClaims.Name = "btn_ExpandAllClaims";
            btn_ExpandAllClaims.Size = new Size(85, 24);
            btn_ExpandAllClaims.TabIndex = 4;
            btn_ExpandAllClaims.Text = Resources.Common_ExpandAll;
            btn_ExpandAllClaims.Click += btn_ExpandAllClaims_Click;

            // btn_CollapseAllClaims
            btn_CollapseAllClaims.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btn_CollapseAllClaims.Location = new Point(670, 7);
            btn_CollapseAllClaims.Name = "btn_CollapseAllClaims";
            btn_CollapseAllClaims.Size = new Size(85, 24);
            btn_CollapseAllClaims.TabIndex = 5;
            btn_CollapseAllClaims.Text = Resources.Common_CollapseAll;
            btn_CollapseAllClaims.Click += btn_CollapseAllClaims_Click;

            // btn_OpenClaimsWindow
            btn_OpenClaimsWindow.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btn_OpenClaimsWindow.Location = new Point(760, 7);
            btn_OpenClaimsWindow.Name = "btn_OpenClaimsWindow";
            btn_OpenClaimsWindow.Size = new Size(90, 24);
            btn_OpenClaimsWindow.TabIndex = 6;
            btn_OpenClaimsWindow.Text = Resources.Form_CurrAccProfile_Button_Permissions;
            btn_OpenClaimsWindow.Click += btn_OpenClaimsWindow_Click;

            // treeListRoleClaims
            treeListRoleClaims.Columns.AddRange(new TreeListColumn[] {
                colRC_IsSelected,
                colRC_CategoryDesc,
                colRC_ClaimDesc,
                colRC_ClaimCode,
                colRC_CategoryId,
                colRC_CategoryParentId,
                colRC_IsCategory
            });
            treeListRoleClaims.Dock = DockStyle.Fill;
            treeListRoleClaims.KeyFieldName = "CategoryId";
            treeListRoleClaims.Location = new Point(0, 38);
            treeListRoleClaims.Name = "treeListRoleClaims";
            treeListRoleClaims.OptionsFilter.ExpandNodesOnFiltering = true;
            treeListRoleClaims.OptionsFind.AlwaysVisible = true;
            treeListRoleClaims.OptionsFind.Behavior = FindPanelBehavior.Filter;
            treeListRoleClaims.OptionsSelection.EnableAppearanceFocusedRow = true;
            treeListRoleClaims.OptionsView.AutoWidth = true;
            treeListRoleClaims.ParentFieldName = "CategoryParentId";
            treeListRoleClaims.RepositoryItems.AddRange(new RepositoryItem[] { repoCheckEditRoleClaim });
            treeListRoleClaims.Size = new Size(858, 499);
            treeListRoleClaims.TabIndex = 1;
            treeListRoleClaims.CellValueChanged += treeListRoleClaims_CellValueChanged;

            // colRC_IsSelected
            colRC_IsSelected.Caption = Resources.Common_Select;
            colRC_IsSelected.ColumnEdit = repoCheckEditRoleClaim;
            colRC_IsSelected.FieldName = "IsSelected";
            colRC_IsSelected.Name = "colRC_IsSelected";
            colRC_IsSelected.Visible = true;
            colRC_IsSelected.VisibleIndex = 0;
            colRC_IsSelected.Width = 60;

            // repoCheckEditRoleClaim
            repoCheckEditRoleClaim.AutoHeight = false;
            repoCheckEditRoleClaim.Name = "repoCheckEditRoleClaim";
            repoCheckEditRoleClaim.EditValueChanged += repoCheckEditRoleClaim_EditValueChanged;

            // colRC_CategoryDesc
            colRC_CategoryDesc.Caption = Resources.Entity_ClaimCategory;
            colRC_CategoryDesc.FieldName = "CategoryDesc";
            colRC_CategoryDesc.Name = "colRC_CategoryDesc";
            colRC_CategoryDesc.OptionsColumn.AllowEdit = false;
            colRC_CategoryDesc.Visible = true;
            colRC_CategoryDesc.VisibleIndex = 1;
            colRC_CategoryDesc.Width = 200;

            // colRC_ClaimDesc
            colRC_ClaimDesc.Caption = Resources.Entity_Claim_Desc;
            colRC_ClaimDesc.FieldName = "ClaimDesc";
            colRC_ClaimDesc.Name = "colRC_ClaimDesc";
            colRC_ClaimDesc.OptionsColumn.AllowEdit = false;
            colRC_ClaimDesc.Visible = true;
            colRC_ClaimDesc.VisibleIndex = 2;
            colRC_ClaimDesc.Width = 250;

            // colRC_ClaimCode
            colRC_ClaimCode.Caption = Resources.Entity_Claim_Code;
            colRC_ClaimCode.FieldName = "ClaimCode";
            colRC_ClaimCode.Name = "colRC_ClaimCode";
            colRC_ClaimCode.OptionsColumn.AllowEdit = false;
            colRC_ClaimCode.Visible = true;
            colRC_ClaimCode.VisibleIndex = 3;
            colRC_ClaimCode.Width = 140;

            // colRC_CategoryId
            colRC_CategoryId.FieldName = "CategoryId";
            colRC_CategoryId.Name = "colRC_CategoryId";

            // colRC_CategoryParentId
            colRC_CategoryParentId.FieldName = "CategoryParentId";
            colRC_CategoryParentId.Name = "colRC_CategoryParentId";

            // colRC_IsCategory
            colRC_IsCategory.FieldName = "IsCategory";
            colRC_IsCategory.Name = "colRC_IsCategory";

            // ====================================================
            // Tab 2: tab_EffectiveClaims
            // ====================================================
            tab_EffectiveClaims.Controls.Add(treeListEffectiveClaims);
            tab_EffectiveClaims.Controls.Add(panelControlEffectiveTop);
            tab_EffectiveClaims.Name = "tab_EffectiveClaims";
            tab_EffectiveClaims.Size = new Size(858, 537);
            tab_EffectiveClaims.Text = Resources.Form_CurrAccProfile_Tab_EffectiveClaims;

            // panelControlEffectiveTop
            panelControlEffectiveTop.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            panelControlEffectiveTop.Controls.Add(lbl_EffectiveSummary);
            panelControlEffectiveTop.Controls.Add(btn_RefreshEffective);
            panelControlEffectiveTop.Controls.Add(btn_ExpandAllEffective);
            panelControlEffectiveTop.Controls.Add(btn_CollapseAllEffective);
            panelControlEffectiveTop.Dock = DockStyle.Top;
            panelControlEffectiveTop.Location = new Point(0, 0);
            panelControlEffectiveTop.Name = "panelControlEffectiveTop";
            panelControlEffectiveTop.Size = new Size(858, 38);
            panelControlEffectiveTop.TabIndex = 0;

            // lbl_EffectiveSummary
            lbl_EffectiveSummary.Appearance.Font = new Font("Tahoma", 8.25F, FontStyle.Bold);
            lbl_EffectiveSummary.Appearance.Options.UseFont = true;
            lbl_EffectiveSummary.Location = new Point(10, 12);
            lbl_EffectiveSummary.Name = "lbl_EffectiveSummary";
            lbl_EffectiveSummary.Size = new Size(95, 13);
            lbl_EffectiveSummary.TabIndex = 0;
            lbl_EffectiveSummary.Text = "";

            // btn_RefreshEffective
            btn_RefreshEffective.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btn_RefreshEffective.Location = new Point(580, 7);
            btn_RefreshEffective.Name = "btn_RefreshEffective";
            btn_RefreshEffective.Size = new Size(85, 24);
            btn_RefreshEffective.TabIndex = 1;
            btn_RefreshEffective.Text = Resources.Common_Refresh;
            btn_RefreshEffective.Click += btn_RefreshEffective_Click;

            // btn_ExpandAllEffective
            btn_ExpandAllEffective.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btn_ExpandAllEffective.Location = new Point(670, 7);
            btn_ExpandAllEffective.Name = "btn_ExpandAllEffective";
            btn_ExpandAllEffective.Size = new Size(85, 24);
            btn_ExpandAllEffective.TabIndex = 2;
            btn_ExpandAllEffective.Text = Resources.Common_ExpandAll;
            btn_ExpandAllEffective.Click += btn_ExpandAllEffective_Click;

            // btn_CollapseAllEffective
            btn_CollapseAllEffective.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btn_CollapseAllEffective.Location = new Point(760, 7);
            btn_CollapseAllEffective.Name = "btn_CollapseAllEffective";
            btn_CollapseAllEffective.Size = new Size(85, 24);
            btn_CollapseAllEffective.TabIndex = 3;
            btn_CollapseAllEffective.Text = Resources.Common_CollapseAll;
            btn_CollapseAllEffective.Click += btn_CollapseAllEffective_Click;

            // treeListEffectiveClaims
            treeListEffectiveClaims.Columns.AddRange(new TreeListColumn[] {
                colEff_IsSelected,
                colEff_CategoryDesc,
                colEff_ClaimDesc,
                colEff_ClaimCode,
                colEff_CategoryId,
                colEff_CategoryParentId,
                colEff_IsCategory
            });
            treeListEffectiveClaims.Dock = DockStyle.Fill;
            treeListEffectiveClaims.KeyFieldName = "CategoryId";
            treeListEffectiveClaims.Location = new Point(0, 38);
            treeListEffectiveClaims.Name = "treeListEffectiveClaims";
            treeListEffectiveClaims.OptionsBehavior.Editable = false;
            treeListEffectiveClaims.OptionsFilter.ExpandNodesOnFiltering = true;
            treeListEffectiveClaims.OptionsFind.AlwaysVisible = true;
            treeListEffectiveClaims.OptionsFind.Behavior = FindPanelBehavior.Filter;
            treeListEffectiveClaims.OptionsSelection.EnableAppearanceFocusedRow = true;
            treeListEffectiveClaims.OptionsView.AutoWidth = true;
            treeListEffectiveClaims.ParentFieldName = "CategoryParentId";
            treeListEffectiveClaims.RepositoryItems.AddRange(new RepositoryItem[] { repoCheckEditEffective });
            treeListEffectiveClaims.Size = new Size(858, 499);
            treeListEffectiveClaims.TabIndex = 1;

            // colEff_IsSelected
            colEff_IsSelected.Caption = Resources.Common_Select;
            colEff_IsSelected.ColumnEdit = repoCheckEditEffective;
            colEff_IsSelected.FieldName = "IsSelected";
            colEff_IsSelected.Name = "colEff_IsSelected";
            colEff_IsSelected.Visible = true;
            colEff_IsSelected.VisibleIndex = 0;
            colEff_IsSelected.Width = 60;

            // repoCheckEditEffective
            repoCheckEditEffective.AutoHeight = false;
            repoCheckEditEffective.Name = "repoCheckEditEffective";

            // colEff_CategoryDesc
            colEff_CategoryDesc.Caption = Resources.Entity_ClaimCategory;
            colEff_CategoryDesc.FieldName = "CategoryDesc";
            colEff_CategoryDesc.Name = "colEff_CategoryDesc";
            colEff_CategoryDesc.Visible = true;
            colEff_CategoryDesc.VisibleIndex = 1;
            colEff_CategoryDesc.Width = 200;

            // colEff_ClaimDesc
            colEff_ClaimDesc.Caption = Resources.Entity_Claim_Desc;
            colEff_ClaimDesc.FieldName = "ClaimDesc";
            colEff_ClaimDesc.Name = "colEff_ClaimDesc";
            colEff_ClaimDesc.Visible = true;
            colEff_ClaimDesc.VisibleIndex = 2;
            colEff_ClaimDesc.Width = 250;

            // colEff_ClaimCode
            colEff_ClaimCode.Caption = Resources.Entity_Claim_Code;
            colEff_ClaimCode.FieldName = "ClaimCode";
            colEff_ClaimCode.Name = "colEff_ClaimCode";
            colEff_ClaimCode.Visible = true;
            colEff_ClaimCode.VisibleIndex = 3;
            colEff_ClaimCode.Width = 140;

            // colEff_CategoryId
            colEff_CategoryId.FieldName = "CategoryId";
            colEff_CategoryId.Name = "colEff_CategoryId";

            // colEff_CategoryParentId
            colEff_CategoryParentId.FieldName = "CategoryParentId";
            colEff_CategoryParentId.Name = "colEff_CategoryParentId";

            // colEff_IsCategory
            colEff_IsCategory.FieldName = "IsCategory";
            colEff_IsCategory.Name = "colEff_IsCategory";

            // ====================================================
            // Tab 3: tab_ReportClaims
            // ====================================================
            tab_ReportClaims.Controls.Add(treeListReportClaims);
            tab_ReportClaims.Controls.Add(panelControlReportTop);
            tab_ReportClaims.Name = "tab_ReportClaims";
            tab_ReportClaims.Size = new Size(858, 537);
            tab_ReportClaims.Text = Resources.Form_CurrAccProfile_Tab_ReportClaims;

            // panelControlReportTop
            panelControlReportTop.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            panelControlReportTop.Controls.Add(lbl_ClaimReport);
            panelControlReportTop.Controls.Add(btnEdit_ClaimReport);
            panelControlReportTop.Controls.Add(btn_ClaimReportSave);
            panelControlReportTop.Dock = DockStyle.Top;
            panelControlReportTop.Location = new Point(0, 0);
            panelControlReportTop.Name = "panelControlReportTop";
            panelControlReportTop.Size = new Size(858, 38);
            panelControlReportTop.TabIndex = 0;

            // lbl_ClaimReport
            lbl_ClaimReport.Location = new Point(10, 12);
            lbl_ClaimReport.Name = "lbl_ClaimReport";
            lbl_ClaimReport.Size = new Size(80, 13);
            lbl_ClaimReport.TabIndex = 0;
            lbl_ClaimReport.Text = Resources.Form_CurrAccProfile_Label_ClaimReport + ":";

            // btnEdit_ClaimReport
            btnEdit_ClaimReport.Location = new Point(95, 9);
            btnEdit_ClaimReport.MenuManager = ribbon;
            btnEdit_ClaimReport.Name = "btnEdit_ClaimReport";
            btnEdit_ClaimReport.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                new DevExpress.XtraEditors.Controls.EditorButton()
            });
            btnEdit_ClaimReport.Size = new Size(250, 20);
            btnEdit_ClaimReport.TabIndex = 1;
            btnEdit_ClaimReport.ButtonPressed += btnEdit_ClaimReport_ButtonPressed;
            btnEdit_ClaimReport.EditValueChanged += btnEdit_ClaimReport_EditValueChanged;

            // btn_ClaimReportSave
            btn_ClaimReportSave.Location = new Point(360, 7);
            btn_ClaimReportSave.Name = "btn_ClaimReportSave";
            btn_ClaimReportSave.Size = new Size(110, 24);
            btn_ClaimReportSave.TabIndex = 2;
            btn_ClaimReportSave.Text = Resources.Common_Save;
            btn_ClaimReportSave.Click += btn_ClaimReportSave_Click;

            // treeListReportClaims
            treeListReportClaims.Columns.AddRange(new TreeListColumn[] {
                colReport_IsSelected,
                colReport_ReportId,
                colReport_ReportName,
                colReport_ClaimCode
            });
            treeListReportClaims.Dock = DockStyle.Fill;
            treeListReportClaims.KeyFieldName = "ReportId";
            treeListReportClaims.Location = new Point(0, 38);
            treeListReportClaims.Name = "treeListReportClaims";
            treeListReportClaims.OptionsView.AutoWidth = true;
            treeListReportClaims.RepositoryItems.AddRange(new RepositoryItem[] { repoCheckEditReport });
            treeListReportClaims.Size = new Size(858, 499);
            treeListReportClaims.TabIndex = 1;
            treeListReportClaims.CellValueChanged += treeListReportClaims_CellValueChanged;

            // colReport_IsSelected
            colReport_IsSelected.Caption = Resources.Common_Select;
            colReport_IsSelected.ColumnEdit = repoCheckEditReport;
            colReport_IsSelected.FieldName = "IsSelected";
            colReport_IsSelected.Name = "colReport_IsSelected";
            colReport_IsSelected.Visible = true;
            colReport_IsSelected.VisibleIndex = 0;
            colReport_IsSelected.Width = 60;

            // repoCheckEditReport
            repoCheckEditReport.AutoHeight = false;
            repoCheckEditReport.Name = "repoCheckEditReport";

            // colReport_ReportId
            colReport_ReportId.Caption = "Id";
            colReport_ReportId.FieldName = "ReportId";
            colReport_ReportId.Name = "colReport_ReportId";
            colReport_ReportId.OptionsColumn.AllowEdit = false;
            colReport_ReportId.Visible = true;
            colReport_ReportId.VisibleIndex = 1;
            colReport_ReportId.Width = 80;

            // colReport_ReportName
            colReport_ReportName.Caption = Resources.Common_Report;
            colReport_ReportName.FieldName = "ReportName";
            colReport_ReportName.Name = "colReport_ReportName";
            colReport_ReportName.OptionsColumn.AllowEdit = false;
            colReport_ReportName.Visible = true;
            colReport_ReportName.VisibleIndex = 2;
            colReport_ReportName.Width = 350;

            // colReport_ClaimCode
            colReport_ClaimCode.Caption = Resources.Entity_Claim_Code;
            colReport_ClaimCode.FieldName = "ClaimCode";
            colReport_ClaimCode.Name = "colReport_ClaimCode";
            colReport_ClaimCode.OptionsColumn.AllowEdit = false;
            colReport_ClaimCode.Visible = true;
            colReport_ClaimCode.VisibleIndex = 3;
            colReport_ClaimCode.Width = 150;

            // ----------------------------------------------------
            // FormCurrAccPermission
            // ----------------------------------------------------
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1350, 744);
            Controls.Add(xtraTabControl1);
            Controls.Add(splitterControl1);
            Controls.Add(layoutControl1);
            Controls.Add(ribbonStatusBar);
            Controls.Add(ribbon);
            Name = "FormCurrAccPermission";
            Ribbon = ribbon;
            StatusBar = ribbonStatusBar;
            Text = Resources.Form_CurrAccPermission_Caption;
            FormClosing += FormCurrAccPermission_FormClosing;
            KeyDown += FormCurrAccPermission_KeyDown;

            ((ISupportInitialize)ribbon).EndInit();
            ((ISupportInitialize)btnEdit_CurrAccCode.Properties).EndInit();
            ((ISupportInitialize)txt_CurrAccDesc.Properties).EndInit();
            ((ISupportInitialize)gridControl_Roles).EndInit();
            ((ISupportInitialize)gV_Roles).EndInit();
            ((ISupportInitialize)repoCheckEditRole).EndInit();
            ((ISupportInitialize)bindingSourceRoles).EndInit();
            ((ISupportInitialize)Root).EndInit();
            ((ISupportInitialize)groupRoles).EndInit();
            ((ISupportInitialize)layoutControl1).EndInit();
            layoutControl1.ResumeLayout(false);

            ((ISupportInitialize)panelControlRoleTop).EndInit();
            panelControlRoleTop.ResumeLayout(false);
            panelControlRoleTop.PerformLayout();
            ((ISupportInitialize)treeListRoleClaims).EndInit();
            ((ISupportInitialize)repoCheckEditRoleClaim).EndInit();
            tab_RoleClaims.ResumeLayout(false);

            ((ISupportInitialize)panelControlEffectiveTop).EndInit();
            panelControlEffectiveTop.ResumeLayout(false);
            panelControlEffectiveTop.PerformLayout();
            ((ISupportInitialize)treeListEffectiveClaims).EndInit();
            ((ISupportInitialize)repoCheckEditEffective).EndInit();
            tab_EffectiveClaims.ResumeLayout(false);

            ((ISupportInitialize)panelControlReportTop).EndInit();
            panelControlReportTop.ResumeLayout(false);
            panelControlReportTop.PerformLayout();
            ((ISupportInitialize)btnEdit_ClaimReport.Properties).EndInit();
            ((ISupportInitialize)treeListReportClaims).EndInit();
            ((ISupportInitialize)repoCheckEditReport).EndInit();
            tab_ReportClaims.ResumeLayout(false);

            ((ISupportInitialize)xtraTabControl1).EndInit();
            xtraTabControl1.ResumeLayout(false);

            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        // Ribbon
        private RibbonControl ribbon;
        private RibbonPage ribbonPage1;
        private RibbonPageGroup ribbonPageGroup1;
        private RibbonPageGroup ribbonPageGroup2;
        private RibbonStatusBar ribbonStatusBar;
        private BarButtonItem BBI_Save;
        private BarButtonItem BBI_Refresh;
        private BarButtonItem BBI_SelectAllRoles;
        private BarButtonItem BBI_UnselectAllRoles;
        private BarButtonItem BBI_NewRole;
        private BarButtonItem BBI_EditRole;
        private BarButtonItem BBI_DeleteRole;
        private BarButtonItem BBI_RoleClaimsWindow;

        // Splitter
        private SplitterControl splitterControl1;

        // Left Controls
        private LayoutControl layoutControl1;
        private LayoutControlGroup Root;
        private ButtonEdit btnEdit_CurrAccCode;
        private TextEdit txt_CurrAccDesc;
        private MyGridControl gridControl_Roles;
        private MyGridView gV_Roles;
        private GridColumn col_IsAssigned;
        private GridColumn col_RoleCode;
        private GridColumn col_RoleDesc;
        private RepositoryItemCheckEdit repoCheckEditRole;
        private SimpleButton btn_SaveRoles;
        private BindingSource bindingSourceRoles;
        private LayoutControlItem layoutControlItemCurrAccCode;
        private LayoutControlItem layoutControlItemCurrAccDesc;
        private LayoutControlGroup groupRoles;
        private LayoutControlItem layoutControlItemRolesGrid;
        private LayoutControlItem layoutControlItemSaveRoles;

        // Right Tab Controls
        private XtraTabControl xtraTabControl1;
        private XtraTabPage tab_RoleClaims;
        private PanelControl panelControlRoleTop;
        private LabelControl lbl_SelectedRole;
        private SimpleButton btn_SaveRoleClaims;
        private SimpleButton btn_SelectAllClaims;
        private SimpleButton btn_UnselectAllClaims;
        private SimpleButton btn_ExpandAllClaims;
        private SimpleButton btn_CollapseAllClaims;
        private SimpleButton btn_OpenClaimsWindow;
        private TreeList treeListRoleClaims;
        private TreeListColumn colRC_IsSelected;
        private RepositoryItemCheckEdit repoCheckEditRoleClaim;
        private TreeListColumn colRC_CategoryDesc;
        private TreeListColumn colRC_ClaimDesc;
        private TreeListColumn colRC_ClaimCode;
        private TreeListColumn colRC_CategoryId;
        private TreeListColumn colRC_CategoryParentId;
        private TreeListColumn colRC_IsCategory;

        private XtraTabPage tab_EffectiveClaims;
        private PanelControl panelControlEffectiveTop;
        private LabelControl lbl_EffectiveSummary;
        private SimpleButton btn_RefreshEffective;
        private SimpleButton btn_ExpandAllEffective;
        private SimpleButton btn_CollapseAllEffective;
        private TreeList treeListEffectiveClaims;
        private TreeListColumn colEff_IsSelected;
        private RepositoryItemCheckEdit repoCheckEditEffective;
        private TreeListColumn colEff_CategoryDesc;
        private TreeListColumn colEff_ClaimDesc;
        private TreeListColumn colEff_ClaimCode;
        private TreeListColumn colEff_CategoryId;
        private TreeListColumn colEff_CategoryParentId;
        private TreeListColumn colEff_IsCategory;

        private XtraTabPage tab_ReportClaims;
        private PanelControl panelControlReportTop;
        private LabelControl lbl_ClaimReport;
        private ButtonEdit btnEdit_ClaimReport;
        private SimpleButton btn_ClaimReportSave;
        private TreeList treeListReportClaims;
        private TreeListColumn colReport_IsSelected;
        private RepositoryItemCheckEdit repoCheckEditReport;
        private TreeListColumn colReport_ReportId;
        private TreeListColumn colReport_ReportName;
        private TreeListColumn colReport_ClaimCode;
    }
}
