using DevExpress.Utils;
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
using System.Drawing;
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
        //public AdornerElement[] Badges { get { return new AdornerElement[] { badge1, badge2 }; } }

        DcReport report = new DcReport();
        string qry = "select 0 Nothing";
        EfMethods efMethods = new EfMethods();
        AdoMethods adoMethods = new AdoMethods();

        RepositoryItemHyperLinkEdit hyperLinkEdit = new RepositoryItemHyperLinkEdit();

        public FormReportGrid()
        {
            InitializeComponent();

            hyperLinkEdit.OpenLink += repoHLE_InvoiceNumber_OpenLink;
            GridColumn column = gV_Report.Columns["InvoiceNumber"];
            if (!object.ReferenceEquals(column, null)) column.ColumnEdit = hyperLinkEdit;

            adornerUIManager1 = new AdornerUIManager(components);
            badge1 = new Badge();
            badge2 = new Badge();
            adornerUIManager1.Elements.Add(badge1);
            adornerUIManager1.Elements.Add(badge2);
            badge1.TargetElement = barButtonItem1;
            badge2.TargetElement = ribbonPage1;
        }

        public FormReportGrid(string qry, DcReport report)
        : this()
        {
            this.qry = qry;
            this.report = report;
            this.Text = report.ReportName;

            LoadData();
            LoadLayout();
        }

        private void LoadData()
        {
            DataTable dt = adoMethods.SqlGetDt(qry);
            gC_Report.DataSource = dt;
        }

        private void bBI_LayoutSave_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (report.ReportId > 0)
            {
                Stream str = new MemoryStream();
                gV_Report.SaveLayoutToStream(str);
                str.Seek(0, SeekOrigin.Begin);
                StreamReader reader = new StreamReader(str);
                string layoutTxt = reader.ReadToEnd();
                efMethods.UpdateReportLayout(report.ReportId, layoutTxt);
            }
        }

        private void bBI_LayoutLoad_ItemClick(object sender, ItemClickEventArgs e)
        {
            LoadLayout();
        }

        private void LoadLayout()
        {
            if (report.ReportId > 0)
            {
                DcReport dcReport = efMethods.SelectReport(report.ReportId);
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

        private void bBI_DesignClear_ItemClick(object sender, ItemClickEventArgs e)
        {
            gV_Report.PopulateColumns();
            //foreach (GridColumn item in gV_Report.Columns)
            //{
            //    gV_Report.Columns.Remove(item);
            //}

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
                if (!String.IsNullOrEmpty(obj.ToString()))
                {
                    Guid invoiceHeaderId = Guid.Parse(obj.ToString());
                    TrInvoiceHeader trInvoiceHeader = efMethods.SelectInvoiceHeader(invoiceHeaderId);

                    FormInvoice formInvoice = new FormInvoice(trInvoiceHeader.ProcessCode, 1, 2, invoiceHeaderId);
                    FormERP formERP = Application.OpenForms["FormERP"] as FormERP;
                    formInvoice.MdiParent = formERP;
                    formInvoice.WindowState = FormWindowState.Maximized;
                    formInvoice.Show();
                    formERP.parentRibbonControl.SelectedPage = formERP.parentRibbonControl.MergedPages[0];
                }
            }
        }

        private void gV_Report_RowStyle(object sender, RowStyleEventArgs e)
        {
            GridView view = sender as GridView;

            if (e.RowHandle >= 0)
            {
                object isReturn = view.GetRowCellValue(e.RowHandle, view.Columns["IsReturn"]);
                isReturn ??= view.GetRowCellValue(e.RowHandle, view.Columns["Geri Qaytarma"]);

                if (!object.ReferenceEquals(isReturn, null))
                {
                    bool value = (bool)isReturn;

                    if (value)
                        e.Appearance.BackColor = Color.MistyRose;
                }
            }
        }

        private void bBI_ExportXlsx_ItemClick(object sender, ItemClickEventArgs e)
        {
            gC_Report.ExportToXlsx($@"C:\Users\Public\Desktop\{report.ReportName}.xlsx");
        }
    }
}
