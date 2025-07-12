using DevExpress.Data.Filtering;
using DevExpress.DataAccess.ConnectionParameters;
using DevExpress.DataAccess.DataFederation;
using DevExpress.DataAccess.Sql;
using DevExpress.Mvvm.POCO;
using DevExpress.XtraEditors;
using DevExpress.XtraReports;
using DevExpress.XtraReports.UI;
using Foxoft.Models;
using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace Foxoft
{
    class ReportClass
    {
        EfMethods efMethods = new();

        string designFolder;
        private string subConnString = Properties.Settings.Default.SubConnString;

        public ReportClass(string designFolder)
        {
            this.designFolder = designFolder;
        }

        public string SelectDesign()
        {
            string fileExt = string.Empty;
            OpenFileDialog file = new();
            file.InitialDirectory = designFolder;
            if (file.ShowDialog() == DialogResult.OK)
            {
                fileExt = Path.GetExtension(file.FileName);
                if (fileExt.CompareTo(".repx") == 0)
                    return file.FileName;
                else
                {
                    XtraMessageBox.Show("Yalnız .repx fayl seçə bilərsiniz", "Diqqət", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return "";
                }
            }
            else
                return "";
        }

        public XtraReport CreateReport(object datasource, string repxFileName)
        {
            string designPath = string.Empty;
            if (!string.IsNullOrEmpty(designFolder))
                if (CustomExtensions.DirectoryExist(designFolder))
                    designPath = designFolder + @"\" + repxFileName;

            if (!File.Exists(designPath))
                designPath = SelectDesign();
            if (File.Exists(designPath))
            {
                XtraReport report = new();
                report.LoadLayoutFromXml(designPath);

                report.DataSource = datasource;
                report.ShowPrintMarginsWarning = false;

                return report;
            }
            else
            {
                return null;
            }
        }

        public XtraReport GetReport(string dataSourceName, string repxFileName, IEnumerable<SqlQuery> sqlQueries)
        {
            using (SqlDataSource dataSource = new(new CustomStringConnectionParameters(subConnString)))
            {
                dataSource.Name = dataSourceName;
                dataSource.Queries.AddRange(sqlQueries);
                dataSource.Fill();

                return CreateReport(dataSource, repxFileName);
            }
        }

        public void ShowReport(DcReport dcReport, string filter, Form parent = null)
        {
            //string filter = CriteriaToWhereClauseHelper.GetMsSqlWhere(filterControl_Outer.FilterCriteria);
            switch (dcReport.ReportTypeId)
            {
                case 1: OpenGridReport(dcReport, filter, parent); break;
                case 2: OpenDetailReport(dcReport, filter, parent); break;
                default: OpenGridReport(dcReport, filter, parent); break;
            }
        }

        private void OpenGridReport(DcReport dcReport, string filter, Form parent = null)
        {
            try
            {
                FormReportGrid myform = new(dcReport.ReportQuery, filter, dcReport);

                myform.MdiParent = parent;
                myform.Show();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString());
            }
        }

        private void OpenDetailReport(DcReport dcReport, string filter, Form parent = null)
        {
            if (!string.IsNullOrEmpty(dcReport.ReportQuery))
            {
                FormReportPreview frm = new(dcReport.ReportQuery, filter, dcReport);
                frm.MdiParent = parent;
                frm.Show();
                frm.WindowState = FormWindowState.Maximized;
                //this.ParentForm.parentRibbonControl.SelectedPage = parentRibbonControl.MergedPages[0];
            }
        }

    }
}
