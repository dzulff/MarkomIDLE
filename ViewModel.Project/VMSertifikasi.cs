using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.Project
{
    public class VMSertifikasi
    {
        public long id_biodata { get; set; }
        public long created_by { get; set; }
        public System.DateTime created_on { get; set; }
        public Nullable<long> modified_by { get; set; }
        public Nullable<System.DateTime> modified_on { get; set; }
        public Nullable<long> deleted_by { get; set; }
        public Nullable<System.DateTime> deleted_on { get; set; }
        public bool is_delete { get; set; }
        public long biodata_id { get; set; }
        public string certificate_name { get; set; }
        public string publisher { get; set; }
        public string valid_start_year { get; set; }
        public string valid_start_month { get; set; }
        public string until_year { get; set; }
        public string until_month { get; set; }
        public string notes { get; set; }

        public long id { get; set; }
    }
}
