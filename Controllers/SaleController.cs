using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCStok_Project.Models.Entity;

namespace MVCStok_Project.Controllers
{
    public class SaleController : Controller
    {
        MvcStokDBEntities1 db = new MvcStokDBEntities1();

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult SaleAdd()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SaleAdd(Satislar_TBL satislar)
        {
            db.Satislar_TBL.Add(satislar);
            db.SaveChanges();
            return View("Index");
        }
    }
}