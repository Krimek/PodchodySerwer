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
        public IHttpActionResult Post()
        {
            ServiceStation service = new ServiceStation();
            Station st;
            string idTeam, idStation, s = "";
            try
            {
                s = "idTeam";
                idTeam = Request.Headers.GetValues(s).FirstOrDefault();
            }
            catch
            {
                string error = "Can't find " + s + " headers";
                return BadRequest(error);
            }
            try
            {
                s = "idStation";
                idStation = Request.Headers.GetValues(s).FirstOrDefault();
            }
            catch
            {
                string error = "Can't find " + s + " headers";
                return BadRequest(error);
            }
            s = service.GetNextStation(idTeam, idStation, out st);
            bool specialTas = false;
            if (s =="" && st.SpecialTasks.Count > 0)
            {
                specialTas = true;
            }
            if (s == "Finish")
            {
                return Ok("Finish");
            }
            else if (s != "")
            {
                return BadRequest(s);
            }
            
            else
            {
                return Ok(new { idStation = st.Id, numberOfStation = st.NumberOfStation, description = st.Description, hint = st.Hint, fullHint = st.NextPlace, code = st.Code, specialTask = specialTas, Location = st.Location });
            }
        }
    }
}
