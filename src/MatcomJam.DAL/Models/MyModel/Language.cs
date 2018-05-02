using System.Collections.Generic;

namespace CodeFirstDatabase
{
    public class Language
    {
        public int Id {get; set; }
		public string Name {get; set; }
		
		public ICollection<Submission> Solutions {get; set; }
    }
}