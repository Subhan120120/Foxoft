using DevExpress.Data.Filtering;
using DevExpress.Data.Filtering.Helpers;
using DevExpress.DataAccess.Excel;
using DevExpress.Utils.Svg;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Filtering;
using Foxoft.AppCode;
using Foxoft.Models;
using Foxoft.Properties;
using Microsoft.Data.SqlClient;
using Microsoft.VisualBasic;
using System.Collections;
using System.ComponentModel;
using System.Data;

namespace Foxoft
{
    public partial class FormReportFilter : RibbonForm
    {
        readonly SettingStore settingStore;
        EfMethods efMethods = new();
        AdoMethods adoMethods = new();
        CustomMethods cM = new();
        DcReport dcReport = new();

        public FormReportFilter(DcReport Report)
        {
            InitializeComponent();

            settingStore = efMethods.SelectSettingStore(Authorization.StoreCode);

            if (settingStore is not null)
                if (CustomExtensions.DirectoryExist(settingStore.ImageFolder))
                    AppDomain.CurrentDomain.SetData("DXResourceDirectory", settingStore.ImageFolder);

            SvgBitmap bm = new(svgImageCollection1["xls"]);
            Image img = bm.Render(null, 0.5);
            filterControl_Outer.MyIcon = img;
            filterControl_Outer.ExcelButtonClick += new ExcelButtonFilterControl.ExcelButtonEventHandler(this.ExcelButtonFilterControl_ExcelButtonClick);

            WindowsFormsSettings.FilterCriteriaDisplayStyle = FilterCriteriaDisplayStyle.Text;
            AcceptButton = btn_ShowReport;

            this.dcReport = efMethods.SelectReport(Report.ReportId); // reload dcReport
            this.Text = Report.ReportName;

            SqlParameter[] sqlParameters;
            string qry = cM.ApplyFilter(dcReport, dcReport.ReportQuery, null, out sqlParameters, 1);

            filterControl_Outer.SourceControl = adoMethods.SqlGetDt(qry, sqlParameters);
            filterControl_Outer.FilterString = dcReport.ReportFilter;

            filterControl_Inner.SourceControl = GetColumnsFromDatabase(dcReport.DcReportVariables); //For Column Types
            filterControl_Inner.FilterCriteria = GetFiltersFromDatabase(dcReport.DcReportVariables);

            LUE_ReportCustomization.Properties.DataSource = efMethods.SelectReportCustomizationByCurrAcc(dcReport.ReportId ,Authorization.CurrAccCode);
            LUE_ReportCustomization.EditValue = Settings.Default.TrReportCustomizations.FirstOrDefault(x => x.ReportId == dcReport.ReportId && x.CurrAccCode == Authorization.CurrAccCode)?.ReportCustomizationId;
        }

        private DataTable opToDt(GroupOperator groupOperand)
        {
            DataTable dt = new();
            dt.Clear();
            Dictionary<string, object> keyValuePairs = Extract(groupOperand);
            foreach (var item in keyValuePairs)
                dt.Columns.Add(item.Key);

            return dt;
        }

        private DataTable GetColumnsFromDatabase(ICollection<DcReportVariable> dcReportVariables)
        {
            DataTable dt = new();
            dt.Clear();

            foreach (DcReportVariable rf in dcReportVariables)
                dt.Columns.Add(rf.VariableProperty, Type.GetType(rf.VariableValueType));

            return dt;
        }

        private GroupOperator GetFiltersFromDatabase(ICollection<DcReportVariable> dcReportVariables)
        {
            GroupOperator groupOperand = new();

            foreach (DcReportVariable rf in dcReportVariables)
            {
                BinaryOperatorType operatorType = ConvertOperatorType(rf.VariableOperator);

                object value = Convert.ChangeType(rf.VariableValue, Type.GetType(rf.VariableValueType));

                CriteriaOperator op = new BinaryOperator(rf.VariableProperty, value, operatorType);

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
            //CriteriaOperator groupOperator = new GroupOperator(GroupOperatorType.And, criteriaOperators);

            string filter = CriteriaToWhereClauseHelper.GetMsSqlWhere(filterControl_Outer.FilterCriteria);

            switch (dcReport.ReportTypeId)
            {
                case 1: OpenGridReport(dcReport.ReportQuery, filter); break;
                case 2: OpenDetailReport(dcReport.ReportQuery, filter); break;
                default: OpenGridReport(dcReport.ReportQuery, filter); break;
            }

            SaveOuterFilterToDB();
        }

        private void SaveOuterFilterToDB()
        {
            string filterCriteria = "";
            if (filterControl_Outer.FilterCriteria is not null)
                filterCriteria = filterControl_Outer.FilterCriteria.ToString();

            efMethods.UpdateDcReport_Filter(dcReport.ReportId, filterCriteria); //save filter to database
        }

        private void OpenGridReport(string qry, string filter)
        {
            try
            {
                FormReportGrid myform = new(qry, filter, dcReport);

                myform.MdiParent = this.MdiParent;
                myform.Show();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString());
            }
        }

        private void OpenDetailReport(string qry, string filter)
        {
            if (!string.IsNullOrEmpty(qry))
            {
                FormReportPreview frm = new(qry, filter, dcReport);
                frm.MdiParent = this.ParentForm;
                frm.Show();
                frm.WindowState = FormWindowState.Maximized;
                //this.ParentForm.parentRibbonControl.SelectedPage = parentRibbonControl.MergedPages[0];
            }
        }

        private BarButtonItem CreateItem()
        {
            BarButtonItem item = new();
            item.ItemClick += item_ItemClick;
            item.Caption = "Get Help";
            return item;
        }

        void item_ItemClick(object sender, ItemClickEventArgs e)
        {
            MessageBox.Show("Item clicked");
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

        Dictionary<string, object> Extract(CriteriaOperator op)
        {
            Dictionary<string, object> dict = new();
            GroupOperator opGroup = op as GroupOperator;

            if (ReferenceEquals(opGroup, null))
                ExtractOne(dict, op);
            else
            {
                if (opGroup.OperatorType == GroupOperatorType.And)
                    foreach (var opn in opGroup.Operands)
                        ExtractOne(dict, opn);
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
            int id = dcReport.ReportId;

            FormReportEditor formQueryEditor = new(id);

            if (formQueryEditor.ShowDialog(this) == DialogResult.OK)
                dcReport.ReportQuery = formQueryEditor.dcReport.ReportQuery;
        }

        private void bBI_ReportNew_ItemClick(object sender, ItemClickEventArgs e)
        {
            FormReportEditor formQueryEditor = new(0);
            if (formQueryEditor.ShowDialog(this) == DialogResult.OK)
            {
            }
        }

        private void bBI_ReportDelete_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (MessageBox.Show("Silmək İstəyirsiniz?", "Diqqət", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                efMethods.DeleteEntityById<DcReport>(dcReport.ReportId);
            }
        }

        private void filterControl_Inner_CustomValueEditor(object sender, CustomValueEditorArgs e)
        {
            e.InitFilterRepositoryItems(this);

            if (e.Value is not null && e.PropertyName is not null)
            {
                foreach (var item in dcReport.DcReportVariables)
                {
                    efMethods.UpdateReportVariableValue(dcReport.ReportId, e.PropertyName, e.Value.ToString());
                }

                this.dcReport = efMethods.SelectReport(dcReport.ReportId); // reload dcReport
            }
        }

        private void filterControl_Outer_CustomValueEditor(object sender, CustomValueEditorArgs e)
        {
            e.InitFilterRepositoryItems(this);
        }

        private void ExcelButtonFilterControl_ExcelButtonClick(object sender, ExcelButtonEventArgs e)
        {
            OpenFileDialog dialog = new();
            dialog.Filter = "Excel Files (*.xls;*.xlsx)|*.xls;*.xlsx|" +
                            "All files (*.*)|*.*";
            dialog.Title = "Yalnız ilk sütünda olan məlumatlar daxil edilir.";

            DialogResult dr = dialog.ShowDialog();
            if (dr == DialogResult.OK)
            {
                ExcelDataSource excelDataSource = new();
                excelDataSource.FileName = dialog.FileName;

                ExcelWorksheetSettings excelWorksheetSettings = new(0, "A1:A10000");
                //excelWorksheetSettings.WorksheetName = "10QK";

                ExcelSourceOptions excelOptions = new();
                excelOptions.ImportSettings = excelWorksheetSettings;
                excelOptions.SkipHiddenRows = false;
                excelOptions.SkipHiddenColumns = false;
                excelOptions.UseFirstRowAsHeader = true;
                excelDataSource.SourceOptions = excelOptions;

                excelDataSource.Fill();

                DataTable dt = new();
                dt = ToDataTableFromExcelDataSource(excelDataSource);

                ClauseNode clauseNode = (ClauseNode)e.LabelInfo.Owner;

                if (clauseNode.Operation == ClauseType.AnyOf || clauseNode.Operation == ClauseType.NoneOf)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        clauseNode.AdditionalOperands.Add(row[0].ToString());
                    }
                }
            }
        }

        public DataTable ToDataTableFromExcelDataSource(ExcelDataSource excelDataSource)
        {
            IList list = ((IListSource)excelDataSource).GetList();
            DevExpress.DataAccess.Native.Excel.DataView dataView = (DevExpress.DataAccess.Native.Excel.DataView)list;
            List<PropertyDescriptor> props = dataView.Columns.ToList<PropertyDescriptor>();

            DataTable table = new();
            for (int i = 0; i < props.Count; i++)
            {
                PropertyDescriptor prop = props[i];
                table.Columns.Add(prop.Name, prop.PropertyType);
            }
            object[] values = new object[props.Count];
            foreach (DevExpress.DataAccess.Native.Excel.ViewRow item in list)
            {
                for (int i = 0; i < values.Length; i++)
                {
                    values[i] = props[i].GetValue(item);
                }
                table.Rows.Add(values);
            }
            return table;
        }

        private void BBI_ReportCustomAdd_ItemClick(object sender, ItemClickEventArgs e)
        {
            String name = Interaction.InputBox("Dizayn Adını daxil edin", "Diqqət");

            string filterCriteria = filterControl_Outer?.FilterCriteria?.ToString();

            var entity = efMethods.InsertEntity<TrReportCustomization>(new TrReportCustomization()
            {
                CurrAccCode = Authorization.CurrAccCode,
                ReportCustomizationDesc = name,
                ReportDesignFileName = BtnEdit_DesignFileFullPath.EditValue?.ToString(),
                ReportFilter = filterCriteria,
                ReportId = dcReport.ReportId
            });

            List<TrReportCustomization> dataSource = (List<TrReportCustomization>)LUE_ReportCustomization.Properties.DataSource;

            dataSource.Add(entity);

            LUE_ReportCustomization.Properties.DataSource = dataSource;
            LUE_ReportCustomization.Refresh();
        }

        private void BBI_ReportCustomDelete_ItemClick(object sender, ItemClickEventArgs e)
        {
            TrReportCustomization selectedEntity = LUE_ReportCustomization.GetSelectedDataRow() as TrReportCustomization;

            if (selectedEntity != null)
            {
                var dataSource = LUE_ReportCustomization.Properties.DataSource as List<TrReportCustomization>;

                if (dataSource != null)
                {
                    dataSource.Remove(selectedEntity);

                    LUE_ReportCustomization.Refresh();
                }

                efMethods.DeleteEntity<TrReportCustomization>(selectedEntity);
            }
            else
            {
                MessageBox.Show("Please select a customization to delete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BBI_ReportCustomSave_ItemClick(object sender, ItemClickEventArgs e)
        {
            TrReportCustomization selectedEntity = LUE_ReportCustomization.GetSelectedDataRow() as TrReportCustomization;

            selectedEntity.ReportFilter = filterControl_Outer?.FilterCriteria?.ToString();
            selectedEntity.ReportDesignFileName = BtnEdit_DesignFileFullPath.EditValue?.ToString();

            efMethods.UpdateEntity<TrReportCustomization>(selectedEntity);
        }

        private void LUE_ReportCustomization_EditValueChanged(object sender, EventArgs e)
        {
            LookUpEdit lookUpEdit = (LookUpEdit)sender;

            int ina = Convert.ToInt32(lookUpEdit?.EditValue);
            TrReportCustomization entity = efMethods.SelectEntityById<TrReportCustomization>(ina);
            BtnEdit_DesignFileFullPath.EditValue = entity.ReportDesignFileName;
            filterControl_Outer.FilterString = entity.ReportFilter;

            var asd = Settings.Default.TrReportCustomizations.ToList();

            asd.RemoveAll(x => x.ReportId == dcReport.ReportId);
            asd.Add(entity);

            Settings.Default.TrReportCustomizations = asd;
        }
    }

    public class TypedProperty<T> : Property where T : IConvertible
    {
        public T TypedValue
        {
            get { return (T)Convert.ChangeType(base.Value, typeof(T)); }
            set { base.Value = value.ToString(); }
        }
    }

    public class Property
    {
        public string Value { get; set; }
    }
}
