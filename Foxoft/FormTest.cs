using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraRichEdit;
using DevExpress.XtraRichEdit.API.Native;
using System;
using System.Windows.Forms;

namespace Foxoft
{

    public partial class FormTest : RibbonForm
    {
        RibbonControl ribbon;
        RibbonPage pageHome;
        RibbonPageGroup groupParagraph;
        BarButtonGroup groupAlign;
        BarCheckItem btnAlignLeft, btnAlignCenter, btnAlignRight, btnAlignJustify;

        RichEditControl richEdit;
        bool _syncingUI; // prevent feedback loops

        public FormTest()
        {
            InitializeComponent();
            BuildUi();
            WireBindings();
        }

        void BuildUi()
        {
            ribbon = new RibbonControl { Dock = DockStyle.Top };
            Controls.Add(ribbon);

            pageHome = new RibbonPage("Home");
            ribbon.Pages.Add(pageHome);

            groupParagraph = new RibbonPageGroup("Paragraph");
            pageHome.Groups.Add(groupParagraph);

            richEdit = new RichEditControl { Dock = DockStyle.Fill };
            Controls.Add(richEdit);
            richEdit.Document.AppendText("Type here and try the alignment buttons...\r\n\r\n");

            groupAlign = new BarButtonGroup { Caption = "Alignment", RibbonStyle = RibbonItemStyles.SmallWithoutText };
            const int alignGroupIndex = 10;

            btnAlignLeft = new BarCheckItem { Caption = "Left", GroupIndex = alignGroupIndex, Down = true };
            btnAlignCenter = new BarCheckItem { Caption = "Center", GroupIndex = alignGroupIndex };
            btnAlignRight = new BarCheckItem { Caption = "Right", GroupIndex = alignGroupIndex };
            btnAlignJustify = new BarCheckItem { Caption = "Justify", GroupIndex = alignGroupIndex };

            groupAlign.ItemLinks.Add(btnAlignLeft);
            groupAlign.ItemLinks.Add(btnAlignCenter);
            groupAlign.ItemLinks.Add(btnAlignRight);
            groupAlign.ItemLinks.Add(btnAlignJustify);
            groupParagraph.ItemLinks.Add(groupAlign);

            ribbon.Items.AddRange(new BarItem[] { ribbon.ExpandCollapseItem, groupAlign, btnAlignLeft, btnAlignCenter, btnAlignRight, btnAlignJustify});

        }

        void WireBindings()
        {
            // Use ItemClick. Check the Down state to know which radio item just won.
            btnAlignLeft.ItemClick += (_, __) => { if (btnAlignLeft.Down) ApplyAlignment(ParagraphAlignment.Left); };
            btnAlignCenter.ItemClick += (_, __) => { if (btnAlignCenter.Down) ApplyAlignment(ParagraphAlignment.Center); };
            btnAlignRight.ItemClick += (_, __) => { if (btnAlignRight.Down) ApplyAlignment(ParagraphAlignment.Right); };
            btnAlignJustify.ItemClick += (_, __) => { if (btnAlignJustify.Down) ApplyAlignment(ParagraphAlignment.Justify); };

            richEdit.SelectionChanged += (_, __) => SyncButtonsWithSelection();
            richEdit.DocumentLoaded += (_, __) => SyncButtonsWithSelection();
        }

        void ApplyAlignment(ParagraphAlignment alignment)
        {
            var doc = richEdit.Document;
            var range = doc.Selection;

            // CORRECT USAGE: BeginUpdateParagraphs returns ParagraphProperties (not IDisposable, not enumerable).
            ParagraphProperties props = doc.BeginUpdateParagraphs(range);
            props.Alignment = alignment;
            doc.EndUpdateParagraphs(props);
        }

        void SyncButtonsWithSelection()
        {
            if (_syncingUI) return;
            _syncingUI = true;

            try
            {
                var doc = richEdit.Document;
                var pars = doc.Paragraphs.Get(doc.Selection);

                ParagraphAlignment? same = null;
                foreach (Paragraph p in pars)
                {
                    var a = p.Alignment; // reading is fine
                    if (same == null) same = a;
                    else if (same.Value != a) { same = null; break; } // mixed
                }

                if (same != null)
                {
                    btnAlignLeft.Down = same == ParagraphAlignment.Left;
                    btnAlignCenter.Down = same == ParagraphAlignment.Center;
                    btnAlignRight.Down = same == ParagraphAlignment.Right;
                    btnAlignJustify.Down = same == ParagraphAlignment.Justify;
                }
                // If mixed, leave states as-is (Office-like behavior).
            }
            finally { _syncingUI = false; }
        }
    }
}