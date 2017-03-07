using Podchody.Models;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.ServiceModel.Web;
using System.Web.Http;

namespace Podchody.Controllers
{
    public class StartController : ApiController
    {
        [HttpPost]
        public IHttpActionResult Post()
        {
            ServiceTeam serviceTeam = new ServiceTeam();
            App_Code.Security sec = new App_Code.Security();
            string s = "";
            string name, code;
            try
            {
                s = "code";
                code = Request.Headers.GetValues(s).FirstOrDefault();
                s = "name";
                name = Request.Headers.GetValues(s).FirstOrDefault();
            }
            catch
            {
                string error = "Can't find " + s + " in header";
                return BadRequest(error);
            }
            
            if(!sec.CheckedStartCode(code))
            {
                return BadRequest("Wrong code");
            }

            Guid g = serviceTeam.AddTeam(name);

            if (g.Equals(Guid.Empty))
            {
                s = "Name " + name + " is exist in current game";
                return BadRequest(s);
            }

            return Ok(g);

        }
    }
}
