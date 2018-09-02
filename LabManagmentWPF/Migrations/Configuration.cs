namespace LabManagmentWPF.Migrations
{
    using LabManagementWPF;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<LabManagementWPF.LabManagementWPF_model>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(LabManagementWPF.LabManagementWPF_model context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            IList<Client> defaultClients = new List<Client>();
            defaultClients.Add(new Client() {
                Name = "Test Client 1",
                Address = "1 Smith Street",
                PhoneNumber = "12345",
                ContactName = "Mr Smith",
                PostalAddress = "1 Jones Street"
            });
            defaultClients.Add(new Client() {
                Name = "Test Client 2",
                Address = "2 Smith Street",
                PhoneNumber = "12345",
                ContactName = "Mr Smith",
                PostalAddress = "1 Jones Street"
            });
            defaultClients.Add(new Client() {
                Name = "Test Client 3",
                Address = "3 Smith Street",
                PhoneNumber = "12345",
                ContactName = "Mr Smith",
                PostalAddress = "1 Jones Street"
            });
            defaultClients.Add(new Client() {
                Name = "Test Client 4",
                Address = "4 Smith Street",
                PhoneNumber = "12345",
                ContactName = "Mr Smith",
                PostalAddress = "1 Jones Street"
            });
            defaultClients.Add(new Client() {
                Name = "Test Client 5",
                Address = "5 Smith Street",
                PhoneNumber = "12345",
                ContactName = "Mr Smith",
                PostalAddress = "1 Jones Street"
            });
            context.Clients.AddRange(defaultClients);
        }
    }
}
