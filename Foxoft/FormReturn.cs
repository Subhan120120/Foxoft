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
