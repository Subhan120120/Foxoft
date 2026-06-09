using DevExpress.XtraEditors;
using System.Drawing.Drawing2D;
using DevExpress.Utils.Menu;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Menu;
using DevExpress.XtraGrid.Views.Grid;
using Foxoft.AppCode.Service;
using Foxoft.Models;
using Foxoft.Properties;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Diagnostics;
using System.IO;

namespace Foxoft
{
    public partial class FormWhatsAppMessageLog : RibbonForm
    {
        private subContext dbContext;
        private bool layoutLoaded;

        public FormWhatsAppMessageLog()
        {
            InitializeComponent();

            DesignComponentNames();
        }

        private void DesignComponentNames()
        {
            Text = Resources.Form_WhatsAppMessageLog;

            lblCardBalance_Title.Text = Resources.Form_WhatsAppMessageLog_Summary_Balance_Title;
            lblCardBalance_Subtitle.Text = Resources.Form_WhatsAppMessageLog_Summary_Balance_Subtitle;

            lblCardToday_Title.Text = Resources.Form_WhatsAppMessageLog_Summary_Today_Title;
            lblCardToday_Subtitle.Text = Resources.Form_WhatsAppMessageLog_Summary_Today_Subtitle;

            lblCardLast30Days_Title.Text = Resources.Form_WhatsAppMessageLog_Summary_Last30Days_Title;
            lblCardLast30Days_Subtitle.Text = Resources.Form_WhatsAppMessageLog_Summary_Last30Days_Subtitle;

            lblCardTotal_Title.Text = Resources.Form_WhatsAppMessageLog_Summary_Total_Title;
            lblCardTotal_Subtitle.Text = Resources.Form_WhatsAppMessageLog_Summary_Total_Subtitle;
        }

        private void FormWhatsAppMessageLog_Load(object sender, EventArgs e)
        {
            LoadData();
            LoadLayout();
        }

        private void LoadData()
        {
            dbContext?.Dispose();
            dbContext = new subContext();

            var list = dbContext.TrWhatsAppMessageLogs
                .AsNoTracking()
                .Include(x => x.DcCurrAcc)
                .Include(x => x.DcSender)
                .OrderByDescending(x => x.CreatedDate)
                .ToList();

            trWhatsAppMessageLogBindingSource.DataSource = list;

            if (!layoutLoaded)
                gV_WhatsAppMessageLogList.BestFitColumns();

            UpdateSummary();
        }

        private void LoadLayout()
        {
            string fileName = "FormWhatsAppMessageLogLayout.xml";
            string layoutFilePath = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData),
                "Foxoft",
                Settings.Default.CompanyCode,
                "Layout Xml Files",
                fileName);

            if (File.Exists(layoutFilePath))
            {
                gV_WhatsAppMessageLogList.RestoreLayoutFromXml(layoutFilePath);
                layoutLoaded = true;
            }

            EnsureSendAgainColumnVisible();
        }

        private void SaveLayout()
        {
            string fileName = "FormWhatsAppMessageLogLayout.xml";
            string layoutFileDir = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData),
                "Foxoft",
                Settings.Default.CompanyCode,
                "Layout Xml Files");

            if (!Directory.Exists(layoutFileDir))
                Directory.CreateDirectory(layoutFileDir);

            gV_WhatsAppMessageLogList.SaveLayoutToXml(Path.Combine(layoutFileDir, fileName));
            layoutLoaded = true;
        }

        private void bBI_Refresh_ItemClick(object sender, ItemClickEventArgs e)
        {
            LoadData();
        }

        private async void bBI_SendSelected_ItemClick(object sender, ItemClickEventArgs e)
        {
            await SendAgainAsync(gV_WhatsAppMessageLogList.GetFocusedRow() as TrWhatsAppMessageLog);
        }

        private async void repoBtn_SendAgain_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            await SendAgainAsync(gV_WhatsAppMessageLogList.GetFocusedRow() as TrWhatsAppMessageLog);
        }

        private async Task SendAgainAsync(TrWhatsAppMessageLog? log)
        {
            if (log == null)
            {
                XtraMessageBox.Show(Resources.Message_NoRowSelected, Resources.Common_Attention);
                return;
            }

            if (log.IsSuccessful)
            {
                XtraMessageBox.Show(Resources.Form_WhatsAppMessageLog_AlreadySent, Resources.Common_Attention);
                return;
            }

            SetSendButtonsEnabled(false);
            try
            {
                await WhatsAppMessageLogService.ResendAsync(log.WhatsAppMessageLogId);
                XtraMessageBox.Show(Resources.Common_SentSuccessfully, Resources.Form_WhatsAppMessageLog, MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(string.Format(Resources.Common_WhatsAppSendError, ex.Message), Resources.Common_Attention);
            }
            finally
            {
                SetSendButtonsEnabled(true);
            }
        }

        private async void bBI_SendAllUnsent_ItemClick(object sender, ItemClickEventArgs e)
        {
            List<Guid> unsentLogIds = dbContext.TrWhatsAppMessageLogs
                .AsNoTracking()
                .Where(x => !x.IsSuccessful)
                .OrderBy(x => x.CreatedDate)
                .Select(x => x.WhatsAppMessageLogId)
                .ToList();

            if (unsentLogIds.Count == 0)
            {
                XtraMessageBox.Show(Resources.Form_WhatsAppMessageLog_NoUnsentMessages, Resources.Common_Attention);
                return;
            }

            DialogResult result = XtraMessageBox.Show(
                Resources.Form_WhatsAppMessageLog_SendAllUnsentConfirm,
                Resources.Common_Confirm,
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result != DialogResult.Yes)
                return;

            int sent = 0;
            int failed = 0;

            SetSendButtonsEnabled(false);
            try
            {
                foreach (Guid logId in unsentLogIds)
                {
                    try
                    {
                        await WhatsAppMessageLogService.ResendAsync(logId);
                        sent++;
                    }
                    catch (Exception ex)
                    {
                        Debug.Print($"WhatsApp resend error: {ex.Message}");
                        failed++;
                    }
                }

                XtraMessageBox.Show(
                    string.Format(Resources.Form_WhatsAppMessageLog_SendResult, sent, failed),
                    Resources.Form_WhatsAppMessageLog,
                    MessageBoxButtons.OK,
                    failed == 0 ? MessageBoxIcon.Information : MessageBoxIcon.Warning);

                LoadData();
            }
            finally
            {
                SetSendButtonsEnabled(true);
            }
        }

        private void SetSendButtonsEnabled(bool enabled)
        {
            bBI_SendSelected.Enabled = enabled;
            bBI_SendAllUnsent.Enabled = enabled;
            bBI_Refresh.Enabled = enabled;
            colSendAgain.OptionsColumn.AllowEdit = enabled;
        }

        private void EnsureSendAgainColumnVisible()
        {
            colSendAgain.Visible = true;
            colSendAgain.VisibleIndex = Math.Max(0, gV_WhatsAppMessageLogList.VisibleColumns.Count - 1);
            colSendAgain.Width = 110;
        }

        private void bBI_ExportXlsx_ItemClick(object sender, ItemClickEventArgs e)
        {
            CustomExtensions.ExportToExcel(this, Resources.Form_WhatsAppMessageLog, gC_WhatsAppMessageLogList);
        }

        private void gC_WhatsAppMessageLogList_ProcessGridKey(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                LoadData();
                e.Handled = true;
            }
        }

        private void gV_WhatsAppMessageLogList_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            if (e.MenuType == GridMenuType.Column)
            {
                GridViewColumnMenu menu = e.Menu as GridViewColumnMenu;

                if (menu?.Column != null)
                    menu.Items.Add(CreateItem(Resources.Common_SaveLayout, menu.Column, null));
            }
        }

        private DXMenuItem CreateItem(string caption, GridColumn column, Image image)
        {
            DXMenuItem item = new(caption, new EventHandler(DXMenuItem_Click), image);
            item.Tag = new MenuColumnInfo(column);
            return item;
        }

        private void DXMenuItem_Click(object sender, EventArgs e)
        {
            DXMenuItem item = sender as DXMenuItem;
            MenuColumnInfo info = item?.Tag as MenuColumnInfo;

            if (info == null)
                return;

            SaveLayout();
        }

        class MenuColumnInfo
        {
            public MenuColumnInfo(GridColumn column)
            {
                Column = column;
            }

            public GridColumn Column;
        }

        private void FormWhatsAppMessageLog_FormClosed(object sender, FormClosedEventArgs e)
        {
            dbContext?.Dispose();
        }

        private void UpdateSummary()
        {
            int countToday = 0;
            int countLast30Days = 0;
            int countTotal = 0;

            if (trWhatsAppMessageLogBindingSource.DataSource is List<TrWhatsAppMessageLog> list)
            {
                foreach (var log in list)
                {
                    if (log.CreatedDate.Date == DateTime.Today) countToday++;
                    if (log.CreatedDate.Date >= DateTime.Today.AddDays(-30)) countLast30Days++;
                    countTotal++;
                }
            }

            lblCardToday_Value.Text = countToday.ToString("N0");
            lblCardLast30Days_Value.Text = countLast30Days.ToString("N0");
            lblCardTotal_Value.Text = countTotal.ToString("N0");

            decimal balance = dbContext.TrCredits
                .AsEnumerable()
                .Sum(x => x.Amount);

            lblCardBalance_Value.Text = balance.ToString("N2");
        }

        private void panelSummary_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            foreach (Control card in panelSummary.Controls)
            {
                if (card is PanelControl && card.Name.StartsWith("panelCard"))
                {
                    DrawCardShadow(e.Graphics, card.Bounds, 15);
                }
            }
        }

        private void DrawCardShadow(Graphics g, Rectangle bounds, int radius)
        {
            int shadowOffset = 2; // Subtle shift
            int shadowBlur = 3;   // Subtle blur layers

            for (int i = 1; i <= shadowBlur; i++)
            {
                Rectangle shadowRect = new Rectangle(bounds.X + shadowOffset, bounds.Y + shadowOffset, bounds.Width, bounds.Height);
                using (GraphicsPath path = GetRoundedPath(shadowRect, radius))
                {
                    int alpha = 10 / i;
                    using (SolidBrush brush = new SolidBrush(Color.FromArgb(alpha, Color.Black)))
                    {
                        g.FillPath(brush, path);
                    }
                }
            }
        }

        private void panelCard_Paint(object sender, PaintEventArgs e)
        {
            PanelControl panel = sender as PanelControl;
            if (panel == null) return;

            int radius = 10;
            using (GraphicsPath path = GetRoundedPath(panel.ClientRectangle, radius))
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                panel.Region = new Region(path);

                using (Pen pen = new Pen(Color.FromArgb(230, 230, 230), 1))
                {
                    e.Graphics.DrawPath(pen, path);
                }
            }
        }

        private void svgCard_Paint(object sender, PaintEventArgs e)
        {
            Control control = sender as Control;
            if (control == null) return;

            using (GraphicsPath path = new GraphicsPath())
            {
                path.AddEllipse(control.ClientRectangle);
                control.Region = new Region(path);
            }
        }

        private readonly Dictionary<string, Image> _imageCache = new();

        private void gV_WhatsAppMessageLogList_CustomRowCellEdit(object sender, CustomRowCellEditEventArgs e)
        {
            if (e.Column != colSendAgain || e.RowHandle < 0)
                return;

            bool isSuccessful = Convert.ToBoolean(gV_WhatsAppMessageLogList.GetRowCellValue(e.RowHandle, colIsSuccessful) ?? false);
            e.RepositoryItem = isSuccessful ? repoTextEmpty : repoBtn_SendAgain;
        }

        private void gV_WhatsAppMessageLogList_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            if (e.Column.FieldName != "colImagePreview" || !e.IsGetData)
                return;

            var view = sender as GridView;
            if (view == null) return;

            string filePath = view.GetListSourceRowCellValue(e.ListSourceRowIndex, colImageFilePath)?.ToString();

            if (string.IsNullOrEmpty(filePath) || !File.Exists(filePath))
            {
                e.Value = null;
                return;
            }

            if (_imageCache.TryGetValue(filePath, out Image cached))
            {
                e.Value = cached;
                return;
            }

            try
            {
                using (var fs = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    Image original = Image.FromStream(fs);
                    Image thumbnail = original.GetThumbnailImage(80, 60, () => false, IntPtr.Zero);
                    original.Dispose();
                    _imageCache[filePath] = thumbnail;
                    e.Value = thumbnail;
                }
            }
            catch
            {
                e.Value = null;
            }
        }

        private void gV_WhatsAppMessageLogList_DoubleClick(object sender, EventArgs e)
        {
            var view = sender as GridView;
            if (view == null) return;

            var hitInfo = view.CalcHitInfo(gC_WhatsAppMessageLogList.PointToClient(Control.MousePosition));
            if (!hitInfo.InRow) return;

            string filePath = view.GetRowCellValue(hitInfo.RowHandle, colImageFilePath)?.ToString();

            if (string.IsNullOrEmpty(filePath) || !File.Exists(filePath))
                return;

            try
            {
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                {
                    FileName = filePath,
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Print($"Image open error: {ex.Message}");
            }
        }

        private GraphicsPath GetRoundedPath(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            float r2 = radius * 2f;
            RectangleF rectF = new RectangleF(rect.X, rect.Y, rect.Width - 1, rect.Height - 1);

            path.AddArc(rectF.X, rectF.Y, r2, r2, 180, 90);
            path.AddArc(rectF.Right - r2, rectF.Y, r2, r2, 270, 90);
            path.AddArc(rectF.Right - r2, rectF.Bottom - r2, r2, r2, 0, 90);
            path.AddArc(rectF.X, rectF.Bottom - r2, r2, r2, 90, 90);
            path.CloseFigure();
            return path;
        }
    }
}
