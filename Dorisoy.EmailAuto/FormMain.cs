using System;
using System.Windows.Forms;

namespace Dorisoy.EmailAuto
{
    /// <summary>
    /// Main From
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    public partial class FormMain : Form
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FormMain"/> class.
        /// </summary>
        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            settingsToolStripMenuItem.Click += SettingsToolStripMenuItem_Click;
            emailBookToolStripMenuItem.Click += EmailBookToolStripMenuItem_Click;
            exitToolStripMenuItem.Click += ExitToolStripMenuItem_Click;
            aboutToolStripMenuItem.Click += AboutToolStripMenuItem_Click;
            var child = (Form)Program.ServiceProvider.GetService(typeof(FrmSendEmail));
            child.MdiParent = this;
            child.Show();
            child.WindowState = FormWindowState.Maximized;
        }

        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Dorisoy.EmailAuto, V1.0.0", "About", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DisposeAll();
            this.Dispose();
            this.Close();
        }

        private void SettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var child = (Form)Program.ServiceProvider.GetService(typeof(FrmSettings));
            child.ShowDialog();
        }

        private void EmailBookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var child = (Form)Program.ServiceProvider.GetService((typeof(FrmEmailBook)));
            child.ShowDialog();
        }

        private void DisposeAll()
        {
            foreach (Form frm in this.MdiChildren)
            {
                frm.Dispose();
                frm.Close();
            }
        }
    }
}
