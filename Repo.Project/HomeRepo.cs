using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Project;
using ViewModel.Project;

namespace Repo.Project
{
    public class HomeRepo
    {
        public static List<VMMenu> getMenu(int role_id)
        {
            List<VMMenu> data = new List<VMMenu>();
            using (DBSpecEntities db = new DBSpecEntities())
            {
                data = (from mt in db.x_menutree
                        join ma in db.x_menu_access
                            on mt.id equals ma.menutree_id
                            where ma.role_id == role_id

                        select new VMMenu
                        {
                            id = mt.id,
                            title = mt.title,
                            menu_imageUrl = mt.menu_imageUrl,
                            menu_icon = mt.menu_icon,
                            menu_order = mt.menu_order,
                            menu_level = mt.menu_level,
                            menu_parent = mt.menu_parent,
                            menu_url = mt.menu_url,
                            menu_type = mt.menu_type

                        }).ToList();
            }
            return data;
        }
    }
}
