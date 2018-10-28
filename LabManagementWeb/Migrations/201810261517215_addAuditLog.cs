namespace LabManagementWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addAuditLog : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AuditLogs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        AuditTime = c.DateTime(nullable: false),
                        AuditUser = c.String(),
                        AuditAction = c.String(),
                        DateCreated = c.DateTime(),
                        UserCreated = c.String(),
                        DateModified = c.DateTime(),
                        UserModified = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.AuditLogs");
        }
    }
}
