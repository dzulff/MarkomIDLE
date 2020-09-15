using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.Project
{
    public class VMUndangan
    {
        //x_biodata
        public long id_biodata { get; set; }
        public string fullname { get; set; }

        //x_employee
        public Nullable<bool> is_ero { get; set; }


        //x_undangan
        public long id_undangan { get; set; }
        public long created_by { get; set; }
        public System.DateTime created_on { get; set; }
        //public Nullable<long> modified_by { get; set; }
        //public Nullable<System.DateTime> modified_on { get; set; }
        //public Nullable<long> deleted_by { get; set; }
        //public Nullable<System.DateTime> deleted_on { get; set; }
        public bool is_delete { get; set; }
        public Nullable<long> schedule_type_id { get; set; }
        public Nullable<System.DateTime> invitation_date { get; set; }
        public string invitation_code { get; set; }
        //public string time { get; set; }
        public Nullable<long> time { get; set; }

        public Nullable<long> ro { get; set; }
        public Nullable<long> tro { get; set; }
        public string other_ro_tro { get; set; }
        public string location { get; set; }
        //public string status { get; set; }

        //x_undangan_detail

        public long undangandetail_id { get; set; }
        public long biodata_id { get; set; }
        public string notes { get; set; }


        //x_time_periode
        public string name { get; set; }
        public string description { get; set; }

        //x_riwayat_pendidikan
        public long id_pendidikan { get; set; }
        public long biodata_id_pendidikan { get; set; }
        public string school_name { get; set; }
        public string major { get; set; }

       
    }
}
