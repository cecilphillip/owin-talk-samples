using System;
using Owin;
using AppFunc = System.Func<System.Collections.Generic.IDictionary<string, object>, System.Threading.Tasks.Task>;


namespace OwinExpress.Host.Web
{

    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseErrorPage();
            app.UseMethodOverride();

            app.Get("/", (req, resp) =>
            {
                return resp.WriteAsync("done");
            });

            app.Get("/fire", (req, resp) =>
            {
                throw new Exception("Boom");
                return resp.WriteAsync("fire");
            });

        }
    }
}