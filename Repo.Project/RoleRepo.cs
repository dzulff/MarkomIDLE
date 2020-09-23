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
    public class RoleRepo
    {
        public static string Message;
        public static string DataKosong;
        public static List<VMRole> GetListAll(string searchName, string searchCode, string searchDescription, DateTime? searchDate, string searchCreatedProduct)
        {
            List<VMRole> listData = new List<VMRole>();
            using (var db = new Markom_IDLEEntities())
            {
                listData = (from a in db.m_role
                            where a.is_delete == false
                            select new VMRole
                            {
                                id = a.id,
                                code = a.code,
                                name = a.name,
                                description = a.description,
                                is_delete = a.is_delete,
                                created_by = a.created_by,
                                created_date = a.created_date,
                                updated_by = a.updated_by,
                                updated_date = a.updated_date
                            }).ToList();
            }
            if (!string.IsNullOrEmpty(searchName))
            {
                listData = listData.Where(x => x.name == searchName).ToList();
            }
            if (!string.IsNullOrEmpty(searchCode))
            {
                listData = listData.Where(x => x.code == searchCode).ToList();
            }
            if (!string.IsNullOrEmpty(searchDescription))
            {
                listData = listData.Where(x => x.description == searchDescription).ToList();
            }
            if (searchDate != null)
            {
                listData = listData.Where(x => x.created_date.ToString("dd MMMM yyyy") == searchDate.Value.ToString("dd MMMM yyyy")).ToList();
            }
            if (!string.IsNullOrEmpty(searchCreatedProduct))
            {
                listData = listData.Where(x => x.created_by == searchCreatedProduct).ToList();
            }
            if (listData.Count == 0)
            {
                DataKosong = "Data tidak ditemukan";
            }
            else
            {
                DataKosong = "";
            }

            return listData;
        }

        public static VMRole GetDetailById(int Id)
        {
            VMRole result = new VMRole();
            using (var db = new Markom_IDLEEntities())
            {
                result = (from a in db.m_role
                          where a.id == Id
                          select new VMRole
                          {
                              id = a.id,
                              code = a.code,
                              name = a.name,
                              description = a.description,
                              is_delete = a.is_delete,
                              created_by = a.created_by,
                              created_date = a.created_date,
                              updated_by = a.updated_by,
                              updated_date = a.updated_date
                          }).FirstOrDefault();
            }
            return result;
        }

        public static bool Insert(VMRole paramModel)
        {
            bool result = true;
            try
            {
                using (var db = new Markom_IDLEEntities())
                {
                    m_role a = new m_role();
                    a.code = paramModel.code;
                    a.name = paramModel.name;
                    a.description = paramModel.description;
                    a.is_delete = paramModel.is_delete;
                    a.created_by = paramModel.created_by;
                    a.created_date = paramModel.created_date;

                    db.m_role.Add(a);
                    db.SaveChanges();
                }
            }
            catch (Exception hasError)
            {
                result = false;
                if (hasError.Message.ToLower().Contains("inner exception"))
                {
                    Message = hasError.InnerException.InnerException.Message;
                }
                else
                {
                    Message = hasError.Message;
                }
            }
            return result;
        }

        public static bool Update(VMRole paramModel)
        {
            bool result = true;
            try
            {
                using (var db = new Markom_IDLEEntities())
                {
                    m_role a = db.m_role.Where(o => o.id == paramModel.id).FirstOrDefault();
                    if (a != null)
                    {
                        a.name = paramModel.name;
                        a.description = paramModel.description;
                        a.updated_by = paramModel.updated_by;
                        a.updated_date = paramModel.updated_date;

                        db.SaveChanges();
                    }
                    else
                    {
                        result = false;
                    }
                }
            }

            catch (Exception hasError)
            {
                result = false;
                if (hasError.Message.ToLower().Contains("inner exception"))
                {
                    Message = hasError.InnerException.InnerException.Message;
                }
                else
                {
                    Message = hasError.Message;
                }
            }
            return result;
        }

        public static bool Delete(VMRole paramModel)
        {
            bool result = true;
            try
            {
                using (var db = new Markom_IDLEEntities())
                {
                    m_role a = db.m_role.Where(o => o.id == paramModel.id).FirstOrDefault();
                    if (a != null)
                    {
                        a.is_delete = true;

                        db.SaveChanges();
                    }
                    else
                    {
                        result = false;
                    }
                }
            }
            catch (Exception hasError)
            {
                result = false;
                if (hasError.Message.ToLower().Contains("inner exception"))
                {
                    Message = hasError.InnerException.InnerException.Message;
                }
                else
                {
                    Message = hasError.Message;
                }
            }
            return result;
        }

    }
}
