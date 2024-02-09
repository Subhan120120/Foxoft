using DevExpress.Data.Filtering;
using DevExpress.DataAccess.Sql;
using DevExpress.Mvvm.Native;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using DevExpress.XtraPrinting;
using DevExpress.XtraReports;
using DevExpress.XtraReports.UI;
using DevExpress.XtraReports.UserDesigner;
using Foxoft.AppCode;
using Foxoft.Migrations;
using Foxoft.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace Foxoft
{
    public partial class FormReportPreview : XtraForm
    {
        private XtraReport xReport;
        private EfMethods efMethods = new();
        private CustomMethods cM = new();
        readonly SettingStore settingStore;

        public FormReportPreview()
        {
            settingStore = efMethods.SelectSettingStore(Authorization.StoreCode);

            InitializeComponent();
        }

        public FormReportPreview(string query, string filter, DcReport dcReport)
            : this()
        {
            dcReport = efMethods.SelectReport(dcReport.ReportId);

            query = cM.AddTop(query, int.MaxValue);

            string qryMaster = $"Select TOP {int.MaxValue} * from ( " + query + " \n) as master"; // 'TOP' daha sonraki 'ORDER BY' ucundur

            if (!string.IsNullOrEmpty(filter))
                qryMaster += " where " + filter;

            qryMaster += " order by RowNumber";

            qryMaster = cM.AddFilters(qryMaster, dcReport);

            CustomSqlQuery mainQuery = new("Main", qryMaster);

            mainQuery = cM.AddParameters(mainQuery, dcReport);


            List<CustomSqlQuery> sqlQueries = new(new[] { mainQuery });

            foreach (TrReportSubQuery reportSubQuery in dcReport.TrReportSubQueries)
            {
                reportSubQuery.SubQueryText = cM.AddTop(reportSubQuery.SubQueryText, int.MaxValue);

                reportSubQuery.SubQueryText = cM.AddRelation(qryMaster, reportSubQuery);

                reportSubQuery.SubQueryText = cM.AddFilters(reportSubQuery.SubQueryText, dcReport);

                CustomSqlQuery subQuery = new(reportSubQuery.SubQueryName, reportSubQuery.SubQueryText);

                subQuery = cM.AddParameters(subQuery, dcReport);

                sqlQueries.Add(subQuery);
            }

            ReportClass reportClass = new();
            XtraReport xtraReport = reportClass.GetReport(dcReport.ReportName, dcReport.ReportName + ".repx", sqlQueries);

            xReport = xtraReport;
            documentViewer1.DocumentSource = xtraReport;
            xReport.CreateDocument();
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
            BarButtonItem bbi_Design = CreateItem();
            pageGroup.ItemLinks.Add(bbi_Design);

            FormDesignRibbon.OpenReport(xReport);
            FormDesignRibbon.Show();
        }

        private void BBI_CopyToClipboard_ItemClick(object sender, ItemClickEventArgs e)
        {
            Image image = Image.FromStream(GetInvoiceReportImg());
            Clipboard.SetImage(image);
        }

        private MemoryStream GetInvoiceReportImg()
        {
            if (xReport is not null)
            {
                MemoryStream ms = new();

                xReport.ExportToImage(ms, new ImageExportOptions() { Format = ImageFormat.Png, PageRange = "1-30", ExportMode = ImageExportMode.SingleFilePageByPage, Resolution = 480 });

                return ms;
            }
            else
                return null;
        }
    }
}
