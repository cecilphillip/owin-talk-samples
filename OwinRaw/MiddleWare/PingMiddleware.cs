using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OwinRaw.Middleware
{
    public class PingMiddleware
    {
        private readonly Func<IDictionary<string, object>, Task> next;
        private const string PingMe = "X-PingMe";
        private const string PingBack = "X-PingBack";

        public PingMiddleware(Func<IDictionary<string, object>, Task> next)
        {
            this.next = next;
        }

        public async Task Invoke(IDictionary<string, object> env)
        {
            var headers = (IDictionary<string, string[]>)env["owin.RequestHeaders"];

            if (headers.Keys.Contains(PingMe))
            {
                var value = headers[PingMe].FirstOrDefault();
                var responseHeaders = (IDictionary<string, string[]>)env["owin.ResponseHeaders"];
                responseHeaders[PingBack] = new[] { string.Format("HI {0}", value) };
                env["owin.ResponseStatusCode"] = 202;

                return;
            }

            await next(env);
        }
    }
}