using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using Foxoft.Models;
using Foxoft.Properties;
using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Foxoft
{
    public partial class FormLoyaltyCard : XtraForm
    {
        private subContext dbContext;
        private EfMethods efMethods = new();
        private Guid? loyaltyCardId;
        private string defaultCurrAccCode;

        public DcLoyaltyCard dcLoyaltyCard = new();

        public FormLoyaltyCard()
        {
            InitializeComponent();
        }

        public FormLoyaltyCard(Guid loyaltyCardId)
            : this()
        {
            this.loyaltyCardId = loyaltyCardId;
        }

        public FormLoyaltyCard(string currAccCode)
            : this()
        {
            this.defaultCurrAccCode = currAccCode;
        }

        private void FormLoyaltyCard_Load(object sender, EventArgs e)
        {
            LoadLookups();
            LoadLoyaltyCard();
        }

        private void LoadLookups()
        {
            using subContext lookUpDb = new();

            var programs = lookUpDb.DcLoyaltyPrograms
                .AsNoTracking()
                .Where(x => x.IsActive)
                .OrderBy(x => x.Name)
                .ToList();

            LoyaltyProgramIdLookUpEdit.Properties.DataSource = programs;
            LoyaltyProgramIdLookUpEdit.Properties.DisplayMember = nameof(DcLoyaltyProgram.Name);
            LoyaltyProgramIdLookUpEdit.Properties.ValueMember = nameof(DcLoyaltyProgram.LoyaltyProgramId);

            LoyaltyProgramIdLookUpEdit.Properties.Columns.Clear();
            LoyaltyProgramIdLookUpEdit.Properties.Columns.Add(new LookUpColumnInfo(nameof(DcLoyaltyProgram.Name), Resources.Entity_DcLoyaltyCard_LoyaltyProgramId, 160));
            LoyaltyProgramIdLookUpEdit.Properties.Columns.Add(new LookUpColumnInfo(nameof(DcLoyaltyProgram.EarnPercent), "Bonus %", 70, DevExpress.Utils.FormatType.Numeric, "N2", true, DevExpress.Utils.HorzAlignment.Far));
            LoyaltyProgramIdLookUpEdit.Properties.Columns.Add(new LookUpColumnInfo(nameof(DcLoyaltyProgram.ExpireDays), "Gün", 60, DevExpress.Utils.FormatType.Numeric, "N0", true, DevExpress.Utils.HorzAlignment.Far));
        }

        private void LoadLoyaltyCard()
        {
            dbContext = new subContext();

            if (loyaltyCardId.HasValue)
            {
                dbContext.DcLoyaltyCards
                    .Where(x => x.LoyaltyCardId == loyaltyCardId.Value)
                    .Include(x => x.DcCurrAcc)
                    .Include(x => x.DcLoyaltyProgram)
                    .Load();

                dbContext.TrLoyaltyTxns
                    .Where(x => x.LoyaltyCardId == loyaltyCardId.Value)
                    .OrderByDescending(x => x.DocumentDate)
                    .Load();

                dcLoyaltyCardsBindingSource.DataSource = dbContext.DcLoyaltyCards.Local.ToBindingList();
                trLoyaltyTxnsBindingSource.DataSource = dbContext.TrLoyaltyTxns.Local.ToBindingList();

                dcLoyaltyCard = dcLoyaltyCardsBindingSource.Current as DcLoyaltyCard ?? new DcLoyaltyCard();

                UpdateCustomerDesc(dcLoyaltyCard.CurrAccCode);
                RefreshBonusBalance();
            }
            else
            {
                dcLoyaltyCardsBindingSource.DataSource = dbContext.DcLoyaltyCards.Local.ToBindingList();
                trLoyaltyTxnsBindingSource.DataSource = dbContext.TrLoyaltyTxns.Local.ToBindingList();

                dcLoyaltyCard = dcLoyaltyCardsBindingSource.AddNew() as DcLoyaltyCard ?? new DcLoyaltyCard();
                dcLoyaltyCard.LoyaltyCardId = Guid.NewGuid();
                dcLoyaltyCard.CardNumber = GenerateCardNumber();
                dcLoyaltyCard.IsActive = true;
                dcLoyaltyCard.CreatedUserName = Authorization.CurrAccCode;
                dcLoyaltyCard.CreatedDate = DateTime.Now;

                if (!string.IsNullOrWhiteSpace(defaultCurrAccCode))
                {
                    dcLoyaltyCard.CurrAccCode = defaultCurrAccCode;
                    UpdateCustomerDesc(defaultCurrAccCode);
                }

                BonusBalanceTextEdit.EditValue = 0m;
            }
        }

        private void RefreshBonusBalance()
        {
            if (dcLoyaltyCard != null && dcLoyaltyCard.LoyaltyCardId != Guid.Empty)
            {
                decimal balance = efMethods.GetLoyaltyBalanceAsync(dcLoyaltyCard.LoyaltyCardId);
                BonusBalanceTextEdit.EditValue = balance;
            }
            else
            {
                BonusBalanceTextEdit.EditValue = 0m;
            }
        }

        private string GenerateCardNumber()
        {
            try
            {
                return efMethods.GetNextDocNum(true, "LC", nameof(DcLoyaltyCard.CardNumber), "DcLoyaltyCards", 6);
            }
            catch
            {
                return "LC-" + DateTime.Now.ToString("yyMMddHHmmss");
            }
        }

        private void UpdateCustomerDesc(string currAccCode)
        {
            if (string.IsNullOrWhiteSpace(currAccCode))
            {
                CurrAccDescTextEdit.EditValue = string.Empty;
                return;
            }

            DcCurrAcc currAcc = efMethods.SelectCurrAcc(currAccCode.Trim());
            CurrAccDescTextEdit.EditValue = currAcc?.CurrAccDesc ?? string.Empty;
        }

        private void CardNumberTextEdit_ButtonPressed(object sender, ButtonPressedEventArgs e)
        {
            CardNumberTextEdit.EditValue = GenerateCardNumber();
        }

        private void CurrAccCodeTextEdit_ButtonPressed(object sender, ButtonPressedEventArgs e)
        {
            string currentCode = CurrAccCodeTextEdit.Text?.Trim() ?? string.Empty;

            using FormCurrAccList form = new(new byte[] { 1, 2, 3 }, false, currentCode);

            try
            {
                if (form.ShowDialog(this) == DialogResult.OK && form.dcCurrAcc != null)
                {
                    CurrAccCodeTextEdit.EditValue = form.dcCurrAcc.CurrAccCode;
                    CurrAccDescTextEdit.EditValue = form.dcCurrAcc.CurrAccDesc;
                    dxErrorProvider1.SetError(CurrAccCodeTextEdit, string.Empty);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, Resources.Common_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CurrAccCodeTextEdit_EditValueChanged(object sender, EventArgs e)
        {
            string currAccCode = CurrAccCodeTextEdit.Text?.Trim() ?? string.Empty;
            UpdateCustomerDesc(currAccCode);
        }

        private void LoyaltyProgramIdLookUpEdit_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == ButtonPredefines.Delete)
            {
                LoyaltyProgramIdLookUpEdit.EditValue = null;
            }
        }

        private bool ValidateData()
        {
            bool isValid = true;
            dxErrorProvider1.ClearErrors();

            string cardNumber = CardNumberTextEdit.Text?.Trim() ?? string.Empty;
            string currAccCode = CurrAccCodeTextEdit.Text?.Trim() ?? string.Empty;

            if (string.IsNullOrWhiteSpace(cardNumber))
            {
                dxErrorProvider1.SetError(CardNumberTextEdit, Resources.Form_LoyaltyCard_CardNumberRequired);
                isValid = false;
            }
            else
            {
                bool cardExists = dbContext.DcLoyaltyCards
                    .AsNoTracking()
                    .Any(x => x.CardNumber == cardNumber && x.LoyaltyCardId != dcLoyaltyCard.LoyaltyCardId);

                if (cardExists)
                {
                    dxErrorProvider1.SetError(CardNumberTextEdit, Resources.Form_LoyaltyCard_CardNumberExists);
                    XtraMessageBox.Show(Resources.Form_LoyaltyCard_CardNumberExists, Resources.Common_Attention, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }

            if (string.IsNullOrWhiteSpace(currAccCode))
            {
                dxErrorProvider1.SetError(CurrAccCodeTextEdit, Resources.Form_LoyaltyCard_CustomerRequired);
                isValid = false;
            }
            else if (!efMethods.EntityExists<DcCurrAcc>(currAccCode))
            {
                dxErrorProvider1.SetError(CurrAccCodeTextEdit, Resources.Common_Error);
                XtraMessageBox.Show(Resources.Common_Error, Resources.Common_Attention, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return isValid;
        }

        private void btn_Ok_Click(object sender, EventArgs e)
        {
            dataLayoutControl1.Validate();
            dcLoyaltyCardsBindingSource.EndEdit();

            if (!ValidateData())
                return;

            try
            {
                dcLoyaltyCard = dcLoyaltyCardsBindingSource.Current as DcLoyaltyCard;

                if (dcLoyaltyCard == null)
                    return;

                if (!loyaltyCardId.HasValue)
                {
                    dcLoyaltyCard.CreatedUserName = Authorization.CurrAccCode;
                    dcLoyaltyCard.CreatedDate = DateTime.Now;
                }

                dcLoyaltyCard.LastUpdatedUserName = Authorization.CurrAccCode;
                dcLoyaltyCard.LastUpdatedDate = DateTime.Now;

                dbContext.SaveChanges(Authorization.CurrAccCode);

                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, Resources.Common_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}