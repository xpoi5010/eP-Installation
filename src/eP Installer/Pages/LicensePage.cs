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
    public partial class LicensePage : UserControl,IPage
    {
        public event NextPageEvent NextPage;

        public string license = "";

        public string License
        {
            get
            {
                return license;
            }
            set
            {
                license = value;
                textBox1.Text = license;
            }
        }

        public LicensePage()
        {
            InitializeComponent();
            button2.Enabled = checkBox1.Checked;
        }

        public void LoadGPLv3License()
        {
            License = eP_Installer.License.GPLV3;
        }

        public void LoadGPLv2License()
        {
            License = eP_Installer.License.GPLV2;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked && NextPage != null)
                NextPage();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            button2.Enabled = checkBox1.Checked;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Are you sure to exit this installation?\r\nPress [Yes] to exit,Press [No] to back installation.", "eP Installion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
                Application.Exit();
        }
    }
}
