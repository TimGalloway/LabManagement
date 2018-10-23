namespace LabManagementWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addClientAddress : DbMigration
    {
        public override void Up()
        {
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
                .PrimaryKey(t => t.ClientAddressID)
                .ForeignKey("dbo.ClientAddressTypes", t => t.ClientAddressType_ClientAddressTypeID)
                .Index(t => t.ClientAddressType_ClientAddressTypeID);
            
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
            
            AddColumn("dbo.Clients", "ClientAddress_ClientAddressID", c => c.Int());
            CreateIndex("dbo.Clients", "ClientAddress_ClientAddressID");
            AddForeignKey("dbo.Clients", "ClientAddress_ClientAddressID", "dbo.ClientAddresses", "ClientAddressID");
            DropColumn("dbo.Clients", "Address");
            DropColumn("dbo.Clients", "PhoneNumber");
            DropColumn("dbo.Clients", "PostalAddress");
            DropColumn("dbo.Clients", "ContactName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Clients", "ContactName", c => c.String());
            AddColumn("dbo.Clients", "PostalAddress", c => c.String());
            AddColumn("dbo.Clients", "PhoneNumber", c => c.String());
            AddColumn("dbo.Clients", "Address", c => c.String());
            DropForeignKey("dbo.ClientAddresses", "ClientAddressType_ClientAddressTypeID", "dbo.ClientAddressTypes");
            DropForeignKey("dbo.Clients", "ClientAddress_ClientAddressID", "dbo.ClientAddresses");
            DropIndex("dbo.ClientAddresses", new[] { "ClientAddressType_ClientAddressTypeID" });
            DropIndex("dbo.Clients", new[] { "ClientAddress_ClientAddressID" });
            DropColumn("dbo.Clients", "ClientAddress_ClientAddressID");
            DropTable("dbo.ClientAddressTypes");
            DropTable("dbo.ClientAddresses");
        }
    }
}
