using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eP_Install_Module.Pages
{
    public class SelectPathPage : IPage
    {
        public event NextPageEvent NextPage;

        public string InstallPath = "";

        public void GotoNextPage()
        {
            NextPage?.Invoke();
        }
    }

    public class SelectPathReturn
    {
        public string InstallPath { get; set; }
    }
}
