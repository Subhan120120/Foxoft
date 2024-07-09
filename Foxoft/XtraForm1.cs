
using DevExpress.XtraEditors;
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
    public partial class XtraForm1 : DevExpress.XtraEditors.XtraForm
    {
        public XtraForm1()
        {
            InitializeComponent();
        }

        private void XtraForm1_Load(object sender, EventArgs e)
        {
            DataTable someDT = new DataTable();
            someDT.Columns.Add("Name", typeof(string));
            someDT.Columns.Add("Property", typeof(string));
            someDT.Columns.Add("SomeDate", typeof(DateTime));
            someDT.Columns.Add("SomeInt", typeof(int));

            someDT.Rows.Add(new object[] { "Name 1", "Property 1", DateTime.Now.AddDays(-5), -3 });
            someDT.Rows.Add(new object[] { "Name 2", "Property 2", DateTime.Now.AddDays(-10), -2 });
            someDT.Rows.Add(new object[] { "Name 3", "Property 3", DateTime.Now.AddDays(-20), 0 });
            someDT.Rows.Add(new object[] { "Name 4", "Property 4", DateTime.Now.AddDays(-30), 1 });
            someDT.Rows.Add(new object[] { "Name 5", "Property 5", DateTime.Now.AddDays(-35), 2 });

            //gridControl1.DataSource = someDT;
            filterControl1.SourceControl = someDT;
        }
    }
}