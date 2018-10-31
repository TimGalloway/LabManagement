namespace LabManagementWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class alteredJobSampleOtherDetails : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Jobs", "SampleTypeOTHERDetails", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Jobs", "SampleTypeOTHERDetails", c => c.Boolean(nullable: false));
        }
    }
}
