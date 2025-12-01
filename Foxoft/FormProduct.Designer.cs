using DevExpress.Utils;
using DevExpress.Utils.Drawing;
using DevExpress.XtraBars.Ribbon;
using Foxoft.Models;
using Foxoft.Properties;

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
            LUE_ProductTypeCode = new DevExpress.XtraEditors.LookUpEdit();
            PurchasePriceTextEdit = new DevExpress.XtraEditors.TextEdit();
            WholesalePriceTextEdit = new DevExpress.XtraEditors.TextEdit();
            RetailPriceTextEdit = new DevExpress.XtraEditors.TextEdit();
            PosDiscountTextEdit = new DevExpress.XtraEditors.TextEdit();
            UseInternetCheckEdit = new DevExpress.XtraEditors.CheckEdit();
            pictureEdit = new DevExpress.XtraEditors.PictureEdit();
            textEdit_ProductCode2 = new DevExpress.XtraEditors.TextEdit();
            btnEdit_Hierarchy = new DevExpress.XtraEditors.ButtonEdit();
            txtEdit_Price = new DevExpress.XtraEditors.TextEdit();
            txtEdit_Desc = new DevExpress.XtraEditors.TextEdit();
            txtEdit_Rating = new DevExpress.XtraEditors.TextEdit();
            btnEdit_Slug = new DevExpress.XtraEditors.ButtonEdit();
            btn_Apply = new DevExpress.XtraEditors.SimpleButton();
            LUE_DefaultUnitOfMeasureId = new DevExpress.XtraEditors.LookUpEdit();
            barManager1 = new DevExpress.XtraBars.BarManager(components);
            bar1 = new DevExpress.XtraBars.Bar();
            BBI_ProductFeature = new DevExpress.XtraBars.BarButtonItem();
            BBI_ProductDiscount = new DevExpress.XtraBars.BarButtonItem();
            BBI_ProductBarcode = new DevExpress.XtraBars.BarButtonItem();
            BBI_ProductStaticPriceList = new DevExpress.XtraBars.BarButtonItem();
            BBI_Scales = new DevExpress.XtraBars.BarButtonItem();
            bar3 = new DevExpress.XtraBars.Bar();
            barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            BBI_GalleryLoad = new DevExpress.XtraBars.BarButtonItem();
            BBI_GalleryDelete = new DevExpress.XtraBars.BarButtonItem();
            BBI_GalleryPaste = new DevExpress.XtraBars.BarButtonItem();
            BBI_GalleryCopy = new DevExpress.XtraBars.BarButtonItem();
            ItemForUsePos = new DevExpress.XtraLayout.LayoutControlItem();
            ItemForPromotionCode = new DevExpress.XtraLayout.LayoutControlItem();
            ItemForPromotionCode2 = new DevExpress.XtraLayout.LayoutControlItem();
            ItemForTaxRate = new DevExpress.XtraLayout.LayoutControlItem();
            Root = new DevExpress.XtraLayout.LayoutControlGroup();
            layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            ItemForPosDiscount = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            ItemForProductCode = new DevExpress.XtraLayout.LayoutControlItem();
            ItemForProductTypeCode = new DevExpress.XtraLayout.LayoutControlItem();
            ItemForProductDesc = new DevExpress.XtraLayout.LayoutControlItem();
            ProductCode2 = new DevExpress.XtraLayout.LayoutControlItem();
            lCI_hierarchyCode = new DevExpress.XtraLayout.LayoutControlItem();
            tabbedControlGroup1 = new DevExpress.XtraLayout.TabbedControlGroup();
            layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem9 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem11 = new DevExpress.XtraLayout.LayoutControlItem();
            autoGroupForPrices = new DevExpress.XtraLayout.LayoutControlGroup();
            ItemForPurchasePrice = new DevExpress.XtraLayout.LayoutControlItem();
            ItemForWholesalePrice = new DevExpress.XtraLayout.LayoutControlItem();
            ItemForRetailPrice = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            ItemForUseInternet = new DevExpress.XtraLayout.LayoutControlItem();
            ItemForIsDisabled = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem10 = new DevExpress.XtraLayout.LayoutControlItem();
            emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            ItemForDefaultUnitOfMeasureId = new DevExpress.XtraLayout.LayoutControlItem();
            gridControl1 = new DevExpress.XtraGrid.GridControl();
            gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            popupMenu_Gallery = new DevExpress.XtraBars.PopupMenu(components);
            svgImageCollection1 = new SvgImageCollection(components);
            dxErrorProvider1 = new DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider(components);
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
            ((System.ComponentModel.ISupportInitialize)LUE_ProductTypeCode.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PurchasePriceTextEdit.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)WholesalePriceTextEdit.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)RetailPriceTextEdit.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PosDiscountTextEdit.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)UseInternetCheckEdit.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureEdit.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)textEdit_ProductCode2.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btnEdit_Hierarchy.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtEdit_Price.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtEdit_Desc.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtEdit_Rating.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btnEdit_Slug.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LUE_DefaultUnitOfMeasureId.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)barManager1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ItemForUsePos).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ItemForPromotionCode).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ItemForPromotionCode2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ItemForTaxRate).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Root).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlGroup1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ItemForPosDiscount).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ItemForProductCode).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ItemForProductTypeCode).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ItemForProductDesc).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ProductCode2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)lCI_hierarchyCode).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tabbedControlGroup1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlGroup2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem6).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem7).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem9).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem11).BeginInit();
            ((System.ComponentModel.ISupportInitialize)autoGroupForPrices).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ItemForPurchasePrice).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ItemForWholesalePrice).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ItemForRetailPrice).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ItemForUseInternet).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ItemForIsDisabled).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem10).BeginInit();
            ((System.ComponentModel.ISupportInitialize)emptySpaceItem2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ItemForDefaultUnitOfMeasureId).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridControl1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridView2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem8).BeginInit();
            ((System.ComponentModel.ISupportInitialize)popupMenu_Gallery).BeginInit();
            ((System.ComponentModel.ISupportInitialize)svgImageCollection1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dxErrorProvider1).BeginInit();
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
            dataLayoutControl1.Controls.Add(LUE_ProductTypeCode);
            dataLayoutControl1.Controls.Add(PurchasePriceTextEdit);
            dataLayoutControl1.Controls.Add(WholesalePriceTextEdit);
            dataLayoutControl1.Controls.Add(RetailPriceTextEdit);
            dataLayoutControl1.Controls.Add(PosDiscountTextEdit);
            dataLayoutControl1.Controls.Add(UseInternetCheckEdit);
            dataLayoutControl1.Controls.Add(pictureEdit);
            dataLayoutControl1.Controls.Add(textEdit_ProductCode2);
            dataLayoutControl1.Controls.Add(btnEdit_Hierarchy);
            dataLayoutControl1.Controls.Add(txtEdit_Price);
            dataLayoutControl1.Controls.Add(txtEdit_Desc);
            dataLayoutControl1.Controls.Add(txtEdit_Rating);
            dataLayoutControl1.Controls.Add(btnEdit_Slug);
            dataLayoutControl1.Controls.Add(btn_Apply);
            dataLayoutControl1.Controls.Add(LUE_DefaultUnitOfMeasureId);
            dataLayoutControl1.DataSource = dcProductsBindingSource;
            dataLayoutControl1.Dock = DockStyle.Fill;
            dataLayoutControl1.HiddenItems.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] { ItemForUsePos, ItemForPromotionCode, ItemForPromotionCode2, ItemForTaxRate });
            dataLayoutControl1.Location = new Point(0, 0);
            dataLayoutControl1.Name = "dataLayoutControl1";
            dataLayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new Rectangle(1070, 296, 514, 400);
            dataLayoutControl1.Root = Root;
            dataLayoutControl1.Size = new Size(511, 376);
            dataLayoutControl1.TabIndex = 0;
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
            galleryControl1.Location = new Point(293, 191);
            galleryControl1.Name = "galleryControl1";
            galleryControl1.Size = new Size(189, 128);
            galleryControl1.StyleController = dataLayoutControl1;
            galleryControl1.TabIndex = 14;
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
            galleryControlClient1.Size = new Size(185, 107);
            // 
            // ProductCodeTextEdit
            // 
            ProductCodeTextEdit.DataBindings.Add(new Binding("EditValue", dcProductsBindingSource, "ProductCode", true));
            ProductCodeTextEdit.Location = new Point(138, 12);
            ProductCodeTextEdit.Name = "ProductCodeTextEdit";
            ProductCodeTextEdit.Size = new Size(106, 20);
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
            UsePosCheckEdit.Properties.Caption = Resources.Entity_Product_UsePos;
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
            IsDisabledCheckEdit.Properties.Caption = Resources.Common_IsDisabled;
            IsDisabledCheckEdit.Properties.GlyphAlignment = HorzAlignment.Default;
            IsDisabledCheckEdit.Size = new Size(145, 20);
            IsDisabledCheckEdit.StyleController = dataLayoutControl1;
            IsDisabledCheckEdit.TabIndex = 15;
            // 
            // ProductDescTextEdit
            // 
            ProductDescTextEdit.DataBindings.Add(new Binding("EditValue", dcProductsBindingSource, "ProductDesc", true));
            ProductDescTextEdit.Location = new Point(138, 36);
            ProductDescTextEdit.Name = "ProductDescTextEdit";
            ProductDescTextEdit.Size = new Size(344, 20);
            ProductDescTextEdit.StyleController = dataLayoutControl1;
            ProductDescTextEdit.TabIndex = 3;
            ProductDescTextEdit.Validating += ProductDescTextEdit_Validating;
            // 
            // btn_Ok
            // 
            btn_Ok.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            btn_Ok.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("btn_Ok.ImageOptions.SvgImage");
            btn_Ok.Location = new Point(408, 323);
            btn_Ok.Name = "btn_Ok";
            btn_Ok.Size = new Size(74, 62);
            btn_Ok.StyleController = dataLayoutControl1;
            btn_Ok.TabIndex = 19;
            btn_Ok.Click += btn_Ok_Click;
            // 
            // btn_Cancel
            // 
            btn_Cancel.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            btn_Cancel.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("btn_Cancel.ImageOptions.SvgImage");
            btn_Cancel.Location = new Point(330, 323);
            btn_Cancel.Name = "btn_Cancel";
            btn_Cancel.Size = new Size(74, 62);
            btn_Cancel.StyleController = dataLayoutControl1;
            btn_Cancel.TabIndex = 18;
            // 
            // LUE_ProductTypeCode
            // 
            LUE_ProductTypeCode.DataBindings.Add(new Binding("EditValue", dcProductsBindingSource, "ProductTypeCode", true));
            LUE_ProductTypeCode.Location = new Point(374, 12);
            LUE_ProductTypeCode.Name = "LUE_ProductTypeCode";
            LUE_ProductTypeCode.Properties.Appearance.Options.UseTextOptions = true;
            LUE_ProductTypeCode.Properties.Appearance.TextOptions.HAlignment = HorzAlignment.Far;
            LUE_ProductTypeCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            LUE_ProductTypeCode.Properties.DisplayMember = "ProductTypeDesc";
            LUE_ProductTypeCode.Properties.NullText = "";
            LUE_ProductTypeCode.Properties.ValueMember = "ProductTypeCode";
            LUE_ProductTypeCode.Size = new Size(108, 20);
            LUE_ProductTypeCode.StyleController = dataLayoutControl1;
            LUE_ProductTypeCode.TabIndex = 2;
            // 
            // PurchasePriceTextEdit
            // 
            PurchasePriceTextEdit.DataBindings.Add(new Binding("EditValue", dcProductsBindingSource, "PurchasePrice", true));
            PurchasePriceTextEdit.Location = new Point(150, 191);
            PurchasePriceTextEdit.Name = "PurchasePriceTextEdit";
            PurchasePriceTextEdit.Properties.Appearance.Options.UseTextOptions = true;
            PurchasePriceTextEdit.Properties.Appearance.TextOptions.HAlignment = HorzAlignment.Far;
            PurchasePriceTextEdit.Properties.Mask.EditMask = "G";
            PurchasePriceTextEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            PurchasePriceTextEdit.Properties.Mask.UseMaskAsDisplayFormat = true;
            PurchasePriceTextEdit.Size = new Size(127, 20);
            PurchasePriceTextEdit.StyleController = dataLayoutControl1;
            PurchasePriceTextEdit.TabIndex = 1;
            // 
            // WholesalePriceTextEdit
            // 
            WholesalePriceTextEdit.DataBindings.Add(new Binding("EditValue", dcProductsBindingSource, "WholesalePrice", true));
            WholesalePriceTextEdit.Location = new Point(150, 215);
            WholesalePriceTextEdit.Name = "WholesalePriceTextEdit";
            WholesalePriceTextEdit.Properties.Appearance.Options.UseTextOptions = true;
            WholesalePriceTextEdit.Properties.Appearance.TextOptions.HAlignment = HorzAlignment.Far;
            WholesalePriceTextEdit.Properties.Mask.EditMask = "G";
            WholesalePriceTextEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            WholesalePriceTextEdit.Properties.Mask.UseMaskAsDisplayFormat = true;
            WholesalePriceTextEdit.Size = new Size(127, 20);
            WholesalePriceTextEdit.StyleController = dataLayoutControl1;
            WholesalePriceTextEdit.TabIndex = 1;
            // 
            // RetailPriceTextEdit
            // 
            RetailPriceTextEdit.DataBindings.Add(new Binding("EditValue", dcProductsBindingSource, "RetailPrice", true));
            RetailPriceTextEdit.Location = new Point(150, 239);
            RetailPriceTextEdit.Name = "RetailPriceTextEdit";
            RetailPriceTextEdit.Properties.Appearance.Options.UseTextOptions = true;
            RetailPriceTextEdit.Properties.Appearance.TextOptions.HAlignment = HorzAlignment.Far;
            RetailPriceTextEdit.Properties.Mask.EditMask = "G";
            RetailPriceTextEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            RetailPriceTextEdit.Properties.Mask.UseMaskAsDisplayFormat = true;
            RetailPriceTextEdit.Size = new Size(127, 20);
            RetailPriceTextEdit.StyleController = dataLayoutControl1;
            RetailPriceTextEdit.TabIndex = 1;
            // 
            // PosDiscountTextEdit
            // 
            PosDiscountTextEdit.DataBindings.Add(new Binding("EditValue", dcProductsBindingSource, "PosDiscount", true));
            PosDiscountTextEdit.Location = new Point(138, 84);
            PosDiscountTextEdit.Name = "PosDiscountTextEdit";
            PosDiscountTextEdit.Properties.Appearance.Options.UseTextOptions = true;
            PosDiscountTextEdit.Properties.Appearance.TextOptions.HAlignment = HorzAlignment.Far;
            PosDiscountTextEdit.Properties.Mask.EditMask = "F";
            PosDiscountTextEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            PosDiscountTextEdit.Properties.Mask.UseMaskAsDisplayFormat = true;
            PosDiscountTextEdit.Size = new Size(151, 20);
            PosDiscountTextEdit.StyleController = dataLayoutControl1;
            PosDiscountTextEdit.TabIndex = 4;
            // 
            // UseInternetCheckEdit
            // 
            UseInternetCheckEdit.DataBindings.Add(new Binding("EditValue", dcProductsBindingSource, "UseInternet", true));
            UseInternetCheckEdit.Location = new Point(161, 299);
            UseInternetCheckEdit.Name = "UseInternetCheckEdit";
            UseInternetCheckEdit.Properties.Caption = Resources.Entity_Product_UseInternet;
            UseInternetCheckEdit.Properties.GlyphAlignment = HorzAlignment.Default;
            UseInternetCheckEdit.Size = new Size(128, 20);
            UseInternetCheckEdit.StyleController = dataLayoutControl1;
            UseInternetCheckEdit.TabIndex = 16;
            // 
            // pictureEdit
            // 
            pictureEdit.Location = new Point(293, 60);
            pictureEdit.Name = "pictureEdit";
            pictureEdit.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            pictureEdit.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom;
            pictureEdit.Size = new Size(189, 127);
            pictureEdit.StyleController = dataLayoutControl1;
            pictureEdit.TabIndex = 1;
            pictureEdit.PopupMenuShowing += pictureEdit_PopupMenuShowing;
            pictureEdit.EditValueChanged += pictureEdit_EditValueChanged;
            pictureEdit.DoubleClick += pictureEdit_DoubleClick;
            // 
            // textEdit_ProductCode2
            // 
            textEdit_ProductCode2.DataBindings.Add(new Binding("EditValue", dcProductsBindingSource, "ProductCode2", true));
            textEdit_ProductCode2.Location = new Point(138, 108);
            textEdit_ProductCode2.Name = "textEdit_ProductCode2";
            textEdit_ProductCode2.Size = new Size(151, 20);
            textEdit_ProductCode2.StyleController = dataLayoutControl1;
            textEdit_ProductCode2.TabIndex = 6;
            // 
            // btnEdit_Hierarchy
            // 
            btnEdit_Hierarchy.DataBindings.Add(new Binding("EditValue", dcProductsBindingSource, "HierarchyCode", true));
            btnEdit_Hierarchy.Location = new Point(138, 132);
            btnEdit_Hierarchy.Name = "btnEdit_Hierarchy";
            btnEdit_Hierarchy.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton() });
            btnEdit_Hierarchy.Size = new Size(151, 20);
            btnEdit_Hierarchy.StyleController = dataLayoutControl1;
            btnEdit_Hierarchy.TabIndex = 7;
            btnEdit_Hierarchy.ButtonPressed += btnEdit_Hierarchy_ButtonPressed;
            btnEdit_Hierarchy.EditValueChanged += btnEdit_Hierarchy_EditValueChanged;
            // 
            // txtEdit_Price
            // 
            txtEdit_Price.DataBindings.Add(new Binding("EditValue", dcProductsBindingSource, "SiteProduct.Price", true));
            txtEdit_Price.Location = new Point(150, 191);
            txtEdit_Price.Name = "txtEdit_Price";
            txtEdit_Price.Size = new Size(127, 20);
            txtEdit_Price.StyleController = dataLayoutControl1;
            txtEdit_Price.TabIndex = 10;
            // 
            // txtEdit_Desc
            // 
            txtEdit_Desc.DataBindings.Add(new Binding("EditValue", dcProductsBindingSource, "SiteProduct.Desc", true));
            txtEdit_Desc.Location = new Point(150, 215);
            txtEdit_Desc.Name = "txtEdit_Desc";
            txtEdit_Desc.Size = new Size(127, 20);
            txtEdit_Desc.StyleController = dataLayoutControl1;
            txtEdit_Desc.TabIndex = 11;
            // 
            // txtEdit_Rating
            // 
            txtEdit_Rating.DataBindings.Add(new Binding("EditValue", dcProductsBindingSource, "SiteProduct.Rating", true));
            txtEdit_Rating.Location = new Point(150, 263);
            txtEdit_Rating.Name = "txtEdit_Rating";
            txtEdit_Rating.Size = new Size(127, 20);
            txtEdit_Rating.StyleController = dataLayoutControl1;
            txtEdit_Rating.TabIndex = 13;
            // 
            // btnEdit_Slug
            // 
            btnEdit_Slug.DataBindings.Add(new Binding("EditValue", dcProductsBindingSource, "SiteProduct.Slug", true));
            btnEdit_Slug.Location = new Point(150, 239);
            btnEdit_Slug.Name = "btnEdit_Slug";
            btnEdit_Slug.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Plus) });
            btnEdit_Slug.Size = new Size(127, 20);
            btnEdit_Slug.StyleController = dataLayoutControl1;
            btnEdit_Slug.TabIndex = 12;
            btnEdit_Slug.ButtonPressed += BtnEdit_Slug_ButtonPressed;
            // 
            // btn_Apply
            // 
            btn_Apply.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            btn_Apply.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("btn_Apply.ImageOptions.SvgImage");
            btn_Apply.Location = new Point(252, 323);
            btn_Apply.Name = "btn_Apply";
            btn_Apply.Size = new Size(74, 62);
            btn_Apply.StyleController = dataLayoutControl1;
            btn_Apply.TabIndex = 17;
            btn_Apply.Click += btn_Apply_Click;
            // 
            // LUE_DefaultUnitOfMeasureId
            // 
            LUE_DefaultUnitOfMeasureId.DataBindings.Add(new Binding("EditValue", dcProductsBindingSource, "DefaultUnitOfMeasureId", true));
            LUE_DefaultUnitOfMeasureId.Location = new Point(138, 60);
            LUE_DefaultUnitOfMeasureId.MenuManager = barManager1;
            LUE_DefaultUnitOfMeasureId.Name = "LUE_DefaultUnitOfMeasureId";
            LUE_DefaultUnitOfMeasureId.Properties.Appearance.Options.UseTextOptions = true;
            LUE_DefaultUnitOfMeasureId.Properties.Appearance.TextOptions.HAlignment = HorzAlignment.Far;
            LUE_DefaultUnitOfMeasureId.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            LUE_DefaultUnitOfMeasureId.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
                new DevExpress.XtraEditors.Controls.LookUpColumnInfo("UnitOfMeasureId", Resources.Entity_UnitOfMeasure_Id),
                new DevExpress.XtraEditors.Controls.LookUpColumnInfo("UnitOfMeasureDesc", Resources.Entity_UnitOfMeasure_Desc)
            });
            LUE_DefaultUnitOfMeasureId.Properties.DisplayMember = "UnitOfMeasureDesc";
            LUE_DefaultUnitOfMeasureId.Properties.NullText = "";
            LUE_DefaultUnitOfMeasureId.Properties.ValueMember = "UnitOfMeasureId";
            LUE_DefaultUnitOfMeasureId.Size = new Size(151, 20);
            LUE_DefaultUnitOfMeasureId.StyleController = dataLayoutControl1;
            LUE_DefaultUnitOfMeasureId.TabIndex = 8;
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
            barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] { BBI_ProductFeature, BBI_ProductDiscount, BBI_ProductBarcode, BBI_GalleryLoad, BBI_GalleryDelete, BBI_GalleryPaste, BBI_GalleryCopy, BBI_ProductStaticPriceList, BBI_Scales });
            barManager1.MaxItemId = 11;
            barManager1.StatusBar = bar3;
            // 
            // bar1
            // 
            bar1.BarName = "Tools";
            bar1.DockCol = 0;
            bar1.DockRow = 1;
            bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] { new DevExpress.XtraBars.LinkPersistInfo(BBI_ProductFeature), new DevExpress.XtraBars.LinkPersistInfo(BBI_ProductDiscount), new DevExpress.XtraBars.LinkPersistInfo(BBI_ProductBarcode), new DevExpress.XtraBars.LinkPersistInfo(BBI_ProductStaticPriceList), new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, BBI_Scales, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph) });
            // 
            // BBI_ProductFeature
            // 
            BBI_ProductFeature.Caption = Resources.Common_Feature;
            BBI_ProductFeature.Enabled = false;
            BBI_ProductFeature.Id = 0;
            BBI_ProductFeature.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("BBI_ProductFeature.ImageOptions.SvgImage");
            BBI_ProductFeature.Name = "BBI_ProductFeature";
            BBI_ProductFeature.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            BBI_ProductFeature.ItemClick += BBI_ProductFeature_ItemClick;
            // 
            // BBI_ProductDiscount
            // 
            BBI_ProductDiscount.Caption = Resources.Common_Discount;
            BBI_ProductDiscount.Enabled = false;
            BBI_ProductDiscount.Id = 1;
            BBI_ProductDiscount.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("BBI_ProductDiscount.ImageOptions.SvgImage");
            BBI_ProductDiscount.Name = "BBI_ProductDiscount";
            BBI_ProductDiscount.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            BBI_ProductDiscount.ItemClick += BBI_ProductDiscount_ItemClick;
            // 
            // BBI_ProductBarcode
            // 
            BBI_ProductBarcode.Caption = Resources.Entity_ProductBarcode_Barcode;
            BBI_ProductBarcode.Enabled = false;
            BBI_ProductBarcode.Id = 2;
            BBI_ProductBarcode.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("BBI_ProductBarcode.ImageOptions.SvgImage");
            BBI_ProductBarcode.Name = "BBI_ProductBarcode";
            BBI_ProductBarcode.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            BBI_ProductBarcode.ItemClick += BBI_ProductBarcode_ItemClick;
            // 
            // BBI_ProductStaticPriceList
            // 
            BBI_ProductStaticPriceList.Caption = Resources.Common_PriceList;
            BBI_ProductStaticPriceList.Enabled = false;
            BBI_ProductStaticPriceList.Id = 9;
            BBI_ProductStaticPriceList.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("BBI_ProductStaticPriceList.ImageOptions.SvgImage");
            BBI_ProductStaticPriceList.Name = "BBI_ProductStaticPriceList";
            BBI_ProductStaticPriceList.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            BBI_ProductStaticPriceList.ItemClick += BBI_ProductStaticPriceList_ItemClick;
            // 
            // BBI_Scales
            // 
            BBI_Scales.Caption = Resources.Common_Scales;
            BBI_Scales.Enabled = false;
            BBI_Scales.Id = 10;
            BBI_Scales.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("BBI_Scales.ImageOptions.SvgImage");
            BBI_Scales.Name = "BBI_Scales";
            BBI_Scales.ItemClick += BBI_Scales_ItemClick;
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
            // 
            // barDockControlTop
            // 
            barDockControlTop.CausesValidation = false;
            barDockControlTop.Dock = DockStyle.Top;
            barDockControlTop.Location = new Point(0, 0);
            barDockControlTop.Manager = barManager1;
            barDockControlTop.Size = new Size(511, 0);
            // 
            // barDockControlBottom
            // 
            barDockControlBottom.CausesValidation = false;
            barDockControlBottom.Dock = DockStyle.Bottom;
            barDockControlBottom.Location = new Point(0, 376);
            barDockControlBottom.Manager = barManager1;
            barDockControlBottom.Size = new Size(511, 61);
            // 
            // barDockControlLeft
            // 
            barDockControlLeft.CausesValidation = false;
            barDockControlLeft.Dock = DockStyle.Left;
            barDockControlLeft.Location = new Point(0, 0);
            barDockControlLeft.Manager = barManager1;
            barDockControlLeft.Size = new Size(0, 376);
            // 
            // barDockControlRight
            // 
            barDockControlRight.CausesValidation = false;
            barDockControlRight.Dock = DockStyle.Right;
            barDockControlRight.Location = new Point(511, 0);
            barDockControlRight.Manager = barManager1;
            barDockControlRight.Size = new Size(0, 376);
            // 
            // BBI_GalleryLoad
            // 
            BBI_GalleryLoad.Caption = Resources.Common_Load;
            BBI_GalleryLoad.Id = 4;
            BBI_GalleryLoad.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("BBI_GalleryLoad.ImageOptions.SvgImage");
            BBI_GalleryLoad.Name = "BBI_GalleryLoad";
            BBI_GalleryLoad.ShowItemShortcut = DefaultBoolean.True;
            BBI_GalleryLoad.ItemClick += BBI_GalleryLoad_ItemClick;
            // 
            // BBI_GalleryDelete
            // 
            BBI_GalleryDelete.Caption = Resources.Common_Delete;
            BBI_GalleryDelete.Id = 5;
            BBI_GalleryDelete.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("BBI_GalleryDelete.ImageOptions.SvgImage");
            BBI_GalleryDelete.Name = "BBI_GalleryDelete";
            BBI_GalleryDelete.ItemClick += BBI_GalleryDelete_ItemClick;
            // 
            // BBI_GalleryPaste
            // 
            BBI_GalleryPaste.Caption = Resources.Common_Delete;
            BBI_GalleryPaste.Id = 6;
            BBI_GalleryPaste.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("BBI_GalleryPaste.ImageOptions.SvgImage");
            BBI_GalleryPaste.Name = "BBI_GalleryPaste";
            BBI_GalleryPaste.ItemClick += BBI_GalleryPaste_ItemClick;
            // 
            // BBI_GalleryCopy
            // 
            BBI_GalleryCopy.Caption = Resources.Common_Copy;
            BBI_GalleryCopy.Id = 7;
            BBI_GalleryCopy.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("BBI_GalleryCopy.ImageOptions.SvgImage");
            BBI_GalleryCopy.Name = "BBI_GalleryCopy";
            BBI_GalleryCopy.ItemClick += BBI_GalleryCopy_ItemClick;
            // 
            // ItemForUsePos
            // 
            ItemForUsePos.Control = UsePosCheckEdit;
            ItemForUsePos.Location = new Point(304, 141);
            ItemForUsePos.Name = "ItemForUsePos";
            ItemForUsePos.Size = new Size(121, 27);
            ItemForUsePos.TextVisible = false;
            // 
            // ItemForPromotionCode
            // 
            ItemForPromotionCode.Control = PromotionCodeTextEdit;
            ItemForPromotionCode.Location = new Point(0, 120);
            ItemForPromotionCode.Name = "ItemForPromotionCode";
            ItemForPromotionCode.Size = new Size(304, 24);
            ItemForPromotionCode.TextSize = new Size(93, 13);
            // 
            // ItemForPromotionCode2
            // 
            ItemForPromotionCode2.Control = PromotionCode2TextEdit;
            ItemForPromotionCode2.Location = new Point(0, 120);
            ItemForPromotionCode2.Name = "ItemForPromotionCode2";
            ItemForPromotionCode2.Size = new Size(304, 48);
            ItemForPromotionCode2.TextSize = new Size(93, 13);
            // 
            // ItemForTaxRate
            // 
            ItemForTaxRate.Control = TaxRateTextEdit;
            ItemForTaxRate.Location = new Point(0, 24);
            ItemForTaxRate.Name = "ItemForTaxRate";
            ItemForTaxRate.Size = new Size(304, 72);
            ItemForTaxRate.TextSize = new Size(93, 13);
            // 
            // Root
            // 
            Root.EnableIndentsWithoutBorders = DefaultBoolean.True;
            Root.GroupBordersVisible = false;
            Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] { layoutControlGroup1 });
            Root.Name = "Root";
            Root.Size = new Size(494, 397);
            Root.TextVisible = false;
            // 
            // layoutControlGroup1
            // 
            layoutControlGroup1.AllowDrawBackground = false;
            layoutControlGroup1.GroupBordersVisible = false;
            layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] { ItemForPosDiscount, layoutControlItem4, ItemForProductCode, ItemForProductTypeCode, ItemForProductDesc, ProductCode2, lCI_hierarchyCode, tabbedControlGroup1, layoutControlItem2, layoutControlItem1, ItemForUseInternet, ItemForIsDisabled, layoutControlItem3, layoutControlItem10, emptySpaceItem2, ItemForDefaultUnitOfMeasureId });
            layoutControlGroup1.Location = new Point(0, 0);
            layoutControlGroup1.Name = "autoGeneratedGroup0";
            layoutControlGroup1.Size = new Size(474, 377);
            // 
            // ItemForPosDiscount
            // 
            ItemForPosDiscount.Control = PosDiscountTextEdit;
            ItemForPosDiscount.Location = new Point(0, 72);
            ItemForPosDiscount.Name = "ItemForPosDiscount";
            ItemForPosDiscount.Size = new Size(281, 24);
            ItemForPosDiscount.TextSize = new Size(114, 13);
            // 
            // layoutControlItem4
            // 
            layoutControlItem4.Control = pictureEdit;
            layoutControlItem4.Location = new Point(281, 48);
            layoutControlItem4.MinSize = new Size(24, 24);
            layoutControlItem4.Name = "layoutControlItem4";
            layoutControlItem4.Size = new Size(193, 131);
            layoutControlItem4.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            layoutControlItem4.TextVisible = false;
            // 
            // ItemForProductCode
            // 
            ItemForProductCode.Control = ProductCodeTextEdit;
            ItemForProductCode.Location = new Point(0, 0);
            ItemForProductCode.Name = "ItemForProductCode";
            ItemForProductCode.Size = new Size(236, 24);
            ItemForProductCode.TextSize = new Size(114, 13);
            // 
            // ItemForProductTypeCode
            // 
            ItemForProductTypeCode.Control = LUE_ProductTypeCode;
            ItemForProductTypeCode.Location = new Point(236, 0);
            ItemForProductTypeCode.Name = "ItemForProductTypeCode";
            ItemForProductTypeCode.Size = new Size(238, 24);
            ItemForProductTypeCode.TextSize = new Size(114, 13);
            // 
            // ItemForProductDesc
            // 
            ItemForProductDesc.Control = ProductDescTextEdit;
            ItemForProductDesc.Location = new Point(0, 24);
            ItemForProductDesc.Name = "ItemForProductDesc";
            ItemForProductDesc.Size = new Size(474, 24);
            ItemForProductDesc.TextSize = new Size(114, 13);
            // 
            // ProductCode2
            // 
            ProductCode2.Control = textEdit_ProductCode2;
            ProductCode2.Location = new Point(0, 96);
            ProductCode2.Name = "ProductCode2";
            ProductCode2.Size = new Size(281, 24);
            ProductCode2.TextSize = new Size(114, 13);
            // 
            // lCI_hierarchyCode
            // 
            lCI_hierarchyCode.Control = btnEdit_Hierarchy;
            lCI_hierarchyCode.Location = new Point(0, 120);
            lCI_hierarchyCode.Name = "lCI_hierarchyCode";
            lCI_hierarchyCode.Size = new Size(281, 24);
            lCI_hierarchyCode.TextSize = new Size(114, 13);
            // 
            // tabbedControlGroup1
            // 
            tabbedControlGroup1.Location = new Point(0, 144);
            tabbedControlGroup1.Name = "tabbedControlGroup1";
            tabbedControlGroup1.SelectedTabPage = layoutControlGroup2;
            tabbedControlGroup1.Size = new Size(281, 143);
            tabbedControlGroup1.TabPages.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] { autoGroupForPrices, layoutControlGroup2 });
            // 
            // layoutControlGroup2
            // 
            layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] { layoutControlItem6, layoutControlItem7, layoutControlItem9, layoutControlItem11 });
            layoutControlGroup2.Location = new Point(0, 0);
            layoutControlGroup2.Name = "layoutControlGroup2";
            layoutControlGroup2.Size = new Size(257, 96);
            layoutControlGroup2.Text = Resources.Common_Site;
            // 
            // layoutControlItem6
            // 
            layoutControlItem6.Control = txtEdit_Price;
            layoutControlItem6.Location = new Point(0, 0);
            layoutControlItem6.Name = "layoutControlItem6";
            layoutControlItem6.Size = new Size(257, 24);
            layoutControlItem6.TextSize = new Size(114, 13);
            // 
            // layoutControlItem7
            // 
            layoutControlItem7.Control = txtEdit_Desc;
            layoutControlItem7.Location = new Point(0, 24);
            layoutControlItem7.Name = "layoutControlItem7";
            layoutControlItem7.Size = new Size(257, 24);
            layoutControlItem7.TextSize = new Size(114, 13);
            // 
            // layoutControlItem9
            // 
            layoutControlItem9.Control = txtEdit_Rating;
            layoutControlItem9.Location = new Point(0, 72);
            layoutControlItem9.Name = "layoutControlItem9";
            layoutControlItem9.Size = new Size(257, 24);
            layoutControlItem9.TextSize = new Size(114, 13);
            // 
            // layoutControlItem11
            // 
            layoutControlItem11.Control = btnEdit_Slug;
            layoutControlItem11.Location = new Point(0, 48);
            layoutControlItem11.Name = "layoutControlItem11";
            layoutControlItem11.Size = new Size(257, 24);
            layoutControlItem11.TextSize = new Size(114, 13);
            // 
            // autoGroupForPrices
            // 
            autoGroupForPrices.GroupStyle = GroupStyle.Light;
            autoGroupForPrices.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] { ItemForPurchasePrice, ItemForWholesalePrice, ItemForRetailPrice });
            autoGroupForPrices.Location = new Point(0, 0);
            autoGroupForPrices.Name = "autoGroupForQiymətlər";
            autoGroupForPrices.Size = new Size(257, 96);
            autoGroupForPrices.Text = Resources.Entity_Product_Prices;
            // 
            // ItemForPurchasePrice
            // 
            ItemForPurchasePrice.Control = PurchasePriceTextEdit;
            ItemForPurchasePrice.Location = new Point(0, 0);
            ItemForPurchasePrice.Name = "ItemForPurchasePrice";
            ItemForPurchasePrice.Size = new Size(257, 24);
            ItemForPurchasePrice.TextSize = new Size(114, 13);
            // 
            // ItemForWholesalePrice
            // 
            ItemForWholesalePrice.Control = WholesalePriceTextEdit;
            ItemForWholesalePrice.Location = new Point(0, 24);
            ItemForWholesalePrice.Name = "ItemForWholesalePrice";
            ItemForWholesalePrice.Size = new Size(257, 24);
            ItemForWholesalePrice.TextSize = new Size(114, 13);
            // 
            // ItemForRetailPrice
            // 
            ItemForRetailPrice.Control = RetailPriceTextEdit;
            ItemForRetailPrice.Location = new Point(0, 48);
            ItemForRetailPrice.Name = "ItemForRetailPrice";
            ItemForRetailPrice.Size = new Size(257, 48);
            ItemForRetailPrice.TextSize = new Size(114, 13);
            // 
            // layoutControlItem2
            // 
            layoutControlItem2.Control = btn_Cancel;
            layoutControlItem2.Location = new Point(318, 311);
            layoutControlItem2.MaxSize = new Size(78, 66);
            layoutControlItem2.MinSize = new Size(78, 66);
            layoutControlItem2.Name = "layoutControlItem2";
            layoutControlItem2.Size = new Size(78, 66);
            layoutControlItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            layoutControlItem2.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            layoutControlItem1.Control = btn_Ok;
            layoutControlItem1.Location = new Point(396, 311);
            layoutControlItem1.MaxSize = new Size(78, 66);
            layoutControlItem1.MinSize = new Size(78, 66);
            layoutControlItem1.Name = "layoutControlItem1";
            layoutControlItem1.Size = new Size(78, 66);
            layoutControlItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            layoutControlItem1.TextVisible = false;
            // 
            // ItemForUseInternet
            // 
            ItemForUseInternet.Control = UseInternetCheckEdit;
            ItemForUseInternet.Location = new Point(149, 287);
            ItemForUseInternet.Name = "ItemForUseInternet";
            ItemForUseInternet.Size = new Size(132, 24);
            ItemForUseInternet.TextVisible = false;
            // 
            // ItemForIsDisabled
            // 
            ItemForIsDisabled.Control = IsDisabledCheckEdit;
            ItemForIsDisabled.Location = new Point(0, 287);
            ItemForIsDisabled.Name = "ItemForIsDisabled";
            ItemForIsDisabled.Size = new Size(149, 24);
            ItemForIsDisabled.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            layoutControlItem3.Control = galleryControl1;
            layoutControlItem3.Location = new Point(281, 179);
            layoutControlItem3.Name = "layoutControlItem3";
            layoutControlItem3.Size = new Size(193, 132);
            layoutControlItem3.TextVisible = false;
            // 
            // layoutControlItem10
            // 
            layoutControlItem10.Control = btn_Apply;
            layoutControlItem10.Location = new Point(240, 311);
            layoutControlItem10.MaxSize = new Size(78, 66);
            layoutControlItem10.MinSize = new Size(78, 66);
            layoutControlItem10.Name = "layoutControlItem10";
            layoutControlItem10.Size = new Size(78, 66);
            layoutControlItem10.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            layoutControlItem10.TextVisible = false;
            // 
            // emptySpaceItem2
            // 
            emptySpaceItem2.Location = new Point(0, 311);
            emptySpaceItem2.Name = "emptySpaceItem2";
            emptySpaceItem2.Size = new Size(240, 66);
            // 
            // ItemForDefaultUnitOfMeasureId
            // 
            ItemForDefaultUnitOfMeasureId.Control = LUE_DefaultUnitOfMeasureId;
            ItemForDefaultUnitOfMeasureId.Location = new Point(0, 48);
            ItemForDefaultUnitOfMeasureId.Name = "ItemForDefaultUnitOfMeasureId";
            ItemForDefaultUnitOfMeasureId.Size = new Size(281, 24);
            ItemForDefaultUnitOfMeasureId.TextSize = new Size(114, 13);
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
            // layoutControlItem8
            // 
            layoutControlItem8.Location = new Point(102, 335);
            layoutControlItem8.Name = "layoutControlItem10";
            layoutControlItem8.Size = new Size(168, 67);
            layoutControlItem8.TextVisible = false;
            // 
            // popupMenu_Gallery
            // 
            popupMenu_Gallery.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] { new DevExpress.XtraBars.LinkPersistInfo(BBI_GalleryCopy), new DevExpress.XtraBars.LinkPersistInfo(BBI_GalleryPaste), new DevExpress.XtraBars.LinkPersistInfo(BBI_GalleryLoad), new DevExpress.XtraBars.LinkPersistInfo(BBI_GalleryDelete) });
            popupMenu_Gallery.Manager = barManager1;
            popupMenu_Gallery.Name = "popupMenu_Gallery";
            popupMenu_Gallery.BeforePopup += popupMenu_Gallery_BeforePopup;
            // 
            // svgImageCollection1
            // 
            svgImageCollection1.Add("save", "image://svgimages/diagramicons/save.svg");
            // 
            // dxErrorProvider1
            // 
            dxErrorProvider1.ContainerControl = this;
            // 
            // FormProduct
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoValidate = AutoValidate.EnableAllowFocusChange;
            ClientSize = new Size(511, 437);
            Controls.Add(dataLayoutControl1);
            Controls.Add(barDockControlLeft);
            Controls.Add(barDockControlRight);
            Controls.Add(barDockControlBottom);
            Controls.Add(barDockControlTop);
            Name = "FormProduct";
            Text = Resources.Form_Product_Caption;
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
            ((System.ComponentModel.ISupportInitialize)LUE_ProductTypeCode.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)PurchasePriceTextEdit.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)WholesalePriceTextEdit.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)RetailPriceTextEdit.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)PosDiscountTextEdit.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)UseInternetCheckEdit.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureEdit.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)textEdit_ProductCode2.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)btnEdit_Hierarchy.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtEdit_Price.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtEdit_Desc.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtEdit_Rating.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)btnEdit_Slug.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)LUE_DefaultUnitOfMeasureId.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)barManager1).EndInit();
            ((System.ComponentModel.ISupportInitialize)ItemForUsePos).EndInit();
            ((System.ComponentModel.ISupportInitialize)ItemForPromotionCode).EndInit();
            ((System.ComponentModel.ISupportInitialize)ItemForPromotionCode2).EndInit();
            ((System.ComponentModel.ISupportInitialize)ItemForTaxRate).EndInit();
            ((System.ComponentModel.ISupportInitialize)Root).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlGroup1).EndInit();
            ((System.ComponentModel.ISupportInitialize)ItemForPosDiscount).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem4).EndInit();
            ((System.ComponentModel.ISupportInitialize)ItemForProductCode).EndInit();
            ((System.ComponentModel.ISupportInitialize)ItemForProductTypeCode).EndInit();
            ((System.ComponentModel.ISupportInitialize)ItemForProductDesc).EndInit();
            ((System.ComponentModel.ISupportInitialize)ProductCode2).EndInit();
            ((System.ComponentModel.ISupportInitialize)lCI_hierarchyCode).EndInit();
            ((System.ComponentModel.ISupportInitialize)tabbedControlGroup1).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlGroup2).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem6).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem7).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem9).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem11).EndInit();
            ((System.ComponentModel.ISupportInitialize)autoGroupForPrices).EndInit();
            ((System.ComponentModel.ISupportInitialize)ItemForPurchasePrice).EndInit();
            ((System.ComponentModel.ISupportInitialize)ItemForWholesalePrice).EndInit();
            ((System.ComponentModel.ISupportInitialize)ItemForRetailPrice).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem2).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem1).EndInit();
            ((System.ComponentModel.ISupportInitialize)ItemForUseInternet).EndInit();
            ((System.ComponentModel.ISupportInitialize)ItemForIsDisabled).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem3).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem10).EndInit();
            ((System.ComponentModel.ISupportInitialize)emptySpaceItem2).EndInit();
            ((System.ComponentModel.ISupportInitialize)ItemForDefaultUnitOfMeasureId).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridControl1).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridView2).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem8).EndInit();
            ((System.ComponentModel.ISupportInitialize)popupMenu_Gallery).EndInit();
            ((System.ComponentModel.ISupportInitialize)svgImageCollection1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dxErrorProvider1).EndInit();
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
        private DevExpress.XtraEditors.LookUpEdit LUE_ProductTypeCode;
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
        private DevExpress.XtraLayout.LayoutControlGroup autoGroupForPrices;
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
        private DevExpress.XtraBars.BarButtonItem BBI_StaticPriceList;
        private DevExpress.XtraBars.BarButtonItem BBI_ProductStaticPriceList;
        private DevExpress.XtraEditors.SimpleButton btn_Apply;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem10;
        private DevExpress.XtraEditors.LookUpEdit DefaultUnitOfMeasureIdLookUpEdit;
        private DevExpress.XtraLayout.LayoutControlItem ItemForDefaultUnitOfMeasureId;
        private DevExpress.XtraEditors.LookUpEdit LUE_DefaultUnitOfMeasureId;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.BarButtonItem BBI_Scales;
        private DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider dxErrorProvider1;
    }
}
