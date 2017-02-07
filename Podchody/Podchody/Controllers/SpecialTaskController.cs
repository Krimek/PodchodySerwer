using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RESTservice.Controllers
{
    public class SpecialTaskController : ApiController
    {
        // GET: podchody/api/SpecialTask
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: podchody/api/SpecialTask/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: podchody/api/SpecialTask
        public void Post([FromBody]string value)
        {
        }

        // PUT: podchody/api/SpecialTask/5
        public string Put(int id, [FromBody]string value)
        {
            return value;
        }

        // DELETE: podchody/api/SpecialTask/5
        public void Delete(int id)
        {
        }
    }
}
