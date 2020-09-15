using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.Project
{
    public class VMPelamar
    {
        public long created_by { get; set; }
        public System.DateTime created_on { get; set; }
        public Nullable<long> modified_by { get; set; }
        public Nullable<System.DateTime> modified_on { get; set; }
        public Nullable<long> deleted_by { get; set; }
        public Nullable<System.DateTime> deleted_on { get; set; }
        public bool is_delete { get; set; }
        public long biodata_id { get; set; }
        public string address1 { get; set; }
        public string postal_code1 { get; set; }
        public string rt1 { get; set; }
        public string rw1 { get; set; }
        public string kelurahan1 { get; set; }
        public string kecamatan1 { get; set; }
        public string region1 { get; set; }
        public string address2 { get; set; }
        public string postal_code2 { get; set; }
        public string rt2 { get; set; }
        public string rw2 { get; set; }
        public string kelurahan2 { get; set; }
        public string kecamatan2 { get; set; }
        public string region2 { get; set; }
     
        public string fullname { get; set; }
        public string nick_name { get; set; }
        public string pob { get; set; }
        public System.DateTime dob { get; set; }

        public bool gender { get; set; }
        public string genderr { get; set; }

        public long religion_id { get; set; }
        public string religion { get; set; }

        public Nullable<int> high { get; set; }

        public Nullable<int> weight { get; set; }
        public string nationally { get; set; }
        public string ethnic { get; set; }
        public string hobby { get; set; }

        public long identity_type_id { get; set; }
        public string identity_type { get; set; }

        public string identity_no { get; set; }
        

        public string email { get; set; }
        public string phone_number1 { get; set; }
        public string phone_number2 { get; set; }
        public string parent_phone_number { get; set; }
        public string child_sequence { get; set; }
        public string how_many_brothers { get; set; }

        public long marital_status_id { get; set; }
        public string marital_status { get; set; }

        public Nullable<long> addrbook_id { get; set; }
        public string token { get; set; }
        public Nullable<System.DateTime> expired_token { get; set; }
        public string marriage_year { get; set; }
        public long company_id { get; set; }
        public Nullable<bool> is_process { get; set; }
        public Nullable<bool> is_complete { get; set; }
    }
}
