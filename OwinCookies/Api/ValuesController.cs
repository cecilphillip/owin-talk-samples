using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http;

namespace OwinCookies.Api
{
    [Authorize]
    [RoutePrefix("api/values")]
    public class ValuesController : ApiController
    {
        // GET api/<controller>
        [HttpGet]
        [Route("")]
        public IEnumerable<string> Get()
        {
            /**How to get the current user**/
            var option1 = this.RequestContext.Principal;
            var option2 = this.Request.GetOwinContext().Authentication.User;
            return new string[] { "value1", "value2" };
        }
    }
}