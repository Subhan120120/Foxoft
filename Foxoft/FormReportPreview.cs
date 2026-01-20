using DevExpress.DataAccess.Sql;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraPrinting;
using DevExpress.XtraReports.UI;
using DevExpress.XtraReports.UserDesigner;
using Foxoft.AppCode;
using Foxoft.Models;
using Foxoft.Models.Entity.Report;
using Foxoft.Properties;
using Microsoft.Data.SqlClient;
using System;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace Foxoft
{
    public partial class FormReportPreview : RibbonForm
    {
        private XtraReport xReport;
        private EfMethods efMethods = new();
        private ReportClass reportClass = new();
        readonly SettingStore settingStore;

        public FormReportPreview()
        {
            settingStore = efMethods.SelectSettingStore(Authorization.StoreCode);

            InitializeComponent();
        }

        public FormReportPreview(string query, string filter, DcReport dcReport)
            : this()
        {
            SqlParameter[] sqlParameters;

            query = this.reportClass.ApplyFilter(dcReport, query, filter, out sqlParameters);

            List<QueryParameter> qryParams = this.reportClass.ConvertSqlParametersToQueryParameters(sqlParameters);

            CustomSqlQuery mainQuery = new("Main", query);
            mainQuery.Parameters.AddRange(qryParams);

            List<CustomSqlQuery> sqlQueries = new(new[] { mainQuery });

            foreach (TrReportSubQuery reportSubQuery in dcReport.TrReportSubQueries)
            {
                SqlParameter[] sqlParameters1;
                reportSubQuery.SubQueryText = this.reportClass.ApplyFilter(dcReport, reportSubQuery.SubQueryText, null, out sqlParameters1);

                reportSubQuery.SubQueryText = this.reportClass.AddRelation(query, reportSubQuery);

                List<QueryParameter> subQryParams = this.reportClass.ConvertSqlParametersToQueryParameters(sqlParameters1);
                CustomSqlQuery subQuery = new(reportSubQuery.SubQueryName, reportSubQuery.SubQueryText);
                subQuery.Parameters.AddRange(subQryParams);

                sqlQueries.Add(subQuery);
            }

            ReportClass reportClass = new(settingStore.DesignFileFolder);

            xReport = reportClass.GetReport(dcReport.ReportName, dcReport.ReportName + ".repx", sqlQueries);

            if (xReport is not null)
            {
                documentViewer1.DocumentSource = xReport;
                xReport.CreateDocument();
                Show();
            }
        }

        private void BBI_EditDesign_ItemClick(object sender, ItemClickEventArgs e)
        {
            using (XRDesignRibbonForm FormDesignRibbon = new())
            {
                RibbonPageGroup pageGroup = FormDesignRibbon.RibbonControl.Pages[0].GetGroupByName("Report");
                BarButtonItem bbi_Design = CreateItem();
                pageGroup.ItemLinks.Add(bbi_Design);

                FormDesignRibbon.OpenReport(xReport);
                FormDesignRibbon.ShowDialog();
            }
        }

        private BarButtonItem CreateItem()
        {
            BarButtonItem item = new();
            item.ItemClick += item_ItemClick;
            item.Caption = Resources.Form_ReportPreview_EditDesign;
            return item;
        }

        void item_ItemClick(object sender, ItemClickEventArgs e)
        {
            MessageBox.Show("Item clicked");
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

        private void FormReportPreview_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (xReport is not null)
            {
                xReport.Dispose();
                xReport = null;
            }
        }
    }
}
