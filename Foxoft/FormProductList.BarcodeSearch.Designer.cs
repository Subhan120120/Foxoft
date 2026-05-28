using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid;
using Foxoft.Properties;

namespace Foxoft
{
    partial class FormProductList
    {
        private const int BarcodeSearchClearButtonIndex = 1;
        private const int BarcodeSearchFindPanelHeight = 54;
        private const int BarcodeSearchFindEditorMaxWidth = 562;
        private const int BarcodeSearchFindEditorMinWidth = 280;
        private const int BarcodeSearchMinWidth = 190;
        private const int BarcodeSearchMaxWidth = 320;
        private const int BarcodeSearchPanelPadding = 8;
        private const int BarcodeSearchEditorGap = 8;
        private const int BarcodeSearchRightReserve = 140;

        private void InitializeBarcodeSearchDesign()
        {
            gV_ProductList.OptionsFind.FindDelay = 100;
            gV_ProductList.OptionsFind.FindMode = FindMode.Always;
            gV_ProductList.OptionsFind.ShowFindButton = false;

            btnEdit_BarcodeSearch.Properties.AutoHeight = true;
            btnEdit_BarcodeSearch.Properties.BorderStyle = BorderStyles.Simple;
            btnEdit_BarcodeSearch.Properties.Buttons.Clear();
            btnEdit_BarcodeSearch.Properties.Buttons.AddRange(new EditorButton[]
            {
                CreateBarcodeSearchGlyphButton(),
                CreateBarcodeSearchClearButton()
            });
            btnEdit_BarcodeSearch.Properties.NullValuePrompt = Resources.Form_ProductList_BarcodeSearchPrompt;
            btnEdit_BarcodeSearch.Properties.ShowNullValuePrompt =
                ShowNullValuePromptOptions.EmptyValue | ShowNullValuePromptOptions.EditorFocused;
            btnEdit_BarcodeSearch.ButtonClick += btnEdit_BarcodeSearch_ButtonClick;
        }

        private EditorButton CreateBarcodeSearchGlyphButton()
        {
            EditorButtonImageOptions imageOptions = new()
            {
                SvgImage = svgImageCollection1["barcode"],
                SvgImageSize = new Size(16, 16)
            };

            return new EditorButton(
                ButtonPredefines.Glyph,
                string.Empty,
                -1,
                true,
                true,
                true,
                imageOptions,
                new KeyShortcut(Keys.None),
                new SerializableAppearanceObject(),
                new SerializableAppearanceObject(),
                new SerializableAppearanceObject(),
                new SerializableAppearanceObject(),
                Resources.Form_ProductList_BarcodeSearchTooltip,
                null,
                null,
                ToolTipAnchor.Default);
        }

        private static EditorButton CreateBarcodeSearchClearButton()
        {
            return new EditorButton(ButtonPredefines.Clear)
            {
                ToolTip = Resources.Common_Clear,
                Visible = false
            };
        }

        private void btnEdit_BarcodeSearch_Layout()
        {
            if (!Settings.Default.AppSetting.UseBarcode || !gV_ProductList.IsFindPanelVisible)
            {
                btnEdit_BarcodeSearch.Visible = false;
                return;
            }

            Point gridControlScreenPoint = gC_ProductList.PointToScreen(Point.Empty);
            Rectangle findPanelRect = new(
                gridControlScreenPoint.X,
                gridControlScreenPoint.Y,
                gC_ProductList.Width,
                BarcodeSearchFindPanelHeight);

            int searchEditorWidth = Math.Min(
                BarcodeSearchFindEditorMaxWidth,
                Math.Max(
                    BarcodeSearchFindEditorMinWidth,
                    findPanelRect.Width
                        - BarcodeSearchMaxWidth
                        - BarcodeSearchRightReserve
                        - BarcodeSearchEditorGap
                        - BarcodeSearchPanelPadding));

            int editorLeft = findPanelRect.Left
                + BarcodeSearchPanelPadding
                + searchEditorWidth
                + BarcodeSearchEditorGap;
            int availableWidth = findPanelRect.Right - BarcodeSearchRightReserve - editorLeft;

            if (availableWidth < BarcodeSearchMinWidth)
            {
                btnEdit_BarcodeSearch.Visible = false;
                return;
            }

            int editorWidth = Math.Min(BarcodeSearchMaxWidth, availableWidth);
            Point additionalEditorScreenPoint = new(
                editorLeft,
                findPanelRect.Top + (findPanelRect.Height - btnEdit_BarcodeSearch.Height) / 2);
            Point additionalEditorFormPoint = PointToClient(additionalEditorScreenPoint);

            btnEdit_BarcodeSearch.Location = additionalEditorFormPoint;
            btnEdit_BarcodeSearch.Width = editorWidth;
            btnEdit_BarcodeSearch.Visible = true;
            btnEdit_BarcodeSearch.BringToFront();
        }

        private void btnEdit_BarcodeSearch_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == ButtonPredefines.Clear)
                btnEdit_BarcodeSearch.EditValue = null;

            btnEdit_BarcodeSearch.Focus();
            btnEdit_BarcodeSearch.SelectAll();
        }

        private void UpdateBarcodeSearchButtons()
        {
            if (btnEdit_BarcodeSearch.Properties.Buttons.Count <= BarcodeSearchClearButtonIndex)
                return;

            btnEdit_BarcodeSearch.Properties.Buttons[BarcodeSearchClearButtonIndex].Visible =
                !string.IsNullOrWhiteSpace(btnEdit_BarcodeSearch.EditValue?.ToString());
        }
    }
}
