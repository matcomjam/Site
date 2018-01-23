using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstDatabase
{
    public class Team
    {
        public int TeamId { get; set; }
        public string Name { get; set; }
        
		public int UserTeamId {get; set; }
		public UserTeam UserTeam {get; set; }
		
		public ICollection<Contestant> Contestants { get; set; }
    }
}
