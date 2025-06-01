using DevExpress.XtraEditors;
using DevExpress.XtraEditors.DXErrorProvider;
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
    public partial class FormProductScales : DevExpress.XtraEditors.XtraForm
    {
        subContext dbContext;
        DcProductScale dcProductScale;
        DcProduct dcProduct;
        EfMethods efMethods = new EfMethods();
        public FormProductScales()
        {
            InitializeComponent();
        }
        public FormProductScales(DcProduct dcProduct)
            : this()
        {
            this.dcProduct = dcProduct;
        }

        private void FormProductScales_Load(object sender, EventArgs e)
        {
            LoadProductcale();
        }

        private void LoadProductcale()
        {
            dbContext = new subContext();

            if (!efMethods.ProductScaleExist(dcProduct.ProductCode))
                ClearControlsAddNew();
            else
            {
                dbContext.DcProductScales.Where(x => x.ProductCode == dcProduct.ProductCode)
                .Load();

                dcProductScaleBindingSource.DataSource = dbContext.DcProductScales.Local.ToBindingList();
            }
        }

        private void ClearControlsAddNew()
        {
            dcProductScale = dcProductScaleBindingSource.AddNew() as DcProductScale;

            dcProductScale.ProductCode = dcProduct.ProductCode;

            dcProductScaleBindingSource.DataSource = dcProductScale;
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            dcProductScale = dcProductScaleBindingSource.Current as DcProductScale;

            if (string.IsNullOrEmpty(dcProductScale.ScaleProductNumber.ToString()))
            {
                efMethods.DeleteEntity(dcProductScale);
                return;
            }

            if (dcProductScale.Id == 0)
                efMethods.InsertEntity(dcProductScale);
            else
                dbContext.SaveChanges();

            DialogResult = DialogResult.OK;
        }

        private void TextEdit_ScaleProductNumber_Validating(object sender, CancelEventArgs e)
        {
            var editor = sender as TextEdit;
            string inputValue = editor.Text;

            if (string.IsNullOrWhiteSpace(inputValue))
                return;

            if (!int.TryParse(inputValue, out int scaleProductNumber))
            {
                e.Cancel = true;
                dxErrorProvider1.SetError(editor, "Ədəd daxil edin.");
                return;
            }

            bool isDuplicate = dbContext.DcProductScales
                .Any(x => x.ScaleProductNumber == scaleProductNumber
                       && x.ProductCode != dcProduct.ProductCode); // optionally exclude current product

            if (isDuplicate)
            {
                e.Cancel = true;
                dxErrorProvider1.SetError(editor, "Bu kod istifadə olunub. Təkrarsız ədəd daxil edin.");
            }
            else
            {
                dxErrorProvider1.SetError(editor, string.Empty); // clear error
            }
        }

    }
}