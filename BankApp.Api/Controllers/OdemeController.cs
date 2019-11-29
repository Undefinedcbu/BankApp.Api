using Business.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace BankApp.Api.Controllers
{
    [EnableCors("*", "*", "*")]
    public class OdemeController : ApiController
    {
        OdemeBusiness business = new OdemeBusiness();
     

        // GET: api/Odeme/5
        public IHttpActionResult Get(int AboneNo)
        {
            var Odeme = business.AboneNoSec(AboneNo);
            if (Odeme == null)
                return NotFound();
            return Ok(Odeme);
        }

        // POST: api/Odeme
        public IHttpActionResult Post(int AboneNo,string HesapNo)
        {
            var Odeme = business.BorcOde(AboneNo,HesapNo);
            if (Odeme)
                return Ok(Odeme);
            return NotFound();
        }

    }
}
