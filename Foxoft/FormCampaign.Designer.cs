using DevExpress.XtraEditors.Repository;
using Foxoft.Models;
using Foxoft.Models.Entity;

namespace Foxoft
{
    partial class FormCampaign
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            lblCampaignPassword = new DevExpress.XtraEditors.LabelControl();
            CampaignPasswordTextEdit = new DevExpress.XtraEditors.TextEdit();
            panelHeader = new DevExpress.XtraEditors.PanelControl();
            lblProcessCode = new DevExpress.XtraEditors.LabelControl();
            LUE_processCode = new DevExpress.XtraEditors.LookUpEdit();
            lblCampaignCode = new DevExpress.XtraEditors.LabelControl();
            lblCampaignDesc = new DevExpress.XtraEditors.LabelControl();
            lblPromoCode = new DevExpress.XtraEditors.LabelControl();
            lblDiscountType = new DevExpress.XtraEditors.LabelControl();
            lblDiscountValue = new DevExpress.XtraEditors.LabelControl();
            lblPriority = new DevExpress.XtraEditors.LabelControl();
            lblStartDate = new DevExpress.XtraEditors.LabelControl();
            lblEndDate = new DevExpress.XtraEditors.LabelControl();
            lblMinInvoiceAmount = new DevExpress.XtraEditors.LabelControl();
            lblMaxDiscountAmount = new DevExpress.XtraEditors.LabelControl();
            lblNote = new DevExpress.XtraEditors.LabelControl();
            CampaignCodeTextEdit = new DevExpress.XtraEditors.TextEdit();
            CampaignDescTextEdit = new DevExpress.XtraEditors.TextEdit();
            PromoCodeTextEdit = new DevExpress.XtraEditors.TextEdit();
            DiscountTypeCodeComboBoxEdit = new DevExpress.XtraEditors.ComboBoxEdit();
            DiscountValueCalcEdit = new DevExpress.XtraEditors.CalcEdit();
            PrioritySpinEdit = new DevExpress.XtraEditors.SpinEdit();
            IsActiveCheckEdit = new DevExpress.XtraEditors.CheckEdit();
            IsCombinableCheckEdit = new DevExpress.XtraEditors.CheckEdit();
            StartDateDateEdit = new DevExpress.XtraEditors.DateEdit();
            EndDateDateEdit = new DevExpress.XtraEditors.DateEdit();
            MinInvoiceAmountCalcEdit = new DevExpress.XtraEditors.CalcEdit();
            MaxDiscountAmountCalcEdit = new DevExpress.XtraEditors.CalcEdit();
            NoteMemoEdit = new DevExpress.XtraEditors.MemoEdit();
            xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            tabProduct = new DevExpress.XtraTab.XtraTabPage();
            gC_Product = new DevExpress.XtraGrid.GridControl();
            trCampaignProductsBindingSource = new BindingSource(components);
            gV_Product = new DevExpress.XtraGrid.Views.Grid.GridView();
            colCampaignProductId = new DevExpress.XtraGrid.Columns.GridColumn();
            colProductCode = new DevExpress.XtraGrid.Columns.GridColumn();
            colProductDesc = new DevExpress.XtraGrid.Columns.GridColumn();
            panelProduct = new DevExpress.XtraEditors.PanelControl();
            btnDeleteProduct = new DevExpress.XtraEditors.SimpleButton();
            btnAddProduct = new DevExpress.XtraEditors.SimpleButton();
            tabCategory = new DevExpress.XtraTab.XtraTabPage();
            gC_Category = new DevExpress.XtraGrid.GridControl();
            trCampaignCategoriesBindingSource = new BindingSource(components);
            gV_Category = new DevExpress.XtraGrid.Views.Grid.GridView();
            colCampaignCategoryId = new DevExpress.XtraGrid.Columns.GridColumn();
            colHierarchyCode = new DevExpress.XtraGrid.Columns.GridColumn();
            panelCategory = new DevExpress.XtraEditors.PanelControl();
            btnDeleteCategory = new DevExpress.XtraEditors.SimpleButton();
            btnAddCategory = new DevExpress.XtraEditors.SimpleButton();
            tabCustomer = new DevExpress.XtraTab.XtraTabPage();
            gC_Customer = new DevExpress.XtraGrid.GridControl();
            trCampaignCustomersBindingSource = new BindingSource(components);
            gV_Customer = new DevExpress.XtraGrid.Views.Grid.GridView();
            colCampaignCustomerId = new DevExpress.XtraGrid.Columns.GridColumn();
            colCurrAccCode = new DevExpress.XtraGrid.Columns.GridColumn();
            colCurrAccDesc = new DevExpress.XtraGrid.Columns.GridColumn();
            panelCustomer = new DevExpress.XtraEditors.PanelControl();
            btnDeleteCustomer = new DevExpress.XtraEditors.SimpleButton();
            btnAddCustomer = new DevExpress.XtraEditors.SimpleButton();
            tabStore = new DevExpress.XtraTab.XtraTabPage();
            gC_Store = new DevExpress.XtraGrid.GridControl();
            trCampaignStoresBindingSource = new BindingSource(components);
            gV_Store = new DevExpress.XtraGrid.Views.Grid.GridView();
            colCampaignStoreId = new DevExpress.XtraGrid.Columns.GridColumn();
            colStoreCode = new DevExpress.XtraGrid.Columns.GridColumn();
            panelStore = new DevExpress.XtraEditors.PanelControl();
            btnDeleteStore = new DevExpress.XtraEditors.SimpleButton();
            btnAddStore = new DevExpress.XtraEditors.SimpleButton();
            tabWarehouse = new DevExpress.XtraTab.XtraTabPage();
            gC_Warehouse = new DevExpress.XtraGrid.GridControl();
            trCampaignWarehousesBindingSource = new BindingSource(components);
            gV_Warehouse = new DevExpress.XtraGrid.Views.Grid.GridView();
            colCampaignWarehouseId = new DevExpress.XtraGrid.Columns.GridColumn();
            colWarehouseCode = new DevExpress.XtraGrid.Columns.GridColumn();
            panelWarehouse = new DevExpress.XtraEditors.PanelControl();
            btnDeleteWarehouse = new DevExpress.XtraEditors.SimpleButton();
            btnAddWarehouse = new DevExpress.XtraEditors.SimpleButton();
            tabPaymentMethod = new DevExpress.XtraTab.XtraTabPage();
            gC_PaymentMethod = new DevExpress.XtraGrid.GridControl();
            trCampaignPaymentMethodsBindingSource = new BindingSource(components);
            gV_PaymentMethod = new DevExpress.XtraGrid.Views.Grid.GridView();
            colCampaignPaymentMethodId = new DevExpress.XtraGrid.Columns.GridColumn();
            colPaymentMethodId = new DevExpress.XtraGrid.Columns.GridColumn();
            colPaymentMethodDesc = new DevExpress.XtraGrid.Columns.GridColumn();
            panelPaymentMethod = new DevExpress.XtraEditors.PanelControl();
            btnDeletePaymentMethod = new DevExpress.XtraEditors.SimpleButton();
            btnAddPaymentMethod = new DevExpress.XtraEditors.SimpleButton();
            panelButtons = new DevExpress.XtraEditors.PanelControl();
            btn_Cancel = new DevExpress.XtraEditors.SimpleButton();
            btn_Ok = new DevExpress.XtraEditors.SimpleButton();
            dcCampaignsBindingSource = new BindingSource(components);
            IsCashOnlyCheckEdit = new DevExpress.XtraEditors.CheckEdit();
            ((System.ComponentModel.ISupportInitialize)CampaignPasswordTextEdit.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)panelHeader).BeginInit();
            panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)LUE_processCode.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)CampaignCodeTextEdit.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)CampaignDescTextEdit.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PromoCodeTextEdit.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)DiscountTypeCodeComboBoxEdit.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)DiscountValueCalcEdit.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PrioritySpinEdit.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)IsActiveCheckEdit.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)IsCombinableCheckEdit.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)StartDateDateEdit.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)StartDateDateEdit.Properties.CalendarTimeProperties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)EndDateDateEdit.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)EndDateDateEdit.Properties.CalendarTimeProperties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)MinInvoiceAmountCalcEdit.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)MaxDiscountAmountCalcEdit.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)NoteMemoEdit.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)xtraTabControl1).BeginInit();
            xtraTabControl1.SuspendLayout();
            tabProduct.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gC_Product).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trCampaignProductsBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gV_Product).BeginInit();
            ((System.ComponentModel.ISupportInitialize)panelProduct).BeginInit();
            panelProduct.SuspendLayout();
            tabCategory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gC_Category).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trCampaignCategoriesBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gV_Category).BeginInit();
            ((System.ComponentModel.ISupportInitialize)panelCategory).BeginInit();
            panelCategory.SuspendLayout();
            tabCustomer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gC_Customer).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trCampaignCustomersBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gV_Customer).BeginInit();
            ((System.ComponentModel.ISupportInitialize)panelCustomer).BeginInit();
            panelCustomer.SuspendLayout();
            tabStore.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gC_Store).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trCampaignStoresBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gV_Store).BeginInit();
            ((System.ComponentModel.ISupportInitialize)panelStore).BeginInit();
            panelStore.SuspendLayout();
            tabWarehouse.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gC_Warehouse).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trCampaignWarehousesBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gV_Warehouse).BeginInit();
            ((System.ComponentModel.ISupportInitialize)panelWarehouse).BeginInit();
            panelWarehouse.SuspendLayout();
            tabPaymentMethod.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gC_PaymentMethod).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trCampaignPaymentMethodsBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gV_PaymentMethod).BeginInit();
            ((System.ComponentModel.ISupportInitialize)panelPaymentMethod).BeginInit();
            panelPaymentMethod.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)panelButtons).BeginInit();
            panelButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dcCampaignsBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)IsCashOnlyCheckEdit.Properties).BeginInit();
            SuspendLayout();
            // 
            // lblCampaignPassword
            // 
            lblCampaignPassword.Location = new Point(788, 15);
            lblCampaignPassword.Name = "lblCampaignPassword";
            lblCampaignPassword.Size = new Size(22, 13);
            lblCampaignPassword.TabIndex = 27;
            lblCampaignPassword.Text = "Şifrə";
            // 
            // CampaignPasswordTextEdit
            // 
            CampaignPasswordTextEdit.Location = new Point(901, 12);
            CampaignPasswordTextEdit.Name = "CampaignPasswordTextEdit";
            CampaignPasswordTextEdit.Properties.UseSystemPasswordChar = true;
            CampaignPasswordTextEdit.Size = new Size(239, 20);
            CampaignPasswordTextEdit.TabIndex = 28;
            // 
            // panelHeader
            // 
            panelHeader.Controls.Add(lblProcessCode);
            panelHeader.Controls.Add(LUE_processCode);
            panelHeader.Controls.Add(lblCampaignCode);
            panelHeader.Controls.Add(lblCampaignDesc);
            panelHeader.Controls.Add(lblPromoCode);
            panelHeader.Controls.Add(lblDiscountType);
            panelHeader.Controls.Add(lblDiscountValue);
            panelHeader.Controls.Add(lblPriority);
            panelHeader.Controls.Add(lblStartDate);
            panelHeader.Controls.Add(lblEndDate);
            panelHeader.Controls.Add(lblMinInvoiceAmount);
            panelHeader.Controls.Add(lblMaxDiscountAmount);
            panelHeader.Controls.Add(lblNote);
            panelHeader.Controls.Add(CampaignCodeTextEdit);
            panelHeader.Controls.Add(CampaignDescTextEdit);
            panelHeader.Controls.Add(PromoCodeTextEdit);
            panelHeader.Controls.Add(DiscountTypeCodeComboBoxEdit);
            panelHeader.Controls.Add(DiscountValueCalcEdit);
            panelHeader.Controls.Add(PrioritySpinEdit);
            panelHeader.Controls.Add(IsCashOnlyCheckEdit);
            panelHeader.Controls.Add(IsActiveCheckEdit);
            panelHeader.Controls.Add(IsCombinableCheckEdit);
            panelHeader.Controls.Add(StartDateDateEdit);
            panelHeader.Controls.Add(EndDateDateEdit);
            panelHeader.Controls.Add(MinInvoiceAmountCalcEdit);
            panelHeader.Controls.Add(MaxDiscountAmountCalcEdit);
            panelHeader.Controls.Add(NoteMemoEdit);
            panelHeader.Controls.Add(lblCampaignPassword);
            panelHeader.Controls.Add(CampaignPasswordTextEdit);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(1180, 202);
            panelHeader.TabIndex = 2;
            // 
            // lblProcessCode
            // 
            lblProcessCode.Location = new Point(12, 137);
            lblProcessCode.Name = "lblProcessCode";
            lblProcessCode.Size = new Size(32, 13);
            lblProcessCode.TabIndex = 26;
            lblProcessCode.Text = "Proses";
            // 
            // LUE_processCode
            // 
            LUE_processCode.EditValue = "RS";
            LUE_processCode.Location = new Point(120, 134);
            LUE_processCode.Name = "LUE_processCode";
            LUE_processCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            LUE_processCode.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] { new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ProcessCode", ""), new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ProcessDesc", "Name2") });
            LUE_processCode.Properties.DisplayMember = "ProcessDesc";
            LUE_processCode.Properties.NullText = "";
            LUE_processCode.Properties.ValueMember = "ProcessCode";
            LUE_processCode.Size = new Size(244, 20);
            LUE_processCode.TabIndex = 3;
            // 
            // lblCampaignCode
            // 
            lblCampaignCode.Location = new Point(12, 15);
            lblCampaignCode.Name = "lblCampaignCode";
            lblCampaignCode.Size = new Size(78, 13);
            lblCampaignCode.TabIndex = 0;
            lblCampaignCode.Text = "Kampaniya kodu";
            // 
            // lblCampaignDesc
            // 
            lblCampaignDesc.Location = new Point(400, 15);
            lblCampaignDesc.Name = "lblCampaignDesc";
            lblCampaignDesc.Size = new Size(69, 13);
            lblCampaignDesc.TabIndex = 1;
            lblCampaignDesc.Text = "Kampaniya adı";
            // 
            // lblPromoCode
            // 
            lblPromoCode.Location = new Point(400, 45);
            lblPromoCode.Name = "lblPromoCode";
            lblPromoCode.Size = new Size(56, 13);
            lblPromoCode.TabIndex = 3;
            lblPromoCode.Text = "Promo code";
            // 
            // lblDiscountType
            // 
            lblDiscountType.Location = new Point(788, 45);
            lblDiscountType.Name = "lblDiscountType";
            lblDiscountType.Size = new Size(51, 13);
            lblDiscountType.TabIndex = 4;
            lblDiscountType.Text = "Endirim tipi";
            // 
            // lblDiscountValue
            // 
            lblDiscountValue.Location = new Point(12, 45);
            lblDiscountValue.Name = "lblDiscountValue";
            lblDiscountValue.Size = new Size(34, 13);
            lblDiscountValue.TabIndex = 5;
            lblDiscountValue.Text = "Endirim";
            // 
            // lblPriority
            // 
            lblPriority.Location = new Point(400, 75);
            lblPriority.Name = "lblPriority";
            lblPriority.Size = new Size(38, 13);
            lblPriority.TabIndex = 6;
            lblPriority.Text = "Prioritet";
            // 
            // lblStartDate
            // 
            lblStartDate.Location = new Point(12, 75);
            lblStartDate.Name = "lblStartDate";
            lblStartDate.Size = new Size(66, 13);
            lblStartDate.TabIndex = 7;
            lblStartDate.Text = "Başlama tarixi";
            // 
            // lblEndDate
            // 
            lblEndDate.Location = new Point(12, 105);
            lblEndDate.Name = "lblEndDate";
            lblEndDate.Size = new Size(53, 13);
            lblEndDate.TabIndex = 8;
            lblEndDate.Text = "Bitmə tarixi";
            // 
            // lblMinInvoiceAmount
            // 
            lblMinInvoiceAmount.Location = new Point(400, 109);
            lblMinInvoiceAmount.Name = "lblMinInvoiceAmount";
            lblMinInvoiceAmount.Size = new Size(58, 13);
            lblMinInvoiceAmount.TabIndex = 9;
            lblMinInvoiceAmount.Text = "Min. faktura";
            // 
            // lblMaxDiscountAmount
            // 
            lblMaxDiscountAmount.Location = new Point(400, 137);
            lblMaxDiscountAmount.Name = "lblMaxDiscountAmount";
            lblMaxDiscountAmount.Size = new Size(65, 13);
            lblMaxDiscountAmount.TabIndex = 10;
            lblMaxDiscountAmount.Text = "Maks. endirim";
            // 
            // lblNote
            // 
            lblNote.Location = new Point(12, 167);
            lblNote.Name = "lblNote";
            lblNote.Size = new Size(26, 13);
            lblNote.TabIndex = 11;
            lblNote.Text = "Qeyd";
            // 
            // CampaignCodeTextEdit
            // 
            CampaignCodeTextEdit.Location = new Point(124, 12);
            CampaignCodeTextEdit.Name = "CampaignCodeTextEdit";
            CampaignCodeTextEdit.Size = new Size(240, 20);
            CampaignCodeTextEdit.TabIndex = 12;
            // 
            // CampaignDescTextEdit
            // 
            CampaignDescTextEdit.Location = new Point(500, 12);
            CampaignDescTextEdit.Name = "CampaignDescTextEdit";
            CampaignDescTextEdit.Size = new Size(240, 20);
            CampaignDescTextEdit.TabIndex = 13;
            // 
            // PromoCodeTextEdit
            // 
            PromoCodeTextEdit.Location = new Point(500, 42);
            PromoCodeTextEdit.Name = "PromoCodeTextEdit";
            PromoCodeTextEdit.Size = new Size(240, 20);
            PromoCodeTextEdit.TabIndex = 15;
            // 
            // DiscountTypeCodeComboBoxEdit
            // 
            DiscountTypeCodeComboBoxEdit.Location = new Point(896, 42);
            DiscountTypeCodeComboBoxEdit.Name = "DiscountTypeCodeComboBoxEdit";
            DiscountTypeCodeComboBoxEdit.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            DiscountTypeCodeComboBoxEdit.Size = new Size(272, 20);
            DiscountTypeCodeComboBoxEdit.TabIndex = 16;
            // 
            // DiscountValueCalcEdit
            // 
            DiscountValueCalcEdit.Location = new Point(124, 42);
            DiscountValueCalcEdit.Name = "DiscountValueCalcEdit";
            DiscountValueCalcEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            DiscountValueCalcEdit.Size = new Size(240, 20);
            DiscountValueCalcEdit.TabIndex = 17;
            // 
            // PrioritySpinEdit
            // 
            PrioritySpinEdit.EditValue = new decimal(new int[] { 0, 0, 0, 0 });
            PrioritySpinEdit.Location = new Point(500, 72);
            PrioritySpinEdit.Name = "PrioritySpinEdit";
            PrioritySpinEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton() });
            PrioritySpinEdit.Size = new Size(240, 20);
            PrioritySpinEdit.TabIndex = 18;
            // 
            // IsActiveCheckEdit
            // 
            IsActiveCheckEdit.Location = new Point(896, 72);
            IsActiveCheckEdit.Name = "IsActiveCheckEdit";
            IsActiveCheckEdit.Properties.Caption = "Aktiv";
            IsActiveCheckEdit.Size = new Size(120, 20);
            IsActiveCheckEdit.TabIndex = 19;
            // 
            // IsCombinableCheckEdit
            // 
            IsCombinableCheckEdit.Location = new Point(1024, 72);
            IsCombinableCheckEdit.Name = "IsCombinableCheckEdit";
            IsCombinableCheckEdit.Properties.Caption = "Birləşə bilir";
            IsCombinableCheckEdit.Size = new Size(144, 20);
            IsCombinableCheckEdit.TabIndex = 20;
            // 
            // StartDateDateEdit
            // 
            StartDateDateEdit.EditValue = new DateTime(2026, 3, 22, 0, 0, 0, 0);
            StartDateDateEdit.Location = new Point(124, 72);
            StartDateDateEdit.Name = "StartDateDateEdit";
            StartDateDateEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            StartDateDateEdit.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            StartDateDateEdit.Size = new Size(240, 20);
            StartDateDateEdit.TabIndex = 21;
            // 
            // EndDateDateEdit
            // 
            EndDateDateEdit.EditValue = new DateTime(2026, 3, 22, 0, 0, 0, 0);
            EndDateDateEdit.Location = new Point(124, 102);
            EndDateDateEdit.Name = "EndDateDateEdit";
            EndDateDateEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            EndDateDateEdit.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            EndDateDateEdit.Size = new Size(240, 20);
            EndDateDateEdit.TabIndex = 22;
            // 
            // MinInvoiceAmountCalcEdit
            // 
            MinInvoiceAmountCalcEdit.Location = new Point(500, 106);
            MinInvoiceAmountCalcEdit.Name = "MinInvoiceAmountCalcEdit";
            MinInvoiceAmountCalcEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            MinInvoiceAmountCalcEdit.Size = new Size(240, 20);
            MinInvoiceAmountCalcEdit.TabIndex = 23;
            // 
            // MaxDiscountAmountCalcEdit
            // 
            MaxDiscountAmountCalcEdit.Location = new Point(500, 134);
            MaxDiscountAmountCalcEdit.Name = "MaxDiscountAmountCalcEdit";
            MaxDiscountAmountCalcEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            MaxDiscountAmountCalcEdit.Size = new Size(240, 20);
            MaxDiscountAmountCalcEdit.TabIndex = 24;
            // 
            // NoteMemoEdit
            // 
            NoteMemoEdit.Location = new Point(125, 165);
            NoteMemoEdit.Name = "NoteMemoEdit";
            NoteMemoEdit.Size = new Size(1044, 22);
            NoteMemoEdit.TabIndex = 25;
            // 
            // xtraTabControl1
            // 
            xtraTabControl1.Dock = DockStyle.Fill;
            xtraTabControl1.Location = new Point(0, 202);
            xtraTabControl1.Name = "xtraTabControl1";
            xtraTabControl1.SelectedTabPage = tabProduct;
            xtraTabControl1.Size = new Size(1180, 470);
            xtraTabControl1.TabIndex = 0;
            xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] { tabProduct, tabCategory, tabCustomer, tabStore, tabWarehouse, tabPaymentMethod });
            // 
            // tabProduct
            // 
            tabProduct.Controls.Add(gC_Product);
            tabProduct.Controls.Add(panelProduct);
            tabProduct.Name = "tabProduct";
            tabProduct.Size = new Size(1178, 445);
            tabProduct.Text = "Məhsullar";
            // 
            // gC_Product
            // 
            gC_Product.DataSource = trCampaignProductsBindingSource;
            gC_Product.Dock = DockStyle.Fill;
            gC_Product.Location = new Point(0, 40);
            gC_Product.MainView = gV_Product;
            gC_Product.Name = "gC_Product";
            gC_Product.Size = new Size(1178, 405);
            gC_Product.TabIndex = 0;
            gC_Product.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gV_Product });
            // 
            // trCampaignProductsBindingSource
            // 
            trCampaignProductsBindingSource.DataSource = typeof(TrCampaignProduct);
            trCampaignProductsBindingSource.AddingNew += trCampaignProductsBindingSource_AddingNew;
            // 
            // gV_Product
            // 
            gV_Product.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { colCampaignProductId, colProductCode, colProductDesc });
            gV_Product.GridControl = gC_Product;
            gV_Product.Name = "gV_Product";
            gV_Product.OptionsView.ShowGroupPanel = false;
            gV_Product.CustomUnboundColumnData += gV_Product_CustomUnboundColumnData;
            // 
            // colCampaignProductId
            // 
            colCampaignProductId.FieldName = "CampaignProductId";
            colCampaignProductId.Name = "colCampaignProductId";
            // 
            // colProductCode
            // 
            colProductCode.Caption = "Məhsul";
            colProductCode.FieldName = "ProductCode";
            colProductCode.Name = "colProductCode";
            colProductCode.Visible = true;
            colProductCode.VisibleIndex = 0;
            // 
            // colProductDesc
            // 
            colProductDesc.FieldName = "DcProduct.ProductDesc";
            colProductDesc.Name = "colProductDesc";
            colProductDesc.UnboundDataType = typeof(string);
            colProductDesc.Visible = true;
            colProductDesc.VisibleIndex = 1;
            // 
            // panelProduct
            // 
            panelProduct.Controls.Add(btnDeleteProduct);
            panelProduct.Controls.Add(btnAddProduct);
            panelProduct.Dock = DockStyle.Top;
            panelProduct.Location = new Point(0, 0);
            panelProduct.Name = "panelProduct";
            panelProduct.Size = new Size(1178, 40);
            panelProduct.TabIndex = 1;
            // 
            // btnDeleteProduct
            // 
            btnDeleteProduct.Location = new Point(124, 8);
            btnDeleteProduct.Name = "btnDeleteProduct";
            btnDeleteProduct.Size = new Size(110, 24);
            btnDeleteProduct.TabIndex = 0;
            btnDeleteProduct.Text = "Sil";
            btnDeleteProduct.Click += btnDeleteProduct_Click;
            // 
            // btnAddProduct
            // 
            btnAddProduct.Location = new Point(8, 8);
            btnAddProduct.Name = "btnAddProduct";
            btnAddProduct.Size = new Size(110, 24);
            btnAddProduct.TabIndex = 1;
            btnAddProduct.Text = "Əlavə et";
            btnAddProduct.Click += btnAddProduct_Click;
            // 
            // tabCategory
            // 
            tabCategory.Controls.Add(gC_Category);
            tabCategory.Controls.Add(panelCategory);
            tabCategory.Name = "tabCategory";
            tabCategory.Size = new Size(1178, 445);
            tabCategory.Text = "Kateqoriyalar";
            // 
            // gC_Category
            // 
            gC_Category.DataSource = trCampaignCategoriesBindingSource;
            gC_Category.Dock = DockStyle.Fill;
            gC_Category.Location = new Point(0, 40);
            gC_Category.MainView = gV_Category;
            gC_Category.Name = "gC_Category";
            gC_Category.Size = new Size(1178, 405);
            gC_Category.TabIndex = 0;
            gC_Category.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gV_Category });
            // 
            // trCampaignCategoriesBindingSource
            // 
            trCampaignCategoriesBindingSource.DataSource = typeof(TrCampaignCategory);
            trCampaignCategoriesBindingSource.AddingNew += trCampaignCategoriesBindingSource_AddingNew;
            // 
            // gV_Category
            // 
            gV_Category.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { colCampaignCategoryId, colHierarchyCode });
            gV_Category.GridControl = gC_Category;
            gV_Category.Name = "gV_Category";
            gV_Category.OptionsView.ShowGroupPanel = false;
            // 
            // colCampaignCategoryId
            // 
            colCampaignCategoryId.FieldName = "CampaignCategoryId";
            colCampaignCategoryId.Name = "colCampaignCategoryId";
            // 
            // colHierarchyCode
            // 
            colHierarchyCode.Caption = "Kateqoriya";
            colHierarchyCode.FieldName = "HierarchyCode";
            colHierarchyCode.Name = "colHierarchyCode";
            colHierarchyCode.Visible = true;
            colHierarchyCode.VisibleIndex = 0;
            // 
            // panelCategory
            // 
            panelCategory.Controls.Add(btnDeleteCategory);
            panelCategory.Controls.Add(btnAddCategory);
            panelCategory.Dock = DockStyle.Top;
            panelCategory.Location = new Point(0, 0);
            panelCategory.Name = "panelCategory";
            panelCategory.Size = new Size(1178, 40);
            panelCategory.TabIndex = 1;
            // 
            // btnDeleteCategory
            // 
            btnDeleteCategory.Location = new Point(124, 8);
            btnDeleteCategory.Name = "btnDeleteCategory";
            btnDeleteCategory.Size = new Size(110, 24);
            btnDeleteCategory.TabIndex = 0;
            btnDeleteCategory.Text = "Sil";
            btnDeleteCategory.Click += btnDeleteCategory_Click;
            // 
            // btnAddCategory
            // 
            btnAddCategory.Location = new Point(8, 8);
            btnAddCategory.Name = "btnAddCategory";
            btnAddCategory.Size = new Size(110, 24);
            btnAddCategory.TabIndex = 1;
            btnAddCategory.Text = "Əlavə et";
            btnAddCategory.Click += btnAddCategory_Click;
            // 
            // tabCustomer
            // 
            tabCustomer.Controls.Add(gC_Customer);
            tabCustomer.Controls.Add(panelCustomer);
            tabCustomer.Name = "tabCustomer";
            tabCustomer.Size = new Size(1178, 445);
            tabCustomer.Text = "Müştərilər";
            // 
            // gC_Customer
            // 
            gC_Customer.DataSource = trCampaignCustomersBindingSource;
            gC_Customer.Dock = DockStyle.Fill;
            gC_Customer.Location = new Point(0, 40);
            gC_Customer.MainView = gV_Customer;
            gC_Customer.Name = "gC_Customer";
            gC_Customer.Size = new Size(1178, 405);
            gC_Customer.TabIndex = 0;
            gC_Customer.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gV_Customer });
            // 
            // trCampaignCustomersBindingSource
            // 
            trCampaignCustomersBindingSource.DataSource = typeof(TrCampaignCustomer);
            trCampaignCustomersBindingSource.AddingNew += trCampaignCustomersBindingSource_AddingNew;
            // 
            // gV_Customer
            // 
            gV_Customer.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { colCampaignCustomerId, colCurrAccCode, colCurrAccDesc });
            gV_Customer.GridControl = gC_Customer;
            gV_Customer.Name = "gV_Customer";
            gV_Customer.OptionsView.ShowGroupPanel = false;
            gV_Customer.CustomUnboundColumnData += gV_Customer_CustomUnboundColumnData;
            // 
            // colCampaignCustomerId
            // 
            colCampaignCustomerId.FieldName = "CampaignCustomerId";
            colCampaignCustomerId.Name = "colCampaignCustomerId";
            // 
            // colCurrAccCode
            // 
            colCurrAccCode.Caption = "Müştəri";
            colCurrAccCode.FieldName = "CurrAccCode";
            colCurrAccCode.Name = "colCurrAccCode";
            colCurrAccCode.Visible = true;
            colCurrAccCode.VisibleIndex = 0;
            // 
            // colCurrAccDesc
            // 
            colCurrAccDesc.FieldName = "DcCurrAcc.CurrAccDesc";
            colCurrAccDesc.Name = "colCurrAccDesc";
            colCurrAccDesc.UnboundDataType = typeof(string);
            colCurrAccDesc.Visible = true;
            colCurrAccDesc.VisibleIndex = 1;
            // 
            // panelCustomer
            // 
            panelCustomer.Controls.Add(btnDeleteCustomer);
            panelCustomer.Controls.Add(btnAddCustomer);
            panelCustomer.Dock = DockStyle.Top;
            panelCustomer.Location = new Point(0, 0);
            panelCustomer.Name = "panelCustomer";
            panelCustomer.Size = new Size(1178, 40);
            panelCustomer.TabIndex = 1;
            // 
            // btnDeleteCustomer
            // 
            btnDeleteCustomer.Location = new Point(124, 8);
            btnDeleteCustomer.Name = "btnDeleteCustomer";
            btnDeleteCustomer.Size = new Size(110, 24);
            btnDeleteCustomer.TabIndex = 0;
            btnDeleteCustomer.Text = "Sil";
            btnDeleteCustomer.Click += btnDeleteCustomer_Click;
            // 
            // btnAddCustomer
            // 
            btnAddCustomer.Location = new Point(8, 8);
            btnAddCustomer.Name = "btnAddCustomer";
            btnAddCustomer.Size = new Size(110, 24);
            btnAddCustomer.TabIndex = 1;
            btnAddCustomer.Text = "Əlavə et";
            btnAddCustomer.Click += btnAddCustomer_Click;
            // 
            // tabStore
            // 
            tabStore.Controls.Add(gC_Store);
            tabStore.Controls.Add(panelStore);
            tabStore.Name = "tabStore";
            tabStore.Size = new Size(1178, 445);
            tabStore.Text = "Store";
            // 
            // gC_Store
            // 
            gC_Store.DataSource = trCampaignStoresBindingSource;
            gC_Store.Dock = DockStyle.Fill;
            gC_Store.Location = new Point(0, 40);
            gC_Store.MainView = gV_Store;
            gC_Store.Name = "gC_Store";
            gC_Store.Size = new Size(1178, 405);
            gC_Store.TabIndex = 0;
            gC_Store.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gV_Store });
            // 
            // trCampaignStoresBindingSource
            // 
            trCampaignStoresBindingSource.DataSource = typeof(TrCampaignStore);
            trCampaignStoresBindingSource.AddingNew += trCampaignStoresBindingSource_AddingNew;
            // 
            // gV_Store
            // 
            gV_Store.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { colCampaignStoreId, colStoreCode });
            gV_Store.GridControl = gC_Store;
            gV_Store.Name = "gV_Store";
            gV_Store.OptionsView.ShowGroupPanel = false;
            // 
            // colCampaignStoreId
            // 
            colCampaignStoreId.FieldName = "CampaignStoreId";
            colCampaignStoreId.Name = "colCampaignStoreId";
            // 
            // colStoreCode
            // 
            colStoreCode.Caption = "Store";
            colStoreCode.FieldName = "StoreCode";
            colStoreCode.Name = "colStoreCode";
            colStoreCode.Visible = true;
            colStoreCode.VisibleIndex = 0;
            // 
            // panelStore
            // 
            panelStore.Controls.Add(btnDeleteStore);
            panelStore.Controls.Add(btnAddStore);
            panelStore.Dock = DockStyle.Top;
            panelStore.Location = new Point(0, 0);
            panelStore.Name = "panelStore";
            panelStore.Size = new Size(1178, 40);
            panelStore.TabIndex = 1;
            // 
            // btnDeleteStore
            // 
            btnDeleteStore.Location = new Point(124, 8);
            btnDeleteStore.Name = "btnDeleteStore";
            btnDeleteStore.Size = new Size(110, 24);
            btnDeleteStore.TabIndex = 0;
            btnDeleteStore.Text = "Sil";
            btnDeleteStore.Click += btnDeleteStore_Click;
            // 
            // btnAddStore
            // 
            btnAddStore.Location = new Point(8, 8);
            btnAddStore.Name = "btnAddStore";
            btnAddStore.Size = new Size(110, 24);
            btnAddStore.TabIndex = 1;
            btnAddStore.Text = "Əlavə et";
            btnAddStore.Click += btnAddStore_Click;
            // 
            // tabWarehouse
            // 
            tabWarehouse.Controls.Add(gC_Warehouse);
            tabWarehouse.Controls.Add(panelWarehouse);
            tabWarehouse.Name = "tabWarehouse";
            tabWarehouse.Size = new Size(1178, 445);
            tabWarehouse.Text = "Depolar";
            // 
            // gC_Warehouse
            // 
            gC_Warehouse.DataSource = trCampaignWarehousesBindingSource;
            gC_Warehouse.Dock = DockStyle.Fill;
            gC_Warehouse.Location = new Point(0, 40);
            gC_Warehouse.MainView = gV_Warehouse;
            gC_Warehouse.Name = "gC_Warehouse";
            gC_Warehouse.Size = new Size(1178, 405);
            gC_Warehouse.TabIndex = 0;
            gC_Warehouse.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gV_Warehouse });
            // 
            // trCampaignWarehousesBindingSource
            // 
            trCampaignWarehousesBindingSource.DataSource = typeof(TrCampaignWarehouse);
            trCampaignWarehousesBindingSource.AddingNew += trCampaignWarehousesBindingSource_AddingNew;
            // 
            // gV_Warehouse
            // 
            gV_Warehouse.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { colCampaignWarehouseId, colWarehouseCode });
            gV_Warehouse.GridControl = gC_Warehouse;
            gV_Warehouse.Name = "gV_Warehouse";
            gV_Warehouse.OptionsView.ShowGroupPanel = false;
            // 
            // colCampaignWarehouseId
            // 
            colCampaignWarehouseId.FieldName = "CampaignWarehouseId";
            colCampaignWarehouseId.Name = "colCampaignWarehouseId";
            // 
            // colWarehouseCode
            // 
            colWarehouseCode.Caption = "Depo";
            colWarehouseCode.FieldName = "WarehouseCode";
            colWarehouseCode.Name = "colWarehouseCode";
            colWarehouseCode.Visible = true;
            colWarehouseCode.VisibleIndex = 0;
            // 
            // panelWarehouse
            // 
            panelWarehouse.Controls.Add(btnDeleteWarehouse);
            panelWarehouse.Controls.Add(btnAddWarehouse);
            panelWarehouse.Dock = DockStyle.Top;
            panelWarehouse.Location = new Point(0, 0);
            panelWarehouse.Name = "panelWarehouse";
            panelWarehouse.Size = new Size(1178, 40);
            panelWarehouse.TabIndex = 1;
            // 
            // btnDeleteWarehouse
            // 
            btnDeleteWarehouse.Location = new Point(124, 8);
            btnDeleteWarehouse.Name = "btnDeleteWarehouse";
            btnDeleteWarehouse.Size = new Size(110, 24);
            btnDeleteWarehouse.TabIndex = 0;
            btnDeleteWarehouse.Text = "Sil";
            btnDeleteWarehouse.Click += btnDeleteWarehouse_Click;
            // 
            // btnAddWarehouse
            // 
            btnAddWarehouse.Location = new Point(8, 8);
            btnAddWarehouse.Name = "btnAddWarehouse";
            btnAddWarehouse.Size = new Size(110, 24);
            btnAddWarehouse.TabIndex = 1;
            btnAddWarehouse.Text = "Əlavə et";
            btnAddWarehouse.Click += btnAddWarehouse_Click;
            // 
            // tabPaymentMethod
            // 
            tabPaymentMethod.Controls.Add(gC_PaymentMethod);
            tabPaymentMethod.Controls.Add(panelPaymentMethod);
            tabPaymentMethod.Name = "tabPaymentMethod";
            tabPaymentMethod.Size = new Size(1178, 445);
            tabPaymentMethod.Text = "Ödəmə üsulları";
            // 
            // gC_PaymentMethod
            // 
            gC_PaymentMethod.DataSource = trCampaignPaymentMethodsBindingSource;
            gC_PaymentMethod.Dock = DockStyle.Fill;
            gC_PaymentMethod.Location = new Point(0, 40);
            gC_PaymentMethod.MainView = gV_PaymentMethod;
            gC_PaymentMethod.Name = "gC_PaymentMethod";
            gC_PaymentMethod.Size = new Size(1178, 405);
            gC_PaymentMethod.TabIndex = 0;
            gC_PaymentMethod.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gV_PaymentMethod });
            // 
            // trCampaignPaymentMethodsBindingSource
            // 
            trCampaignPaymentMethodsBindingSource.AddingNew += trCampaignPaymentMethodsBindingSource_AddingNew;
            // 
            // gV_PaymentMethod
            // 
            gV_PaymentMethod.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { colCampaignPaymentMethodId, colPaymentMethodId, colPaymentMethodDesc });
            gV_PaymentMethod.GridControl = gC_PaymentMethod;
            gV_PaymentMethod.Name = "gV_PaymentMethod";
            gV_PaymentMethod.OptionsView.ShowGroupPanel = false;
            gV_PaymentMethod.CustomUnboundColumnData += gV_PaymentMethod_CustomUnboundColumnData;
            // 
            // colCampaignPaymentMethodId
            // 
            colCampaignPaymentMethodId.FieldName = "CampaignPaymentMethodId";
            colCampaignPaymentMethodId.Name = "colCampaignPaymentMethodId";
            // 
            // colPaymentMethodId
            // 
            colPaymentMethodId.Caption = "Ödəmə üsulu";
            colPaymentMethodId.FieldName = "PaymentMethodId";
            colPaymentMethodId.Name = "colPaymentMethodId";
            colPaymentMethodId.Visible = true;
            colPaymentMethodId.VisibleIndex = 0;
            // 
            // colPaymentMethodDesc
            // 
            colPaymentMethodDesc.FieldName = "DcPaymentMethod.PaymentMethodDesc";
            colPaymentMethodDesc.Name = "colPaymentMethodDesc";
            colPaymentMethodDesc.UnboundDataType = typeof(string);
            colPaymentMethodDesc.Visible = true;
            colPaymentMethodDesc.VisibleIndex = 1;
            // 
            // panelPaymentMethod
            // 
            panelPaymentMethod.Controls.Add(btnDeletePaymentMethod);
            panelPaymentMethod.Controls.Add(btnAddPaymentMethod);
            panelPaymentMethod.Dock = DockStyle.Top;
            panelPaymentMethod.Location = new Point(0, 0);
            panelPaymentMethod.Name = "panelPaymentMethod";
            panelPaymentMethod.Size = new Size(1178, 40);
            panelPaymentMethod.TabIndex = 1;
            // 
            // btnDeletePaymentMethod
            // 
            btnDeletePaymentMethod.Location = new Point(124, 8);
            btnDeletePaymentMethod.Name = "btnDeletePaymentMethod";
            btnDeletePaymentMethod.Size = new Size(110, 24);
            btnDeletePaymentMethod.TabIndex = 0;
            btnDeletePaymentMethod.Text = "Sil";
            btnDeletePaymentMethod.Click += btnDeletePaymentMethod_Click;
            // 
            // btnAddPaymentMethod
            // 
            btnAddPaymentMethod.Location = new Point(8, 8);
            btnAddPaymentMethod.Name = "btnAddPaymentMethod";
            btnAddPaymentMethod.Size = new Size(110, 24);
            btnAddPaymentMethod.TabIndex = 1;
            btnAddPaymentMethod.Text = "Əlavə et";
            btnAddPaymentMethod.Click += btnAddPaymentMethod_Click;
            // 
            // panelButtons
            // 
            panelButtons.Controls.Add(btn_Cancel);
            panelButtons.Controls.Add(btn_Ok);
            panelButtons.Dock = DockStyle.Bottom;
            panelButtons.Location = new Point(0, 672);
            panelButtons.Name = "panelButtons";
            panelButtons.Size = new Size(1180, 48);
            panelButtons.TabIndex = 1;
            // 
            // btn_Cancel
            // 
            btn_Cancel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btn_Cancel.Location = new Point(1058, 10);
            btn_Cancel.Name = "btn_Cancel";
            btn_Cancel.Size = new Size(110, 28);
            btn_Cancel.TabIndex = 0;
            btn_Cancel.Text = "Bağla";
            btn_Cancel.Click += btn_Cancel_Click;
            // 
            // btn_Ok
            // 
            btn_Ok.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btn_Ok.Location = new Point(942, 10);
            btn_Ok.Name = "btn_Ok";
            btn_Ok.Size = new Size(110, 28);
            btn_Ok.TabIndex = 1;
            btn_Ok.Text = "Yadda saxla";
            btn_Ok.Click += btn_Ok_Click;
            // 
            // dcCampaignsBindingSource
            // 
            dcCampaignsBindingSource.DataSource = typeof(DcCampaign);
            // 
            // IsCashOnlyCheckEdit
            // 
            IsCashOnlyCheckEdit.Location = new Point(896, 98);
            IsCashOnlyCheckEdit.Name = "IsCashOnlyCheckEdit";
            IsCashOnlyCheckEdit.Properties.Caption = "IsCashOnly";
            IsCashOnlyCheckEdit.Size = new Size(120, 20);
            IsCashOnlyCheckEdit.TabIndex = 19;
            // 
            // FormCampaign
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1180, 720);
            Controls.Add(xtraTabControl1);
            Controls.Add(panelButtons);
            Controls.Add(panelHeader);
            Name = "FormCampaign";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Kampaniya";
            Load += FormCampaign_Load;
            ((System.ComponentModel.ISupportInitialize)CampaignPasswordTextEdit.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)panelHeader).EndInit();
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)LUE_processCode.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)CampaignCodeTextEdit.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)CampaignDescTextEdit.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)PromoCodeTextEdit.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)DiscountTypeCodeComboBoxEdit.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)DiscountValueCalcEdit.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)PrioritySpinEdit.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)IsActiveCheckEdit.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)IsCombinableCheckEdit.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)StartDateDateEdit.Properties.CalendarTimeProperties).EndInit();
            ((System.ComponentModel.ISupportInitialize)StartDateDateEdit.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)EndDateDateEdit.Properties.CalendarTimeProperties).EndInit();
            ((System.ComponentModel.ISupportInitialize)EndDateDateEdit.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)MinInvoiceAmountCalcEdit.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)MaxDiscountAmountCalcEdit.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)NoteMemoEdit.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)xtraTabControl1).EndInit();
            xtraTabControl1.ResumeLayout(false);
            tabProduct.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)gC_Product).EndInit();
            ((System.ComponentModel.ISupportInitialize)trCampaignProductsBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)gV_Product).EndInit();
            ((System.ComponentModel.ISupportInitialize)panelProduct).EndInit();
            panelProduct.ResumeLayout(false);
            tabCategory.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)gC_Category).EndInit();
            ((System.ComponentModel.ISupportInitialize)trCampaignCategoriesBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)gV_Category).EndInit();
            ((System.ComponentModel.ISupportInitialize)panelCategory).EndInit();
            panelCategory.ResumeLayout(false);
            tabCustomer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)gC_Customer).EndInit();
            ((System.ComponentModel.ISupportInitialize)trCampaignCustomersBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)gV_Customer).EndInit();
            ((System.ComponentModel.ISupportInitialize)panelCustomer).EndInit();
            panelCustomer.ResumeLayout(false);
            tabStore.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)gC_Store).EndInit();
            ((System.ComponentModel.ISupportInitialize)trCampaignStoresBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)gV_Store).EndInit();
            ((System.ComponentModel.ISupportInitialize)panelStore).EndInit();
            panelStore.ResumeLayout(false);
            tabWarehouse.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)gC_Warehouse).EndInit();
            ((System.ComponentModel.ISupportInitialize)trCampaignWarehousesBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)gV_Warehouse).EndInit();
            ((System.ComponentModel.ISupportInitialize)panelWarehouse).EndInit();
            panelWarehouse.ResumeLayout(false);
            tabPaymentMethod.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)gC_PaymentMethod).EndInit();
            ((System.ComponentModel.ISupportInitialize)trCampaignPaymentMethodsBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)gV_PaymentMethod).EndInit();
            ((System.ComponentModel.ISupportInitialize)panelPaymentMethod).EndInit();
            panelPaymentMethod.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)panelButtons).EndInit();
            panelButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dcCampaignsBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)IsCashOnlyCheckEdit.Properties).EndInit();
            ResumeLayout(false);
        }

        private DevExpress.XtraEditors.PanelControl panelHeader;
        private DevExpress.XtraEditors.LabelControl lblCampaignCode;
        private DevExpress.XtraEditors.LabelControl lblCampaignDesc;
        private DevExpress.XtraEditors.LabelControl lblPromoCode;
        private DevExpress.XtraEditors.LabelControl lblDiscountType;
        private DevExpress.XtraEditors.LabelControl lblDiscountValue;
        private DevExpress.XtraEditors.LabelControl lblPriority;
        private DevExpress.XtraEditors.LabelControl lblStartDate;
        private DevExpress.XtraEditors.LabelControl lblEndDate;
        private DevExpress.XtraEditors.LabelControl lblMinInvoiceAmount;
        private DevExpress.XtraEditors.LabelControl lblMaxDiscountAmount;
        private DevExpress.XtraEditors.LabelControl lblNote;

        private DevExpress.XtraEditors.TextEdit CampaignCodeTextEdit;
        private DevExpress.XtraEditors.TextEdit CampaignDescTextEdit;
        private DevExpress.XtraEditors.TextEdit PromoCodeTextEdit;
        private DevExpress.XtraEditors.ComboBoxEdit DiscountTypeCodeComboBoxEdit;
        private DevExpress.XtraEditors.CalcEdit DiscountValueCalcEdit;
        private DevExpress.XtraEditors.SpinEdit PrioritySpinEdit;
        private DevExpress.XtraEditors.CheckEdit IsActiveCheckEdit;
        private DevExpress.XtraEditors.CheckEdit IsCombinableCheckEdit;
        private DevExpress.XtraEditors.DateEdit StartDateDateEdit;
        private DevExpress.XtraEditors.DateEdit EndDateDateEdit;
        private DevExpress.XtraEditors.CalcEdit MinInvoiceAmountCalcEdit;
        private DevExpress.XtraEditors.CalcEdit MaxDiscountAmountCalcEdit;
        private DevExpress.XtraEditors.MemoEdit NoteMemoEdit;

        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage tabProduct;
        private DevExpress.XtraTab.XtraTabPage tabCategory;
        private DevExpress.XtraTab.XtraTabPage tabCustomer;
        private DevExpress.XtraTab.XtraTabPage tabStore;
        private DevExpress.XtraTab.XtraTabPage tabWarehouse;
        private DevExpress.XtraTab.XtraTabPage tabPaymentMethod;

        private DevExpress.XtraGrid.GridControl gC_Product;
        private DevExpress.XtraGrid.Views.Grid.GridView gV_Product;
        private DevExpress.XtraGrid.GridControl gC_Category;
        private DevExpress.XtraGrid.Views.Grid.GridView gV_Category;
        private DevExpress.XtraGrid.GridControl gC_Customer;
        private DevExpress.XtraGrid.Views.Grid.GridView gV_Customer;
        private DevExpress.XtraGrid.GridControl gC_Store;
        private DevExpress.XtraGrid.Views.Grid.GridView gV_Store;
        private DevExpress.XtraGrid.GridControl gC_Warehouse;
        private DevExpress.XtraGrid.Views.Grid.GridView gV_Warehouse;
        private DevExpress.XtraGrid.GridControl gC_PaymentMethod;
        private DevExpress.XtraGrid.Views.Grid.GridView gV_PaymentMethod;

        private BindingSource dcCampaignsBindingSource;
        private BindingSource trCampaignProductsBindingSource;
        private BindingSource trCampaignCategoriesBindingSource;
        private BindingSource trCampaignCustomersBindingSource;
        private BindingSource trCampaignStoresBindingSource;
        private BindingSource trCampaignWarehousesBindingSource;
        private BindingSource trCampaignPaymentMethodsBindingSource;


        private DevExpress.XtraEditors.PanelControl panelButtons;
        private DevExpress.XtraEditors.SimpleButton btn_Ok;
        private DevExpress.XtraEditors.SimpleButton btn_Cancel;

        private DevExpress.XtraEditors.PanelControl panelProduct;
        private DevExpress.XtraEditors.PanelControl panelCategory;
        private DevExpress.XtraEditors.PanelControl panelCustomer;
        private DevExpress.XtraEditors.PanelControl panelStore;
        private DevExpress.XtraEditors.PanelControl panelWarehouse;
        private DevExpress.XtraEditors.PanelControl panelPaymentMethod;

        private DevExpress.XtraEditors.SimpleButton btnAddProduct;
        private DevExpress.XtraEditors.SimpleButton btnDeleteProduct;
        private DevExpress.XtraEditors.SimpleButton btnAddCategory;
        private DevExpress.XtraEditors.SimpleButton btnDeleteCategory;
        private DevExpress.XtraEditors.SimpleButton btnAddCustomer;
        private DevExpress.XtraEditors.SimpleButton btnDeleteCustomer;
        private DevExpress.XtraEditors.SimpleButton btnAddStore;
        private DevExpress.XtraEditors.SimpleButton btnDeleteStore;
        private DevExpress.XtraEditors.SimpleButton btnAddWarehouse;
        private DevExpress.XtraEditors.SimpleButton btnDeleteWarehouse;
        private DevExpress.XtraEditors.SimpleButton btnAddPaymentMethod;
        private DevExpress.XtraEditors.SimpleButton btnDeletePaymentMethod;

        private DevExpress.XtraGrid.Columns.GridColumn colCampaignProductId;
        private DevExpress.XtraGrid.Columns.GridColumn colProductCode;
        private DevExpress.XtraGrid.Columns.GridColumn colCampaignCategoryId;
        private DevExpress.XtraGrid.Columns.GridColumn colHierarchyCode;
        private DevExpress.XtraGrid.Columns.GridColumn colCampaignCustomerId;
        private DevExpress.XtraGrid.Columns.GridColumn colCurrAccCode;
        private DevExpress.XtraGrid.Columns.GridColumn colCampaignStoreId;
        private DevExpress.XtraGrid.Columns.GridColumn colStoreCode;
        private DevExpress.XtraGrid.Columns.GridColumn colCampaignWarehouseId;
        private DevExpress.XtraGrid.Columns.GridColumn colWarehouseCode;
        private DevExpress.XtraGrid.Columns.GridColumn colCampaignPaymentMethodId;
        private DevExpress.XtraGrid.Columns.GridColumn colPaymentMethodId;
        private DevExpress.XtraGrid.Columns.GridColumn colProductDesc;
        private DevExpress.XtraGrid.Columns.GridColumn colCurrAccDesc;
        private DevExpress.XtraGrid.Columns.GridColumn colPaymentMethodDesc;
        private DevExpress.XtraEditors.LookUpEdit LUE_processCode;
        private DevExpress.XtraEditors.LabelControl lblProcessCode;

        private DevExpress.XtraEditors.LabelControl lblCampaignPassword;
        private DevExpress.XtraEditors.TextEdit CampaignPasswordTextEdit;
        private DevExpress.XtraEditors.CheckEdit IsCashOnlyCheckEdit;
    }
}