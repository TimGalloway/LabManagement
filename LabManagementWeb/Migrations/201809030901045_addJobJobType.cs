namespace LabManagementWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addJobJobType : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Jobs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Elements = c.String(),
                        Standards = c.String(),
                        DateCreated = c.DateTime(),
                        UserCreated = c.String(),
                        DateModified = c.DateTime(),
                        UserModified = c.String(),
                        JobType_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.JobTypes", t => t.JobType_ID)
                .Index(t => t.JobType_ID);
            
            CreateTable(
                "dbo.JobTypes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        DateCreated = c.DateTime(),
                        UserCreated = c.String(),
                        DateModified = c.DateTime(),
                        UserModified = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Jobs", "JobType_ID", "dbo.JobTypes");
            DropIndex("dbo.Jobs", new[] { "JobType_ID" });
            DropTable("dbo.JobTypes");
            DropTable("dbo.Jobs");
        }
    }
}
