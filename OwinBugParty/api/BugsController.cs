using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Microsoft.AspNet.SignalR;
using OwinBugParty.Hubs;
using OwinBugParty.Model;

namespace OwinBugParty.api
{
    public class BugsController : ApiController
    {
        private readonly IBugsRepository bugsRepository = new BugsRepository();
        private readonly IHubContext hub;

        public BugsController()
        {
            hub = GlobalHost.ConnectionManager.GetHubContext<BugHub>();
        }

        public IEnumerable<Bug> Get()
        {
            return bugsRepository.GetBugs();
        }

        [HttpPost]
        [Route("api/bugs/backlog")]
        public Bug MoveToBacklog([FromBody] int id)
        {
            var bug = bugsRepository.GetBugs().First(b=>b.id==id);
            bug.state = "backlog";

            hub.Clients.All.moved(bug);

            return bug;
        }

        [HttpPost]
        [Route("api/bugs/working")]
        public Bug MoveToWorking([FromBody] int id)
        {
            var bug = bugsRepository.GetBugs().First(b => b.id == id);
            bug.state = "working";

            hub.Clients.All.moved(bug);

            return bug;
        }

        [HttpPost]
        [Route("api/bugs/done")]
        public Bug MoveToDone([FromBody] int id)
        {
            var bug = bugsRepository.GetBugs().First(b => b.id == id);
            bug.state = "done";

            hub.Clients.All.moved(bug);

            return bug;
        }
    }
}