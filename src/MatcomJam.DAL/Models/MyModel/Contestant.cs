using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;
using MatcomJamDAL.Models.MyModel;

namespace CodeFirstDatabase
{
    public class Contestant : ApplicationUser
    {
        public string ContestantId { get; set; }

        public int ContestId { get; set; }
        public int TeamId { get; set; }
        
		public Contest Contest { get; set; }
        public Team Team { get; set; }
        public ICollection<Solution> Solutions { get; set; }
    }
}
