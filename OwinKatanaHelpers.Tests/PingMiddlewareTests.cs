using System.Linq;
using System.Threading.Tasks;
using Microsoft.Owin.Testing;
using OwinKatanaHelpers.Middleware;
using Xunit;
using Owin;

namespace OwinKatanaHelpers.Tests
{
    public class PingMiddlewareTests
    {
        [Fact]
        public async Task Invoke_Returns_If_Header_Present()
        {
            string PingMe = "X-PingMe";
            string PingBack = "X-PingBack";

            using (var server = TestServer.Create(app => app.UsePing()))
            {
                var reqBuilder = server.CreateRequest("/").AddHeader(PingMe, "dotNet Miami");
                var resp = await reqBuilder.GetAsync();

                Assert.True(resp.Headers.Contains(PingBack));
                var value = resp.Headers.GetValues(PingBack).First();
                Assert.Equal("HI dotNet Miami", value);
            }
        }

        [Fact]
        public async Task Invoke_Passes_Through_If_Header_Not_Present()
        {
            string PingBack = "X-PingBack";
            using (var server = TestServer.Create(app =>
                    {
                        app.UsePing();
                        app.Run(ctx => ctx.Response.WriteAsync("done"));
                    }))
            {
                var reqBuilder = server.CreateRequest("/");
                var resp = await reqBuilder.GetAsync();

                Assert.False(resp.Headers.Contains(PingBack));
                var respBody = await resp.Content.ReadAsStringAsync();
                Assert.Equal("done", respBody);
            }
        }
    }
}