using Podchody.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Podchody.Controllers
{
    public class FullTipController : ApiController
    {
        [HttpPost]
        public IHttpActionResult Post()
        {
            ServiceTeam serviceTeam = new ServiceTeam();
            string s = "";
            string id;
            try
            {
                s = "id";
                id = Request.Headers.GetValues(s).FirstOrDefault();
            }
            catch
            {
                string error = "Can't find " + s + "headers";
                return BadRequest(error);
            }
            s = serviceTeam.AddFullTip(id);
            if (s != "")
            {
                return BadRequest(s);
            }

            return Ok();
        }
    }
}
