namespace Foxoft
{
    partial class FormTreeView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormTreeView));
            treeList1 = new DevExpress.XtraTreeList.TreeList();
            treeListCol_HierarchyCode = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            treeListCol_HierarchyDesc = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            treeListCol_HierarchyParentCode = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            ımageCollection1 = new DevExpress.Utils.ImageCollection(components);
            ((System.ComponentModel.ISupportInitialize)treeList1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ımageCollection1).BeginInit();
            SuspendLayout();
            // 
            // treeList1
            // 
            treeList1.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] { treeListCol_HierarchyCode, treeListCol_HierarchyDesc, treeListCol_HierarchyParentCode });
            treeList1.Dock = System.Windows.Forms.DockStyle.Fill;
            treeList1.KeyFieldName = "HierarchyCode";
            treeList1.Location = new System.Drawing.Point(0, 0);
            treeList1.Name = "treeList1";
            treeList1.OptionsBehavior.Editable = false;
            treeList1.OptionsFilter.ExpandNodesOnFiltering = true;
            treeList1.OptionsFind.AlwaysVisible = true;
            treeList1.OptionsFind.Behavior = DevExpress.XtraEditors.FindPanelBehavior.Filter;
            treeList1.OptionsFind.FindDelay = 300;
            treeList1.ParentFieldName = "HierarchyParentCode";
            treeList1.Size = new System.Drawing.Size(366, 290);
            treeList1.StateImageList = ımageCollection1;
            treeList1.TabIndex = 0;
            treeList1.ViewStyle = DevExpress.XtraTreeList.TreeListViewStyle.TreeView;
            treeList1.InitNewRow += treeList1_InitNewRow;
            treeList1.FocusedNodeChanged += treeList1_FocusedNodeChanged;
            treeList1.HiddenEditor += treeList1_HiddenEditor;
            treeList1.PopupMenuShowing += treeList1_PopupMenuShowing;
            treeList1.CellValueChanged += treeList1_CellValueChanged;
            treeList1.DoubleClick += treeList1_DoubleClick;
            // 
            // treeListCol_HierarchyCode
            // 
            treeListCol_HierarchyCode.FieldName = "HierarchyCode";
            treeListCol_HierarchyCode.Name = "treeListCol_HierarchyCode";
            treeListCol_HierarchyCode.Visible = true;
            treeListCol_HierarchyCode.VisibleIndex = 0;
            // 
            // treeListCol_HierarchyDesc
            // 
            treeListCol_HierarchyDesc.FieldName = "HierarchyDesc";
            treeListCol_HierarchyDesc.Name = "treeListCol_HierarchyDesc";
            treeListCol_HierarchyDesc.Visible = true;
            treeListCol_HierarchyDesc.VisibleIndex = 1;
            // 
            // treeListCol_HierarchyParentCode
            // 
            treeListCol_HierarchyParentCode.FieldName = "treeListCol_HierarchyCode";
            treeListCol_HierarchyParentCode.Name = "treeListCol_HierarchyParentCode";
            // 
            // ımageCollection1
            // 
            ımageCollection1.ImageStream = (DevExpress.Utils.ImageCollectionStreamer)resources.GetObject("ımageCollection1.ImageStream");
            ımageCollection1.Images.SetKeyName(0, "open_16x16.png");
            // 
            // FormTreeView
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(366, 290);
            Controls.Add(treeList1);
            Name = "FormTreeView";
            Text = "Form1";
            Load += FormTreeView_Load;
            ((System.ComponentModel.ISupportInitialize)treeList1).EndInit();
            ((System.ComponentModel.ISupportInitialize)ımageCollection1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraTreeList.TreeList treeList1;
        private DevExpress.Utils.ImageCollection ımageCollection1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListCol_HierarchyCode;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListCol_HierarchyDesc;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListCol_HierarchyParentCode;
    }
}