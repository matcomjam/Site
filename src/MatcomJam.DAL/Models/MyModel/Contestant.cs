using System.Collections.Generic;
using MatcomJamDAL.Models.MyModel;

namespace CodeFirstDatabase
{
    public class Contestant : ApplicationUser
    {
        public string ContestantId { get; set; }

        public int ContestId { get; set; }
        public int TeamId { get; set; }
        
		public Contest Contest { get; set; }
        public Team Team { get; set; }
        public ICollection<Submission> Solutions { get; set; }
    }
}
