namespace Foxoft
{
    partial class FormSalesBonusPlanEdit
    {
        private System.ComponentModel.IContainer components = null;

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
            this.layout = new DevExpress.XtraLayout.LayoutControl();
            this.txtPlanName = new DevExpress.XtraEditors.TextEdit();
            this.txtDescription = new DevExpress.XtraEditors.TextEdit();
            this.lkpCalcMethod = new DevExpress.XtraEditors.LookUpEdit();
            this.lkpTriggerType = new DevExpress.XtraEditors.LookUpEdit();
            this.lkpTierMode = new DevExpress.XtraEditors.LookUpEdit();
            this.lkpPeriodType = new DevExpress.XtraEditors.LookUpEdit();
            this.spinRate = new DevExpress.XtraEditors.SpinEdit();
            this.spinFixedAmount = new DevExpress.XtraEditors.SpinEdit();
            this.spinTargetAmount = new DevExpress.XtraEditors.SpinEdit();
            this.spinTargetMinAchievement = new DevExpress.XtraEditors.SpinEdit();
            this.spinMinBaseAmount = new DevExpress.XtraEditors.SpinEdit();
            this.spinMaxBonusAmount = new DevExpress.XtraEditors.SpinEdit();
            this.txtProcessCodes = new DevExpress.XtraEditors.TextEdit();
            this.chkIsActive = new DevExpress.XtraEditors.CheckEdit();
            this.lblTierHint = new DevExpress.XtraEditors.LabelControl();
            this.gridTiers = new MyGridControl();
            this.viewTiers = new MyGridView();
            this.colTierFrom = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTierTo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTierRate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTierFixed = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnAddTier = new DevExpress.XtraEditors.SimpleButton();
            this.btnRemoveTier = new DevExpress.XtraEditors.SimpleButton();
            this.gridProducts = new MyGridControl();
            this.viewProducts = new MyGridView();
            this.colProductCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProductDesc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProductRate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnAddProduct = new DevExpress.XtraEditors.SimpleButton();
            this.btnRemoveProduct = new DevExpress.XtraEditors.SimpleButton();
            this.gridCategories = new MyGridControl();
            this.viewCategories = new MyGridView();
            this.colCategoryCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCategoryDesc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCategoryRate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnAddCategory = new DevExpress.XtraEditors.SimpleButton();
            this.btnRemoveCategory = new DevExpress.XtraEditors.SimpleButton();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();

            ((System.ComponentModel.ISupportInitialize)(this.layout)).BeginInit();
            this.layout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPlanName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescription.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpCalcMethod.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpTriggerType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpTierMode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpPeriodType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinRate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinFixedAmount.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinTargetAmount.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinTargetMinAchievement.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinMinBaseAmount.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinMaxBonusAmount.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProcessCodes.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIsActive.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridTiers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewTiers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridProducts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewProducts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridCategories)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewCategories)).BeginInit();
            this.SuspendLayout();

            this.layout.Dock = System.Windows.Forms.DockStyle.Fill;
            var root = new DevExpress.XtraLayout.LayoutControlGroup { EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True };

            // enum lookups
            foreach (var lkp in new[] { this.lkpCalcMethod, this.lkpTriggerType, this.lkpTierMode, this.lkpPeriodType })
            {
                lkp.Properties.DisplayMember = "Text";
                lkp.Properties.ValueMember = "Value";
                lkp.Properties.NullText = "";
                lkp.Properties.ShowHeader = false;
                lkp.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
                lkp.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
                lkp.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] { new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Text", "") });
                lkp.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            }

            // numeric editors
            ConfigureSpin(this.spinRate, 4, 0m, 1000000m);
            ConfigureSpin(this.spinFixedAmount, 2, -100000000m, 100000000m);
            ConfigureSpin(this.spinTargetAmount, 2, 0m, 1000000000m);
            ConfigureSpin(this.spinTargetMinAchievement, 2, 0m, 1000m);
            ConfigureSpin(this.spinMinBaseAmount, 2, 0m, 1000000000m);
            ConfigureSpin(this.spinMaxBonusAmount, 2, 0m, 1000000000m);
            this.spinMaxBonusAmount.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.spinMaxBonusAmount.Properties.NullText = "";

            this.chkIsActive.Text = Foxoft.Properties.Resources.Entity_SalesBonusPlan_IsActive;

            this.lblTierHint.Text = Foxoft.Properties.Resources.Form_SalesBonusPlanEdit_TierHint;
            this.lblTierHint.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.lblTierHint.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;

            // tiers grid
            this.gridTiers.MainView = this.viewTiers;
            this.gridTiers.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { this.viewTiers });
            this.viewTiers.GridControl = this.gridTiers;
            this.viewTiers.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { this.colTierFrom, this.colTierTo, this.colTierRate, this.colTierFixed });
            this.viewTiers.OptionsBehavior.Editable = true;
            this.viewTiers.OptionsView.ShowGroupPanel = false;
            this.viewTiers.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None;
            this.viewTiers.OptionsView.ColumnAutoWidth = true;

            this.colTierFrom.Caption = Foxoft.Properties.Resources.Entity_SalesBonusPlanTier_FromValue;
            this.colTierFrom.FieldName = "FromValue";
            this.colTierFrom.Name = "colTierFrom";
            this.colTierFrom.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colTierFrom.DisplayFormat.FormatString = "n2";
            this.colTierFrom.Visible = true;
            this.colTierFrom.VisibleIndex = 0;

            this.colTierTo.Caption = Foxoft.Properties.Resources.Entity_SalesBonusPlanTier_ToValue;
            this.colTierTo.FieldName = "ToValue";
            this.colTierTo.Name = "colTierTo";
            this.colTierTo.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colTierTo.DisplayFormat.FormatString = "n2";
            this.colTierTo.Visible = true;
            this.colTierTo.VisibleIndex = 1;

            this.colTierRate.Caption = Foxoft.Properties.Resources.Entity_SalesBonusPlanTier_Rate;
            this.colTierRate.FieldName = "Rate";
            this.colTierRate.Name = "colTierRate";
            this.colTierRate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colTierRate.DisplayFormat.FormatString = "n4";
            this.colTierRate.Visible = true;
            this.colTierRate.VisibleIndex = 2;

            this.colTierFixed.Caption = Foxoft.Properties.Resources.Entity_SalesBonusPlanTier_FixedAmount;
            this.colTierFixed.FieldName = "FixedAmount";
            this.colTierFixed.Name = "colTierFixed";
            this.colTierFixed.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colTierFixed.DisplayFormat.FormatString = "n2";
            this.colTierFixed.Visible = true;
            this.colTierFixed.VisibleIndex = 3;

            this.btnAddTier.Text = Foxoft.Properties.Resources.Common_New;
            this.btnRemoveTier.Text = Foxoft.Properties.Resources.Common_Delete;

            // products grid
            this.gridProducts.MainView = this.viewProducts;
            this.gridProducts.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { this.viewProducts });
            this.viewProducts.GridControl = this.gridProducts;
            this.viewProducts.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { this.colProductCode, this.colProductDesc, this.colProductRate });
            this.viewProducts.OptionsBehavior.Editable = true;
            this.viewProducts.OptionsView.ShowGroupPanel = false;
            this.viewProducts.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None;
            this.viewProducts.OptionsView.ColumnAutoWidth = true;

            this.colProductCode.Caption = Foxoft.Properties.Resources.Entity_Product_Code;
            this.colProductCode.FieldName = "ProductCode";
            this.colProductCode.Name = "colProductCode";
            this.colProductCode.OptionsColumn.AllowEdit = false;
            this.colProductCode.Visible = true;
            this.colProductCode.VisibleIndex = 0;

            this.colProductDesc.Caption = Foxoft.Properties.Resources.Entity_Product_Desc;
            this.colProductDesc.FieldName = "ProductDesc";
            this.colProductDesc.Name = "colProductDesc";
            this.colProductDesc.OptionsColumn.AllowEdit = false;
            this.colProductDesc.Visible = true;
            this.colProductDesc.VisibleIndex = 1;

            this.colProductRate.Caption = Foxoft.Properties.Resources.Entity_SalesBonusPlan_RateOverride;
            this.colProductRate.FieldName = "RateOverride";
            this.colProductRate.Name = "colProductRate";
            this.colProductRate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colProductRate.DisplayFormat.FormatString = "n4";
            this.colProductRate.Visible = true;
            this.colProductRate.VisibleIndex = 2;

            this.btnAddProduct.Text = Foxoft.Properties.Resources.Common_New;
            this.btnRemoveProduct.Text = Foxoft.Properties.Resources.Common_Delete;

            // categories grid
            this.gridCategories.MainView = this.viewCategories;
            this.gridCategories.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { this.viewCategories });
            this.viewCategories.GridControl = this.gridCategories;
            this.viewCategories.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { this.colCategoryCode, this.colCategoryDesc, this.colCategoryRate });
            this.viewCategories.OptionsBehavior.Editable = true;
            this.viewCategories.OptionsView.ShowGroupPanel = false;
            this.viewCategories.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None;
            this.viewCategories.OptionsView.ColumnAutoWidth = true;

            this.colCategoryCode.Caption = Foxoft.Properties.Resources.Entity_Hierarchy_Code;
            this.colCategoryCode.FieldName = "HierarchyCode";
            this.colCategoryCode.Name = "colCategoryCode";
            this.colCategoryCode.OptionsColumn.AllowEdit = false;
            this.colCategoryCode.Visible = true;
            this.colCategoryCode.VisibleIndex = 0;

            this.colCategoryDesc.Caption = Foxoft.Properties.Resources.Entity_Hierarchy_Desc;
            this.colCategoryDesc.FieldName = "HierarchyDesc";
            this.colCategoryDesc.Name = "colCategoryDesc";
            this.colCategoryDesc.OptionsColumn.AllowEdit = false;
            this.colCategoryDesc.Visible = true;
            this.colCategoryDesc.VisibleIndex = 1;

            this.colCategoryRate.Caption = Foxoft.Properties.Resources.Entity_SalesBonusPlan_RateOverride;
            this.colCategoryRate.FieldName = "RateOverride";
            this.colCategoryRate.Name = "colCategoryRate";
            this.colCategoryRate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colCategoryRate.DisplayFormat.FormatString = "n4";
            this.colCategoryRate.Visible = true;
            this.colCategoryRate.VisibleIndex = 2;

            this.btnAddCategory.Text = Foxoft.Properties.Resources.Common_New;
            this.btnRemoveCategory.Text = Foxoft.Properties.Resources.Common_Delete;

            this.btnSave.Text = Foxoft.Properties.Resources.Common_Save;
            this.btnCancel.Text = Foxoft.Properties.Resources.Common_Cancel;

            // layout
            this.layout.Root = root;
            this.layout.AddItem(Foxoft.Properties.Resources.Entity_SalesBonusPlan_PlanName, this.txtPlanName);
            this.layout.AddItem(Foxoft.Properties.Resources.Entity_SalesBonusPlan_Description, this.txtDescription);
            this.layout.AddItem(Foxoft.Properties.Resources.Entity_SalesBonusPlan_CalcMethod, this.lkpCalcMethod);
            this.layout.AddItem(Foxoft.Properties.Resources.Entity_SalesBonusPlan_TriggerType, this.lkpTriggerType);
            this.layout.AddItem(Foxoft.Properties.Resources.Entity_SalesBonusPlan_TierMode, this.lkpTierMode);
            this.layout.AddItem(Foxoft.Properties.Resources.Entity_SalesBonusPlan_PeriodType, this.lkpPeriodType);
            this.layout.AddItem(Foxoft.Properties.Resources.Entity_SalesBonusPlan_Rate, this.spinRate);
            this.layout.AddItem(Foxoft.Properties.Resources.Entity_SalesBonusPlan_FixedAmount, this.spinFixedAmount);
            this.layout.AddItem(Foxoft.Properties.Resources.Entity_SalesBonusPlan_TargetAmount, this.spinTargetAmount);
            this.layout.AddItem(Foxoft.Properties.Resources.Entity_SalesBonusPlan_TargetMinAchievementPercent, this.spinTargetMinAchievement);
            this.layout.AddItem(Foxoft.Properties.Resources.Entity_SalesBonusPlan_MinBaseAmount, this.spinMinBaseAmount);
            this.layout.AddItem(Foxoft.Properties.Resources.Entity_SalesBonusPlan_MaxBonusAmount, this.spinMaxBonusAmount);
            this.layout.AddItem(Foxoft.Properties.Resources.Entity_SalesBonusPlan_ProcessCodes, this.txtProcessCodes);
            this.layout.AddItem("", this.chkIsActive);

            var tabbed = root.AddTabbedGroup();

            var tabTiers = tabbed.AddTabPage();
            tabTiers.Text = Foxoft.Properties.Resources.Form_SalesBonusPlanEdit_TiersGroup;
            tabTiers.AddItem("", this.lblTierHint);
            var tierBtnGroup = tabTiers.AddGroup();
            tierBtnGroup.GroupBordersVisible = false;
            tierBtnGroup.AddItem("", this.btnAddTier);
            tierBtnGroup.AddItem("", this.btnRemoveTier);
            tabTiers.AddItem("", this.gridTiers);

            var tabProducts = tabbed.AddTabPage();
            tabProducts.Text = Foxoft.Properties.Resources.Form_SalesBonusPlanEdit_ProductsGroup;
            var productBtnGroup = tabProducts.AddGroup();
            productBtnGroup.GroupBordersVisible = false;
            productBtnGroup.AddItem("", this.btnAddProduct);
            productBtnGroup.AddItem("", this.btnRemoveProduct);
            tabProducts.AddItem("", this.gridProducts);

            var tabCategories = tabbed.AddTabPage();
            tabCategories.Text = Foxoft.Properties.Resources.Form_SalesBonusPlanEdit_CategoriesGroup;
            var categoryBtnGroup = tabCategories.AddGroup();
            categoryBtnGroup.GroupBordersVisible = false;
            categoryBtnGroup.AddItem("", this.btnAddCategory);
            categoryBtnGroup.AddItem("", this.btnRemoveCategory);
            tabCategories.AddItem("", this.gridCategories);

            var btnGroup = root.AddGroup();
            btnGroup.GroupBordersVisible = false;
            btnGroup.AddItem("", this.btnSave);
            btnGroup.AddItem("", this.btnCancel);

            this.Controls.Add(this.layout);

            // FormSalesBonusPlanEdit
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(820, 820);
            this.Name = "FormSalesBonusPlanEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "";

            ((System.ComponentModel.ISupportInitialize)(this.layout)).EndInit();
            this.layout.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtPlanName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescription.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpCalcMethod.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpTriggerType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpTierMode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpPeriodType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinRate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinFixedAmount.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinTargetAmount.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinTargetMinAchievement.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinMinBaseAmount.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinMaxBonusAmount.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProcessCodes.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIsActive.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridTiers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewTiers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridProducts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewProducts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridCategories)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewCategories)).EndInit();
            this.ResumeLayout(false);
        }

        private static void ConfigureSpin(DevExpress.XtraEditors.SpinEdit spin, int decimals, decimal min, decimal max)
        {
            string format = "n" + decimals;
            spin.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            spin.Properties.DisplayFormat.FormatString = format;
            spin.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            spin.Properties.EditFormat.FormatString = format;
            spin.Properties.Mask.EditMask = format;
            spin.Properties.MinValue = min;
            spin.Properties.MaxValue = max;
            spin.Properties.Increment = decimals >= 4 ? 0.5m : 1m;
        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layout;
        private DevExpress.XtraEditors.TextEdit txtPlanName;
        private DevExpress.XtraEditors.TextEdit txtDescription;
        private DevExpress.XtraEditors.LookUpEdit lkpCalcMethod;
        private DevExpress.XtraEditors.LookUpEdit lkpTriggerType;
        private DevExpress.XtraEditors.LookUpEdit lkpTierMode;
        private DevExpress.XtraEditors.LookUpEdit lkpPeriodType;
        private DevExpress.XtraEditors.SpinEdit spinRate;
        private DevExpress.XtraEditors.SpinEdit spinFixedAmount;
        private DevExpress.XtraEditors.SpinEdit spinTargetAmount;
        private DevExpress.XtraEditors.SpinEdit spinTargetMinAchievement;
        private DevExpress.XtraEditors.SpinEdit spinMinBaseAmount;
        private DevExpress.XtraEditors.SpinEdit spinMaxBonusAmount;
        private DevExpress.XtraEditors.TextEdit txtProcessCodes;
        private DevExpress.XtraEditors.CheckEdit chkIsActive;
        private DevExpress.XtraEditors.LabelControl lblTierHint;
        private MyGridControl gridTiers;
        private MyGridView viewTiers;
        private DevExpress.XtraGrid.Columns.GridColumn colTierFrom;
        private DevExpress.XtraGrid.Columns.GridColumn colTierTo;
        private DevExpress.XtraGrid.Columns.GridColumn colTierRate;
        private DevExpress.XtraGrid.Columns.GridColumn colTierFixed;
        private DevExpress.XtraEditors.SimpleButton btnAddTier;
        private DevExpress.XtraEditors.SimpleButton btnRemoveTier;
        private MyGridControl gridProducts;
        private MyGridView viewProducts;
        private DevExpress.XtraGrid.Columns.GridColumn colProductCode;
        private DevExpress.XtraGrid.Columns.GridColumn colProductDesc;
        private DevExpress.XtraGrid.Columns.GridColumn colProductRate;
        private DevExpress.XtraEditors.SimpleButton btnAddProduct;
        private DevExpress.XtraEditors.SimpleButton btnRemoveProduct;
        private MyGridControl gridCategories;
        private MyGridView viewCategories;
        private DevExpress.XtraGrid.Columns.GridColumn colCategoryCode;
        private DevExpress.XtraGrid.Columns.GridColumn colCategoryDesc;
        private DevExpress.XtraGrid.Columns.GridColumn colCategoryRate;
        private DevExpress.XtraEditors.SimpleButton btnAddCategory;
        private DevExpress.XtraEditors.SimpleButton btnRemoveCategory;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
    }
}
