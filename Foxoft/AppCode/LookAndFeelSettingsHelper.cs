using DevExpress.LookAndFeel;
using DevExpress.Skins;
using DevExpress.Utils.Svg;
using Foxoft.Models;
using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace Foxoft.AppCode
{

    [DesignerCategory("")]

    public class LookAndFeelSettingsHelper : Component
    {

        public LookAndFeelSettingsHelper()
        {
            RestoreSettings();
            Application.ApplicationExit += Application_ApplicationExit;
        }

        // Fields...
        private string _FileName;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public string FileName
        {
            get { return string.IsNullOrEmpty(_FileName) ? "LookAndFeelSettings.save" : _FileName; }
            set
            {
                _FileName = value;
            }
        }


        void Application_ApplicationExit(object sender, EventArgs e)
        {
            SaveSettings();
        }


        private void SaveSettings()
        {
            Save(FileName);
        }

        private void RestoreSettings()
        {
            Load(FileName);
        }

        public static void Save(string currAccCode)
        {
            MemoryStream stream;
            LookAndFeelSettings settings;

            settings = new LookAndFeelSettings();
            settings.SkinName = UserLookAndFeel.Default.SkinName;
            settings.Style = UserLookAndFeel.Default.Style;
            settings.UseWindowsXPTheme = UserLookAndFeel.Default.UseWindowsXPTheme;
            settings.skinPaletteName = UserLookAndFeel.Default.ActiveSvgPaletteName;

            using (stream = new MemoryStream())
            {
#pragma warning disable SYSLIB0011
                BinaryFormatter formatter;
                formatter = new BinaryFormatter();
                //formatter.AssemblyFormat = FormatterAssemblyStyle.Simple;
                formatter.Serialize(stream, settings);
#pragma warning restore SYSLIB0011

                //to database
                EfMethods efMethods = new();
                stream.Seek(0, SeekOrigin.Begin);
                string layoutTxt = Convert.ToBase64String(stream.ToArray());
                if (efMethods.MainUserExist(currAccCode))
                {
                    efMethods.UpdateMainUserTheme(currAccCode, layoutTxt);
                }
                else
                {
                    efMethods.UpdateCurrAccTheme(currAccCode, layoutTxt);
                }
            }
        }

        public static void Load(string currAccCode)
        {
            if (string.IsNullOrWhiteSpace(currAccCode))
                return;

            EfMethods efMethods = new();
            string? theme = null;

            DcUser? mainUser = efMethods.SelectMainUser(currAccCode);
            if (mainUser != null && !string.IsNullOrEmpty(mainUser.Theme))
            {
                theme = mainUser.Theme;
            }
            else
            {
                DcCurrAcc? dcCurrAcc = efMethods.SelectCurrAcc(currAccCode);
                if (dcCurrAcc != null && !string.IsNullOrEmpty(dcCurrAcc.Theme))
                {
                    theme = dcCurrAcc.Theme;
                }
            }

            if (!string.IsNullOrEmpty(theme))
            {
                try
                {
                    byte[] byteArray = Convert.FromBase64String(theme);
                    MemoryStream stream = new(byteArray);
#pragma warning disable SYSLIB0011
                    BinaryFormatter formatter = new();
                    //formatter.AssemblyFormat = FormatterAssemblyStyle.Simple;
                    LookAndFeelSettings settings = formatter.Deserialize(stream) as LookAndFeelSettings;
#pragma warning restore SYSLIB0011

                    if (settings != null)
                    {
                        UserLookAndFeel.Default.UseWindowsXPTheme = settings.UseWindowsXPTheme;
                        UserLookAndFeel.Default.Style = settings.Style;
                        UserLookAndFeel.Default.SkinName = settings.SkinName;

                        var skin = CommonSkins.GetSkin(UserLookAndFeel.Default);
                        if (!string.IsNullOrEmpty(settings.skinPaletteName))
                        {
                            try
                            {
                                SvgPalette fireBall = skin.CustomSvgPalettes[settings.skinPaletteName];
                                if (fireBall is not null)
                                    skin.SvgPalettes[Skin.DefaultSkinPaletteName]?.SetCustomPalette(fireBall);
                            }
                            catch
                            {
                                // Ignore missing custom palette
                            }
                        }
                        LookAndFeelHelper.ForceDefaultLookAndFeelChanged();
                    }
                }
                catch
                {
                    // Safe fallback if theme payload is invalid
                }
            }
        }
    }
}