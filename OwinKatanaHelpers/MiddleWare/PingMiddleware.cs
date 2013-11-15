using System.Threading.Tasks;
using Microsoft.Owin;

namespace OwinKatanaHelpers.Middleware
{
    public class PingMiddleware : OwinMiddleware
    {
        private const string PingMe = "X-PingMe";
        private const string PingBack = "X-PingBack";

        public PingMiddleware(OwinMiddleware next) : base(next)
        {
        }

        public async override Task Invoke(IOwinContext context)
        {
            if (context.Request.Headers.Keys.Contains(PingMe))
            {
                var value = context.Request.Headers[PingMe];
                context.Response.Headers[PingBack] = string.Format("HI {0}", value);
                context.Response.StatusCode = 202;
                return;
            }

            await Next.Invoke(context);
        }
    }
}