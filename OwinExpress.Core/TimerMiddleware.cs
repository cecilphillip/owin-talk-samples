using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

using AppFunc = System.Func<System.Collections.Generic.IDictionary<string, object>,System.Threading.Tasks.Task>;

namespace OwinExpress
{
    public class TimerMiddleware
    {
        private readonly AppFunc _nextFunc;

        public TimerMiddleware(AppFunc nextFunc)
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
