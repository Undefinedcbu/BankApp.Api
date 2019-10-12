using Business;
using System;
using System.Web.Http;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Web.Http.Cors;
using Models.Concretes;

namespace BankApp.Api.Controllers
{
    [EnableCors("*","*","*")]
    public class MusteriController : ApiController
    {
        MusteriBusiness business = new MusteriBusiness();
        // GET: api/Login
        public MusteriController()
        {

        }
        public IHttpActionResult PostGiris(string TCKimlik, string parola)
        {
            var kullanici = business.Giris(TCKimlik, parola);
            if (kullanici != null)
                return Ok(kullanici);
            return NotFound();
        }

        public IHttpActionResult Get(int id)
        {
            var Kullanici = business.MusteriIdSec(id);
            if (Kullanici == null)
                return NotFound();
            return Ok(Kullanici);
        }

        public IHttpActionResult Post([FromBody]Musteri Musteri)
        {
            if (ModelState.IsValid)
            {
                var olusturulanMusteri = business.MusteriEkle(Musteri);
                return CreatedAtRoute("DefaultApi", new { id = olusturulanMusteri.MusteriID }, olusturulanMusteri);
            }
            return BadRequest();

        }
    }
}
