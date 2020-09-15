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
    public class SertifikasiRepo
    {
        public static List<VMSertifikasi> getAllData()
        {
            List<VMSertifikasi> listsertifikasi = new List<VMSertifikasi>();
            using (DBSpecEntities db = new DBSpecEntities())
            {
                listsertifikasi = (from pg in db.x_sertifikasi
                           where pg.is_delete == false

                           join pgg in db.x_biodata on pg.biodata_id equals pgg.id
                           where pg.biodata_id == 1
                           //where pg.biodata_id == pgg.id
      

                           select new VMSertifikasi
                           {
                               id = pg.id,
                               id_biodata = pgg.id,
                               biodata_id = pgg.id,
                               certificate_name = pg.certificate_name,
                               publisher = pg.publisher,
                               valid_start_month = pg.valid_start_month,
                               valid_start_year = pg.valid_start_year,
                               until_month = pg.until_month,
                               until_year = pg.until_year,
                               notes = pg.notes,


                           }).ToList();

            }
            return listsertifikasi;
        }

        public static bool saveData(VMSertifikasi sert)
        {
            try
            {
                using (DBSpecEntities db = new DBSpecEntities())
                {
                    x_sertifikasi dt = new x_sertifikasi();
                    dt.created_by = 098765;
                    dt.created_on = System.DateTime.Now;
                    dt.is_delete = false;
                    dt.certificate_name = sert.certificate_name;
                    dt.publisher = sert.publisher;
                    dt.valid_start_month = sert.valid_start_month;
                    dt.valid_start_year = sert.valid_start_year;
                    dt.until_month = sert.until_month;
                    dt.until_year = sert.until_year;
                    dt.notes = sert.notes;
                    dt.id = sert.id;
                    dt.biodata_id = sert.id_biodata;

                    db.x_sertifikasi.Add(dt);
                    db.SaveChanges();

                    //x_biodata dt2 = new x_biodata();
                    //dt2.id = sert.id;

                    //db.x_biodata.Add(dt2);
                    //db.SaveChanges();
                    //x_biodata dt2 = new x_biodata();
                    //dt2.id = sert.biodata_id;
                    //db.x_biodata.Add(dt2);
                    //db.SaveChanges();

                    //x_biodata dt2 = new x_biodata();
                    //dt2.id = sert.biodata_id;

                    //db.x_biodata.Add(dt2);
                    //db.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        //public static x_sertifikasi getdataBykode(long id)
        //{
        //    x_sertifikasi data = new x_sertifikasi();
        //    using (DBSpecEntities db = new DBSpecEntities())
        //    {
        //        data = db.x_sertifikasi.Where(a => a.id == id).FirstOrDefault();

        //    }
        //    return data;
        //}


        public static VMSertifikasi getDataByKode(long id)
        {
            VMSertifikasi listsertifikasi = new VMSertifikasi();
            using (DBSpecEntities db = new DBSpecEntities())
            {
                listsertifikasi = (from pg in db.x_sertifikasi
                                   where pg.is_delete == false

                                   join pgg in db.x_biodata on pg.biodata_id equals pgg.id
                                   where pg.id == id

                                   select new VMSertifikasi
                                   {
                                       id = pg.id,
                                       id_biodata = pgg.id,
                                       biodata_id = pgg.id,
                                       certificate_name = pg.certificate_name,
                                       publisher = pg.publisher,
                                       valid_start_month = pg.valid_start_month,
                                       valid_start_year = pg.valid_start_year,
                                       until_month = pg.until_month,
                                       until_year = pg.until_year,
                                       notes = pg.notes
                                    }).FirstOrDefault();
            }
            return listsertifikasi;
        }

        public static bool updateData(VMSertifikasi sert)
        {
            try
            {
                using (DBSpecEntities db = new DBSpecEntities())
                {
                    x_sertifikasi dt = db.x_sertifikasi.Where(a => a.id == sert.id).FirstOrDefault();
                    dt.certificate_name = sert.certificate_name;
                    dt.publisher = sert.publisher;
                    dt.valid_start_month = sert.valid_start_month;
                    dt.valid_start_year = sert.valid_start_year;
                    dt.until_month = sert.until_month;
                    dt.until_year = sert.until_year;
                    dt.notes = sert.notes;
                   
                    //dt.modified_by = sert.modified_by;
                    //dt.modified_on = System.DateTime.Now;
                    //dt.deleted_by = sert.deleted_by;
                    //dt.deleted_on = System.DateTime.Now;
                    //dt.created_by = sert.created_by;
                    //dt.created_on = System.DateTime.Now;
                    dt.biodata_id = sert.id;


                    db.Entry(dt).State = EntityState.Modified;
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

        public static bool deleteData(long id)
        {
            try
            {
                using (DBSpecEntities db = new DBSpecEntities())
                {
                    x_sertifikasi dt = db.x_sertifikasi.Where(a => a.id == id).FirstOrDefault();

                    dt.is_delete = true;
                    db.Entry(dt).State = EntityState.Modified;
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
