using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.Project
{
    public class VMCheck
    {
        public bool MyChecked { get; set; }
        public long Id { get; set; }
        public bool ToF { get; set; }
        public string Value { get; set; }
        public long placement_id { get; set; }

        public string status { get; set; }

        public Nullable<System.DateTime> timesheet_date { get; set; }

        public string user_approval { get; set; }
        public Nullable<System.DateTime> approved_on { get; set; }


    }
}
