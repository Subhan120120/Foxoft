using System;
using System.Configuration;
using Microsoft.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Foxoft.Models;
using Foxoft.Properties;
using Microsoft.EntityFrameworkCore;

namespace Foxoft
{
    public partial class FormConnectionStringBuilder : Form
    {
        private string initialConnectionString;

        EfMethods efMethods = new EfMethods();

        public FormConnectionStringBuilder(string connectionString)
        {
            InitializeComponent();
            initialConnectionString = connectionString;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // Load the provided connection string and fill textboxes
            if (!string.IsNullOrWhiteSpace(initialConnectionString))
            {
                txtConnectionString.Text = initialConnectionString;

                var builder = new SqlConnectionStringBuilder(initialConnectionString);
                txtServer.Text = builder.DataSource;
                txtDatabase.Text = builder.InitialCatalog;
                txtUser.Text = builder.UserID;
                txtPassword.Text = builder.Password;
            }
        }

        private void GenerateConnectionString(object sender, EventArgs e)
        {
            string server = txtServer.Text.Trim();
            string database = txtDatabase.Text.Trim();
            string user = txtUser.Text.Trim();
            string password = txtPassword.Text.Trim();

            string connectionString = $"Server={server};Database={database};TrustServerCertificate=True;User Id={user};Password={password};";

            txtConnectionString.Text = connectionString;
        }

        private void btnTestConnection_Click(object sender, EventArgs e)
        {
            string connectionString = txtConnectionString.Text.Trim();

            DbContext dbContext = new DbContext(new DbContextOptionsBuilder().UseSqlServer(connectionString).Options);

            try
            {
                dbContext.Database.OpenConnection();
                lblConnectionTestResult.Text = Resources.Form_Connection_Result_Success;
                dbContext.Database.CloseConnection();
            }
            catch (Exception ex)
            {
                lblConnectionTestResult.Text = string.Format(Resources.Form_Connection_Result_Fail, ex.Message);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveConnectionString();
            MessageBox.Show(Resources.Form_Connection_Saved);
        }

        Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
        string nameConStr = "Foxoft.Properties.Settings.SubConnString";

        private void SaveConnectionString()
        {
            Settings.Default.SubConnString = txtConnectionString.Text.Trim();
            Settings.Default.Save(); // Save for subcontext

            config.ConnectionStrings.ConnectionStrings[nameConStr].ConnectionString = Settings.Default.SubConnString;
            config.ConnectionStrings.ConnectionStrings[nameConStr].ProviderName = "System.Data.SqlClient";
            config.Save(ConfigurationSaveMode.Modified); // Save permanently
        }

        private void btnCreateDatabase_Click(object sender, EventArgs e)
        {
            SaveConnectionString();
            subContext subContext = new();

            if (subContext.Database.CanConnect())
                XtraMessageBox.Show(Resources.Form_Connection_DbExists);
            else
            {
                subContext.Database.Migrate();
                //subContext.Database.EnsureCreated();

                var comps = efMethods.SelectCompanies();

                if (!comps.Any(x => x.CompanyCode == txtDatabase.Text))
                    efMethods.InsertEntity(new DcCompany() { CompanyCode = txtDatabase.Text, CompanyDesc = txtDatabase.Text });

                XtraMessageBox.Show(Resources.Form_Connection_DbCreated);
            }
        }
    }
}
