using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraLayout;
using DevExpress.XtraLayout.Utils;
using Foxoft.Models;
using Foxoft.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Foxoft
{
    public partial class UcPosButtonSetting : XtraUserControl
    {
        private subContext dbContext;
        private List<DcPosButton> allButtons;
        private BindingList<DcPosButton> hiddenButtonsList;

        // Gorunen buttonlarin UI elementleri
        private readonly List<(DcPosButton data, SimpleButton button, LayoutControlItem layoutItem)> visibleItems = new();

        private const int ColumnCount = 4;

        public UcPosButtonSetting()
        {
            InitializeComponent();
            dbContext = new subContext();
        }

        private void UcPosButtonSetting_Load(object sender, EventArgs e)
        {
            LoadData();
            ApplyLocalization();
            SetupGridDragDrop();
        }

        private void LoadData()
        {
            allButtons = dbContext.DcPosButtons.OrderBy(x => x.SortOrder).ThenBy(x => x.Id).ToList();
            RebuildUI();
        }

        private void ApplyLocalization()
        {
            btnSave.Text = Resources.Common_Save;
            btnCancel.Text = Resources.Common_Cancel;
            btnReset.Text = Resources.Common_Reset;
            lCG_Buttons.Text = Resources.Form_PosButtonSetting_Caption;
            groupHidden.Text = Resources.Common_DragToReorder;
            colButtonName.Caption = Resources.Entity_PosButton_ButtonName;
            colButtonDescription.Caption = Resources.Entity_PosButton_ButtonDescription;
        }

        /// <summary>
        /// Butun UI-ni yeniden qurur: gorunen buttonlari lCG_Buttons-a, gizli olanlari grid-e yerlesdirir
        /// </summary>
        private void RebuildUI()
        {
            // 1) Evvelki gorunen buttonlari temizle
            layoutControl1.BeginUpdate();
            foreach (var item in visibleItems)
            {
                lCG_Buttons.Remove(item.layoutItem);
                layoutControl1.Controls.Remove(item.button);
                item.layoutItem.Dispose();
                item.button.Dispose();
            }
            visibleItems.Clear();

            // 2) Gorunen ve gizli siyahilari ayir
            var visible = allButtons.Where(b => b.IsVisible).OrderBy(b => b.SortOrder).ToList();
            var hidden = allButtons.Where(b => !b.IsVisible).OrderBy(b => b.SortOrder).ToList();

            // 3) Gorunen buttonlar ucun table layout qur
            BuildVisibleButtons(visible);

            // 4) Gizli buttonlari grid-e bind et
            hiddenButtonsList = new BindingList<DcPosButton>(hidden);
            gridHidden.DataSource = hiddenButtonsList;

            layoutControl1.EndUpdate();
        }

        private void BuildVisibleButtons(List<DcPosButton> visible)
        {
            // Column definitions — 4 sutun
            lCG_Buttons.OptionsTableLayoutGroup.ColumnDefinitions.Clear();
            for (int c = 0; c < ColumnCount; c++)
            {
                var cd = new ColumnDefinition { SizeType = SizeType.Percent, Width = 100.0 / ColumnCount };
                lCG_Buttons.OptionsTableLayoutGroup.ColumnDefinitions.Add(cd);
            }

            // Row definitions — yalniz 4x4 sabitle
            int rowCount = 4;

            lCG_Buttons.OptionsTableLayoutGroup.RowDefinitions.Clear();
            for (int r = 0; r < rowCount; r++)
            {
                var rd = new RowDefinition { SizeType = SizeType.Percent, Height = 100.0 / rowCount };
                lCG_Buttons.OptionsTableLayoutGroup.RowDefinitions.Add(rd);
            }

            // Her gorunen button ucun SimpleButton + LayoutControlItem yarat
            for (int i = 0; i < visible.Count; i++)
            {
                var posBtn = visible[i];

                var btn = new SimpleButton
                {
                    Name = "posBtn_" + posBtn.ButtonName,
                    Text = posBtn.ButtonDescription ?? posBtn.ButtonName,
                    Dock = DockStyle.Fill,
                    AllowFocus = false,
                    Tag = posBtn,
                };

                // Custom reng varsa tetbiq et
                if (posBtn.BackColorArgb.HasValue)
                {
                    btn.Appearance.BackColor = Color.FromArgb(posBtn.BackColorArgb.Value);
                    btn.Appearance.Options.UseBackColor = true;
                }
                if (posBtn.ForeColorArgb.HasValue)
                {
                    btn.Appearance.ForeColor = Color.FromArgb(posBtn.ForeColorArgb.Value);
                    btn.Appearance.Options.UseForeColor = true;
                }

                // Double-click — buttonu gizlet (grid-e kecir)
                btn.DoubleClick += VisibleButton_DoubleClick;

                // Drag source — table-dan grid-e surukleme
                btn.MouseDown += VisibleButton_MouseDown;
                btn.MouseMove += VisibleButton_MouseMove;

                layoutControl1.Controls.Add(btn);

                var lci = new LayoutControlItem
                {
                    Control = btn,
                    Name = "lci_" + posBtn.ButtonName,
                    TextVisible = false,
                    SizeConstraintsType = SizeConstraintsType.Custom,
                    MinSize = new Size(50, 40),
                    Visibility = LayoutVisibility.Always,
                };
                // Pozisiya SortOrder-a gore — gizli buttonlarin yeri bos qalir
                lci.OptionsTableLayoutItem.RowIndex = posBtn.SortOrder / ColumnCount;
                lci.OptionsTableLayoutItem.ColumnIndex = posBtn.SortOrder % ColumnCount;

                lCG_Buttons.AddItem(lci);
                visibleItems.Add((posBtn, btn, lci));
            }
        }

        #region Grid → Table Layout (gizliden gorunene kecid)

        private void SetupGridDragDrop()
        {
            // Grid-den drag baslat
            gridViewHidden.MouseDown += GridView_MouseDown;
            gridViewHidden.MouseMove += GridView_MouseMove;

            // LayoutControl-a drop qebul et
            layoutControl1.DragOver += LayoutControl_DragOver;
            layoutControl1.DragDrop += LayoutControl_DragDrop;

            // Grid-e drop qebul et (table-dan grid-e)
            gridHidden.AllowDrop = true;
            gridHidden.DragOver += GridHidden_DragOver;
            gridHidden.DragDrop += GridHidden_DragDrop;

            // Grid-de double-click — buttonu gorunene kecir
            gridViewHidden.DoubleClick += GridViewHidden_DoubleClick;
        }

        private GridHitInfo gridDownHitInfo = null;

        private void GridView_MouseDown(object sender, MouseEventArgs e)
        {
            gridDownHitInfo = null;
            var hitInfo = gridViewHidden.CalcHitInfo(new Point(e.X, e.Y));
            if (e.Button == MouseButtons.Left && hitInfo.InRow && hitInfo.RowHandle >= 0)
                gridDownHitInfo = hitInfo;
        }

        private void GridView_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && gridDownHitInfo != null)
            {
                Size dragSize = SystemInformation.DragSize;
                Rectangle dragRect = new Rectangle(
                    new Point(gridDownHitInfo.HitPoint.X - dragSize.Width / 2,
                              gridDownHitInfo.HitPoint.Y - dragSize.Height / 2), dragSize);

                if (!dragRect.Contains(new Point(e.X, e.Y)))
                {
                    var row = gridViewHidden.GetRow(gridDownHitInfo.RowHandle) as DcPosButton;
                    if (row != null)
                        gridHidden.DoDragDrop(row, DragDropEffects.Move);
                    gridDownHitInfo = null;
                }
            }
        }

        private void LayoutControl_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = e.Data.GetDataPresent(typeof(DcPosButton))
                ? DragDropEffects.Move
                : DragDropEffects.None;
        }

        private void LayoutControl_DragDrop(object sender, DragEventArgs e)
        {
            var draggedButton = e.Data.GetData(typeof(DcPosButton)) as DcPosButton;
            if (draggedButton == null) return;

            Point clientPoint = layoutControl1.PointToClient(new Point(e.X, e.Y));
            int targetSortOrder = FindDropSortOrder(clientPoint);

            if (targetSortOrder >= 0)
            {
                MoveButtonToSlot(draggedButton, targetSortOrder);
            }
        }

        private void GridViewHidden_DoubleClick(object sender, EventArgs e)
        {
            var row = gridViewHidden.GetFocusedRow() as DcPosButton;
            if (row == null) return;
            row.IsVisible = true;
            RebuildUI();
        }

        /// <summary>
        /// Mouse-un layoutControl1 üzerindeki mövqeyinə görə müvafiq slotun (SortOrder) indeksini hesablayır.
        /// </summary>
        private int FindDropSortOrder(Point clientPoint)
        {
            Rectangle bounds = lCG_Buttons.Bounds;
            if (!bounds.Contains(clientPoint))
                return -1;

            // Group caption və border-lər üçün düzəliş
            int topBorder = lCG_Buttons.TextVisible ? 24 : 4;
            int leftBorder = 4;
            int rightBorder = 4;
            int bottomBorder = 4;

            int clientX = clientPoint.X - (bounds.X + leftBorder);
            int clientY = clientPoint.Y - (bounds.Y + topBorder);
            int clientWidth = bounds.Width - (leftBorder + rightBorder);
            int clientHeight = bounds.Height - (topBorder + bottomBorder);

            if (clientWidth <= 0 || clientHeight <= 0 || clientX < 0 || clientY < 0 || clientX >= clientWidth || clientY >= clientHeight)
                return -1;

            int rowCount = 4;

            int cellWidth = clientWidth / ColumnCount;
            int cellHeight = clientHeight / rowCount;

            if (cellWidth <= 0 || cellHeight <= 0)
                return -1;

            int col = clientX / cellWidth;
            int row = clientY / cellHeight;

            if (col < 0) col = 0;
            if (col >= ColumnCount) col = ColumnCount - 1;
            if (row < 0) row = 0;
            if (row >= rowCount) row = rowCount - 1;

            return row * ColumnCount + col;
        }

        #endregion

        #region Table Layout → Grid (gorunenden gizliye kecid)

        private Point visibleBtnDownLocation;

        private void VisibleButton_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                visibleBtnDownLocation = e.Location;
        }

        private void VisibleButton_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                int dx = Math.Abs(e.X - visibleBtnDownLocation.X);
                int dy = Math.Abs(e.Y - visibleBtnDownLocation.Y);

                if (dx > SystemInformation.DragSize.Width || dy > SystemInformation.DragSize.Height)
                {
                    var btn = sender as SimpleButton;
                    if (btn?.Tag is DcPosButton posBtn)
                        btn.DoDragDrop(posBtn, DragDropEffects.Move);
                }
            }
        }

        private void VisibleButton_DoubleClick(object sender, EventArgs e)
        {
            var btn = sender as SimpleButton;
            if (btn?.Tag is DcPosButton posBtn)
                MakeHidden(posBtn);
        }

        private void GridHidden_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = e.Data.GetDataPresent(typeof(DcPosButton))
                ? DragDropEffects.Move
                : DragDropEffects.None;
        }

        private void GridHidden_DragDrop(object sender, DragEventArgs e)
        {
            var draggedButton = e.Data.GetData(typeof(DcPosButton)) as DcPosButton;
            if (draggedButton == null || !draggedButton.IsVisible) return;
            MakeHidden(draggedButton);
        }

        #endregion

        #region Visibility helpers

        private void MoveButtonToSlot(DcPosButton posBtn, int targetSortOrder)
        {
            var existing = allButtons.FirstOrDefault(b => b.SortOrder == targetSortOrder);
            if (existing != null && existing != posBtn)
            {
                // Hədəfdəki button-la yerləri dəyişdiririk (swap)
                int temp = posBtn.SortOrder;
                posBtn.SortOrder = existing.SortOrder;
                existing.SortOrder = temp;
            }
            else
            {
                posBtn.SortOrder = targetSortOrder;
            }

            posBtn.IsVisible = true;
            RebuildUI();
        }

        private void MakeHidden(DcPosButton posBtn)
        {
            posBtn.IsVisible = false;
            // Sıralama (SortOrder) dəyişməz qalır, sadəcə görünmür — yeri boş qalır
            RebuildUI();
        }

        #endregion

        #region Save / Cancel

        private void btnReset_Click(object sender, EventArgs e)
        {
            // Reset in-memory list to defaults matching seed data
            // Default seed: IsVisible = true (except Id >= 17), SortOrder = Id - 1, Colors = null
            foreach (var posBtn in allButtons)
            {
                posBtn.IsVisible = (posBtn.Id < 17);
                posBtn.SortOrder = posBtn.Id - 1;
                posBtn.BackColorArgb = null;
                posBtn.ForeColorArgb = null;
            }

            RebuildUI();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                dbContext.SaveChanges();
                XtraMessageBox.Show(Resources.Common_SavedSuccessfully, Resources.Common_Info,
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(Resources.Common_ErrorOccurred + " " + ex.Message,
                    Resources.Common_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            dbContext.Dispose();
            dbContext = new subContext();
            LoadData();
        }

        #endregion
    }
}
