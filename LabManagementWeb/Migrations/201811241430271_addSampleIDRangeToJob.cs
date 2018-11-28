namespace LabManagementWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addSampleIDRangeToJob : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Jobs", "SampleIDStart", c => c.Int(nullable: false));
            AddColumn("dbo.Jobs", "SampleIDEnd", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Jobs", "SampleIDEnd");
            DropColumn("dbo.Jobs", "SampleIDStart");
        }
    }
}
