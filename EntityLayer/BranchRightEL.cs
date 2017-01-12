using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
  public  class BranchRightEL
    {
        public int Code { get; set; }
        public int UserCD { get; set; }
        public int BranchCd { get; set; }
        public string branchName { get; set; }
        public int RoleCD { get; set; }
        public bool AllowYN { get; set; }
    }
}
