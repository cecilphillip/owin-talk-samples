using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using AppFunc = System.Func<System.Collections.Generic.IDictionary<string, object>, System.Threading.Tasks.Task>;


namespace OwinExpress.Host.Web
{
   
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {

          //  app.Use(typeof (TimerMiddleware));
            //app.Run(Invoke);

            app.UseErrorPage();
          

            
            
        }

        //public Task Invoker(IOwinContext ctx)
        //{
        //    ctx.Response.ContentType = "text/plain";
        //    return ctx.Response.WriteAsync("Hi Mom");
        //}
      
      
    }
}