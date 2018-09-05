namespace LabManagementWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addJobNumberToJob : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Jobs", "JobNumber", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Jobs", "JobNumber");
        }
    }
}
