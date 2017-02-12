using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Podchody.Controllers
{
    public class TipController : ApiController
    {
        // GET: api/Tip/5
        public string Get(int id)
        {
            return "wskazówka";
        }
    }
}
