using MatcomJamDAL.Models.MyModel;

namespace CodeFirstDatabase
{
    public class UserTeam
    {
		public string UserId { get; set; }
		public ApplicationUser User {get; set; }
		
        public int TeamID { get; set; }
        public Team Team {get; set; }
		
		// I think the navigation properties should be virtual
		// TODO Check that
    }
}
