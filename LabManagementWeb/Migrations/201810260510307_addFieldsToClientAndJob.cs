namespace LabManagementWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addFieldsToClientAndJob : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Clients", "Company", c => c.String());
            AddColumn("dbo.Clients", "MailingAddress", c => c.String());
            AddColumn("dbo.Clients", "EmailAddress", c => c.String());
            AddColumn("dbo.Clients", "PhoneNumber", c => c.String());
            AddColumn("dbo.Clients", "FaxNumber", c => c.String());
            AddColumn("dbo.Clients", "SendInvToSame", c => c.Boolean(nullable: false));
            AddColumn("dbo.Clients", "InvoiceName", c => c.String());
            AddColumn("dbo.Clients", "InvoiceCompany", c => c.String());
            AddColumn("dbo.Clients", "InvoiceMailingAddress", c => c.String());
            AddColumn("dbo.Clients", "InvoiceEmailAddress", c => c.String());
            AddColumn("dbo.Clients", "InvoicePhoneNumber", c => c.String());
            AddColumn("dbo.Clients", "InvoiceFaxNumber", c => c.String());
            AddColumn("dbo.Jobs", "SubmissionReference", c => c.String());
            AddColumn("dbo.Jobs", "BulkaBagNumber", c => c.String());
            AddColumn("dbo.Jobs", "ClientOrder", c => c.String());
            AddColumn("dbo.Jobs", "SendReportQLAB", c => c.Boolean(nullable: false));
            AddColumn("dbo.Jobs", "SendReportEmail", c => c.Boolean(nullable: false));
            AddColumn("dbo.Jobs", "SendReportOther", c => c.Boolean(nullable: false));
            AddColumn("dbo.Jobs", "SendReportOtherDetails", c => c.String());
            AddColumn("dbo.Jobs", "Dispose", c => c.Boolean(nullable: false));
            AddColumn("dbo.Jobs", "Stored", c => c.Boolean(nullable: false));
            AddColumn("dbo.Jobs", "StoredUntil", c => c.DateTime(nullable: false));
            AddColumn("dbo.Jobs", "ReturnedToClient", c => c.Boolean(nullable: false));
            AddColumn("dbo.Jobs", "ReturnByCourier", c => c.String());
            AddColumn("dbo.Jobs", "ReturnByCourierAccnt", c => c.String());
            AddColumn("dbo.Jobs", "SampleTypeRABRC", c => c.Boolean(nullable: false));
            AddColumn("dbo.Jobs", "SampleTypeMETPLANT", c => c.Boolean(nullable: false));
            AddColumn("dbo.Jobs", "SampleTypeUMPIREPARTY", c => c.Boolean(nullable: false));
            AddColumn("dbo.Jobs", "SampleTypePULPS", c => c.Boolean(nullable: false));
            AddColumn("dbo.Jobs", "SampleTypeSOILS", c => c.Boolean(nullable: false));
            AddColumn("dbo.Jobs", "SampleTypeCOREROCKS", c => c.Boolean(nullable: false));
            AddColumn("dbo.Jobs", "SampleTypeSOLUTIONS", c => c.Boolean(nullable: false));
            AddColumn("dbo.Jobs", "SampleTypesMMI", c => c.Boolean(nullable: false));
            AddColumn("dbo.Jobs", "SampleTypeOTHER", c => c.Boolean(nullable: false));
            AddColumn("dbo.Jobs", "SampleTypeOTHERDetails", c => c.Boolean(nullable: false));
            DropColumn("dbo.Jobs", "Elements");
            DropColumn("dbo.Jobs", "Standards");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Jobs", "Standards", c => c.String());
            AddColumn("dbo.Jobs", "Elements", c => c.String());
            DropColumn("dbo.Jobs", "SampleTypeOTHERDetails");
            DropColumn("dbo.Jobs", "SampleTypeOTHER");
            DropColumn("dbo.Jobs", "SampleTypesMMI");
            DropColumn("dbo.Jobs", "SampleTypeSOLUTIONS");
            DropColumn("dbo.Jobs", "SampleTypeCOREROCKS");
            DropColumn("dbo.Jobs", "SampleTypeSOILS");
            DropColumn("dbo.Jobs", "SampleTypePULPS");
            DropColumn("dbo.Jobs", "SampleTypeUMPIREPARTY");
            DropColumn("dbo.Jobs", "SampleTypeMETPLANT");
            DropColumn("dbo.Jobs", "SampleTypeRABRC");
            DropColumn("dbo.Jobs", "ReturnByCourierAccnt");
            DropColumn("dbo.Jobs", "ReturnByCourier");
            DropColumn("dbo.Jobs", "ReturnedToClient");
            DropColumn("dbo.Jobs", "StoredUntil");
            DropColumn("dbo.Jobs", "Stored");
            DropColumn("dbo.Jobs", "Dispose");
            DropColumn("dbo.Jobs", "SendReportOtherDetails");
            DropColumn("dbo.Jobs", "SendReportOther");
            DropColumn("dbo.Jobs", "SendReportEmail");
            DropColumn("dbo.Jobs", "SendReportQLAB");
            DropColumn("dbo.Jobs", "ClientOrder");
            DropColumn("dbo.Jobs", "BulkaBagNumber");
            DropColumn("dbo.Jobs", "SubmissionReference");
            DropColumn("dbo.Clients", "InvoiceFaxNumber");
            DropColumn("dbo.Clients", "InvoicePhoneNumber");
            DropColumn("dbo.Clients", "InvoiceEmailAddress");
            DropColumn("dbo.Clients", "InvoiceMailingAddress");
            DropColumn("dbo.Clients", "InvoiceCompany");
            DropColumn("dbo.Clients", "InvoiceName");
            DropColumn("dbo.Clients", "SendInvToSame");
            DropColumn("dbo.Clients", "FaxNumber");
            DropColumn("dbo.Clients", "PhoneNumber");
            DropColumn("dbo.Clients", "EmailAddress");
            DropColumn("dbo.Clients", "MailingAddress");
            DropColumn("dbo.Clients", "Company");
        }
    }
}
