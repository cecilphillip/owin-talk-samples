using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Owin.Testing;
using OwinKatanaHelpers.Middleware;
using Xunit;
using Owin;

namespace OwinKatanaHelpers.Tests
{
    public class RestrictedIPMiddlewareTests
    {
        [Fact]
        public async Task Invoke_Denied_BlackListed_Addresses()
        {
            var deniedAddress = "192.168.1.1";
            using (var server = TestServer.Create(app => app.Use<RestrictedIpMiddleware>(new HashSet<string>{ deniedAddress})))
            {
                var reqBuilder = server.CreateRequest("/").And(req =>
                    {
                        req.Headers.Host = deniedAddress;
                    });
                var resp = await reqBuilder.GetAsync();
                Assert.Equal("Forbidden", resp.StatusCode.ToString());

            }
        }
    }
}
