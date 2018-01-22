using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstDatabase
{
    public class Problem
    {
        public int Id { get; set; }
        
		public string Tag { get; set; }
		public string Description {get; set; }
        
		public ICollection<ProblemContest> ProblemContests { get; set; }
		public ICollection<Test> Tests {get; set; }
		public ICollection<Language> Languages {get; set; }
        
		public Restriction Restriction { get; set; }
    }
}
