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
            IEnumerable<string> headerValues = Request.Headers.GetValues("Id");
            var id = headerValues.FirstOrDefault();
            //var request = WebOperationContext.Current.IncomingRequest;
            //string header = request.Headers[HttpRequestHeader.Cookie];
            //var r = Request.Headers;
            //string c = r.GetValues("id").Single();
            return id;
        }
    }
}
