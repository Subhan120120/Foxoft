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
                    .ToList();
                dcLoyaltyCardBindingSource.DataSource = loyaltyCards;
            }
        }

        private void BBI_New_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FormCommon<DcLoyaltyCard> form = new FormCommon<DcLoyaltyCard>("", true, nameof(DcLoyaltyCard.LoyaltyCardId));
            form.ShowDialog();
        }

        private void BBI_Edit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FormCommon<DcLoyaltyCard> form = new ("", false, nameof(DcLoyaltyCard.LoyaltyCardId), dcLoyaltyCard.LoyaltyCardId.ToString());
            form.ShowDialog();
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
