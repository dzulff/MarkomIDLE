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
    public class BiodataRepo
    {
        public static List<VMPelamar> getAllData()
        {
            List < VMPelamar> alldata = new List<VMPelamar>();
            using (DBSpecEntities db = new DBSpecEntities())
            {
                alldata = (from pg in db.x_biodata
                           where pg.is_delete == false
                           join gr in db.x_address on pg.addrbook_id equals gr.id

                           join df in db.x_religion on pg.religion_id equals df.id         
                           join dff in db.x_identity_type on pg.identity_type_id equals dff.id
                           join ff in db.x_marital_status on pg.marital_status_id equals ff.id


                           select new VMPelamar
                           {
                               fullname = pg.fullname,
                               nick_name = pg.nick_name,
                               pob = pg.pob,
                               dob = pg.dob,
                               //gender = pg.gender,
                               //religion_id = pg.religion_id,
                               high = pg.high,
                               weight = pg.weight,
                               nationally = pg.nationally,
                               ethnic = pg.ethnic,
                               hobby = pg.hobby,
                               //identity_type_id = pg.identity_type_id,
                               identity_no = pg.identity_no,
                               email = pg.email,
                               phone_number1 = pg.phone_number1,
                               phone_number2 = pg.phone_number2,
                               parent_phone_number = pg.parent_phone_number,
                               child_sequence = pg.child_sequence,
                               how_many_brothers = pg.how_many_brothers,
                              
                               marriage_year = pg.marriage_year,
                               
                               addrbook_id = gr.id,

                               religion_id = pg.religion_id,
                               religion = df.name,

                               identity_type_id = pg.identity_type_id,
                               identity_type = dff.name,

                               marital_status_id = pg.marital_status_id,
                               marital_status = ff.name,

                               address1 = gr.address1,
                               postal_code1 = gr.postal_code1,
                               rt1 = gr.rt1,
                               rw1 = gr.rw1,
                               kelurahan1 = gr.kelurahan1,
                               kecamatan1 = gr.kecamatan1,  
                               region1 = gr.region1,                     
                               address2 = gr.address2,
                               postal_code2 = gr.postal_code2,
                               rt2 = gr.rt2,
                               rw2 = gr.rw2,
                               kelurahan2 = gr.kelurahan2,
                               kecamatan2 = gr.kecamatan2,
                               region2 = gr.region2
                           }).ToList();
            }
            return alldata;
        }

        public static List<x_religion> getDataNama()
        {
            List<x_religion> data = new List<x_religion>();
            using (DBSpecEntities db = new DBSpecEntities())
            {
                data = db.x_religion.ToList();
            }
            return data;
        }

        public static List<x_marital_status> getDataStatus()
        {
            List<x_marital_status> data = new List<x_marital_status>();
            using (DBSpecEntities db = new DBSpecEntities())
            {
                data = db.x_marital_status.ToList();
            }
            return data;
        }

        public static List<x_identity_type> getDataIdentitas()
        {
            List<x_identity_type> data = new List<x_identity_type>();
            using (DBSpecEntities db = new DBSpecEntities())
            {
                data = db.x_identity_type.ToList();
            }
            return data;
        }
     
        //public static bool saveData(x_biodata bio)
        //{
        //    try
        //    {
        //        using (DBSpecEntities db = new DBSpecEntities())
        //        {
        //            bio.created_by = 12;
        //            bio.created_on = System.DateTime.Now;
        //            bio.is_delete = false;

        //            db.x_biodata.Add(bio);
        //            db.SaveChanges();


        //        }
        //        return true;
        //    }
        //    catch (Exception)
        //    {
        //        return false;
        //        throw;
        //    }
        //}

        public static string CekEmail(string email)
        {
            using (DBSpecEntities db = new DBSpecEntities())
            {
                x_biodata dt = db.x_biodata.Where(a => a.email.Equals(email)).FirstOrDefault();
                if(dt != null)
                {
                    return "ada";
                }
                else
                {
                    return "tidak ada";
                }
            }
        }

        public static string CekTelp(string phone_number1)
        {
            using (DBSpecEntities db = new DBSpecEntities())
            {
                x_biodata dt = db.x_biodata.Where(a => a.phone_number1.Equals(phone_number1)).FirstOrDefault();
                if(dt != null)
                {
                    return "ada";
                }
                else
                {
                    return "tidak ada";
                }
            }
        }

        //public static string CekNoIden(string identity_no)
        //{
        //    using (DBSpecEntities db = new DBSpecEntities())
        //    {
        //        x_biodata dt = db.x_biodata.Where(a => a.identity_no.Equals(identity_no)).FirstOrDefault();
        //        if(dt!= null)
        //        {
        //            return "ada";
        //        }
        //        else
        //        {
        //            return "tidak ada";
        //        }
        //    }
        //}
        //public static string CekNoIden(string identity_no, int identity_type_id)
        //{
        //    using (DBSpecEntities db = new DBSpecEntities())
        //    {
        //        x_biodata dt = db.x_biodata.Where(a => a.identity_no.Equals(identity_no)).FirstOrDefault();
        //        x_biodata dt2 = db.x_biodata.Where(b => b.identity_type_id.Equals(identity_type_id)).FirstOrDefault();
        //        if (dt != null)
        //        {
        //            if (dt2 != null)
        //            {
        //                return "ada";
        //            }
        //        }
        //        else
        //        {
        //            return "tidak ada";
        //        }
        //    }
        //}

        public static bool saveData(VMPelamar bio)
        {
            using (DBSpecEntities db = new DBSpecEntities())
            {
                try
                {
                    x_biodata isibiodata = new x_biodata();
                    isibiodata.fullname = bio.fullname;
                    isibiodata.nick_name = bio.nick_name;
                    isibiodata.pob = bio.pob;
                    isibiodata.dob = bio.dob;
                    isibiodata.gender = bio.gender;
                    isibiodata.religion_id = bio.religion_id;
                    isibiodata.high = bio.high;
                    isibiodata.weight = bio.weight;
                    isibiodata.nationally = bio.nationally;
                    isibiodata.ethnic = bio.ethnic;
                    isibiodata.hobby = bio.hobby;
                    isibiodata.identity_type_id = bio.identity_type_id;
                    isibiodata.identity_no = bio.identity_no;
                    isibiodata.email = bio.email;
                    isibiodata.phone_number1 = bio.phone_number1;
                    isibiodata.phone_number2 = bio.phone_number2;
                    isibiodata.parent_phone_number = bio.parent_phone_number;
                    isibiodata.child_sequence = bio.child_sequence;
                    isibiodata.how_many_brothers = bio.how_many_brothers;
                    isibiodata.marital_status_id = bio.marital_status_id;
                    isibiodata.marriage_year = bio.marriage_year;
                    isibiodata.addrbook_id = bio.addrbook_id;

                    isibiodata.created_by = 12;
                    isibiodata.created_on = System.DateTime.Now;
                    isibiodata.is_delete = false;
                    
                    db.x_biodata.Add(isibiodata);
                    db.SaveChanges();

                    x_address isiaddress = new x_address();
                    isiaddress.address1 = bio.address1;
                    isiaddress.address2 = bio.address2;
                    isiaddress.postal_code1 = bio.postal_code1;
                    isiaddress.postal_code2 = bio.postal_code2;
                    isiaddress.rt1 = bio.rt1;
                    isiaddress.rt2 = bio.rt2;
                    isiaddress.rw1 = bio.rw1;
                    isiaddress.rw2 = bio.rw2;
                    isiaddress.kecamatan1 = bio.kecamatan1;
                    isiaddress.kecamatan2 = bio.kecamatan2;
                    isiaddress.kelurahan1 = bio.kelurahan1;
                    isiaddress.kelurahan2 = bio.kelurahan2;
                    isiaddress.region1 = bio.region1;
                    isiaddress.region2 = bio.region2;
                    isiaddress.biodata_id = isibiodata.id;
                    isiaddress.created_by = 123;
                    isiaddress.created_on = System.DateTime.Now;
                    //isiaddress.deleted_by = 123;
                    //isiaddress.deleted_on = System.DateTime.Now;
                    //isiaddress.modified_by = 123;
                    //isiaddress.modified_on = System.DateTime.Now;
                    isiaddress.is_delete = false;

                    db.x_address.Add(isiaddress);
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
    }
}
