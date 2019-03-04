using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.ExceptionHandling;
using System.Web.Http.Results;
using Microsoft.Owin;
using Microsoft.Owin.FileSystems;
using Microsoft.Owin.StaticFiles;
using Owin;
using Tracker.App_Start;
using Tracker.Services.Exceptions;

[assembly: OwinStartup(typeof(Tracker.Startup))]

namespace Tracker
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            HttpConfiguration config = new HttpConfiguration();
            config.Services.Replace(typeof(IExceptionHandler), new GlobalExceptionHandler());
            OAuthConfig.ConfigureOAuth(app);
            UnityConfig.RegisterComponents(config);
            WebApiConfig.Register(config);

            var fsOptions = new FileServerOptions
            {
                EnableDirectoryBrowsing = false,
                EnableDefaultFiles = true,
                FileSystem = new PhysicalFileSystem(Path.Combine(HttpRuntime.AppDomainAppPath, @"Client\dist"))
            };
            app.UseFileServer(fsOptions);
         

            app.UseWebApi(config);
        }
    }

    public class GlobalExceptionHandler : ExceptionHandler
    {
 
        public override void Handle(ExceptionHandlerContext ctx)
        {
            var exception = ctx.Exception;
            string message = "";
            bool generic = true;
            if (exception is BaseException)
            {
                message = exception.Message;
                generic = false;
            }
            else message = "Something went wrong, please contact the administrator in order to fix this problem.";

            var result = new HttpResponseMessage(generic? HttpStatusCode.InternalServerError : HttpStatusCode.BadRequest)
            {
                Content = new StringContent(message),
                ReasonPhrase = "ArgumentNullException"
            };

            ctx.Result = new ArgumentNullResult(ctx.Request, result);
        }

    }

    public class ArgumentNullResult : IHttpActionResult
    {
        private HttpRequestMessage _request;
        private HttpResponseMessage _httpResponseMessage;


        public ArgumentNullResult(HttpRequestMessage request, HttpResponseMessage httpResponseMessage)
        {
            _request = request;
            _httpResponseMessage = httpResponseMessage;
        }

        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            return Task.FromResult(_httpResponseMessage);
        }
    }

}
