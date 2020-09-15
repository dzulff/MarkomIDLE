using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Project;
using System.Web;
using System.Data.Entity;


namespace Repo.Project
{
    public class RepoRolePage
    {
        
        public static List<x_role> GetAllData()
        {
            List<x_role> allData = new List<x_role>();
            using (DBSpecEntities db = new DBSpecEntities())
            {
                allData = db.x_role.Where(a => a.is_delete == false).ToList();
            }
            return allData;
        }
        public static x_role GetAllDatabyId(long ID)
        {
            x_role output = new x_role();
            using (DBSpecEntities db= new DBSpecEntities())
            {
                output = db.x_role.Where(a => a.id == ID).FirstOrDefault();
            }
            return output;
        }
        public static string checkdataDuplicate(string rawData)
        {
            x_role data = new x_role();
            using(DBSpecEntities db= new DBSpecEntities())
            {
                data = db.x_role.Where(a => a.code.Contains(rawData)).FirstOrDefault();
                if (data != null)
                {
                    return "ada";
                }
                else
                {
                    return "tidak";
                }
            }
          
        }
        public static bool SaveData(x_role newData,long created)
        {
            try
            {
                
                using (DBSpecEntities db = new DBSpecEntities())
                {
                    newData.created_by = created;
                    newData.created_on = System.DateTime.Now;
                    newData.is_delete = false;

                    db.x_role.Add(newData);
                    
                    db.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
           
        }
        public static bool UpdateData(x_role newData, long updatedby)
        {
            try
            {
               
                using(DBSpecEntities db= new DBSpecEntities())
                {
                    x_role oldData = GetAllDatabyId(newData.id);

                  
                    oldData.modified_by = updatedby;
                    oldData.modified_on= System.DateTime.Now;
                    oldData.code = newData.code;
                    oldData.name = newData.name;
                    db.Entry(oldData).State = EntityState.Modified;
                    db.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        public static bool DeleteData(long id,long deleteby)
        {
            try
            {
                using (DBSpecEntities db= new DBSpecEntities())
                {
                    x_role data = GetAllDatabyId(id);
                    data.is_delete = true;
                    data.deleted_by = deleteby;
                    data.deleted_on = System.DateTime.Now;

                    db.Entry(data).State = EntityState.Modified;
                    db.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
