using System.Collections.Generic;

namespace CodeFirstDatabase
{
    public class Contest
    {
        public int ContestId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Duration { get; set; }
        public ICollection<ProblemContest> ProblemContest { get; set; }
		public ICollection<Contestant> Contestants {get; set; }
    }
}
