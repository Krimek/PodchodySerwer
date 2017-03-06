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

        // GET: api/Start/5
        public string Get()
        {
            string name, code;
            try
            {
                code = Request.Headers.GetValues("Code").FirstOrDefault();
            }
            catch
            {
                return "Can't find 'code' header";
            }
            try
            {
                name = Request.Headers.GetValues("Name").FirstOrDefault();
            }
            catch
            {
                return "Can't find 'name' header";
            }

            Models.ServiceDataBase db = new Models.ServiceDataBase();

            App_Code.Security sec = new App_Code.Security();
            if(!sec.CheckedStartCode(code))
            {
                return "Wrong code";
            }

            return db.AddNewTeam(name);

        }
    }
}
