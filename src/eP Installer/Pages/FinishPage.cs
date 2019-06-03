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
    public partial class FinishPage : UserControl,IPage
    {
        public event NextPageEvent NextPage;

        public bool NeedToReboot = true;

        public FinishPage()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (NeedToReboot)
            {
                DialogResult dr = MessageBox.Show("This installion has finished,but it need to reboot your computer to finish it.\r\nYou want to reboot your computer right now?\r\nPress [Yes] to reboot,press [No] to finish without rebooting.","eP Installion",MessageBoxButtons.YesNo,MessageBoxIcon.Warning);
                if (dr == DialogResult.Yes)
                    Tools.Shutdown();
            }
            Application.Exit();
        }
    }
}
