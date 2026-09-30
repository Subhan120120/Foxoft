using DevExpress.DataAccess.Sql;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraPrinting;
using DevExpress.XtraReports;
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
        private string currentDesignFileName;
        private string fullDesignFilePath;

        public FormReportPreview()
        {
            settingStore = efMethods.SelectSettingStore(Authorization.StoreCode);

            InitializeComponent();
        }

        public FormReportPreview(string query, string filter, DcReport dcReport, string designFileName = null)
            : this()
        {
            this.currentDesignFileName = string.IsNullOrWhiteSpace(designFileName)
                ? dcReport.ReportName + ".repx"
                : designFileName;

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

            ReportClass reportClass = new(settingStore?.DesignFileFolder ?? string.Empty);

            string folder = settingStore?.DesignFileFolder;
            if (string.IsNullOrEmpty(folder))
                folder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Design Files");

            if (!Directory.Exists(folder))
            {
                try { Directory.CreateDirectory(folder); } catch { }
            }

            fullDesignFilePath = Path.IsPathRooted(this.currentDesignFileName)
                ? this.currentDesignFileName
                : Path.Combine(folder, this.currentDesignFileName);

            xReport = reportClass.GetReport(dcReport.ReportName, this.currentDesignFileName, sqlQueries);

            if (xReport is not null)
            {
                SetReportHeaderParameters(xReport);

                documentViewer1.DocumentSource = xReport;
                xReport.CreateDocument();
                Show();
            }
        }

        private void SetReportHeaderParameters(XtraReport report)
        {
            if (report is null)
                return;

            AddOrSetParameter(report, "ImageRootPath", settingStore?.ImageFolder);
            AddOrSetParameter(report, "StoreName", settingStore?.DcStore?.CurrAccDesc);
        }

        private void AddOrSetParameter(XtraReport report, string parameterName, object value)
        {
            var parameter = report.Parameters[parameterName];

            if (parameter is null)
            {
                parameter = new DevExpress.XtraReports.Parameters.Parameter()
                {
                    Name = parameterName,
                    Type = typeof(string),
                    Visible = false
                };

                report.Parameters.Add(parameter);
            }

            parameter.Value = value?.ToString() ?? string.Empty;
        }

        private void BBI_EditDesign_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (xReport is null)
                return;

            using (XRDesignRibbonForm FormDesignRibbon = new())
            {
                if (!string.IsNullOrEmpty(fullDesignFilePath))
                {
                    FormDesignRibbon.DesignMdiController.DesignPanelLoaded += (s, args) =>
                    {
                        XRDesignPanel panel = (XRDesignPanel)s;
                        panel.AddCommandHandler(new RepxSaveCommandHandler(panel, fullDesignFilePath));
                    };
                }

                FormDesignRibbon.OpenReport(xReport);
                FormDesignRibbon.ShowDialog(this);
            }

            xReport?.CreateDocument();
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
