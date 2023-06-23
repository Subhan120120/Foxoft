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
            treeList1 = new DevExpress.XtraTreeList.TreeList();
            ((System.ComponentModel.ISupportInitialize)treeList1).BeginInit();
            SuspendLayout();
            // 
            // treeList1
            // 
            treeList1.Dock = System.Windows.Forms.DockStyle.Fill;
            treeList1.KeyFieldName = "HierarchyCode";
            treeList1.Location = new System.Drawing.Point(0, 0);
            treeList1.Name = "treeList1";
            treeList1.OptionsBehavior.Editable = false;
            treeList1.ParentFieldName = "HierarchyParentCode";
            treeList1.Size = new System.Drawing.Size(800, 450);
            treeList1.TabIndex = 0;
            treeList1.ViewStyle = DevExpress.XtraTreeList.TreeListViewStyle.TreeView;
            // 
            // FormTreeView
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(800, 450);
            Controls.Add(treeList1);
            Name = "FormTreeView";
            Text = "Form1";
            Load += FormTreeView_Load;
            ((System.ComponentModel.ISupportInitialize)treeList1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraTreeList.TreeList treeList1;
    }
}