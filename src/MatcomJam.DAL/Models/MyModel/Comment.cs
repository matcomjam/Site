using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;
using MatcomJamDAL.Models.MyModel;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace CodeFirstDatabase
{
    public class Comment
    {
        public int Id { get; set; } 
		public string UserId {get; set; }
		public int BlogId {get; set; }
        public string Description { get; set; }
		public ApplicationUser User {get; set; }
        public Blog Blog { get; set; }
    }
}
