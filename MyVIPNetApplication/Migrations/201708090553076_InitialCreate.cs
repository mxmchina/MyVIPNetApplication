namespace MyVIPNetApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Company",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 500),
                        CreateTime = c.DateTime(nullable: false),
                        CreatorId = c.Int(nullable: false),
                        LastModifierId = c.Int(),
                        LastModifyTime = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.test1",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.test2",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(maxLength: 50),
                        type = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                        Account = c.String(nullable: false, maxLength: 100, unicode: false),
                        Password = c.String(nullable: false, maxLength: 100, unicode: false),
                        Email = c.String(maxLength: 200, unicode: false),
                        Mobile = c.String(maxLength: 30, unicode: false),
                        CompanyId = c.Int(),
                        CompanyName = c.String(maxLength: 500),
                        State = c.Int(nullable: false),
                        UserType = c.Int(nullable: false),
                        LastLoginTime = c.DateTime(),
                        CreateTime = c.DateTime(nullable: false),
                        CreatorId = c.Int(nullable: false),
                        LastModifierId = c.Int(),
                        LastModifyTime = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.User");
            DropTable("dbo.test2");
            DropTable("dbo.test1");
            DropTable("dbo.Company");
        }
    }
}
