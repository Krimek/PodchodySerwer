using Podchody.Models;
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
        [HttpPost]
        public IHttpActionResult Pos()
        {
            ServiceStation service = new ServiceStation();
            Station st;
            string id, s = "";
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
            s = service.GetNextStation(id, out st);
            if (s != "")
            {
                return BadRequest(s);
            }

            if (service.IsFinish(id))
                return Ok("Finish");

            return Ok(st);
        }
    }
}
