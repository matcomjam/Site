using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstDatabase
{
    public class UserTeam
    {
        public int Id { get; set; }
        
		public int UserId { get; set; }
		public User User {get; set; }
		
        public int TeamID { get; set; }
        public Team Team {get; set; }
		
		// I think the navigation properties should be virtual
		// TODO Check that
    }
}
