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
   public partial class FormFeatures : DevExpress.XtraEditors.XtraForm
   {
      EfMethods efMethods = new EfMethods();
      string productCode;

      public FormFeatures()
      {
         InitializeComponent();
      }

      public FormFeatures(string productCode)
      {
         this.productCode = productCode;


      }

      private void FormFeatures_Load(object sender, EventArgs e)
      {
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
   }
}