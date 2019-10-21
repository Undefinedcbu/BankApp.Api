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

        // GET: api/Hesap/5
        [Route("api/Hesap")]
        public IHttpActionResult Get(int id)
        {
            var Hesap = business.HesapGoruntule(id);
            if (Hesap == null)
                return NotFound();
            return Ok(Hesap);
        }

        // POST: api/Hesap
        [HttpPost]
        [Route("api/Hesap")]
        public IHttpActionResult Post(int id, [FromBody]Hesap Hesap)
        {
            if (ModelState.IsValid)
            {
                var olusturulanHesap = business.HesapEkle(Hesap,id);
                return Ok(olusturulanHesap);
            }
            return BadRequest();

        }

        // PUT: api/Hesap/5
        public IHttpActionResult Post(int id)
        {
            var Hesap = business.HesapDurumGuncelle(id, false);
            if (Hesap == null)
                return NotFound();
            
            return Ok(Hesap);
        }

  
    }
}
