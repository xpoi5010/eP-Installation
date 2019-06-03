using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eP_Install_File_Manager
{
    public static class stringExtension
    {
        public static int LineCount(this string str)
        {
            return Array.FindAll(str.ToArray(), x => x == '\n').Length + 1;
        }
    }
}
