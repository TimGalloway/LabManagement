namespace LabManagementWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addBarCodeImageToSample : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Samples", "BarCodeImage", c => c.Binary());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Samples", "BarCodeImage");
        }
    }
}
