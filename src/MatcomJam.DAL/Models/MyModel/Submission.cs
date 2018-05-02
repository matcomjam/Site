namespace CodeFirstDatabase
{
    public class Submission
    {
        public int ProblemContestId { get; set; }
		public ProblemContest ProblemContest {get; set; }
		        
        public string ContestantId { get; set; }
        public Contestant Contestant { get; set; }
		
		public int LanguageId { get; set; }		
        public Language Language { get; set; }

        public string Result { get; set; }
    }
}