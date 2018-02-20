using System.ComponentModel.DataAnnotations;

namespace CodeFirstDatabase
{
    public class Solution
    {
        public int ProblemContestId { get; set; }
		public ProblemContest ProblemContest {get; set; }
		        
        public string ContestantId { get; set; }
        public Contestant Contestant { get; set; }
		
		public int LanguageId { get; set; }		
        public Language Language { get; set; }
    }
}