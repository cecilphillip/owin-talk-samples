using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Owin;
using AppFunc = System.Func<System.Collections.Generic.IDictionary<string, object>, System.Threading.Tasks.Task>;
namespace OwinRaw
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseErrorPage();
            //app.Use(typeof (PingMiddleWare));
            //app.UsePing();
            //app.Use(new Func<AppFunc, AppFunc>(next => new PingMiddleWare(next).Invoke));
            app.Map("/invoke", sub =>
                {
                    sub.Use(new Func<AppFunc, AppFunc>(next => (AppFunc)Invoke));

                });

            app.UseWelcomePage();
        }


        public async Task Invoke(IDictionary<string, object> env)
        {
            var responseText = "Hi dotNet Miami from Raw OWIN";
            var responseBytes = Encoding.UTF8.GetBytes(responseText);

            var responseStream = (Stream)env["owin.ResponseBody"];
            var responseHeaders = (IDictionary<string, string[]>)env["owin.ResponseHeaders"];

            responseHeaders["Content-Length"] = new[] { responseBytes.Length.ToString(CultureInfo.InvariantCulture) };
            responseHeaders["Content-Type"] = new[] { "text/plain" };

            await responseStream.WriteAsync(responseBytes, 0, responseBytes.Length);
        }
    }
}