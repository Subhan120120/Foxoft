using DevExpress.Utils;
using DevExpress.Utils.VisualEffects;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using Foxoft.Models;
using System;
using System.Data;
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
        AdoMethods adoMethods = new AdoMethods();

        public FormReportGrid(string qry)
        {
            InitializeComponent();

            DataTable dt = adoMethods.SqlGetDt(qry);
            gridControl1.DataSource = dt;

            adornerUIManager1 = new AdornerUIManager(components);
            badge1 = new Badge();
            badge2 = new Badge();
            adornerUIManager1.Elements.Add(badge1);
            adornerUIManager1.Elements.Add(badge2);
            badge1.TargetElement = barButtonItem1;
            badge2.TargetElement = ribbonPage1;
        }

        public FormReportGrid(string qry, int reportId)
            : this(qry)
        {
            this.reportId = reportId;

            LoadLayout();
        }


        public AdornerElement[] Badges
        {
            get
            {
                return new AdornerElement[] { badge1, badge2 };
            }
        }

        private void bBI_LayoutSave_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (reportId > 0)
            {
                Stream str = new MemoryStream();
                gV_Report.SaveLayoutToStream(str);
                str.Seek(0, SeekOrigin.Begin);
                StreamReader reader = new StreamReader(str);
                string layoutTxt = reader.ReadToEnd();
                efMethods.UpdateReportLayout(reportId, layoutTxt);
            }
        }

        private void bBI_LayoutLoad_ItemClick(object sender, ItemClickEventArgs e)
        {
            LoadLayout();
        }

        private void LoadLayout()
        {
            if (reportId > 0)
            {
                DcReport dcReport = efMethods.SelectReport(reportId);
                if (!string.IsNullOrEmpty(dcReport.ReportLayout))
                {
                    byte[] byteArray = Encoding.Unicode.GetBytes(dcReport.ReportLayout);
                    MemoryStream stream = new MemoryStream(byteArray);
                    gV_Report.RestoreLayoutFromStream(stream);
                }
            }
        }

        private void bBI_gridOptions_ItemClick(object sender, ItemClickEventArgs e)
        {
            Stream str = new MemoryStream();
            OptionsLayoutGrid option = new OptionsLayoutGrid() { StoreAllOptions = true, StoreAppearance = true };
            gV_Report.SaveLayoutToStream(str, option);

            using (FormReportGridOptions formGridOptions = new FormReportGridOptions(str))
            {
                if (formGridOptions.ShowDialog(this) == DialogResult.OK)
                {
                    formGridOptions.stream.Seek(0, SeekOrigin.Begin);
                    gV_Report.RestoreLayoutFromStream(formGridOptions.stream, option);
                }
            }
        }

        private void barButtonItem3_ItemClick(object sender, ItemClickEventArgs e)
        {
            //MyGridControlDesigner myDesigner = new MyGridControlDesigner(gridControl1);
            //myDesigner.LevelDesignerVisible = false;
            //myDesigner.Selector.AllowDesignerButton = false;
            //myDesigner.ShowDesigner(null, null);
        }
    }
}
