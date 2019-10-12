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
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Hesap/5
        public string Get(int id)
        {
            return "value";
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
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Hesap/5
        public void Delete(int id)
        {
        }
    }
}
