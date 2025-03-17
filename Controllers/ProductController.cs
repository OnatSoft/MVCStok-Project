using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCStok_Project.Models.Entity;

namespace MVCStok_Project.Controllers
{
    public class ProductController : Controller
    {
        
        public ActionResult Index()
        {
            return View();
        }

        MvcStokDBEntities1 db = new MvcStokDBEntities1();

        public ActionResult ProductList()
        {
            //-> ProductList isimli view sayfasına veritabanında bulunan ürünler listeleniyor.
            var values = db.Urunler_TBL.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult ProductAdd()
        {
            //-> Ürün ekleme sayfasında kategori DropDownListine kategoriler tablosundan ID ve İsim değerleri listeleniyor.
            List<SelectListItem> items = (from i in db.Kategoriler_TBL.ToList()
                                          select new SelectListItem
                                          {
                                              Value = i.KategoriID.ToString(),
                                              Text = i.KategoriAd,
                                          }).ToList();
            ViewBag.ktg = items;
            return View();
        }

        [HttpPost]
        public ActionResult ProductAdd(Urunler_TBL urunler_)
        {
            //-> Ürün ekleme sayfasında POST işlemi gerçekleştiğinde dropdownlist'te seçilen kategori değerinin ID'si ile kaydediliyor.
            // RedirectToAction ile post işlemi gerçekleştikten sonra geri ürünler listesine yönlendiriyor.
            if (urunler_ != null)
            {
                var ktg = db.Kategoriler_TBL.Where(m=>m.KategoriID == urunler_.Kategoriler_TBL.KategoriID).FirstOrDefault();
                urunler_.Kategoriler_TBL = ktg;
                db.Urunler_TBL.Add(urunler_);
                db.SaveChanges();
            }
            return RedirectToAction("ProductList");
        }
    }
}