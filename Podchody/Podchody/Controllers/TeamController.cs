using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Podchody.Controllers
{
    public class TeamController : ApiController
    {
                
        //przy każdym zapytaniu o wskazówkę do kolejnego miejsca musisz się pytać czy jest zad specjalne
        public string Get(string id)
        {
            return "stacje get";
        }
        

        // POST: podchody/api/Team --> tutaj się pytają serwera czy w dobrym miejscu są.
        public string Post(string id, string code)
        {
            return "stacje post";
        }
        
    }
}
