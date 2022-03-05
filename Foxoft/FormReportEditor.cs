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

namespace Foxoft
{
    public partial class FormReportEditor : Form
    {
        DcReport dcReport;

        public FormReportEditor(DcReport dcReport)
        {
            this.dcReport = dcReport;

            InitializeComponent();
            AcceptButton = simpleButton1;
        }

        private void FormQueryEditor_Load(object sender, EventArgs e)
        {
            textEdit1.Text = dcReport.ReportQuery;
            textEdit2.Text = dcReport.ReportName;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            EfMethods efMethods = new EfMethods();
            dcReport = efMethods.SelectReport(dcReport.Id);
            dcReport.ReportQuery = textEdit1.Text;
            dcReport.ReportName = textEdit2.Text;
            efMethods.UpdateReport(dcReport);
            DialogResult = DialogResult.OK;
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
