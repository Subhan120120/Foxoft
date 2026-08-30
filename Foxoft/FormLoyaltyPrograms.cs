using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using Foxoft.Models;
using Foxoft.Properties;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Foxoft
{
    public partial class FormLoyaltyPrograms : RibbonForm
    {
        public DcLoyaltyProgram dcLoyaltyProgram;

        public FormLoyaltyPrograms()
        {
            InitializeComponent();

            LoadData();
        }

        private void LoadData()
        {
            using var context = new subContext();
            var loyaltyPrograms = context.DcLoyaltyPrograms
                .Include(lp => lp.DcLoyaltyCards)
                .OrderBy(lp => lp.Name)
                .ToList();
            dcLoyaltyProgramsBindingSource.DataSource = loyaltyPrograms;
        }

        private void BBI_New_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            using FormLoyaltyProgram form = new();
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }

        private void BBI_Edit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (dcLoyaltyProgram == null)
                return;

            using FormLoyaltyProgram form = new(dcLoyaltyProgram.LoyaltyProgramId);
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gridView1.FocusedRowHandle >= 0)
            {
                dcLoyaltyProgram = gridView1.GetRow(e.FocusedRowHandle) as DcLoyaltyProgram;
            }
            else
            {
                dcLoyaltyProgram = null;
            }
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            if (dcLoyaltyProgram != null)
            {
                BBI_Edit.PerformClick();
            }
        }

        private void BBI_Refresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LoadData();
        }

        private void BBI_Delete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (dcLoyaltyProgram == null)
                return;

            using var context = new subContext();
            var program = context.DcLoyaltyPrograms
                .Include(p => p.DcLoyaltyCards)
                .FirstOrDefault(p => p.LoyaltyProgramId == dcLoyaltyProgram.LoyaltyProgramId);

            if (program == null)
                return;

            if (program.DcLoyaltyCards.Any())
            {
                XtraMessageBox.Show(
                    Resources.Form_LoyaltyProgram_DeleteHasCards,
                    Resources.Common_Attention,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirm = XtraMessageBox.Show(
                $"{program.Name} - {Resources.Common_Delete}?",
                Resources.Common_Attention,
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                context.DcLoyaltyPrograms.Remove(program);
                context.SaveChanges(Authorization.CurrAccCode);
                LoadData();
            }
        }
    }
}