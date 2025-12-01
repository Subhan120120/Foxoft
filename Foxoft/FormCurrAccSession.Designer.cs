using Foxoft.Properties;

namespace Foxoft
{
    partial class FormCurrAccSession
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCurrAccSession));
            ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            bBI_Update = new DevExpress.XtraBars.BarButtonItem();
            bBI_KickUser = new DevExpress.XtraBars.BarButtonItem();
            ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            bindingSource1 = new BindingSource(components);
            gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            colPID = new DevExpress.XtraGrid.Columns.GridColumn();
            colCurrAccCode = new DevExpress.XtraGrid.Columns.GridColumn();
            colCurrAccDesc = new DevExpress.XtraGrid.Columns.GridColumn();
            colChildPID = new DevExpress.XtraGrid.Columns.GridColumn();
            colChildTitle = new DevExpress.XtraGrid.Columns.GridColumn();
            repositoryItemButtonEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            myGridControl1 = new MyGridControl();
            ((System.ComponentModel.ISupportInitialize)ribbon).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bindingSource1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)repositoryItemButtonEdit2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)myGridControl1).BeginInit();
            SuspendLayout();
            // 
            // ribbon
            // 
            ribbon.ExpandCollapseItem.Id = 0;
            ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] { ribbon.ExpandCollapseItem, bBI_Update, bBI_KickUser });
            ribbon.Location = new Point(0, 0);
            ribbon.MaxItemId = 3;
            ribbon.Name = "ribbon";
            ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] { ribbonPage1 });
            ribbon.Size = new Size(1216, 158);
            ribbon.StatusBar = ribbonStatusBar;
            // 
            // bBI_Update
            // 
            bBI_Update.Caption = Resources.Common_Refresh; // "Yenilə" → resx
            bBI_Update.Id = 1;
            bBI_Update.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("bBI_Update.ImageOptions.SvgImage");
            bBI_Update.Name = "bBI_Update";
            bBI_Update.ItemClick += bBI_Update_ItemClick;
            // 
            // bBI_KickUser
            // 
            bBI_KickUser.Caption = Resources.Form_CurrAccSession_KickUser;
            bBI_KickUser.Id = 2;
            bBI_KickUser.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("bBI_KickUser.ImageOptions.SvgImage");
            bBI_KickUser.Name = "bBI_KickUser";
            bBI_KickUser.ItemClick += bBI_KickUser_ItemClick;
            // 
            // ribbonPage1
            // 
            ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] { ribbonPageGroup1 });
            ribbonPage1.Name = "ribbonPage1";
            ribbonPage1.Text = Resources.Form_CurrAccSession_RibbonPage_Main;
            // 
            // ribbonPageGroup1
            // 
            ribbonPageGroup1.ItemLinks.Add(bBI_Update);
            ribbonPageGroup1.ItemLinks.Add(bBI_KickUser);
            ribbonPageGroup1.Name = "ribbonPageGroup1";
            ribbonPageGroup1.Text = "ribbonPageGroup1";
            // 
            // ribbonStatusBar
            // 
            ribbonStatusBar.Location = new Point(0, 595);
            ribbonStatusBar.Name = "ribbonStatusBar";
            ribbonStatusBar.Ribbon = ribbon;
            ribbonStatusBar.Size = new Size(1216, 24);
            // 
            // bindingSource1
            // 
            bindingSource1.DataSource = typeof(UserInfo);
            // 
            // gridView1
            // 
            gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { colPID, colCurrAccCode, colCurrAccDesc, colChildPID, colChildTitle });
            gridView1.GridControl = myGridControl1;
            gridView1.Name = "gridView1";
            gridView1.OptionsView.AllowCellMerge = true;
            gridView1.CellMerge += gridView1_CellMerge;
            // 
            // colPID
            // 
            colPID.FieldName = "PID";
            colPID.Name = "colPID";
            colPID.Visible = true;
            colPID.VisibleIndex = 0;
            // 
            // colCurrAccCode
            // 
            colCurrAccCode.FieldName = "CurrAccCode";
            colCurrAccCode.Name = "colCurrAccCode";
            // 
            // colCurrAccDesc
            // 
            colCurrAccDesc.FieldName = "CurrAccDesc";
            colCurrAccDesc.Name = "colCurrAccDesc";
            colCurrAccDesc.Visible = true;
            colCurrAccDesc.VisibleIndex = 1;
            // 
            // colChildPID
            // 
            colChildPID.FieldName = "ChildPID";
            colChildPID.Name = "colChildPID";
            // 
            // colChildTitle
            // 
            colChildTitle.ColumnEdit = repositoryItemButtonEdit2;
            colChildTitle.FieldName = "ChildTitle";
            colChildTitle.Name = "colChildTitle";
            colChildTitle.Visible = true;
            colChildTitle.VisibleIndex = 2;
            // 
            // repositoryItemButtonEdit2
            // 
            repositoryItemButtonEdit2.AutoHeight = false;
            repositoryItemButtonEdit2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Delete) });
            repositoryItemButtonEdit2.Name = "repositoryItemButtonEdit2";
            repositoryItemButtonEdit2.ButtonPressed += repositoryItemButtonEdit1_ButtonPressed;
            // 
            // myGridControl1
            // 
            myGridControl1.DataSource = bindingSource1;
            myGridControl1.Dock = DockStyle.Fill;
            myGridControl1.Location = new Point(0, 158);
            myGridControl1.MainView = gridView1;
            myGridControl1.MenuManager = ribbon;
            myGridControl1.Name = "myGridControl1";
            myGridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] { repositoryItemButtonEdit2 });
            myGridControl1.Size = new Size(1216, 437);
            myGridControl1.TabIndex = 2;
            myGridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gridView1 });
            // 
            // FormUser
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1216, 619);
            Controls.Add(myGridControl1);
            Controls.Add(ribbonStatusBar);
            Controls.Add(ribbon);
            Name = "FormUser";
            Ribbon = ribbon;
            StatusBar = ribbonStatusBar; 
            Text = Resources.Form_CurrAccSession_Caption;
            Load += RibbonForm1_Load;
            ((System.ComponentModel.ISupportInitialize)ribbon).EndInit();
            ((System.ComponentModel.ISupportInitialize)bindingSource1).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)repositoryItemButtonEdit2).EndInit();
            ((System.ComponentModel.ISupportInitialize)myGridControl1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraBars.BarButtonItem bBI_Update;
        private BindingSource bindingSource1;
        private DevExpress.XtraBars.BarButtonItem bBI_KickUser;
        private MyGridControl myGridControl1;
        private DevExpress.XtraGrid.Columns.GridColumn colPID;
        private DevExpress.XtraGrid.Columns.GridColumn colCurrAccCode;
        private DevExpress.XtraGrid.Columns.GridColumn colCurrAccDesc;
        private DevExpress.XtraGrid.Columns.GridColumn colChildPID;
        private DevExpress.XtraGrid.Columns.GridColumn colChildTitle;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryItemButtonEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repoBtnEdit_DeleteUserWindow;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryItemButtonEdit2;
    }
}