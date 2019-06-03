using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eP_Install_Module.Pages
{
    public class LicensePage : IPage
    {
        public event NextPageEvent NextPage;

        private string license = "";

        public string License
        {
            get
            {
                return license;
            }
            set
            {
                license = value;

                type = LicenseType.Others;
            }
        }

        public LicenseType type { get; set; }

        public LicensePage()
        {
            type = LicenseType.Others;
        }

        public void LoadFromGPLV3()
        {
            type = LicenseType.GPLV3;
        }

        public void LoadFromGPLV2()
        {
            type = LicenseType.GPLV2;
        }

        public void GotoNextPage()
        {
            NextPage?.Invoke();
        }
    }

    public enum LicenseType
    {
        GPLV3,GPLV2,Others
    }
}
