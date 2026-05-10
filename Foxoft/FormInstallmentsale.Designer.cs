using DevExpress.Dialogs.Core.View;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using Foxoft.Models;
using Foxoft.Properties;
using System.Windows.Forms;
using System.Drawing;

namespace Foxoft
{
    partial class FormInstallmentSale
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormInstallmentSale));
            svgImageCollection1 = new DevExpress.Utils.SvgImageCollection(components);
            gridControl1 = new DevExpress.XtraGrid.GridControl();
            bindingSourceTrInstallmentSale = new BindingSource(components);
            gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            repoBtnEdit_Payment = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            col_Buttons = new DevExpress.XtraGrid.Columns.GridColumn();
            colInvoiceHeaderId = new DevExpress.XtraGrid.Columns.GridColumn();
            colMonthlyPayment = new DevExpress.XtraGrid.Columns.GridColumn();
            ribbonControl1 = new RibbonControl();
            BBI_Refresh = new BarButtonItem();
            BBI_GridOptions = new BarButtonItem();
            BSI_Reports = new BarSubItem();
            BBI_QueryEdit = new BarButtonItem();
            BCI_FilterDay = new BarCheckItem();
            BBI_FilterWeek = new BarCheckItem();
            BBI_FilterMonth = new BarCheckItem();
            BCI_FilterContinuing = new BarCheckItem();
            BCI_FilterCompleted = new BarCheckItem();
            ribbonPage1 = new RibbonPage();
            ribbonPageGroup1 = new RibbonPageGroup();
            ribbonPageGroup2 = new RibbonPageGroup();
            ribbonPageGroup3 = new RibbonPageGroup();
            ribbonPageGroupFilterDateRange = new RibbonPageGroup();
            ribbonPageGroupFilterStatus = new RibbonPageGroup();
            ribbonPage2 = new RibbonPage();
            panelSummary = new DevExpress.XtraEditors.PanelControl();
            panelCardRemaining = new DevExpress.XtraEditors.PanelControl();
            svgCardRemaining_ImageBox = new DevExpress.XtraEditors.SvgImageBox();
            lblCardRemaining_Subtitle = new DevExpress.XtraEditors.LabelControl();
            lblCardRemaining_Value = new DevExpress.XtraEditors.LabelControl();
            lblCardRemaining_Title = new DevExpress.XtraEditors.LabelControl();
            panelCardPaid = new DevExpress.XtraEditors.PanelControl();
            svgCardPaid_ImageBox = new DevExpress.XtraEditors.SvgImageBox();
            lblCardPaid_Subtitle = new DevExpress.XtraEditors.LabelControl();
            lblCardPaid_Value = new DevExpress.XtraEditors.LabelControl();
            lblCardPaid_Title = new DevExpress.XtraEditors.LabelControl();
            panelCardAmount = new DevExpress.XtraEditors.PanelControl();
            svgCardAmount_ImageBox = new DevExpress.XtraEditors.SvgImageBox();
            lblCardAmount_Subtitle = new DevExpress.XtraEditors.LabelControl();
            lblCardAmount_Value = new DevExpress.XtraEditors.LabelControl();
            lblCardAmount_Title = new DevExpress.XtraEditors.LabelControl();
            panelCardCount = new DevExpress.XtraEditors.PanelControl();
            svgCardCount_ImageBox = new DevExpress.XtraEditors.SvgImageBox();
            lblCardCount_Subtitle = new DevExpress.XtraEditors.LabelControl();
            lblCardCount_Value = new DevExpress.XtraEditors.LabelControl();
            lblCardCount_Title = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)svgImageCollection1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridControl1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bindingSourceTrInstallmentSale).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)repoBtnEdit_Payment).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ribbonControl1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)panelSummary).BeginInit();
            panelSummary.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)panelCardRemaining).BeginInit();
            panelCardRemaining.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)svgCardRemaining_ImageBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)panelCardPaid).BeginInit();
            panelCardPaid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)svgCardPaid_ImageBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)panelCardAmount).BeginInit();
            panelCardAmount.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)svgCardAmount_ImageBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)panelCardCount).BeginInit();
            panelCardCount.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)svgCardCount_ImageBox).BeginInit();
            SuspendLayout();
            // 
            // svgImageCollection1
            // 
            svgImageCollection1.Add("Count", "image://svgimages/richedit/insertpagecount.svg");
            svgImageCollection1.Add("Remaining", "image://svgimages/icon builder/business_calculator.svg");
            svgImageCollection1.Add("Amount", "image://svgimages/icon builder/actions_calendar.svg");
            svgImageCollection1.Add("Paid", "image://svgimages/business objects/bo_invoice.svg");
            // 
            // gridControl1
            // 
            gridControl1.DataSource = bindingSourceTrInstallmentSale;
            gridControl1.Dock = DockStyle.Fill;
            gridControl1.Location = new Point(0, 258);
            gridControl1.MainView = gridView1;
            gridControl1.Name = "gridControl1";
            gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] { repoBtnEdit_Payment });
            gridControl1.Size = new Size(954, 268);
            gridControl1.TabIndex = 0;
            gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gridView1 });
            // 
            // gridView1
            // 
            gridView1.GridControl = gridControl1;
            gridView1.Name = "gridView1";
            gridView1.OptionsView.ShowAutoFilterRow = true;
            gridView1.RowHeight = 18;
            gridView1.RowStyle += gridView1_RowStyle;
            gridView1.PopupMenuShowing += gridView1_PopupMenuShowing;
            gridView1.ShowingEditor += gV_Report_ShowingEditor;
            gridView1.CustomColumnDisplayText += gridView1_CustomColumnDisplayText;
            // 
            // repoBtnEdit_Payment
            // 
            repoBtnEdit_Payment.AutoHeight = false;
            repoBtnEdit_Payment.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph) });
            repoBtnEdit_Payment.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            repoBtnEdit_Payment.Name = "repoBtnEdit_Payment";
            repoBtnEdit_Payment.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            repoBtnEdit_Payment.ButtonPressed += RepoBtnEdit_Payment_ButtonPressed;
            // 
            // col_Buttons
            // 
            col_Buttons.ColumnEdit = repoBtnEdit_Payment;
            col_Buttons.Name = "col_Buttons";
            col_Buttons.Visible = true;
            col_Buttons.VisibleIndex = 0;
            // 
            // colInvoiceHeaderId
            // 
            colInvoiceHeaderId.Name = "colInvoiceHeaderId";
            // 
            // colMonthlyPayment
            // 
            colMonthlyPayment.Name = "colMonthlyPayment";
            // 
            // ribbonControl1
            // 
            ribbonControl1.ExpandCollapseItem.Id = 0;
            ribbonControl1.Items.AddRange(new BarItem[] { ribbonControl1.ExpandCollapseItem, BBI_Refresh, BBI_GridOptions, BSI_Reports, BBI_QueryEdit, BCI_FilterDay, BBI_FilterWeek, BBI_FilterMonth, BCI_FilterContinuing, BCI_FilterCompleted });
            ribbonControl1.Location = new Point(0, 0);
            ribbonControl1.MaxItemId = 18;
            ribbonControl1.Name = "ribbonControl1";
            ribbonControl1.Pages.AddRange(new RibbonPage[] { ribbonPage1, ribbonPage2 });
            ribbonControl1.Size = new Size(954, 158);
            // 
            // BBI_Refresh
            // 
            BBI_Refresh.Caption = Resources.Common_Refresh;
            BBI_Refresh.Id = 1;
            BBI_Refresh.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("BBI_Refresh.ImageOptions.SvgImage");
            BBI_Refresh.Name = "BBI_Refresh";
            BBI_Refresh.ItemClick += BBI_Refresh_ItemClick;
            // 
            // BBI_GridOptions
            // 
            BBI_GridOptions.Caption = Resources.Form_InstallmentSale_Button_GridOptions;
            BBI_GridOptions.Id = 2;
            BBI_GridOptions.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("BBI_GridOptions.ImageOptions.SvgImage");
            BBI_GridOptions.Name = "BBI_GridOptions";
            BBI_GridOptions.ItemClick += BBI_GridOptions_ItemClick;
            // 
            // BSI_Reports
            // 
            BSI_Reports.Caption = Resources.Common_Report;
            BSI_Reports.Id = 3;
            BSI_Reports.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("BSI_Reports.ImageOptions.SvgImage");
            BSI_Reports.Name = "BSI_Reports";
            // 
            // BBI_QueryEdit
            // 
            BBI_QueryEdit.Caption = Resources.Form_InstallmentSale_Button_QueryEdit;
            BBI_QueryEdit.Id = 4;
            BBI_QueryEdit.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("BBI_QueryEdit.ImageOptions.SvgImage");
            BBI_QueryEdit.Name = "BBI_QueryEdit";
            BBI_QueryEdit.ItemClick += BBI_QueryEdit_ItemClick;
            // 
            // BCI_FilterDay
            // 
            BCI_FilterDay.AllowAllUp = true;
            BCI_FilterDay.Caption = Resources.Form_InstallmentSale_Filter_Day;
            BCI_FilterDay.GroupIndex = 1;
            BCI_FilterDay.Id = 13;
            BCI_FilterDay.ImageOptions.Image = (Image)resources.GetObject("BCI_FilterDay.ImageOptions.Image");
            BCI_FilterDay.ImageOptions.LargeImage = (Image)resources.GetObject("BCI_FilterDay.ImageOptions.LargeImage");
            BCI_FilterDay.Name = "BCI_FilterDay";
            BCI_FilterDay.CheckedChanged += BBI_Filter_CheckedChanged;
            // 
            // BBI_FilterWeek
            // 
            BBI_FilterWeek.AllowAllUp = true;
            BBI_FilterWeek.Caption = Resources.Form_InstallmentSale_Filter_Week;
            BBI_FilterWeek.GroupIndex = 1;
            BBI_FilterWeek.Id = 14;
            BBI_FilterWeek.ImageOptions.Image = (Image)resources.GetObject("BBI_FilterWeek.ImageOptions.Image");
            BBI_FilterWeek.ImageOptions.LargeImage = (Image)resources.GetObject("BBI_FilterWeek.ImageOptions.LargeImage");
            BBI_FilterWeek.Name = "BBI_FilterWeek";
            BBI_FilterWeek.CheckedChanged += BBI_Filter_CheckedChanged;
            // 
            // BBI_FilterMonth
            // 
            BBI_FilterMonth.AllowAllUp = true;
            BBI_FilterMonth.Caption = Resources.Form_InstallmentSale_Filter_Month;
            BBI_FilterMonth.GroupIndex = 1;
            BBI_FilterMonth.Id = 15;
            BBI_FilterMonth.ImageOptions.Image = (Image)resources.GetObject("BBI_FilterMonth.ImageOptions.Image");
            BBI_FilterMonth.ImageOptions.LargeImage = (Image)resources.GetObject("BBI_FilterMonth.ImageOptions.LargeImage");
            BBI_FilterMonth.Name = "BBI_FilterMonth";
            BBI_FilterMonth.CheckedChanged += BBI_Filter_CheckedChanged;
            // 
            // BCI_FilterContinuing
            // 
            BCI_FilterContinuing.AllowAllUp = true;
            BCI_FilterContinuing.Caption = Resources.Form_InstallmentSale_Filter_Continuing;
            BCI_FilterContinuing.GroupIndex = 2;
            BCI_FilterContinuing.Id = 16;
            BCI_FilterContinuing.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("BCI_FilterContinuing.ImageOptions.SvgImage");
            BCI_FilterContinuing.Name = "BCI_FilterContinuing";
            BCI_FilterContinuing.CheckedChanged += BBI_Filter_CheckedChanged;
            // 
            // BCI_FilterCompleted
            // 
            BCI_FilterCompleted.AllowAllUp = true;
            BCI_FilterCompleted.Caption = Resources.Form_InstallmentSale_Filter_Completed;
            BCI_FilterCompleted.GroupIndex = 2;
            BCI_FilterCompleted.Id = 17;
            BCI_FilterCompleted.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("BCI_FilterCompleted.ImageOptions.SvgImage");
            BCI_FilterCompleted.Name = "BCI_FilterCompleted";
            BCI_FilterCompleted.CheckedChanged += BBI_Filter_CheckedChanged;
            // 
            // ribbonPage1
            // 
            ribbonPage1.Groups.AddRange(new RibbonPageGroup[] { ribbonPageGroup1, ribbonPageGroup2, ribbonPageGroup3, ribbonPageGroupFilterDateRange, ribbonPageGroupFilterStatus });
            ribbonPage1.Name = "ribbonPage1";
            ribbonPage1.Text = Resources.Form_InstallmentSale_RibbonPage_Main;
            // 
            // ribbonPageGroup1
            // 
            ribbonPageGroup1.ItemLinks.Add(BBI_Refresh);
            ribbonPageGroup1.Name = "ribbonPageGroup1";
            ribbonPageGroup1.Text = Resources.Form_InstallmentSale_RibbonGroup_Operation;
            // 
            // ribbonPageGroup2
            // 
            ribbonPageGroup2.ItemLinks.Add(BBI_GridOptions);
            ribbonPageGroup2.Name = "ribbonPageGroup2";
            ribbonPageGroup2.Text = Resources.Form_InstallmentSale_RibbonGroup_Design;
            // 
            // ribbonPageGroup3
            // 
            ribbonPageGroup3.ItemLinks.Add(BSI_Reports);
            ribbonPageGroup3.Name = "ribbonPageGroup3";
            ribbonPageGroup3.Text = Resources.Common_Print;
            // 
            // ribbonPageGroupFilterDateRange
            // 
            ribbonPageGroupFilterDateRange.ItemLinks.Add(BCI_FilterDay);
            ribbonPageGroupFilterDateRange.ItemLinks.Add(BBI_FilterWeek);
            ribbonPageGroupFilterDateRange.ItemLinks.Add(BBI_FilterMonth);
            ribbonPageGroupFilterDateRange.Name = "ribbonPageGroupFilterDateRange";
            ribbonPageGroupFilterDateRange.Text = Resources.Form_InstallmentSale_RibbonGroup_DateRange;
            // 
            // ribbonPageGroupFilterStatus
            // 
            ribbonPageGroupFilterStatus.ItemLinks.Add(BCI_FilterContinuing);
            ribbonPageGroupFilterStatus.ItemLinks.Add(BCI_FilterCompleted);
            ribbonPageGroupFilterStatus.Name = "ribbonPageGroupFilterStatus";
            ribbonPageGroupFilterStatus.Text = Resources.Form_InstallmentSale_RibbonGroup_Status;
            // 
            // ribbonPage2
            // 
            ribbonPage2.Name = "ribbonPage2";
            ribbonPage2.Text = Resources.Form_InstallmentSale_RibbonPage_Settings;
            // 
            // panelSummary
            // 
            panelSummary.Appearance.BackColor = Color.FromArgb(240, 240, 240);
            panelSummary.Appearance.Options.UseBackColor = true;
            panelSummary.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            panelSummary.Controls.Add(panelCardRemaining);
            panelSummary.Controls.Add(panelCardPaid);
            panelSummary.Controls.Add(panelCardAmount);
            panelSummary.Controls.Add(panelCardCount);
            panelSummary.Dock = DockStyle.Top;
            panelSummary.Location = new Point(0, 158);
            panelSummary.Name = "panelSummary";
            panelSummary.Padding = new Padding(10);
            panelSummary.Size = new Size(954, 100);
            panelSummary.TabIndex = 1;
            panelSummary.Paint += panelSummary_Paint;
            // 
            // panelCardRemaining
            // 
            panelCardRemaining.Appearance.BackColor = Color.White;
            panelCardRemaining.Appearance.Options.UseBackColor = true;
            panelCardRemaining.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            panelCardRemaining.Controls.Add(svgCardRemaining_ImageBox);
            panelCardRemaining.Controls.Add(lblCardRemaining_Subtitle);
            panelCardRemaining.Controls.Add(lblCardRemaining_Value);
            panelCardRemaining.Controls.Add(lblCardRemaining_Title);
            panelCardRemaining.Location = new Point(711, 10);
            panelCardRemaining.Name = "panelCardRemaining";
            panelCardRemaining.Size = new Size(220, 80);
            panelCardRemaining.TabIndex = 3;
            panelCardRemaining.Paint += panelCard_Paint;
            // 
            // svgCardRemaining_ImageBox
            // 
            svgCardRemaining_ImageBox.BackColor = Color.FromArgb(255, 243, 224);
            svgCardRemaining_ImageBox.Location = new Point(175, 10);
            svgCardRemaining_ImageBox.Name = "svgCardRemaining_ImageBox";
            svgCardRemaining_ImageBox.Size = new Size(35, 35);
            svgCardRemaining_ImageBox.SvgImage = svgImageCollection1["Remaining"];
            svgCardRemaining_ImageBox.TabIndex = 3;
            svgCardRemaining_ImageBox.Text = "svgImageBox4";
            svgCardRemaining_ImageBox.Paint += svgCard_Paint;
            // 
            // lblCardRemaining_Subtitle
            // 
            lblCardRemaining_Subtitle.Appearance.ForeColor = Color.Gray;
            lblCardRemaining_Subtitle.Appearance.Options.UseForeColor = true;
            lblCardRemaining_Subtitle.Location = new Point(10, 58);
            lblCardRemaining_Subtitle.Name = "lblCardRemaining_Subtitle";
            lblCardRemaining_Subtitle.Size = new Size(62, 13);
            lblCardRemaining_Subtitle.TabIndex = 4;
            lblCardRemaining_Subtitle.Text = Resources.Form_InstallmentSale_Summary_Remaining_Subtitle;
            // 
            // lblCardRemaining_Value
            // 
            lblCardRemaining_Value.Appearance.Font = new Font("Tahoma", 14F, FontStyle.Bold);
            lblCardRemaining_Value.Appearance.Options.UseFont = true;
            lblCardRemaining_Value.Location = new Point(10, 30);
            lblCardRemaining_Value.Name = "lblCardRemaining_Value";
            lblCardRemaining_Value.Size = new Size(42, 23);
            lblCardRemaining_Value.TabIndex = 5;
            lblCardRemaining_Value.Text = "0.00";
            // 
            // lblCardRemaining_Title
            // 
            lblCardRemaining_Title.Appearance.ForeColor = Color.Gray;
            lblCardRemaining_Title.Appearance.Options.UseForeColor = true;
            lblCardRemaining_Title.Location = new Point(10, 10);
            lblCardRemaining_Title.Name = "lblCardRemaining_Title";
            lblCardRemaining_Title.Size = new Size(89, 13);
            lblCardRemaining_Title.TabIndex = 6;
            lblCardRemaining_Title.Text = Resources.Form_InstallmentSale_Summary_Remaining_Title;
            // 
            // panelCardPaid
            // 
            panelCardPaid.Appearance.BackColor = Color.White;
            panelCardPaid.Appearance.Options.UseBackColor = true;
            panelCardPaid.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            panelCardPaid.Controls.Add(svgCardPaid_ImageBox);
            panelCardPaid.Controls.Add(lblCardPaid_Subtitle);
            panelCardPaid.Controls.Add(lblCardPaid_Value);
            panelCardPaid.Controls.Add(lblCardPaid_Title);
            panelCardPaid.Location = new Point(478, 10);
            panelCardPaid.Name = "panelCardPaid";
            panelCardPaid.Size = new Size(220, 80);
            panelCardPaid.TabIndex = 2;
            panelCardPaid.Paint += panelCard_Paint;
            // 
            // svgCardPaid_ImageBox
            // 
            svgCardPaid_ImageBox.BackColor = Color.FromArgb(232, 245, 233);
            svgCardPaid_ImageBox.Location = new Point(175, 10);
            svgCardPaid_ImageBox.Name = "svgCardPaid_ImageBox";
            svgCardPaid_ImageBox.Size = new Size(35, 35);
            svgCardPaid_ImageBox.SvgImage = svgImageCollection1["Paid"];
            svgCardPaid_ImageBox.TabIndex = 3;
            svgCardPaid_ImageBox.Text = "svgImageBox3";
            svgCardPaid_ImageBox.Paint += svgCard_Paint;
            // 
            // lblCardPaid_Subtitle
            // 
            lblCardPaid_Subtitle.Appearance.ForeColor = Color.Gray;
            lblCardPaid_Subtitle.Appearance.Options.UseForeColor = true;
            lblCardPaid_Subtitle.Location = new Point(10, 58);
            lblCardPaid_Subtitle.Name = "lblCardPaid_Subtitle";
            lblCardPaid_Subtitle.Size = new Size(62, 13);
            lblCardPaid_Subtitle.TabIndex = 4;
            lblCardPaid_Subtitle.Text = Resources.Form_InstallmentSale_Summary_Paid_Subtitle;
            // 
            // lblCardPaid_Value
            // 
            lblCardPaid_Value.Appearance.Font = new Font("Tahoma", 14F, FontStyle.Bold);
            lblCardPaid_Value.Appearance.Options.UseFont = true;
            lblCardPaid_Value.Location = new Point(10, 30);
            lblCardPaid_Value.Name = "lblCardPaid_Value";
            lblCardPaid_Value.Size = new Size(42, 23);
            lblCardPaid_Value.TabIndex = 5;
            lblCardPaid_Value.Text = "0.00";
            // 
            // lblCardPaid_Title
            // 
            lblCardPaid_Title.Appearance.ForeColor = Color.Gray;
            lblCardPaid_Title.Appearance.Options.UseForeColor = true;
            lblCardPaid_Title.Location = new Point(10, 10);
            lblCardPaid_Title.Name = "lblCardPaid_Title";
            lblCardPaid_Title.Size = new Size(47, 13);
            lblCardPaid_Title.TabIndex = 6;
            lblCardPaid_Title.Text = Resources.Form_InstallmentSale_Summary_Paid_Title;
            // 
            // panelCardAmount
            // 
            panelCardAmount.Appearance.BackColor = Color.White;
            panelCardAmount.Appearance.Options.UseBackColor = true;
            panelCardAmount.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            panelCardAmount.Controls.Add(svgCardAmount_ImageBox);
            panelCardAmount.Controls.Add(lblCardAmount_Subtitle);
            panelCardAmount.Controls.Add(lblCardAmount_Value);
            panelCardAmount.Controls.Add(lblCardAmount_Title);
            panelCardAmount.Location = new Point(245, 10);
            panelCardAmount.Name = "panelCardAmount";
            panelCardAmount.Size = new Size(220, 80);
            panelCardAmount.TabIndex = 1;
            panelCardAmount.Paint += panelCard_Paint;
            // 
            // svgCardAmount_ImageBox
            // 
            svgCardAmount_ImageBox.BackColor = Color.FromArgb(224, 242, 241);
            svgCardAmount_ImageBox.Location = new Point(175, 10);
            svgCardAmount_ImageBox.Name = "svgCardAmount_ImageBox";
            svgCardAmount_ImageBox.Size = new Size(35, 35);
            svgCardAmount_ImageBox.SvgImage = svgImageCollection1["Amount"];
            svgCardAmount_ImageBox.TabIndex = 3;
            svgCardAmount_ImageBox.Text = "svgImageBox2";
            svgCardAmount_ImageBox.Paint += svgCard_Paint;
            // 
            // lblCardAmount_Subtitle
            // 
            lblCardAmount_Subtitle.Appearance.ForeColor = Color.Gray;
            lblCardAmount_Subtitle.Appearance.Options.UseForeColor = true;
            lblCardAmount_Subtitle.Location = new Point(10, 58);
            lblCardAmount_Subtitle.Name = "lblCardAmount_Subtitle";
            lblCardAmount_Subtitle.Size = new Size(62, 13);
            lblCardAmount_Subtitle.TabIndex = 4;
            lblCardAmount_Subtitle.Text = Resources.Form_InstallmentSale_Summary_Amount_Subtitle;
            // 
            // lblCardAmount_Value
            // 
            lblCardAmount_Value.Appearance.Font = new Font("Tahoma", 14F, FontStyle.Bold);
            lblCardAmount_Value.Appearance.Options.UseFont = true;
            lblCardAmount_Value.Location = new Point(10, 30);
            lblCardAmount_Value.Name = "lblCardAmount_Value";
            lblCardAmount_Value.Size = new Size(42, 23);
            lblCardAmount_Value.TabIndex = 5;
            lblCardAmount_Value.Text = "0.00";
            // 
            // lblCardAmount_Title
            // 
            lblCardAmount_Title.Appearance.ForeColor = Color.Gray;
            lblCardAmount_Title.Appearance.Options.UseForeColor = true;
            lblCardAmount_Title.Location = new Point(10, 10);
            lblCardAmount_Title.Name = "lblCardAmount_Title";
            lblCardAmount_Title.Size = new Size(64, 13);
            lblCardAmount_Title.TabIndex = 6;
            lblCardAmount_Title.Text = Resources.Form_InstallmentSale_Summary_Amount_Title;
            // 
            // panelCardCount
            // 
            panelCardCount.Appearance.BackColor = Color.White;
            panelCardCount.Appearance.Options.UseBackColor = true;
            panelCardCount.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            panelCardCount.Controls.Add(svgCardCount_ImageBox);
            panelCardCount.Controls.Add(lblCardCount_Subtitle);
            panelCardCount.Controls.Add(lblCardCount_Value);
            panelCardCount.Controls.Add(lblCardCount_Title);
            panelCardCount.Location = new Point(12, 10);
            panelCardCount.Name = "panelCardCount";
            panelCardCount.Size = new Size(220, 80);
            panelCardCount.TabIndex = 0;
            panelCardCount.Paint += panelCard_Paint;
            // 
            // svgCardCount_ImageBox
            // 
            svgCardCount_ImageBox.BackColor = Color.FromArgb(232, 244, 255);
            svgCardCount_ImageBox.Location = new Point(175, 10);
            svgCardCount_ImageBox.Name = "svgCardCount_ImageBox";
            svgCardCount_ImageBox.Size = new Size(35, 35);
            svgCardCount_ImageBox.SvgImage = svgImageCollection1["Count"];
            svgCardCount_ImageBox.TabIndex = 3;
            svgCardCount_ImageBox.Text = "svgImageBox1";
            svgCardCount_ImageBox.Paint += svgCard_Paint;
            // 
            // lblCardCount_Subtitle
            // 
            lblCardCount_Subtitle.Appearance.ForeColor = Color.Gray;
            lblCardCount_Subtitle.Appearance.Options.UseForeColor = true;
            lblCardCount_Subtitle.Location = new Point(10, 58);
            lblCardCount_Subtitle.Name = "lblCardCount_Subtitle";
            lblCardCount_Subtitle.Size = new Size(62, 13);
            lblCardCount_Subtitle.TabIndex = 4;
            lblCardCount_Subtitle.Text = Resources.Form_InstallmentSale_Summary_Count_Subtitle;
            // 
            // lblCardCount_Value
            // 
            lblCardCount_Value.Appearance.Font = new Font("Tahoma", 14F, FontStyle.Bold);
            lblCardCount_Value.Appearance.Options.UseFont = true;
            lblCardCount_Value.Location = new Point(10, 30);
            lblCardCount_Value.Name = "lblCardCount_Value";
            lblCardCount_Value.Size = new Size(12, 23);
            lblCardCount_Value.TabIndex = 5;
            lblCardCount_Value.Text = "0";
            // 
            // lblCardCount_Title
            // 
            lblCardCount_Title.Appearance.ForeColor = Color.Gray;
            lblCardCount_Title.Appearance.Options.UseForeColor = true;
            lblCardCount_Title.Location = new Point(10, 10);
            lblCardCount_Title.Name = "lblCardCount_Title";
            lblCardCount_Title.Size = new Size(76, 13);
            lblCardCount_Title.TabIndex = 6;
            lblCardCount_Title.Text = Resources.Form_InstallmentSale_Summary_Count_Title;
            // 
            // FormInstallmentSale
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(954, 526);
            Controls.Add(gridControl1);
            Controls.Add(panelSummary);
            Controls.Add(ribbonControl1);
            Name = "FormInstallmentSale";
            Ribbon = ribbonControl1;
            Text = Resources.Form_InstallmentSale_Caption;
            ((System.ComponentModel.ISupportInitialize)svgImageCollection1).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridControl1).EndInit();
            ((System.ComponentModel.ISupportInitialize)bindingSourceTrInstallmentSale).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)repoBtnEdit_Payment).EndInit();
            ((System.ComponentModel.ISupportInitialize)ribbonControl1).EndInit();
            ((System.ComponentModel.ISupportInitialize)panelSummary).EndInit();
            panelSummary.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)panelCardRemaining).EndInit();
            panelCardRemaining.ResumeLayout(false);
            panelCardRemaining.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)svgCardRemaining_ImageBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)panelCardPaid).EndInit();
            panelCardPaid.ResumeLayout(false);
            panelCardPaid.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)svgCardPaid_ImageBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)panelCardAmount).EndInit();
            panelCardAmount.ResumeLayout(false);
            panelCardAmount.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)svgCardAmount_ImageBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)panelCardCount).EndInit();
            panelCardCount.ResumeLayout(false);
            panelCardCount.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)svgCardCount_ImageBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelSummary;
        private DevExpress.XtraEditors.PanelControl panelCardCount;
        private DevExpress.XtraEditors.LabelControl lblCardCount_Title;
        private DevExpress.XtraEditors.LabelControl lblCardCount_Value;
        private DevExpress.XtraEditors.LabelControl lblCardCount_Subtitle;
        private DevExpress.XtraEditors.SvgImageBox svgCardCount_ImageBox;
        private DevExpress.XtraEditors.PanelControl panelCardAmount;
        private DevExpress.XtraEditors.LabelControl lblCardAmount_Title;
        private DevExpress.XtraEditors.LabelControl lblCardAmount_Value;
        private DevExpress.XtraEditors.LabelControl lblCardAmount_Subtitle;
        private DevExpress.XtraEditors.SvgImageBox svgCardAmount_ImageBox;
        private DevExpress.XtraEditors.PanelControl panelCardPaid;
        private DevExpress.XtraEditors.LabelControl lblCardPaid_Title;
        private DevExpress.XtraEditors.LabelControl lblCardPaid_Value;
        private DevExpress.XtraEditors.LabelControl lblCardPaid_Subtitle;
        private DevExpress.XtraEditors.SvgImageBox svgCardPaid_ImageBox;
        private DevExpress.XtraEditors.PanelControl panelCardRemaining;
        private DevExpress.XtraEditors.LabelControl lblCardRemaining_Title;
        private DevExpress.XtraEditors.LabelControl lblCardRemaining_Value;
        private DevExpress.XtraEditors.LabelControl lblCardRemaining_Subtitle;
        private DevExpress.XtraEditors.SvgImageBox svgCardRemaining_ImageBox;

        private DevExpress.Utils.SvgImageCollection svgImageCollection1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.BindingSource bindingSourceTrInstallmentSale;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repoBtnEdit_Payment;
        private DevExpress.XtraGrid.Columns.GridColumn col_Buttons;
        private DevExpress.XtraGrid.Columns.GridColumn colInvoiceHeaderId;
        private DevExpress.XtraGrid.Columns.GridColumn colMonthlyPayment;
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.BarButtonItem BBI_Refresh;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraBars.BarButtonItem BBI_GridOptions;
        private BarSubItem BSI_Reports;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup3;
        private DevExpress.XtraBars.BarButtonItem BBI_QueryEdit;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage2;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroupFilterDateRange;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroupFilterStatus;
        private BarCheckItem BCI_FilterDay;
        private BarCheckItem BBI_FilterWeek;
        private BarCheckItem BBI_FilterMonth;
        private BarCheckItem BCI_FilterContinuing;
        private BarCheckItem BCI_FilterCompleted;
    }
}
