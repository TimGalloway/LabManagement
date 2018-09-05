namespace LabManagementWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class a : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Jobs", "JobType_ID", "dbo.JobTypes");
            DropIndex("dbo.Jobs", new[] { "JobType_ID" });
            AddColumn("dbo.Jobs", "JobType_ID1", c => c.Int());
            AlterColumn("dbo.Jobs", "JobType_ID", c => c.Int(nullable: false));
            CreateIndex("dbo.Jobs", "JobType_ID1");
            AddForeignKey("dbo.Jobs", "JobType_ID1", "dbo.JobTypes", "ID");
            DropColumn("dbo.Jobs", "JobTypeID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Jobs", "JobTypeID", c => c.String());
            DropForeignKey("dbo.Jobs", "JobType_ID1", "dbo.JobTypes");
            DropIndex("dbo.Jobs", new[] { "JobType_ID1" });
            AlterColumn("dbo.Jobs", "JobType_ID", c => c.Int());
            DropColumn("dbo.Jobs", "JobType_ID1");
            CreateIndex("dbo.Jobs", "JobType_ID");
            AddForeignKey("dbo.Jobs", "JobType_ID", "dbo.JobTypes", "ID");
        }
    }
}
