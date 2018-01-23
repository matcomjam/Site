using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstDatabase
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
		
		public int GroupId {get; set; }
		public Group Group {get; set; }
		
		public int InstitutionId {get; set; }
        public Institution Institution { get; set; }
		
		// public int BlogId {get; set; }
		public ICollection<Blog> Blog {get; set; }
		public ICollection<Comment> Comments {get; set; }
		
		//public int UserTeamId {get; set; }
		public ICollection<UserTeam> UserTeam {get; set; }
		
		// Ready!!!
		// TODO Check this entity
    }
}
