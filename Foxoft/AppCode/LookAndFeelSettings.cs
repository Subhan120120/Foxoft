
using System;
using System.Collections.Generic;
using DevExpress.LookAndFeel;

namespace Foxoft.AppCode
{
   [Serializable]
   public class LookAndFeelSettings
   {
      public string SkinName;
      public LookAndFeelStyle Style;
      public bool UseWindowsXPTheme;
      public string skinPaletteName;

      public LookAndFeelSettings()
      {

      }
   }
}