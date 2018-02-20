using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;
using MatcomJamDAL.Models.MyModel;

namespace CodeFirstDatabase
{
    public class Comment
    {
		public string UserId {get; set; }
		public int BlogId {get; set; }
		
		public ApplicationUser User {get; set; }
        public Blog Blog { get; set; }
    }
}
