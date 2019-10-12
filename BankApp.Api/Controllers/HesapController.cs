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
        public IHttpActionResult Get(int id)
        {
            var Hesap = business.HesapIdSec(id);
            if (Hesap == null)
                return NotFound();
            return Ok(Hesap);
        }

        // POST: api/Hesap
        public IHttpActionResult Post([FromBody]Hesap Hesap)
        {
            if (ModelState.IsValid)
            {
                var olusturulanHesap = business.HesapEkle(Hesap);
                return CreatedAtRoute("DefaultApi", new { id = olusturulanHesap.HesapID }, olusturulanHesap);
            }
            return BadRequest();

        }

        // PUT: api/Hesap/5
        public IHttpActionResult Post(int id)
        {
            var Hesap = business.HesapIdSec(id);
            if (Hesap == null)
                return NotFound();
            Hesap.Durum = false;
            return Ok(Hesap);
            
            
        }

  
    }
}
