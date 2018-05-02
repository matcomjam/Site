using System.Collections.Generic;
using MatcomJamDAL.Models.MyModel;

namespace CodeFirstDatabase
{
    public class Blog
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public string UserName { get; set; }
    }
}