using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Views.Grid;
using Foxoft.Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Foxoft
{
    public partial class FormWaybill : RibbonForm
    {
        public Guid deliveryInvoiceHeaderId;
        public TrInvoiceHeader trInvoiceHeader;
        public TrInvoiceHeader deliveryInvoHeader;
        public Guid invoiceLineID;
        public string processCode;

        EfMethods efMethods = new();

        public FormWaybill()
        {
            InitializeComponent();
        }

        public FormWaybill(string processCode)
           : this()
        {
            this.processCode = processCode;
        }

        private void FormDelivery_Load(object sender, EventArgs e)
        {
            //ParentForm.FormClosing += new FormClosingEventHandler(ParentForm_FormClosing); // set Parent Form Closing event
        }

        void ParentForm_FormClosing(object sender, FormClosingEventArgs e) // Parent Form Closing event
        {
            if (efMethods.InvoiceHeaderExist(deliveryInvoiceHeaderId))
                efMethods.DeleteInvoice(deliveryInvoiceHeaderId);
        }

        private void btnEdit_InvoiceHeader_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            SelectDocNum();
        }

        private void SelectDocNum()
        {
            using (FormInvoiceLineUndeliveredList form = new(new string[] { "WS", "RS", "IS" }))
            {
                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    ClearControls();

                    if (efMethods.InvoiceHeaderExist(deliveryInvoiceHeaderId))
                        efMethods.DeleteInvoice(deliveryInvoiceHeaderId);                // delete previous invoice

                    deliveryInvoiceHeaderId = Guid.NewGuid();                   // create next invoice

                    Guid invoiceHeaderId = form.trInvoiceLine.InvoiceHeaderId;

                    trInvoiceHeader = efMethods.SelectInvoiceHeader(invoiceHeaderId);

                    btnEdit_InvoiceHeader.EditValue = trInvoiceHeader.DocumentNumber;

                    LoadInvoice(trInvoiceHeader);
                }
            }
        }

        private void LoadInvoice(TrInvoiceHeader invoiceHeader)
        {
            gC_InvoiceLine.DataSource = efMethods.SelectInvoiceLinesForDelivery(invoiceHeader.InvoiceHeaderId);

            if (invoiceHeader.DcCurrAcc is not null)
                txt_CurrAccDesc.Text = invoiceHeader.DcCurrAcc.CurrAccDesc;

            Tag = invoiceHeader.DocumentNumber;
        }

        private void repobtn_DeliveryLine_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            Guid invoiceLineID = (Guid)gV_InvoiceLine.GetFocusedRowCellValue(col_InvoiceLineId);
            decimal maxDelivery = (decimal)(gV_InvoiceLine.GetFocusedRowCellValue(col_RemainingQty));

            if (maxDelivery > 0)
            {
                using (FormQty formQty = new(maxDelivery))
                {
                    if (formQty.ShowDialog(this) == DialogResult.OK)
                    {
                        if (!efMethods.InvoiceHeaderExist(deliveryInvoiceHeaderId)) //if invoiceHeader doesnt exist
                        {
                            string NewDocNum = efMethods.GetNextDocNum(true, processCode, "DocumentNumber", "TrInvoiceHeaders", 6);

                            deliveryInvoHeader = new();
                            deliveryInvoHeader.InvoiceHeaderId = deliveryInvoiceHeaderId;
                            deliveryInvoHeader.RelatedInvoiceId = trInvoiceHeader.InvoiceHeaderId;
                            deliveryInvoHeader.DocumentNumber = NewDocNum;
                            deliveryInvoHeader.ProcessCode = "WO";
                            deliveryInvoHeader.CurrAccCode = trInvoiceHeader.CurrAccCode;
                            deliveryInvoHeader.OfficeCode = Authorization.OfficeCode;
                            deliveryInvoHeader.StoreCode = Authorization.StoreCode;
                            deliveryInvoHeader.CreatedUserName = Authorization.CurrAccCode;
                            deliveryInvoHeader.WarehouseCode = efMethods.SelectWarehouseByStore(Authorization.StoreCode);
                            deliveryInvoHeader.IsMainTF = true;

                            efMethods.InsertInvoiceHeader(deliveryInvoHeader);
                        }

                        if (!efMethods.WaybillExistByInvoiceLine(invoiceLineID))
                        {
                            TrInvoiceLine invoiceLine = efMethods.SelectInvoiceLine(invoiceLineID);

                            TrInvoiceLine deliveryInvoiceLine = new();

                            deliveryInvoiceLine.InvoiceLineId = Guid.NewGuid();
                            deliveryInvoiceLine.InvoiceHeaderId = deliveryInvoiceHeaderId;
                            deliveryInvoiceLine.RelatedLineId = invoiceLineID;
                            deliveryInvoiceLine.ProductCode = invoiceLine.ProductCode;
                            deliveryInvoiceLine.CreatedUserName = Authorization.CurrAccCode;

                            if ((bool)CustomExtensions.DirectionIsIn(processCode))
                                deliveryInvoiceLine.QtyIn = formQty.qty * (-1);
                            else if (!(bool)CustomExtensions.DirectionIsIn(processCode))
                                deliveryInvoiceLine.QtyOut = formQty.qty * (-1);

                            efMethods.InsertInvoiceLine(deliveryInvoiceLine);

                            List<TrInvoiceLine> deliveryLines = efMethods.SelectInvoiceLines(deliveryInvoiceHeaderId);
                            gC_DeliveryInvoiceLine.DataSource = deliveryLines;
                        }
                        else
                            efMethods.UpdateInvoiceLineQtyOut(deliveryInvoiceHeaderId, invoiceLineID, formQty.qty * (-1));

                        gC_InvoiceLine.DataSource = efMethods.SelectInvoiceLinesForDelivery(trInvoiceHeader.InvoiceHeaderId);
                    }
                }
            }
            else
                XtraMessageBox.Show("Təhvil edilə biləcək miqdar yoxdur");
        }

        private void btn_Ok_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK == XtraMessageBox.Show("Qaiməni açmaq istəyirsiz?", "Qaiməni Aç", MessageBoxButtons.OKCancel))
            {
                OpenFormInvoice(deliveryInvoHeader.DocumentNumber);
            }

            ClearControls();
        }

        private void ClearControls()
        {
            deliveryInvoiceHeaderId = Guid.NewGuid();
            trInvoiceHeader = null;
            gC_InvoiceLine.DataSource = null;
            gC_DeliveryInvoiceLine.DataSource = null;
            btnEdit_InvoiceHeader.EditValue = null;
            txt_CurrAccDesc.Text = null;
        }

        private void OpenFormInvoice(string strDocNum)
        {
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
            else
                MessageBox.Show("Belə bir sənəd yoxdur.");
        }

        private void gV_DeliveryInvoiceLine_CalcPreviewText(object sender, CalcPreviewTextEventArgs e)
        {
            GridView view = sender as GridView;
            if (view == null) return;

            string SalesPersonCode = view.GetRowCellDisplayText(e.RowHandle, view.Columns["SalesPersonCode"]);

            e.PreviewText = CustomExtensions.GetPreviewText(0, 0, 0, 0, String.Empty, SalesPersonCode);
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Təhvil Ləğv Edilsin?", "Təsdiqlə", MessageBoxButtons.YesNo) == DialogResult.Yes)
                if (efMethods.InvoiceHeaderExist(deliveryInvoiceHeaderId))
                {
                    efMethods.DeleteInvoice(deliveryInvoiceHeaderId);

                    ClearControls();
                }

        }
    }
}
