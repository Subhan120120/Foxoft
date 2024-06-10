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
            BinaryFormatter formatter;

            settings = new LookAndFeelSettings();
            settings.SkinName = UserLookAndFeel.Default.SkinName;
            settings.Style = UserLookAndFeel.Default.Style;
            settings.UseWindowsXPTheme = UserLookAndFeel.Default.UseWindowsXPTheme;
            settings.skinPaletteName = UserLookAndFeel.Default.ActiveSvgPaletteName;

            using (stream = new MemoryStream())
            {
                formatter = new BinaryFormatter();
                //formatter.AssemblyFormat = FormatterAssemblyStyle.Simple;
#pragma warning disable SYSLIB0011
                formatter.Serialize(stream, settings);
#pragma warning restore SYSLIB0011

                //to database
                EfMethods efMethods = new();
                stream.Seek(0, SeekOrigin.Begin);
                string layoutTxt = Convert.ToBase64String(stream.ToArray());
                efMethods.UpdateCurrAccTheme(currAccCode, layoutTxt);
            }
        }

        public static void Load(string currAccCode)
        {
            EfMethods efMethods = new();
            DcCurrAcc dcCurrAcc = efMethods.SelectCurrAcc(currAccCode);
            if (!string.IsNullOrEmpty(dcCurrAcc.Theme) && !string.IsNullOrEmpty(dcCurrAcc.CurrAccCode))
            {
                if (!string.IsNullOrEmpty(dcCurrAcc.Theme))
                {
                    byte[] byteArray = Convert.FromBase64String(dcCurrAcc.Theme);
                    MemoryStream stream = new(byteArray);
                    BinaryFormatter formatter = new();
                    //formatter.AssemblyFormat = FormatterAssemblyStyle.Simple;
                    LookAndFeelSettings settings = formatter.Deserialize(stream) as LookAndFeelSettings;

                    if (settings != null)
                    {
                        UserLookAndFeel.Default.UseWindowsXPTheme = settings.UseWindowsXPTheme;
                        UserLookAndFeel.Default.Style = settings.Style;
                        UserLookAndFeel.Default.SkinName = settings.SkinName;

                        var skin = CommonSkins.GetSkin(UserLookAndFeel.Default);
                        SvgPalette fireBall = skin.CustomSvgPalettes[settings.skinPaletteName];
                        if (fireBall is not null)
                            skin.SvgPalettes[Skin.DefaultSkinPaletteName].SetCustomPalette(fireBall);
                        LookAndFeelHelper.ForceDefaultLookAndFeelChanged();
                    }
                }
            }
        }
    }
}