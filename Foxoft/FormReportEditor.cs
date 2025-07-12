using DevExpress.Utils.Extensions;
using DevExpress.XtraEditors;
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
        CustomMethods cM = new();
        EfMethods efMethods = new();

        public FormReportEditor(int reportId)
        {
            this.dcReport.ReportId = reportId;

            InitializeComponent();

            CancelButton = btn_Cancel;
            AcceptButton = btn_Ok;

            ReportTypeIdLookUpEdit.Properties.DataSource = efMethods.SelectEntities<DcReportType>();
            ReportTypeIdLookUpEdit.Properties.ValueMember = "ReportTypeId";
            ReportTypeIdLookUpEdit.Properties.DisplayMember = "ReportTypeDesc";

            ReportCategoryIdLookUpEdit.Properties.DataSource = efMethods.SelectEntities<DcReportCategory>();
            ReportCategoryIdLookUpEdit.Properties.ValueMember = "ReportCategoryId";
            ReportCategoryIdLookUpEdit.Properties.DisplayMember = "ReportCategoryDesc";


            repoLUE_VariableType.DataSource = efMethods.SelectEntities<DcReportVariableType>();.;
            repoLUE_VariableValueType.DataSource = efMethods.SelectEntities<DcInstallmentPlan>();
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
                // Create new tab page and memo editor
                MemoEdit memoEdit = new();
                XtraTabPage xtraTabPage = new()
                {
                    Name = subQuery.SubQueryName,
                    Text = subQuery.SubQueryName,
                    Tag = subQuery.SubQueryId
                };

                // Bind to a new BindingSource for each subquery
                BindingSource subQueryBindingSource = new();
                subQueryBindingSource.DataSource = subQuery;

                memoEdit.Dock = DockStyle.Fill;
                memoEdit.DataBindings.Add("EditValue", subQueryBindingSource, nameof(subQuery.SubQueryText), true, DataSourceUpdateMode.OnPropertyChanged);

                xtraTabPage.Controls.Add(memoEdit);
                xtraTabControl1.TabPages.Add(xtraTabPage);
            }


            // Add "+" tab
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

                // Return to the newly added tab (before the "+" tab)
                xtraTabControl1.SelectedTabPageIndex = xtraTabControl1.TabPages.Count - 2;
            }
        }

        void AddNewSubQueryTab()
        {
            // Create a new TrReportSubQuery (if using EF)
            TrReportSubQuery newSubQuery = new()
            {
                SubQueryName = "New SubQuery",
                SubQueryText = "-- SQL here"
            };

            // Optionally add to selected DcReport
            DcReport? currentReport = dcReportsBindingSource.Current as DcReport;
            currentReport?.TrReportSubQueries.Add(newSubQuery);

            // Create tab UI
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
                SqlParameter[] sqlParameters;
                string query = cM.ApplyFilter(dcReport, dcReport.ReportQuery, null, out sqlParameters); ;

                DataTable dt = adoMethods.SqlGetDt(query, sqlParameters); // if query is correct 

                if (!efMethods.EntityExists<DcReport>(dcReport.ReportId)) //if doesnt exist
                    efMethods.InsertEntity<DcReport>(dcReport);
                else
                    dbContext.SaveChanges();

                DialogResult = DialogResult.OK;
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
    }
}
