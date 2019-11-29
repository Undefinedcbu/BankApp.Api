using Business.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using Models.Concretes;

namespace BankApp.Api.Controllers
{
    public class HesapController : ApiController
    {
        HesapBusiness business = new HesapBusiness();
        // GET: api/Hesap
        public HesapController()
        {

        }

        [Route("api/Hesap/Havale")]
        public IHttpActionResult PutHavale(string GonderenNo, string AliciNo, decimal Miktar)
        {

            return Ok(business.Transfer(GonderenNo, AliciNo, Miktar));

        }

        [Route("api/Hesap/Virman")]
        public IHttpActionResult PutVirman(string GonderenNo,string AliciNo,decimal Miktar)
        {
          
            return Ok(business.Transfer(GonderenNo, AliciNo, Miktar));
        }

        [Route("api/Hesap/")]
        public IHttpActionResult Get()
        {
            var hesaplar = business.tumHesaplar();
            if (hesaplar == null)
                return NotFound();
            return Ok(hesaplar);
        }

        [Route("api/Hesap/")]
        public IHttpActionResult Get(int id)
        {
            var Hesap = business.HesapIdSec(id);
            if (Hesap == null)
                return NotFound();
            return Ok(Hesap);
        }

        [HttpGet]
        [Route("api/Hesap/Liste")]

        public IHttpActionResult Getir(int id)
        {
            var hesaplar = business.hepsiniSec(id);
            return Ok(hesaplar);
        }
        
        // GET: api/Hesap/5
        [HttpGet]
        [Route("api/Hesap/Musteri")]
        public IHttpActionResult Goruntule(int id)
        {
            var Hesap = business.HesapGoruntule(id);
            if (Hesap == null)
                return NotFound();
            return Ok(Hesap);
        }

        // POST: api/Hesap
        [HttpPost]
        [Route("api/Hesap")]
        public IHttpActionResult Ekle(int id,int ek)
        {
            Hesap hesap = new Hesap();
            hesap.Bakiye = 0;
            hesap.Durum = "Açık";
            hesap.MusteriID = id;
            if (ModelState.IsValid)
            {
                var olusturulanHesap = business.HesapEkle(hesap,id,ek);
                return Ok(olusturulanHesap);
            }
            return BadRequest();
        }

        // PUT: api/Hesap/5
        [HttpPut]
        [Route("api/Hesap/Kapat")]
        public IHttpActionResult Kapat(int id)
        {
            var Hesap = business.HesapDurumGuncelle(id, "Kapalı");
            if (Hesap == null)
                return NotFound();
            
            return Ok(Hesap);
        }

  
    }
}
