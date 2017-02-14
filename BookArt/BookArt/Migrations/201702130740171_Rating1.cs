namespace BookArt.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Rating1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Sections", "CoverUrl", c => c.String(maxLength: 300));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Sections", "CoverUrl", c => c.String());
        }
    }
}
