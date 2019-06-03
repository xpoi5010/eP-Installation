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
using System.Threading;
using eP_Install_Module;
namespace eP_Installer.Pages
{
    public partial class InstallingPage : UserControl,IPage
    {
        public event NextPageEvent NextPage;

        public InstallCommand[] InstallCommands;

        public InstallingPage()
        {
            InitializeComponent();
            //Debug
            Task task = new Task(FakeInstall);
            task.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Are you sure to exit this installation?\r\nPress [Yes] to exit,Press [No] to back installation.", "eP Installion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
                Application.Exit();
        }

        public void InstallFinished()
        {
            if(NextPage == null)
            {
                Application.Exit();
            }
            NextPage();
        }

        public void FakeInstall()
        {
            //使用於Debug用途
            Random rd = new Random();
            for(int i = 1; i <= 97;i++)
            {
                Thread.Sleep(rd.Next(15, 43));
                double d = (double)i / 97;
                d *= 100;
                int p = (int)d;
                BgReport($@"正在複製cab{i}.dat到{InstallInfo.MainInstall.InstallationPage.InstallPath}", p);
            }
        }

        public delegate void bgRd(string message, int p);
        public void BgReport(string message,int p)
        {
            if (this.InvokeRequired)
            {
                bgRd b = new bgRd(BgReport);
                this.Invoke(b, message,p);
            }
            else
            {
                this.textBox1.AppendText(message + "\r\n");
                this.progressBar1.Value = p;
                this.textBox1.ScrollToCaret();
                if (p == 100)
                    InstallFinished();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            

        }
    }
}
