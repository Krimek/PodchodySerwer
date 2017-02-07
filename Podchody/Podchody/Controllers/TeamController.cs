using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RESTservice.Controllers
{
    public class TeamController : ApiController
    {
        // GET: podchody/api/Team
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: podchody/api/Team/5
        public string Get(int id)
        {
            return "value";
        }
        

        // POST: podchody/api/Team
        public string Post(int id, [FromBody]string value)
        {
            return id.ToString();
        }

        // PUT: podchody/api/Team/5
        public void Put(int id, [FromBody]string value)
        {
        }
        
    }
}
