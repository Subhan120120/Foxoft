using DevExpress.Utils.Extensions;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.DXErrorProvider;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraTab;
using Foxoft.AppCode;
using Foxoft.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Foxoft
{
    public partial class FormReportEditor : XtraForm
    {
        public DcReport dcReport = new();
        subContext dbContext = new();
        ReportClass reportClass = new();
        EfMethods efMethods = new();

        public FormReportEditor(int reportId)
        {
            this.dcReport.ReportId = reportId;

            InitializeComponent();

            CancelButton = btn_Cancel;
            AcceptButton = btn_Ok;

            ReportTypeIdLookUpEdit.Properties.DataSource = efMethods.SelectEntities<DcReportType>();
            ReportCategoryIdLookUpEdit.Properties.DataSource = efMethods.SelectEntities<DcReportCategory>();
            repoLUE_VariableType.DataSource = efMethods.SelectEntities<DcReportVariableType>();
            repoLUE_VariableValueType.DataSource = reportClass.VariableValueTypes;
            repoLUE_VariableOperator.DataSource = reportClass.VariableOperators;
        }

        private void FormQueryEditor_Load(object sender, EventArgs e)
        {
            FillDataLayout();
        }

        private void FillDataLayout()
        {
            if (!(dcReport.ReportId > 0))
                ClearControlsAddNew();
            else
            {
                dbContext.DcReports.Include(x => x.DcReportVariables)
                                   .Include(x => x.TrReportSubQueries)
                                   .Where(x => x.ReportId == dcReport.ReportId)
                                   .Load();

                dcReportsBindingSource.DataSource = dbContext.DcReports.Local.ToBindingList();

                dbContext.DcReportVariables.Where(x => x.ReportId == dcReport.ReportId)
                                   .Load();

                dcReportVariableBindingSource.DataSource = dbContext.DcReportVariables.Local.ToBindingList();
            }

            //xtraTabControl1.TabPages.Clear();

            List<TrReportSubQuery> subQueries = dbContext.DcReports.Local
                         .SelectMany(r => r.TrReportSubQueries)
                         .ToList();

            foreach (var subQuery in subQueries)
            {
                MemoEdit memoEdit = new();
                XtraTabPage xtraTabPage = new()
                {
                    Name = subQuery.SubQueryName,
                    Text = subQuery.SubQueryName,
                    Tag = subQuery.SubQueryId,
                };

                BindingSource subQueryBindingSource = new();
                subQueryBindingSource.DataSource = subQuery;

                memoEdit.Dock = DockStyle.Fill;
                memoEdit.Properties.WordWrap = false;
                memoEdit.Properties.ScrollBars = ScrollBars.Both;
                memoEdit.DataBindings.Add("EditValue", subQueryBindingSource, nameof(subQuery.SubQueryText), true, DataSourceUpdateMode.OnPropertyChanged);

                xtraTabPage.Controls.Add(memoEdit);
                xtraTabControl1.TabPages.Add(xtraTabPage);
            }

            XtraTabPage addTabPage = new()
            {
                Text = "+",
                Name = "tabAddNew",
                Tag = "AddNew"
            };

            xtraTabControl1.TabPages.Add(addTabPage);
            xtraTabControl1.SelectedPageChanged += XtraTabControl1_SelectedPageChanged;
        }

        private void XtraTabControl1_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            if (e.Page.Tag?.ToString() == "AddNew")
            {
                AddNewSubQueryTab();

                xtraTabControl1.SelectedTabPageIndex = xtraTabControl1.TabPages.Count - 2;
            }
        }

        void AddNewSubQueryTab()
        {
            TrReportSubQuery newSubQuery = new()
            {
                SubQueryName = "New SubQuery",
                SubQueryText = "-- SQL here"
            };

            DcReport? currentReport = dcReportsBindingSource.Current as DcReport;
            currentReport?.TrReportSubQueries.Add(newSubQuery);

            MemoEdit? memoEdit = new() { Dock = DockStyle.Fill, EditValue = newSubQuery.SubQueryText };
            XtraTabPage newPage = new()
            {
                Text = newSubQuery.SubQueryName,
                Tag = newSubQuery.SubQueryId
            };

            BindingSource? subQueryBinding = new() { DataSource = newSubQuery };
            memoEdit.DataBindings.Add("EditValue", subQueryBinding, nameof(newSubQuery.SubQueryText), true, DataSourceUpdateMode.OnPropertyChanged);

            newPage.Controls.Add(memoEdit);

            // Insert before "+" tab
            xtraTabControl1.TabPages.Insert(xtraTabControl1.TabPages.Count - 1, newPage);
        }


        private void ClearControlsAddNew()
        {
            dcReport = dcReportsBindingSource.AddNew() as DcReport;

            dcReportsBindingSource.DataSource = dcReport;
        }

        private void btn_Ok_Click(object sender, EventArgs e)
        {
            EfMethods efMethods = new();
            AdoMethods adoMethods = new();

            dcReport = dcReportsBindingSource.Current as DcReport;

            if (!String.IsNullOrEmpty(dcReport?.ReportQuery))
            {
                try
                {
                    SqlParameter[] sqlParameters;
                    string query = reportClass.ApplyFilter(dcReport, dcReport.ReportQuery, null, out sqlParameters);

                    DataTable dt = adoMethods.SqlGetDt(query, sqlParameters); // if query is correct 

                    if (!efMethods.EntityExists<DcReport>(dcReport.ReportId)) //if doesnt exist
                        efMethods.InsertEntity<DcReport>(dcReport);
                    else
                        dbContext.SaveChanges();

                    DialogResult = DialogResult.OK;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Foxoft Error Code: 1215451 ");
                }

            }
        }

        private void xtraTabControl1_CloseButtonClick(object sender, EventArgs e)
        {
            var args = e as DevExpress.XtraTab.ViewInfo.ClosePageButtonEventArgs;
            if (args == null) return;

            var tabToClose = args.Page as XtraTabPage;
            if (tabToClose?.Tag?.ToString() == "AddNew")
                return; // Don't allow closing the "+" tab

            // Confirm deletion
            if (MessageBox.Show($"Delete tab '{tabToClose.Text}'?", "Confirm Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                // Remove from EF collection if needed
                var subQueryId = tabToClose.Tag;

                var report = dcReportsBindingSource.Current as DcReport;
                if (report != null && subQueryId is int id)
                {
                    var subQuery = report.TrReportSubQueries.FirstOrDefault(sq => sq.SubQueryId == id);
                    if (subQuery != null)
                    {
                        if (dbContext.Entry(subQuery).State != EntityState.Added)
                            dbContext.TrReportSubQueries.Remove(subQuery); // DB-dən sil
                        else
                            report.TrReportSubQueries.Remove(subQuery); // Sadəcə yaddaşdan sil
                    }
                }

                xtraTabControl1.TabPages.Remove(tabToClose);
            }
        }

        private void gridView1_InitNewRow(object sender, InitNewRowEventArgs e)
        {
            GridView gv = sender as GridView;

            var newRow = (DcReportVariable)gv.GetRow(e.RowHandle);
            newRow.ReportId = dcReport.ReportId;
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            //if (e.Column == colVariableTypeId || e.Column == colVariableProperty)
            //{
            //    object variableTypeId = gridView1.GetFocusedRowCellValue(colVariableTypeId);
            //    object variableProperty = gridView1.GetFocusedRowCellValue(colVariableProperty);
            //    object operatorValue = gridView1.GetFocusedRowCellValue(colVariableOperator);

            //    if (variableProperty == null || variableTypeId == null)
            //        return;

            //    string variablePropertyStr = variableProperty.ToString();

            //    if (variableTypeId.ToString() == "1")
            //    {
            //        gridView1.SetFocusedRowCellValue(colRepresentative, "@" + variablePropertyStr);
            //        gridView1.SetFocusedRowCellValue(colVariableOperator, null);

            //        colVariableOperator.OptionsColumn.AllowEdit = false;

            //        gridView1.SetColumnError(colVariableOperator, "");
            //    }
            //    else if (variableTypeId.ToString() == "2")
            //    {
            //        gridView1.SetFocusedRowCellValue(colRepresentative, "{" + variablePropertyStr + "}");

            //        colVariableOperator.OptionsColumn.AllowEdit = true;

            //        if (operatorValue == null || string.IsNullOrWhiteSpace(operatorValue.ToString()))
            //        {
            //            gridView1.SetColumnError(colVariableOperator, "Boş buraxıla bilməz.");
            //        }
            //        else
            //        {
            //            gridView1.SetColumnError(colVariableOperator, "");
            //        }
            //    }
            //}

            //if (e.Column == colVariableOperator)
            //{
            //    object operatorValue = gridView1.GetFocusedRowCellValue(colVariableOperator);

            //    if (operatorValue != null && !string.IsNullOrWhiteSpace(operatorValue.ToString()))
            //    {
            //        gridView1.SetColumnError(colVariableOperator, "");
            //    }
            //}
        }

        private void gridView1_CustomRowCellEdit(object sender, CustomRowCellEditEventArgs e)
        {
            if (e.Column == colVariableOperator)
            {
                var typeId = Convert.ToInt32(GV_ReportVariables.GetFocusedRowCellValue(colVariableTypeId));
                var variableProperty = Convert.ToString(GV_ReportVariables.GetFocusedRowCellValue(colVariableProperty));

                if (typeId == 1)
                {
                    repoLUE_VariableOperator.ReadOnly = true;
                    GV_ReportVariables.SetFocusedRowCellValue(colVariableOperator, null);

                    if (!string.IsNullOrEmpty(variableProperty))
                        GV_ReportVariables.SetFocusedRowCellValue(colRepresentative, "@" + variableProperty);
                }
                else
                {
                    repoLUE_VariableOperator.ReadOnly = false;

                    if (!string.IsNullOrEmpty(variableProperty))
                        GV_ReportVariables.SetFocusedRowCellValue(colRepresentative, $"{{{variableProperty}}}");
                }

                //e.RepositoryItem = repoLUE_VariableOperator;
            }

            if (e.Column == colVariableValue)
            {
                var valueType = Convert.ToString(GV_ReportVariables.GetFocusedRowCellValue(colVariableValueType));
                if (valueType == "System.DateTime")
                    e.RepositoryItem = repoDateEdit_VariableValue;
                else
                    e.RepositoryItem = null;
            }
        }

        private void gridView1_ValidatingEditor(object sender, BaseContainerValidateEditorEventArgs e)
        {
            //GridView view = sender as GridView;

            //if (view.FocusedColumn == colVariableOperator)
            //{
            //    var typeId = Convert.ToInt32(view.GetFocusedRowCellValue(colVariableTypeId));

            //    if (typeId == 2) // Make required only if editable
            //    {
            //        if (e.Value == null || string.IsNullOrWhiteSpace(e.Value.ToString()))
            //        {
            //            e.Valid = false;
            //            e.ErrorText = "This field is required.";
            //        }
            //    }
            //}
        }

        private void gridView1_ValidateRow(object sender, ValidateRowEventArgs e)
        {
            GridView view = sender as GridView;
            var typeId = Convert.ToInt32(view.GetRowCellValue(e.RowHandle, colVariableTypeId));
            var opValue = view.GetRowCellValue(e.RowHandle, colVariableOperator);

            if (typeId == 2 && (opValue == null || string.IsNullOrWhiteSpace(opValue.ToString())))
            {
                e.Valid = false;
                view.SetColumnError(colVariableOperator, "This field is required.");
            }
            else
            {
                view.SetColumnError(colVariableOperator, null); // clear error
            }
        }

        private void DcReportVariablesGridControl_KeyDown(object sender, KeyEventArgs e)
        {
            if (GV_ReportVariables.SelectedRowsCount > 0)
            {
                if (e.KeyCode == Keys.Delete && GV_ReportVariables.ActiveEditor == null)
                {
                    if (MessageBox.Show("Sətir Silinsin?", "Təsdiqlə", MessageBoxButtons.YesNo) != DialogResult.Yes)
                        return;

                    GV_ReportVariables.DeleteSelectedRows();
                }
            }
        }
    }
}
