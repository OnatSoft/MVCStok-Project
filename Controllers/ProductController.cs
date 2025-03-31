using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Razor.Generator;
using MVCStok_Project.Models.Entity;
using PagedList;
using PagedList.Mvc;

namespace MVCStok_Project.Controllers
{
    public class ProductController : Controller
    {
        
        public ActionResult Index()
        {
            return View();
        }

        MvcStokDBEntities1 db = new MvcStokDBEntities1();

        public ActionResult ProductList(int page = 1)
        {
            //-> ProductList isimli view sayfasına veritabanında bulunan ürünler listeleniyor.
            //-- Genel Kullanım: var values = db.Urunler_TBL.ToList();
            var values = db.Urunler_TBL.ToList().ToPagedList(page, 4);
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

            var ktg = db.Kategoriler_TBL.Where(m => m.KategoriID == urunler_.Kategoriler_TBL.KategoriID).FirstOrDefault();
            urunler_.Kategoriler_TBL = ktg;
            db.Urunler_TBL.Add(urunler_);
            db.SaveChanges();
            return RedirectToAction("ProductList");
        }

        public ActionResult DeleteProduct(int id)
        {
            //-> Ürün silme işlemi yapılıyor.
            var urun = db.Urunler_TBL.Find(id);
            db.Urunler_TBL.Remove(urun);
            db.SaveChanges();
            return RedirectToAction("ProductList");
        }

        [HttpGet]
        public ActionResult UpdateProduct(int id)
        {
            var urun = db.Urunler_TBL.Find(id);
            List<SelectListItem> items = (from i in db.Kategoriler_TBL.ToList()
                                          select new SelectListItem
                                          {
                                              Value = i.KategoriID.ToString(),
                                              Text = i.KategoriAd,
                                          }).ToList();
            
            ViewBag.val = items;
            return View("UpdateProduct", urun);
        }

        [HttpPost]
        public ActionResult UpdateProduct(Urunler_TBL urunler)
        {
            //if (!ModelState.IsValid)
            //{
            //    return View("UpdateProduct");
            //}

            var urun = db.Urunler_TBL.Find(urunler.UrunID);
            urun.UrunAd = urunler.UrunAd;
            urun.Stok = urunler.Stok;
            urun.UrunMarka = urunler.UrunMarka;
            urun.Fiyat = urunler.Fiyat;
            var ktgr = db.Kategoriler_TBL.Where(m => m.KategoriID == urunler.Kategoriler_TBL.KategoriID).FirstOrDefault();
            urun.UrunKategori = ktgr.KategoriID;

            db.SaveChanges();
            return RedirectToAction("ProductList");
        }
    }
}