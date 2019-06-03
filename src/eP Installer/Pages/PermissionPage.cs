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
    public partial class PermissionPage : UserControl,IPage
    {
        public event NextPageEvent NextPage;

        public PermissionPage()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (NextPage != null)
                NextPage();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Are you sure to exit this installation?\r\nPress [Yes] to exit,Press [No] to back installation.", "eP Installion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
                Application.Exit();
        }
    }
}
