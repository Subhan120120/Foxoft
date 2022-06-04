using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Windows.Forms;

namespace Foxoft
{
    public partial class FormReportGridConfig : Form
    {
        GridView gridView = new GridView();
        public FormReportGridConfig(GridView gridView)
        {
            this.gridView = gridView;
            InitializeComponent();
        }

        private void checkEdit1_CheckedChanged(object sender, EventArgs e)
        {
            //if (checkEdit1.Checked == true)
            //{
            //    gridView.OptionsView.GroupFooterShowMode = GroupFooterShowMode.Hidden;
            //}
            //if (checkEdit1.Checked == false)
            //{
            gridView.OptionsView.GroupFooterShowMode = GroupFooterShowMode.VisibleIfExpanded;
            //}
        }
    }
}
