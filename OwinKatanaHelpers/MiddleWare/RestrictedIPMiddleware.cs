using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Owin;

namespace OwinKatanaHelpers.Middleware
{
    /* Alternative way of building middleware but not recommended */
    public class RestrictedIpMiddleware : OwinMiddleware
    {
        private readonly HashSet<string> deniedIps;

        public RestrictedIpMiddleware(OwinMiddleware next, HashSet<string> deniedIps) :
            base(next)
        {
            this.deniedIps = deniedIps;
        }

        public override async Task Invoke(IOwinContext context)
        {
            var ipAddress = context.Request.RemoteIpAddress;

            if (deniedIps.Contains(ipAddress))
            {
                context.Response.StatusCode = 403;
                return;
            }

            await Next.Invoke(context);
        }
    }
}