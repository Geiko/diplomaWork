namespace BookArt.Migrations
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<BookArt.Models.SectionDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(BookArt.Models.SectionDBContext context)
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


            var works = new List<Work>();
            works.Add(new Work
            {
                Name = "Nikolaev Medalon",
                CoverUrl = "/Content/Images/Work/1/Cover.jpg",
                SectionId = 1
            });

            var sections = new List<Section>();
            sections.Add(new Section
            {
                Title = "blab",
                CoverURL = "/Content/Images/Sections/1/Cover.jpg",
                Works = works
            });
            sections.Add(new Section { Title = "blab", CoverURL = "/Content/Images/Sections/2/Cover.jpg" });
            sections.Add(new Section { Title = "blab", CoverURL = "/Content/Images/Sections/3/Cover.jpg" });
            sections.Add(new Section { Title = "blab", CoverURL = "/Content/Images/Sections/4/Cover.jpg" });
            sections.Add(new Section { Title = "blab", CoverURL = "/Content/Images/Sections/5/Cover.jpg" });
            sections.Add(new Section { Title = "blab", CoverURL = "/Content/Images/Sections/6/Cover.jpg" });
            sections.Add(new Section { Title = "blab", CoverURL = "/Content/Images/Sections/7/Cover.jpg" });
            sections.Add(new Section { Title = "blab", CoverURL = "/Content/Images/Sections/8/Cover.jpg" });
            sections.ForEach(s => context.Sections.Add(s));


            var feedbacks = new List<Feedback>();
            feedbacks.Add(new Feedback { UsersEmail = "testEmail", Content = "testContent", Date = DateTime.Now });
            feedbacks.ForEach(s => context.Feedbacks.Add(s));

            context.SaveChanges();
        }
    }
}
