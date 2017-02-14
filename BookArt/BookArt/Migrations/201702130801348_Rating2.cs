namespace BookArt.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Rating2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Pages", "ImgUrl", c => c.String(maxLength: 300));
            AlterColumn("dbo.Works", "CoverUrl", c => c.String(maxLength: 300));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Works", "CoverUrl", c => c.String());
            AlterColumn("dbo.Pages", "ImgUrl", c => c.String());
        }
    }
}
