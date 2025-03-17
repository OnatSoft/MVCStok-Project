using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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
            if (kategoriler_ != null)
            {
                db.Kategoriler_TBL.Add(kategoriler_);
                db.SaveChanges();
            }
            return RedirectToAction("CategoryList");
        }
    }
}