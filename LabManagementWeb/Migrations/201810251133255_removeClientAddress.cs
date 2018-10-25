namespace LabManagementWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeClientAddress : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Clients", "ClientAddress_ClientAddressID", "dbo.ClientAddresses");
            DropForeignKey("dbo.ClientAddresses", "ClientAddressType_ClientAddressTypeID", "dbo.ClientAddressTypes");
            DropIndex("dbo.Clients", new[] { "ClientAddress_ClientAddressID" });
            DropIndex("dbo.ClientAddresses", new[] { "ClientAddressType_ClientAddressTypeID" });
            DropColumn("dbo.Clients", "ClientAddress_ClientAddressID");
            DropTable("dbo.ClientAddresses");
            DropTable("dbo.ClientAddressTypes");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ClientAddressTypes",
                c => new
                    {
                        ClientAddressTypeID = c.Int(nullable: false, identity: true),
                        ClientAddressTypeDescription = c.String(),
                        DateCreated = c.DateTime(),
                        UserCreated = c.String(),
                        DateModified = c.DateTime(),
                        UserModified = c.String(),
                    })
                .PrimaryKey(t => t.ClientAddressTypeID);
            
            CreateTable(
                "dbo.ClientAddresses",
                c => new
                    {
                        ClientAddressID = c.Int(nullable: false, identity: true),
                        ClientAddressName = c.String(),
                        ClientAddressContact = c.String(),
                        ClientAddressLine1 = c.String(),
                        ClientAddressLine2 = c.String(),
                        ClientAddressEmail = c.String(),
                        ClientAddressPhone = c.String(),
                        ClientAddressFax = c.String(),
                        DateCreated = c.DateTime(),
                        UserCreated = c.String(),
                        DateModified = c.DateTime(),
                        UserModified = c.String(),
                        ClientAddressType_ClientAddressTypeID = c.Int(),
                    })
                .PrimaryKey(t => t.ClientAddressID);
            
            AddColumn("dbo.Clients", "ClientAddress_ClientAddressID", c => c.Int());
            CreateIndex("dbo.ClientAddresses", "ClientAddressType_ClientAddressTypeID");
            CreateIndex("dbo.Clients", "ClientAddress_ClientAddressID");
            AddForeignKey("dbo.ClientAddresses", "ClientAddressType_ClientAddressTypeID", "dbo.ClientAddressTypes", "ClientAddressTypeID");
            AddForeignKey("dbo.Clients", "ClientAddress_ClientAddressID", "dbo.ClientAddresses", "ClientAddressID");
        }
    }
}
