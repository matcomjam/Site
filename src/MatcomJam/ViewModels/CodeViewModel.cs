using System;

namespace MatcomJam.ViewModels
{
    public class CodeViewModel
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public string Text { get; set; }
        public string Status { get; set; }
        public int ProblemId { get; set; }
        public int LanguageId { get; set; }
        public string UserId { get; set; }

        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
