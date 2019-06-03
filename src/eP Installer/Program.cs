using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;

namespace eP_Installer
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new SetupMain());
           // object F = Assembly.LoadFrom("http://app.yuanstudio.cc/webApp/猜數字.exe").CreateInstance("猜數字.Form1");
            //Application.Run((Form)F);
        }
    }
}
