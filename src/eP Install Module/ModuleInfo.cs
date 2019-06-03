using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eP_Install_Module
{
    public class ModuleInfo
    {
        public string Author { get; private set; }

        public string Corporation { get; private set; }

        public string Version { get; set; }

        public string Name { get; set; }

        public ModuleType ModuleType { get; set; }
    }

    public enum ModuleType
    {
        InstallModule,Extension
    }
}
