using DevExpress.XtraEditors;
using DevExpress.XtraLayout;
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
    public partial class UCNumberPad : XtraUserControl
    {
        public UCNumberPad()
        {
            InitializeComponent();
            InitializeInputPad();
        }
        private void InitializeInputPad()
        {
            LayoutControlGroup Root = new();

            ((ISupportInitialize)Root).BeginInit();
            Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            Root.GroupBordersVisible = false;
            Root.LayoutMode = DevExpress.XtraLayout.Utils.LayoutMode.Table;
            ((ISupportInitialize)Root).EndInit();

            LayoutControl layoutControl1 = new()
            {
                Dock = DockStyle.Fill,
                Root = Root,
            };

            Controls.Add(layoutControl1);

            string[] buttonLabels = { "7", "8", "9", "←", "4", "5", "6", "C", "1", "2", "3", "↵", "*", "0", "," };

            for (int i = 0; i < 4; i++)
                Root.OptionsTableLayoutGroup.ColumnDefinitions.Add(new ColumnDefinition(Root, 25D, SizeType.Percent));

            for (int i = 0; i < 4; i++)
                Root.OptionsTableLayoutGroup.RowDefinitions.Add(new RowDefinition(Root, 25D, SizeType.Percent));

            for (int i = 0; i < buttonLabels.Length; i++)
            {
                var button = new SimpleButton
                {
                    Text = buttonLabels[i],
                    AllowFocus = false,
                    Appearance = { Font = new Font("Tahoma", 18F) },
                    StyleController = layoutControl1
                };
                button.Click += btn_Num_Click;

                var layoutItem = new LayoutControlItem
                {
                    Control = button,
                    TextVisible = false,
                    OptionsTableLayoutItem = {
                        RowIndex = i / 4, // Row index
                        ColumnIndex = i % 4, // Column index
                    },
                    SizeConstraintsType = SizeConstraintsType.Custom
                };

                if (buttonLabels[i] == "↵")
                    layoutItem.OptionsTableLayoutItem.RowSpan = 2;

                Root.AddItem(layoutItem);
            }

        }


        private void btn_Num_Click(object sender, EventArgs e)
        {
            string key = (sender as SimpleButton).Text;

            switch (key)
            {
                case "←": SendKeys.Send("{BACKSPACE}"); break;
                case "C": SendKeys.Send("^A{DELETE}"); break;
                case "↵": SendKeys.Send("{ENTER}"); break;
                default: SendKeys.Send(key); break;
            }
        }
    }
}
