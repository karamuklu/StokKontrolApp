using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UrunKontrolWebApi.Entities;

namespace StokKontrolApp.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        UrunKontrolContext ent = new UrunKontrolContext();
        [HttpPost]
        public ActionResult Index(FormCollection form)
        {
            var kullaniciAdi = form["kullaniciAdi"].ToString();
            var sifre = form["sifre"].ToString();
            var kullanici = ent.TBLKULLANICI_MKA.Where(i => i.KULLANICI_ADI == kullaniciAdi && i.SIFRE == sifre).FirstOrDefault();
            var SepetId = ent.TBLSEPET_MKA.OrderByDescending(i => i.SEPETID).FirstOrDefault().SEPETID;

            int yeniSepetId = SepetId + 1;

            Session["YeniSepetId"] = yeniSepetId.ToString();
            

            if (kullanici != null)
            {
                Session["Kullanıcı"] = kullanici.KULLANICI_ADI + " " + kullanici.ISIM;
                Session["KullaniciId"] = kullanici.KULLANICI_NO;
                return RedirectToAction("index", "Stok");
            }
            else
            {
                Session["Mesaj"] = "Kullanıcı adı veya şifre hatalı";
                RedirectToAction("Index", "Login");
            }
            return View(kullanici);
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(FormCollection form)
        {


            var kullaniciAdi = form["kullaniciAdi"].ToString();
            var sifre = form["sifre"].ToString();

            var gelenVeri = ent.TBLKULLANICI_MKA.Where(i => i.KULLANICI_ADI == kullaniciAdi && i.SIFRE == sifre).Count();

            if (gelenVeri == 0)
            {
                TBLKULLANICI_MKA yeniKullanici = new TBLKULLANICI_MKA();
                yeniKullanici.KULLANICI_ADI = form["KullaniciAdi"].ToString();
                yeniKullanici.SIFRE = form["sifre"].ToString();
                ent.TBLKULLANICI_MKA.Add(yeniKullanici);
                ent.SaveChanges();
                Session["Mesaj"] = "Kayıt başarıyla tamamlandı. Yönlendiriliyorsunuz...";
                System.Threading.Thread.Sleep(200);

                Response.Redirect("../Emlak/Index");

            }
            else if (gelenVeri > 0)
            {
                Session["Mesaj"] = "Kullanıcı sistemde daha önceden kayıtlıdır. Lütfen Kullanıcı adınızı değiştiriniz";
            }

            return View();
        }

        public ActionResult SignOut()
        {
            Session.Clear();
            return RedirectToAction("Index", "Login");
        }
    }
}