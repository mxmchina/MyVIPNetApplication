namespace MyVIPNetApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBlogCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.test3",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(maxLength: 50),
                        type = c.Int(nullable: false),
                        content = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.test3");
        }
    }
}
