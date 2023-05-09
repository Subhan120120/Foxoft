using DevExpress.Export;
using DevExpress.XtraEditors;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace Foxoft
{
   static class Program
   {
      [STAThread]
      static void Main()
      {         
         string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Foxoft Log");
         if (!Directory.Exists(path))
            Directory.CreateDirectory(path);
         string fileName = DateTime.Now.ToString("yyyyMMddHHmmss") + ".txt";
         Stream myFile = File.Create(Path.Combine(path, fileName));
         
         TextWriterTraceListener myTextListener = new(myFile);
         Trace.Listeners.Add(myTextListener);

         Trace.Write("Program Started \n Initializing custom settings...");
         Trace.Flush();

         CultureInfo culture = CultureInfo.CreateSpecificCulture("tr-TR");
         Thread.CurrentThread.CurrentUICulture = culture;
         //Thread.CurrentThread.CurrentCulture = culture;
         //CultureInfo.DefaultThreadCurrentCulture = culture;
         CultureInfo.DefaultThreadCurrentUICulture = culture;

         ExportSettings.DefaultExportType = ExportType.WYSIWYG;
         WindowsFormsSettings.DefaultFont = new Font("Tahoma", 10);
         Application.EnableVisualStyles();
         Application.SetCompatibleTextRenderingDefault(false);

         Trace.Write("Initialized custom settings \n Running FormLogin... ");
         Trace.Flush();
         Application.Run(new FormLogin());
      }
   }
}
