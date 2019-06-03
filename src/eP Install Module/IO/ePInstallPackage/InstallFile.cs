using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eP_Installer.IO.ePInstallPackage
{
    public class InstallFile
    {
        public string OriginalFileLocation = "";

        public string TargerLocation = "";//$InstallPath @ environment var

        public InstallFile(string o,string i)
        {
            OriginalFileLocation = o;
            TargerLocation = i;
        }
    }
}
