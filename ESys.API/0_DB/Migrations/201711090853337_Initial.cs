namespace ESys.DB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FB_Account",
                c => new
                    {
                        FBAccount_Guid = c.Guid(nullable: false),
                        Email = c.String(maxLength: 200),
                        ProviderKey = c.String(maxLength: 200),
                    })
                .PrimaryKey(t => t.FBAccount_Guid);
            
            CreateTable(
                "dbo.Local_Account",
                c => new
                    {
                        Account_Guid = c.Guid(nullable: false),
                        UserAccount = c.String(maxLength: 50),
                        Password = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Account_Guid);
            
            CreateTable(
                "dbo.MemberTypes",
                c => new
                    {
                        MemberType_Guid = c.Guid(nullable: false),
                        MemberType_Name = c.String(maxLength: 50),
                        MemberType_Code = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.MemberType_Guid);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.MemberTypes");
            DropTable("dbo.Local_Account");
            DropTable("dbo.FB_Account");
        }
    }
}
