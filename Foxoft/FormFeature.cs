using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
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
   public partial class FormFeature : XtraForm
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

            TextEdit txt = new();
            txt.Name = feature.Id.ToString();
            txt.StyleController = this.layoutControl1;
            if (proFea is not null)
               txt.EditValue = proFea.FeatureDesc;
            txt.EditValueChanged += new EventHandler(this.btnEdit_DocNum_ButtonPressed);


            LayoutControlItem lCI = new();
            lCI.Control = txt;
            lCI.Name = feature.FeatureName;

            Root.Items.AddRange(new BaseLayoutItem[] { lCI });
         }
      }

      private void btnEdit_DocNum_ButtonPressed(object sender, EventArgs e)
      {
         TextEdit textEdit = sender as TextEdit;
         efMethods.UpdateDcFeature_Value(Convert.ToInt32(textEdit.Name), productCode, textEdit.EditValue.ToString());
      }
   }
}