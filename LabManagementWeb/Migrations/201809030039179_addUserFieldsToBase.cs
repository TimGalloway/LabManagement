namespace LabManagementWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addUserFieldsToBase : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Clients", "UserCreated", c => c.String());
            AddColumn("dbo.Clients", "UserModified", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Clients", "UserModified");
            DropColumn("dbo.Clients", "UserCreated");
        }
    }
}
