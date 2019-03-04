using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Hosting;
using System.Web.Http;

namespace Tracker.Controllers
{
    public class AppController : ApiController
    {
        [HttpGet]
        public HttpResponseMessage FetchIndex()
        {
            var root = new DirectoryInfo(HostingEnvironment.MapPath(@"~"));
            var clientPath = Path.Combine(root.FullName, "Client/dist/index.html");
            var rsp = new HttpResponseMessage();



            rsp.Content = new StringContent(File.ReadAllText(clientPath));
            rsp.Content.Headers.ContentType = new MediaTypeHeaderValue("text/html");
            rsp.StatusCode = HttpStatusCode.OK;
            return rsp;
        }
    }
}
