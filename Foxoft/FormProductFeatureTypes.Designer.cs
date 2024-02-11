
using Foxoft.Models;

namespace Foxoft
{
    partial class FormProductFeatureTypes
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
            buttonEdit1 = new DevExpress.XtraEditors.ButtonEdit();
            gC_ProductFeatureTypes = new DevExpress.XtraGrid.GridControl();
            gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            ProductFeatureTypesBindingSource = new System.Windows.Forms.BindingSource(components);
            ((System.ComponentModel.ISupportInitialize)buttonEdit1.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gC_ProductFeatureTypes).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ProductFeatureTypesBindingSource).BeginInit();
            SuspendLayout();
            // 
            // ProductFeaturesBindingSource
            // 
            ProductFeatureTypesBindingSource.DataSource = typeof(TrHierarchyFeatureType);
            // 
            // buttonEdit1
            // 
            buttonEdit1.Location = new System.Drawing.Point(12, 12);
            buttonEdit1.Name = "buttonEdit1";
            buttonEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton() });
            buttonEdit1.Size = new System.Drawing.Size(317, 20);
            buttonEdit1.TabIndex = 0;
            buttonEdit1.ButtonPressed += buttonEdit1_ButtonPressed;
            // 
            // gC_ProductFeatures
            // 
            gC_ProductFeatureTypes.DataSource = ProductFeatureTypesBindingSource;
            gC_ProductFeatureTypes.Location = new System.Drawing.Point(12, 38);
            gC_ProductFeatureTypes.MainView = gridView1;
            gC_ProductFeatureTypes.Name = "gC_ProductFeatures";
            gC_ProductFeatureTypes.Size = new System.Drawing.Size(750, 356);
            gC_ProductFeatureTypes.TabIndex = 1;
            gC_ProductFeatureTypes.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gridView1 });
            // 
            // gridView1
            // 
            gridView1.GridControl = gC_ProductFeatureTypes;
            gridView1.Name = "gridView1";
            // 
            // FormProductFeatures
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(800, 450);
            Controls.Add(gC_ProductFeatureTypes);
            Controls.Add(buttonEdit1);
            Name = "FormProductFeatures";
            Text = "Məhsul Özəllikləri";
            ((System.ComponentModel.ISupportInitialize)buttonEdit1.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)gC_ProductFeatureTypes).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)ProductFeatureTypesBindingSource).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraEditors.ButtonEdit buttonEdit1;
        private DevExpress.XtraGrid.GridControl gC_ProductFeatureTypes;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.BindingSource ProductFeatureTypesBindingSource;
    }
}