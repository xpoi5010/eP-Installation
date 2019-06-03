using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace eP_Installer.IO
{
    public static class PathCreater
    {
        public static void CreatePath(string Path)
        {
            PathInfo pi = new PathInfo(Path);
            for(int i = 1; i <= pi.MaxLevel; i++)
            {
                if (!Directory.Exists(pi.GetFullPath(i)))
                    Directory.CreateDirectory(pi.GetFullPath(i));
            }
        }
    }
}
