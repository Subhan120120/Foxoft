using DevExpress.Data.Filtering;
using DevExpress.Data.Filtering.Helpers;
using DevExpress.DataAccess.Excel;
using DevExpress.DataAccess.Sql;
using DevExpress.Utils.Svg;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Filtering;
using DevExpress.XtraReports.UI;
using DevExpress.XtraReports.UserDesigner;
using Foxoft.AppCode;
using Foxoft.Models;
using Foxoft.Models.Entity.Report;
using Foxoft.Properties;
using Microsoft.Data.SqlClient;
using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Foxoft
{
    public partial class FormReportFilter : RibbonForm
    {
        readonly SettingStore settingStore;
        EfMethods efMethods = new();
        AdoMethods adoMethods = new();
        ReportClass reportClass = new();
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
            string qry = reportClass.ApplyFilter(dcReport, dcReport.ReportQuery, null, out sqlParameters, 1);

            filterControl_Outer.SourceControl = adoMethods.SqlGetDt(qry, sqlParameters);

            filterControl_Inner.SourceControl = GetColumnsFromDatabase(dcReport.DcReportVariables); //For Column Types
            filterControl_Inner.FilterCriteria = GetFiltersFromDatabase(dcReport.DcReportVariables);

            var customizations = efMethods.SelectReportCustomizationByCurrAcc(dcReport.ReportId, Authorization.CurrAccCode);
            LUE_ReportCustomization.Properties.DataSource = customizations;

            int? savedCustomizationId = Settings.Default.TrReportCustomizations?
                .FirstOrDefault(x => x.ReportId == dcReport.ReportId && x.CurrAccCode == Authorization.CurrAccCode)?
                .ReportCustomizationId;

            if (savedCustomizationId.HasValue && customizations.Any(x => x.ReportCustomizationId == savedCustomizationId.Value))
            {
                LUE_ReportCustomization.EditValue = savedCustomizationId.Value;
            }
            else if (customizations.Count > 0)
            {
                LUE_ReportCustomization.EditValue = customizations[0].ReportCustomizationId;
            }
            else
            {
                BtnEdit_DesignFileFullPath.EditValue = dcReport.ReportName + ".repx";
                ApplyOuterFilter(dcReport.ReportFilter);
            }
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

                Type targetType = Type.GetType(rf.VariableValueType);
                string rawValue = rf.VariableValue;

                object value = targetType == typeof(Guid)
                    ? Guid.Parse(rawValue)
                    : Convert.ChangeType(rawValue, targetType);

                CriteriaOperator op = new BinaryOperator(rf.VariableProperty, value, operatorType);

                groupOperand.Operands.Add(op);
            }

            return groupOperand;
        }

        private void FormReport_Load(object sender, EventArgs e)
        {
        }

        private void btn_ShowReport_Click(object sender, EventArgs e)
        {
            filterControl_Outer.ApplyFilter();

            string filter = CriteriaToWhereClauseHelper.GetMsSqlWhere(filterControl_Outer.FilterCriteria);

            switch (dcReport.ReportTypeId)
            {
                case 1:
                    OpenGridReport(dcReport.ReportQuery, filter);
                    break;
                case 2:
                    OpenDetailReport(dcReport.ReportQuery, filter);
                    break;
                default:
                    OpenGridReport(dcReport.ReportQuery, filter);
                    break;
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
                XtraMessageBox.Show(
                    string.Format(Resources.Form_ReportFilter_Error_OpenGridReport, ex),
                    Resources.Common_ErrorTitle);
            }
        }

        private void OpenDetailReport(string qry, string filter)
        {
            if (!string.IsNullOrEmpty(qry))
            {
                string designFileName = BtnEdit_DesignFileFullPath.EditValue?.ToString();
                FormReportPreview frm = new(qry, filter, dcReport, designFileName);
                frm.MdiParent = this.ParentForm;
                frm.Show();
                frm.WindowState = FormWindowState.Maximized;
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

        private void bBI_ReportDelete_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (MessageBox.Show(
                    Resources.Common_DeleteConfirm,
                    Resources.Common_Attention,
                    MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                efMethods.DeleteEntityById<DcReport>(dcReport.ReportId);
            }
        }

        private void filterControl_Inner_CustomValueEditor(object sender, CustomValueEditorArgs e)
        {
            e.InitFilterRepositoryItems();

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
            e.InitFilterRepositoryItems();
        }

        private void ExcelButtonFilterControl_ExcelButtonClick(object sender, ExcelButtonEventArgs e)
        {
            OpenFileDialog dialog = new();
            dialog.Filter = Resources.Form_ReportFilter_ExcelDialogFilter;
            dialog.Title = Resources.Form_ReportFilter_ExcelDialogTitle;

            DialogResult dr = dialog.ShowDialog();
            if (dr == DialogResult.OK)
            {
                ExcelDataSource excelDataSource = new();
                excelDataSource.FileName = dialog.FileName;

                ExcelWorksheetSettings excelWorksheetSettings = new(0, "A1:A10000");

                ExcelSourceOptions excelOptions = new();
                excelOptions.ImportSettings = excelWorksheetSettings;
                excelOptions.SkipHiddenRows = false;
                excelOptions.SkipHiddenColumns = false;
                excelOptions.UseFirstRowAsHeader = true;
                excelDataSource.SourceOptions = excelOptions;

                excelDataSource.Fill();

                DataTable dt = ToDataTableFromExcelDataSource(excelDataSource);

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

        private void BtnEdit_DesignFileFullPath_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            using OpenFileDialog dialog = new();
            dialog.Title = Resources.Form_ReportFilter_DesignSelectFile;
            dialog.Filter = Resources.Form_ReportFilter_DesignFileFilter;

            string folder = GetDesignFolder();
            if (!string.IsNullOrEmpty(folder) && Directory.Exists(folder))
                dialog.InitialDirectory = folder;

            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                string selectedPath = dialog.FileName;
                if (!string.IsNullOrEmpty(folder) && selectedPath.StartsWith(folder, StringComparison.OrdinalIgnoreCase))
                {
                    string relative = selectedPath.Substring(folder.Length).TrimStart(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar);
                    BtnEdit_DesignFileFullPath.EditValue = relative;
                }
                else
                {
                    BtnEdit_DesignFileFullPath.EditValue = selectedPath;
                }

                TrReportCustomization selectedEntity =
                    LUE_ReportCustomization.GetSelectedDataRow() as TrReportCustomization;

                if (selectedEntity != null)
                {
                    selectedEntity.ReportDesignFileName = BtnEdit_DesignFileFullPath.EditValue?.ToString();
                    efMethods.UpdateEntity(selectedEntity);
                }
            }
        }

        private void BBI_ReportCustomAdd_ItemClick(object sender, ItemClickEventArgs e)
        {
            string name = Interaction.InputBox(
                Resources.Form_ReportFilter_Input_DesignName,
                Resources.Common_Attention);

            if (string.IsNullOrWhiteSpace(name))
                return;

            name = name.Trim();

            string sanitized = string.Join("_", name.Split(Path.GetInvalidFileNameChars()));
            string newFileName = $"{dcReport.ReportName}_{sanitized}.repx";

            string folder = GetDesignFolder();
            string targetFilePath = Path.Combine(folder, newFileName);
            string baseFilePath = Path.Combine(folder, dcReport.ReportName + ".repx");

            try
            {
                if (!File.Exists(targetFilePath))
                {
                    if (File.Exists(baseFilePath))
                    {
                        File.Copy(baseFilePath, targetFilePath, true);
                    }
                    else
                    {
                        using XtraReport initialReport = new();
                        initialReport.SaveLayoutToXml(targetFilePath);
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, Resources.Common_Attention, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            filterControl_Outer.ApplyFilter();
            string filterCriteria = filterControl_Outer.FilterCriteria?.ToString() ?? filterControl_Outer.FilterString;

            var entity = efMethods.InsertEntity<TrReportCustomization>(new TrReportCustomization()
            {
                CurrAccCode = Authorization.CurrAccCode,
                ReportCustomizationDesc = name,
                ReportDesignFileName = newFileName,
                ReportFilter = filterCriteria,
                ReportId = dcReport.ReportId
            });

            var dataSource = efMethods.SelectReportCustomizationByCurrAcc(dcReport.ReportId, Authorization.CurrAccCode);
            LUE_ReportCustomization.Properties.DataSource = dataSource;
            LUE_ReportCustomization.EditValue = entity.ReportCustomizationId;

            if (XtraMessageBox.Show(
                    Resources.Form_ReportFilter_Prompt_OpenDesignerNow,
                    Resources.Common_Attention,
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.Yes)
            {
                OpenReportDesigner(newFileName);
            }
        }

        private void BBI_ReportCustomEdit_ItemClick(object sender, ItemClickEventArgs e)
        {
            string designFileName = BtnEdit_DesignFileFullPath.EditValue?.ToString();
            if (string.IsNullOrWhiteSpace(designFileName))
                designFileName = dcReport.ReportName + ".repx";

            OpenReportDesigner(designFileName);
        }

        private void OpenReportDesigner(string designFileName)
        {
            try
            {
                string folder = GetDesignFolder();
                string fullPath = Path.IsPathRooted(designFileName)
                    ? designFileName
                    : Path.Combine(folder, designFileName);

                string filter = CriteriaToWhereClauseHelper.GetMsSqlWhere(filterControl_Outer.FilterCriteria);
                SqlParameter[] sqlParameters;
                string query = reportClass.ApplyFilter(dcReport, dcReport.ReportQuery, filter, out sqlParameters);
                List<QueryParameter> qryParams = reportClass.ConvertSqlParametersToQueryParameters(sqlParameters);

                CustomSqlQuery mainQuery = new("Main", query);
                mainQuery.Parameters.AddRange(qryParams);

                List<CustomSqlQuery> sqlQueries = new(new[] { mainQuery });

                foreach (TrReportSubQuery reportSubQuery in dcReport.TrReportSubQueries)
                {
                    SqlParameter[] sqlParameters1;
                    string subQueryText = reportClass.ApplyFilter(dcReport, reportSubQuery.SubQueryText, null, out sqlParameters1);
                    subQueryText = reportClass.AddRelation(query, reportSubQuery, subQueryText);

                    List<QueryParameter> subQryParams = reportClass.ConvertSqlParametersToQueryParameters(sqlParameters1);
                    CustomSqlQuery subQuery = new(reportSubQuery.SubQueryName, subQueryText);
                    subQuery.Parameters.AddRange(subQryParams);

                    sqlQueries.Add(subQuery);
                }

                if (!File.Exists(fullPath))
                {
                    string baseFilePath = Path.Combine(folder, dcReport.ReportName + ".repx");
                    if (File.Exists(baseFilePath))
                    {
                        File.Copy(baseFilePath, fullPath, true);
                    }
                    else
                    {
                        using XtraReport initialReport = new();
                        initialReport.SaveLayoutToXml(fullPath);
                    }
                }

                ReportClass reportCls = new(folder);
                XtraReport xReport = reportCls.GetReport(dcReport.ReportName, designFileName, sqlQueries);

                if (xReport is null)
                {
                    XtraMessageBox.Show(Resources.Common_Error, Resources.Common_Attention, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                using (XRDesignRibbonForm formDesignRibbon = new())
                {
                    formDesignRibbon.DesignMdiController.DesignPanelLoaded += (s, args) =>
                    {
                        XRDesignPanel panel = (XRDesignPanel)s;
                        panel.AddCommandHandler(new RepxSaveCommandHandler(panel, fullPath));
                    };

                    formDesignRibbon.OpenReport(xReport);
                    formDesignRibbon.ShowDialog(this);
                }

                BtnEdit_DesignFileFullPath.EditValue = designFileName;

                TrReportCustomization selectedEntity =
                    LUE_ReportCustomization.GetSelectedDataRow() as TrReportCustomization;

                if (selectedEntity != null)
                {
                    selectedEntity.ReportDesignFileName = designFileName;
                    efMethods.UpdateEntity(selectedEntity);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, Resources.Common_Attention, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string GetDesignFolder()
        {
            string folder = settingStore?.DesignFileFolder;
            if (string.IsNullOrWhiteSpace(folder))
                folder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Design Files");

            if (!Directory.Exists(folder))
            {
                try { Directory.CreateDirectory(folder); } catch { }
            }

            return folder;
        }

        private void BBI_ReportCustomDelete_ItemClick(object sender, ItemClickEventArgs e)
        {
            TrReportCustomization selectedEntity =
                LUE_ReportCustomization.GetSelectedDataRow() as TrReportCustomization;

            if (selectedEntity != null)
            {
                if (XtraMessageBox.Show(
                        Resources.Common_DeleteConfirm,
                        Resources.Common_Attention,
                        MessageBoxButtons.OKCancel,
                        MessageBoxIcon.Question) != DialogResult.OK)
                    return;

                efMethods.DeleteEntity(selectedEntity);

                var savedList = Settings.Default.TrReportCustomizations?.ToList() ?? new List<TrReportCustomization>();
                savedList.RemoveAll(x => x.ReportCustomizationId == selectedEntity.ReportCustomizationId || (x.ReportId == dcReport.ReportId && x.CurrAccCode == Authorization.CurrAccCode));
                Settings.Default.TrReportCustomizations = savedList;
                Settings.Default.Save();

                var list = efMethods.SelectReportCustomizationByCurrAcc(dcReport.ReportId, Authorization.CurrAccCode);
                LUE_ReportCustomization.Properties.DataSource = list;

                if (list.Count > 0)
                {
                    LUE_ReportCustomization.EditValue = list[0].ReportCustomizationId;
                }
                else
                {
                    LUE_ReportCustomization.EditValue = null;
                    BtnEdit_DesignFileFullPath.EditValue = dcReport.ReportName + ".repx";
                    ApplyOuterFilter(dcReport.ReportFilter);
                }
            }
            else
            {
                XtraMessageBox.Show(
                    Resources.Form_ReportFilter_Message_NoCustomizationSelected,
                    Resources.Form_ReportFilter_Message_NoCustomizationSelectedTitle,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        private void BBI_ReportCustomSave_ItemClick(object sender, ItemClickEventArgs e)
        {
            filterControl_Outer.ApplyFilter();

            TrReportCustomization selectedEntity =
                LUE_ReportCustomization.GetSelectedDataRow() as TrReportCustomization;

            if (selectedEntity == null)
            {
                XtraMessageBox.Show(
                    Resources.Form_ReportFilter_Message_NoCustomizationSelected,
                    Resources.Form_ReportFilter_Message_NoCustomizationSelectedTitle,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            string filterCriteria = filterControl_Outer.FilterCriteria?.ToString() ?? filterControl_Outer.FilterString;
            selectedEntity.ReportFilter = filterCriteria;
            selectedEntity.ReportDesignFileName = BtnEdit_DesignFileFullPath.EditValue?.ToString();

            efMethods.UpdateEntity(selectedEntity);

            var savedList = Settings.Default.TrReportCustomizations?.ToList() ?? new List<TrReportCustomization>();
            savedList.RemoveAll(x => x.ReportId == dcReport.ReportId && x.CurrAccCode == Authorization.CurrAccCode);
            savedList.Add(selectedEntity);
            Settings.Default.TrReportCustomizations = savedList;
            Settings.Default.Save();

            XtraMessageBox.Show(
                Resources.Common_SavedSuccessfully,
                Resources.Common_Attention,
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void LUE_ReportCustomization_EditValueChanged(object sender, EventArgs e)
        {
            LookUpEdit lookUpEdit = (LookUpEdit)sender;
            if (lookUpEdit?.EditValue == null || lookUpEdit.EditValue == DBNull.Value)
                return;

            int id = Convert.ToInt32(lookUpEdit.EditValue);
            if (id <= 0)
                return;

            TrReportCustomization entity = lookUpEdit.GetSelectedDataRow() as TrReportCustomization
                                           ?? efMethods.SelectEntityById<TrReportCustomization>(id);
            if (entity == null)
                return;

            BtnEdit_DesignFileFullPath.EditValue = string.IsNullOrWhiteSpace(entity.ReportDesignFileName)
                ? dcReport.ReportName + ".repx"
                : entity.ReportDesignFileName;

            ApplyOuterFilter(entity.ReportFilter);

            var savedList = Settings.Default.TrReportCustomizations?.ToList() ?? new List<TrReportCustomization>();
            savedList.RemoveAll(x => x.ReportId == dcReport.ReportId && x.CurrAccCode == Authorization.CurrAccCode);
            savedList.Add(entity);

            Settings.Default.TrReportCustomizations = savedList;
            Settings.Default.Save();
        }

        private void ApplyOuterFilter(string filterString)
        {
            if (string.IsNullOrWhiteSpace(filterString))
            {
                filterControl_Outer.FilterCriteria = null;
                filterControl_Outer.FilterString = string.Empty;
            }
            else
            {
                try
                {
                    CriteriaOperator op = CriteriaOperator.Parse(filterString);
                    filterControl_Outer.FilterCriteria = op;
                }
                catch
                {
                    filterControl_Outer.FilterString = filterString;
                }
            }
        }

        private void bBI_FilterExportExcel_ItemClick(object sender, ItemClickEventArgs e)
        {
            FilterExcelHelper.ExportEntireFilterToExcel(filterControl_Outer, this);
        }

        private void bBI_FilterImportExcel_ItemClick(object sender, ItemClickEventArgs e)
        {
            FilterExcelHelper.ImportEntireFilterFromExcel(filterControl_Outer, this);
        }
    }
}
