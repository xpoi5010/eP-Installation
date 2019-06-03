using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace eP_Installer.IO
{
    public class PathInfo
    {
        public string OriginalPath = "";

        private string[] Split;

        public int MaxLevel => Split.Length - 1;

        public PathInfo(string Path)
        {
            OriginalPath = Path;
            Initization();
        }

        private void Initization()
        {
            if (
                Environment.OSVersion.Platform == PlatformID.Win32NT ||
                Environment.OSVersion.Platform == PlatformID.Win32S ||
                Environment.OSVersion.Platform == PlatformID.Win32Windows)
            {
                Windows();
            }
            else if(Environment.OSVersion.Platform== PlatformID.Unix || Environment.OSVersion.Platform == PlatformID.MacOSX)
            {
                Unix();
            }
        }

        private void Unix()
        {

        }

        private void Windows()
        {
            Regex regex1 = new Regex(@"([A-Za-z]{1})\:(.*)");
            Match match = regex1.Match(OriginalPath);
            string root = match.Groups[1].Value + ":";
            string p2 = match.Groups[2].Value;
            Regex regex2 = new Regex(@"\\([^\\]*)");
            MatchCollection mc = regex2.Matches(p2);
            List<string> splits = new List<string>();
            splits.Add(root);
            foreach(Match matc in mc)
            {
                splits.Add(matc.Groups[1].Value);
            }
            Split = splits.ToArray();
        }

        public string GetFullPath(int level)
        {
            if (level >= Split.Length)
                return OriginalPath;
            string[] c = new string[level];
            Array.Copy(Split, 1, c, 0, level);
            string[] Con = Array.ConvertAll(c, x => "\\" + x);
            return Split[0] + String.Join("",Con);
        }

    }
}
