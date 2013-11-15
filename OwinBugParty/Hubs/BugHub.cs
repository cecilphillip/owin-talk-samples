using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace OwinBugParty.Hubs
{
    [HubName("bugs")]
    public class BugHub : Hub
    {
    }
}