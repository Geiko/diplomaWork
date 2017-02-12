namespace BookArt.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Seed1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Feedbacks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UsersEmail = c.String(nullable: false, maxLength: 80),
                        Content = c.String(nullable: false),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Pages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        WorkId = c.Int(nullable: false),
                        Number = c.Int(nullable: false),
                        ImgUrl = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Works", t => t.WorkId, cascadeDelete: true)
                .Index(t => t.WorkId);
            
            CreateTable(
                "dbo.Sections",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Number = c.Int(nullable: false),
                        Title = c.String(),
                        CoverUrl = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Works",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SectionId = c.Int(nullable: false),
                        Number = c.Int(nullable: false),
                        Name = c.String(),
                        CoverUrl = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Sections", t => t.SectionId, cascadeDelete: true)
                .Index(t => t.SectionId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Works", "SectionId", "dbo.Sections");
            DropForeignKey("dbo.Pages", "WorkId", "dbo.Works");
            DropIndex("dbo.Works", new[] { "SectionId" });
            DropIndex("dbo.Pages", new[] { "WorkId" });
            DropTable("dbo.Works");
            DropTable("dbo.Sections");
            DropTable("dbo.Pages");
            DropTable("dbo.Feedbacks");
        }
    }
}
