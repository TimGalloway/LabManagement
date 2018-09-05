namespace LabManagementWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addPrefixToJobType : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.JobTypes", "Prefix", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.JobTypes", "Prefix");
        }
    }
}
