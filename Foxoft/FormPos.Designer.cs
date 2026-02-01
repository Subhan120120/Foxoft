using DevExpress.XtraBars;
using DevExpress.XtraBars.Navigation;
using DevExpress.XtraBars.ToolbarForm;
using Foxoft.Properties;
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
            components = new Container();
            toolbarFormControl1 = new ToolbarFormControl();
            toolbarFormManager1 = new ToolbarFormManager(components);
            barDockControlTop = new BarDockControl();
            barDockControlBottom = new BarDockControl();
            barDockControlLeft = new BarDockControl();
            barDockControlRight = new BarDockControl();
            bCI_invoice = new BarCheckItem();
            bCI_return = new BarCheckItem();
            bCI_expenses = new BarCheckItem();
            navPage_Return = new NavigationPage();
            navPage_Sale = new NavigationPage();
            navigationFrame1 = new NavigationFrame();
            navPage_Expenses = new NavigationPage();
            ((ISupportInitialize)toolbarFormControl1).BeginInit();
            ((ISupportInitialize)toolbarFormManager1).BeginInit();
            ((ISupportInitialize)navigationFrame1).BeginInit();
            navigationFrame1.SuspendLayout();
            SuspendLayout();
            // 
            // toolbarFormControl1
            // 
            toolbarFormControl1.Location = new Point(0, 0);
            toolbarFormControl1.Manager = toolbarFormManager1;
            toolbarFormControl1.Name = "toolbarFormControl1";
            toolbarFormControl1.Size = new Size(1242, 31);
            toolbarFormControl1.TabIndex = 1;
            toolbarFormControl1.TabStop = false;
            toolbarFormControl1.TitleItemLinks.Add(bCI_invoice);
            toolbarFormControl1.TitleItemLinks.Add(bCI_return);
            toolbarFormControl1.TitleItemLinks.Add(bCI_expenses);
            toolbarFormControl1.ToolbarForm = this;
            // 
            // toolbarFormManager1
            // 
            toolbarFormManager1.DockControls.Add(barDockControlTop);
            toolbarFormManager1.DockControls.Add(barDockControlBottom);
            toolbarFormManager1.DockControls.Add(barDockControlLeft);
            toolbarFormManager1.DockControls.Add(barDockControlRight);
            toolbarFormManager1.Form = this;
            toolbarFormManager1.Items.AddRange(new BarItem[] { bCI_invoice, bCI_return, bCI_expenses });
            toolbarFormManager1.MaxItemId = 25;
            // 
            // barDockControlTop
            // 
            barDockControlTop.CausesValidation = false;
            barDockControlTop.Dock = DockStyle.Top;
            barDockControlTop.Location = new Point(0, 31);
            barDockControlTop.Manager = toolbarFormManager1;
            barDockControlTop.Size = new Size(1242, 0);
            // 
            // barDockControlBottom
            // 
            barDockControlBottom.CausesValidation = false;
            barDockControlBottom.Dock = DockStyle.Bottom;
            barDockControlBottom.Location = new Point(0, 649);
            barDockControlBottom.Manager = toolbarFormManager1;
            barDockControlBottom.Size = new Size(1242, 0);
            // 
            // barDockControlLeft
            // 
            barDockControlLeft.CausesValidation = false;
            barDockControlLeft.Dock = DockStyle.Left;
            barDockControlLeft.Location = new Point(0, 31);
            barDockControlLeft.Manager = toolbarFormManager1;
            barDockControlLeft.Size = new Size(0, 618);
            // 
            // barDockControlRight
            // 
            barDockControlRight.CausesValidation = false;
            barDockControlRight.Dock = DockStyle.Right;
            barDockControlRight.Location = new Point(1242, 31);
            barDockControlRight.Manager = toolbarFormManager1;
            barDockControlRight.Size = new Size(0, 618);
            // 
            // bCI_invoice
            // 
            bCI_invoice.BindableChecked = true;
            bCI_invoice.Caption = Resources.Form_POS_Button_Sale;
            bCI_invoice.Checked = true;
            bCI_invoice.Id = 20;
            bCI_invoice.Name = "bCI_invoice";
            bCI_invoice.CheckedChanged += bCI_CheckedChanged;
            bCI_invoice.ItemClick += bCI_invoice_ItemClick;
            // 
            // bCI_return
            // 
            bCI_return.Caption = Resources.Form_POS_Button_Return;
            bCI_return.Id = 22;
            bCI_return.Name = "bCI_return";
            bCI_return.CheckedChanged += bCI_CheckedChanged;
            bCI_return.ItemClick += bCI_return_ItemClick;
            // 
            // bCI_expenses
            // 
            bCI_expenses.Caption = Resources.Form_POS_Button_Expenses;
            bCI_expenses.Id = 24;
            bCI_expenses.Name = "bCI_expenses";
            bCI_expenses.CheckedChanged += bCI_CheckedChanged;
            bCI_expenses.ItemClick += bCI_expenses_ItemClick;
            // 
            // navPage_Return
            // 
            navPage_Return.Caption = Resources.Form_POS_Page_Return;
            navPage_Return.ControlName = "GeriQaytarma";
            navPage_Return.Name = "navPage_Return";
            navPage_Return.Size = new Size(1242, 618);
            // 
            // navPage_Sale
            // 
            navPage_Sale.Caption = Resources.Form_POS_Page_Sale;
            navPage_Sale.ControlName = "Satış";
            navPage_Sale.Name = "navPage_Sale";
            navPage_Sale.Size = new Size(1242, 618);
            // 
            // navigationFrame1
            // 
            navigationFrame1.Controls.Add(navPage_Sale);
            navigationFrame1.Controls.Add(navPage_Return);
            navigationFrame1.Controls.Add(navPage_Expenses);
            navigationFrame1.Dock = DockStyle.Fill;
            navigationFrame1.Location = new Point(0, 31);
            navigationFrame1.Name = "navigationFrame1";
            navigationFrame1.Pages.AddRange(new NavigationPageBase[] { navPage_Sale, navPage_Return, navPage_Expenses });
            navigationFrame1.SelectedPage = navPage_Sale;
            navigationFrame1.Size = new Size(1242, 618);
            navigationFrame1.TabIndex = 0;
            navigationFrame1.Text = "navigationFrame1";
            navigationFrame1.TransitionAnimationProperties.FrameInterval = 3000;
            // 
            // navPage_Expenses
            // 
            navPage_Expenses.Caption = Resources.Form_POS_Page_Expenses;
            navPage_Expenses.Name = "navPage_Expenses";
            navPage_Expenses.Size = new Size(1242, 618);
            // 
            // FormPOS
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1242, 649);
            Controls.Add(navigationFrame1);
            Controls.Add(barDockControlLeft);
            Controls.Add(barDockControlRight);
            Controls.Add(barDockControlBottom);
            Controls.Add(barDockControlTop);
            Controls.Add(toolbarFormControl1);
            KeyPreview = true;
            Name = "FormPOS";
            Text = Resources.Form_POS_Caption;
            ToolbarFormControl = toolbarFormControl1;
            WindowState = FormWindowState.Maximized;
            Load += FormPOS_Load;
            ((ISupportInitialize)toolbarFormControl1).EndInit();
            ((ISupportInitialize)toolbarFormManager1).EndInit();
            ((ISupportInitialize)navigationFrame1).EndInit();
            navigationFrame1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();

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
