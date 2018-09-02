namespace LabManagementWPF
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class LabManagement_model : DbContext
    {
        // Your context has been configured to use a 'LabManagement_model' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'LabManagement.LabManagement_model' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'LabManagement_model' 
        // connection string in the application configuration file.
        public LabManagement_model()
            : base("name=LabManagement_model")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<Client> Clients { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}

    public class Client
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
    }
}