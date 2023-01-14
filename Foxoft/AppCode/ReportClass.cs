using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;
using System.IO;
using System.Windows.Forms;

namespace Foxoft
{
   class ReportClass
   {
      EfMethods efMethods = new EfMethods();
      public string SelectDesign()
      {
         string fileExt = string.Empty;
         OpenFileDialog file = new();
         file.InitialDirectory = efMethods.SelectSettingStore(Authorization.StoreCode).DesignFileFolder;
         if (file.ShowDialog() == DialogResult.OK)
         {
            fileExt = Path.GetExtension(file.FileName);
            if (fileExt.CompareTo(".repx") == 0)
            {
               return file.FileName;
            }
            else
            {
               XtraMessageBox.Show("Yalnız .repx fayl seçə bilərsiniz", "Diqqət", MessageBoxButtons.OK, MessageBoxIcon.Error);
               return "";
            }
         }
         else
            return "";
      }

      public XtraReport CreateReport(object Datasource, string reportFilePath)
      {
         XtraReport report = new();

         report.LoadLayoutFromXml(reportFilePath);

         //string styleSheetFilePath = @"C:\Temp\ReportStyleSheet1.repss";
         //if (File.Exists(styleSheetFilePath))
         //    report.StyleSheet.LoadFromXml(styleSheetFilePath);
         //else
         //    XtraMessageBox.Show("The source file does not exist.");

         report.DataSource = Datasource;
         report.ShowPrintMarginsWarning = false;

         return report;
      }
   }
}
