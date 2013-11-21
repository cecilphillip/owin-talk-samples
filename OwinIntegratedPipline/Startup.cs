using Microsoft.Owin.Extensions;
using Owin;

namespace OwinIntegratedPipline
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.Use<IntegratedMiddleware>("One");
            app.Use<IntegratedMiddleware>("Two");
            app.UseStageMarker(PipelineStage.Authorize);
            
            app.Use<IntegratedMiddleware>("Three");
            app.Use<IntegratedMiddleware>("Four");
            app.UseStageMarker(PipelineStage.PostMapHandler);
          
            app.Run(ctx =>
               ctx.Response.WriteAsync("Done!!")
            );
        }
    }
}