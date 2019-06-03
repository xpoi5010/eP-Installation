using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eP_Installer.Permission
{
    public static class PermissionManagement
    {
        public static bool UAC = true;

        public static bool FileAccess = true;

        public static bool Network = true;

        public static bool Registry = true;

        public static bool Advertisement= false;

        public static bool CreateShortcut = true;

        public static bool CloseProgram = true;

        public static bool Reboot = true;
    }
}
