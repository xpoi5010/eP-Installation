using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eP_Install_Module.Pages;

namespace eP_Install_Module
{
    public abstract class Module
    {
        public ModuleInfo ModuleInfo { get;}

        public abstract void LoadModule(ref InstallationPage MainPage);
    }
}
