using DevExpress.DataAccess.Sql;
using DevExpress.Mvvm.Native;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using DevExpress.XtraPrinting;
using DevExpress.XtraReports.UI;
using DevExpress.XtraReports.UserDesigner;
using Foxoft.Models;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace Foxoft
{
    public partial class FormReportPreview : XtraForm
    {
        XtraReport xReport;
        private EfMethods efMethods = new();
        readonly SettingStore settingStore;

        public FormReportPreview()
        {
            settingStore = efMethods.SelectSettingStore(Authorization.StoreCode);

            InitializeComponent();
        }

        public FormReportPreview(string query, string filter, DcReport dcReport)
            : this()
        {
            query = CustomExtensions.AddTop(query, int.MaxValue);

            string qryMaster = "Select * from ( " + query + " \n) as master";

            if (!string.IsNullOrEmpty(filter))
                qryMaster = qryMaster + " where " + filter;

            XtraReport xtraReport = GetInvoiceReport(dcReport, qryMaster);

            this.xReport = xtraReport;
            documentViewer1.DocumentSource = xtraReport;
            this.xReport.CreateDocument();
            Show();
        }

        private XtraReport GetInvoiceReport(DcReport dcReport, string reportQry)
        {
            List<DcReportSubQuery> ReportSubQueries = efMethods.SelectReportQueriesByReport(dcReport.ReportId);
            List<CustomSqlQuery> sqlQueries = new();

            sqlQueries.Add(new CustomSqlQuery("Data", reportQry));

            foreach (DcReportSubQuery reportSubQuery in ReportSubQueries)
            {
                CustomSqlQuery sqlQuery = SelectQry(reportSubQuery);
                sqlQueries.Add(sqlQuery);
            }

            ReportClass reportClass = new();
            return reportClass.GetReport(dcReport.ReportName, dcReport.ReportName + ".repx", sqlQueries);
        }

        public CustomSqlQuery SelectQry(DcReportSubQuery reportSubQuery)
        {
            List<DcQueryParam> dcQueryParams = efMethods.SelectQueryParamsByQuery(reportSubQuery.SubQueryId);

            CustomSqlQuery sqlQuery = new(reportSubQuery.SubQueryName, reportSubQuery.SubQueryText);

            foreach (DcQueryParam queryParam in dcQueryParams)
            {
                //string typeName = typeof(DateTime).FullName;

                //object value = Convert.ChangeType(queryParam.ParameterValue, Type.GetType(queryParam.ParameterType));
                //QueryParameter queryParameter = new(queryParam.ParameterName, Type.GetType(queryParam.ParameterType), value);
                //sqlQuery.Parameters.Add(queryParameter);

                //QueryParameter queryParameter2 = new();
                //queryParameter2.Name = "EndDate";
                //queryParameter2.Type = typeof(DateTime);
                //queryParameter2.ValueInfo = EndDate.ToString("yyyy-MM-dd");
            }

            return sqlQuery;
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
