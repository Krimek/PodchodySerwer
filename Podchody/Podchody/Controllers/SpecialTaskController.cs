using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Podchody.Controllers
{
    public class SpecialTaskController : ApiController
    {

        //przy każdej kolejnej wskazówce pobranej musisz się zapytać czy jest specjalne zadanie.

        public string Get(string id)
        {
            return "zadanie specjalne, pobrane";
        }

        // POST: podchody/api/SpecialTask
        public string Post(string id, [FromBody]string value)
        {
            return "zadanie specjalne, wykonane";
        }
    }
}
