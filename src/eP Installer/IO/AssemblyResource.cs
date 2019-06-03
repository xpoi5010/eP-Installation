using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace eP_Installer.IO
{
    public class AssemblyResource: IProtocol

    {
        public string Name => "resource";

        public void CopyFileTo(string path, string targer)
        {
            Stream s = ModuleBase.ModuleLoad.InstallModule.GetManifestResourceStream(path);
            FileStream fs = new FileStream(targer, FileMode.Create);
            for(long i = 0; i < s.Length; i += 131072)
            {
                byte[] bytes = new byte[(s.Length - i) >= 131072 ? 131072 : (s.Length - i)];
                s.Read(bytes, 0, bytes.Length);
                fs.Write(bytes, 0, bytes.Length);
            }
            fs.Close();
            s.Close();
        }

        public string[] GetFiles()
        {
            return ModuleBase.ModuleLoad.InstallModule.GetManifestResourceNames();
        }


    }
}
