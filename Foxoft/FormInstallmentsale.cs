﻿using DevExpress.Data;
using DevExpress.Utils;
using DevExpress.Utils.Menu;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Menu;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraReports;
using Foxoft.AppCode;
using Foxoft.Models;
using Foxoft.Properties;
using Microsoft.Data.SqlClient;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace Foxoft
{
    public partial class FormInstallmentsale : RibbonForm
    {
        EfMethods efMethods = new();
        TrInstallmentViewModel trInstallmentViewModel;
        DcReport dcReport;

        public FormInstallmentsale()
        {
            InitializeComponent();

            ReloadData();

            gridView1.PopulateColumns();
            LoadLayout();

            HyperLinkColumns();

            gridView1.Columns.Add(col_Buttons);
            col_Buttons.VisibleIndex = gridView1.Columns.Count - 1;
            gridView1.BestFitColumns();
            ApplyConditionalFormatting();
        }

        private void LoadLayout()
        {
            dcReport = efMethods.SelectReportByName("Report_Embedded_Installmentsale");
            if (!string.IsNullOrEmpty(dcReport?.ReportLayout) && dcReport?.ReportId > 0)
            {
                byte[] byteArray = Encoding.Unicode.GetBytes(dcReport.ReportLayout);
                MemoryStream stream = new(byteArray);
                gridView1.RestoreLayoutFromStream(stream);
            }

            TrimNumbersFormat();
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
                Column = gridView1.Columns[nameof(TrInstallmentViewModel.DueAmount)]
            };

            var ruleLess = new FormatConditionRuleValue
            {
                Condition = FormatCondition.Less,
                Value1 = 0,
                Appearance = { ForeColor = Color.Red }
            };
            //ruleLess.Appearance.Options.UseForeColor = true;

            formatRuleLess.Rule = ruleLess;
            gridView1.FormatRules.Add(formatRuleLess);

            var formatRuleGreater = new GridFormatRule
            {
                Column = gridView1.Columns[nameof(TrInstallmentViewModel.DueAmount)]
            };

            var ruleGreater = new FormatConditionRuleValue
            {
                Condition = FormatCondition.Greater,
                Value1 = 0,
                Appearance = { ForeColor = Color.Green }
            };
            //ruleGreater.Appearance.Options.UseForeColor = true;

            formatRuleGreater.Rule = ruleGreater;
            gridView1.FormatRules.Add(formatRuleGreater);
        }

        private void HyperLinkColumns()
        {
            GridColumn col_DocumentNumber = gridView1.Columns["DocumentNumber"];
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

            GridColumn col_CurrAccCode = gridView1.Columns["CurrAccCode"];
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
            object objCurrAccCode = gridView1.GetFocusedRowCellValue("CurrAccCode");
            string currAccCode = objCurrAccCode?.ToString();
            if (!String.IsNullOrEmpty(currAccCode))
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

            if (!String.IsNullOrEmpty(strDocNum))
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
                        XtraMessageBox.Show("Qaimə açıqdır.");
                    }

                    // Close the window if necessary
                    // CloseWindow(window.Handle);
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
                    MessageBox.Show("Yetkiniz yoxdur! ");
                    return;
                }

                byte[] bytes = CustomExtensions.GetProductTypeArray(trInvoiceHeader.ProcessCode);

                FormInvoice frm = new(trInvoiceHeader.ProcessCode, null, bytes, null, trInvoiceHeader.InvoiceHeaderId);
                FormERP formERP = Application.OpenForms[nameof(FormERP)] as FormERP;
                frm.MdiParent = formERP;
                frm.WindowState = FormWindowState.Maximized;
                frm.Show();
                formERP.parentRibbonControl.SelectedPage = formERP.parentRibbonControl.MergedPages[0];
            }
            else if (trPaymentHeader is not null)
            {
                string claim = CustomExtensions.GetClaim(trPaymentHeader.ProcessCode);

                bool currAccHasClaims = efMethods.CurrAccHasClaims(Authorization.CurrAccCode, claim);
                if (!currAccHasClaims)
                {
                    MessageBox.Show("Yetkiniz yoxdur! ");
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
                MessageBox.Show("Belə bir sənəd yoxdur.");
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
                //object currAccCode = gridView1.GetFocusedRowCellValue(nameof(TrInstallmentViewModel.CurrAccCode));
                //if (currAccCode is not null)
                //    trInstallmentViewModel = efMethods.SelectCurrAcc(currAccCode.ToString());
            }
            else
                trInstallmentViewModel = null;
        }

        private void LoadData()
        {
            DcReport dcReport = efMethods.SelectReportByName("Report_Embedded_Installmentsale");

            if (dcReport is not null)
            {
                if (!String.IsNullOrEmpty(dcReport.ReportQuery))
                {
                    CustomMethods cM = new();
                    AdoMethods adoMethods = new();

                    SqlParameter[] sqlParameters;
                    string qryMaster = cM.ApplyFilter(dcReport, dcReport.ReportQuery, "", out sqlParameters);

                    DataTable dt = adoMethods.SqlGetDt(qryMaster, sqlParameters);
                    if (dt.Rows.Count > 0)
                        bindingSourceTrInstallmentsale.DataSource = dt;
                }
            }

            if (gridView1.FocusedRowHandle >= 0)
                trInstallmentViewModel = gridView1.GetFocusedRow() as TrInstallmentViewModel;
            else
                trInstallmentViewModel = null;

            gridView1.BestFitColumns();
            gridView1.MakeRowVisible(gridView1.FocusedRowHandle);
        }

        public void RepoBtnEdit_Payment_ButtonPressed(object sender, ButtonPressedEventArgs e)
        {
            colInvoiceHeaderId = gridView1.Columns[nameof(TrInstallment.InvoiceHeaderId)];
            colMonthlyPayment = gridView1.Columns[nameof(TrInstallment.MonthlyPayment)];

            Guid invoiceHeaderId = (Guid)gridView1.GetFocusedRowCellValue(colInvoiceHeaderId);
            Decimal monthlyPayment = (Decimal)gridView1.GetFocusedRowCellValue(colMonthlyPayment);


            TrInvoiceHeader trInvoiceHeader = efMethods.SelectInvoiceHeader(invoiceHeaderId);


            MakePayment(monthlyPayment, trInvoiceHeader);
        }

        private void MakePayment(decimal pay, TrInvoiceHeader trInvoiceHeader)
        {
            using FormPayment formPayment = new(1, Math.Round(pay, 2), trInvoiceHeader, new byte[] { 1, 2 }, true);
            bool currAccHasClaims = efMethods.CurrAccHasClaims(Authorization.CurrAccCode, formPayment.Name);
            if (!currAccHasClaims)
            {
                MessageBox.Show("Yetkiniz yoxdur! ");
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
                //menu.Items.Clear();
                if (menu.Column != null)
                    menu.Items.Add(CreateMenuItem("Save Layout", menu.Column, null));
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
    }
}