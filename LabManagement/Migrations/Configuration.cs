namespace LabManagementWPF.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<LabManagementWPF.LabManagement_model>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(LabManagementWPF.LabManagement_model context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            IList<Client> defaultClients = new List<Client>();
            defaultClients.Add(new Client() { Name = "Test Client 1" });
            defaultClients.Add(new Client() { Name = "Test Client 2" });
            defaultClients.Add(new Client() { Name = "Test Client 3" });
            defaultClients.Add(new Client() { Name = "Test Client 4" });
            defaultClients.Add(new Client() { Name = "Test Client 5" });
            context.Clients.AddRange(defaultClients);
        }
    }
}
