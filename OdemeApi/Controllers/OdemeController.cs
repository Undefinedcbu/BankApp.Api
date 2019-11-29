using Business.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace OdemeApi.Controllers
{
    public class OdemeController : ApiController
    {
        OdemeBusiness business = new OdemeBusiness();
        // GET: api/Odeme
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Odeme/5
        public IHttpActionResult Get(string AboneNo)
        {
            var Odeme = business.AboneNoSec(AboneNo);
            if (Odeme == null)
                return NotFound();
            return Ok(Odeme.Borc);
        }

        // POST: api/Odeme
        public IHttpActionResult Post(string AboneNo)
        {
            var Odeme = business.BorcOde(AboneNo);
            if (Odeme)
                return NotFound();
            return Ok(Odeme);
        }

        // PUT: api/Odeme/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Odeme/5
        public void Delete(int id)
        {
        }
    }
}
