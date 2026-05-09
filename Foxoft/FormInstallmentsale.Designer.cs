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
            ribbonPage1 = new RibbonPage();
            ribbonPageGroup1 = new RibbonPageGroup();
            ribbonPageGroup2 = new RibbonPageGroup();
            ribbonPageGroup3 = new RibbonPageGroup();
            ribbonPageGroup5 = new RibbonPageGroup();
            ribbonPage2 = new RibbonPage();
            ribbonPageGroup4 = new RibbonPageGroup();
            panelSummary = new DevExpress.XtraEditors.PanelControl();
            panelCard4 = new DevExpress.XtraEditors.PanelControl();
            svgCard4 = new DevExpress.XtraEditors.SvgImageBox();
            lblCard4Subtitle = new DevExpress.XtraEditors.LabelControl();
            lblCard4Value = new DevExpress.XtraEditors.LabelControl();
            lblCard4Title = new DevExpress.XtraEditors.LabelControl();
            panelCard3 = new DevExpress.XtraEditors.PanelControl();
            svgCard3 = new DevExpress.XtraEditors.SvgImageBox();
            lblCard3Subtitle = new DevExpress.XtraEditors.LabelControl();
            lblCard3Value = new DevExpress.XtraEditors.LabelControl();
            lblCard3Title = new DevExpress.XtraEditors.LabelControl();
            panelCard2 = new DevExpress.XtraEditors.PanelControl();
            svgCard2 = new DevExpress.XtraEditors.SvgImageBox();
            lblCard2Subtitle = new DevExpress.XtraEditors.LabelControl();
            lblCard2Value = new DevExpress.XtraEditors.LabelControl();
            lblCard2Title = new DevExpress.XtraEditors.LabelControl();
            panelCard1 = new DevExpress.XtraEditors.PanelControl();
            svgCard1 = new DevExpress.XtraEditors.SvgImageBox();
            lblCard1Subtitle = new DevExpress.XtraEditors.LabelControl();
            lblCard1Value = new DevExpress.XtraEditors.LabelControl();
            lblCard1Title = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)gridControl1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bindingSourceTrInstallmentSale).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)repoBtnEdit_Payment).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ribbonControl1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)panelSummary).BeginInit();
            panelSummary.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)panelCard4).BeginInit();
            panelCard4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)svgCard4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)panelCard3).BeginInit();
            panelCard3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)svgCard3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)panelCard2).BeginInit();
            panelCard2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)svgCard2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)panelCard1).BeginInit();
            panelCard1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)svgCard1).BeginInit();
            SuspendLayout();
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
            ribbonControl1.Items.AddRange(new BarItem[] { ribbonControl1.ExpandCollapseItem, BBI_Refresh, BBI_GridOptions, BSI_Reports, BBI_QueryEdit, BCI_FilterDay, BBI_FilterWeek, BBI_FilterMonth });
            ribbonControl1.Location = new Point(0, 0);
            ribbonControl1.MaxItemId = 16;
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
            // ribbonPage1
            // 
            ribbonPage1.Groups.AddRange(new RibbonPageGroup[] { ribbonPageGroup1, ribbonPageGroup2, ribbonPageGroup3, ribbonPageGroup5 });
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
            // ribbonPageGroup5
            // 
            ribbonPageGroup5.ItemLinks.Add(BCI_FilterDay);
            ribbonPageGroup5.ItemLinks.Add(BBI_FilterWeek);
            ribbonPageGroup5.ItemLinks.Add(BBI_FilterMonth);
            ribbonPageGroup5.Name = "ribbonPageGroup5";
            ribbonPageGroup5.Text = Resources.Form_InstallmentSale_RibbonGroup_Filter;
            // 
            // ribbonPage2
            // 
            ribbonPage2.Groups.AddRange(new RibbonPageGroup[] { ribbonPageGroup4 });
            ribbonPage2.Name = "ribbonPage2";
            ribbonPage2.Text = Resources.Form_InstallmentSale_RibbonPage_Settings;
            // 
            // ribbonPageGroup4
            // 
            ribbonPageGroup4.ItemLinks.Add(BBI_QueryEdit);
            ribbonPageGroup4.Name = "ribbonPageGroup4";
            ribbonPageGroup4.Text = Resources.Form_InstallmentSale_RibbonGroup_Query;
            // 
            // panelSummary
            // 
            panelSummary.Appearance.BackColor = Color.FromArgb(240, 240, 240);
            panelSummary.Appearance.Options.UseBackColor = true;
            panelSummary.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            panelSummary.Controls.Add(panelCard4);
            panelSummary.Controls.Add(panelCard3);
            panelSummary.Controls.Add(panelCard2);
            panelSummary.Controls.Add(panelCard1);
            panelSummary.Dock = DockStyle.Top;
            panelSummary.Location = new Point(0, 158);
            panelSummary.Name = "panelSummary";
            panelSummary.Padding = new Padding(10);
            panelSummary.Size = new Size(954, 100);
            panelSummary.TabIndex = 1;
            panelSummary.Paint += panelSummary_Paint;
            // 
            // panelCard4
            // 
            panelCard4.Appearance.BackColor = Color.White;
            panelCard4.Appearance.Options.UseBackColor = true;
            panelCard4.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            panelCard4.Controls.Add(svgCard4);
            panelCard4.Controls.Add(lblCard4Subtitle);
            panelCard4.Controls.Add(lblCard4Value);
            panelCard4.Controls.Add(lblCard4Title);
            panelCard4.Location = new Point(711, 10);
            panelCard4.Name = "panelCard4";
            panelCard4.Size = new Size(220, 80);
            panelCard4.TabIndex = 3;
            panelCard4.Paint += panelCard_Paint;
            // 
            // svgCard4
            // 
            svgCard4.BackColor = Color.FromArgb(255, 243, 224);
            svgCard4.Location = new Point(175, 10);
            svgCard4.Name = "svgCard4";
            svgCard4.Size = new Size(35, 35);
            svgCard4.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("svgCard4.SvgImage");
            svgCard4.TabIndex = 3;
            svgCard4.Text = "svgImageBox4";
            svgCard4.Paint += svgCard_Paint;
            // 
            // lblCard4Subtitle
            // 
            lblCard4Subtitle.Appearance.ForeColor = Color.Gray;
            lblCard4Subtitle.Appearance.Options.UseForeColor = true;
            lblCard4Subtitle.Location = new Point(10, 58);
            lblCard4Subtitle.Name = "lblCard4Subtitle";
            lblCard4Subtitle.Size = new Size(62, 13);
            lblCard4Subtitle.TabIndex = 4;
            lblCard4Subtitle.Text = global::Foxoft.Properties.Resources.Form_InstallmentSale_Summary_Remaining_Subtitle;
            // 
            // lblCard4Value
            // 
            lblCard4Value.Appearance.Font = new Font("Tahoma", 14F, FontStyle.Bold);
            lblCard4Value.Appearance.Options.UseFont = true;
            lblCard4Value.Location = new Point(10, 30);
            lblCard4Value.Name = "lblCard4Value";
            lblCard4Value.Size = new Size(42, 23);
            lblCard4Value.TabIndex = 5;
            lblCard4Value.Text = "0.00";
            // 
            // lblCard4Title
            // 
            lblCard4Title.Appearance.ForeColor = Color.Gray;
            lblCard4Title.Appearance.Options.UseForeColor = true;
            lblCard4Title.Location = new Point(10, 10);
            lblCard4Title.Name = "lblCard4Title";
            lblCard4Title.Size = new Size(89, 13);
            lblCard4Title.TabIndex = 6;
            lblCard4Title.Text = global::Foxoft.Properties.Resources.Form_InstallmentSale_Summary_Remaining_Title;
            // 
            // panelCard3
            // 
            panelCard3.Appearance.BackColor = Color.White;
            panelCard3.Appearance.Options.UseBackColor = true;
            panelCard3.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            panelCard3.Controls.Add(svgCard3);
            panelCard3.Controls.Add(lblCard3Subtitle);
            panelCard3.Controls.Add(lblCard3Value);
            panelCard3.Controls.Add(lblCard3Title);
            panelCard3.Location = new Point(478, 10);
            panelCard3.Name = "panelCard3";
            panelCard3.Size = new Size(220, 80);
            panelCard3.TabIndex = 2;
            panelCard3.Paint += panelCard_Paint;
            // 
            // svgCard3
            // 
            svgCard3.BackColor = Color.FromArgb(232, 245, 233);
            svgCard3.Location = new Point(175, 10);
            svgCard3.Name = "svgCard3";
            svgCard3.Size = new Size(35, 35);
            svgCard3.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("svgCard3.SvgImage");
            svgCard3.TabIndex = 3;
            svgCard3.Text = "svgImageBox3";
            svgCard3.Paint += svgCard_Paint;
            // 
            // lblCard3Subtitle
            // 
            lblCard3Subtitle.Appearance.ForeColor = Color.Gray;
            lblCard3Subtitle.Appearance.Options.UseForeColor = true;
            lblCard3Subtitle.Location = new Point(10, 58);
            lblCard3Subtitle.Name = "lblCard3Subtitle";
            lblCard3Subtitle.Size = new Size(62, 13);
            lblCard3Subtitle.TabIndex = 4;
            lblCard3Subtitle.Text = global::Foxoft.Properties.Resources.Form_InstallmentSale_Summary_Paid_Subtitle;
            // 
            // lblCard3Value
            // 
            lblCard3Value.Appearance.Font = new Font("Tahoma", 14F, FontStyle.Bold);
            lblCard3Value.Appearance.Options.UseFont = true;
            lblCard3Value.Location = new Point(10, 30);
            lblCard3Value.Name = "lblCard3Value";
            lblCard3Value.Size = new Size(42, 23);
            lblCard3Value.TabIndex = 5;
            lblCard3Value.Text = "0.00";
            // 
            // lblCard3Title
            // 
            lblCard3Title.Appearance.ForeColor = Color.Gray;
            lblCard3Title.Appearance.Options.UseForeColor = true;
            lblCard3Title.Location = new Point(10, 10);
            lblCard3Title.Name = "lblCard3Title";
            lblCard3Title.Size = new Size(60, 13);
            lblCard3Title.TabIndex = 6;
            lblCard3Title.Text = global::Foxoft.Properties.Resources.Form_InstallmentSale_Summary_Paid_Title;
            // 
            // panelCard2
            // 
            panelCard2.Appearance.BackColor = Color.White;
            panelCard2.Appearance.Options.UseBackColor = true;
            panelCard2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            panelCard2.Controls.Add(svgCard2);
            panelCard2.Controls.Add(lblCard2Subtitle);
            panelCard2.Controls.Add(lblCard2Value);
            panelCard2.Controls.Add(lblCard2Title);
            panelCard2.Location = new Point(245, 10);
            panelCard2.Name = "panelCard2";
            panelCard2.Size = new Size(220, 80);
            panelCard2.TabIndex = 1;
            panelCard2.Paint += panelCard_Paint;
            // 
            // svgCard2
            // 
            svgCard2.BackColor = Color.FromArgb(224, 242, 241);
            svgCard2.Location = new Point(175, 10);
            svgCard2.Name = "svgCard2";
            svgCard2.Size = new Size(35, 35);
            svgCard2.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("svgCard2.SvgImage");
            svgCard2.TabIndex = 3;
            svgCard2.Text = "svgImageBox2";
            svgCard2.Paint += svgCard_Paint;
            // 
            // lblCard2Subtitle
            // 
            lblCard2Subtitle.Appearance.ForeColor = Color.Gray;
            lblCard2Subtitle.Appearance.Options.UseForeColor = true;
            lblCard2Subtitle.Location = new Point(10, 58);
            lblCard2Subtitle.Name = "lblCard2Subtitle";
            lblCard2Subtitle.Size = new Size(62, 13);
            lblCard2Subtitle.TabIndex = 4;
            lblCard2Subtitle.Text = global::Foxoft.Properties.Resources.Form_InstallmentSale_Summary_Amount_Subtitle;
            // 
            // lblCard2Value
            // 
            lblCard2Value.Appearance.Font = new Font("Tahoma", 14F, FontStyle.Bold);
            lblCard2Value.Appearance.Options.UseFont = true;
            lblCard2Value.Location = new Point(10, 30);
            lblCard2Value.Name = "lblCard2Value";
            lblCard2Value.Size = new Size(42, 23);
            lblCard2Value.TabIndex = 5;
            lblCard2Value.Text = "0.00";
            // 
            // lblCard2Title
            // 
            lblCard2Title.Appearance.ForeColor = Color.Gray;
            lblCard2Title.Appearance.Options.UseForeColor = true;
            lblCard2Title.Location = new Point(10, 10);
            lblCard2Title.Name = "lblCard2Title";
            lblCard2Title.Size = new Size(69, 13);
            lblCard2Title.TabIndex = 6;
            lblCard2Title.Text = global::Foxoft.Properties.Resources.Form_InstallmentSale_Summary_Amount_Title;
            // 
            // panelCard1
            // 
            panelCard1.Appearance.BackColor = Color.White;
            panelCard1.Appearance.Options.UseBackColor = true;
            panelCard1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            panelCard1.Controls.Add(svgCard1);
            panelCard1.Controls.Add(lblCard1Subtitle);
            panelCard1.Controls.Add(lblCard1Value);
            panelCard1.Controls.Add(lblCard1Title);
            panelCard1.Location = new Point(12, 10);
            panelCard1.Name = "panelCard1";
            panelCard1.Size = new Size(220, 80);
            panelCard1.TabIndex = 0;
            panelCard1.Paint += panelCard_Paint;
            // 
            // svgCard1
            // 
            svgCard1.BackColor = Color.FromArgb(232, 244, 255);
            svgCard1.Location = new Point(175, 10);
            svgCard1.Name = "svgCard1";
            svgCard1.Size = new Size(35, 35);
            svgCard1.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("svgCard1.SvgImage");
            svgCard1.TabIndex = 3;
            svgCard1.Text = "svgImageBox1";
            svgCard1.Paint += svgCard_Paint;
            // 
            // lblCard1Subtitle
            // 
            lblCard1Subtitle.Appearance.ForeColor = Color.Gray;
            lblCard1Subtitle.Appearance.Options.UseForeColor = true;
            lblCard1Subtitle.Location = new Point(10, 58);
            lblCard1Subtitle.Name = "lblCard1Subtitle";
            lblCard1Subtitle.Size = new Size(62, 13);
            lblCard1Subtitle.TabIndex = 4;
            lblCard1Subtitle.Text = global::Foxoft.Properties.Resources.Form_InstallmentSale_Summary_Count_Subtitle;
            // 
            // lblCard1Value
            // 
            lblCard1Value.Appearance.Font = new Font("Tahoma", 14F, FontStyle.Bold);
            lblCard1Value.Appearance.Options.UseFont = true;
            lblCard1Value.Location = new Point(10, 30);
            lblCard1Value.Name = "lblCard1Value";
            lblCard1Value.Size = new Size(12, 23);
            lblCard1Value.TabIndex = 5;
            lblCard1Value.Text = "0";
            // 
            // lblCard1Title
            // 
            lblCard1Title.Appearance.ForeColor = Color.Gray;
            lblCard1Title.Appearance.Options.UseForeColor = true;
            lblCard1Title.Location = new Point(10, 10);
            lblCard1Title.Name = "lblCard1Title";
            lblCard1Title.Size = new Size(61, 13);
            lblCard1Title.TabIndex = 6;
            lblCard1Title.Text = global::Foxoft.Properties.Resources.Form_InstallmentSale_Summary_Count_Title;
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
            Text = "Installment Sales";
            ((System.ComponentModel.ISupportInitialize)gridControl1).EndInit();
            ((System.ComponentModel.ISupportInitialize)bindingSourceTrInstallmentSale).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)repoBtnEdit_Payment).EndInit();
            ((System.ComponentModel.ISupportInitialize)ribbonControl1).EndInit();
            ((System.ComponentModel.ISupportInitialize)panelSummary).EndInit();
            panelSummary.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)panelCard4).EndInit();
            panelCard4.ResumeLayout(false);
            panelCard4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)svgCard4).EndInit();
            ((System.ComponentModel.ISupportInitialize)panelCard3).EndInit();
            panelCard3.ResumeLayout(false);
            panelCard3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)svgCard3).EndInit();
            ((System.ComponentModel.ISupportInitialize)panelCard2).EndInit();
            panelCard2.ResumeLayout(false);
            panelCard2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)svgCard2).EndInit();
            ((System.ComponentModel.ISupportInitialize)panelCard1).EndInit();
            panelCard1.ResumeLayout(false);
            panelCard1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)svgCard1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelSummary;
        private DevExpress.XtraEditors.PanelControl panelCard1;
        private DevExpress.XtraEditors.LabelControl lblCard1Title;
        private DevExpress.XtraEditors.LabelControl lblCard1Value;
        private DevExpress.XtraEditors.LabelControl lblCard1Subtitle;
        private DevExpress.XtraEditors.SvgImageBox svgCard1;
        private DevExpress.XtraEditors.PanelControl panelCard2;
        private DevExpress.XtraEditors.LabelControl lblCard2Title;
        private DevExpress.XtraEditors.LabelControl lblCard2Value;
        private DevExpress.XtraEditors.LabelControl lblCard2Subtitle;
        private DevExpress.XtraEditors.SvgImageBox svgCard2;
        private DevExpress.XtraEditors.PanelControl panelCard3;
        private DevExpress.XtraEditors.LabelControl lblCard3Title;
        private DevExpress.XtraEditors.LabelControl lblCard3Value;
        private DevExpress.XtraEditors.LabelControl lblCard3Subtitle;
        private DevExpress.XtraEditors.SvgImageBox svgCard3;
        private DevExpress.XtraEditors.PanelControl panelCard4;
        private DevExpress.XtraEditors.LabelControl lblCard4Title;
        private DevExpress.XtraEditors.LabelControl lblCard4Value;
        private DevExpress.XtraEditors.LabelControl lblCard4Subtitle;
        private DevExpress.XtraEditors.SvgImageBox svgCard4;

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
        private BarButtonItem BBI_QueryEdit;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage2;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup4;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup5;
        private BarCheckItem BCI_FilterDay;
        private BarCheckItem BBI_FilterWeek;
        private BarCheckItem BBI_FilterMonth;
    }
}
