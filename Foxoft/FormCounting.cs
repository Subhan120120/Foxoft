using DevExpress.XtraWizard;
using Foxoft.Migrations;
using Foxoft.Models;
using Foxoft.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Foxoft
{
    public partial class FormCounting : Form
    {
        List<CountingVM> countingVM;
        EfMethods efMethods = new EfMethods();
        Guid relatedInvoiceId;
        public FormCounting(List<TrInvoiceLine> invoiceLines, Guid relatedInvoiceId)
        {
            InitializeComponent();

            this.relatedInvoiceId = relatedInvoiceId;
            this.countingVM = AutoMapper<TrInvoiceLine, CountingVM>.MapList(invoiceLines);
            LUE_StoreCode.Properties.DataSource = efMethods.SelectStores();
        }

        private void WizardControl1_NextClick(object sender, WizardCommandButtonClickEventArgs e)
        {
            if (e.Page == welcomeWizardPage1)
            {
                countingVM.ForEach(x =>
                {
                    x.Balance = CalcProductBalance(x.SerialNumberCode, x.ProductCode, LUE_WarehouseCode.EditValue?.ToString(), 0);
                    x.Difference = x.Qty - CalcProductBalance(x.SerialNumberCode, x.ProductCode, LUE_WarehouseCode.EditValue?.ToString(), 0);
                });

                gridControl1.DataSource = countingVM;
                gridControl1.RefreshDataSource();
            }

            if (e.Page == wizardPage2)
            {

            }
        }

        private void WizardControl1_FinishClick(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (countingVM.Where(x => x.Difference > 0).Any())
            {
                Guid invoiceHeaderId = Guid.NewGuid();

                TrInvoiceHeader invoiceHeader = new();
                invoiceHeader.InvoiceHeaderId = invoiceHeaderId;
                invoiceHeader.RelatedInvoiceId = relatedInvoiceId;
                string NewDocNum = efMethods.GetNextDocNum(true, "CI", nameof(TrInvoiceHeader.DocumentNumber), nameof(subContext.TrInvoiceHeaders), 6);
                invoiceHeader.DocumentNumber = NewDocNum;
                invoiceHeader.DocumentDate = DateTime.Now;
                invoiceHeader.DocumentTime = TimeSpan.Parse(DateTime.Now.ToString("HH:mm:ss"));
                invoiceHeader.ProcessCode = "CI";
                invoiceHeader.OfficeCode = Authorization.OfficeCode;
                invoiceHeader.StoreCode = Authorization.StoreCode;
                invoiceHeader.CreatedUserName = Authorization.CurrAccCode;
                invoiceHeader.IsMainTF = true;
                invoiceHeader.WarehouseCode = LUE_WarehouseCode.EditValue.ToString();

                efMethods.InsertEntity<TrInvoiceHeader>(invoiceHeader);

                countingVM.Where(x => x.Difference > 0).ToList().ForEach(x =>
                {
                    TrInvoiceLine invoiceLine = new();
                    invoiceLine.InvoiceHeaderId = invoiceHeaderId;
                    invoiceLine.InvoiceLineId = Guid.NewGuid();
                    invoiceLine.CreatedDate = DateTime.Now;
                    invoiceLine.CreatedUserName = Authorization.CurrAccCode;
                    invoiceLine.QtyIn = x.Difference;
                    invoiceLine.VatRate = x.VatRate;
                    invoiceLine.ExchangeRate = x.ExchangeRate;
                    invoiceLine.Amount = x.Amount;
                    invoiceLine.AmountLoc = x.AmountLoc;
                    invoiceLine.CurrencyCode = x.CurrencyCode;
                    invoiceLine.ExchangeRate = x.ExchangeRate;
                    invoiceLine.LineDescription = x.LineDescription;
                    invoiceLine.NetAmount = x.NetAmount;
                    invoiceLine.NetAmountLoc = x.NetAmountLoc;
                    invoiceLine.PosDiscount = x.PosDiscount;
                    invoiceLine.Price = x.Price;
                    invoiceLine.PriceLoc = x.PriceLoc;
                    invoiceLine.ProductCode = x.ProductCode;
                    invoiceLine.SerialNumberCode = x.SerialNumberCode;
                    invoiceLine.UnitOfMeasureId = x.UnitOfMeasureId;
                    invoiceLine.VatRate = x.VatRate;

                    efMethods.InsertEntity<TrInvoiceLine>(invoiceLine);
                });
            }

            if (countingVM.Where(x => x.Difference < 0).Any())
            {
                Guid invoiceHeaderId = Guid.NewGuid();

                TrInvoiceHeader invoiceHeader = new();
                invoiceHeader.InvoiceHeaderId = invoiceHeaderId;
                invoiceHeader.RelatedInvoiceId = relatedInvoiceId;
                string NewDocNum = efMethods.GetNextDocNum(true, "CO", nameof(TrInvoiceHeader.DocumentNumber), nameof(subContext.TrInvoiceHeaders), 6);
                invoiceHeader.DocumentNumber = NewDocNum;
                invoiceHeader.DocumentDate = DateTime.Now;
                invoiceHeader.DocumentTime = TimeSpan.Parse(DateTime.Now.ToString("HH:mm:ss"));
                invoiceHeader.ProcessCode = "CO";
                invoiceHeader.OfficeCode = Authorization.OfficeCode;
                invoiceHeader.StoreCode = Authorization.StoreCode;
                invoiceHeader.CreatedUserName = Authorization.CurrAccCode;
                invoiceHeader.IsMainTF = true;
                invoiceHeader.WarehouseCode = LUE_WarehouseCode.EditValue.ToString();

                efMethods.InsertEntity<TrInvoiceHeader>(invoiceHeader);

                countingVM.Where(x => x.Difference < 0).ToList().ForEach(x =>
                {
                    TrInvoiceLine invoiceLine = new();
                    invoiceLine.InvoiceHeaderId = invoiceHeaderId;
                    invoiceLine.InvoiceLineId = Guid.NewGuid();
                    invoiceLine.CreatedDate = DateTime.Now;
                    invoiceLine.CreatedUserName = Authorization.CurrAccCode;
                    invoiceLine.QtyOut = Math.Abs(x.Difference);
                    invoiceLine.VatRate = x.VatRate;
                    invoiceLine.ExchangeRate = x.ExchangeRate;
                    invoiceLine.Amount = x.Amount;
                    invoiceLine.AmountLoc = x.AmountLoc;
                    invoiceLine.CurrencyCode = x.CurrencyCode;
                    invoiceLine.ExchangeRate = x.ExchangeRate;
                    invoiceLine.LineDescription = x.LineDescription;
                    invoiceLine.NetAmount = x.NetAmount;
                    invoiceLine.NetAmountLoc = x.NetAmountLoc;
                    invoiceLine.PosDiscount = x.PosDiscount;
                    invoiceLine.Price = x.Price;
                    invoiceLine.PriceLoc = x.PriceLoc;
                    invoiceLine.ProductCode = x.ProductCode;
                    invoiceLine.SerialNumberCode = x.SerialNumberCode;
                    invoiceLine.UnitOfMeasureId = x.UnitOfMeasureId;
                    invoiceLine.VatRate = x.VatRate;

                    efMethods.InsertEntity<TrInvoiceLine>(invoiceLine);
                });
            }
        }

        private void WizardPage2_PageInit(object sender, EventArgs e)
        {
        }

        private decimal CalcProductBalance(string serialNumberCode, string productCode, string wareHouse, decimal presentQty)
        {
            if (!String.IsNullOrEmpty(serialNumberCode))
                return efMethods.SelectProductBalanceSerialNumber(productCode, wareHouse, serialNumberCode);
            else
                return efMethods.SelectProductBalance(productCode, wareHouse);
        }

        private void LUE_StoreCode_EditValueChanged(object sender, EventArgs e)
        {
            string storeCode = LUE_StoreCode.EditValue.ToString();
            List<DcWarehouse> dcWarehouses = efMethods.SelectWarehousesByStoreIncludeDisabled(storeCode);
            LUE_WarehouseCode.Properties.DataSource = dcWarehouses;
        }
    }
}
