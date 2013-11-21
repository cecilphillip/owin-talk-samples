using System;
using System.Diagnostics;
using Owin;

namespace OwinWPFHost
{
    public class StartupInternal
    {
        private const string FileName = "Sample.html";

        public void Configuration(IAppBuilder app)
        {
            Environment.CurrentDirectory = Environment.CurrentDirectory + @"..\..\..";
            Process.Start("IExplore.exe", Environment.CurrentDirectory + "\\" + FileName);
            app.Map("/welcome", welcomeApp => welcomeApp.UseWelcomePage());
            
        }
    }
}