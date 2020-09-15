using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.Project
{
    public class VMOnlineTest
    {
        public long id_bio { get; set; }
        public string email_bio { get; set; }
        public string fullname { get; set; }

        public long id_ab { get; set; }
        public int attempt { get; set; }
        public string email_ab { get; set; }
        public string abuid { get; set; }
        public string abpwd { get; set; }
        public string fp_token { get; set; }
        public Nullable<System.DateTime> fp_expired_date { get; set; }
        public int fp_counter { get; set; }

        public long id_ot { get; set; }
        public long biodata_id { get; set; }
        public string period_code { get; set; }
        public Nullable<int> period { get; set; }
        public Nullable<System.DateTime> test_date { get; set; }
        public Nullable<System.DateTime> expired_test { get; set; }
        public string user_access { get; set; }
        public string status { get; set; }

        public long id_otd { get; set; }
        public Nullable<long> online_test_id { get; set; }
        public Nullable<long> test_type_id { get; set; }
        public Nullable<int> test_order { get; set; }

        public long id_tt { get; set; }
        public string name { get; set; }
        public string description { get; set; }

        public string test_name { get; set; }
    }
}
