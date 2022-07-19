﻿using DevExpress.Data;
using DevExpress.Utils.Extensions;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using Foxoft.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Foxoft
{
    public partial class FormPaymentDetail : RibbonForm
    {
        private TrPaymentHeader trPaymentHeader;
        private EfMethods efMethods = new EfMethods();
        private subContext dbContext;
        private Guid paymentHeaderId;

        public FormPaymentDetail()
        {
            InitializeComponent();

            StoreCodeLookUpEdit.Properties.DataSource = efMethods.SelectStores();
            repoLUE_CurrencyCode.DataSource = efMethods.SelectCurrencies();
            repoLUE_PaymentTypeCode.DataSource = efMethods.SelectPaymentTypes();

            ClearControlsAddNew();
        }
        public FormPaymentDetail(Guid paymentHeaderId)
            : this()
        {
            trPaymentHeader = efMethods.SelectPaymentHeader(paymentHeaderId);
            LoadPayment(trPaymentHeader.PaymentHeaderId);
        }

        private void ClearControlsAddNew()
        {
            dbContext = new subContext();

            paymentHeaderId = Guid.NewGuid();

            dbContext.TrPaymentHeaders.Where(x => x.InvoiceHeaderId == paymentHeaderId)
                                      .Load();
            trPaymentHeadersBindingSource.DataSource = dbContext.TrPaymentHeaders.Local.ToBindingList();

            trPaymentHeader = trPaymentHeadersBindingSource.AddNew() as TrPaymentHeader;


            dbContext.TrPaymentLines.Where(x => x.PaymentHeaderId == trPaymentHeader.InvoiceHeaderId)
                                    .LoadAsync()
                                    .ContinueWith(loadTask => trPaymentLinesBindingSource.DataSource = dbContext.TrPaymentLines.Local.ToBindingList(), TaskScheduler.FromCurrentSynchronizationContext());

            dataLayoutControl1.isValid(out List<string> errorList);
        }

        private void trPaymentHeadersBindingSource_AddingNew(object sender, AddingNewEventArgs e)
        {
            TrPaymentHeader paymentHeader = new TrPaymentHeader();
            string NewDocNum = efMethods.GetNextDocNum("PA", "DocumentNumber", "TrPaymentHeaders", 6);
            paymentHeader.InvoiceHeaderId = Guid.NewGuid();
            paymentHeader.DocumentNumber = NewDocNum;
            paymentHeader.DocumentDate = DateTime.Now;
            paymentHeader.DocumentTime = TimeSpan.Parse(DateTime.Now.ToString("HH:mm:ss"));
            paymentHeader.OfficeCode = Authorization.OfficeCode;

            e.NewObject = paymentHeader;
        }

        private void trPaymentHeadersBindingSource_CurrentItemChanged(object sender, EventArgs e)
        {
            trPaymentHeader = trPaymentHeadersBindingSource.Current as TrPaymentHeader;

            if (trPaymentHeader != null && dbContext != null && dataLayoutControl1.isValid(out List<string> errorList))
            {
                int count = efMethods.SelectPaymentLines(trPaymentHeader.PaymentHeaderId).Count;
                if (count > 0)
                    SavePayment();
            }
        }

        private void SavePayment()
        {
            try
            {
                dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Daxil Etdiyiniz Məlumatlar Əsaslı Deyil ! \n \n {ex}");
            }
        }

        private void btnEdit_DocNum_ButtonPressed(object sender, ButtonPressedEventArgs e)
        {
            SelectDocNum();
        }

        private void CurrAccCodeButtonEdit_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            SelectCurrAcc();
        }

        private void SelectDocNum()
        {
            using (FormPaymentHeaderList form = new FormPaymentHeaderList())
            {
                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    trPaymentHeader = form.trPaymentHeader;
                    LoadPayment(trPaymentHeader.PaymentHeaderId);
                }
            }
        }

        private void LoadPayment(Guid paymentHeaderId)
        {
            dbContext = new subContext();

            dbContext.TrPaymentHeaders.Include(x => x.DcCurrAcc)
                                      .Where(x => x.PaymentHeaderId == paymentHeaderId).Load();

            LocalView<TrPaymentHeader> lV_paymentHeader = dbContext.TrPaymentHeaders.Local;

            trPaymentHeadersBindingSource.DataSource = lV_paymentHeader.ToBindingList();

            dbContext.TrPaymentLines.Where(x => x.PaymentHeaderId == paymentHeaderId)
                                    .OrderBy(x => x.CreatedDate)
                                    .LoadAsync()
                                    .ContinueWith(loadTask =>
                                    {
                                        LocalView<TrPaymentLine> lV_paymentLine = dbContext.TrPaymentLines.Local;
                                        trPaymentLinesBindingSource.DataSource = lV_paymentLine.ToBindingList();

                                    }, TaskScheduler.FromCurrentSynchronizationContext());

            //dataLayoutControl1.isValid(out List<string> errorList);
        }

        private void bBI_DeletePayment_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (efMethods.PaymentHeaderExist(trPaymentHeader.PaymentHeaderId))
            {
                if (MessageBox.Show("Silmek Isteyirsiz?", "Diqqet", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    efMethods.DeletePayment(trPaymentHeader.PaymentHeaderId);

                    ClearControlsAddNew();
                }
            }
            else
                XtraMessageBox.Show("Silinmeli olan faktura yoxdur");
        }

        private void SelectCurrAcc()
        {
            using (FormCurrAccList form = new FormCurrAccList(0))
            {
                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    CurrAccCodeButtonEdit.EditValue = form.dcCurrAcc.CurrAccCode;
                    trPaymentHeader.CurrAccCode = form.dcCurrAcc.CurrAccCode;

                }
            }
        }

        private void gV_PaymentLine_InitNewRow(object sender, InitNewRowEventArgs e)
        {
            gV_PaymentLine.SetRowCellValue(e.RowHandle, colPaymentHeaderId, trPaymentHeader.PaymentHeaderId);
            gV_PaymentLine.SetRowCellValue(e.RowHandle, colPaymentLineId, Guid.NewGuid());
            gV_PaymentLine.SetRowCellValue(e.RowHandle, colPaymentTypeCode, 1);
            gV_PaymentLine.SetRowCellValue(e.RowHandle, colCashRegisterCode, "kassa01");
            gV_PaymentLine.SetRowCellValue(e.RowHandle, colCurrencyCode, "USD");
            gV_PaymentLine.SetRowCellValue(e.RowHandle, colExchangeRate, 1.703f);
            gV_PaymentLine.SetRowCellValue(e.RowHandle, colCreatedDate, DateTime.Now);
        }

        private void gC_PaymentLine_KeyDown(object sender, KeyEventArgs e)
        {
            GridControl gC = sender as GridControl;
            GridView gV = gC.MainView as GridView;

            if (e.KeyCode == Keys.Delete)
            {
                if (MessageBox.Show("Sətir Silinsin?", "Təsdiqlə", MessageBoxButtons.YesNo) != DialogResult.Yes)
                    return;

                gV.DeleteSelectedRows();
            }
        }

        private void gV_PaymentLine_CellValueChanging(object sender, CellValueChangedEventArgs e)
        {
            CalcRowLocNetAmount(e);
        }

        private void CalcRowLocNetAmount(CellValueChangedEventArgs e)
        {
            object objExRate = gV_PaymentLine.GetFocusedRowCellValue(colExchangeRate);
            object objPayment = gV_PaymentLine.GetRowCellValue(e.RowHandle, colPayment);
            object objPaymentLoc = gV_PaymentLine.GetFocusedRowCellValue(colPaymentLoc);

            decimal exRate = objExRate.IsNumeric() ? Convert.ToDecimal(objExRate, CultureInfo.InvariantCulture) : 1;
            decimal Payment = objPayment.IsNumeric() ? Convert.ToDecimal(objPayment, CultureInfo.InvariantCulture) : 0;
            decimal PaymentLoc = objPaymentLoc.IsNumeric() ? Convert.ToDecimal(objPaymentLoc, CultureInfo.InvariantCulture) : 0;

            if (e.Value != null && e.Column == colPayment)
            {
                objPayment = e.Value;
                Payment = objPayment.IsNumeric() ? Convert.ToDecimal(objPayment, CultureInfo.InvariantCulture) : 0;
                gV_PaymentLine.SetRowCellValue(e.RowHandle, colPaymentLoc, Math.Round(Payment * exRate, 2));
            }
            else if (e.Value != null && e.Column == colExchangeRate)
            {
                objExRate = e.Value;
                exRate = objExRate.IsNumeric() ? Convert.ToDecimal(objExRate, CultureInfo.InvariantCulture) : 1;
                gV_PaymentLine.SetRowCellValue(e.RowHandle, colPaymentLoc, Math.Round(Payment * exRate, 2));
            }
        }

        private void gV_PaymentLine_RowUpdated(object sender, RowObjectEventArgs e)
        {
            SavePayment();
        }

        private void gV_PaymentLine_RowDeleted(object sender, RowDeletedEventArgs e)
        {
            SavePayment();
        }

        private void repoLUE_CurrencyCode_EditValueChanged(object sender, EventArgs e)
        {
            LookUpEdit textEditor = (LookUpEdit)sender;
            float exRate = efMethods.SelectExRate(textEditor.EditValue.ToString());
            gV_PaymentLine.SetFocusedRowCellValue(colExchangeRate, exRate);

            CalcRowLocNetAmount(new CellValueChangedEventArgs(gV_PaymentLine.FocusedRowHandle, colExchangeRate, exRate));
        }

        private void bBI_SaveAndClose_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (trPaymentHeader != null && dbContext != null && dataLayoutControl1.isValid(out List<string> errorList))
            {
                int count = efMethods.SelectPaymentLines(trPaymentHeader.PaymentHeaderId).Count;
                if (count > 0)
                    SavePayment();
            }
        }
    }
}