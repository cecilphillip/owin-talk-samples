using Owin;

namespace OwinRaw.Middleware
{
    public static class OwinExtensions
    {
        public static IAppBuilder UsePing(this IAppBuilder app)
        {
            return app.Use(typeof (PingMiddleware));
        }
    }
}