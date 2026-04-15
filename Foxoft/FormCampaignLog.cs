using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraLayout;
using Foxoft.Models;

namespace Foxoft
{
    /// <summary>
    /// Faktura üzrə tətbiq olunmuş kampaniyaların logunu göstərən sadə form.
    /// Designer faylsız, kod ilə inşa edilir.
    /// </summary>
    public class FormCampaignLog : XtraForm
    {
        private GridControl _grid;
        private GridView _view;
        private LayoutControl _layout;
        private SimpleButton _btnClose;

        public FormCampaignLog(List<TrInvoiceCampaignLog> logs)
        {
            Text = "Kampaniya Loqu";
            Width = 900;
            Height = 480;
            StartPosition = FormStartPosition.CenterParent;
            MinimizeBox = false;
            MaximizeBox = false;

            BuildUI();
            BindData(logs);
        }

        private void BuildUI()
        {
            _layout = new LayoutControl { Dock = DockStyle.Fill };
            _grid = new GridControl { Dock = DockStyle.Fill };
            _view = new GridView
            {
                GridControl = _grid,
                Name = "gridView1"
            };
            _view.OptionsView.ShowGroupPanel = false;
            _view.OptionsView.ShowFooter = true;
            _view.OptionsBehavior.Editable = false;

            _grid.MainView = _view;
            _grid.ViewCollection.Add(_view);

            _btnClose = new SimpleButton
            {
                Text = "Bağla",
                Width = 100,
                Height = 30,
                Anchor = AnchorStyles.Bottom | AnchorStyles.Right
            };
            _btnClose.Click += (_, __) => Close();

            var panel = new Panel { Dock = DockStyle.Bottom, Height = 40 };
            panel.Controls.Add(_btnClose);
            _btnClose.Location = new Point(panel.Width - 110, 5);
            panel.Resize += (_, __) => _btnClose.Location = new Point(panel.Width - 110, 5);

            Controls.Add(_grid);
            Controls.Add(panel);

            AddColumns();
        }

        private void AddColumns()
        {
            AddCol("CampaignCode", "Kampaniya Kodu", 110);
            AddCol("CampaignDesc", "Kampaniya Adı", 180);
            AddCol("PromoCode", "Promo Kod", 80);
            AddCol("Priority", "Prioritet", 65);
            AddCol("BaseAmount", "Əsas Məbləğ", 100, "{0:n2}");
            AddCol("DiscountAmount", "Endirim", 100, "{0:n2}");
            AddCol("DiscountAmountLoc", "Endirim (Yerli)", 100, "{0:n2}");
            AddCol("DiscountPercent", "Endirim %", 80, "{0:n2}");
        }

        private void AddCol(string fieldName, string caption, int width, string? format = null)
        {
            var col = _view.Columns.AddField(fieldName);
            col.Caption = caption;
            col.Width = width;
            col.Visible = true;
            col.VisibleIndex = _view.Columns.Count - 1;
            col.OptionsColumn.AllowEdit = false;
            if (format != null)
            {
                col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                col.DisplayFormat.FormatString = format;

                if (new[] { "DiscountAmount", "DiscountAmountLoc" }.Contains(fieldName))
                {
                    col.Summary.Add(DevExpress.Data.SummaryItemType.Sum, fieldName, format);
                }
            }
        }

        private void BindData(List<TrInvoiceCampaignLog> logs)
        {
            _grid.DataSource = logs;
            _view.BestFitColumns();
        }
    }
}
