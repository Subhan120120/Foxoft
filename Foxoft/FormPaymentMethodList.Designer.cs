using Foxoft.Models;
using Foxoft.Properties;

namespace Foxoft
{
    partial class FormPaymentMethodList
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
            gC_PaymentMethodList = new MyGridControl();
            dcPaymentMethodsBindingSource = new BindingSource(components);
            gV_PaymentMethodList = new MyGridView();
            colPaymentMethodId = new DevExpress.XtraGrid.Columns.GridColumn();
            colPaymentMethodDesc = new DevExpress.XtraGrid.Columns.GridColumn();
            colPaymentTypeCode = new DevExpress.XtraGrid.Columns.GridColumn();
            colIsRedirected = new DevExpress.XtraGrid.Columns.GridColumn();
            colIsDefault = new DevExpress.XtraGrid.Columns.GridColumn();
            colIsDisabled = new DevExpress.XtraGrid.Columns.GridColumn();
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
            ((System.ComponentModel.ISupportInitialize)gC_PaymentMethodList).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dcPaymentMethodsBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gV_PaymentMethodList).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ribbonControl1).BeginInit();
            SuspendLayout();
            // 
            // gC_PaymentMethodList
            // 
            gC_PaymentMethodList.DataSource = dcPaymentMethodsBindingSource;
            gC_PaymentMethodList.Dock = DockStyle.Fill;
            gC_PaymentMethodList.Location = new Point(0, 158);
            gC_PaymentMethodList.MainView = gV_PaymentMethodList;
            gC_PaymentMethodList.Name = "gC_PaymentMethodList";
            gC_PaymentMethodList.Size = new Size(858, 413);
            gC_PaymentMethodList.TabIndex = 0;
            gC_PaymentMethodList.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gV_PaymentMethodList });
            gC_PaymentMethodList.Paint += gC_PaymentMethodList_Paint;
            gC_PaymentMethodList.ProcessGridKey += gC_PaymentMethodList_ProcessGridKey;
            // 
            // dcPaymentMethodsBindingSource
            // 
            dcPaymentMethodsBindingSource.DataSource = typeof(DcPaymentMethod);
            // 
            // gV_PaymentMethodList
            // 
            gV_PaymentMethodList.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { colPaymentMethodId, colPaymentMethodDesc, colPaymentTypeCode, colIsRedirected, colIsDefault, colIsDisabled });
            gV_PaymentMethodList.GridControl = gC_PaymentMethodList;
            gV_PaymentMethodList.Name = "gV_PaymentMethodList";
            gV_PaymentMethodList.OptionsFind.FindDelay = 100;
            gV_PaymentMethodList.OptionsView.ShowGroupPanel = false;
            gV_PaymentMethodList.FocusedRowChanged += gV_PaymentMethodList_FocusedRowChanged;
            gV_PaymentMethodList.ColumnFilterChanged += gV_PaymentMethodList_ColumnFilterChanged;
            gV_PaymentMethodList.DoubleClick += gV_PaymentMethodList_DoubleClick;
            // 
            // colPaymentMethodId
            // 
            colPaymentMethodId.FieldName = "PaymentMethodId";
            colPaymentMethodId.Name = "colPaymentMethodId";
            colPaymentMethodId.Visible = true;
            colPaymentMethodId.VisibleIndex = 0;
            // 
            // colPaymentMethodDesc
            // 
            colPaymentMethodDesc.FieldName = "PaymentMethodDesc";
            colPaymentMethodDesc.Name = "colPaymentMethodDesc";
            colPaymentMethodDesc.Visible = true;
            colPaymentMethodDesc.VisibleIndex = 1;
            // 
            // colPaymentTypeCode
            // 
            colPaymentTypeCode.FieldName = "PaymentTypeCode";
            colPaymentTypeCode.Name = "colPaymentTypeCode";
            colPaymentTypeCode.Visible = true;
            colPaymentTypeCode.VisibleIndex = 2;
            // 
            // colIsRedirected
            // 
            colIsRedirected.FieldName = "IsRedirected";
            colIsRedirected.Name = "colIsRedirected";
            colIsRedirected.Visible = true;
            colIsRedirected.VisibleIndex = 3;
            // 
            // colIsDefault
            // 
            colIsDefault.FieldName = "IsDefault";
            colIsDefault.Name = "colIsDefault";
            colIsDefault.Visible = true;
            colIsDefault.VisibleIndex = 4;
            // 
            // colIsDisabled
            // 
            colIsDisabled.FieldName = "IsDisabled";
            colIsDisabled.Name = "colIsDisabled";
            colIsDisabled.Visible = true;
            colIsDisabled.VisibleIndex = 5;
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
            ribbonPage1.Text = Resources.Form_PaymentMethodList_RibbonPage_Main;
            // 
            // ribbonPageGroup1
            // 
            ribbonPageGroup1.ItemLinks.Add(bBI_New);
            ribbonPageGroup1.ItemLinks.Add(bBI_Edit);
            ribbonPageGroup1.ItemLinks.Add(bBI_Delete);
            ribbonPageGroup1.ItemLinks.Add(bBI_Refresh);
            ribbonPageGroup1.Name = "ribbonPageGroup1";
            ribbonPageGroup1.Text = Resources.Form_PaymentMethodList_RibbonGroup_Manage;
            // 
            // ribbonPageGroup2
            // 
            ribbonPageGroup2.ItemLinks.Add(bBI_ExportXlsx);
            ribbonPageGroup2.Name = "ribbonPageGroup2";
            ribbonPageGroup2.Text = Resources.Form_PaymentMethodList_RibbonGroup_Report;
            // 
            // ribbonStatusBar1
            // 
            ribbonStatusBar1.Location = new Point(0, 571);
            ribbonStatusBar1.Name = "ribbonStatusBar1";
            ribbonStatusBar1.Ribbon = ribbonControl1;
            ribbonStatusBar1.Size = new Size(858, 24);
            // 
            // FormPaymentMethodList
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(858, 595);
            Controls.Add(gC_PaymentMethodList);
            Controls.Add(ribbonStatusBar1);
            Controls.Add(ribbonControl1);
            KeyPreview = true;
            Name = "FormPaymentMethodList";
            Ribbon = ribbonControl1;
            StartPosition = FormStartPosition.CenterScreen;
            StatusBar = ribbonStatusBar1;
            Text = Resources.Entity_PaymentMethod;
            KeyDown += FormPaymentMethodList_KeyDown;
            ((System.ComponentModel.ISupportInitialize)gC_PaymentMethodList).EndInit();
            ((System.ComponentModel.ISupportInitialize)dcPaymentMethodsBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)gV_PaymentMethodList).EndInit();
            ((System.ComponentModel.ISupportInitialize)ribbonControl1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MyGridControl gC_PaymentMethodList;
        private MyGridView gV_PaymentMethodList;
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
        private System.Windows.Forms.BindingSource dcPaymentMethodsBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colPaymentMethodId;
        private DevExpress.XtraGrid.Columns.GridColumn colPaymentMethodDesc;
        private DevExpress.XtraGrid.Columns.GridColumn colPaymentTypeCode;
        private DevExpress.XtraGrid.Columns.GridColumn colIsRedirected;
        private DevExpress.XtraGrid.Columns.GridColumn colIsDefault;
        private DevExpress.XtraGrid.Columns.GridColumn colIsDisabled;
    }
}
