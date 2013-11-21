using System;
using Microsoft.Owin.Hosting;

namespace OwinExpress.Host.Self
{
    class Program
    {
        static void Main(string[] args)
        {
            const string url = "http://localhost:8181";

            using (WebApp.Start<Startup>(url))
            {
                Console.WriteLine("Running on {0}", url);
                Console.WriteLine("Press enter to exit");
                Console.ReadLine();
            }
        }
    }
}