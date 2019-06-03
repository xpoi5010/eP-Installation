using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eP_Install_Module
{
    public class InstallCommand
    {
        public string Command { get; set; }

        public object[] args { get; set; }

        public InstallCommand(string command,params object[] args)
        {
            Command = command;
            this.args = args;
        }
    }
}
