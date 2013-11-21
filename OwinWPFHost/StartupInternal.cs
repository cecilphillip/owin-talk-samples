using System;
using System.Diagnostics;
using System.IO;
using Ormikon.Owin.Static;
using Owin;

namespace OwinWPFHost
{
    public class StartupInternal
    {
        private const string FileName = "index.html";

        public void Configuration(IAppBuilder app)
        {
            //Environment.CurrentDirectory = Environment.CurrentDirectory + @"..\..\..";
            app.Map("/Sample", sampleApp => sampleApp.UseSample(Path.Combine(Environment.CurrentDirectory, FileName)));

            app.UseStatic(new StaticSettings(Environment.CurrentDirectory) { Cached = false });
            app.MapSignalR();
            app.UseWelcomePage();
            Process.Start("IExplore.exe", "http://localhost:11000/Sample");
        }
    }
}