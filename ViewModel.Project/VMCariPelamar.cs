using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.Project
{
    public class VMCariPelamar
    {
        public long id { get; set; }
        public long created_by { get; set; }
        public System.DateTime created_on { get; set; }
        public Nullable<long> modified_by { get; set; }
        public Nullable<System.DateTime> modified_on { get; set; }
        public Nullable<long> deleted_by { get; set; }
        public Nullable<System.DateTime> deleted_on { get; set; }
        public bool is_delete { get; set; }
        public string fullname { get; set; }
        public string nick_name { get; set; }
        public string pob { get; set; }
        public bool gender { get; set; }
        public long religion_id { get; set; }
        public Nullable<int> high { get; set; }
        public Nullable<int> wight { get; set; }
        public string nationality { get; set; }
        public string ethnic { get; set; }
        public string hobby { get; set; }
        public long identity_type_id { get; set; }
        public string identity_no { get; set; }
        public string email { get; set; }
        public string phone_number1 { get; set; }
        public string phone_number2 { get; set; }
        public string parent_phone_number { get; set; }
        public string child_sequence { get; set; }
        public string how_many_brothers { get; set; }
        public long marital_status_id { get; set; }
        public Nullable<long> addrbook_id { get; set; }
        public string token { get; set; }
        public Nullable<System.DateTime> expired_token { get; set; }
        public string marriage_year { get; set; }
        public long company_id { get; set; }
        public Nullable<bool> is_process { get; set; }
        public Nullable<bool> is_complete { get; set; }

        public long biodata_id { get; set; }

        public string school_name { get; set; }
        public string major { get; set; }
        public string graduation_year { get; set; }
        
        public string period_code { get; set; }
        public Nullable<int> period { get; set; }
        public Nullable<System.DateTime> test_date { get; set; }
        public Nullable<System.DateTime> expired_test { get; set; }
        public string user_access { get; set; }
        public string status { get; set; }


        public Nullable<long> online_test_id { get; set; }
        public Nullable<long> test_type_id { get; set; }
        public Nullable<int> test_order { get; set; }
    }
}
