using DevExpress.XtraBars.Ribbon;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using Foxoft.Models;

namespace Foxoft
{
    public partial class FormLoyaltyCards : RibbonForm
    {
        public DcLoyaltyCard dcLoyaltyCard;

        public FormLoyaltyCards()
        {
            InitializeComponent();

            LoadData();
        }

        private void LoadData()
        {
            using (var context = new subContext())
            {
                var loyaltyCards = context.DcLoyaltyCards
                    .Include(lc => lc.DcCurrAcc)
                    .Include(lc => lc.DcLoyaltyProgram)
                    .ToList();
                dcLoyaltyCardBindingSource.DataSource = loyaltyCards;
            }
        }

        private void BBI_New_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            using FormLoyaltyCard form = new();
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }

        private void BBI_Edit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (dcLoyaltyCard == null)
                return;

            using FormLoyaltyCard form = new(dcLoyaltyCard.LoyaltyCardId);
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gridView1.FocusedRowHandle >= 0)
            {
                dcLoyaltyCard = (DcLoyaltyCard)gridView1.GetRow(e.FocusedRowHandle);
            }
            else
                dcLoyaltyCard = null;
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            if (dcLoyaltyCard != null)
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
            if (dcLoyaltyCard == null)
                return;

            using (var context = new subContext())
            {
                var loyaltyCard = context.DcLoyaltyCards.Find(dcLoyaltyCard.LoyaltyCardId);
                if (loyaltyCard != null)
                {
                    context.DcLoyaltyCards.Remove(loyaltyCard);
                    context.SaveChanges();
                    LoadData();
                }
            }
        }
    }
}
