using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CW.Backend.Services.Controllers
{
    public class DataTestController : ApiController
    {
        // GET: api/DataTest
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/DataTest/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/DataTest
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/DataTest/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/DataTest/5
        public void Delete(int id)
        {
        }
    }
}
