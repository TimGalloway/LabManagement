namespace LabManagementWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addJobTypeIDToJob : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Jobs", "JobTypeID", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Jobs", "JobTypeID");
        }
    }
}
