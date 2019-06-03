using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eP_Install_Module.Pages
{
    public class InstallingPage : IPage
    {
        public event NextPageEvent NextPage;

        public InstallCommand[] InstallCommands { get; set; }

        public void GotoNextPage()
        {
            NextPage?.Invoke();
        }

    }
}
