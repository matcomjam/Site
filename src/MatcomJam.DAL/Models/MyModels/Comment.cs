using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstDatabase
{
    public class Comment
    {
		public int Id {get; set; }
		public int UserId {get; set; }
		public int BlogId {get; set; }
		
		public User User {get; set; }
		public Blog Blog {get; set; ]
    }
}
