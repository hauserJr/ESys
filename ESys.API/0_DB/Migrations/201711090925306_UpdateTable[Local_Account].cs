namespace ESys.DB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateTableLocal_Account : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Local_Account", "EmailCheck", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Local_Account", "EmailCheck");
        }
    }
}
