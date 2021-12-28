using System.Collections.Generic;
using System.Web.Http;
using UrunKontrolWebApi.Business;
using UrunKontrolWebApi.Entities;

namespace StokKontrolApp.Controllers
{
    public class UrunController : ApiController
    {
        UrunKontrolManager stokKontrolManager = new UrunKontrolManager();


        public IEnumerable<STOKBAKIYE_MKA> GetTumStoklar()
        {
            return stokKontrolManager.StokBakiyeListe();
        }


        //public IHttpActionResult GetStokBakiye(string id)
        //{
        //    var arananUrun = stokKontrolManager.stokBakiyeGetir(id);
        //    return Ok(arananUrun);
        //}

        //[Route("GetStokBakiyeAdaGore")]
        public IHttpActionResult GetStokBakiyeAdaGore(string id)
        {
            var arananUrun = stokKontrolManager.StokBakiyeAdaGoreGetir(id);
            return Ok(arananUrun);
        }

        [Route("GetStokBakiyeDepolarAyri")]
        public IHttpActionResult GetStokBakiyeDepolarAyri(string id)
        {
            var arananUrun = stokKontrolManager.StokBakiyeDepolarAyri(id);
            return Ok(arananUrun);
        }

    }
}
