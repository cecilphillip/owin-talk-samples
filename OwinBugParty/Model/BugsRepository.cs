using System.Collections.Generic;

namespace OwinBugParty.Model
{
    public class BugsRepository : IBugsRepository
    {
        private static readonly List<Bug> _repo;

        static BugsRepository()
        {
            _repo = new List<Bug>
                {
                    new Bug {id = 1, title = "bug #1", description = "first bug", state = "backlog"}, 
                    new Bug {id = 2, title = "bug #2", description = "second bug", state = "working"}, 
                    new Bug {id = 3, title = "bug #3", description = "third bug", state = "done"},
                    new Bug {id = 4, title = "bug #4", description = "fourth bug", state = "backlog"}, 
                    new Bug {id = 5, title = "bug #5", description = "fifth bug", state = "working"}, 
                    new Bug {id = 6, title = "bug #6", description = "sixth bug", state = "done"}
                };
        }

        public IEnumerable<Bug> GetBugs()
        {
            return _repo;
        }
    }
}