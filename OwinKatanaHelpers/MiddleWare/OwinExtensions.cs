using Owin;

namespace OwinKatanaHelpers.Middleware
{
    public static class OwinExtensions
    {
        public static IAppBuilder UsePing(this IAppBuilder app)
        {
            return app.Use(typeof (PingMiddleware));
        }
    }
}