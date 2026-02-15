using DevExpress.Utils;
using Foxoft.Models;
using Foxoft.Properties;

namespace Foxoft
{
    partial class FormTerminalList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormTerminalList));
            gC_TerminalList = new DevExpress.XtraGrid.GridControl();
            dcTerminalsBindingSource = new BindingSource(components);
            gV_TerminalList = new DevExpress.XtraGrid.Views.Grid.GridView();
            colTerminalId = new DevExpress.XtraGrid.Columns.GridColumn();
            colTerminalDesc = new DevExpress.XtraGrid.Columns.GridColumn();
            colCashRegisterCode = new DevExpress.XtraGrid.Columns.GridColumn();
            colTouchUIMode = new DevExpress.XtraGrid.Columns.GridColumn();
            colTouchScaleFactor = new DevExpress.XtraGrid.Columns.GridColumn();
            colIsDisabled = new DevExpress.XtraGrid.Columns.GridColumn();
            colRowGuid = new DevExpress.XtraGrid.Columns.GridColumn();
            ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            bBI_TerminalNew = new DevExpress.XtraBars.BarButtonItem();
            bBI_TerminalEdit = new DevExpress.XtraBars.BarButtonItem();
            bBI_TerminalDelete = new DevExpress.XtraBars.BarButtonItem();
            bBI_TerminalRefresh = new DevExpress.XtraBars.BarButtonItem();
            ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            ribbonStatusBar1 = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            ((System.ComponentModel.ISupportInitialize)gC_TerminalList).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dcTerminalsBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gV_TerminalList).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ribbonControl1).BeginInit();
            SuspendLayout();
            // 
            // gC_TerminalList
            // 
            gC_TerminalList.DataSource = dcTerminalsBindingSource;
            gC_TerminalList.Dock = DockStyle.Fill;
            gC_TerminalList.Location = new Point(0, 158);
            gC_TerminalList.MainView = gV_TerminalList;
            gC_TerminalList.Name = "gC_TerminalList";
            gC_TerminalList.Size = new Size(900, 470);
            gC_TerminalList.TabIndex = 0;
            gC_TerminalList.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gV_TerminalList });
            gC_TerminalList.ProcessGridKey += gC_TerminalList_ProcessGridKey;
            // 
            // dcTerminalsBindingSource
            // 
            dcTerminalsBindingSource.DataSource = typeof(DcTerminal);
            // 
            // gV_TerminalList
            // 
            gV_TerminalList.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { colTerminalId, colTerminalDesc, colCashRegisterCode, colTouchUIMode, colTouchScaleFactor, colIsDisabled, colRowGuid });
            gV_TerminalList.CustomizationFormBounds = new Rectangle(760, 248, 264, 272);
            gV_TerminalList.GridControl = gC_TerminalList;
            gV_TerminalList.Name = "gV_TerminalList";
            gV_TerminalList.OptionsFind.FindDelay = 100;
            gV_TerminalList.OptionsView.ShowGroupPanel = false;
            gV_TerminalList.FocusedRowChanged += gV_TerminalList_FocusedRowChanged;
            // 
            // colTerminalId
            // 
            colTerminalId.FieldName = "TerminalId";
            colTerminalId.Name = "colTerminalId";
            colTerminalId.Visible = true;
            colTerminalId.VisibleIndex = 0;
            // 
            // colTerminalDesc
            // 
            colTerminalDesc.FieldName = "TerminalDesc";
            colTerminalDesc.Name = "colTerminalDesc";
            colTerminalDesc.Visible = true;
            colTerminalDesc.VisibleIndex = 1;
            // 
            // colCashRegisterCode
            // 
            colCashRegisterCode.FieldName = "CashRegisterCode";
            colCashRegisterCode.Name = "colCashRegisterCode";
            colCashRegisterCode.Visible = true;
            colCashRegisterCode.VisibleIndex = 2;
            // 
            // colTouchUIMode
            // 
            colTouchUIMode.FieldName = "TouchUIMode";
            colTouchUIMode.Name = "colTouchUIMode";
            colTouchUIMode.Visible = true;
            colTouchUIMode.VisibleIndex = 3;
            // 
            // colTouchScaleFactor
            // 
            colTouchScaleFactor.FieldName = "TouchScaleFactor";
            colTouchScaleFactor.Name = "colTouchScaleFactor";
            colTouchScaleFactor.Visible = true;
            colTouchScaleFactor.VisibleIndex = 4;
            // 
            // colIsDisabled
            // 
            colIsDisabled.FieldName = "IsDisabled";
            colIsDisabled.Name = "colIsDisabled";
            colIsDisabled.Visible = true;
            colIsDisabled.VisibleIndex = 5;
            // 
            // colRowGuid
            // 
            colRowGuid.FieldName = "RowGuid";
            colRowGuid.Name = "colRowGuid";
            // 
            // ribbonControl1
            // 
            ribbonControl1.ExpandCollapseItem.Id = 0;
            ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] { ribbonControl1.ExpandCollapseItem, bBI_TerminalNew, bBI_TerminalEdit, bBI_TerminalDelete, bBI_TerminalRefresh });
            ribbonControl1.Location = new Point(0, 0);
            ribbonControl1.MaxItemId = 10;
            ribbonControl1.Name = "ribbonControl1";
            ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] { ribbonPage1 });
            ribbonControl1.Size = new Size(900, 158);
            ribbonControl1.StatusBar = ribbonStatusBar1;
            // 
            // bBI_TerminalNew
            // 
            bBI_TerminalNew.Caption = Resources.Common_New;
            bBI_TerminalNew.Id = 1;
            bBI_TerminalNew.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("bBI_TerminalNew.ImageOptions.SvgImage");
            bBI_TerminalNew.Name = "bBI_TerminalNew";
            bBI_TerminalNew.ItemClick += bBI_TerminalNew_ItemClick;
            // 
            // bBI_TerminalEdit
            // 
            bBI_TerminalEdit.Caption = Resources.Common_Edit;
            bBI_TerminalEdit.Id = 2;
            bBI_TerminalEdit.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("bBI_TerminalEdit.ImageOptions.SvgImage");
            bBI_TerminalEdit.Name = "bBI_TerminalEdit";
            bBI_TerminalEdit.ItemClick += bBI_TerminalEdit_ItemClick;
            // 
            // bBI_TerminalDelete
            // 
            bBI_TerminalDelete.Caption = Resources.Common_Delete;
            bBI_TerminalDelete.Id = 3;
            bBI_TerminalDelete.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("bBI_TerminalDelete.ImageOptions.SvgImage");
            bBI_TerminalDelete.Name = "bBI_TerminalDelete";
            bBI_TerminalDelete.ItemClick += bBI_TerminalDelete_ItemClick;
            // 
            // bBI_TerminalRefresh
            // 
            bBI_TerminalRefresh.Caption = Resources.Common_Refresh;
            bBI_TerminalRefresh.Id = 4;
            bBI_TerminalRefresh.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("bBI_TerminalRefresh.ImageOptions.SvgImage");
            bBI_TerminalRefresh.Name = "bBI_TerminalRefresh";
            bBI_TerminalRefresh.ItemClick += bBI_TerminalRefresh_ItemClick;
            // 
            // ribbonPage1
            // 
            ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] { ribbonPageGroup1 });
            ribbonPage1.Name = "ribbonPage1";
            ribbonPage1.Text = "Main";
            // 
            // ribbonPageGroup1
            // 
            ribbonPageGroup1.ItemLinks.Add(bBI_TerminalNew);
            ribbonPageGroup1.ItemLinks.Add(bBI_TerminalEdit);
            ribbonPageGroup1.ItemLinks.Add(bBI_TerminalDelete);
            ribbonPageGroup1.ItemLinks.Add(bBI_TerminalRefresh);
            ribbonPageGroup1.Name = "ribbonPageGroup1";
            ribbonPageGroup1.Text = "Manage";
            // 
            // ribbonStatusBar1
            // 
            ribbonStatusBar1.Location = new Point(0, 628);
            ribbonStatusBar1.Name = "ribbonStatusBar1";
            ribbonStatusBar1.Ribbon = ribbonControl1;
            ribbonStatusBar1.Size = new Size(900, 24);
            // 
            // FormTerminalList
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(900, 652);
            Controls.Add(gC_TerminalList);
            Controls.Add(ribbonStatusBar1);
            Controls.Add(ribbonControl1);
            KeyPreview = true;
            Name = "FormTerminalList";
            Ribbon = ribbonControl1;
            StartPosition = FormStartPosition.CenterScreen;
            StatusBar = ribbonStatusBar1;
            Text = "Terminals";
            Load += FormTerminalList_Load;
            KeyDown += FormTerminalList_KeyDown;
            ((System.ComponentModel.ISupportInitialize)gC_TerminalList).EndInit();
            ((System.ComponentModel.ISupportInitialize)dcTerminalsBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)gV_TerminalList).EndInit();
            ((System.ComponentModel.ISupportInitialize)ribbonControl1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DevExpress.XtraGrid.GridControl gC_TerminalList;
        private DevExpress.XtraGrid.Views.Grid.GridView gV_TerminalList;
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar1;
        private DevExpress.XtraBars.BarButtonItem bBI_TerminalNew;
        private DevExpress.XtraBars.BarButtonItem bBI_TerminalEdit;
        private DevExpress.XtraBars.BarButtonItem bBI_TerminalDelete;
        private DevExpress.XtraBars.BarButtonItem bBI_TerminalRefresh;
        private System.Windows.Forms.BindingSource dcTerminalsBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colTerminalId;
        private DevExpress.XtraGrid.Columns.GridColumn colTerminalDesc;
        private DevExpress.XtraGrid.Columns.GridColumn colIsDisabled;
        private DevExpress.XtraGrid.Columns.GridColumn colRowGuid;
        private DevExpress.XtraGrid.Columns.GridColumn colCashRegisterCode;
        private DevExpress.XtraGrid.Columns.GridColumn colTouchUIMode;
        private DevExpress.XtraGrid.Columns.GridColumn colTouchScaleFactor;
    }
}
