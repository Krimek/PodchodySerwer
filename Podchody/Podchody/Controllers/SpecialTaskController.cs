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
            string idTeam, s = "";
            try
            {
                s = "idTeam";
                idTeam = Request.Headers.GetValues(s).FirstOrDefault();
            }
            catch
            {
                string error = "Can't find " + s + "headers";
                return BadRequest(error);
            }
            s = service.GetSpecialTask(idTeam, out st);

            if (s == "Brak")
            {
                return BadRequest("Brak zadania specjalnego dla danej stacji");
            }
            else if (s != "")
            {
                return BadRequest(s);
            }
            
            return Ok(new { Id = st.Id, Bonus = st.Bonus, Description = st.Description, Name = st.Name, IdStation = st.IdStation, Code = st.Code});
        }

        [HttpPost]
        public IHttpActionResult Post()
        {
            ServiceSpecialTask service = new ServiceSpecialTask();
            string idTeam, idSpecialTask, s = "";
            try
            {
                s = "idTeam";
                idTeam = Request.Headers.GetValues(s).FirstOrDefault();
            }
            catch
            {
                string error = "Can't find " + s + "headers";
                return BadRequest(error);
            }
            try
            {
                s = "idSpecialTask";
                idSpecialTask = Request.Headers.GetValues(s).FirstOrDefault();
            }
            catch
            {
                string error = "Can't find " + s + "headers";
                return BadRequest(error);
            }
            s = service.AcceptSpecialTask(idSpecialTask, idTeam);
            if(s != "")
            {
                return BadRequest(s);
            }
            return Ok();
        }
    }
}
