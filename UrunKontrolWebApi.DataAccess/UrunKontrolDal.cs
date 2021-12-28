using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrunKontrolWebApi.Entities;

namespace UrunKontrolWebApi.DataAccess
{
    public class UrunKontrolDal
    {
        public List<STOKBAKIYE_MKA> StokBakiyeListesi()
        {
            using (UrunKontrolContext context = new UrunKontrolContext())
            {
                return context.STOKBAKIYE_MKA.ToList();
            }
        }

        //stok adına göre arama yapılabiliyor olması lazım.
        public STOKBAKIYE_MKA StokBakiyeGetir(string stokKodu)
        {
            using (UrunKontrolContext context = new UrunKontrolContext())
            {
                var urun = context.STOKBAKIYE_MKA.Where(i => i.STOK_KODU == stokKodu).FirstOrDefault();
                return urun;
            }
        }

        public List<SEPET_MKA> SEPETGETIR(string sepetID)
        {
            using (UrunKontrolContext context = new UrunKontrolContext())
            {
                string sqlCumle = "SELECT * FROM SEPET_MKA WHERE SEPETID=" + sepetID + " ";
                return context.Database.SqlQuery<SEPET_MKA>(sqlCumle).ToList();
                //return context.SEPET_MKA.Where(i=>i.SEPETID==sepetID).ToList();
            }
        }

        public List<STOKBAKIYE_MKA> StokBakiyeAdaGoreGetir(string stokAdi)
        {
            string sqlCumle = "Select * from STOKBAKIYE_MKA s where STOK_KODU like '%" + stokAdi + "%' or STOK_ADI like '%" + stokAdi + "%'";
            UrunKontrolContext context = new UrunKontrolContext();
            return context.Database.SqlQuery<STOKBAKIYE_MKA>(sqlCumle).ToList();
        }

        public TBLKULLANICI_MKA KULLANICIGETIR(string kullaniciAdi, string sifre)
        {
            UrunKontrolContext context = new UrunKontrolContext();
            var kullanici = context.TBLKULLANICI_MKA.Where(i => i.KULLANICI_ADI.ToLower() == kullaniciAdi.ToLower() && i.SIFRE.ToLower() == sifre.ToLower()).FirstOrDefault();
            return kullanici;
        }

        public int SIRABUL(int sepetID)
        {
            using (UrunKontrolContext context = new UrunKontrolContext())
            {
                int siraNo = 1;
                if (context.TBLSEPET_MKA.Where(i => i.SEPETID == sepetID).OrderByDescending(a => a.SIRA).FirstOrDefault()==null)
                    return 1;
                else
                {
                    siraNo=context.TBLSEPET_MKA.Where(i => i.SEPETID == sepetID).OrderByDescending(a => a.SIRA).FirstOrDefault().SIRA;
                    return siraNo = siraNo + 1;
                }
            }
        }

        public void SEPETEEKLE(TBLSEPET_MKA gelenSepet)
        {
            using (UrunKontrolContext context = new UrunKontrolContext())
            {
                TBLSEPET_MKA sepetEleman = new TBLSEPET_MKA();
                sepetEleman.STOK_KODU = gelenSepet.STOK_KODU;
                sepetEleman.MIKTAR = gelenSepet.MIKTAR;
                sepetEleman.TARIH = DateTime.Now.Date;
                sepetEleman.SEPETID = gelenSepet.SEPETID;
                sepetEleman.KAYITYAPANKUL = gelenSepet.KAYITYAPANKUL;
                sepetEleman.NETSISDURUMU = gelenSepet.NETSISDURUMU;
                sepetEleman.DEPO_KODU = gelenSepet.DEPO_KODU;
                sepetEleman.SATIS_FIYAT = gelenSepet.SATIS_FIYAT;
                sepetEleman.SIRA = SIRABUL(gelenSepet.SEPETID);
                context.TBLSEPET_MKA.Add(sepetEleman);
                context.SaveChanges();
            }
        }

        public void SEPETUSTEKLE(TBLSEPETUST_MKA sepetUst)
        {
            using (UrunKontrolContext context = new UrunKontrolContext())
            {
                var sonuc = context.SEPETUST_MKA.Find(sepetUst.SEPETID);

                if (sonuc == null)
                {
                    TBLSEPETUST_MKA sepetUstEleman = new TBLSEPETUST_MKA();
                    sepetUstEleman.TARIH = DateTime.Now.Date;
                    sepetUstEleman.SEPETID = sepetUst.SEPETID;
                    sepetUstEleman.KAYITYAPANKUL = sepetUst.KAYITYAPANKUL;
                    sepetUstEleman.GENELTOPLAM = 0;
                    context.TBLSEPETUST_MKA.Add(sepetUstEleman);

                    context.SaveChanges();
                }
            }
        }

        public List<SEPETUST_MKA> SEPETUSTLIST(int kayitYapan)
        {
            using (UrunKontrolContext context = new UrunKontrolContext())
            {
                return context.SEPETUST_MKA.Where(i => i.KAYITYAPANKUL == kayitYapan).ToList();
            }
        }

        public TBLSEPETUST_MKA SEPETUST(string sepetNo)
        {
            using (UrunKontrolContext context = new UrunKontrolContext())
            {
                var urun = context.TBLSEPETUST_MKA.Where(i => i.SEPETID == sepetNo).FirstOrDefault();
                return urun;
            }
        }

        public void SEPETUSTGUNCELLE(TBLSEPETUST_MKA gelenSepet)
        {
            using (UrunKontrolContext context = new UrunKontrolContext())
            {
                var sepet = context.TBLSEPETUST_MKA.Where(i => i.SEPETID == gelenSepet.SEPETID).FirstOrDefault();
                sepet.CARI_KODU = gelenSepet.CARI_KODU;
                context.SaveChanges();
            }
        }


        public void SEPETKALEMFIYATGUNCELLE(TBLSEPET_MKA gelenSepet)
        {
            using (UrunKontrolContext context = new UrunKontrolContext())
            {
                var sepet = context.TBLSEPET_MKA.Where(i => i.SEPETID == gelenSepet.SEPETID && i.SIRA==gelenSepet.SIRA).FirstOrDefault();
                sepet.SATIS_FIYAT = gelenSepet.SATIS_FIYAT;
                context.SaveChanges();
            }
        }

        public void SEPETTENSIL(string stok_kodu, int sepetNo, int siraNo)
        {
            using (UrunKontrolContext context = new UrunKontrolContext())
            {

                string sqlCumle = "delete from TBLSEPET_MKA where STOK_KODU ='" + stok_kodu + "' and SEPETID= " + sepetNo + " and SIRA= " + siraNo + "  ";
                context.TBLSEPET_MKA.SqlQuery(sqlCumle);
                context.Database.ExecuteSqlCommand(sqlCumle);

                //var silinecekUrun = context.TBLSEPET_MKA.Where(i => i.SEPETID == sepetNo && i.STOK_KODU == stok_kodu && i.DEPO_KODU==depoKodu).FirstOrDefault();
                //context.TBLSEPET_MKA.Remove(silinecekUrun);
                //context.SaveChanges();                 
            }
        }
    }
}

