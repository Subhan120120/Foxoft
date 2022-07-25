using DevExpress.Data.Filtering;
using DevExpress.Utils;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using Foxoft.Models;
using Foxoft.Properties;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Foxoft
{
   public partial class FormCurrAccList : RibbonForm
   {
      EfMethods efMethods = new EfMethods();
      public DcCurrAcc dcCurrAcc { get; set; }
      public byte currAccTypeCode;

      public FormCurrAccList()
      {
         InitializeComponent();
         bBI_quit.ItemShortcut = new BarShortcut(Keys.Escape);

         byte[] byteArray = Encoding.ASCII.GetBytes(Settings.Default.AppSetting.GridViewLayout);
         MemoryStream stream = new MemoryStream(byteArray);
         OptionsLayoutGrid option = new OptionsLayoutGrid() { StoreAllOptions = true, StoreAppearance = true };
         gV_CurrAccList.RestoreLayoutFromStream(stream, option);
      }

      public FormCurrAccList(byte currAccTypeCode)
          : this()
      {
         this.currAccTypeCode = currAccTypeCode;
         UpdateGridViewData();
      }

      private void gV_CurrAccList_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
      {
         GridView view = sender as GridView;

         if (view.FocusedRowHandle >= 0)
            dcCurrAcc = view.GetFocusedRow() as DcCurrAcc;
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

         //ApplySelectedCurrAcc();
         GridView view = sender as GridView;
         if (view.SelectedRowsCount > 0)
            DialogResult = DialogResult.OK;
      }

      private void bBI_CurrAccNew_ItemClick(object sender, ItemClickEventArgs e)
      {
         dcCurrAcc = new DcCurrAcc();
         FormCurrAcc form = new FormCurrAcc(currAccTypeCode);
         if (form.ShowDialog(this) == DialogResult.OK)
         {
            UpdateGridViewData();
         }
      }

      private void bBI_CurrAccEdit_ItemClick(object sender, ItemClickEventArgs e)
      {
         //ApplySelectedCurrAcc();

         if (!Object.ReferenceEquals(dcCurrAcc, null))
         {
            FormCurrAcc form = new FormCurrAcc(dcCurrAcc.CurrAccCode);
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
      }

      private void LoadCurrAccs()
      {
         if (currAccTypeCode != 0)
            gC_CurrAccList.DataSource = efMethods.SelectCurrAccsByType(currAccTypeCode);
         else
            gC_CurrAccList.DataSource = efMethods.SelectCurrAccs();
      }

      private void bBI_refresh_ItemClick(object sender, ItemClickEventArgs e)
      {
         UpdateGridViewData();
      }

      private void gC_CurrAccList_ProcessGridKey(object sender, KeyEventArgs e)
      {
         ColumnView view = (sender as GridControl).FocusedView as ColumnView;
         if (view == null) return;
         if (e.KeyCode == Keys.Enter && view.SelectedRowsCount > 0)
         {
            DialogResult = DialogResult.OK;
         }

      }

      // AutoFocus FindPanel
      bool isFirstPaint = true;
      private void gC_CurrAccList_Paint(object sender, PaintEventArgs e)
      {
         GridControl gC = sender as GridControl;
         GridView gV = gC.MainView as GridView;

         if (isFirstPaint)
         {
            if (!gV.FindPanelVisible)
               gV.ShowFindPanel();
            gV.ShowFindPanel();
         }
         isFirstPaint = false;
      }

      private void bBI_quit_ItemClick(object sender, ItemClickEventArgs e)
      {
         this.Close();
      }

      private void ApplySelectedCurrAcc()
      {
         if (gV_CurrAccList.FocusedRowHandle >= 0)
         {
            dcCurrAcc = gV_CurrAccList.GetFocusedRow() as DcCurrAcc;
            DialogResult = DialogResult.OK;
         }
         else
         {
            MessageBox.Show("Məhsul Seçilmədi");
         }
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
         object currAccCode = gV_CurrAccList.GetFocusedRowCellValue(col_CurrAccCode);

         if (!Object.ReferenceEquals(currAccCode, null))
         {

            efMethods.UpdateDcReportFilter_Value(dcReport.ReportId, "CurrAccCode", currAccCode.ToString());

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

            FormReportGrid formGrid = new FormReportGrid(qryMaster, dcReport);
            formGrid.Show();
         }
      }

      private BinaryOperatorType ConvertOperatorType(string filterOperatorType)
      {
         switch (filterOperatorType)
         {
            case "+":
               return BinaryOperatorType.Plus;
            case "&":
               return BinaryOperatorType.BitwiseAnd;
            case "/":
               return BinaryOperatorType.Divide;
            case "==":
               return BinaryOperatorType.Equal;
            case ">":
               return BinaryOperatorType.Greater;
            case ">=":
               return BinaryOperatorType.GreaterOrEqual;
            case "<":
               return BinaryOperatorType.Less;
            case "<=":
               return BinaryOperatorType.LessOrEqual;
            case "%":
               return BinaryOperatorType.Modulo;
            case "*":
               return BinaryOperatorType.Multiply;
            case "!=":
               return BinaryOperatorType.NotEqual;
            case "|":
               return BinaryOperatorType.BitwiseOr;
            case "-":
               return BinaryOperatorType.Minus;
            case "^":
               return BinaryOperatorType.BitwiseXor;
            default:
               return BinaryOperatorType.Equal;
         }
      }
   }
}