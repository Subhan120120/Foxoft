using Foxoft.Properties;

namespace Foxoft
{
    partial class FormClaimCategoryList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormClaimCategoryList));
            svgImageCollection1 = new DevExpress.Utils.SvgImageCollection(components);
            panelControlTop = new DevExpress.XtraEditors.PanelControl();
            lbl_Role = new DevExpress.XtraEditors.LabelControl();
            lue_Role = new DevExpress.XtraEditors.LookUpEdit();
            btn_SelectAll = new DevExpress.XtraEditors.SimpleButton();
            btn_UnselectAll = new DevExpress.XtraEditors.SimpleButton();
            btn_ExpandAll = new DevExpress.XtraEditors.SimpleButton();
            btn_CollapseAll = new DevExpress.XtraEditors.SimpleButton();
            btn_Refresh = new DevExpress.XtraEditors.SimpleButton();
            treeList1 = new DevExpress.XtraTreeList.TreeList();
            treeListCol_IsSelected = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            repoCheckEdit = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            treeListCol_CategoryDesc = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            treeListCol_ClaimDesc = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            treeListCol_ClaimCode = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            treeListCol_CategoryId = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            treeListCol_CategoryParentId = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            treeListCol_IsCategory = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            panelControlBottom = new DevExpress.XtraEditors.PanelControl();
            btn_Claims = new DevExpress.XtraEditors.SimpleButton();
            lbl_Summary = new DevExpress.XtraEditors.LabelControl();
            btn_Save = new DevExpress.XtraEditors.SimpleButton();
            btn_Cancel = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)svgImageCollection1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)panelControlTop).BeginInit();
            panelControlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)lue_Role.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)treeList1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)repoCheckEdit).BeginInit();
            ((System.ComponentModel.ISupportInitialize)panelControlBottom).BeginInit();
            panelControlBottom.SuspendLayout();
            SuspendLayout();
            // 
            // svgImageCollection1
            // 
            svgImageCollection1.Add("open", "image://svgimages/actions/open.svg");
            svgImageCollection1.Add("closed", "image://svgimages/icon builder/actions_folderclose.svg");
            svgImageCollection1.Add("check", "image://svgimages/icon builder/actions_check.svg");
            svgImageCollection1.Add("clear", "image://svgimages/icon builder/actions_clear.svg");
            svgImageCollection1.Add("expand", "image://svgimages/spreadsheet/expandfieldpivottable.svg");
            svgImageCollection1.Add("collapse", "image://svgimages/spreadsheet/collapsefieldpivottable.svg");
            svgImageCollection1.Add("refresh", "image://svgimages/icon builder/actions_refresh.svg");
            svgImageCollection1.Add("save", "image://svgimages/save/save.svg");
            svgImageCollection1.Add("cancel", "image://svgimages/icon builder/actions_delete.svg");
            svgImageCollection1.Add("Key", (DevExpress.Utils.Svg.SvgImage)resources.GetObject("svgImageCollection1.Key"));
            // 
            // panelControlTop
            // 
            panelControlTop.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            panelControlTop.Controls.Add(lbl_Role);
            panelControlTop.Controls.Add(lue_Role);
            panelControlTop.Controls.Add(btn_SelectAll);
            panelControlTop.Controls.Add(btn_UnselectAll);
            panelControlTop.Controls.Add(btn_ExpandAll);
            panelControlTop.Controls.Add(btn_CollapseAll);
            panelControlTop.Controls.Add(btn_Refresh);
            panelControlTop.Dock = DockStyle.Top;
            panelControlTop.Location = new Point(0, 0);
            panelControlTop.Name = "panelControlTop";
            panelControlTop.Size = new Size(800, 44);
            panelControlTop.TabIndex = 0;
            // 
            // lbl_Role
            // 
            lbl_Role.Location = new Point(12, 14);
            lbl_Role.Name = "lbl_Role";
            lbl_Role.Size = new Size(20, 13);
            lbl_Role.TabIndex = 0;
            lbl_Role.Text = Resources.Common_Role + ":";
            // 
            // lue_Role
            // 
            lue_Role.Location = new Point(42, 11);
            lue_Role.Name = "lue_Role";
            lue_Role.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
            });
            lue_Role.Properties.NullText = "";
            lue_Role.Properties.ShowFooter = false;
            lue_Role.Size = new Size(180, 22);
            lue_Role.TabIndex = 1;
            lue_Role.EditValueChanged += lue_Role_EditValueChanged;
            // 
            // btn_SelectAll
            // 
            btn_SelectAll.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btn_SelectAll.ImageOptions.ImageIndex = 2;
            btn_SelectAll.ImageOptions.ImageList = svgImageCollection1;
            btn_SelectAll.Location = new Point(245, 8);
            btn_SelectAll.Name = "btn_SelectAll";
            btn_SelectAll.Size = new Size(105, 28);
            btn_SelectAll.TabIndex = 2;
            btn_SelectAll.Text = Resources.Common_SelectAll;
            btn_SelectAll.Click += btn_SelectAll_Click;
            // 
            // btn_UnselectAll
            // 
            btn_UnselectAll.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btn_UnselectAll.ImageOptions.ImageIndex = 3;
            btn_UnselectAll.ImageOptions.ImageList = svgImageCollection1;
            btn_UnselectAll.Location = new Point(356, 8);
            btn_UnselectAll.Name = "btn_UnselectAll";
            btn_UnselectAll.Size = new Size(105, 28);
            btn_UnselectAll.TabIndex = 3;
            btn_UnselectAll.Text = Resources.Common_UnselectAll;
            btn_UnselectAll.Click += btn_UnselectAll_Click;
            // 
            // btn_ExpandAll
            // 
            btn_ExpandAll.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btn_ExpandAll.ImageOptions.ImageIndex = 4;
            btn_ExpandAll.ImageOptions.ImageList = svgImageCollection1;
            btn_ExpandAll.Location = new Point(467, 8);
            btn_ExpandAll.Name = "btn_ExpandAll";
            btn_ExpandAll.Size = new Size(100, 28);
            btn_ExpandAll.TabIndex = 4;
            btn_ExpandAll.Text = Resources.Common_ExpandAll;
            btn_ExpandAll.Click += btn_ExpandAll_Click;
            // 
            // btn_CollapseAll
            // 
            btn_CollapseAll.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btn_CollapseAll.ImageOptions.ImageIndex = 5;
            btn_CollapseAll.ImageOptions.ImageList = svgImageCollection1;
            btn_CollapseAll.Location = new Point(573, 8);
            btn_CollapseAll.Name = "btn_CollapseAll";
            btn_CollapseAll.Size = new Size(105, 28);
            btn_CollapseAll.TabIndex = 5;
            btn_CollapseAll.Text = Resources.Common_CollapseAll;
            btn_CollapseAll.Click += btn_CollapseAll_Click;
            // 
            // btn_Refresh
            // 
            btn_Refresh.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btn_Refresh.ImageOptions.ImageIndex = 6;
            btn_Refresh.ImageOptions.ImageList = svgImageCollection1;
            btn_Refresh.Location = new Point(684, 8);
            btn_Refresh.Name = "btn_Refresh";
            btn_Refresh.Size = new Size(104, 28);
            btn_Refresh.TabIndex = 6;
            btn_Refresh.Text = Resources.Common_Refresh;
            btn_Refresh.Click += btn_Refresh_Click;
            // 
            // treeList1
            // 
            treeList1.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
                treeListCol_IsSelected,
                treeListCol_CategoryDesc,
                treeListCol_ClaimDesc,
                treeListCol_ClaimCode,
                treeListCol_CategoryId,
                treeListCol_CategoryParentId,
                treeListCol_IsCategory
            });
            treeList1.Dock = DockStyle.Fill;
            treeList1.KeyFieldName = "CategoryId";
            treeList1.Location = new Point(0, 44);
            treeList1.Name = "treeList1";
            treeList1.OptionsFilter.ExpandNodesOnFiltering = true;
            treeList1.OptionsFind.AlwaysVisible = true;
            treeList1.OptionsFind.Behavior = DevExpress.XtraEditors.FindPanelBehavior.Filter;
            treeList1.OptionsFind.FindDelay = 100;
            treeList1.OptionsMenu.ShowExpandCollapseItems = false;
            treeList1.OptionsSelection.EnableAppearanceFocusedRow = true;
            treeList1.OptionsView.AutoWidth = true;
            treeList1.ParentFieldName = "CategoryParentId";
            treeList1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
                repoCheckEdit
            });
            treeList1.Size = new Size(800, 472);
            treeList1.StateImageList = svgImageCollection1;
            treeList1.TabIndex = 1;
            treeList1.ViewStyle = DevExpress.XtraTreeList.TreeListViewStyle.TreeView;
            treeList1.FocusedNodeChanged += treeList1_FocusedNodeChanged;
            treeList1.CellValueChanged += treeList1_CellValueChanged;
            // 
            // treeListCol_IsSelected
            // 
            treeListCol_IsSelected.Caption = Resources.Common_Select;
            treeListCol_IsSelected.ColumnEdit = repoCheckEdit;
            treeListCol_IsSelected.FieldName = "IsSelected";
            treeListCol_IsSelected.Fixed = DevExpress.XtraTreeList.Columns.FixedStyle.Left;
            treeListCol_IsSelected.MaxWidth = 60;
            treeListCol_IsSelected.MinWidth = 45;
            treeListCol_IsSelected.Name = "treeListCol_IsSelected";
            treeListCol_IsSelected.Visible = true;
            treeListCol_IsSelected.VisibleIndex = 0;
            treeListCol_IsSelected.Width = 55;
            // 
            // repoCheckEdit
            // 
            repoCheckEdit.AllowGrayed = true;
            repoCheckEdit.AutoHeight = false;
            repoCheckEdit.Name = "repoCheckEdit";
            repoCheckEdit.ValueChecked = true;
            repoCheckEdit.ValueGrayed = null;
            repoCheckEdit.ValueUnchecked = false;
            repoCheckEdit.EditValueChanged += repoCheckEdit_EditValueChanged;
            // 
            // treeListCol_CategoryDesc
            // 
            treeListCol_CategoryDesc.Caption = Resources.Form_ClaimCategoryList_ColCategory;
            treeListCol_CategoryDesc.FieldName = "CategoryDesc";
            treeListCol_CategoryDesc.MinWidth = 120;
            treeListCol_CategoryDesc.Name = "treeListCol_CategoryDesc";
            treeListCol_CategoryDesc.OptionsColumn.AllowEdit = false;
            treeListCol_CategoryDesc.Visible = true;
            treeListCol_CategoryDesc.VisibleIndex = 1;
            treeListCol_CategoryDesc.Width = 320;
            // 
            // treeListCol_ClaimDesc
            // 
            treeListCol_ClaimDesc.Caption = Resources.Form_ClaimCategoryList_ColDescription;
            treeListCol_ClaimDesc.FieldName = "ClaimDesc";
            treeListCol_ClaimDesc.MinWidth = 150;
            treeListCol_ClaimDesc.Name = "treeListCol_ClaimDesc";
            treeListCol_ClaimDesc.OptionsColumn.AllowEdit = false;
            treeListCol_ClaimDesc.Visible = true;
            treeListCol_ClaimDesc.VisibleIndex = 2;
            treeListCol_ClaimDesc.Width = 405;
            // 
            // treeListCol_ClaimCode
            // 
            treeListCol_ClaimCode.FieldName = "ClaimCode";
            treeListCol_ClaimCode.Name = "treeListCol_ClaimCode";
            // 
            // treeListCol_CategoryId
            // 
            treeListCol_CategoryId.FieldName = "CategoryId";
            treeListCol_CategoryId.Name = "treeListCol_CategoryId";
            // 
            // treeListCol_CategoryParentId
            // 
            treeListCol_CategoryParentId.FieldName = "CategoryParentId";
            treeListCol_CategoryParentId.Name = "treeListCol_CategoryParentId";
            // 
            // treeListCol_IsCategory
            // 
            treeListCol_IsCategory.FieldName = "IsCategory";
            treeListCol_IsCategory.Name = "treeListCol_IsCategory";
            // 
            // panelControlBottom
            // 
            panelControlBottom.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            panelControlBottom.Controls.Add(btn_Claims);
            panelControlBottom.Controls.Add(lbl_Summary);
            panelControlBottom.Controls.Add(btn_Save);
            panelControlBottom.Controls.Add(btn_Cancel);
            panelControlBottom.Dock = DockStyle.Bottom;
            panelControlBottom.Location = new Point(0, 516);
            panelControlBottom.Name = "panelControlBottom";
            panelControlBottom.Size = new Size(800, 44);
            panelControlBottom.TabIndex = 2;
            // 
            // btn_Claims
            // 
            btn_Claims.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btn_Claims.ImageOptions.ImageIndex = 9;
            btn_Claims.ImageOptions.ImageList = svgImageCollection1;
            btn_Claims.Location = new Point(12, 8);
            btn_Claims.Name = "btn_Claims";
            btn_Claims.Size = new Size(110, 28);
            btn_Claims.TabIndex = 0;
            btn_Claims.Text = Resources.Form_ClaimCategoryList_Button_Claims;
            btn_Claims.Click += btn_Claims_Click;
            // 
            // lbl_Summary
            // 
            lbl_Summary.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lbl_Summary.Appearance.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_Summary.Appearance.Options.UseFont = true;
            lbl_Summary.Location = new Point(135, 15);
            lbl_Summary.Name = "lbl_Summary";
            lbl_Summary.Size = new Size(120, 15);
            lbl_Summary.TabIndex = 1;
            lbl_Summary.Text = "";
            // 
            // btn_Save
            // 
            btn_Save.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btn_Save.ImageOptions.ImageIndex = 7;
            btn_Save.ImageOptions.ImageList = svgImageCollection1;
            btn_Save.Location = new Point(578, 8);
            btn_Save.Name = "btn_Save";
            btn_Save.Size = new Size(105, 28);
            btn_Save.TabIndex = 2;
            btn_Save.Text = Resources.Common_Save;
            btn_Save.Click += btn_Save_Click;
            // 
            // btn_Cancel
            // 
            btn_Cancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btn_Cancel.DialogResult = DialogResult.Cancel;
            btn_Cancel.ImageOptions.ImageIndex = 8;
            btn_Cancel.ImageOptions.ImageList = svgImageCollection1;
            btn_Cancel.Location = new Point(689, 8);
            btn_Cancel.Name = "btn_Cancel";
            btn_Cancel.Size = new Size(99, 28);
            btn_Cancel.TabIndex = 3;
            btn_Cancel.Text = Resources.Common_Cancel;
            btn_Cancel.Click += btn_Cancel_Click;
            // 
            // FormClaimCategoryList
            // 
            AcceptButton = btn_Save;
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btn_Cancel;
            ClientSize = new Size(800, 560);
            Controls.Add(treeList1);
            Controls.Add(panelControlTop);
            Controls.Add(panelControlBottom);
            KeyPreview = true;
            MinimumSize = new Size(650, 420);
            Name = "FormClaimCategoryList";
            StartPosition = FormStartPosition.CenterParent;
            Text = Resources.Form_ClaimCategoryList_Caption;
            FormClosing += FormClaimCategoryList_FormClosing;
            Load += FormClaimCategoryList_Load;
            KeyDown += FormClaimCategoryList_KeyDown;
            ((System.ComponentModel.ISupportInitialize)svgImageCollection1).EndInit();
            ((System.ComponentModel.ISupportInitialize)panelControlTop).EndInit();
            panelControlTop.ResumeLayout(false);
            panelControlTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)lue_Role.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)treeList1).EndInit();
            ((System.ComponentModel.ISupportInitialize)repoCheckEdit).EndInit();
            ((System.ComponentModel.ISupportInitialize)panelControlBottom).EndInit();
            panelControlBottom.ResumeLayout(false);
            panelControlBottom.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private DevExpress.Utils.SvgImageCollection svgImageCollection1;
        private DevExpress.XtraEditors.PanelControl panelControlTop;
        private DevExpress.XtraEditors.LabelControl lbl_Role;
        private DevExpress.XtraEditors.LookUpEdit lue_Role;
        private DevExpress.XtraEditors.SimpleButton btn_SelectAll;
        private DevExpress.XtraEditors.SimpleButton btn_UnselectAll;
        private DevExpress.XtraEditors.SimpleButton btn_ExpandAll;
        private DevExpress.XtraEditors.SimpleButton btn_CollapseAll;
        private DevExpress.XtraEditors.SimpleButton btn_Refresh;
        private DevExpress.XtraTreeList.TreeList treeList1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListCol_IsSelected;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repoCheckEdit;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListCol_CategoryDesc;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListCol_ClaimDesc;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListCol_ClaimCode;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListCol_CategoryId;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListCol_CategoryParentId;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListCol_IsCategory;
        private DevExpress.XtraEditors.PanelControl panelControlBottom;
        private DevExpress.XtraEditors.SimpleButton btn_Claims;
        private DevExpress.XtraEditors.LabelControl lbl_Summary;
        private DevExpress.XtraEditors.SimpleButton btn_Save;
        private DevExpress.XtraEditors.SimpleButton btn_Cancel;
    }
}
