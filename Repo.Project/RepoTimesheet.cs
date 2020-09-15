using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Project;
using ViewModel.Project;
using System.Data.Entity;



namespace Repo.Project
{
    public class RepoTimesheet
    {
        public static List<x_timesheet> GetAllData()
        {
            List<x_timesheet> output = new List<x_timesheet>();
            using (DBSpecEntities db = new DBSpecEntities())
            {
                output = db.x_timesheet.Where(a => a.is_delete == false).ToList();
            }
            return output;
        }

        public static List<x_timesheet> GetAllDataApp()
        {
            List<x_timesheet> output = new List<x_timesheet>();
            using (DBSpecEntities db = new DBSpecEntities())
            {
                output = db.x_timesheet.Where(a => a.is_delete == false&& a.user_approval=="Submitted"&& a.ero_status==null).ToList();
            }
            return output;
        }
        public static x_timesheet GetDatabyId(long id)
        {
            x_timesheet data = new x_timesheet();
            using (DBSpecEntities db = new DBSpecEntities())
            {
                data = db.x_timesheet.Where(a => a.id == id).FirstOrDefault();
            }
            return data;
        }
        public static bool SaveData(x_timesheet Sheet, long createdBy)
        {
            //try
            //{
            using (DBSpecEntities db = new DBSpecEntities())
            {
                Sheet.timesheet_date = Sheet.timesheet_date;
                Sheet.created_by = createdBy;
                Sheet.created_on = System.DateTime.Now;
                Sheet.overtime = Sheet.overtime;

                Sheet.modified_on = null;
                Sheet.deleted_on = null;
                Sheet.user_approval = null;
                Sheet.ero_status = null;
                Sheet.submitted_on = null;

                db.x_timesheet.Add(Sheet);

                db.SaveChanges();
                return true;
            }

            //}
            //catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
            //{
            //    Exception raise = dbEx;
            //    foreach (var validationErrors in dbEx.EntityValidationErrors)
            //    {
            //        foreach (var validationError in validationErrors.ValidationErrors)
            //        {
            //            string message = string.Format("{0}:{1}",
            //                validationErrors.Entry.Entity.ToString(),
            //                validationError.ErrorMessage);
            //            // raise a new exception nesting  
            //            // the current instance as InnerException  
            //            raise = new InvalidOperationException(message, raise);
            //        }
            //    }
            //    throw raise;
            //}
        }
        public static bool UpdateData(x_timesheet dataForm, long modifiedBy)
        {
            x_timesheet dataBefore = GetDatabyId(dataForm.id);
            try
            {
                using (DBSpecEntities db = new DBSpecEntities())
                {
                    dataBefore.modified_by = modifiedBy;
                    dataBefore.modified_on = System.DateTime.Now;
                    dataBefore.overtime = dataForm.overtime;
                    dataBefore.start = dataForm.start;
                    dataBefore.end = dataForm.end;
                    dataBefore.start_ot = dataForm.start_ot;
                    dataBefore.end_ot = dataForm.end_ot;
                    dataBefore.status = dataForm.status;
                    dataBefore.timesheet_date = dataForm.timesheet_date;
                    dataBefore.activity = dataForm.activity;

                    db.Entry(dataBefore).State = EntityState.Modified;
                    db.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {

                return false;
            }


        }
        public static VMTimesheet getClientNPLid(long loginId)
        {
            VMTimesheet activeClient = new VMTimesheet();

            using (DBSpecEntities db = new DBSpecEntities())
            {
                activeClient = (from emp in db.x_employee
                                join plc in db.x_placement on emp.id equals plc.employee_id
                                where emp.id == loginId
                                join cl in db.x_client on plc.client_id equals cl.id
                                where plc.is_placement_active == true
                                select new VMTimesheet
                                {
                                    placement_id = plc.id,
                                    clientName = cl.name,
                                    client_id = cl.id
                                }).FirstOrDefault();
            }

            return activeClient;
        }
        public static bool DeleteData(long id)
        {
            using (DBSpecEntities db = new DBSpecEntities())
            {
                x_timesheet data = GetDatabyId(id);
                data.is_delete = true;
                db.Entry(data).State = EntityState.Modified;
                db.SaveChanges();
                return true;
            }
        }

        //public static bool ApprovedorNot(string[] datasep)
        //{
        //    return true;
        //}

        public static List<VMCheck> GetListVM()
        {
            List<VMCheck> output = new List<VMCheck>();

            using (DBSpecEntities db = new DBSpecEntities())
            {
                output = (from ts in db.x_timesheet
                          where ts.is_delete == false
                          select new VMCheck
                          {
                              Id = ts.id,
                              timesheet_date = ts.timesheet_date,
                              status = ts.status,
                              placement_id = ts.placement_id

                          }).ToList();
            }
            return output;

        }
        public static bool TimeReport(x_timesheet_assessment data, long createdBy)
        {

            using (DBSpecEntities db = new DBSpecEntities())
            {
                data.created_by = createdBy;
                data.created_on = System.DateTime.Now;
                data.is_delete = false;
                db.x_timesheet_assessment.Add(data);
                db.SaveChanges();
            }

            return true;
        }

        public static bool userApproval(string data)
        {
            string[] arr = data.Split(',');
            using (DBSpecEntities db = new DBSpecEntities())
            {               
                for (int i = 1; i < arr.Length; i++)
                {
                    x_timesheet dtTimesheet = new x_timesheet();
                    dtTimesheet = GetDatabyId(Convert.ToInt64(arr[i]));
                    if (arr[0]=="Approved")
                    {
                        dtTimesheet.approved_on = System.DateTime.Now;
                    }
                    else
                    {
                        dtTimesheet.approved_on = null;
                    }
                    dtTimesheet.user_approval = arr[0];
                    db.Entry(dtTimesheet).State = EntityState.Modified;
                    db.SaveChanges();
                }
            }
            return true;
        }

        //public static bool checkTgl(DateTime date)
        //{
        //    dateonly=date
        //}
    }
}

