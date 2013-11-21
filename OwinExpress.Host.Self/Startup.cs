using System;
using Owin;

namespace OwinExpress.Host.Self
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