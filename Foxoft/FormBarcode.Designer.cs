using Foxoft.Models;

namespace Foxoft
{
    partial class FormProductBarcode
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
            myGridControl1 = new MyGridControl();
            bindingSourceProductBarcode = new System.Windows.Forms.BindingSource(components);
            GV_ProductBarcode = new DevExpress.XtraGrid.Views.Grid.GridView();
            colBarcode = new DevExpress.XtraGrid.Columns.GridColumn();
            RepoBtnEdit_Barcode = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            colBarcodeTypeCode = new DevExpress.XtraGrid.Columns.GridColumn();
            RepoBtnEdit_BarcodeType = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            colProductCode = new DevExpress.XtraGrid.Columns.GridColumn();
            RepoBtnEdit_ProductCode = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            colCreatedDate = new DevExpress.XtraGrid.Columns.GridColumn();
            colCreatedUserName = new DevExpress.XtraGrid.Columns.GridColumn();
            colLastUpdatedDate = new DevExpress.XtraGrid.Columns.GridColumn();
            colLastUpdatedUserName = new DevExpress.XtraGrid.Columns.GridColumn();
            colId = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)myGridControl1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bindingSourceProductBarcode).BeginInit();
            ((System.ComponentModel.ISupportInitialize)GV_ProductBarcode).BeginInit();
            ((System.ComponentModel.ISupportInitialize)RepoBtnEdit_Barcode).BeginInit();
            ((System.ComponentModel.ISupportInitialize)RepoBtnEdit_BarcodeType).BeginInit();
            ((System.ComponentModel.ISupportInitialize)RepoBtnEdit_ProductCode).BeginInit();
            SuspendLayout();
            // 
            // myGridControl1
            // 
            myGridControl1.DataSource = bindingSourceProductBarcode;
            myGridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            myGridControl1.Location = new System.Drawing.Point(0, 0);
            myGridControl1.MainView = GV_ProductBarcode;
            myGridControl1.Name = "myGridControl1";
            myGridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] { RepoBtnEdit_BarcodeType, RepoBtnEdit_Barcode, RepoBtnEdit_ProductCode });
            myGridControl1.Size = new System.Drawing.Size(800, 450);
            myGridControl1.TabIndex = 0;
            myGridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { GV_ProductBarcode });
            // 
            // bindingSourceProductBarcode
            // 
            bindingSourceProductBarcode.DataSource = typeof(TrProductBarcode);
            // 
            // GV_ProductBarcode
            // 
            GV_ProductBarcode.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { colBarcode, colBarcodeTypeCode, colProductCode, colCreatedDate, colCreatedUserName, colLastUpdatedDate, colLastUpdatedUserName, colId });
            GV_ProductBarcode.GridControl = myGridControl1;
            GV_ProductBarcode.Name = "GV_ProductBarcode";
            GV_ProductBarcode.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
            GV_ProductBarcode.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            GV_ProductBarcode.OptionsView.ShowGroupPanel = false;
            GV_ProductBarcode.InitNewRow += GV_ProductBarcode_InitNewRow;
            GV_ProductBarcode.RowDeleted += GV_ProductBarcode_RowDeleted;
            GV_ProductBarcode.RowUpdated += GV_ProductBarcode_RowUpdated;
            // 
            // colBarcode
            // 
            colBarcode.ColumnEdit = RepoBtnEdit_Barcode;
            colBarcode.FieldName = "Barcode";
            colBarcode.Name = "colBarcode";
            colBarcode.Visible = true;
            colBarcode.VisibleIndex = 0;
            // 
            // RepoBtnEdit_Barcode
            // 
            RepoBtnEdit_Barcode.AutoHeight = false;
            RepoBtnEdit_Barcode.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Plus) });
            RepoBtnEdit_Barcode.Name = "RepoBtnEdit_Barcode";
            RepoBtnEdit_Barcode.ButtonPressed += RepoBtnEdit_Barcode_ButtonPressed;
            // 
            // colBarcodeTypeCode
            // 
            colBarcodeTypeCode.ColumnEdit = RepoBtnEdit_BarcodeType;
            colBarcodeTypeCode.FieldName = "BarcodeTypeCode";
            colBarcodeTypeCode.Name = "colBarcodeTypeCode";
            colBarcodeTypeCode.Visible = true;
            colBarcodeTypeCode.VisibleIndex = 1;
            // 
            // RepoBtnEdit_BarcodeType
            // 
            RepoBtnEdit_BarcodeType.AutoHeight = false;
            RepoBtnEdit_BarcodeType.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton() });
            RepoBtnEdit_BarcodeType.Name = "RepoBtnEdit_BarcodeType";
            RepoBtnEdit_BarcodeType.ButtonPressed += RepoBtnEdit_BarcodeType_ButtonPressed;
            // 
            // colProductCode
            // 
            colProductCode.ColumnEdit = RepoBtnEdit_ProductCode;
            colProductCode.FieldName = "ProductCode";
            colProductCode.Name = "colProductCode";
            colProductCode.Visible = true;
            colProductCode.VisibleIndex = 2;
            // 
            // RepoBtnEdit_ProductCode
            // 
            RepoBtnEdit_ProductCode.AutoHeight = false;
            RepoBtnEdit_ProductCode.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton() });
            RepoBtnEdit_ProductCode.Name = "RepoBtnEdit_ProductCode";
            RepoBtnEdit_ProductCode.ButtonPressed += RepoBtnEdit_ProductCode_ButtonPressed;
            // 
            // colCreatedDate
            // 
            colCreatedDate.FieldName = "CreatedDate";
            colCreatedDate.Name = "colCreatedDate";
            // 
            // colCreatedUserName
            // 
            colCreatedUserName.FieldName = "CreatedUserName";
            colCreatedUserName.Name = "colCreatedUserName";
            // 
            // colLastUpdatedDate
            // 
            colLastUpdatedDate.FieldName = "LastUpdatedDate";
            colLastUpdatedDate.Name = "colLastUpdatedDate";
            // 
            // colLastUpdatedUserName
            // 
            colLastUpdatedUserName.FieldName = "LastUpdatedUserName";
            colLastUpdatedUserName.Name = "colLastUpdatedUserName";
            // 
            // colId
            // 
            colId.FieldName = "Id";
            colId.Name = "colId";
            // 
            // FormProductBarcode
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(800, 450);
            Controls.Add(myGridControl1);
            Name = "FormProductBarcode";
            Text = "FormBarcode";
            ((System.ComponentModel.ISupportInitialize)myGridControl1).EndInit();
            ((System.ComponentModel.ISupportInitialize)bindingSourceProductBarcode).EndInit();
            ((System.ComponentModel.ISupportInitialize)GV_ProductBarcode).EndInit();
            ((System.ComponentModel.ISupportInitialize)RepoBtnEdit_Barcode).EndInit();
            ((System.ComponentModel.ISupportInitialize)RepoBtnEdit_BarcodeType).EndInit();
            ((System.ComponentModel.ISupportInitialize)RepoBtnEdit_ProductCode).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private MyGridControl myGridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView GV_ProductBarcode;
        private System.Windows.Forms.BindingSource bindingSourceProductBarcode;
        private DevExpress.XtraGrid.Columns.GridColumn colBarcode;
        private DevExpress.XtraGrid.Columns.GridColumn colBarcodeTypeCode;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryItemButtonEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn colProductCode;
        private DevExpress.XtraGrid.Columns.GridColumn colCreatedDate;
        private DevExpress.XtraGrid.Columns.GridColumn colCreatedUserName;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit RepoBtnEdit_BarcodeType;
        private DevExpress.XtraGrid.Columns.GridColumn colLastUpdatedDate;
        private DevExpress.XtraGrid.Columns.GridColumn colLastUpdatedUserName;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit RepoBtnEdit_Barcode;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit RepoBtnEdit_ProductCode;
        private DevExpress.XtraGrid.Columns.GridColumn colId;
    }
}