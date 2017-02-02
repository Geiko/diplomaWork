using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BookArt.Models
{
    public class BookArtDBContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
    }
}