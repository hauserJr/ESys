namespace ESys.DB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateTableRSA_Key : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RSA_Key",
                c => new
                    {
                        RSA_Guid = c.Guid(nullable: false),
                        PublicKey = c.String(),
                        PrivateKey = c.String(),
                        RSA_Type = c.String(),
                    })
                .PrimaryKey(t => t.RSA_Guid);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.RSA_Key");
        }
    }
}
