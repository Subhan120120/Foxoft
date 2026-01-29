namespace Foxoft
{
    partial class FormPayrollList
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
            ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            btnNew = new DevExpress.XtraBars.BarButtonItem();
            btnEdit = new DevExpress.XtraBars.BarButtonItem();
            btnDelete = new DevExpress.XtraBars.BarButtonItem();
            btnRefresh = new DevExpress.XtraBars.BarButtonItem();
            ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            grid = new DevExpress.XtraGrid.GridControl();
            view = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)ribbonControl1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)grid).BeginInit();
            ((System.ComponentModel.ISupportInitialize)view).BeginInit();
            SuspendLayout();
            // 
            // ribbonControl1
            // 
            ribbonControl1.ExpandCollapseItem.Id = 0;
            ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] { ribbonControl1.ExpandCollapseItem, btnNew, btnEdit, btnDelete, btnRefresh });
            ribbonControl1.Location = new Point(0, 0);
            ribbonControl1.MaxItemId = 6;
            ribbonControl1.Name = "ribbonControl1";
            ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] { ribbonPage1 });
            ribbonControl1.Size = new Size(800, 158);
            // 
            // btnNew
            // 
            btnNew.Caption = "New";
            btnNew.Id = 1;
            btnNew.Name = "btnNew";
            btnNew.ItemClick += BtnNew_ItemClick;
            // 
            // btnEdit
            // 
            btnEdit.Caption = "Edit";
            btnEdit.Id = 2;
            btnEdit.Name = "btnEdit";
            btnEdit.ItemClick += BtnEdit_ItemClick;
            // 
            // btnDelete
            // 
            btnDelete.Caption = "Delete";
            btnDelete.Id = 3;
            btnDelete.Name = "btnDelete";
            btnDelete.ItemClick += BtnDelete_ItemClick;
            // 
            // btnRefresh
            // 
            btnRefresh.Caption = "Refresh";
            btnRefresh.Id = 4;
            btnRefresh.Name = "btnRefresh";
            btnRefresh.ItemClick += BtnRefresh_ItemClick;
            // 
            // ribbonPage1
            // 
            ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] { ribbonPageGroup1 });
            ribbonPage1.Name = "ribbonPage1";
            ribbonPage1.Text = "HR";
            // 
            // ribbonPageGroup1
            // 
            ribbonPageGroup1.ItemLinks.Add(btnNew);
            ribbonPageGroup1.ItemLinks.Add(btnEdit);
            ribbonPageGroup1.ItemLinks.Add(btnDelete);
            ribbonPageGroup1.ItemLinks.Add(btnRefresh);
            ribbonPageGroup1.Name = "ribbonPageGroup1";
            ribbonPageGroup1.Text = "Payroll";
            // 
            // grid
            // 
            grid.Dock = DockStyle.Fill;
            grid.Location = new Point(0, 158);
            grid.MainView = view;
            grid.MenuManager = ribbonControl1;
            grid.Name = "grid";
            grid.Size = new Size(800, 374);
            grid.TabIndex = 1;
            grid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { view });
            // 
            // view
            // 
            view.GridControl = grid;
            view.Name = "view";
            view.OptionsBehavior.Editable = false;
            view.OptionsView.ColumnAutoWidth = false;
            view.OptionsView.ShowAutoFilterRow = true;
            view.CustomDrawRowIndicator += View_CustomDrawRowIndicator;
            // 
            // FormPayrollList
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 532);
            Controls.Add(grid);
            Controls.Add(ribbonControl1);
            Name = "FormPayrollList";
            Ribbon = ribbonControl1;
            Text = "FormPayrollList";
            Load += FormPayrollList_Load;
            ((System.ComponentModel.ISupportInitialize)ribbonControl1).EndInit();
            ((System.ComponentModel.ISupportInitialize)grid).EndInit();
            ((System.ComponentModel.ISupportInitialize)view).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }



        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;

        private DevExpress.XtraBars.BarButtonItem btnNew;
        private DevExpress.XtraBars.BarButtonItem btnEdit;
        private DevExpress.XtraBars.BarButtonItem btnDelete;
        private DevExpress.XtraBars.BarButtonItem btnRefresh;

        private DevExpress.XtraGrid.GridControl grid;
        private DevExpress.XtraGrid.Views.Grid.GridView view;
    }
}
