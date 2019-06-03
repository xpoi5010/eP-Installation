using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace eP_Installer.IO.ePInstallPackage
{
    public static class OriginalFilePath
    {
        public static string[] Spliter(string str)
        {
            string[] output = new string[2];
            Regex regex = new Regex(@"^([a-zA-Z]*)\://(.*)");
            Match match = regex.Match(str);
            output[0] = match.Groups[1].Value;
            output[1] = match.Groups[1].Value;
            return output;
        }

        public static long[] SplitThis(string str)
        {
            long[] output = new long[2];
            Regex regex = new Regex(@"^offset\:(\d*)&size\:(\d*)");
            Match match = regex.Match(str);
            output[0] = Convert.ToInt64(match.Groups[1].Value);
            output[1] = Convert.ToInt64(match.Groups[2].Value);
            return output;
        }
    }
}
