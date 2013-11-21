using System;
using System.Web;

namespace OwinIntegratedPipline
{
    public class CustomModule : IHttpModule
    {
        public void Init(HttpApplication context)
        {
            context.MapRequestHandler += context_MapRequestHandler;
        }

        public void Dispose()
        {
        }

        protected void context_MapRequestHandler(object sender, EventArgs e)
        {
            HttpContext.Current.Response.Write("<p> Hi from the module </ p>");
        }
    }
}