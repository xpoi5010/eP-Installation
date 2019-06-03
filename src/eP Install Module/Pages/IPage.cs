using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eP_Install_Module.Pages
{
    public interface IPage
    {
        event NextPageEvent NextPage;
    }

    public delegate void NextPageEvent();
}
