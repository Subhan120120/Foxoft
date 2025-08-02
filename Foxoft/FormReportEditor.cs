using DevExpress.Mvvm.Native;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraLayout;
using DevExpress.XtraTab;
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
                                   .Include(x => x.TrReportSubQueries).ThenInclude(x => x.TrReportSubQueryRelationColumns)
                                   .Where(x => x.ReportId == dcReport.ReportId)
                                   .Load();

                dcReportsBindingSource.DataSource = dbContext.DcReports.Local.ToBindingList();

                dbContext.DcReportVariables.Where(x => x.ReportId == dcReport.ReportId)
                                   .Load();

                dcReportVariableBindingSource.DataSource = dbContext.DcReportVariables.Local.ToBindingList();
            }

            List<TrReportSubQuery> subQueries = dbContext.DcReports.Local
                         .SelectMany(r => r.TrReportSubQueries)
                         .ToList();

            foreach (TrReportSubQuery? subQuery in subQueries)
            {
                MemoEdit memoEdit = new();
                GridControl GC = new();
                GridView GV = new();
                LayoutControlGroup LCG = new();
                LayoutControl LC = new();
                BindingSource subQueryBindingSource = new();
                BindingSource relationColumnBindingSource = new();
                LayoutControlItem LCI_ME = new();
                LayoutControlItem LCI_GC = new();
                SplitterItem splitterItem = new();
                XtraTabPage xtraTabPage = new();
                GridColumn? colId = new();
                GridColumn? colParent = new();
                GridColumn? colSub = new();
                GridColumn? colSubQueryId = new();

                colId.FieldName = nameof(TrReportSubQueryRelationColumn.Id);
                colId.Caption = ReflectionExt.GetDisplayName<TrReportSubQueryRelationColumn>(x => x.Id);
                colParent.FieldName = nameof(TrReportSubQueryRelationColumn.ParentColumnName);
                colParent.Caption = ReflectionExt.GetDisplayName<TrReportSubQueryRelationColumn>(x => x.ParentColumnName);
                colParent.Visible = true;
                colSub.FieldName = nameof(TrReportSubQueryRelationColumn.SubColumnName);
                colSub.Caption = ReflectionExt.GetDisplayName<TrReportSubQueryRelationColumn>(x => x.SubColumnName);
                colSub.Visible = true;
                colSubQueryId.FieldName = nameof(TrReportSubQueryRelationColumn.SubQueryId);
                colSubQueryId.Caption = ReflectionExt.GetDisplayName<TrReportSubQueryRelationColumn>(x => x.SubQueryId);
                //colSubQueryId.Visible = true;

                subQueryBindingSource.DataSource = subQuery;

                memoEdit.Dock = DockStyle.Fill;
                memoEdit.Properties.WordWrap = false;
                memoEdit.Properties.ScrollBars = ScrollBars.Both;
                memoEdit.DataBindings.Add("EditValue", subQueryBindingSource, nameof(subQuery.SubQueryText), true, DataSourceUpdateMode.OnPropertyChanged);
                memoEdit.StyleController = layoutControl1;

                GC.MainView = GV;
                GC.ViewCollection.Add(GV);
                GC.DataSource = relationColumnBindingSource;

                relationColumnBindingSource.DataSource = typeof(TrReportSubQueryRelationColumn);
                relationColumnBindingSource.DataSource = dbContext.TrReportSubQueryRelationColumns.Local.ToBindingList();

                GV.GridControl = GC;
                GV.OptionsView.ShowGroupPanel = false;
                GV.Columns.AddRange(new GridColumn[] { colId, colParent, colSub, colSubQueryId });
                GV.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
                GV.OptionsBehavior.EditingMode = GridEditingMode.Inplace;
                GV.OptionsNavigation.AutoFocusNewRow = true;
                GV.OptionsView.NewItemRowPosition = NewItemRowPosition.Bottom;
                GV.ActiveFilterString = $"[{nameof(TrReportSubQueryRelationColumn.SubQueryId)}] = {subQuery.SubQueryId}"; GV.ActiveFilterString = $"[{nameof(TrReportSubQueryRelationColumn.SubQueryId)}] = {subQuery.SubQueryId}";
                GV.OptionsView.ShowFilterPanelMode = ShowFilterPanelMode.Never;
                GV.InitNewRow += (s, e) =>
                {
                    GV.SetRowCellValue(e.RowHandle, colSubQueryId, subQuery.SubQueryId);
                };
                GV.KeyDown += (s, e) =>
                {
                    if (e.KeyCode == Keys.Delete && GV != null && !GV.IsNewItemRow(GV.FocusedRowHandle))
                    {
                        if (MessageBox.Show("Sətir Silinsin?", "Təsdiqlə", MessageBoxButtons.YesNo) == DialogResult.Yes)
                            GV.DeleteSelectedRows();
                    }
                };

                LC.Controls.Add(memoEdit);
                LC.Controls.Add(GC);
                LC.Dock = DockStyle.Fill;
                LC.Root = LCG;

                LCI_GC.Control = GC;
                LCI_GC.TextVisible = false;
                LCI_GC.SizeConstraintsType = SizeConstraintsType.Custom;
                LCI_GC.MaxSize = new Size(1000, 100);

                LCI_ME.Control = memoEdit;
                LCI_ME.TextVisible = false;

                LCG.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
                LCG.GroupBordersVisible = false;
                LCG.TextVisible = false;

                LCG.AddItem(LCI_GC);
                LCG.AddItem(splitterItem);
                LCG.AddItem(LCI_ME);

                xtraTabPage.Name = subQuery.SubQueryName;
                xtraTabPage.Text = subQuery.SubQueryName;
                xtraTabPage.Tag = subQuery.SubQueryId;
                xtraTabPage.Controls.Add(LC);

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

        private void XtraTabControl1_SelectedPageChanged(object sender, TabPageChangedEventArgs e)
        {
            if (e.Page.Tag?.ToString() == "AddNew")
            {
                AddNewSubQueryTab();

                xtraTabControl1.SelectedTabPageIndex = xtraTabControl1.TabPages.Count - 2;
            }
        }

        void AddNewSubQueryTab()
        {
            TrReportSubQuery newSubQuery = new() { SubQueryName = "New SubQuery", SubQueryText = "-- SQL here" };

            DcReport? currentReport = dcReportsBindingSource.Current as DcReport;
            currentReport?.TrReportSubQueries.Add(newSubQuery);

            BindingSource? subQueryBinding = new() { DataSource = newSubQuery };

            MemoEdit? memoEdit = new() { Dock = DockStyle.Fill, EditValue = newSubQuery.SubQueryText };
            memoEdit.DataBindings.Add("EditValue", subQueryBinding, nameof(newSubQuery.SubQueryText), true, DataSourceUpdateMode.OnPropertyChanged);

            XtraTabPage newPage = new() { Text = newSubQuery.SubQueryName, Tag = newSubQuery.SubQueryId };
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
                    string query = reportClass.ApplyFilter(dcReport, dcReport.ReportQuery, null, out sqlParameters, 1);
                    DataTable dt = adoMethods.SqlGetDt(query, sqlParameters); // check query is correct 

                    DcReport? report = dcReportsBindingSource.Current as DcReport;
                    ICollection<TrReportSubQuery> subQueries = report.TrReportSubQueries;

                    foreach (TrReportSubQuery? subQuery in subQueries)
                    {
                        SqlParameter[] sqlParameters1;

                        subQuery.SubQueryText = reportClass.ApplyFilter(dcReport, subQuery.SubQueryText, null, out sqlParameters1, 1);

                        subQuery.SubQueryText = this.reportClass.AddRelation(query, subQuery);

                        DataTable dt2 = adoMethods.SqlGetDt(subQuery.SubQueryText, sqlParameters1); // check query is correct 
                    }

                    if (!efMethods.EntityExists<DcReport>(dcReport.ReportId)) //if doesnt exist
                        efMethods.InsertEntity(dcReport);
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

            if (MessageBox.Show($"Delete tab '{tabToClose.Text}'?", "Confirm Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                var subQueryId = tabToClose.Tag;

                var report = dcReportsBindingSource.Current as DcReport;
                if (report != null && subQueryId is int id)
                {
                    var subQuery = report.TrReportSubQueries.FirstOrDefault(sq => sq.SubQueryId == id);
                    if (subQuery != null)
                    {
                        if (dbContext.Entry(subQuery).State != EntityState.Added)
                        {
                            //dbContext.TrReportSubQueries.Remove(subQuery); // DB-dən sil
                            report.TrReportSubQueries.Remove(subQuery); // yaddaşdan sil
                        }
                        else
                            report.TrReportSubQueries.Remove(subQuery); // yaddaşdan sil
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
                    if (MessageBox.Show("Sətir Silinsin?", "Təsdiqlə", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        GV_ReportVariables.DeleteSelectedRows();
                }
            }
        }
    }
}
