using Foxoft.Models;
using Foxoft.Properties;

namespace Foxoft
{
    partial class FormPaymentPlanList
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
            gC_PaymentPlanList = new DevExpress.XtraGrid.GridControl();
            dcPaymentPlansBindingSource = new BindingSource(components);
            gV_PaymentPlanList = new DevExpress.XtraGrid.Views.Grid.GridView();
            colPaymentPlanCode = new DevExpress.XtraGrid.Columns.GridColumn();
            colPaymentPlanDesc = new DevExpress.XtraGrid.Columns.GridColumn();
            colPaymentMethodId = new DevExpress.XtraGrid.Columns.GridColumn();
            colDurationInMonths = new DevExpress.XtraGrid.Columns.GridColumn();
            colCommissionRate = new DevExpress.XtraGrid.Columns.GridColumn();
            colIsDefault = new DevExpress.XtraGrid.Columns.GridColumn();
            ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            bBI_New = new DevExpress.XtraBars.BarButtonItem();
            bBI_Edit = new DevExpress.XtraBars.BarButtonItem();
            bBI_Delete = new DevExpress.XtraBars.BarButtonItem();
            bBI_Refresh = new DevExpress.XtraBars.BarButtonItem();
            bBI_ExportXlsx = new DevExpress.XtraBars.BarButtonItem();
            ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            ribbonStatusBar1 = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            ((System.ComponentModel.ISupportInitialize)gC_PaymentPlanList).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dcPaymentPlansBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gV_PaymentPlanList).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ribbonControl1).BeginInit();
            SuspendLayout();
            // 
            // gC_PaymentPlanList
            // 
            gC_PaymentPlanList.DataSource = dcPaymentPlansBindingSource;
            gC_PaymentPlanList.Dock = DockStyle.Fill;
            gC_PaymentPlanList.Location = new Point(0, 158);
            gC_PaymentPlanList.MainView = gV_PaymentPlanList;
            gC_PaymentPlanList.Name = "gC_PaymentPlanList";
            gC_PaymentPlanList.Size = new Size(858, 413);
            gC_PaymentPlanList.TabIndex = 0;
            gC_PaymentPlanList.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gV_PaymentPlanList });
            gC_PaymentPlanList.Paint += gC_PaymentPlanList_Paint;
            gC_PaymentPlanList.ProcessGridKey += gC_PaymentPlanList_ProcessGridKey;
            // 
            // dcPaymentPlansBindingSource
            // 
            dcPaymentPlansBindingSource.DataSource = typeof(DcPaymentPlan);
            // 
            // gV_PaymentPlanList
            // 
            gV_PaymentPlanList.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { colPaymentPlanCode, colPaymentPlanDesc, colPaymentMethodId, colDurationInMonths, colCommissionRate, colIsDefault });
            gV_PaymentPlanList.GridControl = gC_PaymentPlanList;
            gV_PaymentPlanList.Name = "gV_PaymentPlanList";
            gV_PaymentPlanList.OptionsFind.FindDelay = 100;
            gV_PaymentPlanList.OptionsView.ShowGroupPanel = false;
            gV_PaymentPlanList.FocusedRowChanged += gV_PaymentPlanList_FocusedRowChanged;
            gV_PaymentPlanList.ColumnFilterChanged += gV_PaymentPlanList_ColumnFilterChanged;
            gV_PaymentPlanList.DoubleClick += gV_PaymentPlanList_DoubleClick;
            // 
            // colPaymentPlanCode
            // 
            colPaymentPlanCode.FieldName = "PaymentPlanCode";
            colPaymentPlanCode.Name = "colPaymentPlanCode";
            colPaymentPlanCode.Visible = true;
            colPaymentPlanCode.VisibleIndex = 0;
            // 
            // colPaymentPlanDesc
            // 
            colPaymentPlanDesc.FieldName = "PaymentPlanDesc";
            colPaymentPlanDesc.Name = "colPaymentPlanDesc";
            colPaymentPlanDesc.Visible = true;
            colPaymentPlanDesc.VisibleIndex = 1;
            // 
            // colPaymentMethodId
            // 
            colPaymentMethodId.FieldName = "PaymentMethodId";
            colPaymentMethodId.Name = "colPaymentMethodId";
            colPaymentMethodId.Visible = true;
            colPaymentMethodId.VisibleIndex = 2;
            // 
            // colDurationInMonths
            // 
            colDurationInMonths.FieldName = "DurationInMonths";
            colDurationInMonths.Name = "colDurationInMonths";
            colDurationInMonths.Visible = true;
            colDurationInMonths.VisibleIndex = 3;
            // 
            // colCommissionRate
            // 
            colCommissionRate.FieldName = "CommissionRate";
            colCommissionRate.Name = "colCommissionRate";
            colCommissionRate.Visible = true;
            colCommissionRate.VisibleIndex = 4;
            // 
            // colIsDefault
            // 
            colIsDefault.FieldName = "IsDefault";
            colIsDefault.Name = "colIsDefault";
            colIsDefault.Visible = true;
            colIsDefault.VisibleIndex = 5;
            // 
            // ribbonControl1
            // 
            ribbonControl1.ExpandCollapseItem.Id = 0;
            ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] { ribbonControl1.ExpandCollapseItem, bBI_New, bBI_Edit, bBI_Delete, bBI_Refresh, bBI_ExportXlsx });
            ribbonControl1.Location = new Point(0, 0);
            ribbonControl1.MaxItemId = 6;
            ribbonControl1.Name = "ribbonControl1";
            ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] { ribbonPage1 });
            ribbonControl1.Size = new Size(858, 158);
            ribbonControl1.StatusBar = ribbonStatusBar1;
            // 
            // bBI_New
            // 
            bBI_New.Caption = Resources.Common_New;
            bBI_New.Id = 1;
            bBI_New.Name = "bBI_New";
            bBI_New.ItemClick += bBI_New_ItemClick;
            // 
            // bBI_Edit
            // 
            bBI_Edit.Caption = Resources.Common_Edit;
            bBI_Edit.Id = 2;
            bBI_Edit.Name = "bBI_Edit";
            bBI_Edit.ItemClick += bBI_Edit_ItemClick;
            // 
            // bBI_Delete
            // 
            bBI_Delete.Caption = Resources.Common_Delete;
            bBI_Delete.Id = 3;
            bBI_Delete.Name = "bBI_Delete";
            bBI_Delete.ItemClick += bBI_Delete_ItemClick;
            // 
            // bBI_Refresh
            // 
            bBI_Refresh.Caption = Resources.Common_Refresh;
            bBI_Refresh.Id = 4;
            bBI_Refresh.Name = "bBI_Refresh";
            bBI_Refresh.ItemClick += bBI_Refresh_ItemClick;
            // 
            // bBI_ExportXlsx
            // 
            bBI_ExportXlsx.Caption = Resources.Common_ExportToExcel;
            bBI_ExportXlsx.Id = 5;
            bBI_ExportXlsx.Name = "bBI_ExportXlsx";
            bBI_ExportXlsx.ItemClick += bBI_ExportXlsx_ItemClick;
            // 
            // ribbonPage1
            // 
            ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] { ribbonPageGroup1, ribbonPageGroup2 });
            ribbonPage1.Name = "ribbonPage1";
            ribbonPage1.Text = Resources.Form_PaymentPlanList_RibbonPage_Main;
            // 
            // ribbonPageGroup1
            // 
            ribbonPageGroup1.ItemLinks.Add(bBI_New);
            ribbonPageGroup1.ItemLinks.Add(bBI_Edit);
            ribbonPageGroup1.ItemLinks.Add(bBI_Delete);
            ribbonPageGroup1.ItemLinks.Add(bBI_Refresh);
            ribbonPageGroup1.Name = "ribbonPageGroup1";
            ribbonPageGroup1.Text = Resources.Form_PaymentPlanList_RibbonGroup_Manage;
            // 
            // ribbonPageGroup2
            // 
            ribbonPageGroup2.ItemLinks.Add(bBI_ExportXlsx);
            ribbonPageGroup2.Name = "ribbonPageGroup2";
            ribbonPageGroup2.Text = Resources.Form_PaymentPlanList_RibbonGroup_Report;
            // 
            // ribbonStatusBar1
            // 
            ribbonStatusBar1.Location = new Point(0, 571);
            ribbonStatusBar1.Name = "ribbonStatusBar1";
            ribbonStatusBar1.Ribbon = ribbonControl1;
            ribbonStatusBar1.Size = new Size(858, 24);
            // 
            // FormPaymentPlanList
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(858, 595);
            Controls.Add(gC_PaymentPlanList);
            Controls.Add(ribbonStatusBar1);
            Controls.Add(ribbonControl1);
            KeyPreview = true;
            Name = "FormPaymentPlanList";
            Ribbon = ribbonControl1;
            StartPosition = FormStartPosition.CenterScreen;
            StatusBar = ribbonStatusBar1;
            Text = Resources.Entity_PaymentPlan;
            KeyDown += FormPaymentPlanList_KeyDown;
            ((System.ComponentModel.ISupportInitialize)gC_PaymentPlanList).EndInit();
            ((System.ComponentModel.ISupportInitialize)dcPaymentPlansBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)gV_PaymentPlanList).EndInit();
            ((System.ComponentModel.ISupportInitialize)ribbonControl1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DevExpress.XtraGrid.GridControl gC_PaymentPlanList;
        private DevExpress.XtraGrid.Views.Grid.GridView gV_PaymentPlanList;
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar1;
        private DevExpress.XtraBars.BarButtonItem bBI_New;
        private DevExpress.XtraBars.BarButtonItem bBI_Edit;
        private DevExpress.XtraBars.BarButtonItem bBI_Delete;
        private DevExpress.XtraBars.BarButtonItem bBI_Refresh;
        private DevExpress.XtraBars.BarButtonItem bBI_ExportXlsx;
        private System.Windows.Forms.BindingSource dcPaymentPlansBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colPaymentPlanCode;
        private DevExpress.XtraGrid.Columns.GridColumn colPaymentPlanDesc;
        private DevExpress.XtraGrid.Columns.GridColumn colPaymentMethodId;
        private DevExpress.XtraGrid.Columns.GridColumn colDurationInMonths;
        private DevExpress.XtraGrid.Columns.GridColumn colCommissionRate;
        private DevExpress.XtraGrid.Columns.GridColumn colIsDefault;
    }
}
