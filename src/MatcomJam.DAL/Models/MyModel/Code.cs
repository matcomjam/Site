using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using CodeFirstDatabase;
using MatcomJamDAL.Models.MyModel.interfaces;
using Microsoft.AspNetCore.Http;

namespace MatcomJamDAL.Models.MyModel
{
    public class Code : IAuditableEntity
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string FileName { get; set; }
        [NotMapped]
        public IFormFile file { get; set; }
        public string Text { get; set; }
        public string Status { get; set; }
        public int ProblemId { get; set; }
        public Problem Problem { get; set; }
        public int LanguageId { get; set; }
        public Language Language { get; set; }
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }

        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
