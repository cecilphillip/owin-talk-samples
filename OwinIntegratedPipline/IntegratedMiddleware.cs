using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Owin;

namespace OwinIntegratedPipline
{
    public class IntegratedMiddleware
    {
        private readonly Func<IDictionary<string, object>, Task> next;
        private readonly string _text;

        public IntegratedMiddleware(Func<IDictionary<string, object>, Task> next, string text)
        {
            this.next = next;
            _text = text;
        }

        public async Task Invoke(IDictionary<string, object> env)
        {
            var context = new OwinContext(env);
            context.Response.Write("<p>" + _text + " begin </ p>");
            await next.Invoke(env);
        }
    }
}