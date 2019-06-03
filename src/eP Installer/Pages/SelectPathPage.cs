using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using eP_Installer.InstallTool;

namespace eP_Installer.Pages
{
    public partial class SelectPathPage : UserControl,IPage
    {
        public event NextPageEvent NextPage;

        public bool NeedToReboot = true;

        public string InstallPath = @"C:\Program Files\{ProductName}\";

        public SelectPathPage()
        {
            InitializeComponent();
        }

        public void LinkInstallPath(ref string InstallPath)
        {
            this.InstallPath = InstallPath;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Are you sure to exit this installation?\r\nPress [Yes] to exit,Press [No] to back installation.", "eP Installion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
                Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            InstallPath = textBox1.Text;
            InstallInfo.MainInstall.InstallationPage.InstallPath = InstallPath;
            NextPage?.Invoke();
        }
    }
}
