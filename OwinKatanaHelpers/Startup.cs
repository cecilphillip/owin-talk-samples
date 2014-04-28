using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using OwinKatanaHelpers.Middleware;

namespace OwinKatanaHelpers
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var deniedAddress = "192.168.1.1";
            //app.Use<RestrictedIpMiddleware>(new HashSet<string> { deniedAddress });
            app.Use<PingMiddleware>();
                      
            app.Run(InvokeContext);
        }

        public Task InvokeContext(IOwinContext context)
        {
            context.Response.ContentType = "text/plain";
            return context.Response.WriteAsync("Hi dotNet Miami from OWIN w/ helpers");
        }
    }
}