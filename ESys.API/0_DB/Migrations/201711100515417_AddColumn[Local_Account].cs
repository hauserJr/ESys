namespace ESys.DB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddColumnLocal_Account : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Local_Account", "CreateDateTime", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Local_Account", "CreateDateTime");
        }
    }
}
