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
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List(string searchName, string searchCode, string searchDescription, DateTime? searchDate, string searchCreatedProduct)
        {
            List<VMProduct> List = new List<VMProduct>();
            List = ProductRepo.GetListAll(searchName, searchCode, searchDescription, searchDate, searchCreatedProduct);
            ViewBag.DataKosong = ProductRepo.DataKosong;
            return PartialView("List", List);
        }

        public ActionResult Create()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult Create(VMProduct paramModel)
        {
            try
            {
                ProductRepo.Message = string.Empty;

                //Create auto generate product_code
                using (var db = new Markom_IDLEEntities())
                {
                    string nol = "";
                    m_product cek = db.m_product.OrderByDescending(x => x.code).First();
                    int simpan = int.Parse(cek.code.Substring(3));
                    simpan++;
                    for (int i = simpan.ToString().Length; i < 4; i++)
                    {
                        nol = nol + "0";
                    }
                    paramModel.code = "PR" + nol + simpan;
                }

                paramModel.created_by = "Administrator";
                paramModel.created_date = DateTime.Now;
                paramModel.is_delete = false;

                if (null == paramModel.name)
                {
                    ProductRepo.Message = "Anda belum memasukan semua data. Silahkan ulangi kembali";
                }
                if (string.IsNullOrEmpty(ProductRepo.Message))
                {
                    return Json(new
                    {
                        success = ProductRepo.Insert(paramModel),
                        message = paramModel.code
                    }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { success = false, message = ProductRepo.Message },
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
            return PartialView(ProductRepo.GetDetailById(paramId));
        }

        [HttpPost]
        public ActionResult Edit(VMProduct paramModel)
        {
            try
            {
                ProductRepo.Message = string.Empty;

                paramModel.updated_by = "Dzul";
                paramModel.updated_date = DateTime.Now;

                if (null == paramModel.name)
                {
                    ProductRepo.Message = "Anda belum memasukan semua data. Silahkan ulangi kembali";
                }
                if (string.IsNullOrEmpty(ProductRepo.Message))
                {
                    return Json(new
                    {
                        success = ProductRepo.Update(paramModel),
                        message = ProductRepo.Message
                    }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { success = false, message = ProductRepo.Message },
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
            return PartialView(ProductRepo.GetDetailById(paramId));
        }

        public ActionResult Delete(Int32 paramId)
        {
            return PartialView(ProductRepo.GetDetailById(paramId));
        }

        [HttpPost]
        public ActionResult Delete(VMProduct paramModel)
        {
            try
            {
                return Json(new
                {
                    success = ProductRepo.Delete(paramModel),
                    message = ProductRepo.Message
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