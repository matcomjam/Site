using System;
using MatcomJamDAL.Models.MyModel;
using MatcomJamDAL.Models.MyModel.interfaces;

namespace CodeFirstDatabase
{
    public class Comment : IAuditableEntity
    {
        public int Id { get; set; }
        public string Change { get; set; }
        public string UserId { get; set; }
        public int BlogId { get; set; }
        public string Description { get; set; }
        public ApplicationUser User { get; set; }
        public Blog Blog { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
