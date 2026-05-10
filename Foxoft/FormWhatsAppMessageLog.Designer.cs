using DevExpress.Utils;
using DevExpress.Utils.Svg;
using Foxoft.Models;
using Foxoft.Properties;
using System.ComponentModel;

namespace Foxoft
{
    partial class FormWhatsAppMessageLog
    {
        private IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            components = new Container();
            ComponentResourceManager resources = new ComponentResourceManager(typeof(FormWhatsAppMessageLog));
            gC_WhatsAppMessageLogList = new DevExpress.XtraGrid.GridControl();
            trWhatsAppMessageLogBindingSource = new BindingSource(components);
            gV_WhatsAppMessageLogList = new DevExpress.XtraGrid.Views.Grid.GridView();
            colCreatedUserName = new DevExpress.XtraGrid.Columns.GridColumn();
            colCreatedDate = new DevExpress.XtraGrid.Columns.GridColumn();
            colWhatsAppMessageLogId = new DevExpress.XtraGrid.Columns.GridColumn();
            colDocumentHeaderId = new DevExpress.XtraGrid.Columns.GridColumn();
            colReceiverPhoneNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            colMessageType = new DevExpress.XtraGrid.Columns.GridColumn();
            colMessage = new DevExpress.XtraGrid.Columns.GridColumn();
            colSender = new DevExpress.XtraGrid.Columns.GridColumn();
            colSenderName = new DevExpress.XtraGrid.Columns.GridColumn();
            colCurrAccCode = new DevExpress.XtraGrid.Columns.GridColumn();
            colCurrAccDesc = new DevExpress.XtraGrid.Columns.GridColumn();
            ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            bBI_ExportXlsx = new DevExpress.XtraBars.BarButtonItem();
            bBI_Refresh = new DevExpress.XtraBars.BarButtonItem();
            ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            ribbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            ribbonStatusBar1 = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            svgImageCollection1 = new SvgImageCollection(components);
            ((ISupportInitialize)gC_WhatsAppMessageLogList).BeginInit();
            ((ISupportInitialize)trWhatsAppMessageLogBindingSource).BeginInit();
            ((ISupportInitialize)gV_WhatsAppMessageLogList).BeginInit();
            ((ISupportInitialize)ribbonControl1).BeginInit();
            ((ISupportInitialize)svgImageCollection1).BeginInit();
            SuspendLayout();
            // 
            // svgImageCollection1
            // 
            svgImageCollection1.Add("Refresh", "image://svgimages/actions/refresh.svg");
            svgImageCollection1.Add("Export", "image://svgimages/export/exporttoxlsx.svg");
            // 
            // gC_WhatsAppMessageLogList
            // 
            gC_WhatsAppMessageLogList.DataSource = trWhatsAppMessageLogBindingSource;
            gC_WhatsAppMessageLogList.Dock = DockStyle.Fill;
            gC_WhatsAppMessageLogList.Location = new Point(0, 158);
            gC_WhatsAppMessageLogList.MainView = gV_WhatsAppMessageLogList;
            gC_WhatsAppMessageLogList.MenuManager = ribbonControl1;
            gC_WhatsAppMessageLogList.Name = "gC_WhatsAppMessageLogList";
            gC_WhatsAppMessageLogList.Size = new Size(1100, 462);
            gC_WhatsAppMessageLogList.TabIndex = 0;
            gC_WhatsAppMessageLogList.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gV_WhatsAppMessageLogList });
            gC_WhatsAppMessageLogList.ProcessGridKey += gC_WhatsAppMessageLogList_ProcessGridKey;
            // 
            // trWhatsAppMessageLogBindingSource
            // 
            trWhatsAppMessageLogBindingSource.DataSource = typeof(TrWhatsAppMessageLog);
            // 
            // gV_WhatsAppMessageLogList
            // 
            gV_WhatsAppMessageLogList.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { colWhatsAppMessageLogId, colDocumentHeaderId, colCreatedDate, colCreatedUserName, colCurrAccCode, colCurrAccDesc, colReceiverPhoneNumber, colMessageType, colMessage, colSender, colSenderName });
            gV_WhatsAppMessageLogList.GridControl = gC_WhatsAppMessageLogList;
            gV_WhatsAppMessageLogList.Name = "gV_WhatsAppMessageLogList";
            gV_WhatsAppMessageLogList.OptionsBehavior.Editable = false;
            gV_WhatsAppMessageLogList.OptionsFind.FindDelay = 100;
            gV_WhatsAppMessageLogList.OptionsView.ShowAutoFilterRow = true;
            gV_WhatsAppMessageLogList.OptionsView.ShowGroupPanel = false;
            // 
            // colWhatsAppMessageLogId
            // 
            colWhatsAppMessageLogId.FieldName = "WhatsAppMessageLogId";
            colWhatsAppMessageLogId.Name = "colWhatsAppMessageLogId";
            // 
            // colDocumentHeaderId
            // 
            colDocumentHeaderId.FieldName = "DocumentHeaderId";
            colDocumentHeaderId.Name = "colDocumentHeaderId";
            // 
            // colCreatedUserName
            // 
            colCreatedUserName.Caption = Resources.Entity_Base_CreatedUserName;
            colCreatedUserName.FieldName = "CreatedUserName";
            colCreatedUserName.Name = "colCreatedUserName";
            colCreatedUserName.Visible = true;
            colCreatedUserName.VisibleIndex = 1;
            // 
            // colCreatedDate
            // 
            colCreatedDate.Caption = Resources.Entity_Base_CreatedDate;
            colCreatedDate.FieldName = "CreatedDate";
            colCreatedDate.Name = "colCreatedDate";
            colCreatedDate.Visible = true;
            colCreatedDate.VisibleIndex = 0;
            // 
            // colReceiverPhoneNumber
            // 
            colReceiverPhoneNumber.Caption = Resources.Common_Phone;
            colReceiverPhoneNumber.FieldName = "ReceiverPhoneNumber";
            colReceiverPhoneNumber.Name = "colReceiverPhoneNumber";
            colReceiverPhoneNumber.Visible = true;
            colReceiverPhoneNumber.VisibleIndex = 3;
            // 
            // colMessageType
            // 
            colMessageType.Caption = Resources.Entity_TrWhatsAppMessageLog_MessageType;
            colMessageType.FieldName = "MessageType";
            colMessageType.Name = "colMessageType";
            colMessageType.Visible = true;
            colMessageType.VisibleIndex = 4;
            // 
            // colMessage
            // 
            colMessage.Caption = Resources.Common_Message;
            colMessage.FieldName = "Message";
            colMessage.Name = "colMessage";
            colMessage.Visible = true;
            colMessage.VisibleIndex = 5;
            // 
            // colSender
            // 
            colSender.Caption = Resources.Common_Sender;
            colSender.FieldName = "Sender";
            colSender.Name = "colSender";
            colSender.Visible = true;
            colSender.VisibleIndex = 6;
            // 
            // colSenderName
            // 
            colSenderName.Caption = Resources.Common_Sender + " " + Resources.Entity_CurrAcc_FirstName;
            colSenderName.FieldName = "DcSender.CurrAccDesc";
            colSenderName.Name = "colSenderName";
            colSenderName.Visible = true;
            colSenderName.VisibleIndex = 7;
            // 
            // colCurrAccCode
            // 
            colCurrAccCode.Caption = Resources.Entity_CurrAcc_CurrAccCode;
            colCurrAccCode.FieldName = "CurrAccCode";
            colCurrAccCode.Name = "colCurrAccCode";
            colCurrAccCode.Visible = true;
            colCurrAccCode.VisibleIndex = 2;
            // 
            // colCurrAccDesc
            // 
            colCurrAccDesc.Caption = Resources.Entity_CurrAcc_CurrAccDesc;
            colCurrAccDesc.FieldName = "DcCurrAcc.CurrAccDesc";
            colCurrAccDesc.Name = "colCurrAccDesc";
            colCurrAccDesc.Visible = true;
            colCurrAccDesc.VisibleIndex = 3;
            // 
            // ribbonControl1
            // 
            ribbonControl1.ExpandCollapseItem.Id = 0;
            ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] { ribbonControl1.ExpandCollapseItem, bBI_ExportXlsx, bBI_Refresh });
            ribbonControl1.Location = new Point(0, 0);
            ribbonControl1.MaxItemId = 3;
            ribbonControl1.Name = "ribbonControl1";
            ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] { ribbonPage1 });
            ribbonControl1.Size = new Size(1100, 158);
            ribbonControl1.StatusBar = ribbonStatusBar1;
            // 
            // bBI_ExportXlsx
            // 
            bBI_ExportXlsx.Caption = Resources.Common_ExportToExcel;
            bBI_ExportXlsx.Id = 1;
            bBI_ExportXlsx.ImageOptions.SvgImage = svgImageCollection1["Export"];
            bBI_ExportXlsx.Name = "bBI_ExportXlsx";
            bBI_ExportXlsx.ItemClick += bBI_ExportXlsx_ItemClick;
            // 
            // bBI_Refresh
            // 
            bBI_Refresh.Caption = Resources.Common_Refresh;
            bBI_Refresh.Id = 2;
            bBI_Refresh.ImageOptions.SvgImage = svgImageCollection1["Refresh"];
            bBI_Refresh.Name = "bBI_Refresh";
            bBI_Refresh.ItemClick += bBI_Refresh_ItemClick;
            // 
            // ribbonPage1
            // 
            ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] { ribbonPageGroup1, ribbonPageGroup3 });
            ribbonPage1.Name = "ribbonPage1";
            ribbonPage1.Text = Resources.Form_WhatsAppMessageLog;
            // 
            // ribbonPageGroup1
            // 
            ribbonPageGroup1.ItemLinks.Add(bBI_Refresh);
            ribbonPageGroup1.Name = "ribbonPageGroup1";
            ribbonPageGroup1.Text = Resources.Common_Operations;
            // 
            // ribbonPageGroup3
            // 
            ribbonPageGroup3.ItemLinks.Add(bBI_ExportXlsx);
            ribbonPageGroup3.Name = "ribbonPageGroup3";
            ribbonPageGroup3.Text = Resources.Common_Export;
            // 
            // ribbonStatusBar1
            // 
            ribbonStatusBar1.Location = new Point(0, 620);
            ribbonStatusBar1.Name = "ribbonStatusBar1";
            ribbonStatusBar1.Ribbon = ribbonControl1;
            ribbonStatusBar1.Size = new Size(1100, 24);
            // 
            // FormWhatsAppMessageLog
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1100, 644);
            Controls.Add(gC_WhatsAppMessageLogList);
            Controls.Add(ribbonStatusBar1);
            Controls.Add(ribbonControl1);
            Name = "FormWhatsAppMessageLog";
            Ribbon = ribbonControl1;
            StartPosition = FormStartPosition.CenterScreen;
            StatusBar = ribbonStatusBar1;
            Text = Resources.Form_WhatsAppMessageLog;
            Load += FormWhatsAppMessageLog_Load;
            ((ISupportInitialize)gC_WhatsAppMessageLogList).EndInit();
            ((ISupportInitialize)trWhatsAppMessageLogBindingSource).EndInit();
            ((ISupportInitialize)gV_WhatsAppMessageLogList).EndInit();
            ((ISupportInitialize)ribbonControl1).EndInit();
            ((ISupportInitialize)svgImageCollection1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DevExpress.XtraGrid.GridControl gC_WhatsAppMessageLogList;
        private BindingSource trWhatsAppMessageLogBindingSource;
        private DevExpress.XtraGrid.Views.Grid.GridView gV_WhatsAppMessageLogList;
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.BarButtonItem bBI_ExportXlsx;
        private DevExpress.XtraBars.BarButtonItem bBI_Refresh;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup3;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar1;
        private DevExpress.XtraGrid.Columns.GridColumn colCreatedUserName;
        private DevExpress.XtraGrid.Columns.GridColumn colCreatedDate;
        private DevExpress.XtraGrid.Columns.GridColumn colWhatsAppMessageLogId;
        private DevExpress.XtraGrid.Columns.GridColumn colDocumentHeaderId;
        private DevExpress.XtraGrid.Columns.GridColumn colReceiverPhoneNumber;
        private DevExpress.XtraGrid.Columns.GridColumn colMessageType;
        private DevExpress.XtraGrid.Columns.GridColumn colMessage;
        private DevExpress.XtraGrid.Columns.GridColumn colSender;
        private DevExpress.XtraGrid.Columns.GridColumn colSenderName;
        private DevExpress.XtraGrid.Columns.GridColumn colCurrAccCode;
        private DevExpress.XtraGrid.Columns.GridColumn colCurrAccDesc;
        private SvgImageCollection svgImageCollection1;
    }
}
