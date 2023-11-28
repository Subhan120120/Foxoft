
using DevExpress.Utils.Extensions;
using DevExpress.XtraDataLayout;
using DevExpress.XtraEditors;
using Foxoft.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Foxoft
{
    public partial class FormProduct : XtraForm
    {
        subContext dbContext = new();
        EfMethods efMethods = new();
        string imageFolder;
        public DcProduct dcProduct = new();
        private byte productTypeCode;
        private bool isNew;

        public FormProduct(byte productTypeCode, bool isNew)
        {
            InitializeComponent();

            tabbedControlGroup1.SelectedTabPage = autoGroupForQiymətlər;

            InitializeControlText();

            this.productTypeCode = productTypeCode;
            this.isNew = isNew;

            if (!isNew)
                btn_ProductDiscount.Enabled = true;

            SettingStore settingStore = efMethods.SelectSettingStore(Authorization.StoreCode);
            if (CustomExtensions.DirectoryExist(settingStore.ImageFolder))
                imageFolder = settingStore.ImageFolder;

            ProductTypeCodeLookUpEdit.Properties.DataSource = efMethods.SelectProductTypes();
            ProductTypeCodeLookUpEdit.Properties.ValueMember = "ProductTypeCode";
            ProductTypeCodeLookUpEdit.Properties.DisplayMember = "ProductTypeDesc";

            AcceptButton = btn_Ok;
            CancelButton = btn_Cancel;
        }

        private void InitializeControlText()
        {
            layoutControlItem6.Name = ReflectionExtensions.GetPropertyDisplayName<SiteProduct>(x => x.Price);
            layoutControlItem7.Name = ReflectionExtensions.GetPropertyDisplayName<SiteProduct>(x => x.Desc);
            layoutControlItem11.Name = ReflectionExtensions.GetPropertyDisplayName<SiteProduct>(x => x.Slug);
            layoutControlItem9.Name = ReflectionExtensions.GetPropertyDisplayName<SiteProduct>(x => x.Rating);
        }

        public FormProduct(byte productTypeCode, string productCode)
            : this(productTypeCode, false)
        {
            this.dcProduct.ProductCode = productCode;
            ItemForProductCode.Enabled = false;
        }

        private void FormProduct_Load(object sender, EventArgs e)
        {
            FillDataLayout();
            dataLayoutControl1.IsValid(out List<string> errorList);
        }

        private void FillDataLayout()
        {
            dbContext = new subContext();

            if (string.IsNullOrEmpty(dcProduct.ProductCode))
                ClearControlsAddNew();
            else
            {
                //dbContext.DcCurrAccs.Where(x => x.CurrAccCode == dcCurrAcc.CurrAccCode)
                //                    .LoadAsync()
                //                    .ContinueWith(loadTask => dcCurrAccsBindingSource.DataSource = dbContext.DcCurrAccs.Local.ToBindingList(), TaskScheduler.FromCurrentSynchronizationContext());

                dbContext.DcProducts.Where(x => x.ProductCode == dcProduct.ProductCode)
                                    .Include(x => x.DcProductType)
                                    .Include(x => x.TrInvoiceLines)
                                    .Include(x => x.SiteProduct)
                                    .Load();

                dbContext.DcProducts.Local.ForEach(x => x.Balance = x.TrInvoiceLines.Sum(l => l.QtyIn - l.QtyOut));

                dcProductsBindingSource.DataSource = dbContext.DcProducts.Local.ToBindingList();

                //var file = Path.ChangeExtension(table[8], ".jpg");
                string fullPath = imageFolder + @"\" + dcProduct.ProductCode + ".jpg";
                if (!File.Exists(fullPath))
                {
                    //MessageBox.Show("No image!");
                }
                else
                {
                    using (var alma = new FileStream(fullPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                    {
                        pictureEdit.Image = Image.FromStream(alma);
                    }
                }
            }
        }

        private void ClearControlsAddNew()
        {
            dcProduct = dcProductsBindingSource.AddNew() as DcProduct;

            string NewDocNum = efMethods.GetNextDocNum(true, "P", "ProductCode", "DcProducts", 6);
            dcProduct.ProductCode = NewDocNum;
            dcProduct.ProductTypeCode = productTypeCode;
            dcProduct.CreatedUserName = Authorization.CurrAccCode;

            dcProductsBindingSource.DataSource = dcProduct;
        }

        private void dcCurrAccsBindingSource_AddingNew(object sender, AddingNewEventArgs e)
        {
            //dcCurrAcc = new DcCurrAcc();
            //dcCurrAcc.CurrAccCode = efMethods.GetNextDocNum("CA", "CurrAccCode", "DcCurrAccs");
            //dcCurrAcc.DataLanguageCode = "AZ";
            //e.NewObject = dcCurrAcc;
        }

        private void dataLayoutControl1_FieldRetrieving(object sender, FieldRetrievingEventArgs e)
        {
            if (e.FieldName == "ModifiedDate")
            {
                e.Visible = false;
                e.Handled = true;
            }
        }

        private void btn_Ok_Click(object sender, EventArgs e)
        {
            if (dataLayoutControl1.IsValid(out List<string> errorList))
            {
                dcProduct = dcProductsBindingSource.Current as DcProduct;
                if (isNew) //if invoiceHeader doesnt exist
                    if (!efMethods.ProductExist(dcProduct.ProductCode))
                        efMethods.InsertProduct(dcProduct);
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

        private void SaveImage()
        {
            string outPutImage = Path.Combine(imageFolder, dcProduct.ProductCode + ".jpg");

            //pictureEdit.Image.Save(imagePath);
            //pictureEdit.Image.Dispose();

            //using (FileStream fs = new(outPutImage, FileMode.Open, FileAccess.ReadWrite))
            //{
            try
            {
                //bitmap = pictureEdit.Image
                if (pictureEdit.Image is not null)
                {
                    pictureEdit.Image.Save(outPutImage);
                    GC.Collect();
                }
                else
                    File.Delete(outPutImage);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_ProductFeature_Click(object sender, EventArgs e)
        {
            efMethods.UpdateProductHierarchyCode(dcProduct.ProductCode, btnEdit_Hierarchy.Text);
            FormProductFeature formFeature = new(dcProduct.ProductCode);
            formFeature.ShowDialog();
        }

        private void openFileDialog()
        {
            OpenFileDialog dialog = new();
            dialog.Filter =
                        "Images (*.BMP;*.JPG;*.GIF,*.PNG,*.TIFF)|*.BMP;*.JPG;*.GIF;*.PNG;*.TIFF|" +
                        "All files (*.*)|*.*";

            //dialog.Multiselect = true;
            dialog.Title = "Foxoft üçün şəkil seçin.";

            DialogResult dr = dialog.ShowDialog();
            if (dr == DialogResult.OK)
            {
                foreach (String file in dialog.FileNames)
                {
                    try
                    {
                        Image.GetThumbnailImageAbort myCallback = new(ThumbnailCallback);
                        //Image myThumbnail = myBitmap.GetThumbnailImage(300, 300, myCallback, IntPtr.Zero);

                        using (FileStream fs = new(file, FileMode.Open, FileAccess.Read))
                        {
                            using (Image img = Image.FromStream(fs, true, false))
                            {
                                Bitmap myBitmap = new(img);
                                pictureEdit.Image = myBitmap;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
        }
        public bool ThumbnailCallback()
        {
            return false;
        }

        private void pictureEdit_DoubleClick(object sender, EventArgs e)
        {
            string outPutImage = imageFolder + @"\" + dcProduct.ProductCode + ".jpg";
            //Process.Start(outPutImage);

            if (File.Exists(outPutImage))
            {
                ProcessStartInfo startInfo = new(outPutImage);
                startInfo.UseShellExecute = true;
                Process.Start(startInfo);
            }
        }

        private void btn_loadImage_Click(object sender, EventArgs e)
        {
            openFileDialog();
        }

        private void btn_SaveImage_Click(object sender, EventArgs e)
        {
            SaveImage();
        }

        private void btnEdit_Hierarchy_ButtonPressed(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            ButtonEdit buttonEdit = (ButtonEdit)sender;

            using (FormTreeView form = new())
            {
                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    buttonEdit.EditValue = form.DcHierarchy.HierarchyCode;
                }
            }
        }

        private void btn_ProductDiscount_Click(object sender, EventArgs e)
        {
            //FormCommonList<TrProductDiscount> formFeature = new("", "DiscountId");
            FormCommonList<TrProductDiscount> formFeature = new("", "DiscountId", "", "ProductCode", dcProduct.ProductCode);
            formFeature.ShowDialog();
        }

        private void buttonEdit1_ButtonPressed(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            string slugify = dbContext.Slugify.FromSqlInterpolated($"Select dbo.Slugify ({ProductDescTextEdit.EditValue?.ToString()}) as Slugify").FirstOrDefault().Slugify;
            btnEdit_Slug.EditValue = slugify;
        }

        private void btnEdit_Hierarchy_EditValueChanged(object sender, EventArgs e)
        {
            ButtonEdit buttonEdit = (ButtonEdit)sender;
            string hierarchy = buttonEdit.EditValue?.ToString();

            if (!isNew)
                if (!string.IsNullOrEmpty(hierarchy))
                    if (efMethods.HierarchyExist(hierarchy))
                        btn_ProductFeature.Enabled = true;
                    else btn_ProductFeature.Enabled = false;

        }

        private void Btn_ProductBarcode_Click(object sender, EventArgs e)
        {
            FormProductBarcode formBarcode = new FormProductBarcode(dcProduct.ProductCode);
            formBarcode.ShowDialog();
        }
    }
}