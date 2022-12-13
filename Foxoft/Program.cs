using DevExpress.LookAndFeel;
using DevExpress.Skins;
using DevExpress.UserSkins;
using DevExpress.XtraEditors;
using Foxoft.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;

namespace Foxoft
{
   static class Program
   {
      /// <summary>
      /// The main entry point for the application.
      /// </summary>
      [STAThread]
      static void Main()
      {
         using (subContext db = new())
         {
            db.Database.EnsureCreated();
            string con = db.Database.GetDbConnection().ConnectionString;
            db.Database.Migrate();

            //string sql = db.Database.GenerateCreateScript();

            //IRelationalDatabaseCreator databaseCreator = db.GetService<IRelationalDatabaseCreator>();
            //databaseCreator.CreateTables();

            CreateViews(new DatabaseFacade(db));
         }

         DevExpress.Export.ExportSettings.DefaultExportType = DevExpress.Export.ExportType.WYSIWYG;

         CultureInfo culture = CultureInfo.CreateSpecificCulture("tr-TR");
         Thread.CurrentThread.CurrentUICulture = culture;
         //Thread.CurrentThread.CurrentCulture = culture;
         //CultureInfo.DefaultThreadCurrentCulture = culture;
         //CultureInfo.DefaultThreadCurrentUICulture = culture;

         WindowsFormsSettings.DefaultFont = new System.Drawing.Font("Tahoma", 10);
         Application.EnableVisualStyles();
         Application.SetCompatibleTextRenderingDefault(false);

         Application.Run(new FormLogin());
      }

      private static void CreateViews(DatabaseFacade db)
      {
         InjectView(db, "View_RetailSales.sql", "RetailSales");
         InjectView(db, "View_AllPayments.sql", "AllPayments");
         InjectView(db, "View_Transactions.sql", "Transactions");
      }

      private static void InjectView(DatabaseFacade db, string sqlFileName, string viewName)
      {
         Assembly assembly = typeof(Program).Assembly;
         string assemblyName = assembly.FullName.Substring(0, assembly.FullName.IndexOf(','));
         string path = assemblyName + ".AppCode.SqlQuery" + "." + sqlFileName;
         Stream stream = assembly.GetManifestResourceStream(path);
         var sqlQuery = new StreamReader(stream).ReadToEnd();

         db.ExecuteSqlRaw($"IF OBJECT_ID('{viewName}') IS NOT NULL BEGIN DROP VIEW {viewName} END");
         db.ExecuteSqlRaw($"CREATE VIEW {viewName} AS {sqlQuery}");
      }
   }
}
