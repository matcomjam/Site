using System.Collections.Generic;

namespace CodeFirstDatabase
{
    public class Problem
    {
        public int Id { get; set; }

        public string Title { get; set; }
		public string Tag { get; set; }
		public string Description {get; set; }
        
		public ICollection<ProblemContest> ProblemContests { get; set; }
		public ICollection<Test> Tests {get; set; }
		public ICollection<Language> Languages {get; set; }
        
        public int TimeLimit { get; set; }
        public int MemoryLimit { get; set; }
        public int MaximumMessages { get; set; }
        public int NumberOfNodes { get; set; }
        public int SizeOfMessages { get; set; }
    }
}
