using System.ComponentModel.DataAnnotations;

namespace CodeFirstDatabase
{
    public class Solution
    {
        public int Id { get; set; }

        public int ProblemContestId { get; set; }
		public ProblemContest ProblemContest {get; set; }
		        
        public int ContestantId { get; set; }
        public Contestant Contestant { get; set; }
		
		public int LanguageId { get; set; }		
        public Language Language { get; set; }
    }
}