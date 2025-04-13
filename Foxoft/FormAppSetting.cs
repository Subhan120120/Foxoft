using DevExpress.XtraEditors;
using Foxoft.Models;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Foxoft
{
    public partial class FormAppSetting : XtraForm
    {
        subContext dbContext = new();
        AppSetting AppSetting;

        public FormAppSetting()
        {
            InitializeComponent();
        }

        private void FormAppSetting_Load(object sender, EventArgs e)
        {
            FillDataLayout();
        }


        private void FillDataLayout()
        {
            dbContext = new subContext();

            dbContext.AppSettings.Where(x => x.Id == 1)
                                .LoadAsync()
                                .ContinueWith(loadTask => appSettingBindingSource.DataSource = dbContext.AppSettings.Local.ToBindingList(), TaskScheduler.FromCurrentSynchronizationContext());
        }

        private void Btn_Save_Click(object sender, EventArgs e)
        {
            dbContext.SaveChanges();
        }

    }
}
