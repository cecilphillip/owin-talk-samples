using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Owin;

namespace OwinKatanaHelpers.Middleware
{
    public class PingMiddleware
    {
        private readonly Func<IDictionary<string, object>, Task> _next;
        private const string PingMe = "X-PingMe";
        private const string PingBack = "X-PingBack";

        public PingMiddleware(Func<IDictionary<string, object>, Task> next)
        {
            this._next = next;
        }

        public async Task Invoke(IDictionary<string, object> env)
        {
            var context = new OwinContext(env);
            if (context.Request.Headers.Keys.Contains(PingMe))
            {
                var value = context.Request.Headers[PingMe];
                context.Response.Headers[PingBack] = string.Format("HI {0}", value);
                context.Response.StatusCode = 202;
                return;
            }

            await _next(env);
        }
    }
}