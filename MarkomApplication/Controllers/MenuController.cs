using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Repo.Project;
using Model.Project;
using ViewModel.Project;
using System.Data.Entity;
using System.Web.Mvc;

namespace MarkomApplication.Controllers
{
    public class MenuController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List(string searchName, string searchCode, DateTime? searchDate, string searchCreatedProduct)
        {
            List<VMMenu> List = new List<VMMenu>();
            List = MenuRepo.GetListAll(searchName, searchCode, searchDate, searchCreatedProduct);
            ViewBag.DataKosong = MenuRepo.DataKosong;
            ViewBag.ListData = MenuRepo.GetListAll();
            return PartialView("List", List);
        }

        public ActionResult Create()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult Create(VMMenu paramModel)
        {
            try
            {
                MenuRepo.Message = string.Empty;

                //Create auto generate product_code
                using (var db = new Markom_IDLEEntities())
                {
                    string nol = "";
                    m_menu cek = db.m_menu.OrderByDescending(x => x.code).First();
                    int simpan = int.Parse(cek.code.Substring(3));
                    simpan++;
                    for (int i = simpan.ToString().Length; i < 4; i++)
                    {
                        nol = nol + "0";
                    }
                    paramModel.code = "ME" + nol + simpan;
                }

                paramModel.created_by = "Administrator";
                paramModel.created_date = DateTime.Now;
                paramModel.is_delete = false;

                if (null == paramModel.name)
                {
                    MenuRepo.Message = "Anda belum memasukan semua data. Silahkan ulangi kembali";
                }
                if (string.IsNullOrEmpty(MenuRepo.Message))
                {
                    return Json(new
                    {
                        success = MenuRepo.Insert(paramModel),
                        message = paramModel.code
                    }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { success = false, message = MenuRepo.Message },
                    JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception hasError)
            {
                return Json(new { success = false, message = hasError.Message },
                    JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult Edit(Int32 paramId)
        {
            return PartialView(MenuRepo.GetDetailById(paramId));
        }

        [HttpPost]
        public ActionResult Edit(VMMenu paramModel)
        {
            try
            {
                MenuRepo.Message = string.Empty;

                paramModel.updated_by = "Dzul";
                paramModel.updated_date = DateTime.Now;

                if (null == paramModel.name)
                {
                    MenuRepo.Message = "Anda belum memasukan semua data. Silahkan ulangi kembali";
                }
                if (string.IsNullOrEmpty(MenuRepo.Message))
                {
                    return Json(new
                    {
                        success = MenuRepo.Update(paramModel),
                        message = MenuRepo.Message
                    }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { success = false, message = MenuRepo.Message },
                    JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception hasError)
            {
                return Json(new { success = false, message = hasError.Message },
                    JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult Detail(Int32 paramId)
        {
            return PartialView(MenuRepo.GetDetailById(paramId));
        }

        public ActionResult Delete(Int32 paramId)
        {
            return PartialView(MenuRepo.GetDetailById(paramId));
        }

        [HttpPost]
        public ActionResult Delete(VMMenu paramModel)
        {
            try
            {
                return Json(new
                {
                    success = MenuRepo.Delete(paramModel),
                    message = MenuRepo.Message
                }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception hasError)
            {
                return Json(new { success = false, message = hasError.Message },
                    JsonRequestBehavior.AllowGet);
            }
        }









    }
}