using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using eP_Installer.Pages;
using eP_Installer.InstallInfo;
using eP_Installer.ModuleBase;

namespace eP_Installer
{
    public partial class SetupMain : Form
    {
        public SetupMain()
        {
            InitializeComponent();
            Initization();
        }

        public void Initization()
        {
            MainInstall.InstallationPage = new eP_Install_Module.Pages.InstallationPage();
            MainInstall.InstallationPage.WelcomeEvent += InstallationPage_WelcomeEvent;
            MainInstall.InstallationPage.SelectPathEvent += InstallationPage_SelectPathEvent;
            MainInstall.InstallationPage.LicenseEvent += InstallationPage_LicenseEvent;
            MainInstall.InstallationPage.InstallingPageEvent += InstallationPage_InstallingPageEvent;
            MainInstall.InstallationPage.FinishPageEvent += InstallationPage_FinishPageEvent;
            LoadModule();
            //InstallStep1();
        }

        private void InstallationPage_FinishPageEvent(eP_Install_Module.Pages.FinishPage page)
        {
            FinishPage page_ = new FinishPage();
            page_.NextPage += page.GotoNextPage;
            page_.NeedToReboot = page.NeedReboot;
            this.installPage.Controls.Clear();
            this.installPage.Controls.Add(page_);
        }

        private void InstallationPage_InstallingPageEvent(eP_Install_Module.Pages.InstallingPage page)
        {
            InstallingPage page_ = new InstallingPage();
            page_.NextPage += page.GotoNextPage;
            page_.InstallCommands = page.InstallCommands;
            this.installPage.Controls.Clear();
            this.installPage.Controls.Add(page_);
        }

        private void InstallationPage_LicenseEvent(eP_Install_Module.Pages.LicensePage page)
        {
            IPage page_ = new LicensePage();
            page_.NextPage += page.GotoNextPage;
            if (page.type == eP_Install_Module.Pages.LicenseType.Others)
                ((LicensePage)page_).License = page.License;
            else if (page.type == eP_Install_Module.Pages.LicenseType.GPLV2)
                ((LicensePage)page_).LoadGPLv2License();
            else if (page.type == eP_Install_Module.Pages.LicenseType.GPLV3)
                ((LicensePage)page_).LoadGPLv3License();
            this.installPage.Controls.Clear();
            this.installPage.Controls.Add((Control)page_);
        }

        private void InstallationPage_SelectPathEvent(ref eP_Install_Module.Pages.SelectPathPage page)
        {
            IPage page_ = new SelectPathPage();
            page_.NextPage += page.GotoNextPage;
            ((SelectPathPage)page_).LinkInstallPath(ref page.InstallPath);
            this.installPage.Controls.Clear();
            this.installPage.Controls.Add((Control)page_);
        }

        private void InstallationPage_WelcomeEvent(eP_Install_Module.Pages.WelcomePage page)
        {
            IPage page_ = new WelcomePage();
            page_.NextPage += page.GotoNextPage;
            this.installPage.Controls.Clear();
            this.installPage.Controls.Add((Control)page_);
        }

        public void ChangePage(IPage page)
        {
            page.NextPage += NextPage;
            this.installPage.Controls.Clear();
            this.installPage.Controls.Add((Control)page);
        }

        public void NextPage()
        {
            ChangePage(new InstallingPage());
        }

        public void InstallStep1()
        {
            IPage page = new WelcomePage();
            page.NextPage += InstallStep2;
            this.installPage.Controls.Clear();
            this.installPage.Controls.Add((Control)page);
        }

        public void InstallStep2()
        {
            LicensePage page = new LicensePage();
            page.LoadGPLv3License();
            page.NextPage += InstallStep3;
            this.installPage.Controls.Clear();
            this.installPage.Controls.Add(page);
        }

        public void InstallStep3()
        {
            InstallingPage page = new InstallingPage();
            page.NextPage += InstallStep4;
            this.installPage.Controls.Clear();
            this.installPage.Controls.Add(page);
        }

        public void InstallStep4()
        {
            FinishPage page = new FinishPage();
            page.NeedToReboot = false;
            this.installPage.Controls.Clear();
            this.installPage.Controls.Add(page);
        }

        public void LoadModule()
        {
            ModuleLoad.Load();
        }
    }
}
