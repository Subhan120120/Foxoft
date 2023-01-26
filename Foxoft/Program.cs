using DevExpress.Export;
using DevExpress.XtraEditors;
using Foxoft.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Diagnostics;
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
         string path = Path.Combine(Environment.CurrentDirectory, "Log");
         if (!Directory.Exists(path))
            Directory.CreateDirectory(path);
         Stream myFile = File.Create(Path.Combine(path, DateTime.Now.ToShortDateString() + " - " + Process.GetCurrentProcess().Id.ToString() + " - " + "Program.cs.txt"));

         /* Create a new text writer using the output stream, and add it to the trace listeners. */
         TextWriterTraceListener myTextListener = new(myFile);
         Trace.Listeners.Add(myTextListener);

         // Write output to the file.
         Trace.Write("Program Started \n Initializing custom settings...");
         Trace.Flush();
         // Flush the output.

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

         Trace.Write("Initialized custom settings \n Running FormLogin... ");
         Trace.Flush();
         Application.Run(new FormLogin());
      }
   }
}
