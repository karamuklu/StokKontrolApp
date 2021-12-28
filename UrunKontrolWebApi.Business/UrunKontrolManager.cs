using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrunKontrolWebApi.DataAccess;
using UrunKontrolWebApi.Entities;

namespace UrunKontrolWebApi.Business
{
    public class UrunKontrolManager
    {
        UrunKontrolDal stokKontrolDal = new UrunKontrolDal();
        public List<STOKBAKIYE_MKA> StokBakiyeListe()
        {
            return stokKontrolDal.StokBakiyeListesi();
        }
        public STOKBAKIYE_MKA stokBakiyeGetir(string stokKodu)
        {
            return stokKontrolDal.StokBakiyeGetir(stokKodu);
        }
        public List<STOKBAKIYE_MKA> StokBakiyeAdaGoreGetir(string stokAdi)
        {
            return stokKontrolDal.StokBakiyeAdaGoreGetir(stokAdi);
        }
        public TBLKULLANICI_MKA KULLANICIGETIR(string kullaniciAdi, string sifre)
        {
            return stokKontrolDal.KULLANICIGETIR(kullaniciAdi, sifre);
        }
        public List<STOKBAKIYE_MKA> StokBakiyeDepolarAyri(string stokAdi)
        {
            return stokKontrolDal.StokBakiyeAdaGoreGetir(stokAdi);
        }
        public void SepeteEkle(TBLSEPET_MKA gelenSepet)
        {
            stokKontrolDal.SEPETEEKLE(gelenSepet);
        }

        public void SEPETUSTEKLE(TBLSEPETUST_MKA sepetUst)
        {
            stokKontrolDal.SEPETUSTEKLE(sepetUst);
        }

        public void SEPETUSTGUNCELLE(TBLSEPETUST_MKA gelenSepet)
        {
            stokKontrolDal.SEPETUSTGUNCELLE(gelenSepet);
        }

        public List<SEPET_MKA> SEPETGETIR(string sepetID)
        {
            return stokKontrolDal.SEPETGETIR(sepetID).ToList();
        }
        public List<SEPETUST_MKA> SEPETUSTLIST(int kayitYapan)
        {
            return stokKontrolDal.SEPETUSTLIST(kayitYapan);
        }

        public TBLSEPETUST_MKA SEPETUST(string sepetNo)
        {
            return stokKontrolDal.SEPETUST(sepetNo);
        }

        public void SEPETTENSIL(string stok_kodu, int sepetNo, int siraNo)
        {
            stokKontrolDal.SEPETTENSIL(stok_kodu, sepetNo, siraNo);
        }
        public void SEPETKALEMFIYATGUNCELLE(TBLSEPET_MKA gelenSepet)
        {
            stokKontrolDal.SEPETKALEMFIYATGUNCELLE(gelenSepet);
        }
    }

}
