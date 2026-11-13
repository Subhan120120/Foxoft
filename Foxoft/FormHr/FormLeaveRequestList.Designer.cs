namespace Foxoft
{
    partial class FormLeaveRequestList
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.btnNew = new DevExpress.XtraBars.BarButtonItem();
            this.btnEdit = new DevExpress.XtraBars.BarButtonItem();
            this.btnDelete = new DevExpress.XtraBars.BarButtonItem();
            this.btnApprove = new DevExpress.XtraBars.BarButtonItem();
            this.btnReject = new DevExpress.XtraBars.BarButtonItem();
            this.btnRefresh = new DevExpress.XtraBars.BarButtonItem();
            this.btnClose = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbon
            // 
            this.ribbon.ExpandCollapseItem.Id = 0;
            this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
                this.ribbon.ExpandCollapseItem,
                this.btnNew,
                this.btnEdit,
                this.btnDelete,
                this.btnApprove,
                this.btnReject,
                this.btnRefresh,
                this.btnClose
            });
            this.ribbon.Location = new System.Drawing.Point(0, 0);
            this.ribbon.MaxItemId = 8;
            this.ribbon.Name = "ribbon";
            this.ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
                this.ribbonPage1
            });
            this.ribbon.Size = new System.Drawing.Size(1000, 158);
            // 
            // btnNew
            // 
            this.btnNew.Caption = Foxoft.Properties.Resources.Common_New;
            this.btnNew.Id = 1;
            this.btnNew.Name = "btnNew";
            // 
            // btnEdit
            // 
            this.btnEdit.Caption = Foxoft.Properties.Resources.Common_Edit;
            this.btnEdit.Id = 2;
            this.btnEdit.Name = "btnEdit";
            // 
            // btnDelete
            // 
            this.btnDelete.Caption = Foxoft.Properties.Resources.Common_Delete;
            this.btnDelete.Id = 3;
            this.btnDelete.Name = "btnDelete";
            // 
            // btnApprove
            // 
            this.btnApprove.Caption = Foxoft.Properties.Resources.Form_LeaveRequest_Approve;
            this.btnApprove.Id = 4;
            this.btnApprove.Name = "btnApprove";
            // 
            // btnReject
            // 
            this.btnReject.Caption = Foxoft.Properties.Resources.Form_LeaveRequest_Reject;
            this.btnReject.Id = 5;
            this.btnReject.Name = "btnReject";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Caption = Foxoft.Properties.Resources.Common_Refresh;
            this.btnRefresh.Id = 6;
            this.btnRefresh.Name = "btnRefresh";
            // 
            // btnClose
            // 
            this.btnClose.Caption = Foxoft.Properties.Resources.Common_Close;
            this.btnClose.Id = 7;
            this.btnClose.Name = "btnClose";
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
                this.ribbonPageGroup1,
                this.ribbonPageGroup2
            });
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = Foxoft.Properties.Resources.ERP_ACE_LeaveRequests;
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.btnNew);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnEdit);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnDelete);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnRefresh);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnClose);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = Foxoft.Properties.Resources.Common_Operations;
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.ItemLinks.Add(this.btnApprove);
            this.ribbonPageGroup2.ItemLinks.Add(this.btnReject);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            this.ribbonPageGroup2.Text = "Təsdiqləmə";
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 158);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.MenuManager = this.ribbon;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1000, 442);
            this.gridControl1.TabIndex = 1;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
                this.gridView1
            });
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // FormLeaveRequestList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 600);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.ribbon);
            this.Name = "FormLeaveRequestList";
            this.Ribbon = this.ribbon;
            this.Text = Foxoft.Properties.Resources.Form_LeaveRequestList_Caption;
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraBars.BarButtonItem btnNew;
        private DevExpress.XtraBars.BarButtonItem btnEdit;
        private DevExpress.XtraBars.BarButtonItem btnDelete;
        private DevExpress.XtraBars.BarButtonItem btnApprove;
        private DevExpress.XtraBars.BarButtonItem btnReject;
        private DevExpress.XtraBars.BarButtonItem btnRefresh;
        private DevExpress.XtraBars.BarButtonItem btnClose;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
    }
}
