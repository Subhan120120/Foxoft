using DevExpress.Utils;
using DevExpress.Utils.Drawing;
using DevExpress.XtraBars.Ribbon;
using Foxoft.Models;

namespace Foxoft
{
    partial class FormProduct
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            DevExpress.Skins.SkinPaddingEdges skinPaddingEdges1 = new DevExpress.Skins.SkinPaddingEdges();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormProduct));
            dataLayoutControl1 = new DevExpress.XtraDataLayout.DataLayoutControl();
            galleryControl1 = new GalleryControl();
            barAndDockingController1 = new DevExpress.XtraBars.BarAndDockingController(components);
            galleryControlClient1 = new GalleryControlClient();
            ProductCodeTextEdit = new DevExpress.XtraEditors.TextEdit();
            dcProductsBindingSource = new BindingSource(components);
            UsePosCheckEdit = new DevExpress.XtraEditors.CheckEdit();
            PromotionCodeTextEdit = new DevExpress.XtraEditors.TextEdit();
            PromotionCode2TextEdit = new DevExpress.XtraEditors.TextEdit();
            TaxRateTextEdit = new DevExpress.XtraEditors.TextEdit();
            IsDisabledCheckEdit = new DevExpress.XtraEditors.CheckEdit();
            ProductDescTextEdit = new DevExpress.XtraEditors.TextEdit();
            btn_Ok = new DevExpress.XtraEditors.SimpleButton();
            btn_Cancel = new DevExpress.XtraEditors.SimpleButton();
            ProductTypeCodeLookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            PurchasePriceTextEdit = new DevExpress.XtraEditors.TextEdit();
            WholesalePriceTextEdit = new DevExpress.XtraEditors.TextEdit();
            RetailPriceTextEdit = new DevExpress.XtraEditors.TextEdit();
            PosDiscountTextEdit = new DevExpress.XtraEditors.TextEdit();
            UseInternetCheckEdit = new DevExpress.XtraEditors.CheckEdit();
            BalanceTextEdit = new DevExpress.XtraEditors.TextEdit();
            pictureEdit = new DevExpress.XtraEditors.PictureEdit();
            textEdit_ProductCode2 = new DevExpress.XtraEditors.TextEdit();
            btnEdit_Hierarchy = new DevExpress.XtraEditors.ButtonEdit();
            txtEdit_Price = new DevExpress.XtraEditors.TextEdit();
            txtEdit_Desc = new DevExpress.XtraEditors.TextEdit();
            txtEdit_Rating = new DevExpress.XtraEditors.TextEdit();
            btnEdit_Slug = new DevExpress.XtraEditors.ButtonEdit();
            ItemForUsePos = new DevExpress.XtraLayout.LayoutControlItem();
            ItemForPromotionCode = new DevExpress.XtraLayout.LayoutControlItem();
            ItemForPromotionCode2 = new DevExpress.XtraLayout.LayoutControlItem();
            ItemForTaxRate = new DevExpress.XtraLayout.LayoutControlItem();
            Root = new DevExpress.XtraLayout.LayoutControlGroup();
            layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            ItemForPosDiscount = new DevExpress.XtraLayout.LayoutControlItem();
            ItemForBalance = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            ItemForProductCode = new DevExpress.XtraLayout.LayoutControlItem();
            ItemForProductTypeCode = new DevExpress.XtraLayout.LayoutControlItem();
            ItemForProductDesc = new DevExpress.XtraLayout.LayoutControlItem();
            ProductCode2 = new DevExpress.XtraLayout.LayoutControlItem();
            lCI_hierarchyCode = new DevExpress.XtraLayout.LayoutControlItem();
            tabbedControlGroup1 = new DevExpress.XtraLayout.TabbedControlGroup();
            autoGroupForQiymətlər = new DevExpress.XtraLayout.LayoutControlGroup();
            ItemForPurchasePrice = new DevExpress.XtraLayout.LayoutControlItem();
            ItemForWholesalePrice = new DevExpress.XtraLayout.LayoutControlItem();
            ItemForRetailPrice = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem9 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem11 = new DevExpress.XtraLayout.LayoutControlItem();
            emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            ItemForUseInternet = new DevExpress.XtraLayout.LayoutControlItem();
            ItemForIsDisabled = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            gridControl1 = new DevExpress.XtraGrid.GridControl();
            gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            barManager1 = new DevExpress.XtraBars.BarManager(components);
            bar1 = new DevExpress.XtraBars.Bar();
            BBI_ProductFeature = new DevExpress.XtraBars.BarButtonItem();
            BBI_ProductDiscount = new DevExpress.XtraBars.BarButtonItem();
            BBI_ProductBarcode = new DevExpress.XtraBars.BarButtonItem();
            bar3 = new DevExpress.XtraBars.Bar();
            barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            BBI_GalleryLoad = new DevExpress.XtraBars.BarButtonItem();
            BBI_GalleryDelete = new DevExpress.XtraBars.BarButtonItem();
            BBI_GalleryPaste = new DevExpress.XtraBars.BarButtonItem();
            BBI_GalleryCopy = new DevExpress.XtraBars.BarButtonItem();
            layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            popupMenu_Gallery = new DevExpress.XtraBars.PopupMenu(components);
            svgImageCollection1 = new SvgImageCollection(components);
            ((System.ComponentModel.ISupportInitialize)dataLayoutControl1).BeginInit();
            dataLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)galleryControl1).BeginInit();
            galleryControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)barAndDockingController1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ProductCodeTextEdit.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dcProductsBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)UsePosCheckEdit.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PromotionCodeTextEdit.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PromotionCode2TextEdit.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)TaxRateTextEdit.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)IsDisabledCheckEdit.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ProductDescTextEdit.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ProductTypeCodeLookUpEdit.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PurchasePriceTextEdit.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)WholesalePriceTextEdit.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)RetailPriceTextEdit.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PosDiscountTextEdit.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)UseInternetCheckEdit.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)BalanceTextEdit.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureEdit.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)textEdit_ProductCode2.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btnEdit_Hierarchy.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtEdit_Price.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtEdit_Desc.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtEdit_Rating.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btnEdit_Slug.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ItemForUsePos).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ItemForPromotionCode).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ItemForPromotionCode2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ItemForTaxRate).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Root).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlGroup1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ItemForPosDiscount).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ItemForBalance).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ItemForProductCode).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ItemForProductTypeCode).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ItemForProductDesc).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ProductCode2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)lCI_hierarchyCode).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tabbedControlGroup1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)autoGroupForQiymətlər).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ItemForPurchasePrice).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ItemForWholesalePrice).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ItemForRetailPrice).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlGroup2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem6).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem7).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem9).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem11).BeginInit();
            ((System.ComponentModel.ISupportInitialize)emptySpaceItem2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ItemForUseInternet).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ItemForIsDisabled).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridControl1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridView2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)barManager1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem8).BeginInit();
            ((System.ComponentModel.ISupportInitialize)popupMenu_Gallery).BeginInit();
            ((System.ComponentModel.ISupportInitialize)svgImageCollection1).BeginInit();
            SuspendLayout();
            // 
            // dataLayoutControl1
            // 
            dataLayoutControl1.Controls.Add(galleryControl1);
            dataLayoutControl1.Controls.Add(ProductCodeTextEdit);
            dataLayoutControl1.Controls.Add(UsePosCheckEdit);
            dataLayoutControl1.Controls.Add(PromotionCodeTextEdit);
            dataLayoutControl1.Controls.Add(PromotionCode2TextEdit);
            dataLayoutControl1.Controls.Add(TaxRateTextEdit);
            dataLayoutControl1.Controls.Add(IsDisabledCheckEdit);
            dataLayoutControl1.Controls.Add(ProductDescTextEdit);
            dataLayoutControl1.Controls.Add(btn_Ok);
            dataLayoutControl1.Controls.Add(btn_Cancel);
            dataLayoutControl1.Controls.Add(ProductTypeCodeLookUpEdit);
            dataLayoutControl1.Controls.Add(PurchasePriceTextEdit);
            dataLayoutControl1.Controls.Add(WholesalePriceTextEdit);
            dataLayoutControl1.Controls.Add(RetailPriceTextEdit);
            dataLayoutControl1.Controls.Add(PosDiscountTextEdit);
            dataLayoutControl1.Controls.Add(UseInternetCheckEdit);
            dataLayoutControl1.Controls.Add(BalanceTextEdit);
            dataLayoutControl1.Controls.Add(pictureEdit);
            dataLayoutControl1.Controls.Add(textEdit_ProductCode2);
            dataLayoutControl1.Controls.Add(btnEdit_Hierarchy);
            dataLayoutControl1.Controls.Add(txtEdit_Price);
            dataLayoutControl1.Controls.Add(txtEdit_Desc);
            dataLayoutControl1.Controls.Add(txtEdit_Rating);
            dataLayoutControl1.Controls.Add(btnEdit_Slug);
            dataLayoutControl1.DataSource = dcProductsBindingSource;
            dataLayoutControl1.Dock = DockStyle.Fill;
            dataLayoutControl1.HiddenItems.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] { ItemForUsePos, ItemForPromotionCode, ItemForPromotionCode2, ItemForTaxRate });
            dataLayoutControl1.Location = new Point(0, 0);
            dataLayoutControl1.Name = "dataLayoutControl1";
            dataLayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new Rectangle(1070, 296, 514, 400);
            dataLayoutControl1.Root = Root;
            dataLayoutControl1.Size = new Size(490, 397);
            dataLayoutControl1.TabIndex = 0;
            dataLayoutControl1.Text = "dataLayoutControl1";
            // 
            // galleryControl1
            // 
            galleryControl1.Controller = barAndDockingController1;
            galleryControl1.Controls.Add(galleryControlClient1);
            // 
            // 
            // 
            galleryControl1.Gallery.ImageSize = new Size(90, 60);
            galleryControl1.Gallery.ItemCheckMode = DevExpress.XtraBars.Ribbon.Gallery.ItemCheckMode.SingleCheck;
            galleryControl1.Gallery.ItemImageLayout = ImageLayoutMode.ZoomInside;
            skinPaddingEdges1.All = -5;
            skinPaddingEdges1.Bottom = -5;
            skinPaddingEdges1.Left = -5;
            skinPaddingEdges1.Right = -5;
            skinPaddingEdges1.Top = -5;
            galleryControl1.Gallery.ItemImagePadding = skinPaddingEdges1;
            galleryControl1.Gallery.Orientation = Orientation.Horizontal;
            galleryControl1.Gallery.ShowGroupCaption = false;
            galleryControl1.Location = new Point(262, 227);
            galleryControl1.Name = "galleryControl1";
            galleryControl1.Size = new Size(216, 92);
            galleryControl1.StyleController = dataLayoutControl1;
            galleryControl1.TabIndex = 19;
            galleryControl1.Text = "galleryControl1";
            galleryControl1.MouseDoubleClick += GalleryControl1_MouseDoubleClick;
            galleryControl1.MouseDown += galleryControl1_MouseDown;
            // 
            // barAndDockingController1
            // 
            barAndDockingController1.PropertiesBar.AllowLinkLighting = false;
            barAndDockingController1.PropertiesBar.LargeIcons = true;
            // 
            // galleryControlClient1
            // 
            galleryControlClient1.GalleryControl = galleryControl1;
            galleryControlClient1.Location = new Point(2, 2);
            galleryControlClient1.Size = new Size(212, 71);
            // 
            // ProductCodeTextEdit
            // 
            ProductCodeTextEdit.DataBindings.Add(new Binding("EditValue", dcProductsBindingSource, "ProductCode", true));
            ProductCodeTextEdit.Location = new Point(123, 12);
            ProductCodeTextEdit.Name = "ProductCodeTextEdit";
            ProductCodeTextEdit.Size = new Size(135, 20);
            ProductCodeTextEdit.StyleController = dataLayoutControl1;
            ProductCodeTextEdit.TabIndex = 0;
            // 
            // dcProductsBindingSource
            // 
            dcProductsBindingSource.DataSource = typeof(DcProduct);
            // 
            // UsePosCheckEdit
            // 
            UsePosCheckEdit.DataBindings.Add(new Binding("EditValue", dcProductsBindingSource, "UsePos", true));
            UsePosCheckEdit.Location = new Point(316, 153);
            UsePosCheckEdit.Name = "UsePosCheckEdit";
            UsePosCheckEdit.Properties.Caption = "Use Pos";
            UsePosCheckEdit.Properties.GlyphAlignment = HorzAlignment.Default;
            UsePosCheckEdit.Size = new Size(117, 20);
            UsePosCheckEdit.StyleController = dataLayoutControl1;
            UsePosCheckEdit.TabIndex = 1;
            // 
            // PromotionCodeTextEdit
            // 
            PromotionCodeTextEdit.DataBindings.Add(new Binding("EditValue", dcProductsBindingSource, "PromotionCode", true));
            PromotionCodeTextEdit.Location = new Point(117, 132);
            PromotionCodeTextEdit.Name = "PromotionCodeTextEdit";
            PromotionCodeTextEdit.Size = new Size(195, 20);
            PromotionCodeTextEdit.StyleController = dataLayoutControl1;
            PromotionCodeTextEdit.TabIndex = 1;
            // 
            // PromotionCode2TextEdit
            // 
            PromotionCode2TextEdit.DataBindings.Add(new Binding("EditValue", dcProductsBindingSource, "PromotionCode2", true));
            PromotionCode2TextEdit.Location = new Point(117, 156);
            PromotionCode2TextEdit.Name = "PromotionCode2TextEdit";
            PromotionCode2TextEdit.Size = new Size(195, 20);
            PromotionCode2TextEdit.StyleController = dataLayoutControl1;
            PromotionCode2TextEdit.TabIndex = 1;
            // 
            // TaxRateTextEdit
            // 
            TaxRateTextEdit.DataBindings.Add(new Binding("EditValue", dcProductsBindingSource, "TaxRate", true));
            TaxRateTextEdit.Location = new Point(117, 84);
            TaxRateTextEdit.Name = "TaxRateTextEdit";
            TaxRateTextEdit.Properties.Appearance.Options.UseTextOptions = true;
            TaxRateTextEdit.Properties.Appearance.TextOptions.HAlignment = HorzAlignment.Far;
            TaxRateTextEdit.Properties.Mask.UseMaskAsDisplayFormat = true;
            TaxRateTextEdit.Size = new Size(195, 20);
            TaxRateTextEdit.StyleController = dataLayoutControl1;
            TaxRateTextEdit.TabIndex = 1;
            // 
            // IsDisabledCheckEdit
            // 
            IsDisabledCheckEdit.DataBindings.Add(new Binding("EditValue", dcProductsBindingSource, "IsDisabled", true));
            IsDisabledCheckEdit.Location = new Point(12, 299);
            IsDisabledCheckEdit.Name = "IsDisabledCheckEdit";
            IsDisabledCheckEdit.Properties.Caption = "Is Disabled";
            IsDisabledCheckEdit.Properties.GlyphAlignment = HorzAlignment.Default;
            IsDisabledCheckEdit.Size = new Size(78, 20);
            IsDisabledCheckEdit.StyleController = dataLayoutControl1;
            IsDisabledCheckEdit.TabIndex = 15;
            // 
            // ProductDescTextEdit
            // 
            ProductDescTextEdit.DataBindings.Add(new Binding("EditValue", dcProductsBindingSource, "ProductDesc", true));
            ProductDescTextEdit.Location = new Point(123, 36);
            ProductDescTextEdit.Name = "ProductDescTextEdit";
            ProductDescTextEdit.Properties.AllowNullInput = DefaultBoolean.False;
            ProductDescTextEdit.Size = new Size(355, 20);
            ProductDescTextEdit.StyleController = dataLayoutControl1;
            ProductDescTextEdit.TabIndex = 3;
            // 
            // btn_Ok
            // 
            btn_Ok.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            btn_Ok.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("btn_Ok.ImageOptions.SvgImage");
            btn_Ok.Location = new Point(401, 323);
            btn_Ok.Name = "btn_Ok";
            btn_Ok.Size = new Size(77, 62);
            btn_Ok.StyleController = dataLayoutControl1;
            btn_Ok.TabIndex = 18;
            btn_Ok.Text = "simpleButton1";
            btn_Ok.Click += btn_Ok_Click;
            // 
            // btn_Cancel
            // 
            btn_Cancel.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            btn_Cancel.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("btn_Cancel.ImageOptions.SvgImage");
            btn_Cancel.Location = new Point(321, 323);
            btn_Cancel.Name = "btn_Cancel";
            btn_Cancel.Size = new Size(76, 62);
            btn_Cancel.StyleController = dataLayoutControl1;
            btn_Cancel.TabIndex = 17;
            btn_Cancel.Text = "simpleButton2";
            // 
            // ProductTypeCodeLookUpEdit
            // 
            ProductTypeCodeLookUpEdit.DataBindings.Add(new Binding("EditValue", dcProductsBindingSource, "ProductTypeCode", true));
            ProductTypeCodeLookUpEdit.Location = new Point(373, 12);
            ProductTypeCodeLookUpEdit.Name = "ProductTypeCodeLookUpEdit";
            ProductTypeCodeLookUpEdit.Properties.Appearance.Options.UseTextOptions = true;
            ProductTypeCodeLookUpEdit.Properties.Appearance.TextOptions.HAlignment = HorzAlignment.Far;
            ProductTypeCodeLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            ProductTypeCodeLookUpEdit.Properties.NullText = "";
            ProductTypeCodeLookUpEdit.Size = new Size(105, 20);
            ProductTypeCodeLookUpEdit.StyleController = dataLayoutControl1;
            ProductTypeCodeLookUpEdit.TabIndex = 2;
            // 
            // PurchasePriceTextEdit
            // 
            PurchasePriceTextEdit.DataBindings.Add(new Binding("EditValue", dcProductsBindingSource, "PurchasePrice", true));
            PurchasePriceTextEdit.Location = new Point(135, 191);
            PurchasePriceTextEdit.Name = "PurchasePriceTextEdit";
            PurchasePriceTextEdit.Properties.Appearance.Options.UseTextOptions = true;
            PurchasePriceTextEdit.Properties.Appearance.TextOptions.HAlignment = HorzAlignment.Far;
            PurchasePriceTextEdit.Properties.Mask.EditMask = "G";
            PurchasePriceTextEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            PurchasePriceTextEdit.Properties.Mask.UseMaskAsDisplayFormat = true;
            PurchasePriceTextEdit.Size = new Size(111, 20);
            PurchasePriceTextEdit.StyleController = dataLayoutControl1;
            PurchasePriceTextEdit.TabIndex = 1;
            // 
            // WholesalePriceTextEdit
            // 
            WholesalePriceTextEdit.DataBindings.Add(new Binding("EditValue", dcProductsBindingSource, "WholesalePrice", true));
            WholesalePriceTextEdit.Location = new Point(135, 215);
            WholesalePriceTextEdit.Name = "WholesalePriceTextEdit";
            WholesalePriceTextEdit.Properties.Appearance.Options.UseTextOptions = true;
            WholesalePriceTextEdit.Properties.Appearance.TextOptions.HAlignment = HorzAlignment.Far;
            WholesalePriceTextEdit.Properties.Mask.EditMask = "G";
            WholesalePriceTextEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            WholesalePriceTextEdit.Properties.Mask.UseMaskAsDisplayFormat = true;
            WholesalePriceTextEdit.Size = new Size(111, 20);
            WholesalePriceTextEdit.StyleController = dataLayoutControl1;
            WholesalePriceTextEdit.TabIndex = 1;
            // 
            // RetailPriceTextEdit
            // 
            RetailPriceTextEdit.DataBindings.Add(new Binding("EditValue", dcProductsBindingSource, "RetailPrice", true));
            RetailPriceTextEdit.Location = new Point(135, 239);
            RetailPriceTextEdit.Name = "RetailPriceTextEdit";
            RetailPriceTextEdit.Properties.Appearance.Options.UseTextOptions = true;
            RetailPriceTextEdit.Properties.Appearance.TextOptions.HAlignment = HorzAlignment.Far;
            RetailPriceTextEdit.Properties.Mask.EditMask = "G";
            RetailPriceTextEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            RetailPriceTextEdit.Properties.Mask.UseMaskAsDisplayFormat = true;
            RetailPriceTextEdit.Size = new Size(111, 20);
            RetailPriceTextEdit.StyleController = dataLayoutControl1;
            RetailPriceTextEdit.TabIndex = 1;
            // 
            // PosDiscountTextEdit
            // 
            PosDiscountTextEdit.DataBindings.Add(new Binding("EditValue", dcProductsBindingSource, "PosDiscount", true));
            PosDiscountTextEdit.Location = new Point(123, 60);
            PosDiscountTextEdit.Name = "PosDiscountTextEdit";
            PosDiscountTextEdit.Properties.Appearance.Options.UseTextOptions = true;
            PosDiscountTextEdit.Properties.Appearance.TextOptions.HAlignment = HorzAlignment.Far;
            PosDiscountTextEdit.Properties.Mask.EditMask = "F";
            PosDiscountTextEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            PosDiscountTextEdit.Properties.Mask.UseMaskAsDisplayFormat = true;
            PosDiscountTextEdit.Size = new Size(135, 20);
            PosDiscountTextEdit.StyleController = dataLayoutControl1;
            PosDiscountTextEdit.TabIndex = 4;
            // 
            // UseInternetCheckEdit
            // 
            UseInternetCheckEdit.DataBindings.Add(new Binding("EditValue", dcProductsBindingSource, "UseInternet", true));
            UseInternetCheckEdit.Location = new Point(94, 299);
            UseInternetCheckEdit.Name = "UseInternetCheckEdit";
            UseInternetCheckEdit.Properties.Caption = "İnternetdə İstifadə Et";
            UseInternetCheckEdit.Properties.GlyphAlignment = HorzAlignment.Default;
            UseInternetCheckEdit.Size = new Size(164, 20);
            UseInternetCheckEdit.StyleController = dataLayoutControl1;
            UseInternetCheckEdit.TabIndex = 16;
            // 
            // BalanceTextEdit
            // 
            BalanceTextEdit.DataBindings.Add(new Binding("EditValue", dcProductsBindingSource, "Balance", true));
            BalanceTextEdit.Location = new Point(123, 84);
            BalanceTextEdit.Name = "BalanceTextEdit";
            BalanceTextEdit.Properties.Appearance.Options.UseTextOptions = true;
            BalanceTextEdit.Properties.Appearance.TextOptions.HAlignment = HorzAlignment.Far;
            BalanceTextEdit.Properties.Mask.EditMask = "N0";
            BalanceTextEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            BalanceTextEdit.Properties.Mask.UseMaskAsDisplayFormat = true;
            BalanceTextEdit.Size = new Size(135, 20);
            BalanceTextEdit.StyleController = dataLayoutControl1;
            BalanceTextEdit.TabIndex = 5;
            // 
            // pictureEdit
            // 
            pictureEdit.Location = new Point(262, 60);
            pictureEdit.Name = "pictureEdit";
            pictureEdit.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            pictureEdit.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom;
            pictureEdit.Size = new Size(216, 163);
            pictureEdit.StyleController = dataLayoutControl1;
            pictureEdit.TabIndex = 1;
            pictureEdit.PopupMenuShowing += pictureEdit_PopupMenuShowing;
            pictureEdit.EditValueChanged += pictureEdit_EditValueChanged;
            pictureEdit.DoubleClick += pictureEdit_DoubleClick;
            // 
            // textEdit_ProductCode2
            // 
            textEdit_ProductCode2.DataBindings.Add(new Binding("EditValue", dcProductsBindingSource, "ProductCode2", true));
            textEdit_ProductCode2.Location = new Point(123, 108);
            textEdit_ProductCode2.Name = "textEdit_ProductCode2";
            textEdit_ProductCode2.Size = new Size(135, 20);
            textEdit_ProductCode2.StyleController = dataLayoutControl1;
            textEdit_ProductCode2.TabIndex = 6;
            // 
            // btnEdit_Hierarchy
            // 
            btnEdit_Hierarchy.DataBindings.Add(new Binding("EditValue", dcProductsBindingSource, "HierarchyCode", true));
            btnEdit_Hierarchy.Location = new Point(123, 132);
            btnEdit_Hierarchy.Name = "btnEdit_Hierarchy";
            btnEdit_Hierarchy.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton() });
            btnEdit_Hierarchy.Size = new Size(135, 20);
            btnEdit_Hierarchy.StyleController = dataLayoutControl1;
            btnEdit_Hierarchy.TabIndex = 8;
            btnEdit_Hierarchy.ButtonPressed += btnEdit_Hierarchy_ButtonPressed;
            btnEdit_Hierarchy.EditValueChanged += btnEdit_Hierarchy_EditValueChanged;
            // 
            // txtEdit_Price
            // 
            txtEdit_Price.DataBindings.Add(new Binding("EditValue", dcProductsBindingSource, "SiteProduct.Price", true));
            txtEdit_Price.Location = new Point(135, 191);
            txtEdit_Price.Name = "txtEdit_Price";
            txtEdit_Price.Size = new Size(111, 20);
            txtEdit_Price.StyleController = dataLayoutControl1;
            txtEdit_Price.TabIndex = 10;
            // 
            // txtEdit_Desc
            // 
            txtEdit_Desc.DataBindings.Add(new Binding("EditValue", dcProductsBindingSource, "SiteProduct.Desc", true));
            txtEdit_Desc.Location = new Point(135, 215);
            txtEdit_Desc.Name = "txtEdit_Desc";
            txtEdit_Desc.Size = new Size(111, 20);
            txtEdit_Desc.StyleController = dataLayoutControl1;
            txtEdit_Desc.TabIndex = 11;
            // 
            // txtEdit_Rating
            // 
            txtEdit_Rating.DataBindings.Add(new Binding("EditValue", dcProductsBindingSource, "SiteProduct.Rating", true));
            txtEdit_Rating.Location = new Point(135, 263);
            txtEdit_Rating.Name = "txtEdit_Rating";
            txtEdit_Rating.Size = new Size(111, 20);
            txtEdit_Rating.StyleController = dataLayoutControl1;
            txtEdit_Rating.TabIndex = 13;
            // 
            // btnEdit_Slug
            // 
            btnEdit_Slug.DataBindings.Add(new Binding("EditValue", dcProductsBindingSource, "SiteProduct.Slug", true));
            btnEdit_Slug.Location = new Point(135, 239);
            btnEdit_Slug.Name = "btnEdit_Slug";
            btnEdit_Slug.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Plus) });
            btnEdit_Slug.Size = new Size(111, 20);
            btnEdit_Slug.StyleController = dataLayoutControl1;
            btnEdit_Slug.TabIndex = 12;
            btnEdit_Slug.ButtonPressed += BtnEdit_Slug_ButtonPressed;
            // 
            // ItemForUsePos
            // 
            ItemForUsePos.Control = UsePosCheckEdit;
            ItemForUsePos.Location = new Point(304, 141);
            ItemForUsePos.Name = "ItemForUsePos";
            ItemForUsePos.Size = new Size(121, 27);
            ItemForUsePos.Text = "Use Pos";
            ItemForUsePos.TextSize = new Size(0, 0);
            ItemForUsePos.TextVisible = false;
            // 
            // ItemForPromotionCode
            // 
            ItemForPromotionCode.Control = PromotionCodeTextEdit;
            ItemForPromotionCode.Location = new Point(0, 120);
            ItemForPromotionCode.Name = "ItemForPromotionCode";
            ItemForPromotionCode.Size = new Size(304, 24);
            ItemForPromotionCode.Text = "Promotion Code";
            ItemForPromotionCode.TextSize = new Size(93, 13);
            // 
            // ItemForPromotionCode2
            // 
            ItemForPromotionCode2.Control = PromotionCode2TextEdit;
            ItemForPromotionCode2.Location = new Point(0, 120);
            ItemForPromotionCode2.Name = "ItemForPromotionCode2";
            ItemForPromotionCode2.Size = new Size(304, 48);
            ItemForPromotionCode2.Text = "Promotion Code2";
            ItemForPromotionCode2.TextSize = new Size(93, 13);
            // 
            // ItemForTaxRate
            // 
            ItemForTaxRate.Control = TaxRateTextEdit;
            ItemForTaxRate.Location = new Point(0, 24);
            ItemForTaxRate.Name = "ItemForTaxRate";
            ItemForTaxRate.Size = new Size(304, 72);
            ItemForTaxRate.Text = "Tax Rate";
            ItemForTaxRate.TextSize = new Size(93, 13);
            // 
            // Root
            // 
            Root.EnableIndentsWithoutBorders = DefaultBoolean.True;
            Root.GroupBordersVisible = false;
            Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] { layoutControlGroup1 });
            Root.Name = "Root";
            Root.Size = new Size(490, 397);
            Root.TextVisible = false;
            // 
            // layoutControlGroup1
            // 
            layoutControlGroup1.AllowDrawBackground = false;
            layoutControlGroup1.GroupBordersVisible = false;
            layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] { ItemForPosDiscount, ItemForBalance, layoutControlItem4, ItemForProductCode, ItemForProductTypeCode, ItemForProductDesc, ProductCode2, lCI_hierarchyCode, tabbedControlGroup1, emptySpaceItem2, layoutControlItem2, layoutControlItem1, ItemForUseInternet, ItemForIsDisabled, layoutControlItem3 });
            layoutControlGroup1.Location = new Point(0, 0);
            layoutControlGroup1.Name = "autoGeneratedGroup0";
            layoutControlGroup1.Size = new Size(470, 377);
            // 
            // ItemForPosDiscount
            // 
            ItemForPosDiscount.Control = PosDiscountTextEdit;
            ItemForPosDiscount.Location = new Point(0, 48);
            ItemForPosDiscount.Name = "ItemForPosDiscount";
            ItemForPosDiscount.Size = new Size(250, 24);
            ItemForPosDiscount.Text = "Pos Endirimi";
            ItemForPosDiscount.TextSize = new Size(99, 13);
            // 
            // ItemForBalance
            // 
            ItemForBalance.Control = BalanceTextEdit;
            ItemForBalance.Location = new Point(0, 72);
            ItemForBalance.Name = "ItemForBalance";
            ItemForBalance.Size = new Size(250, 24);
            ItemForBalance.Text = "Qalıq";
            ItemForBalance.TextSize = new Size(99, 13);
            // 
            // layoutControlItem4
            // 
            layoutControlItem4.Control = pictureEdit;
            layoutControlItem4.Location = new Point(250, 48);
            layoutControlItem4.MinSize = new Size(24, 24);
            layoutControlItem4.Name = "layoutControlItem4";
            layoutControlItem4.Size = new Size(220, 167);
            layoutControlItem4.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            layoutControlItem4.TextSize = new Size(0, 0);
            layoutControlItem4.TextVisible = false;
            // 
            // ItemForProductCode
            // 
            ItemForProductCode.Control = ProductCodeTextEdit;
            ItemForProductCode.Location = new Point(0, 0);
            ItemForProductCode.Name = "ItemForProductCode";
            ItemForProductCode.Size = new Size(250, 24);
            ItemForProductCode.Text = "Məhsul Kodu";
            ItemForProductCode.TextSize = new Size(99, 13);
            // 
            // ItemForProductTypeCode
            // 
            ItemForProductTypeCode.Control = ProductTypeCodeLookUpEdit;
            ItemForProductTypeCode.Location = new Point(250, 0);
            ItemForProductTypeCode.Name = "ItemForProductTypeCode";
            ItemForProductTypeCode.Size = new Size(220, 24);
            ItemForProductTypeCode.Text = "Məhsul Tipi";
            ItemForProductTypeCode.TextSize = new Size(99, 13);
            // 
            // ItemForProductDesc
            // 
            ItemForProductDesc.Control = ProductDescTextEdit;
            ItemForProductDesc.Location = new Point(0, 24);
            ItemForProductDesc.Name = "ItemForProductDesc";
            ItemForProductDesc.Size = new Size(470, 24);
            ItemForProductDesc.Text = "Məhsul Adı";
            ItemForProductDesc.TextSize = new Size(99, 13);
            // 
            // ProductCode2
            // 
            ProductCode2.Control = textEdit_ProductCode2;
            ProductCode2.Location = new Point(0, 96);
            ProductCode2.Name = "ProductCode2";
            ProductCode2.Size = new Size(250, 24);
            ProductCode2.TextSize = new Size(99, 13);
            // 
            // lCI_hierarchyCode
            // 
            lCI_hierarchyCode.Control = btnEdit_Hierarchy;
            lCI_hierarchyCode.Location = new Point(0, 120);
            lCI_hierarchyCode.Name = "lCI_hierarchyCode";
            lCI_hierarchyCode.Size = new Size(250, 24);
            lCI_hierarchyCode.TextSize = new Size(99, 13);
            // 
            // tabbedControlGroup1
            // 
            tabbedControlGroup1.Location = new Point(0, 144);
            tabbedControlGroup1.Name = "tabbedControlGroup1";
            tabbedControlGroup1.SelectedTabPage = autoGroupForQiymətlər;
            tabbedControlGroup1.Size = new Size(250, 143);
            tabbedControlGroup1.TabPages.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] { autoGroupForQiymətlər, layoutControlGroup2 });
            // 
            // autoGroupForQiymətlər
            // 
            autoGroupForQiymətlər.GroupStyle = GroupStyle.Light;
            autoGroupForQiymətlər.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] { ItemForPurchasePrice, ItemForWholesalePrice, ItemForRetailPrice });
            autoGroupForQiymətlər.Location = new Point(0, 0);
            autoGroupForQiymətlər.Name = "autoGroupForQiymətlər";
            autoGroupForQiymətlər.Size = new Size(226, 96);
            autoGroupForQiymətlər.Text = "Qiymətlər";
            // 
            // ItemForPurchasePrice
            // 
            ItemForPurchasePrice.Control = PurchasePriceTextEdit;
            ItemForPurchasePrice.Location = new Point(0, 0);
            ItemForPurchasePrice.Name = "ItemForPurchasePrice";
            ItemForPurchasePrice.Size = new Size(226, 24);
            ItemForPurchasePrice.TextSize = new Size(99, 13);
            // 
            // ItemForWholesalePrice
            // 
            ItemForWholesalePrice.Control = WholesalePriceTextEdit;
            ItemForWholesalePrice.Location = new Point(0, 24);
            ItemForWholesalePrice.Name = "ItemForWholesalePrice";
            ItemForWholesalePrice.Size = new Size(226, 24);
            ItemForWholesalePrice.TextSize = new Size(99, 13);
            // 
            // ItemForRetailPrice
            // 
            ItemForRetailPrice.Control = RetailPriceTextEdit;
            ItemForRetailPrice.Location = new Point(0, 48);
            ItemForRetailPrice.Name = "ItemForRetailPrice";
            ItemForRetailPrice.Size = new Size(226, 48);
            ItemForRetailPrice.TextSize = new Size(99, 13);
            // 
            // layoutControlGroup2
            // 
            layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] { layoutControlItem6, layoutControlItem7, layoutControlItem9, layoutControlItem11 });
            layoutControlGroup2.Location = new Point(0, 0);
            layoutControlGroup2.Name = "layoutControlGroup2";
            layoutControlGroup2.Size = new Size(226, 96);
            layoutControlGroup2.Text = "Sayt";
            // 
            // layoutControlItem6
            // 
            layoutControlItem6.Control = txtEdit_Price;
            layoutControlItem6.Location = new Point(0, 0);
            layoutControlItem6.Name = "layoutControlItem6";
            layoutControlItem6.Size = new Size(226, 24);
            layoutControlItem6.TextSize = new Size(99, 13);
            // 
            // layoutControlItem7
            // 
            layoutControlItem7.Control = txtEdit_Desc;
            layoutControlItem7.Location = new Point(0, 24);
            layoutControlItem7.Name = "layoutControlItem7";
            layoutControlItem7.Size = new Size(226, 24);
            layoutControlItem7.TextSize = new Size(99, 13);
            // 
            // layoutControlItem9
            // 
            layoutControlItem9.Control = txtEdit_Rating;
            layoutControlItem9.Location = new Point(0, 72);
            layoutControlItem9.Name = "layoutControlItem9";
            layoutControlItem9.Size = new Size(226, 24);
            layoutControlItem9.TextSize = new Size(99, 13);
            // 
            // layoutControlItem11
            // 
            layoutControlItem11.Control = btnEdit_Slug;
            layoutControlItem11.Location = new Point(0, 48);
            layoutControlItem11.Name = "layoutControlItem11";
            layoutControlItem11.Size = new Size(226, 24);
            layoutControlItem11.TextSize = new Size(99, 13);
            // 
            // emptySpaceItem2
            // 
            emptySpaceItem2.AllowHotTrack = false;
            emptySpaceItem2.Location = new Point(0, 311);
            emptySpaceItem2.Name = "emptySpaceItem2";
            emptySpaceItem2.Size = new Size(309, 66);
            emptySpaceItem2.TextSize = new Size(0, 0);
            // 
            // layoutControlItem2
            // 
            layoutControlItem2.Control = btn_Cancel;
            layoutControlItem2.Location = new Point(309, 311);
            layoutControlItem2.MinSize = new Size(78, 26);
            layoutControlItem2.Name = "layoutControlItem2";
            layoutControlItem2.Size = new Size(80, 66);
            layoutControlItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            layoutControlItem2.TextSize = new Size(0, 0);
            layoutControlItem2.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            layoutControlItem1.Control = btn_Ok;
            layoutControlItem1.Location = new Point(389, 311);
            layoutControlItem1.MinSize = new Size(78, 26);
            layoutControlItem1.Name = "layoutControlItem1";
            layoutControlItem1.Size = new Size(81, 66);
            layoutControlItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            layoutControlItem1.TextSize = new Size(0, 0);
            layoutControlItem1.TextVisible = false;
            // 
            // ItemForUseInternet
            // 
            ItemForUseInternet.Control = UseInternetCheckEdit;
            ItemForUseInternet.Location = new Point(82, 287);
            ItemForUseInternet.Name = "ItemForUseInternet";
            ItemForUseInternet.Size = new Size(168, 24);
            ItemForUseInternet.Text = "İnternetdə İstifadə Et";
            ItemForUseInternet.TextSize = new Size(0, 0);
            ItemForUseInternet.TextVisible = false;
            // 
            // ItemForIsDisabled
            // 
            ItemForIsDisabled.Control = IsDisabledCheckEdit;
            ItemForIsDisabled.Location = new Point(0, 287);
            ItemForIsDisabled.Name = "ItemForIsDisabled";
            ItemForIsDisabled.Size = new Size(82, 24);
            ItemForIsDisabled.Text = "Is Disabled";
            ItemForIsDisabled.TextSize = new Size(0, 0);
            ItemForIsDisabled.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            layoutControlItem3.Control = galleryControl1;
            layoutControlItem3.Location = new Point(250, 215);
            layoutControlItem3.Name = "layoutControlItem3";
            layoutControlItem3.Size = new Size(220, 96);
            layoutControlItem3.TextSize = new Size(0, 0);
            layoutControlItem3.TextVisible = false;
            // 
            // gridControl1
            // 
            gridControl1.Location = new Point(0, 0);
            gridControl1.MainView = gridView2;
            gridControl1.Name = "gridControl1";
            gridControl1.Size = new Size(400, 200);
            gridControl1.TabIndex = 0;
            gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gridView2 });
            // 
            // gridView2
            // 
            gridView2.GridControl = gridControl1;
            gridView2.Name = "gridView2";
            // 
            // barManager1
            // 
            barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] { bar1, bar3 });
            barManager1.Controller = barAndDockingController1;
            barManager1.DockControls.Add(barDockControlTop);
            barManager1.DockControls.Add(barDockControlBottom);
            barManager1.DockControls.Add(barDockControlLeft);
            barManager1.DockControls.Add(barDockControlRight);
            barManager1.Form = this;
            barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] { BBI_ProductFeature, BBI_ProductDiscount, BBI_ProductBarcode, BBI_GalleryLoad, BBI_GalleryDelete, BBI_GalleryPaste, BBI_GalleryCopy });
            barManager1.MaxItemId = 8;
            barManager1.StatusBar = bar3;
            // 
            // bar1
            // 
            bar1.BarName = "Tools";
            bar1.DockCol = 0;
            bar1.DockRow = 1;
            bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] { new DevExpress.XtraBars.LinkPersistInfo(BBI_ProductFeature), new DevExpress.XtraBars.LinkPersistInfo(BBI_ProductDiscount), new DevExpress.XtraBars.LinkPersistInfo(BBI_ProductBarcode) });
            bar1.Text = "Tools";
            // 
            // BBI_ProductFeature
            // 
            BBI_ProductFeature.Caption = "Özəllik";
            BBI_ProductFeature.Enabled = false;
            BBI_ProductFeature.Id = 0;
            BBI_ProductFeature.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("BBI_ProductFeature.ImageOptions.SvgImage");
            BBI_ProductFeature.Name = "BBI_ProductFeature";
            BBI_ProductFeature.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            BBI_ProductFeature.ItemClick += BBI_ProductFeature_ItemClick;
            // 
            // BBI_ProductDiscount
            // 
            BBI_ProductDiscount.Caption = "Endirim";
            BBI_ProductDiscount.Enabled = false;
            BBI_ProductDiscount.Id = 1;
            BBI_ProductDiscount.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("BBI_ProductDiscount.ImageOptions.SvgImage");
            BBI_ProductDiscount.Name = "BBI_ProductDiscount";
            BBI_ProductDiscount.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            BBI_ProductDiscount.ItemClick += BBI_ProductDiscount_ItemClick;
            // 
            // BBI_ProductBarcode
            // 
            BBI_ProductBarcode.Caption = "Barkod";
            BBI_ProductBarcode.Enabled = false;
            BBI_ProductBarcode.Id = 2;
            BBI_ProductBarcode.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("BBI_ProductBarcode.ImageOptions.SvgImage");
            BBI_ProductBarcode.Name = "BBI_ProductBarcode";
            BBI_ProductBarcode.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            BBI_ProductBarcode.ItemClick += BBI_ProductBarcode_ItemClick;
            // 
            // bar3
            // 
            bar3.BarName = "Status bar";
            bar3.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            bar3.DockCol = 0;
            bar3.DockRow = 0;
            bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            bar3.OptionsBar.AllowQuickCustomization = false;
            bar3.OptionsBar.DrawDragBorder = false;
            bar3.OptionsBar.UseWholeRow = true;
            bar3.Text = "Status bar";
            // 
            // barDockControlTop
            // 
            barDockControlTop.CausesValidation = false;
            barDockControlTop.Dock = DockStyle.Top;
            barDockControlTop.Location = new Point(0, 0);
            barDockControlTop.Manager = barManager1;
            barDockControlTop.Size = new Size(490, 0);
            // 
            // barDockControlBottom
            // 
            barDockControlBottom.CausesValidation = false;
            barDockControlBottom.Dock = DockStyle.Bottom;
            barDockControlBottom.Location = new Point(0, 397);
            barDockControlBottom.Manager = barManager1;
            barDockControlBottom.Size = new Size(490, 61);
            // 
            // barDockControlLeft
            // 
            barDockControlLeft.CausesValidation = false;
            barDockControlLeft.Dock = DockStyle.Left;
            barDockControlLeft.Location = new Point(0, 0);
            barDockControlLeft.Manager = barManager1;
            barDockControlLeft.Size = new Size(0, 397);
            // 
            // barDockControlRight
            // 
            barDockControlRight.CausesValidation = false;
            barDockControlRight.Dock = DockStyle.Right;
            barDockControlRight.Location = new Point(490, 0);
            barDockControlRight.Manager = barManager1;
            barDockControlRight.Size = new Size(0, 397);
            // 
            // BBI_GalleryLoad
            // 
            BBI_GalleryLoad.Caption = "Yüklə";
            BBI_GalleryLoad.Id = 4;
            BBI_GalleryLoad.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("BBI_GalleryLoad.ImageOptions.SvgImage");
            BBI_GalleryLoad.ItemShortcut = new DevExpress.XtraBars.BarShortcut(Keys.Control | Keys.O);
            BBI_GalleryLoad.Name = "BBI_GalleryLoad";
            BBI_GalleryLoad.ShowItemShortcut = DefaultBoolean.True;
            BBI_GalleryLoad.ItemClick += BBI_GalleryLoad_ItemClick;
            // 
            // BBI_GalleryDelete
            // 
            BBI_GalleryDelete.Caption = "Sil";
            BBI_GalleryDelete.Id = 5;
            BBI_GalleryDelete.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("BBI_GalleryDelete.ImageOptions.SvgImage");
            BBI_GalleryDelete.Name = "BBI_GalleryDelete";
            BBI_GalleryDelete.ItemClick += BBI_GalleryDelete_ItemClick;
            // 
            // BBI_GalleryPaste
            // 
            BBI_GalleryPaste.Caption = "Yapıştır";
            BBI_GalleryPaste.Id = 6;
            BBI_GalleryPaste.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("BBI_GalleryPaste.ImageOptions.SvgImage");
            BBI_GalleryPaste.ItemShortcut = new DevExpress.XtraBars.BarShortcut(Keys.Control | Keys.V);
            BBI_GalleryPaste.Name = "BBI_GalleryPaste";
            BBI_GalleryPaste.ItemClick += BBI_GalleryPaste_ItemClick;
            // 
            // BBI_GalleryCopy
            // 
            BBI_GalleryCopy.Caption = "Kopyala";
            BBI_GalleryCopy.Id = 7;
            BBI_GalleryCopy.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("BBI_GalleryCopy.ImageOptions.SvgImage");
            BBI_GalleryCopy.ItemShortcut = new DevExpress.XtraBars.BarShortcut(Keys.Control | Keys.C);
            BBI_GalleryCopy.Name = "BBI_GalleryCopy";
            BBI_GalleryCopy.ItemClick += BBI_GalleryCopy_ItemClick;
            // 
            // layoutControlItem8
            // 
            layoutControlItem8.Location = new Point(102, 335);
            layoutControlItem8.Name = "layoutControlItem10";
            layoutControlItem8.Size = new Size(168, 67);
            layoutControlItem8.TextSize = new Size(0, 0);
            layoutControlItem8.TextVisible = false;
            // 
            // popupMenu_Gallery
            // 
            popupMenu_Gallery.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] { new DevExpress.XtraBars.LinkPersistInfo(BBI_GalleryLoad), new DevExpress.XtraBars.LinkPersistInfo(BBI_GalleryDelete), new DevExpress.XtraBars.LinkPersistInfo(BBI_GalleryPaste), new DevExpress.XtraBars.LinkPersistInfo(BBI_GalleryCopy) });
            popupMenu_Gallery.Manager = barManager1;
            popupMenu_Gallery.Name = "popupMenu_Gallery";
            popupMenu_Gallery.BeforePopup += popupMenu_Gallery_BeforePopup;
            // 
            // svgImageCollection1
            // 
            svgImageCollection1.Add("save", "image://svgimages/diagramicons/save.svg");
            // 
            // FormProduct
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(490, 458);
            Controls.Add(dataLayoutControl1);
            Controls.Add(barDockControlLeft);
            Controls.Add(barDockControlRight);
            Controls.Add(barDockControlBottom);
            Controls.Add(barDockControlTop);
            Name = "FormProduct";
            Text = "Məhsul";
            Load += FormProduct_Load;
            ((System.ComponentModel.ISupportInitialize)dataLayoutControl1).EndInit();
            dataLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)galleryControl1).EndInit();
            galleryControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)barAndDockingController1).EndInit();
            ((System.ComponentModel.ISupportInitialize)ProductCodeTextEdit.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)dcProductsBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)UsePosCheckEdit.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)PromotionCodeTextEdit.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)PromotionCode2TextEdit.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)TaxRateTextEdit.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)IsDisabledCheckEdit.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)ProductDescTextEdit.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)ProductTypeCodeLookUpEdit.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)PurchasePriceTextEdit.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)WholesalePriceTextEdit.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)RetailPriceTextEdit.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)PosDiscountTextEdit.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)UseInternetCheckEdit.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)BalanceTextEdit.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureEdit.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)textEdit_ProductCode2.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)btnEdit_Hierarchy.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtEdit_Price.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtEdit_Desc.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtEdit_Rating.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)btnEdit_Slug.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)ItemForUsePos).EndInit();
            ((System.ComponentModel.ISupportInitialize)ItemForPromotionCode).EndInit();
            ((System.ComponentModel.ISupportInitialize)ItemForPromotionCode2).EndInit();
            ((System.ComponentModel.ISupportInitialize)ItemForTaxRate).EndInit();
            ((System.ComponentModel.ISupportInitialize)Root).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlGroup1).EndInit();
            ((System.ComponentModel.ISupportInitialize)ItemForPosDiscount).EndInit();
            ((System.ComponentModel.ISupportInitialize)ItemForBalance).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem4).EndInit();
            ((System.ComponentModel.ISupportInitialize)ItemForProductCode).EndInit();
            ((System.ComponentModel.ISupportInitialize)ItemForProductTypeCode).EndInit();
            ((System.ComponentModel.ISupportInitialize)ItemForProductDesc).EndInit();
            ((System.ComponentModel.ISupportInitialize)ProductCode2).EndInit();
            ((System.ComponentModel.ISupportInitialize)lCI_hierarchyCode).EndInit();
            ((System.ComponentModel.ISupportInitialize)tabbedControlGroup1).EndInit();
            ((System.ComponentModel.ISupportInitialize)autoGroupForQiymətlər).EndInit();
            ((System.ComponentModel.ISupportInitialize)ItemForPurchasePrice).EndInit();
            ((System.ComponentModel.ISupportInitialize)ItemForWholesalePrice).EndInit();
            ((System.ComponentModel.ISupportInitialize)ItemForRetailPrice).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlGroup2).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem6).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem7).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem9).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem11).EndInit();
            ((System.ComponentModel.ISupportInitialize)emptySpaceItem2).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem2).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem1).EndInit();
            ((System.ComponentModel.ISupportInitialize)ItemForUseInternet).EndInit();
            ((System.ComponentModel.ISupportInitialize)ItemForIsDisabled).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem3).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridControl1).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridView2).EndInit();
            ((System.ComponentModel.ISupportInitialize)barManager1).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem8).EndInit();
            ((System.ComponentModel.ISupportInitialize)popupMenu_Gallery).EndInit();
            ((System.ComponentModel.ISupportInitialize)svgImageCollection1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DevExpress.XtraDataLayout.DataLayoutControl dataLayoutControl1;
        private System.Windows.Forms.BindingSource dcProductsBindingSource;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraEditors.CheckEdit UsePosCheckEdit;
        private DevExpress.XtraEditors.TextEdit PromotionCodeTextEdit;
        private DevExpress.XtraEditors.TextEdit PromotionCode2TextEdit;
        private DevExpress.XtraEditors.TextEdit TaxRateTextEdit;
        private DevExpress.XtraEditors.CheckEdit IsDisabledCheckEdit;
        private DevExpress.XtraEditors.TextEdit ProductDescTextEdit;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem ItemForUsePos;
        private DevExpress.XtraLayout.LayoutControlItem ItemForPromotionCode;
        private DevExpress.XtraLayout.LayoutControlItem ItemForPromotionCode2;
        private DevExpress.XtraLayout.LayoutControlItem ItemForTaxRate;
        private DevExpress.XtraLayout.LayoutControlItem ItemForIsDisabled;
        private DevExpress.XtraLayout.LayoutControlItem ItemForProductDesc;
        private DevExpress.XtraEditors.SimpleButton btn_Ok;
        private DevExpress.XtraEditors.SimpleButton btn_Cancel;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraEditors.LookUpEdit ProductTypeCodeLookUpEdit;
        private DevExpress.XtraLayout.LayoutControlItem ItemForProductTypeCode;
        private DevExpress.XtraEditors.TextEdit ProductCodeTextEdit;
        private DevExpress.XtraLayout.LayoutControlItem ItemForProductCode;
        private DevExpress.XtraEditors.TextEdit PurchasePriceTextEdit;
        private DevExpress.XtraEditors.TextEdit WholesalePriceTextEdit;
        private DevExpress.XtraEditors.TextEdit RetailPriceTextEdit;
        private DevExpress.XtraEditors.TextEdit PosDiscountTextEdit;
        private DevExpress.XtraEditors.CheckEdit UseInternetCheckEdit;
        private DevExpress.XtraLayout.LayoutControlItem ItemForUseInternet;
        private DevExpress.XtraLayout.LayoutControlItem ItemForPosDiscount;
        private DevExpress.XtraEditors.TextEdit BalanceTextEdit;
        private DevExpress.XtraLayout.LayoutControlItem ItemForBalance;
        private DevExpress.XtraEditors.PictureEdit pictureEdit;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraEditors.SimpleButton btn_SaveImage;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraEditors.TextEdit txtEdit_Price;
        private DevExpress.XtraLayout.LayoutControlItem ProductCode2;
        private DevExpress.XtraEditors.TextEdit textEdit_ProductCode;
        private DevExpress.XtraEditors.TextEdit textEdit_ProductCode2;
        private DevExpress.XtraEditors.ButtonEdit btnEdit_Hierarchy;
        private DevExpress.XtraLayout.LayoutControlItem lCI_hierarchyCode;
        private DevExpress.XtraLayout.TabbedControlGroup tabbedControlGroup1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private DevExpress.XtraLayout.LayoutControlGroup autoGroupForQiymətlər;
        private DevExpress.XtraLayout.LayoutControlItem ItemForPurchasePrice;
        private DevExpress.XtraLayout.LayoutControlItem ItemForWholesalePrice;
        private DevExpress.XtraLayout.LayoutControlItem ItemForRetailPrice;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraEditors.TextEdit txtEdit_Desc;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private DevExpress.XtraEditors.TextEdit txtEdit_Rating;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem9;
        private DevExpress.XtraEditors.ButtonEdit btnEdit_Slug;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem11;
        private DevExpress.XtraLayout.LayoutControlItem ItemForBarcode;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarAndDockingController barAndDockingController1;
        private DevExpress.XtraBars.BarButtonItem BBI_ProductFeature;
        private DevExpress.XtraBars.BarButtonItem BBI_ProductDiscount;
        private DevExpress.XtraBars.BarButtonItem BBI_ProductBarcode;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraBars.Ribbon.GalleryControl galleryControl1;
        private DevExpress.XtraBars.Ribbon.GalleryControlClient galleryControlClient1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraBars.PopupMenu popupMenu_Gallery;
        private DevExpress.XtraBars.BarButtonItem BBI_GalleryAdd;
        private DevExpress.XtraBars.BarButtonItem BBI_GalleryDelete;
        private DevExpress.XtraBars.BarButtonItem BBI_GalleryLoad;
        private DevExpress.XtraBars.BarButtonItem BBI_GalleryPaste;
        private SvgImageCollection svgImageCollection1;
        private DevExpress.XtraBars.BarButtonItem BBI_GalleryCopy;
    }
}