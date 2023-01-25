using DevExpress.Export;
using DevExpress.XtraEditors;
using Foxoft.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Drawing;
using System.Globalization;
using System.IO;
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
         CultureInfo culture = CultureInfo.CreateSpecificCulture("tr-TR");
         Thread.CurrentThread.CurrentUICulture = culture;
         //Thread.CurrentThread.CurrentCulture = culture;
         //CultureInfo.DefaultThreadCurrentCulture = culture;
         //CultureInfo.DefaultThreadCurrentUICulture = culture;

         ExportSettings.DefaultExportType = ExportType.WYSIWYG;
         WindowsFormsSettings.DefaultFont = new Font("Tahoma", 10);
         //DevExpress.UserSkins.BonusSkins.Register();
         Application.EnableVisualStyles();
         Application.SetCompatibleTextRenderingDefault(false);

         Application.Run(new FormLogin());
      }
   }
}
