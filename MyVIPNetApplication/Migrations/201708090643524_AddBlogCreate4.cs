namespace MyVIPNetApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBlogCreate4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.User", "CC", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.User", "CC");
        }
    }
}
