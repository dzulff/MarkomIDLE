using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Project;

namespace Repo.Project
{
    public class ReligionRepo
    {
        public static List<x_religion> getAllReligion()
        {
            List<x_religion> alldata = new List<x_religion>();

            using (DBSpecEntities db = new DBSpecEntities())
            {
                alldata = db.x_religion.Where(a => a.is_delete == false).ToList();
            }
            return alldata;
        }

        public static bool SaveData(x_religion rel)
        {
            try
            {
                using (DBSpecEntities db = new DBSpecEntities())
                {
                    rel.created_by = 1;
                    rel.created_on = System.DateTime.Now;
                    rel.is_delete = false;

                    db.x_religion.Add(rel);
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

        public static x_religion getDataByKode(long id)
        {
            x_religion data = new x_religion();
            using (DBSpecEntities db = new DBSpecEntities())
            {
                data = db.x_religion.Where(a => a.id == id).FirstOrDefault();
            }
            return data;
        }

        public static bool UpdateData(x_religion rel)
        {
            try
            {
                using (DBSpecEntities db = new DBSpecEntities())
                {
                    x_religion dtRel = db.x_religion.Where(a => a.id == rel.id).FirstOrDefault();
                    dtRel.name = rel.name;
                    dtRel.description = rel.description;
                    dtRel.modified_on = DateTime.Now;


                    db.Entry(dtRel).State = EntityState.Modified;
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

        public static bool DeleteData(long id)
        {
            try
            {
                using (DBSpecEntities db = new DBSpecEntities())
                {
                    x_religion dtRel = getDataByKode(id);

                    dtRel.is_delete = true;
                    dtRel.deleted_on = DateTime.Now;
                    db.Entry(dtRel).State = EntityState.Modified;
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

        public static string CekNama(string name)
        {
            using (DBSpecEntities db = new DBSpecEntities())
            {
                x_religion dt = db.x_religion.Where(a => a.name.Equals(name)).Where(a => a.is_delete == false).FirstOrDefault();
                if (dt != null)
                {
                    return "ada";
                }
                else
                {
                    return "tidak ada";
                }
            }
        }
    }
}
