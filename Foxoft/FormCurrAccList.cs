using DevExpress.Data.Filtering;
using DevExpress.Utils;
using DevExpress.Utils.Menu;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Menu;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using Foxoft.Models;
using Foxoft.Properties;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Foxoft
{
   public partial class FormCurrAccList : RibbonForm
   {
      EfMethods efMethods = new();
      public DcCurrAcc dcCurrAcc { get; set; }
      public byte currAccTypeCode;
      public string currAccCode;

      public FormCurrAccList()
      {
         InitializeComponent();
         bBI_quit.ItemShortcut = new BarShortcut(Keys.Escape);

         LoadLayout();

         //colPhoneNum.Properties.Mask.EditMask = "(00) 000 00 00";
         //colPhoneNum.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Simple;
         //colPhoneNum.Properties.Mask.SaveLiteral = false;
         //colPhoneNum.Properties.Mask.UseMaskAsDisplayFormat = true;
      }

      public FormCurrAccList(byte currAccTypeCode)
          : this()
      {
         this.currAccTypeCode = currAccTypeCode;
         UpdateGridViewData();
      }

      public FormCurrAccList(byte productTypeCode, string currAccCode)
    : this(productTypeCode)
      {
         this.currAccCode = currAccCode;
      }

      private void SaveLayout()
      {
         string fileName = "FormCurrAccList.xml";
         string layoutFileDir = Path.Combine(Path.GetTempPath(), "Foxoft", "Layout Xml Files");
         if (!Directory.Exists(layoutFileDir))
            Directory.CreateDirectory(layoutFileDir);
         gV_CurrAccList.SaveLayoutToXml(Path.Combine(layoutFileDir, fileName));
      }

      private void LoadLayout()
      {
         string fileName = "FormCurrAccList.xml";
         string layoutFilePath = Path.Combine(Path.GetTempPath(), "Foxoft", "Layout Xml Files", fileName);

         if (File.Exists(layoutFilePath))
            gV_CurrAccList.RestoreLayoutFromXml(layoutFilePath);
         else
         {
            byte[] byteArray = Encoding.ASCII.GetBytes(Settings.Default.AppSetting.GridViewLayout);
            MemoryStream stream = new(byteArray);
            OptionsLayoutGrid option = new() { StoreAllOptions = true, StoreAppearance = true };
            gV_CurrAccList.RestoreLayoutFromStream(stream, option);
         }
      }

      private void gV_CurrAccList_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
      {
         GridView view = sender as GridView;

         if (view.FocusedRowHandle >= 0)
            dcCurrAcc = view.GetFocusedRow() as DcCurrAcc;
         else
            dcCurrAcc = null;
      }

      private void gV_CurrAccList_DoubleClick(object sender, EventArgs e)
      {
         #region comment
         //DXMouseEventArgs ea = e as DXMouseEventArgs;
         //GridView view = sender as GridView;
         //GridHitInfo info = view.CalcHitInfo(ea.Location);
         //if (info.InRow || info.InRowCell)
         //{
         //    //info.RowHandle
         //    string colCaption = info.Column == null ? "N/A" : info.Column.GetCaption();
         //    dcCurrAcc = new DcCurrAcc();
         //    string CurrAccCode = view.GetRowCellValue(view.FocusedRowHandle, view.Columns["CurrAccCode"]).ToString();
         //    dcCurrAcc = efMethods.SelectCurrAcc(CurrAccCode);

         //    DialogResult = DialogResult.OK;
         //} 
         #endregion

         if (dcCurrAcc is not null)
            AcceptForm();
      }

      private void AcceptForm()
      {
         DialogResult = DialogResult.OK;
      }

      private void bBI_CurrAccNew_ItemClick(object sender, ItemClickEventArgs e)
      {
         dcCurrAcc = new DcCurrAcc();
         FormCurrAcc form = new(currAccTypeCode);
         if (form.ShowDialog(this) == DialogResult.OK)
         {
            UpdateGridViewData();
         }
      }

      private void bBI_CurrAccEdit_ItemClick(object sender, ItemClickEventArgs e)
      {
         //ApplySelectedCurrAcc();

         if (dcCurrAcc is not null)
         {
            FormCurrAcc form = new(dcCurrAcc.CurrAccCode);
            if (form.ShowDialog(this) == DialogResult.OK)
            {
               UpdateGridViewData();
            }
         }
      }

      private void UpdateGridViewData()
      {
         int fr = gV_CurrAccList.FocusedRowHandle;

         LoadCurrAccs();

         if (fr > 0)
            gV_CurrAccList.FocusedRowHandle = fr;
         else
            gV_CurrAccList.MoveLast();

         if (gV_CurrAccList.FocusedRowHandle >= 0)
            dcCurrAcc = gV_CurrAccList.GetFocusedRow() as DcCurrAcc;
         else
            dcCurrAcc = null;
      }

      private void LoadCurrAccs()
      {
         if (currAccTypeCode != 0)
         {
            dcCurrAccsBindingSource.DataSource = efMethods.SelectCurrAccs(new byte[] { currAccTypeCode });
         }
         else
         {
            //dbContext.DcCurrAccs.Load();
            //dcCurrAccsBindingSource.DataSource = dbContext.DcCurrAccs.Local.ToBindingList();
            dcCurrAccsBindingSource.DataSource = efMethods.SelectCurrAccs(new byte[] { 1, 2, 3, 4 });
         }
      }

      private void bBI_refresh_ItemClick(object sender, ItemClickEventArgs e)
      {
         UpdateGridViewData();
      }

      private void gC_CurrAccList_ProcessGridKey(object sender, KeyEventArgs e)
      {
         ColumnView view = (sender as GridControl).FocusedView as ColumnView;
         if (view == null) return;

         if (dcCurrAcc is not null)
         {
            if (e.KeyCode == Keys.Enter)
            {
               DialogResult = DialogResult.OK;
            }

            if (e.KeyCode == Keys.C && e.Control)
            {
               //if (view.GetRowCellValue(view.FocusedRowHandle, view.FocusedColumn) != null && view.GetRowCellValue(view.FocusedRowHandle, view.FocusedColumn).ToString() != String.Empty)
               //   Clipboard.SetText(view.GetRowCellValue(view.FocusedRowHandle, view.FocusedColumn).ToString());
               //else
               //   MessageBox.Show("The value in the selected cell is null or empty!");

               string cellValue = gV_CurrAccList.GetFocusedValue().ToString();
               Clipboard.SetText(cellValue);
               e.Handled = true;
            }

         }
      }

      // AutoFocus FindPanel
      bool isFirstPaint = true;
      private void gC_CurrAccList_Paint(object sender, PaintEventArgs e)
      {
         //GridControl gC = sender as GridControl;
         //GridView gV = gC.MainView as GridView;

         //if (isFirstPaint)
         //{
         //   if (!gV.FindPanelVisible)
         //      gV.ShowFindPanel();
         //   gV.ShowFindPanel();

         //   gV.OptionsFind.FindFilterColumns = "CurrAccDesc";
         //   gV.OptionsFind.FindNullPrompt = "Axtarın...";
         //}
         //isFirstPaint = false;
      }

      private void bBI_quit_ItemClick(object sender, ItemClickEventArgs e)
      {
         this.Close();
      }

      private void gV_CurrAccList_ColumnFilterChanged(object sender, EventArgs e)
      {
         GridView view = sender as GridView;


         if (view.FocusedRowHandle >= 0)
            dcCurrAcc = view.GetFocusedRow() as DcCurrAcc;
         else
            dcCurrAcc = null;
      }

      private void bBI_Report1_ItemClick(object sender, ItemClickEventArgs e)
      {
         DcReport dcReport = efMethods.SelectReport(1003);
         object currAccCode = gV_CurrAccList.GetFocusedRowCellValue(colCurrAccCode);

         if (currAccCode is not null)
         {
            efMethods.UpdateDcReportFilter_Value(dcReport.ReportId, "CurrAccCode", currAccCode.ToString());

            dcReport = efMethods.SelectReport(dcReport.ReportId);

            string reportQuery = dcReport.ReportQuery;

            ICollection<DcReportFilter> dcReportFilters = dcReport.DcReportFilters;
            CriteriaOperator[] criteriaOperators = new CriteriaOperator[dcReportFilters.Count];
            int index = 0;
            foreach (DcReportFilter rf in dcReportFilters)
            {
               BinaryOperatorType operatorType = ConvertOperatorType(rf.FilterOperatorType);

               criteriaOperators[index] = new BinaryOperator(rf.FilterProperty, rf.FilterValue, operatorType);

               string filterSql = CriteriaToWhereClauseHelper.GetMsSqlWhere(criteriaOperators[index]);
               reportQuery = reportQuery.Replace(rf.Representative, " and " + filterSql); //filter sorgunun icinde temsilci ile deyisdirilir

               index++;
            }
            //CriteriaOperator groupOperator = new GroupOperator(GroupOperatorType.And, criteriaOperators);
            string qryMaster = "Select * from ( " + reportQuery + ") as master";

            string activeFilterStr = "[StoreCode] = \'" + Authorization.StoreCode + "\'";

            FormReportGrid formGrid = new(qryMaster, dcReport, activeFilterStr);
            formGrid.Show();
         }
      }

      private BinaryOperatorType ConvertOperatorType(string filterOperatorType)
      {
         return filterOperatorType switch
         {
            "+" => BinaryOperatorType.Plus,
            "&" => BinaryOperatorType.BitwiseAnd,
            "/" => BinaryOperatorType.Divide,
            "==" => BinaryOperatorType.Equal,
            ">" => BinaryOperatorType.Greater,
            ">=" => BinaryOperatorType.GreaterOrEqual,
            "<" => BinaryOperatorType.Less,
            "<=" => BinaryOperatorType.LessOrEqual,
            "%" => BinaryOperatorType.Modulo,
            "*" => BinaryOperatorType.Multiply,
            "!=" => BinaryOperatorType.NotEqual,
            "|" => BinaryOperatorType.BitwiseOr,
            "-" => BinaryOperatorType.Minus,
            "^" => BinaryOperatorType.BitwiseXor,
            _ => BinaryOperatorType.Equal,
         };
      }

      private void bBI_ExportXlsx_ItemClick(object sender, ItemClickEventArgs e)
      {
         try
         {
            Trace.Write("\n Before 'SaveFileDialog sFD = new();' ");
            SaveFileDialog sFD = new();
            Trace.Write("\n Before ' sFD.Filter = 'Excel Faylı | *.xlsx';' ");
            sFD.Filter = "Excel Faylı|*.xlsx";
            Trace.Write("\n Before 'sFD.Title = 'Excel Faylı Yadda Saxla';' ");
            sFD.Title = "Excel Faylı Yadda Saxla";
            Trace.Write("\n Before 'sFD.FileName = this.Text");
            sFD.FileName = this.Text;
            Trace.Write("\n Before 'sFD.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);' ");
            sFD.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            Trace.Write("\n Before 'sFD.DefaultExt = ' *.xlsx';' ");
            sFD.DefaultExt = "*.xlsx";

            if (sFD.ShowDialog() == DialogResult.OK)
            {
               Trace.Write("\n Before 'gC_CurrAccList.ExportToXlsx(sFD.FileName);' ");
               gC_CurrAccList.ExportToXlsx(sFD.FileName);
            }
         }
         catch (Exception ex)
         {
            MessageBox.Show(ex.ToString());
         }
      }

      private void bBI_CurrAccDelete_ItemClick(object sender, ItemClickEventArgs e)
      {
         if (efMethods.CurrAccExist(dcCurrAcc.CurrAccCode))
         {
            if (XtraMessageBox.Show("Silmek Isteyirsiz? \n " + dcCurrAcc.CurrAccDesc, "Diqqet", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
               efMethods.DeleteCurrAcc(dcCurrAcc);

               LoadCurrAccs();
            }
         }
         else
            XtraMessageBox.Show("Silinmeli olan faktura yoxdur");
      }

      private void bBI_CurAccRefresh_ItemClick(object sender, ItemClickEventArgs e)
      {
         UpdateGridViewData();
      }

      //AutoFocus FindPanel 
      private void gC_CurrAccList_Load(object sender, EventArgs e)
      {
         GridControl gC = sender as GridControl;
         GridView gV = gC.MainView as GridView;
         if (gV is not null)
         {
            gV_CurrAccList.OptionsFind.FindFilterColumns = "CurrAccDesc";
            gV_CurrAccList.OptionsFind.FindNullPrompt = "Axtarın...";

            //if (!gV.FindPanelVisible)
            gC.BeginInvoke(new Action(gV.ShowFindPanel));
         }

         int rowHandle = gV_CurrAccList.LocateByValue(0, colCurrAccCode, currAccCode);
         if (rowHandle != GridControl.InvalidRowHandle)
         {
            gV_CurrAccList.FocusedRowHandle = rowHandle;
            gV_CurrAccList.MakeRowVisible(rowHandle);
         }

         gV_CurrAccList.BestFitColumns();
      }

      private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
      {
         DcReport dcReport = efMethods.SelectReport(3);
         object currAccCode = gV_CurrAccList.GetFocusedRowCellValue(colCurrAccCode);

         if (currAccCode is not null)
         {
            string qryMaster = "Select * from ( " + dcReport.ReportQuery + ") as master";

            string filter = " where [CurrAccCode] = '" + currAccCode + "' ";

            string activeFilterStr = "[StoreCode] = \'" + Authorization.StoreCode + "\'";

            FormReportGrid formGrid = new(qryMaster + filter, dcReport, activeFilterStr);
            formGrid.Show();
         }
      }

      private void gV_Report_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
      {
         if (e.MenuType == GridMenuType.Column)
         {
            GridViewColumnMenu menu = e.Menu as GridViewColumnMenu;
            //menu.Items.Clear();
            if (menu.Column != null)
            {
               menu.Items.Add(CreateItem("Save Layout", menu.Column, null));
            }
         }
      }

      DXMenuItem CreateItem(string caption, GridColumn column, Image image)
      {
         DXMenuItem item = new(caption, new EventHandler(DXMenuCheckItem_ItemClick), image);
         item.Tag = new MenuColumnInfo(column);
         return item;
      }

      // Menu item click handler.
      void DXMenuCheckItem_ItemClick(object sender, EventArgs e)
      {
         DXMenuItem item = sender as DXMenuItem;
         MenuColumnInfo info = item.Tag as MenuColumnInfo;
         if (info == null) return;

         SaveLayout();

         //GridColumn col = gV_Report.Columns.AddVisible("Unbound" + gV_Report.Columns.Count);
      }

      class MenuColumnInfo
      {
         public MenuColumnInfo(GridColumn column)
         {
            this.Column = column;
         }
         public GridColumn Column;
      }
   }
}