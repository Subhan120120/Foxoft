using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraLayout.Utils;
using DevExpress.XtraSplashScreen;
using Foxoft.Models;
using Foxoft.Properties;
using System.ComponentModel;

namespace Foxoft
{
    public partial class FormPayment : XtraForm
    {
        private Guid PaymentHeaderId;
        private TrPaymentHeader trPaymentHeader = new();
        private TrInvoiceHeader trInvoiceHeader { get; set; }
        private TrPaymentLine trPaymentLineCash = new();
        private TrPaymentLine trPaymentLineCashless = new();
        private TrPaymentLine trPaymentLineBonus = new();
        private TrPaymentLine trPaymentLineCommission = new();
        private DcPaymentMethod dcPaymentMethod = new();
        private EfMethods efMethods = new();
        private DcLoyaltyCard dcLoyaltyCard = new();

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

            List<DcCurrency> currencies = efMethods.SelectEntities<DcCurrency>();
            lUE_cashCurrency.Properties.DataSource = currencies;
            lUE_CashlessCurrency.Properties.DataSource = currencies;
            lUE_PaymentMethod.Properties.DataSource = efMethods.SelectPaymentMethodsByPaymentTypes(new[] { PaymentType.Cashless });
        }

        public FormPayment(PaymentType paymentType, decimal pay, TrInvoiceHeader trInvoiceHeader)
           : this()
        {
            this.trInvoiceHeader = trInvoiceHeader;

            PaymentDefaults(paymentType, trInvoiceHeader);

            lUE_PaymentMethod.EditValue = efMethods.SelectPaymentMethodsByPaymentTypes(new[] { PaymentType.Cashless })
                                                    .FirstOrDefault(x => x.IsDefault == true)?
                                                    .PaymentMethodId;

            if ((bool)CustomExtensions.DirectionIsIn(trInvoiceHeader.ProcessCode, trInvoiceHeader.IsReturn))
                isNegativ = true;

            switch (paymentType)
            {
                case PaymentType.Cash:
                    trPaymentLineCash.Payment = Math.Abs(pay);
                    break;
                case PaymentType.Cashless:
                    trPaymentLineCashless.Payment = Math.Abs(pay);
                    break;
                case PaymentType.Bonus:
                    trPaymentLineBonus.Payment = Math.Abs(pay);
                    break;
                default:
                    break;
            }
        }

        public FormPayment(PaymentType paymentType, decimal pay, TrInvoiceHeader trInvoiceHeader, PaymentType[] paymentTypes, DcLoyaltyCard loyaltyCard)
           : this(paymentType, pay, trInvoiceHeader)
        {
            lCG_Cash.Visibility = paymentTypes.Contains(PaymentType.Cash) ? LayoutVisibility.Always : LayoutVisibility.Never;
            lCG_Cashless.Visibility = paymentTypes.Contains(PaymentType.Cashless) ? LayoutVisibility.Always : LayoutVisibility.Never;
            lCG_CustomerBonus.Visibility = paymentTypes.Contains(PaymentType.Bonus) ? LayoutVisibility.Always : LayoutVisibility.Never;

            dcLoyaltyCard = loyaltyCard;
        }

        public FormPayment(PaymentType paymentType, decimal pay, TrInvoiceHeader trInvoiceHeader, PaymentType[] paymentTypes, DcLoyaltyCard loyaltyCard, bool isInstallmentPayment)
           : this(paymentType, pay, trInvoiceHeader, paymentTypes, loyaltyCard)
        {
            if (isInstallmentPayment)
                trPaymentHeader.PaymentKindId = 3;
        }

        private void PaymentDefaults(PaymentType paymentType, TrInvoiceHeader trInvoiceHeader)
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
            trPaymentLineCash.PaymentTypeCode = PaymentType.Cash;
            trPaymentLineCash.PaymentMethodId = 1;
            trPaymentLineCash.CurrencyCode = Settings.Default.AppSetting.LocalCurrencyCode;
            trPaymentLineCash.ExchangeRate = 1;
            trPaymentLineCash.CreatedUserName = Authorization.CurrAccCode;

            trPaymentLineCashless.PaymentHeaderId = PaymentHeaderId;
            trPaymentLineCashless.PaymentTypeCode = PaymentType.Cashless;
            trPaymentLineCashless.PaymentMethodId = 3;
            trPaymentLineCashless.CurrencyCode = Settings.Default.AppSetting.LocalCurrencyCode;
            trPaymentLineCashless.ExchangeRate = 1;
            trPaymentLineCashless.CreatedUserName = Authorization.CurrAccCode;

            trPaymentLineBonus.PaymentHeaderId = PaymentHeaderId;
            trPaymentLineBonus.PaymentTypeCode = PaymentType.Bonus;
            trPaymentLineBonus.PaymentMethodId = 1;
            trPaymentLineBonus.CurrencyCode = Settings.Default.AppSetting.LocalCurrencyCode;
            trPaymentLineBonus.ExchangeRate = 1;
            trPaymentLineBonus.CreatedUserName = Authorization.CurrAccCode;

            trPaymentLineCommission.PaymentHeaderId = PaymentHeaderId;
            trPaymentLineCommission.PaymentLineId = Guid.NewGuid();
            trPaymentLineCommission.PaymentTypeCode = PaymentType.Commission;
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
            txtEdit_Bonus.EditValue = trPaymentLineBonus.PaymentLoc;

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
            e.WindowCaption = Resources.Common_Attention;
            e.ErrorText = Resources.Validation_Range_Min;
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
            SelectCashRegister(sender, PaymentType.Cash);
        }

        private void SelectCashRegister(object sender, PaymentType paymentType)
        {
            ButtonEdit buttonEdit = (ButtonEdit)sender;

            using (FormCashRegisterList form = new(trInvoiceHeader.CurrAccCode, (byte)paymentType))
            {
                if (form.ShowDialog(this) == DialogResult.OK)
                    buttonEdit.EditValue = form.dcCurrAcc.CurrAccCode;
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
            e.ErrorText = Resources.Form_Payment_CashRegisterNotFound;
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
                PaymentType code = ((DcPaymentMethod)row).PaymentTypeCode;
                SelectCashRegister(sender, code);
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

        private void textEditBonus_EditValueChanged(object sender, EventArgs e)
        {
            trPaymentLineBonus.Payment = Convert.ToDecimal(txtEdit_Bonus.EditValue);
            txtEdit_Bonus.DoValidate();
        }

        private void textEditBonus_Validating(object sender, CancelEventArgs e)
        {
            if (dcLoyaltyCard is null)
            {
                e.Cancel = true;
                return;
            }

            if (trPaymentLineBonus.Payment < 0)
            {
                e.Cancel = true;
                return;
            }

            // Return / refund halında (isNegativ=true) bonus balans limiti yoxlanmamalıdır
            if (isNegativ)
                return;

            if (trInvoiceHeader == null || trInvoiceHeader.InvoiceHeaderId == Guid.Empty)
                return;

            decimal availableBonus = efMethods.SelectPaymentLinesBonusSumByInvoice(dcLoyaltyCard);

            if (trPaymentLineBonus.Payment > availableBonus)
                e.Cancel = true;
        }

        private void textEditBonus_InvalidValue(object sender, InvalidValueExceptionEventArgs e)
        {
        }

        private void btn_Ok_Click(object sender, EventArgs e)
        {
            SavePayment();
        }

        private void SavePayment()
        {
            // ✅ bonusu da nəzərə al
            if (trPaymentLineCash.PaymentLoc <= 0 &&
                trPaymentLineCashless.PaymentLoc <= 0 &&
                trPaymentLineBonus.PaymentLoc <= 0)
                return;

            // Bonus yalnız invoice-a bağlı məntiqlidir (istəsən bu qaydanı götürə bilərsən)
            if (trPaymentLineBonus.PaymentLoc > 0 &&
                (trInvoiceHeader == null || trInvoiceHeader.InvoiceHeaderId == Guid.Empty))
                return;

            // Cashless varsa PaymentMethod/PPlan validation
            if (trPaymentLineCashless.PaymentLoc > 0)
            {
                if (lUE_PaymentMethod.EditValue == null)
                {
                    dxErrorProvider1.SetError(lUE_PaymentMethod, Resources.Validation_Required);
                    return;
                }

                if (((List<DcPaymentPlan>)LUE_PaymentPlan.Properties.DataSource)?.Count > 0 && LUE_PaymentPlan.EditValue == null)
                {
                    dxErrorProvider1.SetError(LUE_PaymentPlan, Resources.Validation_Required);
                    return;
                }
            }

            // ✅ Bonus balansını server tərəfdə də yoxla (UI bypass olmasın)
            //if (!isNegativ && trPaymentLineBonus.PaymentLoc > 0 &&
            //    trInvoiceHeader != null && trInvoiceHeader.InvoiceHeaderId != Guid.Empty)
            //{
            //    decimal availableBonus = efMethods.SelectCustomerBonusBalance(trInvoiceHeader.CurrAccCode);
            //    if (trPaymentLineBonus.PaymentLoc > availableBonus)
            //    {
            //        dxErrorProvider1.SetError(txtEdit_Bonus, Resources.Validation_Range_Max);
            //        return;
            //    }
            //}

            // ✅ OverpaymentMode tətbiqi (insertlərdən ƏVVƏL)
            if (!ApplyOverpaymentMode())
                return;

            // Capping-dən sonra 0 ola bilər
            if (trPaymentLineCash.PaymentLoc <= 0 &&
                trPaymentLineCashless.PaymentLoc <= 0 &&
                trPaymentLineBonus.PaymentLoc <= 0)
                return;

            // ✅ bonusu da daxil et
            if (trPaymentLineCash.PaymentLoc > 0 ||
                trPaymentLineCashless.PaymentLoc > 0 ||
                trPaymentLineBonus.PaymentLoc > 0)
            {
                string NewDocNum = efMethods.GetNextDocNum(true, "PA", nameof(TrPaymentHeader.DocumentNumber), "TrPaymentHeaders", 6);
                trPaymentHeader.DocumentNumber = NewDocNum;
                trPaymentHeader.Description = TxtEdit_Description.EditValue?.ToString();

                efMethods.InsertEntity(trPaymentHeader);

                // CASH
                if (trPaymentLineCash.PaymentLoc > 0)
                {
                    trPaymentLineCash.PaymentLineId = Guid.NewGuid();
                    trPaymentLineCash.Payment = isNegativ ? -trPaymentLineCash.Payment : trPaymentLineCash.Payment;
                    efMethods.InsertEntity(trPaymentLineCash);
                }

                // CASHLESS
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
                            DocumentNumber = efMethods.GetNextDocNum(true, "PA", nameof(TrPaymentHeader.DocumentNumber), "TrPaymentHeaders", 6),
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
                            PaymentMethodId = dcPaymentMethod.PaymentMethodId,
                            PaymentHeaderId = redirectedHeader.PaymentHeaderId,
                            PaymentTypeCode = PaymentType.Cashless,
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

                // ✅ BONUS (yeni)
                if (trPaymentLineBonus.PaymentLoc > 0)
                {
                    InsertBonusRedeemToLoyaltyTxn();
                }

            }

            DialogResult = DialogResult.OK;
        }

        private void InsertBonusRedeemToLoyaltyTxn()
        {
            decimal bonusLoc = trPaymentLineBonus.PaymentLoc;
            if (bonusLoc <= 0) return;

            var txn = new TrLoyaltyTxn
            {
                LoyaltyTxnId = Guid.NewGuid(),
                CurrAccCode = trPaymentHeader.CurrAccCode,
                InvoiceHeaderId = trPaymentHeader.InvoiceHeaderId,
                PaymentHeaderId = trPaymentHeader.PaymentHeaderId,
                LoyaltyCardId = dcLoyaltyCard.LoyaltyCardId,
                // satışda bonus xərclənir -> mənfi
                // return/refund-da geri qaytarılır -> müsbət (Reverse)
                TxnType = isNegativ ? LoyaltyTxnType.Reverse : LoyaltyTxnType.Redeem,
                //Amount = isNegativ ? bonusLoc : -bonusLoc,
                DocumentDate = trPaymentHeader.DocumentDate,

                CreatedUserName = trPaymentHeader.CreatedUserName,

                Note = TxtEdit_Description.EditValue?.ToString()
            };

            efMethods.InsertEntity(txn);
            efMethods.InsertEntity(trPaymentLineBonus);
        }


        private bool ApplyOverpaymentMode()
        {
            // Invoice yoxdursa – overpayment qaydası tətbiq edilmir
            if (trInvoiceHeader == null || trInvoiceHeader.InvoiceHeaderId == Guid.Empty)
                return true;

            decimal dueLoc = efMethods.SelectInvoiceSum(trInvoiceHeader.InvoiceHeaderId);
            if (dueLoc <= 0)
                return true;

            decimal paidLoc = (trPaymentLineCash.PaymentLoc + trPaymentLineCashless.PaymentLoc + trPaymentLineBonus.PaymentLoc);

            if (paidLoc <= dueLoc)
                return true;

            decimal overLoc = paidLoc - dueLoc;

            var mode = (OverpaymentMode)Settings.Default.AppSetting.OverpaymentMode;

            // AskEachTime + manual => soruş
            if (mode == OverpaymentMode.AskEachTime)
            {
                var dr = XtraMessageBox.Show(
                    this,
                    $"Ödənilən məbləğ borcdan {overLoc:n2} çoxdur.\r\n\r\n" +
                    $"YES  = Üst pulu qaytar\r\n" +
                    $"NO   = Avans kimi saxla\r\n" +
                    $"CANCEL = Ləğv",
                    Resources.Common_Attention,
                    MessageBoxButtons.YesNoCancel,
                    MessageBoxIcon.Question
                );

                if (dr == DialogResult.Yes) mode = OverpaymentMode.AcceptExactAndReturnChange;
                else if (dr == DialogResult.No) mode = OverpaymentMode.AcceptAllAsAdvance;
                else return false; // Cancel
            }

            if (mode == OverpaymentMode.AcceptExactAndReturnChange)
            {
                CapPaymentsToDue(dueLoc);

                XtraMessageBox.Show(
                    this,
                    $"Qaytarılan məbləğ: {overLoc:n2}.",
                    Resources.Common_Attention
                );
            }
            // AcceptAllAsAdvance => heç nə etmirik (mövcud sistem sonradan avans kimi işləyə bilər)
            return true;
        }

        private void CapPaymentsToDue(decimal dueLoc)
        {
            decimal cashLoc = trPaymentLineCash.PaymentLoc;
            decimal cashlessLoc = trPaymentLineCashless.PaymentLoc;
            decimal bonusLoc = trPaymentLineBonus.PaymentLoc;

            decimal total = cashLoc + cashlessLoc + bonusLoc;
            decimal over = total - dueLoc;
            if (over <= 0) return;

            decimal newCashLoc = cashLoc;
            decimal newCashlessLoc = cashlessLoc;
            decimal newBonusLoc = bonusLoc;

            // əvvəl cash-dən azaldırıq (üst pulu qaytarma klassik)
            if (newCashLoc > 0)
            {
                decimal reduce = Math.Min(over, newCashLoc);
                newCashLoc -= reduce;
                over -= reduce;
            }

            // sonra cashless
            if (over > 0 && newCashlessLoc > 0)
            {
                decimal reduce = Math.Min(over, newCashlessLoc);
                newCashlessLoc -= reduce;
                over -= reduce;
            }

            // sonda bonus (cash/cashless yoxdursa məcbur cap olunur)
            if (over > 0 && newBonusLoc > 0)
            {
                decimal reduce = Math.Min(over, newBonusLoc);
                newBonusLoc -= reduce;
                over -= reduce;
            }

            SetPaymentLoc(trPaymentLineCash, newCashLoc);
            SetPaymentLoc(trPaymentLineCashless, newCashlessLoc);
            SetPaymentLoc(trPaymentLineBonus, newBonusLoc);

            txtEdit_Cash.EditValue = trPaymentLineCash.PaymentLoc;
            txtEdit_Cashless.EditValue = trPaymentLineCashless.PaymentLoc;
            txtEdit_Bonus.EditValue = trPaymentLineBonus.PaymentLoc;

            RecalcCashlessCommission();
        }


        private static void SetPaymentLoc(TrPaymentLine line, decimal desiredLoc)
        {
            decimal rate = (decimal)(line.ExchangeRate == 0 ? 1 : line.ExchangeRate);
            line.Payment = Math.Round(desiredLoc / rate, 4);
        }

        private void RecalcCashlessCommission()
        {
            object row = LUE_PaymentPlan.Properties.GetDataSourceRowByKeyValue(LUE_PaymentPlan.EditValue);
            if (row is DcPaymentPlan plan)
                txt_CashlessCommission.EditValue = trPaymentLineCashless.PaymentLoc * (decimal)plan.CommissionRate / 100m;
            else
                txt_CashlessCommission.EditValue = 0m;
        }
    }
}
