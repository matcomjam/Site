using System;

namespace MatcomJam.ViewModels
{
    public class CommentViewModel
    {
        public int Id { get; set; }
        public string Change { get; set; }
        public string UserId { get; set; }
        public int BlogId { get; set; }
        public string Description { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
