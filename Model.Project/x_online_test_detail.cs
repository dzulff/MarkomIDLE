//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Model.Project
{
    using System;
    using System.Collections.Generic;
    
    public partial class x_online_test_detail
    {
        public long id { get; set; }
        public long created_by { get; set; }
        public System.DateTime created_on { get; set; }
        public Nullable<long> modified_by { get; set; }
        public Nullable<System.DateTime> modified_on { get; set; }
        public Nullable<long> deleted_by { get; set; }
        public Nullable<System.DateTime> deleted_on { get; set; }
        public bool is_delete { get; set; }
        public Nullable<long> online_test_id { get; set; }
        public Nullable<long> test_type_id { get; set; }
        public Nullable<int> test_order { get; set; }
    }
}