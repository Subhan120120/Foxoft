using DevExpress.XtraEditors;
using DevExpress.XtraLayout;
using Foxoft.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Foxoft
{
   public partial class FormFeature : DevExpress.XtraEditors.XtraForm
   {
      EfMethods efMethods = new();
      string productCode;

      public FormFeature()
      {
         InitializeComponent();
      }

      public FormFeature(string productCode)
         : this()
      {
         this.productCode = productCode;
      }

      private void FormFeatureTest_Load(object sender, EventArgs e)
      {
         List<DcFeature> dcFeatures = efMethods.SelectFeatures();

         foreach (DcFeature feature in dcFeatures)
         {
            DcProductDcFeature proFea = efMethods.SelectFeature(feature.Id, productCode);

            ButtonEdit buttonEdit = new();
            buttonEdit.StyleController = this.layoutControl1;
            if (proFea is not null)
               buttonEdit.EditValue = proFea.FeatureDesc;

            LayoutControlItem lCI = new();
            lCI.Control = buttonEdit;
            lCI.Name = feature.FeatureName.ToString();

            Root.Items.AddRange(new BaseLayoutItem[] { lCI });
         }
      }
   }
}