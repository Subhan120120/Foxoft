using DevExpress.Utils.VisualEffects;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Foxoft
{
    public partial class FormERP : RibbonForm
    {
        AdornerUIManager adornerUIManager1;
        IList<AdornerElement> adorners1;

        public FormERP()
        {
            InitializeComponent();

            adorners1 = new List<AdornerElement>();
            adornerUIManager1 = new AdornerUIManager(this.components);
        }

        private void RibbonControl1_Merge(object sender, RibbonMergeEventArgs e)
        {
            AdornerElement[] badges = ((FormInvoice)e.MergedChild.Parent).Badges;
            adornerUIManager1.BeginUpdate();
            foreach (AdornerElement badge in badges)
            {
                AdornerElement clone = badge.Clone() as AdornerElement;
                if (badge.TargetElement is BarItem)
                    clone.TargetElement = badge.TargetElement;
                if (badge.TargetElement is RibbonPage)
                    clone.TargetElement = ribbonControl.MergedPages.GetPageByName((badge.TargetElement as RibbonPage).Name);
                adornerUIManager1.Elements.Add(clone);
                adorners1.Add(clone);
            }
            adornerUIManager1.EndUpdate();
        }

        private void RibbonControl1_UnMerge(object sender, RibbonMergeEventArgs e)
        {
            adornerUIManager1.BeginUpdate();
            foreach (AdornerElement badge in adorners1)
            {
                adornerUIManager1.Elements.Remove(badge);
                badge.Dispose();
            }
            adorners1.Clear();
            adornerUIManager1.EndUpdate();
        }

        private void bBI_POS_ItemClick(object sender, ItemClickEventArgs e)
        {
            FormPOS formPOS = new FormPOS();
            formPOS.Show();
        }

        private void bBI_CloseWindows_ItemClick(object sender, ItemClickEventArgs e)
        {
            CloseOpenChildForms();
        }

        private void CloseOpenChildForms()
        {
            foreach (var child in this.MdiChildren)
            {
                var myCustomChild = child as RibbonForm;
                if (myCustomChild == null) continue; //if there are any casting problems

                myCustomChild.Close();
            }
        }

        private void FormERP_MdiChildActivate(object sender, EventArgs e)
        {
            try
            {
                ribbonControl.SelectedPage = ribbonControl.MergedPages[0]; // child form acanda ona aid olan ribbon acilsin
            }
            catch (Exception) { }
        }

        private void aCE_shipment_Click(object sender, EventArgs e)
        {
            FormTransfer formTransfer = Application.OpenForms["FormTransfer"] as FormTransfer;

            if (formTransfer != null)
            {
                formTransfer.BringToFront();
                formTransfer.Activate();
            }
            else
            {
                formTransfer = new FormTransfer();
                formTransfer.MdiParent = this;
                formTransfer.Show();
                ribbonControl.SelectedPage = ribbonControl.MergedPages[0];
            }
        }

        private void aCE_Report_Click(object sender, EventArgs e)
        {
            FormReportFilter formReport = Application.OpenForms["FormReportFilter"] as FormReportFilter;

            if (formReport != null)
            {
                formReport.BringToFront();
                formReport.Activate();
            }
            else
            {
                formReport = new FormReportFilter();
                formReport.MdiParent = this;
                formReport.Show();
                ribbonControl.SelectedPage = ribbonControl.MergedPages[0];
            }
        }

        private void aCE_CurrAccs_Click(object sender, EventArgs e)
        {
            FormCurrAccList form = Application.OpenForms["FormCurrAccList"] as FormCurrAccList;

            if (form != null)
            {
                form.BringToFront();
                form.Activate();
            }
            else
            {
                form = new FormCurrAccList(0);
                form.MdiParent = this;
                form.Show();
                ribbonControl.SelectedPage = ribbonControl.MergedPages[0];
            }
        }

        private void aCE_RetailPurchaseInvoice_Click(object sender, EventArgs e)
        {
            int OpenFormCount = 0;

            foreach (Form form in Application.OpenForms)
            {
                FormInvoice formInvoice = form as FormInvoice;
                if (formInvoice != null && formInvoice.processCode == "RP")
                {
                    formInvoice.BringToFront();
                    formInvoice.Activate();
                    OpenFormCount++;
                }
            }

            if (OpenFormCount == 0)
            {
                FormInvoice formInvoice = new FormInvoice("RP", 1);
                formInvoice.MdiParent = this;
                formInvoice.Show();
                ribbonControl.SelectedPage = ribbonControl.MergedPages[0];
            }
        }

        private void aCE_RetailSaleInvoice_Click(object sender, EventArgs e)
        {
            int OpenFormCount = 0;

            foreach (Form form in Application.OpenForms)
            {
                FormInvoice formInvoice = form as FormInvoice;
                if (formInvoice != null && formInvoice.processCode == "RS")
                {
                    formInvoice.BringToFront();
                    formInvoice.Activate();
                    OpenFormCount++;
                }
            }

            if (OpenFormCount == 0)
            {
                FormInvoice formInvoice = new FormInvoice("RS", 1);
                formInvoice.MdiParent = this;
                formInvoice.Show();
                ribbonControl.SelectedPage = ribbonControl.MergedPages[0];
            }
        }

        private void aCE_Expense_Click(object sender, EventArgs e)
        {
            int OpenFormCount = 0;

            foreach (Form form in Application.OpenForms)
            {
                FormInvoice formInvoice = form as FormInvoice;
                if (formInvoice != null && formInvoice.processCode == "EX")
                {
                    formInvoice.BringToFront();
                    formInvoice.Activate();
                    OpenFormCount++;
                }
            }

            if (OpenFormCount == 0)
            {
                FormInvoice formInvoice = new FormInvoice("EX", 2);
                formInvoice.MdiParent = this;
                formInvoice.Show();
                ribbonControl.SelectedPage = ribbonControl.MergedPages[0];
            }
        }
    }
}