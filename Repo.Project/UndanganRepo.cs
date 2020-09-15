using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Project;
using System.Data.Entity;
using ViewModel.Project;
using System.Globalization;

namespace Repo.Project
{
    public class UndanganRepo
    {
        public static List<VMUndangan> getAllData()
        {
            List<VMUndangan> lisundangan = new List<VMUndangan>();
            using (DBSpecEntities db = new DBSpecEntities())
            {
                lisundangan = (from db1 in db.x_undangan
                               where db1.is_delete == false

                               join db2 in db.x_undangan_detail on db1.id equals db2.undangan_id

                               join db3 in db.x_schedule_type on db1.schedule_type_id equals db3.id

                               join db4 in db.x_time_period on db1.time equals db4.id

                               join db5 in db.x_biodata on db2.biodata_id equals db5.id

                               join db6 in db.x_riwayat_pendidikan on db1.id equals db6.biodata_id



                               //join und in db.x_biodata on pg.id equals und.id

                               //join emp in db.x_employee on pg.id equals emp.id

                               //join sch in db.x_schedule_type on pg.schedule_type_id equals sch.id


                               //join tim in db.x_time_period on pg.time equals tim.id.ToString()

                               //join undang in db.x_undangan_detail on pg.id equals undang.undangan_id


                               select new VMUndangan
                               {

                                   //biodata

                                   fullname = db5.fullname,

                                   //employee

                                   //undangan
                                   id_undangan = db1.id,
                                   schedule_type_id = db3.id,
                                   invitation_date = db1.invitation_date,
                                   invitation_code = db1.invitation_code,
                                   time = db4.id,
                                   ro = db1.ro,
                                   tro = db1.tro,
                                   other_ro_tro = db1.other_ro_tro,
                                   location = db1.location,

                                   //undangan_details

                                   biodata_id = db5.id,
                                   notes = db2.notes,
                                   undangandetail_id = db1.id,

                                   //riwayat_pendidikan
                                   biodata_id_pendidikan = db6.id,
                                   school_name = db6.school_name,
                                   major = db6.major


                               }).ToList();

            }
            return lisundangan;

        }

        public static List<x_schedule_type> getDataNama()
        {
            List<x_schedule_type> data = new List<x_schedule_type>();
            using (DBSpecEntities db = new DBSpecEntities())
            {
                data = db.x_schedule_type.ToList();
            }
            return data;
        }

        public static List<x_time_period> getDataTime()
        {
            List<x_time_period> data = new List<x_time_period>();
            using (DBSpecEntities db = new DBSpecEntities())
            {
                data = db.x_time_period.ToList();
            }
            return data;
        }

        public static List<x_biodata> getDataPelamar()
        {
            List<x_biodata> data = new List<x_biodata>();
            using (DBSpecEntities db = new DBSpecEntities())
            {
                data = db.x_biodata.ToList();
            }
            return data;
        }

        //public static List<x_biodata> getDataRoTro()
        //{
        //    List<x_biodata> data = new List<x_biodata>();
        //    using (DBSpecEntities db = new DBSpecEntities())
        //    {
        //        data = db.x_biodata.ToList();
        //    }
        //}

        //public static List<x_schedule_type> getDataSchedule()
        //{
        //    List<x_schedule_type> data = new List<x_schedule_type>();
        //    using (DBSpecEntities db = new DBSpecEntities())
        //    {
        //        data = db.x_schedule_type.ToList();
        //    }
        //    return data;
        //}

        //public static List<x_time_period> getDataTime()
        //{
        //    List<x_time_period> data = new List<x_time_period>();
        //    using (DBSpecEntities db = new DBSpecEntities())
        //    {
        //        data = db.x_time_period.ToList();
        //    }
        //    return data;
        //}



        public static bool saveData(VMUndangan und)
        {
            using (DBSpecEntities db = new DBSpecEntities())
            {
                try
                {
                    x_undangan dt = new x_undangan();
                    dt.created_by = 12;
                    dt.created_on = System.DateTime.Now;
                    dt.is_delete = false;

                    dt.schedule_type_id = und.schedule_type_id;
                    dt.invitation_date = und.invitation_date;
                    dt.invitation_code = generateKode("x_undangan");
                    dt.time = und.time;
                    dt.ro = und.ro;
                    dt.tro = und.tro;
                    dt.other_ro_tro = und.other_ro_tro;
                    dt.location = und.location;

                    //dt.invitation_code = generateKode("x_undangan");

                    //dt.invitation_date = und.invitation_date;
                    //dt.schedule_type_id = und.schedule_type_id;

                    //dt.time = und.time;
                    //dt.ro = und.ro;
                    //dt.tro = und.tro;
                    //dt.other_ro_tro = und.other_ro_tro;
                    //dt.location = und.location;
                    //dt.status = und.status;

                    db.x_undangan.Add(dt);
                    db.SaveChanges();

                    ////x_biodata dt2 = new x_biodata();
                    ////dt2.id = und.id;
                    //dt2.fullname = und.fullname;


                    ////dt2.fullname = und.fullname;
                    ////dt2.nick_name = und.nick_name;
                    ////dt2.pob = und.pob;
                    ////dt2.dob = und.dob;
                    ////dt2.gender = und.gender;
                    ////dt2.religion_id = und.religion_id;
                    ////dt2.high = und.high;
                    ////dt2.weight = und.weight;
                    ////dt2.nationally = und.nationally;
                    ////dt2.ethnic = und.ethnic;
                    ////dt2.hobby = und.hobby;
                    ////dt2.identity_type_id = und.identity_type_id;
                    ////dt2.identity_no = und.identity_no;
                    ////dt2.email = und.email;
                    ////dt2.phone_number1 = und.phone_number1;
                    ////dt2.phone_number2 = und.phone_number2;
                    ////dt2.parent_phone_number = und.parent_phone_number;
                    ////dt2.child_sequence = und.child_sequence;
                    ////dt2.how_many_brothers = und.how_many_brothers;
                    ////dt2.marital_status_id = und.marital_status_id;
                    ////dt2.marriage_year = und.marriage_year;
                    ////dt2.addrbook_id = und.addrbook_id;

                    ////dt2.created_by = 12;
                    ////dt2.created_on = System.DateTime.Now;
                    ////dt2.is_delete = false;

                    //db.x_biodata.Add(dt2);
                    //db.SaveChanges();




                    x_undangan_detail dt3 = new x_undangan_detail();
                    dt3.created_by = 12;
                    dt3.created_on = System.DateTime.Now;
                    dt3.undangan_id = dt.id;
                    dt3.is_delete = false;
                    dt3.biodata_id = dt.id;
                    dt3.notes = und.notes;
                    //dt3.undangan_id = und.id;
                    //dt3.biodata_id = und.id;
                    //dt3.notes = und.notes;

                    db.x_undangan_detail.Add(dt3);
                    db.SaveChanges();

                    return true;
                }

                catch (Exception)
                {
                    return false;
                    throw;
                }
            }
        }

        public static VMUndangan getDataByKode(long id)
        {
            VMUndangan data = new VMUndangan();
            using (DBSpecEntities db = new DBSpecEntities())
            {
                data = (from db1 in db.x_undangan

                        where db1.is_delete == false

                        join db2 in db.x_undangan_detail on db1.id equals db2.undangan_id

                        join db3 in db.x_schedule_type on db1.schedule_type_id equals db3.id

                        join db4 in db.x_time_period on db1.time equals db4.id

                        join db5 in db.x_biodata on db2.biodata_id equals db5.id

                        join db6 in db.x_riwayat_pendidikan on db1.id equals db6.biodata_id

                        where db1.id == id


                        select new VMUndangan
                        {

                            //biodata

                            fullname = db5.fullname,

                            //employee

                            //undangan
                            id_undangan = db1.id,
                            schedule_type_id = db3.id,
                            invitation_date = db1.invitation_date,
                            invitation_code = db1.invitation_code,
                            time = db4.id,
                            ro = db1.ro,
                            tro = db1.tro,
                            other_ro_tro = db1.other_ro_tro,
                            location = db1.location,

                            //undangan_details

                            biodata_id = db5.id,
                            notes = db2.notes,
                            undangandetail_id = db1.id,

                            //riwayat_pendidikan
                            biodata_id_pendidikan = db6.id,
                            school_name = db6.school_name,
                            major = db6.major

                            
                        }).FirstOrDefault();
            }
            return data;
        }

        public static bool updateData(VMUndangan und)
        {
            try
            {
                using (DBSpecEntities db = new DBSpecEntities())
                {
                    x_undangan dt = db.x_undangan.Where(a => a.id == und.id_undangan).FirstOrDefault();
                    dt.id = und.id_undangan;
                    dt.schedule_type_id = und.schedule_type_id;
                    dt.invitation_date = und.invitation_date;
                    //dt.invitation_code = und.invitation_code;
                    dt.time = und.time;
                    dt.ro = und.ro;
                    dt.tro = und.tro;
                    dt.other_ro_tro = und.other_ro_tro;
                    dt.location = und.location;
                    dt.modified_by = 12;
                    dt.modified_on = System.DateTime.Now;

                    db.Entry(dt).State = EntityState.Modified;
                    db.SaveChanges();

                    x_undangan_detail dt3 = db.x_undangan_detail.Where(a => a.undangan_id == und.undangandetail_id).FirstOrDefault();
                    //dt3.undangan_id = und.undangandetail_id;
                    //dt3.biodata_id = und.biodata_id;
                    dt3.notes = und.notes;


                    db.Entry(dt3).State = EntityState.Modified;
                    db.SaveChanges();

                    x_biodata dt4 = db.x_biodata.Where(a => a.id == und.biodata_id).FirstOrDefault();
                    dt4.fullname = und.fullname;

                    db.Entry(dt4).State = EntityState.Modified;
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
                    x_undangan dt = db.x_undangan.Where(a => a.id == id).FirstOrDefault();
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


        public static string generateKode(string type)
        {
            string Kode_Terakhir = "";
            int digit = 4;
            int digitnol = 0;
            string jmlNol = "";
            string strKode = "";
            using (DBSpecEntities db = new DBSpecEntities())
            {
                if (type == "x_undangan")
                {
                    Kode_Terakhir = db.x_undangan.OrderByDescending(a => a.invitation_code).Select(a => a.invitation_code).FirstOrDefault();
                    if (Kode_Terakhir == null)
                    {
                        Kode_Terakhir = "UND0000";
                    }
                    strKode = "UND";
                }
                else
                {

                }
                int angka = int.Parse(Kode_Terakhir.Substring(3, 4));
                angka += 1;
                if (angka.ToString().Length <= digit)
                {
                    digitnol = digit - angka.ToString().Length;
                    for (int i = 0; i < digitnol; i++)
                    {
                        jmlNol += "0";
                    }
                }
                Kode_Terakhir = strKode + jmlNol + angka;
            }
            return Kode_Terakhir;
        }
    }
}