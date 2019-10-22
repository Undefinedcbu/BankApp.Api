using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Business.Concretes;

namespace BankApp.Api.Controllers
{
    public class TransferController : ApiController
    {
        HesapBusiness hesapBusiness = new HesapBusiness();
        // GET: api/Transfer
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Transfer/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Transfer
        public bool Post(string GonderenNo, string AliciNo, decimal Miktar)
        {
            return hesapBusiness.Transfer(GonderenNo, AliciNo, Miktar);
        }

        // PUT: api/Transfer/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Transfer/5
        public void Delete(int id)
        {
        }
    }
}
