using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace OwinKatanaHelpers.Middleware
{
    public class TimerMiddleware
    {
        private readonly Func<IDictionary<string, object>, Task> _nextFunc;

        public TimerMiddleware(Func<IDictionary<string, object>, Task> nextFunc)
        {
            _nextFunc = nextFunc;
        }

        public async Task Invoke(IDictionary<string, object> env)
        {
            Debug.WriteLine("Request: " + env["owin.RequestPath"].ToString());
            await _nextFunc(env);
            Debug.WriteLine("Response: " + env["owin.ResponseStatusCode"].ToString());
        }
    }
}
