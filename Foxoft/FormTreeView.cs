using DevExpress.XtraEditors;
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
    public partial class FormTreeView : XtraForm
    {
        private EfMethods efMethods = new();
        private subContext dbContext;

        public FormTreeView()
        {
            InitializeComponent();
        }

        private void FormTreeView_Load(object sender, EventArgs e)
        {
            List<DcHierarchy> DcHierarchies = efMethods.SelectHierarchies();
            treeList1.DataSource = DcHierarchies;

        }
    }
}
