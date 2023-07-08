using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;
using DevExpress.XtraReports.UserDesigner;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Foxoft
{
    public partial class FormReportPreview : XtraForm
    {
        XtraReport reportE;
        public FormReportPreview()
        {
            InitializeComponent();


        }

        public FormReportPreview(XtraReport report)
            : this()
        {
            this.reportE = report;
            documentViewer1.DocumentSource = report;
            reportE.CreateDocument();
            Show();
        }

        private BarButtonItem CreateItem()
        {
            BarButtonItem item = new();
            item.ItemClick += item_ItemClick;
            item.Caption = "Get Help";
            return item;
        }

        void item_ItemClick(object sender, ItemClickEventArgs e)
        {
            MessageBox.Show("Item clicked");
        }

        private void BBI_EditDesign_ItemClick(object sender, ItemClickEventArgs e)
        {
            XRDesignRibbonForm FormDesignRibbon = new();

            //FormDesignRibbon.RibbonControl.Pages[0].Groups.Add(new RibbonPageGroup() { Name = "Design", Text = "Dizayn"});
            RibbonPageGroup pageGroup = FormDesignRibbon.RibbonControl.Pages[0].GetGroupByName("Report");
            BarButtonItem item = CreateItem();
            pageGroup.ItemLinks.Add(item);

            FormDesignRibbon.OpenReport(reportE);
            FormDesignRibbon.Show();
        }
    }
}
