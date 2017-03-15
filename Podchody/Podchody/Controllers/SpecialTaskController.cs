using Podchody.Models;
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

        [HttpGet]
        public IHttpActionResult Get()
        {
            ServiceSpecialTask service = new ServiceSpecialTask();
            SpecialTask st;
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
            s = service.GetSpecialTask(id, out st);

            if (s == "Brak")
            {
                return Ok("Brak zadania specjalnego dla danej stacji");
            }
            else if (s != "")
            {
                return BadRequest(s);
            }
            
            return Ok(st);
        }

        [HttpPost]
        public IHttpActionResult Post()
        {

            return Ok();
        }
    }
}
