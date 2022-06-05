using DevExpress.Utils;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.IO;
using System.Windows.Forms;

namespace Foxoft
{
    public partial class FormReportGridOptions : Form
    {
        public Stream stream = new MemoryStream();
        GridView gridView = new GridView();

        public FormReportGridOptions(Stream stream)
        {
            this.stream = stream;
            InitializeComponent();
        }
        private void FormReportGridOptions_Load(object sender, EventArgs e)
        {
            stream.Seek(0, SeekOrigin.Begin);
            OptionsLayoutGrid option = new OptionsLayoutGrid() { StoreAllOptions = true, StoreAppearance = true };
            gridView.RestoreLayoutFromStream(stream, option);

            if (gridView.OptionsView.GroupFooterShowMode == GroupFooterShowMode.VisibleAlways)
                checkEdit_GroupFooter.Checked = true;
        }

        private void checkEdit_GroupFooter_CheckedChanged(object sender, EventArgs e)
        {
            if (checkEdit_GroupFooter.Checked == true)
            {
                gridView.OptionsView.GroupFooterShowMode = GroupFooterShowMode.VisibleAlways;
            }
            if (checkEdit_GroupFooter.Checked == false)
            {
                gridView.OptionsView.GroupFooterShowMode = GroupFooterShowMode.Hidden;
            }
        }


        private void simpleButton_Ok_Click(object sender, EventArgs e)
        {
            stream = new MemoryStream();
            OptionsLayoutGrid option = new OptionsLayoutGrid() { StoreAllOptions = true, StoreAppearance = true };
            gridView.SaveLayoutToStream(stream, option);
            DialogResult = DialogResult.OK;
        }
    }
}
