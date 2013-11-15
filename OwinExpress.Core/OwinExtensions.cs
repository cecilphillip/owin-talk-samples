using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using OwinExpress;
using OwinExpress.Middleware;

namespace Owin
{
    public static class OwinExtensions
    {
        public static IAppBuilder UseMethodOverride(this IAppBuilder app)
        {
            return app.Use<MethodOverrideMiddleware>();
        }

        public static IAppBuilder Get(this IAppBuilder app, string path, Func<IOwinRequest, IOwinResponse, Task> handler)
        {
            return ProcessRequest(app, Constants.GET, path, handler);
        }

        public static IAppBuilder Post(this IAppBuilder app, string path, Func<IOwinRequest, IOwinResponse, Task> handler)
        {
            return ProcessRequest(app, Constants.POST, path, handler);
        }

        public static IAppBuilder Put(this IAppBuilder app, string path, Func<IOwinRequest, IOwinResponse, Task> handler)
        {
            return ProcessRequest(app, Constants.PUT, path, handler);
        }

        public static IAppBuilder Delete(this IAppBuilder app, string path, Func<IOwinRequest, IOwinResponse, Task> handler)
        {
            return ProcessRequest(app, Constants.DELETE, path, handler);
        }

        private static IAppBuilder ProcessRequest(IAppBuilder app, string method, string path, Func<IOwinRequest, IOwinResponse, Task> handler)
        {
            return app.Use( async (ctx, next) =>
            {
                if (ctx.Request.Method == method && ctx.Request.Path.Value == path)
                {
                    await handler(ctx.Request, ctx.Response);
                }
                else
                {
                    await next();
                }
            });
        }
    }
}