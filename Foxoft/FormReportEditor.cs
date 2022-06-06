using Foxoft.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;

namespace Foxoft
{
    public partial class FormReportEditor : Form
    {
        DcReport dcReport;
        EfMethods efMethods = new EfMethods();

        public FormReportEditor(DcReport dcReport)
        {
            this.dcReport = dcReport;


            InitializeComponent();
            CancelButton = btn_Cancel;
            AcceptButton = btn_Ok;

            //subContext dbContext = new subContext();
            
            //dbContext.DcReports.LoadAsync().ContinueWith(loadTask =>
            //{
            //    dcReportsBindingSource.DataSource = dbContext.DcReports.Local.ToBindingList();
            //}, TaskScheduler.FromCurrentSynchronizationContext());
        }

        private void FormQueryEditor_Load(object sender, EventArgs e)
        {
            //textEdit1.Text = dcReport.ReportQuery;
            //textEdit2.Text = dcReport.ReportName;
        }

        private void FillDataLayout()
        {
            subContext dbContext = new subContext();

            if (string.IsNullOrEmpty(dcReport.Id))
                ClearControlsAddNew();
            else
            {
                //dbContext.DcCurrAccs.Where(x => x.CurrAccCode == dcCurrAcc.CurrAccCode)
                //                    .LoadAsync()
                //                    .ContinueWith(loadTask => dcCurrAccsBindingSource.DataSource = dbContext.DcCurrAccs.Local.ToBindingList(), TaskScheduler.FromCurrentSynchronizationContext());

                dbContext.DcReports.Where(x => x.Id == dcReport.Id)
                    .Load();
                dcReportsBindingSource.DataSource = dbContext.DcReports.Local.ToBindingList();
            }
        }

        private void ClearControlsAddNew()
        {
            dcReport = dcReportsBindingSource.AddNew() as DcReport;

            Guid Id = Guid.NewGuid();
            dcReport.Id = Id;

            dcReportsBindingSource.DataSource = dcReport;
        }

        private void btn_Ok_Click(object sender, EventArgs e)
        {
            EfMethods efMethods = new EfMethods();
            dcReport = efMethods.SelectReport(dcReport.Id);
            dcReport.ReportQuery = ReportQueryMemoEdit.Text;
            dcReport.ReportName = ReportNameTextEdit.Text;
            efMethods.UpdateReport(dcReport);
            DialogResult = DialogResult.OK;
        }
    }
}
