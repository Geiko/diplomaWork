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
                SectionId = 1,
                Number = 1,
                Name = "Nikolaev Medalon",
                CoverUrl = "/Content/Images/Works/1/WorkCover_1.jpg"
            });



            var sections = new List<Section>();
            sections.Add(new Section
            {
                Number = 1,
                Title = "Книга",
                CoverUrl = "/Content/Images/Sections/SectionCover_1.jpg",
                Works = works
            });
            sections.Add(new Section
            {
                Number = 2,
                Title = "Айдентика",
                CoverUrl = "/Content/Images/Sections/SectionCover_2.jpg"
            });
            sections.Add(new Section
            {
                Number = 3,
                Title = "Геральдика",
                CoverUrl = "/Content/Images/Sections/SectionCover_3.jpg"
            });
            sections.Add(new Section
            {
                Number = 4,
                Title = "Композиції",
                CoverUrl = "/Content/Images/Sections/SectionCover_4.jpg"
            });
            sections.Add(new Section
            {
                Number = 5,
                Title = "Книга в шкірі",
                CoverUrl = "/Content/Images/Sections/SectionCover_5.jpg"
            });
            sections.Add(new Section
            {
                Number = 6,
                Title = "Інтер'єр",
                CoverUrl = "/Content/Images/Sections/SectionCover_6.jpg"
            });
            sections.Add(new Section
            {
                Number = 7,
                Title = "Дизайн",
                CoverUrl = "/Content/Images/Sections/SectionCover_7.jpg"
            });
            sections.Add(new Section
            {
                Number = 8,
                Title = "Каліграфія",
                CoverUrl = "/Content/Images/Sections/SectionCover_8.jpg"
            });

            sections.ForEach(s => context.Sections.Add(s));


            var feedbacks = new List<Feedback>();
            feedbacks.Add(new Feedback
            {
                UsersEmail = "testEmail",
                Content = "testContent",
                Date = DateTime.Now
            });

            feedbacks.ForEach(s => context.Feedbacks.Add(s));



            context.SaveChanges();
        }
    }
}
