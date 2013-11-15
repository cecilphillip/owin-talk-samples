using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Owin;


namespace OwinExpress.Middleware
{
    public class MethodOverrideMiddleware
    {
        private readonly Func<IDictionary<string, object>, Task> _nextFunc;
        private readonly string[] _methods = { Constants.DELETE, Constants.HEAD, Constants.PUT };
        private const string HEADER = "X-HTTP-Method-Override";

        public MethodOverrideMiddleware(Func<IDictionary<string, object>, Task> nextFunc)
        {
            _nextFunc = nextFunc;
        }

        public async Task Invoke(IDictionary<string, object> env)
        {
            var ctx = new OwinContext(env);
            if (ctx.Request.Method == Constants.POST && ctx.Request.Headers.Keys.Contains(HEADER))
            {
                var method = ctx.Request.Headers.Get(HEADER);
                if (_methods.Contains(method))
                {
                    ctx.Request.Method = method;
                }
            }
            await _nextFunc(env);
        }
    }
}