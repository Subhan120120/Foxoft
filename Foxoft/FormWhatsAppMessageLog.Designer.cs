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
            gC_WhatsAppMessageLogList = new DevExpress.XtraGrid.GridControl();
            trWhatsAppMessageLogBindingSource = new BindingSource(components);
            gV_WhatsAppMessageLogList = new DevExpress.XtraGrid.Views.Grid.GridView();
            colWhatsAppMessageLogId = new DevExpress.XtraGrid.Columns.GridColumn();
            colDocumentHeaderId = new DevExpress.XtraGrid.Columns.GridColumn();
            colCreatedDate = new DevExpress.XtraGrid.Columns.GridColumn();
            colCreatedUserName = new DevExpress.XtraGrid.Columns.GridColumn();
            colCurrAccCode = new DevExpress.XtraGrid.Columns.GridColumn();
            colCurrAccDesc = new DevExpress.XtraGrid.Columns.GridColumn();
            colReceiverPhoneNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            colMessageType = new DevExpress.XtraGrid.Columns.GridColumn();
            colMessage = new DevExpress.XtraGrid.Columns.GridColumn();
            colIsSuccessful = new DevExpress.XtraGrid.Columns.GridColumn();
            colSender = new DevExpress.XtraGrid.Columns.GridColumn();
            colSenderName = new DevExpress.XtraGrid.Columns.GridColumn();
            colImagePreview = new DevExpress.XtraGrid.Columns.GridColumn();
            repoPictureEdit = new DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit();
            colSendAgain = new DevExpress.XtraGrid.Columns.GridColumn();
            repoBtn_SendAgain = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            colImageFilePath = new DevExpress.XtraGrid.Columns.GridColumn();
            ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            bBI_ExportXlsx = new DevExpress.XtraBars.BarButtonItem();
            bBI_Refresh = new DevExpress.XtraBars.BarButtonItem();
            bBI_SendSelected = new DevExpress.XtraBars.BarButtonItem();
            bBI_SendAllUnsent = new DevExpress.XtraBars.BarButtonItem();
            ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            ribbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            ribbonStatusBar1 = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            repoTextEmpty = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            svgImageCollection1 = new SvgImageCollection(components);
            panelSummary = new DevExpress.XtraEditors.PanelControl();
            panelCardBalance = new DevExpress.XtraEditors.PanelControl();
            svgCardBalance_ImageBox = new DevExpress.XtraEditors.SvgImageBox();
            lblCardBalance_Subtitle = new DevExpress.XtraEditors.LabelControl();
            lblCardBalance_Value = new DevExpress.XtraEditors.LabelControl();
            lblCardBalance_Title = new DevExpress.XtraEditors.LabelControl();
            panelCardToday = new DevExpress.XtraEditors.PanelControl();
            svgCardToday_ImageBox = new DevExpress.XtraEditors.SvgImageBox();
            lblCardToday_Subtitle = new DevExpress.XtraEditors.LabelControl();
            lblCardToday_Value = new DevExpress.XtraEditors.LabelControl();
            lblCardToday_Title = new DevExpress.XtraEditors.LabelControl();
            panelCardLast30Days = new DevExpress.XtraEditors.PanelControl();
            svgCardLast30Days_ImageBox = new DevExpress.XtraEditors.SvgImageBox();
            lblCardLast30Days_Subtitle = new DevExpress.XtraEditors.LabelControl();
            lblCardLast30Days_Value = new DevExpress.XtraEditors.LabelControl();
            lblCardLast30Days_Title = new DevExpress.XtraEditors.LabelControl();
            panelCardTotal = new DevExpress.XtraEditors.PanelControl();
            svgCardTotal_ImageBox = new DevExpress.XtraEditors.SvgImageBox();
            lblCardTotal_Subtitle = new DevExpress.XtraEditors.LabelControl();
            lblCardTotal_Value = new DevExpress.XtraEditors.LabelControl();
            lblCardTotal_Title = new DevExpress.XtraEditors.LabelControl();
            ((ISupportInitialize)gC_WhatsAppMessageLogList).BeginInit();
            ((ISupportInitialize)trWhatsAppMessageLogBindingSource).BeginInit();
            ((ISupportInitialize)gV_WhatsAppMessageLogList).BeginInit();
            ((ISupportInitialize)repoPictureEdit).BeginInit();
            ((ISupportInitialize)repoBtn_SendAgain).BeginInit();
            ((ISupportInitialize)ribbonControl1).BeginInit();
            ((ISupportInitialize)repoTextEmpty).BeginInit();
            ((ISupportInitialize)svgImageCollection1).BeginInit();
            ((ISupportInitialize)panelSummary).BeginInit();
            panelSummary.SuspendLayout();
            ((ISupportInitialize)panelCardBalance).BeginInit();
            panelCardBalance.SuspendLayout();
            ((ISupportInitialize)svgCardBalance_ImageBox).BeginInit();
            ((ISupportInitialize)panelCardToday).BeginInit();
            panelCardToday.SuspendLayout();
            ((ISupportInitialize)svgCardToday_ImageBox).BeginInit();
            ((ISupportInitialize)panelCardLast30Days).BeginInit();
            panelCardLast30Days.SuspendLayout();
            ((ISupportInitialize)svgCardLast30Days_ImageBox).BeginInit();
            ((ISupportInitialize)panelCardTotal).BeginInit();
            panelCardTotal.SuspendLayout();
            ((ISupportInitialize)svgCardTotal_ImageBox).BeginInit();
            SuspendLayout();
            // 
            // gC_WhatsAppMessageLogList
            // 
            gC_WhatsAppMessageLogList.DataSource = trWhatsAppMessageLogBindingSource;
            gC_WhatsAppMessageLogList.Dock = DockStyle.Fill;
            gC_WhatsAppMessageLogList.Location = new Point(0, 258);
            gC_WhatsAppMessageLogList.MainView = gV_WhatsAppMessageLogList;
            gC_WhatsAppMessageLogList.MenuManager = ribbonControl1;
            gC_WhatsAppMessageLogList.Name = "gC_WhatsAppMessageLogList";
            gC_WhatsAppMessageLogList.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] { repoPictureEdit, repoBtn_SendAgain, repoTextEmpty });
            gC_WhatsAppMessageLogList.Size = new Size(1100, 362);
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
            gV_WhatsAppMessageLogList.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { colWhatsAppMessageLogId, colDocumentHeaderId, colCreatedDate, colCreatedUserName, colCurrAccCode, colCurrAccDesc, colReceiverPhoneNumber, colMessageType, colMessage, colIsSuccessful, colSender, colSenderName, colImagePreview, colSendAgain, colImageFilePath });
            gV_WhatsAppMessageLogList.GridControl = gC_WhatsAppMessageLogList;
            gV_WhatsAppMessageLogList.Name = "gV_WhatsAppMessageLogList";
            gV_WhatsAppMessageLogList.OptionsFind.FindDelay = 100;
            gV_WhatsAppMessageLogList.OptionsView.RowAutoHeight = true;
            gV_WhatsAppMessageLogList.OptionsView.ShowAutoFilterRow = true;
            gV_WhatsAppMessageLogList.OptionsView.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
            gV_WhatsAppMessageLogList.OptionsView.ShowFooter = true;
            gV_WhatsAppMessageLogList.OptionsView.ShowGroupPanel = false;
            gV_WhatsAppMessageLogList.RowHeight = 60;
            gV_WhatsAppMessageLogList.CustomRowCellEdit += gV_WhatsAppMessageLogList_CustomRowCellEdit;
            gV_WhatsAppMessageLogList.PopupMenuShowing += gV_WhatsAppMessageLogList_PopupMenuShowing;
            gV_WhatsAppMessageLogList.CustomUnboundColumnData += gV_WhatsAppMessageLogList_CustomUnboundColumnData;
            gV_WhatsAppMessageLogList.DoubleClick += gV_WhatsAppMessageLogList_DoubleClick;
            // 
            // colWhatsAppMessageLogId
            // 
            colWhatsAppMessageLogId.FieldName = "WhatsAppMessageLogId";
            colWhatsAppMessageLogId.Name = "colWhatsAppMessageLogId";
            colWhatsAppMessageLogId.OptionsColumn.AllowEdit = false;
            // 
            // colDocumentHeaderId
            // 
            colDocumentHeaderId.FieldName = "DocumentHeaderId";
            colDocumentHeaderId.Name = "colDocumentHeaderId";
            colDocumentHeaderId.OptionsColumn.AllowEdit = false;
            // 
            // colCreatedDate
            // 
            colCreatedDate.Caption = "Created Date";
            colCreatedDate.FieldName = "CreatedDate";
            colCreatedDate.Name = "colCreatedDate";
            colCreatedDate.OptionsColumn.AllowEdit = false;
            colCreatedDate.Visible = true;
            colCreatedDate.VisibleIndex = 0;
            // 
            // colCreatedUserName
            // 
            colCreatedUserName.Caption = "Created User";
            colCreatedUserName.FieldName = "CreatedUserName";
            colCreatedUserName.Name = "colCreatedUserName";
            colCreatedUserName.OptionsColumn.AllowEdit = false;
            // 
            // colCurrAccCode
            // 
            colCurrAccCode.Caption = "Current Account Code";
            colCurrAccCode.FieldName = "CurrAccCode";
            colCurrAccCode.Name = "colCurrAccCode";
            colCurrAccCode.OptionsColumn.AllowEdit = false;
            colCurrAccCode.Visible = true;
            colCurrAccCode.VisibleIndex = 3;
            // 
            // colCurrAccDesc
            // 
            colCurrAccDesc.Caption = "Current Account Name";
            colCurrAccDesc.FieldName = "DcCurrAcc.CurrAccDesc";
            colCurrAccDesc.Name = "colCurrAccDesc";
            colCurrAccDesc.OptionsColumn.AllowEdit = false;
            colCurrAccDesc.Visible = true;
            colCurrAccDesc.VisibleIndex = 4;
            // 
            // colReceiverPhoneNumber
            // 
            colReceiverPhoneNumber.Caption = "Phone";
            colReceiverPhoneNumber.FieldName = "ReceiverPhoneNumber";
            colReceiverPhoneNumber.Name = "colReceiverPhoneNumber";
            colReceiverPhoneNumber.OptionsColumn.AllowEdit = false;
            colReceiverPhoneNumber.Visible = true;
            colReceiverPhoneNumber.VisibleIndex = 5;
            // 
            // colMessageType
            // 
            colMessageType.Caption = "Message Type";
            colMessageType.FieldName = "MessageType";
            colMessageType.Name = "colMessageType";
            colMessageType.OptionsColumn.AllowEdit = false;
            colMessageType.Visible = true;
            colMessageType.VisibleIndex = 6;
            // 
            // colMessage
            // 
            colMessage.Caption = "Message";
            colMessage.FieldName = "Message";
            colMessage.Name = "colMessage";
            colMessage.OptionsColumn.AllowEdit = false;
            colMessage.Visible = true;
            colMessage.VisibleIndex = 7;
            // 
            // colIsSuccessful
            // 
            colIsSuccessful.FieldName = "IsSuccessful";
            colIsSuccessful.Name = "colIsSuccessful";
            colIsSuccessful.OptionsColumn.AllowEdit = false;
            colIsSuccessful.Visible = true;
            colIsSuccessful.VisibleIndex = 8;
            // 
            // colSender
            // 
            colSender.Caption = "Sender";
            colSender.FieldName = "Sender";
            colSender.Name = "colSender";
            colSender.OptionsColumn.AllowEdit = false;
            colSender.Visible = true;
            colSender.VisibleIndex = 1;
            // 
            // colSenderName
            // 
            colSenderName.Caption = "Sender First Name";
            colSenderName.FieldName = "DcSender.CurrAccDesc";
            colSenderName.Name = "colSenderName";
            colSenderName.OptionsColumn.AllowEdit = false;
            colSenderName.Visible = true;
            colSenderName.VisibleIndex = 2;
            // 
            // colImagePreview
            // 
            colImagePreview.Caption = "Image";
            colImagePreview.ColumnEdit = repoPictureEdit;
            colImagePreview.FieldName = "colImagePreview";
            colImagePreview.Name = "colImagePreview";
            colImagePreview.OptionsColumn.AllowEdit = false;
            colImagePreview.UnboundDataType = typeof(object);
            colImagePreview.Visible = true;
            colImagePreview.VisibleIndex = 9;
            colImagePreview.Width = 80;
            // 
            // repoPictureEdit
            // 
            repoPictureEdit.Name = "repoPictureEdit";
            repoPictureEdit.NullText = " ";
            repoPictureEdit.ReadOnly = true;
            repoPictureEdit.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom;
            // 
            // colSendAgain
            // 
            colSendAgain.Caption = "Action";
            colSendAgain.ColumnEdit = repoBtn_SendAgain;
            colSendAgain.FieldName = "colSendAgain";
            colSendAgain.Name = "colSendAgain";
            colSendAgain.OptionsColumn.FixedWidth = true;
            colSendAgain.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
            colSendAgain.UnboundDataType = typeof(object);
            colSendAgain.Visible = true;
            colSendAgain.VisibleIndex = 10;
            colSendAgain.Width = 110;
            // 
            // repoBtn_SendAgain
            // 
            repoBtn_SendAgain.AutoHeight = false;
            repoBtn_SendAgain.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph) });
            repoBtn_SendAgain.Name = "repoBtn_SendAgain";
            repoBtn_SendAgain.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            repoBtn_SendAgain.ButtonClick += repoBtn_SendAgain_ButtonClick;
            // 
            // colImageFilePath
            // 
            colImageFilePath.Caption = "Image File Path";
            colImageFilePath.FieldName = "ImageFilePath";
            colImageFilePath.Name = "colImageFilePath";
            colImageFilePath.OptionsColumn.AllowEdit = false;
            // 
            // ribbonControl1
            // 
            ribbonControl1.ExpandCollapseItem.Id = 0;
            ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] { ribbonControl1.ExpandCollapseItem, bBI_ExportXlsx, bBI_Refresh, bBI_SendSelected, bBI_SendAllUnsent });
            ribbonControl1.Location = new Point(0, 0);
            ribbonControl1.MaxItemId = 5;
            ribbonControl1.Name = "ribbonControl1";
            ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] { ribbonPage1 });
            ribbonControl1.Size = new Size(1100, 158);
            ribbonControl1.StatusBar = ribbonStatusBar1;
            // 
            // bBI_ExportXlsx
            // 
            bBI_ExportXlsx.Caption = Resources.Common_ExportToExcel;
            bBI_ExportXlsx.Id = 1;
            bBI_ExportXlsx.Name = "bBI_ExportXlsx";
            bBI_ExportXlsx.ItemClick += bBI_ExportXlsx_ItemClick;
            // 
            // bBI_Refresh
            // 
            bBI_Refresh.Caption = Resources.Common_Refresh;
            bBI_Refresh.Id = 2;
            bBI_Refresh.Name = "bBI_Refresh";
            bBI_Refresh.ItemClick += bBI_Refresh_ItemClick;
            // 
            // bBI_SendSelected
            // 
            bBI_SendSelected.Caption = Resources.Form_WhatsAppMessageLog_SendSelected;
            bBI_SendSelected.Id = 3;
            bBI_SendSelected.Name = "bBI_SendSelected";
            bBI_SendSelected.ItemClick += bBI_SendSelected_ItemClick;
            // 
            // bBI_SendAllUnsent
            // 
            bBI_SendAllUnsent.Caption = Resources.Form_WhatsAppMessageLog_SendAllUnsent;
            bBI_SendAllUnsent.Id = 4;
            bBI_SendAllUnsent.Name = "bBI_SendAllUnsent";
            bBI_SendAllUnsent.ItemClick += bBI_SendAllUnsent_ItemClick;
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
            ribbonPageGroup1.ItemLinks.Add(bBI_SendSelected);
            ribbonPageGroup1.ItemLinks.Add(bBI_SendAllUnsent);
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
            // repoTextEmpty
            // 
            repoTextEmpty.AutoHeight = false;
            repoTextEmpty.Name = "repoTextEmpty";
            repoTextEmpty.ReadOnly = true;
            // 
            // svgImageCollection1
            // 
            svgImageCollection1.Add("Export", "image://svgimages/export/exporttoxlsx.svg");
            svgImageCollection1.Add("Balance", "image://svgimages/business objects/bo_sale.svg");
            svgImageCollection1.Add("Today", "image://svgimages/richedit/insertpagecount.svg");
            svgImageCollection1.Add("Last30Days", "image://svgimages/icon builder/actions_calendar.svg");
            svgImageCollection1.Add("Total", "image://svgimages/data/summary.svg");
            // 
            // panelSummary
            // 
            panelSummary.Appearance.BackColor = Color.FromArgb(240, 240, 240);
            panelSummary.Appearance.Options.UseBackColor = true;
            panelSummary.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            panelSummary.Controls.Add(panelCardBalance);
            panelSummary.Controls.Add(panelCardToday);
            panelSummary.Controls.Add(panelCardLast30Days);
            panelSummary.Controls.Add(panelCardTotal);
            panelSummary.Dock = DockStyle.Top;
            panelSummary.Location = new Point(0, 158);
            panelSummary.Name = "panelSummary";
            panelSummary.Padding = new Padding(10);
            panelSummary.Size = new Size(1100, 100);
            panelSummary.TabIndex = 1;
            panelSummary.Paint += panelSummary_Paint;
            // 
            // panelCardBalance
            // 
            panelCardBalance.Appearance.BackColor = Color.White;
            panelCardBalance.Appearance.Options.UseBackColor = true;
            panelCardBalance.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            panelCardBalance.Controls.Add(svgCardBalance_ImageBox);
            panelCardBalance.Controls.Add(lblCardBalance_Subtitle);
            panelCardBalance.Controls.Add(lblCardBalance_Value);
            panelCardBalance.Controls.Add(lblCardBalance_Title);
            panelCardBalance.Location = new Point(12, 10);
            panelCardBalance.Name = "panelCardBalance";
            panelCardBalance.Size = new Size(220, 80);
            panelCardBalance.TabIndex = 0;
            panelCardBalance.Paint += panelCard_Paint;
            // 
            // svgCardBalance_ImageBox
            // 
            svgCardBalance_ImageBox.BackColor = Color.FromArgb(232, 244, 255);
            svgCardBalance_ImageBox.Location = new Point(175, 10);
            svgCardBalance_ImageBox.Name = "svgCardBalance_ImageBox";
            svgCardBalance_ImageBox.Size = new Size(35, 35);
            svgCardBalance_ImageBox.TabIndex = 3;
            svgCardBalance_ImageBox.Text = "svgImageBox1";
            svgCardBalance_ImageBox.Paint += svgCard_Paint;
            // 
            // lblCardBalance_Subtitle
            // 
            lblCardBalance_Subtitle.Appearance.ForeColor = Color.Gray;
            lblCardBalance_Subtitle.Appearance.Options.UseForeColor = true;
            lblCardBalance_Subtitle.Location = new Point(10, 58);
            lblCardBalance_Subtitle.Name = "lblCardBalance_Subtitle";
            lblCardBalance_Subtitle.Size = new Size(0, 13);
            lblCardBalance_Subtitle.TabIndex = 4;
            // 
            // lblCardBalance_Value
            // 
            lblCardBalance_Value.Appearance.Font = new Font("Tahoma", 14F, FontStyle.Bold);
            lblCardBalance_Value.Appearance.Options.UseFont = true;
            lblCardBalance_Value.Location = new Point(10, 30);
            lblCardBalance_Value.Name = "lblCardBalance_Value";
            lblCardBalance_Value.Size = new Size(39, 23);
            lblCardBalance_Value.TabIndex = 5;
            lblCardBalance_Value.Text = "N/A";
            // 
            // lblCardBalance_Title
            // 
            lblCardBalance_Title.Appearance.ForeColor = Color.Gray;
            lblCardBalance_Title.Appearance.Options.UseForeColor = true;
            lblCardBalance_Title.Location = new Point(10, 10);
            lblCardBalance_Title.Name = "lblCardBalance_Title";
            lblCardBalance_Title.Size = new Size(0, 13);
            lblCardBalance_Title.TabIndex = 6;
            // 
            // panelCardToday
            // 
            panelCardToday.Appearance.BackColor = Color.White;
            panelCardToday.Appearance.Options.UseBackColor = true;
            panelCardToday.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            panelCardToday.Controls.Add(svgCardToday_ImageBox);
            panelCardToday.Controls.Add(lblCardToday_Subtitle);
            panelCardToday.Controls.Add(lblCardToday_Value);
            panelCardToday.Controls.Add(lblCardToday_Title);
            panelCardToday.Location = new Point(245, 10);
            panelCardToday.Name = "panelCardToday";
            panelCardToday.Size = new Size(220, 80);
            panelCardToday.TabIndex = 1;
            panelCardToday.Paint += panelCard_Paint;
            // 
            // svgCardToday_ImageBox
            // 
            svgCardToday_ImageBox.BackColor = Color.FromArgb(224, 242, 241);
            svgCardToday_ImageBox.Location = new Point(175, 10);
            svgCardToday_ImageBox.Name = "svgCardToday_ImageBox";
            svgCardToday_ImageBox.Size = new Size(35, 35);
            svgCardToday_ImageBox.TabIndex = 3;
            svgCardToday_ImageBox.Text = "svgImageBox2";
            svgCardToday_ImageBox.Paint += svgCard_Paint;
            // 
            // lblCardToday_Subtitle
            // 
            lblCardToday_Subtitle.Appearance.ForeColor = Color.Gray;
            lblCardToday_Subtitle.Appearance.Options.UseForeColor = true;
            lblCardToday_Subtitle.Location = new Point(10, 58);
            lblCardToday_Subtitle.Name = "lblCardToday_Subtitle";
            lblCardToday_Subtitle.Size = new Size(0, 13);
            lblCardToday_Subtitle.TabIndex = 4;
            // 
            // lblCardToday_Value
            // 
            lblCardToday_Value.Appearance.Font = new Font("Tahoma", 14F, FontStyle.Bold);
            lblCardToday_Value.Appearance.Options.UseFont = true;
            lblCardToday_Value.Location = new Point(10, 30);
            lblCardToday_Value.Name = "lblCardToday_Value";
            lblCardToday_Value.Size = new Size(12, 23);
            lblCardToday_Value.TabIndex = 5;
            lblCardToday_Value.Text = "0";
            // 
            // lblCardToday_Title
            // 
            lblCardToday_Title.Appearance.ForeColor = Color.Gray;
            lblCardToday_Title.Appearance.Options.UseForeColor = true;
            lblCardToday_Title.Location = new Point(10, 10);
            lblCardToday_Title.Name = "lblCardToday_Title";
            lblCardToday_Title.Size = new Size(0, 13);
            lblCardToday_Title.TabIndex = 6;
            // 
            // panelCardLast30Days
            // 
            panelCardLast30Days.Appearance.BackColor = Color.White;
            panelCardLast30Days.Appearance.Options.UseBackColor = true;
            panelCardLast30Days.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            panelCardLast30Days.Controls.Add(svgCardLast30Days_ImageBox);
            panelCardLast30Days.Controls.Add(lblCardLast30Days_Subtitle);
            panelCardLast30Days.Controls.Add(lblCardLast30Days_Value);
            panelCardLast30Days.Controls.Add(lblCardLast30Days_Title);
            panelCardLast30Days.Location = new Point(478, 10);
            panelCardLast30Days.Name = "panelCardLast30Days";
            panelCardLast30Days.Size = new Size(220, 80);
            panelCardLast30Days.TabIndex = 2;
            panelCardLast30Days.Paint += panelCard_Paint;
            // 
            // svgCardLast30Days_ImageBox
            // 
            svgCardLast30Days_ImageBox.BackColor = Color.FromArgb(232, 245, 233);
            svgCardLast30Days_ImageBox.Location = new Point(175, 10);
            svgCardLast30Days_ImageBox.Name = "svgCardLast30Days_ImageBox";
            svgCardLast30Days_ImageBox.Size = new Size(35, 35);
            svgCardLast30Days_ImageBox.TabIndex = 3;
            svgCardLast30Days_ImageBox.Text = "svgImageBox3";
            svgCardLast30Days_ImageBox.Paint += svgCard_Paint;
            // 
            // lblCardLast30Days_Subtitle
            // 
            lblCardLast30Days_Subtitle.Appearance.ForeColor = Color.Gray;
            lblCardLast30Days_Subtitle.Appearance.Options.UseForeColor = true;
            lblCardLast30Days_Subtitle.Location = new Point(10, 58);
            lblCardLast30Days_Subtitle.Name = "lblCardLast30Days_Subtitle";
            lblCardLast30Days_Subtitle.Size = new Size(0, 13);
            lblCardLast30Days_Subtitle.TabIndex = 4;
            // 
            // lblCardLast30Days_Value
            // 
            lblCardLast30Days_Value.Appearance.Font = new Font("Tahoma", 14F, FontStyle.Bold);
            lblCardLast30Days_Value.Appearance.Options.UseFont = true;
            lblCardLast30Days_Value.Location = new Point(10, 30);
            lblCardLast30Days_Value.Name = "lblCardLast30Days_Value";
            lblCardLast30Days_Value.Size = new Size(12, 23);
            lblCardLast30Days_Value.TabIndex = 5;
            lblCardLast30Days_Value.Text = "0";
            // 
            // lblCardLast30Days_Title
            // 
            lblCardLast30Days_Title.Appearance.ForeColor = Color.Gray;
            lblCardLast30Days_Title.Appearance.Options.UseForeColor = true;
            lblCardLast30Days_Title.Location = new Point(10, 10);
            lblCardLast30Days_Title.Name = "lblCardLast30Days_Title";
            lblCardLast30Days_Title.Size = new Size(0, 13);
            lblCardLast30Days_Title.TabIndex = 6;
            // 
            // panelCardTotal
            // 
            panelCardTotal.Appearance.BackColor = Color.White;
            panelCardTotal.Appearance.Options.UseBackColor = true;
            panelCardTotal.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            panelCardTotal.Controls.Add(svgCardTotal_ImageBox);
            panelCardTotal.Controls.Add(lblCardTotal_Subtitle);
            panelCardTotal.Controls.Add(lblCardTotal_Value);
            panelCardTotal.Controls.Add(lblCardTotal_Title);
            panelCardTotal.Location = new Point(711, 10);
            panelCardTotal.Name = "panelCardTotal";
            panelCardTotal.Size = new Size(220, 80);
            panelCardTotal.TabIndex = 3;
            panelCardTotal.Paint += panelCard_Paint;
            // 
            // svgCardTotal_ImageBox
            // 
            svgCardTotal_ImageBox.BackColor = Color.FromArgb(255, 243, 224);
            svgCardTotal_ImageBox.Location = new Point(175, 10);
            svgCardTotal_ImageBox.Name = "svgCardTotal_ImageBox";
            svgCardTotal_ImageBox.Size = new Size(35, 35);
            svgCardTotal_ImageBox.TabIndex = 3;
            svgCardTotal_ImageBox.Text = "svgImageBox4";
            svgCardTotal_ImageBox.Paint += svgCard_Paint;
            // 
            // lblCardTotal_Subtitle
            // 
            lblCardTotal_Subtitle.Appearance.ForeColor = Color.Gray;
            lblCardTotal_Subtitle.Appearance.Options.UseForeColor = true;
            lblCardTotal_Subtitle.Location = new Point(10, 58);
            lblCardTotal_Subtitle.Name = "lblCardTotal_Subtitle";
            lblCardTotal_Subtitle.Size = new Size(0, 13);
            lblCardTotal_Subtitle.TabIndex = 4;
            // 
            // lblCardTotal_Value
            // 
            lblCardTotal_Value.Appearance.Font = new Font("Tahoma", 14F, FontStyle.Bold);
            lblCardTotal_Value.Appearance.Options.UseFont = true;
            lblCardTotal_Value.Location = new Point(10, 30);
            lblCardTotal_Value.Name = "lblCardTotal_Value";
            lblCardTotal_Value.Size = new Size(12, 23);
            lblCardTotal_Value.TabIndex = 5;
            lblCardTotal_Value.Text = "0";
            // 
            // lblCardTotal_Title
            // 
            lblCardTotal_Title.Appearance.ForeColor = Color.Gray;
            lblCardTotal_Title.Appearance.Options.UseForeColor = true;
            lblCardTotal_Title.Location = new Point(10, 10);
            lblCardTotal_Title.Name = "lblCardTotal_Title";
            lblCardTotal_Title.Size = new Size(0, 13);
            lblCardTotal_Title.TabIndex = 6;
            // 
            // FormWhatsAppMessageLog
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1100, 644);
            Controls.Add(gC_WhatsAppMessageLogList);
            Controls.Add(panelSummary);
            Controls.Add(ribbonStatusBar1);
            Controls.Add(ribbonControl1);
            Name = "FormWhatsAppMessageLog";
            Ribbon = ribbonControl1;
            StartPosition = FormStartPosition.CenterScreen;
            StatusBar = ribbonStatusBar1;
            FormClosed += FormWhatsAppMessageLog_FormClosed;
            Load += FormWhatsAppMessageLog_Load;
            ((ISupportInitialize)gC_WhatsAppMessageLogList).EndInit();
            ((ISupportInitialize)trWhatsAppMessageLogBindingSource).EndInit();
            ((ISupportInitialize)gV_WhatsAppMessageLogList).EndInit();
            ((ISupportInitialize)repoPictureEdit).EndInit();
            ((ISupportInitialize)repoBtn_SendAgain).EndInit();
            ((ISupportInitialize)ribbonControl1).EndInit();
            ((ISupportInitialize)repoTextEmpty).EndInit();
            ((ISupportInitialize)svgImageCollection1).EndInit();
            ((ISupportInitialize)panelSummary).EndInit();
            panelSummary.ResumeLayout(false);
            ((ISupportInitialize)panelCardBalance).EndInit();
            panelCardBalance.ResumeLayout(false);
            panelCardBalance.PerformLayout();
            ((ISupportInitialize)svgCardBalance_ImageBox).EndInit();
            ((ISupportInitialize)panelCardToday).EndInit();
            panelCardToday.ResumeLayout(false);
            panelCardToday.PerformLayout();
            ((ISupportInitialize)svgCardToday_ImageBox).EndInit();
            ((ISupportInitialize)panelCardLast30Days).EndInit();
            panelCardLast30Days.ResumeLayout(false);
            panelCardLast30Days.PerformLayout();
            ((ISupportInitialize)svgCardLast30Days_ImageBox).EndInit();
            ((ISupportInitialize)panelCardTotal).EndInit();
            panelCardTotal.ResumeLayout(false);
            panelCardTotal.PerformLayout();
            ((ISupportInitialize)svgCardTotal_ImageBox).EndInit();
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
        private DevExpress.XtraBars.BarButtonItem bBI_SendSelected;
        private DevExpress.XtraBars.BarButtonItem bBI_SendAllUnsent;
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
        private DevExpress.XtraGrid.Columns.GridColumn colIsSuccessful;
        private DevExpress.XtraGrid.Columns.GridColumn colImagePreview;
        private DevExpress.XtraGrid.Columns.GridColumn colSendAgain;
        private DevExpress.XtraGrid.Columns.GridColumn colImageFilePath;
        private DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit repoPictureEdit;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repoBtn_SendAgain;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repoTextEmpty;
        private SvgImageCollection svgImageCollection1;

        private DevExpress.XtraEditors.PanelControl panelSummary;
        private DevExpress.XtraEditors.PanelControl panelCardBalance;
        private DevExpress.XtraEditors.LabelControl lblCardBalance_Title;
        private DevExpress.XtraEditors.LabelControl lblCardBalance_Value;
        private DevExpress.XtraEditors.LabelControl lblCardBalance_Subtitle;
        private DevExpress.XtraEditors.SvgImageBox svgCardBalance_ImageBox;
        private DevExpress.XtraEditors.PanelControl panelCardToday;
        private DevExpress.XtraEditors.LabelControl lblCardToday_Title;
        private DevExpress.XtraEditors.LabelControl lblCardToday_Value;
        private DevExpress.XtraEditors.LabelControl lblCardToday_Subtitle;
        private DevExpress.XtraEditors.SvgImageBox svgCardToday_ImageBox;
        private DevExpress.XtraEditors.PanelControl panelCardLast30Days;
        private DevExpress.XtraEditors.LabelControl lblCardLast30Days_Title;
        private DevExpress.XtraEditors.LabelControl lblCardLast30Days_Value;
        private DevExpress.XtraEditors.LabelControl lblCardLast30Days_Subtitle;
        private DevExpress.XtraEditors.SvgImageBox svgCardLast30Days_ImageBox;
        private DevExpress.XtraEditors.PanelControl panelCardTotal;
        private DevExpress.XtraEditors.LabelControl lblCardTotal_Title;
        private DevExpress.XtraEditors.LabelControl lblCardTotal_Value;
        private DevExpress.XtraEditors.LabelControl lblCardTotal_Subtitle;
        private DevExpress.XtraEditors.SvgImageBox svgCardTotal_ImageBox;
    }
}
