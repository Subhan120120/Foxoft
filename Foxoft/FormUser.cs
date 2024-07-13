using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using Foxoft.AppCode;
using Foxoft.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Foxoft
{
    public partial class FormUser : RibbonForm
    {
        EfMethods efMethods = new EfMethods();
        public FormUser()
        {
            InitializeComponent();

            LoadUsers();
        }

        private void RibbonForm1_Load(object sender, EventArgs e)
        {

        }

        private void bBI_Update_ItemClick(object sender, ItemClickEventArgs e)
        {
            LoadUsers();
        }

        private void LoadUsers()
        {
            List<TrSession> trSessions = efMethods.SelectSessions();
            List<UserInfo> userInfos = new();

            if (trSessions is not null)
            {
                foreach (TrSession trSession in trSessions)
                {
                    Process process = null;

                    try
                    {
                        process = Process.GetProcessById(trSession.PID);

                        List<WindowInfo> windowinfos = WindowsAPI.GetMDIChildWindowsOfProcess(process);

                        foreach (WindowInfo windowinfo in windowinfos)
                        {
                            userInfos.Add(new UserInfo()
                            {
                                PID = trSession.PID,
                                CurrAccCode = trSession.CurrAccCode,
                                CurrAccDesc = efMethods.SelectCurrAcc(trSession.CurrAccCode).CurrAccDesc,
                                ChildPID = windowinfo.Handle,
                                ChildTitle = windowinfo.Title + " - " + windowinfo.Tag,
                            });
                        }

                        if (windowinfos.Count == 0)
                        {
                            userInfos.Add(new UserInfo()
                            {
                                PID = trSession.PID,
                                CurrAccCode = trSession.CurrAccCode,
                                CurrAccDesc = efMethods.SelectCurrAcc(trSession.CurrAccCode).CurrAccDesc,
                            });
                        }
                    }
                    catch (ArgumentException)
                    {
                        efMethods.DeleteSession(trSession);
                    }
                }
            }

            myGridControl1.DataSource = userInfos;
        }

        private void gridView1_CellMerge(object sender, DevExpress.XtraGrid.Views.Grid.CellMergeEventArgs e)
        {
            if (e.Column.FieldName == "PID" || e.Column.FieldName == "CurrAccDesc")
            {
                string value1 = gridView1.GetRowCellDisplayText(e.RowHandle1, e.Column);
                string value2 = gridView1.GetRowCellDisplayText(e.RowHandle2, e.Column);
                e.Merge = value1 == value2;
            }
            else
            {
                e.Merge = false;
            }
            e.Handled = true;
        }

        private void repositoryItemButtonEdit1_ButtonPressed(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            ButtonEdit buttonEdit = (ButtonEdit)sender;

            if (DialogResult.OK == XtraMessageBox.Show(buttonEdit.EditValue + " Pəncərəni bağlamaq istəyirsiz?", "Diqqət", MessageBoxButtons.OKCancel))
                WindowsAPI.CloseWindow((nint)gridView1.GetFocusedRowCellValue(colChildPID));

            LoadUsers();
        }

        private void bBI_KickUser_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                Process process = Process.GetProcessById(Convert.ToInt32(gridView1.GetFocusedRowCellValue(colPID)));

                if (DialogResult.OK == XtraMessageBox.Show("İstifadəçini atmaq istəyirsiz?", "Diqqət", MessageBoxButtons.OKCancel))
                    process.Kill(true);
            }
            catch (ArgumentException ex)
            {
                XtraMessageBox.Show("Proses tapılmadı.");
            }
            catch (UnauthorizedAccessException ex)
            {
                Console.WriteLine($"Cəhd əngəlləndi. Admin imtiyazlarınız olduğundan əmin olun.:" + ex.Message);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }

            LoadUsers();
        }
    }

    public class UserInfo
    {
        public int PID { get; set; }
        public string CurrAccCode { get; set; }
        public string CurrAccDesc { get; set; }
        public nint ChildPID { get; set; }
        public string ChildTitle { get; set; }
    }
}