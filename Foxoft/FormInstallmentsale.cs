using DevExpress.Data;
using DevExpress.Data.Filtering;
using DevExpress.Utils;
using DevExpress.Utils.Menu;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Frames;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Localization;
using DevExpress.XtraGrid.Menu;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraReports;
using DevExpress.XtraRichEdit.Fields;
using DevExpress.XtraSplashScreen;
using Foxoft.AppCode;
using Foxoft.AppCode.Service;
using Foxoft.Migrations;
using Foxoft.Models;
using Foxoft.Models.Entity.Report;
using Foxoft.Properties;
using Microsoft.Data.SqlClient;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Drawing.Drawing2D;

namespace Foxoft
{
    public partial class FormInstallmentSale : RibbonForm
    {
        EfMethods efMethods = new();
        TrInstallmentViewModel trInstallmentViewModel;
        DcReport dcReport;
        ReportClass reportClass;
        readonly SettingStore settingStore;
        private readonly subContext _db = new();
        private readonly DocumentLockService _lockService;

        public FormInstallmentSale()
        {

            InitializeComponent();
            _lockService = new DocumentLockService(_db);

            SetSummaryIcons();

            ReloadData();

            gridView1.PopulateColumns();
            LoadLayout();

            gridView1.ColumnFilterChanged += (s, e) => UpdateSummary();

            HyperLinkColumns();

            gridView1.Columns.Add(col_Buttons);
            col_Buttons.VisibleIndex = gridView1.Columns.Count - 1;
            gridView1.BestFitColumns();
            //ApplyConditionalFormatting();

            settingStore = efMethods.SelectSettingStore(Authorization.StoreCode);
            reportClass = new(settingStore.DesignFileFolder);
            string activeFilterStr = "[StoreCode] = '" + Authorization.StoreCode + "'";
            reportClass.AddReports(BSI_Reports, "InstallmentSale", nameof(TrInstallment.InvoiceHeaderId), gridView1, activeFilterStr);

            GridLocalizer.Active = new MyGridLocalizer();

            UpdateSummary();
        }

        private void LoadLayout()
        {
            dcReport = efMethods.SelectReportByName("Report_Embedded_InstallmentSale");
            if (!string.IsNullOrEmpty(dcReport?.ReportLayout) && dcReport?.ReportId > 0)
            {
                byte[] byteArray = Encoding.Unicode.GetBytes(dcReport.ReportLayout);
                MemoryStream stream = new(byteArray);
                gridView1.RestoreLayoutFromStream(stream);
            }

            TrimNumbersFormat();

            LocalizeColumns();
        }

        private void TrimNumbersFormat()
        {
            foreach (var item in gridView1.Columns)
            {
                GridColumn gridColumn = (GridColumn)item;
                if (gridColumn.ColumnType.Name == "Decimal")
                {
                    gridColumn.DisplayFormat.FormatType = FormatType.Numeric;
                    gridColumn.DisplayFormat.FormatString = "0.00";
                }
            }
        }

        private void SaveLayout()
        {
            if (dcReport?.ReportId > 0)
            {
                Stream str = new MemoryStream();
                gridView1.SaveLayoutToStream(str);
                str.Seek(0, SeekOrigin.Begin);
                StreamReader reader = new(str);
                string layoutTxt = reader.ReadToEnd();
                efMethods.UpdateReportLayout(dcReport.ReportId, layoutTxt);
            }
        }

        private void ApplyConditionalFormatting()
        {
            // Formatting rule for "Less than 0"
            var formatRuleLess = new GridFormatRule
            {
                Column = gridView1.Columns[nameof(TrInstallmentViewModel.DueAmount)],
                Rule = new FormatConditionRuleValue
                {
                    Condition = FormatCondition.Less,
                    Value1 = 0,
                    Appearance = { ForeColor = Color.Red }
                }
            };

            var formatRuleGreater = new GridFormatRule
            {
                Column = gridView1.Columns[nameof(TrInstallmentViewModel.DueAmount)],
                Rule = new FormatConditionRuleValue
                {
                    Condition = FormatCondition.Greater,
                    Value1 = 0,
                    Appearance = { ForeColor = Color.Green }
                }
            };

            gridView1.FormatRules.AddRange(new GridFormatRule[] { formatRuleLess, formatRuleGreater });

        }

        private void HyperLinkColumns()
        {
            GridColumn col_DocumentNumber = gridView1.Columns[nameof(TrInvoiceHeader.DocumentNumber)];
            if (col_DocumentNumber is not null)
            {
                RepositoryItemHyperLinkEdit HLE_DocumentNum = new();
                HLE_DocumentNum.SingleClick = true;
                HLE_DocumentNum.OpenLink += repoHLE_DocumentNumber_OpenLink;
                col_DocumentNumber.ColumnEdit = HLE_DocumentNum;
            }

            GridColumn col_InvoiceNum = gridView1.Columns["InvoiceNumber"];
            if (col_InvoiceNum is not null)
            {
                RepositoryItemHyperLinkEdit HLE_InvoiceNum = new();
                HLE_InvoiceNum.SingleClick = true;
                HLE_InvoiceNum.OpenLink += repoHLE_DocumentNumber_OpenLink;
                col_InvoiceNum.ColumnEdit = HLE_InvoiceNum;
            }

            GridColumn col_CurrAccCode = gridView1.Columns[nameof(TrInvoiceHeader.CurrAccCode)];
            if (col_CurrAccCode is not null)
            {
                RepositoryItemHyperLinkEdit HLE_CurrAccCode = new();
                HLE_CurrAccCode.SingleClick = true;
                HLE_CurrAccCode.OpenLink += repoHLE_CurrAccCode_OpenLink;
                col_CurrAccCode.ColumnEdit = HLE_CurrAccCode;
            }
        }

        GridColumn prevColumn = null; // Disable the Immediate Edit Cell
        int prevRow = -1;

        private void gV_Report_ShowingEditor(object sender, CancelEventArgs e)
        {
            GridView view = sender as GridView;

            // Disable the Immediate Edit Cell
            if (prevColumn != view.FocusedColumn || prevRow != view.FocusedRowHandle)
                e.Cancel = true;
            prevColumn = view.FocusedColumn;
            prevRow = view.FocusedRowHandle;
        }

        private void repoHLE_CurrAccCode_OpenLink(object sender, OpenLinkEventArgs e)
        {
            object objCurrAccCode = gridView1.GetFocusedRowCellValue(nameof(TrInvoiceHeader.CurrAccCode));
            string currAccCode = objCurrAccCode?.ToString();
            if (!string.IsNullOrEmpty(currAccCode))
                OpenFormCurrAcc(currAccCode);
        }

        private void OpenFormCurrAcc(string currAccCode)
        {
            FormCurrAcc formCurrAcc = new(currAccCode);
            if (formCurrAcc.ShowDialog(this) == DialogResult.OK)
            {
                LoadData();
            }
        }

        private void repoHLE_DocumentNumber_OpenLink(object sender, OpenLinkEventArgs e)
        {
            object objDocNum = gridView1.GetFocusedValue();
            string strDocNum = objDocNum?.ToString();

            if (!string.IsNullOrEmpty(strDocNum))
            {
                bool isOpen = InvoiceIsOpen(strDocNum);

                if (!isOpen)
                    OpenFormInvoice(strDocNum);
            }
        }

        private bool InvoiceIsOpen(string docNum)
        {
            bool isOpen = false;
            Process[]? processes = Process.GetProcessesByName("Foxoft");
            foreach (Process? process in processes)
            {
                List<WindowInfo> childWindows = WindowsAPI.GetMDIChildWindowsOfProcess(process);
                foreach (WindowInfo? window in childWindows)
                {
                    if (window.Tag == docNum)
                    {
                        isOpen = true;
                        XtraMessageBox.Show(Resources.Form_InstallmentSale_Message_InvoiceAlreadyOpen);
                    }

                    // Close the window if necessary
                    // CloseWindow(window.Handle);
                }
            }

            return isOpen;
        }

        private bool TryActivateOpenInvoiceWindow(Guid invoiceHeaderId, FormERP formERP)
        {
            if (formERP == null)
                return false;

            foreach (Form child in formERP.MdiChildren)
            {
                if (child is FormInvoice frm &&
                    frm.trInvoiceHeader is not null &&
                    frm.trInvoiceHeader.InvoiceHeaderId == invoiceHeaderId)
                {
                    if (frm.WindowState == FormWindowState.Minimized)
                        frm.WindowState = FormWindowState.Normal;

                    frm.BringToFront();
                    frm.Activate();
                    return true;
                }
            }

            return false;
        }

        private bool TryAcquireInvoiceLockForEdit(Guid invoiceHeaderId, FormERP formERP, Guid formInstanceId)
        {
            if (formERP == null)
                return false;

            var res = _lockService.TryAcquireLock(
                documentType: "Invoice",
                documentId: invoiceHeaderId,
                userId: Authorization.CurrAccCode,
                machineName: Environment.MachineName,
                appInstanceId: formERP._appInstanceId,
                formInstanceId: formInstanceId,
                clientProcessId: Process.GetCurrentProcess().Id,
                timeout: TimeSpan.FromMinutes(10),
                reason: "Edit invoice");

            if (!res.Acquired)
            {
                if (res.LockedBy == Authorization.CurrAccCode &&
                    res.AppInstanceId == formERP._appInstanceId)
                {
                    if (TryActivateOpenInvoiceWindow(invoiceHeaderId, formERP))
                        return false;
                }

                DialogResult answer = XtraMessageBox.Show(
                    $"Faktura hazırda {res.LockedByName} tərəfindən redaktə olunur.\n" +
                    $"Machine: {res.MachineName}\n" +
                    $"LockedAt: {res.LockedAtUtc:yyyy-MM-dd HH:mm:ss} (UTC)\n" +
                    $"Heartbeat: {res.LastHeartbeatAtUtc:yyyy-MM-dd HH:mm:ss} (UTC)\n\n" +
                    $"Sənəd sahibinə bağlama sorğusu göndərilsin?",
                    "Sənəd lock olunub",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (answer == DialogResult.Yes)
                {
                    _lockService.RequestOwnerToClose(
                        documentType: "Invoice",
                        documentId: invoiceHeaderId,
                        requestedByUserId: Authorization.CurrAccCode,
                        note: "Another user wants to edit this invoice.");
                }

                return false;
            }

            return true;
        }

        private void OpenFormInvoice(string strDocNum)
        {
            TrPaymentHeader trPaymentHeader = efMethods.SelectPaymentHeaderByDocNum(strDocNum);
            TrInvoiceHeader trInvoiceHeader = efMethods.SelectInvoiceHeaderByDocNum(strDocNum);

            if (trInvoiceHeader is not null)
            {
                string claim = CustomExtensions.GetClaim(trInvoiceHeader.ProcessCode);

                bool currAccHasClaims = efMethods.CurrAccHasClaims(Authorization.CurrAccCode, claim);
                if (!currAccHasClaims)
                {
                    MessageBox.Show(Resources.Common_NoPermission);
                    return;
                }

                FormERP formERP = Application.OpenForms[nameof(FormERP)] as FormERP;
                if (formERP == null)
                    return;

                Guid formInstanceId = Guid.NewGuid();
                byte[] bytes = CustomExtensions.GetProductTypeArray(trInvoiceHeader.ProcessCode);

                if (TryAcquireInvoiceLockForEdit(trInvoiceHeader.InvoiceHeaderId, formERP, formInstanceId))
                {
                    FormInvoice frm = new(trInvoiceHeader.ProcessCode, null, bytes, null, trInvoiceHeader.InvoiceHeaderId);
                    frm._formInstanceId = formInstanceId;
                    frm.MdiParent = formERP;
                    frm.WindowState = FormWindowState.Maximized;
                    frm.Show();
                    formERP.parentRibbonControl.SelectedPage = formERP.parentRibbonControl.MergedPages[0];
                }
            }
            else if (trPaymentHeader is not null)
            {
                string claim = CustomExtensions.GetClaim(trPaymentHeader.ProcessCode);

                bool currAccHasClaims = efMethods.CurrAccHasClaims(Authorization.CurrAccCode, claim);
                if (!currAccHasClaims)
                {
                    MessageBox.Show(Resources.Common_NoPermission);
                    return;
                }

                if (trPaymentHeader.ProcessCode == "PA")
                {
                    FormPaymentDetail frm = new(trPaymentHeader.PaymentHeaderId);
                    FormERP formERP = Application.OpenForms[nameof(FormERP)] as FormERP;
                    frm.MdiParent = formERP;
                    frm.WindowState = FormWindowState.Maximized;
                    frm.Show();
                    if (formERP.parentRibbonControl.MergedPages.Count > 0)
                        formERP.parentRibbonControl.SelectedPage = formERP.parentRibbonControl.MergedPages[0];
                }
                else if (trPaymentHeader.ProcessCode == "CT")
                {
                    FormMoneyTransfer frm = new(trPaymentHeader.PaymentHeaderId);
                    FormERP formERP = Application.OpenForms[nameof(FormERP)] as FormERP;
                    frm.MdiParent = formERP;
                    frm.WindowState = FormWindowState.Maximized;
                    frm.Show();
                    formERP.parentRibbonControl.SelectedPage = formERP.parentRibbonControl.MergedPages[0];
                }
            }
            else
                MessageBox.Show(Resources.Form_InstallmentSale_Message_DocumentNotFound);
        }

        private void ReloadData()
        {
            int fr = gridView1.FocusedRowHandle;

            LoadData();

            if (fr > 0)
                gridView1.FocusedRowHandle = fr;
            else
                gridView1.MoveLast();

            if (gridView1.FocusedRowHandle >= 0)
            {
                trInstallmentViewModel = gridView1.GetFocusedRow() as TrInstallmentViewModel;
            }
            else
                trInstallmentViewModel = null;
        }

        private void SetSummaryIcons()
        {
            //svgCard1.SvgImage = DevExpress.Images.ImageResourceCache.Default.GetSvgImage("svgimages/icon builder/actions_user.svg");
            //svgCard2.SvgImage = DevExpress.Images.ImageResourceCache.Default.GetSvgImage("svgimages/business objects/bo_sale.svg");
            //svgCard3.SvgImage = DevExpress.Images.ImageResourceCache.Default.GetSvgImage("svgimages/business objects/bo_validation.svg");
            //svgCard4.SvgImage = DevExpress.Images.ImageResourceCache.Default.GetSvgImage("svgimages/business objects/bo_money_report.svg");
        }

        private void LoadData()
        {
            DcReport dcReport = efMethods.SelectReportByName("Report_Embedded_InstallmentSale");

            if (dcReport is not null)
            {
                if (!string.IsNullOrEmpty(dcReport.ReportQuery))
                {
                    ReportClass reportClass = new();
                    AdoMethods adoMethods = new();

                    SqlParameter[] sqlParameters;
                    string qryMaster = reportClass.ApplyFilter(dcReport, dcReport.ReportQuery, "", out sqlParameters);

                    DataTable dt = adoMethods.SqlGetDt(qryMaster, sqlParameters);
                    bindingSourceTrInstallmentSale.DataSource = dt;
                }
            }

            UpdateSummary();

            if (gridView1.FocusedRowHandle >= 0)
                trInstallmentViewModel = gridView1.GetFocusedRow() as TrInstallmentViewModel;
            else
                trInstallmentViewModel = null;

            gridView1.BestFitColumns();
            gridView1.MakeRowVisible(gridView1.FocusedRowHandle);
        }

        private void UpdateSummary()
        {
            decimal totalAmount = 0;
            decimal totalPaid = 0;
            decimal totalRemaining = 0;
            int count = 0;

            for (int i = 0; i < gridView1.RowCount; i++)
            {
                int rowHandle = gridView1.GetVisibleRowHandle(i);
                if (rowHandle < 0) continue;

                object amountObj = gridView1.GetRowCellValue(rowHandle, "InstallmentAmount");
                object paidObj = gridView1.GetRowCellValue(rowHandle, "InstallmentPaid");
                object remainingObj = gridView1.GetRowCellValue(rowHandle, "RemainingAmount");

                if (amountObj != null && amountObj != DBNull.Value) totalAmount += Convert.ToDecimal(amountObj);
                if (paidObj != null && paidObj != DBNull.Value) totalPaid += Convert.ToDecimal(paidObj);
                if (remainingObj != null && remainingObj != DBNull.Value) totalRemaining += Convert.ToDecimal(remainingObj);

                count++;
            }

            string currencyCode = Settings.Default.AppSetting?.LocalCurrencyCode ?? "AZN";

            lblCard1Value.Text = $"{count:N0} {Resources.Common_Pieces}";
            lblCard2Value.Text = $"{totalAmount:N2} {currencyCode}";
            lblCard3Value.Text = $"{totalPaid:N2} {currencyCode}";
            lblCard4Value.Text = $"{totalRemaining:N2} {currencyCode}";
        }

        private void LocalizeColumns()
        {
            var columnCaptions = new Dictionary<string, string>
            {
                { "InstallmentId", Resources.Form_InstallmentSale_Col_InstallmentId },
                { "InvoiceHeaderId", Resources.Form_InstallmentSale_Col_InvoiceHeaderId },
                { "DocumentNumber", Resources.Form_InstallmentSale_Col_DocumentNumber },
                { "CurrAccDesc", Resources.Form_InstallmentSale_Col_CurrAccDesc },
                { "PhoneNum", Resources.Form_InstallmentSale_Col_PhoneNum },
                { "InstallmentDate", Resources.Form_InstallmentSale_Col_InstallmentDate },
                { "InstallmentAmount", Resources.Form_InstallmentSale_Col_InstallmentAmount },
                { "DurationInMonths", Resources.Form_InstallmentSale_Col_DurationInMonths },
                { "InstallmentPaid", Resources.Form_InstallmentSale_Col_InstallmentPaid },
                { "RemainingAmount", Resources.Form_InstallmentSale_Col_RemainingAmount },
                { "InstallmentStatus", Resources.Form_InstallmentSale_Col_InstallmentStatus },
                { "MonthlyPayment", Resources.Form_InstallmentSale_Col_MonthlyPayment },
                { "PassedMonth", Resources.Form_InstallmentSale_Col_PassedMonth },
                { "PaidMonth", Resources.Form_InstallmentSale_Col_PaidMonth },
                { "DueAmount", Resources.Form_InstallmentSale_Col_DueAmount },
                { "DueDate", Resources.Form_InstallmentSale_Col_DueDate },
                { "OverDueDays", Resources.Form_InstallmentSale_Col_OverDueDays },
            };

            foreach (GridColumn col in gridView1.Columns)
            {
                if (columnCaptions.TryGetValue(col.FieldName, out string caption))
                    col.Caption = caption;
            }
        }

        public void RepoBtnEdit_Payment_ButtonPressed(object sender, ButtonPressedEventArgs e)
        {
            colInvoiceHeaderId = gridView1.Columns[nameof(TrInstallment.InvoiceHeaderId)];
            colMonthlyPayment = gridView1.Columns[nameof(TrInstallment.MonthlyPayment)];

            Guid invoiceHeaderId = (Guid)gridView1.GetFocusedRowCellValue(colInvoiceHeaderId);
            decimal monthlyPayment = (decimal)gridView1.GetFocusedRowCellValue(colMonthlyPayment);

            TrInvoiceHeader trInvoiceHeader = efMethods.SelectInvoiceHeader(invoiceHeaderId);

            MakePayment(monthlyPayment, trInvoiceHeader);
        }

        private void MakePayment(decimal pay, TrInvoiceHeader trInvoiceHeader)
        {
            using FormPayment formPayment = new(PaymentType.Cash, Math.Round(pay, 2), trInvoiceHeader, true);
            bool currAccHasClaims = efMethods.CurrAccHasClaims(Authorization.CurrAccCode, formPayment.Name);
            if (!currAccHasClaims)
            {
                MessageBox.Show(Resources.Common_NoPermission);
                return;
            }
            else
            {
                if (formPayment.ShowDialog(this) == DialogResult.OK)
                    ReloadData();
            }
        }

        private void gridView1_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            if (e.MenuType == GridMenuType.Column)
            {
                GridViewColumnMenu menu = e.Menu as GridViewColumnMenu;
                if (menu.Column != null)
                    menu.Items.Add(CreateMenuItem(Resources.Common_SaveLayout, menu.Column, null));
            }
        }

        DXMenuItem CreateMenuItem(string caption, GridColumn column, Image image)
        {
            DXMenuItem item = new(caption, new EventHandler(DXMenuItem_Click), image);
            item.Tag = new MenuColumnInfo(column);
            return item;
        }

        class MenuColumnInfo
        {
            public MenuColumnInfo(GridColumn column)
            {
                this.Column = column;
            }
            public GridColumn Column;
        }

        void DXMenuItem_Click(object sender, EventArgs e)
        {
            DXMenuItem item = sender as DXMenuItem;
            MenuColumnInfo info = item.Tag as MenuColumnInfo;
            if (info == null) return;

            SaveLayout();
        }

        public class MyGridLocalizer : GridLocalizer
        {
            public override string GetLocalizedString(GridStringId id)
            {
                if (id == GridStringId.MenuFooterMaxFormat)
                    return "{0}";
                if (id == GridStringId.MenuFooterMinFormat)
                    return "{0}";
                if (id == GridStringId.MenuFooterSumFormat)
                    return "{0}";
                if (id == GridStringId.MenuFooterCountFormat)
                    return "{0}";
                if (id == GridStringId.MenuFooterAverageFormat)
                    return "{0}";

                return base.GetLocalizedString(id);
            }
        }

        private void BBI_GridOptions_ItemClick(object sender, ItemClickEventArgs e)
        {
            FormReportGridOptions gridSetting = new(gridView1);
            gridSetting.ShowDialog();
        }

        private void BBI_Refresh_ItemClick(object sender, ItemClickEventArgs e)
        {
            ReloadData();
        }

        private void BBI_QueryEdit_ItemClick(object sender, ItemClickEventArgs e)
        {
            DcReport dcReport = null;

            dcReport = efMethods.SelectReportByName("Report_Embedded_InstallmentSale");

            if (dcReport is not null)
            {
                int id = dcReport.ReportId;
                FormReportEditor formQueryEditor = new(id);
                if (formQueryEditor.ShowDialog(this) == DialogResult.OK)
                    ReloadData();
            }
        }

        private void gridView1_RowStyle(object sender, RowStyleEventArgs e)
        {
            GridView view = sender as GridView;
            if (view == null || e.RowHandle < 0)
                return;

            object statusObj = view.GetRowCellValue(e.RowHandle, "InstallmentStatus");
            object overDueDaysObj = view.GetRowCellValue(e.RowHandle, "OverDueDays");

            int installmentStatus = 0;
            int overDueDays = 0;

            if (statusObj != null && statusObj != DBNull.Value)
                int.TryParse(statusObj.ToString(), out installmentStatus);

            if (overDueDaysObj != null && overDueDaysObj != DBNull.Value)
                int.TryParse(overDueDaysObj.ToString(), out overDueDays);

            if (installmentStatus == 1)
            {
                // Fully paid — green tint
                e.Appearance.BackColor = Color.FromArgb(232, 245, 233);
                e.Appearance.ForeColor = Color.FromArgb(27, 94, 32);
                e.Appearance.Font = new Font(e.Appearance.Font, FontStyle.Regular);
            }
            else if (overDueDays > 0)
            {
                // Overdue — red tint with bold
                e.Appearance.BackColor = Color.FromArgb(255, 235, 238);
                e.Appearance.ForeColor = Color.FromArgb(183, 28, 28);
                e.Appearance.Font = new Font(e.Appearance.Font, FontStyle.Bold);
            }
        }

        private void BBI_Filter_CheckedChanged(object sender, ItemClickEventArgs e)
        {
            CriteriaOperator dateCriteria = null;
            if (BCI_FilterDay.Checked)
                dateCriteria = new BinaryOperator("InstallmentDate", DateTime.Today, BinaryOperatorType.GreaterOrEqual);
            else if (BBI_FilterWeek.Checked)
                dateCriteria = new BinaryOperator("InstallmentDate", DateTime.Today.AddDays(-7), BinaryOperatorType.GreaterOrEqual);
            else if (BBI_FilterMonth.Checked)
                dateCriteria = new BinaryOperator("InstallmentDate", DateTime.Today.AddMonths(-1), BinaryOperatorType.GreaterOrEqual);

            CriteriaOperator statusCriteria = null;
            if (BCI_FilterContinuing.Checked)
                statusCriteria = new BinaryOperator("InstallmentStatus", 0, BinaryOperatorType.Equal);
            else if (BCI_FilterCompleted.Checked)
                statusCriteria = new BinaryOperator("InstallmentStatus", 1, BinaryOperatorType.Equal);

            gridView1.ActiveFilterCriteria = GroupOperator.Combine(GroupOperatorType.And, dateCriteria, statusCriteria);
            UpdateSummary();
        }

        private void gridView1_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == "InstallmentStatus")
            {
                if (e.Value != null && e.Value != DBNull.Value)
                {
                    int status = Convert.ToInt32(e.Value);
                    if (status == 0)
                        e.DisplayText = Resources.Common_Status_Continuing;
                    else if (status == 1)
                        e.DisplayText = Resources.Common_Status_Completed;
                }
            }
        }

        private void panelSummary_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            foreach (Control card in panelSummary.Controls)
            {
                if (card is PanelControl && card.Name.StartsWith("panelCard"))
                {
                    // Draw a very subtle shadow behind each card
                    DrawCardShadow(e.Graphics, card.Bounds, 15);
                }
            }
        }

        private void DrawCardShadow(Graphics g, Rectangle bounds, int radius)
        {
            int shadowOffset = 2; // Subtle shift
            int shadowBlur = 3;   // Subtle blur layers

            for (int i = 1; i <= shadowBlur; i++)
            {
                // Slightly offset the shadow rect
                Rectangle shadowRect = new Rectangle(bounds.X + shadowOffset, bounds.Y + shadowOffset, bounds.Width, bounds.Height);
                using (GraphicsPath path = GetRoundedPath(shadowRect, radius))
                {
                    // Very low alpha for "very little shade"
                    int alpha = 10 / i;
                    using (SolidBrush brush = new SolidBrush(Color.FromArgb(alpha, Color.Black)))
                    {
                        g.FillPath(brush, path);
                    }
                }
            }
        }

        private void panelCard_Paint(object sender, PaintEventArgs e)
        {
            PanelControl panel = sender as PanelControl;
            if (panel == null) return;

            int radius = 10;
            using (GraphicsPath path = GetRoundedPath(panel.ClientRectangle, radius))
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

                // Create a region for clipping child controls
                panel.Region = new Region(path);

                // Draw a subtle border for a premium look
                using (Pen pen = new Pen(Color.FromArgb(230, 230, 230), 1))
                {
                    e.Graphics.DrawPath(pen, path);
                }
            }
        }

        private void svgCard_Paint(object sender, PaintEventArgs e)
        {
            Control control = sender as Control;
            if (control == null) return;

            using (GraphicsPath path = new GraphicsPath())
            {
                // Make the icon background circular
                path.AddEllipse(control.ClientRectangle);
                control.Region = new Region(path);
            }
        }

        private GraphicsPath GetRoundedPath(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            float r2 = radius * 2f;
            // Subtract 1 to avoid clipping at the edges
            RectangleF rectF = new RectangleF(rect.X, rect.Y, rect.Width - 1, rect.Height - 1);

            path.AddArc(rectF.X, rectF.Y, r2, r2, 180, 90);
            path.AddArc(rectF.Right - r2, rectF.Y, r2, r2, 270, 90);
            path.AddArc(rectF.Right - r2, rectF.Bottom - r2, r2, r2, 0, 90);
            path.AddArc(rectF.X, rectF.Bottom - r2, r2, r2, 90, 90);
            path.CloseFigure();
            return path;
        }
    }
}
