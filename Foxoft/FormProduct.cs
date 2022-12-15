using DevExpress.Utils.Extensions;
using DevExpress.XtraDataLayout;
using DevExpress.XtraEditors;
using Foxoft.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Foxoft
{
   public partial class FormProduct : XtraForm
   {
      subContext dbContext = new();
      EfMethods efMethods = new();
      public DcProduct dcProduct = new();
      private byte productTypeCode;

      public FormProduct(byte productTypeCode)
      {
         InitializeComponent();
         this.productTypeCode = productTypeCode;

         ProductTypeCodeLookUpEdit.Properties.DataSource = efMethods.SelectProductTypes();
         ProductTypeCodeLookUpEdit.Properties.ValueMember = "ProductTypeCode";
         ProductTypeCodeLookUpEdit.Properties.DisplayMember = "ProductTypeDesc";

         AcceptButton = btn_Ok;
         CancelButton = btn_Cancel;
      }

      public FormProduct(byte productTypeCode, string productCode)
          : this(productTypeCode)
      {
         this.dcProduct.ProductCode = productCode;
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
            var fullPath = Path.Combine(@"\\192.168.2.199\Foxoft Images\", dcProduct.ProductCode + ".jpg");
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

         string NewDocNum = efMethods.GetNextDocNum("P", "ProductCode", "DcProducts", 6);
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
            if (!efMethods.ProductExist(dcProduct.ProductCode)) //if invoiceHeader doesnt exist
               efMethods.InsertProduct(dcProduct);
            else
               dbContext.SaveChanges();


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
         string outPutImage = @"\\192.168.2.199\Foxoft Images\" + dcProduct.ProductCode + ".jpg";
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
         FormFeature formFeature = new();
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
                  Bitmap myBitmap = new(file);
                  //Image myThumbnail = myBitmap.GetThumbnailImage(300, 300, myCallback, IntPtr.Zero);

                  pictureEdit.Image = myBitmap;
                  //myBitmap.Dispose();
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
         openFileDialog();
      }

      private void simpleButton2_Click(object sender, EventArgs e)
      {
         SaveImage();
      }
   }
}