using System;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid;

namespace Foxoft
{
    public partial class FeatureBrowserForm : Form
    {
        private GridView targetGridView;

        public FeatureBrowserForm(GridView gridView)
        {
            targetGridView = gridView;
            InitializeComponent();
            InitializeTreeViewNodes();
        }

        private void InitializeTreeViewNodes()
        {
            // Add nodes for features
            featureBrowser.Nodes.Add("Data Binding");
            featureBrowser.Nodes.Add("Columns");
            featureBrowser.Nodes.Add("Summary");
            featureBrowser.Nodes.Add("Filtering");
            featureBrowser.Nodes.Add("Behavior");
            featureBrowser.Nodes.Add("Editing");
            featureBrowser.Nodes.Add("Appearance");

            // Handle TreeView selection changes
            featureBrowser.AfterSelect += FeatureBrowser_AfterSelect;
        }

        private void FeatureBrowser_AfterSelect(object sender, TreeViewEventArgs e)
        {
            // Display the corresponding panel based on selected node
            string selectedNode = e.Node.Text;
            settingsPanel.Controls.Clear(); // Clear existing controls

            switch (selectedNode)
            {
                case "Data Binding":
                    ShowDataBindingPanel();
                    break;
                case "Columns":
                    ShowColumnsPanel();
                    break;
                case "Summary":
                    ShowSummaryPanel();
                    break;
                case "Filtering":
                    ShowFilteringPanel();
                    break;
                case "Behavior":
                    ShowBehaviorPanel();
                    break;
                case "Editing":
                    ShowEditingPanel();
                    break;
                case "Appearance":
                    ShowAppearancePanel();
                    break;
            }
        }

        private void ShowDataBindingPanel()
        {
            // Panel for Data Binding settings
            Label label = new Label { Text = "Data Binding Settings:", Dock = DockStyle.Top };
            TextBox dataSourceTextBox = new TextBox
            {
                Dock = DockStyle.Top
                //Text = targetGridView.GridControl.DataSource?.ToString() ?? "None"
            };
            dataSourceTextBox.ReadOnly = true;

            settingsPanel.Controls.Add(dataSourceTextBox);
            settingsPanel.Controls.Add(label);
        }

        private void ShowColumnsPanel()
        {
            // Panel for managing columns
            Label label = new Label { Text = "Manage Columns:", Dock = DockStyle.Top };
            Button addColumnButton = new Button { Text = "Add Column", Dock = DockStyle.Top };
            Button removeColumnButton = new Button { Text = "Remove Column", Dock = DockStyle.Top };

            addColumnButton.Click += (s, e) =>
            {
                targetGridView.Columns.Add();
            };
            removeColumnButton.Click += (s, e) =>
            {
                if (targetGridView.Columns.Count > 0)
                    targetGridView.Columns.RemoveAt(targetGridView.Columns.Count - 1);
            };

            settingsPanel.Controls.Add(removeColumnButton);
            settingsPanel.Controls.Add(addColumnButton);
            settingsPanel.Controls.Add(label);
        }

        private void ShowSummaryPanel()
        {
            // Panel for summary options
            Label label = new Label { Text = "Summary Options:", Dock = DockStyle.Top };
            CheckBox enableSummary = new CheckBox
            {
                Text = "Enable Footer Summary",
                Dock = DockStyle.Top,
                Checked = targetGridView.OptionsView.ShowFooter
            };

            enableSummary.CheckedChanged += (s, e) =>
            {
                targetGridView.OptionsView.ShowFooter = enableSummary.Checked;
            };

            settingsPanel.Controls.Add(enableSummary);
            settingsPanel.Controls.Add(label);
        }

        private void ShowFilteringPanel()
        {
            // Panel for filtering settings
            Label label = new Label { Text = "Filtering Settings:", Dock = DockStyle.Top };
            CheckBox allowFilter = new CheckBox
            {
                Text = "Allow Filtering",
                Dock = DockStyle.Top,
                Checked = targetGridView.OptionsCustomization.AllowFilter
            };

            allowFilter.CheckedChanged += (s, e) =>
            {
                targetGridView.OptionsCustomization.AllowFilter = allowFilter.Checked;
            };

            settingsPanel.Controls.Add(allowFilter);
            settingsPanel.Controls.Add(label);
        }

        private void ShowBehaviorPanel()
        {
            // Panel for behavior settings
            Label label = new Label { Text = "Behavior Settings:", Dock = DockStyle.Top };
            CheckBox autoUpdateSummary = new CheckBox
            {
                Text = "AutoUpdate Summary",
                Dock = DockStyle.Top,
                Checked = targetGridView.OptionsBehavior.AutoUpdateTotalSummary
            };

            autoUpdateSummary.CheckedChanged += (s, e) =>
            {
                targetGridView.OptionsBehavior.AutoUpdateTotalSummary = autoUpdateSummary.Checked;
            };

            settingsPanel.Controls.Add(autoUpdateSummary);
            settingsPanel.Controls.Add(label);
        }

        private void ShowEditingPanel()
        {
            // Panel for editing settings
            Label label = new Label { Text = "Editing Settings:", Dock = DockStyle.Top };
            CheckBox allowEditing = new CheckBox
            {
                Text = "Allow Editing",
                Dock = DockStyle.Top,
                Checked = targetGridView.OptionsBehavior.Editable
            };

            allowEditing.CheckedChanged += (s, e) =>
            {
                targetGridView.OptionsBehavior.Editable = allowEditing.Checked;
            };

            settingsPanel.Controls.Add(allowEditing);
            settingsPanel.Controls.Add(label);
        }

        private void ShowAppearancePanel()
        {
            // Panel for appearance settings
            Label label = new Label { Text = "Appearance Settings:", Dock = DockStyle.Top };
            Button setAppearanceButton = new Button { Text = "Customize Appearance", Dock = DockStyle.Top };

            setAppearanceButton.Click += (s, e) =>
            {
                MessageBox.Show("Appearance customization dialog not implemented yet.");
            };

            settingsPanel.Controls.Add(setAppearanceButton);
            settingsPanel.Controls.Add(label);
        }
    }
}
