
#region usings
using DevExpress.Data;
using DevExpress.Utils;
using DevExpress.Utils.Design;
using DevExpress.Utils.Menu;
using DevExpress.Utils.VisualEffects;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Localization;
using DevExpress.XtraGrid.Menu;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraPrinting;
using DevExpress.XtraReports.Design;
using DevExpress.XtraReports.UI;
using DevExpress.XtraReports.UserDesigner;
using DevExpress.XtraReports.UserDesigner.Native;
using Foxoft.AppCode;
using Foxoft.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
#endregion

namespace Foxoft
{
    public partial class FormReportGrid : RibbonForm
    {
        Badge badge1;
        Badge badge2;
        AdornerUIManager adornerUIManager1;

        //public AdornerElement[] Badges { get { return new AdornerElement[] { badge1, badge2 }; } }

        EfMethods efMethods = new();
        AdoMethods adoMethods = new();
        CustomMethods cM = new();
        DcReport dcReport = new();
        SqlParameter[] sqlParameters;

        string qry = "select 0 Nothing";
        string imageFolder;

        RepositoryItemPictureEdit riPictureEdit = new();
        GridColumn colImage = new();

        public FormReportGrid()
        {
            InitializeComponent();

            SettingStore settingStore = efMethods.SelectSettingStore(Authorization.StoreCode);
            if (CustomExtensions.DirectoryExist(settingStore.ImageFolder))
                imageFolder = settingStore.ImageFolder;

            GridLocalizer.Active = new MyGridLocalizer();

            adornerUIManager1 = new AdornerUIManager(components);
            badge1 = new Badge();
            badge2 = new Badge();
            adornerUIManager1.Elements.Add(badge1);
            adornerUIManager1.Elements.Add(badge2);
            //badge1.TargetElement = barButtonItem1;
            badge2.TargetElement = ribbonPage1;
        }

        public FormReportGrid(string query, string filter, DcReport dcReport)
        : this()
        {
            query = cM.AddTop(query, int.MaxValue);

            string qryMaster = "Select * from ( " + query + " \n) as master";

            if (!string.IsNullOrEmpty(filter))
                qryMaster = qryMaster + " where " + filter;

            query = qryMaster + " order by RowNumber";

            qry = cM.AddFilters(query, dcReport);
            sqlParameters = cM.AddParameters(dcReport);

            this.dcReport = dcReport;
            Text = dcReport.ReportName;

            LoadData();
            HyperLinkColumns();
            LoadLayout();
        }

        public FormReportGrid(string qry, string filter, DcReport dcReport, string activeFilterStr)
           : this(qry, filter, dcReport)
        {
            gV_Report.ActiveFilterString = activeFilterStr;
        }

        Dictionary<string, Image> imageCache = new(StringComparer.OrdinalIgnoreCase);
        private void gV_Report_CustomUnboundColumnData(object sender, CustomColumnDataEventArgs e)
        {
            if (e.Column == colImage && e.IsGetData)
            {
                GridView gV = sender as GridView;
                int rowInd = gV.GetRowHandle(e.ListSourceRowIndex);
                string fileName = gV.GetRowCellValue(rowInd, "ProductCode") as string ?? string.Empty;
                fileName += ".jpg";
                string path = imageFolder + @"\" + fileName;
                if (!imageCache.ContainsKey(path))
                {
                    Image img = GetImage(path);
                    imageCache.Add(path, img);
                }
                e.Value = imageCache[path];
            }
        }

        Image GetImage(string path)
        {
            Image img = null;

            try
            {
                if (File.Exists(path))
                    using (Stream stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                        img = Image.FromStream(stream);
            }
            catch (Exception)
            {
            }

            return img;
        }

        public class MyGridLocalizer : GridLocalizer
        {
            public override string GetLocalizedString(GridStringId id)
            {
                if (id == GridStringId.MenuFooterMaxFormat)
                    return "{0}";
                if (id == GridStringId.MenuFooterMinFormat)
                    return "{0}";
                if (id == GridStringId.MenuFooterSumFormat)
                    return "{0}";
                if (id == GridStringId.MenuFooterCountFormat)
                    return "{0}";
                if (id == GridStringId.MenuFooterAverageFormat)
                    return "{0}";

                return base.GetLocalizedString(id);
            }
        }

        private void LoadData()
        {
            DataTable dt = adoMethods.SqlGetDt(qry, sqlParameters);
            gC_Report.DataSource = dt;
            gV_Report.MoveLast();
            gV_Report.MakeRowVisible(gV_Report.FocusedRowHandle);
        }

        private void HyperLinkColumns()
        {
            GridColumn col_DocumentNumber = gV_Report.Columns["DocumentNumber"];
            if (col_DocumentNumber is not null)
            {
                RepositoryItemHyperLinkEdit HLE_DocumentNum = new();
                HLE_DocumentNum.SingleClick = true;
                HLE_DocumentNum.OpenLink += repoHLE_DocumentNumber_OpenLink;
                col_DocumentNumber.ColumnEdit = HLE_DocumentNum;
            }

            GridColumn col_InvoiceNum = gV_Report.Columns["InvoiceNumber"];
            if (col_InvoiceNum is not null)
            {
                RepositoryItemHyperLinkEdit HLE_InvoiceNum = new();
                HLE_InvoiceNum.SingleClick = true;
                HLE_InvoiceNum.OpenLink += repoHLE_DocumentNumber_OpenLink;
                col_InvoiceNum.ColumnEdit = HLE_InvoiceNum;
            }

            GridColumn col_ProductCode = gV_Report.Columns["ProductCode"];
            if (col_ProductCode is not null)
            {
                RepositoryItemHyperLinkEdit HLE_ProductCode = new();
                HLE_ProductCode.SingleClick = true;
                HLE_ProductCode.OpenLink += repoHLE_ProductCode_OpenLink;
                col_ProductCode.ColumnEdit = HLE_ProductCode;

                CreateColImage();
                gV_Report.Columns.Add(colImage);
            }

            GridColumn col_CurrAccCode = gV_Report.Columns["CurrAccCode"];
            if (col_CurrAccCode is not null)
            {
                RepositoryItemHyperLinkEdit HLE_CurrAccCode = new();
                HLE_CurrAccCode.SingleClick = true;
                HLE_CurrAccCode.OpenLink += repoHLE_CurrAccCode_OpenLink;
                col_CurrAccCode.ColumnEdit = HLE_CurrAccCode;
            }
        }

        private void CreateColImage()
        {
            //if (colImage is null)
            //{
            //   colImage = new();
            //}
            colImage.FieldName = "Image";
            colImage.Caption = "Şəkil";
            colImage.UnboundType = UnboundColumnType.Object;
            colImage.OptionsColumn.AllowEdit = false;
            colImage.OptionsColumn.FixedWidth = false;
            colImage.Visible = true;

            //if (riPictureEdit is null)
            //{
            //   riPictureEdit = new();
            colImage.ColumnEdit = riPictureEdit;
            riPictureEdit.SizeMode = PictureSizeMode.Zoom;
            riPictureEdit.NullText = " ";
            gC_Report.RepositoryItems.Add(riPictureEdit);
            //}
        }

        private void bBI_LayoutSave_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (dcReport.ReportId > 0)
            {
                Stream str = new MemoryStream();
                gV_Report.SaveLayoutToStream(str);
                str.Seek(0, SeekOrigin.Begin);
                StreamReader reader = new(str);
                string layoutTxt = reader.ReadToEnd();
                efMethods.UpdateReportLayout(dcReport.ReportId, layoutTxt);
            }
        }

        private void bBI_LayoutLoad_ItemClick(object sender, ItemClickEventArgs e)
        {
            LoadLayout();
        }

        private void LoadLayout()
        {
            dcReport = efMethods.SelectReport(dcReport.ReportId);
            if (!string.IsNullOrEmpty(dcReport.ReportLayout) && dcReport.ReportId > 0)
            {
                byte[] byteArray = Encoding.Unicode.GetBytes(dcReport.ReportLayout);
                MemoryStream stream = new(byteArray);
                gV_Report.RestoreLayoutFromStream(stream);
            }

            TrimNumbersFormat();
        }

        private void bBI_gridOptions_ItemClick(object sender, ItemClickEventArgs e)
        {
            Stream str = new MemoryStream();
            OptionsLayoutGrid option = new() { StoreAllOptions = true, StoreAppearance = true };
            gV_Report.SaveLayoutToStream(str, option);

            using (FormReportGridOptions formGridOptions = new(str, gV_Report))
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
        }

        GridColumn prevColumn = null; // Disable the Immediate Edit Cell
        int prevRow = -1;
        private void gV_Report_ShowingEditor(object sender, CancelEventArgs e)
        {
            GridView view = sender as GridView;

            // Disable the Immediate Edit Cell
            if (prevColumn != view.FocusedColumn || prevRow != view.FocusedRowHandle)
                e.Cancel = true;
            prevColumn = view.FocusedColumn;
            prevRow = view.FocusedRowHandle;

            // hiperLinkedit
            //if (view.FocusedColumn.FieldName == "InvoiceNumber" || view.FocusedColumn.FieldName == "Faktura Nömrəsi")
            //   e.Cancel = true; //icine girmesin
            //else if (view.FocusedColumn.FieldName == "DocumentNumber" || view.FocusedColumn.FieldName == "Ödəniş Nömrəsi")
            //   e.Cancel = true; //icine girmesin
        }


        private void repoHLE_ProductCode_OpenLink(object sender, OpenLinkEventArgs e)
        {
            object objProductCode = gV_Report.GetFocusedRowCellValue("ProductCode");
            string productCode = objProductCode?.ToString();
            if (!String.IsNullOrEmpty(productCode))
                OpenFormProduct(productCode);
        }

        private void repoHLE_CurrAccCode_OpenLink(object sender, OpenLinkEventArgs e)
        {
            object objCurrAccCode = gV_Report.GetFocusedRowCellValue("CurrAccCode");
            string currAccCode = objCurrAccCode?.ToString();
            if (!String.IsNullOrEmpty(currAccCode))
                OpenFormCurrAcc(currAccCode);
        }

        private void repoHLE_DocumentNumber_OpenLink(object sender, OpenLinkEventArgs e)
        {
            object objDocNum = gV_Report.GetFocusedValue();
            string strDocNum = objDocNum?.ToString();

            if (!String.IsNullOrEmpty(strDocNum))
            {
                bool isOpen = InvoiceIsOpen(strDocNum);

                if (!isOpen)
                    OpenFormInvoice(strDocNum);
            }
        }

        private bool InvoiceIsOpen(string docNum)
        {
            bool isOpen = false;
            Process[]? processes = Process.GetProcessesByName("Foxoft");
            foreach (Process? process in processes)
            {
                List<WindowInfo> childWindows = WindowsAPI.GetMDIChildWindowsOfProcess(process);
                foreach (WindowInfo? window in childWindows)
                {
                    if (window.Tag == docNum)
                    {
                        isOpen = true;
                        XtraMessageBox.Show("Qaimə açıqdır.");
                    }

                    // Close the window if necessary
                    // CloseWindow(window.Handle);
                }
            }

            return isOpen;
        }

        private void OpenFormInvoice(string strDocNum)
        {
            TrPaymentHeader trPaymentHeader = efMethods.SelectPaymentHeaderByDocNum(strDocNum);
            TrInvoiceHeader trInvoiceHeader = efMethods.SelectInvoiceHeaderByDocNum(strDocNum);

            if (trInvoiceHeader is not null)
            {
                string claim = trInvoiceHeader.ProcessCode switch
                {
                    "IT" => "InventoryTransfer",
                    "CI" => "CountIn",
                    "CO" => "CountOut",
                    "RP" => "RetailPurchaseInvoice",
                    "RS" => "RetailSaleInvoice",
                    "WS" => "WholesaleInvoice",
                    "EX" => "Expense",
                    "EI" => "Expense of Invoice",
                    _ => ""
                };

                bool currAccHasClaims = efMethods.CurrAccHasClaims(Authorization.CurrAccCode, claim);
                if (!currAccHasClaims)
                {
                    MessageBox.Show("Yetkiniz yoxdur! ");
                    return;
                }


                byte[] bytes = trInvoiceHeader.ProcessCode switch
                {
                    "IT" => new byte[] { 1 },
                    "CI" => new byte[] { 1 },
                    "CO" => new byte[] { 1 },
                    "RP" => new byte[] { 1, 3 },
                    "RS" => new byte[] { 1, 3 },
                    "WS" => new byte[] { 1, 3 },
                    "EX" => new byte[] { 2, 3 },
                    "EI" => new byte[] { 2, 3 },
                    _ => new byte[] { }
                };

                FormInvoice frm = new(trInvoiceHeader.ProcessCode, bytes, Guid.Empty, trInvoiceHeader.InvoiceHeaderId);
                FormERP formERP = Application.OpenForms[nameof(FormERP)] as FormERP;
                frm.MdiParent = formERP;
                frm.WindowState = FormWindowState.Maximized;
                frm.Show();
                formERP.parentRibbonControl.SelectedPage = formERP.parentRibbonControl.MergedPages[0];
            }
            else if (trPaymentHeader is not null)
            {
                if (trPaymentHeader.ProcessCode == "PA")
                {
                    FormPaymentDetail frm = new(trPaymentHeader.PaymentHeaderId);
                    FormERP formERP = Application.OpenForms[nameof(FormERP)] as FormERP;
                    frm.MdiParent = formERP;
                    frm.WindowState = FormWindowState.Maximized;
                    //frm.Show();
                    if (formERP.parentRibbonControl.MergedPages.Count > 0)
                        formERP.parentRibbonControl.SelectedPage = formERP.parentRibbonControl.MergedPages[0];
                }
                else if (trPaymentHeader.ProcessCode == "CT")
                {
                    FormMoneyTransfer frm = new(trPaymentHeader.PaymentHeaderId);
                    FormERP formERP = Application.OpenForms[nameof(FormERP)] as FormERP;
                    frm.MdiParent = formERP;
                    frm.WindowState = FormWindowState.Maximized;
                    frm.Show();
                    formERP.parentRibbonControl.SelectedPage = formERP.parentRibbonControl.MergedPages[0];
                }
            }
            else
                MessageBox.Show("Belə bir sənəd yoxdur.");
        }

        private void gV_Report_RowStyle(object sender, RowStyleEventArgs e)
        {
            GridView view = sender as GridView;

            if (e.RowHandle >= 0)
            {
                object isReturn = view.GetRowCellValue(e.RowHandle, view.Columns["IsReturn"]);

                if (isReturn is not null)
                {
                    bool value = (bool)isReturn;

                    if (value)
                        e.Appearance.BackColor = Color.MistyRose;
                }
            }
        }

        private void bBI_ExportXlsx_ItemClick(object sender, ItemClickEventArgs e)
        {
            XtraSaveFileDialog sFD = new()
            {
                Filter = "Excel Faylı|*.xlsx",
                Title = "Excel Faylı Yadda Saxla",
                FileName = dcReport.ReportName,
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                DefaultExt = "*.xlsx",
            };

            String fileName = Invoke((Func<string>)(() =>
            {
                if (sFD.ShowDialog() == DialogResult.OK)
                {
                    gC_Report.ExportToXlsx(sFD.FileName);

                    if (XtraMessageBox.Show(this, "Açmaq istəyirsiz?", "Diqqət", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        Process p = new();
                        p.StartInfo = new ProcessStartInfo(sFD.FileName) { UseShellExecute = true };
                        p.Start();
                    }

                    return "Ok";
                }
                else
                    return "Fail";
            }));
        }

        private void BBI_ExportExcel_ItemClick(object sender, ItemClickEventArgs e)
        {
            XtraSaveFileDialog sFD = new()
            {
                Filter = "Excel Faylı|*.xlsx",
                Title = "Excel Faylı Yadda Saxla",
                FileName = dcReport.ReportName,
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                DefaultExt = "*.xlsx",
            };

            if (sFD.ShowDialog() == DialogResult.OK)
            {
                gC_Report.ExportToXlsx(sFD.FileName);

                if (XtraMessageBox.Show(this, "Açmaq istəyirsiz?", "Diqqət", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    Process p = new();
                    p.StartInfo = new ProcessStartInfo(sFD.FileName) { UseShellExecute = true };
                    p.Start();
                }
            }
        }

        private void bBI_Refresh_ItemClick(object sender, ItemClickEventArgs e)
        {
            LoadData();
        }

        private void bBI_Quit_ItemClick(object sender, ItemClickEventArgs e)
        {
            Close();
        }

        private void gC_Report_ProcessGridKey(object sender, KeyEventArgs e)
        {
            GridControl gC = sender as GridControl;
            GridView gV = gC.MainView as GridView;

            if (e.KeyCode == Keys.C && e.Control)
            {
                string cellValue = gV.GetFocusedValue().ToString();
                Clipboard.SetText(cellValue);
                e.Handled = true;
            }
        }

        private void gV_Report_CalcRowHeight(object sender, RowHeightEventArgs e)
        {
            GridView gV = sender as GridView;
            if (e.RowHandle == GridControl.AutoFilterRowHandle)
                e.RowHeight = 25;
            if (colImage is not null)
                colImage.Width = gV.RowHeight;
        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            GridColumn col = gV_Report.Columns.AddVisible("Unbound" + gV_Report.Columns.Count);
            col.UnboundDataType = typeof(string);
        }

        private void TrimNumbersFormat()
        {
            foreach (var item in gV_Report.Columns)
            {
                GridColumn gridColumn = (GridColumn)item;
                if (gridColumn.ColumnType.Name == "Decimal")
                {
                    gridColumn.DisplayFormat.FormatType = FormatType.Numeric;
                    gridColumn.DisplayFormat.FormatString = "0.00";
                }
            }
        }

        private void customItem_ItemClick(object sender, ItemClickEventArgs e)
        {
            // Implement the custom action.
            // ...
        }

        private void gV_Report_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            GridViewColumnMenu menu = e.Menu as GridViewColumnMenu;

            if (e.MenuType == GridMenuType.Column)
            {
                if (menu.Column != null)
                {
                    menu.Items.Add(CreateItemExpression("Expression", e.HitInfo.RowHandle, menu.Column, null));

                    DXSubMenuItem menuSubItem = CreateSubMenuReports(e.HitInfo.Column, e.HitInfo.RowHandle);
                    menuSubItem.BeginGroup = true;

                    if (menuSubItem.Items.Count > 0)
                        menu.Items.Add(menuSubItem);
                }
            }
            else if (e.MenuType == GridMenuType.Row)
            {
                e.Menu.Items.Clear();

                CreateMenuItemEdit(e);

                DXSubMenuItem menuSubItem = CreateSubMenuReports(e.HitInfo.Column, e.HitInfo.RowHandle);
                menuSubItem.BeginGroup = true;

                if (menuSubItem.Items.Count > 0)
                    e.Menu.Items.Add(menuSubItem);
            }
        }

        DXMenuItem CreateMenuItemEdit(PopupMenuShowingEventArgs eMenu)
        {
            int rowHandle = eMenu.HitInfo.RowHandle;
            GridColumn gridColumn = eMenu.HitInfo.Column;

            DXMenuItem menuItem = new("Dəyiş");
            //menuItem.Tag = new RowInfo(view, rowHandle);
            menuItem.ImageOptions.SvgImage = svgImageCollection1[1];

            object objCellValue = gV_Report.GetRowCellValue(rowHandle, gridColumn);
            string cellValue = objCellValue?.ToString();

            if (!String.IsNullOrEmpty(cellValue))
            {
                if (gridColumn.FieldName == "ProductCode")
                {
                    menuItem.Click += (sender, e) =>
                    {
                        OpenFormProduct(cellValue);
                    };
                    eMenu.Menu.Items.Add(menuItem);
                }
                else if (gridColumn.FieldName == "CurrAccCode")
                {
                    menuItem.Click += (sender, e) =>
                    {
                        OpenFormCurrAcc(cellValue);
                    };
                    eMenu.Menu.Items.Add(menuItem);
                }
                else if (new string[] { "DocumentNumber", "InvoiceNumber" }.Contains(gridColumn.FieldName))
                {
                    menuItem.Click += (sender, e) =>
                    {
                        OpenFormInvoice(cellValue);
                    };
                    eMenu.Menu.Items.Add(menuItem);
                }
            }

            return menuItem;
        }

        private void OpenFormCurrAcc(string currAccCode)
        {
            FormCurrAcc formCurrAcc = new(currAccCode);
            if (formCurrAcc.ShowDialog(this) == DialogResult.OK)
            {
                LoadData();
            }
        }

        private void OpenFormProduct(string productCode)
        {
            FormProduct formProduct = new(0, productCode);
            if (formProduct.ShowDialog(this) == DialogResult.OK)
            {
                string path = imageFolder + @"\" + productCode + ".jpg";
                imageCache.Remove(path);

                LoadData();
            }
        }

        DXSubMenuItem CreateSubMenuReports(GridColumn gridColumn, int rowHandle)
        {
            DXSubMenuItem subMenu = new("Hesabat");

            subMenu.ImageOptions.SvgImage = svgImageCollection1[0];

            List<TrFormReport> trFormReports = new List<TrFormReport>();
            if (gridColumn.FieldName == "ProductCode")
                trFormReports = efMethods.SelectFormReports("Products");
            else if (gridColumn.FieldName == "CurrAccCode")
                trFormReports = efMethods.SelectFormReports("CurrAccs");

            foreach (TrFormReport report in trFormReports)
            {
                DXMenuItem dxItem = new(report.DcReport.ReportName);
                dxItem.Tag = new CellInfo(rowHandle, gridColumn);
                //dxItem.Enabled = gV_Report.IsDataRow(rowHandle) || gV_Report.IsGroupRow(rowHandle);
                dxItem.ImageOptions.SvgImage = svgImageCollection1[0];
                subMenu.Items.Add(dxItem);

                dxItem.Click += (sender, e) =>
                {
                    DcReport dcReport = efMethods.SelectReport(report.DcReport.ReportId);

                    List<DataRowView> mydata = GetFilteredData<DataRowView>(gV_Report).ToList();

                    string filter = "";

                    if (rowHandle > 0)
                        filter = gridColumn.FieldName + " = '" + gV_Report.GetRowCellValue(rowHandle, gridColumn) + "' ";
                    else
                    {
                        var combined = "";
                        foreach (DataRowView rowView in mydata)
                            combined += "'" + rowView[gridColumn.FieldName].ToString() + "',";

                        combined = combined.Substring(0, combined.Length - 1);
                        filter = "[" + gridColumn.FieldName + "] in ( " + combined + ")";
                    }

                    if (dcReport.ReportTypeId == 1)
                    {
                        FormReportGrid formGrid = new(dcReport.ReportQuery, filter, dcReport);
                        formGrid.Show();
                    }
                    else if (dcReport.ReportTypeId == 2)
                    {
                        FormReportPreview form = new(dcReport.ReportQuery, filter, dcReport);
                        form.WindowState = FormWindowState.Maximized;
                        form.Show();
                    }
                };
            }

            return subMenu;
        }

        public static List<T> GetFilteredData<T>(ColumnView view)
        {
            List<T> resp = new List<T>();
            for (int i = 0; i < view.DataRowCount; i++)
                resp.Add((T)view.GetRow(i));

            return resp;
        }


        DXMenuItem CreateItemExpression(string caption, int rowHandle, GridColumn column, Image image)
        {
            DXMenuItem item = new(caption, new EventHandler(DXMenuItemExpression_ItemClick), image);
            item.Tag = new CellInfo(rowHandle, column);
            return item;
        }

        void DXMenuItemExpression_ItemClick(object sender, EventArgs e)
        {
            DXMenuItem item = sender as DXMenuItem;
            CellInfo info = item.Tag as CellInfo;
            if (info == null) return;

            GridColumn col = info.Column;
            col.UnboundType = UnboundColumnType.Object;
            using (XRDesignFormEx designForm = new())
            {
                XtraReport report = new();
                report.DataSource = gC_Report.DataSource;
                CalculatedField calcField = new();
                calcField.Expression = col.UnboundExpression;
                report.CalculatedFields.Add(calcField);
                designForm.OpenReport(report);
                XRDesignerHost host = designForm.DesignPanel.GetService(typeof(IDesignerHost)) as XRDesignerHost;
                IDesigner designer = host.GetDesigner(calcField);
                string newExpression = Convert.ToString(EditorContextHelper.EditValue(designer, calcField, XRComponentPropertyNames.Expression));
                col.UnboundExpression = calcField.Expression;
            }
        }

        class CellInfo
        {
            public CellInfo(int rowHandle, GridColumn column)
            {
                this.RowHandle = rowHandle;
                this.Column = column;
            }

            public int RowHandle;
            public GridColumn Column;
        }

        private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
        {
            gV_Report.MakeRowVisible(gV_Report.FocusedRowHandle);
        }

        private void BBI_PrintPreview_ItemClick(object sender, ItemClickEventArgs e)
        {
            gC_Report.ShowPrintPreview();
        }

        private void gV_Report_PrintInitialize(object sender, PrintInitializeEventArgs e)
        {
            //PrintingSystemBase pb = e.PrintingSystem as PrintingSystemBase;
            //pb.PageSettings.Landscape = true;
            //pb.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.A4;
            //pb.PageSettings.TopMarginF = 0.75f;
            //pb.PageSettings.BottomMarginF = 0.75f;
            //pb.PageSettings.RightMarginF = 0.75f;
            //pb.PageSettings.LeftMarginF = 0.75f;
        }
    }
}
