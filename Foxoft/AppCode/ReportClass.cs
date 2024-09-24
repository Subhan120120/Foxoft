using DevExpress.DataAccess.ConnectionParameters;
using DevExpress.DataAccess.DataFederation;
using DevExpress.DataAccess.Sql;
using DevExpress.Mvvm.POCO;
using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;
using Foxoft.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Windows.Forms;

namespace Foxoft
{
    class ReportClass
    {
        EfMethods efMethods = new();

        private string subConnString = Properties.Settings.Default.SubConnString;

        public string SelectDesign()
        {
            string fileExt = string.Empty;
            OpenFileDialog file = new();
            file.InitialDirectory = efMethods.SelectSettingStore(Authorization.StoreCode).DesignFileFolder;
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
            SettingStore settingStore = efMethods.SelectSettingStore(Authorization.StoreCode);

            string designPath = string.Empty;
            if (settingStore is not null)
                if (CustomExtensions.DirectoryExist(settingStore.DesignFileFolder))
                    designPath = settingStore.DesignFileFolder + @"\" + repxFileName;

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
    }
}
