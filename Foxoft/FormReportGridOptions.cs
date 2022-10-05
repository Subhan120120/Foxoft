﻿using DevExpress.Utils;
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

            if (gridView.OptionsBehavior.ReadOnly == true)
                checkEdit_CellReadOnly.Checked = true;

            if (gridView.OptionsBehavior.Editable == true)
                checkEdit_Editable.Checked = true;
        }



        private void simpleButton_Ok_Click(object sender, EventArgs e)
        {
            stream = new MemoryStream();
            OptionsLayoutGrid option = new OptionsLayoutGrid() { StoreAllOptions = true, StoreAppearance = true };
            gridView.SaveLayoutToStream(stream, option);
            DialogResult = DialogResult.OK;
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

        private void checkEdit_CellReadOnly_CheckedChanged(object sender, EventArgs e)
        {
            if (checkEdit_CellReadOnly.Checked == true)
            {
                gridView.OptionsBehavior.ReadOnly = true;
            }
            if (checkEdit_CellReadOnly.Checked == false)
            {
                gridView.OptionsBehavior.ReadOnly = false;
            }
        }

        private void checkEdit_Editable_CheckedChanged(object sender, EventArgs e)
        {
            if (checkEdit_Editable.Checked == true)
            {
                gridView.OptionsBehavior.Editable = true;
            }
            if (checkEdit_Editable.Checked == false)
            {
                gridView.OptionsBehavior.Editable = false;
            }
        }
    }
}
