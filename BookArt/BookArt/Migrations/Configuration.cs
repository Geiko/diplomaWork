namespace BookArt.Migrations
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<BookArt.Models.BookArtDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(BookArt.Models.BookArtDBContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            var books = new List<Book>();
            books.Add(new Book { Description = "blab", CoverURL = "/Content/Books/1/Cover.jpg" });
            books.Add(new Book { Description = "blab", CoverURL = "/Content/Books/2/Cover.jpg" });
            books.Add(new Book { Description = "blab", CoverURL = "/Content/Books/3/Cover.jpg" });
            books.Add(new Book { Description = "blab", CoverURL = "/Content/Books/4/Cover.jpg" });
            books.Add(new Book { Description = "blab", CoverURL = "/Content/Books/5/Cover.jpg" });
            books.Add(new Book { Description = "blab", CoverURL = "/Content/Books/6/Cover.jpg" });
            books.Add(new Book { Description = "blab", CoverURL = "/Content/Books/7/Cover.jpg" });
            books.Add(new Book { Description = "blab", CoverURL = "/Content/Books/8/Cover.jpg" });
            books.ForEach(s => context.Books.Add(s));

            var feedbacks = new List<Feedback>();
            feedbacks.Add(new Feedback { UsersEmail = "testEmail", Content = "testContent", Date = DateTime.Now });
            feedbacks.ForEach(s => context.Feedbacks.Add(s));

            context.SaveChanges();
        }
    }
}
