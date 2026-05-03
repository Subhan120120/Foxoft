using DevExpress.DataAccess.Excel;
using DevExpress.Export;
using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;
using Foxoft.AppCode;
using Foxoft.Models;
using Foxoft.Properties;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Net;

namespace Foxoft
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            EfMethods efMethods = new();

            SplashScreenManager.ShowForm(typeof(SplashScreenStartup));

            //if (Debugger.IsAttached)
            //{
            //    Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("en-US");
            //    CultureInfo.DefaultThreadCurrentUICulture = CultureInfo.GetCultureInfo("en-US");
            //}

            ExportSettings.DefaultExportType = ExportType.WYSIWYG;
            WindowsFormsSettings.DefaultFont = new Font("Tahoma", 10);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //if (!Debugger.IsAttached)
            //    RegistryWriteValue(@"SOFTWARE\Foxoft", "InstallLocation", AppContext.BaseDirectory); // for service

            if (SqlServerConnected())
            {
                mainContext mainDb = new();
                if (!mainDb.Database.CanConnect())
                    mainDb.Database.EnsureCreated();

                subContext subDb = new();
                if (subDb.Database.CanConnect())
                {
                    //db.Database.Migrate();
                    //string sql = db.Database.GenerateCreateScript();

                    UpdateLicense();

                    SplashScreenManager.CloseForm();
                    Application.Run(new FormLogin());
                }
                else
                {
                    SplashScreenManager.CloseForm();
                    Application.Run(new FormConnectionStringBuilder(subDb.Database.GetConnectionString()));
                }
            }

            bool SqlServerConnected()
            {
                string connString = Settings.Default.MainConnString;

                SqlConnectionStringBuilder builder = new(connString);
                builder.InitialCatalog = string.Empty;

                DbContextOptionsBuilder<subContext> optionsBuilder = new();
                optionsBuilder.UseSqlServer(builder.ConnectionString);

                using (subContext db = new(optionsBuilder.Options))
                {
                    try
                    {
                        db.Database.OpenConnection();
                        db.Database.CloseConnection();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show(
                            string.Format(
                                Resources.Message_ServerConnectionError,
                                builder.ConnectionString,
                                ex.Message),
                            Resources.Common_Attention);

                        return false;
                    }
                }
            }

            bool UpdateLicense()
            {
                if (!CheckForInternetConnection(1000, "http://www.google.com"))
                    return false;

                using GoogleDriveAPI googleDriveAPI = new();
                using MemoryStream excelStream = googleDriveAPI.DownloadAsStream("1F_FHrpN3eLC1jfXXHmxQklttwq-P8v1v");

                ExcelDataSource excelDataSource = new();
                excelDataSource.Stream = excelStream;
                excelDataSource.StreamDocumentFormat = ExcelDocumentFormat.Xlsx;

                ExcelWorksheetSettings worksheetSettings = new(0);

                ExcelSourceOptions excelOptions = new();
                excelOptions.ImportSettings = worksheetSettings;
                excelOptions.UseFirstRowAsHeader = true;
                excelOptions.SkipHiddenRows = false;
                excelOptions.SkipHiddenColumns = false;

                excelDataSource.SourceOptions = excelOptions;
                excelDataSource.Fill();

                IList list = ((IListSource)excelDataSource).GetList();

                if (list == null || list.Count == 0)
                    return false;

                DevExpress.DataAccess.Native.Excel.DataView dataView = (DevExpress.DataAccess.Native.Excel.DataView)list;
                List<PropertyDescriptor> props = dataView.Columns.ToList<PropertyDescriptor>();

                int companyCodeIndex = props.FindIndex(p => string.Equals(p.Name, "CompanyCode", StringComparison.OrdinalIgnoreCase));
                int licenseIndex = props.FindIndex(p => string.Equals(p.Name, "License", StringComparison.OrdinalIgnoreCase));
                int dueDateIndex = props.FindIndex(p => string.Equals(p.Name, "DueDate", StringComparison.OrdinalIgnoreCase));

                if (companyCodeIndex == -1 || licenseIndex == -1 || dueDateIndex == -1)
                    return false;

                List<DcCompany> companies = efMethods.SelectCompanies();

                foreach (DevExpress.DataAccess.Native.Excel.ViewRow row in list)
                {
                    string companyCode = props[companyCodeIndex].GetValue(row)?.ToString()?.Trim() ?? string.Empty;
                    string license = props[licenseIndex].GetValue(row)?.ToString()?.Trim() ?? string.Empty;
                    string dueDate = props[dueDateIndex].GetValue(row)?.ToString()?.Trim() ?? string.Empty;

                    if (string.IsNullOrEmpty(companyCode) || string.IsNullOrEmpty(license) || string.IsNullOrEmpty(dueDate))
                        continue;

                    if (license == CustomExtensions.GetPhiscalAdress())
                    {
                        string licenseString = companyCode + "+" + license + "+" + dueDate;
                        string key = "FoxoftIsTheBestP";
                        string iv = "ThisIsAnInitVect";

                        CustomMethods cM = new();
                        string encrypt = cM.EncryptString(licenseString, key, iv);

                        foreach (DcCompany company in companies)
                        {
                            if (company.CompanyCode == companyCode)
                            {
                                efMethods.UpdateAppSettingLicense(encrypt, company.CompanyCode);
                            }
                        }
                    }
                }

                return true;
            }

            bool CheckForInternetConnection(int timeoutMs = 10000, string url = null)
            {
                try
                {
                    var request = (HttpWebRequest)WebRequest.Create(url);
                    request.KeepAlive = false;
                    request.Timeout = timeoutMs;
                    using (var response = (HttpWebResponse)request.GetResponse())
                        return true;
                }
                catch
                {
                    return false;
                }
            }

        }
    }
}
