using DevExpress.Map.Kml.Model;
using DevExpress.XtraEditors;
using Foxoft.Models;
using Microsoft.EntityFrameworkCore;
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
        subContext dbContext;
        EfMethods efMethods = new();
        public DcFeature DcFeature = new();
        private bool isNew;

        public FormFeature(int featureTypeId, bool isNew)
        {
            InitializeComponent();

            AcceptButton = btn_Ok;
            CancelButton = btn_Cancel;

            this.isNew = isNew;
            DcFeature.FeatureTypeId = featureTypeId;
        }

        public FormFeature(int featureTypeId, string featureCode)
            : this(featureTypeId, false)
        {
            DcFeature.FeatureCode = featureCode;
            FeatureCode.Enabled = false;
        }

        private void FormFeature_Load(object sender, EventArgs e)
        {
            LoadFeature();
        }

        private void LoadFeature()
        {
            dbContext = new subContext();

            if (string.IsNullOrEmpty(DcFeature.FeatureCode))
                ClearControlsAddNew();
            else
            {
                dbContext.DcFeatures.Where(x => x.FeatureCode == DcFeature.FeatureCode)
                    .Load();
                bindingSource_feature.DataSource = dbContext.DcFeatures.Local.ToBindingList();
            }
        }

        private void ClearControlsAddNew()
        {
            int temp = DcFeature.FeatureTypeId;
            DcFeature = bindingSource_feature.AddNew() as DcFeature;
            DcFeature.FeatureTypeId = temp;

            string NewDocNum = efMethods.GetNextDocNum(false, "F", "FeatureCode", "DcFeatures", 4);
            DcFeature.FeatureCode = NewDocNum;

            bindingSource_feature.DataSource = DcFeature;
        }

        private void btn_Ok_Click(object sender, EventArgs e)
        {
            if (dataLayoutControl1.IsValid(out List<string> errorList))
            {
                DcFeature = bindingSource_feature.Current as DcFeature;
                if (isNew) //if invoiceHeader doesnt exist
                    if (!efMethods.FeatureExist(DcFeature.FeatureCode, DcFeature.FeatureTypeId))
                        efMethods.InsertFeature(DcFeature);
                    else
                        MessageBox.Show("Bu kodda özəllik artıq mövcuddur.");
                else
                    dbContext.SaveChanges();

                //SaveImage();

                DialogResult = DialogResult.OK;
            }
            else
            {
                string combinedString = errorList.Aggregate((x, y) => x + "" + y);
                XtraMessageBox.Show(combinedString);
            }
        }
    }
}
