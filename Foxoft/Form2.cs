using System;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;
using Foxoft.Properties;
using Microsoft.EntityFrameworkCore;

namespace Foxoft
{
    public partial class Form2 : Form
    {
        private string initialConnectionString;

        public Form2(string connectionString)
        {
            InitializeComponent();
            initialConnectionString = connectionString;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // Load the provided connection string and fill textboxes
            if (!string.IsNullOrWhiteSpace(initialConnectionString))
            {
                var builder = new SqlConnectionStringBuilder(initialConnectionString);
                txtServer.Text = builder.DataSource;
                txtDatabase.Text = builder.InitialCatalog;
                txtUser.Text = builder.UserID;
                txtPassword.Text = builder.Password;
                txtConnectionString.Text = initialConnectionString;
            }
        }

        private void GenerateConnectionString(object sender, EventArgs e)
        {
            // Generate connection string based on user input
            string server = txtServer.Text.Trim();
            string database = txtDatabase.Text.Trim();
            string user = txtUser.Text.Trim();
            string password = txtPassword.Text.Trim();

            // EF Core connection string format with username and password
            string connectionString = $"Server={server};Database={database};User Id={user};Password={password};";

            txtConnectionString.Text = connectionString;
        }

        private void btnTestConnection_Click(object sender, EventArgs e)
        {
            // Test the connection using EF Core
            string connectionString = txtConnectionString.Text.Trim();

            using (var dbContext = new DbContext(new DbContextOptionsBuilder().UseSqlServer(connectionString).Options))
            {
                try
                {
                    // Try to open the connection
                    dbContext.Database.OpenConnection();
                    lblConnectionTestResult.Text = "Connection successful!";
                    dbContext.Database.CloseConnection();
                }
                catch (Exception ex)
                {
                    lblConnectionTestResult.Text = $"Connection failed: {ex.Message}";
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveConnectionString();
            MessageBox.Show("Connection string saved successfully.");
        }

        Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
        string nameConStr = "subConnString";

        private void SaveConnectionString()
        {
            Settings.Default.subConnString = txtConnectionString.Text.Trim();
            Settings.Default.Save(); // Save for subcontext

            config.ConnectionStrings.ConnectionStrings[nameConStr].ConnectionString = Settings.Default.subConnString;
            config.ConnectionStrings.ConnectionStrings[nameConStr].ProviderName = "System.Data.SqlClient";
            config.Save(ConfigurationSaveMode.Modified); // Save permenantly
        }
    }
}
