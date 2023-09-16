using DevExpress.Diagram.Core.Layout.Native;
using DevExpress.XtraEditors;
using Foxoft.Migrations;
using Foxoft.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Foxoft
{
    public partial class FormPriceType : XtraForm
    {
        subContext dbContext;
        EfMethods efMethods = new();
        public DcPriceType DcPriceType = new();
        private bool isNew;

        public FormPriceType(bool isNew)
        {
            InitializeComponent();

            AcceptButton = btn_Ok;
            CancelButton = btn_Cancel;

            this.isNew = isNew;
        }

        public FormPriceType(string priceTypeCode)
            : this(false)
        {
            DcPriceType.PriceTypeCode = priceTypeCode;
            ItemForPriceTypeCode.Enabled = false;
        }

        private void FormPriceType_Load(object sender, EventArgs e)
        {
            LoadPriceType();
        }

        private void LoadPriceType()
        {
            dbContext = new subContext();

            if (string.IsNullOrEmpty(DcPriceType.PriceTypeCode))
                ClearControlsAddNew();
            else
            {
                dbContext.DcPriceTypes.Where(x => x.PriceTypeCode == DcPriceType.PriceTypeCode)
                    .Load();
                bindingSource_PriceType.DataSource = dbContext.DcPriceTypes.Local.ToBindingList();
            }
        }

        private void ClearControlsAddNew()
        {
            DcPriceType = bindingSource_PriceType.AddNew() as DcPriceType;

            string NewDocNum = efMethods.GetNextDocNum(false, "PL", "PriceTypeCode", "DcPriceTypes", 4);
            DcPriceType.PriceTypeCode = NewDocNum;

            bindingSource_PriceType.DataSource = DcPriceType;
        }

        private void btn_Ok_Click(object sender, EventArgs e)
        {
            if (dataLayoutControl1.IsValid(out List<string> errorList))
            {
                DcPriceType = bindingSource_PriceType.Current as DcPriceType;
                if (isNew) //if invoiceHeader doesnt exist
                    if (!efMethods.PriceTypeExist(DcPriceType.PriceTypeCode))
                        efMethods.InsertFeature(DcPriceType);
                    else
                        MessageBox.Show("Bu Kodda Məhsul Artıq Mövcuddur!");
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
