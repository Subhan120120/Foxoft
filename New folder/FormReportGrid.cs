using DevExpress.Utils.VisualEffects;
using Foxoft.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Foxoft
{
    public partial class FormReportGrid : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        Badge badge1;
        Badge badge2;
        AdornerUIManager adornerUIManager1;
        Guid reportId;
        EfMethods efMethods = new EfMethods();

        public FormReportGrid(Guid reportId)
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

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Stream str = new MemoryStream();
            gridView1.SaveLayoutToStream(str);
            str.Seek(0, SeekOrigin.Begin);
            StreamReader reader = new StreamReader(str);
            string layourTxt = reader.ReadToEnd();
            efMethods.UpdateReportLayout(reportId, layourTxt);
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DcReport dcReport = efMethods.SelectReport(reportId);
            byte[] byteArray = Encoding.ASCII.GetBytes(dcReport.ReportLayout);
            MemoryStream stream = new MemoryStream(byteArray);
            gridView1.RestoreLayoutFromStream(stream);
        }
    }
}
