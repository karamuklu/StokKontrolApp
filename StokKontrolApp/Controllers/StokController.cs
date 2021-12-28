using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using UrunKontrolWebApi.Business;
using UrunKontrolWebApi.Entities;

namespace StokKontrolApp.Controllers
{
    public class StokController : Controller
    {

        UrunKontrolManager stokKontrolManager = new UrunKontrolManager();

        public ActionResult Deneme()
        {
            return View();
        }
        // GET: Stok

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Depolar()
        {
            return View();
        }
        public ActionResult Test()
        {
            return View();
        }
        public ActionResult Duzenle(string sepetNo)
        {
            var sepet = stokKontrolManager.SEPETUST(sepetNo);
            return View();
        }
        [HttpPost]
        public void Duzenle(TBLSEPETUST_MKA gelenSepet)
        {
            //var sepetUst = stokKontrolManager.SEPETUST(sepetNo);
            stokKontrolManager.SEPETUSTGUNCELLE(gelenSepet);
        }

        public ActionResult SepetUstList(string sepetNo)
        {
            var kullaniciNo = Convert.ToInt32(Session["KullaniciId"]);
            string sepetid = Session["YeniSepetId"].ToString();
            var list = stokKontrolManager.SEPETUSTLIST(kullaniciNo).OrderBy(i=>i.SEPETID);
            return View(list);
        }


        [HttpPost]
        public JsonResult SepetUstList()
        {
            var kullaniciNo = Convert.ToInt32(Session["KullaniciId"]);
            string sepetid = Session["YeniSepetId"].ToString();
            var list = stokKontrolManager.SEPETUSTLIST(kullaniciNo);

            return Json(list, JsonRequestBehavior.AllowGet);

        }

        public ActionResult SepetList(string id)
        {
            var list = stokKontrolManager.SEPETGETIR(id);
            return View(list);
        }

        [HttpPost]
        public void SepeteEkle(TBLSEPET_MKA gelenSepet)
        {
            stokKontrolManager.SepeteEkle(gelenSepet);
        }

        [HttpPost]
        public void SepeteUstEkle(TBLSEPETUST_MKA sepetUst)
        {
            stokKontrolManager.SEPETUSTEKLE(sepetUst);
        }

        [HttpPost]
        public void SepeteUstGuncelle(TBLSEPETUST_MKA sepetUst)
        {
            stokKontrolManager.SEPETUSTGUNCELLE(sepetUst);
        }

        
        public void SepetKalemFiyatGuncelle(TBLSEPET_MKA sepet)
        {
            stokKontrolManager.SEPETKALEMFIYATGUNCELLE(sepet);
        }

        public ActionResult SepettenSil(string id, int sepetNo,int siraNo)
        {
            stokKontrolManager.SEPETTENSIL(id, sepetNo, siraNo);
            return RedirectToAction("SepetUstList", "Stok",sepetNo);
        }
      
    }
}