using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.Project
{
    public class VMTimesheet
    {
        public long id { get; set; }
        public long client_id { get; set; }
        public string clientName { get; set; }
        public long employee_id { get; set; }
        public bool is_placement_active { get; set; }
        public long placement_id { get; set; }

       
    }
}
