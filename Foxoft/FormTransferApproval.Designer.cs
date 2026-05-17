using Foxoft.Properties;

namespace Foxoft
{
    partial class FormTransferApproval
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
            ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            BBI_Approve = new DevExpress.XtraBars.BarButtonItem();
            BBI_Reject = new DevExpress.XtraBars.BarButtonItem();
            BBI_Refresh = new DevExpress.XtraBars.BarButtonItem();
            ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            gridControl1 = new DevExpress.XtraGrid.GridControl();
            gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)ribbonControl1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridControl1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridView1).BeginInit();
            SuspendLayout();
            // 
            // ribbonControl1
            // 
            ribbonControl1.ExpandCollapseItem.Id = 0;
            ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] { ribbonControl1.ExpandCollapseItem, BBI_Approve, BBI_Reject, BBI_Refresh });
            ribbonControl1.Location = new System.Drawing.Point(0, 0);
            ribbonControl1.MaxItemId = 4;
            ribbonControl1.Name = "ribbonControl1";
            ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] { ribbonPage1 });
            ribbonControl1.Size = new System.Drawing.Size(900, 158);
            // 
            // BBI_Approve
            // 
            BBI_Approve.Caption = Resources.Form_TransferApproval_Button_Approve;
            BBI_Approve.Id = 1;
            BBI_Approve.ImageOptions.SvgImage = DevExpress.Utils.Svg.SvgImage.FromResources("DevExpress.Utils.Svg.SvgImages.Actions.Apply.svg", typeof(DevExpress.Utils.Svg.SvgImage).Assembly);
            BBI_Approve.Name = "BBI_Approve";
            BBI_Approve.ItemClick += BBI_Approve_ItemClick;
            // 
            // BBI_Reject
            // 
            BBI_Reject.Caption = Resources.Form_TransferApproval_Button_Reject;
            BBI_Reject.Id = 2;
            BBI_Reject.ImageOptions.SvgImage = DevExpress.Utils.Svg.SvgImage.FromResources("DevExpress.Utils.Svg.SvgImages.Actions.Cancel.svg", typeof(DevExpress.Utils.Svg.SvgImage).Assembly);
            BBI_Reject.Name = "BBI_Reject";
            BBI_Reject.ItemClick += BBI_Reject_ItemClick;
            // 
            // BBI_Refresh
            // 
            BBI_Refresh.Caption = Resources.Form_TransferApproval_Button_Refresh;
            BBI_Refresh.Id = 3;
            BBI_Refresh.ImageOptions.SvgImage = DevExpress.Utils.Svg.SvgImage.FromResources("DevExpress.Utils.Svg.SvgImages.Actions.Refresh.svg", typeof(DevExpress.Utils.Svg.SvgImage).Assembly);
            BBI_Refresh.Name = "BBI_Refresh";
            BBI_Refresh.ItemClick += BBI_Refresh_ItemClick;
            // 
            // ribbonPage1
            // 
            ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] { ribbonPageGroup1 });
            ribbonPage1.Name = "ribbonPage1";
            ribbonPage1.Text = Resources.Form_TransferApproval_Caption;
            // 
            // ribbonPageGroup1
            // 
            ribbonPageGroup1.ItemLinks.Add(BBI_Approve);
            ribbonPageGroup1.ItemLinks.Add(BBI_Reject);
            ribbonPageGroup1.ItemLinks.Add(BBI_Refresh);
            ribbonPageGroup1.Name = "ribbonPageGroup1";
            ribbonPageGroup1.Text = Resources.Form_TransferApproval_Caption;
            // 
            // gridControl1
            // 
            gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            gridControl1.Location = new System.Drawing.Point(0, 158);
            gridControl1.MainView = gridView1;
            gridControl1.Name = "gridControl1";
            gridControl1.Size = new System.Drawing.Size(900, 442);
            gridControl1.TabIndex = 1;
            gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gridView1 });
            // 
            // gridView1
            // 
            gridView1.GridControl = gridControl1;
            gridView1.Name = "gridView1";
            gridView1.OptionsBehavior.Editable = false;
            gridView1.OptionsView.ShowAutoFilterRow = true;
            gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // FormTransferApproval
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(900, 600);
            Controls.Add(gridControl1);
            Controls.Add(ribbonControl1);
            Name = "FormTransferApproval";
            Ribbon = ribbonControl1;
            Text = Resources.Form_TransferApproval_Caption;
            ((System.ComponentModel.ISupportInitialize)ribbonControl1).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridControl1).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.BarButtonItem BBI_Approve;
        private DevExpress.XtraBars.BarButtonItem BBI_Reject;
        private DevExpress.XtraBars.BarButtonItem BBI_Refresh;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
    }
}
