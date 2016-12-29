using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPAPracticeManagement.AppConstants
{
    public static class AppsPropertise
    {
        private static UserEL _objUserEL;
        public static UserEL UserDetails
        {
            get { return _objUserEL; }
            set { _objUserEL = value; }
        }
    }
}
