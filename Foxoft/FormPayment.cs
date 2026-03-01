using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraLayout.Utils;
using Foxoft.Models;
using Foxoft.Properties;
using System.ComponentModel;

namespace Foxoft
{
    public partial class FormPayment : XtraForm
    {
        private Guid PaymentHeaderId;

        private readonly TrPaymentHeader trPaymentHeader = new();
        private TrInvoiceHeader trInvoiceHeader { get; set; }

        private readonly TrPaymentLine trPaymentLineCash = new();
        private readonly TrPaymentLine trPaymentLineCashless = new();
        private readonly TrPaymentLine trPaymentLineBonus = new();
        private readonly TrPaymentLine trPaymentLineCommission = new();

        private DcPaymentMethod dcPaymentMethod = new();
        private readonly EfMethods efMethods = new();

        private decimal availableBonus = 0m;
        private decimal expectedPayLoc = 0m;

        private const decimal PayTolerance = 0.01m;
        private bool isNegativ = false;

        public FormPayment()
        {
            InitializeComponent();

            Name = "PaymentDetail";
            AcceptButton = btn_Ok;
            CancelButton = btn_Cancel;

            InitLookups();
        }

        public FormPayment(PaymentType paymentType, decimal pay, TrInvoiceHeader invoiceHeader)
            : this()
        {
            trInvoiceHeader = invoiceHeader;
            expectedPayLoc = Math.Abs(pay);

            if (invoiceHeader.DcLoyaltyCard != null && HasInvoice())
                availableBonus = efMethods.SelectLoyaltyBalanceExceptInvoice(invoiceHeader.DcLoyaltyCard.LoyaltyCardId, trInvoiceHeader.InvoiceHeaderId);

            txtEdit_LoyaltyBalance.EditValue = availableBonus;

            PaymentDefaults(invoiceHeader);

            SetDefaultPaymentMethod();
            isNegativ = (bool)CustomExtensions.DirectionIsIn(invoiceHeader.ProcessCode, invoiceHeader.IsReturn);

            ApplyInitialPayments(paymentType, pay);
        }

        public FormPayment(PaymentType paymentType, decimal pay, TrInvoiceHeader invoiceHeader, bool isInstallmentPayment)
            : this(paymentType, pay, invoiceHeader)
        {
            if (isInstallmentPayment)
                trPaymentHeader.PaymentKindId = 3;
        }

        private void InitLookups()
        {
            LUE_PaymentPlan.Properties.ValueMember = nameof(DcPaymentPlan.PaymentPlanCode);
            LUE_PaymentPlan.Properties.DisplayMember = nameof(DcPaymentPlan.PaymentPlanDesc);
            LUE_PaymentPlan.Properties.Columns.AddRange(new LookUpColumnInfo[]
            {
                new LookUpColumnInfo(nameof(DcPaymentPlan.PaymentPlanCode), ReflectionExt.GetDisplayName<DcPaymentPlan>(x => x.PaymentPlanCode)),
                new LookUpColumnInfo(nameof(DcPaymentPlan.PaymentPlanDesc), ReflectionExt.GetDisplayName<DcPaymentPlan>(x => x.PaymentPlanDesc)),
                new LookUpColumnInfo(nameof(DcPaymentPlan.DurationInMonths), ReflectionExt.GetDisplayName<DcPaymentPlan>(x => x.DurationInMonths)),
                new LookUpColumnInfo(nameof(DcPaymentPlan.CommissionRate), ReflectionExt.GetDisplayName<DcPaymentPlan>(x => x.CommissionRate)),
            });

            var currencies = efMethods.SelectEntities<DcCurrency>();
            lUE_cashCurrency.Properties.DataSource = currencies;
            lUE_CashlessCurrency.Properties.DataSource = currencies;

            lUE_PaymentMethod.Properties.DataSource =
                efMethods.SelectPaymentMethodsByPaymentTypes(new[] { PaymentType.Cashless });
        }

        private void SetDefaultPaymentMethod()
        {
            lUE_PaymentMethod.EditValue =
                efMethods.SelectPaymentMethodsByPaymentTypes(new[] { PaymentType.Cashless })
                         .FirstOrDefault(x => x.IsDefault)?.PaymentMethodId;
        }

        private void ApplyInitialPayments(PaymentType paymentType, decimal pay)
        {
            var absPay = Math.Abs(pay);

            switch (paymentType)
            {
                case PaymentType.Cash:
                    trPaymentLineCash.Payment = absPay;
                    break;

                case PaymentType.Cashless:
                    trPaymentLineCashless.Payment = absPay;
                    break;

                case PaymentType.Bonus:
                    var bonusToUse = Math.Min(absPay, availableBonus);
                    var remaining = absPay - bonusToUse;
                    trPaymentLineBonus.Payment = bonusToUse;
                    trPaymentLineCash.Payment = remaining;
                    break;
            }
        }

        private void PaymentDefaults(TrInvoiceHeader header)
        {
            PaymentHeaderId = Guid.NewGuid();

            trPaymentHeader.PaymentHeaderId = PaymentHeaderId;
            trPaymentHeader.CurrAccCode = header?.CurrAccCode;
            trPaymentHeader.CreatedUserName = Authorization.CurrAccCode;
            trPaymentHeader.OfficeCode = Authorization.OfficeCode;
            trPaymentHeader.StoreCode = Authorization.StoreCode;
            trPaymentHeader.ProcessCode = "PA";
            trPaymentHeader.DocumentDate = header?.DocumentDate ?? DateTime.Today;
            trPaymentHeader.DocumentTime = header?.DocumentTime ?? DateTime.Now.TimeOfDay;
            trPaymentHeader.TerminalId = Settings.Default.TerminalId;

            if (HasInvoice())
            {
                trPaymentHeader.InvoiceHeaderId = header.InvoiceHeaderId;
                trPaymentHeader.PaymentKindId = 2;
            }
            else
            {
                trPaymentHeader.PaymentKindId = 1;
            }

            trPaymentHeader.OperationDate = DateTime.Now;
            trPaymentHeader.IsMainTF = true;

            InitLineDefaults(trPaymentLineCash, PaymentType.Cash, 1);
            InitLineDefaults(trPaymentLineCashless, PaymentType.Cashless, 3);
            InitLineDefaults(trPaymentLineBonus, PaymentType.Bonus, 1);

            trPaymentLineCommission.PaymentHeaderId = PaymentHeaderId;
            trPaymentLineCommission.PaymentLineId = Guid.NewGuid();
            trPaymentLineCommission.PaymentTypeCode = PaymentType.Commission;
            trPaymentLineCommission.PaymentMethodId = 3;
            trPaymentLineCommission.CreatedUserName = Authorization.CurrAccCode;

            SetDefaultCashRegisterToLines();
        }

        private void InitLineDefaults(TrPaymentLine line, PaymentType type, int paymentMethodId)
        {
            line.PaymentHeaderId = PaymentHeaderId;
            line.PaymentTypeCode = type;
            line.PaymentMethodId = paymentMethodId;
            line.CurrencyCode = Settings.Default.AppSetting.LocalCurrencyCode;
            line.ExchangeRate = 1;
            line.CreatedUserName = Authorization.CurrAccCode;
        }

        private void SetDefaultCashRegisterToLines()
        {
            var cashReg = efMethods.SelectCashRegisterByTerminal(Settings.Default.TerminalId);
            if (!string.IsNullOrWhiteSpace(cashReg))
            {
                trPaymentLineCash.CashRegisterCode = cashReg;
                trPaymentLineCashless.CashRegisterCode = cashReg;
            }
        }

        private bool HasInvoice()
            => trInvoiceHeader != null && trInvoiceHeader.InvoiceHeaderId != Guid.Empty;

        private void FormPayment_Load(object sender, EventArgs e) => FillControls();

        private void FillControls()
        {
            dateEdit_Date.EditValue = DateTime.Now.ToString("yyyy-MM-dd");

            txtEdit_Cash.EditValue = trPaymentLineCash.PaymentLoc;
            lUE_cashCurrency.EditValue = trPaymentLineCash.CurrencyCode;
            btnEdit_CashRegister.EditValue = trPaymentLineCash.CashRegisterCode;

            txtEdit_Cashless.EditValue = trPaymentLineCashless.PaymentLoc;
            lUE_CashlessCurrency.EditValue = trPaymentLineCashless.CurrencyCode;

            txtEdit_Bonus.EditValue = trPaymentLineBonus.PaymentLoc;
        }

        private void dateEdit_Date_EditValueChanged(object sender, EventArgs e)
        {
            if (dateEdit_Date.EditValue is DateTime dt)
                trPaymentHeader.OperationDate = dt;
        }

        // ---------- Safe decimal parsing ----------
        private static decimal TryGetDecimal(object value)
            => value == null ? 0m : decimal.TryParse(value.ToString(), out var d) ? d : 0m;

        private void txtEdit_Cash_EditValueChanged(object sender, EventArgs e)
        {
            trPaymentLineCash.Payment = TryGetDecimal(txtEdit_Cash.EditValue);
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
            var code = lUE_cashCurrency.EditValue?.ToString();
            if (string.IsNullOrWhiteSpace(code)) return;

            trPaymentLineCash.CurrencyCode = code;

            var rateObj = lUE_cashCurrency.GetColumnValue(nameof(DcCurrency.ExchangeRate));
            if (rateObj != null && float.TryParse(rateObj.ToString(), out var rate))
                trPaymentLineCash.ExchangeRate = rate;
        }

        private void lUE_PaymentMethod_EditValueChanged(object sender, EventArgs e)
        {
            if (lUE_PaymentMethod.EditValue == null) return;

            dcPaymentMethod = efMethods.SelectEntityById<DcPaymentMethod>(Convert.ToInt32(lUE_PaymentMethod.EditValue));
            trPaymentLineCashless.PaymentMethodId = dcPaymentMethod.PaymentMethodId;

            var isRedirected = dcPaymentMethod.IsRedirected;

            LayoutControlAnimator.SetVisibilityWithAnimation(lCI_BankCurrAcc, isRedirected ? LayoutVisibility.Never : LayoutVisibility.Always);

            if (isRedirected)
            {
                btnEdit_BankAccout.EditValue = null;
                trPaymentLineCashless.CashRegisterCode = null;
            }
            else
            {
                var cashReg = string.IsNullOrWhiteSpace(dcPaymentMethod.DefaultCashRegCode)
                    ? efMethods.SelectCashRegisterByTerminal(Settings.Default.TerminalId)
                    : dcPaymentMethod.DefaultCashRegCode;

                btnEdit_BankAccout.EditValue = cashReg;
                trPaymentLineCashless.CashRegisterCode = cashReg;
            }

            var paymentPlans = efMethods.SelectPaymentPlans(dcPaymentMethod.PaymentMethodId);
            var hasPlans = paymentPlans.Count > 0;

            LUE_PaymentPlan.Properties.DataSource = paymentPlans;
            LUE_PaymentPlan.EditValue = hasPlans ? efMethods.SelectPaymentPlanDefault(dcPaymentMethod.PaymentMethodId)?.PaymentPlanCode : null;

            LayoutControlAnimator.SetVisibilityWithAnimation(LCI_PaymentPlan, hasPlans ? LayoutVisibility.Always : LayoutVisibility.Never);
            LayoutControlAnimator.SetVisibilityWithAnimation(LCI_CashlessCommission, hasPlans ? LayoutVisibility.Always : LayoutVisibility.Never);

            RecalcCashlessCommission();
        }

        private void textEditCashless_EditValueChanged(object sender, EventArgs e)
        {
            trPaymentLineCashless.Payment = TryGetDecimal(txtEdit_Cashless.EditValue);
            txtEdit_Cashless.DoValidate();
            RecalcCashlessCommission();
        }
        private void textEditCashless_Validating(object sender, CancelEventArgs e)
        {
            if (trPaymentLineCashless.Payment < 0)
                e.Cancel = true;
        }

        private void textEditCashless_InvalidValue(object sender, InvalidValueExceptionEventArgs e) { }

        private void lUE_CashlessCurrency_EditValueChanged(object sender, EventArgs e)
        {
            var code = lUE_CashlessCurrency.EditValue?.ToString();
            if (string.IsNullOrWhiteSpace(code)) return;

            trPaymentLineCashless.CurrencyCode = code;

            var rateObj = lUE_CashlessCurrency.GetColumnValue(nameof(DcCurrency.ExchangeRate));
            if (rateObj != null && float.TryParse(rateObj.ToString(), out var rate))
                trPaymentLineCashless.ExchangeRate = rate;

            RecalcCashlessCommission();
        }
        private void btnEdit_BankAccout_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            object row = lUE_PaymentMethod.Properties.GetDataSourceRowByKeyValue(lUE_PaymentMethod.EditValue);
            if (row is not null)
            {
                SelectCashRegister(sender);
            }
        }

        private void btnEdit_BankAccout_EditValueChanged(object sender, EventArgs e)
        {
            trPaymentLineCashless.CashRegisterCode = btnEdit_BankAccout.EditValue?.ToString();
        }

        private void textEditBonus_EditValueChanged(object sender, EventArgs e)
        {
            trPaymentLineBonus.Payment = TryGetDecimal(txtEdit_Bonus.EditValue);
            txtEdit_Bonus.DoValidate();
        }

        private void textEditBonus_Validating(object sender, CancelEventArgs e)
        {
            if (trInvoiceHeader.DcLoyaltyCard is null) { e.Cancel = true; return; }
            if (trPaymentLineBonus.Payment < 0) { e.Cancel = true; return; }

            if (isNegativ) return; // refund -> limit check etmirik
            if (!HasInvoice()) return;

            if (trPaymentLineBonus.Payment > availableBonus)
                e.Cancel = true;
        }

        private void textEditBonus_InvalidValue(object sender, InvalidValueExceptionEventArgs e)
        {
            e.ErrorText = "Bonus Balansı Kifayət Deyil.";
            e.ExceptionMode = ExceptionMode.DisplayError;
        }

        private void btnEdit_CashRegister_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            SelectCashRegister(sender);
        }

        private void SelectCashRegister(object sender)
        {
            ButtonEdit buttonEdit = (ButtonEdit)sender;

            using (FormCashRegisterList form = new(trInvoiceHeader.CurrAccCode))
            {
                if (form.ShowDialog(this) == DialogResult.OK)
                    buttonEdit.EditValue = form.dcCurrAcc.CurrAccCode;
            }
        }

        private void btnEdit_CashRegister_EditValueChanged(object sender, EventArgs e)
        {
            trPaymentLineCash.CashRegisterCode = btnEdit_CashRegister.EditValue?.ToString();
        }

        private void btnEdit_CashRegister_Validating(object sender, CancelEventArgs e)
        {
            var code = btnEdit_CashRegister.EditValue?.ToString();
            if (string.IsNullOrWhiteSpace(code)) return;

            var cashReg = efMethods.SelectCurrAcc(code);
            if (cashReg is null) e.Cancel = true;
            else trPaymentLineCash.CashRegisterCode = code;
        }

        private void btnEdit_CashRegister_InvalidValue(object sender, InvalidValueExceptionEventArgs e)
        {
            e.ErrorText = Resources.Form_Payment_CashRegisterNotFound;
            e.ExceptionMode = ExceptionMode.DisplayError;
        }

        private void LUE_PaymentPlan_EditValueChanged(object sender, EventArgs e)
        {
            trPaymentLineCommission.LineDescription =
                LUE_PaymentPlan.GetColumnValue(nameof(DcPaymentPlan.PaymentPlanDesc))?.ToString();

            RecalcCashlessCommission();
        }

        private void txt_CashlessCommission_EditValueChanged(object sender, EventArgs e)
        {
            trPaymentLineCommission.Payment = (-1) * (decimal)txt_CashlessCommission.EditValue;
        }

        private void RecalcCashlessCommission()
        {
            if (LUE_PaymentPlan.EditValue == null)
            {
                txt_CashlessCommission.EditValue = 0m;
                trPaymentLineCommission.Payment = 0m;
                return;
            }

            var row = LUE_PaymentPlan.Properties.GetDataSourceRowByKeyValue(LUE_PaymentPlan.EditValue);
            if (row is DcPaymentPlan plan)
            {
                var commission = trPaymentLineCashless.PaymentLoc * (decimal)plan.CommissionRate / 100m;
                txt_CashlessCommission.EditValue = commission;
                trPaymentLineCommission.Payment = -commission;
            }
            else
            {
                txt_CashlessCommission.EditValue = 0m;
                trPaymentLineCommission.Payment = 0m;
            }
        }

        private void btn_Ok_Click(object sender, EventArgs e) => SavePayment();

        private decimal TotalPaidLoc()
            => trPaymentLineCash.PaymentLoc + trPaymentLineCashless.PaymentLoc + trPaymentLineBonus.PaymentLoc;

        private void SavePayment()
        {
            dxErrorProvider1.ClearErrors();

            if (!HasAnyPayment()) return;
            if (!ValidateCashlessRequired()) return;
            if (!ValidateUnderpayment()) return;
            if (!ApplyOverpaymentMode()) return;
            if (!HasAnyPayment()) return; // cap-dən sonra 0 ola bilər

            CreateHeaderAndInsertLines();

            if (trPaymentLineBonus.PaymentLoc > 0)
                SyncLoyaltySpend(trPaymentHeader.PaymentHeaderId);

            DialogResult = DialogResult.OK;
        }

        private bool HasAnyPayment()
        {
            return trPaymentLineCash.PaymentLoc > 0 ||
                   trPaymentLineCashless.PaymentLoc > 0 ||
                   trPaymentLineBonus.PaymentLoc > 0;
        }

        private bool ValidateCashlessRequired()
        {
            if (trPaymentLineCashless.PaymentLoc <= 0) return true;

            if (lUE_PaymentMethod.EditValue == null)
            {
                dxErrorProvider1.SetError(lUE_PaymentMethod, Resources.Validation_Required);
                return false;
            }

            var plans = (List<DcPaymentPlan>)LUE_PaymentPlan.Properties.DataSource;
            if (plans?.Count > 0 && LUE_PaymentPlan.EditValue == null)
            {
                dxErrorProvider1.SetError(LUE_PaymentPlan, Resources.Validation_Required);
                return false;
            }

            return true;
        }

        private bool ValidateUnderpayment()
        {
            if (expectedPayLoc <= 0) return true;

            var total = TotalPaidLoc();

            bool currAccHasClaims = efMethods.CurrAccHasClaims(
                Authorization.CurrAccCode,
                "AllowPaymentDifference");

            if (currAccHasClaims) return true;

            if ((total + PayTolerance) < expectedPayLoc)
            {
                var missing = expectedPayLoc - total;

                XtraMessageBox.Show(
                    this,
                    $"Ödənişlərin cəmi gözləniləndən azdır.\r\n" +
                    $"Gözlənilən: {expectedPayLoc:n2}\r\n" +
                    $"Daxil edilən: {total:n2}\r\n" +
                    $"Çatışmır: {missing:n2}",
                    Resources.Common_Attention,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return false;
            }

            return true;
        }

        private void CreateHeaderAndInsertLines()
        {
            trPaymentHeader.DocumentNumber = efMethods.GetNextDocNum(true, "PA", nameof(TrPaymentHeader.DocumentNumber), "TrPaymentHeaders", 6);
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
                InsertCashlessFlow();
            }
        }

        private void InsertCashlessFlow()
        {
            trPaymentLineCashless.PaymentLineId = Guid.NewGuid();
            trPaymentLineCashless.Payment = isNegativ ? -trPaymentLineCashless.Payment : trPaymentLineCashless.Payment;

            if (dcPaymentMethod.IsRedirected)
                trPaymentLineCashless.CashRegisterCode = null;

            efMethods.InsertEntity(trPaymentLineCashless);

            var hasCommission = TryGetDecimal(txt_CashlessCommission.EditValue) > 0m;

            if (!dcPaymentMethod.IsRedirected)
            {
                if (hasCommission) efMethods.InsertEntity(trPaymentLineCommission);
                return;
            }

            // redirected
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

        private decimal ResolveDueLoc()
        {
            if (expectedPayLoc > 0) return expectedPayLoc;

            if (!HasInvoice()) return 0m;

            var invoiceSum = efMethods.SelectInvoiceSum(trInvoiceHeader.InvoiceHeaderId);
            return invoiceSum > 0 ? invoiceSum : 0m;
        }

        private bool ApplyOverpaymentMode()
        {
            var dueLoc = ResolveDueLoc();
            if (dueLoc <= 0) return true;

            var paidLoc = TotalPaidLoc();
            if (paidLoc <= dueLoc + PayTolerance) return true;

            var overLoc = paidLoc - dueLoc;

            var mode = (OverpaymentMode)Settings.Default.AppSetting.OverpaymentMode;

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
                else return false;
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

        private void SyncLoyaltySpend(Guid paymentHeaderId)
        {
            subContext db = new subContext();

            if (paymentHeaderId == Guid.Empty) return;
            if (trInvoiceHeader.DcLoyaltyCard == null) return;

            var txn = db.TrLoyaltyTxns
                .FirstOrDefault(x =>
                    x.PaymentLineId == trPaymentLineBonus.PaymentLineId &&
                    x.LoyaltyCardId == trInvoiceHeader.DcLoyaltyCard.LoyaltyCardId &&
                    (x.TxnType == LoyaltyTxnType.Redeem || x.TxnType == LoyaltyTxnType.Refund));

            if (txn == null)
            {
                txn = new TrLoyaltyTxn
                {
                    LoyaltyTxnId = Guid.NewGuid(),
                    LoyaltyCardId = trInvoiceHeader.DcLoyaltyCard.LoyaltyCardId,
                    CurrAccCode = trInvoiceHeader.CurrAccCode,
                    InvoiceHeaderId = trInvoiceHeader.InvoiceHeaderId, // istəsən saxla
                    CreatedUserName = Authorization.CurrAccCode,
                    Amount = isNegativ ? trPaymentLineBonus.PaymentLoc : -trPaymentLineBonus.PaymentLoc,
                    DocumentDate = DateTime.Now,
                    TxnType = isNegativ ? LoyaltyTxnType.Refund : LoyaltyTxnType.Redeem,
                    Note = $"Payment (Bonus) for Invoice: {trInvoiceHeader.DocumentNumber}"
                };

                txn.TrPaymentLine = trPaymentLineBonus;

                db.Add(trPaymentLineBonus);
                db.Add(txn);
                db.SaveChanges();
            }
        }

    }
}
