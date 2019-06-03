using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eP_Install_Module.Pages
{
    public class InstallationPage
    {
        public string ProductName { get; set; }

        public string ProductVersion { get; set; }

        public string Language { get; set; }

        public IPage NowPage { get; set; }

        public string InstallPath { get; set; }

        public InstallationPage()
        {

        }
        //
        public void WelcomePage(WelcomePage page)
        {
            WelcomeEvent?.Invoke(page);
        }

        public delegate void WelcomePageE(WelcomePage page);

        public event WelcomePageE WelcomeEvent;
        //
        public void LicensePage(LicensePage page)
        {
            LicenseEvent?.Invoke(page);
            NowPage = page;
        }

        public delegate void LicensePageE(LicensePage page);

        public event LicensePageE LicenseEvent;
        //
        public void SelectPathPage(ref SelectPathPage page)
        {
            SelectPathEvent?.Invoke(ref page);
            NowPage = page;
        }

        public delegate void SelectPathPageE(ref SelectPathPage page);

        public event SelectPathPageE SelectPathEvent;
        //
        public void InstallingPage(InstallingPage page)
        {
            InstallingPageEvent?.Invoke(page);
            NowPage = page;
        }

        public delegate void InstallingPageE(InstallingPage page);

        public event InstallingPageE InstallingPageEvent;

        //
        public void FinishPage(FinishPage page)
        {
            FinishPageEvent?.Invoke(page);
            NowPage = page;
        }

        public delegate void FinishPageE(FinishPage page);

        public event FinishPageE FinishPageEvent;
    }
}
