﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CodeFirstDatabase
{
    public class ProblemContest
    {
        public int Id { get; set; }
        public int ContestId { get; set; }
        public int ProblemId { get; set; }
        public string Description { get; set; }
        public virtual Contest Constest { get; set; }
        public virtual Problem Problem { get; set; }
        public List<Solution> Solutions { get; set; }
    }
}