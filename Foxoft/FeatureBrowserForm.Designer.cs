using System.Windows.Forms;

namespace Foxoft
{
    partial class FeatureBrowserForm
    {
        private SplitContainer splitContainer;
        private TreeView featureBrowser;
        private Panel settingsPanel;

        private void InitializeComponent()
        {
            // Initialize SplitContainer
            splitContainer = new SplitContainer
            {
                Dock = DockStyle.Fill,
                Orientation = Orientation.Vertical,
            };

            // Initialize Feature Browser (TreeView)
            featureBrowser = new TreeView
            {
                Dock = DockStyle.Fill,
            };

            // Initialize Settings Panel
            settingsPanel = new Panel
            {
                Dock = DockStyle.Fill,
            };

            // Assemble SplitContainer
            splitContainer.Panel1.Controls.Add(featureBrowser);
            splitContainer.Panel2.Controls.Add(settingsPanel);

            // Configure Form
            this.Controls.Add(splitContainer);
            this.Text = "GridView Feature Browser";
            this.WindowState = FormWindowState.Maximized;
        }
    }
}
