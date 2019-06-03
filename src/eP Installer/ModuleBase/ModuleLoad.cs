using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Security;
using System.IO;
using eP_Install_Module;
using eP_Installer.InstallInfo;
using System.Windows.Forms;

namespace eP_Installer.ModuleBase
{
    public static class ModuleLoad
    {
        public static Assembly InstallModule;

        public static bool Load()
        {
            if (!File.Exists("ePInstall.Module.dll"))
                return false;
            try
            {
                Assembly assembly = Assembly.LoadFile(Application.StartupPath + "\\ePInstall.Module.dll");
                eP_Install_Module.Module m = (eP_Install_Module.Module)assembly.CreateInstance("ePInstall.Install.InstallModule");
                m.LoadModule(ref MainInstall.InstallationPage);
                InstallModule = assembly;
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
