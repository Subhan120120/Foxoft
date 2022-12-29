using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraLayout;
using Foxoft.Models;
using System;
using System.Collections.Generic;

namespace Foxoft
{
   public partial class FormFeature : XtraForm
   {
      EfMethods efMethods = new EfMethods();
      string productCode;

      public FormFeature()
      {
         InitializeComponent();
      }

      public FormFeature(string productCode)
      {
         this.productCode = productCode;
      }

      private void FormFeature_Load(object sender, EventArgs e)
      {
         List<DcFeature> dcFeatures = efMethods.SelectFeatures();

         foreach (DcFeature feature in dcFeatures)
         {
            //DcProductDcFeature proFea = efMethods.SelectFeature(feature.Id, productCode);

            ButtonEdit buttonEdit = new();
            //buttonEdit.EditValue = proFea.FeatureDesc;
            buttonEdit.StyleController = this.layoutControl1;

            LayoutControlItem layoutControlItem = new();
            layoutControlItem.Control = buttonEdit;
            layoutControlItem.Name = feature.FeatureName.ToString();

            Root.Items.AddRange(new BaseLayoutItem[] { layoutControlItem });
         }
      }

      //private void FormFeature_Load(object sender, EventArgs e)
      //{
      //   List<DcFeature> dcFeatures = efMethods.SelectFeatures();

      //   foreach (DcFeature feature in dcFeatures)
      //   {
      //      DcProductDcFeature proFea = efMethods.SelectFeature(feature.Id, productCode);

      //      ButtonEdit buttonEdit = new();
      //      buttonEdit.EditValue = proFea.FeatureDesc;
      //      buttonEdit.StyleController = this.layoutControl1;

      //      LayoutControlItem layoutControlItem = new();
      //      layoutControlItem.Control = buttonEdit;
      //      layoutControlItem.Name = feature.FeatureName.ToString();

      //      Root.Items.AddRange(new BaseLayoutItem[] { layoutControlItem });
      //   }
      //}
   }
}