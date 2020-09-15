using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Project;
using System.Data.Entity;
using ViewModel.Project;

namespace Repo.Project
{ 
    public class RepoSelectAccess
    {

        public static List<x_role> GetAllData()
        {
            List<x_role> allData = new List<x_role>();
            using(DBSpecEntities db= new DBSpecEntities())
            {
                allData = db.x_role.Where(a => a.is_delete == false).ToList();
            }
            return allData;
        }
        public static List<VMAccess> GetdataAccess(string email)
        {
            List<VMAccess> data = new List<VMAccess>();
            using (DBSpecEntities db = new DBSpecEntities())
            {
                data = (from rl in db.x_role
                        join usr in db.x_userrole on rl.id equals usr.role_id
                        join addr in db.x_addrbook on usr.addrbook_id equals addr.id
                        where addr.email == email          
                        select new VMAccess {
                            id=addr.id,
                            codeaccess= rl.code,
                            nameaccess=rl.name,
                            emailuser= addr.email
                        }).ToList();
            }
            return data;
        }


    }
}
