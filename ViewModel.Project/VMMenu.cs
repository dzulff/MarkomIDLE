using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.Project
{
    public class VMMenu
    {
        public int id { get; set; }
        public string title { get; set; }
        public string menu_imageUrl { get; set; }
        public string menu_icon { get; set; }
        public int menu_order { get; set; }
        public int menu_level { get; set; }
        public Nullable<int> menu_parent { get; set; }
        public string menu_url { get; set; }
        public string menu_type { get; set; }
        public int created_by { get; set; }
        public System.DateTime created_on { get; set; }
        public Nullable<int> modified_by { get; set; }
        public Nullable<System.DateTime> modified_on { get; set; }
        public Nullable<int> delete_by { get; set; }
        public Nullable<System.DateTime> detele_on { get; set; }
        public bool is_delete { get; set; }
    }
}
