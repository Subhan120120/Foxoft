using DevExpress.Utils;
using DevExpress.Utils.VisualEffects;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using Foxoft.Models;
using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Foxoft
{
    public partial class FormReportGrid : RibbonForm
    {
        Badge badge1;
        Badge badge2;
        AdornerUIManager adornerUIManager1;
        int reportId;
        EfMethods efMethods = new EfMethods();

        public FormReportGrid(int reportId)
        {
            this.reportId = reportId;

            InitializeComponent();

            adornerUIManager1 = new AdornerUIManager(components);
            badge1 = new Badge();
            badge2 = new Badge();
            adornerUIManager1.Elements.Add(badge1);
            adornerUIManager1.Elements.Add(badge2);
            badge1.TargetElement = barButtonItem1;
            badge2.TargetElement = ribbonPage1;
        }

        public AdornerElement[] Badges
        {
            get
            {
                return new AdornerElement[] { badge1, badge2 };
            }
        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            Stream str = new MemoryStream();
            gridView1.SaveLayoutToStream(str);
            str.Seek(0, SeekOrigin.Begin);
            StreamReader reader = new StreamReader(str);
            string layourTxt = reader.ReadToEnd();
            efMethods.UpdateReportLayout(reportId, layourTxt);
        }

        private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
        {
            DcReport dcReport = efMethods.SelectReport(reportId);

            if (!string.IsNullOrEmpty(dcReport.ReportLayout))
            {
                byte[] byteArray = Encoding.ASCII.GetBytes(dcReport.ReportLayout);
                MemoryStream stream = new MemoryStream(byteArray);
                gridView1.RestoreLayoutFromStream(stream);
            }
        }

        private void bBI_gridOptions_ItemClick(object sender, ItemClickEventArgs e)
        {
            Stream str = new MemoryStream();
            OptionsLayoutGrid option = new OptionsLayoutGrid() { StoreAllOptions = true, StoreAppearance = true };
            gridView1.SaveLayoutToStream(str, option);

            using (FormReportGridOptions formReportGridOptions = new FormReportGridOptions(str))
            {
                if (formReportGridOptions.ShowDialog(this) == DialogResult.OK)
                {
                    formReportGridOptions.stream.Seek(0, SeekOrigin.Begin);
                    gridView1.RestoreLayoutFromStream(formReportGridOptions.stream, option);
                }
            }
        }
    }
}
