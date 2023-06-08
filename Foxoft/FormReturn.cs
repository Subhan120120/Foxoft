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
            UcReturn ucReturn = new UcReturn();
            Controls.Add(ucReturn);
        }
        public FormReturn(string processCode)
           : this()
        {
            UcReturn ucReturn = new UcReturn(processCode);
            Controls.Add(ucReturn);
        }

    }
}
