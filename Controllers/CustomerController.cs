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

        public ActionResult CustomerList(string param)
        {
            //-> Veritabanına kaydedilen müşterileri listeleme view sayfası.
            //-> Müşteri adı arama kutusu yapımı.
            var values = from d in db.Musteriler_TBL select d;
            if (!string.IsNullOrEmpty(param))
            {
                values = values.Where(m => m.MusteriAd.Contains(param));
            }
            return View(values.ToList());

            //var values = db.Musteriler_TBL.ToList();
            //return View(values);
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
            if (!ModelState.IsValid)
            {
                return View("CustomerAdd");
            }
            db.Musteriler_TBL.Add(musteriler_);
            db.SaveChanges();
            return RedirectToAction("CustomerList");
        }

        public ActionResult DeleteCustomer(int id)
        {
            var musteri = db.Musteriler_TBL.Find(id);
            db.Musteriler_TBL.Remove(musteri);
            db.SaveChanges();
            return RedirectToAction("CustomerList");
        }

        [HttpGet]
        public ActionResult UpdateCustomer(int id)
        {
            var musteri = db.Musteriler_TBL.Find(id);
            return View("UpdateCustomer", musteri);
        }

        [HttpPost]
        public ActionResult UpdateCustomer(Musteriler_TBL mst)
        {
            if (!ModelState.IsValid)
            {
                return View("UpdateCustomer");
            }

            var musteri = db.Musteriler_TBL.Find(mst.MusteriID);
            musteri.MusteriAd = mst.MusteriAd;
            musteri.MusteriSoyad = mst.MusteriSoyad;
            db.SaveChanges();
            return RedirectToAction("CustomerList");
        }
    }
}