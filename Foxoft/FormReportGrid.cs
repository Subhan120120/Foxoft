﻿using DevExpress.Utils;
using DevExpress.Utils.VisualEffects;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using Foxoft.Models;
using System;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Foxoft
{
    public partial class FormReportGrid : RibbonForm
    {
        Badge badge1;
        Badge badge2;
        AdornerUIManager adornerUIManager1;
        int reportId;
        EfMethods efMethods = new EfMethods();
        AdoMethods adoMethods = new AdoMethods();

        RepositoryItemHyperLinkEdit hyperLinkEdit = new RepositoryItemHyperLinkEdit();

        public FormReportGrid(string qry)
        {
            InitializeComponent();
            
            DataTable dt = adoMethods.SqlGetDt(qry);
            gridControl1.DataSource = dt;

            GridColumn column = gV_Report.Columns["InvoiceNumber"];
            column.ColumnEdit = hyperLinkEdit;
            hyperLinkEdit.OpenLink += repoHLE_InvoiceNumber_OpenLink;

            adornerUIManager1 = new AdornerUIManager(components);
            badge1 = new Badge();
            badge2 = new Badge();
            adornerUIManager1.Elements.Add(badge1);
            adornerUIManager1.Elements.Add(badge2);
            badge1.TargetElement = barButtonItem1;
            badge2.TargetElement = ribbonPage1;
        }

        public FormReportGrid(string qry, int reportId)
        : this(qry)
        {
            this.reportId = reportId;

            LoadLayout();
        }


        public AdornerElement[] Badges
        {
            get
            {
                return new AdornerElement[] { badge1, badge2 };
            }
        }

        private void bBI_LayoutSave_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (reportId > 0)
            {
                Stream str = new MemoryStream();
                gV_Report.SaveLayoutToStream(str);
                str.Seek(0, SeekOrigin.Begin);
                StreamReader reader = new StreamReader(str);
                string layoutTxt = reader.ReadToEnd();
                efMethods.UpdateReportLayout(reportId, layoutTxt);
            }
        }

        private void bBI_LayoutLoad_ItemClick(object sender, ItemClickEventArgs e)
        {
            LoadLayout();
        }

        private void LoadLayout()
        {
            if (reportId > 0)
            {
                DcReport dcReport = efMethods.SelectReport(reportId);
                if (!string.IsNullOrEmpty(dcReport.ReportLayout))
                {
                    byte[] byteArray = Encoding.Unicode.GetBytes(dcReport.ReportLayout);
                    MemoryStream stream = new MemoryStream(byteArray);
                    gV_Report.RestoreLayoutFromStream(stream);
                }
            }
        }

        private void bBI_gridOptions_ItemClick(object sender, ItemClickEventArgs e)
        {
            Stream str = new MemoryStream();
            OptionsLayoutGrid option = new OptionsLayoutGrid() { StoreAllOptions = true, StoreAppearance = true };
            gV_Report.SaveLayoutToStream(str, option);

            using (FormReportGridOptions formGridOptions = new FormReportGridOptions(str))
            {
                if (formGridOptions.ShowDialog(this) == DialogResult.OK)
                {
                    formGridOptions.stream.Seek(0, SeekOrigin.Begin);
                    gV_Report.RestoreLayoutFromStream(formGridOptions.stream, option);
                }
            }
        }

        private void barButtonItem3_ItemClick(object sender, ItemClickEventArgs e)
        {
            //MyGridControlDesigner myDesigner = new MyGridControlDesigner(gridControl1);
            //myDesigner.LevelDesignerVisible = false;
            //myDesigner.Selector.AllowDesignerButton = false;
            //myDesigner.ShowDesigner(null, null);
        }

        GridColumn prevColumn = null; // Disable the Immediate Edit Cell
        int prevRow = -1;
        private void gV_Report_ShowingEditor(object sender, CancelEventArgs e)
        {
            GridView view = sender as GridView;
            if (prevColumn != view.FocusedColumn || prevRow != view.FocusedRowHandle)
                e.Cancel = true;
            prevColumn = view.FocusedColumn;
            prevRow = view.FocusedRowHandle;
        }



        private void repoHLE_InvoiceNumber_OpenLink(object sender, OpenLinkEventArgs e)
        {
            object obj = gV_Report.GetFocusedRowCellValue("InvoiceHeaderId");

            if (!object.ReferenceEquals(obj, null))
            {
                Guid invoiceHeaderId = Guid.Parse(obj.ToString());
                TrInvoiceHeader trInvoiceHeader = efMethods.SelectInvoiceHeader(invoiceHeaderId);

                this.Close();

                FormInvoice formInvoice = new FormInvoice(trInvoiceHeader.ProcessCode, 1, 2, invoiceHeaderId);
                FormERP formERP = Application.OpenForms["FormERP"] as FormERP;
                formInvoice.MdiParent = formERP;
                formInvoice.WindowState = FormWindowState.Maximized;
                formInvoice.Show();
                formERP.parentRibbonControl.SelectedPage = formERP.parentRibbonControl.MergedPages[0];
            }
        }
    }
}
