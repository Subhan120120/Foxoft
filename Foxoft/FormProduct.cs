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
         this.productTypeCode = productTypeCode;
         this.isNew = isNew;

         SettingStore settingStore = efMethods.SelectSettingStore(Authorization.StoreCode);
         if (CustomExtensions.DirectoryExist(settingStore.ImageFolder))
            imageFolder = settingStore.ImageFolder;

         ProductTypeCodeLookUpEdit.Properties.DataSource = efMethods.SelectProductTypes();
         ProductTypeCodeLookUpEdit.Properties.ValueMember = "ProductTypeCode";
         ProductTypeCodeLookUpEdit.Properties.DisplayMember = "ProductTypeDesc";

         AcceptButton = btn_Ok;
         CancelButton = btn_Cancel;
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
                                .Load();

            dbContext.DcProducts.Local.ForEach(x => x.Balance = x.TrInvoiceLines.Sum(l => l.QtyIn - l.QtyOut));

            dcProductsBindingSource.DataSource = dbContext.DcProducts.Local.ToBindingList();

            //var file = Path.ChangeExtension(table[8], ".jpg");
            string fullPath = Path.Combine(imageFolder, dcProduct.ProductCode + ".jpg");
            if (!File.Exists(fullPath))
            {
               //MessageBox.Show("No image!");
            }
            else
            {
               Image img = Image.FromStream(new FileStream(fullPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite));

               pictureEdit.Image = img;
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
            //else if (efMethods.ProductExist(dcProduct.ProductCode))
            else
               dbContext.SaveChanges();
            //MessageBox.Show("Test");

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

         string outPutImage = imageFolder + dcProduct.ProductCode + ".jpg";
         //pictureEdit.Image.Save(imagePath);
         //pictureEdit.Image.Dispose();

         //using (FileStream fs = new(outPutImage, FileMode.Open, FileAccess.ReadWrite))
         //{
         try
         {
            //using (Bitmap bitmap = (Bitmap)Image.FromStream(fs, true, false))
            //{
            try
            {
               //bitmap = pictureEdit.Image
               if (pictureEdit.Image is not null)
               {
                  pictureEdit.Image.Save(outPutImage);
                  GC.Collect();
               }
            }
            catch (Exception ex)
            {
               MessageBox.Show(ex.Message);
            }
            //}
         }
         catch (ArgumentException aex)
         {
            MessageBox.Show(aex.Message);
         }
         //}
      }

      private void simpleButton1_Click(object sender, EventArgs e)
      {
         FormFeature formFeature = new(dcProduct.ProductCode);
         formFeature.Show();
      }

      private void pictureEdit_EditValueChanged(object sender, EventArgs e)
      {

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
         string outPutImage = imageFolder + dcProduct.ProductCode + ".jpg";
         //Process.Start(outPutImage);

         if (File.Exists(outPutImage))
         {
            ProcessStartInfo startInfo = new(outPutImage);
            startInfo.UseShellExecute = true;
            Process.Start(startInfo);
         }
      }

      private void simpleButton2_Click(object sender, EventArgs e)
      {
         SaveImage();
      }

      private void simpleButton3_Click(object sender, EventArgs e)
      {
         openFileDialog();
      }


      private void btn_BarcodeGenerate_Click(object sender, EventArgs e)
      {
         string genNumber = efMethods.GetNextDocNum(false, "20", "Barcode", "DcProducts", 10);
         string checkDigit = CalculateChecksumDigit("20", genNumber.Substring(2));
         BarcodeTextEdit.EditValue = genNumber + checkDigit;
      }

      public string CalculateChecksumDigit(string countryCode, string productCode)
      {
         string sTemp = countryCode + productCode;
         int iSum = 0;
         int iDigit = 0;

         // Calculate the checksum digit here.
         for (int i = sTemp.Length; i >= 1; i--)
         {
            iDigit = Convert.ToInt32(sTemp.Substring(i - 1, 1));
            if (i % 2 == 0)
            {  // odd
               iSum += iDigit * 3;
            }
            else
            {  // even
               iSum += iDigit * 1;
            }
         }

         int iCheckSum = (10 - (iSum % 10)) % 10;
         return iCheckSum.ToString();
      }
   }
}