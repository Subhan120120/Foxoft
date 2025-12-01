using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using Foxoft.AppCode;
using Foxoft.Models;
using Foxoft.Properties;
using System.Diagnostics;

namespace Foxoft
{
    public partial class FormCurrAccSession : RibbonForm
    {
        EfMethods efMethods = new EfMethods();

        public FormCurrAccSession()
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
            List<TrSession> trSessions = efMethods.SelectEntities<TrSession>();
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
                        efMethods.DeleteEntity(trSession);
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

            if (DialogResult.OK == XtraMessageBox.Show(
                    string.Format(Resources.Form_CurrAccSession_CloseWindowQuestion, buttonEdit.EditValue),
                    Resources.Common_Attention, MessageBoxButtons.OKCancel))
            {
                WindowsAPI.CloseWindow((nint)gridView1.GetFocusedRowCellValue(colChildPID));
            }

            LoadUsers();
        }

        private void bBI_KickUser_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                Process process = Process.GetProcessById(Convert.ToInt32(gridView1.GetFocusedRowCellValue(colPID)));

                if (DialogResult.OK == XtraMessageBox.Show(
                        Resources.Form_CurrAccSession_KickUserQuestion,
                        Resources.Common_Attention, MessageBoxButtons.OKCancel))
                {
                    process.Kill(true);
                }
            }
            catch (ArgumentException)
            {
                XtraMessageBox.Show(Resources.Common_ProcessNotFound);
            }
            catch (UnauthorizedAccessException ex)
            {
                XtraMessageBox.Show(Resources.Common_AccessDenied + " " + ex.Message);
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