using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraLayout.Utils;
using DevExpress.XtraReports;
using DevExpress.XtraSpreadsheet.Model;
using Foxoft.Models;
using Foxoft.Properties;
using Microsoft.IdentityModel.Tokens;
using System.ComponentModel;
using System.Linq;
using System.Windows;

namespace Foxoft
{
    public partial class FormPayment : XtraForm
    {
        private Guid PaymentHeaderId;
        private TrPaymentHeader trPaymentHeader = new();
        private TrInvoiceHeader trInvoiceHeader { get; set; }
        private TrPaymentLine trPaymentLineCash = new();
        private TrPaymentLine trPaymentLineCashless = new();
        private TrPaymentLine trPaymentLineCommission = new();
        private DcPaymentMethod dcPaymentMethod = new();
        //private TrInstallment trInstallment = new();
        private EfMethods efMethods = new();

        private bool isNegativ = false;

        public FormPayment()
        {
            InitializeComponent();

            Name = "PaymentDetail";

            AcceptButton = btn_Ok;
            CancelButton = btn_Cancel;

            LUE_PaymentPlan.Properties.ValueMember = nameof(DcPaymentPlan.PaymentPlanCode);
            LUE_PaymentPlan.Properties.DisplayMember = nameof(DcPaymentPlan.PaymentPlanDesc);
            LUE_PaymentPlan.Properties.Columns.AddRange(new LookUpColumnInfo[]
            {
                new LookUpColumnInfo(nameof(DcPaymentPlan.PaymentPlanCode), ReflectionExt.GetDisplayName<DcPaymentPlan>(x => x.PaymentPlanCode)),
                new LookUpColumnInfo(nameof(DcPaymentPlan.PaymentPlanDesc), ReflectionExt.GetDisplayName<DcPaymentPlan>(x => x.PaymentPlanDesc)),
                new LookUpColumnInfo(nameof(DcPaymentPlan.DurationInMonths), ReflectionExt.GetDisplayName<DcPaymentPlan>(x => x.DurationInMonths)),
                new LookUpColumnInfo(nameof(DcPaymentPlan.CommissionRate), ReflectionExt.GetDisplayName<DcPaymentPlan>(x => x.CommissionRate)),
            });

            //LUE_InstallmentPlan.Properties.DataSource = efMethods.SelectPaymentPlans(2);
            //LUE_InstallmentPlan.Properties.ValueMember = nameof(DcPaymentPlan.PaymentPlanCode);
            //LUE_InstallmentPlan.Properties.DisplayMember = nameof(DcPaymentPlan.PaymentPlanDesc);
            //LUE_InstallmentPlan.Properties.Columns.AddRange(new LookUpColumnInfo[]
            //{
            //    new LookUpColumnInfo(nameof(DcPaymentPlan.PaymentPlanCode), ReflectionExt.GetDisplayName<DcPaymentPlan>(x => x.PaymentPlanCode)),
            //    new LookUpColumnInfo(nameof(DcPaymentPlan.PaymentPlanDesc), ReflectionExt.GetDisplayName<DcPaymentPlan>(x => x.PaymentPlanDesc)),
            //    new LookUpColumnInfo(nameof(DcPaymentPlan.DurationInMonths), ReflectionExt.GetDisplayName<DcPaymentPlan>(x => x.DurationInMonths)),
            //    new LookUpColumnInfo(nameof(DcPaymentPlan.CommissionRate), ReflectionExt.GetDisplayName<DcPaymentPlan>(x => x.CommissionRate)),
            //});

            List<DcCurrency> currencies = efMethods.SelectEntities<DcCurrency>();
            //LUE_InstallmentCurrency.Properties.DataSource = currencies;
            lUE_cashCurrency.Properties.DataSource = currencies;
            lUE_CashlessCurrency.Properties.DataSource = currencies;
            lUE_PaymentMethod.Properties.DataSource = efMethods.SelectPaymentMethodsByPaymentTypes(new byte[] { 2 });
        }

        public FormPayment(byte paymentType, decimal pay, TrInvoiceHeader trInvoiceHeader)
           : this()
        {
            this.trInvoiceHeader = trInvoiceHeader;

            PaymentDefaults(paymentType, trInvoiceHeader);

            lUE_PaymentMethod.EditValue = efMethods.SelectPaymentMethodsByPaymentTypes(new byte[] { 2 }).FirstOrDefault(x => x.IsDefault == true)?.PaymentMethodId;

            if ((bool)CustomExtensions.DirectionIsIn(trInvoiceHeader.ProcessCode, trInvoiceHeader.IsReturn))
                isNegativ = true;

            switch (paymentType)
            {
                case 1:
                    trPaymentLineCash.Payment = Math.Abs(pay);
                    break;
                case 2:
                    trPaymentLineCashless.Payment = Math.Abs(pay);
                    break;
                default:
                    break;
            }
        }

        public FormPayment(byte paymentType, decimal pay, TrInvoiceHeader trInvoiceHeader, bool autoMakePayment)
           : this(paymentType, pay, trInvoiceHeader)
        {
            if (trPaymentLineCash.Payment > 0)
                if (autoMakePayment)
                    SavePayment(autoMakePayment);
        }

        public FormPayment(byte paymentType, decimal pay, TrInvoiceHeader trInvoiceHeader, byte[] paymentTypes)
           : this(paymentType, pay, trInvoiceHeader)
        {
            lCG_Cash.Visibility = paymentTypes.Contains((byte)1) ? LayoutVisibility.Always : LayoutVisibility.Never;
            lCG_Cashless.Visibility = paymentTypes.Contains((byte)2) ? LayoutVisibility.Always : LayoutVisibility.Never;
            //LCG_Installment.Visibility = paymentTypes.Contains((byte)3) ? LayoutVisibility.Always : LayoutVisibility.Never;
            //lCG_CustomerBonus.Enabled = paymentTypes.Contains((byte)4) ? true : false;
        }

        public FormPayment(byte paymentType, decimal pay, TrInvoiceHeader trInvoiceHeader, byte[] paymentTypes, bool isInstallmentPayment)
           : this(paymentType, pay, trInvoiceHeader, new byte[] { 1, 2 })
        {
            if (isInstallmentPayment)
                trPaymentHeader.PaymentKindId = 3;
        }

        private void PaymentDefaults(byte paymentType, TrInvoiceHeader trInvoiceHeader)
        {
            PaymentHeaderId = Guid.NewGuid();

            bool invoiceExist = trInvoiceHeader.InvoiceHeaderId != Guid.Empty && trInvoiceHeader != null;

            trPaymentHeader.PaymentHeaderId = PaymentHeaderId;
            trPaymentHeader.CurrAccCode = trInvoiceHeader.CurrAccCode;
            trPaymentHeader.CreatedUserName = Authorization.CurrAccCode;
            trPaymentHeader.OfficeCode = Authorization.OfficeCode;
            trPaymentHeader.StoreCode = Authorization.StoreCode;
            trPaymentHeader.ProcessCode = "PA";
            trPaymentHeader.DocumentDate = trInvoiceHeader.DocumentDate;
            trPaymentHeader.DocumentTime = trInvoiceHeader.DocumentTime;

            if (invoiceExist)
            {
                trPaymentHeader.InvoiceHeaderId = trInvoiceHeader.InvoiceHeaderId;
                trPaymentHeader.PaymentKindId = 2;
            }
            else
                trPaymentHeader.PaymentKindId = 1;

            trPaymentHeader.OperationDate = DateTime.Now;
            trPaymentHeader.IsMainTF = true;

            trPaymentLineCash.PaymentHeaderId = PaymentHeaderId;
            trPaymentLineCash.PaymentTypeCode = 1;
            trPaymentLineCash.PaymentMethodId = 1;
            trPaymentLineCash.CurrencyCode = Settings.Default.AppSetting.LocalCurrencyCode;
            trPaymentLineCash.ExchangeRate = 1;
            trPaymentLineCash.CreatedUserName = Authorization.CurrAccCode;

            trPaymentLineCashless.PaymentHeaderId = PaymentHeaderId;
            trPaymentLineCashless.PaymentTypeCode = 2;
            trPaymentLineCashless.PaymentMethodId = 3;
            trPaymentLineCashless.CurrencyCode = Settings.Default.AppSetting.LocalCurrencyCode;
            trPaymentLineCashless.ExchangeRate = 1;
            trPaymentLineCashless.CreatedUserName = Authorization.CurrAccCode;

            trPaymentLineCommission.PaymentHeaderId = PaymentHeaderId;
            trPaymentLineCommission.PaymentLineId = Guid.NewGuid();
            trPaymentLineCommission.PaymentTypeCode = 5;
            trPaymentLineCommission.PaymentMethodId = 3;
            trPaymentLineCommission.CreatedUserName = Authorization.CurrAccCode;

            //trInstallment.CurrencyCode = Settings.Default.AppSetting.LocalCurrencyCode;
            //trInstallment.ExchangeRate = 1;

            string cashReg = efMethods.SelectDefaultCashRegister(Authorization.StoreCode);
            if (!String.IsNullOrEmpty(cashReg))
            {
                trPaymentLineCash.CashRegisterCode = cashReg;
                trPaymentLineCashless.CashRegisterCode = cashReg;
            }
        }

        private void FormPayment_Load(object sender, EventArgs e)
        {
            FillControls();
        }

        private void FillControls()
        {
            dateEdit_Date.EditValue = DateTime.Now.ToString("yyyy-MM-dd");

            txtEdit_Cash.EditValue = trPaymentLineCash.PaymentLoc;
            lUE_cashCurrency.EditValue = trPaymentLineCash.CurrencyCode;
            btnEdit_CashRegister.EditValue = trPaymentLineCash.CashRegisterCode;

            txtEdit_Cashless.EditValue = trPaymentLineCashless.PaymentLoc;
            lUE_CashlessCurrency.EditValue = trPaymentLineCashless.CurrencyCode;

            //TxtEdit_Installment.EditValue = trInstallment.Amount;
            //LUE_InstallmentCurrency.EditValue = trInstallment.CurrencyCode;
            //LUE_InstallmentPlan.EditValue = trInstallment.InstallmentPlanCode;
        }

        private void dateEdit_Date_EditValueChanged(object sender, EventArgs e)
        {
            DateTime date = Convert.ToDateTime(dateEdit_Date.EditValue);
            trPaymentHeader.OperationDate = date;
        }

        private void txtEdit_Cash_EditValueChanged(object sender, EventArgs e)
        {
            trPaymentLineCash.Payment = Convert.ToDecimal(txtEdit_Cash.EditValue);
            txtEdit_Cash.DoValidate();
        }

        private void txtEdit_Cash_Validating(object sender, CancelEventArgs e)
        {
            if (trPaymentLineCash.Payment < 0)
                e.Cancel = true;
        }

        private void textEditCash_InvalidValue(object sender, InvalidValueExceptionEventArgs e)
        {
            e.ExceptionMode = ExceptionMode.DisplayError;
            e.WindowCaption = "Diqqət";
            e.ErrorText = "Dəyər 0 dan böyük olmalıdır";
        }

        private void lUE_cashCurrency_EditValueChanged(object sender, EventArgs e)
        {
            trPaymentLineCash.CurrencyCode = lUE_cashCurrency.EditValue.ToString();
            trPaymentLineCash.ExchangeRate = (float)lUE_cashCurrency.GetColumnValue(nameof(DcCurrency.ExchangeRate));
        }

        private void lUE_PaymentMethod_EditValueChanged(object sender, EventArgs e)
        {
            dcPaymentMethod = efMethods.SelectEntityById<DcPaymentMethod>(Convert.ToInt32(lUE_PaymentMethod.EditValue));
            trPaymentLineCashless.PaymentMethodId = dcPaymentMethod.PaymentMethodId;

            btnEdit_BankAccout.EditValue = dcPaymentMethod.DefaultCashRegCode;

            bool isRedirected = dcPaymentMethod.IsRedirected;

            LayoutControlAnimator.SetVisibilityWithAnimation(lCI_BankCurrAcc, isRedirected ? LayoutVisibility.Never : LayoutVisibility.Always);

            if (isRedirected)
            {
                btnEdit_BankAccout.EditValue = null;
            }
            else
            {
                string cashReg = efMethods.SelectDefaultCashRegister(Authorization.StoreCode);
                if (!String.IsNullOrEmpty(cashReg))
                {
                    btnEdit_BankAccout.EditValue = cashReg;
                }
            }

            var paymentPlans = efMethods.SelectPaymentPlans(dcPaymentMethod.PaymentMethodId);
            bool hasPlans = paymentPlans.Count > 0;

            LUE_PaymentPlan.Properties.DataSource = paymentPlans;
            LUE_PaymentPlan.EditValue = hasPlans ? efMethods.SelectPaymentPlanDefault(dcPaymentMethod.PaymentMethodId)?.PaymentPlanCode : null;

            LayoutControlAnimator.SetVisibilityWithAnimation(LCI_PaymentPlan, hasPlans ? LayoutVisibility.Always : LayoutVisibility.Never);
            LayoutControlAnimator.SetVisibilityWithAnimation(LCI_CashlessCommission, hasPlans ? LayoutVisibility.Always : LayoutVisibility.Never);



        }

        private void btnEdit_CashRegister_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            SelectCashRegister(sender, 1);
        }

        private void SelectCashRegister(object sender, byte paymentTypeCode)
        {
            ButtonEdit buttonEdit = (ButtonEdit)sender;

            using (FormCashRegisterList form = new(trInvoiceHeader.CurrAccCode, paymentTypeCode))
            {
                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    buttonEdit.EditValue = form.dcCurrAcc.CurrAccCode;
                }
            }
        }

        private void btnEdit_CashRegister_EditValueChanged(object sender, EventArgs e)
        {
            trPaymentLineCash.CashRegisterCode = btnEdit_CashRegister.EditValue.ToString();
        }

        private void btnEdit_CashRegister_Validating(object sender, CancelEventArgs e)
        {
            object eValue = btnEdit_CashRegister.EditValue;

            if (eValue is not null)
            {
                DcCurrAcc cashReg = efMethods.SelectCurrAcc(eValue.ToString());

                if (cashReg is null)
                {
                    e.Cancel = true;
                }
                else
                {
                    trPaymentLineCash.CashRegisterCode = eValue.ToString();
                }
            }
        }

        private void btnEdit_CashRegister_InvalidValue(object sender, InvalidValueExceptionEventArgs e)
        {
            e.ErrorText = "Belə bir kassa yoxdur";
            e.ExceptionMode = ExceptionMode.DisplayError;
        }

        private void textEditCashless_EditValueChanged(object sender, EventArgs e)
        {
            trPaymentLineCashless.Payment = Convert.ToDecimal(txtEdit_Cashless.EditValue);
            txtEdit_Cashless.DoValidate();

            object row = LUE_PaymentPlan.Properties.GetDataSourceRowByKeyValue(LUE_PaymentPlan.EditValue);
            if (row is not null)
            {
                float paymentTypeCode = ((DcPaymentPlan)row).CommissionRate;
                txt_CashlessCommission.EditValue = trPaymentLineCashless.Payment * (decimal)paymentTypeCode / 100;
            }
        }

        private void textEditCashless_Validating(object sender, CancelEventArgs e)
        {
            if (trPaymentLineCashless.Payment < 0)
                e.Cancel = true;
        }

        private void textEditCashless_InvalidValue(object sender, InvalidValueExceptionEventArgs e) { }

        private void lUE_CashlessCurrency_EditValueChanged(object sender, EventArgs e)
        {
            trPaymentLineCashless.CurrencyCode = lUE_CashlessCurrency.EditValue.ToString();
            trPaymentLineCashless.ExchangeRate = (float)lUE_CashlessCurrency.GetColumnValue(nameof(DcCurrency.ExchangeRate));
        }

        private void btnEdit_BankAccout_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            object row = lUE_PaymentMethod.Properties.GetDataSourceRowByKeyValue(lUE_PaymentMethod.EditValue);
            if (row is not null)
            {
                byte paymentTypeCode = ((DcPaymentMethod)row).PaymentTypeCode;
                SelectCashRegister(sender, paymentTypeCode);
            }
        }

        private void btnEdit_BankAccout_EditValueChanged(object sender, EventArgs e)
        {
            trPaymentLineCashless.CashRegisterCode = btnEdit_BankAccout.EditValue?.ToString();
        }

        private void LUE_PaymentPlan_EditValueChanged(object sender, EventArgs e)
        {
            object row = LUE_PaymentPlan.Properties.GetDataSourceRowByKeyValue(LUE_PaymentPlan.EditValue);
            if (row is not null)
            {
                float commisionRate = ((DcPaymentPlan)row).CommissionRate;
                txt_CashlessCommission.EditValue = trPaymentLineCashless.Payment * (decimal)commisionRate / 100;
            }

            trPaymentLineCommission.LineDescription = LUE_PaymentPlan.GetColumnValue(nameof(DcPaymentPlan.PaymentPlanDesc))?.ToString();
        }

        private void txt_CashlessCommission_EditValueChanged(object sender, EventArgs e)
        {
            trPaymentLineCommission.Payment = (-1) * (decimal)txt_CashlessCommission.EditValue;
        }

        //private void txt_InstallmentCommission_EditValueChanged(object sender, EventArgs e)
        //{
        //    trInstallment.Commission = Convert.ToDecimal(txt_InstallmentCommission.EditValue);
        //}

        private void textEditBonus_EditValueChanged(object sender, EventArgs e) { }

        private void textEditBonus_Validating(object sender, CancelEventArgs e) { }

        private void textEditBonus_InvalidValue(object sender, InvalidValueExceptionEventArgs e) { }

        //private void TxtEdit_Installment_EditValueChanged(object sender, EventArgs e)
        //{
        //    //trInstallment.Amount = Convert.ToDecimal(TxtEdit_Installment.EditValue);
        //    //TxtEdit_Installment.DoValidate();
        //}

        //private void LUE_InstallmentCurrency_EditValueChanged(object sender, EventArgs e)
        //{
        //    //trInstallment.CurrencyCode = LUE_InstallmentCurrency.EditValue.ToString();

        //    //if (LUE_InstallmentCurrency.Visible)
        //    //    trInstallment.ExchangeRate = (float)LUE_InstallmentCurrency.GetColumnValue(nameof(DcCurrency.ExchangeRate));
        //}

        //private void LUE_InstallmentPlan_EditValueChanged(object sender, EventArgs e)
        //{
        //    if (efMethods.CurrAccHasClaims(Authorization.CurrAccCode, "InstallmentCommissionChange"))
        //        txt_InstallmentCommission.Enabled = true;

        //    //object row = LUE_InstallmentPlan.Properties.GetDataSourceRowByKeyValue(LUE_InstallmentPlan.EditValue);
        //    //trInstallment.InstallmentPlanCode = ((DcPaymentPlan)row).PaymentPlanCode;

        //    //if (row is not null)
        //    //{
        //    //    float commisionRate = ((DcPaymentPlan)row).CommissionRate;
        //    //    txt_InstallmentCommission.EditValue = trInstallment.AmountLoc * (decimal)commisionRate / 100;
        //    //}


        //}

        private void btn_Ok_Click(object sender, EventArgs e)
        {
            SavePayment(false);
        }

        private void SavePayment(bool autoPayment)
        {
            if (trPaymentLineCash.PaymentLoc <= 0 && trPaymentLineCashless.PaymentLoc <= 0)
                return;

            if (trPaymentLineCashless.PaymentLoc > 0)// lUE_PaymentMethod Validation
            {
                if (lUE_PaymentMethod.EditValue == null)
                {
                    dxErrorProvider1.SetError(lUE_PaymentMethod, "Boş buraxıla bilməz!");
                    return;
                }
                else
                {
                    if (((List<DcPaymentPlan>)LUE_PaymentPlan.Properties.DataSource)?.Count > 0 && LUE_PaymentPlan.EditValue == null)
                    {
                        dxErrorProvider1.SetError(LUE_PaymentPlan, "Boş buraxıla bilməz!");
                        return;
                    }
                }
            }

            //if (trInstallment.Amount > 0)// lUE_PaymentMethod Validation
            //{
            //    if (LUE_InstallmentPlan.EditValue == null)
            //    {
            //        dxErrorProvider1.SetError(LUE_InstallmentPlan, "Boş buraxıla bilməz!");
            //        return;
            //    }

            //    DcCurrAcc dcCurrAcc = efMethods.SelectCurrAcc(trInvoiceHeader.CurrAccCode);

            //    if (dcCurrAcc is null)
            //    {
            //        XtraMessageBox.Show("Cari Hesab Seçilməyib");
            //        return;
            //    }

            //    if (String.IsNullOrEmpty(dcCurrAcc.IdentityNum))
            //    {
            //        XtraMessageBox.Show("Cari Hesabın Şəxsiyyət Vəsiqəsinin Nömrəsi yoxdur");
            //        return;
            //    }

            //    if (String.IsNullOrEmpty(dcCurrAcc.PhoneNum))
            //    {
            //        XtraMessageBox.Show("Cari Hesabın Telefon Nömrəsi yoxdur");
            //        return;
            //    }
            //}

            if (trPaymentLineCash.PaymentLoc > 0 || trPaymentLineCashless.PaymentLoc > 0)
            {
                string NewDocNum = efMethods.GetNextDocNum(true, "PA", "DocumentNumber", "TrPaymentHeaders", 6);
                trPaymentHeader.DocumentNumber = NewDocNum;
                trPaymentHeader.Description = TxtEdit_Description.EditValue?.ToString();

                efMethods.InsertEntity(trPaymentHeader);

                if (trPaymentLineCash.PaymentLoc > 0)
                {
                    trPaymentLineCash.PaymentLineId = Guid.NewGuid();
                    trPaymentLineCash.Payment = isNegativ ? -trPaymentLineCash.Payment : trPaymentLineCash.Payment;
                    efMethods.InsertEntity(trPaymentLineCash);
                }

                if (trPaymentLineCashless.PaymentLoc > 0)
                {
                    trPaymentLineCashless.PaymentLineId = Guid.NewGuid();
                    trPaymentLineCashless.Payment = isNegativ ? -trPaymentLineCashless.Payment : trPaymentLineCashless.Payment;

                    if (dcPaymentMethod.IsRedirected)
                        trPaymentLineCashless.CashRegisterCode = null;

                    efMethods.InsertEntity(trPaymentLineCashless);

                    var hasCommission = Convert.ToDecimal(txt_CashlessCommission.EditValue ?? 0) > 0;

                    if (!dcPaymentMethod.IsRedirected)
                    {
                        if (hasCommission)
                            efMethods.InsertEntity(trPaymentLineCommission);
                    }
                    else
                    {
                        var redirectedHeader = new TrPaymentHeader
                        {
                            PaymentHeaderId = Guid.NewGuid(),
                            DocumentNumber = efMethods.GetNextDocNum(true, "PA", "DocumentNumber", "TrPaymentHeaders", 6),
                            CurrAccCode = dcPaymentMethod.RedirectedCurrAccCode?.ToString(),
                            PaymentKindId = 1,
                            CreatedUserName = Authorization.CurrAccCode,
                            OfficeCode = Authorization.OfficeCode,
                            StoreCode = Authorization.StoreCode,
                            ProcessCode = "PA",
                            DocumentDate = trInvoiceHeader.DocumentDate,
                            DocumentTime = trInvoiceHeader.DocumentTime,
                            InvoiceHeaderId = trInvoiceHeader.InvoiceHeaderId,
                            OperationDate = DateTime.Now,
                            IsMainTF = true,
                        };
                        efMethods.InsertEntity(redirectedHeader);

                        var redirectedLine = new TrPaymentLine
                        {
                            PaymentLineId = Guid.NewGuid(),
                            PaymentHeaderId = redirectedHeader.PaymentHeaderId,
                            PaymentTypeCode = 2,
                            CurrencyCode = trPaymentLineCashless.CurrencyCode,
                            ExchangeRate = trPaymentLineCashless.ExchangeRate,
                            CreatedDate = DateTime.Now,
                            Payment = -trPaymentLineCashless.Payment,
                            CreatedUserName = Authorization.CurrAccCode,
                        };
                        efMethods.InsertEntity(redirectedLine);

                        if (hasCommission)
                        {
                            trPaymentLineCommission.PaymentHeaderId = redirectedHeader.PaymentHeaderId;
                            trPaymentLineCommission.Payment = -trPaymentLineCommission.Payment;
                            trPaymentLineCommission.CurrencyCode = trPaymentLineCashless.CurrencyCode;
                            trPaymentLineCommission.ExchangeRate = trPaymentLineCashless.ExchangeRate;
                            efMethods.InsertEntity(trPaymentLineCommission);
                        }
                    }
                }
            }

            //if (trInstallment.Amount > 0)
            //{
            //    if (!string.IsNullOrEmpty(trInstallment.InstallmentPlanCode))
            //    {
            //        trInstallment.InvoiceHeaderId = (Guid)trPaymentHeader.InvoiceHeaderId;
            //        trInstallment.DocumentDate = Convert.ToDateTime(dateEdit_Date.EditValue);
            //        efMethods.InsertEntity(trInstallment);
            //    }
            //}

            DialogResult = DialogResult.OK;
        }
    }
}