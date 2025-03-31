using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using MVCStok_Project.Models.Entity;

namespace MVCStok_Project.Controllers
{
    public class CategoryController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        MvcStokDBEntities1 db = new MvcStokDBEntities1();

        public ActionResult CategoryList()
        {
            var values = db.Kategoriler_TBL.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCategory(Kategoriler_TBL kategoriler_)
        {
            if (!ModelState.IsValid)
            {
                return View("AddCategory");
            }
            db.Kategoriler_TBL.Add(kategoriler_);
            db.SaveChanges();
            return RedirectToAction("CategoryList");
        }

        public ActionResult DeleteCategory(int id)
        {
            var kategori = db.Kategoriler_TBL.Find(id);
            db.Kategoriler_TBL.Remove(kategori);
            db.SaveChanges();
            return RedirectToAction("CategoryList");
        }

        [HttpGet]
        public ActionResult UpdateCategory(int id)
        {
            var ktgr = db.Kategoriler_TBL.Find(id);
            return View("UpdateCategory", ktgr);
        }

        [HttpPost]
        public ActionResult UpdateCategory(Kategoriler_TBL ktgr)
        {
            if (!ModelState.IsValid)
            {
                return View("UpdateCategory");
            }
            var kategori = db.Kategoriler_TBL.Find(ktgr.KategoriID);
            kategori.KategoriAd = ktgr.KategoriAd;
            db.SaveChanges();
            return RedirectToAction("CategoryList");
        }
    }
}