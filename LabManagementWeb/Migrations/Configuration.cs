namespace LabManagementWeb.Migrations
{
    using LabManagementWeb.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<LabManagementWeb.Models.ApplicationDBContext>
    {
        private bool _pendingMigrations;

        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            //var migrator = new DbMigrator(this);
            //_pendingMigrations = migrator.GetPendingMigrations().Any();

            // If there are pending migrations run migrator.Update() to create/update the
            // database then run the Seed() method to populate the data if necessary.
            //if (_pendingMigrations)
            //{
            //    migrator.Update();
            //}
        }

        protected override void Seed(LabManagementWeb.Models.ApplicationDBContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            IList<Client> defaultClients = new List<Client>();
            defaultClients.Add(new Client()
            {
                Name = "Test Client 1",
                Address = "1 Smith Street",
                PhoneNumber = "12345",
                ContactName = "Mr Smith",
                PostalAddress = "1 Jones Street"
            });
            defaultClients.Add(new Client()
            {
                Name = "Test Client 2",
                Address = "2 Smith Street",
                PhoneNumber = "12345",
                ContactName = "Mr Smith",
                PostalAddress = "2 Jones Street"
            });
            defaultClients.Add(new Client()
            {
                Name = "Test Client 3",
                Address = "3 Smith Street",
                PhoneNumber = "12345",
                ContactName = "Mr Smith",
                PostalAddress = "3 Jones Street"
            });
            defaultClients.Add(new Client()
            {
                Name = "Test Client 4",
                Address = "4 Smith Street",
                PhoneNumber = "12345",
                ContactName = "Mr Smith",
                PostalAddress = "4 Jones Street"
            });
            defaultClients.Add(new Client()
            {
                Name = "Test Client 5",
                Address = "5 Smith Street",
                PhoneNumber = "12345",
                ContactName = "Mr Smith",
                PostalAddress = "5 Jones Street"
            });
            context.Clients.AddRange(defaultClients);

            IList<JobType> defaultJobTypes = new List<JobType>();
            defaultJobTypes.Add(new JobType()
            {
                Description = "Internal",
                Prefix = "i"
            });
            defaultJobTypes.Add(new JobType()
            {
                Description = "Normal",
                Prefix = "u"
            });
            context.JobTypes.AddRange(defaultJobTypes);

            IList<Job> defaultJobs = new List<Job>();
            defaultJobs.Add(new Job()
            {
                JobNumber = "i1",
                Elements = "Test Elements 1",
                Standards = "Test Standards 1",
                JobType = defaultJobTypes.SingleOrDefault(a => a.Description == "Internal"),
                JobType_ID = 1
            });
            defaultJobs.Add(new Job()
            {
                JobNumber = "u2",
                Elements = "Test Elements 2",
                Standards = "Test Standards 2",
                JobType = defaultJobTypes.SingleOrDefault(a => a.Description == "Normal"),
                JobType_ID = 2
            });
            context.Jobs.AddRange(defaultJobs);

            IList<UserProfile> defaultUserProfile = new List<UserProfile>();
            defaultUserProfile.Add(new UserProfile()
            {
                UserName = "tim",
                Password = "tl1000"
            });
            context.UserProfiles.AddRange(defaultUserProfile);
        }
    }   
    }
