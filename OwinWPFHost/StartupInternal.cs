using System;
using System.Diagnostics;
using System.IO;
using Ormikon.Owin.Static;
using Owin;


namespace OwinWPFHost
{
    public class StartupInternal
    {
        private const string FileName = "Sample.html";

        public void Configuration(IAppBuilder app)
        {
             Environment.CurrentDirectory = Environment.CurrentDirectory + @"..\..\..";

            app.MapSignalR();
            app.Map("/welcome", welcomeApp => welcomeApp.UseWelcomePage());
            app.Map("/Sample", sampleApp => sampleApp.UseSample(Path.Combine(Environment.CurrentDirectory, FileName)));
            app.MapStatic("/scripts", new StaticSettings(Path.Combine(Environment.CurrentDirectory, "Scripts")) {Expires = DateTimeOffset.Now.AddDays(1), Cached = true, Include = "*.js"});
            Process.Start("IExplore.exe",  "http://localhost:11000/Sample");
        }
    }
}