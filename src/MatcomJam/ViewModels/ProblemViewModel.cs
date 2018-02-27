using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodeFirstDatabase;

namespace QuickApp.ViewModels
{
    public class ProblemViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }
        public string Tag { get; set; }
        public string Description { get; set; }
        public int TimeLimit { get; set; }
        public int MemoryLimit { get; set; }
        public int MaximumMessages { get; set; }
        public int NumberOfNodes { get; set; }
        public int SizeOfMessages { get; set; }
    }
}
