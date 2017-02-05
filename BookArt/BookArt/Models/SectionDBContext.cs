using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BookArt.Models
{
    public class SectionDBContext : DbContext
    {
        public DbSet<Section> Sections { get; set; }
        public DbSet<Work> Works { get; set; }
        public DbSet<Page> Pages { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
    }
}