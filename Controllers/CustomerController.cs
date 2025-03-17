using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCStok_Project.Models.Entity;

namespace MVCStok_Project.Controllers
{
    public class CustomerController : Controller
    {
        
        public ActionResult Index()
        {
            return View();
        }

        MvcStokDBEntities1 db = new MvcStokDBEntities1();

        public ActionResult CustomerList()
        {
            //-> Veritabanına kaydedilen müşterileri listeleme view sayfası.
            var values = db.Musteriler_TBL.ToList();
            return View(values);
        }
        
        [HttpGet]
        public ActionResult CustomerAdd()
        {
            //-> Müşteri ekleme sayfası açıldığında POST işleminin yapılmasını engelleyerek boş değer kaydedilmesinin önüne geçiyor, GET işlemi yapılıyor.
            return View();
        }

        [HttpPost]
        public ActionResult CustomerAdd(Musteriler_TBL musteriler_)
        {
            //-> Müşteri ekleme sayfasında "Kaydet" butonuna tıklandığında bu POST işlem methodu çalışıyor ve yeni müşteri kaydediliyor.
            if (musteriler_ != null)
            {
                db.Musteriler_TBL.Add(musteriler_);
                db.SaveChangesAsync();
            }
            return RedirectToAction("CustomerList");
        }
    }
}