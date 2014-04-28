using System;
using Microsoft.Owin;
using Microsoft.Owin.FileSystems;
using Microsoft.Owin.StaticFiles;
using Owin;

namespace OwinWPFHost
{
    public class StartupInternal
    {
        public void Configuration(IAppBuilder app)
        {
         
              app.MapSignalR();
                
                app.UseStaticFiles(new StaticFileOptions()
                {
                    RequestPath = new PathString("/Scripts"),
                    FileSystem = new PhysicalFileSystem(Environment.CurrentDirectory + @"\Scripts")
                });
                app.UseFileServer(new FileServerOptions
                {
                    RequestPath = PathString.Empty,
                    EnableDirectoryBrowsing = true,

                    FileSystem = new PhysicalFileSystem(@"."),
                                    });
                
                app.UseWelcomePage();
               
       
        }
    }
}