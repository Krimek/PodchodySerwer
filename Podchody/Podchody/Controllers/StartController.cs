using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Podchody.Controllers
{
    public class StartController : ApiController
    {
        
        // GET: api/Start/5
        public string Get(string id)
        {
            return "Twoje ID";
        }
    }
}
