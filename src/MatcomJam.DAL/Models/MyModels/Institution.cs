﻿using System.ComponentModel.DataAnnotations;
using System.Net.Mime;
using System.Reflection;

namespace CodeFirstDatabase
{
    public class Institution
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public string Logo { get; set; }
    }
}
