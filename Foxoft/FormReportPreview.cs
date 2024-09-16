using DevExpress.DataAccess.Sql;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraPrinting;
using DevExpress.XtraReports.UI;
using DevExpress.XtraReports.UserDesigner;
using Foxoft.AppCode;
using Foxoft.Models;
using Microsoft.Data.SqlClient;
using System.Drawing.Imaging;
using System.IO;

namespace Foxoft
{
    public partial class FormReportPreview : RibbonForm
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

            SqlParameter[] sqlParameters;
            string qryMaster = "";

            query = cM.ApplyFilter(dcReport, query, filter, out sqlParameters);

            List<QueryParameter> qryParams = cM.ConvertSqlParametersToQueryParameters(sqlParameters);

            CustomSqlQuery mainQuery = new("Main", query);
            mainQuery.Parameters.AddRange(qryParams);

            List<CustomSqlQuery> sqlQueries = new(new[] { mainQuery });

            foreach (TrReportSubQuery reportSubQuery in dcReport.TrReportSubQueries)
            {
                reportSubQuery.SubQueryText = cM.AddRelation(qryMaster, reportSubQuery);

                SqlParameter[] sqlParameters1;
                string qry = cM.ApplyFilter(dcReport, reportSubQuery.SubQueryText, null, out sqlParameters1);

                List<QueryParameter> qryParams1 = cM.ConvertSqlParametersToQueryParameters(sqlParameters1);
                CustomSqlQuery subQuery = new(reportSubQuery.SubQueryName, reportSubQuery.SubQueryText);
                subQuery.Parameters.AddRange(qryParams1);

                sqlQueries.Add(subQuery);
            }

            ReportClass reportClass = new();

            xReport = reportClass.GetReport(dcReport.ReportName, dcReport.ReportName + ".repx", sqlQueries);

            if (xReport is not null)
            {
                documentViewer1.DocumentSource = xReport;
                xReport.CreateDocument();
                Show();
            }
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
