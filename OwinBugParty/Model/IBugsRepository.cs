using System.Collections.Generic;

namespace OwinBugParty.Model
{
    public interface IBugsRepository
    {
        IEnumerable<Bug> GetBugs();
    }
}