
using DevExpress.XtraEditors.Controls;
using Foxoft.Models;
using Foxoft.Properties;

namespace Foxoft
{
    partial class FormAppSetting
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

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAppSetting));
            tabControl1 = new DevExpress.XtraTab.XtraTabControl();
            tabPageSettings = new DevExpress.XtraTab.XtraTabPage();
            tabPageShortcuts = new DevExpress.XtraTab.XtraTabPage();
            ucShortcutSetting1 = new Foxoft.UcShortcutSetting();
            dataLayoutControl1 = new DevExpress.XtraDataLayout.DataLayoutControl();
            btn_OptimizeDatabaseIndexes = new DevExpress.XtraEditors.SimpleButton();
            btn_Save = new DevExpress.XtraEditors.SimpleButton();
            GridViewLayoutTextEdit = new DevExpress.XtraEditors.TextEdit();
            appSettingBindingSource = new BindingSource(components);
            dcWhatsAppProviderSettingBindingSource = new BindingSource(components);
            AutoPrintCheckEdit = new DevExpress.XtraEditors.CheckEdit();
            PrintCountSpinEdit = new DevExpress.XtraEditors.SpinEdit();
            PrintDesignPathButtonEdit = new DevExpress.XtraEditors.ButtonEdit();
            LocalCurrencyCodeButtonEdit = new DevExpress.XtraEditors.ButtonEdit();
            WhatsappChromeProfileNameTextEdit = new DevExpress.XtraEditors.TextEdit();
            UsePriceListCheckEdit = new DevExpress.XtraEditors.CheckEdit();
            AutoSaveCheckEdit = new DevExpress.XtraEditors.CheckEdit();
            InvoiceEditGraceDaysSpinEdit = new DevExpress.XtraEditors.SpinEdit();
            PaymentEditGraceDaysSpinEdit = new DevExpress.XtraEditors.SpinEdit();
            AppFontSizeSpinEdit = new DevExpress.XtraEditors.SpinEdit();
            btn_ClearMemory = new DevExpress.XtraEditors.SimpleButton();
            POSShowQuantityDialogCheckEdit = new DevExpress.XtraEditors.CheckEdit();
            POSShowSalesmanCodeDialogCheckEdit = new DevExpress.XtraEditors.CheckEdit();
            POSFindProductByCheckedComboBoxEdit = new DevExpress.XtraEditors.CheckedComboBoxEdit();
            POSMergeSameProductsCheckEdit = new DevExpress.XtraEditors.CheckEdit();
            ProductsFormKeepActiveCheckEdit = new DevExpress.XtraEditors.CheckEdit();
            OverpaymentModeImageComboBoxEdit = new DevExpress.XtraEditors.ImageComboBoxEdit();
            UseBarcodeCheckEdit = new DevExpress.XtraEditors.CheckEdit();
            UseScalesCheckEdit = new DevExpress.XtraEditors.CheckEdit();
            UseCampaignCheckEdit = new DevExpress.XtraEditors.CheckEdit();
            WhatsAppProviderImageComboBoxEdit = new DevExpress.XtraEditors.ImageComboBoxEdit();
            ServerUrlTextEdit = new DevExpress.XtraEditors.TextEdit();
            InstanceNameTextEdit = new DevExpress.XtraEditors.TextEdit();
            ApiKeyTextEdit = new DevExpress.XtraEditors.TextEdit();
            NotifyBalanceWarningLevelCheckEdit = new DevExpress.XtraEditors.CheckEdit();
            LockReturnDocumentCheckEdit = new DevExpress.XtraEditors.CheckEdit();
            TransferAutoApproveCheckEdit = new DevExpress.XtraEditors.CheckEdit();
            Root = new DevExpress.XtraLayout.LayoutControlGroup();
            layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            layoutControlGroupGeneral = new DevExpress.XtraLayout.LayoutControlGroup();
            layoutControlGroupPos = new DevExpress.XtraLayout.LayoutControlGroup();
            layoutControlGroupSystem = new DevExpress.XtraLayout.LayoutControlGroup();
            ItemForGetPrint = new DevExpress.XtraLayout.LayoutControlItem();
            ItemForPrintCount = new DevExpress.XtraLayout.LayoutControlItem();
            ItemForPrintDesignPath = new DevExpress.XtraLayout.LayoutControlItem();
            ItemForLocalCurrencyCode = new DevExpress.XtraLayout.LayoutControlItem();
            ItemForUsePriceList = new DevExpress.XtraLayout.LayoutControlItem();
            ItemForAutoSave = new DevExpress.XtraLayout.LayoutControlItem();
            ItemForInvoiceEditGraceDays = new DevExpress.XtraLayout.LayoutControlItem();
            ItemForPaymentEditGraceDays = new DevExpress.XtraLayout.LayoutControlItem();
            ItemForAppFontSize = new DevExpress.XtraLayout.LayoutControlItem();
            emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            ItemForGridViewLayout = new DevExpress.XtraLayout.LayoutControlItem();
            LCI_ClearMemory = new DevExpress.XtraLayout.LayoutControlItem();
            ItemForPOSShowQuantityDialog = new DevExpress.XtraLayout.LayoutControlItem();
            ItemForPOSShowSalesmanCodeDialog = new DevExpress.XtraLayout.LayoutControlItem();
            ItemForPOSFindProductBy = new DevExpress.XtraLayout.LayoutControlItem();
            ItemForPOSMergeSameProducts = new DevExpress.XtraLayout.LayoutControlItem();
            ItemForProductsFormKeepActive = new DevExpress.XtraLayout.LayoutControlItem();
            ItemForOverpaymentMode = new DevExpress.XtraLayout.LayoutControlItem();
            ItemForUseBarcode = new DevExpress.XtraLayout.LayoutControlItem();
            ItemForUseScales = new DevExpress.XtraLayout.LayoutControlItem();
            ItemForUseCampaign = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlGroupWhatsApp = new DevExpress.XtraLayout.LayoutControlGroup();
            ItemForServerUrl = new DevExpress.XtraLayout.LayoutControlItem();
            ItemForInstanceName = new DevExpress.XtraLayout.LayoutControlItem();
            ItemForApiKey = new DevExpress.XtraLayout.LayoutControlItem();
            ItemForNotifyBalanceWarningLevel = new DevExpress.XtraLayout.LayoutControlItem();
            ItemForLockReturnDocument = new DevExpress.XtraLayout.LayoutControlItem();
            ItemForTransferAutoApprove = new DevExpress.XtraLayout.LayoutControlItem();
            ItemForWhatsappChromeProfileName = new DevExpress.XtraLayout.LayoutControlItem();
            ItemForWhatsAppProvider = new DevExpress.XtraLayout.LayoutControlItem();
            tabPageNotification = new DevExpress.XtraTab.XtraTabPage();
            ucNotificationSetting1 = new Foxoft.UcNotificationSetting();
            ((System.ComponentModel.ISupportInitialize)tabControl1).BeginInit();
            tabControl1.SuspendLayout();
            tabPageSettings.SuspendLayout();
            tabPageShortcuts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataLayoutControl1).BeginInit();
            dataLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)GridViewLayoutTextEdit.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)appSettingBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dcWhatsAppProviderSettingBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)AutoPrintCheckEdit.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PrintCountSpinEdit.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PrintDesignPathButtonEdit.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LocalCurrencyCodeButtonEdit.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)WhatsappChromeProfileNameTextEdit.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)UsePriceListCheckEdit.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)AutoSaveCheckEdit.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)InvoiceEditGraceDaysSpinEdit.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PaymentEditGraceDaysSpinEdit.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)AppFontSizeSpinEdit.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)POSShowQuantityDialogCheckEdit.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)POSShowSalesmanCodeDialogCheckEdit.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)POSFindProductByCheckedComboBoxEdit.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)POSMergeSameProductsCheckEdit.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ProductsFormKeepActiveCheckEdit.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)OverpaymentModeImageComboBoxEdit.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)UseBarcodeCheckEdit.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)UseScalesCheckEdit.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)UseCampaignCheckEdit.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)WhatsAppProviderImageComboBoxEdit.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ServerUrlTextEdit.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)InstanceNameTextEdit.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ApiKeyTextEdit.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)NotifyBalanceWarningLevelCheckEdit.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LockReturnDocumentCheckEdit.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)TransferAutoApproveCheckEdit.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Root).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlGroup1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlGroupGeneral).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlGroupPos).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlGroupSystem).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ItemForGetPrint).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ItemForPrintCount).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ItemForPrintDesignPath).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ItemForLocalCurrencyCode).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ItemForUsePriceList).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ItemForAutoSave).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ItemForInvoiceEditGraceDays).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ItemForPaymentEditGraceDays).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ItemForAppFontSize).BeginInit();
            ((System.ComponentModel.ISupportInitialize)emptySpaceItem1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ItemForGridViewLayout).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LCI_ClearMemory).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ItemForPOSShowQuantityDialog).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ItemForPOSShowSalesmanCodeDialog).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ItemForPOSFindProductBy).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ItemForPOSMergeSameProducts).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ItemForProductsFormKeepActive).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ItemForOverpaymentMode).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ItemForUseBarcode).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ItemForUseScales).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ItemForUseCampaign).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlGroupWhatsApp).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ItemForServerUrl).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ItemForInstanceName).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ItemForApiKey).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ItemForNotifyBalanceWarningLevel).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ItemForLockReturnDocument).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ItemForTransferAutoApprove).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ItemForWhatsappChromeProfileName).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ItemForWhatsAppProvider).BeginInit();
            tabPageNotification.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(0, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedTabPage = tabPageSettings;
            tabControl1.Size = new Size(800, 650);
            tabControl1.TabIndex = 1;
            tabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] { tabPageSettings, tabPageShortcuts, tabPageNotification });
            // 
            // tabPageSettings
            // 
            tabPageSettings.Controls.Add(dataLayoutControl1);
            tabPageSettings.Name = "tabPageSettings";
            tabPageSettings.Size = new Size(798, 625);
            tabPageSettings.Text = Resources.Form_AppSetting_Caption;
            // 
            // tabPageShortcuts
            // 
            tabPageShortcuts.Controls.Add(ucShortcutSetting1);
            tabPageShortcuts.Name = "tabPageShortcuts";
            tabPageShortcuts.Size = new Size(798, 625);
            tabPageShortcuts.Text = Resources.FormShortcut_Title;
            // 
            // ucShortcutSetting1
            // 
            ucShortcutSetting1.Dock = DockStyle.Fill;
            ucShortcutSetting1.Location = new Point(0, 0);
            ucShortcutSetting1.Name = "ucShortcutSetting1";
            ucShortcutSetting1.Size = new Size(798, 625);
            ucShortcutSetting1.TabIndex = 0;
            // 
            // dataLayoutControl1
            // 
            dataLayoutControl1.Controls.Add(btn_OptimizeDatabaseIndexes);
            dataLayoutControl1.Controls.Add(btn_Save);
            dataLayoutControl1.Controls.Add(GridViewLayoutTextEdit);
            dataLayoutControl1.Controls.Add(AutoPrintCheckEdit);
            dataLayoutControl1.Controls.Add(PrintCountSpinEdit);
            dataLayoutControl1.Controls.Add(PrintDesignPathButtonEdit);
            dataLayoutControl1.Controls.Add(LocalCurrencyCodeButtonEdit);
            dataLayoutControl1.Controls.Add(WhatsappChromeProfileNameTextEdit);
            dataLayoutControl1.Controls.Add(UsePriceListCheckEdit);
            dataLayoutControl1.Controls.Add(AutoSaveCheckEdit);
            dataLayoutControl1.Controls.Add(InvoiceEditGraceDaysSpinEdit);
            dataLayoutControl1.Controls.Add(PaymentEditGraceDaysSpinEdit);
            dataLayoutControl1.Controls.Add(AppFontSizeSpinEdit);
            dataLayoutControl1.Controls.Add(btn_ClearMemory);
            dataLayoutControl1.Controls.Add(POSShowQuantityDialogCheckEdit);
            dataLayoutControl1.Controls.Add(POSShowSalesmanCodeDialogCheckEdit);
            dataLayoutControl1.Controls.Add(POSFindProductByCheckedComboBoxEdit);
            dataLayoutControl1.Controls.Add(POSMergeSameProductsCheckEdit);
            dataLayoutControl1.Controls.Add(ProductsFormKeepActiveCheckEdit);
            dataLayoutControl1.Controls.Add(OverpaymentModeImageComboBoxEdit);
            dataLayoutControl1.Controls.Add(UseBarcodeCheckEdit);
            dataLayoutControl1.Controls.Add(UseScalesCheckEdit);
            dataLayoutControl1.Controls.Add(UseCampaignCheckEdit);
            dataLayoutControl1.Controls.Add(WhatsAppProviderImageComboBoxEdit);
            dataLayoutControl1.Controls.Add(ServerUrlTextEdit);
            dataLayoutControl1.Controls.Add(InstanceNameTextEdit);
            dataLayoutControl1.Controls.Add(ApiKeyTextEdit);
            dataLayoutControl1.Controls.Add(NotifyBalanceWarningLevelCheckEdit);
            dataLayoutControl1.Controls.Add(LockReturnDocumentCheckEdit);
            dataLayoutControl1.Controls.Add(TransferAutoApproveCheckEdit);
            dataLayoutControl1.DataSource = appSettingBindingSource;
            dataLayoutControl1.Dock = DockStyle.Fill;
            dataLayoutControl1.Location = new Point(0, 0);
            dataLayoutControl1.Name = "dataLayoutControl1";
            dataLayoutControl1.Root = Root;
            dataLayoutControl1.Size = new Size(798, 625);
            dataLayoutControl1.TabIndex = 0;
            dataLayoutControl1.Text = "dataLayoutControl1";
            // 
            // btn_OptimizeDatabaseIndexes
            // 
            btn_OptimizeDatabaseIndexes.Location = new Point(411, 402);
            btn_OptimizeDatabaseIndexes.Name = "btn_OptimizeDatabaseIndexes";
            btn_OptimizeDatabaseIndexes.Size = new Size(353, 22);
            btn_OptimizeDatabaseIndexes.StyleController = dataLayoutControl1;
            btn_OptimizeDatabaseIndexes.TabIndex = 23;
            btn_OptimizeDatabaseIndexes.Text = Resources.Entity_AppSetting_OptimizeDatabaseIndexes_Button;
            btn_OptimizeDatabaseIndexes.Click += Btn_OptimizeDatabaseIndexes_Click;
            // 
            // btn_Save
            // 
            btn_Save.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("btn_Save.ImageOptions.SvgImage");
            btn_Save.Location = new Point(591, 589);
            btn_Save.Name = "btn_Save";
            btn_Save.Size = new Size(175, 22);
            btn_Save.StyleController = dataLayoutControl1;
            btn_Save.TabIndex = 25;
            btn_Save.Text = Resources.Common_Save;
            btn_Save.Click += Btn_Save_Click;
            // 
            // GridViewLayoutTextEdit
            // 
            GridViewLayoutTextEdit.DataBindings.Add(new Binding("EditValue", appSettingBindingSource, "GridViewLayout", true));
            GridViewLayoutTextEdit.Location = new Point(575, 378);
            GridViewLayoutTextEdit.Name = "GridViewLayoutTextEdit";
            GridViewLayoutTextEdit.Size = new Size(189, 20);
            GridViewLayoutTextEdit.StyleController = dataLayoutControl1;
            GridViewLayoutTextEdit.TabIndex = 21;
            // 
            appSettingBindingSource.DataSource = typeof(AppSetting);
            // 
            // dcWhatsAppProviderSettingBindingSource
            // 
            dcWhatsAppProviderSettingBindingSource.DataSource = typeof(DcWhatsAppProviderSetting);
            // 
            // AutoPrintCheckEdit
            // 
            AutoPrintCheckEdit.DataBindings.Add(new Binding("EditValue", appSettingBindingSource, "AutoPrint", true));
            AutoPrintCheckEdit.Location = new Point(24, 43);
            AutoPrintCheckEdit.Name = "AutoPrintCheckEdit";
            AutoPrintCheckEdit.Properties.Caption = Resources.Entity_AppSetting_AutoPrint;
            AutoPrintCheckEdit.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Default;
            AutoPrintCheckEdit.Size = new Size(353, 20);
            AutoPrintCheckEdit.StyleController = dataLayoutControl1;
            AutoPrintCheckEdit.TabIndex = 5;
            // 
            // PrintCountSpinEdit
            // 
            PrintCountSpinEdit.DataBindings.Add(new Binding("EditValue", appSettingBindingSource, "PrintCount", true));
            PrintCountSpinEdit.EditValue = new decimal(new int[] { 0, 0, 0, 0 });
            PrintCountSpinEdit.Location = new Point(188, 67);
            PrintCountSpinEdit.Name = "PrintCountSpinEdit";
            PrintCountSpinEdit.Properties.Appearance.Options.UseTextOptions = true;
            PrintCountSpinEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            PrintCountSpinEdit.Properties.Buttons.AddRange(new EditorButton[] { new EditorButton(ButtonPredefines.Combo) });
            PrintCountSpinEdit.Properties.Mask.EditMask = "N0";
            PrintCountSpinEdit.Properties.Mask.UseMaskAsDisplayFormat = true;
            PrintCountSpinEdit.Size = new Size(189, 20);
            PrintCountSpinEdit.StyleController = dataLayoutControl1;
            PrintCountSpinEdit.TabIndex = 6;
            // 
            // PrintDesignPathButtonEdit
            // 
            PrintDesignPathButtonEdit.DataBindings.Add(new Binding("EditValue", appSettingBindingSource, "PrintDesignPath", true));
            PrintDesignPathButtonEdit.Location = new Point(188, 91);
            PrintDesignPathButtonEdit.Name = "PrintDesignPathButtonEdit";
            PrintDesignPathButtonEdit.Properties.Buttons.AddRange(new EditorButton[] { new EditorButton() });
            PrintDesignPathButtonEdit.Size = new Size(189, 20);
            PrintDesignPathButtonEdit.StyleController = dataLayoutControl1;
            PrintDesignPathButtonEdit.TabIndex = 7;
            // 
            // LocalCurrencyCodeButtonEdit
            // 
            LocalCurrencyCodeButtonEdit.DataBindings.Add(new Binding("EditValue", appSettingBindingSource, "LocalCurrencyCode", true));
            LocalCurrencyCodeButtonEdit.Location = new Point(188, 115);
            LocalCurrencyCodeButtonEdit.Name = "LocalCurrencyCodeButtonEdit";
            LocalCurrencyCodeButtonEdit.Properties.Buttons.AddRange(new EditorButton[] { new EditorButton() });
            LocalCurrencyCodeButtonEdit.Size = new Size(189, 20);
            LocalCurrencyCodeButtonEdit.StyleController = dataLayoutControl1;
            LocalCurrencyCodeButtonEdit.TabIndex = 8;
            // 
            // WhatsappChromeProfileNameTextEdit
            // 
            WhatsappChromeProfileNameTextEdit.DataBindings.Add(new Binding("EditValue", appSettingBindingSource, "WhatsappChromeProfileName", true));
            WhatsappChromeProfileNameTextEdit.Location = new Point(188, 330);
            WhatsappChromeProfileNameTextEdit.Name = "WhatsappChromeProfileNameTextEdit";
            WhatsappChromeProfileNameTextEdit.Size = new Size(189, 20);
            WhatsappChromeProfileNameTextEdit.StyleController = dataLayoutControl1;
            WhatsappChromeProfileNameTextEdit.TabIndex = 9;
            // 
            // UsePriceListCheckEdit
            // 
            UsePriceListCheckEdit.DataBindings.Add(new Binding("EditValue", appSettingBindingSource, "UsePriceList", true));
            UsePriceListCheckEdit.Location = new Point(24, 139);
            UsePriceListCheckEdit.Name = "UsePriceListCheckEdit";
            UsePriceListCheckEdit.Properties.Caption = Resources.Entity_AppSetting_UsePriceList;
            UsePriceListCheckEdit.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Default;
            UsePriceListCheckEdit.Size = new Size(353, 20);
            UsePriceListCheckEdit.StyleController = dataLayoutControl1;
            UsePriceListCheckEdit.TabIndex = 10;
            // 
            // AutoSaveCheckEdit
            // 
            AutoSaveCheckEdit.DataBindings.Add(new Binding("EditValue", appSettingBindingSource, "AutoSave", true));
            AutoSaveCheckEdit.Location = new Point(24, 163);
            AutoSaveCheckEdit.Name = "AutoSaveCheckEdit";
            AutoSaveCheckEdit.Properties.Caption = Resources.Entity_AppSetting_AutoSave;
            AutoSaveCheckEdit.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Default;
            AutoSaveCheckEdit.Size = new Size(353, 20);
            AutoSaveCheckEdit.StyleController = dataLayoutControl1;
            AutoSaveCheckEdit.TabIndex = 11;
            // 
            // InvoiceEditGraceDaysSpinEdit
            // 
            InvoiceEditGraceDaysSpinEdit.DataBindings.Add(new Binding("EditValue", appSettingBindingSource, "InvoiceEditGraceDays", true));
            InvoiceEditGraceDaysSpinEdit.EditValue = new decimal(new int[] { 0, 0, 0, 0 });
            InvoiceEditGraceDaysSpinEdit.Location = new Point(188, 187);
            InvoiceEditGraceDaysSpinEdit.Name = "InvoiceEditGraceDaysSpinEdit";
            InvoiceEditGraceDaysSpinEdit.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            InvoiceEditGraceDaysSpinEdit.Properties.Appearance.Options.UseTextOptions = true;
            InvoiceEditGraceDaysSpinEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            InvoiceEditGraceDaysSpinEdit.Properties.Buttons.AddRange(new EditorButton[] { new EditorButton(ButtonPredefines.Combo) });
            InvoiceEditGraceDaysSpinEdit.Properties.Mask.EditMask = "N0";
            InvoiceEditGraceDaysSpinEdit.Properties.Mask.UseMaskAsDisplayFormat = true;
            InvoiceEditGraceDaysSpinEdit.Size = new Size(189, 20);
            InvoiceEditGraceDaysSpinEdit.StyleController = dataLayoutControl1;
            InvoiceEditGraceDaysSpinEdit.TabIndex = 12;
            // 
            // PaymentEditGraceDaysSpinEdit
            // 
            PaymentEditGraceDaysSpinEdit.DataBindings.Add(new Binding("EditValue", appSettingBindingSource, "PaymentEditGraceDays", true));
            PaymentEditGraceDaysSpinEdit.EditValue = new decimal(new int[] { 0, 0, 0, 0 });
            PaymentEditGraceDaysSpinEdit.Location = new Point(188, 211);
            PaymentEditGraceDaysSpinEdit.Name = "PaymentEditGraceDaysSpinEdit";
            PaymentEditGraceDaysSpinEdit.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            PaymentEditGraceDaysSpinEdit.Properties.Appearance.Options.UseTextOptions = true;
            PaymentEditGraceDaysSpinEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            PaymentEditGraceDaysSpinEdit.Properties.Buttons.AddRange(new EditorButton[] { new EditorButton(ButtonPredefines.Combo) });
            PaymentEditGraceDaysSpinEdit.Properties.Mask.EditMask = "N0";
            PaymentEditGraceDaysSpinEdit.Properties.Mask.UseMaskAsDisplayFormat = true;
            PaymentEditGraceDaysSpinEdit.Size = new Size(189, 20);
            PaymentEditGraceDaysSpinEdit.StyleController = dataLayoutControl1;
            PaymentEditGraceDaysSpinEdit.TabIndex = 13;
            // 
            // AppFontSizeSpinEdit
            // 
            AppFontSizeSpinEdit.DataBindings.Add(new Binding("EditValue", appSettingBindingSource, "AppFontSize", true, DataSourceUpdateMode.OnPropertyChanged));
            AppFontSizeSpinEdit.Location = new Point(188, 235);
            AppFontSizeSpinEdit.Name = "AppFontSizeSpinEdit";
            AppFontSizeSpinEdit.Properties.Appearance.Options.UseTextOptions = true;
            AppFontSizeSpinEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            AppFontSizeSpinEdit.Properties.Buttons.AddRange(new EditorButton[] { new EditorButton(ButtonPredefines.Combo) });
            AppFontSizeSpinEdit.Properties.Increment = new decimal(new int[] { 5, 0, 0, 65536 });
            AppFontSizeSpinEdit.Properties.IsFloatValue = true;
            AppFontSizeSpinEdit.Properties.Mask.EditMask = "N1";
            AppFontSizeSpinEdit.Properties.Mask.UseMaskAsDisplayFormat = true;
            AppFontSizeSpinEdit.Properties.MaxValue = Foxoft.AppCode.AppFontSettings.MaxFontSize;
            AppFontSizeSpinEdit.Properties.MinValue = Foxoft.AppCode.AppFontSettings.MinFontSize;
            AppFontSizeSpinEdit.Size = new Size(189, 20);
            AppFontSizeSpinEdit.StyleController = dataLayoutControl1;
            AppFontSizeSpinEdit.TabIndex = 14;
            // 
            // btn_ClearMemory
            // 
            btn_ClearMemory.Location = new Point(411, 428);
            btn_ClearMemory.Name = "btn_ClearMemory";
            btn_ClearMemory.Size = new Size(353, 22);
            btn_ClearMemory.StyleController = dataLayoutControl1;
            btn_ClearMemory.TabIndex = 24;
            btn_ClearMemory.Text = Resources.Entity_AppSetting_ClearMemory;
            btn_ClearMemory.Click += Btn_ClearMemory_Click;
            // 
            // POSShowQuantityDialogCheckEdit
            // 
            POSShowQuantityDialogCheckEdit.DataBindings.Add(new Binding("EditValue", appSettingBindingSource, "POSShowQuantityDialog", true));
            POSShowQuantityDialogCheckEdit.Location = new Point(413, 43);
            POSShowQuantityDialogCheckEdit.Name = "POSShowQuantityDialogCheckEdit";
            POSShowQuantityDialogCheckEdit.Properties.Caption = Resources.Entity_AppSetting_POSShowQuantityDialog;
            POSShowQuantityDialogCheckEdit.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Default;
            POSShowQuantityDialogCheckEdit.Size = new Size(353, 20);
            POSShowQuantityDialogCheckEdit.StyleController = dataLayoutControl1;
            POSShowQuantityDialogCheckEdit.TabIndex = 14;
            // 
            // POSShowSalesmanCodeDialogCheckEdit
            // 
            POSShowSalesmanCodeDialogCheckEdit.DataBindings.Add(new Binding("EditValue", appSettingBindingSource, "POSShowSalesmanCodeDialog", true));
            POSShowSalesmanCodeDialogCheckEdit.Location = new Point(413, 67);
            POSShowSalesmanCodeDialogCheckEdit.Name = "POSShowSalesmanCodeDialogCheckEdit";
            POSShowSalesmanCodeDialogCheckEdit.Properties.Caption = Resources.Entity_AppSetting_POSShowSalesmanDialog;
            POSShowSalesmanCodeDialogCheckEdit.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Default;
            POSShowSalesmanCodeDialogCheckEdit.Size = new Size(353, 20);
            POSShowSalesmanCodeDialogCheckEdit.StyleController = dataLayoutControl1;
            POSShowSalesmanCodeDialogCheckEdit.TabIndex = 15;
            // 
            // POSFindProductByCheckedComboBoxEdit
            // 
            POSFindProductByCheckedComboBoxEdit.DataBindings.Add(new Binding("EditValue", appSettingBindingSource, "POSFindProductBy", true));
            POSFindProductByCheckedComboBoxEdit.Location = new Point(577, 211);
            POSFindProductByCheckedComboBoxEdit.Name = "POSFindProductByCheckedComboBoxEdit";
            POSFindProductByCheckedComboBoxEdit.Properties.Buttons.AddRange(new EditorButton[] { new EditorButton(ButtonPredefines.Combo) });
            POSFindProductByCheckedComboBoxEdit.Size = new Size(189, 20);
            POSFindProductByCheckedComboBoxEdit.StyleController = dataLayoutControl1;
            POSFindProductByCheckedComboBoxEdit.TabIndex = 20;
            // 
            // POSMergeSameProductsCheckEdit
            // 
            POSMergeSameProductsCheckEdit.DataBindings.Add(new Binding("EditValue", appSettingBindingSource, "POSMergeSameProducts", true));
            POSMergeSameProductsCheckEdit.Location = new Point(413, 91);
            POSMergeSameProductsCheckEdit.Name = "POSMergeSameProductsCheckEdit";
            POSMergeSameProductsCheckEdit.Properties.Caption = Resources.Entity_AppSetting_POSMergeSameProducts;
            POSMergeSameProductsCheckEdit.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Default;
            POSMergeSameProductsCheckEdit.Size = new Size(353, 20);
            POSMergeSameProductsCheckEdit.StyleController = dataLayoutControl1;
            POSMergeSameProductsCheckEdit.TabIndex = 16;
            // 
            // ProductsFormKeepActiveCheckEdit
            // 
            ProductsFormKeepActiveCheckEdit.DataBindings.Add(new Binding("EditValue", appSettingBindingSource, "ProductsFormKeepActive", true));
            ProductsFormKeepActiveCheckEdit.Location = new Point(413, 115);
            ProductsFormKeepActiveCheckEdit.Name = "ProductsFormKeepActiveCheckEdit";
            ProductsFormKeepActiveCheckEdit.Properties.Caption = Resources.Entity_AppSetting_ProductsFormKeepActive;
            ProductsFormKeepActiveCheckEdit.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Default;
            ProductsFormKeepActiveCheckEdit.Size = new Size(353, 20);
            ProductsFormKeepActiveCheckEdit.StyleController = dataLayoutControl1;
            ProductsFormKeepActiveCheckEdit.TabIndex = 17;
            // 
            // OverpaymentModeImageComboBoxEdit
            // 
            OverpaymentModeImageComboBoxEdit.Location = new Point(577, 235);
            OverpaymentModeImageComboBoxEdit.Name = "OverpaymentModeImageComboBoxEdit";
            OverpaymentModeImageComboBoxEdit.Properties.Appearance.Options.UseTextOptions = true;
            OverpaymentModeImageComboBoxEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            OverpaymentModeImageComboBoxEdit.Properties.Buttons.AddRange(new EditorButton[] { new EditorButton(ButtonPredefines.Combo) });
            OverpaymentModeImageComboBoxEdit.Properties.Items.AddRange(new ImageComboBoxItem[] { new ImageComboBoxItem(Resources.Entity_AppSetting_OverpaymentMode_AskEachTime, 0, -1), new ImageComboBoxItem(Resources.Entity_AppSetting_OverpaymentMode_AcceptExactAndReturnChange, 1, -1), new ImageComboBoxItem(Resources.Entity_AppSetting_OverpaymentMode_AcceptAllAsAdvance, 2, -1) });
            OverpaymentModeImageComboBoxEdit.Properties.UseCtrlScroll = true;
            OverpaymentModeImageComboBoxEdit.Size = new Size(189, 20);
            OverpaymentModeImageComboBoxEdit.StyleController = dataLayoutControl1;
            OverpaymentModeImageComboBoxEdit.TabIndex = 22;
            // 
            // UseBarcodeCheckEdit
            // 
            UseBarcodeCheckEdit.DataBindings.Add(new Binding("EditValue", appSettingBindingSource, "UseBarcode", true));
            UseBarcodeCheckEdit.Location = new Point(413, 139);
            UseBarcodeCheckEdit.Name = "UseBarcodeCheckEdit";
            UseBarcodeCheckEdit.Properties.Caption = Resources.Entity_AppSetting_UseBarcode;
            UseBarcodeCheckEdit.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Default;
            UseBarcodeCheckEdit.Size = new Size(353, 20);
            UseBarcodeCheckEdit.StyleController = dataLayoutControl1;
            UseBarcodeCheckEdit.TabIndex = 18;
            // 
            // UseScalesCheckEdit
            // 
            UseScalesCheckEdit.DataBindings.Add(new Binding("EditValue", appSettingBindingSource, "UseScales", true));
            UseScalesCheckEdit.Location = new Point(413, 163);
            UseScalesCheckEdit.Name = "UseScalesCheckEdit";
            UseScalesCheckEdit.Properties.Caption = Resources.Entity_AppSetting_UseScales;
            UseScalesCheckEdit.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Default;
            UseScalesCheckEdit.Size = new Size(353, 20);
            UseScalesCheckEdit.StyleController = dataLayoutControl1;
            UseScalesCheckEdit.TabIndex = 19;
            // 
            // UseCampaignCheckEdit
            // 
            UseCampaignCheckEdit.DataBindings.Add(new Binding("EditValue", appSettingBindingSource, "UseCampaign", true));
            UseCampaignCheckEdit.Location = new Point(413, 187);
            UseCampaignCheckEdit.Name = "UseCampaignCheckEdit";
            UseCampaignCheckEdit.Properties.Caption = Resources.Entity_AppSetting_UseCampaign;
            UseCampaignCheckEdit.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Default;
            UseCampaignCheckEdit.Size = new Size(353, 20);
            UseCampaignCheckEdit.StyleController = dataLayoutControl1;
            UseCampaignCheckEdit.TabIndex = 20;
            // 
            // WhatsAppProviderImageComboBoxEdit
            // 
            WhatsAppProviderImageComboBoxEdit.DataBindings.Add(new Binding("EditValue", appSettingBindingSource, "WhatsAppProvider", true));
            WhatsAppProviderImageComboBoxEdit.Location = new Point(188, 306);
            WhatsAppProviderImageComboBoxEdit.Name = "WhatsAppProviderImageComboBoxEdit";
            WhatsAppProviderImageComboBoxEdit.Properties.Buttons.AddRange(new EditorButton[] { new EditorButton(ButtonPredefines.Combo) });
            WhatsAppProviderImageComboBoxEdit.Properties.Items.AddRange(new ImageComboBoxItem[] { new ImageComboBoxItem("Chrome", WhatsAppProvider.Chrome, -1), new ImageComboBoxItem("API", WhatsAppProvider.API, -1) });
            WhatsAppProviderImageComboBoxEdit.Size = new Size(189, 20);
            WhatsAppProviderImageComboBoxEdit.StyleController = dataLayoutControl1;
            WhatsAppProviderImageComboBoxEdit.TabIndex = 0;
            // 
            // NotifyBalanceWarningLevelCheckEdit
            // 
            NotifyBalanceWarningLevelCheckEdit.DataBindings.Add(new Binding("EditValue", appSettingBindingSource, "NotifyBalanceWarningLevel", true));
            NotifyBalanceWarningLevelCheckEdit.Location = new Point(413, 306);
            NotifyBalanceWarningLevelCheckEdit.Name = "NotifyBalanceWarningLevelCheckEdit";
            NotifyBalanceWarningLevelCheckEdit.Properties.Caption = Resources.Entity_AppSetting_NotifyBalanceWarningLevel;
            NotifyBalanceWarningLevelCheckEdit.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Default;
            NotifyBalanceWarningLevelCheckEdit.Size = new Size(353, 20);
            NotifyBalanceWarningLevelCheckEdit.StyleController = dataLayoutControl1;
            NotifyBalanceWarningLevelCheckEdit.TabIndex = 26;
            // 
            // LockReturnDocumentCheckEdit
            // 
            LockReturnDocumentCheckEdit.DataBindings.Add(new Binding("EditValue", appSettingBindingSource, "LockReturnDocument", true));
            LockReturnDocumentCheckEdit.Location = new Point(413, 330);
            LockReturnDocumentCheckEdit.Name = "LockReturnDocumentCheckEdit";
            LockReturnDocumentCheckEdit.Properties.Caption = Resources.Entity_AppSetting_LockReturnDocument;
            LockReturnDocumentCheckEdit.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Default;
            LockReturnDocumentCheckEdit.Size = new Size(353, 20);
            LockReturnDocumentCheckEdit.StyleController = dataLayoutControl1;
            LockReturnDocumentCheckEdit.TabIndex = 27;
            // 
            // TransferAutoApproveCheckEdit
            // 
            TransferAutoApproveCheckEdit.DataBindings.Add(new Binding("EditValue", appSettingBindingSource, "TransferAutoApprove", true));
            TransferAutoApproveCheckEdit.Location = new Point(413, 354);
            TransferAutoApproveCheckEdit.Name = "TransferAutoApproveCheckEdit";
            TransferAutoApproveCheckEdit.Properties.Caption = Resources.Entity_AppSetting_TransferAutoApprove;
            TransferAutoApproveCheckEdit.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Default;
            TransferAutoApproveCheckEdit.Size = new Size(353, 20);
            TransferAutoApproveCheckEdit.StyleController = dataLayoutControl1;
            TransferAutoApproveCheckEdit.TabIndex = 28;
            // 
            // ServerUrlTextEdit
            // 
            ServerUrlTextEdit.DataBindings.Add(new Binding("EditValue", dcWhatsAppProviderSettingBindingSource, "ServerUrl", true));
            ServerUrlTextEdit.Location = new Point(188, 402);
            ServerUrlTextEdit.Name = "ServerUrlTextEdit";
            ServerUrlTextEdit.Size = new Size(189, 20);
            ServerUrlTextEdit.StyleController = dataLayoutControl1;
            ServerUrlTextEdit.TabIndex = 4;
            ServerUrlTextEdit.EditValueChanged += ServerUrlTextEdit_EditValueChanged;
            // 
            // InstanceNameTextEdit
            // 
            InstanceNameTextEdit.DataBindings.Add(new Binding("EditValue", dcWhatsAppProviderSettingBindingSource, "InstanceName", true));
            InstanceNameTextEdit.Location = new Point(188, 378);
            InstanceNameTextEdit.Name = "InstanceNameTextEdit";
            InstanceNameTextEdit.Size = new Size(189, 20);
            InstanceNameTextEdit.StyleController = dataLayoutControl1;
            InstanceNameTextEdit.TabIndex = 3;
            // 
            // ApiKeyTextEdit
            // 
            ApiKeyTextEdit.DataBindings.Add(new Binding("EditValue", dcWhatsAppProviderSettingBindingSource, "ApiKey", true));
            ApiKeyTextEdit.Location = new Point(188, 354);
            ApiKeyTextEdit.Name = "ApiKeyTextEdit";
            ApiKeyTextEdit.Size = new Size(189, 20);
            ApiKeyTextEdit.StyleController = dataLayoutControl1;
            ApiKeyTextEdit.TabIndex = 2;
            // 
            // Root
            // 
            Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            Root.GroupBordersVisible = false;
            Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] { layoutControlGroup1 });
            Root.Name = "Root";
            Root.Size = new Size(798, 625);
            Root.TextVisible = false;
            // 
            // layoutControlGroup1
            // 
            layoutControlGroup1.AllowDrawBackground = false;
            layoutControlGroup1.GroupBordersVisible = false;
            layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] { layoutControlGroupGeneral, layoutControlGroupPos, layoutControlGroupWhatsApp, layoutControlGroupSystem, emptySpaceItem1, layoutControlItem1 });
            layoutControlGroup1.Location = new Point(0, 0);
            layoutControlGroup1.Name = "autoGeneratedGroup0";
            layoutControlGroup1.Size = new Size(778, 605);
            // 
            // layoutControlGroupGeneral
            // 
            layoutControlGroupGeneral.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] { ItemForGetPrint, ItemForPrintCount, ItemForPrintDesignPath, ItemForLocalCurrencyCode, ItemForUsePriceList, ItemForAutoSave, ItemForInvoiceEditGraceDays, ItemForPaymentEditGraceDays, ItemForAppFontSize });
            layoutControlGroupGeneral.Location = new Point(0, 0);
            layoutControlGroupGeneral.Name = "layoutControlGroupGeneral";
            layoutControlGroupGeneral.Size = new Size(389, 261);
            layoutControlGroupGeneral.Text = Resources.Form_AppSetting_Group_General;
            // 
            // layoutControlGroupPos
            // 
            layoutControlGroupPos.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] { ItemForPOSShowQuantityDialog, ItemForPOSShowSalesmanCodeDialog, ItemForPOSMergeSameProducts, ItemForProductsFormKeepActive, ItemForUseBarcode, ItemForUseScales, ItemForUseCampaign, ItemForPOSFindProductBy, ItemForOverpaymentMode });
            layoutControlGroupPos.Location = new Point(389, 0);
            layoutControlGroupPos.Name = "layoutControlGroupPos";
            layoutControlGroupPos.Size = new Size(389, 261);
            layoutControlGroupPos.Text = Resources.Form_AppSetting_Group_POS;
            // 
            // layoutControlGroupSystem
            // 
            layoutControlGroupSystem.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] { ItemForNotifyBalanceWarningLevel, ItemForLockReturnDocument, ItemForTransferAutoApprove, ItemForGridViewLayout, layoutControlItem2, LCI_ClearMemory });
            layoutControlGroupSystem.Location = new Point(389, 261);
            layoutControlGroupSystem.Name = "layoutControlGroupSystem";
            layoutControlGroupSystem.Size = new Size(389, 197);
            layoutControlGroupSystem.Text = Resources.Form_AppSetting_Group_System;
            // 
            // ItemForGetPrint
            // 
            ItemForGetPrint.Control = AutoPrintCheckEdit;
            ItemForGetPrint.Location = new Point(0, 0);
            ItemForGetPrint.Name = "ItemForGetPrint";
            ItemForGetPrint.Size = new Size(365, 24);
            ItemForGetPrint.TextVisible = false;
            // 
            // ItemForPrintCount
            // 
            ItemForPrintCount.Control = PrintCountSpinEdit;
            ItemForPrintCount.Location = new Point(0, 24);
            ItemForPrintCount.Name = "ItemForPrintCount";
            ItemForPrintCount.Size = new Size(365, 24);
            ItemForPrintCount.Text = Resources.Entity_AppSetting_PrintCount;
            ItemForPrintCount.TextSize = new Size(152, 13);
            // 
            // ItemForPrintDesignPath
            // 
            ItemForPrintDesignPath.Control = PrintDesignPathButtonEdit;
            ItemForPrintDesignPath.Location = new Point(0, 48);
            ItemForPrintDesignPath.Name = "ItemForPrintDesignPath";
            ItemForPrintDesignPath.Size = new Size(365, 24);
            ItemForPrintDesignPath.Text = Resources.Entity_AppSetting_PrintDesignPath;
            ItemForPrintDesignPath.TextSize = new Size(152, 13);
            // 
            // ItemForLocalCurrencyCode
            // 
            ItemForLocalCurrencyCode.Control = LocalCurrencyCodeButtonEdit;
            ItemForLocalCurrencyCode.Location = new Point(0, 72);
            ItemForLocalCurrencyCode.Name = "ItemForLocalCurrencyCode";
            ItemForLocalCurrencyCode.Size = new Size(365, 24);
            ItemForLocalCurrencyCode.Text = Resources.Entity_AppSetting_LocalCurrencyCode;
            ItemForLocalCurrencyCode.TextSize = new Size(152, 13);
            // 
            // ItemForUsePriceList
            // 
            ItemForUsePriceList.Control = UsePriceListCheckEdit;
            ItemForUsePriceList.Location = new Point(0, 96);
            ItemForUsePriceList.Name = "ItemForUsePriceList";
            ItemForUsePriceList.Size = new Size(365, 24);
            ItemForUsePriceList.TextVisible = false;
            // 
            // ItemForAutoSave
            // 
            ItemForAutoSave.Control = AutoSaveCheckEdit;
            ItemForAutoSave.Location = new Point(0, 120);
            ItemForAutoSave.Name = "ItemForAutoSave";
            ItemForAutoSave.Size = new Size(365, 24);
            ItemForAutoSave.TextVisible = false;
            // 
            // ItemForInvoiceEditGraceDays
            // 
            ItemForInvoiceEditGraceDays.Control = InvoiceEditGraceDaysSpinEdit;
            ItemForInvoiceEditGraceDays.Location = new Point(0, 144);
            ItemForInvoiceEditGraceDays.Name = "ItemForInvoiceEditGraceDays";
            ItemForInvoiceEditGraceDays.Size = new Size(365, 24);
            ItemForInvoiceEditGraceDays.Text = Resources.Entity_AppSetting_InvoiceEditGraceDays;
            ItemForInvoiceEditGraceDays.TextSize = new Size(152, 13);
            // 
            // ItemForPaymentEditGraceDays
            // 
            ItemForPaymentEditGraceDays.Control = PaymentEditGraceDaysSpinEdit;
            ItemForPaymentEditGraceDays.Location = new Point(0, 168);
            ItemForPaymentEditGraceDays.Name = "ItemForPaymentEditGraceDays";
            ItemForPaymentEditGraceDays.Size = new Size(365, 24);
            ItemForPaymentEditGraceDays.Text = Resources.Entity_AppSetting_PaymentEditGraceDays;
            ItemForPaymentEditGraceDays.TextSize = new Size(152, 13);
            // 
            // ItemForAppFontSize
            // 
            ItemForAppFontSize.Control = AppFontSizeSpinEdit;
            ItemForAppFontSize.Location = new Point(0, 192);
            ItemForAppFontSize.Name = "ItemForAppFontSize";
            ItemForAppFontSize.Size = new Size(365, 24);
            ItemForAppFontSize.Text = Resources.Entity_AppSetting_AppFontSize;
            ItemForAppFontSize.TextSize = new Size(152, 13);
            // 
            // emptySpaceItem1
            // 
            emptySpaceItem1.Location = new Point(0, 458);
            emptySpaceItem1.Name = "emptySpaceItem1";
            emptySpaceItem1.Size = new Size(579, 147);
            // 
            // layoutControlItem1
            // 
            layoutControlItem1.Control = btn_Save;
            layoutControlItem1.Location = new Point(579, 579);
            layoutControlItem1.MinSize = new Size(70, 26);
            layoutControlItem1.Name = "layoutControlItem1";
            layoutControlItem1.Size = new Size(199, 26);
            layoutControlItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            layoutControlItem2.Control = btn_OptimizeDatabaseIndexes;
            layoutControlItem2.Location = new Point(0, 96);
            layoutControlItem2.Name = "layoutControlItem2";
            layoutControlItem2.Size = new Size(365, 26);
            layoutControlItem2.TextVisible = false;
            // 
            // ItemForGridViewLayout
            // 
            ItemForGridViewLayout.Control = GridViewLayoutTextEdit;
            ItemForGridViewLayout.Location = new Point(0, 72);
            ItemForGridViewLayout.Name = "ItemForGridViewLayout";
            ItemForGridViewLayout.Size = new Size(365, 24);
            ItemForGridViewLayout.Text = Resources.Entity_AppSetting_GridViewLayout;
            ItemForGridViewLayout.TextSize = new Size(152, 13);
            // 
            // LCI_ClearMemory
            // 
            LCI_ClearMemory.Control = btn_ClearMemory;
            LCI_ClearMemory.Location = new Point(0, 122);
            LCI_ClearMemory.Name = "LCI_ClearMemory";
            LCI_ClearMemory.Size = new Size(365, 26);
            LCI_ClearMemory.TextVisible = false;
            // 
            // ItemForPOSShowQuantityDialog
            // 
            ItemForPOSShowQuantityDialog.Control = POSShowQuantityDialogCheckEdit;
            ItemForPOSShowQuantityDialog.Location = new Point(0, 0);
            ItemForPOSShowQuantityDialog.Name = "ItemForPOSShowQuantityDialog";
            ItemForPOSShowQuantityDialog.Size = new Size(365, 24);
            ItemForPOSShowQuantityDialog.TextVisible = false;
            // 
            // ItemForPOSShowSalesmanCodeDialog
            // 
            ItemForPOSShowSalesmanCodeDialog.Control = POSShowSalesmanCodeDialogCheckEdit;
            ItemForPOSShowSalesmanCodeDialog.Location = new Point(0, 24);
            ItemForPOSShowSalesmanCodeDialog.Name = "ItemForPOSShowSalesmanCodeDialog";
            ItemForPOSShowSalesmanCodeDialog.Size = new Size(365, 24);
            ItemForPOSShowSalesmanCodeDialog.TextVisible = false;
            // 
            // ItemForPOSFindProductBy
            // 
            ItemForPOSFindProductBy.Control = POSFindProductByCheckedComboBoxEdit;
            ItemForPOSFindProductBy.Location = new Point(0, 168);
            ItemForPOSFindProductBy.Name = "ItemForPOSFindProductBy";
            ItemForPOSFindProductBy.Size = new Size(365, 24);
            ItemForPOSFindProductBy.Text = Resources.Entity_AppSetting_POSFindProductBy;
            ItemForPOSFindProductBy.TextSize = new Size(152, 13);
            // 
            // ItemForPOSMergeSameProducts
            // 
            ItemForPOSMergeSameProducts.Control = POSMergeSameProductsCheckEdit;
            ItemForPOSMergeSameProducts.Location = new Point(0, 48);
            ItemForPOSMergeSameProducts.Name = "ItemForPOSMergeSameProducts";
            ItemForPOSMergeSameProducts.Size = new Size(365, 24);
            ItemForPOSMergeSameProducts.TextVisible = false;
            // 
            // ItemForProductsFormKeepActive
            // 
            ItemForProductsFormKeepActive.Control = ProductsFormKeepActiveCheckEdit;
            ItemForProductsFormKeepActive.Location = new Point(0, 72);
            ItemForProductsFormKeepActive.Name = "ItemForProductsFormKeepActive";
            ItemForProductsFormKeepActive.Size = new Size(365, 24);
            ItemForProductsFormKeepActive.TextVisible = false;
            // 
            // ItemForOverpaymentMode
            // 
            ItemForOverpaymentMode.Control = OverpaymentModeImageComboBoxEdit;
            ItemForOverpaymentMode.Location = new Point(0, 192);
            ItemForOverpaymentMode.Name = "ItemForOverpaymentMode";
            ItemForOverpaymentMode.Size = new Size(365, 24);
            ItemForOverpaymentMode.Text = Resources.Entity_AppSetting_OverpaymentMode;
            ItemForOverpaymentMode.TextSize = new Size(152, 13);
            // 
            // ItemForUseBarcode
            // 
            ItemForUseBarcode.Control = UseBarcodeCheckEdit;
            ItemForUseBarcode.Location = new Point(0, 96);
            ItemForUseBarcode.Name = "ItemForUseBarcode";
            ItemForUseBarcode.Size = new Size(365, 24);
            ItemForUseBarcode.TextVisible = false;
            // 
            // ItemForUseScales
            // 
            ItemForUseScales.Control = UseScalesCheckEdit;
            ItemForUseScales.Location = new Point(0, 120);
            ItemForUseScales.Name = "ItemForUseScales";
            ItemForUseScales.Size = new Size(365, 24);
            ItemForUseScales.TextVisible = false;
            // 
            // ItemForUseCampaign
            // 
            ItemForUseCampaign.Control = UseCampaignCheckEdit;
            ItemForUseCampaign.Location = new Point(0, 144);
            ItemForUseCampaign.Name = "ItemForUseCampaign";
            ItemForUseCampaign.Size = new Size(365, 24);
            ItemForUseCampaign.TextVisible = false;
            // 
            // ItemForNotifyBalanceWarningLevel
            // 
            ItemForNotifyBalanceWarningLevel.Control = NotifyBalanceWarningLevelCheckEdit;
            ItemForNotifyBalanceWarningLevel.Location = new Point(0, 0);
            ItemForNotifyBalanceWarningLevel.Name = "ItemForNotifyBalanceWarningLevel";
            ItemForNotifyBalanceWarningLevel.Size = new Size(365, 24);
            ItemForNotifyBalanceWarningLevel.TextVisible = false;
            // 
            // ItemForLockReturnDocument
            // 
            ItemForLockReturnDocument.Control = LockReturnDocumentCheckEdit;
            ItemForLockReturnDocument.Location = new Point(0, 24);
            ItemForLockReturnDocument.Name = "ItemForLockReturnDocument";
            ItemForLockReturnDocument.Size = new Size(365, 24);
            ItemForLockReturnDocument.TextVisible = false;
            // 
            // ItemForTransferAutoApprove
            // 
            ItemForTransferAutoApprove.Control = TransferAutoApproveCheckEdit;
            ItemForTransferAutoApprove.Location = new Point(0, 48);
            ItemForTransferAutoApprove.Name = "ItemForTransferAutoApprove";
            ItemForTransferAutoApprove.Size = new Size(365, 24);
            ItemForTransferAutoApprove.TextVisible = false;
            // 
            // layoutControlGroupWhatsApp
            // 
            layoutControlGroupWhatsApp.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] { ItemForWhatsAppProvider, ItemForWhatsappChromeProfileName, ItemForApiKey, ItemForInstanceName, ItemForServerUrl });
            layoutControlGroupWhatsApp.Location = new Point(0, 261);
            layoutControlGroupWhatsApp.Name = "layoutControlGroupWhatsApp";
            layoutControlGroupWhatsApp.Size = new Size(389, 165);
            layoutControlGroupWhatsApp.Text = Resources.Form_AppSetting_Group_WhatsApp;
            // 
            // ItemForServerUrl
            // 
            ItemForServerUrl.Control = ServerUrlTextEdit;
            ItemForServerUrl.Location = new Point(0, 96);
            ItemForServerUrl.Name = "ItemForServerUrl";
            ItemForServerUrl.Size = new Size(365, 24);
            ItemForServerUrl.Text = Resources.Entity_DcWhatsAppProviderSetting_ServerUrl;
            ItemForServerUrl.TextSize = new Size(152, 13);
            // 
            // ItemForInstanceName
            // 
            ItemForInstanceName.Control = InstanceNameTextEdit;
            ItemForInstanceName.Location = new Point(0, 72);
            ItemForInstanceName.Name = "ItemForInstanceName";
            ItemForInstanceName.Size = new Size(365, 24);
            ItemForInstanceName.Text = Resources.Entity_DcWhatsAppProviderSetting_InstanceName;
            ItemForInstanceName.TextSize = new Size(152, 13);
            // 
            // ItemForApiKey
            // 
            ItemForApiKey.Control = ApiKeyTextEdit;
            ItemForApiKey.Location = new Point(0, 48);
            ItemForApiKey.Name = "ItemForApiKey";
            ItemForApiKey.Size = new Size(365, 24);
            ItemForApiKey.Text = Resources.Entity_DcWhatsAppProviderSetting_ApiKey;
            ItemForApiKey.TextSize = new Size(152, 13);
            // 
            // ItemForWhatsappChromeProfileName
            // 
            ItemForWhatsappChromeProfileName.Control = WhatsappChromeProfileNameTextEdit;
            ItemForWhatsappChromeProfileName.Location = new Point(0, 24);
            ItemForWhatsappChromeProfileName.Name = "ItemForWhatsappChromeProfileName";
            ItemForWhatsappChromeProfileName.Size = new Size(365, 24);
            ItemForWhatsappChromeProfileName.Text = Resources.Entity_AppSetting_WhatsappChromeProfileName;
            ItemForWhatsappChromeProfileName.TextSize = new Size(152, 13);
            // 
            // ItemForWhatsAppProvider
            // 
            ItemForWhatsAppProvider.Control = WhatsAppProviderImageComboBoxEdit;
            ItemForWhatsAppProvider.Location = new Point(0, 0);
            ItemForWhatsAppProvider.Name = "ItemForWhatsAppProvider";
            ItemForWhatsAppProvider.Size = new Size(365, 24);
            ItemForWhatsAppProvider.Text = Resources.Entity_AppSetting_WhatsAppProvider;
            ItemForWhatsAppProvider.TextSize = new Size(152, 13);
            // 
            // tabPageNotification
            // 
            tabPageNotification.Controls.Add(ucNotificationSetting1);
            tabPageNotification.Name = "tabPageNotification";
            tabPageNotification.Size = new Size(798, 625);
            tabPageNotification.Text = Resources.Form_NotificationSettings;
            // 
            // ucNotificationSetting1
            // 
            ucNotificationSetting1.Dock = DockStyle.Fill;
            ucNotificationSetting1.Location = new Point(0, 0);
            ucNotificationSetting1.Name = "ucNotificationSetting1";
            ucNotificationSetting1.Size = new Size(798, 625);
            ucNotificationSetting1.TabIndex = 0;
            // 
            // FormAppSetting
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 650);
            Controls.Add(tabControl1);
            Name = "FormAppSetting";
            Text = Resources.Form_AppSetting_Caption;
            Load += FormAppSetting_Load;
            ((System.ComponentModel.ISupportInitialize)tabControl1).EndInit();
            tabControl1.ResumeLayout(false);
            tabPageSettings.ResumeLayout(false);
            tabPageShortcuts.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataLayoutControl1).EndInit();
            dataLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)GridViewLayoutTextEdit.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)appSettingBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)dcWhatsAppProviderSettingBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)AutoPrintCheckEdit.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)PrintCountSpinEdit.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)PrintDesignPathButtonEdit.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)LocalCurrencyCodeButtonEdit.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)WhatsappChromeProfileNameTextEdit.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)UsePriceListCheckEdit.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)AutoSaveCheckEdit.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)InvoiceEditGraceDaysSpinEdit.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)PaymentEditGraceDaysSpinEdit.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)AppFontSizeSpinEdit.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)POSShowQuantityDialogCheckEdit.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)POSShowSalesmanCodeDialogCheckEdit.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)POSFindProductByCheckedComboBoxEdit.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)POSMergeSameProductsCheckEdit.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)ProductsFormKeepActiveCheckEdit.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)OverpaymentModeImageComboBoxEdit.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)UseBarcodeCheckEdit.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)UseScalesCheckEdit.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)UseCampaignCheckEdit.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)WhatsAppProviderImageComboBoxEdit.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)ServerUrlTextEdit.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)InstanceNameTextEdit.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)ApiKeyTextEdit.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)NotifyBalanceWarningLevelCheckEdit.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)LockReturnDocumentCheckEdit.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)TransferAutoApproveCheckEdit.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)Root).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlGroup1).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlGroupGeneral).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlGroupPos).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlGroupSystem).EndInit();
            ((System.ComponentModel.ISupportInitialize)ItemForGetPrint).EndInit();
            ((System.ComponentModel.ISupportInitialize)ItemForPrintCount).EndInit();
            ((System.ComponentModel.ISupportInitialize)ItemForPrintDesignPath).EndInit();
            ((System.ComponentModel.ISupportInitialize)ItemForLocalCurrencyCode).EndInit();
            ((System.ComponentModel.ISupportInitialize)ItemForUsePriceList).EndInit();
            ((System.ComponentModel.ISupportInitialize)ItemForAutoSave).EndInit();
            ((System.ComponentModel.ISupportInitialize)ItemForInvoiceEditGraceDays).EndInit();
            ((System.ComponentModel.ISupportInitialize)ItemForPaymentEditGraceDays).EndInit();
            ((System.ComponentModel.ISupportInitialize)ItemForAppFontSize).EndInit();
            ((System.ComponentModel.ISupportInitialize)emptySpaceItem1).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem1).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem2).EndInit();
            ((System.ComponentModel.ISupportInitialize)ItemForGridViewLayout).EndInit();
            ((System.ComponentModel.ISupportInitialize)LCI_ClearMemory).EndInit();
            ((System.ComponentModel.ISupportInitialize)ItemForPOSShowQuantityDialog).EndInit();
            ((System.ComponentModel.ISupportInitialize)ItemForPOSShowSalesmanCodeDialog).EndInit();
            ((System.ComponentModel.ISupportInitialize)ItemForPOSFindProductBy).EndInit();
            ((System.ComponentModel.ISupportInitialize)ItemForPOSMergeSameProducts).EndInit();
            ((System.ComponentModel.ISupportInitialize)ItemForProductsFormKeepActive).EndInit();
            ((System.ComponentModel.ISupportInitialize)ItemForOverpaymentMode).EndInit();
            ((System.ComponentModel.ISupportInitialize)ItemForUseBarcode).EndInit();
            ((System.ComponentModel.ISupportInitialize)ItemForUseScales).EndInit();
            ((System.ComponentModel.ISupportInitialize)ItemForUseCampaign).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlGroupWhatsApp).EndInit();
            ((System.ComponentModel.ISupportInitialize)ItemForServerUrl).EndInit();
            ((System.ComponentModel.ISupportInitialize)ItemForInstanceName).EndInit();
            ((System.ComponentModel.ISupportInitialize)ItemForApiKey).EndInit();
            ((System.ComponentModel.ISupportInitialize)ItemForNotifyBalanceWarningLevel).EndInit();
            ((System.ComponentModel.ISupportInitialize)ItemForLockReturnDocument).EndInit();
            ((System.ComponentModel.ISupportInitialize)ItemForTransferAutoApprove).EndInit();
            ((System.ComponentModel.ISupportInitialize)ItemForWhatsappChromeProfileName).EndInit();
            ((System.ComponentModel.ISupportInitialize)ItemForWhatsAppProvider).EndInit();
            tabPageNotification.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraDataLayout.DataLayoutControl dataLayoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroupGeneral;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroupPos;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroupSystem;
        private DevExpress.XtraEditors.SimpleButton btn_Save;
        private DevExpress.XtraEditors.SimpleButton btn_OptimizeDatabaseIndexes;
        private DevExpress.XtraEditors.TextEdit GridViewLayoutTextEdit;
        private BindingSource appSettingBindingSource;
        private BindingSource dcWhatsAppProviderSettingBindingSource;
        private DevExpress.XtraEditors.CheckEdit AutoPrintCheckEdit;
        private DevExpress.XtraEditors.SpinEdit PrintCountSpinEdit;
        private DevExpress.XtraEditors.ButtonEdit PrintDesignPathButtonEdit;
        private DevExpress.XtraEditors.ButtonEdit LocalCurrencyCodeButtonEdit;
        private DevExpress.XtraEditors.TextEdit WhatsappChromeProfileNameTextEdit;
        private DevExpress.XtraEditors.CheckEdit UsePriceListCheckEdit;
        private DevExpress.XtraEditors.CheckEdit AutoSaveCheckEdit;
        private DevExpress.XtraEditors.SpinEdit InvoiceEditGraceDaysSpinEdit;
        private DevExpress.XtraEditors.SpinEdit PaymentEditGraceDaysSpinEdit;
        private DevExpress.XtraEditors.SpinEdit AppFontSizeSpinEdit;
        private DevExpress.XtraLayout.LayoutControlItem ItemForGetPrint;
        private DevExpress.XtraLayout.LayoutControlItem ItemForPrintCount;
        private DevExpress.XtraLayout.LayoutControlItem ItemForPrintDesignPath;
        private DevExpress.XtraLayout.LayoutControlItem ItemForLocalCurrencyCode;
        private DevExpress.XtraLayout.LayoutControlItem ItemForWhatsappChromeProfileName;
        private DevExpress.XtraLayout.LayoutControlItem ItemForUsePriceList;
        private DevExpress.XtraLayout.LayoutControlItem ItemForAutoSave;
        private DevExpress.XtraLayout.LayoutControlItem ItemForInvoiceEditGraceDays;
        private DevExpress.XtraLayout.LayoutControlItem ItemForPaymentEditGraceDays;
        private DevExpress.XtraLayout.LayoutControlItem ItemForAppFontSize;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem ItemForGridViewLayout;
        private DevExpress.XtraEditors.SimpleButton btn_ClearMemory;
        private DevExpress.XtraLayout.LayoutControlItem LCI_ClearMemory;
        private DevExpress.XtraEditors.CheckEdit UseScalesCheckEdit;
        private DevExpress.XtraEditors.CheckEdit POSShowQuantityDialogCheckEdit;
        private DevExpress.XtraEditors.CheckEdit POSShowSalesmanCodeDialogCheckEdit;
        private DevExpress.XtraLayout.LayoutControlItem ItemForPOSShowQuantityDialog;
        private DevExpress.XtraLayout.LayoutControlItem ItemForPOSShowSalesmanCodeDialog;
        private DevExpress.XtraLayout.LayoutControlItem ItemForPOSFindProductBy;
        private DevExpress.XtraEditors.CheckedComboBoxEdit POSFindProductByCheckedComboBoxEdit;
        private DevExpress.XtraEditors.CheckEdit POSMergeSameProductsCheckEdit;
        private DevExpress.XtraLayout.LayoutControlItem ItemForPOSMergeSameProducts;
        private DevExpress.XtraEditors.CheckEdit ProductsFormKeepActiveCheckEdit;
        private DevExpress.XtraLayout.LayoutControlItem ItemForProductsFormKeepActive;
        private DevExpress.XtraLayout.LayoutControlItem ItemForOverpaymentMode;
        private DevExpress.XtraEditors.ImageComboBoxEdit OverpaymentModeImageComboBoxEdit;
        private DevExpress.XtraEditors.CheckEdit UseBarcodeCheckEdit;
        private DevExpress.XtraLayout.LayoutControlItem ItemForUseBarcode;
        private DevExpress.XtraLayout.LayoutControlItem ItemForUseScales;
        private DevExpress.XtraEditors.CheckEdit UseCampaignCheckEdit;
        private DevExpress.XtraLayout.LayoutControlItem ItemForUseCampaign;
        private DevExpress.XtraEditors.ImageComboBoxEdit WhatsAppProviderImageComboBoxEdit;
        private DevExpress.XtraEditors.TextEdit ServerUrlTextEdit;
        private DevExpress.XtraEditors.TextEdit InstanceNameTextEdit;
        private DevExpress.XtraEditors.TextEdit ApiKeyTextEdit;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroupWhatsApp;
        private DevExpress.XtraLayout.LayoutControlItem ItemForWhatsAppProvider;
        private DevExpress.XtraLayout.LayoutControlItem ItemForServerUrl;
        private DevExpress.XtraLayout.LayoutControlItem ItemForInstanceName;
        private DevExpress.XtraLayout.LayoutControlItem ItemForApiKey;
        private DevExpress.XtraEditors.CheckEdit NotifyBalanceWarningLevelCheckEdit;
        private DevExpress.XtraLayout.LayoutControlItem ItemForNotifyBalanceWarningLevel;
        private DevExpress.XtraEditors.CheckEdit LockReturnDocumentCheckEdit;
        private DevExpress.XtraLayout.LayoutControlItem ItemForLockReturnDocument;
        private DevExpress.XtraEditors.CheckEdit TransferAutoApproveCheckEdit;
        private DevExpress.XtraLayout.LayoutControlItem ItemForTransferAutoApprove;
        private DevExpress.XtraTab.XtraTabControl tabControl1;
        private DevExpress.XtraTab.XtraTabPage tabPageSettings;
        private DevExpress.XtraTab.XtraTabPage tabPageShortcuts;
        private Foxoft.UcShortcutSetting ucShortcutSetting1;
        // Notification tab
        private DevExpress.XtraTab.XtraTabPage tabPageNotification;
        private Foxoft.UcNotificationSetting ucNotificationSetting1;
    }
}
