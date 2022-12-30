using DevExpress.XtraEditors;
using DevExpress.XtraLayout;
using Foxoft.Models;
using System;
using System.Collections.Generic;

namespace Foxoft
{
   public partial class FormFeatures : XtraForm
   {
      EfMethods efMethods = new();
      string productCode;

      public FormFeatures()
      {
         InitializeComponent();

         
      }

      public FormFeatures(string productCode)
      {
         this.productCode = productCode;

         List<DcFeature> dcFeatures = efMethods.SelectFeatures();

         foreach (DcFeature feature in dcFeatures)
         {
            DcProductDcFeature proFea = efMethods.SelectFeature(feature.Id, productCode);

            if (proFea is not null)
            {
               ButtonEdit buttonEdit = new();
               buttonEdit.EditValue = proFea.FeatureDesc;
               buttonEdit.StyleController = this.layoutControl1;

               LayoutControlItem layoutControlItem = new();
               layoutControlItem.Control = buttonEdit;
               layoutControlItem.Name = feature.FeatureName.ToString();

               Root.Items.AddRange(new BaseLayoutItem[] { layoutControlItem });
            }
         }
      }

      private void FormFeatures_Load(object sender, EventArgs e)
      {
         
      }
   }
}