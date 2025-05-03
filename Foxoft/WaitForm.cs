
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraWaitForm;

namespace Foxoft
{
    public partial class WaitForm : DevExpress.XtraWaitForm.WaitForm
    {
        public WaitForm()
        {
            InitializeComponent();
            this.progressPanel1.AutoSize = true;
        }

        #region Overrides

        public override void SetCaption(string caption)
        {
            base.SetCaption(caption);
            this.progressPanel1.Caption = caption;
        }
        public override void SetDescription(string description)
        {
            base.SetDescription(description);
            this.progressPanel1.Description = description;
        }
        public override void ProcessCommand(Enum cmd, object arg)
        {
            WaitFormCommand command = (WaitFormCommand)cmd;
            if (command == WaitFormCommand.SetProgress)
            {
                progressBarControl1.EditValue = arg;
            }
            base.ProcessCommand(cmd, arg);
        }

        #endregion

        public enum WaitFormCommand
        {
            SetProgress
        }
    }
}