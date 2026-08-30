using DevExpress.XtraEditors;
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
    public partial class FormLoyaltyProgram : XtraForm
    {
        private subContext dbContext;
        private Guid? loyaltyProgramId;

        public DcLoyaltyProgram dcLoyaltyProgram = new();

        public FormLoyaltyProgram()
        {
            InitializeComponent();
        }

        public FormLoyaltyProgram(Guid loyaltyProgramId)
            : this()
        {
            this.loyaltyProgramId = loyaltyProgramId;
        }

        private void FormLoyaltyProgram_Load(object sender, EventArgs e)
        {
            LoadLoyaltyProgram();
        }

        private void LoadLoyaltyProgram()
        {
            dbContext = new subContext();

            if (loyaltyProgramId.HasValue)
            {
                dbContext.DcLoyaltyPrograms
                    .Where(x => x.LoyaltyProgramId == loyaltyProgramId.Value)
                    .Include(x => x.DcLoyaltyCards)
                        .ThenInclude(c => c.DcCurrAcc)
                    .Load();

                dcLoyaltyProgramsBindingSource.DataSource = dbContext.DcLoyaltyPrograms.Local.ToBindingList();
                dcLoyaltyProgram = dcLoyaltyProgramsBindingSource.Current as DcLoyaltyProgram ?? new DcLoyaltyProgram();

                dcLoyaltyCardsBindingSource.DataSource = dcLoyaltyProgram.DcLoyaltyCards.ToList();
            }
            else
            {
                dcLoyaltyProgramsBindingSource.DataSource = dbContext.DcLoyaltyPrograms.Local.ToBindingList();

                dcLoyaltyProgram = dcLoyaltyProgramsBindingSource.AddNew() as DcLoyaltyProgram ?? new DcLoyaltyProgram();
                dcLoyaltyProgram.LoyaltyProgramId = Guid.NewGuid();
                dcLoyaltyProgram.EarnPercent = 5.00m;
                dcLoyaltyProgram.IsActive = true;

                dcLoyaltyCardsBindingSource.DataSource = new BindingList<DcLoyaltyCard>();
            }
        }

        private bool ValidateData()
        {
            bool isValid = true;
            dxErrorProvider1.ClearErrors();

            string name = NameTextEdit.Text?.Trim() ?? string.Empty;

            if (string.IsNullOrWhiteSpace(name))
            {
                dxErrorProvider1.SetError(NameTextEdit, Resources.Form_LoyaltyProgram_NameRequired);
                isValid = false;
            }
            else
            {
                bool nameExists = dbContext.DcLoyaltyPrograms
                    .AsNoTracking()
                    .Any(x => x.Name == name && x.LoyaltyProgramId != dcLoyaltyProgram.LoyaltyProgramId);

                if (nameExists)
                {
                    dxErrorProvider1.SetError(NameTextEdit, Resources.Form_LoyaltyProgram_NameExists);
                    XtraMessageBox.Show(Resources.Form_LoyaltyProgram_NameExists, Resources.Common_Attention, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }

            decimal earnPercent = EarnPercentCalcEdit.Value;
            if (earnPercent < 0 || earnPercent > 100)
            {
                dxErrorProvider1.SetError(EarnPercentCalcEdit, Resources.Form_LoyaltyProgram_InvalidPercent);
                isValid = false;
            }

            if (MaxRedeemPercentCalcEdit.EditValue != null && MaxRedeemPercentCalcEdit.EditValue != DBNull.Value)
            {
                decimal maxRedeem = MaxRedeemPercentCalcEdit.Value;
                if (maxRedeem < 0 || maxRedeem > 100)
                {
                    dxErrorProvider1.SetError(MaxRedeemPercentCalcEdit, Resources.Form_LoyaltyProgram_InvalidPercent);
                    isValid = false;
                }
            }

            return isValid;
        }

        private void btn_Ok_Click(object sender, EventArgs e)
        {
            dataLayoutControl1.Validate();
            dcLoyaltyProgramsBindingSource.EndEdit();

            if (!ValidateData())
                return;

            try
            {
                dcLoyaltyProgram = dcLoyaltyProgramsBindingSource.Current as DcLoyaltyProgram;

                if (dcLoyaltyProgram == null)
                    return;

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