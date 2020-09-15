using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.Project
{
    public class VMAccess
    {
        public long id { get; set; }
        public long addrbook_id { get; set; }
        public long role_id { get; set; }
        public long menutree_id { get; set; }
        public string codeaccess { get; set; }
        public string nameaccess { get; set; }
        public string emailuser { get; set; }
    }
}
