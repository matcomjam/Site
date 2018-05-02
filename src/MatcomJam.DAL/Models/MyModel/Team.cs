using System.Collections.Generic;

namespace CodeFirstDatabase
{
    public class Team
    {
        public int TeamId { get; set; }
        public string Name { get; set; }
        
		//public int UserTeamId {get; set; }
		public ICollection<UserTeam> UserTeams {get; set; }
		
		public ICollection<Contestant> Contestants { get; set; }
    }
}
