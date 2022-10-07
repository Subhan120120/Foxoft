using DevExpress.Data.Filtering;
using DevExpress.Utils.Drawing;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Drawing;
using DevExpress.XtraEditors.Filtering;
using DevExpress.XtraEditors.Repository;
using Foxoft.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace Foxoft
{
   public partial class FormReportFilter : RibbonForm
   {
      EfMethods efMethods = new EfMethods();
      AdoMethods adoMethods = new AdoMethods();
      DcReport dcReport = new DcReport();

      readonly RepositoryItemButtonEdit repoBtnEdit_ProductCode = new RepositoryItemButtonEdit();
      readonly RepositoryItemButtonEdit repoBtnEdit_CurrAccCode = new RepositoryItemButtonEdit();
      readonly RepositoryItemButtonEdit repoBtnEdit_StoreCode = new RepositoryItemButtonEdit();
      readonly RepositoryItemButtonEdit repoBtnEdit_CashRegisterCode = new RepositoryItemButtonEdit();

      public FormReportFilter(DcReport Report)
      {
         InitializeComponent();
         WindowsFormsSettings.FilterCriteriaDisplayStyle = FilterCriteriaDisplayStyle.Text;
         AcceptButton = btn_ShowReport;

         this.dcReport = efMethods.SelectReport(Report.ReportId); // reload dcReport
         this.Text = Report.ReportName;

         string querySql = null;
         if (dcReport is not null)
            querySql = ClearVariables(dcReport.ReportQuery);

         if (querySql is not null)
            filterControl_Outer.SourceControl = adoMethods.SqlGetDt(querySql);
         filterControl_Outer.FilterString = dcReport.ReportFilter;

         GroupOperator groupOperator = GetFiltersFromDatabase(dcReport.DcReportFilters);
         filterControl_Inner.SourceControl = opToDt(groupOperator);
         filterControl_Inner.FilterCriteria = groupOperator;

         this.repoBtnEdit_ProductCode.AutoHeight = false;
         this.repoBtnEdit_ProductCode.Name = "repoBtnEdit_ProductCode";
         this.repoBtnEdit_ProductCode.ButtonPressed += new ButtonPressedEventHandler(this.repoBtnEdt_ButtonPressed);

         this.repoBtnEdit_CurrAccCode.AutoHeight = false;
         this.repoBtnEdit_CurrAccCode.Name = "repoBtnEdit_CurrAccCode";
         this.repoBtnEdit_CurrAccCode.ButtonPressed += new ButtonPressedEventHandler(this.repobtnEdit_CurrAccCode_ButtonPressed);

         this.repoBtnEdit_StoreCode.AutoHeight = false;
         this.repoBtnEdit_StoreCode.Name = "repoBtnEdit_StoreCode";
         this.repoBtnEdit_StoreCode.ButtonPressed += new ButtonPressedEventHandler(this.repobtnEdit_StoreCode_ButtonPressed);

         this.repoBtnEdit_CashRegisterCode.AutoHeight = false;
         this.repoBtnEdit_CashRegisterCode.Name = "repoBtnEdit_CashRegisterCode";
         this.repoBtnEdit_CashRegisterCode.ButtonPressed += new ButtonPressedEventHandler(this.repobtnEdit_CashRegisterCode_ButtonPressed);
      }

      private string ClearVariables(string querySql)
      {
         if (querySql is not null)

            if (querySql.Contains("{"))
            {
               int startindex = querySql.IndexOf('{');
               int endindex = querySql.IndexOf('}');
               string outputstring = querySql.Substring(startindex, endindex - startindex + 1);
               string newQuerySql = querySql.Replace(outputstring, "");
               return newQuerySql;
            }
            else
               return querySql;
         else return null;
      }

      private DataTable opToDt(GroupOperator groupOperand)
      {
         DataTable dt = new DataTable();
         dt.Clear();
         Dictionary<string, object> keyValuePairs = Extract(groupOperand);
         foreach (var item in keyValuePairs)
            dt.Columns.Add(item.Key);

         return dt;
      }

      private GroupOperator GetFiltersFromDatabase(ICollection<DcReportFilter> dcReportFilters)
      {
         GroupOperator groupOperand = new GroupOperator();

         foreach (DcReportFilter rf in dcReportFilters)
         {
            BinaryOperatorType operatorType = ConvertOperatorType(rf.FilterOperatorType);
            CriteriaOperator op = new BinaryOperator(rf.FilterProperty, rf.FilterValue, operatorType);
            groupOperand.Operands.Add(op);
         }

         return groupOperand;
      }

      //private CriteriaOperator DoSomthing(CriteriaOperator criteriaOperator)
      //{
      //    if (criteriaOperator is GroupOperator)
      //    {
      //        var groupOperator = (GroupOperator)criteriaOperator;
      //        CriteriaOperatorCollection operands = groupOperator.Operands;

      //        var indexesToremove = new List<int>();
      //        for (int i = 0; i < operands.Count; i++)
      //        {
      //            CriteriaOperator operand = operands[i];
      //            if (operand.ToString() == matchString)
      //            {
      //                if (ReferenceEquals(replaceOperator, null))
      //                    indexesToremove.Add(i);
      //                else
      //                    operands[i] = replaceOperator;
      //            }
      //            else
      //            {
      //                CriteriaOperator extract = operand;
      //                operands.RemoveAt(i);
      //                operands.Insert(i, extract);
      //            }
      //        }
      //        foreach (int i in indexesToremove)
      //            operands.RemoveAt(i);
      //    }
      //    return criteriaOperator;
      //}

      private void FormReport_Load(object sender, EventArgs e)
      {
      }

      private void btn_ShowReport_Click(object sender, EventArgs e)
      {
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

         string queryFilter = CriteriaToWhereClauseHelper.GetMsSqlWhere(filterControl_Outer.FilterCriteria);
         if (!string.IsNullOrEmpty(queryFilter))
            queryFilter = " where " + queryFilter;

         try
         {
            FormReportGrid myform = new FormReportGrid(qryMaster + queryFilter, dcReport);

            myform.MdiParent = this.MdiParent;
            myform.Show();
         }
         catch (Exception ex)
         {
            XtraMessageBox.Show(ex.ToString());
         }

         string filterCriteria = "";
         if (filterControl_Outer.FilterCriteria is not null)
            filterCriteria = filterControl_Outer.FilterCriteria.ToString();

         efMethods.UpdateDcReport_Filter(dcReport.ReportId, filterCriteria); //save filter to database
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

      Dictionary<string, object> Extract(CriteriaOperator op)
      {
         Dictionary<string, object> dict = new Dictionary<string, object>();
         GroupOperator opGroup = op as GroupOperator;
         if (ReferenceEquals(opGroup, null))
         {
            ExtractOne(dict, op);
         }
         else
         {
            if (opGroup.OperatorType == GroupOperatorType.And)
            {
               foreach (var opn in opGroup.Operands)
               {
                  ExtractOne(dict, opn);
               }
            }
         }
         return dict;
      }
      private void ExtractOne(Dictionary<string, object> dict, CriteriaOperator op)
      {
         BinaryOperator opBinary = op as BinaryOperator;
         if (ReferenceEquals(opBinary, null)) return;
         OperandProperty opProperty = opBinary.LeftOperand as OperandProperty;
         OperandValue opValue = opBinary.RightOperand as OperandValue;
         if (ReferenceEquals(opProperty, null) || ReferenceEquals(opValue, null)) return;
         dict.Add(opProperty.PropertyName, opValue.Value);
      }

      private void bBI_ReportEdit_ItemClick(object sender, ItemClickEventArgs e)
      {
         string qry = dcReport.ReportQuery;
         int id = dcReport.ReportId;

         FormReportEditor formQueryEditor = new FormReportEditor(id);
         if (formQueryEditor.ShowDialog(this) == DialogResult.OK)
         {
            dcReport.ReportQuery = formQueryEditor.dcReport.ReportQuery;
         }

      }

      private void bBI_ReportNew_ItemClick(object sender, ItemClickEventArgs e)
      {
         FormReportEditor formQueryEditor = new FormReportEditor(0);
         if (formQueryEditor.ShowDialog(this) == DialogResult.OK)
         {
         }
      }

      private void bBI_ReportDelete_ItemClick(object sender, ItemClickEventArgs e)
      {
         if (MessageBox.Show("Silmək İstəyirsiniz?", "Diqqət", MessageBoxButtons.OKCancel) == DialogResult.OK)
         {
            efMethods.DeleteReport(dcReport.ReportId);
         }
      }

      private void filterControl_Inner_CustomValueEditor(object sender, CustomValueEditorArgs e)
      {
         if (e.Node.FirstOperand.PropertyName == "Məhsul Kodu" || e.Node.FirstOperand.PropertyName == "ProductCode")
            e.RepositoryItem = repoBtnEdit_ProductCode;
         if (e.Node.FirstOperand.PropertyName == "Cari Hesab Kodu" || e.Node.FirstOperand.PropertyName == "CurrAccCode")
            e.RepositoryItem = repoBtnEdit_CurrAccCode;

         if (e.Value is not null && e.PropertyName is not null)
         {
            foreach (var item in dcReport.DcReportFilters)
            {
               efMethods.UpdateReportFilter(dcReport.ReportId, e.PropertyName, e.Value.ToString());
            }
            this.dcReport = efMethods.SelectReport(dcReport.ReportId); // reload dcReport
         }
      }

      private void filterControl_Outer_CustomValueEditor(object sender, CustomValueEditorArgs e)
      {
         if (e.Node.FirstOperand.PropertyName == "Məhsul Kodu" || e.Node.FirstOperand.PropertyName == "ProductCode")
            e.RepositoryItem = repoBtnEdit_ProductCode;
         if (e.Node.FirstOperand.PropertyName == "Cari Hesab Kodu" || e.Node.FirstOperand.PropertyName == "CurrAccCode")
            e.RepositoryItem = repoBtnEdit_CurrAccCode;
         if (e.Node.FirstOperand.PropertyName == "Mağaza Kodu" || e.Node.FirstOperand.PropertyName == "StoreCode")
            e.RepositoryItem = repoBtnEdit_StoreCode;
         if (e.Node.FirstOperand.PropertyName == "Kassa Kodu" || e.Node.FirstOperand.PropertyName == "CashRegisterCode")
            e.RepositoryItem = repoBtnEdit_CashRegisterCode;
      }

      private void repoBtnEdt_ButtonPressed(object sender, ButtonPressedEventArgs e)
      {
         SelectProduct(sender);
      }

      private void SelectProduct(object sender)
      {
         ButtonEdit editor = (ButtonEdit)sender;
         using (FormProductList form = new FormProductList(1))
         {
            if (form.ShowDialog(this) == DialogResult.OK)
            {
               editor.EditValue = form.dcProduct.ProductCode;
            }
         }
      }

      private void repobtnEdit_CurrAccCode_ButtonPressed(object sender, ButtonPressedEventArgs e)
      {
         SelectCurrAcc(sender, 0);
      }

      private void repobtnEdit_StoreCode_ButtonPressed(object sender, ButtonPressedEventArgs e)
      {
         SelectCurrAcc(sender, 4);
      }

      private void repobtnEdit_CashRegisterCode_ButtonPressed(object sender, ButtonPressedEventArgs e)
      {
         SelectCurrAcc(sender, 5);
      }

      private void SelectCurrAcc(object sender, byte currAccTypeCode)
      {
         ButtonEdit editor = (ButtonEdit)sender;
         using (FormCurrAccList form = new FormCurrAccList(currAccTypeCode))
         {
            if (form.ShowDialog(this) == DialogResult.OK)
            {
               editor.EditValue = form.dcCurrAcc.CurrAccCode;
            }
         }
      }

      // Prevent delete filter
      public class MyFilterControl : FilterControl
      {
         public MyFilterControl() : base() { }
         protected override BaseControlPainter CreatePainter()
         {
            return new MyFilterControlPainter(this);
         }

         protected override void RaisePopupMenuShowing(PopupMenuShowingEventArgs e)
         {
            base.RaisePopupMenuShowing(e);
            e.Cancel = true;
         }
      }

      public class MyFilterControlPainter : FilterControlPainter
      {
         public MyFilterControlPainter(FilterControl filterControl) : base(filterControl) { }

         protected override void DrawNodeLabel(Node node, ControlGraphicsInfoArgs info)
         {
            //base.DrawNodeLabel(node, info);
            if (Model[node] == null) return;
            Paint(Model[node], info);
         }

         public virtual void Paint(FilterControlLabelInfo labelInfo, ControlGraphicsInfoArgs info)
         {
            labelInfo.ViewInfo.Calculate(new GraphicsCache(info.Graphics));
            labelInfo.ViewInfo.TopLine = 0;
            for (int i = 0; i < labelInfo.ViewInfo.Count; i++)
            {
               NodeEditableElement elem = labelInfo.ViewInfo[i].InfoText.Tag as NodeEditableElement;
               if (elem == null || (elem.ElementType == ElementType.NodeAdd
                   || elem.ElementType == ElementType.NodeRemove
                   || elem.ElementType == ElementType.Group))
               {
                  labelInfo.ViewInfo[i].InfoText.Tag = null;
                  continue;
               }
               labelInfo.ViewInfo[i].ViewInfo.Calculate(new GraphicsCache(info.Graphics));
               labelInfo.ViewInfo[i].Draw(info.Cache, info.ViewInfo.Appearance.GetFont(), labelInfo.ViewInfo[i].InfoText.Color, info.ViewInfo.Appearance.GetStringFormat());
            }
         }

         public override void DrawFocusRectangle(ControlGraphicsInfoArgs info) { }
      }
   }
}
