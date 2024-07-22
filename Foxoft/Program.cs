using DevExpress.Export;
using DevExpress.XtraEditors;
using DevExpress.XtraRichEdit.Import.Html;
using DevExpress.XtraSplashScreen;
using Foxoft.AppCode;
using Foxoft.Models;
using Foxoft.Properties;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Win32;
using System;
using Microsoft.Data.SqlClient;
using System.Diagnostics;
using System.DirectoryServices.ActiveDirectory;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;

namespace Foxoft
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            EfMethods efMethods = new();

            SplashScreenManager.ShowForm(typeof(SplashScreenStartup));

            CultureInfo culture = CultureInfo.CreateSpecificCulture("tr-TR");
            Thread.CurrentThread.CurrentUICulture = culture;
            Thread.CurrentThread.CurrentCulture = culture;//
            CultureInfo.DefaultThreadCurrentCulture = culture;//
            CultureInfo.DefaultThreadCurrentUICulture = culture;

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
                        XtraMessageBox.Show($"Server ilə əlaqə qurula bilmir. \nConnection string: \n{builder.ConnectionString} \nError: {ex.Message}", "Diqqət");
                        return false;
                    }
                }
            }

            bool UpdateLicense()
            {
                if (!CheckForInternetConnection(1000, "http://www.google.com"))
                    return false;

                //string url = @"https://drive.usercontent.google.com/download?id=1NCnJoEonMjtzxIaM3n5x5ppC3DlvpLCu&export=download&authuser=0&confirm=t&uuid=10ba17da-5c80-445b-8974-62f562889c84&at=APZUnTUKwjTq71SBFZ5uIwBa1UWI:1717941152672";
                //using (HttpClient client = new() { Timeout = TimeSpan.FromMilliseconds(2000) })
                //using (HttpResponseMessage response = client.GetAsync(url).Result)
                //    result = response.IsSuccessStatusCode ? response.Content.ReadAsStringAsync().Result : null;

                GoogleDriveAPI googleDriveAPI = new();
                string result = googleDriveAPI.Drive();

                string[] txtLisence = result.Split(new string[] { " ", "\r\n", "\r", "\n" }, StringSplitOptions.None);

                if (txtLisence is not null)
                {
                    for (int i = 0; i < txtLisence.Length; i = i + 3)
                    {
                        string databaseName = txtLisence[i + 0];
                        string localAddress = txtLisence[i + 1];
                        string date = txtLisence[i + 2];

                        if (localAddress == GetPhiscalAdress())
                        {
                            string license = databaseName + "+" + localAddress + "+" + date;
                            string key = "FoxoftIsTheBestP";
                            string iv = "ThisIsAnInitVect";

                            CustomMethods cM = new();
                            string encrypt = cM.EncryptString(license, key, iv);

                            List<DcCompany> companies = efMethods.SelectCompanies();

                            foreach (DcCompany company in companies)
                            {
                                if (company.CompanyDesc == databaseName)
                                {
                                    efMethods.UpdateAppSettingLicense(encrypt, company.CompanyDesc);
                                }
                            }
                        }
                    }

                    return true;
                }
                else
                    return false;
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

            string GetPhiscalAdress()
            {
                string fiscal = String.Empty;
                foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
                {
                    PhysicalAddress pInterfaceProperties = nic.GetPhysicalAddress();

                    if (nic.NetworkInterfaceType == NetworkInterfaceType.Ethernet && nic.Name.StartsWith("Ethernet"))
                        fiscal = nic.Id + pInterfaceProperties;
                }

                return fiscal;
            }

            //void RegistryWriteValue(string keyName, string valueName, object value)
            //{
            //    using (RegistryKey key = Registry.LocalMachine.CreateSubKey(keyName))
            //    {
            //        if (key != null)
            //        {
            //            key.SetValue(valueName, value);
            //        }
            //    }
            //}
        }
    }
}
