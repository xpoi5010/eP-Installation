using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eP_Installer.IO
{
    public interface IProtocol
    {
        string Name { get; }

        void CopyFileTo(string path, string targer);
    }
}
