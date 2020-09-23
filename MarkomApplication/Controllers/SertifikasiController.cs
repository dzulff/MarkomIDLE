using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.Project;
using System.Data.Entity;
using Repo.Project;
using ViewModel.Project;

namespace Batch212MiniProject.Controllers
{
    public class SertifikasiController : Controller
    {
        // GET: Sertifikasi
        //public ActionResult Index()
        //{ 
        //    List<x_sertifikasi> listsertifikasi = new List<x_sertifikasi>();
        //    listsertifikasi = SertifikasiRepo.getAllData();
        //    return View(listsertifikasi);
        //}

            public ActionResult Index()
        {
            List<VMSertifikasi> listsertifikasi = new List<VMSertifikasi>();
            listsertifikasi = SertifikasiRepo.getAllData();
            return View(listsertifikasi);
        }

        

        public ActionResult Create(long id)
        {
            VMSertifikasi dt = new VMSertifikasi();
            ViewBag.ListYear = GeneralRepo.ListYear();
            ViewBag.ListMonth = GeneralRepo.ListMonth();
            dt.biodata_id = id;
            dt.id_biodata = id;
            return PartialView("_Create", dt);
        }

        [HttpPost]
        public ActionResult Create(VMSertifikasi sert)
        {
            if(ModelState.IsValid)
            {
                if(SertifikasiRepo.saveData(sert))
                {
                    return RedirectToAction("Index");
                }
            }
            return RedirectToAction("Index");
        }

        public ActionResult Edit(long id)
        {

            //VMSertifikasi listsertifikasi = SertifikasiRepo.getDataByKode(id);
            //return PartialView("_Edit", listsertifikasi);


            VMSertifikasi listsertifikasi = new VMSertifikasi();
            listsertifikasi = SertifikasiRepo.getDataByKode(id);
            return PartialView("_Edit", listsertifikasi);
        }

        [HttpPost]
        public ActionResult Edit(VMSertifikasi sert)
        {
            if (SertifikasiRepo.updateData(sert))
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        public ActionResult Delete(long id)
        {
            if(SertifikasiRepo.deleteData(id))
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }


        //public ActionResult Edit(long id)
        //{
        //    x_sertifikasi dtsert = new x_sertifikasi();
        //    dtsert = SertifikasiRepo.getdataBykode(id);
        //    return PartialView("_Edit", dtsert);
        //}

        //[HttpPost]
        //public ActionResult Edit(x_sertifikasi sert)
        //{
        //    if (SertifikasiRepo.updateData(sert))
        //    {
        //        return RedirectToAction("Index");
        //    }
        //    return RedirectToAction("Index");
        //}

        //[HttpPost]
        //public ActionResult Delete(long id)
        //{
        //    if (SertifikasiRepo.deleteData(id))
        //    {
        //        return RedirectToAction("Index");
        //    }
        //    return RedirectToAction("Index");
        //}



        //public JsonResult cekvalid(string valid_start_year)
        //{
        //    return Json(BiodataRepo.CekValid(valid_start_year), JsonRequestBehavior.AllowGet);
        //}
    }
}