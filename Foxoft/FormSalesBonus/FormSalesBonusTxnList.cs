using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using Foxoft.AppCode;
using Foxoft.AppCode.Service;
using Foxoft.Models;
using Foxoft.Properties;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using static Foxoft.AppCode.Service.SalesBonusCalculator;

namespace Foxoft
{
    public partial class FormSalesBonusTxnList : RibbonForm
    {
        private readonly EfMethods efMethods = new();
        private readonly DocumentLockService _lockService = new(new subContext());
        private bool canCalculate;
        private GridColumn prevColumn = null;
        private int prevRow = -1;

        public FormSalesBonusTxnList()
        {
            InitializeComponent();

            canCalculate = efMethods.CurrAccHasClaims(Authorization.CurrAccCode, "SalesBonusCalculate");
            btnCalculate.Enabled = canCalculate;
            btnAdjustment.Enabled = canCalculate;

            DateTime today = DateTime.Today;
            dtFrom.DateTime = new DateTime(today.Year, today.Month, 1);
            dtTo.DateTime = dtFrom.DateTime.AddMonths(1).AddDays(-1);

            btnSalesPerson.ButtonClick += BtnSalesPerson_ButtonClick;
            lkpPlan.ButtonClick += (s, e) =>
            {
                if (e.Button.Kind == ButtonPredefines.Delete)
                    lkpPlan.EditValue = null;
            };

            btnRefresh.ItemClick += (_, __) => LoadData();
            btnCalculate.ItemClick += (_, __) => OpenCalculate();
            btnAdjustment.ItemClick += (_, __) => OpenAdjustment();
            btnDetails.ItemClick += (_, __) => ShowDetails();
            btnClose.ItemClick += (_, __) => Close();

            gridView1.DoubleClick += (_, __) => ShowDetails();
            gridView1.CustomDrawRowIndicator += (s, e) =>
            {
                if (e.Info.IsRowIndicator && e.RowHandle >= 0)
                    e.Info.DisplayText = (e.RowHandle + 1).ToString();
            };
            gridView1.ShowingEditor += GridView1_ShowingEditor;

            ConfigureHyperLinkColumns();

            Load += (_, __) =>
            {
                LoadPlans();
                LoadData();
            };
        }

        private void GridView1_ShowingEditor(object sender, CancelEventArgs e)
        {
            if (sender is GridView view)
            {
                if (prevColumn != view.FocusedColumn || prevRow != view.FocusedRowHandle)
                    e.Cancel = true;
                prevColumn = view.FocusedColumn;
                prevRow = view.FocusedRowHandle;
            }
        }

        private void ConfigureHyperLinkColumns()
        {
            GridColumn col_InvoiceNum = colInvoice ?? gridView1.Columns["InvoiceDocumentNumber"];
            if (col_InvoiceNum is not null)
            {
                RepositoryItemHyperLinkEdit HLE_InvoiceNum = new();
                HLE_InvoiceNum.SingleClick = true;
                HLE_InvoiceNum.OpenLink += RepoHLE_DocumentNumber_OpenLink;
                col_InvoiceNum.ColumnEdit = HLE_InvoiceNum;
                col_InvoiceNum.OptionsColumn.AllowEdit = true;
                col_InvoiceNum.OptionsColumn.ReadOnly = true;
            }

            GridColumn col_PaymentNum = colPayment ?? gridView1.Columns["PaymentDocumentNumber"];
            if (col_PaymentNum is not null)
            {
                RepositoryItemHyperLinkEdit HLE_PaymentNum = new();
                HLE_PaymentNum.SingleClick = true;
                HLE_PaymentNum.OpenLink += RepoHLE_DocumentNumber_OpenLink;
                col_PaymentNum.ColumnEdit = HLE_PaymentNum;
                col_PaymentNum.OptionsColumn.AllowEdit = true;
                col_PaymentNum.OptionsColumn.ReadOnly = true;
            }
        }

        private void RepoHLE_DocumentNumber_OpenLink(object sender, OpenLinkEventArgs e)
        {
            prevColumn = null;
            prevRow = -1;
            e.Handled = true;

            string? strDocNum = e.EditValue?.ToString();
            if (string.IsNullOrEmpty(strDocNum))
            {
                object? objDocNum = gridView1.GetFocusedRowCellValue("InvoiceDocumentNumber")
                                 ?? gridView1.GetFocusedValue();
                strDocNum = objDocNum?.ToString();
            }

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
                        XtraMessageBox.Show(Resources.Form_ReportGrid_Message_InvoiceIsOpen);
                    }
                }
            }

            return isOpen;
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
                    MessageBox.Show(Resources.Common_AccessDenied);
                    return;
                }

                FormERP? formERP = Application.OpenForms[nameof(FormERP)] as FormERP;
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
                    if (formERP.parentRibbonControl.MergedPages.Count > 0)
                        formERP.parentRibbonControl.SelectedPage = formERP.parentRibbonControl.MergedPages[0];
                }
            }
            else if (trPaymentHeader is not null)
            {
                bool currAccHasMakePaymentClaims = efMethods.CurrAccHasClaims(Authorization.CurrAccCode, "MakePayment");
                bool currAccHasReceivePaymentClaims = efMethods.CurrAccHasClaims(Authorization.CurrAccCode, "ReceivePayment");

                if (!(currAccHasMakePaymentClaims || currAccHasReceivePaymentClaims))
                {
                    MessageBox.Show(Resources.Common_AccessDenied);
                    return;
                }

                if (trPaymentHeader.ProcessCode == "PA")
                {
                    FormPaymentDetail frm = new(trPaymentHeader.PaymentHeaderId);
                    FormERP? formERP = Application.OpenForms[nameof(FormERP)] as FormERP;
                    frm.MdiParent = formERP;
                    frm.WindowState = FormWindowState.Maximized;
                    frm.Show();
                    if (formERP?.parentRibbonControl.MergedPages.Count > 0)
                        formERP.parentRibbonControl.SelectedPage = formERP.parentRibbonControl.MergedPages[0];
                }
                else if (trPaymentHeader.ProcessCode == "CT")
                {
                    FormMoneyTransfer frm = new(trPaymentHeader.PaymentHeaderId);
                    FormERP? formERP = Application.OpenForms[nameof(FormERP)] as FormERP;
                    frm.MdiParent = formERP;
                    frm.WindowState = FormWindowState.Maximized;
                    frm.Show();
                    if (formERP?.parentRibbonControl.MergedPages.Count > 0)
                        formERP.parentRibbonControl.SelectedPage = formERP.parentRibbonControl.MergedPages[0];
                }
            }
            else
            {
                MessageBox.Show(Resources.Common_NotFound);
            }
        }

        private bool TryActivateOpenInvoiceWindow(Guid invoiceHeaderId, FormERP formERP)
        {
            if (formERP == null)
                return false;

            foreach (Form child in formERP.MdiChildren)
            {
                if (child is FormInvoice frm &&
                    frm.trInvoiceHeader?.InvoiceHeaderId == invoiceHeaderId)
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

                bool canTakeover = efMethods.CurrAccHasClaims(Authorization.CurrAccCode, "DocumentLockTakeover");

                if (canTakeover)
                {
                    var answer = XtraMessageBox.Show(
                        string.Format(Resources.Form_Invoice_LockTakeoverQuestion, res.LockedByName),
                        Resources.Form_Invoice_LockTakeoverCaption,
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                    if (answer == DialogResult.Yes)
                    {
                        var takeoverRes = _lockService.ForceTakeoverLock(
                            documentType: "Invoice",
                            documentId: invoiceHeaderId,
                            newUserId: Authorization.CurrAccCode,
                            machineName: Environment.MachineName,
                            appInstanceId: formERP._appInstanceId,
                            formInstanceId: formInstanceId,
                            clientProcessId: Process.GetCurrentProcess().Id,
                            reason: "Force takeover by authorized user");

                        if (takeoverRes.Acquired)
                            return true;
                    }

                    return false;
                }

                var closeAnswer = XtraMessageBox.Show(
                    string.Format(
                        Resources.Form_Invoice_LockedQuestion,
                        res.LockedByName,
                        res.MachineName,
                        res.LockedAtUtc?.ToString("yyyy-MM-dd HH:mm:ss"),
                        res.LastHeartbeatAtUtc?.ToString("yyyy-MM-dd HH:mm:ss")),
                    Resources.Form_Invoice_LockedCaption,
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (closeAnswer == DialogResult.Yes)
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

        private void BtnSalesPerson_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == ButtonPredefines.Delete)
            {
                btnSalesPerson.EditValue = null;
                return;
            }

            FormCurrAccList form = new(new byte[] { (byte)CurrAccType.Personnel }, false, btnSalesPerson.EditValue?.ToString());
            if (form.ShowDialog(this) == DialogResult.OK && form.dcCurrAcc != null)
                btnSalesPerson.EditValue = form.dcCurrAcc.CurrAccCode;
        }

        private void LoadPlans()
        {
            using var db = new subContext();
            lkpPlan.Properties.DataSource = db.DcSalesBonusPlans.AsNoTracking()
                .OrderBy(x => x.PlanName)
                .Select(x => new { x.SalesBonusPlanId, x.PlanName })
                .ToList();
        }

        private void LoadData()
        {
            using var db = new subContext();

            DateTime from = dtFrom.EditValue == null ? DateTime.MinValue : dtFrom.DateTime.Date;
            DateTime to = dtTo.EditValue == null ? DateTime.MaxValue.Date : dtTo.DateTime.Date;
            string? salesPersonCode = btnSalesPerson.EditValue?.ToString();
            Guid? planId = lkpPlan.EditValue is Guid g ? g : null;
            bool onlyPending = chkOnlyPending.Checked;

            IQueryable<TrSalesBonusTxn> q = db.TrSalesBonusTxns.AsNoTracking()
                .Include(x => x.DcSalesBonusPlan)
                .Include(x => x.DcCurrAcc)
                .Where(x => x.DocumentDate >= from && x.DocumentDate <= to);

            if (!string.IsNullOrWhiteSpace(salesPersonCode))
                q = q.Where(x => x.SalesPersonCode == salesPersonCode);
            if (planId.HasValue)
                q = q.Where(x => x.SalesBonusPlanId == planId.Value);
            if (onlyPending)
                q = q.Where(x => x.PayrollHeaderId == null);

            var list = q.OrderByDescending(x => x.DocumentDate)
                .ThenByDescending(x => x.CreatedDate)
                .ToList()
                .Select(x => new
                {
                    Id = x.SalesBonusTxnId,
                    x.DocumentDate,
                    TxnTypeText = SalesBonusTexts.Text(x.TxnType),
                    x.SalesPersonCode,
                    SalesPersonName = EmployeeName(x.DcCurrAcc),
                    PlanName = x.DcSalesBonusPlan?.PlanName,
                    PeriodText = PeriodText(x.PeriodYear, x.PeriodNo, x.DcSalesBonusPlan?.PeriodType ?? BonusPeriodType.Monthly),
                    x.BaseAmount,
                    x.Rate,
                    x.Amount,
                    x.InvoiceDocumentNumber,
                    x.PaymentDocumentNumber,
                    PayrollStatusText = x.PayrollHeaderId.HasValue
                        ? Properties.Resources.Entity_SalesBonusTxn_PayrollIncluded
                        : Properties.Resources.Entity_SalesBonusTxn_PayrollPending,
                    x.Note,
                    x.CreatedUserName,
                    x.CreatedDate,
                    x.CalcDetails
                })
                .ToList();

            gridControl1.DataSource = list;
            gridView1.BestFitColumns();
        }

        private static string EmployeeName(DcCurrAcc? emp)
        {
            if (emp == null) return string.Empty;
            string name = $"{emp.FirstName} {emp.LastName}".Trim();
            return string.IsNullOrWhiteSpace(name) ? (emp.CurrAccDesc ?? string.Empty) : name;
        }

        private void OpenCalculate()
        {
            if (!canCalculate)
            {
                XtraMessageBox.Show(this, Properties.Resources.Common_NoPermission, Properties.Resources.Common_Attention, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using var f = new FormSalesBonusCalc();
            f.ShowDialog(this);
            LoadData();
        }

        private void OpenAdjustment()
        {
            if (!canCalculate)
            {
                XtraMessageBox.Show(this, Properties.Resources.Common_NoPermission, Properties.Resources.Common_Attention, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using var f = new FormSalesBonusAdjustmentEdit(btnSalesPerson.EditValue?.ToString());
            if (f.ShowDialog(this) == DialogResult.OK)
                LoadData();
        }

        private void ShowDetails()
        {
            var row = gridView1.GetFocusedRow();
            if (row == null) return;

            string? details = row.GetType().GetProperty("CalcDetails")?.GetValue(row)?.ToString();
            string? note = row.GetType().GetProperty("Note")?.GetValue(row)?.ToString();

            using var f = new FormSalesBonusTxnDetails(note, details);
            f.ShowDialog(this);
        }
    }
}
