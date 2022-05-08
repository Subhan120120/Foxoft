using DevExpress.LookAndFeel;
using DevExpress.Skins;
using DevExpress.UserSkins;
using DevExpress.XtraEditors;
using Foxoft.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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
            WindowsFormsSettings.DefaultFont = new System.Drawing.Font("Tahoma", 10);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            EfMethods efMethods = new EfMethods();
            AppSetting appSetting = efMethods.SelectAppSetting();
            Properties.Settings.Default.AppSetting = appSetting;
            Application.Run(new FormLogin());
        }
    }
}
