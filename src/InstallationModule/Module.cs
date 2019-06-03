using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eP_Install_Module;
using eP_Install_Module.Pages;
using System.Diagnostics;

namespace ePInstall.Install//Don't change namespace!!!
{
    public class InstallModule : Module
    {
        public InstallationPage InstallationPage;

        public override void LoadModule(ref InstallationPage page)
        {
            InstallationPage = page;
            Initization();
            Step1();
        }
        public void Initization()
        {
            InstallationPage.ProductName = "測試用安裝程式";
            InstallationPage.ProductVersion = "1.0";
            InstallationPage.Language = "zh-tw";
        }

        public void Step1()
        {
            WelcomePage page = new WelcomePage();
            page.NextPage += Step2;
            InstallationPage.WelcomePage(page);
        }

        public void Step2()
        {
            LicensePage page = new LicensePage();
            page.NextPage += Step3;
            page.LoadFromGPLV3();
            InstallationPage.LicensePage(page);
        }

        public void Step3()
        {
            SelectPathPage page = new SelectPathPage();
            page.NextPage += Step4;
            InstallationPage.SelectPathPage(ref page);
        }

        private void Step4()
        {
            string InstallPath = InstallationPage.InstallPath;
            Debug.Print(InstallPath);
            InstallingPage installingPage = new InstallingPage();
            installingPage.NextPage += Step5;
            InstallationPage.InstallingPage(installingPage);
        }

        private void Step5()
        {
            FinishPage page = new FinishPage();
            InstallationPage.FinishPage(page);
        }
    }
}
