namespace MyVIPNetApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBlogCreate1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.test3", "content", c => c.String(maxLength: 1000));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.test3", "content", c => c.String(maxLength: 100));
        }
    }
}
