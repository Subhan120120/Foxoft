
using DevExpress.XtraBars;
using DevExpress.XtraBars.Navigation;
using DevExpress.XtraBars.ToolbarForm;
using System.ComponentModel;

namespace Foxoft
{
    partial class FormPOS
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            this.components = new System.ComponentModel.Container();
            this.toolbarFormControl1 = new DevExpress.XtraBars.ToolbarForm.ToolbarFormControl();
            this.toolbarFormManager1 = new DevExpress.XtraBars.ToolbarForm.ToolbarFormManager(this.components);
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.bCI_invoice = new DevExpress.XtraBars.BarCheckItem();
            this.bCI_return = new DevExpress.XtraBars.BarCheckItem();
            this.bCI_expenses = new DevExpress.XtraBars.BarCheckItem();
            this.navPage_Return = new DevExpress.XtraBars.Navigation.NavigationPage();
            this.navPage_Sale = new DevExpress.XtraBars.Navigation.NavigationPage();
            this.navigationFrame1 = new DevExpress.XtraBars.Navigation.NavigationFrame();
            this.navPage_Expenses = new DevExpress.XtraBars.Navigation.NavigationPage();
            ((System.ComponentModel.ISupportInitialize)(this.toolbarFormControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.toolbarFormManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.navigationFrame1)).BeginInit();
            this.navigationFrame1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolbarFormControl1
            // 
            this.toolbarFormControl1.Location = new System.Drawing.Point(0, 0);
            this.toolbarFormControl1.Manager = this.toolbarFormManager1;
            this.toolbarFormControl1.Name = "toolbarFormControl1";
            this.toolbarFormControl1.Size = new System.Drawing.Size(1242, 31);
            this.toolbarFormControl1.TabIndex = 1;
            this.toolbarFormControl1.TabStop = false;
            this.toolbarFormControl1.TitleItemLinks.Add(this.bCI_invoice);
            this.toolbarFormControl1.TitleItemLinks.Add(this.bCI_return);
            this.toolbarFormControl1.TitleItemLinks.Add(this.bCI_expenses);
            this.toolbarFormControl1.ToolbarForm = this;
            // 
            // toolbarFormManager1
            // 
            this.toolbarFormManager1.DockControls.Add(this.barDockControlTop);
            this.toolbarFormManager1.DockControls.Add(this.barDockControlBottom);
            this.toolbarFormManager1.DockControls.Add(this.barDockControlLeft);
            this.toolbarFormManager1.DockControls.Add(this.barDockControlRight);
            this.toolbarFormManager1.Form = this;
            this.toolbarFormManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.bCI_invoice,
            this.bCI_return,
            this.bCI_expenses});
            this.toolbarFormManager1.MaxItemId = 25;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 31);
            this.barDockControlTop.Manager = this.toolbarFormManager1;
            this.barDockControlTop.Size = new System.Drawing.Size(1242, 0);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 649);
            this.barDockControlBottom.Manager = this.toolbarFormManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(1242, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 31);
            this.barDockControlLeft.Manager = this.toolbarFormManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 618);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1242, 31);
            this.barDockControlRight.Manager = this.toolbarFormManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 618);
            // 
            // bCI_invoice
            // 
            this.bCI_invoice.BindableChecked = true;
            this.bCI_invoice.Caption = "Satış";
            this.bCI_invoice.Checked = true;
            this.bCI_invoice.Id = 20;
            this.bCI_invoice.Name = "bCI_invoice";
            this.bCI_invoice.CheckedChanged += new DevExpress.XtraBars.ItemClickEventHandler(this.bCI_CheckedChanged);
            this.bCI_invoice.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bCI_invoice_ItemClick);
            // 
            // bCI_return
            // 
            this.bCI_return.Caption = "Geri Qaytarma";
            this.bCI_return.Id = 22;
            this.bCI_return.Name = "bCI_return";
            this.bCI_return.CheckedChanged += new DevExpress.XtraBars.ItemClickEventHandler(this.bCI_CheckedChanged);
            this.bCI_return.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bCI_return_ItemClick);
            // 
            // bCI_expenses
            // 
            this.bCI_expenses.Caption = "Xərclər";
            this.bCI_expenses.Id = 24;
            this.bCI_expenses.Name = "bCI_expenses";
            this.bCI_expenses.CheckedChanged += new DevExpress.XtraBars.ItemClickEventHandler(this.bCI_CheckedChanged);
            this.bCI_expenses.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bCI_expenses_ItemClick);
            // 
            // navPage_Return
            // 
            this.navPage_Return.ControlName = "GeriQaytarma";
            this.navPage_Return.Name = "navPage_Return";
            this.navPage_Return.Size = new System.Drawing.Size(1242, 618);
            // 
            // navPage_Sale
            // 
            this.navPage_Sale.ControlName = "Satış";
            this.navPage_Sale.Name = "navPage_Sale";
            this.navPage_Sale.Size = new System.Drawing.Size(1242, 618);
            // 
            // navigationFrame1
            // 
            this.navigationFrame1.Controls.Add(this.navPage_Sale);
            this.navigationFrame1.Controls.Add(this.navPage_Return);
            this.navigationFrame1.Controls.Add(this.navPage_Expenses);
            this.navigationFrame1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.navigationFrame1.Location = new System.Drawing.Point(0, 31);
            this.navigationFrame1.Name = "navigationFrame1";
            this.navigationFrame1.Pages.AddRange(new DevExpress.XtraBars.Navigation.NavigationPageBase[] {
            this.navPage_Sale,
            this.navPage_Return,
            this.navPage_Expenses});
            this.navigationFrame1.SelectedPage = this.navPage_Sale;
            this.navigationFrame1.Size = new System.Drawing.Size(1242, 618);
            this.navigationFrame1.TabIndex = 0;
            this.navigationFrame1.Text = "navigationFrame1";
            this.navigationFrame1.TransitionAnimationProperties.FrameInterval = 3000;
            // 
            // navPage_Expenses
            // 
            this.navPage_Expenses.Name = "navPage_Expenses";
            this.navPage_Expenses.Size = new System.Drawing.Size(1242, 618);
            // 
            // FormPOS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1242, 649);
            this.Controls.Add(this.navigationFrame1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Controls.Add(this.toolbarFormControl1);
            this.Name = "FormPOS";
            this.ToolbarFormControl = this.toolbarFormControl1;
            this.Load += new System.EventHandler(this.FormPOS_Load);
            ((System.ComponentModel.ISupportInitialize)(this.toolbarFormControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.toolbarFormManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.navigationFrame1)).EndInit();
            this.navigationFrame1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private ToolbarFormControl toolbarFormControl1;
        private ToolbarFormManager toolbarFormManager1;
        private NavigationFrame navigationFrame1;
        private NavigationPage navPage_Sale;
        private NavigationPage navPage_Return;
        private BarDockControl barDockControlTop;
        private BarDockControl barDockControlBottom;
        private BarDockControl barDockControlLeft;
        private BarDockControl barDockControlRight;
        //private UcSale ucSale;
        //private UcReturn ucReturn;
        private BarCheckItem bCI_invoice;
        private BarCheckItem bCI_return;
        private BarCheckItem bCI_expenses;
        private NavigationPage navPage_Expenses;
    }
}