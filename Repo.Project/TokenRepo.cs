using Model.Project;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repo.Project
{
    public class TokenRepo
    {
        public static x_biodata getDataByKode(long id)
        {
            x_biodata data = new x_biodata();
            using (DBSpecEntities db = new DBSpecEntities())
            {
                data = db.x_biodata.Where(a => a.id == id).FirstOrDefault();
            }
            return data;
        }

        public static bool ExpDate(long id)
        {
            try
            {
                using (DBSpecEntities db = new DBSpecEntities())
                {
                    x_biodata dtBio = getDataByKode(id);
                    //dtBio.expired_token = 
                    db.Entry(dtBio).State = EntityState.Modified;
                    db.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }
    }
}
