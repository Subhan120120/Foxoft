using DevExpress.XtraSplashScreen;
using Foxoft.Properties;
using System;
using System.Windows.Forms;

namespace Foxoft
{
    public partial class SplashScreenStartup : SplashScreen
    {
        public SplashScreenStartup()
        {
            InitializeComponent();

            // Localized text assignments
        }

        #region Overrides
        public override void ProcessCommand(Enum cmd, object arg)
        {
            base.ProcessCommand(cmd, arg);
        }
        #endregion

        public enum SplashScreenCommand
        {
        }
    }
}
