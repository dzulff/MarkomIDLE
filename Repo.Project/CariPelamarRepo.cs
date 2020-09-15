using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Project;
using ViewModel.Project;

namespace Repo.Project
{
    public class CariPelamarRepo
    {
        public static List<VMCariPelamar> getAllData(string searchString)
        {
            List<VMCariPelamar> data = new List<VMCariPelamar>();
            //List<VMCariPelamar> data2 = new List<VMCariPelamar>();
            using (DBSpecEntities db = new DBSpecEntities())
            {
                //data2 = (from rp in db.x_riwayat_pendidikan
                //         select new VMCariPelamar
                //         {
                //             biodata_id = rp.biodata_id,
                //             school_name = rp.school_name,
                //             major = rp.major,
                //             graduation_year = rp.graduation_year
                //         }).ToList();

                data = (from bio in db.x_biodata
                        where bio.is_delete == false
                        join rp in db.x_riwayat_pendidikan on bio.id equals rp.biodata_id
                        /*&& bio.fullname.Contains(searchString)*/
                        select new VMCariPelamar
                        {
                            id = bio.id,
                            fullname = bio.fullname,
                            nick_name = bio.nick_name,
                            email = bio.email,
                            phone_number1 = bio.phone_number1,
                            school_name = rp.school_name,
                            expired_token = bio.expired_token,
                            major = rp.major,
                            graduation_year = rp.graduation_year
                        }).ToList();
            }
            return data;
        }

        public static x_biodata getBiodataByKode(long id)
        {
            x_biodata data = new x_biodata();
            using (DBSpecEntities db = new DBSpecEntities())
            {
                data = db.x_biodata.Where(a => a.id == id).FirstOrDefault();
            }
            return data;
        }

        public static List<VMOnlineTest> getOnlineTestDataByKode(long id)
        {
            List<VMOnlineTest> data = new List<VMOnlineTest>();
            using (DBSpecEntities db = new DBSpecEntities())
            {
                data = (from bio in db.x_biodata
                        where bio.id == id
                        join ab in db.x_addrbook on bio.email equals ab.email
                        where ab.email == bio.email
                        join ot in db.x_online_test on bio.id equals ot.biodata_id
                        where ot.biodata_id == bio.id
                        //join otd in db.x_online_test_detail on ot.id equals otd.online_test_id
                        //where otd.online_test_id == ot.id
                        //join tt in db.x_test_type on otd.test_type_id equals tt.id
                        select new VMOnlineTest
                        {
                            id_bio = bio.id,
                            email_bio = bio.email,
                            fullname = bio.fullname,

                            id_ab = ab.id,
                            email_ab = ab.email,
                            attempt = ab.attempt,
                            abuid = ab.abuid,
                            abpwd = ab.abpwd,
                            fp_token = ab.fp_token,
                            fp_expired_date = ab.fp_expired_date,
                            fp_counter = ab.fp_counter,

                            id_ot = ot.id,
                            biodata_id = ot.biodata_id,
                            period_code = ot.period_code,
                            period = ot.period,
                            test_date = ot.test_date,
                            expired_test = ot.expired_test,
                            user_access = ot.user_access,
                            status = ot.status,

                            //id_otd = otd.id,
                            //online_test_id = otd.online_test_id,
                            //test_type_id = otd.test_type_id,
                            //test_order = otd.test_order,

                            //id_tt = tt.id,
                            //test_name = tt.name,
                            //description = tt.description,
                        }).ToList();
            }
            return data;
        }

        public static VMCariPelamar getDataByKode(long id)
        {
            VMCariPelamar data = new VMCariPelamar();
            using (DBSpecEntities db = new DBSpecEntities())
            {
                data = (from bio in db.x_biodata
                        join rp in db.x_riwayat_pendidikan on bio.id equals rp.biodata_id
                        join ot in db.x_online_test on bio.id equals ot.biodata_id
                        join otd in db.x_online_test_detail on ot.id equals otd.online_test_id
                        where bio.id == 2
                        select new VMCariPelamar
                        {
                            id = bio.id,
                            fullname = bio.fullname,
                            nick_name = bio.nick_name,
                            email = bio.email,
                            phone_number1 = bio.phone_number1,

                            school_name = rp.school_name,
                            expired_token = bio.expired_token,
                            major = rp.major,
                            graduation_year = rp.graduation_year,

                            period_code = ot.period_code,
                            period = ot.period,
                            test_date = ot.test_date,
                            expired_test = ot.expired_test,
                            user_access = ot.user_access,
                            status = ot.status,

                            online_test_id = otd.online_test_id,
                            test_type_id = otd.test_type_id,
                            test_order = otd.test_order
                        }).FirstOrDefault();
            }
            return data;
        }

        public static bool UpdateToken(x_biodata bio)
        {
            try
            {
                using (DBSpecEntities db = new DBSpecEntities())
                {
                    
                    x_biodata dtBio = db.x_biodata.Where(a => a.id == bio.id).FirstOrDefault();

                    dtBio.token = generateToken();
                    dtBio.expired_token = bio.expired_token;
                    
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

        public static string generateToken()
        {
            string Token_Terakhir = "";
            int digit = 4;
            int digitnol = 0;
            string jmlNol = "";
            string strKode = "";
            using (DBSpecEntities db = new DBSpecEntities())
            {
                Token_Terakhir = db.x_biodata.OrderByDescending(a => a.token).Select(a => a.token).FirstOrDefault();
                if (Token_Terakhir == null)
                {
                    Token_Terakhir = "TKN0000";
                }
                strKode = "TKN";

                int angka = int.Parse(Token_Terakhir.Substring(3, 4));
                angka += 1;
                if (angka.ToString().Length <= digit)
                {
                    digitnol = digit - angka.ToString().Length;
                    for (int i = 0; i < digitnol; i++)
                    {
                        jmlNol += "0";
                    }
                }
                Token_Terakhir = strKode + jmlNol + angka;
            }
            return Token_Terakhir;
        }

        public static string lastToken()
        {
            string Token_Terakhir = "";
            using (DBSpecEntities db = new DBSpecEntities())
            {
                Token_Terakhir = db.x_biodata.OrderByDescending(a => a.token).Select(a => a.token).FirstOrDefault();
            }
            return Token_Terakhir;
        }

        public static bool SaveDataOnlineTest(x_online_test ot)
        {
            try
            {
                using (DBSpecEntities db = new DBSpecEntities())
                {
                    ot.created_by = 1;
                    ot.created_on = System.DateTime.Now;
                    ot.is_delete = false;
                    ot.period_code = generatePeriodeCode();
                    ot.period = generatePeriode();
                    ot.status = "Proses";

                    db.x_online_test.Add(ot);
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

        public static string generatePeriodeCode()
        {
            string Period_Terakhir = "";
            int digit = 4;
            int digitnol = 0;
            string jmlNol = "";
            string strKode = "";
            using (DBSpecEntities db = new DBSpecEntities())
            {
                Period_Terakhir = db.x_online_test.OrderByDescending(a => a.period_code).Select(a => a.period_code).FirstOrDefault();
                if (Period_Terakhir == null)
                {
                    Period_Terakhir = "PRD0000";
                }
                strKode = "PRD";

                int angka = int.Parse(Period_Terakhir.Substring(3, 4));
                angka += 1;
                if (angka.ToString().Length <= digit)
                {
                    digitnol = digit - angka.ToString().Length;
                    for (int i = 0; i < digitnol; i++)
                    {
                        jmlNol += "0";
                    }
                }
                Period_Terakhir = strKode + jmlNol + angka;
            }
            return Period_Terakhir;
        }

        public static int generatePeriode()
        {
            int angka = 0;
            string Period_Terakhir = "";
            using (DBSpecEntities db = new DBSpecEntities())
            {
                Period_Terakhir = db.x_online_test.OrderByDescending(a => a.period).Select(a => a.period).FirstOrDefault().ToString();
                
                angka = int.Parse(Period_Terakhir);
                angka += 1;
            }

            return angka;
        }

        public static string CekData(string searchString)
        {
            using (DBSpecEntities db = new DBSpecEntities())
            {
                x_biodata dt = db.x_biodata.Where(a => a.fullname.ToUpper().Contains(searchString.ToUpper())).FirstOrDefault();
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
