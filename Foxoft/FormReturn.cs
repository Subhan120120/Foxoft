using DevExpress.XtraEditors;
using Foxoft.Properties;
using System;
using System.Windows.Forms;

namespace Foxoft
{
    public partial class FormReturn : XtraForm
    {
        public FormReturn()
        {
            InitializeComponent();
        }

        public FormReturn(string processCode)
            : this()
        {
            UcReturn ucReturn = new(processCode);
            ucReturn.Dock = DockStyle.Fill;
            Controls.Add(ucReturn);
        }
    }
}
