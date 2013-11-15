using System.Web.Http;
using Owin;

namespace OwinBugParty
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();

            var config = new HttpConfiguration();
            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute("bugs", "api/{Controller}");
            app.UseWebApi(config);

            
            app.UseNancy();
        }
    }
}