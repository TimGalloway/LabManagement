namespace LabManagementWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeBarCodeImageToString : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Samples", "BarCodeImage", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Samples", "BarCodeImage", c => c.Binary());
        }
    }
}
