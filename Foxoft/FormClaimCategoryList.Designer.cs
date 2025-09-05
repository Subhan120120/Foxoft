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
            treeList1 = new DevExpress.XtraTreeList.TreeList();
            treeListCol_CategoryId = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            treeListCol_CategoryDesc = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            treeListCol_CategoryParentId = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            treeListCol_ClaimDesc = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            svgImageCollection1 = new DevExpress.Utils.SvgImageCollection(components);
            btn_Clear = new Button();
            btn_Save = new DevExpress.XtraEditors.SimpleButton();
            btn_Claims = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)treeList1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)svgImageCollection1).BeginInit();
            SuspendLayout();
            // 
            // treeList1
            // 
            treeList1.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] { treeListCol_CategoryId, treeListCol_CategoryDesc, treeListCol_CategoryParentId, treeListCol_ClaimDesc });
            treeList1.CustomizationFormBounds = new Rectangle(163, 241, 264, 200);
            treeList1.Dock = DockStyle.Fill;
            treeList1.KeyFieldName = "CategoryId";
            treeList1.Location = new Point(0, 0);
            treeList1.Name = "treeList1";
            treeList1.OptionsFilter.ExpandNodesOnFiltering = true;
            treeList1.OptionsFind.AlwaysVisible = true;
            treeList1.OptionsFind.Behavior = DevExpress.XtraEditors.FindPanelBehavior.Filter;
            treeList1.OptionsFind.FindDelay = 100;
            treeList1.OptionsMenu.ShowExpandCollapseItems = false;
            treeList1.ParentFieldName = "CategoryParentId";
            treeList1.Size = new Size(379, 290);
            treeList1.StateImageList = svgImageCollection1;
            treeList1.TabIndex = 0;
            treeList1.ViewStyle = DevExpress.XtraTreeList.TreeListViewStyle.TreeView;
            treeList1.InitNewRow += treeList1_InitNewRow;
            treeList1.FocusedNodeChanged += treeList1_FocusedNodeChanged;
            treeList1.DoubleClick += treeList1_DoubleClick;
            // 
            // treeListCol_CategoryId
            // 
            treeListCol_CategoryId.FieldName = "CategoryId";
            treeListCol_CategoryId.Name = "treeListCol_CategoryId";
            // 
            // treeListCol_CategoryDesc
            // 
            treeListCol_CategoryDesc.FieldName = "CategoryDesc";
            treeListCol_CategoryDesc.Name = "treeListCol_CategoryDesc";
            treeListCol_CategoryDesc.Visible = true;
            treeListCol_CategoryDesc.VisibleIndex = 0;
            // 
            // treeListCol_CategoryParentId
            // 
            treeListCol_CategoryParentId.FieldName = "CategoryParentId";
            treeListCol_CategoryParentId.Name = "treeListCol_CategoryParentId";
            // 
            // treeListCol_ClaimDesc
            // 
            treeListCol_ClaimDesc.Caption = "coltreeListColumn4";
            treeListCol_ClaimDesc.FieldName = "ClaimDesc";
            treeListCol_ClaimDesc.Name = "treeListCol_ClaimDesc";
            treeListCol_ClaimDesc.Visible = true;
            treeListCol_ClaimDesc.VisibleIndex = 1;
            // 
            // svgImageCollection1
            // 
            svgImageCollection1.Add("open", "image://svgimages/actions/open.svg");
            svgImageCollection1.Add("add", "image://svgimages/icon builder/actions_add.svg");
            svgImageCollection1.Add("child2", "image://svgimages/spreadsheet/expandfieldpivottable.svg");
            svgImageCollection1.Add("child", "image://svgimages/icon builder/actions_addcircled.svg");
            svgImageCollection1.Add("edit", "image://svgimages/icon builder/actions_edit.svg");
            svgImageCollection1.Add("delete", "image://svgimages/icon builder/actions_delete.svg");
            svgImageCollection1.Add("Key", (DevExpress.Utils.Svg.SvgImage)resources.GetObject("svgImageCollection1.Key"));
            // 
            // btn_Clear
            // 
            btn_Clear.Location = new Point(292, 255);
            btn_Clear.Name = "btn_Clear";
            btn_Clear.Size = new Size(75, 23);
            btn_Clear.TabIndex = 1;
            btn_Clear.Text = "Təmizlə";
            btn_Clear.UseVisualStyleBackColor = true;
            btn_Clear.Click += btnClear_Click;
            // 
            // btn_Save
            // 
            btn_Save.Location = new Point(211, 255);
            btn_Save.Name = "btn_Save";
            btn_Save.Size = new Size(75, 23);
            btn_Save.TabIndex = 2;
            btn_Save.Text = "Yadda Saxla";
            btn_Save.Click += Btn_Save_Click;
            // 
            // btn_Claims
            // 
            btn_Claims.Location = new Point(130, 255);
            btn_Claims.Name = "btn_Claims";
            btn_Claims.Size = new Size(75, 23);
            btn_Claims.TabIndex = 3;
            btn_Claims.Text = "Yetkilər";
            btn_Claims.Click += Btn_Claims_Click;
            // 
            // FormClaimCategoryList
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(379, 290);
            Controls.Add(btn_Claims);
            Controls.Add(btn_Save);
            Controls.Add(btn_Clear);
            Controls.Add(treeList1);
            Name = "FormClaimCategoryList";
            Text = "Form1";
            Load += FormTreeView_Load;
            ((System.ComponentModel.ISupportInitialize)treeList1).EndInit();
            ((System.ComponentModel.ISupportInitialize)svgImageCollection1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraTreeList.TreeList treeList1;
        private DevExpress.Utils.ImageCollection ımageCollection1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListCol_CategoryId;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListCol_CategoryDesc;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListCol_CategoryParentId;
        private DevExpress.Utils.SvgImageCollection svgImageCollection1;
        private Button btn_Clear;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn1;
        private DevExpress.XtraEditors.SimpleButton btn_Save;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.SimpleButton btn_Claims;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListCol_ClaimDesc;
    }
}