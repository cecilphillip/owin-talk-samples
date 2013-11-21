using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Owin;

namespace OwinWPFHost
{
    public static class OwinExtensions
    {
        public static IAppBuilder UseSample(this IAppBuilder app, string filePath)
        {
            return app.Use(typeof(FileStreamMiddle), filePath);
        }
    }

    public class FileStreamMiddle
    {
        private Func<IDictionary<string, object>, Task> _next;
        private readonly string _filePath;

        public FileStreamMiddle(Func<IDictionary<string, object>, Task> next, string filePath)
        {
            this._next = next;
            _filePath = filePath;
        }

        public async Task Invoke(IDictionary<string, object> env)
        {
            var responseText = File.ReadAllText(_filePath);
            var responseBytes = Encoding.UTF8.GetBytes(responseText);

            var responseStream = (Stream)env["owin.ResponseBody"];
            var responseHeaders = (IDictionary<string, string[]>)env["owin.ResponseHeaders"];

            responseHeaders["Content-Length"] = new[] { responseBytes.Length.ToString(CultureInfo.InvariantCulture) };
            responseHeaders["Content-Type"] = new[] { "text/html" };

            await responseStream.WriteAsync(responseBytes, 0, responseBytes.Length);
        }
    }
}
